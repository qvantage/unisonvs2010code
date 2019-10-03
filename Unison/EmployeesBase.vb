Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors

Public Class EmployeesBase
    Inherits System.Windows.Forms.Form
    Dim SQLSelect As String = _
                            "Select eb.ID, eb.FirstName, eb.MiddleName, eb.LastName, eb.Status" & _
                            " , eb.EmplGroupID, convert(varchar, eb.CreateDate, 101) as CreateDate, isnull(eb.StatusDate, '') as StatusDate, eg.Name as EmplGroup " & _
                            " From " & AppTblPath & "EmployeesBase eb, " & AppTblPath & "EmployeeGroups eg" & _
                            " Where eb.EmplGroupID *= eg.ID " & _
                            " Order by eb.ID "

    Dim SQLEdit As String = _
                            "Select eb.ID, eb.FirstName, eb.MiddleName, eb.LastName, eb.Status" & _
                            " , eb.EmplGroupID, convert(varchar, eb.CreateDate, 101) as CreateDate, isnull(eb.StatusDate, '') as StatusDate " & _
                            " From " & AppTblPath & "EmployeesBase eb"

    Dim EmplCriteria As String = " WHERE eb.ID = @EmplID "
    Dim EmplCriteria2 As String = " WHERE ID = @EmplID "

    Dim MeText As String
    Dim dtSet As New DataSet()
    Dim dvStates As New DataView()
    Dim cmdTrans As SqlCommand
    Dim m_oColumn As Infragistics.Win.UltraWinGrid.UltraGridColumn = Nothing
    Dim delugrow As Infragistics.Win.UltraWinGrid.UltraGridRow

    Dim StatusTable As New DataTable()

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
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnSaveNew As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cboStatus As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnGroup As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnPrev As System.Windows.Forms.Button
    Friend WithEvents btnEmpl As System.Windows.Forms.Button
    Friend WithEvents EmplID As System.Windows.Forms.TextBox
    Friend WithEvents LName As System.Windows.Forms.TextBox
    Friend WithEvents CreateDate As System.Windows.Forms.TextBox
    Friend WithEvents EmplGroupID As System.Windows.Forms.TextBox
    Friend WithEvents EmplGroup As System.Windows.Forms.TextBox
    Friend WithEvents MName As System.Windows.Forms.TextBox
    Friend WithEvents FName As System.Windows.Forms.TextBox
    Friend WithEvents DTPicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents InsertMsg As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(EmployeesBase))
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.InsertMsg = New System.Windows.Forms.Label
        Me.btnPrev = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.btnEmpl = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.EmplID = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnSaveNew = New System.Windows.Forms.Button
        Me.btnNew = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.LName = New System.Windows.Forms.TextBox
        Me.CreateDate = New System.Windows.Forms.TextBox
        Me.btnGroup = New System.Windows.Forms.Button
        Me.EmplGroupID = New System.Windows.Forms.TextBox
        Me.EmplGroup = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.MName = New System.Windows.Forms.TextBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.FName = New System.Windows.Forms.TextBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.cboStatus = New System.Windows.Forms.ComboBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.DTPicker1 = New System.Windows.Forms.DateTimePicker
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.InsertMsg)
        Me.GroupBox3.Controls.Add(Me.btnPrev)
        Me.GroupBox3.Controls.Add(Me.btnNext)
        Me.GroupBox3.Controls.Add(Me.btnEmpl)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.EmplID)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(480, 48)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        '
        'InsertMsg
        '
        Me.InsertMsg.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.InsertMsg.ForeColor = System.Drawing.Color.Red
        Me.InsertMsg.Location = New System.Drawing.Point(328, 16)
        Me.InsertMsg.Name = "InsertMsg"
        Me.InsertMsg.Size = New System.Drawing.Size(128, 24)
        Me.InsertMsg.TabIndex = 4
        Me.InsertMsg.Text = "Leave ID blank to set it to next available ID."
        Me.InsertMsg.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.InsertMsg.Visible = False
        '
        'btnPrev
        '
        Me.btnPrev.Image = CType(resources.GetObject("btnPrev.Image"), System.Drawing.Image)
        Me.btnPrev.Location = New System.Drawing.Point(192, 16)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(24, 23)
        Me.btnPrev.TabIndex = 1
        '
        'btnNext
        '
        Me.btnNext.Image = CType(resources.GetObject("btnNext.Image"), System.Drawing.Image)
        Me.btnNext.Location = New System.Drawing.Point(216, 16)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(24, 23)
        Me.btnNext.TabIndex = 2
        '
        'btnEmpl
        '
        Me.btnEmpl.Location = New System.Drawing.Point(248, 16)
        Me.btnEmpl.Name = "btnEmpl"
        Me.btnEmpl.Size = New System.Drawing.Size(75, 21)
        Me.btnEmpl.TabIndex = 3
        Me.btnEmpl.Text = "Se&lect"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(88, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "ID:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'EmplID
        '
        Me.EmplID.Location = New System.Drawing.Point(120, 16)
        Me.EmplID.Name = "EmplID"
        Me.EmplID.Size = New System.Drawing.Size(56, 20)
        Me.EmplID.TabIndex = 0
        Me.EmplID.Tag = ".id.INSERT"
        Me.EmplID.Text = ""
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnExit)
        Me.GroupBox1.Controls.Add(Me.btnSaveNew)
        Me.GroupBox1.Controls.Add(Me.btnNew)
        Me.GroupBox1.Controls.Add(Me.btnSave)
        Me.GroupBox1.Controls.Add(Me.btnEdit)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(0, 293)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(480, 40)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnExit.Location = New System.Drawing.Point(402, 16)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 21)
        Me.btnExit.TabIndex = 4
        Me.btnExit.Text = "E&xit"
        '
        'btnSaveNew
        '
        Me.btnSaveNew.Location = New System.Drawing.Point(264, 16)
        Me.btnSaveNew.Name = "btnSaveNew"
        Me.btnSaveNew.Size = New System.Drawing.Size(96, 21)
        Me.btnSaveNew.TabIndex = 3
        Me.btnSaveNew.Text = "S&ave-New"
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
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.LName)
        Me.GroupBox2.Controls.Add(Me.CreateDate)
        Me.GroupBox2.Controls.Add(Me.btnGroup)
        Me.GroupBox2.Controls.Add(Me.EmplGroupID)
        Me.GroupBox2.Controls.Add(Me.EmplGroup)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.MName)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.FName)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 48)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(480, 152)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(47, 117)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(72, 16)
        Me.Label13.TabIndex = 99
        Me.Label13.Text = "Create Date :"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(24, 92)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(97, 16)
        Me.Label16.TabIndex = 98
        Me.Label16.Text = "Employee Group :"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LName
        '
        Me.LName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.LName.Location = New System.Drawing.Point(120, 65)
        Me.LName.Name = "LName"
        Me.LName.Size = New System.Drawing.Size(224, 20)
        Me.LName.TabIndex = 2
        Me.LName.Tag = ".LastName"
        Me.LName.Text = ""
        '
        'CreateDate
        '
        Me.CreateDate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.CreateDate.Enabled = False
        Me.CreateDate.Location = New System.Drawing.Point(120, 116)
        Me.CreateDate.Name = "CreateDate"
        Me.CreateDate.Size = New System.Drawing.Size(96, 20)
        Me.CreateDate.TabIndex = 5
        Me.CreateDate.Tag = ".CreateDate.view"
        Me.CreateDate.Text = ""
        '
        'btnGroup
        '
        Me.btnGroup.Location = New System.Drawing.Point(352, 93)
        Me.btnGroup.Name = "btnGroup"
        Me.btnGroup.Size = New System.Drawing.Size(75, 21)
        Me.btnGroup.TabIndex = 4
        Me.btnGroup.Text = "Select"
        '
        'EmplGroupID
        '
        Me.EmplGroupID.Location = New System.Drawing.Point(280, 89)
        Me.EmplGroupID.Name = "EmplGroupID"
        Me.EmplGroupID.Size = New System.Drawing.Size(24, 20)
        Me.EmplGroupID.TabIndex = 97
        Me.EmplGroupID.Tag = ".EmplGroupID"
        Me.EmplGroupID.Text = ""
        Me.EmplGroupID.Visible = False
        '
        'EmplGroup
        '
        Me.EmplGroup.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.EmplGroup.Location = New System.Drawing.Point(120, 89)
        Me.EmplGroup.Name = "EmplGroup"
        Me.EmplGroup.Size = New System.Drawing.Size(152, 20)
        Me.EmplGroup.TabIndex = 3
        Me.EmplGroup.Tag = ".EmplGroup.view"
        Me.EmplGroup.Text = ""
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(36, 68)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(80, 16)
        Me.Label7.TabIndex = 96
        Me.Label7.Text = "Last Name :"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(36, 44)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(80, 16)
        Me.Label8.TabIndex = 95
        Me.Label8.Text = "Middle Name :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MName
        '
        Me.MName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.MName.Location = New System.Drawing.Point(120, 44)
        Me.MName.Name = "MName"
        Me.MName.Size = New System.Drawing.Size(224, 20)
        Me.MName.TabIndex = 1
        Me.MName.Tag = ".MiddleName"
        Me.MName.Text = ""
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(48, 20)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 16)
        Me.Label9.TabIndex = 94
        Me.Label9.Text = "First Name :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'FName
        '
        Me.FName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.FName.Location = New System.Drawing.Point(120, 20)
        Me.FName.Name = "FName"
        Me.FName.Size = New System.Drawing.Size(224, 20)
        Me.FName.TabIndex = 0
        Me.FName.Tag = ".FirstName"
        Me.FName.Text = ""
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.cboStatus)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Controls.Add(Me.DTPicker1)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox4.Location = New System.Drawing.Point(0, 200)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(480, 93)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Status"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(48, 27)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(112, 16)
        Me.Label2.TabIndex = 102
        Me.Label2.Text = "Status :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboStatus
        '
        Me.cboStatus.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboStatus.Items.AddRange(New Object() {"Active", "Suspended", "Terminated"})
        Me.cboStatus.Location = New System.Drawing.Point(168, 24)
        Me.cboStatus.Name = "cboStatus"
        Me.cboStatus.Size = New System.Drawing.Size(104, 21)
        Me.cboStatus.TabIndex = 0
        Me.cboStatus.Tag = ".status"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(49, 58)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(112, 16)
        Me.Label5.TabIndex = 100
        Me.Label5.Text = "Status Change Date :"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DTPicker1
        '
        Me.DTPicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.DTPicker1.Location = New System.Drawing.Point(169, 56)
        Me.DTPicker1.Name = "DTPicker1"
        Me.DTPicker1.Size = New System.Drawing.Size(104, 20)
        Me.DTPicker1.TabIndex = 1
        Me.DTPicker1.Tag = ".StatusDate"
        '
        'EmployeesBase
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(480, 333)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Name = "EmployeesBase"
        Me.Tag = "EmployeesBase"
        Me.Text = "Employee Basic Setup"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub EmployeesBase_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

        cboStatus.Items.Clear()
        PrepData(StatusTable)
        cboStatus.DataSource = StatusTable
        cboStatus.DisplayMember = "Status"
        cboStatus.ValueMember = "Code"

        cboStatus.SelectedIndex = 0

        DTPicker1.Format = DateTimePickerFormat.Custom
        DTPicker1.CustomFormat = "MM/dd/yyyy"

        Group_EnDis(False)

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
        row("Code") = "S" : row("Status") = "Suspended"
        tbl.Rows.Add(row)

        row = tbl.NewRow
        row("Code") = "T" : row("Status") = "Terminated"
        tbl.Rows.Add(row)



    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim cnt As Integer
        Dim ID As Integer
        Dim IdentIns As Boolean = False
        Dim CritTmp, StrArr() As String

        StrArr = GetCtrldbFieldInfo(EmplID)

        'Karina "Field empty - don't save"
        If FName.Text.Trim = "" Or LName.Text.Trim = "" Then
            'Message modified by Michael Pastor
            MsgBox("Full name remains unspecified. Please enter the entire name.", MsgBoxStyle.Exclamation, "Missing Data Input")
            'MsgBox("Enter First Name and Last Name!")
            Exit Sub
        End If

        If EmplID.Text.Trim <> "" Then

            CritTmp = EmplCriteria2.Replace("@EmplID", EmplID.Text)
            IdentIns = True
            If btnEdit.Text.ToUpper = "&CANCEL" Then
                EmplID.Tag = StrArr(TagOpts.dtTableName) & "." & StrArr(TagOpts.dtFieldName) & "." & "View"
            Else
                EmplID.Tag = StrArr(TagOpts.dtTableName) & "." & StrArr(TagOpts.dtFieldName) & "." & "INSERT"
            End If
            'EmplID.Tag = StrArr(TagOpts.dtTableName) & "." & StrArr(TagOpts.dtFieldName)
            'New rule: USE INSERT or UPDATE instead of VIEW ...
        Else
            CritTmp = ""
            IdentIns = False
            EmplID.Tag = StrArr(TagOpts.dtTableName) & "." & StrArr(TagOpts.dtFieldName) & "." & "View"
        End If
        If Val(EmplID.Text.Trim) < 0 Then
            'Message modified by Michael Pastor
            MsgBox("ID number is invalid. Please re-enter a valid ID.", MsgBoxStyle.Exclamation, "Data Invalid")
            '- MsgBox("Please input valid ID number.")
            Exit Sub
        End If
        If EditForm(Me, SQLSelect, EditAction.ENDEDIT, cmdTrans, CritTmp, IdentIns) Then
            Dim row As DataRow
            Dim dtA As New SqlDataAdapter
            If EmplID.Text = "" Then
                LoadData("", "P")
            Else
                LoadData(EmplID.Text, "C")
            End If
            btnEdit.Text = "&Edit"
            btnNew.Text = "&New"
            'Me.Text = MeText & " -- Record Updated."
            ''PopulateDataset2(dtA, dtSet, SQLSelect)
            'sender.text = "&New"
            Group_EnDis(False)
        End If

    End Sub

    Private Sub btnSaveNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveNew.Click
        'Karina "Field empty - don't save"
        If FName.Text.Trim = "" Or LName.Text.Trim = "" Then
            'Message modified by Michael Pastor
            MsgBox("Full name remains unspecified. Please enter the entire name.", MsgBoxStyle.Exclamation, "Missing Data Input")
            'MsgBox("Enter First Name and Last Name!")
            Exit Sub
        End If
        If btnNew.Text = "&New" Then
            'Message modified by Michael Pastor
            MsgBox("This option is available only in the 'New' mode.", MsgBoxStyle.Information, "Current Mode: Save New")
            '- MessageBox.Show("You have to be in 'New' mode to be able to use this button.")
            Exit Sub
        End If
        If EditForm(Me, SQLSelect, EditAction.ENDEDIT, cmdTrans, " Where ID = " & EmplID.Text) Then
            Dim row As DataRow
            Dim dtA As New SqlDataAdapter

            PopulateDataset2(dtA, dtSet, SQLSelect)
            ClearForm(Me)
            Group_EnDis(True)
            EmplID.Focus()
            btnSave.Text = "&Save"
        End If

    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Dim CritTmp As String

        CritTmp = EmplCriteria2.Replace("@EmplID", EmplID.Text)

        ' Lock Records
        If btnNew.Text = "&Cancel" Then
            'Message modified by Michael Pastor
            MsgBox("You are in 'New' mode. Cancel or Save your current job first.", MsgBoxStyle.Exclamation, "Current Mode: New")
            Exit Sub
        End If

        ' Karina - the problem from here
        If EmplID.Text.Trim = "" Then Exit Sub 'Karina's changes

        If sender.text.toupper = "&EDIT" Then
            If EditForm(Me, PrepSelectQuery(SQLEdit, CritTmp), EditAction.START, cmdTrans) Then
                Group_EnDis(True)
                'btnSaveNew.Enabled = False
                sender.text = "&Cancel"
            End If
        Else
            If EditForm(Me, SQLEdit, EditAction.CANCEL, cmdTrans) Then
                Group_EnDis(False)
                'btnSaveNew.Enabled = True
                sender.text = "&Edit"
                'FormLoad(Me, dvCompany)
            End If
        End If
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
            'Message modified by Michael Pastor
            '- I am unable to get this error to pop up.
            MsgBox("You are in 'Edit' mode. Cancel or Save your current job first.", MsgBoxStyle.Exclamation, "Current Mode: Edit")
            Exit Sub
        End If
        If sender.text = "&New" Then
            ClearForm(Me)
            sender.text = "&Cancel"
            btnSave.Text = "&Save"
            Group_EnDis(True)
            EmplID.Focus()
        Else
            ClearForm(Me)
            sender.text = "&New"
            Group_EnDis(False)
            btnSave.Text = "&Update"

        End If
    End Sub

    Private Sub LoadData(Optional ByVal IDValue As String = "", Optional ByVal Direction As String = "C")
        Dim dtAdapter As SqlDataAdapter
        Dim dvAcct As New DataView
        Dim dtSet2 As New DataSet
        Dim TempQuery As String
        Dim CritTmp As String

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

        TempQuery = PrepSelectQuery(SQLSelect, CritTmp)

        PopulateDataset2(dtAdapter, dtSet2, TempQuery)
        If dtSet2 Is Nothing Then Exit Sub
        If dtSet2.Tables Is Nothing Then Exit Sub
        If dtSet2.Tables(0) Is Nothing Then Exit Sub

        If dtSet2.Tables(0).Rows.Count = 0 Then
            'ClearForm(GroupBox2)
        Else
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
        End If

        dtSet2 = Nothing

    End Sub

    Private Sub EmplID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles EmplID.Leave
        Dim dtAdapter As SqlDataAdapter
        Dim dvAcct As New DataView
        Dim dtSet2 As New DataSet
        Dim TempQuery As String
        Dim CritTmp As String
        Dim row As DataRow

        CritTmp = EmplCriteria.Replace("@EmplID", EmplID.Text)

        If sender.Modified = False Then Exit Sub
        If sender.Text.Trim = "" Then Exit Sub
        If btnNew.Text = "&Cancel" Or btnEdit.Text = "&Cancel" Then
            If ReturnRowByID(EmplID.Text, row, AppTblPath & "EmployeesBase") Then
                'Message modified by Michael Pastor
                MsgBox("Specified ID has already been assigned. Please enter a unique ID.", MsgBoxStyle.Exclamation, "Data Invalid")
                '- MsgBox("This ID is already assigned. Try other number.")
                EmplID.Undo()
                EmplID.ClearUndo()
                EmplID.Modified = False
                EmplID.Focus()
                Exit Sub
            End If
        End If

        sender.Modified = False

        TempQuery = PrepSelectQuery(SQLSelect, CritTmp)

        PopulateDataset2(dtAdapter, dtSet2, TempQuery)
        If dtSet2 Is Nothing Then Exit Sub
        If dtSet2.Tables Is Nothing Then Exit Sub
        If dtSet2.Tables(0) Is Nothing Then Exit Sub

        If dtSet2.Tables(0).Rows.Count = 0 Then
            Group_EnDis(True)
            ClearForm(GroupBox2)
            FName.Focus()
            btnNew.Text = "&Cancel"
            btnSave.Text = "&Save"
        Else
            Group_EnDis(False)
            btnSave.Text = "&Save"
            btnEdit.Text = "&Edit"
            btnNew.Text = "&New"

            dvAcct.Table = dtSet2.Tables(0)
            FormLoad(Me, dvAcct)
        End If

        dtSet2 = Nothing
    End Sub

    'Private Sub Group_EnDis(ByVal status As Boolean)
    '    btnSave.Enabled = status
    '    If btnNew.Text.ToUpper = "&CANCEL" Then
    '        btnSaveNew.Enabled = True
    '        btnPrev.Enabled = False
    '        btnNext.Enabled = False
    '        btnEmpl.Enabled = False
    '        InsertMsg.Visible = True
    '    Else
    '        btnSaveNew.Enabled = False
    '        btnPrev.Enabled = True
    '        btnNext.Enabled = True
    '        btnEmpl.Enabled = True
    '        InsertMsg.Visible = False
    '    End If

    '    GroupBox2.Enabled = status
    '    GroupBox4.Enabled = status
    '    btnSave.Text = "&Save"
    'End Sub
    'Karina, fixing order of buttong able/unable
    Private Sub Group_EnDis(ByVal status As Boolean)
        btnSave.Enabled = status

        If btnNew.Text.ToUpper = "&CANCEL" Then
            btnSaveNew.Enabled = True
            btnPrev.Enabled = False
            btnNext.Enabled = False
            btnEmpl.Enabled = False
            InsertMsg.Visible = True
        Else
            btnSaveNew.Enabled = False
            btnPrev.Enabled = True
            btnNext.Enabled = True
            btnEmpl.Enabled = True
            InsertMsg.Visible = False
        End If
        Btn_En(status)
        GroupBox2.Enabled = status
        GroupBox4.Enabled = status
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

    Private Sub btnEmpl_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEmpl.Click


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

        SelectQry = "Select ID, FirstName, MiddleName, LastName from " & Me.Tag & " order by LastName"

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
                'Message modified by Michael Pastor
                MsgBox("SQL_Error: " & osqlexception.Message, MsgBoxStyle.Critical, "Critical Error")
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

    Private Sub Value_Int_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles EmplID.KeyPress
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

        SelectSQL = "Select * From " & AppTblPath & "EmployeeGroups order by Name"
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
                'Message modified by Michael Pastor
                MsgBox("SQL_Error: " & osqlexception.Message, MsgBoxStyle.Critical, "Critical Error")
                Srch = Nothing
                sender.Focus()
                Exit Try
            Finally
                If HasErr = False Then
                    ugRow = Srch.UltraGrid1.ActiveRow
                    EmplGroupID.Text = ugRow.Cells("ID").Text
                    EmplGroup.Text = ugRow.Cells("Name").Text
                    Srch = Nothing
                End If
            End Try
        End If

    End Sub

    Private Sub EmplGroup_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles EmplGroup.KeyUp

        TypeAhead(sender, e, AppTblPath & "EmployeeGroups", "Name", "")
        'sender.modified = True
    End Sub

    Private Sub EmplGroup_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles EmplGroup.Leave
        Dim row As DataRow
        If sender.text.trim = "" Then
            EmplGroupID.Text = ""
            sender.text = ""
        ElseIf SearchOnLeave(sender, EmplGroupID, AppTblPath & "EmployeeGroups", , , "*", "Employee Groups") Then
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
    End Sub

    Private Sub btnPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrev.Click
        LoadData(Val(EmplID.Text), "P")
    End Sub

    Private Sub EmployeesBase_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If btnEdit.Text = "&Cancel" Or btnNew.Text = "&Cancel" Then
            'Message modified by Michael Pastor
            If MessageBox.Show("Data is not saved! Are you sure you want to exit?", "Data Not Saved", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = MsgBoxResult.No Then
                e.Cancel = True
                Exit Sub
            End If
        End If

        If Not cmdTrans Is Nothing Then
            If EditForm(Me, SQLSelect, EditAction.CANCEL, cmdTrans) Then
                'UltraGrid1.Enabled = True
                'Group_EnDis(False)
                sender.text = "&Edit"
            Else
                'Exit Sub
            End If

        End If
        'UGSaveLayout(Me, UltraGrid1, 1)
    End Sub

   
    'Private Sub EmployeesBase_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Activated
    '    If ValidateAccess(Me, LoginInfo.UserID, LoginInfo.CompanyCode) = False Then
    '        MsgBox("Authorization Denied.")
    '        Me.Close()
    '    End If
    'End Sub
End Class
