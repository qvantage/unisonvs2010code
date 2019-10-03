set ANSI_NULLS ON
set QUOTED_IDENTIFIER ON
go

ALTER procedure [dbo].[DeleteInvoice] @@InvNo as int, @@Module as varchar(20)
as
if @@Module = 'TRACKING'
Begin
Set identity_insert [UN_TRACKING].dbo.ManifestInvoice ON;

insert into [UN_TRACKING].dbo.ManifestInvoice(RowEnum, RowID, DateTime, VOID, TrackingNum, BillNum, FromCustID, FromAddID, FromLocID, FromZip, ToCustID, ToAddID, ToLocID, ToZip, Weight, ParcelType, Invoice_No, Pieces, Charge, PlanID, PlanIDs, Ref1, Ref2, Ref3, Ref4, Ref5, ServiceLevel, SpecialHandle, BillType)
Select * from [UN_TRACKING].dbo.ManifestInvoiceArchive where Invoice_No = @@InvNo;

Set identity_insert [UN_TRACKING].dbo.ManifestInvoice OFF;

--Select count(*) from ManifestInvoiceArchive where Invoice_No = 20518;
--Select count(*) from ManifestInvoice where Invoice_No = 20518;

Delete From [UN_TRACKING].dbo.ManifestInvoiceArchive where Invoice_No = @@InvNo;

-- Select tolocid, tozip, weight, charge
Update  [UN_TRACKING].dbo.ManifestInvoice set PlanID = NULL, charge = null, invoice_no = null, PlanIDs = NULL
from [UN_TRACKING].dbo.ManifestInvoice mi where invoice_No = @@InvNo;

delete from [UN_BILLING].dbo.InvoiceLineItems where invoice_no = @@InvNo;

Update [UN_BILLING].dbo.InvoiceMiscCharges Set Invoice_No = NULL where invoice_No = @@InvNo;

Delete from [UN_BILLING].dbo.Invoices Where Invoice_No = @@InvNo;

END

