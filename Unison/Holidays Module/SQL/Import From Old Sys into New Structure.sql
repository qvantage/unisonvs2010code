Delete From BillingCycles;
INSERT INTO BillingCycles
SELECT     *
FROM         NTSRVR.HolidaysModule.dbo.BillingCycles BillingCycles_1;

Delete from AccountServices;
set identity_insert UN_Routes.dbo.AccountServices on;
ALTER TABLE UN_Routes.[dbo].[AccountServices] DISABLE TRIGGER [SIDIncrement];
Insert into UN_Routes.dbo.AccountServices(ROWID, ID, AccountID, OfficeID, CompName, Street, CityName, STATE, ZipCode, PHONE1, PHONE2, Remarks, StartDate, EndDate, OpenTime, CloseTime, DoorKey, BoxKey, InternalRef, AccountRef, TimeFrameID, ServiceID, ServiceTypeID, PackageID, Charge, DailyAvgChg, InfoSID, SchedType, NonPrintRemark, [Last Bill Date], [Subj To Wgt], [Wgt Plan ID])
SELECT *
FROM         NTSRVR.HolidaysModule.dbo.AccountServices ;
set identity_insert UN_Routes.dbo.AccountServices oFF;
ALTER TABLE UN_Routes.[dbo].[AccountServices] ENABLE TRIGGER [SIDIncrement];

Delete from City;
Insert into City
SELECT     *
FROM         NTSRVR.HolidaysModule.dbo.City;

Delete from Customer;
Insert into Customer(ID, NAME, CONTACT, STREET, CITYNAME, STATE, ZIPCODE, PHONE1, PHONE2, FAX, PAGER, EXTENSION, EMAIL, Web, CREATEDATE, LASTBillDate, BCycleCode, CREDITLIMIT, COMMENTS, DISCOUNTRATE, SALESID, APPLYRATEINCREASE, GRACEPERIOD, TAXRATE, FuelSURCHARGE, INCREASEDATE, INCREASERATE, FINANCECHARGE, Status, AcctGroupID, SubjHoliday, bNAME, bCONTACT, bSTREET, bCITYNAME, bSTATE, bZIPCODE, bPHONE1, bPHONE2, bFAX, bEMAIL, SamePayAddress, NRVNU, HolidaySvcMj, HolidaySvcMn, HolidayNoticeMj, HolidayNoticeMn)
SELECT     *
FROM         NTSRVR.HolidaysModule.dbo.Customer;

Delete from ListingsTemplates;
set identity_insert UNISON.dbo.ListingsTemplates on;
Insert into ListingsTemplates(ID, ListName, NAME, Template)
SELECT     *
FROM         NTSRVR.HolidaysModule.dbo.ListingsTemplates;
set identity_insert UNISON.dbo.ListingsTemplates off;


Delete from ListLayouts;
set identity_insert UNISON.dbo.ListLayouts on;
Insert into ListLayouts(ID, USERID, FORMNAME, GRIDTAG, LAYOUT)
SELECT     *
FROM         NTSRVR.HolidaysModule.dbo.ListLayouts;
set identity_insert UNISON.dbo.ListLayouts off;

Delete from STATE;
Insert into STATE
SELECT     *
FROM         NTSRVR.HolidaysModule.dbo.STATE;

