Drop Proc EmployeePeriodIncomeDeductions;
CREATE PROCEDURE EmployeePeriodIncomeDeductions @PAYDATE as DateTime 
AS
SELECT     dbo.EmployeesBase.ID AS EmployeeID, dbo.EmployeesBase.FirstName, dbo.EmployeesBase.LastName, dbo.EMPLOYEEMISCCHARGES.PayrollDate, 
                      dbo.EMPLOYEEMISCCHARGES.Description AS Description, dbo.EMPLOYEEMISCCHARGES.Amount, dbo.EMPLOYEEMISCCHARGES.Processed, dbo.EMPLOYEEMISCCHARGES.Type
FROM         dbo.EMPLOYEEMISCCHARGES INNER JOIN
                      dbo.EmployeesBase ON dbo.EMPLOYEEMISCCHARGES.EmployeeID = dbo.EmployeesBase.ID
Where dbo.EmployeeMiscCharges.PayrollDate = @PAYDATE
UNION
SELECT     dbo.EmployeesBase.ID AS EmployeeID, dbo.EmployeesBase.FirstName, dbo.EmployeesBase.LastName, NULL AS PayrollDate, 
                      d .Deduction AS Description, ed.Amount, 0 AS Processed, 'D' as Type
FROM         EmployeeDeductions ed INNER JOIN
                      dbo.EmployeesBase ON ed.EmployeeID = dbo.EmployeesBase.ID INNER JOIN
                      Dbo.Deductions d ON ed.DeductionID = d .DeductionID
WHERE  NOT EXISTS (SELECT     emc.employeeid
                   FROM          EMPLOYEEMISCCHARGES emc
                   WHERE      (emc.PayrollDate = @PAYDATE ) AND emc.type = 'D')

exec EmployeePeriodIncomeDeductions '12/11/2005'