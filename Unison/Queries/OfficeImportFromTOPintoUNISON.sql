Insert into  unison.dbo.SERVICEOFFICES(ID, NAME, Contact, STREET, Address2, CITY, STATE, ZIPCODE
, PHONE1, EMAIL, Password, CustomerID,  Active)
SELECT     BranchID, Name, Contact, Address1, Address2, City, State, Zip,Phone, Email, Password, CustomerID
, '1' as Active
FROM         [top].dbo.BRANCH
WHERE     (BranchID = 10)
