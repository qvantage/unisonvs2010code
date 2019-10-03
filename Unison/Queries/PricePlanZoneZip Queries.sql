--Update priceplanzonezip set zip = substring(zip, 1, 5)
Select * from priceplanzonezip where  substring(zip, 1, 5) in (Select substring(zip, 1, 5) from priceplanzonezip group by substring(zip, 1, 5) having count(substring(zip, 1, 5)) > 1)

-- Add Zip codes from locations of Any Account to CA
Select  distinct '1' as ZoneID, substring(l.zip, 1, 5) as Zip
from location l 
where substring(l.zip, 1, 5) not in (select substring(zip, 1, 5) from priceplanzonezip where zoneid = 1) 
and l.state = 'CA'
--AND l.customerid in ('25140', '25141') 

-- Add Zip codes from locations of INGRAM to INGNV
insert into priceplanzonezip
Select distinct '4' as ZoneID, substring(l.zip, 1, 5) as Zip
from location l 
where substring(l.zip, 1, 5) not in (select substring(zip, 1, 5) from priceplanzonezip where zoneid = 4 ) 
and l.state = 'NV'
AND l.city <> 'RENO' 

Delete from priceplanzonezip 
where zip in
(Select substring(l.zip, 1, 5) as Zip
from location l 
where  city = 'RENO' and customerid in ('25140', '25141') 
and l.state = 'NV') and zoneid = 4


Select * from priceplanzonezip
where zoneid = 1 
and zip not in (Select  distinct substring(l.zip, 1, 5) as Zip
from location l 
where l.state = 'CA' )
And zip not in 
(Select  distinct l.zipcode as Zip
from City l 
where 
l.statecode = 'CA')


Select  l.*
--update location set STATE = 'NV' 
from location l 
where l.state = 'CA'
and l.zip like '8%'

Select * from priceplanzonezip
where zoneid = 1 
And zip not in 
(Select  distinct l.zipcode as Zip
from City l 
where 
l.statecode = 'CA')

-- Add zips to CITY table
insert into city(Name, ZipCode, StateCode)
Select distinct rtrim(city), substring(zip,1,5), State from Location
where State = 'CA' 
And substring(zip, 1, 5) not in 
(Select  l.zipcode as Zip
from City l 
where 
l.statecode = 'CA')
And substring(zip, 1, 5) <> '92668'


Delete From priceplanzonezip where zoneid = 1 and zip like '8%'


Select * From priceplanzonezip where zoneid = 4 and zip not like '8%'

Select * from priceplanzonezip
where zoneid = 4
and zip not in (Select  distinct substring(l.zip, 1, 5) as Zip
from location l 
where l.state = 'NV' )
And zip not in 
(Select  distinct l.zipcode as Zip
from City l 
where 
l.statecode = 'NV')


