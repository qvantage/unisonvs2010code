Imports System.Data.SqlClient
Imports System.Drawing.SystemColors

Public Class PhoneListing
    Inherits System.Windows.Forms.Form
    Dim MeText As String
    Dim dtSet As New DataSet
    'Dim HidCols() As String = {"RowID"}
    Dim HidCols() As String = {"RowID", "OfficeID", "EmployeeID", "Status", "StatusDate", "CreateDate", "DeptNo", "PayRate", "MileageRate", "FuelSurcharge_Rate", "WCCode", "ClassID", "Class", "Deduction", "Amount", "DOB", "Gender", "Race", "Address1", "Address2", "City", "State", "Zip", "DLN", "Auto_Pol_Num", "AutoIns_ExpDate", "Marital_Status"}
    Dim m_oColumn As Infragistics.Win.UltraWinGrid.UltraGridColumn = Nothing

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
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnDisplay As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents utOfficeName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utOfficeID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnOffice As System.Windows.Forms.Button
    Friend WithEvents uopOffice As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents uopCompany As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents ucboCompany As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents utEmployee As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utEmployeeID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents uopEmployee As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents btnEmployee As System.Windows.Forms.Button
    Friend WithEvents CntMenu1 As System.Windows.Forms.ContextMenu
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem5 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem6 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnPrint = New System.Windows.Forms.Button
        Me.btnDisplay = New System.Windows.Forms.Button
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.utOfficeName = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utOfficeID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.btnOffice = New System.Windows.Forms.Button
        Me.uopOffice = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.uopCompany = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.ucboCompany = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.utEmployee = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utEmployeeID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.uopEmployee = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.btnEmployee = New System.Windows.Forms.Button
        Me.CntMenu1 = New System.Windows.Forms.ContextMenu
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.utOfficeName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utOfficeID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uopOffice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.uopCompany, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucboCompany, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.utEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utEmployeeID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uopEmployee, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGrid1.Location = New System.Drawing.Point(0, 144)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(672, 301)
        Me.UltraGrid1.TabIndex = 3
        Me.UltraGrid1.Tag = "EmployeeListingGrid"
        Me.UltraGrid1.Text = "Phone Listing"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnPrint)
        Me.GroupBox1.Controls.Add(Me.btnDisplay)
        Me.GroupBox1.Controls.Add(Me.GroupBox4)
        Me.GroupBox1.Controls.Add(Me.GroupBox3)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(672, 144)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(576, 16)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(88, 21)
        Me.btnPrint.TabIndex = 7
        Me.btnPrint.Text = "&Print"
        '
        'btnDisplay
        '
        Me.btnDisplay.Location = New System.Drawing.Point(480, 16)
        Me.btnDisplay.Name = "btnDisplay"
        Me.btnDisplay.Size = New System.Drawing.Size(88, 21)
        Me.btnDisplay.TabIndex = 6
        Me.btnDisplay.Text = "D&isplay"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.utOfficeName)
        Me.GroupBox4.Controls.Add(Me.utOfficeID)
        Me.GroupBox4.Controls.Add(Me.btnOffice)
        Me.GroupBox4.Controls.Add(Me.uopOffice)
        Me.GroupBox4.Location = New System.Drawing.Point(232, 72)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(432, 64)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        '
        'utOfficeName
        '
        Appearance1.ForeColor = System.Drawing.Color.Black
        Appearance1.ForeColorDisabled = System.Drawing.Color.Black
        Me.utOfficeName.Appearance = Appearance1
        Me.utOfficeName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utOfficeName.Location = New System.Drawing.Point(104, 32)
        Me.utOfficeName.Name = "utOfficeName"
        Me.utOfficeName.Size = New System.Drawing.Size(176, 21)
        Me.utOfficeName.TabIndex = 1
        Me.utOfficeName.Tag = ""
        '
        'utOfficeID
        '
        Appearance2.ForeColor = System.Drawing.Color.Black
        Appearance2.ForeColorDisabled = System.Drawing.Color.Black
        Me.utOfficeID.Appearance = Appearance2
        Me.utOfficeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utOfficeID.Location = New System.Drawing.Point(288, 32)
        Me.utOfficeID.Name = "utOfficeID"
        Me.utOfficeID.Size = New System.Drawing.Size(40, 21)
        Me.utOfficeID.TabIndex = 2
        Me.utOfficeID.Tag = ".OfficeID"
        '
        'btnOffice
        '
        Me.btnOffice.Location = New System.Drawing.Point(352, 32)
        Me.btnOffice.Name = "btnOffice"
        Me.btnOffice.Size = New System.Drawing.Size(75, 20)
        Me.btnOffice.TabIndex = 3
        Me.btnOffice.TabStop = False
        Me.btnOffice.Text = "Selec&t"
        '
        'uopOffice
        '
        Appearance3.TextTrimming = Infragistics.Win.TextTrimming.EllipsisWord
        Me.uopOffice.Appearance = Appearance3
        Me.uopOffice.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.uopOffice.ItemAppearance = Appearance4
        ValueListItem1.DataValue = "All Offices"
        ValueListItem1.DisplayText = "All Offices"
        ValueListItem2.DataValue = "By Office"
        ValueListItem2.DisplayText = "By Office"
        Me.uopOffice.Items.Add(ValueListItem1)
        Me.uopOffice.Items.Add(ValueListItem2)
        Me.uopOffice.ItemSpacingVertical = 7
        Me.uopOffice.Location = New System.Drawing.Point(8, 16)
        Me.uopOffice.Name = "uopOffice"
        Me.uopOffice.Size = New System.Drawing.Size(72, 46)
        Me.uopOffice.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.uopCompany)
        Me.GroupBox3.Controls.Add(Me.ucboCompany)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 72)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(216, 64)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        '
        'uopCompany
        '
        Appearance5.TextTrimming = Infragistics.Win.TextTrimming.EllipsisWord
        Me.uopCompany.Appearance = Appearance5
        Me.uopCompany.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.uopCompany.ItemAppearance = Appearance6
        ValueListItem3.DataValue = "All Companies"
        ValueListItem3.DisplayText = "All Companies"
        ValueListItem4.DataValue = "By Company"
        ValueListItem4.DisplayText = "By Company"
        Me.uopCompany.Items.Add(ValueListItem3)
        Me.uopCompany.Items.Add(ValueListItem4)
        Me.uopCompany.ItemSpacingVertical = 7
        Me.uopCompany.Location = New System.Drawing.Point(8, 16)
        Me.uopCompany.Name = "uopCompany"
        Me.uopCompany.Size = New System.Drawing.Size(96, 46)
        Me.uopCompany.TabIndex = 0
        '
        'ucboCompany
        '
        Appearance7.BackColorDisabled = System.Drawing.Color.Silver
        Appearance7.ForeColor = System.Drawing.Color.Black
        Appearance7.ForeColorDisabled = System.Drawing.Color.Black
        Me.ucboCompany.Appearance = Appearance7
        Me.ucboCompany.AutoEdit = False
        Me.ucboCompany.DisplayMember = ""
        Me.ucboCompany.Location = New System.Drawing.Point(104, 32)
        Me.ucboCompany.Name = "ucboCompany"
        Me.ucboCompany.Size = New System.Drawing.Size(100, 21)
        Me.ucboCompany.TabIndex = 1
        Me.ucboCompany.Tag = ".Company..1.Companies.Company.Company"
        Me.ucboCompany.ValueMember = ""
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.utEmployee)
        Me.GroupBox2.Controls.Add(Me.utEmployeeID)
        Me.GroupBox2.Controls.Add(Me.uopEmployee)
        Me.GroupBox2.Controls.Add(Me.btnEmployee)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(432, 64)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'utEmployee
        '
        Appearance8.ForeColor = System.Drawing.Color.Black
        Appearance8.ForeColorDisabled = System.Drawing.Color.Black
        Me.utEmployee.Appearance = Appearance8
        Me.utEmployee.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utEmployee.Enabled = False
        Me.utEmployee.Location = New System.Drawing.Point(168, 32)
        Me.utEmployee.Name = "utEmployee"
        Me.utEmployee.Size = New System.Drawing.Size(176, 21)
        Me.utEmployee.TabIndex = 2
        Me.utEmployee.Tag = ""
        '
        'utEmployeeID
        '
        Appearance9.ForeColor = System.Drawing.Color.Black
        Appearance9.ForeColorDisabled = System.Drawing.Color.Black
        Me.utEmployeeID.Appearance = Appearance9
        Me.utEmployeeID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utEmployeeID.Location = New System.Drawing.Point(104, 32)
        Me.utEmployeeID.Name = "utEmployeeID"
        Me.utEmployeeID.Size = New System.Drawing.Size(56, 21)
        Me.utEmployeeID.TabIndex = 1
        Me.utEmployeeID.Tag = ".OfficeID"
        '
        'uopEmployee
        '
        Appearance10.TextTrimming = Infragistics.Win.TextTrimming.EllipsisWord
        Me.uopEmployee.Appearance = Appearance10
        Me.uopEmployee.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.uopEmployee.ItemAppearance = Appearance11
        ValueListItem5.DataValue = "All Employees"
        ValueListItem5.DisplayText = "All Employees"
        ValueListItem6.DataValue = "By Employee"
        ValueListItem6.DisplayText = "By Employee"
        Me.uopEmployee.Items.Add(ValueListItem5)
        Me.uopEmployee.Items.Add(ValueListItem6)
        Me.uopEmployee.ItemSpacingVertical = 7
        Me.uopEmployee.Location = New System.Drawing.Point(8, 16)
        Me.uopEmployee.Name = "uopEmployee"
        Me.uopEmployee.Size = New System.Drawing.Size(96, 46)
        Me.uopEmployee.TabIndex = 0
        '
        'btnEmployee
        '
        Me.btnEmployee.Location = New System.Drawing.Point(352, 32)
        Me.btnEmployee.Name = "btnEmployee"
        Me.btnEmployee.Size = New System.Drawing.Size(75, 20)
        Me.btnEmployee.TabIndex = 3
        Me.btnEmployee.Text = "Select"
        '
        'PhoneListing
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(672, 445)
        Me.Controls.Add(Me.UltraGrid1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "PhoneListing"
        Me.Tag = "EmployeeListing"
        Me.Text = "Phone Listing"
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.utOfficeName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utOfficeID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uopOffice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.uopCompany, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucboCompany, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.utEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utEmployeeID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uopEmployee, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub PhoneListing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler Me.Activated, AddressOf Form_Activated
        Me.CenterToScreen()

        Me.KeyPreview = True
        MeText = Me.Text

        AddHandler Me.KeyUp, AddressOf Form_KeyUp

        utEmployeeID.MaxLength = 6
        utEmployeeID.Enabled = False
        utEmployee.Enabled = False
        btnEmployee.Enabled = False

        utOfficeID.Enabled = False
        utOfficeName.Enabled = False
        btnEmployee.Enabled = False

        ucboCompany.Enabled = False

        uopEmployee.CheckedIndex = 0
        uopCompany.CheckedIndex = 0
        uopOffice.CheckedIndex = 0

        FillUCombo(ucboCompany, "", "", "", HRTblPath)
        AddHandler ucboCompany.Leave, AddressOf UCbo_Leave
    End Sub

    Private Sub utEmployeeID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utEmployeeID.Leave
        Dim row As DataRow
        Dim gAcct, gAcctID As Infragistics.Win.UltraWinEditors.UltraTextEditor

        Select Case sender.Name
            Case "utEmployeeID"
                gAcct = utEmployee
                gAcctID = utEmployeeID
        End Select

        If sender.Modified = False Then Exit Sub

        If sender.text.trim = "" Then
            gAcct.Text = ""
            sender.text = ""
        Else
            If SearchOnLeave(sender, gAcctID, "" & HRTblPath & "EmployeesBase", "ID", "ID", "*", "Employees", "") Then
                If ReturnRowByID(gAcctID.Text, row, HRTblPath & "EmployeesBase", "", "ID") Then
                    gAcct.Text = row("FirstName") & " " & row("LastName")
                    row = Nothing
                Else
                    'Message modified by Michael Pastor
                    MsgBox("Employee not found.", MsgBoxStyle.Exclamation, "Data Unavailable")
                    '- MsgBox("Employee Not Found.")
                    gAcctID.Text = ""
                    gAcct.Text = ""
                End If
            Else
                gAcctID.Text = ""
                gAcct.Text = ""
                sender.focus()
            End If
        End If
        sender.Modified = False
    End Sub

    Private Sub btnEmployee_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmployee.Click
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim gAcct, gAcctID As Infragistics.Win.UltraWinEditors.UltraTextEditor
        Select Case sender.Name
            Case "btnEmployee"
                gAcct = utEmployee
                gAcctID = utEmployeeID
            Case Else
                MsgBox("Unknown Button")
                Exit Sub
        End Select

        SelectSQL = "Select * from " & HRTblPath & "EmployeesBase i order by ID "

        PopulateDataset2(dtAdapter, dtSet, SelectSQL)
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
                Srch = Nothing
                sender.Focus()
                HasErr = True
                Exit Try
            Catch Err2 As System.NullReferenceException
                Srch = Nothing
                sender.Focus()
                HasErr = True
                Exit Try
            Catch osqlexception As SqlException
                'Message modified by Michael Pastor
                MsgBox("SQL_Error: " & osqlexception.Message, MsgBoxStyle.Critical, "Critical Error")
                '- MsgBox("SQL_Error: " & osqlexception.Message)
                Srch = Nothing
                sender.Focus()
                Exit Try
            Finally
                If HasErr = False Then
                    ugRow = Srch.UltraGrid1.ActiveRow
                    gAcct.Text = ugRow.Cells("FirstName").Text & " " & ugRow.Cells("LastName").Text
                    gAcctID.Text = ugRow.Cells("ID").Text
                    Srch = Nothing
                    gAcct.Modified = False
                    gAcctID.Modified = False
                End If
            End Try
        End If
    End Sub

    Private Sub uopEmployee_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles uopEmployee.ValueChanged
        Select Case uopEmployee.CheckedIndex
            Case 0 ' All Employees
                utEmployee.Text = ""
                utEmployeeID.Text = ""
                utEmployeeID.Enabled = False
                btnEmployee.Enabled = False
            Case 1 ' By Employee
                utEmployeeID.Enabled = True
                btnEmployee.Enabled = True
        End Select
    End Sub

    Private Sub uopCompany_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uopCompany.ValueChanged
        Select Case uopCompany.CheckedIndex
            Case 0 ' All 
                ucboCompany.Text = ""
                ucboCompany.Value = Nothing
                ucboCompany.Enabled = False
            Case 1 ' By Company
                ucboCompany.Enabled = True
        End Select
    End Sub

    Private Sub uopOffice_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles uopOffice.ValueChanged
        Select Case uopOffice.CheckedIndex
            Case 0 ' All 
                utOfficeName.Text = ""
                utOfficeID.Text = ""
                utOfficeName.Enabled = False
                utOfficeID.Enabled = False
                btnOffice.Enabled = False
            Case 1 ' By Employee
                utOfficeName.Enabled = True
                utOfficeID.Enabled = True
                btnOffice.Enabled = True
        End Select
    End Sub

    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOffice.Click
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
                'Message modified by Michael Pastor
                MsgBox("SQL_Error: " & osqlexception.Message, MsgBoxStyle.Critical, "Critical Error")
                '- MsgBox("SQL_Error: " & osqlexception.Message)
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
                'Message modified by Michael Pastor
                MsgBox("Account not found.", MsgBoxStyle.Exclamation, "Data Unavailable")
                '- MsgBox("Account not found.")
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
        Else
            If SearchOnLeave(sender, utOfficeID, HRTblPath & "ServiceOffices", "ID", "Name", "*", "Service Offices", " Where Active = 1 ") Then
                ucboCompany.Focus()
            Else
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

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        UltraGrid1.PrintPreview(Infragistics.Win.UltraWinGrid.RowPropertyCategories.All)
    End Sub

    Private Sub btnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        LoadData()
    End Sub

    Private Sub LoadData()

        Dim dtAdapter As SqlDataAdapter
        Dim i As Integer
        Dim SQLSelect, DateRngCond, StatusCond, EmplCond, CompCond, OfficeCond, DedJoinCond, DedCond, SummCol As String

        SQLSelect = "Select eb.Company, eb.OfficeID, so.Name as Office, eb.ID As EmployeeID " & _
                    " , eb.FirstName, eb.MiddleName, eb.LastName, eb.Status, eb.StatusDate, eb.CreateDate " & _
                    " , ep.DeptNo, ep.PayRate " & _
                    ",  ep.MileageRate, sofs.FuelSurcharge_Rate " & _
                    " , ep.WCCode, ep.ClassID, cl.Class " & _
                    " , d.Deduction, ed.Amount " & _
                    " , ei.DOB, ei.Gender, ei.Race, ei.Address1, ei.Address2, ei.City, ei.State, ei.Zip, ei.Phone, ei.Phone2 as Emrg_Phone " & _
                    " , ei.Cell, ei.email, ei.DLN, ei.AutoInsPolNum as Auto_Pol_Num, ei.AutoInsExpDate as AutoIns_ExpDate " & _
                    " , ei.Marital_Status  " & _
                    " FROM " & HRTblPath & "EmployeesBase eb " & _
                    " Left Outer Join " & HRTblPath & "EmployeeInfo ei On eb.ID = ei.EmployeeID " & _
                    " Left Outer Join " & HRTblPath & "EmployeePayRates ep On eb.ID = ep.EmployeeID " & _
                    " @DEDJOIN " & HRTblPath & "EmployeeDeductions ed On eb.ID = ed.EmployeeID " & _
                    " Left Outer Join " & HRTblPath & "ServiceOffices so On eb.OfficeID = so.ID " & _
                    " Left Outer Join " & HRTblPath & "ServiceOffice_FS sofs On eb.OfficeID = sofs.OfficeID " & _
                    " Left Outer Join " & HRTblPath & "CLASSES cl On ep.ClassID = cl.ClassID " & _
                    " Left Outer Join " & HRTblPath & "Deductions d On ed.DeductionID = d.DeductionID " & _
                    " WHERE @EMPLID @STATUS @COMP @OFFICE " & _
                    " ORDER BY eb.Company, so.Name, eb.ID "

        Select Case uopEmployee.CheckedIndex
            Case 0 'All Employees
                EmplCond = " eb.ID like '%' "
            Case 1 'By Employee
                If utEmployeeID.Text.Trim = "" Then
                    'Message modified by Michael Pastor
                    MsgBox("Employee remains unspecified. Please select an employee to continue.", MsgBoxStyle.Exclamation, "Missing Data Input")
                    '- MsgBox("Employee not selected.")
                    Exit Sub
                End If
                EmplCond = " eb.ID = '" & utEmployeeID.Text.Trim & "'"
        End Select

        Select Case uopCompany.CheckedIndex
            Case 0 'All Companies
                CompCond = ""
            Case 1 'By Company
                If ucboCompany.Value Is Nothing Or ucboCompany.Text.Trim = "" Then
                    'Message modified by Michael Pastor
                    MsgBox("Copmpany remains unspecified. Please select a conpany to continue.", MsgBoxStyle.Exclamation, "Missing Data Input")
                    '- MsgBox("Company not selected.")
                    Exit Sub
                End If
                CompCond = " AND eb.Company = '" & ucboCompany.Value & "'"
        End Select

        Select Case uopOffice.CheckedIndex
            Case 0 'All Offices
                OfficeCond = ""
            Case 1 'By Office
                If utOfficeID.Text.Trim = "" Then
                    'Message modified by Michael Pastor
                    MsgBox("Office remains unspecified. Please select an office to continue.", MsgBoxStyle.Exclamation, "Missing Data Input")
                    '- MsgBox("Office not selected.")
                    Exit Sub
                End If
                OfficeCond = " AND eb.OfficeID = '" & utOfficeID.Text.Trim & "'"
        End Select
        'Select Case uchDeduction.Checked
        '    Case True
        '        DedJoinCond = " INNER JOIN "
        '        sqlPayRates = ""
        '        DedCond = " AND eb.ID in (Select distinct EmployeeID from " & HRTblPath & "EmployeeDeductions ed)"
        '    Case False
        DedJoinCond = " Left Outer Join "
        DedCond = ""
        'End Select

        If Not UltraGrid1.DataSource Is Nothing Then
            'UGSaveLayout(Me, UltraGrid1, 1)
        End If

        StatusCond = " AND eb.Status = 'A' "

        SQLSelect = SQLSelect.Replace("@EMPLID", EmplCond)
        SQLSelect = SQLSelect.Replace("@STATUS", StatusCond)
        SQLSelect = SQLSelect.Replace("@COMP", CompCond)
        SQLSelect = SQLSelect.Replace("@OFFICE", OfficeCond)
        SQLSelect = SQLSelect.Replace("@DEDJOIN", DedJoinCond)

        PopulateDataset2(dtAdapter, dtSet, SQLSelect)

        For i = 0 To dtSet.Tables(0).Columns.Count - 1
            dtSet.Tables(0).Columns(i).ReadOnly = True
        Next
        'dtSet.Tables(0).Columns(0).ReadOnly = False

        FillUltraGrid(UltraGrid1, dtSet, -1, HidCols, 0)
        'UltraGrid1.DataSource = dtSet
        'UGLoadLayout(Me, UltraGrid1, 1)
        UltraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True
        UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        UltraGrid1.DisplayLayout.AutoFitColumns = False
        For i = 0 To UltraGrid1.DisplayLayout.Bands(0).Columns.Count - 1
            UltraGrid1.DisplayLayout.Bands(0).Columns(i).TabStop = True
            UltraGrid1.DisplayLayout.Bands(0).Columns(i).CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Next

        UltraGrid1.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.True

        'UltraGrid1.DisplayLayout.Bands(0).Summaries.Add("Mileage", Infragistics.Win.UltraWinGrid.SummaryType.Sum, UltraGrid1.DisplayLayout.Bands(0).Columns("Mileage"), Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn)
        'UltraGrid1.DisplayLayout.Bands(0).Summaries("Mileage").Appearance.TextHAlign = Infragistics.Win.HAlign.Right
        'UltraGrid1.DisplayLayout.Bands(0).SummaryFooterCaption = ""
        'UltraGrid1.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False

        SummCol = "EmployeeID"
        UltraGrid1.DisplayLayout.Bands(0).Summaries.Add(SummCol, Infragistics.Win.UltraWinGrid.SummaryType.Count, UltraGrid1.DisplayLayout.Bands(0).Columns(SummCol), Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn)
        UltraGrid1.DisplayLayout.Bands(0).Summaries(SummCol).Appearance.TextHAlign = Infragistics.Win.HAlign.Right
        UltraGrid1.DisplayLayout.Bands(0).SummaryFooterCaption = ""
        UltraGrid1.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False


        UltraGrid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus

        UltraGrid1.DisplayLayout.GroupByBox.Hidden = False
        UltraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid, False, False)
        'UltraGrid1.Text = "Packages"
    End Sub


    ' =============================================================================================
    ' ==================================     MENU ROUTINES     ====================================
    ' =============================================================================================

    Private Sub Ultragrid1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles UltraGrid1.MouseDown
        On Error GoTo ErrLabel

        If e.Button = MouseButtons.Right Then

            Dim oHeaderUI As Infragistics.Win.UltraWinGrid.HeaderUIElement
            Dim oCaptionUI As Infragistics.Win.UltraWinGrid.CaptionAreaUIElement
            Dim oUIElement As Infragistics.Win.UIElement
            Dim oUIElementTmp As Infragistics.Win.UIElement
            Dim point As Point = New Point(e.X, e.Y)


            oUIElement = Me.UltraGrid1.DisplayLayout.UIElement.ElementFromPoint(point)
            If oUIElement Is Nothing Then Exit Sub

            oUIElementTmp = oUIElement.GetAncestor(GetType(Infragistics.Win.UltraWinGrid.HeaderUIElement))
            If oUIElementTmp Is Nothing Then
                oUIElementTmp = oUIElement.GetAncestor(GetType(Infragistics.Win.UltraWinGrid.CaptionAreaUIElement))
                If oUIElementTmp Is Nothing Then
                    Return
                End If
            End If
            oUIElement = oUIElementTmp
            If Not oUIElement.GetType() Is GetType(Infragistics.Win.UltraWinGrid.HeaderUIElement) Then
                If Not oUIElement.GetType() Is GetType(Infragistics.Win.UltraWinGrid.CaptionAreaUIElement) Then
                    Exit Sub
                Else
                    oCaptionUI = oUIElement
                End If
            Else
                oHeaderUI = oUIElement
            End If

            If oCaptionUI Is Nothing Then
                CntMenu1.MenuItems.Clear()
                CntMenu1.MenuItems.Add("Hide", New EventHandler(AddressOf mnuHide_Click))
                CntMenu1.MenuItems.Add("Unhide")
                CntMenu1.MenuItems.Add("Find", New EventHandler(AddressOf mnuFind_Click))
                CntMenu1.MenuItems.Add("Add to Sort (Asc)", New EventHandler(AddressOf mnuSortAsc_Click))
                CntMenu1.MenuItems.Add("Add to Sort (Desc)", New EventHandler(AddressOf mnuSortDesc_Click))


                Dim oColHeader As Infragistics.Win.UltraWinGrid.ColumnHeader = Nothing
                m_oColumn = Nothing
                oColHeader = oHeaderUI.SelectableItem
                m_oColumn = oColHeader.Column
                If m_oColumn Is Nothing Then Exit Sub


                Dim ugcol As Infragistics.Win.UltraWinGrid.UltraGridColumn
                If CntMenu1.MenuItems.Item(1).MenuItems.Count > 0 Then
                    CntMenu1.MenuItems.Item(1).MenuItems.Clear()
                    CntMenu1.MenuItems.RemoveAt(1)
                    CntMenu1.MenuItems.Add("Unhide")
                    CntMenu1.MenuItems(CntMenu1.MenuItems.Count).Index = 1
                End If
                For Each ugcol In UltraGrid1.DisplayLayout.Bands(0).Columns
                    If ugcol.Hidden = True Then
                        CntMenu1.MenuItems(1).MenuItems.Add(ugcol.ToString, New EventHandler(AddressOf SubMnuUnHide_Click))
                    End If
                Next

                CntMenu1.Show(UltraGrid1, point)
            Else 'Caption Click
                CntMenu1.MenuItems.Clear()
                CntMenu1.MenuItems.Add("AutoFit", New EventHandler(AddressOf mnuAutoFit_Click))
                CntMenu1.MenuItems(0).Checked = UltraGrid1.DisplayLayout.AutoFitColumns
                CntMenu1.Show(UltraGrid1, point)

            End If
        End If
        Exit Sub
ErrLabel:
        'Message modified by Michael Pastor
        MsgBox("Error : " & Err.Description, MsgBoxStyle.Critical, "Critical Error")
        '- MsgBox("Error : " & Err.Description)
        'Resume
    End Sub

    Private Sub mnuAutoFit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If CntMenu1.MenuItems(0).Checked Then
            CntMenu1.MenuItems(0).Checked = False
        Else
            CntMenu1.MenuItems(0).Checked = True
        End If
        UltraGrid1.DisplayLayout.AutoFitColumns = CntMenu1.MenuItems(0).Checked

    End Sub

    Private Sub mnuHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles mnuHide.Click
        If Not m_oColumn Is Nothing Then
            m_oColumn.Hidden = True
        End If
    End Sub
    Private Sub SubMnuUnHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ugCol As Infragistics.Win.UltraWinGrid.UltraGridColumn

        For Each ugCol In UltraGrid1.DisplayLayout.Bands(0).Columns
            If ugCol.ToString = sender.text Then
                ugCol.Hidden = False
            End If
        Next

    End Sub

    Private Sub mnuSortAsc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles mnuSortAsc.Click
        UltraGrid1.DisplayLayout.Bands(0).SortedColumns.Add(m_oColumn, False)
    End Sub

    Private Sub mnuSortDesc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles mnuSortDesc.Click
        UltraGrid1.DisplayLayout.Bands(0).SortedColumns.Add(Me.m_oColumn, True)
    End Sub

    '=================================================================================================================
    '=================================================================================================================
    '================================             Search Routines              =======================================
    '=================================================================================================================

    Private m_searchForm As frmSearchInfo = Nothing
    Private m_searchInfo As clsSearchInfo = New clsSearchInfo

    Private Sub mnuFind_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

        If Me.m_oColumn Is Nothing Then Exit Sub

        If Me.m_searchForm Is Nothing Then
            Me.m_searchForm = New frmSearchInfo
        End If

        Me.m_searchForm.ShowMe(Me, Me.m_oColumn.Key, UltraGrid1, m_searchInfo)

    End Sub

    Private Sub utEmployeeID_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles utEmployeeID.ValueChanged, utOfficeName.ValueChanged, utOfficeID.ValueChanged
        Select Case sender.name
            Case "utEmployeeID"
                If utEmployeeID.Text = "" Then utEmployee.Text = ""
            Case "utOfficeName"
                If utOfficeName.Text = "" Then utOfficeID.Text = ""
            Case "utOfficeID"
                If utOfficeID.Text = "" Then utOfficeName.Text = ""

        End Select
    End Sub
End Class
