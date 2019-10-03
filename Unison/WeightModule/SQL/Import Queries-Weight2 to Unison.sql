set identity_insert netsrv.unison.dbo.GroupClubs on;
INSERT INTO netsrv.unison.dbo.GroupClubs
                      (GroupID, ClubID, Club_Name, Club_Comment)
SELECT     'W' AS Expr1, ID, Name, '' AS Expr2
FROM         NTSRVR.WEIGHTMODULE2.dbo.AccountGroups;
set identity_insert netsrv.unison.dbo.GroupClubs off;


-- ======================================================
SELECT     *
FROM         NTSRVR.WEIGHTMODULE2.dbo.CUSTOMER CUSTOMER_1
WHERE     (ID NOT IN (SELECT [id] FROM customer))


Insert into Customer(ID, NAME, CONTACT, STREET, CITYNAME, STATE, ZIPCODE, PHONE1, PHONE2, FAX, PAGER, EXTENSION, EMAIL, Web, CREATEDATE, LASTBillDate, BCycleCode, CREDITLIMIT, COMMENTS, DISCOUNTRATE, SALESID, APPLYRATEINCREASE, GRACEPERIOD, TAXRATE, FuelSURCHARGE, INCREASEDATE, INCREASERATE, FINANCECHARGE, Status, AcctGroupID, SubjHoliday, bNAME, bCONTACT, bSTREET, bCITYNAME, bSTATE, bZIPCODE, bPHONE1, bPHONE2, bFAX, bEMAIL, SamePayAddress, NRVNU, HolidaySvcMj, HolidaySvcMn, HolidayNoticeMj, HolidayNoticeMn)
SELECT     *
FROM         NTSRVR.WEIGHTMODULE2.dbo.Customer where id in 
(SELECT  ID
FROM         NTSRVR.WEIGHTMODULE2.dbo.CUSTOMER CUSTOMER_1
WHERE     (ID NOT IN (SELECT [id] FROM customer))
)

SELECT     *
FROM         NTSRVR.WEIGHTMODULE2.dbo.CUSTOMER CUSTOMER_1
WHERE     (name NOT IN (SELECT [name] FROM customer))

-- Difference Between First Import (Holidays) and Weight Module
SELECT     ID, Street as WGT2_Cust_Str, (SELECT [street] FROM customer c2 where c2.id = c1.id) as UN_Cust_STR
FROM         NTSRVR.WEIGHTMODULE2.dbo.CUSTOMER C1
WHERE     (left(street, 5) <> (SELECT left([street], 5) FROM customer c2 where c2.id = c1.id) )


-- ===================================================================================

SELECT * FROM NTSRVR.WEIGHTMODULE2.dbo.CITY WHERE (ZIPCODE NOT IN (SELECT zipcode FROM netsrv.unison.dbo.city
                            WHERE      statecode = 'CA')) AND (STATECODE = 'CA')


-- ===================================================================================

Insert into ListingsTemplates(ListName, NAME, Template)
SELECT     ListName, NAME, Template
FROM         NTSRVR.WEIGHTMODULE2.dbo.ListingsTemplates;

-- ===================================================================================

Insert into ListLayouts(USERID, FORMNAME, GRIDTAG, LAYOUT)
SELECT     USERID, FORMNAME, GRIDTAG, LAYOUT
FROM         NTSRVR.WEIGHTMODULE2.dbo.ListLayouts;

-- ===================================================================================

set identity_insert Regions on;
Insert into Regions
SELECT     *
FROM         NTSRVR.WEIGHTMODULE2.dbo.Regions;
set identity_insert Regions off;

-- ===================================================================================
-- Regions are required for Offices.

Insert into 
ServiceOffices(ID, NAME, Contact, STREET, Address2, CITY, STATE, ZIPCODE, PHONE1, PHONE2, FAX, EMAIL, WEB, Territory, RegionID, Password, CustomerID)
select ID, NAME, '', STREET, '',  CITY, STATE, ZIPCODE, PHONE1, PHONE2, FAX, EMAIL, WEB, Territory, RegionID, '', 10000
 from NTSRVR.WEIGHTMODULE2.dbo.ServiceOffices

-- Select BranchID, Name, Contact, Address1, Address2, City, State, Zip, Phone, '', '', Email, '', '', 0, Password, CustomerID from  [TOP].dbo.Branch;
-- ===================================================================================

