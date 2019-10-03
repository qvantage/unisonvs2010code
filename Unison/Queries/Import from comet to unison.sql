SELECT     CUSTOMERID, City as CityOLD, 
rtrim
(
replace(substring(city, 1, 
convert(int, 
(1000 - sign( log10(charindex(', ', isnull(City, ''))+1) ) * 1000) / 2 + charindex(', ', isnull(City, ''))
)
), ',', '')
) as City
, 
rtrim(ltrim(substring(isnull(city, ''), charindex(', ', City)+1,
convert(int, 1000 * sign( log10(charindex(', ', City)+1) ) )
 )
)) as State
FROM 
CometTopCust
where city is not null and city <> ''
AND len(rtrim(ltrim(substring(isnull(city, ''), charindex(', ', City)+1,
convert(int, 1000 * sign( log10(charindex(', ', City)+1) ) )
 )
))
) > 2



update CometTopCust
set state = rtrim(ltrim(substring(isnull(city, ''), charindex(', ', City)+1,
convert(int, 1000 * sign( log10(charindex(', ', City)+1) ) )
 )
))
, 
City = rtrim
(
replace(substring(city, 1, 
convert(int, 
(1000 - sign( log10(charindex(', ', isnull(City, ''))+1) ) * 1000) / 2 + charindex(', ', isnull(City, ''))
)
), ',', '')
)
where city is not null and ltrim(city) <> ''


Update CometTopCust
set state = 'CA' where state = 'C'

-- -----------------------------------------------------------------

SELECT     CUSTOMERID, City as CityOLD, 
rtrim
(
replace(substring(city, 1, 
convert(int, 
(1000 - sign( log10(charindex(', ', isnull(City, ''))+1) ) * 1000) / 2 + charindex(', ', isnull(City, ''))
)
), ',', '')
) as City
, 
rtrim(ltrim(substring(isnull(city, ''), charindex(', ', City)+1,
convert(int, 1000 * sign( log10(charindex(', ', City)+1) ) )
 )
)) as State
FROM 
CometCFCCust
where city is not null and city <> ''


AND len(rtrim(ltrim(substring(isnull(city, ''), charindex(', ', City)+1,
convert(int, 1000 * sign( log10(charindex(', ', City)+1) ) )
 )
))
) > 2




update CometCFCCust
set state = rtrim(ltrim(substring(isnull(city, ''), charindex(', ', City)+1,
convert(int, 1000 * sign( log10(charindex(', ', City)+1) ) )
 )
))
, 
City = rtrim
(
replace(substring(city, 1, 
convert(int, 
(1000 - sign( log10(charindex(', ', isnull(City, ''))+1) ) * 1000) / 2 + charindex(', ', isnull(City, ''))
)
), ',', '')
)
where city is not null and ltrim(city) <> ''


Update CometCFCCust
set state = 'CA' where state = 'C'

-- ========================================================================
-- Accounts not in Comet but in UNISON
SELECT     ID, NAME, CONTACT, STREET, Address2, CITYNAME, STATE, ZIPCODE, PHONE1, PHONE2, FAX, PAGER, EXTENSION, EMAIL, Web, CREATEDATE, 
                      LASTBillDate, BCycleCode, CREDITLIMIT, COMMENTS, DISCOUNTRATE, SALESID, APPLYRATEINCREASE, GRACEPERIOD, TAXRATE, 
                      FuelSURCHARGE, INCREASEDATE, INCREASERATE, FINANCECHARGE, Status, AcctGroupID, SubjHoliday, bNAME, bCONTACT, bSTREET, bCITYNAME, 
                      bSTATE, bZIPCODE, bPHONE1, bPHONE2, bFAX, bEMAIL, SamePayAddress, NRVNU, HolidaySvcMj, HolidaySvcMn, HolidayNoticeMj, 
                      HolidayNoticeMn, HolidayCommentsMn, CourierCode, LocIDSuffix, MasterCustID, MasterCustName
FROM         CUSTOMER
WHERE     (ID NOT IN
                          (SELECT     CUSTOMERID
                            FROM          CometTopCust)) AND (ID / 10000 > 1)



-- TOP

SELECT     CustomerID, Name, Address1, Address2, City, State, Zip, Contact, Phone, Email, CourierCode, Active, LocIDSuffix
FROM         [TOP].dbo.CUSTOMER
WHERE     (CustomerID NOT IN
                          (SELECT     CUSTOMERID
                            FROM          CometTopCust)) 
AND (CONVERT(int, CustomerID) / 10000 > 1)

SELECT     CustomerID, Name, Address1, Address2, City, State, Zip, Contact, Phone, Email, CourierCode, Active, LocIDSuffix
FROM         [TOP].dbo.CUSTOMER
WHERE     (CustomerID NOT IN
                          (SELECT     ID
                            FROM      unison.dbo.customer)) 



-- =========================================================================================

SELECT     ID, NAME, CONTACT, STREET, Address2, CITYNAME, STATE, ZIPCODE, PHONE1, FAX,  
                      
                      Status, bNAME, bCONTACT, bSTREET, bCITYNAME, 
                      bSTATE, bZIPCODE, bPHONE1, bFAX, SamePayAddress, 
                      CourierCode
FROM         CUSTOMER
WHERE     (ID IN
                          (SELECT     CUSTOMERID
                            FROM          CometTopCust)) AND (ID / 10000 > 1)

Select cm.billcycle, (case when cm.billcycle = 'C' or cm.billcycle = 'X' then 0 else 1 end) as XSTATUS,
c.status,
c.bcyclecode,cm.CustomerID, cm.Customer, c.Name, cm.Contact, c.Contact, (case ltrim(rtrim(isnull(cm.Contact, ''))) when '' then c.contact else ltrim(rtrim(isnull(cm.Contact, ''))) end) as XCONTACT, 
cm.address1, c.Street, c.bstreet, cm.Address2, c.Address2, cm.City, c.CityName, cm.State, c.State, cm.zip, c.zipcode, cm.phone, c.phone1, cm.fax, c.fax 
from CometTopCust cm inner join Customer c on convert(int, cm.CustomerID) = c.id
where cm.city is not null and cm.customerid / 10000 > 1


Select cm.CustomerID, cm.Contact, c.Contact, 
from CometTopCust cm inner join Customer c on convert(int, cm.CustomerID) = c.id
where cm.city is not null and cm.customerid / 10000 > 1


Update Customer
Set 
bcyclecode = ltrim(rtrim(cm.billcycle)),
[Name] = ltrim(rtrim(cm.Customer)),
Street = ltrim(rtrim(cm.Address1)),
Address2 = ltrim(rtrim(isnull(cm.address2, ''))),
cityname = ltrim(rtrim(cm.city)),
state = (case when cm.State is null then c.state else ltrim(rtrim(cm.state)) end ),
zipcode = ltrim(rtrim(cm.zip)),
phone1 = replace(replace(replace(replace(replace(cm.phone, ' ', ''), '-', ''), '.', ''), '(', ''), ')', ''),
fax = replace(replace(replace(replace(replace(cm.fax, ' ', ''), '-', ''), '.', ''), '(', ''), ')', ''),
Contact = (case  when ltrim(rtrim(isnull(cm.Contact, ''))) = '' then c.contact else ltrim(rtrim(isnull(cm.Contact, ''))) END ),
status = (case when cm.billcycle = 'C' or cm.billcycle = 'X' then 0 else 1 end)
from CometTopCust cm inner join Customer c on convert(int, cm.CustomerID) = c.[id]
where cm.city is not null and cm.customerid / 10000 > 1

-- 670 rows the same

-- ======================================


SELECT   *
FROM         CometTopCust
WHERE     (customerID not IN
                          (SELECT     ID
                            FROM          Customer where id / 10000 > 1)) AND (customerID / 10000 > 1)

insert into Customer(ID, [Name],Contact, Street, Address2, cityname, state ,zipcode , phone1, Fax, status, bcyclecode)
Select 
ltrim(rtrim(cm.CustomerID)) as CustomerID,
ltrim(rtrim(cm.Customer)) as Customer_Name,
ltrim(rtrim(isnull(cm.Contact, ''))) as Contact, 
ltrim(rtrim(cm.Address1)) as Street,
ltrim(rtrim(isnull(cm.address2, ''))) as Address2,
ltrim(rtrim(cm.city)) as CITY, 
ltrim(rtrim(isnull(cm.state, ''))) as State, 
ltrim(rtrim(cm.zip)) as zipcode,
replace(replace(replace(replace(replace(cm.phone, ' ', ''), '-', ''), '.', ''), '(', ''), ')', '') as Phone1,
replace(replace(replace(replace(replace(cm.fax, ' ', ''), '-', ''), '.', ''), '(', ''), ')', '') as Fax,
(case when cm.billcycle = 'C' or cm.billcycle = 'X' then 0 else 1 end) as Status,
ltrim(rtrim(cm.billcycle)) as BCycleCode
From  CometTopCust cm
WHERE     (customerID not IN
                          (SELECT [ID] FROM  Customer where [id] / 10000 > 1)) 
AND (customerID / 10000 > 1)


Select * from customer c where id /10000 > 1 and id not in (SELECT CUSTOMERID FROM CometTopCust cm where cm.city is not null and cm.customerid / 10000 > 1)

insert into [Unison].dbo.Customer(ID, [Name],Contact, Street, Address2, cityname, state ,zipcode , phone1, Fax, status, bcyclecode)
Select CustomerID, Name, Contact, Address1, Address2, City, state, zip, Phone, '' as Fax, 
(case when Active = 'Y' then 1 else 0 end) as Status, '' as BCycleCode
From [top].dbo.customer 
WHERE     (CustomerID NOT IN
                          (SELECT     ID
                            FROM      unison.dbo.customer)) 
Select * from [top].dbo.location
where (customerid+'-'+locationid) not in 
(
Select CustomerID+'-'+LocationID from [top].dbo.location
)


-- ============ END Processing of TOP Customers  ===============================================================

-- ===========  CFC Customers    =======================================
SELECT     ID, NAME, CONTACT, STREET, Address2, CITYNAME, STATE, ZIPCODE, PHONE1, FAX,  
                      
                      Status, bNAME, bCONTACT, bSTREET, bCITYNAME, 
                      bSTATE, bZIPCODE, bPHONE1, bFAX, SamePayAddress, 
                      CourierCode
FROM         CUSTOMER
WHERE     (ID IN
                          (SELECT     CUSTOMERID
                            FROM          CometcfcCust)) AND (ID / 10000 < 1) and (ID / 1000 > 1)


-- Contact/Address2 Data Correction Query

SELECT     CUSTOMERID, CUSTOMER, CONTACT, ADDRESS1, ADDRESS2, CITY, STATE, ZIP, CUSTTYPE, BILLCYCLE, STATFLAG, BALANCE, [CURRENT], 
                      [3060BALANCE], [6090BALANCE], [90120BALANCE], [120+ DAY BALANCE], [RECEIPT DATE], PHONE, FAX, [LAST INCREASE], FUEL, 
                      LASTBILLDATE, (case when rtrim(LastBillDate) <> '' and lastbilldate is not null then substring(LastBillDate, 1, 2)+'/'+ substring(LastBillDate, 3, 2)+'/'+substring(LastBillDate, 5, 2) Else NULL end) XLBillDate
FROM         CometCFCCust AS cm
WHERE     (CUSTOMERID / 1000 > 1) AND (CUSTOMERID / 10000 < 1) AND (CUSTOMERID IN
                          (SELECT     ID
                            FROM          CUSTOMER AS c
                            WHERE      (ID / 1000 > 1) AND (ID / 10000 < 1))) AND 
                      (CUSTOMERID / 1000 > 1) AND (CUSTOMERID / 10000 < 1) AND (CUSTOMERID IN
                          (SELECT     ID
                            FROM          CUSTOMER AS c
                            WHERE      (ID / 1000 > 1) AND (ID / 10000 < 1))) 
--AND ( (CONTACT NOT LIKE '%ATTN%') AND (RTRIM(CONTACT) <> '') )



Select 
cm.CustomerID, cm.Customer, c.Name, cm.Contact, c.Contact as C_Contact, (case ltrim(rtrim(isnull(cm.Contact, ''))) when '' then c.contact else ltrim(rtrim(isnull(cm.Contact, ''))) end) as XCONTACT, 
cm.address1, c.Street, c.bstreet, cm.Address2, c.Address2, cm.City, c.CityName, cm.State, c.State, cm.zip, c.zipcode, cm.phone, c.phone1, cm.fax, c.fax,
cm.billcycle, c.bcyclecode,(case when cm.billcycle = 'C' or cm.billcycle = 'X' then 0 else 1 end) as XSTATUS,
c.status
from CometCFCCust cm inner join Customer c on convert(int, cm.CustomerID) = c.id
where cm.city is not null and cm.customerid / 1000 > 1 and cm.customerid / 10000 < 1

-- Update existing Accounts in CFC

Update Customer
Set 
bcyclecode = ltrim(rtrim(cm.billcycle)),
[Name] = ltrim(rtrim(cm.Customer)),
Street = ltrim(rtrim(cm.Address1)),
Address2 = ltrim(rtrim(isnull(cm.address2, ''))),
cityname = ltrim(rtrim(cm.city)),
state = (case when cm.State is null then c.state else ltrim(rtrim(cm.state)) end ),
zipcode = ltrim(rtrim(cm.zip)),
phone1 = replace(replace(replace(replace(replace(cm.phone, ' ', ''), '-', ''), '.', ''), '(', ''), ')', ''),
fax = replace(replace(replace(replace(replace(cm.fax, ' ', ''), '-', ''), '.', ''), '(', ''), ')', ''),
Contact = (case  when ltrim(rtrim(isnull(cm.Contact, ''))) = '' then c.contact else ltrim(rtrim(isnull(cm.Contact, ''))) END ),
status = (case when cm.billcycle = 'C' or cm.billcycle = 'X' then 0 else 1 end),
LastBillDate = (case when rtrim(cm.LastBillDate) <> '' and cm.lastbilldate is not null then substring(cm.LastBillDate, 1, 2)+'/'+ substring(cm.LastBillDate, 3, 2)+'/'+substring(cm.LastBillDate, 5, 2) else NULL END)
from CometCFCCust cm inner join Customer c on convert(int, cm.CustomerID) = c.[id]
where cm.city is not null and (ID / 1000 > 1) AND (ID / 10000 < 1)



-- Add new accounts

SELECT   *
FROM         CometCFCCust
WHERE     (customerID not IN
                          (SELECT     ID
                            FROM          Customer where (ID / 1000 > 1) AND (ID / 10000 < 1) )) AND (customerID / 10000 < 1) AND (customerID / 1000 > 1)



insert into Customer(ID, [Name],Contact, Street, Address2, cityname, state ,zipcode , phone1, Fax, status, bcyclecode, LastBillDate)
Select 
ltrim(rtrim(cm.CustomerID)) as CustomerID,
ltrim(rtrim(cm.Customer)) as Customer_Name,
ltrim(rtrim(isnull(cm.Contact, ''))) as Contact, 
ltrim(rtrim(cm.Address1)) as Street,
ltrim(rtrim(isnull(cm.address2, ''))) as Address2,
ltrim(rtrim(cm.city)) as CITY, 
ltrim(rtrim(isnull(cm.state, ''))) as State, 
ltrim(rtrim(cm.zip)) as zipcode,
replace(replace(replace(replace(replace(cm.phone, ' ', ''), '-', ''), '.', ''), '(', ''), ')', '') as Phone1,
replace(replace(replace(replace(replace(cm.fax, ' ', ''), '-', ''), '.', ''), '(', ''), ')', '') as Fax,
(case when cm.billcycle = 'C' or cm.billcycle = 'X' then 0 else 1 end) as Status,
ltrim(rtrim(cm.billcycle)) as BCycleCode,
(case when rtrim(cm.LastBillDate) <> '' and cm.lastbilldate is not null then substring(cm.LastBillDate, 1, 2)+'/'+ substring(cm.LastBillDate, 3, 2)+'/'+substring(cm.LastBillDate, 5, 2) else NULL END) as LastBillDate
From  CometCFCCust cm
WHERE     (customerID not IN
                          (SELECT [ID] FROM  Customer where (ID / 1000 > 1) AND (ID / 10000 < 1)) )
AND (customerID / 10000 < 1) AND (customerID / 1000 > 1)


Select * from CometCFCCust cm where (customerID / 10000 < 1) AND (customerID / 1000 > 1)
 and customerid not in (SELECT ID FROM Customer c where (ID / 1000 > 1) AND (ID / 10000 < 1) )

-- ===========================    End of CFC Customers   ======================================================

Select * from [UN_TRACKING].dbo.location where customerid in (select distinct customerid from [top].dbo.location where customerid <> 10000)

Select * from [top].dbo.location where customerid in (21106, 23103, 5766, 25649)

Select * from [top].dbo.location 
where addressid in (Select addressid from [UN_TRACKING].dbo.location)

Select max(addressid) from [top].dbo.location 

Select a.addressid, (Select count(b.addressID)+1 from [UN_TRACKING].dbo.location b where b.addressid < a.addressid) as SortedAddrID from [UN_TRACKING].dbo.location a order by a.addressid

update [UN_TRACKING].dbo.location
set addressid = (Select count(b.addressID)+1 from [UN_TRACKING].dbo.location b where b.addressid < a.addressid) 
from [UN_TRACKING].dbo.location a 

Select Addressid from [UN_TRACKING].dbo.location order by addressid

update [UN_TRACKING].dbo.location
set addressid = addressid+9481

Select CustomerID, LocationID, Name, Address1, Address2, City, State, Zip, Contact, Phone, Active, Email, AddressID, Password
 from [top].dbo.location 
where contact is null

Insert into Unison.dbo.Address( CustomerID,  LocationID, NAME, STREET, Address2, CITYNAME, STATECODE, ZIPCODE, CONTACT, PHONE, ACTIVE, email, ID, WEB_PASSWORD)
Select CustomerID, LocationID, Name, Address1, Address2, City, State, Zip, isnull(Contact, ''), Phone, Active, isnull(Email, ''), AddressID, Password
 from [top].dbo.location 

-- Location ==> Address Table: Last AddressID Inserted = 9481

-- Updating Address Diff 08/02/2006
Select max(addressid) from [top].dbo.location 

Select * from [TOP].dbo.Location where addressid > 9481 order by Addressid

update [UN_TRACKING].dbo.location
set addressid = addressid + (9536 - 9481) -- As of 08/01/2006: 9534
where AddressID > 9481
-- 9149 Rows Updated
Select * from [UN_TRACKING].dbo.location where addressid > 9480 order by addressid
Select * from [TOP].dbo.Location where addressid > 9480 order by Addressid

Insert into Unison.dbo.Address( CustomerID,  LocationID, NAME, STREET, Address2, CITYNAME, STATECODE, ZIPCODE, CONTACT, PHONE, ACTIVE, email, ID, WEB_PASSWORD)
Select CustomerID, LocationID, Name, Address1, Address2, City, State, Zip, isnull(Contact, ''), Phone, Active, isnull(Email, ''), AddressID, Password
 from [top].dbo.location 
 where AddressID > 9481
order by Addressid

-- End Updating Address Diff 08/02/2006

-- Maintain Unknown zipcodes for branches and price zones.
-- Fix adding Address2 into Manifest Table in Weight Module
-- Fix Ingram Importer Service to UNISON
-- DTS Imports:
-- 	UN_TRACKING
--		CourierLabels
--		DeliveryOptions
--		EVENT
--		EVENTCODES
--		LabelForms
--		Manifest
--		ManifestVoid
--		ManifestInvoice
--		ManifestInvoiceArchive
--		PePrintedLabels
-- 	UN_BILLING
--		BillingSetup
--		InvoiceChargeCodes
--		InvoiceLineItems
--		InvoiceMiscCharges
--		Invoices
--		InvoiceTerms
--		PricePlanCharges
--		PricePlanCondition
--		PricePlanConditionOperators
--		PricePlanCustomer
--		PricePlanModules
--		PricePlans
--		PricePlanTypes
--		PricePlanZones
--		PricePlanZoneZip
--		
-- 	UNISON
--		BRANCH?---> No Need
--		CITY
--		GROUP ========> Using a query into Unison
--		GROUPAccount ========> Using a query into Unison
--		ListingTemplates ========> Using a query
--		ParcelTypes
--		Routes
-- Routes Updating

Select * from [top].dbo.routes order by rowid

Select * from [un_tracking].dbo.routes order by rowid

Insert into [un_tracking].dbo.routes(ID, Name, Remarks, OfficeID, DriverID, ActiveOffice, CustomerID, LocationID, Zip)
Select ID, Name, Remarks, OfficeID, DriverID, ActiveOffice, CustomerID, LocationID, Zip 
from [top].dbo.routes order by rowid

-- 2373 Rows Affected, Last RowID in UNISON: 4976, Route 0203, 08/03/2006

Select * from [unison].dbo.Packagetypes
Select * from [un_Tracking].dbo.ParcelTypes
Select * from [top].dbo.ParcelTypes

insert into [un_Tracking].dbo.ParcelTypes
Select * from [top].dbo.ParcelTypes
-- 5 Rows Affected

-- ======================  City Update  ===========================

-- Existing Zips in UNISON not in TOP

SELECT     ID, NAME, ZIPCODE, ZIPPLUS, STATECODE, LATITUDE, LONGITUDE
FROM         UNISON.dbo.CITY
WHERE     (ZIPCODE NOT IN
                          (SELECT     ZIPCODE
                            FROM          [TOP].dbo.CITY AS CITY_1))


-- Existing Zips in TOP not in Unison

SELECT     ID, NAME, ZIPCODE, ZIPPLUS, STATECODE, LATITUDE, LONGITUDE
FROM         [TOP].dbo.CITY
WHERE     (ZIPCODE NOT IN
                          (SELECT     ZIPCODE
                            FROM          UNISON.dbo.CITY AS CITY_1))


insert into UNISON.dbo.CITY(NAME, ZIPCODE, ZIPPLUS, STATECODE, LATITUDE, LONGITUDE)
SELECT     NAME, ZIPCODE, ZIPPLUS, STATECODE, LATITUDE, LONGITUDE
FROM         [TOP].dbo.CITY
WHERE     (ZIPCODE NOT IN
                          (SELECT     ZIPCODE
                            FROM          UNISON.dbo.CITY AS CITY_1))


-- ==============  End City  ================================

Select * from unison.dbo.groups

Select * from unison.dbo.groupClubs

Select * from unison.dbo.groupClubMembers

Select * from [top].dbo.[group]

Select * from [top].dbo.[groupAccount]

-- Add Tracking Groups into Clubs
Insert into unison.dbo.groupClubs(GroupID, Club_Name, Club_Comment, Club_Code)
Select 'Z' as GroupID, GroupName, 'Imported From Tracking' as Club_Comment, GroupID as Club_Code
from [top].dbo.[group]


-- Add Accounts to ClubMembers
Select * from unison.dbo.groupClubs where groupid = 'Z'

Insert into unison.dbo.groupClubMembers(GroupID, ClubID, MemberID, Member_Name, MemberType)
Select 'Z' as GroupID, ugc.ClubID, tga.CustomerID, c.Name as Member_Name, 'A' as MemberType
from [top].dbo.[groupAccount] tga inner join unison.dbo.groupClubs ugc on tga.groupid = ugc.Club_Code
inner join unison.dbo.Customer c on tga.CustomerID = c.ID


-- ==================  End Groups  ==========================

-- ListingTemplates

Select * from [top].dbo.listingstemplates

Select * from [unison].dbo.listingstemplates

Insert into [unison].dbo.listingstemplates(ListName, Name, Template)
Select ListName, Name, Template
from [top].dbo.listingstemplates

-- =============== Ens ListingsTemplate =========================

-- ========== DestinationZipCode  ==============

Select * from [top].dbo.destinationzipcode

Select * from [unison].dbo.destinationzipcode

delete from [unison].dbo.destinationzipcode

insert into [unison].dbo.destinationzipcode
Select * from [top].dbo.destinationzipcode

-- Last Performed on 08/03/2006 
-- ============ END DestinationZipCode  ============================

-- Address Change verifications
Select Max(Addressid) from [top].dbo.location
Select * from [top].dbo.location
Select * from [UN_TRACKING].dbo.location_All where addressid < 9537

Select tl.* from [top].dbo.location tl inner join [UN_TRACKING].dbo.location_All ul on tl.addressid = ul.addressid 
where ul.addressid < 9537
and tl.locationid <> ul.locationid


Select count(rowid) from [top].dbo.Event
Select count(rowid) from [UN_TRACKING].dbo.Event

Select count(trackingnum) from [top].dbo.ManifestInvoice
Select count(trackingnum) from [UN_TRACKING].dbo.ManifestInvoice 

Select * from [top].dbo.ManifestInvoiceArchive
Select * from [UN_TRACKING].dbo.ManifestInvoiceArchive

Select * from [top].dbo.CourierLabels
Select * from [UN_TRACKING].dbo.CourierLabels

Select * from [top].dbo.Employee where EmployeeID not in 
(Select EmployeeID from [UN_TRACKING].dbo.Employee)

-- Scanning Employees
Set Identity_Insert [unison].dbo.EmployeesBase on
Insert into [Unison].dbo.EmployeesBase(ID, FirstName, MiddleName, LastName, Status, OfficeID, Company)
Select EmployeeID, FirstName, 'FOR TRACKING' as MiddleName, LastName, 'A' as Status, BranchID, 'TPC' as Company
from [top].dbo.Employee where EmployeeID not in 
(Select EmployeeID from [UN_TRACKING].dbo.Employee)
Set Identity_Insert [unison].dbo.EmployeesBase off

-- Scan Points
Select * from [top].dbo.location 
where customerid = 10000
AND locationid not in 
(Select locationid from [UN_Tracking].dbo.location where customerid = 10000)


Select * from [top].dbo.PricePlans
Select * from [UN_Billing].dbo.PricePlans

Select * from [top].dbo.Invoices
Select * from [UN_Billing].dbo.Invoices

Select * from [top].dbo.InvoiceLineItems
Select * from [UN_Billing].dbo.InvoiceLineItems

Select * from [top].dbo.InvoiceMiscCharges
Select * from [UN_Billing].dbo.InvoiceMiscCharges


sp_who2


