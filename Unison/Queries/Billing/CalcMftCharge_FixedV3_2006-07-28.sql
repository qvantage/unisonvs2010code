set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

ALTER PROC [dbo].[CalcMftCharge_FixedV3] @@PlanID AS int, @@InvNo AS varchar(20), @@FromCustID AS varchar(10), @@StartDate as varchar(20), @@EndDate as varchar(20), @@FROMZONE as int, @@TOZONE as int, @@TABLENAME as varchar(100), @@COLNAME as varchar(20), @@INV_PATH as varchar(100)
AS
declare @FRZ as varchar(200)
declare @TZ as varchar(200)
declare @DateCond as varchar(200)
declare @UPDQ as varchar(2900)
declare @TotalQty as varchar(500)
Declare @TblPath as varchar(100)

Select @TblPath = substring(@@TABLENAME, 1, len(@@TABLENAME) - (case when charIndex('.', reverse(@@TABLENAME)) = 0 then len(@@TABLENAME)+1 else charIndex('.', reverse(@@TABLENAME)) END)+1)

if @@FROMZONE = 0
   Select @FRZ = ''
else
    Select @FRZ = ' AND substring(mft.FromZip, 1, 5) in (Select substring(zip, 1, 5) from ' + @@INV_PATH + 'PricePlanZoneZip where ZoneID = ' + convert(varchar, @@FROMZONE) + ') '

if @@TOZONE = 0
   Select @TZ = ''
else
    Select @TZ = ' AND Substring(mft.ToZip, 1, 5) in (Select Substring(zip, 1, 5) from ' + @@INV_PATH + 'PricePlanZoneZip where ZoneID = ' + convert(varchar, @@TOZONE) + ') '

if @@EndDate = ''
Select @DateCond = ' AND mft.[datetime] >= ''' + @@startdate + ''''
else
--Select @DateCond = ' AND mft.[datetime] between ''' + @@StartDate + ''' and ''' + @@EndDate + ''''
Select @DateCond = ' AND mft.[datetime] >= ''' + @@StartDate + ''' and mft.[datetime] < dateadd(day, 1, ''' + @@EndDate + ''')'

-- Select @UPDQ = ' UPDATE ManifestInvoice SET charge = (SELECT ppc.Charge * mft.' + @@COLNAME + ' as ItemCharge FROM PricePlanCharges ppc WHERE ppc.planid = ' + convert(varchar, @@PlanID) + '), Invoice_No = ' + @@InvNo + ', PlanID = ' + convert(varchar, @@PlanID) +
-- ' FROM ManifestInvoice mft WHERE (FromCustID = ''' + @@FromCustID + ''') AND ((Invoice_No IS NULL) OR (RTRIM(Invoice_No) = '''')) ' + @DateCond

-- Select @UPDQ = @UPDQ + @FRZ + @TZ

-- Select @TotalQty = '('+'Select sum(mft.WEIGHT) from ManifestInvoice mft WHERE (mft.FromCustID = ''' + @@FromCustID + ''') AND ((mft.Invoice_No IS NULL) OR (RTRIM(mft.Invoice_No) = '''')) ' + @DateCond + @FRZ + @TZ+ ')'

-- Additional Conditions
declare @CONDTMP as varchar(200)
declare @ADDCOND as varchar(2000)
SELECT @ADDCOND = ''

Declare @CondSQL as varchar(800)
Select @CondSQL = 'DECLARE csrConds CURSOR
FOR
Select '' mft.''+ColumnName+'' ''+Operator+'' ''+(case when substring([Values], 1, 1) = ''('' then [VALUES] ELSE ''''''''+[VALUES]+'''''''' END)+'' '' as Condition 
from ' + @@INV_PATH + 'PricePlanCondition where PlanID = ' + convert(varchar, @@PLANID) + ' order by Rowid '

Exec SP_ExecuteSQL @CondSQL;

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

Declare @TOLOCIDGRP as smallint 
Declare @TempStr as varchar(1000)

Select @TempStr = 'Select @TOLOCIDGRP = convert(int, PerLocationID) from ' + @@INV_PATH + 'PricePlans pp where pp.PlanID = ' + convert(varchar, @@PLANID) + ''
Exec(@TempStr)

-- Declare @GRPSTMT as varchar(20)
-- if @@TOLOCIDGRP = 1 then
--   Select @GRPSTMT = ' group by mft.ToCustID, mft.ToLocID '
-- else
--   Select @GRPSTMT = ''

Select @UPDQ =
' Insert into ' + @@INV_PATH + 'InvoiceLineItems(Invoice_No, Invoice_Date, Description, PlanID) ' +
' Select ''' +  @@InvNo + ''' as Invoice_NO ' +
', (Select TOP 1 Invoice_Date from ' + @@INV_PATH + 'Invoices where invoice_No = ''' +  @@InvNo + ''' ORDER BY INVOICE_dATE DESC) as Invoice_Date ' +
', pp.Invoice_Title as [Description] ' +
', pp.PlanID as PlanID ' +
' From ' + @@INV_PATH + 'PricePlans pp where pp.PlanID = ' + convert(varchar, @@PlanID) + ''

print @UPDQ
exec(@UPDQ)

if @TOLOCIDGRP = 1
Begin
Select @UPDQ = 'Insert into ' + @@INV_PATH + 'InvoiceLineItems(Invoice_No, Invoice_Date, Charge_Code, Description, UnitPrice, Prefix, Qty, Suffix, Unit, Charge, Tax, PlanID, TranDate, ToAddID, ToCustID, ToLocID) ' +
' Select ''' + @@InvNo + ''' as Invoice_No
,(Select TOP 1 Invoice_Date from ' + @@INV_PATH + 'Invoices where invoice_No = ''' + @@InvNo + ''' ORDER BY INVOICE_DATE DESC) as Invoice_Date
, (Select pp.Charge_Code from ' + @@INV_PATH + 'PricePlans pp where pp.PlanID = '+ convert(varchar, @@PlanID) + ') as Charge_Code
, (Select pp.Description from ' + @@INV_PATH + 'PricePlans pp where pp.PlanID = '+ convert(varchar, @@PlanID) + ') as [Description]
, (Select ppc.charge from ' + @@INV_PATH + 'PricePlanCharges ppc where ppc.PlanID = '+ convert(varchar, @@PlanID) + ') as UnitPrice
, (Select pp.ColumnPrefix from ' + @@INV_PATH + 'PricePlans pp where pp.PlanID = '+ convert(varchar, @@PlanID) + ') as ColumnPrefix
, count(mft.pieces) as Qty
, (Select pp.columnsuffix from ' + @@INV_PATH + 'PricePlans pp where pp.PlanID = '+ convert(varchar, @@PlanID) + ') as Suffix
, (Select isnull(pp.ColumnPrefix, '''') + isnull(pp.ColumnSuffix, '''') from ' + @@INV_PATH + 'PricePlans pp where pp.PlanID = '+ convert(varchar, @@PlanID) + ') as Unit
, (Select ppc.charge from ' + @@INV_PATH + 'PricePlanCharges ppc where ppc.PlanID = '+ convert(varchar, @@PlanID) + ') as Charge
, '''' as Tax
, '+ convert(varchar, @@PlanID) + ' as PlanID
, Convert(varchar, mft.[datetime], 101) as TranDate
, (Select top 1 mi22.ToAddID From ' + @TblPath + 'ManifestInvoice2 mi22 Where Convert(varchar, mi22.[datetime], 101) = Convert(varchar, mft.[datetime], 101) AND mi22.ToCustID = mft.ToCustID and mi22.ToLocID = mft.ToLocID Order By ToLocIDOrg) as ToAddID
, mft.toCustID
, mft.ToLocID
from ' + @@TABLENAME + ' mft
where mft.FromCustID = ''' + @@FromCustID + ''' ' + @DateCond + @FRZ + @TZ+@ADDCOND+
' group by Convert(varchar, mft.[datetime], 101), mft.ToCustID, mft.tolocid 
 order by Convert(varchar, mft.[datetime], 101), mft.ToCustID, mft.tolocid '
End
Else
Begin
	Select @TotalQty = '('+'Select sum(mft.'+@@COLNAME+') from ' + @@TABLENAME+' mft WHERE (mft.FromCustID = ''' + @@FromCustID + ''') ' + @DateCond + @FRZ + @TZ+@ADDCOND+')'
	Select @UPDQ = 'Insert into ' + @@INV_PATH + 'InvoiceLineItems(Invoice_No, Invoice_Date, Charge_Code, Description, UnitPrice, Prefix, Qty, Suffix, Unit, Charge, Tax, PlanID) ' +
	' Select ''' + @@InvNo + ''' as Invoice_No
	, (Select TOP 1 Invoice_Date from ' + @@INV_PATH + 'Invoices where invoice_No = ''' + @@InvNo + ''' ORDER BY INVOICE_DATE DESC) as Invoice_Date
	, pp.Charge_Code as Charge_Code
	, pp.Description as [Description]
	, ppc.charge as UnitPrice
	, pp.ColumnPrefix as Prefix
	, ' + @TotalQty + ' as Qty
	, pp.columnsuffix as suffix
	, isnull(pp.ColumnPrefix, '''') + isnull(pp.ColumnSuffix, '''') as unit
	, ppc.charge * ' + @TotalQty + ' as Charge
	, '''' as Tax
	, pp.planid as PlanID
	from ' + @@INV_PATH + 'PricePlanCharges ppc, ' + @@INV_PATH + 'PricePlans pp
	where pp.planid = '+ convert(varchar, @@PlanID) + '
	AND pp.PlanID = ppc.PlanID'
END

print @UPDQ
exec(@UPDQ)

Select @UPDQ = ' UPDATE ' + @@TABLENAME+
' SET Invoice_No = ''' + @@InvNo + ''', PlanIDs = convert(varchar, ISNULL(PlanIDs, ''-'')) + ''' + convert(varchar, @@PlanID) + ''' + ''-'' ' +
' FROM ' + @@TABLENAME+ ' mft WHERE (mft.FromCustID = ''' + @@FromCustID + ''') ' + @DateCond + @FRZ + @TZ+ @ADDCOND + ''
print @UPDQ
exec(@UPDQ)

