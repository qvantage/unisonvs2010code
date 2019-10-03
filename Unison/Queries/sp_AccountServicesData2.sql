Create procedure Ali2 @@AccountID  varchar(10), @@SID  varchar(10), @@SIDSign  varchar(1)
as
declare @@SID2 varchar(10)
declare @Weekly as Char(1)
if @@SIDSign = '=' 
begin
 Set @@SID2 = @@SID
end
else if @@SIDSign = '>'
begin
	Select top 1 @@SID2 = ID from AccountServices where AccountID = @@AccountID and ID > @@SID order by ID Asc
end
else
begin
	Select top 1 @@SID2 = ID from AccountServices where AccountID = @@AccountID and ID < @@SID order by ID desc
end
Select 'SVC' as Tbl, mft2.rowid, mft2.AccountID, mft2.ID as SID, c.name as AccountName 
             , mft2.CompName as [Location Name], mft2.Street, mft2.CityName as City, mft2.State, mft2.ZipCode, mft2.Phone1, mft2.Phone2 
             , mft2.Remarks, mft2.StartDate, mft2.EndDate, mft2.OpenTime, mft2.CloseTime, mft2.DoorKey, mft2.BoxKey, mft2.InternalRef, mft2.AccountRef 
             , mft2.TimeFrameID, isnull(tf.Name, '') as [Time Frame], mft2.ServiceID, isnull(s.Name, '') as Service, mft2.ServiceTypeID, isnull(stp.Name, '') as [Service Type] 
             , mft2.PackageID, isnull(p.Name, '') as Package, mft2.Charge, mft2.DailyAvgChg as [Daily Avg], mft2.InfoSID 
             , c.BCycleCode , mft2.SchedType, c.NRVNU, mft2.NonPrintRemark as [Non Printable Remark] 
             FROM (((((AccountServices mft2 LEFT OUTER JOIN 
             Customer c ON mft2.accountid = c.id) LEFT OUTER JOIN 
             TimeFrames tf ON mft2.TimeFrameID = tf.ID) LEFT OUTER JOIN 
             Services s ON mft2.ServiceID = s.ID) LEFT OUTER JOIN 
             ServiceTypes stp ON mft2.ServiceTypeID = stp.ID) 
             LEFT OUTER JOIN PackageTypes p ON mft2.PackageID = p.ID) 
	     where mft2.AccountID = @@AccountID AND mft2.ID = @@SID2
             ORDER BY mft2.ID;

Select 'SCH' as Tbl, [ID], [Day], ServiceDate as SvcDate, OfficeID as Ofc, RouteNo as Rte, STime as STm, CTime as CTm, StopNo as Stp, Charge as Chg from ServiceSchedules where AccountID = @@AccountID AND SID = @@SID2 Order by ID;
Select 'GRP' as Tbl, mft3.rowid, mft3.AccountID, mft3.ID as SID, c.name as AccountName 
             , mft3.CompName as [Location Name], mft3.Street, mft3.CityName as City, mft3.State, mft3.ZipCode, mft3.Phone1, mft3.Phone2 
             , mft3.Remarks, mft3.StartDate, mft3.EndDate, mft3.OpenTime, mft3.CloseTime, mft3.DoorKey, mft3.BoxKey, mft3.InternalRef, mft3.AccountRef 
             , mft3.TimeFrameID, isnull(tf.Name, '') as [Time Frame], mft3.ServiceID, isnull(s.Name, '') as Service, mft3.ServiceTypeID, isnull(stp.Name, '') as [Service Type] 
             , mft3.PackageID, isnull(p.Name, '') as Package, mft3.Charge, mft3.DailyAvgChg as [Daily Avg], mft3.InfoSID 
             , c.BCycleCode , mft3.SchedType, c.NRVNU, mft3.NonPrintRemark as [Non Printable Remark] 
             FROM (((((AccountServices mft3 LEFT OUTER JOIN 
             Customer c ON mft3.accountid = c.id) LEFT OUTER JOIN 
             TimeFrames tf ON mft3.TimeFrameID = tf.ID) LEFT OUTER JOIN 
             Services s ON mft3.ServiceID = s.ID) LEFT OUTER JOIN 
             ServiceTypes stp ON mft3.ServiceTypeID = stp.ID) 
             LEFT OUTER JOIN PackageTypes p ON mft3.PackageID = p.ID) 
	     Where convert(varchar, mft3.AccountID)+convert(varchar,mft3.ID) in (Select convert(varchar, AccountID)+convert(varchar,SID) from ServiceGroupMembers where SGroupID in (select sgroupID from ServiceGroupMembers Where ServiceGroupMembers.AccountID = @@AccountID AND ServiceGroupMembers.SID = @@SID2))
             ORDER BY mft3.ID;
