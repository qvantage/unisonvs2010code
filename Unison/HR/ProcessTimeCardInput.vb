Imports System.Data
Imports System.Data.SqlClient

Public Class ProcessTimeCardInput
    Inherits System.Windows.Forms.Form
    Dim MeText As String
    Private _clsWorkDate As clsWorkDate

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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnProcess As System.Windows.Forms.Button
    Friend WithEvents ulblSelectPayroll As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ulblSelectDivision As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ucboDivision As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents utEmployeeID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnEmployee As System.Windows.Forms.Button
    Friend WithEvents uopEmployee As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents utEmployee As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraDate1 As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.utEmployee = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utEmployeeID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.btnEmployee = New System.Windows.Forms.Button
        Me.uopEmployee = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.ulblSelectPayroll = New Infragistics.Win.Misc.UltraLabel
        Me.ulblSelectDivision = New Infragistics.Win.Misc.UltraLabel
        Me.UltraDate1 = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.ucboDivision = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnProcess = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.utEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utEmployeeID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uopEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDate1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucboDivision, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.utEmployee)
        Me.GroupBox1.Controls.Add(Me.utEmployeeID)
        Me.GroupBox1.Controls.Add(Me.btnEmployee)
        Me.GroupBox1.Controls.Add(Me.uopEmployee)
        Me.GroupBox1.Controls.Add(Me.ulblSelectPayroll)
        Me.GroupBox1.Controls.Add(Me.ulblSelectDivision)
        Me.GroupBox1.Controls.Add(Me.UltraDate1)
        Me.GroupBox1.Controls.Add(Me.ucboDivision)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(456, 181)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'utEmployee
        '
        Appearance1.ForeColorDisabled = System.Drawing.Color.Black
        Me.utEmployee.Appearance = Appearance1
        Me.utEmployee.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utEmployee.Enabled = False
        Me.utEmployee.Location = New System.Drawing.Point(224, 136)
        Me.utEmployee.Name = "utEmployee"
        Me.utEmployee.Size = New System.Drawing.Size(200, 21)
        Me.utEmployee.TabIndex = 155
        Me.utEmployee.Tag = ".EmployeeID"
        '
        'utEmployeeID
        '
        Me.utEmployeeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utEmployeeID.Location = New System.Drawing.Point(224, 104)
        Me.utEmployeeID.Name = "utEmployeeID"
        Me.utEmployeeID.Size = New System.Drawing.Size(72, 21)
        Me.utEmployeeID.TabIndex = 153
        Me.utEmployeeID.Tag = ".EmployeeID"
        '
        'btnEmployee
        '
        Me.btnEmployee.Location = New System.Drawing.Point(312, 104)
        Me.btnEmployee.Name = "btnEmployee"
        Me.btnEmployee.Size = New System.Drawing.Size(64, 24)
        Me.btnEmployee.TabIndex = 154
        Me.btnEmployee.TabStop = False
        Me.btnEmployee.Text = "Se&lect"
        '
        'uopEmployee
        '
        Appearance2.TextTrimming = Infragistics.Win.TextTrimming.EllipsisWord
        Me.uopEmployee.Appearance = Appearance2
        Me.uopEmployee.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.uopEmployee.ItemAppearance = Appearance3
        ValueListItem1.DataValue = "All Employees"
        ValueListItem1.DisplayText = "All Employees"
        ValueListItem2.DataValue = "By Employee"
        ValueListItem2.DisplayText = "By Employee"
        Me.uopEmployee.Items.Add(ValueListItem1)
        Me.uopEmployee.Items.Add(ValueListItem2)
        Me.uopEmployee.ItemSpacingVertical = 9
        Me.uopEmployee.Location = New System.Drawing.Point(128, 80)
        Me.uopEmployee.Name = "uopEmployee"
        Me.uopEmployee.Size = New System.Drawing.Size(96, 48)
        Me.uopEmployee.TabIndex = 152
        '
        'ulblSelectPayroll
        '
        Appearance4.TextHAlign = Infragistics.Win.HAlign.Right
        Me.ulblSelectPayroll.Appearance = Appearance4
        Me.ulblSelectPayroll.Location = New System.Drawing.Point(9, 51)
        Me.ulblSelectPayroll.Name = "ulblSelectPayroll"
        Me.ulblSelectPayroll.Size = New System.Drawing.Size(112, 16)
        Me.ulblSelectPayroll.TabIndex = 4
        Me.ulblSelectPayroll.Text = "Payroll Ending Date:"
        '
        'ulblSelectDivision
        '
        Appearance5.TextHAlign = Infragistics.Win.HAlign.Right
        Me.ulblSelectDivision.Appearance = Appearance5
        Me.ulblSelectDivision.Location = New System.Drawing.Point(72, 20)
        Me.ulblSelectDivision.Name = "ulblSelectDivision"
        Me.ulblSelectDivision.Size = New System.Drawing.Size(48, 16)
        Me.ulblSelectDivision.TabIndex = 5
        Me.ulblSelectDivision.Text = "Division:"
        '
        'UltraDate1
        '
        Me.UltraDate1.DateTime = New Date(2006, 4, 6, 0, 0, 0, 0)
        Me.UltraDate1.Location = New System.Drawing.Point(128, 48)
        Me.UltraDate1.Name = "UltraDate1"
        Me.UltraDate1.Size = New System.Drawing.Size(88, 21)
        Me.UltraDate1.TabIndex = 8
        Me.UltraDate1.Value = New Date(2006, 4, 6, 0, 0, 0, 0)
        '
        'ucboDivision
        '
        Me.ucboDivision.DisplayMember = ""
        Me.ucboDivision.Location = New System.Drawing.Point(128, 16)
        Me.ucboDivision.Name = "ucboDivision"
        Me.ucboDivision.Size = New System.Drawing.Size(88, 21)
        Me.ucboDivision.TabIndex = 7
        Me.ucboDivision.Tag = ".Division...Divisions.Division.Division"
        Me.ucboDivision.ValueMember = ""
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnExit)
        Me.GroupBox3.Controls.Add(Me.btnProcess)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox3.Location = New System.Drawing.Point(0, 181)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(456, 40)
        Me.GroupBox3.TabIndex = 6
        Me.GroupBox3.TabStop = False
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnExit.Location = New System.Drawing.Point(389, 16)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(64, 21)
        Me.btnExit.TabIndex = 1
        Me.btnExit.Text = "E&xit"
        '
        'btnProcess
        '
        Me.btnProcess.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnProcess.Location = New System.Drawing.Point(3, 16)
        Me.btnProcess.Name = "btnProcess"
        Me.btnProcess.Size = New System.Drawing.Size(64, 21)
        Me.btnProcess.TabIndex = 0
        Me.btnProcess.Text = "P&rocess"
        '
        'ProcessTimeCardInput
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(456, 221)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Name = "ProcessTimeCardInput"
        Me.Text = "Process Time-Card Input"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.utEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utEmployeeID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uopEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDate1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucboDivision, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub InitWorkDate()

        If Not IsNothing(_clsWorkDate) Then _clsWorkDate = Nothing

        If ucboDivision.Text = "" Then
            MsgBox("Division is empty.")
            Exit Sub
        End If

        'Prepare to use the returned data values
        Dim strSQL As String
        Dim dtaCbo As New SqlDataAdapter
        Dim dtSet As DataSet
        Dim dtView As New DataView
        Dim dtRow As DataRow
        Dim PayrollEnding As Date
        Dim Freq, WeekEnding As String

        strSQL = "SELECT InitialPayPeriodEnding, PayPeriodFreq, WeekEndingDay FROM " & HRTblPath & "divisions WHERE division = '" & ucboDivision.Value & "'"

        PopulateDataset2(dtaCbo, dtSet, strSQL)

        dtView.Table = dtSet.Tables(0)
        dtRow = dtView.Table.Rows(0)
        PayrollEnding = CDate(dtRow("InitialPayPeriodEnding"))
        Freq = dtRow("PayPeriodFreq")
        WeekEnding = dtRow("WeekEndingDay")
        '_clsWorkDate = New clsWorkDate(CDate(dtRow("InitialPayPeriodEnding")), dtRow("PayPeriodFreq"), dtRow("WeekEndingDay"))
        _clsWorkDate = New clsWorkDate(PayrollEnding, Freq, WeekEnding)


        'clean up, no longer needed
        dtRow = Nothing

        dtView.Dispose()
        dtView = Nothing
        dtSet.Dispose()
        dtSet = Nothing
        dtaCbo.Dispose()
        dtaCbo = Nothing

    End Sub

    Private Sub ProcessTimeCardInput_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'AddHandler Me.Activated, AddressOf Form_Activated
        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = HRTblPath & Me.Tag
            End If
        End If
        Me.CenterToScreen()

        Me.KeyPreview = True
        AddHandler Me.KeyUp, AddressOf Form_KeyUp

        MeText = Me.Text

        Me.StartPosition = FormStartPosition.CenterScreen

        UltraDate1.Nullable = True
        UltraDate1.Value = Nothing ' DateAdd(DateInterval.Day, 0, Date.Today)
        UltraDate1.FormatString = "MM/dd/yyyy"
        UltraDate1.Enabled = False

        FillUCombo(ucboDivision, "", , , HRTblPath)

        'UltraDate1.Value = _clsWorkDate.PayrollEndDate(Date.Now)

        uopEmployee.CheckedIndex = 0


    End Sub

    Private Sub ucboDivision_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucboDivision.ValueChanged
        'If DivisionChanged = False Then Exit Sub
        'If _iValueChanged >= 2 Then _iValueChanged = 1

    End Sub

    Private Sub ucboDivision_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucboDivision.Leave
        If ucboDivision.Text = "" Then
            UltraDate1.Value = Nothing
            UltraDate1.Enabled = False
            Exit Sub
        End If
        UltraDate1.Enabled = True

        InitWorkDate()
        UltraDate1.Value = _clsWorkDate.PayrollEndDate(Date.Now)
        UltraDate1.Focus()

    End Sub

    Private Sub EmplID_Int_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles utEmployeeID.KeyPress
        If IsNumeric(e.KeyChar) = False And Asc(e.KeyChar) <> Keys.Back And e.KeyChar <> "-" Then
            e.Handled = True
        End If
    End Sub

    Private Sub utEmployeeID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utEmployeeID.Leave
        Dim row As DataRow
        Dim gAcct, gAcctID As Infragistics.Win.UltraWinEditors.UltraTextEditor

        gAcct = utEmployee
        gAcctID = utEmployeeID

        If sender.Modified = False Then Exit Sub

        If sender.text.trim = "" Then
            gAcct.Text = ""
            sender.text = ""
            'btnSave.Enabled = False
        Else
            ' This for Accounts With Numbers Only Name!!
            'If IsNumeric(sender.text) Then
            '    sender.text = "?" & sender.text
            '    sender.modified = True
            'End If
            If SearchOnLeave(sender, gAcctID, "" & HRTblPath & "EmployeesBase", "ID", "ID", "*", "Employees", "") Then
                If ReturnRowByID(gAcctID.Text, row, HRTblPath & "EmployeesBase", "", "ID") Then
                    gAcct.Text = row("FirstName") & " " & row("LastName")
                    row = Nothing
                Else
                    MsgBox("Employee Not Found.")
                    gAcctID.Text = ""
                    gAcct.Text = ""
                End If
            Else
                'MsgBox("Truck Not Found.")
                gAcctID.Text = ""
                gAcct.Text = ""
                sender.focus()
            End If
        End If
        sender.Modified = False

    End Sub

    Private Sub btnEmpl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmployee.Click


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
                    utEmployeeID.Text = ugRow.Cells("ID").Text
                    utEmployee.Text = ugRow.Cells("FirstName").Text & " " & ugRow.Cells("LastName").Text
                    Srch = Nothing
                    utEmployeeID.Modified = True
                    Dim ev As New System.EventArgs
                    '''''EmplID_Leave(EmplID, ev)
                End If
            End Try
        End If
    End Sub

    Private Sub utEmployeeID_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles utEmployeeID.ValueChanged
        If sender.text = "" Then
            utEmployee.Text = ""
        End If
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub uopEmployee_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uopEmployee.ValueChanged
        Select Case uopEmployee.CheckedIndex
            Case 0 ' All
                utEmployeeID.Visible = False
                utEmployee.Visible = False
                btnEmployee.Visible = False
            Case 1 'By Employee
                utEmployeeID.Text = ""
                utEmployee.Text = ""
                utEmployeeID.Visible = True
                utEmployee.Visible = True
                btnEmployee.Visible = True

        End Select
    End Sub

    Private Sub btnProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcess.Click
        Dim sqlProcessPay As String = "Update " & HRTblPath & "EmployeeActivityDetail Set Processed = 1 where PayrollEnding = @PAYDATE AND Division = @DIV @EMPLID; "
        Dim sqlInsertPayrollEnding As String = "Insert into " & HRTblPath & "ProcessedPayrollEndings(PayrollEnding, Processed, Company) values('" & UltraDate1.Text & "', '1', '" & ucboDivision.Value & "') ; "
        Dim sqlPayrollEndingTotals As String = _
            "Insert into " & HRTblPath & "EmployeeActivity(PayrollDate, EmployeeID, OfficeID, Office, DeptNo, RegHrs, OTHrs, DTHrs, MileageRate, PayRate, WCCode, ClassID, Class, HrsPay  ) " & _
            " Select ead.PayrollEnding, ead.EmployeeID, ead.OfficeID, ead.Office, ead.DeptNo, Sum(ead.RegHrs) as RegHrsTotal, Sum(ead.OTHrs) as OTHrsTotal, Sum(ead.DTHrs) as DTHrsTotal " & _
            " , max(ep.MileageRate) as MileageRate, max(ep.PayRate) as PayRate, max(ep.WCCode) as WCCode, max(ep.ClassiD) as ClassID, max(cl.Class) as Class " & _
            " , max(ep.PayRate) * ( Sum(ead.RegHrs)+ (1.5 * Sum(ead.OTHrs)) +  (2. * Sum(ead.DTHrs)) ) as HrsPay " & _
            " from " & HRTblPath & "EmployeeActivityDetail ead inner join " & HRTblPath & "EmployeePayRates ep on ead.EmployeeID = ep.EmployeeID and ead.DeptNo = ep.DeptNo " & _
            " left outer join " & HRTblPath & "Classes cl on ep.Classid = cl.Classid " & _
            " where ead.Processed = 0 AND ead.payrollending = @PAYEND and ead.Division = @DIV  @EMPLID " & _
            " group by ead.PayrollEnding, ead.EmployeeID, ead.DeptNo, ead.OfficeID, ead.Office; "
        Dim AIO As String
        Dim cmd As SqlCommand
        Dim trnSql As SqlTransaction
        Dim HasError As Boolean = True
        Dim x As MessageDialog

        If GetPassword("procok") = False Then Exit Sub
        '05/11/2005
        ' Zak Suggested to remove the timecard process and saving a time card will update totals in EMPLOYEEACTIVITY. Processing a Payroll 
        ' Flags the timecard rows and adds the date for all divisions in processedpayrolls.
        '05/09/2006
        ' When a Payroll is processed in Time-Cards, data will be summed up and added to the EMPLOYEEACTIVITY table.
        ' This means no more time-card additions for this payroll for the division. In totals, they will add deductions
        ' and incomes. An employee can not be singly unprocessed because the program will not permit any addition
        ' in a processed payroll. Unprocessing the TimeCards requires deletion of total hours from
        ' EMPLOYEEACTIVITY along with their associated deductions and incomes and mileages.
        ' Unprocessing the totals requires deletion of deductions and addtl. incomes for the payroll so before undoing 
        ' the process, print a report.
        'We intentionally keep this flaw open that input for an unprocessed payroll before a processed payroll is
        ' possible.
        ' If there is a problem in processed data of TimeCard Input, before adjusting the totals, the single 
        ' employee should be unprocessed. The timecard should be corrected and then process payroll for division 
        ' should recalculate the totals for that employee.

        ' Discarded on 05/09/2006
        'The general logic is that If AN EMPLOYEE is being PROCESSED, we can not input any TIME_CARD data for the 
        'processed Payroll Ending for
        'the DeptNo processed. So If there is any unprocessed data for a DeptNo, it means there 
        'is no totals in the EMPLOYEEACTIVITY table and data can safely be ADDED to the totals table.

        sqlPayrollEndingTotals = sqlPayrollEndingTotals.Replace("@PAYEND", "'" & UltraDate1.Text & "'")
        sqlPayrollEndingTotals = sqlPayrollEndingTotals.Replace("@DIV", "'" & ucboDivision.Value & "'")

        sqlProcessPay = sqlProcessPay.Replace("@PAYDATE", "'" & UltraDate1.Text & "'")
        sqlProcessPay = sqlProcessPay.Replace("@DIV", "'" & ucboDivision.Value & "'")
        If uopEmployee.CheckedIndex = 0 Then
            sqlPayrollEndingTotals = sqlPayrollEndingTotals.Replace("@EMPLID", "")
            sqlProcessPay = sqlProcessPay.Replace("@EMPLID", "")
            AIO = sqlPayrollEndingTotals & sqlProcessPay & sqlInsertPayrollEnding
        Else
            If utEmployeeID.Text.Trim = "" Then
                MsgBox("Employee is not specified.")
                Exit Sub
            End If
            sqlPayrollEndingTotals = sqlPayrollEndingTotals.Replace("@EMPLID", " AND ead.EmployeeID = '" & utEmployeeID.Text & "'")
            sqlProcessPay = sqlProcessPay.Replace("@EMPLID", " AND EmployeeID = '" & utEmployeeID.Text & "'")
            AIO = sqlPayrollEndingTotals & sqlProcessPay
        End If

        Try
            x = New MessageDialog
            x.btnOK.Enabled = False
            x.ulMessage.Text = "Processing ..."
            x.Show()

            sqlConn.Open()
            trnSql = sqlConn.BeginTransaction()
            cmd = New SqlCommand(AIO, sqlConn, trnSql)
            With cmd
                .CommandType = CommandType.Text
                .ExecuteNonQuery()
            End With

            cmd.Transaction.Commit()
            HasError = False
        Catch Err As System.Exception
            MsgBox("Error: " & Err.Message)
            cmd.Transaction.Rollback()
            'Exit Try
        Catch Err As System.NullReferenceException
            MsgBox("Error: " & Err.Message)
            cmd.Transaction.Rollback()
        Catch Err As SqlException
            MsgBox("Error: " & Err.Message)
            cmd.Transaction.Rollback()
        Finally
            If HasError Then
                x.ulMessage.Text = "Process Failed."
                x.btnOK.Enabled = True
                Me.Text = MeText & " -- Payroll Date '" & UltraDate1.Text & "' Process Failed."
            Else
                x.ulMessage.Text = "Process Successful"
                x.btnOK.Enabled = True
                Me.Text = MeText & " -- Payroll Date '" & UltraDate1.Text & "' Processed Successfully."
            End If
            cmd.Connection.Close()
            cmd = Nothing
        End Try

    End Sub

    Private Sub UltraDate1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraDate1.ValueChanged
        If ucboDivision.Value Is Nothing Or ucboDivision.Text = "" Then
            Exit Sub
        End If
        If UltraDate1.Text.IndexOf(UltraDate1.PromptChar) >= 0 Then
            Exit Sub
        End If
        Dim dt As Date

        If _clsWorkDate Is Nothing Then
            InitWorkDate()
        End If
        dt = _clsWorkDate.PayrollEndDate(UltraDate1.Value)
        If dt <> UltraDate1.Value Then
            UltraDate1.Value = dt
        End If

        'UltraDate1.Focus()

    End Sub
End Class
