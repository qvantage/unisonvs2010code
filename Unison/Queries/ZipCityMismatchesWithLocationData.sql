Select * from manifest where substring(tozip,1, 5) not in (Select DestZip from DestinationZipcode)
and datetime >= '02/23/2006'

Select * from manifest where substring(tozip,1, 5) not in (Select Zipcode from city)
and datetime >= '02/23/2006'


Select * from location where substring(zip,1, 5) not in (Select Zipcode from city)

Select * from location where substring(zip,1, 5) not in (Select DestZip from DestinationZipcode)

Select l.CustomerID, l.locationid, l.Address1, l.City, l.State, l.Zip from location l where substring(zip,1, 5)+upper(rtrim(City)) not in (Select Zipcode+upper(rtrim(name)) from city)

Select l.CustomerID, l.locationid, l.Address1, l.City, l.State, l.Zip, c.Name as CityName, c.zipcode from location l outer join city c on substring(l.zip,1, 5)+upper(rtrim(l.City)) <> (Select Zipcode+upper(rtrim(name)) from city)
