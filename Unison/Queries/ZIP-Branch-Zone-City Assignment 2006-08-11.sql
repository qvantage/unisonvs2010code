
SELECT ZIP FROM un_tracking.dbo.LOCATION 
WHERE 
SUBSTRING(ZIP, 1, 5) NOT IN (SELECT SUBSTRING(ZIP, 1, 5) FROM [un_billing].dbo.PRICEPLANZONEZIP where zoneid <> 1) AND STATE = 'CA'

-- Search New Cities in Addresses not in CITY table
SELECT city, ZIP FROM un_tracking.dbo.LOCATION 
WHERE 
SUBSTRING(ZIP, 1, 5) NOT IN (SELECT zipcode FROM [un_tracking].dbo.city ) and State in ('CA', 'AZ', 'NV')

-- Search DestinationZipCode to see what zipcodes are not assigned to branches
SELECT CustomerID, city, ZIP FROM un_tracking.dbo.LOCATION 
WHERE 
SUBSTRING(ZIP, 1, 5) NOT IN (SELECT Destzip FROM [un_tracking].dbo.DestinationZipCode ) and State in ('CA', 'AZ', 'NV')
order by city

-- Search For same name cities assigned to a branch
SELECT distinct l.CustomerID, l.city, l.ZIP, dz.BranchID as Matched_Branch FROM un_tracking.dbo.LOCATION l
left outer join [un_tracking].dbo.City c on l.city = c.name
left outer join [un_tracking].dbo.DestinationZipCode dz on c.ZIPcode = dz.destzip
WHERE 
SUBSTRING(l.ZIP, 1, 5) NOT IN (SELECT Destzip FROM [un_tracking].dbo.DestinationZipCode ) and State in ('CA', 'AZ', 'NV')
order by city



Select * FROM [un_billing].dbo.PRICEPLANZONEZIP
where zip = '95659'

-- End PricePlanZoneZip

-- Find UnknownZips with similar assigned city names

Select State, city, zip, (Select BranchID from DestinationZipcode where destzip in (
Select zipcode from City where name = location.city)) as Branch from location where customerid = 5137 and zip not in (Select destzip from destinationzipcode)

Select BranchID from DestinationZipcode where destzip in (
Select zipcode from City where name = 'Union City')

-- End Similar City Search

-- Find Duplicate Addresses and unassigned LocIDs

SELECT     CustomerID, LocationID, NAME, Address1, Address2, City, State, Zip, CONTACT, PHONE, ACTIVE, EMAIL, AddressID, Password
FROM         Location
WHERE     ((CustomerID + '-' + LocationID) IN
                          (SELECT     CustomerID + '-' + LocationID AS LocID
                            FROM          Location_All
                            WHERE      (ACTIVE = 'Y')
                            GROUP BY CustomerID, LocationID
                            HAVING      (COUNT(LocationID) > 1))) AND (ACTIVE = 'Y')
ORDER BY CustomerID, LocationID
-- Acct#20000, LocID 0036


SELECT     CustomerID, LocationID, NAME, Address1, Address2, City, State, Zip, CONTACT, PHONE, ACTIVE, EMAIL, AddressID, Password
FROM         Location
WHERE     ((Address1) IN
                          (SELECT    Address1 AS LocID
                            FROM          Location_All
                            WHERE      (ACTIVE = 'Y')
                            GROUP BY CustomerID, Address1
                            HAVING      (COUNT(Address1) > 1))) AND (ACTIVE = 'Y')
ORDER BY CustomerID, Address1


-- Find Duplicate Addresses By Address1
SELECT     CustomerID, LocationID, NAME, Address1, Address2, City, State, Zip, CONTACT, PHONE, ACTIVE, EMAIL, AddressID, Password
FROM         Location
WHERE     (ACTIVE = 'Y') AND (Address1 IN
                          (SELECT     Address1 AS LocID
                            FROM          Location_All
                            WHERE      (ACTIVE = 'Y')
                            GROUP BY CustomerID, Address1
                            HAVING      (COUNT(Address1) > 1))) AND (CustomerID NOT IN ('10000', '25141', '25140', '25149', '5630'))
ORDER BY CustomerID, Address1

