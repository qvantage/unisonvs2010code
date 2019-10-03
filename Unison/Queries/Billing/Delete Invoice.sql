set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

ALTER procedure [dbo].[DeleteInvoice] @@InvNo as int, @@Module as varchar(20), @@BILLTblPath as varchar(30), @@TRCTblPath as varchar(30)
as
if @@Module = 'TRACKING'
Begin
Declare @TempStr as varchar(1000);

exec('Set identity_insert ' + @@TRCtblPath + 'ManifestInvoice ON;');

Select @TempStr = 
'insert into ' + @@TRCtblPath + 'ManifestInvoice(RowEnum, RowID, DateTime, VOID, TrackingNum, BillNum, FromCustID, FromAddID, FromLocID, FromZip, ToCustID, ToAddID, ToLocID, ToZip, Weight, ParcelType, Invoice_No, Pieces, Charge, PlanID, PlanIDs, Ref1, Ref2, Ref3, Ref4, Ref5, ServiceLevel, SpecialHandle, BillType)
Select * from ' + @@TRCtblPath + 'ManifestInvoiceArchive where Invoice_No = ' + convert(varchar,@@InvNo) + ';'

exec(@TempStr);

exec('Set identity_insert ' + @@TRCtblPath + 'ManifestInvoice OFF;')

--Select count(*) from ManifestInvoiceArchive where Invoice_No = 20518;
--Select count(*) from ManifestInvoice where Invoice_No = 20518;

Select @TempStr = 'Delete From ' + @@TRCtblPath + 'ManifestInvoiceArchive where Invoice_No = ' + Convert(varchar,@@InvNo) + ';'
exec(@TempStr);

-- Select tolocid, tozip, weight, charge
Select @TempStr = 'Update  ' + @@TRCTblPath + 'ManifestInvoice set PlanID = NULL, charge = null, invoice_no = null, PlanIDs = NULL from ' + @@TRCtblPath + 'ManifestInvoice mi where invoice_No = ' + Convert(varchar(15), @@InvNo) + ';';
exec(@TempStr);

Select @TempStr = 'delete from ' + @@BILLTblPath + 'InvoiceLineItems where invoice_no = ' + Convert(varchar, @@InvNo) +';'
exec(@TempStr);

Select @TempStr = 'Update ' + @@BILLTblPath + 'InvoiceMiscCharges Set Invoice_No = NULL where invoice_No = ' + Convert(varchar, @@InvNo) + ';';
exec(@TempStr);

Select @TempStr = 'Delete from ' + @@BILLTblPath + 'Invoices Where Invoice_No = ' + Convert(varchar, @@InvNo) + ';';
exec(@TempStr);

END

