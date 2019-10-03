-- INSERT INTO UN_HRTimeCardOfficeRights
-- SELECT     'JAN' AS UserID, 'TPC' AS Company_Code, '' AS Division, so.ID
-- FROM         UNISON.dbo.SERVICEOFFICES so

--SELECT Obj_Name, SUM([View]) AS [VIEW], SUM(Edit) AS Edit, SUM([Delete]) AS [DELETE], SUM([Print]) AS [PRINT] FROM (SELECT * FROM UN_CFG.dbo.UN_Rights WHERE Company_Code = 'TPC' And UserID = 'TEST'       UNION       SELECT * FROM UN_CFG.dbo.UN_Rights WHERE Company_Code = 'TPC' And userid IN  (SELECT Group_Code FROM UN_CFG.dbo.UN_UserMemberships WHERE UserID = 'TEST')) u GROUP BY Obj_Name ORDER BY Obj_Name 

--Insert into  UN_HRTimeCardOfficeRights
--Select 'ADMINS' as UserID, 'TPC' as Company_Code, '' as Division, so.ID as OfficeID, '1' as TimeCardInput, '1' as EmployeeSetup from unison.dbo.serviceoffices so

-- Select Group_Code as UserID from UN_UserMemberships where userid = 'JAN'
-- union 
-- Select 'JAN' as UserID

-- Select Obj_Name, SUM([View]) AS [VIEW], SUM(Edit) AS Edit, SUM([Delete]) AS [DELETE], SUM([Print]) AS [PRINT] 
-- from UN_CFG.dbo.UN_Rights 
-- where Company_Code = 'TPC' And UserID IN (Select Group_Code as UserID from UN_UserMemberships where userid = '' UNION Select '' as UserID) 
-- group by Obj_Name ORDER BY Obj_Name 



