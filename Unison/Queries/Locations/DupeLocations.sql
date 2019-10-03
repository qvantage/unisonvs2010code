-- Duplicate Addresses

SELECT     CustomerID, LocationID, NAME, Address1, Address2, City, State, Zip, CONTACT, PHONE, ACTIVE, EMAIL, AddressID, Password
FROM         Location
WHERE     (ACTIVE = 'Y') AND (Address1 IN
                          (SELECT     Address1 AS LocID
                            FROM          Location_All
                            WHERE      (ACTIVE = 'Y')
                            GROUP BY CustomerID, Address1
                            HAVING      (COUNT(Address1) > 1))) AND (CustomerID NOT IN ('10000', '25141', '25140', '25149', '5630'))
ORDER BY CustomerID, Address1