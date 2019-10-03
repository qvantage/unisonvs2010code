Select ead.EmployeeID, ead.PayrollEnding, ead.DeptNo, Sum(ead.RegHrs) as TotRegHrs, Sum(ead.OTHrs) as TotOTHrs, Sum(ead.DTHrs) as TotDTHrs 
from UN_HR.dbo.EmployeeActivityDetail ead 
where ead.Processed = 0 AND ead.PayrollEnding = '05/14/2006' 
group by ead.EmployeeID, ead.PayrollEnding, ead.DeptNo
order by employeeid, deptno


Select employeeid, deptno from employeeactivitydetail
where payrollending = '05/28/2006'
and convert(varchar, employeeid)+convert(varchar,deptno) not in (Select convert(varchar, employeeid)+convert(varchar,deptno) from employeeactivity where payrolldate = '05/28/2006')
group by employeeid, deptno
order by employeeid , deptno

-- Insert Query For adding Time-Card Inputs that are not added yet, to the totals 
Insert into UN_HR.dbo.EmployeeActivity(PayrollDate, EmployeeID, OfficeID, Office, DeptNo, RegHrs, OTHrs, DTHrs, MileageRate, PayRate, WCCode, ClassID, Class, HrsPay  ) 
Select ead.PayrollEnding, ead.EmployeeID, ead.OfficeID, ead.Office, ead.DeptNo, Sum(ead.RegHrs) as RegHrsTotal, Sum(ead.OTHrs) as OTHrsTotal, Sum(ead.DTHrs) as DTHrsTotal  , max(ep.MileageRate) as MileageRate, max(ep.PayRate) as PayRate, max(ep.WCCode) as WCCode, max(ep.ClassiD) as ClassID, max(cl.Class) as Class  , max(ep.PayRate) * ( Sum(ead.RegHrs)+ (1.5 * Sum(ead.OTHrs)) +  (2. * Sum(ead.DTHrs)) ) as HrsPay  
from UN_HR.dbo.EmployeeActivityDetail ead inner join UN_HR.dbo.EmployeePayRates ep 
on ead.EmployeeID = ep.EmployeeID and ead.DeptNo = ep.DeptNo  left outer join UN_HR.dbo.Classes cl on ep.Classid = cl.Classid  
where ead.Processed = 0 AND ead.payrollending = '05/14/2006' 
and convert(varchar, ead.employeeid)+convert(varchar,ead.deptno) not in (Select convert(varchar, employeeid)+convert(varchar,deptno) from employeeactivity where payrolldate = '05/14/2006')
group by ead.PayrollEnding, ead.EmployeeID, ead.DeptNo, ead.OfficeID, ead.Office; 



-- Update query to fix the wrong totals of the input cards in EMPLOYEEACTIVITY

Update UN_HR.dbo.EmployeeActivity SET  RegHrs = ead.TotRegHrs  , OTHrs = ead.TotOTHrs  , DTHrs = ead.TotDTHrs  , HrsPay = (ea.PayRate) * ( ead.TotRegHrs+ (1.5 * ead.TotOTHrs) +  (2. * ead.TotDTHrs) )   
--select ea.*
From UN_HR.dbo.EmployeeActivity ea inner join  
(Select ead.EmployeeID, ead.PayrollEnding, ead.DeptNo, Sum(ead.RegHrs) as TotRegHrs, Sum(ead.OTHrs) as TotOTHrs, Sum(ead.DTHrs) as TotDTHrs from UN_HR.dbo.EmployeeActivityDetail ead where ead.Processed = 0 AND ead.PayrollEnding = '05/14/2006' group by ead.EmployeeID, ead.PayrollEnding, ead.DeptNo) ead  
on ea.EmployeeID = ead.EmployeeID AND ea.DeptNo = ead.DeptNo And ea.PayrollDate = ead.PayrollEnding   
where ea.PayrollDate = '05/14/2006' 
--order by ea.employeeid, ea.deptno



-- Adding a Processed Payrol to the table for all divisions
Select '04/30/2006' as PayrollEnding, '1' as Processed, ead.Division from EmployeeActivityDetail ead where ead.payrollending = '04/30/2006' group by ead.division


