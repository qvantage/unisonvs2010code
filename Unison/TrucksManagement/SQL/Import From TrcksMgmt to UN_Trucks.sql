delete from UN_TRUCKS.dbo.DailyActivity;
set identity_insert UN_TRUCKS.dbo.DailyActivity on;
Insert into UN_TRUCKS.dbo.DailyActivity(Act_ID, Act_Date, Route, Driver_ID, Driver, Office_ID, Truck_Invent_ID, Start_Miles, End_Miles, Fuel, Inv_No, Inv_Beg_Date, Inv_End_Date)
Select Act_ID, Act_Date, Route, Driver_ID, Driver, Office_ID, Truck_Invent_ID, Start_Miles, End_Miles, Fuel, Inv_No, Inv_Beg_Date, Inv_End_Date from ntsrvr.Trucksmanagement.dbo.DailyActivity
set identity_insert UN_TRUCKS.dbo.DailyActivity off;

-- ===================================================================================

delete from UN_TRUCKS.dbo.EmployeesBase;
set identity_insert UNISON.dbo.EmployeesBase on;
Insert into UN_TRUCKS.dbo.EmployeesBase(ID, FirstName, MiddleName, LastName, Status, EmplGroupID, CreateDate, StatusDate)
Select * from ntsrvr.Trucksmanagement.dbo.EmployeesBase
set identity_insert UNISON.dbo.EmployeesBase off;

-- ===================================================================================

delete from UN_TRUCKS.dbo.Inventory;
set identity_insert UN_TRUCKS.dbo.Inventory on;
Insert into UN_TRUCKS.dbo.Inventory(Truck_Invent_ID, TruckID, Lic_Plate, VIN, Provider_ID, Provider, Date_In, Miles_In, Office_In_ID, Office_In, Operator_In, Date_Out, Miles_Out, Office_Out_ID, Office_Out, Operator_Out, [Truck Size], Remarks)
Select * from ntsrvr.Trucksmanagement.dbo.Inventory
-- select * from UN_TRUCKS.dbo.Inventory
set identity_insert UN_TRUCKS.dbo.Inventory off;

-- ===================================================================================

