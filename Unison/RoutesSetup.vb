Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors

Public Class RoutesSetup
    Inherits System.Windows.Forms.Form
    Dim SQLSelect As String = _
                            "Select r.RowID, r.OfficeID, r.ID as [Route ID], r.Name as Route, r.CustomerID, r.LocationID, isnull(c.Name, '') as Customer, isnull(l.Name, '') as Location, r.DriverID, isnull(eb.FirstName + ' ' + eb.LastName,'') as Driver, r.Remarks " & _
                            " FROM " & AppTblPath & "Routes r left outer join " & AppTblPath & "EmployeesBase eb on r.DriverID = eb.ID " & _
                            " Left Outer Join Customer c on r.CustomerID = c.ID " & _
                            " Left Outer Join Address l on r.LocationID = l.LocationID and l.Active = 'Y'"

    Dim SQLEdit As String = _
                            "Select OfficeID, ID as [Route ID], Name as Route, DriverID, CustomerID, LocationID, Remarks" & _
                            " FROM " & AppTblPath & "Routes as r" 'Karina, fix the ID order

    Dim Criteria As String = " Where RowID = '@@ROWID' " '" Where OfficeID = @OfficeID "
    Dim Criteriar As String = " Where r.OfficeID = @OfficeID "

    Dim HidCols() As String = {"RowID", "OfficeID"}

    Dim MeText As String
    Dim dtSet As New DataSet()
    Dim dvStates As New DataView()
    Dim cmdTrans As SqlCommand

    Dim m_oColumn As Infragistics.Win.UltraWinGrid.UltraGridColumn = Nothing

    Dim delugrow As Infragistics.Win.UltraWinGrid.UltraGridRow

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
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents OfficeID As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Office As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Route As System.Windows.Forms.TextBox
    Friend WithEvents RouteID As System.Windows.Forms.TextBox
    Friend WithEvents btnOffice As System.Windows.Forms.Button
    Friend WithEvents btnDriver As System.Windows.Forms.Button
    Friend WithEvents DriverID As System.Windows.Forms.TextBox
    Friend WithEvents Driver As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents utRemarks As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnAcct As System.Windows.Forms.Button
    Friend WithEvents utAcct As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents utAcctID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents utFromLoc As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utFromAddrID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents utFromLocID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnFromLoc As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents utRowID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents CntMenu1 As System.Windows.Forms.ContextMenu
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Office = New System.Windows.Forms.TextBox
        Me.btnOffice = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.OfficeID = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnNew = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.utFromLoc = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utFromAddrID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label7 = New System.Windows.Forms.Label
        Me.utFromLocID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.btnFromLoc = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label6 = New System.Windows.Forms.Label
        Me.btnAcct = New System.Windows.Forms.Button
        Me.utAcct = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label5 = New System.Windows.Forms.Label
        Me.utAcctID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label4 = New System.Windows.Forms.Label
        Me.utRemarks = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.btnDriver = New System.Windows.Forms.Button
        Me.DriverID = New System.Windows.Forms.TextBox
        Me.Driver = New System.Windows.Forms.TextBox
        Me.Route = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.RouteID = New System.Windows.Forms.TextBox
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.utRowID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.CntMenu1 = New System.Windows.Forms.ContextMenu
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.utFromLoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utFromAddrID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utFromLocID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.utAcct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utAcctID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utRemarks, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utRowID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Controls.Add(Me.Office)
        Me.GroupBox3.Controls.Add(Me.btnOffice)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.OfficeID)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(600, 48)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(186, 18)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 16)
        Me.Label2.TabIndex = 25
        Me.Label2.Text = "Office :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Office
        '
        Me.Office.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Office.Enabled = False
        Me.Office.Location = New System.Drawing.Point(226, 16)
        Me.Office.Name = "Office"
        Me.Office.Size = New System.Drawing.Size(216, 20)
        Me.Office.TabIndex = 1
        Me.Office.Tag = ".Office.view"
        Me.Office.Text = ""
        '
        'btnOffice
        '
        Me.btnOffice.Location = New System.Drawing.Point(456, 16)
        Me.btnOffice.Name = "btnOffice"
        Me.btnOffice.Size = New System.Drawing.Size(75, 21)
        Me.btnOffice.TabIndex = 2
        Me.btnOffice.Text = "Se&lect"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(48, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Office ID:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'OfficeID
        '
        Me.OfficeID.Location = New System.Drawing.Point(120, 16)
        Me.OfficeID.Name = "OfficeID"
        Me.OfficeID.Size = New System.Drawing.Size(56, 20)
        Me.OfficeID.TabIndex = 0
        Me.OfficeID.Tag = ".Officeid......_NOUPD_"
        Me.OfficeID.Text = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnExit)
        Me.GroupBox1.Controls.Add(Me.btnNew)
        Me.GroupBox1.Controls.Add(Me.btnSave)
        Me.GroupBox1.Controls.Add(Me.btnEdit)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(0, 421)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(600, 40)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnExit.Location = New System.Drawing.Point(522, 16)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 21)
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "E&xit"
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(155, 16)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(75, 21)
        Me.btnNew.TabIndex = 2
        Me.btnNew.Text = "&New"
        '
        'btnSave
        '
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnSave.Location = New System.Drawing.Point(3, 16)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 21)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "&Save"
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(79, 16)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 21)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "&Edit"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.utRowID)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.utFromLoc)
        Me.GroupBox2.Controls.Add(Me.utFromAddrID)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.utFromLocID)
        Me.GroupBox2.Controls.Add(Me.btnFromLoc)
        Me.GroupBox2.Controls.Add(Me.Panel1)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.utRemarks)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.btnDriver)
        Me.GroupBox2.Controls.Add(Me.DriverID)
        Me.GroupBox2.Controls.Add(Me.Driver)
        Me.GroupBox2.Controls.Add(Me.Route)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.RouteID)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 48)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(600, 184)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(24, 139)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(88, 16)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Location :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utFromLoc
        '
        Me.utFromLoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utFromLoc.Location = New System.Drawing.Point(120, 136)
        Me.utFromLoc.Name = "utFromLoc"
        Me.utFromLoc.Size = New System.Drawing.Size(216, 21)
        Me.utFromLoc.TabIndex = 8
        Me.utFromLoc.Tag = ".Location.view"
        '
        'utFromAddrID
        '
        Me.utFromAddrID.Enabled = False
        Me.utFromAddrID.Location = New System.Drawing.Point(568, 136)
        Me.utFromAddrID.Name = "utFromAddrID"
        Me.utFromAddrID.Size = New System.Drawing.Size(24, 21)
        Me.utFromAddrID.TabIndex = 12
        Me.utFromAddrID.Tag = ""
        Me.utFromAddrID.Visible = False
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(336, 136)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 23)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Loc.ID:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utFromLocID
        '
        Me.utFromLocID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utFromLocID.Location = New System.Drawing.Point(392, 136)
        Me.utFromLocID.Name = "utFromLocID"
        Me.utFromLocID.Size = New System.Drawing.Size(72, 21)
        Me.utFromLocID.TabIndex = 10
        Me.utFromLocID.Tag = ".LocationID"
        '
        'btnFromLoc
        '
        Me.btnFromLoc.Location = New System.Drawing.Point(473, 136)
        Me.btnFromLoc.Name = "btnFromLoc"
        Me.btnFromLoc.Size = New System.Drawing.Size(80, 21)
        Me.btnFromLoc.TabIndex = 11
        Me.btnFromLoc.Text = "Se&lect"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.btnAcct)
        Me.Panel1.Controls.Add(Me.utAcct)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.utAcctID)
        Me.Panel1.Location = New System.Drawing.Point(16, 97)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(544, 32)
        Me.Panel1.TabIndex = 6
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(8, 8)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(88, 16)
        Me.Label6.TabIndex = 3
        Me.Label6.Text = "Account :"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAcct
        '
        Me.btnAcct.Location = New System.Drawing.Point(455, 5)
        Me.btnAcct.Name = "btnAcct"
        Me.btnAcct.Size = New System.Drawing.Size(80, 21)
        Me.btnAcct.TabIndex = 2
        Me.btnAcct.Text = "Se&lect"
        '
        'utAcct
        '
        Me.utAcct.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utAcct.Location = New System.Drawing.Point(103, 4)
        Me.utAcct.Name = "utAcct"
        Me.utAcct.Size = New System.Drawing.Size(216, 21)
        Me.utAcct.TabIndex = 0
        Me.utAcct.Tag = ".Customer.view"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(319, 4)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 23)
        Me.Label5.TabIndex = 4
        Me.Label5.Text = "Acct.ID:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utAcctID
        '
        Me.utAcctID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utAcctID.Location = New System.Drawing.Point(375, 4)
        Me.utAcctID.Name = "utAcctID"
        Me.utAcctID.Size = New System.Drawing.Size(72, 21)
        Me.utAcctID.TabIndex = 1
        Me.utAcctID.Tag = ".CustomerID"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(48, 74)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(64, 16)
        Me.Label4.TabIndex = 101
        Me.Label4.Text = "Remarks:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utRemarks
        '
        Me.utRemarks.Location = New System.Drawing.Point(120, 72)
        Me.utRemarks.Name = "utRemarks"
        Me.utRemarks.Size = New System.Drawing.Size(416, 21)
        Me.utRemarks.TabIndex = 5
        Me.utRemarks.Tag = ".Remarks"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(176, 21)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 16)
        Me.Label3.TabIndex = 99
        Me.Label3.Text = "Name  :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(48, 48)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(64, 16)
        Me.Label16.TabIndex = 98
        Me.Label16.Text = "Driver :"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnDriver
        '
        Me.btnDriver.Location = New System.Drawing.Point(400, 48)
        Me.btnDriver.Name = "btnDriver"
        Me.btnDriver.Size = New System.Drawing.Size(75, 21)
        Me.btnDriver.TabIndex = 4
        Me.btnDriver.Text = "Select"
        '
        'DriverID
        '
        Me.DriverID.Location = New System.Drawing.Point(120, 48)
        Me.DriverID.Name = "DriverID"
        Me.DriverID.Size = New System.Drawing.Size(48, 20)
        Me.DriverID.TabIndex = 2
        Me.DriverID.Tag = ".DriverID"
        Me.DriverID.Text = ""
        '
        'Driver
        '
        Me.Driver.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Driver.Enabled = False
        Me.Driver.Location = New System.Drawing.Point(224, 48)
        Me.Driver.Name = "Driver"
        Me.Driver.Size = New System.Drawing.Size(168, 20)
        Me.Driver.TabIndex = 3
        Me.Driver.Tag = ".Driver.view"
        Me.Driver.Text = ""
        '
        'Route
        '
        Me.Route.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Route.Location = New System.Drawing.Point(224, 16)
        Me.Route.Name = "Route"
        Me.Route.Size = New System.Drawing.Size(168, 20)
        Me.Route.TabIndex = 1
        Me.Route.Tag = ".Name......Route"
        Me.Route.Text = ""
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(40, 18)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 16)
        Me.Label9.TabIndex = 94
        Me.Label9.Text = "Route ID :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'RouteID
        '
        Me.RouteID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.RouteID.Location = New System.Drawing.Point(120, 18)
        Me.RouteID.Name = "RouteID"
        Me.RouteID.Size = New System.Drawing.Size(48, 20)
        Me.RouteID.TabIndex = 0
        Me.RouteID.Tag = ".ID......Route ID"
        Me.RouteID.Text = ""
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGrid1.Location = New System.Drawing.Point(0, 232)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(600, 189)
        Me.UltraGrid1.TabIndex = 2
        Me.UltraGrid1.Text = "Routes"
        '
        'utRowID
        '
        Me.utRowID.Enabled = False
        Me.utRowID.Location = New System.Drawing.Point(424, 16)
        Me.utRowID.Name = "utRowID"
        Me.utRowID.Size = New System.Drawing.Size(24, 21)
        Me.utRowID.TabIndex = 102
        Me.utRowID.Tag = ".RowID.view"
        Me.utRowID.Visible = False
        '
        'RoutesSetup
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(600, 461)
        Me.Controls.Add(Me.UltraGrid1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Name = "RoutesSetup"
        Me.Tag = "Routes"
        Me.Text = "Routes Setup"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.utFromLoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utFromAddrID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utFromLocID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.utAcct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utAcctID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utRemarks, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utRowID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub RouteSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim MinWinSize As System.Drawing.Size
        Dim Index As Integer

        AddHandler Me.Activated, AddressOf Form_Activated
        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = AppTblPath & Me.Tag
            End If
        End If

        Me.CenterToScreen()

        Me.KeyPreview = True
        MeText = Me.Text

        ' Set each control's length based on DB size
        SetupCtrlsLength(Me, AppDBName, AppDBUser, AppDBPass)

        AddHandler Me.KeyUp, AddressOf Form_KeyUp

        Group_EnDis(False)

        utAcct.MaxLength = 70
        utAcct.Enabled = True
        btnAcct.Enabled = True
        utAcctID.MaxLength = 10

        utFromLoc.MaxLength = 70
        utFromLocID.MaxLength = 10

    End Sub

    Private Sub UltraGrid1_AfterRowActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraGrid1.AfterRowActivate
        FormLoadFromGrid(GroupBox2, sender)
    End Sub

    Private Sub UltraGrid1_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraGrid1.EnabledChanged
        If sender.enabled Then
            FormLoadFromGrid(GroupBox2, sender)
        End If
    End Sub

    Private Sub Group_EnDis(ByVal status As Boolean)
        'Panel1.Enabled = status
        GroupBox2.Enabled = status
        GroupBox3.Enabled = Not status
        btnSave.Enabled = status
        btnSave.Text = "&Save"
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim cnt As Integer
        Dim CritTmp As String
        Dim sqlCheckDupe As String = "Select * from " & AppTblPath & "Routes where CustomerID = '@CUSTID' and LocationID = '@LOCID' "
        Dim row As DataRow = Nothing

        If OfficeID.Text.Trim = "" Then
            MessageBox.Show("Office is not selected.")
            Exit Sub
        End If
        If RouteID.Text.Trim = "" Then
            MessageBox.Show("Office is not selected.")
            Exit Sub
        End If
        If utAcctID.Text.Trim <> "" And utFromLocID.Text.Trim = "" Then
            MsgBox("Location is not specified.")
            Exit Sub
        End If
        If utAcctID.Text.Trim = "" And utFromLocID.Text.Trim <> "" Then
            MsgBox("Customer is not specified.")
            Exit Sub
        End If
        If utAcctID.Text.Trim <> "" And utFromLocID.Text.Trim <> "" Then
            sqlCheckDupe = sqlCheckDupe.Replace("@CUSTID", utAcctID.Text.Trim)
            sqlCheckDupe = sqlCheckDupe.Replace("@LOCID", utFromLocID.Text.Trim)
            ReturnRowByID("", row, "", "", "", sqlCheckDupe)
            If Not row Is Nothing Then
                row = Nothing
                If MsgBox("The same Customer-Location exists in the database. Do you want to continue?", MsgBoxStyle.YesNo) <> MsgBoxResult.Yes Then
                    Exit Sub
                End If
            End If
        End If

        'CritTmp = Criteria.Replace("@OfficeID", OfficeID.Text) & " AND ID = '" & UltraGrid1.ActiveRow.Cells("Route ID").Value & "'"
        CritTmp = Criteria.Replace("@@ROWID", utRowID.Text)

        If EditForm(Me, SQLEdit, EditAction.ENDEDIT, cmdTrans, CritTmp) Then
            'Dim row As DataRow
            Dim dtA As New SqlDataAdapter

            btnEdit.Text = "&Edit"
            btnNew.Text = "&New"
            LoadData()
            Me.Text = MeText & " -- Record saved."
            UltraGrid1.Enabled = True
            Group_EnDis(False)
            UltraGrid1.Focus()
            UltraGrid1.Refresh()
        End If

    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        ' Lock Records
        If Office.Text.Trim = "" Then Exit Sub
        If RouteID.Text.Trim = "" Then Exit Sub

        If btnNew.Text = "&Cancel" Then
            MessageBox.Show("You are in 'New' mode. Cancel or Save your current job first.")
            Exit Sub
        End If

        Dim CritTmp As String
        'CritTmp = Criteria.Replace("@OfficeID", OfficeID.Text) & " AND ID = '" & RouteID.Text & "'"
        CritTmp = Criteria.Replace("@@ROWID", utRowID.Text)

        If sender.text.toupper = "&EDIT" Then
            If EditForm(Me, PrepSelectQuery(SQLEdit, CritTmp), EditAction.START, cmdTrans) Then
                UltraGrid1.Enabled = False
                Group_EnDis(True)

                sender.text = "&Cancel"
                RouteID.Focus()
            End If
        Else
            If EditForm(Me, SQLSelect, EditAction.CANCEL, cmdTrans) Then
                UltraGrid1.Enabled = True
                Group_EnDis(False)
                sender.text = "&Edit"
                'FormLoad(Me, dvCompany)
            End If
        End If
    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        'Karina commented and added RoutesSetup_Closing, for MSG if user exits from EDIT/NEW mode
        'Dim CritTmp As String
        'CritTmp = Criteria.Replace("@OfficeID", OfficeID.Text) & " AND routes.ID = '" & RouteID.Text & "'"

        'If Not cmdTrans Is Nothing Then
        '    If EditForm(Me, PrepSelectQuery(SQLEdit, CritTmp), EditAction.CANCEL, cmdTrans) Then
        '        UltraGrid1.Enabled = True
        '        Group_EnDis(False)
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
            MessageBox.Show("You are in 'Edit' mode. Cancel or Save your current job first.")
            Exit Sub
        End If
        If Office.Text.Trim = "" Then
            MsgBox("Please select an office first.")
            Exit Sub
        End If

        If sender.text = "&New" Then
            UltraGrid1.Enabled = False
            ClearForm(GroupBox2)
            Group_EnDis(True)
            sender.text = "&Cancel"
            RouteID.Focus()
        Else
            sender.text = "&New"
            UltraGrid1.Enabled = True
            Group_EnDis(False)
            UltraGrid1.Focus()

        End If
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim dsData As DataSet
        Dim ID As Integer
        Dim row As DataRow
        Dim BandIndex As Integer

        If UltraGrid1.Selected.Rows.Count = 0 Then
            MessageBox.Show("No Record is selected")
            Exit Sub
        End If

        UltraGrid1.DeleteSelectedRows()

        ''If UpdateDbFromDataSet(dtSet, SQLSelectDel & " Where mft.ID = " & ManifestID.Text) <= 0 Then
        ''    MsgBox("btnDelete_Click: Error!")
        ''    Exit Sub
        ''End If


        'ID = UltraGrid1.ActiveRow.Cells(0).Value
        'row = dtSet.Tables(0).Rows.Find(ID)
        'row.Delete()

        'UltraGrid1.ActiveRow.Delete()
        'dsData = UltraGrid1.DataSource


    End Sub

    Private Sub UltraGrid1_AfterRowsDeleted(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraGrid1.AfterRowsDeleted
        Dim CritTmp As String

        CritTmp = Criteriar.Replace("@OfficeID", OfficeID.Text) & " AND r.ID = '" & RouteID.Text & "'"

        If UpdateDbFromDataSet(dtSet, PrepSelectQuery(SQLEdit, CritTmp)) <= 0 Then
            'MsgBox("btnDelete_Click: Error!")
            Exit Sub
        End If

    End Sub

    Private Sub Value_Int_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles OfficeID.KeyPress
        If IsNumeric(e.KeyChar) = False And Asc(e.KeyChar) <> Keys.Back Then
            e.Handled = True
        End If
    End Sub

    Private Sub OfficeID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles OfficeID.Leave
        Dim dbRow As DataRow
        If sender.Modified = False Then Exit Sub
        If sender.Text.Trim = "" Then
            ClearForm(Me)
            UltraGrid1.DataSource = Nothing
            Exit Sub
        End If
        sender.modified = False

        If Val(sender.text) > 0 Then
            'If ReturnRowByID(Val(sender.Text), dbRow, AppTblPath & "ServiceOffices", "") = False Then
            If ReturnRowByID(Val(sender.Text), dbRow, AppTblPath & "ServiceOffices", "where Active = 1") = False Then
                MsgBox("Account not found.")
                ClearForm(Me) 'Karina
                UltraGrid1.DataSource = Nothing 'KArina
                sender.Focus()
                Exit Sub
            End If
            Office.Text = dbRow.Item("NAME")
            sender.Modified = False
            If btnNew.Text.ToUpper <> "&NEW" Then Exit Sub
            LoadData()
        End If

    End Sub

    Private Sub DriverID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles DriverID.Leave
        Dim dbRow As DataRow
        If sender.Modified = False Then Exit Sub
        If sender.Text.Trim = "" Then
            Driver.Text = ""
            Exit Sub
        End If
        sender.modified = False

        If Val(sender.text) > 0 Then
            If ReturnRowByID(Val(sender.Text), dbRow, AppTblPath & "EmployeesBase", " Status = 'A' ") = False Then
                MsgBox("Employee not found.")
                sender.Focus()
                Exit Sub
            End If
            Driver.Text = dbRow.Item("FirstNAME") & " " & dbRow.Item("LastNAME")
            sender.Modified = False
            If btnNew.Text.ToUpper <> "&NEW" Then Exit Sub
        End If

    End Sub

    Private Sub btnDriver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDriver.Click
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter()
        Dim dtSet As New DataSet()
        Dim dtView As New DataView()
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim Title As String

        SelectSQL = "Select * FROM " & AppTblPath & "EmployeesBase Where Status = 'A' order by ID"
        Title = "Employees"

        PopulateDataset2(dtAdapter, dtSet, SelectSQL)
        dtView.Table = dtSet.Tables(0)
        If dtView.Table.Rows.Count > 0 Then
            Dim Srch As New SearchListings()
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
                    Driver.Text = ugRow.Cells("FirstName").Text & " " & ugRow.Cells("LastName").Text
                    DriverID.Text = ugRow.Cells("ID").Text
                    Srch = Nothing
                End If
            End Try
        End If

    End Sub

    Private Sub btnOffice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOffice.Click
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter()
        Dim dtSet As New DataSet()
        Dim dtView As New DataView()
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim Title As String

        SelectSQL = "Select * FROM " & AppTblPath & "ServiceOffices where Active = 1 order by Name"
        'SelectSQL = "Select * FROM " & AppTblPath & "ServiceOffices order by Name"
        Title = "Offices"

        PopulateDataset2(dtAdapter, dtSet, SelectSQL)
        dtView.Table = dtSet.Tables(0)
        If dtView.Table.Rows.Count > 0 Then
            Dim Srch As New SearchListings()
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
                    Office.Text = ugRow.Cells("Name").Text
                    OfficeID.Text = ugRow.Cells("ID").Text
                    Srch = Nothing
                    LoadData()
                End If
            End Try
        End If
    End Sub

    Private Sub UltraGrid1_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles UltraGrid1.BeforeRowsDeleted
        delugrow = UltraGrid1.Selected.Rows(0)
        delugrow = delugrow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Previous)
    End Sub

    Private Sub LoadData()

        Dim dtAdapter As SqlDataAdapter
        If Not UltraGrid1.DataSource Is Nothing Then
            'UGSaveLayout(Me, UltraGrid1, 1)
        End If

        Dim CritTmp As String
        CritTmp = Criteriar.Replace("@OfficeID", OfficeID.Text) '& " AND r.ID = '" & RouteID.Text & "'"

        PopulateDataset2(dtAdapter, dtSet, PrepSelectQuery(SQLSelect, CritTmp))

        btnSave.Text = "&Save"

        FillUltraGrid(UltraGrid1, dtSet, 1, HidCols)
        UGLoadLayout(Me, UltraGrid1, 1)
        UltraGrid1.DisplayLayout.GroupByBox.Hidden = False
        UltraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy

    End Sub


    Private Sub RouteID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles RouteID.Leave
        If RouteID.Text.Trim <> "" Then
            'RouteID.Text = RouteID.Text.PadLeft(RouteID.MaxLength, "0")
        End If
    End Sub

    Private Sub RoutesSetup_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim CritTmp As String
        If btnEdit.Text = "&Cancel" Or btnNew.Text = "&Cancel" Then
            If MsgBox("Data is not saved! Are you sure you want to exit?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                e.Cancel = True
                Exit Sub
            End If
        End If

        'CritTmp = Criteria.Replace("@OfficeID", OfficeID.Text) & " AND routes.ID = '" & RouteID.Text & "'"
        CritTmp = Criteria.Replace("@@ROWID", utRowID.Text)

        If Not cmdTrans Is Nothing Then
            If EditForm(Me, PrepSelectQuery(SQLEdit, CritTmp), EditAction.CANCEL, cmdTrans) Then
                UltraGrid1.Enabled = True
                Group_EnDis(False)
                sender.text = "&Edit"
            Else
                'Exit Sub
            End If

        End If
        'UGSaveLayout(Me, UltraGrid1, 1)
    End Sub

    Private Sub utAcct_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utAcct.Leave
        Dim row As DataRow
        Dim gAcct, gAcctID As Infragistics.Win.UltraWinEditors.UltraTextEditor

        Select Case sender.Name
            Case "utAcct"
                gAcct = utAcct
                gAcctID = utAcctID
        End Select

        If sender.Modified = False Then Exit Sub

        utFromLocID.Text = ""
        utFromLoc.Text = ""
        utFromAddrID.Text = ""

        If sender.text.trim = "" Then
            gAcctID.Text = ""
            sender.text = ""
            'btnSave.Enabled = False
        Else
            ' This for Accounts With Numbers Only Name!!
            'If IsNumeric(sender.text) Then
            '    sender.text = "?" & sender.text
            '    sender.modified = True
            'End If
            If SearchOnLeave(sender, gAcctID, "" & BILLTblPath & "Customer", "CustomerID", "Name", "*", "Accounts", " Where Active = 'Y'") Then
                'If ReturnRowByID(utTruckInventID.Text, row, "TrucksManagement.dbo.Inventory", "", "Truck_Invent_ID") Then
                '    'utLicPlate.Text = row("Lic_Plate")
                '    'utTruckInventID.Text = row("Truck_Invent_ID")
                '    row = Nothing
                'Else
                '    MsgBox("Truck Not Found.")
                '    utTruckInventID.Text = ""
                '    utTruckID.Text = ""
                'End If
            Else
                'MsgBox("Truck Not Found.")
                gAcctID.Text = ""
                gAcct.Text = ""

                sender.focus()
            End If
        End If
        sender.Modified = False

    End Sub

    Private Sub utAcct_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles utAcct.KeyUp
        TypeAhead(sender, e, "" & AppTblPath & "Customer", "Name", " Where Status = 1")
    End Sub

    Private Sub utAcctID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utAcctID.Leave
        Dim row As DataRow
        Dim gAcct, gAcctID As Infragistics.Win.UltraWinEditors.UltraTextEditor

        Select Case sender.Name
            Case "utAcctID"
                gAcct = utAcct
                gAcctID = utAcctID
        End Select

        If sender.Modified = False Then Exit Sub

        utFromLocID.Text = ""
        utFromLoc.Text = ""
        utFromAddrID.Text = ""

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
            If SearchOnLeave(sender, gAcctID, "" & AppTblPath & "Customer", "ID", "ID", "*", "Accounts", " Where Active = 'Y'") Then
                If ReturnRowByID(gAcctID.Text, row, "" & AppTblPath & "Customer", "", "ID") Then
                    gAcct.Text = row("Name")
                    utFromLocID.Text = ""
                    utFromLoc.Text = ""
                    utFromAddrID.Text = ""

                    row = Nothing
                Else
                    MsgBox("Account Not Found.")
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

    Private Sub btnAcct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcct.Click
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim gAcct, gAcctID As Infragistics.Win.UltraWinEditors.UltraTextEditor
        Select Case sender.Name
            Case "btnAcct"
                gAcct = utAcct
                gAcctID = utAcctID
        End Select

        SelectSQL = "Select i.* from " & AppTblPath & "Customer i WHERE (i.status = 1) order by i.Name"

        PopulateDataset2(dtAdapter, dtSet, SelectSQL)
        dtView.Table = dtSet.Tables(0)
        If dtView.Table.Rows.Count > 0 Then
            Dim Srch As New SearchListings
            Srch.dsList = dtSet

            Srch.UltraGrid1.Text = "Accounts"
            Srch.Text = "Accounts"
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
                    gAcct.Text = ugRow.Cells("Name").Text
                    gAcctID.Text = ugRow.Cells("CustomerID").Text

                    utFromLocID.Text = ""
                    utFromLoc.Text = ""
                    utFromAddrID.Text = ""

                    Srch = Nothing
                    gAcct.Modified = False
                    gAcctID.Modified = False
                    'utProviderID.Modified = True
                    'Dim ev As New System.EventArgs
                    'utInventID_Leave(utInventID, ev)
                End If
            End Try
        End If

    End Sub

    Private Sub utPoint_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utFromLoc.Leave
        Dim row As DataRow
        Dim gLocID, gLoc, gAddrID As Infragistics.Win.UltraWinEditors.UltraTextEditor
        Dim CondAcctID As String = ""

        Select Case sender.name
            Case "utFromLoc"
                gLocID = utFromLocID
                gLoc = utFromLoc
                gAddrID = utFromAddrID
        End Select
        If sender.Modified = False Then Exit Sub

        If sender.text.trim = "" Then
            gLocID.Text = ""
            gAddrID.Text = ""
            sender.text = ""
            'btnSave.Enabled = False
        Else
            ' This for Accounts With Numbers Only Name!!
            If IsNumeric(sender.text) Then
                sender.text = "?" & sender.text
                sender.modified = True
            End If

            If utAcctID.Text.Trim <> "" Then
                CondAcctID = " AND CustomerID = '" & utAcctID.Text & "'"
            End If

            If SearchOnLeave(sender, gAddrID, "" & AppTblPath & "Address", "ID", "Name", "*", "Locations", " Where Active = 'Y' " & CondAcctID) Then
                If ReturnRowByID(gAddrID.Text, row, "" & AppTblPath & "Address", "", "ID") Then
                    gLoc.Text = row("Name")
                    gLocID.Text = row("LocationID")
                    row = Nothing
                Else
                    MsgBox("Point Not Found.")
                    gLoc.Text = ""
                    gLocID.Text = ""
                    gAddrID.Text = ""
                End If
            Else
                'MsgBox("Truck Not Found.")
                gLoc.Text = ""
                gLocID.Text = ""
                gAddrID.Text = ""
                sender.focus()
            End If
        End If
        sender.Modified = False

    End Sub

    Private Sub utPoint_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles utFromLoc.KeyUp
        Dim CondAcctID As String = ""

        If utAcctID.Text.Trim <> "" Then
            CondAcctID = " AND CustomerID = '" & utAcctID.Text & "'"
        End If

        TypeAhead(sender, e, "" & AppTblPath & "Address", "Name", " Where Active = 'Y'" & CondAcctID)
    End Sub

    Private Sub utPointLocID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utFromLocID.Leave
        Dim row As DataRow
        Dim gLocID, gLoc, gAddrID As Infragistics.Win.UltraWinEditors.UltraTextEditor
        Dim CondAcctID As String = ""

        If sender.Modified = False Then Exit Sub
        Select Case sender.name
            Case "utFromLocID"
                gLocID = utFromLocID
                gLoc = utFromLoc
                gAddrID = utFromAddrID
        End Select

        If sender.text.trim = "" Then
            gLoc.Text = ""
            gAddrID.Text = ""
            sender.text = ""
            'btnSave.Enabled = False
        Else
            ' This for Accounts With Numbers Only Name!!
            If IsNumeric(sender.text) Then
                sender.text = "?" & sender.text
                sender.modified = True
            End If

            If utAcctID.Text.Trim <> "" Then
                CondAcctID = " AND CustomerID = '" & utAcctID.Text & "'"
            End If

            If SearchOnLeave(sender, gAddrID, "" & AppTblPath & "Address", "ID", "LocationID", "*", "Locations", " Where Active = 'Y' " & CondAcctID) Then
                If ReturnRowByID(gAddrID.Text, row, "" & AppTblPath & "Address", "", "ID", "Select c.Name as Customer, l.* from " & AppTblPath & "Address l left outer join " & AppTblPath & "Customer c on l.CustomerID = c.ID Where l.ID = " & gAddrID.Text) Then
                    gLoc.Text = row("Name")
                    utAcctID.Text = row("CustomerID")
                    utAcct.Text = row("Customer")
                    row = Nothing
                Else
                    MsgBox("Location Not Found.")
                    gLoc.Text = ""
                    gLocID.Text = ""
                    gAddrID.Text = ""
                End If
            Else
                'MsgBox("Truck Not Found.")
                gLoc.Text = ""
                gLocID.Text = ""
                gAddrID.Text = ""
                sender.focus()
            End If
        End If
        sender.Modified = False

    End Sub

    Private Sub btnPoint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFromLoc.Click
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim gLocID, gLoc, gAddrID As Infragistics.Win.UltraWinEditors.UltraTextEditor
        Dim CondAcctID As String = ""

        Select Case sender.name
            Case "btnFromLoc"
                gLocID = utFromLocID
                gLoc = utFromLoc
                gAddrID = utFromAddrID
        End Select

        If utAcctID.Text.Trim <> "" Then
            CondAcctID = " AND CustomerID = '" & utAcctID.Text & "'"
        End If

        SelectSQL = "Select c.Name as Customer, l.* from " & AppTblPath & "Address l inner join " & AppTblPath & "Customer c on l.CustomerID = c.ID WHERE (l.Active = 'Y') " & CondAcctID & " order by l.Name"

        PopulateDataset2(dtAdapter, dtSet, SelectSQL)
        dtView.Table = dtSet.Tables(0)
        If dtView.Table.Rows.Count > 0 Then
            Dim Srch As New SearchListings
            Srch.dsList = dtSet

            Srch.UltraGrid1.Text = "Locations"
            Srch.Text = "Locations"
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

                    gLoc.Text = ugRow.Cells("Name").Text
                    gLocID.Text = ugRow.Cells("LocationID").Text
                    gAddrID.Text = ugRow.Cells("ID").Text
                    utAcctID.Text = ugRow.Cells("CustomerID").Text
                    utAcct.Text = ugRow.Cells("Customer").Text

                    Srch = Nothing
                    utAcct.Modified = False
                    utAcctID.Modified = False
                    'utProviderID.Modified = True
                    'Dim ev As New System.EventArgs
                    'utInventID_Leave(utInventID, ev)
                End If
            End Try
        End If

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
            'Infragistics.Win.UltraWinGrid.BandHeadersUIElement()
            'Infragistics.Win.UltraWinGrid.CaptionAreaUIElement()
            'Infragistics.Win.UltraWinGrid.CardAreaUIElement()
            'Infragistics.Win.UltraWinGrid.CardCaptionUIElement()
            'Infragistics.Win.UltraWinGrid.CardLabelAreaUIElement()
            'Infragistics.Win.UltraWinGrid.CardLabelUIElement()
            'Infragistics.Win.UltraWinGrid.CellUIElement()
            'Infragistics.Win.UltraWinGrid.DataAreaUIElement()
            'Infragistics.Win.UltraWinGrid.PageHeaderUIElement()
            'Infragistics.Win.UltraWinGrid.PreRowAreaUIElement()
            'Infragistics.Win.UltraWinGrid.RowCellAreaUIElement()
            'Infragistics.Win.UltraWinGrid.RowSelectorUIElement()
            'Infragistics.Win.UltraWinGrid.RowUIElement()
            'Infragistics.Win.UltraWinGrid.SortIndicatorUIElement()
            'Infragistics.Win.UltraWinGrid.UltraGridUIElement()

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
        MsgBox("Error : " & Err.Description)
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

End Class
