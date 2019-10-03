set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go


ALTER PROC [dbo].[CalcMftCharge_RangeV2] @@PlanID AS int, @@InvNo AS varchar(20), @@FromCustID AS varchar(10), @@StartDate as varchar(20), @@EndDate as varchar(20), @@FROMZONE as int, @@TOZONE as int, @@TABLENAME as varchar(100), @@COLNAME as varchar(20), @@INV_PATH as varchar(100)
AS
declare @FRZ as varchar(500)
declare @TZ as varchar(500)
declare @DateCond as varchar(500)
declare @UPDQ as varchar(2900)
--declare @INVLIQ as varchar(2900)

-- Additional Conditions
declare @CONDTMP as varchar(200)
declare @ADDCOND as varchar(2000)
--declare @LastCondID as int 
SELECT @ADDCOND = ''

Declare @CondSQL as varchar(800)
Select @CondSQL = 'DECLARE csrConds CURSOR
FOR Select '' mft.''+ColumnName+'' ''+Operator+'' ''''''+[Values]+'''''' '' as Condition 
from ' + @@INV_PATH + 'PricePlanCondition where PlanID = ' + convert(varchar, @@PLANID) + ' order by Rowid '

Exec SP_ExecuteSQL @CondSQL;

--DECLARE csrConds CURSOR
--FOR
--Select ' mft.'+ColumnName+' '+Operator+' '''+[Values]+''' ' as Condition 
--from PricePlanCondition where PlanID = @@PLANID order by Rowid 

OPEN csrConds
FETCH NEXT FROM csrConds INTO @CONDTMP
print '@CONDTMP = ' + @CONDTMP
WHILE (@@FETCH_STATUS <> -1)
BEGIN
   IF (@@FETCH_STATUS <> -2)
   BEGIN   
      IF @ADDCOND = ''
         SELECT @ADDCOND = RTRIM(@CONDTMP) 
      ELSE
         SELECT @ADDCOND = @ADDCOND + ' AND ' + RTRIM(@CONDTMP) 
   END
   print '@ADDCOND = ' + @ADDCOND
   FETCH NEXT FROM csrConds INTO @CONDTMP
   print '@CONDTMP = ' + @CONDTMP
END
CLOSE csrConds
DEALLOCATE csrConds
IF @ADDCOND <> ''
	Select @ADDCOND = ' AND ('+@ADDCOND+')'
-- End Additional Conditions

--Select TOP 1 @ADDCOND = TableName+'.dbo.'+ColumnName+' '+Opertor+' '+[Values] from PricePlanCondition where PlanID = @@PLANID and rowid > @LastCondID order by Rowid 

if @@FROMZONE = 0
Select @FRZ = ''
else
Select @FRZ = ' AND substring(mft.FromZip, 1, 5) in (Select substring(zip, 1, 5) from ' + @@INV_PATH + 'PricePlanZoneZip where ZoneID = ' + convert(varchar, @@FROMZONE) + ' ) '

if @@TOZONE = 0
Select @TZ = ''
else
Select @TZ = ' AND substring(mft.ToZip, 1, 5) in (Select Substring(zip, 1, 5) from ' + @@INV_PATH + 'PricePlanZoneZip where ZoneID = ' + convert(varchar, @@TOZONE) + ' ) '

if @@EndDate = ''
Select @DateCond = ' AND mft.[datetime] >= ''' + @@startdate + ''''
else
Select @DateCond = ' AND mft.[datetime] >= ''' + @@StartDate + ''' and mft.[datetime] < dateadd(day, 1, ''' + @@EndDate + ''')'

-- Select @UPDQ = ' UPDATE ManifestInvoice
--  SET charge = (SELECT ppc.Charge FROM PricePlanCharges ppc WHERE (ceiling(mft.' + @@COLNAME + ') BETWEEN From_Range AND To_Range) AND ppc.planid = ' + convert(varchar, @@PlanID) + '), Invoice_No = ' + @@InvNo + ', PlanID = ' + convert(varchar, @@PlanID) +
-- ' FROM ManifestInvoice mft WHERE (FromCustID = ''' + @@FromCustID + ''') AND ((Invoice_No IS NULL) OR (RTRIM(Invoice_No) = '''')) ' + @DateCond

--Select @UPDQ = ' UPDATE ManifestInvoice
-- SET charge = (SELECT ppc.Charge FROM PricePlanCharges ppc WHERE (ceiling(mft.' + @@COLNAME + ') BETWEEN From_Range AND To_Range) AND ppc.planid = ' + convert(varchar, @@PlanID) + '), Invoice_No = ''' + @@InvNo + ''', PlanID = ' + convert(varchar, @@PlanID) + ', PlanIDs = convert(varchar, ISNULL(PlanIDs, ''-'')) + ' + convert(varchar, @@PlanID) + ' + ''-'' ' +
--' FROM ManifestInvoice mft WHERE (FromCustID = ''' + @@FromCustID + ''') AND mft.rowid not in (Select ili.MftRowID from InvoiceLineItems ili, Invoices i where ili.Invoice_No = i.Invoice_No and i.Closing_Date <= ''' + @@EndDate + ''' and ili.PlanID = ' + convert(varchar, @@PlanID) +')' + @DateCond

--ManifestInvoice
Select @UPDQ = ' UPDATE ' + @@TABLENAME  + 
 ' SET charge = (SELECT ppc.Charge FROM ' + @@INV_PATH + 'PricePlanCharges ppc WHERE (ceiling(mft.' + @@COLNAME + ') BETWEEN From_Range AND To_Range) AND ppc.planid = ' + convert(varchar, @@PlanID) + '), Invoice_No = ''' + @@InvNo + ''', PlanID = ' + convert(varchar, @@PlanID) + ', PlanIDs = convert(varchar, ISNULL(PlanIDs, ''-'')) + ''' + convert(varchar, @@PlanID) + ''' + ''-'' ' +
' FROM ' + @@TABLENAME  + ' mft WHERE (FromCustID = ''' + @@FromCustID + ''')  AND upper(ISNULL(mft.Void, ''F'')) = ''F'' ' + @DateCond


--print '1, UPDQ = '+@UPDQ+'FRZ = '+@FRZ+'TZ = '+@TZ
Select @UPDQ = @UPDQ + @FRZ + @TZ + @ADDCOND
print '2, '+@updq
-- return
exec(@UPDQ)
-- Invoice Title
Select @UPDQ = 'Insert into ' + @@INV_PATH + 'InvoiceLineItems(Invoice_No, Invoice_Date, Description, PlanID) ' +
' Select ''' + @@InvNo + ''' as Invoice_NO ' +
', (Select TOP 1 Invoice_Date from ' + @@INV_PATH + 'Invoices where invoice_No = ''' + @@INVNO + ''' ORDER BY INVOICE_dATE DESC) as Invoice_Date ' +
', pp.Invoice_Title as [Description] ' +
', pp.PlanID as PlanID ' +
' From ' + @@INV_PATH + 'PricePlans pp where pp.PlanID = ' + convert(varchar, @@PlanID) + ''

print '3, '+@updq
exec(@UPDQ)

Select @UPDQ = ' Insert into ' + @@INV_PATH + 'InvoiceLineItems(Invoice_No, Invoice_Date, TranDate, Charge_Code,  Description, UnitPrice, Prefix, Qty, Suffix, Unit, Charge, Tax, PlanID, MftRowID) ' +
' Select mftx.Invoice_NO ' +
', (Select TOP 1 Invoice_Date from ' + @@INV_PATH + 'Invoices where invoice_No = mftx.Invoice_No ORDER BY INVOICE_dATE DESC) as Invoice_Date ' +
', mftx.[DateTime] as TranDate ' +
', pp.Charge_Code as Charge_Code ' +
', pp.Description as [Description] ' +
', NULL as UnitPrice ' +
', pp.ColumnPrefix as Prefix ' +
', mftx.' + @@COLNAME + ' as Qty ' +
', '''' as suffix ' +
', pp.ColumnSuffix as unit ' +', mftx.Charge ' +
', (case pp.Taxable when 1 then ''T'' else '''' end) as Tax ' +
', mftx.PlanID as PlanID ' +
', mftx.RowID ' +
' From ' + @@TABLENAME  + ' mftx left outer join ' + @@INV_PATH + 'PricePlans pp on mftx.PlanID = pp.PlanID ' +
' where mftx.invoice_no = ''' + @@InvNo + ''' AND upper(ISNULL(mftx.Void, ''F'')) = ''F'' AND mftx.PlanID = ' + convert(varchar, @@PlanID) + ''

print '4, '+@updq
exec(@UPDQ)


