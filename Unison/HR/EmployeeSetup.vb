Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Imaging
Imports TTSI.UTILITES

Public Class EmployeeSetup
    Inherits System.Windows.Forms.Form

    'Dim SQLSelect As String = _
    '                        " Select eb.ID, eb.FirstName, eb.MiddleName, eb.LastName, eb.Status " & _
    '                        " , eb.EmplGroupID, eb.CreateDate as CreateDate, isnull(eb.StatusDate, '') as StatusDate, " & _
    '                        " eg.Name as EmplGroup " & _
    '                        " ,ei.DOB, ei.Gender, ei.Race, ei.Address1, ei.Address2, ei.City, ei.State, ei.Zip, " & _
    '                        " ei.Phone, ei.Phone2, ei.Cell, ei.email, ei.SSN, ei.DLN, ei.AutoInsPolNum, ei.AutoInsExpDate " & _
    '                        " From " & HRTblPath & "EmployeesBase eb, " & HRTblPath & "EmployeeGroups eg" & _
    '                        ", " & HRTblPath & "EmployeeInfo ei " & _
    '                        " Where eb.EmplGroupID *= eg.ID " & _
    '                        " AND eb.ID *= ei.EmployeeID " & _
    '                        " Order by eb.ID "

    'Dim SQLSelect2 As String = _
    '                        " Select eb.ID, eb.FirstName, eb.MiddleName, eb.LastName, eb.Status, eb.StatusComment " & _
    '                        " , eb.EmplGroupID, isnull(eb.HireDate,'') as HireDate, eb.CreateDate , isnull(eb.StatusDate, '') as StatusDate " & _
    '                        " , eg.Name AS EmplGroup " & _
    '                        " , ei.DOB, ei.Gender, ei.Race, ei.Marital_Status, ei.Address1, ei.Address2, ei.City, ei.State, ei.Zip " & _
    '                        " , ei.Phone, ei.Phone2, ei.Cell, ei.email, ei.SSN, ei.DLN, ei.DLExpDate " & _
    '                        " , ei.AutoInsName, ei.AutoInsPhone, ei.AutoInsPolNum, ei.AutoInsExpDate, ei.DMVPull " & _
    '                        " , eb.FirstName + ' ' + eb.LastName as EmployeeName, eb.Company " & _
    '                        " , eb.OfficeID " & _
    '                        " From " & HRTblPath & "EmployeesBase eb Left Outer Join " & HRTblPath & "EmployeeInfo ei On eb.ID = ei.EmployeeID " & _
    '                        " Left Outer Join " & HRTblPath & "EmployeeGroups eg on eb.EmplGroupID = eg.ID " & _
    '                        " Order by eb.ID "


    Dim SQLSelect2 As String = _
                           " Select eb.ID, eb.FirstName, eb.MiddleName, eb.LastName, eb.Status, eb.StatusComment " & _
                           " , eb.EmplGroupID, isnull(eb.HireDate,'') as HireDate, eb.CreateDate , isnull(eb.StatusDate, '') as StatusDate " & _
                           " , eg.Name AS EmplGroup " & _
                           " , ei.DOB, ei.Gender, ei.Race, ei.Marital_Status, ei.Address1, ei.Address2, ei.City, ei.State, ei.Zip " & _
                           " , ei.Phone, ei.Phone2, ei.Cell, ei.email, ei.SSN, ei.DLN, ei.DLExpDate " & _
                           " , ei.AutoInsName, ei.AutoInsPhone, ei.AutoInsPolNum, ei.AutoInsExpDate, ei.DMVPull " & _
                           " , eb.FirstName + ' ' + eb.LastName as EmployeeName, eb.Company " & _
                           " , eb.OfficeID " & _
                           " From " & HRTblPath & "EmployeesBase eb Left Outer Join " & HRTblPath & "EmployeeInfo ei On eb.ID = ei.EmployeeID " & _
                           " Left Outer Join " & HRTblPath & "EmployeeGroups eg on eb.EmplGroupID = eg.ID " & _
                           " Order by eb.ID "
    '" Left Outer Join " & HRTblPath & "EmployeeBadgeInfo ebi on eb.ID = ebi.EmployeeID " & _

    'Dim SQLSelect2 As String = _
    '                      " Select eb.ID, eb.FirstName, eb.MiddleName, eb.LastName, eb.Status, eb.StatusComment " & _
    '                      " , eb.EmplGroupID, isnull(eb.HireDate,'') as HireDate, eb.CreateDate , isnull(eb.StatusDate, '') as StatusDate " & _
    '                      " , eg.Name AS EmplGroup " & _
    '                      " , ei.DOB, ei.Gender, ei.Race, ei.Marital_Status, ei.Address1, ei.Address2, ei.City, ei.State, ei.Zip " & _
    '                      " , ei.Phone, ei.Phone2, ei.Cell, ei.email, ei.SSN, ei.DLN, ei.DLExpDate " & _
    '                      " , ei.AutoInsName, ei.AutoInsPhone, ei.AutoInsPolNum, ei.AutoInsExpDate, ebi.HairCode, ebi.EyesCode, ebi.EmployeeHeight, ebi.EmployeeWeight, ei.DMVPull " & _
    '                      " , eb.FirstName + ' ' + eb.LastName as EmployeeName, eb.Company " & _
    '                      " , eb.OfficeID " & _
    '                      " From " & HRTblPath & "EmployeesBase eb Left Outer Join " & HRTblPath & "EmployeeInfo ei On eb.ID = ei.EmployeeID " & _
    '                      " Left Outer Join " & HRTblPath & "EmployeeGroups eg on eb.EmplGroupID = eg.ID " & _
    '                      " Left Outer Join " & HRTblPath & "EmployeeBadgeInfo ebi On ei.EmployeeID = ebi.EmployeeID" & _
    '                      " Order by eb.ID "

    Dim SQLSelectBase As String = _
                            " Select eb.ID, eb.FirstName, eb.MiddleName, eb.LastName, eb.Status, eb.StatusComment " & _
                            " , eb.EmplGroupID, convert(varchar, eb.HireDate, 101) as HireDate, convert(varchar, eb.CreateDate, 101) as CreateDate, isnull(eb.StatusDate, '') as StatusDate " & _
                            " , eb.Company, eb.OfficeID " & _
                            " From " & AppTblPath & "EmployeesBase eb " & _
                            " Order by eb.ID "
    '" Left Outer Join " & HRTblPath & "EmployeeBadgeInfo ebi on eb.ID = ebi.EmployeeID " & _

    Dim SQLSelectAdtl As String = _
                            " Select " & _
                            " ei.DOB, ei.Gender, ei.Race, ei.Marital_Status, ei.Address1, ei.Address2, ei.City, ei.State, ei.Zip, " & _
                            " ei.Phone, ei.Phone2, ei.Cell, ei.email, ei.SSN, ei.DLN, ei.DLExpDate, ei.AutoInsName, ei.AutoInsPhone, ei.AutoInsPolNum, ei.AutoInsExpDate " & _
                            " From " & HRTblPath & "EmployeeInfo ei " & _
                            " Order by ei.EmployeeID "

    'Dim SQLSelectAdtl As String = _
    '                        " Select " & _
    '                        " ei.EmployeeID, ei.DOB, ei.Gender, ei.Race, ei.Marital_Status, ei.Address1, ei.Address2, ei.City, ei.State, ei.Zip, " & _
    '                        " ei.Phone, ei.Phone2, ei.Cell, ei.email, ei.SSN, ei.DLN, ei.DLExpDate, ei.AutoInsName, ei.AutoInsPhone, ei.AutoInsPolNum, ei.AutoInsExpDate, ebi.HairCode, ebi.EyesCode, ebi.EmployeeHeight, ebi.EmployeeWeight " & _
    '                        " From " & HRTblPath & "EmployeeInfo ei " & _
    '                         " Left Outer Join " & HRTblPath & "EmployeeBadgeInfo ebi On ei.EmployeeID = ebi.EmployeeID" & _
    '                        " Order by ei.EmployeeID "

    'Dim sqlDeduction As String = "Select EmployeeID, RowID, ed.DeductionID, d.Deduction, Amount from " & HRTblPath & "EmployeeDeductions ed ,  " & HRTblPath & "Deductions d where ed.DeductionID = d.DeductionID AND EmployeeID = @EMPLID"
    Dim sqlDeduction As String = "Select EmployeeID, RowID, DeductionID, Amount from " & HRTblPath & "EmployeeDeductions ed where EmployeeID = @EMPLID"
    Dim sqlPay As String = "Select EmployeeID, DeptNo, ClassID, WCCode, PayRate, MileageRate from " & HRTblPath & "EmployeePayRates where EmployeeID = @EMPLID"
    Dim sqlVehicles As String = "Select RowID, LicPlate, State, EmployeeID, VIN, Make, Model, ModelYear, Color, Type, Mileage, StartDate, EndDate, Active, LastInspectDate, AutoInsName, AutoInsPolNum, AutoInsExpDate, AutoInsPhone, Remarks, AutoInsLimits from " & HRTblPath & "VEHICLES where EmployeeID = @EMPLID"


    Dim EmplCriteria As String = " WHERE eb.ID = @EmplID "
    Dim EmplCriteria2 As String = " WHERE ID = @EmplID "
    Dim EmplCriteria3 As String = " WHERE EmployeeID = @EmplID "
    'Dim EmplCriteria3 As String = " WHERE ei.EmployeeID = @EmplID "

    Dim MeText As String
    Dim dtSet As New DataSet
    Dim dvStates As New DataView
    Dim cmdTrans As SqlCommand
    Dim m_oColumn As Infragistics.Win.UltraWinGrid.UltraGridColumn = Nothing
    Dim delugrow As Infragistics.Win.UltraWinGrid.UltraGridRow
    Dim sPhotoFileName As String = ""
    Dim imageStatus As Boolean
    'Dim imageUploadStatus As Boolean = False
    'Dim employeeImageFullName As String

    Dim StatusTable, StatusTableActive, StatusTableHeight As New DataTable

#Region " Windows Form Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    Friend WithEvents tpBSet As System.Windows.Forms.TabPage
    Friend WithEvents tpAddInfo As System.Windows.Forms.TabPage
    Friend WithEvents tpPayInfo As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnPrev As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnEmplID As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents btnGroup As System.Windows.Forms.Button
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txbLName As System.Windows.Forms.TextBox
    Friend WithEvents txbEmplGroupID As System.Windows.Forms.TextBox
    Friend WithEvents txbEmplGroup As System.Windows.Forms.TextBox
    Friend WithEvents txbMName As System.Windows.Forms.TextBox
    Friend WithEvents txbFName As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents DTPicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents InsertMsg As System.Windows.Forms.Label
    Friend WithEvents btnSaveNew As System.Windows.Forms.Button
    Friend WithEvents EmplID As System.Windows.Forms.TextBox
    Friend WithEvents UltraGrid2 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents TabCtrl1 As System.Windows.Forms.TabControl
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Phone2 As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents DLN As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents SSN As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Address1 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Address2 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents City As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Email As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Phone1 As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents ZipCode As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents ucboDept As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents ucboClass As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents ucboWCCode As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents ucboState2 As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents txtPayEmplID As System.Windows.Forms.TextBox
    Friend WithEvents utPayRate As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utMileageRate As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents ucboDeduction As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents utDeductionAmount As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtDedEmplID As System.Windows.Forms.TextBox
    Friend WithEvents utRowID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents tpDeductions As System.Windows.Forms.TabPage
    Friend WithEvents utEmployeeName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents ucboCompany As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents utOfficeName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnSelect As System.Windows.Forms.Button
    Friend WithEvents utOfficeID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraDate1 As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents ucboGender As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents ucboRace As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents ucboMaritalStatus As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents EmplID2 As System.Windows.Forms.TextBox
    Friend WithEvents umeCell As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents utAutoInsName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents umeAutoInsPhone As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents utAutoInsPolNum As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents udtAutoExp As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents txtCreateDate As System.Windows.Forms.TextBox
    Friend WithEvents txtStatusComment As System.Windows.Forms.TextBox
    Friend WithEvents Label37 As System.Windows.Forms.Label
    Friend WithEvents utDLExp As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents DTPicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents tpVehicles As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents UltraTextEditor1 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents UltraTextEditor2 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents UltraTextEditor3 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents UltraTextEditor4 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents UltraTextEditor6 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents UltraGrid3 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraTextEditor9 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents ucboStatePlate As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents udtStartDate As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents txtVehEmplID As System.Windows.Forms.TextBox
    Friend WithEvents utVehRowID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utMileage As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents ucboType As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents cboActive As System.Windows.Forms.ComboBox
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents GroupBox10 As System.Windows.Forms.GroupBox
    Friend WithEvents udtEndDate As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents uteAutoInsName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents uteAutoInsPolNum As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents uteAutoInsPhone As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents udtExpDate As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents btnAutoIns As System.Windows.Forms.Button
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents utModelYear As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraGrid4 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents udtLastInspDate As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents utePolicyLimits As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents uchDMVPull As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents ContextMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents bUpload As System.Windows.Forms.Button
    Friend WithEvents OpenFileDialog As System.Windows.Forms.OpenFileDialog
    Friend WithEvents PictureBox As System.Windows.Forms.PictureBox
    Friend WithEvents btnRemove As System.Windows.Forms.Button
    Friend WithEvents pbDefaultPhoto As System.Windows.Forms.PictureBox
    Friend WithEvents btnPrintBadge As System.Windows.Forms.Button
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents Weight As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents cboHeight As System.Windows.Forms.ComboBox
    Friend WithEvents ucboHair As System.Windows.Forms.ComboBox
    Friend WithEvents ucboEyes As System.Windows.Forms.ComboBox
    Friend WithEvents btnPrnRepId As System.Windows.Forms.Button
    Friend WithEvents btnResetOdometer As System.Windows.Forms.Button
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents udtLastOdoCheck As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(EmployeeSetup))
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance14 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance15 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance16 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance17 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance18 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance19 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance20 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance21 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance22 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance23 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance24 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance25 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance26 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance27 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance28 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance29 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance30 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance31 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance32 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance33 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance34 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance35 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance36 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance37 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance38 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance39 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance40 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance41 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance42 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance43 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance44 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance45 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance46 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance47 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance48 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance49 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance50 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance51 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance52 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance53 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.TabCtrl1 = New System.Windows.Forms.TabControl
        Me.tpBSet = New System.Windows.Forms.TabPage
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Label37 = New System.Windows.Forms.Label
        Me.txtStatusComment = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.cboStatus = New System.Windows.Forms.ComboBox
        Me.ContextMenu1 = New System.Windows.Forms.ContextMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.Label5 = New System.Windows.Forms.Label
        Me.DTPicker1 = New System.Windows.Forms.DateTimePicker
        Me.pbDefaultPhoto = New System.Windows.Forms.PictureBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.DTPicker2 = New System.Windows.Forms.DateTimePicker
        Me.EmplID2 = New System.Windows.Forms.TextBox
        Me.utOfficeName = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utOfficeID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label29 = New System.Windows.Forms.Label
        Me.btnSelect = New System.Windows.Forms.Button
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.txbLName = New System.Windows.Forms.TextBox
        Me.txtCreateDate = New System.Windows.Forms.TextBox
        Me.btnGroup = New System.Windows.Forms.Button
        Me.txbEmplGroupID = New System.Windows.Forms.TextBox
        Me.txbEmplGroup = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.txbMName = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.txbFName = New System.Windows.Forms.TextBox
        Me.ucboCompany = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.Label28 = New System.Windows.Forms.Label
        Me.PictureBox = New System.Windows.Forms.PictureBox
        Me.bUpload = New System.Windows.Forms.Button
        Me.btnRemove = New System.Windows.Forms.Button
        Me.tpAddInfo = New System.Windows.Forms.TabPage
        Me.UltraGrid4 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.ucboEyes = New System.Windows.Forms.ComboBox
        Me.ucboHair = New System.Windows.Forms.ComboBox
        Me.Weight = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.cboHeight = New System.Windows.Forms.ComboBox
        Me.Label60 = New System.Windows.Forms.Label
        Me.Label58 = New System.Windows.Forms.Label
        Me.Label59 = New System.Windows.Forms.Label
        Me.Label57 = New System.Windows.Forms.Label
        Me.uchDMVPull = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.Label38 = New System.Windows.Forms.Label
        Me.utDLExp = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label36 = New System.Windows.Forms.Label
        Me.udtAutoExp = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.utAutoInsPolNum = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label35 = New System.Windows.Forms.Label
        Me.umeAutoInsPhone = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
        Me.Label34 = New System.Windows.Forms.Label
        Me.utAutoInsName = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label33 = New System.Windows.Forms.Label
        Me.Label32 = New System.Windows.Forms.Label
        Me.ucboMaritalStatus = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.Label31 = New System.Windows.Forms.Label
        Me.ucboRace = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.Label30 = New System.Windows.Forms.Label
        Me.ucboGender = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.Label15 = New System.Windows.Forms.Label
        Me.UltraDate1 = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.ucboState2 = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.umeCell = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
        Me.Label26 = New System.Windows.Forms.Label
        Me.Phone2 = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
        Me.Label24 = New System.Windows.Forms.Label
        Me.Phone1 = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
        Me.Label25 = New System.Windows.Forms.Label
        Me.Email = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label23 = New System.Windows.Forms.Label
        Me.City = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.ZipCode = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label22 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Address2 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label27 = New System.Windows.Forms.Label
        Me.Address1 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.DLN = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.SSN = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.tpDeductions = New System.Windows.Forms.TabPage
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.utRowID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtDedEmplID = New System.Windows.Forms.TextBox
        Me.utDeductionAmount = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.ucboDeduction = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.tpPayInfo = New System.Windows.Forms.TabPage
        Me.UltraGrid2 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.utMileageRate = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utPayRate = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtPayEmplID = New System.Windows.Forms.TextBox
        Me.ucboWCCode = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.ucboClass = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.ucboDept = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.tpVehicles = New System.Windows.Forms.TabPage
        Me.UltraGrid3 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.udtLastOdoCheck = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label61 = New System.Windows.Forms.Label
        Me.btnResetOdometer = New System.Windows.Forms.Button
        Me.udtLastInspDate = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label50 = New System.Windows.Forms.Label
        Me.utModelYear = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label55 = New System.Windows.Forms.Label
        Me.GroupBox10 = New System.Windows.Forms.GroupBox
        Me.utePolicyLimits = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label56 = New System.Windows.Forms.Label
        Me.btnAutoIns = New System.Windows.Forms.Button
        Me.Label53 = New System.Windows.Forms.Label
        Me.uteAutoInsName = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label54 = New System.Windows.Forms.Label
        Me.uteAutoInsPolNum = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.udtExpDate = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label51 = New System.Windows.Forms.Label
        Me.Label52 = New System.Windows.Forms.Label
        Me.uteAutoInsPhone = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
        Me.ucboType = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.Label43 = New System.Windows.Forms.Label
        Me.utVehRowID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.txtVehEmplID = New System.Windows.Forms.TextBox
        Me.ucboStatePlate = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.Label49 = New System.Windows.Forms.Label
        Me.udtStartDate = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.UltraTextEditor9 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label47 = New System.Windows.Forms.Label
        Me.utMileage = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label46 = New System.Windows.Forms.Label
        Me.Label45 = New System.Windows.Forms.Label
        Me.UltraTextEditor6 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label44 = New System.Windows.Forms.Label
        Me.UltraTextEditor4 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label42 = New System.Windows.Forms.Label
        Me.UltraTextEditor3 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label41 = New System.Windows.Forms.Label
        Me.UltraTextEditor2 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label40 = New System.Windows.Forms.Label
        Me.UltraTextEditor1 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label39 = New System.Windows.Forms.Label
        Me.cboActive = New System.Windows.Forms.ComboBox
        Me.udtEndDate = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label48 = New System.Windows.Forms.Label
        Me.btnPrintBadge = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btnPrnRepId = New System.Windows.Forms.Button
        Me.btnSaveNew = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnNew = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.utEmployeeName = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.InsertMsg = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnPrev = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.btnEmplID = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.EmplID = New System.Windows.Forms.TextBox
        Me.OpenFileDialog = New System.Windows.Forms.OpenFileDialog
        Me.TabCtrl1.SuspendLayout()
        Me.tpBSet.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.utOfficeName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utOfficeID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucboCompany, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpAddInfo.SuspendLayout()
        CType(Me.UltraGrid4, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        CType(Me.Weight, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utDLExp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtAutoExp, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utAutoInsPolNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utAutoInsName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucboMaritalStatus, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucboRace, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucboGender, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDate1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucboState2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Email, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.City, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ZipCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Address2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Address1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DLN, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SSN, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpDeductions.SuspendLayout()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.utRowID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utDeductionAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucboDeduction, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpPayInfo.SuspendLayout()
        CType(Me.UltraGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.utMileageRate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utPayRate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucboWCCode, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucboClass, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucboDept, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.tpVehicles.SuspendLayout()
        CType(Me.UltraGrid3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox8.SuspendLayout()
        CType(Me.udtLastOdoCheck, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtLastInspDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utModelYear, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox10.SuspendLayout()
        CType(Me.utePolicyLimits, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uteAutoInsName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uteAutoInsPolNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtExpDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucboType, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utVehRowID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucboStatePlate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtStartDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraTextEditor9, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utMileage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraTextEditor6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraTextEditor4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraTextEditor3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraTextEditor2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraTextEditor1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtEndDate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.utEmployeeName, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TabCtrl1
        '
        Me.TabCtrl1.Controls.Add(Me.tpBSet)
        Me.TabCtrl1.Controls.Add(Me.tpAddInfo)
        Me.TabCtrl1.Controls.Add(Me.tpDeductions)
        Me.TabCtrl1.Controls.Add(Me.tpPayInfo)
        Me.TabCtrl1.Controls.Add(Me.tpVehicles)
        Me.TabCtrl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabCtrl1.Location = New System.Drawing.Point(0, 72)
        Me.TabCtrl1.Name = "TabCtrl1"
        Me.TabCtrl1.SelectedIndex = 0
        Me.TabCtrl1.Size = New System.Drawing.Size(664, 372)
        Me.TabCtrl1.TabIndex = 1
        '
        'tpBSet
        '
        Me.tpBSet.Controls.Add(Me.GroupBox4)
        Me.tpBSet.Controls.Add(Me.GroupBox2)
        Me.tpBSet.Location = New System.Drawing.Point(4, 22)
        Me.tpBSet.Name = "tpBSet"
        Me.tpBSet.Size = New System.Drawing.Size(656, 346)
        Me.tpBSet.TabIndex = 0
        Me.tpBSet.Text = "Basic Setup"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label37)
        Me.GroupBox4.Controls.Add(Me.txtStatusComment)
        Me.GroupBox4.Controls.Add(Me.Label3)
        Me.GroupBox4.Controls.Add(Me.cboStatus)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.DTPicker1)
        Me.GroupBox4.Controls.Add(Me.pbDefaultPhoto)
        Me.GroupBox4.Location = New System.Drawing.Point(13, 221)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(607, 72)
        Me.GroupBox4.TabIndex = 1
        Me.GroupBox4.TabStop = False
        '
        'Label37
        '
        Me.Label37.Location = New System.Drawing.Point(40, 40)
        Me.Label37.Name = "Label37"
        Me.Label37.Size = New System.Drawing.Size(64, 16)
        Me.Label37.TabIndex = 108
        Me.Label37.Text = "Comments:"
        '
        'txtStatusComment
        '
        Me.txtStatusComment.Location = New System.Drawing.Point(107, 40)
        Me.txtStatusComment.Name = "txtStatusComment"
        Me.txtStatusComment.Size = New System.Drawing.Size(320, 20)
        Me.txtStatusComment.TabIndex = 2
        Me.txtStatusComment.Tag = ".StatusComment"
        Me.txtStatusComment.Text = ""
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(47, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(47, 16)
        Me.Label3.TabIndex = 106
        Me.Label3.Text = "Status:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboStatus
        '
        Me.cboStatus.ContextMenu = Me.ContextMenu1
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Items.AddRange(New Object() {"Active", "Inactive", "Suspended", "Terminated"})
        Me.cboStatus.Location = New System.Drawing.Point(107, 16)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(104, 21)
        Me.cboStatus.TabIndex = 0
        Me.cboStatus.Tag = ".status"
        '
        'ContextMenu1
        '
        Me.ContextMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.Text = "Add Event Trigger"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(200, 16)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 16)
        Me.Label5.TabIndex = 105
        Me.Label5.Text = "Status Change Date:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DTPicker1
        '
        Me.DTPicker1.Checked = False
        Me.DTPicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPicker1.Location = New System.Drawing.Point(320, 16)
        Me.DTPicker1.Name = "DTPicker1"
        Me.DTPicker1.Size = New System.Drawing.Size(104, 20)
        Me.DTPicker1.TabIndex = 1
        Me.DTPicker1.Tag = ".StatusDate"
        '
        'pbDefaultPhoto
        '
        Me.pbDefaultPhoto.Image = CType(resources.GetObject("pbDefaultPhoto.Image"), System.Drawing.Image)
        Me.pbDefaultPhoto.Location = New System.Drawing.Point(460, 21)
        Me.pbDefaultPhoto.Name = "pbDefaultPhoto"
        Me.pbDefaultPhoto.Size = New System.Drawing.Size(133, 41)
        Me.pbDefaultPhoto.TabIndex = 133
        Me.pbDefaultPhoto.TabStop = False
        Me.pbDefaultPhoto.Tag = ""
        Me.pbDefaultPhoto.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.DTPicker2)
        Me.GroupBox2.Controls.Add(Me.EmplID2)
        Me.GroupBox2.Controls.Add(Me.utOfficeName)
        Me.GroupBox2.Controls.Add(Me.utOfficeID)
        Me.GroupBox2.Controls.Add(Me.Label29)
        Me.GroupBox2.Controls.Add(Me.btnSelect)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.txbLName)
        Me.GroupBox2.Controls.Add(Me.txtCreateDate)
        Me.GroupBox2.Controls.Add(Me.btnGroup)
        Me.GroupBox2.Controls.Add(Me.txbEmplGroupID)
        Me.GroupBox2.Controls.Add(Me.txbEmplGroup)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.txbMName)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.txbFName)
        Me.GroupBox2.Controls.Add(Me.ucboCompany)
        Me.GroupBox2.Controls.Add(Me.Label28)
        Me.GroupBox2.Controls.Add(Me.PictureBox)
        Me.GroupBox2.Controls.Add(Me.bUpload)
        Me.GroupBox2.Controls.Add(Me.btnRemove)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 16)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(607, 200)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'DTPicker2
        '
        Me.DTPicker2.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPicker2.Location = New System.Drawing.Point(104, 112)
        Me.DTPicker2.Name = "DTPicker2"
        Me.DTPicker2.Size = New System.Drawing.Size(104, 20)
        Me.DTPicker2.TabIndex = 5
        Me.DTPicker2.Tag = ".HireDate"
        '
        'EmplID2
        '
        Me.EmplID2.Location = New System.Drawing.Point(360, 16)
        Me.EmplID2.Name = "EmplID2"
        Me.EmplID2.Size = New System.Drawing.Size(24, 20)
        Me.EmplID2.TabIndex = 127
        Me.EmplID2.Tag = ".id"
        Me.EmplID2.Text = ""
        Me.EmplID2.Visible = False
        '
        'utOfficeName
        '
        Appearance1.ForeColor = System.Drawing.Color.Black
        Appearance1.ForeColorDisabled = System.Drawing.Color.Black
        Me.utOfficeName.Appearance = Appearance1
        Me.utOfficeName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utOfficeName.Enabled = False
        Me.utOfficeName.Location = New System.Drawing.Point(104, 137)
        Me.utOfficeName.Name = "utOfficeName"
        Me.utOfficeName.Size = New System.Drawing.Size(176, 21)
        Me.utOfficeName.TabIndex = 6
        Me.utOfficeName.Tag = ""
        '
        'utOfficeID
        '
        Appearance2.ForeColor = System.Drawing.Color.Black
        Appearance2.ForeColorDisabled = System.Drawing.Color.Black
        Me.utOfficeID.Appearance = Appearance2
        Me.utOfficeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utOfficeID.Location = New System.Drawing.Point(288, 137)
        Me.utOfficeID.Name = "utOfficeID"
        Me.utOfficeID.Size = New System.Drawing.Size(40, 21)
        Me.utOfficeID.TabIndex = 6
        Me.utOfficeID.Tag = ".OfficeID"
        '
        'Label29
        '
        Me.Label29.Location = New System.Drawing.Point(32, 139)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(72, 16)
        Me.Label29.TabIndex = 126
        Me.Label29.Text = "Office ID:"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnSelect
        '
        Me.btnSelect.Location = New System.Drawing.Point(344, 138)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(53, 20)
        Me.btnSelect.TabIndex = 7
        Me.btnSelect.Text = "Selec&t"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(32, 112)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(72, 16)
        Me.Label13.TabIndex = 111
        Me.Label13.Text = "Hired Date :"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(8, 88)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(97, 16)
        Me.Label16.TabIndex = 110
        Me.Label16.Text = "Employee Group :"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txbLName
        '
        Me.txbLName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txbLName.Location = New System.Drawing.Point(104, 64)
        Me.txbLName.Name = "txbLName"
        Me.txbLName.Size = New System.Drawing.Size(225, 20)
        Me.txbLName.TabIndex = 2
        Me.txbLName.Tag = ".LastName"
        Me.txbLName.Text = ""
        '
        'txtCreateDate
        '
        Me.txtCreateDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtCreateDate.Enabled = False
        Me.txtCreateDate.Location = New System.Drawing.Point(344, 112)
        Me.txtCreateDate.Name = "txtCreateDate"
        Me.txtCreateDate.TabIndex = 4
        Me.txtCreateDate.Tag = ".CreateDate.view"
        Me.txtCreateDate.Text = ""
        Me.txtCreateDate.Visible = False
        '
        'btnGroup
        '
        Me.btnGroup.Location = New System.Drawing.Point(343, 88)
        Me.btnGroup.Name = "btnGroup"
        Me.btnGroup.Size = New System.Drawing.Size(54, 20)
        Me.btnGroup.TabIndex = 4
        Me.btnGroup.Text = "Se&lect"
        '
        'txbEmplGroupID
        '
        Me.txbEmplGroupID.Location = New System.Drawing.Point(304, 88)
        Me.txbEmplGroupID.Name = "txbEmplGroupID"
        Me.txbEmplGroupID.Size = New System.Drawing.Size(25, 20)
        Me.txbEmplGroupID.TabIndex = 4
        Me.txbEmplGroupID.Tag = ".EmplGroupID"
        Me.txbEmplGroupID.Text = ""
        Me.txbEmplGroupID.Visible = False
        '
        'txbEmplGroup
        '
        Me.txbEmplGroup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txbEmplGroup.Location = New System.Drawing.Point(104, 88)
        Me.txbEmplGroup.Name = "txbEmplGroup"
        Me.txbEmplGroup.Size = New System.Drawing.Size(192, 20)
        Me.txbEmplGroup.TabIndex = 3
        Me.txbEmplGroup.Tag = ".EmplGroup.view"
        Me.txbEmplGroup.Text = ""
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(24, 64)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 16)
        Me.Label7.TabIndex = 108
        Me.Label7.Text = "Last Name :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(24, 40)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 16)
        Me.Label8.TabIndex = 107
        Me.Label8.Text = "Middle Name :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txbMName
        '
        Me.txbMName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txbMName.Location = New System.Drawing.Point(104, 40)
        Me.txbMName.Name = "txbMName"
        Me.txbMName.Size = New System.Drawing.Size(225, 20)
        Me.txbMName.TabIndex = 1
        Me.txbMName.Tag = ".MiddleName"
        Me.txbMName.Text = ""
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(32, 16)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 16)
        Me.Label9.TabIndex = 106
        Me.Label9.Text = "First Name :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txbFName
        '
        Me.txbFName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txbFName.Location = New System.Drawing.Point(104, 16)
        Me.txbFName.Name = "txbFName"
        Me.txbFName.Size = New System.Drawing.Size(225, 20)
        Me.txbFName.TabIndex = 0
        Me.txbFName.Tag = ".FirstName"
        Me.txbFName.Text = ""
        '
        'ucboCompany
        '
        Appearance3.ForeColor = System.Drawing.Color.Black
        Appearance3.ForeColorDisabled = System.Drawing.Color.Black
        Me.ucboCompany.Appearance = Appearance3
        Me.ucboCompany.AutoEdit = False
        Me.ucboCompany.DisplayMember = ""
        Me.ucboCompany.Location = New System.Drawing.Point(104, 166)
        Me.ucboCompany.Name = "ucboCompany"
        Me.ucboCompany.Size = New System.Drawing.Size(216, 21)
        Me.ucboCompany.TabIndex = 8
        Me.ucboCompany.Tag = ".Company..1.Companies.Company.Company"
        Me.ucboCompany.ValueMember = ""
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(13, 166)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(85, 16)
        Me.Label28.TabIndex = 122
        Me.Label28.Text = "Company:"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'PictureBox
        '
        Me.PictureBox.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.PictureBox.Image = CType(resources.GetObject("PictureBox.Image"), System.Drawing.Image)
        Me.PictureBox.Location = New System.Drawing.Point(447, 10)
        Me.PictureBox.Name = "PictureBox"
        Me.PictureBox.Size = New System.Drawing.Size(126, 132)
        Me.PictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox.TabIndex = 129
        Me.PictureBox.TabStop = False
        Me.PictureBox.Tag = ""
        '
        'bUpload
        '
        Me.bUpload.Location = New System.Drawing.Point(448, 146)
        Me.bUpload.Name = "bUpload"
        Me.bUpload.Size = New System.Drawing.Size(64, 20)
        Me.bUpload.TabIndex = 128
        Me.bUpload.Text = "&Upload"
        '
        'btnRemove
        '
        Me.btnRemove.Location = New System.Drawing.Point(515, 146)
        Me.btnRemove.Name = "btnRemove"
        Me.btnRemove.Size = New System.Drawing.Size(61, 20)
        Me.btnRemove.TabIndex = 131
        Me.btnRemove.Text = "Remove"
        '
        'tpAddInfo
        '
        Me.tpAddInfo.Controls.Add(Me.UltraGrid4)
        Me.tpAddInfo.Controls.Add(Me.GroupBox7)
        Me.tpAddInfo.Location = New System.Drawing.Point(4, 22)
        Me.tpAddInfo.Name = "tpAddInfo"
        Me.tpAddInfo.Size = New System.Drawing.Size(656, 346)
        Me.tpAddInfo.TabIndex = 1
        Me.tpAddInfo.Text = "Additional Info"
        '
        'UltraGrid4
        '
        Me.UltraGrid4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGrid4.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraGrid4.Location = New System.Drawing.Point(0, 180)
        Me.UltraGrid4.Name = "UltraGrid4"
        Me.UltraGrid4.Size = New System.Drawing.Size(656, 166)
        Me.UltraGrid4.TabIndex = 189
        Me.UltraGrid4.Tag = "EMPLOYEEINFO"
        Me.UltraGrid4.Text = "Auto Insurances"
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.ucboEyes)
        Me.GroupBox7.Controls.Add(Me.ucboHair)
        Me.GroupBox7.Controls.Add(Me.Weight)
        Me.GroupBox7.Controls.Add(Me.cboHeight)
        Me.GroupBox7.Controls.Add(Me.Label60)
        Me.GroupBox7.Controls.Add(Me.Label58)
        Me.GroupBox7.Controls.Add(Me.Label59)
        Me.GroupBox7.Controls.Add(Me.Label57)
        Me.GroupBox7.Controls.Add(Me.uchDMVPull)
        Me.GroupBox7.Controls.Add(Me.Label38)
        Me.GroupBox7.Controls.Add(Me.utDLExp)
        Me.GroupBox7.Controls.Add(Me.Label36)
        Me.GroupBox7.Controls.Add(Me.udtAutoExp)
        Me.GroupBox7.Controls.Add(Me.utAutoInsPolNum)
        Me.GroupBox7.Controls.Add(Me.Label35)
        Me.GroupBox7.Controls.Add(Me.umeAutoInsPhone)
        Me.GroupBox7.Controls.Add(Me.Label34)
        Me.GroupBox7.Controls.Add(Me.utAutoInsName)
        Me.GroupBox7.Controls.Add(Me.Label33)
        Me.GroupBox7.Controls.Add(Me.Label32)
        Me.GroupBox7.Controls.Add(Me.ucboMaritalStatus)
        Me.GroupBox7.Controls.Add(Me.Label31)
        Me.GroupBox7.Controls.Add(Me.ucboRace)
        Me.GroupBox7.Controls.Add(Me.Label30)
        Me.GroupBox7.Controls.Add(Me.ucboGender)
        Me.GroupBox7.Controls.Add(Me.Label15)
        Me.GroupBox7.Controls.Add(Me.UltraDate1)
        Me.GroupBox7.Controls.Add(Me.ucboState2)
        Me.GroupBox7.Controls.Add(Me.umeCell)
        Me.GroupBox7.Controls.Add(Me.Label26)
        Me.GroupBox7.Controls.Add(Me.Phone2)
        Me.GroupBox7.Controls.Add(Me.Label24)
        Me.GroupBox7.Controls.Add(Me.Phone1)
        Me.GroupBox7.Controls.Add(Me.Label25)
        Me.GroupBox7.Controls.Add(Me.Email)
        Me.GroupBox7.Controls.Add(Me.Label23)
        Me.GroupBox7.Controls.Add(Me.City)
        Me.GroupBox7.Controls.Add(Me.ZipCode)
        Me.GroupBox7.Controls.Add(Me.Label22)
        Me.GroupBox7.Controls.Add(Me.Label21)
        Me.GroupBox7.Controls.Add(Me.Label20)
        Me.GroupBox7.Controls.Add(Me.Address2)
        Me.GroupBox7.Controls.Add(Me.Label27)
        Me.GroupBox7.Controls.Add(Me.Address1)
        Me.GroupBox7.Controls.Add(Me.DLN)
        Me.GroupBox7.Controls.Add(Me.SSN)
        Me.GroupBox7.Controls.Add(Me.Label4)
        Me.GroupBox7.Controls.Add(Me.Label6)
        Me.GroupBox7.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox7.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(656, 180)
        Me.GroupBox7.TabIndex = 188
        Me.GroupBox7.TabStop = False
        '
        'ucboEyes
        '
        Me.ucboEyes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ucboEyes.Items.AddRange(New Object() {"Black", "Blue", "Brown", "Gray", "Green", "Hazel", "Dichromatic", "Pink", "Unknown"})
        Me.ucboEyes.Location = New System.Drawing.Point(360, 130)
        Me.ucboEyes.Name = "ucboEyes"
        Me.ucboEyes.Size = New System.Drawing.Size(107, 21)
        Me.ucboEyes.TabIndex = 214
        Me.ucboEyes.Tag = ""
        '
        'ucboHair
        '
        Me.ucboHair.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ucboHair.Items.AddRange(New Object() {"Gray", "Brown", "White", "Bald", "Black", "Red", "Sandy", "Blonde", "Unknown"})
        Me.ucboHair.Location = New System.Drawing.Point(513, 106)
        Me.ucboHair.Name = "ucboHair"
        Me.ucboHair.Size = New System.Drawing.Size(107, 21)
        Me.ucboHair.TabIndex = 213
        Me.ucboHair.Tag = ""
        '
        'Weight
        '
        Appearance4.ForeColor = System.Drawing.Color.Black
        Appearance4.ForeColorDisabled = System.Drawing.Color.Black
        Me.Weight.Appearance = Appearance4
        Me.Weight.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Weight.Location = New System.Drawing.Point(360, 154)
        Me.Weight.Name = "Weight"
        Me.Weight.Size = New System.Drawing.Size(107, 21)
        Me.Weight.TabIndex = 212
        Me.Weight.Tag = ""
        '
        'cboHeight
        '
        Me.cboHeight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHeight.Items.AddRange(New Object() {"4`00", "4`01", "4`02", "4`03", "4`04", "4`05", "4`06", "4`07", "4`08", "4`09", "4`10", "4`11", "5`00", "5`01", "5`02", "5`03", "5`04", "5`05", "5`06", "5`07", "5`08", "5`09", "5`10", "5`11", "6`00", "6`01", "6`02", "6`03", "6`04", "6`05", "6`06", "6`07", "6`08", "6`09", "6`10", "6`11", "7`00", "Unknown"})
        Me.cboHeight.Location = New System.Drawing.Point(513, 130)
        Me.cboHeight.Name = "cboHeight"
        Me.cboHeight.Size = New System.Drawing.Size(107, 21)
        Me.cboHeight.TabIndex = 18
        Me.cboHeight.Tag = ""
        '
        'Label60
        '
        Me.Label60.Location = New System.Drawing.Point(313, 154)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(47, 17)
        Me.Label60.TabIndex = 211
        Me.Label60.Text = "Weight:"
        Me.Label60.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label58
        '
        Me.Label58.Location = New System.Drawing.Point(473, 130)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(40, 16)
        Me.Label58.TabIndex = 209
        Me.Label58.Text = "Height:"
        Me.Label58.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label59
        '
        Me.Label59.Location = New System.Drawing.Point(327, 130)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(31, 16)
        Me.Label59.TabIndex = 207
        Me.Label59.Text = "Eyes:"
        Me.Label59.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label57
        '
        Me.Label57.Location = New System.Drawing.Point(480, 106)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(33, 16)
        Me.Label57.TabIndex = 205
        Me.Label57.Text = "Hair:"
        Me.Label57.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'uchDMVPull
        '
        Me.uchDMVPull.Location = New System.Drawing.Point(360, 81)
        Me.uchDMVPull.Name = "uchDMVPull"
        Me.uchDMVPull.Size = New System.Drawing.Size(147, 20)
        Me.uchDMVPull.TabIndex = 14
        Me.uchDMVPull.Tag = ".DMVPull"
        Me.uchDMVPull.Text = "Part of DMV Pull Program"
        '
        'Label38
        '
        Me.Label38.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label38.Location = New System.Drawing.Point(498, 59)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(46, 16)
        Me.Label38.TabIndex = 202
        Me.Label38.Text = "Expires:"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utDLExp
        '
        Appearance5.ForeColor = System.Drawing.Color.Black
        Appearance5.ForeColorDisabled = System.Drawing.Color.Black
        Me.utDLExp.Appearance = Appearance5
        Me.utDLExp.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.utDLExp.Location = New System.Drawing.Point(513, 59)
        Me.utDLExp.Name = "utDLExp"
        Me.utDLExp.Size = New System.Drawing.Size(107, 21)
        Me.utDLExp.TabIndex = 13
        Me.utDLExp.Tag = ".DLExpDate"
        Me.utDLExp.Value = Nothing
        '
        'Label36
        '
        Me.Label36.Location = New System.Drawing.Point(256, 132)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(24, 15)
        Me.Label36.TabIndex = 200
        Me.Label36.Text = "Auto Ins.Exp.Date:"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label36.Visible = False
        '
        'udtAutoExp
        '
        Appearance6.ForeColor = System.Drawing.Color.Black
        Appearance6.ForeColorDisabled = System.Drawing.Color.Black
        Me.udtAutoExp.Appearance = Appearance6
        Me.udtAutoExp.DateTime = New Date(2004, 9, 27, 0, 0, 0, 0)
        Me.udtAutoExp.Location = New System.Drawing.Point(280, 132)
        Me.udtAutoExp.Name = "udtAutoExp"
        Me.udtAutoExp.Size = New System.Drawing.Size(8, 21)
        Me.udtAutoExp.TabIndex = 199
        Me.udtAutoExp.Tag = ".AutoInsExpDate"
        Me.udtAutoExp.Value = New Date(2004, 9, 27, 0, 0, 0, 0)
        Me.udtAutoExp.Visible = False
        '
        'utAutoInsPolNum
        '
        Appearance7.ForeColor = System.Drawing.Color.Black
        Appearance7.ForeColorDisabled = System.Drawing.Color.Black
        Me.utAutoInsPolNum.Appearance = Appearance7
        Me.utAutoInsPolNum.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utAutoInsPolNum.Location = New System.Drawing.Point(216, 132)
        Me.utAutoInsPolNum.Name = "utAutoInsPolNum"
        Me.utAutoInsPolNum.Size = New System.Drawing.Size(8, 21)
        Me.utAutoInsPolNum.TabIndex = 197
        Me.utAutoInsPolNum.Tag = ".AutoInsPolNum"
        Me.utAutoInsPolNum.Visible = False
        '
        'Label35
        '
        Me.Label35.Location = New System.Drawing.Point(192, 132)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(24, 15)
        Me.Label35.TabIndex = 198
        Me.Label35.Text = "Auto Ins. Pol.#:"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label35.Visible = False
        '
        'umeAutoInsPhone
        '
        Appearance8.ForeColor = System.Drawing.Color.Black
        Appearance8.ForeColorDisabled = System.Drawing.Color.Black
        Me.umeAutoInsPhone.Appearance = Appearance8
        Me.umeAutoInsPhone.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.umeAutoInsPhone.InputMask = "(###)###-####"
        Me.umeAutoInsPhone.Location = New System.Drawing.Point(248, 132)
        Me.umeAutoInsPhone.Name = "umeAutoInsPhone"
        Me.umeAutoInsPhone.Size = New System.Drawing.Size(8, 20)
        Me.umeAutoInsPhone.TabIndex = 195
        Me.umeAutoInsPhone.Tag = ".AutoInsPhone"
        Me.umeAutoInsPhone.Text = "()--"
        Me.umeAutoInsPhone.Visible = False
        '
        'Label34
        '
        Me.Label34.Location = New System.Drawing.Point(224, 132)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(24, 15)
        Me.Label34.TabIndex = 196
        Me.Label34.Text = "Auto Ins. Phone :"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label34.Visible = False
        '
        'utAutoInsName
        '
        Appearance9.ForeColor = System.Drawing.Color.Black
        Appearance9.ForeColorDisabled = System.Drawing.Color.Black
        Me.utAutoInsName.Appearance = Appearance9
        Me.utAutoInsName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utAutoInsName.Location = New System.Drawing.Point(184, 132)
        Me.utAutoInsName.Name = "utAutoInsName"
        Me.utAutoInsName.Size = New System.Drawing.Size(8, 21)
        Me.utAutoInsName.TabIndex = 193
        Me.utAutoInsName.Tag = ".AutoInsName"
        Me.utAutoInsName.Visible = False
        '
        'Label33
        '
        Me.Label33.Location = New System.Drawing.Point(160, 139)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(20, 7)
        Me.Label33.TabIndex = 194
        Me.Label33.Text = "Auto Ins. Name:"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label33.Visible = False
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(433, 36)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(80, 17)
        Me.Label32.TabIndex = 192
        Me.Label32.Text = "Marital Status:"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ucboMaritalStatus
        '
        Appearance10.BackColorDisabled = System.Drawing.Color.Silver
        Appearance10.ForeColor = System.Drawing.Color.Black
        Appearance10.ForeColorDisabled = System.Drawing.Color.Black
        Me.ucboMaritalStatus.Appearance = Appearance10
        Me.ucboMaritalStatus.DisplayMember = "b,k,k"
        Me.ucboMaritalStatus.Location = New System.Drawing.Point(513, 36)
        Me.ucboMaritalStatus.Name = "ucboMaritalStatus"
        Me.ucboMaritalStatus.Size = New System.Drawing.Size(107, 21)
        Me.ucboMaritalStatus.TabIndex = 11
        Me.ucboMaritalStatus.Tag = ".Marital_Status...MaritalStatus.Marital_Status.Marital_Status_Name"
        Me.ucboMaritalStatus.ValueMember = ""
        '
        'Label31
        '
        Me.Label31.Location = New System.Drawing.Point(480, 14)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(33, 15)
        Me.Label31.TabIndex = 190
        Me.Label31.Text = "Race:"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ucboRace
        '
        Appearance11.ForeColor = System.Drawing.Color.Black
        Appearance11.ForeColorDisabled = System.Drawing.Color.Black
        Me.ucboRace.Appearance = Appearance11
        Me.ucboRace.DisplayMember = "b,k,k"
        Me.ucboRace.Location = New System.Drawing.Point(513, 14)
        Me.ucboRace.Name = "ucboRace"
        Me.ucboRace.Size = New System.Drawing.Size(107, 21)
        Me.ucboRace.TabIndex = 10
        Me.ucboRace.Tag = ".Race...Races.Race.Race_Name"
        Me.ucboRace.ValueMember = "a,b,c"
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(313, 106)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(47, 16)
        Me.Label30.TabIndex = 188
        Me.Label30.Text = "Gender:"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ucboGender
        '
        Appearance12.ForeColor = System.Drawing.Color.Black
        Appearance12.ForeColorDisabled = System.Drawing.Color.Black
        Me.ucboGender.Appearance = Appearance12
        Me.ucboGender.DisplayMember = "b,k,k"
        Me.ucboGender.Location = New System.Drawing.Point(360, 106)
        Me.ucboGender.Name = "ucboGender"
        Me.ucboGender.Size = New System.Drawing.Size(107, 21)
        Me.ucboGender.TabIndex = 15
        Me.ucboGender.Tag = ".Gender...Genders.Gender.Gender_Name"
        Me.ucboGender.ValueMember = "a,b,c"
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(480, 154)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(33, 17)
        Me.Label15.TabIndex = 186
        Me.Label15.Text = "DOB:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UltraDate1
        '
        Appearance13.ForeColor = System.Drawing.Color.Black
        Appearance13.ForeColorDisabled = System.Drawing.Color.Black
        Me.UltraDate1.Appearance = Appearance13
        Me.UltraDate1.DateTime = New Date(2004, 9, 27, 0, 0, 0, 0)
        Me.UltraDate1.Location = New System.Drawing.Point(513, 154)
        Me.UltraDate1.Name = "UltraDate1"
        Me.UltraDate1.Size = New System.Drawing.Size(107, 21)
        Me.UltraDate1.TabIndex = 20
        Me.UltraDate1.Tag = ".DOB"
        Me.UltraDate1.Value = New Date(2004, 9, 27, 0, 0, 0, 0)
        '
        'ucboState2
        '
        Appearance14.ForeColor = System.Drawing.Color.Black
        Appearance14.ForeColorDisabled = System.Drawing.Color.Black
        Me.ucboState2.Appearance = Appearance14
        Me.ucboState2.DisplayMember = ""
        Me.ucboState2.Location = New System.Drawing.Point(56, 81)
        Me.ucboState2.Name = "ucboState2"
        Me.ucboState2.Size = New System.Drawing.Size(91, 21)
        Me.ucboState2.TabIndex = 3
        Me.ucboState2.Tag = ".STATE...STATE.CODE.CODE"
        Me.ucboState2.ValueMember = ""
        '
        'umeCell
        '
        Appearance15.ForeColor = System.Drawing.Color.Black
        Appearance15.ForeColorDisabled = System.Drawing.Color.Black
        Me.umeCell.Appearance = Appearance15
        Me.umeCell.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.umeCell.InputMask = "(###)###-####"
        Me.umeCell.Location = New System.Drawing.Point(56, 130)
        Me.umeCell.Name = "umeCell"
        Me.umeCell.Size = New System.Drawing.Size(91, 20)
        Me.umeCell.TabIndex = 7
        Me.umeCell.Tag = ".Cell"
        Me.umeCell.Text = "()--"
        '
        'Label26
        '
        Me.Label26.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label26.Location = New System.Drawing.Point(47, 130)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(37, 16)
        Me.Label26.TabIndex = 184
        Me.Label26.Text = "Cell:"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Phone2
        '
        Appearance16.ForeColor = System.Drawing.Color.Black
        Appearance16.ForeColorDisabled = System.Drawing.Color.Black
        Me.Phone2.Appearance = Appearance16
        Me.Phone2.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.Phone2.InputMask = "(###)###-####"
        Me.Phone2.Location = New System.Drawing.Point(213, 106)
        Me.Phone2.Name = "Phone2"
        Me.Phone2.Size = New System.Drawing.Size(92, 20)
        Me.Phone2.TabIndex = 6
        Me.Phone2.Tag = ".Phone2"
        Me.Phone2.Text = "()--"
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(153, 106)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(60, 16)
        Me.Label24.TabIndex = 182
        Me.Label24.Text = "Em Phone:"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Phone1
        '
        Appearance17.ForeColor = System.Drawing.Color.Black
        Appearance17.ForeColorDisabled = System.Drawing.Color.Black
        Me.Phone1.Appearance = Appearance17
        Me.Phone1.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.Phone1.InputMask = "(###)###-####"
        Me.Phone1.Location = New System.Drawing.Point(56, 106)
        Me.Phone1.Name = "Phone1"
        Me.Phone1.Size = New System.Drawing.Size(91, 20)
        Me.Phone1.TabIndex = 5
        Me.Phone1.Tag = ".Phone"
        Me.Phone1.Text = "()--"
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(16, 106)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(40, 16)
        Me.Label25.TabIndex = 181
        Me.Label25.Text = "Phone:"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Email
        '
        Appearance18.ForeColor = System.Drawing.Color.Black
        Appearance18.ForeColorDisabled = System.Drawing.Color.Black
        Me.Email.Appearance = Appearance18
        Me.Email.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Email.Location = New System.Drawing.Point(56, 154)
        Me.Email.Name = "Email"
        Me.Email.Size = New System.Drawing.Size(250, 21)
        Me.Email.TabIndex = 8
        Me.Email.Tag = ".email"
        '
        'Label23
        '
        Me.Label23.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Label23.Location = New System.Drawing.Point(44, 154)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(40, 19)
        Me.Label23.TabIndex = 177
        Me.Label23.Text = "eMail:"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'City
        '
        Appearance19.ForeColor = System.Drawing.Color.Black
        Appearance19.ForeColorDisabled = System.Drawing.Color.Black
        Me.City.Appearance = Appearance19
        Me.City.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.City.Location = New System.Drawing.Point(56, 59)
        Me.City.Name = "City"
        Me.City.Size = New System.Drawing.Size(157, 21)
        Me.City.TabIndex = 2
        Me.City.Tag = ".City"
        '
        'ZipCode
        '
        Appearance20.ForeColor = System.Drawing.Color.Black
        Appearance20.ForeColorDisabled = System.Drawing.Color.Black
        Me.ZipCode.Appearance = Appearance20
        Me.ZipCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ZipCode.Location = New System.Drawing.Point(213, 81)
        Me.ZipCode.Name = "ZipCode"
        Me.ZipCode.Size = New System.Drawing.Size(92, 21)
        Me.ZipCode.TabIndex = 4
        Me.ZipCode.Tag = ".Zip"
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(180, 81)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(36, 17)
        Me.Label22.TabIndex = 173
        Me.Label22.Text = "Zip:"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(16, 81)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(40, 17)
        Me.Label21.TabIndex = 172
        Me.Label21.Text = "State:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(24, 59)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(32, 16)
        Me.Label20.TabIndex = 171
        Me.Label20.Text = "City:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Address2
        '
        Appearance21.ForeColor = System.Drawing.Color.Black
        Appearance21.ForeColorDisabled = System.Drawing.Color.Black
        Me.Address2.Appearance = Appearance21
        Me.Address2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Address2.Location = New System.Drawing.Point(56, 36)
        Me.Address2.Name = "Address2"
        Me.Address2.Size = New System.Drawing.Size(250, 21)
        Me.Address2.TabIndex = 1
        Me.Address2.Tag = ".Address2"
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(6, 16)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(50, 16)
        Me.Label27.TabIndex = 169
        Me.Label27.Text = "Address:"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Address1
        '
        Appearance22.ForeColor = System.Drawing.Color.Black
        Appearance22.ForeColorDisabled = System.Drawing.Color.Black
        Me.Address1.Appearance = Appearance22
        Me.Address1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Address1.Location = New System.Drawing.Point(56, 14)
        Me.Address1.Name = "Address1"
        Me.Address1.Size = New System.Drawing.Size(250, 21)
        Me.Address1.TabIndex = 0
        Me.Address1.Tag = ".Address1"
        '
        'DLN
        '
        Appearance23.ForeColor = System.Drawing.Color.Black
        Appearance23.ForeColorDisabled = System.Drawing.Color.Black
        Me.DLN.Appearance = Appearance23
        Me.DLN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.DLN.Location = New System.Drawing.Point(360, 59)
        Me.DLN.Name = "DLN"
        Me.DLN.Size = New System.Drawing.Size(107, 21)
        Me.DLN.TabIndex = 12
        Me.DLN.Tag = ".DLN"
        '
        'SSN
        '
        Appearance24.ForeColor = System.Drawing.Color.Black
        Appearance24.ForeColorDisabled = System.Drawing.Color.Black
        Me.SSN.Appearance = Appearance24
        Me.SSN.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.SSN.Location = New System.Drawing.Point(360, 14)
        Me.SSN.Name = "SSN"
        Me.SSN.Size = New System.Drawing.Size(107, 21)
        Me.SSN.TabIndex = 9
        Me.SSN.Tag = ".SSN"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(328, 59)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 16)
        Me.Label4.TabIndex = 111
        Me.Label4.Text = "DLN:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(328, 14)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(32, 16)
        Me.Label6.TabIndex = 110
        Me.Label6.Text = "SSN:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tpDeductions
        '
        Me.tpDeductions.Controls.Add(Me.UltraGrid1)
        Me.tpDeductions.Controls.Add(Me.GroupBox6)
        Me.tpDeductions.Location = New System.Drawing.Point(4, 22)
        Me.tpDeductions.Name = "tpDeductions"
        Me.tpDeductions.Size = New System.Drawing.Size(656, 346)
        Me.tpDeductions.TabIndex = 3
        Me.tpDeductions.Tag = "EmployeeDeductions"
        Me.tpDeductions.Text = "Deductions"
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGrid1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraGrid1.Location = New System.Drawing.Point(0, 80)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(656, 266)
        Me.UltraGrid1.TabIndex = 1
        Me.UltraGrid1.Tag = "DEDUCTIONS"
        Me.UltraGrid1.Text = "Deductions"
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.utRowID)
        Me.GroupBox6.Controls.Add(Me.txtDedEmplID)
        Me.GroupBox6.Controls.Add(Me.utDeductionAmount)
        Me.GroupBox6.Controls.Add(Me.ucboDeduction)
        Me.GroupBox6.Controls.Add(Me.Label11)
        Me.GroupBox6.Controls.Add(Me.Label10)
        Me.GroupBox6.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox6.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(656, 80)
        Me.GroupBox6.TabIndex = 0
        Me.GroupBox6.TabStop = False
        '
        'utRowID
        '
        Appearance25.ForeColor = System.Drawing.Color.Black
        Appearance25.ForeColorDisabled = System.Drawing.Color.Black
        Me.utRowID.Appearance = Appearance25
        Me.utRowID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utRowID.Location = New System.Drawing.Point(208, 48)
        Me.utRowID.Name = "utRowID"
        Me.utRowID.Size = New System.Drawing.Size(40, 21)
        Me.utRowID.TabIndex = 119
        Me.utRowID.Tag = ".RowID.view"
        Me.utRowID.Visible = False
        '
        'txtDedEmplID
        '
        Me.txtDedEmplID.Location = New System.Drawing.Point(344, 16)
        Me.txtDedEmplID.Name = "txtDedEmplID"
        Me.txtDedEmplID.Size = New System.Drawing.Size(32, 20)
        Me.txtDedEmplID.TabIndex = 118
        Me.txtDedEmplID.Tag = ".EmployeeID.INSERT.1"
        Me.txtDedEmplID.Text = ""
        Me.txtDedEmplID.Visible = False
        '
        'utDeductionAmount
        '
        Appearance26.ForeColor = System.Drawing.Color.Black
        Appearance26.ForeColorDisabled = System.Drawing.Color.Black
        Me.utDeductionAmount.Appearance = Appearance26
        Me.utDeductionAmount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utDeductionAmount.Location = New System.Drawing.Point(80, 43)
        Me.utDeductionAmount.Name = "utDeductionAmount"
        Me.utDeductionAmount.Size = New System.Drawing.Size(80, 21)
        Me.utDeductionAmount.TabIndex = 1
        Me.utDeductionAmount.Tag = ".Amount"
        '
        'ucboDeduction
        '
        Appearance27.ForeColor = System.Drawing.Color.Black
        Appearance27.ForeColorDisabled = System.Drawing.Color.Black
        Me.ucboDeduction.Appearance = Appearance27
        Me.ucboDeduction.AutoEdit = False
        Me.ucboDeduction.DisplayMember = ""
        Me.ucboDeduction.Location = New System.Drawing.Point(80, 16)
        Me.ucboDeduction.Name = "ucboDeduction"
        Me.ucboDeduction.Size = New System.Drawing.Size(232, 21)
        Me.ucboDeduction.TabIndex = 0
        Me.ucboDeduction.Tag = ".DeductionID...Deductions.DeductionID.Deduction"
        Me.ucboDeduction.ValueMember = ""
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(16, 45)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 16)
        Me.Label11.TabIndex = 115
        Me.Label11.Text = "Amount: $"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(16, 16)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 16)
        Me.Label10.TabIndex = 112
        Me.Label10.Text = "Deduction:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tpPayInfo
        '
        Me.tpPayInfo.Controls.Add(Me.UltraGrid2)
        Me.tpPayInfo.Controls.Add(Me.GroupBox5)
        Me.tpPayInfo.Location = New System.Drawing.Point(4, 22)
        Me.tpPayInfo.Name = "tpPayInfo"
        Me.tpPayInfo.Size = New System.Drawing.Size(656, 346)
        Me.tpPayInfo.TabIndex = 2
        Me.tpPayInfo.Tag = "EmployeePayRates"
        Me.tpPayInfo.Text = "Pay Info"
        '
        'UltraGrid2
        '
        Me.UltraGrid2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGrid2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraGrid2.Location = New System.Drawing.Point(0, 120)
        Me.UltraGrid2.Name = "UltraGrid2"
        Me.UltraGrid2.Size = New System.Drawing.Size(656, 226)
        Me.UltraGrid2.TabIndex = 0
        Me.UltraGrid2.Tag = "EMPLOYEEPAYRATES"
        Me.UltraGrid2.Text = "Pay Rates"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.utMileageRate)
        Me.GroupBox5.Controls.Add(Me.utPayRate)
        Me.GroupBox5.Controls.Add(Me.txtPayEmplID)
        Me.GroupBox5.Controls.Add(Me.ucboWCCode)
        Me.GroupBox5.Controls.Add(Me.ucboClass)
        Me.GroupBox5.Controls.Add(Me.ucboDept)
        Me.GroupBox5.Controls.Add(Me.Label18)
        Me.GroupBox5.Controls.Add(Me.Label17)
        Me.GroupBox5.Controls.Add(Me.Label14)
        Me.GroupBox5.Controls.Add(Me.Label12)
        Me.GroupBox5.Controls.Add(Me.Label19)
        Me.GroupBox5.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox5.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(656, 120)
        Me.GroupBox5.TabIndex = 133
        Me.GroupBox5.TabStop = False
        '
        'utMileageRate
        '
        Appearance28.ForeColor = System.Drawing.Color.Black
        Appearance28.ForeColorDisabled = System.Drawing.Color.Black
        Me.utMileageRate.Appearance = Appearance28
        Me.utMileageRate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utMileageRate.Location = New System.Drawing.Point(296, 40)
        Me.utMileageRate.Name = "utMileageRate"
        Me.utMileageRate.Size = New System.Drawing.Size(64, 21)
        Me.utMileageRate.TabIndex = 4
        Me.utMileageRate.Tag = ".MileageRate"
        '
        'utPayRate
        '
        Appearance29.ForeColor = System.Drawing.Color.Black
        Appearance29.ForeColorDisabled = System.Drawing.Color.Black
        Me.utPayRate.Appearance = Appearance29
        Me.utPayRate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utPayRate.Location = New System.Drawing.Point(296, 16)
        Me.utPayRate.Name = "utPayRate"
        Me.utPayRate.Size = New System.Drawing.Size(64, 21)
        Me.utPayRate.TabIndex = 3
        Me.utPayRate.Tag = ".PayRate"
        '
        'txtPayEmplID
        '
        Me.txtPayEmplID.Location = New System.Drawing.Point(64, 88)
        Me.txtPayEmplID.Name = "txtPayEmplID"
        Me.txtPayEmplID.Size = New System.Drawing.Size(32, 20)
        Me.txtPayEmplID.TabIndex = 8
        Me.txtPayEmplID.Tag = ".EmployeeID.INSERT.1"
        Me.txtPayEmplID.Text = ""
        Me.txtPayEmplID.Visible = False
        '
        'ucboWCCode
        '
        Appearance30.ForeColor = System.Drawing.Color.Black
        Appearance30.ForeColorDisabled = System.Drawing.Color.Black
        Me.ucboWCCode.Appearance = Appearance30
        Me.ucboWCCode.AutoEdit = False
        Me.ucboWCCode.DisplayMember = ""
        Me.ucboWCCode.Location = New System.Drawing.Point(64, 63)
        Me.ucboWCCode.Name = "ucboWCCode"
        Me.ucboWCCode.Size = New System.Drawing.Size(96, 21)
        Me.ucboWCCode.TabIndex = 2
        Me.ucboWCCode.Tag = ".WCCode..1.WCCodes.WCCode.WCTitle"
        Me.ucboWCCode.ValueMember = ""
        '
        'ucboClass
        '
        Appearance31.ForeColor = System.Drawing.Color.Black
        Appearance31.ForeColorDisabled = System.Drawing.Color.Black
        Me.ucboClass.Appearance = Appearance31
        Me.ucboClass.AutoEdit = False
        Me.ucboClass.DisplayMember = ""
        Me.ucboClass.Location = New System.Drawing.Point(64, 38)
        Me.ucboClass.Name = "ucboClass"
        Me.ucboClass.Size = New System.Drawing.Size(96, 21)
        Me.ucboClass.TabIndex = 1
        Me.ucboClass.Tag = ".ClassID..1.Classes.ClassID.Class"
        Me.ucboClass.ValueMember = ""
        '
        'ucboDept
        '
        Appearance32.ForeColor = System.Drawing.Color.Black
        Appearance32.ForeColorDisabled = System.Drawing.Color.Black
        Me.ucboDept.Appearance = Appearance32
        Me.ucboDept.AutoEdit = False
        Me.ucboDept.DisplayMember = ""
        Me.ucboDept.Location = New System.Drawing.Point(64, 16)
        Me.ucboDept.Name = "ucboDept"
        Me.ucboDept.Size = New System.Drawing.Size(96, 21)
        Me.ucboDept.TabIndex = 0
        Me.ucboDept.Tag = ".DeptNo..1.Departments.DeptNo.DeptNo"
        Me.ucboDept.ValueMember = ""
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(208, 40)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(88, 16)
        Me.Label18.TabIndex = 127
        Me.Label18.Text = "Mileage Rate: $"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(224, 16)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(72, 16)
        Me.Label17.TabIndex = 126
        Me.Label17.Text = "Pay Rate: $"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(24, 40)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(40, 16)
        Me.Label14.TabIndex = 121
        Me.Label14.Text = "Class:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(24, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(40, 16)
        Me.Label12.TabIndex = 120
        Me.Label12.Text = "Dept.:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(8, 64)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(56, 16)
        Me.Label19.TabIndex = 130
        Me.Label19.Text = "WC Code:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tpVehicles
        '
        Me.tpVehicles.Controls.Add(Me.UltraGrid3)
        Me.tpVehicles.Controls.Add(Me.GroupBox8)
        Me.tpVehicles.Location = New System.Drawing.Point(4, 22)
        Me.tpVehicles.Name = "tpVehicles"
        Me.tpVehicles.Size = New System.Drawing.Size(656, 346)
        Me.tpVehicles.TabIndex = 4
        Me.tpVehicles.Tag = "VEHICLES"
        Me.tpVehicles.Text = "Vehicles"
        '
        'UltraGrid3
        '
        Me.UltraGrid3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGrid3.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraGrid3.Location = New System.Drawing.Point(0, 224)
        Me.UltraGrid3.Name = "UltraGrid3"
        Me.UltraGrid3.Size = New System.Drawing.Size(656, 122)
        Me.UltraGrid3.TabIndex = 0
        Me.UltraGrid3.Tag = "VEHICLES"
        Me.UltraGrid3.Text = "Vehicles"
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.udtLastOdoCheck)
        Me.GroupBox8.Controls.Add(Me.Label61)
        Me.GroupBox8.Controls.Add(Me.btnResetOdometer)
        Me.GroupBox8.Controls.Add(Me.udtLastInspDate)
        Me.GroupBox8.Controls.Add(Me.Label50)
        Me.GroupBox8.Controls.Add(Me.utModelYear)
        Me.GroupBox8.Controls.Add(Me.Label55)
        Me.GroupBox8.Controls.Add(Me.GroupBox10)
        Me.GroupBox8.Controls.Add(Me.ucboType)
        Me.GroupBox8.Controls.Add(Me.Label43)
        Me.GroupBox8.Controls.Add(Me.utVehRowID)
        Me.GroupBox8.Controls.Add(Me.txtVehEmplID)
        Me.GroupBox8.Controls.Add(Me.ucboStatePlate)
        Me.GroupBox8.Controls.Add(Me.Label49)
        Me.GroupBox8.Controls.Add(Me.udtStartDate)
        Me.GroupBox8.Controls.Add(Me.UltraTextEditor9)
        Me.GroupBox8.Controls.Add(Me.Label47)
        Me.GroupBox8.Controls.Add(Me.utMileage)
        Me.GroupBox8.Controls.Add(Me.Label46)
        Me.GroupBox8.Controls.Add(Me.Label45)
        Me.GroupBox8.Controls.Add(Me.UltraTextEditor6)
        Me.GroupBox8.Controls.Add(Me.Label44)
        Me.GroupBox8.Controls.Add(Me.UltraTextEditor4)
        Me.GroupBox8.Controls.Add(Me.Label42)
        Me.GroupBox8.Controls.Add(Me.UltraTextEditor3)
        Me.GroupBox8.Controls.Add(Me.Label41)
        Me.GroupBox8.Controls.Add(Me.UltraTextEditor2)
        Me.GroupBox8.Controls.Add(Me.Label40)
        Me.GroupBox8.Controls.Add(Me.UltraTextEditor1)
        Me.GroupBox8.Controls.Add(Me.Label39)
        Me.GroupBox8.Controls.Add(Me.cboActive)
        Me.GroupBox8.Controls.Add(Me.udtEndDate)
        Me.GroupBox8.Controls.Add(Me.Label48)
        Me.GroupBox8.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox8.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(656, 224)
        Me.GroupBox8.TabIndex = 0
        Me.GroupBox8.TabStop = False
        '
        'udtLastOdoCheck
        '
        Appearance33.ForeColor = System.Drawing.Color.Black
        Appearance33.ForeColorDisabled = System.Drawing.Color.Black
        Me.udtLastOdoCheck.Appearance = Appearance33
        Me.udtLastOdoCheck.DateTime = New Date(2004, 9, 27, 0, 0, 0, 0)
        Me.udtLastOdoCheck.Location = New System.Drawing.Point(416, 120)
        Me.udtLastOdoCheck.Name = "udtLastOdoCheck"
        Me.udtLastOdoCheck.Size = New System.Drawing.Size(104, 21)
        Me.udtLastOdoCheck.TabIndex = 214
        Me.udtLastOdoCheck.Tag = ""
        Me.udtLastOdoCheck.Value = New Date(2004, 9, 27, 0, 0, 0, 0)
        '
        'Label61
        '
        Me.Label61.Location = New System.Drawing.Point(296, 120)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(120, 23)
        Me.Label61.TabIndex = 213
        Me.Label61.Text = "Last Odometer Check"
        Me.Label61.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnResetOdometer
        '
        Me.btnResetOdometer.Location = New System.Drawing.Point(528, 122)
        Me.btnResetOdometer.Name = "btnResetOdometer"
        Me.btnResetOdometer.Size = New System.Drawing.Size(104, 16)
        Me.btnResetOdometer.TabIndex = 212
        Me.btnResetOdometer.Text = "reset odometer..."
        '
        'udtLastInspDate
        '
        Appearance34.ForeColor = System.Drawing.Color.Black
        Appearance34.ForeColorDisabled = System.Drawing.Color.Black
        Me.udtLastInspDate.Appearance = Appearance34
        Me.udtLastInspDate.DateTime = New Date(2004, 9, 27, 0, 0, 0, 0)
        Me.udtLastInspDate.Location = New System.Drawing.Point(416, 96)
        Me.udtLastInspDate.Name = "udtLastInspDate"
        Me.udtLastInspDate.Size = New System.Drawing.Size(104, 21)
        Me.udtLastInspDate.TabIndex = 11
        Me.udtLastInspDate.Tag = ".LastInspectDate"
        Me.udtLastInspDate.Value = New Date(2004, 9, 27, 0, 0, 0, 0)
        '
        'Label50
        '
        Me.Label50.Location = New System.Drawing.Point(296, 96)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(120, 16)
        Me.Label50.TabIndex = 211
        Me.Label50.Text = "Last Inspection Date:"
        Me.Label50.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utModelYear
        '
        Appearance35.ForeColor = System.Drawing.Color.Black
        Appearance35.ForeColorDisabled = System.Drawing.Color.Black
        Me.utModelYear.Appearance = Appearance35
        Me.utModelYear.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utModelYear.Location = New System.Drawing.Point(80, 70)
        Me.utModelYear.Name = "utModelYear"
        Me.utModelYear.Size = New System.Drawing.Size(86, 21)
        Me.utModelYear.TabIndex = 4
        Me.utModelYear.Tag = ".ModelYear"
        '
        'Label55
        '
        Me.Label55.Location = New System.Drawing.Point(40, 72)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(40, 16)
        Me.Label55.TabIndex = 210
        Me.Label55.Text = "Year:"
        Me.Label55.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox10
        '
        Me.GroupBox10.Controls.Add(Me.utePolicyLimits)
        Me.GroupBox10.Controls.Add(Me.Label56)
        Me.GroupBox10.Controls.Add(Me.btnAutoIns)
        Me.GroupBox10.Controls.Add(Me.Label53)
        Me.GroupBox10.Controls.Add(Me.uteAutoInsName)
        Me.GroupBox10.Controls.Add(Me.Label54)
        Me.GroupBox10.Controls.Add(Me.uteAutoInsPolNum)
        Me.GroupBox10.Controls.Add(Me.udtExpDate)
        Me.GroupBox10.Controls.Add(Me.Label51)
        Me.GroupBox10.Controls.Add(Me.Label52)
        Me.GroupBox10.Controls.Add(Me.uteAutoInsPhone)
        Me.GroupBox10.Location = New System.Drawing.Point(0, 144)
        Me.GroupBox10.Name = "GroupBox10"
        Me.GroupBox10.Size = New System.Drawing.Size(616, 72)
        Me.GroupBox10.TabIndex = 0
        Me.GroupBox10.TabStop = False
        Me.GroupBox10.Text = "Auto Insurance"
        '
        'utePolicyLimits
        '
        Appearance36.ForeColor = System.Drawing.Color.Black
        Appearance36.ForeColorDisabled = System.Drawing.Color.Black
        Me.utePolicyLimits.Appearance = Appearance36
        Me.utePolicyLimits.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utePolicyLimits.Location = New System.Drawing.Point(448, 40)
        Me.utePolicyLimits.Name = "utePolicyLimits"
        Me.utePolicyLimits.Size = New System.Drawing.Size(160, 21)
        Me.utePolicyLimits.TabIndex = 5
        Me.utePolicyLimits.Tag = ".AutoInsLimits"
        '
        'Label56
        '
        Me.Label56.Location = New System.Drawing.Point(376, 40)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(72, 16)
        Me.Label56.TabIndex = 209
        Me.Label56.Text = "Policy Limit :"
        Me.Label56.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAutoIns
        '
        Me.btnAutoIns.Location = New System.Drawing.Point(312, 16)
        Me.btnAutoIns.Name = "btnAutoIns"
        Me.btnAutoIns.Size = New System.Drawing.Size(53, 20)
        Me.btnAutoIns.TabIndex = 1
        Me.btnAutoIns.Text = "Select"
        '
        'Label53
        '
        Me.Label53.Location = New System.Drawing.Point(400, 16)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(48, 16)
        Me.Label53.TabIndex = 204
        Me.Label53.Text = "Phone :"
        Me.Label53.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'uteAutoInsName
        '
        Appearance37.ForeColor = System.Drawing.Color.Black
        Appearance37.ForeColorDisabled = System.Drawing.Color.Black
        Me.uteAutoInsName.Appearance = Appearance37
        Me.uteAutoInsName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.uteAutoInsName.Location = New System.Drawing.Point(48, 16)
        Me.uteAutoInsName.Name = "uteAutoInsName"
        Me.uteAutoInsName.Size = New System.Drawing.Size(256, 21)
        Me.uteAutoInsName.TabIndex = 0
        Me.uteAutoInsName.Tag = ".AutoInsName"
        '
        'Label54
        '
        Me.Label54.Location = New System.Drawing.Point(8, 16)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(40, 16)
        Me.Label54.TabIndex = 202
        Me.Label54.Text = "Name:"
        Me.Label54.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'uteAutoInsPolNum
        '
        Appearance38.ForeColor = System.Drawing.Color.Black
        Appearance38.ForeColorDisabled = System.Drawing.Color.Black
        Me.uteAutoInsPolNum.Appearance = Appearance38
        Me.uteAutoInsPolNum.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.uteAutoInsPolNum.Location = New System.Drawing.Point(48, 40)
        Me.uteAutoInsPolNum.Name = "uteAutoInsPolNum"
        Me.uteAutoInsPolNum.Size = New System.Drawing.Size(96, 21)
        Me.uteAutoInsPolNum.TabIndex = 2
        Me.uteAutoInsPolNum.Tag = ".AutoInsPolNum"
        '
        'udtExpDate
        '
        Appearance39.ForeColor = System.Drawing.Color.Black
        Appearance39.ForeColorDisabled = System.Drawing.Color.Black
        Me.udtExpDate.Appearance = Appearance39
        Me.udtExpDate.DateTime = New Date(2004, 9, 27, 0, 0, 0, 0)
        Me.udtExpDate.Location = New System.Drawing.Point(208, 40)
        Me.udtExpDate.Name = "udtExpDate"
        Me.udtExpDate.Size = New System.Drawing.Size(96, 21)
        Me.udtExpDate.TabIndex = 3
        Me.udtExpDate.Tag = ".AutoInsExpDate"
        Me.udtExpDate.Value = New Date(2004, 9, 27, 0, 0, 0, 0)
        '
        'Label51
        '
        Me.Label51.Location = New System.Drawing.Point(144, 40)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(64, 16)
        Me.Label51.TabIndex = 208
        Me.Label51.Text = "Exp. Date:"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label52
        '
        Me.Label52.Location = New System.Drawing.Point(1, 40)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(47, 16)
        Me.Label52.TabIndex = 206
        Me.Label52.Text = "Policy #:"
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'uteAutoInsPhone
        '
        Appearance40.ForeColor = System.Drawing.Color.Black
        Appearance40.ForeColorDisabled = System.Drawing.Color.Black
        Me.uteAutoInsPhone.Appearance = Appearance40
        Me.uteAutoInsPhone.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.uteAutoInsPhone.InputMask = "(###)###-####"
        Me.uteAutoInsPhone.Location = New System.Drawing.Point(448, 16)
        Me.uteAutoInsPhone.Name = "uteAutoInsPhone"
        Me.uteAutoInsPhone.TabIndex = 4
        Me.uteAutoInsPhone.Tag = ".AutoInsPhone"
        Me.uteAutoInsPhone.Text = "()--"
        '
        'ucboType
        '
        Appearance41.ForeColor = System.Drawing.Color.Black
        Appearance41.ForeColorDisabled = System.Drawing.Color.Black
        Me.ucboType.Appearance = Appearance41
        Me.ucboType.AutoEdit = False
        Me.ucboType.DisplayMember = ""
        Me.ucboType.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.ucboType.Location = New System.Drawing.Point(80, 96)
        Me.ucboType.Name = "ucboType"
        Me.ucboType.Size = New System.Drawing.Size(86, 21)
        Me.ucboType.TabIndex = 6
        Me.ucboType.Tag = ".Type...VehicleTypes.ID.Description"
        Me.ucboType.ValueMember = ""
        '
        'Label43
        '
        Me.Label43.Location = New System.Drawing.Point(496, 40)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(64, 16)
        Me.Label43.TabIndex = 193
        Me.Label43.Text = "Start Date:"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utVehRowID
        '
        Appearance42.ForeColor = System.Drawing.Color.Black
        Appearance42.ForeColorDisabled = System.Drawing.Color.Black
        Me.utVehRowID.Appearance = Appearance42
        Me.utVehRowID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utVehRowID.Location = New System.Drawing.Point(248, 16)
        Me.utVehRowID.Name = "utVehRowID"
        Me.utVehRowID.Size = New System.Drawing.Size(8, 21)
        Me.utVehRowID.TabIndex = 192
        Me.utVehRowID.Tag = ".RowID.view"
        Me.utVehRowID.Visible = False
        '
        'txtVehEmplID
        '
        Me.txtVehEmplID.Location = New System.Drawing.Point(240, 16)
        Me.txtVehEmplID.Name = "txtVehEmplID"
        Me.txtVehEmplID.Size = New System.Drawing.Size(8, 20)
        Me.txtVehEmplID.TabIndex = 191
        Me.txtVehEmplID.Tag = ".EmployeeID.INSERT.1"
        Me.txtVehEmplID.Text = ""
        Me.txtVehEmplID.Visible = False
        '
        'ucboStatePlate
        '
        Appearance43.ForeColor = System.Drawing.Color.Black
        Appearance43.ForeColorDisabled = System.Drawing.Color.Black
        Me.ucboStatePlate.Appearance = Appearance43
        Me.ucboStatePlate.AutoEdit = False
        Me.ucboStatePlate.DisplayMember = ""
        Me.ucboStatePlate.Location = New System.Drawing.Point(208, 16)
        Me.ucboStatePlate.Name = "ucboStatePlate"
        Me.ucboStatePlate.Size = New System.Drawing.Size(56, 21)
        Me.ucboStatePlate.TabIndex = 1
        Me.ucboStatePlate.Tag = ".STATE...STATE.CODE.CODE"
        Me.ucboStatePlate.ValueMember = ""
        '
        'Label49
        '
        Me.Label49.Location = New System.Drawing.Point(168, 16)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(40, 16)
        Me.Label49.TabIndex = 190
        Me.Label49.Text = "State:"
        Me.Label49.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'udtStartDate
        '
        Appearance44.ForeColor = System.Drawing.Color.Black
        Appearance44.ForeColorDisabled = System.Drawing.Color.Black
        Me.udtStartDate.Appearance = Appearance44
        Me.udtStartDate.DateTime = New Date(2004, 9, 27, 0, 0, 0, 0)
        Me.udtStartDate.Location = New System.Drawing.Point(560, 40)
        Me.udtStartDate.Name = "udtStartDate"
        Me.udtStartDate.Size = New System.Drawing.Size(86, 21)
        Me.udtStartDate.TabIndex = 9
        Me.udtStartDate.Tag = ".StartDate"
        Me.udtStartDate.Value = New Date(2004, 9, 27, 0, 0, 0, 0)
        '
        'UltraTextEditor9
        '
        Appearance45.ForeColor = System.Drawing.Color.Black
        Appearance45.ForeColorDisabled = System.Drawing.Color.Black
        Me.UltraTextEditor9.Appearance = Appearance45
        Me.UltraTextEditor9.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.UltraTextEditor9.Location = New System.Drawing.Point(80, 120)
        Me.UltraTextEditor9.Name = "UltraTextEditor9"
        Me.UltraTextEditor9.Size = New System.Drawing.Size(224, 21)
        Me.UltraTextEditor9.TabIndex = 12
        Me.UltraTextEditor9.Tag = ".Remarks"
        '
        'Label47
        '
        Me.Label47.Location = New System.Drawing.Point(24, 120)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(56, 16)
        Me.Label47.TabIndex = 129
        Me.Label47.Text = "Remarks:"
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utMileage
        '
        Appearance46.ForeColor = System.Drawing.Color.Black
        Appearance46.ForeColorDisabled = System.Drawing.Color.Black
        Me.utMileage.Appearance = Appearance46
        Me.utMileage.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utMileage.Location = New System.Drawing.Point(416, 40)
        Me.utMileage.Name = "utMileage"
        Me.utMileage.Size = New System.Drawing.Size(82, 21)
        Me.utMileage.TabIndex = 8
        Me.utMileage.Tag = ".Mileage"
        '
        'Label46
        '
        Me.Label46.Location = New System.Drawing.Point(344, 40)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(74, 16)
        Me.Label46.TabIndex = 127
        Me.Label46.Text = "Start Mileage:"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label45
        '
        Me.Label45.Location = New System.Drawing.Point(48, 96)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(32, 16)
        Me.Label45.TabIndex = 125
        Me.Label45.Text = "Type:"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UltraTextEditor6
        '
        Appearance47.ForeColor = System.Drawing.Color.Black
        Appearance47.ForeColorDisabled = System.Drawing.Color.Black
        Me.UltraTextEditor6.Appearance = Appearance47
        Me.UltraTextEditor6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.UltraTextEditor6.Location = New System.Drawing.Point(416, 16)
        Me.UltraTextEditor6.Name = "UltraTextEditor6"
        Me.UltraTextEditor6.Size = New System.Drawing.Size(232, 21)
        Me.UltraTextEditor6.TabIndex = 7
        Me.UltraTextEditor6.Tag = ".VIN"
        '
        'Label44
        '
        Me.Label44.Location = New System.Drawing.Point(328, 16)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(88, 16)
        Me.Label44.TabIndex = 123
        Me.Label44.Text = "Vehicle ID (VIN):"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UltraTextEditor4
        '
        Appearance48.ForeColor = System.Drawing.Color.Black
        Appearance48.ForeColorDisabled = System.Drawing.Color.Black
        Me.UltraTextEditor4.Appearance = Appearance48
        Me.UltraTextEditor4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.UltraTextEditor4.Location = New System.Drawing.Point(208, 70)
        Me.UltraTextEditor4.Name = "UltraTextEditor4"
        Me.UltraTextEditor4.Size = New System.Drawing.Size(79, 21)
        Me.UltraTextEditor4.TabIndex = 5
        Me.UltraTextEditor4.Tag = ".Color"
        '
        'Label42
        '
        Me.Label42.Location = New System.Drawing.Point(168, 72)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(40, 16)
        Me.Label42.TabIndex = 119
        Me.Label42.Text = "Color:"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UltraTextEditor3
        '
        Appearance49.ForeColor = System.Drawing.Color.Black
        Appearance49.ForeColorDisabled = System.Drawing.Color.Black
        Me.UltraTextEditor3.Appearance = Appearance49
        Me.UltraTextEditor3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.UltraTextEditor3.Location = New System.Drawing.Point(208, 42)
        Me.UltraTextEditor3.Name = "UltraTextEditor3"
        Me.UltraTextEditor3.Size = New System.Drawing.Size(80, 21)
        Me.UltraTextEditor3.TabIndex = 3
        Me.UltraTextEditor3.Tag = ".Model"
        '
        'Label41
        '
        Me.Label41.Location = New System.Drawing.Point(168, 44)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(40, 16)
        Me.Label41.TabIndex = 117
        Me.Label41.Text = "Model:"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UltraTextEditor2
        '
        Appearance50.ForeColor = System.Drawing.Color.Black
        Appearance50.ForeColorDisabled = System.Drawing.Color.Black
        Me.UltraTextEditor2.Appearance = Appearance50
        Me.UltraTextEditor2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.UltraTextEditor2.Location = New System.Drawing.Point(80, 42)
        Me.UltraTextEditor2.Name = "UltraTextEditor2"
        Me.UltraTextEditor2.Size = New System.Drawing.Size(86, 21)
        Me.UltraTextEditor2.TabIndex = 2
        Me.UltraTextEditor2.Tag = ".Make"
        '
        'Label40
        '
        Me.Label40.Location = New System.Drawing.Point(40, 44)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(36, 16)
        Me.Label40.TabIndex = 115
        Me.Label40.Text = "Make:"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UltraTextEditor1
        '
        Appearance51.ForeColor = System.Drawing.Color.Black
        Appearance51.ForeColorDisabled = System.Drawing.Color.Black
        Me.UltraTextEditor1.Appearance = Appearance51
        Me.UltraTextEditor1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.UltraTextEditor1.Location = New System.Drawing.Point(80, 16)
        Me.UltraTextEditor1.Name = "UltraTextEditor1"
        Me.UltraTextEditor1.Size = New System.Drawing.Size(86, 21)
        Me.UltraTextEditor1.TabIndex = 0
        Me.UltraTextEditor1.Tag = ".LicPlate"
        '
        'Label39
        '
        Me.Label39.Location = New System.Drawing.Point(2, 15)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(75, 16)
        Me.Label39.TabIndex = 113
        Me.Label39.Text = "License Plate:"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboActive
        '
        Me.cboActive.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboActive.Items.AddRange(New Object() {"Active", "Inactive"})
        Me.cboActive.Location = New System.Drawing.Point(416, 72)
        Me.cboActive.Name = "cboActive"
        Me.cboActive.Size = New System.Drawing.Size(104, 21)
        Me.cboActive.TabIndex = 10
        Me.cboActive.Tag = ".Active"
        '
        'udtEndDate
        '
        Appearance52.ForeColor = System.Drawing.Color.Black
        Appearance52.ForeColorDisabled = System.Drawing.Color.Black
        Me.udtEndDate.Appearance = Appearance52
        Me.udtEndDate.DateTime = New Date(2004, 9, 27, 0, 0, 0, 0)
        Me.udtEndDate.Location = New System.Drawing.Point(536, 72)
        Me.udtEndDate.Name = "udtEndDate"
        Me.udtEndDate.Size = New System.Drawing.Size(96, 21)
        Me.udtEndDate.TabIndex = 1
        Me.udtEndDate.Tag = ".EndDate"
        Me.udtEndDate.Value = New Date(2004, 9, 27, 0, 0, 0, 0)
        Me.udtEndDate.Visible = False
        '
        'Label48
        '
        Me.Label48.Location = New System.Drawing.Point(376, 72)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(40, 16)
        Me.Label48.TabIndex = 197
        Me.Label48.Text = "Status:"
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'btnPrintBadge
        '
        Me.btnPrintBadge.Location = New System.Drawing.Point(480, 10)
        Me.btnPrintBadge.Name = "btnPrintBadge"
        Me.btnPrintBadge.Size = New System.Drawing.Size(80, 20)
        Me.btnPrintBadge.TabIndex = 134
        Me.btnPrintBadge.Text = "Print Emp ID"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnPrnRepId)
        Me.GroupBox3.Controls.Add(Me.btnSaveNew)
        Me.GroupBox3.Controls.Add(Me.btnExit)
        Me.GroupBox3.Controls.Add(Me.btnDelete)
        Me.GroupBox3.Controls.Add(Me.btnNew)
        Me.GroupBox3.Controls.Add(Me.btnSave)
        Me.GroupBox3.Controls.Add(Me.btnEdit)
        Me.GroupBox3.Controls.Add(Me.btnPrintBadge)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox3.Location = New System.Drawing.Point(0, 444)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(664, 32)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        '
        'btnPrnRepId
        '
        Me.btnPrnRepId.Location = New System.Drawing.Point(400, 10)
        Me.btnPrnRepId.Name = "btnPrnRepId"
        Me.btnPrnRepId.Size = New System.Drawing.Size(80, 20)
        Me.btnPrnRepId.TabIndex = 135
        Me.btnPrnRepId.Text = "Print Rep ID"
        '
        'btnSaveNew
        '
        Me.btnSaveNew.Location = New System.Drawing.Point(264, 10)
        Me.btnSaveNew.Name = "btnSaveNew"
        Me.btnSaveNew.Size = New System.Drawing.Size(75, 20)
        Me.btnSaveNew.TabIndex = 5
        Me.btnSaveNew.Text = "S&ave-New"
        Me.btnSaveNew.Visible = False
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Location = New System.Drawing.Point(560, 10)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(61, 20)
        Me.btnExit.TabIndex = 4
        Me.btnExit.Text = "E&xit"
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(200, 10)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(61, 20)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "&Delete"
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(136, 10)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(61, 20)
        Me.btnNew.TabIndex = 2
        Me.btnNew.Text = "&New"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(8, 10)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(61, 20)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "&Save"
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(72, 10)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(61, 20)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "&Edit"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.utEmployeeName)
        Me.GroupBox1.Controls.Add(Me.InsertMsg)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btnPrev)
        Me.GroupBox1.Controls.Add(Me.btnNext)
        Me.GroupBox1.Controls.Add(Me.btnEmplID)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.EmplID)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(664, 72)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'utEmployeeName
        '
        Appearance53.ForeColor = System.Drawing.Color.Black
        Appearance53.ForeColorDisabled = System.Drawing.Color.Black
        Me.utEmployeeName.Appearance = Appearance53
        Me.utEmployeeName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utEmployeeName.Enabled = False
        Me.utEmployeeName.Location = New System.Drawing.Point(104, 40)
        Me.utEmployeeName.Name = "utEmployeeName"
        Me.utEmployeeName.Size = New System.Drawing.Size(248, 21)
        Me.utEmployeeName.TabIndex = 4
        Me.utEmployeeName.Tag = ".EmployeeName.view"
        '
        'InsertMsg
        '
        Me.InsertMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InsertMsg.ForeColor = System.Drawing.Color.Red
        Me.InsertMsg.Location = New System.Drawing.Point(360, 8)
        Me.InsertMsg.Name = "InsertMsg"
        Me.InsertMsg.Size = New System.Drawing.Size(96, 56)
        Me.InsertMsg.TabIndex = 11
        Me.InsertMsg.Text = "Leave ID blank    to set it to next available ID."
        Me.InsertMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.InsertMsg.Visible = False
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(32, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 9
        Me.Label2.Text = "Empl. Name:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnPrev
        '
        Me.btnPrev.Image = CType(resources.GetObject("btnPrev.Image"), System.Drawing.Image)
        Me.btnPrev.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPrev.Location = New System.Drawing.Point(192, 16)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(24, 21)
        Me.btnPrev.TabIndex = 1
        Me.btnPrev.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnNext
        '
        Me.btnNext.Image = CType(resources.GetObject("btnNext.Image"), System.Drawing.Image)
        Me.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNext.Location = New System.Drawing.Point(216, 16)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(24, 21)
        Me.btnNext.TabIndex = 2
        '
        'btnEmplID
        '
        Me.btnEmplID.Location = New System.Drawing.Point(254, 16)
        Me.btnEmplID.Name = "btnEmplID"
        Me.btnEmplID.Size = New System.Drawing.Size(53, 20)
        Me.btnEmplID.TabIndex = 3
        Me.btnEmplID.Text = "Select"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(40, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "Empl. ID:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'EmplID
        '
        Me.EmplID.Location = New System.Drawing.Point(104, 16)
        Me.EmplID.Name = "EmplID"
        Me.EmplID.Size = New System.Drawing.Size(75, 20)
        Me.EmplID.TabIndex = 0
        Me.EmplID.Tag = ".id"
        Me.EmplID.Text = ""
        '
        'OpenFileDialog
        '
        '
        'EmployeeSetup
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(664, 476)
        Me.Controls.Add(Me.TabCtrl1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Name = "EmployeeSetup"
        Me.Tag = "EMPLOYEES"
        Me.Text = "Employee Setup"
        Me.TabCtrl1.ResumeLayout(False)
        Me.tpBSet.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.utOfficeName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utOfficeID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucboCompany, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpAddInfo.ResumeLayout(False)
        CType(Me.UltraGrid4, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        CType(Me.Weight, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utDLExp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtAutoExp, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utAutoInsPolNum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utAutoInsName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucboMaritalStatus, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucboRace, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucboGender, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDate1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucboState2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Email, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.City, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ZipCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Address2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Address1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DLN, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SSN, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpDeductions.ResumeLayout(False)
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        CType(Me.utRowID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utDeductionAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucboDeduction, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpPayInfo.ResumeLayout(False)
        CType(Me.UltraGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.utMileageRate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utPayRate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucboWCCode, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucboClass, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucboDept, System.ComponentModel.ISupportInitialize).EndInit()
        Me.tpVehicles.ResumeLayout(False)
        CType(Me.UltraGrid3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox8.ResumeLayout(False)
        CType(Me.udtLastOdoCheck, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtLastInspDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utModelYear, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox10.ResumeLayout(False)
        CType(Me.utePolicyLimits, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uteAutoInsName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uteAutoInsPolNum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtExpDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucboType, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utVehRowID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucboStatePlate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtStartDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraTextEditor9, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utMileage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraTextEditor6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraTextEditor4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraTextEditor3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraTextEditor2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraTextEditor1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtEndDate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.utEmployeeName, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private Sub EmployeeSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim MinWinSize As System.Drawing.Size
        Dim Index As Integer
        Dim TabPg As TabPage

        btnDelete.Enabled = True
        AddHandler Me.Activated, AddressOf Form_Activated
        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = HRTblPath & Me.Tag
            End If
        End If

        For Each TabPg In TabCtrl1.TabPages
            If TabPg.Tag <> "" Then
                TabPg.Tag = HRTblPath & TabPg.Tag
            End If
        Next

        Me.CenterToScreen()

        Me.KeyPreview = True
        MeText = Me.Text

        ' Set each control's length based on DB size
        'SetupCtrlsLength(Me, HRDBName, HRDBUser, HRDBPass)

        'AddHandler State.KeyPress, AddressOf CBO_Search
        'AddHandler State.KeyUp, AddressOf CBO_KeyUp
        'AddHandler State.Leave, AddressOf CBO_Leave
        AddHandler Me.KeyUp, AddressOf Form_KeyUp

        AddHandler utOfficeID.KeyPress, AddressOf Value_Int_KeyPress
        AddHandler utPayRate.KeyPress, AddressOf Value_Dec_KeyPress
        AddHandler utMileageRate.KeyPress, AddressOf Value_Dec_KeyPress

        FillUCombo(ucboDeduction, "", "", "", HRTblPath, False, False)
        AddHandler utDeductionAmount.KeyPress, AddressOf Value_Dec_KeyPress


        FillUCombo(ucboType, "PICKUP", "", "", HRTblPath, False, False)
        'FillUCombo(ucboType, "PICKUP")
        FillUCombo(ucboCompany, "", "", "", HRTblPath, False, True)
        AddHandler ucboCompany.Leave, AddressOf UCbo_Leave

        FillUCombo(ucboGender, "", "", "", HRTblPath, False, True)
        AddHandler ucboGender.Leave, AddressOf UCbo_Leave

        'FillUCombo(ucboHair, "", "", "", HRTblPath, False, True)
        'AddHandler ucboHair.Leave, AddressOf UCbo_Leave

        'FillUCombo(ucboHair, "", "Select * from " & HRTblPath & "HairColor", "", "")
        'AddHandler ucboHair.Leave, AddressOf UCbo_Leave
        'FillUCombo(ucboEyes, "", "", "", HRTblPath, False, True)
        'AddHandler ucboEyes.Leave, AddressOf UCbo_Leave

        FillUCombo(ucboRace, "", "", "", HRTblPath, False, True)
        AddHandler ucboRace.Leave, AddressOf UCbo_Leave

        FillUCombo(ucboMaritalStatus, "", "", "", HRTblPath, False, True)
        AddHandler ucboMaritalStatus.Leave, AddressOf UCbo_Leave

        cboStatus.Items.Clear()

        PrepData(StatusTable)
        cboStatus.DataSource = StatusTable
        cboStatus.DisplayMember = "Status"
        cboStatus.ValueMember = "Code"

        cboStatus.SelectedIndex = 0

        cboActive.Items.Clear()
        PrepDataActive(StatusTableActive)
        cboActive.DataSource = StatusTableActive
        cboActive.DisplayMember = "Active"
        cboActive.ValueMember = "Code"
        cboActive.SelectedIndex = 0

        'cboHeight.Items.Clear()
        'PrepDataHeight(StatusTableHeight)
        'cboHeight.DataSource = StatusTableHeight
        'cboHeight.DisplayMember = "4`00"
        'cboHeight.ValueMember = "Height"
        'cboHeight.SelectedIndex = 0

        FillUCombo(ucboState2, "CA", "", "", AppTblPath, False, False)
        '        FillUCombo(ucboStatePlate, "CA", "", "", AppTblPath, False, False)
        FillUCombo(ucboStatePlate, "CA")
        FillUCombo(ucboDept, "", " Active = 1 ", "", HRTblPath, True, False)
        FillUCombo(ucboClass, "", " Active = 1 ", "", HRTblPath, True, False)
        FillUCombo(ucboWCCode, "", "", "", HRTblPath, True, False)

        AddHandler ucboState2.Leave, AddressOf UCbo_Leave
        AddHandler ucboDept.Leave, AddressOf UCbo_Leave
        AddHandler ucboClass.Leave, AddressOf UCbo_Leave
        AddHandler ucboWCCode.Leave, AddressOf UCbo_Leave

        AddHandler Phone1.MaskValidationError, AddressOf UltraMaskValidationError
        AddHandler Phone2.MaskValidationError, AddressOf UltraMaskValidationError
        AddHandler umeCell.MaskValidationError, AddressOf UltraMaskValidationError
        AddHandler umeAutoInsPhone.MaskValidationError, AddressOf UltraMaskValidationError

        udtAutoExp.Nullable = True
        udtAutoExp.Value = "01/01/1980" 'Date.Today 'DateAdd(DateInterval.Day, -1, Date.Today)
        udtAutoExp.FormatString = "MM/dd/yyyy"

        'UltraDate1.Visible = True
        'UltraDate1.Nullable = True
        'UltraDate1.Value = Date.Today 
        'UltraDate1.FormatString = "MM/dd/yyyy"

        DTPicker1.Format = DateTimePickerFormat.Custom
        DTPicker1.CustomFormat = "MM/dd/yyyy"

        DTPicker2.Format = DateTimePickerFormat.Custom
        DTPicker2.CustomFormat = "MM/dd/yyyy"

        udtStartDate.Nullable = True
        'udtStartDate.Value = "01/01/1980"
        udtStartDate.Value = Date.Today
        udtStartDate.FormatString = "MM/dd/yyyy"

        udtLastInspDate.Nullable = True
        udtLastInspDate.Value = Date.Today
        udtLastInspDate.FormatString = "MM/dd/yyyy"

        udtEndDate.Nullable = True
        'udtEndDate.Value = "01/01/1980"
        udtEndDate.Value = Date.Today
        udtEndDate.FormatString = "MM/dd/yyyy"

        udtExpDate.Nullable = True
        udtExpDate.Value = Date.Today
        udtExpDate.FormatString = "MM/dd/yyyy"

        Group_EnDis(False)
        'LoadAutoIns()
        'tabctrl1.TabPages(0).
    End Sub
    Private Sub PrepData(ByRef tbl As DataTable)
        Dim row As DataRow
        Dim col As DataColumn

        tbl.Columns.Add("Code", GetType(System.String))
        tbl.Columns.Add("Status", GetType(System.String))

        row = tbl.NewRow
        row("Code") = "A" : row("Status") = "Active"
        tbl.Rows.Add(row)

        row = tbl.NewRow
        row("Code") = "I" : row("Status") = "Inactive"
        tbl.Rows.Add(row)

        row = tbl.NewRow
        row("Code") = "S" : row("Status") = "Suspended"
        tbl.Rows.Add(row)

        row = tbl.NewRow
        row("Code") = "T" : row("Status") = "Terminated"
        tbl.Rows.Add(row)
    End Sub
    Private Sub PrepDataHeight(ByRef tbl As DataTable)
        Dim row As DataRow
        Dim col As DataColumn

        tbl.Columns.Add("Height", GetType(System.String))

        row = tbl.NewRow
        row("Height") = "4`00"
        tbl.Rows.Add(row)
        row = tbl.NewRow
        row("Height") = "4`01"
        tbl.Rows.Add(row)
        row = tbl.NewRow
        row("Height") = "4`02"
        tbl.Rows.Add(row)
        row = tbl.NewRow
        row("Height") = "4`03"
        tbl.Rows.Add(row)
        row = tbl.NewRow
        row("Height") = "4`04"
        tbl.Rows.Add(row)
        row = tbl.NewRow
        row("Height") = "4`05"
        tbl.Rows.Add(row)
        row = tbl.NewRow
        row("Height") = "4`06"
        tbl.Rows.Add(row)
        row = tbl.NewRow
        row("Height") = "4`07"
        tbl.Rows.Add(row)
        row = tbl.NewRow
        row("Height") = "4`08"
        tbl.Rows.Add(row)
        row = tbl.NewRow
        row("Height") = "4`09"
        tbl.Rows.Add(row)
        row = tbl.NewRow
        row("Height") = "4`10"
        tbl.Rows.Add(row)
        row = tbl.NewRow
        row("Height") = "4`11"
        tbl.Rows.Add(row)
        row = tbl.NewRow
        row("Height") = "5`00"
        tbl.Rows.Add(row)
        row = tbl.NewRow
        row("Height") = "5`01"
        tbl.Rows.Add(row)
        row = tbl.NewRow
        row("Height") = "5`02"
        tbl.Rows.Add(row)
        row = tbl.NewRow
        row("Height") = "5`03"
        tbl.Rows.Add(row)
        row = tbl.NewRow
        row("Height") = "5`04"
        tbl.Rows.Add(row)
        row = tbl.NewRow
        row("Height") = "5`05"
        tbl.Rows.Add(row)
        row = tbl.NewRow
        row("Height") = "5`06"
        tbl.Rows.Add(row)
        row = tbl.NewRow
        row("Height") = "5`07"
        tbl.Rows.Add(row)
        row = tbl.NewRow
        row("Height") = "5`08"
        tbl.Rows.Add(row)
        row = tbl.NewRow
        row("Height") = "5`09"
        tbl.Rows.Add(row)
        row = tbl.NewRow
        row("Height") = "5`10"
        tbl.Rows.Add(row)
        row = tbl.NewRow
        row("Height") = "5`11"
        tbl.Rows.Add(row)
        row = tbl.NewRow
        row("Height") = "6`00"
        tbl.Rows.Add(row)
        row = tbl.NewRow
        row("Height") = "6`01"
        tbl.Rows.Add(row)
        row = tbl.NewRow
        row("Height") = "6`02"
        tbl.Rows.Add(row)
        row = tbl.NewRow
        row("Height") = "6`03"
        tbl.Rows.Add(row)
        row = tbl.NewRow
        row("Height") = "6`04"
        tbl.Rows.Add(row)
        row = tbl.NewRow
        row("Height") = "6`05"
        tbl.Rows.Add(row)
        row = tbl.NewRow
        row("Height") = "6`06"
        tbl.Rows.Add(row)
        row = tbl.NewRow
        row("Height") = "6`07"
        tbl.Rows.Add(row)
        row = tbl.NewRow
        row("Height") = "6`08"
        tbl.Rows.Add(row)
        row = tbl.NewRow
        row("Height") = "6`09"
        tbl.Rows.Add(row)
        row = tbl.NewRow
        row("Height") = "6`10"
        tbl.Rows.Add(row)
        row = tbl.NewRow
        row("Height") = "6`11"
        tbl.Rows.Add(row)
    End Sub

    Private Sub PrepDataActive(ByRef tbl As DataTable)
        Dim row As DataRow
        Dim col As DataColumn

        tbl.Columns.Add("Code", GetType(System.String))
        tbl.Columns.Add("Active", GetType(System.String))

        row = tbl.NewRow
        row("Code") = "T" : row("Active") = "Active"
        tbl.Rows.Add(row)

        row = tbl.NewRow
        row("Code") = "F" : row("Active") = "Inactive"
        tbl.Rows.Add(row)
    End Sub
    Private Sub LoadEmployeeBadgeInfo()
        Dim dtAdapter As SqlDataAdapter
        Dim dsSelect As DataSet
        Dim sqlSelect As String = "Select Hair, Eyes, EmployeeHeight, EmployeeWeight from " & HRTblPath & "EmployeeBadgeInfo where EmployeeID = " & EmplID.Text.Trim & ""


        PopulateDataset2(dtAdapter, dsSelect, sqlSelect)

        If dsSelect Is Nothing Then Exit Sub
        If dsSelect.Tables Is Nothing Then Exit Sub
        If dsSelect.Tables(0) Is Nothing Then Exit Sub

        If dsSelect.Tables(0).Rows.Count = 0 Then
            Weight.Text = ""
            ucboHair.Text = "Unknown"
            ucboEyes.Text = "Unknown"
            cboHeight.Text = "Unknown"
        Else
            Weight.Text = dsSelect.Tables(0).Rows(0).Item("EmployeeWeight")
            ucboHair.Text = dsSelect.Tables(0).Rows(0).Item("Hair")
            ucboEyes.Text = dsSelect.Tables(0).Rows(0).Item("Eyes")
            cboHeight.Text = dsSelect.Tables(0).Rows(0).Item("EmployeeHeight")

        End If



        'FillUCombo(ucboHair, "", "Select * from " & HRTblPath & "HairColor", "", "")
        'AddHandler ucboHair.Leave, AddressOf UCbo_Leave


        'FillUCombo(ucboHair, "", "", "Select * from " & HRTblPath & "HairColor", "", False, True)

        'FillUCombo(ucboHair, "", "", "", HRTblPath, False, True)
    End Sub
    Private Sub LoadAutoIns()
        Dim sqlAutoIns As String
        Dim dtAdapter As SqlDataAdapter
        Dim dsAutoIns As DataSet
        'Dim HidCols() As String = {"gcm.ClubID"}
        Dim HidCols() As String
        Dim SummFld As String
        Dim i As Int16

        If EmplID.Text.Trim = "" Then Exit Sub

        'sqlAutoIns = "Select gcm.GroupID, g.Group_Name, gcm.ClubID, gc.Club_Name From " & AppTblPath & "GroupClubMembers gcm left outer join " & AppTblPath & " Groups g on gcm.GroupID = g.GroupID left outer join " & AppTblPath & " GroupClubs gc on gcm.ClubID = gc.ClubID Where gcm.MemberID = " & AccountID.Text & " Order by g.Group_Name, gc.Club_Name "

        'sqlAutoIns = "select DISTINCT AutoInsPolNum, AutoInsName, AutoInsExpDate, AutoInsPhone from " & HRTblPath & "Vehicles where EmployeeID = " & EmplID.Text.Trim & "" & _
        '                " AND (AutoInsPolNum != '' or AutoInsName != '') UNION Select AutoINsPolNum, AutoInsName, AutoINsExpDate, AutoInsPhone from " & HRTblPath & "Employeeinfo" & _
        '                " Where EmployeeID = " & EmplID.Text.Trim & " AND (AutoInsPolNum != '' or AutoInsName != '') order by AutoInsName"
        'Deleted UNISON
        sqlAutoIns = "select DISTINCT AutoInsPolNum, AutoInsName, AutoInsExpDate, AutoInsPhone from " & HRTblPath & "Vehicles where EmployeeID = " & EmplID.Text.Trim & "" & _
                        " AND (AutoInsPolNum != '' or AutoInsName != '') order by AutoInsName"

        PopulateDataset2(dtAdapter, dsAutoIns, sqlAutoIns)

        For i = 0 To dsAutoIns.Tables(0).Columns.Count - 1
            dsAutoIns.Tables(0).Columns(i).ReadOnly = True
        Next
        'dsgroup.Tables(0).Columns(0).ReadOnly = False

        FillUltraGrid(UltraGrid4, dsAutoIns, -1, HidCols, 0)
        'UltraGrid1.DataSource = dsgroup
        'UGLoadLayout(Me, UltraGrid1, 1)
        UltraGrid4.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True
        UltraGrid4.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect
        UltraGrid4.DisplayLayout.AutoFitColumns = False
        For i = 0 To UltraGrid4.DisplayLayout.Bands(0).Columns.Count - 1
            UltraGrid4.DisplayLayout.Bands(0).Columns(i).TabStop = True
            UltraGrid4.DisplayLayout.Bands(0).Columns(i).CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Next

        UltraGrid4.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.True

        'UltraGrid1.DisplayLayout.Bands(0).Summaries.Add("Mileage", Infragistics.Win.UltraWinGrid.SummaryType.Sum, UltraGrid1.DisplayLayout.Bands(0).Columns("Mileage"), Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn)
        'UltraGrid1.DisplayLayout.Bands(0).Summaries("Mileage").Appearance.TextHAlign = Infragistics.Win.HAlign.Right
        'UltraGrid1.DisplayLayout.Bands(0).SummaryFooterCaption = ""
        'UltraGrid1.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False

        ''SummFld = "Club_Name"
        ''UltraGrid4.DisplayLayout.Bands(0).Summaries.Add(SummFld, Infragistics.Win.UltraWinGrid.SummaryType.Count, UltraGrid4.DisplayLayout.Bands(0).Columns(SummFld), Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn)
        ''UltraGrid4.DisplayLayout.Bands(0).Summaries(SummFld).Appearance.TextHAlign = Infragistics.Win.HAlign.Right
        ''UltraGrid4.DisplayLayout.Bands(0).SummaryFooterCaption = ""
        ''UltraGrid4.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False


        ''UltraGrid4.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus

        UltraGrid4.DisplayLayout.GroupByBox.Hidden = False
        UltraGrid4.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        UltraGrid4.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid, False, False)

        dsAutoIns.Dispose()
        dsAutoIns = Nothing

    End Sub
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim cnt As Integer
        Dim ID As Integer
        Dim IdentIns As Boolean = False
        Dim CritTmp, StrArr(), sqlTemp As String

        StrArr = GetCtrldbFieldInfo(EmplID)

        If Val(EmplID.Text.Trim) < 0 Then
            MsgBox("Please input valid ID number.")
            Exit Sub
        End If

        If txbFName.Text.Trim = "" Or txbLName.Text.Trim = "" Then
            MsgBox("Enter First Name and Last Name!")
            Exit Sub
        End If

        'udtEndDate.Nullable = True
        'udtEndDate.Value = "01/01/1980"

        If cboActive.Text = "Active" Then
            'udtEndDate.Nullable = True
            'udtEndDate.Value = ""
            udtEndDate.Nullable = True
            udtEndDate.Value = ""
        Else
            'If udtEndDate.Value = "" Then
            '    udtEndDate.Value = Date.Today
            'End If
            'udtEndDate.Nullable = True
            udtEndDate.Value = Date.Today
        End If

        If EmplID.Text.Trim <> "" Then
            EmplID2.Text = EmplID.Text
            CritTmp = EmplCriteria2.Replace("@EmplID", EmplID.Text)
            IdentIns = True
            If btnEdit.Text.ToUpper = "&CANCEL" Then
                EmplID.Tag = StrArr(TagOpts.dtTableName) & "." & StrArr(TagOpts.dtFieldName) & "." & "View"
                EmplID2.Tag = StrArr(TagOpts.dtTableName) & "." & StrArr(TagOpts.dtFieldName) & "." & "View"
            Else
                EmplID.Tag = StrArr(TagOpts.dtTableName) & "." & StrArr(TagOpts.dtFieldName) & "." & "INSERT"
                EmplID2.Tag = StrArr(TagOpts.dtTableName) & "." & StrArr(TagOpts.dtFieldName) & "." & "INSERT"
            End If
        Else
            EmplID2.Text = EmplID.Text
            CritTmp = ""
            IdentIns = False
            EmplID.Tag = StrArr(TagOpts.dtTableName) & "." & StrArr(TagOpts.dtFieldName) & "." & "View"
            EmplID2.Tag = StrArr(TagOpts.dtTableName) & "." & StrArr(TagOpts.dtFieldName) & "." & "View"
        End If

        Dim TabPg As TabPage = Nothing
        Dim TabName As String = ""
        Select Case True
            Case GroupBox5.Enabled
                TabName = "tpPayInfo"
            Case GroupBox6.Enabled
                TabName = "tpDeductions"
            Case GroupBox2.Enabled
                TabName = "tpBSet"
            Case GroupBox7.Enabled
                TabName = "tpAddInfo"
            Case GroupBox8.Enabled
                TabName = "tpVehicles"
        End Select
        For Each TabPg In TabCtrl1.TabPages
            If TabPg.Name = TabName Then
                Exit For
            End If
        Next
        If TabPg Is Nothing Then
            MsgBox("No Active Tab Page.")
            Exit Sub
        End If

        Select Case TabPg.Name
            Case "tpPayInfo"
                If EmplID.Text.Trim = "" Then
                    MsgBox("EmployeeID is empty.")
                    Exit Sub
                End If
                If ucboDept.Value Is Nothing Then
                    MsgBox("Department is not selected.")
                    Exit Sub
                End If

                sqlTemp = sqlPay.ToUpper.Replace("@EMPLID", EmplID.Text.Trim)
                Dim OldDeptNo As String
                If Not cmdTrans Is Nothing Then
                    OldDeptNo = UltraGrid2.ActiveRow.Cells("DeptNo").Value
                Else
                    OldDeptNo = ucboDept.Value
                End If
                If EditForm(TabPg, sqlTemp, EditAction.ENDEDIT, cmdTrans, " Where EmployeeID = " & EmplID.Text.Trim & " AND DeptNo = '" & OldDeptNo & "'") Then
                    'If EditForm(TabPg, sqlTemp, EditAction.ENDEDIT, cmdTrans, " AND DeptNo = " & ucboDept.Value) Then
                    'btnEdit.Text = "&Edit"
                    'Me.Text = MeText & " -- Record Updated."
                    'PopulateDataset2(dtA, dtSet, SQLSelect)
                    'sender.text = "&New"
                    ClearForm(TabPg)
                    ucboDept.Text = ""
                    ucboWCCode.Text = ""
                    ucboClass.Text = ""

                    btnEdit.Text = "&Edit"
                    btnNew.Text = "&New"
                    btnSave.Text = "&Save"
                    LoadPayInfo()
                    Group_EnDis(False, TabPg)
                End If
            Case "tpDeductions"
                If EmplID.Text.Trim = "" Then
                    MsgBox("EmployeeID is empty.")
                    Exit Sub
                End If
                If ucboDeduction.Value Is Nothing Then
                    MsgBox("Deduction is not selected.")
                    Exit Sub
                End If

                sqlTemp = sqlDeduction.ToUpper.Replace("@EMPLID", EmplID.Text.Trim)

                If EditForm(TabPg, sqlTemp, EditAction.ENDEDIT, cmdTrans, " Where EmployeeID = " & EmplID.Text.Trim & " AND RowID = " & utRowID.Text) Then
                    'btnEdit.Text = "&Edit"
                    'Me.Text = MeText & " -- Record Updated."
                    'PopulateDataset2(dtA, dtSet, SQLSelect)
                    'sender.text = "&New"
                    ClearForm(TabPg)
                    btnEdit.Text = "&Edit"
                    btnNew.Text = "&New"
                    btnSave.Text = "&Save"
                    LoadDeductions()
                    Group_EnDis(False, TabPg)
                End If
            Case "tpBSet"
                TabPg.Tag = AppTblPath & "EmployeesBase"
                'If cmdTrans Is Nothing Then
                '    If EmplID.Text.Trim = "" Then
                '        EmplID.Tag = ".ID.view"
                '    Else
                '        EmplID.Tag = ".ID.insert"
                '    End If
                'End If
                If EditForm(TabPg, SQLSelectBase, EditAction.ENDEDIT, cmdTrans, CritTmp, IdentIns) Then
                    TabPg.Tag = ""
                    ClearForm(TabCtrl1.SelectedTab)
                    Me.Text = MeText & " - Record Saved."

                    If EmplID.Text = "" Then

                        LoadData("", "P")

                        PictureBox.Image = pbDefaultPhoto.Image
                    Else
                        LoadData(EmplID.Text, "C")

                        ImageUploadORLoad()
                        If imageStatus = False Then
                            bUpload.Text = "Upload"
                            PictureBox.Image = pbDefaultPhoto.Image
                        Else
                            bUpload.Text = "Replace"
                            LoadImage()
                        End If

                    End If

                    btnEdit.Text = "&Edit"
                    btnNew.Text = "&New"

                    Group_EnDis(False, TabPg)

                End If
                TabPg.Tag = ""
            Case "tpAddInfo" '
                'MessageBox.Show("ENDEDIT TP Add Info")
                If cmdTrans Is Nothing Then
                    MsgBox("Insert is not permitted.")
                    Exit Sub
                End If
                If CritTmp <> "" Then
                    CritTmp = EmplCriteria3.Replace("@EmplID", EmplID.Text)
                End If
                TabPg.Tag = HRTblPath & "EmployeeInfo"
                IdentIns = False
                If EditForm(TabPg, SQLSelectAdtl, EditAction.ENDEDIT, cmdTrans, CritTmp, IdentIns) Then
                    'Save Employee Badge Info
                    'Create an Insert Statement to save the current values in thouse fields for current employee
                    'Weight
                    Dim insertWeight As String = "Update " & HRTblPath & "EmployeeBadgeInfo set Hair = '" & ucboHair.Text & "', Eyes = '" & ucboEyes.Text & "', EmployeeWeight = '" & Weight.Text & "', EmployeeHeight = '" & cboHeight.Text & "'  WHERE Employeeid = '" & EmplID.Text.Trim & "'"
                    If ExecuteQuery(insertWeight) = False Then
                        MsgBox("Error inserting Weight.")
                    End If

                    TabPg.Tag = ""
                    ClearForm(TabCtrl1.SelectedTab)
                    Me.Text = MeText & " - Record Saved."

                    If EmplID.Text = "" Then

                        LoadData("", "P")

                        PictureBox.Image = pbDefaultPhoto.Image
                    Else
                        LoadData(EmplID.Text, "C")

                        ImageUploadORLoad()
                        If imageStatus = False Then
                            bUpload.Text = "Upload"
                            PictureBox.Image = pbDefaultPhoto.Image
                        Else
                            bUpload.Text = "Replace"
                            LoadImage()
                        End If

                    End If

                    btnEdit.Text = "&Edit"
                    btnNew.Text = "&New"

                    Group_EnDis(False)
                End If
                TabPg.Tag = ""
            Case "tpVehicles"

                'Dim Acitve As String
                If EmplID.Text.Trim = "" Then
                    MsgBox("EmployeeID is empty.")
                    Exit Sub
                End If
                If ucboType.Value Is Nothing Then
                    MsgBox("Type of the vehicle not selected.")
                    Exit Sub
                End If
                'sqlTemp = sqlTemp.ToUpper.Replace("@EMPLID", EmplID.Text.Trim)
                sqlTemp = sqlVehicles.ToUpper.Replace("@EMPLID", EmplID.Text.Trim)
                If EditForm(TabPg, sqlTemp, EditAction.ENDEDIT, cmdTrans, " Where EmployeeID = " & EmplID.Text.Trim & " AND RowID = " & utVehRowID.Text) Then
                    'If EditForm(TabPg, sqlTemp, EditAction.ENDEDIT, cmdTrans, " Where EmployeeID = " & EmplID.Text.Trim) Then
                    'btnEdit.Text = "&Edit"
                    'Me.Text = MeText & " -- Record Updated."
                    'PopulateDataset2(dtA, dtSet, SQLSelect)
                    'sender.text = "&New"
                    ClearForm(TabPg)
                    btnEdit.Text = "&Edit"
                    btnNew.Text = "&New"
                    btnSave.Text = "&Save"
                    LoadVehicles(True)
                    Group_EnDis(False, TabPg)
                End If
            Case Else


        End Select

    End Sub

    Private Sub btnSaveNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveNew.Click
        'Karina "Field empty - don't save"
        If txbFName.Text.Trim = "" Or txbLName.Text.Trim = "" Then
            MsgBox("Enter First Name and Last Name!")
            Exit Sub
        End If
        If btnNew.Text = "&New" Then
            MessageBox.Show("You have to be in 'New' mode to be able to use this button.")
            Exit Sub
        End If
        If EditForm(Me, SQLSelect2, EditAction.ENDEDIT, cmdTrans, " Where ID = " & EmplID.Text) Then
            Dim row As DataRow
            Dim dtA As New SqlDataAdapter

            PopulateDataset2(dtA, dtSet, SQLSelect2)
            'ClearForm(Me)
            EmplID.Text = ""
            Group_EnDis(True)
            EmplID.Focus()
            btnSave.Text = "&Save"
        End If

    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Dim CritTmp, sqlTemp As String

        If btnNew.Text = "&Cancel" Then
            MessageBox.Show("You are in 'New' mode. Cancel or Save your current job first.")
            Exit Sub
        End If

        If EmplID.Text.Trim = "" Then Exit Sub

        If sender.text.toupper = "&EDIT" Then
            Select Case TabCtrl1.SelectedTab.Name
                Case "tpDeductions"
                    If UltraGrid1.ActiveRow Is Nothing Then Exit Sub

                    If ucboDeduction.Value Is Nothing Then
                        MsgBox("Deduction is not specified.")
                        Exit Sub
                    End If

                    sqlTemp = sqlDeduction.Replace("@EMPLID", EmplID.Text.Trim)
                    If EditForm(TabCtrl1.SelectedTab, PrepSelectQuery(sqlTemp, " AND RowID = " & utRowID.Text), EditAction.START, cmdTrans) Then
                        sender.text = "&Cancel"
                        GroupBox1.Enabled = False
                        Group_EnDis(True, TabCtrl1.SelectedTab)
                        'tabctrl1.TabPages(4).Enabled = True
                        'Enabletions(True)
                        'btnSaveNew.Enabled = False
                    End If
                Case "tpVehicles"
                    If UltraGrid3.ActiveRow Is Nothing Then Exit Sub

                    sqlTemp = sqlVehicles.Replace("@EMPLID", EmplID.Text.Trim)
                    If EditForm(TabCtrl1.SelectedTab, PrepSelectQuery(sqlTemp, " AND RowID = " & utVehRowID.Text), EditAction.START, cmdTrans) Then
                        sender.text = "&Cancel"
                        GroupBox1.Enabled = False
                        Group_EnDis(True, TabCtrl1.SelectedTab)
                    End If
                Case "tpPayInfo"
                    If UltraGrid2.ActiveRow Is Nothing Then Exit Sub

                    If ucboDept.Value Is Nothing Then
                        MsgBox("Department is not specified.")
                        Exit Sub
                    End If

                    sqlTemp = sqlPay.Replace("@EMPLID", EmplID.Text.Trim)
                    If EditForm(TabCtrl1.SelectedTab, PrepSelectQuery(sqlTemp, " AND DeptNo = '" & ucboDept.Value & "'"), EditAction.START, cmdTrans) Then
                        sender.text = "&Cancel"
                        GroupBox1.Enabled = False
                        Group_EnDis(True, TabCtrl1.SelectedTab)
                        'tabctrl1.TabPages(4).Enabled = True
                        'Enabletions(True)
                        'btnSaveNew.Enabled = False
                    End If
                Case "tpBSet"
                    If EditForm(TabCtrl1.SelectedTab, PrepSelectQuery(SQLSelectBase, EmplCriteria2.Replace("@EmplID", EmplID.Text.Trim)), EditAction.START, cmdTrans) Then
                        'TabCtrl1.TabPages(0).Enabled = True
                        'EnableBasicSetup(True)
                        Group_EnDis(True, TabCtrl1.SelectedTab)
                        'Dim TabPg As TabPage
                        'For Each TabPg In TabCtrl1.TabPages
                        '    If TabPg.Name <> TabCtrl1.SelectedTab.Name Then
                        '        TabPg.Enabled = False
                        '    Else
                        '        TabPg.Enabled = True
                        '    End If
                        'Next

                        'btnSaveNew.Enabled = False
                        sender.text = "&Cancel"
                    End If

                Case "tpAddInfo"
                    If EditForm(TabCtrl1.SelectedTab, PrepSelectQuery(SQLSelectAdtl, EmplCriteria3.Replace("@EmplID", EmplID.Text.Trim)), EditAction.START, cmdTrans) Then
                        'TabCtrl1.TabPages(0).Enabled = True
                        'EnableBasicSetup(True)
                        Group_EnDis(True, TabCtrl1.SelectedTab)
                        'Dim TabPg As TabPage
                        'For Each TabPg In TabCtrl1.TabPages
                        '    If TabPg.Name <> TabCtrl1.SelectedTab.Name Then
                        '        TabPg.Enabled = False
                        '    Else
                        '        TabPg.Enabled = True
                        '    End If
                        'Next

                        'btnSaveNew.Enabled = False
                        sender.text = "&Cancel"
                    End If
                Case Else
            End Select
        Else
            Select Case True
                Case GroupBox5.Enabled
                    sqlTemp = sqlPay.Replace("@EMPLID", EmplID.Text.Trim)
                    If EditForm(Me, sqlTemp, EditAction.CANCEL, cmdTrans) Then
                        Group_EnDis(False)
                        sender.text = "&Edit"
                        LoadPayInfo()
                    End If
                Case GroupBox6.Enabled
                    sqlTemp = sqlDeduction.Replace("@EMPLID", EmplID.Text.Trim)
                    If EditForm(Me, sqlTemp, EditAction.CANCEL, cmdTrans) Then
                        Group_EnDis(False)
                        'btnSaveNew.Enabled = True
                        sender.text = "&Edit"
                        'LoadData(EmplID.Text.Trim)
                        LoadDeductions()
                    End If
                Case Else
                    If EditForm(Me, SQLSelect2, EditAction.CANCEL, cmdTrans) Then
                        Group_EnDis(False)
                        'btnSaveNew.Enabled = True
                        sender.text = "&Edit"


                        LoadData(EmplID.Text.Trim)


                        ImageUploadORLoad()
                        If imageStatus = False Then
                            bUpload.Text = "Upload"
                            PictureBox.Image = pbDefaultPhoto.Image
                        Else
                            bUpload.Text = "Replace"
                            LoadImage()
                        End If



                    End If
            End Select

        End If

    End Sub
    Private Sub EnableBasicSetup(ByVal status As Boolean)

        Dim TabPg As TabPage

        btnSave.Enabled = status
        btnDelete.Enabled = True
        If btnNew.Text.ToUpper = "&CANCEL" Then
            btnSaveNew.Enabled = True
        Else
            btnSaveNew.Enabled = False
        End If

        btnSave.Text = "&Save"
        btnPrev.Enabled = Not status
        btnNext.Enabled = Not status
    End Sub
    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        'Dim CritTmp As String

        'CritTmp = EmplCriteria2.Replace("@EmplID", EmplID.Text)
        'If Not cmdTrans Is Nothing Then
        '    If EditForm(Me, PrepSelectQuery(SQLSelect, CritTmp), EditAction.CANCEL, cmdTrans) Then
        '        'UltraGrid1.Enabled = True
        '        'Group_EnDis(False)
        '        sender.text = "&Edit"
        '    Else
        '        'Exit Sub
        '    End If

        'End If
        ''UGSaveLayout(Me, UltraGrid1, 1)
        Me.Close()

    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        'UltraGrid1.DeleteSelectedRows()
        If btnEdit.Text = "&Cancel" Then
            MessageBox.Show("You are in Edit mode. Cancel or Save your current job first.")
            Exit Sub
        End If

        If sender.text = "&New" Then
            If TabCtrl1.SelectedTab.Name <> "tpBSet" Then
                If TabCtrl1.SelectedTab.Name.ToUpper = "TPADDINFO" Then
                    MsgBox("To add a new employee, please select 'Basic Setup' tab then click new. 'Additional Info' is EDITABLE only.")
                    Exit Sub
                End If
                If EmplID.Text.Trim = "" Then
                    MsgBox("An employee must be selected to add Pay Information, Deductions or Vehicles.")
                    Exit Sub
                End If
                txtPayEmplID.Text = EmplID.Text
                txtDedEmplID.Text = EmplID.Text
                txtVehEmplID.Text = EmplID.Text
                ClearForm(TabCtrl1.SelectedTab)
                If TabCtrl1.SelectedTab.Name = "tpPayInfo" Then
                    ucboDept.Text = ""
                    ucboClass.Text = ""
                    ucboWCCode.Text = ""
                End If
                If TabCtrl1.SelectedTab.Name = "tpVehicles" Then
                    udtStartDate.Nullable = True
                    'udtStartDate.Value = "01/01/1980"
                    udtStartDate.Value = Date.Today
                    udtStartDate.FormatString = "MM/dd/yyyy"

                    udtLastInspDate.Nullable = True
                    udtLastInspDate.FormatString = "MM/dd/yyyy"

                    udtEndDate.Nullable = True
                    udtLastInspDate.Nullable = True
                    'udtEndDate.Value = "01/01/1980"

                    udtEndDate.FormatString = "MM/dd/yyyy"
                    udtLastInspDate.FormatString = "MM/dd/yyyy"

                    udtExpDate.Nullable = True
                    udtExpDate.Value = Date.Today
                    udtExpDate.FormatString = "MM/dd/yyyy"
                    'FillUCombo(ucboStatePlate, "CA", "", "", AppTblPath, False, False)
                    FillUCombo(ucboStatePlate, "CA")
                    FillUCombo(ucboType, "4", "", "", HRTblPath, False, False)
                    'FillUCombo(ucboType, "PICKUP")
                End If
            Else
                'ClearForm(TabCtrl1)
                EmplID.Text = ""
            End If
            sender.text = "&Cancel"
            btnSave.Text = "&Save"
            Group_EnDis(True, TabCtrl1.SelectedTab)
            If TabCtrl1.SelectedTab.Name = "tpBSet" Then
                GroupBox1.Enabled = True
                btnDelete.Enabled = True
            End If
            'Dim TabName As String
            'TabName = TabCtrl1.SelectedTab.Text

            'Dim TabPg As TabPage

            'For Each TabPg In TabCtrl1.TabPages
            '    TabPg.Enabled = False
            '    If TabPg.Text = TabName Then
            '        TabPg.Enabled = True
            '    End If
            'Next
            EmplID.Focus()
        Else
            'ClearForm(Me)
            If GroupBox2.Enabled = True Then
                EmplID.Text = "" ' Clear All tabs
            End If
            sender.text = "&New"
            Group_EnDis(False)
            btnSave.Text = "&Update"

        End If
    End Sub

    Private Sub LoadData(Optional ByVal IDValue As String = "", Optional ByVal Direction As String = "C")
        Dim dtAdapter As SqlDataAdapter
        Dim dvAcct As New DataView
        Dim dtSet2 As New DataSet
        Dim dtSet3 As DataSet
        Dim TempQuery As String
        Dim CritTmp As String

        btnDelete.Enabled = True

            If Val(IDValue) > 0 Then
                CritTmp = EmplCriteria.Replace("@EmplID", IDValue)
            Else
                CritTmp = ""
            End If

            Select Case Direction.ToUpper
                Case "N"
                    If CritTmp = "" Then
                        CritTmp = EmplCriteria.Replace("@EmplID", "0")
                    End If
                    CritTmp = CritTmp.Replace("=", ">")
                Case "C"
                Case "P"
                    If CritTmp = "" Then
                        CritTmp = EmplCriteria.Replace("@EmplID", "999999999")
                    End If
                    CritTmp = CritTmp.Replace("=", "<")
            End Select


            TempQuery = PrepSelectQuery(SQLSelect2, CritTmp)

            PopulateDataset2(dtAdapter, dtSet2, TempQuery)
            If dtSet2 Is Nothing Then Exit Sub
            If dtSet2.Tables Is Nothing Then Exit Sub
            If dtSet2.Tables(0) Is Nothing Then Exit Sub

            If dtSet2.Tables(0).Rows.Count = 0 Then
                If Direction.ToUpper = "C" Then
                    'Group_EnDis(True)
                    'EmplID.Text = ""
                    ''ClearForm(TabCtrl1)
                    'txbFName.Focus()
                    'btnNew.Text = "&Cancel"
                    'btnSave.Text = "Save"
                    TabCtrl1.TabPages(0).Select()
                    'ClearForm(TabCtrl1)
                    Dim TmpEmplID As String
                    TmpEmplID = EmplID.Text
                    EmplID.Text = ""
                    MessageBox.Show("No Records found.")
                    'EmplID.Text = TmpEmplID
                    'btnNew_Click(btnNew, New System.EventArgs)
                Else
                    MessageBox.Show("No Records found.")
                End If
                'ClearForm(GroupBox2)
            Else
                EmplID.Text = "" ' Clears the form
                Group_EnDis(False)
                btnSave.Text = "&Save"
                btnEdit.Text = "&Edit"
                btnNew.Text = "&New"

                dvAcct.Table = dtSet2.Tables(0)
                If Direction.ToUpper = "N" Then
                    dvAcct.RowFilter = "ID = Min(ID)"
                ElseIf Direction.ToUpper = "P" Then
                    dvAcct.RowFilter = "ID = Max(ID)"
                End If
                FormLoad(Me, dvAcct)


                CritTmp = EmplCriteria3.Replace("@EmplID", EmplID.Text.Trim)
                TempQuery = PrepSelectQuery(SQLSelectAdtl, CritTmp)
                PopulateDataset2(dtAdapter, dtSet3, TempQuery)
                If dtSet3.Tables(0).Rows.Count = 0 Then
                    If ExecuteQuery("Insert into " & HRTblPath & "EmployeeInfo(EmployeeID) values('" & EmplID.Text.Trim & "')") = False Then
                        MsgBox("Error inserting blank row for Additional Info.")
                    End If
                End If
                dtSet3 = Nothing
            End If


            dtSet2 = Nothing
            Select Case TabCtrl1.SelectedTab.Name
                Case "tpPayInfo" 'EmployeePayRates
                    LoadPayInfo()
                Case "tpAddInfo"
                    LoadAutoIns()
                    LoadEmployeeBadgeInfo()
                Case "tpDeductions"
                    LoadDeductions()
                Case "tpVehicles"
                    LoadVehicles()
            End Select


    End Sub

    Private Sub EmplID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles EmplID.Leave
        Dim row As DataRow

        'CritTmp = EmplCriteria.Replace("@EmplID", EmplID.Text)

        If sender.Modified = False Then Exit Sub
        If sender.Text.Trim = "" Then Exit Sub
        If btnNew.Text = "&Cancel" Or btnEdit.Text = "&Cancel" Then
            If ReturnRowByID(EmplID.Text, row, HRTblPath & "EmployeesBase") Then
                MsgBox("This ID is already assigned. Try other number.")
                EmplID.Undo()
                EmplID.ClearUndo()
                EmplID.Modified = False
                EmplID.Focus()
            End If
            Exit Sub
        End If

        sender.Modified = False


        LoadData(Val(EmplID.Text), "C")


        ImageUploadORLoad()
        If imageStatus = False Then

            '''Check if EmployeeBadge record for current employee exists already. Need to UPLOAD/UPDATE just photo
            ''Dim dtAdapterUpdate As New SqlDataAdapter
            ''Dim dtViewUpdate As New DataView
            ''Dim dtSetUpdate As New DataSet
            ''Dim SelectQueryUpdate As String = "Select Photo From " & HRTblPath & "EmployeeBadgeInfo Where EmployeeID = " & EmplID.Text.Trim & ""
            ''PopulateDataset2(dtAdapterUpdate, dtSetUpdate, SelectQueryUpdate)
            ''dtViewUpdate.Table = dtSetUpdate.Tables(0)
            ''If dtViewUpdate.Table.Rows.Count > 0 Then
            ''    'If dtView.Table.Rows(0).Item("Photo").Length <= 1 Then
            ''    '    'If (dtView.Table.Rows.Count <= 0) Then
            ''    '    'There is no photo in database for current user - UPLOAD the new photo
            ''    '    imageStatus = False
            ''    'Else
            ''    '    'These is a photo in database for current user - LOAD a new photo
            ''    '    imageStatus = True
            ''    'End If
            ''    bUpload.Text = "Replace"
            ''    LoadImage()
            ''Else
            ''    'imageStatus = False


                bUpload.Text = "Upload"
                PictureBox.Image = pbDefaultPhoto.Image
                'End If
        Else
            bUpload.Text = "Replace"
            LoadImage()
        End If



    End Sub

    'Karina, fixing order of buttong able/unable
    Private Sub Group_EnDis(ByVal status As Boolean, Optional ByVal TabPg As TabPage = Nothing)
        'Dim TabPg As TabPage
        btnSave.Enabled = status

        If btnNew.Text.ToUpper = "&CANCEL" Then
            btnSaveNew.Enabled = True
            btnPrev.Enabled = False
            btnNext.Enabled = False
            btnEmplID.Enabled = False
            InsertMsg.Visible = True
        Else
            btnSaveNew.Enabled = False
            btnPrev.Enabled = True
            btnNext.Enabled = True
            btnEmplID.Enabled = True
            InsertMsg.Visible = False
        End If

        ' Tab Based: GroupBox2.Enabled = status
        'to enable tabs


        Btn_En(status)

        GroupBox1.Enabled = Not status

        GroupBox2.Enabled = False
        GroupBox4.Enabled = False

        GroupBox5.Enabled = False

        GroupBox6.Enabled = False

        GroupBox7.Enabled = False
        ucboState2.Enabled = True

        UltraGrid1.Enabled = True
        UltraGrid2.Enabled = True

        GroupBox8.Enabled = False
        UltraGrid3.Enabled = True

        If Not TabPg Is Nothing Then
            Select Case TabPg.Name
                Case "tpBSet"
                    GroupBox2.Enabled = status
                    GroupBox4.Enabled = status
                    ucboCompany.Enabled = True
                    btnDelete.Enabled = True

                Case "tpAddInfo"
                    GroupBox7.Enabled = status
                    ucboGender.Enabled = True
                    ucboRace.Enabled = True
                    ucboMaritalStatus.Enabled = True
                    'ucboHair.Enabled = True
                    'ucboEyes.Enabled = True
                    'cboHeight.Enabled = True

                Case "tpPayInfo"
                    GroupBox5.Enabled = status
                    UltraGrid2.Enabled = Not status

                Case "tpDeductions"
                    GroupBox6.Enabled = status
                    UltraGrid1.Enabled = Not status

                Case "tpVehicles"
                    GroupBox8.Enabled = status
                    UltraGrid3.Enabled = Not status
            End Select
        End If

    End Sub
    Private Sub Btn_En(ByVal status As Boolean)

        btnSave.Enabled = status
        If status = True Then 'Enable Editing

        Else 'End Editing
            btnNew.Enabled = True
            btnEdit.Enabled = True
            btnEdit.Text = "&Edit"
            btnNew.Text = "&New"
        End If

        btnSave.Text = "&Save"
    End Sub

    Private Sub btnEmpl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmplID.Click


        'Dim row As DataRow
        'Dim dvAcct As New DataView()

        'If SearchOnLeave(FName, EmplID, AppTblPath & "EmployeesBase", , "FirstName", "*", "Employees") Then
        '    dvAcct.Table = row.Table
        '    FormLoad(Me, dvAcct)
        'End If



        Dim SelectQry As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow

        'SelectQry = "Select ID, FirstName, MiddleName, LastName from " & Me.Tag & " order by LastName"
        SelectQry = "Select eb.ID, eb.FirstName, eb.MiddleName, eb.LastName, eb.OfficeID, so.Name as Office,  eb.Company from " & HRTblPath & "EmployeesBase eb left outer join " & HRTblPath & "ServiceOffices so on eb.OfficeID = so.ID order by eb.LastName"
        PopulateDataset2(dtAdapter, dtSet, SelectQry)
        dtView.Table = dtSet.Tables(0)
        If dtView.Table.Rows.Count > 0 Then
            Dim Srch As New SearchListings
            Srch.dsList = dtSet

            Srch.UltraGrid1.Text = "Employees"
            Srch.Text = "Employees"
            Srch.ShowDialog()
            If Srch.DialogResult <> DialogResult.OK Then Exit Sub
            Try
                Dim cnt As Integer
                cnt = Srch.UltraGrid1.Rows.Count
            Catch Err As System.Exception
                'MsgBox("Zipcode Leave: " & Err.Message)
                Srch = Nothing
                sender.Focus()
                HasErr = True
                Exit Try
            Catch Err2 As System.NullReferenceException
                ' CANCEL PRESSED
                Srch = Nothing
                sender.Focus()
                HasErr = True
                Exit Try
            Catch osqlexception As SqlException
                MsgBox("SQL_Error: " & osqlexception.Message)
                Srch = Nothing
                sender.Focus()
                Exit Try
            Finally
                If HasErr = False Then
                    ugRow = Srch.UltraGrid1.ActiveRow
                    'AcctName.Text = ugRow.Cells("Name").Text
                    EmplID.Text = ugRow.Cells("ID").Text
                    Srch = Nothing
                    EmplID.Modified = True
                    Dim ev As New System.EventArgs
                    EmplID_Leave(EmplID, ev)
                End If
            End Try
        End If
    End Sub

    Private Sub EmplID_Int_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles EmplID.KeyPress
        If IsNumeric(e.KeyChar) = False And Asc(e.KeyChar) <> Keys.Back And e.KeyChar <> "-" Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGroup.Click
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim Title As String

        SelectSQL = "Select * From " & HRTblPath & "EmployeeGroups order by Name"
        Title = "Employee Groups"

        PopulateDataset2(dtAdapter, dtSet, SelectSQL)
        dtView.Table = dtSet.Tables(0)
        If dtView.Table.Rows.Count > 0 Then
            Dim Srch As New SearchListings
            Srch.dsList = dtSet

            Srch.UltraGrid1.Text = Title
            Srch.Text = Title
            Srch.ShowDialog()
            If Srch.DialogResult <> DialogResult.OK Then Exit Sub
            Try
                Dim cnt As Integer
                cnt = Srch.UltraGrid1.Rows.Count
            Catch Err As System.Exception
                'MsgBox("Zipcode Leave: " & Err.Message)
                Srch = Nothing
                sender.Focus()
                HasErr = True
                Exit Try
            Catch Err2 As System.NullReferenceException
                ' CANCEL PRESSED
                Srch = Nothing
                sender.Focus()
                HasErr = True
                Exit Try
            Catch osqlexception As SqlException
                MsgBox("SQL_Error: " & osqlexception.Message)
                Srch = Nothing
                sender.Focus()
                Exit Try
            Finally
                If HasErr = False Then
                    ugRow = Srch.UltraGrid1.ActiveRow
                    txbEmplGroupID.Text = ugRow.Cells("ID").Text
                    txbEmplGroup.Text = ugRow.Cells("Name").Text
                    Srch = Nothing
                End If
            End Try
        End If

    End Sub

    Private Sub EmplGroup_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbEmplGroup.KeyUp

        TypeAhead(sender, e, HRTblPath & "EmployeeGroups", "Name", "")
        'sender.modified = True
    End Sub

    Private Sub EmplGroup_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbEmplGroup.Leave
        Dim row As DataRow
        If sender.text.trim = "" Then
            txbEmplGroupID.Text = ""
            sender.text = ""
        ElseIf SearchOnLeave(sender, txbEmplGroupID, HRTblPath & "EmployeeGroups", , , "*", "Employee Groups") Then
            'If ReturnRowByID(EmplGroupID.Text, row, "EmployeeGroups") Then
            '    Street.Text = row("Street")
            '    City.Text = row("CityName")
            '    State.SelectedValue = row("StateCode")
            '    Zipcode.Text = row("Zipcode")
            '    Phone1.Text = row("Phone")
            '    'row.Table.DataSet = Nothing
            '    row = Nothing
            'End If
        End If
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        LoadData(Val(EmplID.Text), "N")
        ImageUploadORLoad()
        If imageStatus = False Then
            bUpload.Text = "Upload"
            PictureBox.Image = pbDefaultPhoto.Image
        Else
            bUpload.Text = "Replace"
            LoadImage()
        End If
    End Sub

    Private Sub btnPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrev.Click
        LoadData(Val(EmplID.Text), "P")
        ImageUploadORLoad()
        If imageStatus = False Then
            bUpload.Text = "Upload"
            PictureBox.Image = pbDefaultPhoto.Image
        Else
            bUpload.Text = "Replace"
            LoadImage()
        End If
    End Sub

    Private Sub EmployeesBase_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If btnEdit.Text = "&Cancel" Or btnNew.Text = "&Cancel" Then
            If MsgBox("Data is not saved! Are you sure you want to exit?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                e.Cancel = True
                Exit Sub
            End If
        End If

        If Not cmdTrans Is Nothing Then
            If EditForm(Me, SQLSelect2, EditAction.CANCEL, cmdTrans) Then
                'UltraGrid1.Enabled = True
                'Group_EnDis(False)
                sender.text = "&Edit"
            Else
                'Exit Sub
            End If

        End If
        'UGSaveLayout(Me, UltraGrid1, 1)
    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim Title As String

        SelectSQL = "Select * From " & HRTblPath & "ServiceOffices order by Name"
        Title = "Service Offices"

        PopulateDataset2(dtAdapter, dtSet, SelectSQL)
        dtView.Table = dtSet.Tables(0)
        If dtView.Table.Rows.Count > 0 Then
            Dim Srch As New SearchListings
            Srch.dsList = dtSet

            Srch.UltraGrid1.Text = Title
            Srch.Text = Title
            Srch.ShowDialog()
            If Srch.DialogResult <> DialogResult.OK Then Exit Sub
            Try
                Dim cnt As Integer
                cnt = Srch.UltraGrid1.Rows.Count
            Catch Err As System.Exception
                'MsgBox("Zipcode Leave: " & Err.Message)
                Srch = Nothing
                sender.Focus()
                HasErr = True
                Exit Try
            Catch Err2 As System.NullReferenceException
                ' CANCEL PRESSED
                Srch = Nothing
                sender.Focus()
                HasErr = True
                Exit Try
            Catch osqlexception As SqlException
                MsgBox("SQL_Error: " & osqlexception.Message)
                Srch = Nothing
                sender.Focus()
                Exit Try
            Finally
                If HasErr = False Then
                    ugRow = Srch.UltraGrid1.ActiveRow
                    utOfficeID.Text = ugRow.Cells("ID").Text
                    utOfficeName.Text = ugRow.Cells("Name").Text
                    Srch = Nothing
                End If
            End Try
        End If
    End Sub

    Private Sub utOfficeID_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles utOfficeID.Leave
        Dim dbRow As DataRow
        If sender.Modified = False Then Exit Sub
        If sender.Text.Trim = "" Then
            utOfficeID.Text = ""
            utOfficeName.Text = ""
            Exit Sub
        End If
        sender.modified = False
        If Val(sender.text) > 0 Then
            If ReturnRowByID(Val(sender.Text), dbRow, HRTblPath & "ServiceOffices", "where Active = 1") = False Then
                MsgBox("Account not found.")
                utOfficeID.Text = ""
                utOfficeName.Text = ""
                sender.Focus()
                Exit Sub
            End If
            utOfficeName.Text = dbRow.Item("NAME")
            sender.Modified = False
            ucboCompany.Focus()
            dbRow = Nothing
        End If
    End Sub

    Private Sub utOfficeName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utOfficeName.Leave
        Dim row As DataRow

        If sender.Modified = False Then Exit Sub

        If sender.text.trim = "" Then
            utOfficeID.Text = ""
            sender.text = ""
            'btnSave.Enabled = False
        Else
            ' This for Accounts With Numbers Only Name!!
            'If IsNumeric(sender.text) Then
            '    sender.text = "?" & sender.text
            '    sender.modified = True
            'End If
            If SearchOnLeave(sender, utOfficeID, HRTblPath & "ServiceOffices", "ID", "Name", "*", "Service Offices", " Where Active = 1 ") Then
                'If ReturnRowByID(utTruckInventID.Text, row, "TrucksManagement.dbo.Inventory", "", "Truck_Invent_ID") Then
                '    'utLicPlate.Text = row("Lic_Plate")
                '    'utTruckInventID.Text = row("Truck_Invent_ID")
                '    row = Nothing
                'Else
                '    MsgBox("Truck Not Found.")
                '    utTruckInventID.Text = ""
                '    utTruckID.Text = ""
                'End If
                ucboCompany.Focus()
            Else
                'MsgBox("Truck Not Found.")
                utOfficeID.Text = ""
                utOfficeName.Text = ""
                sender.focus()
            End If
        End If
        sender.Modified = False

    End Sub

    Private Sub utOfficeName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles utOfficeName.KeyUp
        TypeAhead(sender, e, HRTblPath & "ServiceOffices", "Name", " Where Active = 1 ")

    End Sub
    Private Sub LoadVehicles(Optional ByVal p_bUpdate As Boolean = False)
        'Dim sqlDeduction As String = "Select EmployeeID, RowID, DeductionID, Amount from " & HRTblPath & "EmployeeDeductions ed where EmployeeID = @EMPLID"
        'Dim sqlLoc As String = "Select EmployeeID, RowID, ed.DeductionID, d.Deduction, Amount from " & HRTblPath & "EmployeeDeductions ed ,  " & HRTblPath & "Deductions d where ed.DeductionID = d.DeductionID AND EmployeeID = @EMPLID"
        'Dim sqlVehicles As String = "Select LicPlate, State, EmployeeID, VIN, Make, Model, Color, Type, Mileage, StartDate, Remarks from " & HRTblPath & "VEHICLES where EmplID = @EMPLID"
        Dim sqlLoc As String = "Select RowID, LicPlate, State, EmployeeID, VIN, Make, Model, ModelYear, Color, Type, Mileage, StartDate, EndDate, Active, LastInspectDate, AutoInsName, AutoInsPolNum, AutoInsExpDate, AutoInsPhone, Remarks, AutoInsLimits from " & HRTblPath & "VEHICLES where EmployeeID = @EMPLID"
        Dim sqlLocs, Active As String
        Dim dtAdapter As SqlDataAdapter
        Dim dsLocs As DataSet
        Dim HidCols() As String = {"RowID", "EmployeeID"}
        Dim SummFld As String
        Dim i, TabIdx As Int16
        Dim page As System.Windows.Forms.TabPage

        'FillUCombo(ucboStatePlate, "CA", "", "", AppTblPath, False, False)
        'udtStartDate.Nullable = True
        'udtStartDate.Value = "01/01/1980"
        'udtStartDate.FormatString = "MM/dd/yyyy"

        'FillUCombo(ucboType, "", "", "", AppTblPath, False, False)
        'udtEndDate.Nullable = True
        'udtEndDate.Value = "01/01/1980"
        'udtEndDate.FormatString = "MM/dd/yyyy"
        btnDelete.Enabled = False
        udtStartDate.Nullable = True
        'udtStartDate.Value = "01/01/1980"
        udtStartDate.Value = Date.Today
        udtStartDate.FormatString = "MM/dd/yyyy"

        udtLastInspDate.Nullable = True
        udtLastInspDate.Value = Date.Today
        udtLastInspDate.FormatString = "MM/dd/yyyy"

        udtEndDate.Nullable = True
        'udtEndDate.Value = "01/01/1980"
        udtEndDate.Value = Date.Today
        udtEndDate.FormatString = "MM/dd/yyyy"

        udtExpDate.Nullable = True
        udtExpDate.Value = Date.Today
        udtExpDate.FormatString = "MM/dd/yyyy"
        'FillUCombo(ucboStatePlate, "CA", "", "", AppTblPath, False, False)
        FillUCombo(ucboStatePlate, "CA")
        FillUCombo(ucboType, "4", "", "", HRTblPath, False, False)
        'FillUCombo(ucboType, "PICKUP")

        If EmplID.Text.Trim = "" Then Exit Sub

        sqlLocs = sqlLoc.Replace("@EMPLID", EmplID.Text.Trim)


        For Each page In TabCtrl1.TabPages
            If page.Name = "tpVehicles" Then
                ClearForm(page)
                Exit For
            End If
        Next
        PopulateDataset2(dtAdapter, dsLocs, sqlLocs)

        'Update OdometerReset to reflect current Vehicle Info
        If p_bUpdate Then
            Dim x As Integer
            Dim sb As String
            For x = 0 To dsLocs.Tables(0).Rows.Count - 1
                sb = String.Empty
                sb = "UPDATE " & HRTblPath & "OdometerReset SET LicPlate = '" & dsLocs.Tables(0).Rows(x).Item("LicPlate") & "' WHERE VechicleRowID = " & dsLocs.Tables(0).Rows(x).Item("RowID") & " AND EmployeeID = '" & dsLocs.Tables(0).Rows(x).Item("EmployeeID") & "'"
                'MessageBox.Show(sb)
            Next
        End If

        For i = 0 To dsLocs.Tables(0).Columns.Count - 1
            dsLocs.Tables(0).Columns(i).ReadOnly = True
        Next
        'dsgroup.Tables(0).Columns(0).ReadOnly = False


        FillUltraGrid(UltraGrid3, dsLocs, -1, HidCols, 0)
        UltraGrid3.Enabled = True
        'Ultragrid1.DataSource = dsgroup
        'UGLoadLayout(Me, UltraGrid1, 1)
        UltraGrid3.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True
        UltraGrid3.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        UltraGrid3.DisplayLayout.AutoFitColumns = False
        For i = 0 To UltraGrid3.DisplayLayout.Bands(0).Columns.Count - 1
            UltraGrid3.DisplayLayout.Bands(0).Columns(i).TabStop = True
            UltraGrid3.DisplayLayout.Bands(0).Columns(i).CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Next

        UltraGrid3.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.True
        UltraGrid3.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus

        UltraGrid3.DisplayLayout.GroupByBox.Hidden = False
        UltraGrid3.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        UltraGrid3.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid, False, False)

        dsLocs.Dispose()
        dsLocs = Nothing


    End Sub
    Private Sub LoadPayInfo()
        Dim sqlLoc As String = "Select '@EMPLID' as EmployeeID, DeptNo, ClassID, WCCode, PayRate, MileageRate From " & HRTblPath & "EMPLOYEEPAYRATES where EmployeeID = @EMPLID"
        Dim sqlLocs As String
        Dim dtAdapter As SqlDataAdapter
        Dim dsLocs As DataSet
        Dim HidCols() As String = {"EmployeeID"}
        Dim SummFld As String
        Dim i, TabIdx As Int16
        Dim page As System.Windows.Forms.TabPage

        btnDelete.Enabled = True
        If EmplID.Text.Trim = "" Then Exit Sub

        sqlLocs = sqlLoc.Replace("@EMPLID", EmplID.Text.Trim)

        For Each page In TabCtrl1.TabPages
            If page.Name = "tpPayInfo" Then
                ClearForm(page)
                Exit For
            End If
        Next

        PopulateDataset2(dtAdapter, dsLocs, sqlLocs)

        For i = 0 To dsLocs.Tables(0).Columns.Count - 1
            dsLocs.Tables(0).Columns(i).ReadOnly = True
        Next
        'dsgroup.Tables(0).Columns(0).ReadOnly = False


        FillUltraGrid(UltraGrid2, dsLocs, -1, HidCols, 0)
        UltraGrid2.Enabled = True
        'Ultragrid2.DataSource = dsgroup
        'UGLoadLayout(Me, Ultragrid2, 1)
        UltraGrid2.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True
        UltraGrid2.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        UltraGrid2.DisplayLayout.AutoFitColumns = False
        For i = 0 To UltraGrid2.DisplayLayout.Bands(0).Columns.Count - 1
            UltraGrid2.DisplayLayout.Bands(0).Columns(i).TabStop = True
            UltraGrid2.DisplayLayout.Bands(0).Columns(i).CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Next

        UltraGrid2.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.True
        UltraGrid2.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus

        UltraGrid2.DisplayLayout.GroupByBox.Hidden = False
        UltraGrid2.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        UltraGrid2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid, False, False)

        dsLocs.Dispose()
        dsLocs = Nothing



    End Sub
    Private Sub LoadDeductions()
        'Dim sqlLoc As String = "Select '@EMPLID' as EmployeeID, RowID, DeductionID, Amount From " & HRTblPath & "EMPLOYEEDEDUCTIONS where EmployeeID = @EMPLID"
        Dim sqlLoc As String = "Select EmployeeID, RowID, ed.DeductionID, d.Deduction, Amount from " & HRTblPath & "EmployeeDeductions ed ,  " & HRTblPath & "Deductions d where ed.DeductionID = d.DeductionID AND EmployeeID = @EMPLID"
        Dim sqlLocs As String
        Dim dtAdapter As SqlDataAdapter
        Dim dsLocs As DataSet
        Dim HidCols() As String = {"EmployeeID", "RowID", "DeductionID"}
        Dim SummFld As String
        Dim i, TabIdx As Int16
        Dim page As System.Windows.Forms.TabPage

        btnDelete.Enabled = True

        If EmplID.Text.Trim = "" Then Exit Sub

        sqlLocs = sqlLoc.Replace("@EMPLID", EmplID.Text.Trim)

        For Each page In TabCtrl1.TabPages
            If page.Name = "tpDeductions" Then
                ClearForm(page)
                Exit For
            End If
        Next

        PopulateDataset2(dtAdapter, dsLocs, sqlLocs)

        For i = 0 To dsLocs.Tables(0).Columns.Count - 1
            dsLocs.Tables(0).Columns(i).ReadOnly = True
        Next
        'dsgroup.Tables(0).Columns(0).ReadOnly = False


        FillUltraGrid(UltraGrid1, dsLocs, -1, HidCols, 0)
        UltraGrid1.Enabled = True
        'Ultragrid1.DataSource = dsgroup
        'UGLoadLayout(Me, UltraGrid1, 1)
        UltraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True
        UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        UltraGrid1.DisplayLayout.AutoFitColumns = False
        For i = 0 To UltraGrid1.DisplayLayout.Bands(0).Columns.Count - 1
            UltraGrid1.DisplayLayout.Bands(0).Columns(i).TabStop = True
            UltraGrid1.DisplayLayout.Bands(0).Columns(i).CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Next

        UltraGrid1.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.True
        UltraGrid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus

        UltraGrid1.DisplayLayout.GroupByBox.Hidden = False
        UltraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid, False, False)

        dsLocs.Dispose()
        dsLocs = Nothing


    End Sub
    Private Sub TabCtrl1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabCtrl1.Click

        Select Case TabCtrl1.SelectedIndex
            Case 0 ' Basic Setup
                btnDelete.Enabled = True
            Case 1 ' Additional Info
                btnDelete.Enabled = False
                LoadEmployeeBadgeInfo()
                LoadAutoIns()
            Case 2 ' Pay Info
                If btnNew.Text.ToUpper <> "&CANCEL" And btnEdit.Text.ToUpper <> "&CANCEL" Then
                    btnDelete.Enabled = True
                    LoadPayInfo()
                End If
            Case 3 ' Deductions
                If btnNew.Text.ToUpper <> "&CANCEL" And btnEdit.Text.ToUpper <> "&CANCEL" Then
                    btnDelete.Enabled = True
                    LoadDeductions()
                End If
            Case 4 ' Vehicles
                If btnNew.Text.ToUpper <> "&CANCEL" And btnEdit.Text.ToUpper <> "&CANCEL" Then
                    btnDelete.Enabled = True
                    LoadVehicles()
                End If
        End Select

    End Sub

    Private Sub City_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles City.Leave, ZipCode.Leave
        'On Error GoTo ErrTrap
        Dim daCity As New SqlDataAdapter
        Dim dsCity As New DataSet
        Dim dvCities1 As New DataView
        Dim gZipcode, gCity As Control
        Dim gPhone As Control
        Dim gState As Infragistics.Win.UltraWinGrid.UltraCombo
        'Dim gState As ComboBox
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow

        Dim CitiesSQL As String = "Select ID, Name as City, Zipcode, StateCode as State from  " & HRTblPath & "City "
        HasErr = False
        If sender.Modified Then
            gZipcode = ZipCode
            gCity = City
            gState = ucboState2
            gPhone = Phone1
            'Zipcode.Text = sender.Text.ToString
            'City.Text = dvCities1.Table.Rows(0).Item("Name")
            'UltraMaskedEdit1.Focus()
            'State.SelectedValue = dvCities1.Table.Rows(0).Item("StateCode")
            If IsNumeric(sender.Text) Then ' Zipcode
                CitiesSQL = CitiesSQL & " where zipcode = '" & sender.Text & "'"
                PopulateDataset2(daCity, dsCity, CitiesSQL)
                dvCities1.Table = dsCity.Tables(0)
                If dvCities1.Table.Rows.Count > 0 Then
                    gZipcode.Text = sender.Text.ToString
                    gCity.Text = dvCities1.Table.Rows(0).Item("City")
                    gPhone.Focus()
                    gState.Value = dvCities1.Table.Rows(0).Item("State")

                    'gState.SelectedValue = dvCities1.Table.Rows(0).Item("State")
                Else
                    MsgBox("Zipcode not found!", MsgBoxStyle.OKOnly, MeText)
                    ZipCode.ResetText()
                    ZipCode.Focus()
                End If
            Else 'Blank or City Name
                If sender.text.trim() = "" Then Exit Sub
                If sender.Text.StartsWith("?") Then
                    sender.text = sender.text.substring(1)
                End If
                CitiesSQL = CitiesSQL & " where StateCode = '" & GetNextControl(sender, True).Text & "' and Name like '" & sender.text & "%' Order by Name"
                PopulateDataset2(daCity, dsCity, CitiesSQL)
                dvCities1.Table = dsCity.Tables("City")
                If dvCities1.Table.Rows.Count > 0 Then
                    If dvCities1.Table.Rows.Count > 1 Then
                        Dim Srch As New SearchListings
                        Srch.dsList = dsCity

                        Srch.UltraGrid1.Text = "Cities beginning with '" & sender.text & "' in '" & GetNextControl(sender, True).Text & "'"
                        Srch.Text = "Cities"
                        Srch.ShowDialog()
                        Try
                            Dim cnt As Integer
                            cnt = Srch.UltraGrid1.Rows.Count
                        Catch Err As System.Exception
                            'MsgBox("Zipcode Leave: " & Err.Message)
                            Srch = Nothing
                            sender.Focus()
                            HasErr = True
                            Exit Try
                        Catch Err2 As System.NullReferenceException
                            ' CANCEL PRESSED
                            Srch = Nothing
                            sender.Focus()
                            HasErr = True
                            Exit Try
                        Catch osqlexception As SqlException
                            MsgBox("SQL_Error: " & osqlexception.Message)
                            Srch = Nothing
                            sender.Focus()
                            Exit Try
                        Finally
                            If HasErr = False Then
                                ugRow = Srch.UltraGrid1.ActiveRow
                                gCity.Text = ugRow.Cells("City").Text
                                gZipcode.Text = ugRow.Cells("Zipcode").Text
                                gPhone.Focus()
                                gState.Value = ugRow.Cells("State").Text
                                'gState.SelectedValue = ugRow.Cells("State").Text
                                Srch = Nothing
                            End If
                        End Try
                    Else ' Just one record found
                        gCity.Text = dvCities1(0).Item("City") 'ugRow.Cells("City").Text
                        gZipcode.Text = dvCities1(0).Item("Zipcode") ' ugRow.Cells("Zipcode").Text
                        gPhone.Focus()
                        gState.Value = dvCities1(0).Item("State")
                        'gState.SelectedValue = dvCities1(0).Item("State") ' ugRow.Cells("State").Text

                    End If
                Else
                    MsgBox("No matching city found!", MsgBoxStyle.OKOnly, MeText)
                End If
            End If
            sender.Modified = False
        End If
        daCity.Dispose()
        daCity = Nothing
        dsCity.Dispose()
        dsCity = Nothing
        Exit Sub
ErrTrap:
        MsgBox("ZipCode Error: " & Err.Description)
        daCity.Dispose()
        daCity = Nothing
        dsCity.Dispose()
        dsCity = Nothing
    End Sub
    Private Sub City_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles City.KeyUp
        TypeAhead(sender, e, HRTblPath & "City", "Name", "AND StateCode = '" & GetNextControl(sender, True).Text & "'")
        'sender.modified = True
    End Sub

    Private Sub ZipCode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ZipCode.KeyPress, utMileage.KeyPress, utModelYear.KeyPress
        If IsNumeric(e.KeyChar) = False And Asc(e.KeyChar) <> Keys.Back Then
            e.Handled() = True
        End If
    End Sub

    Private Sub txbEmplGroupID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles txbEmplGroupID.Leave
        Dim row As DataRow
        If sender.text.trim = "" Then
            txbEmplGroupID.Text = ""
            sender.text = ""
        ElseIf SearchOnLeave(sender, txbEmplGroupID, HRTblPath & "EmployeeGroups", , , "*", "Employee Groups") Then
        End If
    End Sub

    Private Sub txbEmplGroupID_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txbEmplGroupID.KeyUp
        TypeAhead(sender, e, HRTblPath & "EmployeeGroups", "Name", "")
    End Sub

    Private Sub UltraGrid2_AfterRowActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraGrid2.AfterRowActivate, UltraGrid1.AfterRowActivate, UltraGrid3.AfterRowActivate
        Dim TabPg As TabPage
        Dim PageName As String = ""

        Select Case sender.name
            Case "UltraGrid1"
                PageName = "tpDeductions"
            Case "UltraGrid2"
                PageName = "tpPayInfo"
            Case "UltraGrid3"
                PageName = "tpVehicles"
            Case Else
                Exit Sub
        End Select
        For Each TabPg In TabCtrl1.TabPages
            If TabPg.Name = PageName Then
                Exit For
            End If
        Next
        FormLoadFromGrid(TabPg, sender)
    End Sub

    Private Sub UltraGrid2_AfterRowUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles UltraGrid2.AfterRowUpdate, UltraGrid1.AfterRowUpdate, UltraGrid3.AfterRowUpdate
        'If Not m_row Is Nothing Then
        Dim TabPg As TabPage
        Dim PageName As String = ""

        Select Case sender.name
            Case "UltraGrid1"
                PageName = "tpDeductions"
            Case "UltraGrid2"
                PageName = "tpPayInfo"
            Case "UltraGrid3"
                PageName = "tpVehicles"
            Case Else
                Exit Sub
        End Select

        For Each TabPg In TabCtrl1.TabPages
            If TabPg.Name = PageName Then
                Exit For
            End If
        Next
        FormLoadFromGrid(TabPg, sender)
        '        FormLoadFromGrid(TabCtrl1.TabPages(2), UltraGrid2)
        'End If
    End Sub

    Private Sub UltraGrid1_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraGrid1.EnabledChanged, UltraGrid2.EnabledChanged, UltraGrid3.EnabledChanged
        If sender.enabled = True Then
            Dim TabPg As TabPage
            Dim PageName As String = ""

            Select Case sender.name
                Case "UltraGrid1"
                    PageName = "tpDeductions"
                Case "UltraGrid2"
                    PageName = "tpPayInfo"
                Case "UltraGrid3"
                    PageName = "tpVehicles"
                Case Else
                    Exit Sub
            End Select
            For Each TabPg In TabCtrl1.TabPages
                If TabPg.Name = PageName Then
                    Exit For
                End If
            Next
            FormLoadFromGrid(TabPg, sender)
        End If
    End Sub

    Private Sub UltraGrid2_EnabledChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraGrid2.EnabledChanged
        If sender.enabled And UltraGrid1.Rows.Count > 0 Then
            'FormLoadFromGrid(Me, sender)
        End If
    End Sub

    Private Sub EmplID_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles EmplID.TextChanged
        If sender.text = "" Then
            UltraGrid1.DataSource = Nothing
            UltraGrid2.DataSource = Nothing
            UltraGrid3.DataSource = Nothing
            ClearForm(Me)
            'ucboDeduction.Text = ""
            txtPayEmplID.Text = ""
            txtDedEmplID.Text = ""
            txtVehEmplID.Text = ""
            ucboDept.Text = ""
            ucboClass.Text = ""
            ucboWCCode.Text = ""
        End If
    End Sub

    Private Sub utOfficeid_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles utOfficeID.TextChanged
        Dim row As DataRow

        If GlobalVars.ReturnRowByID(utOfficeID.Text.Trim, row, HRTblPath & "ServiceOffices") Then
            utOfficeName.Text = row("Name")
        End If
        row = Nothing
    End Sub

    Private Sub utMileageRate_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utMileageRate.Leave, utPayRate.Leave, utDeductionAmount.Leave
        sender.text = Format(Val(sender.text), "0.00")
    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim TabPg As TabPage
        Dim TabName As String
        Dim ugrow As Infragistics.Win.UltraWinGrid.UltraGridRow

        'If GroupBox5.Enabled = True Then
        '    TabName = "tpPayInfo"
        'ElseIf GroupBox6.Enabled = True Then
        '    TabName = "tpDeductions"
        'Else
        '    MsgBox("DELETE button is only usable for 'Pay Rates' and 'Deductions' screens.")
        '    Exit Sub
        'End If

        'For Each TabPg In TabCtrl1.TabPages
        '    If TabPg.Name = TabName Then Exit For
        'Next

        If btnNew.Text.ToUpper = "&CANCEL" Or btnEdit.Text.ToUpper = "&CANCEL" Then
            Exit Sub
        End If

        Select Case TabCtrl1.SelectedTab.Name
            Case "tpPayInfo"
                If UltraGrid2.ActiveRow Is Nothing Then
                    MsgBox("No Rows Selected.")
                    Exit Sub
                End If
                If UltraGrid2.ActiveRow.ListObject Is Nothing Then
                    MsgBox("No Rows Selected.")
                    Exit Sub
                End If
                ugrow = UltraGrid2.ActiveRow
                If MsgBox("Are you sure to DELETE Department Number '" & ugrow.Cells("DeptNo").Value & "' record for this employee?", MsgBoxStyle.YesNo, "Delete Pay Rate Record") = MsgBoxResult.Yes Then
                    If ExecuteQuery("Delete from " & HRTblPath & "EmployeePayRates where EmployeeID = " & EmplID.Text.Trim & " and DeptNo = '" & ugrow.Cells("DeptNo").Value & "'") = False Then
                        MsgBox("Error Deleting the record.")
                        Exit Sub
                    End If
                    LoadPayInfo()
                End If
            Case "tpVehicles"
                If UltraGrid3.ActiveRow Is Nothing Then
                    MsgBox("No Rows Selected.")
                    Exit Sub
                End If
                If UltraGrid3.ActiveRow.ListObject Is Nothing Then
                    MsgBox("No Rows Selected.")
                    Exit Sub
                End If
                ugrow = UltraGrid3.ActiveRow
                If MsgBox("Are you sure to DELETE Vehicle '" & ugrow.Cells("Vehicles").Value & "' record for this employee?", MsgBoxStyle.YesNo, "Delete Vehicle Record") = MsgBoxResult.Yes Then
                    Dim sqlDel = "Update " & HRTblPath & "VEHICLES Set Void = 'T' AND EndDate = '" & udtEndDate.Text.Trim & "' where EmployeeID = " & EmplID.Text.Trim & " and RowID = '" & ugrow.Cells("RowID").Value & "'"
                    If TRCTblPath <> "" Then
                        If ExecuteQuery(sqlDel) = False Then
                            MsgBox("Error Deleting the Record.")
                            Exit Sub
                        End If
                    End If
                    LoadVehicles()
                End If
            Case "tpDeductions"
                If UltraGrid1.ActiveRow Is Nothing Then
                    MsgBox("No Rows Selected.")
                    Exit Sub
                End If
                If UltraGrid1.ActiveRow.ListObject Is Nothing Then
                    MsgBox("No Rows Selected.")
                    Exit Sub
                End If
                ugrow = UltraGrid1.ActiveRow
                If MsgBox("Are you sure to DELETE Deduction '" & ugrow.Cells("Deduction").Value & "' record for this employee?", MsgBoxStyle.YesNo, "Delete Pay Rate Record") = MsgBoxResult.Yes Then
                    If ExecuteQuery("Delete from " & HRTblPath & "EmployeeDeductions where EmployeeID = " & EmplID.Text.Trim & " and DeductionID = '" & ugrow.Cells("DeductionID").Value & "'") = False Then
                        MsgBox("Error Deleting the record.")
                        Exit Sub
                    End If
                    LoadDeductions()
                End If
            Case Else
                MsgBox("DELETE button is only usable for 'Pay Rates' and 'Deductions' screens.")
                Exit Sub
        End Select


    End Sub

    'Private Sub uteAutoInsName__TabIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles uteAutoInsName.TabStopChanged
    '    'Private Sub uteAutoInsName__KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles uteAutoInsName.KeyUp
    '    'Dim daAutoIns As New SqlDataAdapter
    '    'Dim dsAutoIns As New DataSet
    '    'Dim AutoInsSQL As String = "Select AutoInsNAme, AutoInsPolNum, AutoInsExpDate, AutoInsPhone " & HRTblPath & "EmployeeInfo"
    '    'AutoInsSQL = AutoInsSQL & " where EmployeeID = '" & txtVehEmplID.Text & "'"
    '    'If MsgBox("Do you want to use the default Employee's Auto Insurance Information?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
    '    ''e.Cancel = True
    '    'PopulateDataset2(daAutoIns, dsAutoIns, AutoInsSQL)
    '    'Exit Sub
    '    'End If
    '    Dim SelectSQL, UnionSQL As String
    '    Dim dtAdapter As New SqlDataAdapter
    '    Dim dtSet As New DataSet
    '    Dim dtView As New DataView
    '    Dim HasErr As Boolean
    '    Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
    '    Dim Title, frmTitle As String

    '    'SelectSQL = "Select * FROM " & AppTblPath & "Customer order by Name"
    '    SelectSQL = "Select DISTINCT AutoInsPolNum, AutoInsNAme, AutoInsExpDate, AutoInsPhone FROM " & HRTblPath & "EmployeeInfo"
    '    UnionSQL = "UNION Select DISTINCT AutoInsPolNum, AutoInsNAme, AutoInsExpDate, AutoInsPhone FROM " & HRTblPath & "Vehicles"

    '    SelectSQL = SelectSQL & " where EmployeeID = '" & txtVehEmplID.Text & "'" & UnionSQL & " where EmployeeID = '" & txtVehEmplID.Text & "'"
    '    'SelectSQL = SelectSQL & UnionSQL & " where EmployeeID = '" & txtVehEmplID.Text & "'"

    '    frmTitle = "Do you wish to use stored Employee's Auto Insurance Information?"
    '    Title = "Employee's Auto Insurance"
    '    PopulateDataset2(dtAdapter, dtSet, SelectSQL)
    '    dtView.Table = dtSet.Tables(0)
    '    If dtView.Table.Rows.Count > 0 Then
    '        Dim Srch As New SearchListings
    '        Srch.dsList = dtSet
    '        Srch.btnAddNew.Visible = True

    '        Srch.UltraGrid1.Text = frmTitle
    '        Srch.Text = Title
    '        Srch.ShowDialog()
    '        If Srch.DialogResult <> DialogResult.OK Then Exit Sub
    '        Try
    '            Dim cnt As Integer
    '            cnt = Srch.UltraGrid1.Rows.Count
    '        Catch Err As System.Exception
    '            'MsgBox("Zipcode Leave: " & Err.Message)
    '            Srch = Nothing
    '            sender.Focus()
    '            HasErr = True
    '            Exit Try
    '        Catch Err2 As System.NullReferenceException
    '            ' CANCEL PRESSED
    '            Srch = Nothing
    '            sender.Focus()
    '            HasErr = True
    '            Exit Try
    '        Catch osqlexception As SqlException
    '            MsgBox("SQL_Error: " & osqlexception.Message)
    '            Srch = Nothing
    '            sender.Focus()
    '            Exit Try
    '        Finally
    '            If HasErr = False Then
    '                ugRow = Srch.UltraGrid1.ActiveRow
    '                uteAutoInsName.Text = ugRow.Cells("AutoInsName").Text
    '                uteAutoInsPolNum.Text = ugRow.Cells("AutoInsPolNum").Text
    '                uteAutoInsPhone.Text = ugRow.Cells("AutoInsPhone").Text
    '                udtExpDate.Text = ugRow.Cells("AutoInsExpDate").Text
    '                'MasterCustID.Text = ugRow.Cells("ID").Text
    '                'MasterCustName.Text = ugRow.Cells("Name").Text
    '                Srch = Nothing
    '            End If
    '        End Try
    '    End If


    'End Sub

    'Private Sub uteAutoInsName__TabIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles uteAutoInsName.TabStopChanged
    '    If MsgBox("Do you want to use the default Employee's Auto Insurance Information?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
    '        'e.Cancel = True
    '        Exit Sub
    '    End If
    'End Sub


    Private Sub btnAutoIns_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAutoIns.Click
        Dim SelectSQL, UnionSQL As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim Title, frmTitle As String

        'SelectSQL = "Select * FROM " & AppTblPath & "Customer order by Name"
        SelectSQL = "Select DISTINCT AutoInsPolNum, AutoInsNAme, AutoInsExpDate, AutoInsPhone FROM " & HRTblPath & "EmployeeInfo"
        UnionSQL = "UNION Select DISTINCT AutoInsPolNum, AutoInsNAme, AutoInsExpDate, AutoInsPhone FROM " & HRTblPath & "Vehicles"

        SelectSQL = SelectSQL & " where EmployeeID = '" & txtVehEmplID.Text & "'" & UnionSQL & " where EmployeeID = '" & txtVehEmplID.Text & "'"
        'SelectSQL = SelectSQL & UnionSQL & " where EmployeeID = '" & txtVehEmplID.Text & "'"

        frmTitle = "Do you wish to use stored Employee's Auto Insurance Information?"
        Title = "Employee's Auto Insurance"
        PopulateDataset2(dtAdapter, dtSet, SelectSQL)
        dtView.Table = dtSet.Tables(0)
        If dtView.Table.Rows.Count > 0 Then
            Dim Srch As New SearchListings
            Srch.dsList = dtSet
            Srch.btnAddNew.Visible = True

            Srch.UltraGrid1.Text = frmTitle
            Srch.Text = Title
            Srch.ShowDialog()
            If Srch.DialogResult = DialogResult.None Then
                uteAutoInsName.Focus()
                Exit Sub
            End If
            If Srch.DialogResult <> DialogResult.OK Then Exit Sub
            Try
                Dim cnt As Integer
                cnt = Srch.UltraGrid1.Rows.Count
            Catch Err As System.Exception
                'MsgBox("Zipcode Leave: " & Err.Message)
                Srch = Nothing
                sender.Focus()
                HasErr = True
                Exit Try
            Catch Err2 As System.NullReferenceException
                ' CANCEL PRESSED
                Srch = Nothing
                sender.Focus()
                HasErr = True
                Exit Try
            Catch osqlexception As SqlException
                MsgBox("SQL_Error: " & osqlexception.Message)
                Srch = Nothing
                sender.Focus()
                Exit Try
            Finally
                If Srch.btnAddNew.Enabled = True Then
                    uteAutoInsName.TabStop = True
                End If
                If HasErr = False Then
                    ugRow = Srch.UltraGrid1.ActiveRow
                    uteAutoInsName.Text = ugRow.Cells("AutoInsName").Text
                    uteAutoInsPolNum.Text = ugRow.Cells("AutoInsPolNum").Text
                    uteAutoInsPhone.Text = ugRow.Cells("AutoInsPhone").Text
                    udtExpDate.Text = ugRow.Cells("AutoInsExpDate").Text
                    'MasterCustID.Text = ugRow.Cells("ID").Text
                    'MasterCustName.Text = ugRow.Cells("Name").Text
                    Srch = Nothing
                End If
            End Try
        End If
    End Sub

    Protected Sub bUpload_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bUpload.Click
        UploadImage()
    End Sub

    'Private Sub bBrowse_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bBrowse.Click
    '    OpenFileDialog.Title = "Get Employee's Profile Photo"
    '    OpenFileDialog.ShowDialog()

    'End Sub

    Private Sub OpenFileDialog_FileOk(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog.FileOk
        sPhotoFileName = OpenFileDialog.FileName
        'employeeImageFullName = OpenFileDialog.FileName
    End Sub

    Private Sub btnRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRemove.Click
        If MessageBox.Show("Photo of current Employee is going to be deleted from database!", "Employee's Photo Removal!", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = DialogResult.OK Then
            'Remove the image from DataBase




            'Check if EmployeeBadge record for current employee exists already. Need to UPLOAD/UPDATE just photo
            Dim dtDataAdapter As New SqlDataAdapter
            Dim dtDataView As New DataView
            Dim dtDataSet As New DataSet
            Dim SelectQuery As String = "Select * From " & HRTblPath & "EmployeeBadgeInfo Where EmployeeID = " & EmplID.Text.Trim & ""
            Dim UpdatePhotoQuery As String
            PopulateDataset2(dtDataAdapter, dtDataSet, SelectQuery)
            dtDataView.Table = dtDataSet.Tables(0)
            If dtDataView.Table.Rows.Count > 0 Then
                If dtDataView.Table.Rows(0).Item("Hair") = "Unknown" And dtDataView.Table.Rows(0).Item("Eyes") = "Unknown" And dtDataView.Table.Rows(0).Item("EmployeeHeight") = "Unknown" And dtDataView.Table.Rows(0).Item("EmployeeWeight") = "" Then
                    UpdatePhotoQuery = "DELETE From " & HRTblPath & "EmployeeBadgeInfo Where EmployeeID = " & EmplID.Text.Trim & ""
                Else
                    UpdatePhotoQuery = "Update " & HRTblPath & "EmployeeBadgeInfo set Photo = '" & "" & "' WHERE EmployeeID = " & EmplID.Text.Trim & ""
                End If
            Else

            End If
            'Dim DeleteQuery As String = "DELETE From " & HRTblPath & "EmployeeBadgeInfo Where EmployeeID = " & EmplID.Text.Trim & ""
            'UpdatePhotoQuery = "Update " & HRTblPath & "EmployeeBadgeInfo set Photo = '" & "" & "' WHERE EmployeeID = " & EmplID.Text.Trim & ""

            ExecuteQuery(UpdatePhotoQuery)

            'Remove the image from Form
            PictureBox.Image = pbDefaultPhoto.Image
            bUpload.Text = "Upload"
        End If
    End Sub

    'Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
    'Load Image from the database to the form
    Private Sub LoadImage()
        Dim SelectQuery As String = "Select EmployeeID, Photo, Height, Width, Length, Type FROM " & HRTblPath & "EmployeeBadgeInfo Where EmployeeID = " & EmplID.Text.Trim & ""

        Dim oDbImage As New DBImage(DBCommandType.DoSelect, "", SelectQuery, strConnection)
        oDbImage.Load(SelectQuery)

        'If oDbImage.FileName = "" Then
        'MessageBox.Show("There is no photo for this employee in database!", "Employee's Photo Status!", MessageBoxButtons.OK, MessageBoxIcon.Information)
        'Else
        PictureBox.Image = Image.FromFile(oDbImage.FileName)
        'employeeImageFullName = oDbImage.FileName
        'End If

    End Sub
    'Upload New Image to the database
    Private Sub UploadImage()
        Dim dtAdapter As SqlDataAdapter
        Dim dtSet As DataSet
        Dim dtView As DataView

        'PictureBox.Image = Image.FromFile(sPhotoFileName)
        'Dim SelectQuery As String
        Dim sQuery As String

        'SelectQuery = "Select * From " & HRTblPath & "EmployeeBadgeInfo Where EmployeeID = " & EmplID.Text.Trim & ""
        'PopulateDataset2(dtAdapter, dtSet, SelectQuery)
        'dtView.Table = dtSet.Tables(0)

        'If dtView.Table.Rows.Count <= 0 Then
        If imageStatus = True Then 'Replace Employee's Photo
            If MsgBox("This Employee has the photo in Data Base already! Do you wish to replace the photo?", MsgBoxStyle.OKCancel, "Photo Replacement Confirmation") = MsgBoxResult.OK Then
                sPhotoFileName = ""
                OpenFileDialog.Title = "Get Employee's Profile Photo"
                OpenFileDialog.ShowDialog()
                If (sPhotoFileName <> "") Then

                    'sQuery = "Update " & HRTblPath & "EmployeeBadgeInfo Set Photo = @image Where EmployeeID = " & EmplID.Text.Trim & ""
                    Dim oDbImage As New DBImage(DBCommandType.DoSelect, sPhotoFileName, sQuery, strConnection)
                    'oDbImage.SaveWithParameter()
                    oDbImage.TableName = HRTblPath & "EmployeeBadgeInfo"
                    oDbImage.KeyColumnName = "EmployeeID"
                    oDBImage.KeyColumn = EmplID.Text

                    If oDbImage.Update() = False Then
                        MessageBox.Show("Updating of employee's photo has failed! Not proper formatting!", "Employee's Photo Status!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Else
                        PictureBox.Image = Image.FromFile(sPhotoFileName) 'Image.FromFile(oDbImage.FileName)
                    End If
                    bUpload.Text = "Replace"
                Else
                    MessageBox.Show("To upload the photo please select it first in File Dialog Box!", "Employee's Photo Status!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End If
        Else 'Upload a New Photo "imageStatus = False"
            sPhotoFileName = ""
            OpenFileDialog.Title = "Get Employee's Profile Photo"
            OpenFileDialog.ShowDialog()
            If (sPhotoFileName <> "") Then




                'Check if EmployeeBadge record for current employee exists already. Need to UPLOAD/UPDATE just photo
                Dim dtAdapterUpdate As New SqlDataAdapter
                Dim dtViewUpdate As New DataView
                Dim dtSetUpdate As New DataSet
                Dim SelectQueryUpdate As String = "Select Photo From " & HRTblPath & "EmployeeBadgeInfo Where EmployeeID = " & EmplID.Text.Trim & ""
                PopulateDataset2(dtAdapterUpdate, dtSetUpdate, SelectQueryUpdate)
                dtViewUpdate.Table = dtSetUpdate.Tables(0)
                If dtViewUpdate.Table.Rows.Count > 0 Then
                    ''    'If dtView.Table.Rows(0).Item("Photo").Length <= 1 Then
                    ''    '    'If (dtView.Table.Rows.Count <= 0) Then
                    ''    '    'There is no photo in database for current user - UPLOAD the new photo
                    ''    '    imageStatus = False
                    ''    'Else
                    ''    '    'These is a photo in database for current user - LOAD a new photo
                    ''    '    imageStatus = True
                    ''    'End If
                    ''    bUpload.Text = "Replace"
                    ''    LoadImage()

                    PictureBox.Image = Image.FromFile(sPhotoFileName) 'Image.FromFile(oDbImage.FileName)
                    'PictureBox.Image.Save(sPhotoFileName)
                    'sQuery = "Insert Into " & HRTblPath & "EmployeeBadgeInfo (EmployeeID, Photo, CopiesPrinted, Height, Width, Length, Type) Values (" & EmplID.Text & ", @image, 0, 90, 90, @length)"
                    Dim oDbImage As New DBImage(DBCommandType.DoUpdate, sPhotoFileName, sQuery, strConnection)
                    'oDbImage.SaveWithParameter()
                    oDBImage.TableName = HRTblPath & "EmployeeBadgeInfo"
                    oDBImage.KeyColumnName = "EmployeeID"
                    oDBImage.KeyColumn = EmplID.Text
                    If oDBImage.Update() = False Then
                        MessageBox.Show("Inserting of employee's photo has failed! Not proper formatting!", "Employee's Photo Status!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        bUpload.Text = "Upload"
                    Else
                        bUpload.Text = "Replace"
                    End If


                Else
                    PictureBox.Image = Image.FromFile(sPhotoFileName) 'Image.FromFile(oDbImage.FileName)
                    'sQuery = "Insert Into " & HRTblPath & "EmployeeBadgeInfo (EmployeeID, Photo, CopiesPrinted, Height, Width, Length, Type) Values (" & EmplID.Text & ", @image, 0, 90, 90, @length)"
                    Dim oDbImage As New DBImage(DBCommandType.DoInsert, sPhotoFileName, sQuery, strConnection)
                    'oDbImage.SaveWithParameter()
                    oDBImage.TableName = HRTblPath & "EmployeeBadgeInfo"
                    oDBImage.KeyColumnName = "EmployeeID"
                    oDBImage.KeyColumn = EmplID.Text
                    If oDBImage.Save() = False Then
                        MessageBox.Show("Inserting of employee's photo has failed! Not proper formatting!", "Employee's Photo Status!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        bUpload.Text = "Upload"
                    Else
                        bUpload.Text = "Replace"
                    End If


                    ''    'imageStatus = False
                    'bUpload.Text = "Upload"
                    'PictureBox.Image = pbDefaultPhoto.Image
                End If







                'PictureBox.Image = Image.FromFile(sPhotoFileName) 'Image.FromFile(oDbImage.FileName)
                ''sQuery = "Insert Into " & HRTblPath & "EmployeeBadgeInfo (EmployeeID, Photo, CopiesPrinted, Height, Width, Length, Type) Values (" & EmplID.Text & ", @image, 0, 90, 90, @length)"
                'Dim oDbImage As New DBImage(DBCommandType.DoInsert, sPhotoFileName, sQuery, strConnection)
                ''oDbImage.SaveWithParameter()
                'oDBImage.TableName = HRTblPath & "EmployeeBadgeInfo"
                'oDBImage.KeyColumnName = "EmployeeID"
                'oDBImage.KeyColumn = EmplID.Text
                'If oDBImage.Save() = False Then
                '    MessageBox.Show("Inserting of employee's photo has failed! Not proper formatting!", "Employee's Photo Status!", MessageBoxButtons.OK, MessageBoxIcon.Error)
                '    bUpload.Text = "Upload"
                'Else
                '    bUpload.Text = "Replace"
                'End If

            Else
                MessageBox.Show("To upload the photo please select it first in File Dialog Box!", "Employee's Photo Status!", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
            End If
        End If
    End Sub
    'Function to check if the photo for current emploee exists in database, if there is no photo - load a default
    Private Sub ImageUploadORLoad()
        Dim dtAdapter As New SqlDataAdapter
        Dim dtView As New DataView
        Dim dtSet As New DataSet

        Dim SelectQuery As String = "Select Photo From " & HRTblPath & "EmployeeBadgeInfo Where EmployeeID = " & EmplID.Text.Trim & ""
        PopulateDataset2(dtAdapter, dtSet, SelectQuery)
        dtView.Table = dtSet.Tables(0)

        If dtView.Table.Rows.Count > 0 Then
            If dtView.Table.Rows(0).Item("Photo").Length <= 1 Then
                'If (dtView.Table.Rows.Count <= 0) Then
                'There is no photo in database for current user - UPLOAD the new photo
                imageStatus = False
            Else
                'These is a photo in database for current user - LOAD a new photo
                imageStatus = True
            End If
        Else
            imageStatus = False
        End If
    End Sub

    Private Sub btnPrintBadge_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrintBadge.Click

        'Badges can only be printed for active employees
        Dim bPrintBadge As Boolean
        If String.Compare(CStr(cboStatus.SelectedValue), "A") = 0 Then bPrintBadge = True Else bPrintBadge = False

        If bPrintBadge Then

            Dim dtAdapter As SqlDataAdapter
            Dim i As Integer
            Dim EmplCond, CompCond, OfficeCond, DedJoinCond, SummCol, SQLSelect As String

            'SQLSelect = "Select eb.Company, eb.OfficeID, so.Name as Office, eb.ID As EmployeeID " & _
            '    " , RTrim(eb.FirstName) + (CASE WHEN eb.MiddleName = '' Then ' ' ELSE ' ' + RTrim(eb.MiddleName) + ' ' END) + RTrim(eb.LastName) As FullName " & _
            '    " , eb.Status, eb.StatusDate, eb.CreateDate, eb.HireDate, ei.DOB, ei.DLN, ebi.Photo, a.ID as AddressID, ebi.Hair, ebi.Eyes, ebi.EmployeeHeight, ebi.EmployeeWeight " & _
            '    " FROM " & HRTblPath & "EmployeesBase eb " & _
            '    " Left Outer Join " & HRTblPath & "EmployeeInfo ei On eb.ID = ei.EmployeeID " & _
            '    " Left Outer Join " & HRTblPath & "ServiceOffices so On eb.OfficeID = so.ID " & _
            '    " Left Outer Join " & HRTblPath & "EmployeeBadgeInfo ebi On eb.ID = ebi.EmployeeID " & _
            '    " Join " & AppTblPath & "ADDRESS a On a.CustomerID = 10000 and CAST(a.LocationID as INT) = so.ID AND ISNUMERIC(a.LocationID) = 1 " & _
            '    " WHERE @EMPLID"

            SQLSelect = "Select eb.Company, eb.OfficeID, so.Name as Office, eb.ID As EmployeeID " & _
               " , RTrim(eb.FirstName) + (CASE WHEN eb.MiddleName = '' Then ' ' ELSE ' ' + RTrim(eb.MiddleName) + ' ' END) + RTrim(eb.LastName) As FullName " & _
               " , eb.Status, eb.StatusDate, eb.CreateDate, eb.HireDate, ei.DOB, ei.DLN, ebi.Photo, a.ID as AddressID, ebi.Hair, ebi.Eyes, ebi.EmployeeHeight, ebi.EmployeeWeight " & _
               " FROM " & HRTblPath & "EmployeesBase eb " & _
               " Left Outer Join " & HRTblPath & "EmployeeInfo ei On eb.ID = ei.EmployeeID " & _
               " Left Outer Join " & HRTblPath & "ServiceOffices so On eb.OfficeID = so.ID " & _
               " Left Outer Join " & HRTblPath & "EmployeeBadgeInfo ebi On eb.ID = ebi.EmployeeID " & _
               " Left Outer Join " & AppTblPath & "ADDRESS a ON a.LocationID=CAST(so.ID As Char) " & _
               " WHERE @EMPLID"

            If EmplID.Text.Trim = "" Then
                MessageBox.Show("Please select the Employee to print the badge!", "Print Employee's Badge Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                Exit Sub
            End If
            EmplCond = " eb.ID = '" & EmplID.Text.Trim & "'"


            SQLSelect = SQLSelect.Replace("@EMPLID", EmplCond)

            PopulateDataset2(dtAdapter, dtSet, SQLSelect)

            For i = 0 To dtSet.Tables(0).Columns.Count - 1
                dtSet.Tables(0).Columns(i).ReadOnly = True
            Next

            Dim x As New EmployeeBadgePreview
            If String.Compare(LoginInfo.CompanyName, "Worldwide Couriers") = False Then
                x.ReportFormat = BadgeFormat.TTI
            Else
                Dim sCompany As String = ucboCompany.Value
                Select Case sCompany
                    Case "CFC"
                        x.ReportFormat = BadgeFormat.CFC
                    Case Else
                        x.ReportFormat = BadgeFormat.TPC
                End Select
            End If

            x.SqlCommand = SQLSelect
            x.Show()

        Else

            MessageBox.Show("You can only print badges for ACTIVE employees or representatives")

        End If

    End Sub

    'Private Sub btnMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    ''Show()
    '    'Dim x As New CustomMessageBox
    '    'x.BodyText = "Body Text"
    '    'x.btnFirstText = "First"
    '    'x.btnSecondText = "Second"
    '    'x.btnThirdText = "Third"
    '    'x.Height = 600
    '    'x.Width = 600
    '    'x.BodyColor = Color.Purple
    '    'x.BodyFont = New Font("Times New Roman", 30, FontStyle.Bold)
    '    'x.Picture = Image.FromFile("QuestionMark.jpg")
    '    'x.HeaderText = "Body Text"
    '    'x.HeaderColor = Color.Purple
    '    'x.HeaderFont = New Font("Times New Roman", 18, FontStyle.Bold)
    '    'x.FooterText = "Body Text"
    '    'x.FooterColor = Color.Purple
    '    'x.FooterFont = New Font("Times New Roman", 18, FontStyle.Bold)
    '    'x.FormName = "Custom Message Box"
    '    'x.Show()


    '    Dim infoMessage As New CustomMessageBox
    '    'infoMessage.Picture = Image.FromFile("C :\Program Files\Common Files\TransTechSoftware\10391.jpg")

    '    'infoMessage.Picture = Image.FromFile(infoMessage.ExclamationImagePath)
    '    'Maximum values that user can overwright
    '    infoMessage.Height = 600
    '    infoMessage.Width = 1000
    '    infoMessage.BodyColor = Color.Red
    '    infoMessage.BodyFont = New Font("Times New Roman", 30, FontStyle.Bold)
    '    infoMessage.Picture = Image.FromFile("C :\Program Files\Common Files\TransTechSoftware\E.jpg")
    '    infoMessage.HeaderText = "User Header Text"
    '    infoMessage.HeaderColor = Color.Orange
    '    infoMessage.HeaderFont = New Font("Times New Roman", 18, FontStyle.Bold)
    '    infoMessage.FooterText = "User Footer Text"
    '    infoMessage.FooterColor = Color.Green
    '    infoMessage.FooterFont = New Font("Times New Roman", 18, FontStyle.Bold)

    '    Dim buttonPressed As DialogResult = infoMessage.Show("Function Body Text", "Function Form Name", MessageBoxButtons.YesNo, , MessageBoxDefaultButton.Button2)
    'End Sub

    Private Sub btnPrnRepId_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrnRepId.Click

        'Badges can only be printed for active employees
        Dim bPrintBadge As Boolean
        If String.Compare(CStr(cboStatus.SelectedValue), "A") = 0 Then bPrintBadge = True Else bPrintBadge = False

        If bPrintBadge Then

            Dim dtAdapter As SqlDataAdapter
            Dim i As Integer
            Dim EmplCond, CompCond, OfficeCond, DedJoinCond, SummCol, SQLSelect As String

            Dim x As New EmployeeBadgePreview
            Dim y As New RepresentWhichCompany
            y.ShowDialog()

            If Not y.FormatSelected = BadgeFormat.NONE Then

                SQLSelect = "Select eb.Company, eb.OfficeID, so.Name as Office, eb.ID As EmployeeID " & _
                   " , RTrim(eb.FirstName) + (CASE WHEN eb.MiddleName = '' Then ' ' ELSE ' ' + RTrim(eb.MiddleName) + ' ' END) + RTrim(eb.LastName) As FullName " & _
                   " , eb.Status, eb.StatusDate, eb.CreateDate, eb.HireDate, ei.DOB, ei.DLN, ebi.Photo, a.ID as AddressID, ebi.Hair, ebi.Eyes, ebi.EmployeeHeight, ebi.EmployeeWeight " & _
                   " FROM " & HRTblPath & "EmployeesBase eb " & _
                   " Left Outer Join " & HRTblPath & "EmployeeInfo ei On eb.ID = ei.EmployeeID " & _
                   " Left Outer Join " & HRTblPath & "ServiceOffices so On eb.OfficeID = so.ID " & _
                   " Left Outer Join " & HRTblPath & "EmployeeBadgeInfo ebi On eb.ID = ebi.EmployeeID " & _
                   " Left Outer Join " & AppTblPath & "ADDRESS a ON a.LocationID=CAST(so.ID As Char) " & _
                   " WHERE @EMPLID"

                If EmplID.Text.Trim = "" Then
                    MessageBox.Show("Please select the Employee to print the badge!", "Print Employee's Badge Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                    Exit Sub
                End If
                EmplCond = " eb.ID = '" & EmplID.Text.Trim & "'"


                SQLSelect = SQLSelect.Replace("@EMPLID", EmplCond)

                PopulateDataset2(dtAdapter, dtSet, SQLSelect)

                For i = 0 To dtSet.Tables(0).Columns.Count - 1
                    dtSet.Tables(0).Columns(i).ReadOnly = True
                Next
                x.ReportFormat = y.FormatSelected
                x.SqlCommand = SQLSelect
                x.Show()

            End If

        Else

            MessageBox.Show("You can only print badges for ACTIVE employees or representatives")

        End If

    End Sub


    Private Sub btnResetOdometer_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnResetOdometer.Click

    End Sub

End Class
