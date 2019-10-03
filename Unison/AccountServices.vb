Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors

Public Class AccountServices
    Inherits System.Windows.Forms.Form
    Dim SQLSelect As String = _
            "Select mft.ID, mft.AccountID, c.name as AccountName, mft.OfficeID as [Office ID]" & _
            " , so.Name as [Office] " & _
            " , mft.CompName as [Location Name], mft.Street, mft.CityName as City, mft.State, mft.ZipCode, mft.Phone1, mft.Phone2 " & _
            " , mft.Remarks, mft.StartDate, mft.EndDate, mft.OpenTime, mft.CloseTime, mft.DoorKey, mft.BoxKey, mft.InternalRef, mft.AccountRef, mft.AddressId " & _
            " from " & ROUTESTblPath & "AccountServices mft,  " & AppTblPath & "Customer c,  " & AppTblPath & "ServiceOffices so " & _
            " WHERE mft.accountid *= c.id AND mft.officeid *= so.id " & _
            " ORDER BY mft.ID "

    Dim SQLSelectDel As String = _
            "Select mft.ID, mft.AccountID, mft.OfficeID as [Office ID]" & _
            " , mft.CompName as [Location Name], mft.Street, mft.CityName as City, mft.State, mft.ZipCode, mft.Phone1, mft.Phone2 " & _
            " , mft.Remarks, mft.StartDate, mft.EndDate, mft.OpenTime, mft.CloseTime, mft.DoorKey, mft.BoxKey, mft.InternalRef, mft.AccountRef " & _
            " From " & ROUTESTblPath & "AccountServices mft "

    Dim SQLSelectDel2 As String = _
            "Select ID, AccountID, OfficeID as [Office ID]" & _
            " , WeightID  " & _
            " ,CompName as [Location Name], Street, CityName as City, State, ZipCode, Phone1, Phone2 " & _
            " , Remarks, StartDate, EndDate, OpenTime, CloseTime, DoorKey, BoxKey, InternalRef, AccountRef " & _
            " From " & ROUTESTblPath & "AccountServices  "

    Dim SQLEdit As String = _
            "Select mft.AddressId, mft.ID, mft.AccountID, mft.OfficeID as [Office ID]" & _
            " , mft.CompName as [Location Name], mft.Street, mft.CityName as City, mft.State, mft.ZipCode, mft.Phone1, mft.Phone2 " & _
            " , mft.Remarks, mft.StartDate, mft.EndDate, mft.OpenTime, mft.CloseTime, mft.DoorKey, mft.BoxKey, mft.InternalRef, mft.AccountRef " & _
            " From " & ROUTESTblPath & "AccountServices mft " & _
            " ORDER BY mft.ID "
    Dim AcctCriteria As String = " mft.AccountID = "

    Dim HidCols() As String = {"AccountID", "AccountName"}

    Dim MeText As String
    Dim dtSet As New DataSet()
    Dim dvStates As New DataView()
    Dim cmdTrans As SqlCommand
    Dim m_oColumn As Infragistics.Win.UltraWinGrid.UltraGridColumn = Nothing
    Dim delugrow As Infragistics.Win.UltraWinGrid.UltraGridRow


    Private m_searchInfo As clsSearchInfo = New clsSearchInfo()

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
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents CntMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents AcctID As System.Windows.Forms.TextBox
    Friend WithEvents AcctName As System.Windows.Forms.TextBox
    Friend WithEvents btnAcct As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Zipcode As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents State As System.Windows.Forms.ComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents City As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Street As System.Windows.Forms.TextBox
    Friend WithEvents ManifestID As System.Windows.Forms.TextBox
    Friend WithEvents btnOffice As System.Windows.Forms.Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents OFFICEID As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents OfficeName As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Phone2 As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Phone1 As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents btnSearchPlan As System.Windows.Forms.Button
    Friend WithEvents Radio1 As System.Windows.Forms.RadioButton
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Radio2 As System.Windows.Forms.RadioButton
    Friend WithEvents Remarks As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents LocID As System.Windows.Forms.TextBox
    Friend WithEvents chkDoorKey As System.Windows.Forms.CheckBox
    Friend WithEvents chkBoxKey As System.Windows.Forms.CheckBox
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents InternalRef As System.Windows.Forms.TextBox
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents umskOpenTime As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents umskEndDate As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents SrvcID As System.Windows.Forms.TextBox
    Friend WithEvents LocSrch As System.Windows.Forms.TextBox
    Friend WithEvents umskStartDate As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents AcctRef As System.Windows.Forms.TextBox
    Friend WithEvents umskCloseTime As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents btnLocation As System.Windows.Forms.Button
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents LocIDSrch As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnNew = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnSearchPlan = New System.Windows.Forms.Button
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.CntMenu1 = New System.Windows.Forms.ContextMenu
        Me.AcctID = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.txtID = New System.Windows.Forms.TextBox
        Me.LocIDSrch = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.SrvcID = New System.Windows.Forms.TextBox
        Me.LocSrch = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Radio2 = New System.Windows.Forms.RadioButton
        Me.Radio1 = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnLocation = New System.Windows.Forms.Button
        Me.umskStartDate = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
        Me.Label20 = New System.Windows.Forms.Label
        Me.AcctRef = New System.Windows.Forms.TextBox
        Me.umskCloseTime = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
        Me.Label17 = New System.Windows.Forms.Label
        Me.umskOpenTime = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
        Me.Label16 = New System.Windows.Forms.Label
        Me.umskEndDate = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.InternalRef = New System.Windows.Forms.TextBox
        Me.chkBoxKey = New System.Windows.Forms.CheckBox
        Me.chkDoorKey = New System.Windows.Forms.CheckBox
        Me.LocID = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Remarks = New System.Windows.Forms.TextBox
        Me.Phone2 = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
        Me.Label13 = New System.Windows.Forms.Label
        Me.Phone1 = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Zipcode = New System.Windows.Forms.TextBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.State = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.City = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Street = New System.Windows.Forms.TextBox
        Me.ManifestID = New System.Windows.Forms.TextBox
        Me.btnOffice = New System.Windows.Forms.Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.OFFICEID = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.OfficeName = New System.Windows.Forms.TextBox
        Me.btnAcct = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.AcctName = New System.Windows.Forms.TextBox
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnExit)
        Me.GroupBox1.Controls.Add(Me.btnNew)
        Me.GroupBox1.Controls.Add(Me.btnSave)
        Me.GroupBox1.Controls.Add(Me.btnEdit)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(0, 511)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(762, 40)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnExit.Location = New System.Drawing.Point(684, 16)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 21)
        Me.btnExit.TabIndex = 4
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
        'btnSearchPlan
        '
        Me.btnSearchPlan.Location = New System.Drawing.Point(440, 29)
        Me.btnSearchPlan.Name = "btnSearchPlan"
        Me.btnSearchPlan.Size = New System.Drawing.Size(72, 21)
        Me.btnSearchPlan.TabIndex = 7
        Me.btnSearchPlan.Text = "Se&arch"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.UltraGrid1)
        Me.Panel2.Location = New System.Drawing.Point(0, 256)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(792, 256)
        Me.Panel2.TabIndex = 1
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(760, 248)
        Me.UltraGrid1.TabIndex = 0
        Me.UltraGrid1.Text = "Account Services"
        '
        'AcctID
        '
        Me.AcctID.Location = New System.Drawing.Point(120, 6)
        Me.AcctID.Name = "AcctID"
        Me.AcctID.Size = New System.Drawing.Size(64, 20)
        Me.AcctID.TabIndex = 10
        Me.AcctID.Tag = ".AccountID"
        Me.AcctID.Text = ""
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(56, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 16)
        Me.Label5.TabIndex = 10
        Me.Label5.Text = "Acct. ID:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.txtID)
        Me.Panel1.Controls.Add(Me.LocIDSrch)
        Me.Panel1.Controls.Add(Me.Label21)
        Me.Panel1.Controls.Add(Me.SrvcID)
        Me.Panel1.Controls.Add(Me.LocSrch)
        Me.Panel1.Controls.Add(Me.Label15)
        Me.Panel1.Controls.Add(Me.Radio2)
        Me.Panel1.Controls.Add(Me.Radio1)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.btnAcct)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.AcctName)
        Me.Panel1.Controls.Add(Me.AcctID)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.btnSearchPlan)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(762, 256)
        Me.Panel1.TabIndex = 1
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(616, 24)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(40, 20)
        Me.txtID.TabIndex = 173
        Me.txtID.Tag = ".ID"
        Me.txtID.Text = ""
        Me.txtID.Visible = False
        '
        'LocIDSrch
        '
        Me.LocIDSrch.Location = New System.Drawing.Point(552, 24)
        Me.LocIDSrch.Name = "LocIDSrch"
        Me.LocIDSrch.Size = New System.Drawing.Size(24, 20)
        Me.LocIDSrch.TabIndex = 8
        Me.LocIDSrch.Tag = ""
        Me.LocIDSrch.Text = ""
        Me.LocIDSrch.Visible = False
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(56, 54)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(64, 16)
        Me.Label21.TabIndex = 13
        Me.Label21.Text = "Service ID:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SrvcID
        '
        Me.SrvcID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.SrvcID.Location = New System.Drawing.Point(120, 51)
        Me.SrvcID.Name = "SrvcID"
        Me.SrvcID.Size = New System.Drawing.Size(64, 20)
        Me.SrvcID.TabIndex = 13
        Me.SrvcID.Tag = ".ID.view"
        Me.SrvcID.Text = ""
        '
        'LocSrch
        '
        Me.LocSrch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.LocSrch.Location = New System.Drawing.Point(120, 29)
        Me.LocSrch.Name = "LocSrch"
        Me.LocSrch.Size = New System.Drawing.Size(304, 20)
        Me.LocSrch.TabIndex = 12
        Me.LocSrch.Tag = ""
        Me.LocSrch.Text = ""
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(56, 31)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(64, 16)
        Me.Label15.TabIndex = 12
        Me.Label15.Text = "Location :"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Radio2
        '
        Me.Radio2.Location = New System.Drawing.Point(32, 33)
        Me.Radio2.Name = "Radio2"
        Me.Radio2.Size = New System.Drawing.Size(16, 11)
        Me.Radio2.TabIndex = 11
        '
        'Radio1
        '
        Me.Radio1.Location = New System.Drawing.Point(32, 8)
        Me.Radio1.Name = "Radio1"
        Me.Radio1.Size = New System.Drawing.Size(16, 11)
        Me.Radio1.TabIndex = 9
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnLocation)
        Me.GroupBox2.Controls.Add(Me.umskStartDate)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.AcctRef)
        Me.GroupBox2.Controls.Add(Me.umskCloseTime)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.umskOpenTime)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.umskEndDate)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.InternalRef)
        Me.GroupBox2.Controls.Add(Me.chkBoxKey)
        Me.GroupBox2.Controls.Add(Me.chkDoorKey)
        Me.GroupBox2.Controls.Add(Me.LocID)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.Remarks)
        Me.GroupBox2.Controls.Add(Me.Phone2)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.Phone1)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label12)
        Me.GroupBox2.Controls.Add(Me.TextBox1)
        Me.GroupBox2.Controls.Add(Me.Zipcode)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.State)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.City)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Street)
        Me.GroupBox2.Controls.Add(Me.ManifestID)
        Me.GroupBox2.Controls.Add(Me.btnOffice)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.OFFICEID)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.OfficeName)
        Me.GroupBox2.Location = New System.Drawing.Point(0, 70)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(760, 178)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        '
        'btnLocation
        '
        Me.btnLocation.Location = New System.Drawing.Point(356, 48)
        Me.btnLocation.Name = "btnLocation"
        Me.btnLocation.Size = New System.Drawing.Size(55, 21)
        Me.btnLocation.TabIndex = 160
        Me.btnLocation.Text = "Select"
        '
        'umskStartDate
        '
        Me.umskStartDate.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Date
        Me.umskStartDate.InputMask = "mm/dd/yyyy"
        Me.umskStartDate.Location = New System.Drawing.Point(520, 16)
        Me.umskStartDate.Name = "umskStartDate"
        Me.umskStartDate.Size = New System.Drawing.Size(72, 20)
        Me.umskStartDate.TabIndex = 9
        Me.umskStartDate.Tag = ".StartDate"
        Me.umskStartDate.Text = "//"
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(439, 112)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(80, 16)
        Me.Label20.TabIndex = 105
        Me.Label20.Text = "Customer Ref.:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'AcctRef
        '
        Me.AcctRef.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.AcctRef.Location = New System.Drawing.Point(520, 112)
        Me.AcctRef.Name = "AcctRef"
        Me.AcctRef.Size = New System.Drawing.Size(152, 20)
        Me.AcctRef.TabIndex = 16
        Me.AcctRef.Tag = ".AccountRef"
        Me.AcctRef.Text = ""
        '
        'umskCloseTime
        '
        Me.umskCloseTime.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Time
        Me.umskCloseTime.Location = New System.Drawing.Point(680, 40)
        Me.umskCloseTime.Name = "umskCloseTime"
        Me.umskCloseTime.Size = New System.Drawing.Size(72, 20)
        Me.umskCloseTime.TabIndex = 12
        Me.umskCloseTime.Tag = ".CloseTime"
        Me.umskCloseTime.Text = ": "
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(607, 43)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(72, 16)
        Me.Label17.TabIndex = 102
        Me.Label17.Text = "Close Time:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'umskOpenTime
        '
        Me.umskOpenTime.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Time
        Me.umskOpenTime.Location = New System.Drawing.Point(520, 40)
        Me.umskOpenTime.Name = "umskOpenTime"
        Me.umskOpenTime.Size = New System.Drawing.Size(72, 20)
        Me.umskOpenTime.TabIndex = 11
        Me.umskOpenTime.Tag = ".OpenTime"
        Me.umskOpenTime.Text = ": "
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(447, 47)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(72, 16)
        Me.Label16.TabIndex = 100
        Me.Label16.Text = "Open Time:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'umskEndDate
        '
        Me.umskEndDate.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Date
        Me.umskEndDate.InputMask = "mm/dd/yyyy"
        Me.umskEndDate.Location = New System.Drawing.Point(680, 16)
        Me.umskEndDate.Name = "umskEndDate"
        Me.umskEndDate.Size = New System.Drawing.Size(72, 20)
        Me.umskEndDate.TabIndex = 10
        Me.umskEndDate.Tag = ".ENDDate"
        Me.umskEndDate.Text = "//"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(616, 19)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 16)
        Me.Label7.TabIndex = 98
        Me.Label7.Text = "End Date:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(456, 22)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 16)
        Me.Label6.TabIndex = 97
        Me.Label6.Text = "Start Date:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(446, 85)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(72, 16)
        Me.Label19.TabIndex = 95
        Me.Label19.Text = "Internal Ref.:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'InternalRef
        '
        Me.InternalRef.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.InternalRef.Location = New System.Drawing.Point(520, 80)
        Me.InternalRef.Name = "InternalRef"
        Me.InternalRef.Size = New System.Drawing.Size(152, 20)
        Me.InternalRef.TabIndex = 15
        Me.InternalRef.Tag = ".InternalRef"
        Me.InternalRef.Text = ""
        '
        'chkBoxKey
        '
        Me.chkBoxKey.Location = New System.Drawing.Point(606, 66)
        Me.chkBoxKey.Name = "chkBoxKey"
        Me.chkBoxKey.Size = New System.Drawing.Size(88, 16)
        Me.chkBoxKey.TabIndex = 14
        Me.chkBoxKey.Tag = ".BoxKey"
        Me.chkBoxKey.Text = "Box Key"
        '
        'chkDoorKey
        '
        Me.chkDoorKey.Location = New System.Drawing.Point(520, 64)
        Me.chkDoorKey.Name = "chkDoorKey"
        Me.chkDoorKey.Size = New System.Drawing.Size(88, 16)
        Me.chkDoorKey.TabIndex = 13
        Me.chkDoorKey.Tag = ".DoorKey"
        Me.chkDoorKey.Text = "Door Key"
        '
        'LocID
        '
        Me.LocID.Location = New System.Drawing.Point(416, 46)
        Me.LocID.Name = "LocID"
        Me.LocID.Size = New System.Drawing.Size(24, 20)
        Me.LocID.TabIndex = 82
        Me.LocID.Tag = ".AddressId"
        Me.LocID.Text = ""
        Me.LocID.Visible = False
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(456, 136)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(64, 16)
        Me.Label18.TabIndex = 81
        Me.Label18.Text = "Remarks :"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Remarks
        '
        Me.Remarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Remarks.Location = New System.Drawing.Point(520, 136)
        Me.Remarks.Name = "Remarks"
        Me.Remarks.Size = New System.Drawing.Size(232, 20)
        Me.Remarks.TabIndex = 17
        Me.Remarks.Tag = ".Remarks"
        Me.Remarks.Text = ""
        '
        'Phone2
        '
        Me.Phone2.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.Phone2.InputMask = "(###)-###-####"
        Me.Phone2.Location = New System.Drawing.Point(255, 144)
        Me.Phone2.Name = "Phone2"
        Me.Phone2.Size = New System.Drawing.Size(96, 20)
        Me.Phone2.TabIndex = 8
        Me.Phone2.Tag = ".PHONE2"
        Me.Phone2.Text = "()--"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(200, 146)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(56, 16)
        Me.Label13.TabIndex = 74
        Me.Label13.Text = "Phone 2:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Phone1
        '
        Me.Phone1.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.Phone1.InputMask = "(###)-###-####"
        Me.Phone1.Location = New System.Drawing.Point(88, 144)
        Me.Phone1.Name = "Phone1"
        Me.Phone1.TabIndex = 7
        Me.Phone1.Tag = ".PHONE1"
        Me.Phone1.Text = "()--"
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(24, 146)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(64, 16)
        Me.Label14.TabIndex = 73
        Me.Label14.Text = "Phone 1:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(24, 48)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(64, 16)
        Me.Label12.TabIndex = 70
        Me.Label12.Text = "Location :"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBox1
        '
        Me.TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox1.Location = New System.Drawing.Point(88, 48)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(264, 20)
        Me.TextBox1.TabIndex = 2
        Me.TextBox1.Tag = ".COMPNAME......Location Name"
        Me.TextBox1.Text = ""
        '
        'Zipcode
        '
        Me.Zipcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Zipcode.Location = New System.Drawing.Point(254, 120)
        Me.Zipcode.Name = "Zipcode"
        Me.Zipcode.Size = New System.Drawing.Size(96, 20)
        Me.Zipcode.TabIndex = 6
        Me.Zipcode.Tag = ".ZIPCODE"
        Me.Zipcode.Text = ""
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(192, 120)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 16)
        Me.Label3.TabIndex = 67
        Me.Label3.Text = "ZipCode:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'State
        '
        Me.State.Location = New System.Drawing.Point(88, 120)
        Me.State.Name = "State"
        Me.State.Size = New System.Drawing.Size(56, 21)
        Me.State.TabIndex = 5
        Me.State.Tag = ".STATE...STATE.CODE.CODE"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(48, 120)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 16)
        Me.Label4.TabIndex = 68
        Me.Label4.Text = "State:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(48, 96)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 16)
        Me.Label9.TabIndex = 66
        Me.Label9.Text = "City:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'City
        '
        Me.City.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.City.Location = New System.Drawing.Point(88, 96)
        Me.City.Name = "City"
        Me.City.Size = New System.Drawing.Size(264, 20)
        Me.City.TabIndex = 4
        Me.City.Tag = ".CITYNAME......City"
        Me.City.Text = ""
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(32, 72)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 16)
        Me.Label10.TabIndex = 65
        Me.Label10.Text = "Address:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Street
        '
        Me.Street.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Street.Location = New System.Drawing.Point(88, 72)
        Me.Street.Name = "Street"
        Me.Street.Size = New System.Drawing.Size(264, 20)
        Me.Street.TabIndex = 3
        Me.Street.Tag = ".STREET"
        Me.Street.Text = ""
        '
        'ManifestID
        '
        Me.ManifestID.Location = New System.Drawing.Point(416, 70)
        Me.ManifestID.Name = "ManifestID"
        Me.ManifestID.Size = New System.Drawing.Size(24, 20)
        Me.ManifestID.TabIndex = 9
        Me.ManifestID.Tag = ".ID.View"
        Me.ManifestID.Text = ""
        Me.ManifestID.Visible = False
        '
        'btnOffice
        '
        Me.btnOffice.Location = New System.Drawing.Point(356, 16)
        Me.btnOffice.Name = "btnOffice"
        Me.btnOffice.Size = New System.Drawing.Size(56, 21)
        Me.btnOffice.TabIndex = 17
        Me.btnOffice.Text = "Select"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(16, 19)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 16)
        Me.Label11.TabIndex = 55
        Me.Label11.Text = "Office ID:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'OFFICEID
        '
        Me.OFFICEID.Location = New System.Drawing.Point(88, 16)
        Me.OFFICEID.Name = "OFFICEID"
        Me.OFFICEID.Size = New System.Drawing.Size(32, 20)
        Me.OFFICEID.TabIndex = 0
        Me.OFFICEID.Tag = ".officeid......Office ID"
        Me.OFFICEID.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(132, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(40, 16)
        Me.Label1.TabIndex = 56
        Me.Label1.Text = "Office :"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'OfficeName
        '
        Me.OfficeName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.OfficeName.Enabled = False
        Me.OfficeName.Location = New System.Drawing.Point(172, 16)
        Me.OfficeName.Name = "OfficeName"
        Me.OfficeName.Size = New System.Drawing.Size(180, 20)
        Me.OfficeName.TabIndex = 1
        Me.OfficeName.Tag = ".OfficeNAME.view.....Office"
        Me.OfficeName.Text = ""
        '
        'btnAcct
        '
        Me.btnAcct.Location = New System.Drawing.Point(440, 5)
        Me.btnAcct.Name = "btnAcct"
        Me.btnAcct.Size = New System.Drawing.Size(72, 21)
        Me.btnAcct.TabIndex = 6
        Me.btnAcct.Text = "Select"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(200, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 23
        Me.Label2.Text = "Acct. Name:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'AcctName
        '
        Me.AcctName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.AcctName.Enabled = False
        Me.AcctName.Location = New System.Drawing.Point(272, 6)
        Me.AcctName.Name = "AcctName"
        Me.AcctName.Size = New System.Drawing.Size(152, 20)
        Me.AcctName.TabIndex = 11
        Me.AcctName.Tag = ".AccountNAME.view"
        Me.AcctName.Text = ""
        '
        'AccountServices
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(762, 551)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "AccountServices"
        Me.Tag = "AccountServices"
        Me.Text = "Account Services Setup"
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub ManifestSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim dtaStates As New SqlDataAdapter()
        Dim MinWinSize As System.Drawing.Size

        Me.CenterToScreen()

        Me.KeyPreview = True
        MeText = Me.Text

        ' Set each control's length based on DB size
        SetupCtrlsLength(Me, AppDBName, AppDBUser, AppDBPass)

        AddHandler State.KeyPress, AddressOf CBO_Search
        AddHandler State.KeyUp, AddressOf CBO_KeyUp
        AddHandler State.Leave, AddressOf CBO_Leave
        AddHandler Me.KeyUp, AddressOf Form_KeyUp
        AddHandler umskStartDate.Validating, AddressOf umskDate_Validating
        AddHandler umskEndDate.Validating, AddressOf umskDate_Validating

        umskOpenTime.InputMask = "hh:mm"
        umskCloseTime.InputMask = "hh:mm"

        FillCombo(State, "CA")

        Group_EnDis(False)
        Radio1.Checked = True

        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = ROUTESTblPath & Me.Tag
            End If
        End If
        'UltraGrid1.DisplayLayout.Bands(0).Summaries.Add("1", Infragistics.Win.UltraWinGrid.SummaryType.Sum, 1, Infragistics.Win.UltraWinGrid.SummaryPosition.Right)


    End Sub

    Private Sub UltraGrid1_AfterRowActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraGrid1.AfterRowActivate
        FormLoadFromGrid(Me, sender)
    End Sub

    Private Sub UltraGrid1_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraGrid1.EnabledChanged
        If sender.enabled Then
            FormLoadFromGrid(Me, sender)
        End If
    End Sub

    Private Sub Group_EnDis(ByVal status As Boolean)
        'Panel1.Enabled = status
        GroupBox2.Enabled = status
        btnSave.Enabled = status
        SrvcID.Enabled = Not status
        btnSave.Text = "&Save"
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim cnt As Integer
        Dim ID As Integer
        Dim dtrow As DataRow

        If TypeOf umskStartDate.Value Is DBNull Then
            MessageBox.Show("Start Date must be entered.")
            Exit Sub
        End If

        If AcctID.Text.Trim = "" Then
            'Message modified by Michael Pastor
            MsgBox("No account ID is selected. Please select an account ID to continue.", MsgBoxStyle.Exclamation, "Missing Data Input")
            Exit Sub
        End If
        If OFFICEID.Text.Trim = "" Then
            'Message modified by Michael Pastor
            MsgBox("No office ID is selected. Please select an office ID to continue.", MsgBoxStyle.Exclamation, "Missing Data Input")
            Exit Sub
        End If

        If InternalRef.Text.Length > 20 Then
            InternalRef.Text = Mid(InternalRef.Text, 1, 20)
        End If

        If Not btnNew.Text = "&New" Then
            If ReturnRowByID(AcctID.Text, dtrow, ROUTESTblPath & "AccountServices as1", "AND as1.id = (SELECT MAX(id) FROM " & ROUTESTblPath & "accountservices as2 WHERE as2.accountid = as1.accountid)", "AccountID") Then
                txtID.Text = dtrow("ID") + 1
            End If
        End If

        If (LocID.Text = "0" Or LocID.Text = "") And Zipcode.Text <> "" Then
            If ReturnRowByID(Zipcode.Text, dtrow, "City", , "Zipcode") Then
                'If ReturnRowByID(LocID.Text, dtrow, "Address") Then
                LocID.Text = dtrow("ID")
            End If
        End If

        If EditForm(Me, SQLEdit, EditAction.ENDEDIT, cmdTrans, " Where ID = " & ManifestID.Text) Then
            Dim row As DataRow
            Dim dtA As New SqlDataAdapter

            ID = OFFICEID.Text
            btnEdit.Text = "&Edit"
            btnNew.Text = "&New"
            LoadData()
            'Me.Text = MeText & " -- Record Updated."
            ''PopulateDataset2(dtA, dtSet, SQLSelect)
            ''FillUltraGrid(UltraGrid1, dtSet, 1)
            '''row = dtSet.Tables(0).Rows.Find(ID)
            'UltraGrid1.ActiveRow.Cells(0) = row.Item(0) 'Infragistics.Win.UltraWinGrid.UltraGridRow)
            'sender.text = "&New"
            UltraGrid1.Enabled = True
            Group_EnDis(False)
            UltraGrid1.Focus()
            UltraGrid1.Refresh()
        End If

    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        ' Lock Records
        If ManifestID.Text.Trim = "" Then Exit Sub
        If btnNew.Text = "&Cancel" Then
            'Message modified by Michael Pastor
            '- I am unable to get this error to pop up.
            MsgBox("You are in 'New' mode. Cancel or Save your current job first.", MsgBoxStyle.Exclamation, "Current Mode: New")
            Exit Sub
        End If

        If sender.text.toupper = "&EDIT" Then
            If EditForm(Me, PrepSelectQuery(SQLEdit, " Where ID = " & ManifestID.Text), EditAction.START, cmdTrans) Then
                UltraGrid1.Enabled = False
                Group_EnDis(True)

                sender.text = "&Cancel"
                TextBox1.Focus()
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
    'Karina commented and added PackageTypes_Closing to WARN a user about Exiting from EDIT/NEW mode.
    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        'If Not cmdTrans Is Nothing Then
        '    If EditForm(Me, PrepSelectQuery(SQLEdit, " Where ID = " & ManifestID.Text), EditAction.CANCEL, cmdTrans) Then
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
            'Message modified by Michael Pastor
            MsgBox("You are in 'Edit' mode. Cancel or Save your current job first.", MsgBoxStyle.Exclamation, "Current Mode: Edit")
            Exit Sub
        End If
        If sender.text = "&New" Then
            UltraGrid1.Enabled = False
            ClearForm(Me)
            Group_EnDis(True)
            sender.text = "&Cancel"
            AcctID.Focus()
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
            'Message modified by Michael Pastor
            '- I am unable to locate the Delete button, and therefore cannot simulate error.
            MsgBox("No record is selected. Please select a record to continue.", MsgBoxStyle.Exclamation, "Missing Data Input")
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

    Private Sub Value_Int_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles AcctID.KeyPress, SrvcID.KeyPress
        If IsNumeric(e.KeyChar) = False And Asc(e.KeyChar) <> Keys.Back Then
            e.Handled = True
        End If
    End Sub

    Private Sub AcctID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles AcctID.Leave
        Dim dbRow As DataRow
        If sender.Modified = False Then Exit Sub
        If sender.Text.Trim = "" Then
            ClearForm(Me)
            UltraGrid1.DataSource = Nothing
            Exit Sub
        End If
        sender.modified = False

        If Val(sender.text) > 0 Then
            If ReturnRowByID(Val(sender.Text), dbRow, AppTblPath & "CUSTOMER", " Status = 1") = False Then
                'Message modified by Michael Pastor
                MsgBox("Account not found.", MsgBoxStyle.Information, "Data Unavailable")
                sender.Focus()
                Exit Sub
            End If
            AcctName.Text = dbRow.Item("NAME")
            sender.Modified = False
            If btnNew.Text.ToUpper <> "&NEW" Then Exit Sub
            LoadData()
        End If

    End Sub

    Private Sub LoadData()

        Dim dtAdapter As SqlDataAdapter
        If Not UltraGrid1.DataSource Is Nothing Then
            'UGSaveLayout(Me, UltraGrid1, 1)
        End If
        PopulateDataset2(dtAdapter, dtSet, PrepSelectQuery(SQLSelect, AcctCriteria & AcctID.Text))

        If dtSet.Tables(0).Rows.Count = 0 Then
            btnSave.Text = "&Save"
        Else
            btnSave.Text = "&Update"
        End If
        FillUltraGrid(UltraGrid1, dtSet, 0, HidCols)
        UGLoadLayout(Me, UltraGrid1, 1)
        UltraGrid1.DisplayLayout.GroupByBox.Hidden = False
        UltraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy

    End Sub

    Private Sub OfficeID_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OFFICEID.Leave
        'Aly's code - start
        'Dim dbRow As DataRow

        'If sender.Modified = False Then Exit Sub
        'If sender.Text.Trim = "" Then Exit Sub
        'sender.modified = False

        'If Val(sender.text) > 0 Then
        '    If ReturnRowByID(Val(sender.Text), dbRow, AppTblPath & "ServiceOffices", " Active = 1 ") = False Then Exit Sub
        '    OfficeName.Text = dbRow.Item("NAME")
        '    sender.Modified = False
        'End If
        'Aly's code - end
        'Karina made changes
        Dim dbRow As DataRow
        If sender.Modified = False Then Exit Sub
        If sender.Text.Trim = "" Then
            ClearForm(Me)
            UltraGrid1.DataSource = Nothing
            Exit Sub
        End If
        sender.modified = False

        If Val(sender.text) > 0 Then
            If ReturnRowByID(Val(sender.Text), dbRow, AppTblPath & "ServiceOffices", " Active = 1 ") = False Then
                'Message modified by Michael Pastor
                MsgBox("Invalid office ID. Please re-enter an office ID.", MsgBoxStyle.Information, "Data Invalid")
                ClearForm(Me) 'Karina
                OfficeName.Text = ""
                sender.Focus()
                Exit Sub
            End If
            OfficeName.Text = dbRow.Item("NAME")
            'ClearForm(Me)
            UltraGrid1.DataSource = Nothing
            sender.Modified = False
            If btnNew.Text.ToUpper <> "&NEW" Then Exit Sub
            LoadData()
        End If
    End Sub

    Private Sub btnAcct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcct.Click
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow

        SelectSQL = "Select * from  " & AppTblPath & "Customer Where Status = 1 order by Name"

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
                'Message modified by Michael Pastor
                MsgBox("SQL_Error: " & osqlexception.Message, MsgBoxStyle.Critical, "Critical Error")
                Srch = Nothing
                sender.Focus()
                Exit Try
            Finally
                If HasErr = False Then
                    ugRow = Srch.UltraGrid1.ActiveRow
                    AcctName.Text = ugRow.Cells("Name").Text
                    AcctID.Text = ugRow.Cells("ID").Text
                    Srch = Nothing
                    If btnNew.Text.ToUpper = "&NEW" Then
                        LoadData()
                    End If
                End If
            End Try
        End If
    End Sub

    Private Sub btnOffice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOffice.Click
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim Title As String

        SelectSQL = "Select * from  " & AppTblPath & "ServiceOffices where Active = 1 order by Name"
        Title = "Offices"

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
                    OfficeName.Text = ugRow.Cells("Name").Text
                    OFFICEID.Text = ugRow.Cells("ID").Text
                    Srch = Nothing
                End If
            End Try
        End If
    End Sub


    Private Sub State_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles State.SelectedIndexChanged
        If sender.Focused Then
            City.Text = ""
            City.Modified = False
            Zipcode.Text = ""
            Zipcode.Modified = False
        Else
        End If
    End Sub

    Private Sub City_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles City.Leave, Zipcode.Leave
        'On Error GoTo ErrTrap
        Dim daCity As New SqlDataAdapter
        Dim dsCity As New DataSet
        Dim dvCities1 As New DataView
        Dim gZipcode, gCity As Control
        Dim gPhone As Control
        Dim gState As ComboBox
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow

        Dim CitiesSQL As String = "Select ID, Name as City, Zipcode, StateCode as State from  " & AppTblPath & "City " '& " where StateCode = '" & State.SelectedValue & "'" '" AND zipcode = '" & Zipcode.Text & "'"
        HasErr = False
        If sender.Modified Then
            gZipcode = Zipcode
            gCity = City
            gState = State
            gPhone = Phone1
            'Zipcode.Text = sender.Text.ToString
            'City.Text = dvCities1.Table.Rows(0).Item("Name")
            'UltraMaskedEdit1.Focus()
            'State.SelectedValue = dvCities1.Table.Rows(0).Item("StateCode")
            If IsNumeric(sender.Text) Then ' Zipcode
                CitiesSQL = CitiesSQL & " where zipcode = '" & sender.Text & "'"
                PopulateDataset2(daCity, dsCity, CitiesSQL)
                dvCities1.Table = dsCity.Tables("City")
                If dvCities1.Table.Rows.Count > 0 Then
                    gZipcode.Text = sender.Text.ToString
                    gCity.Text = dvCities1.Table.Rows(0).Item("City")
                    gPhone.Focus()
                    gState.SelectedValue = dvCities1.Table.Rows(0).Item("State")
                Else
                    'Message modified by Michael Pastor
                    MsgBox("Zipcode not found.", MsgBoxStyle.Exclamation, "Data Unavailable")
                    Zipcode.ResetText()
                    Zipcode.Focus()
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
                            'Message modified by Michael Pastor
                            MsgBox("SQL_Error: " & osqlexception.Message, MsgBoxStyle.Critical, "Critical Error")
                            Srch = Nothing
                            sender.Focus()
                            Exit Try
                        Finally
                            If HasErr = False Then
                                ugRow = Srch.UltraGrid1.ActiveRow
                                gCity.Text = ugRow.Cells("City").Text
                                gZipcode.Text = ugRow.Cells("Zipcode").Text
                                gPhone.Focus()
                                gState.SelectedValue = ugRow.Cells("State").Text
                                Srch = Nothing
                            End If
                        End Try
                    Else ' Just one record found
                        gCity.Text = dvCities1(0).Item("City") 'ugRow.Cells("City").Text
                        gZipcode.Text = dvCities1(0).Item("Zipcode") ' ugRow.Cells("Zipcode").Text
                        gPhone.Focus()
                        gState.SelectedValue = dvCities1(0).Item("State") ' ugRow.Cells("State").Text

                    End If
                Else
                    'Message modified by Michael Pastor
                    MsgBox("City not found.", MsgBoxStyle.Exclamation, "Data Unavailable")
                    '- Original Message:
                    '- MsgBox("No matching city found!", MsgBoxStyle.OKOnly, MeText)
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
        'Message modified by Michael Pastor
        MsgBox("Zip Code is invalid. Error: " & Err.Description, MsgBoxStyle.Exclamation, "Data Invalid")
        '- Original Message:
        '- MsgBox("ZipCode Error: " & Err.Description)
        daCity.Dispose()
        daCity = Nothing
        dsCity.Dispose()
        dsCity = Nothing
    End Sub

    Private Sub City_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles City.KeyUp

        TypeAhead(sender, e, AppTblPath & "City", "Name", "AND StateCode = '" & GetNextControl(sender, True).Text & "'")
        'sender.modified = True
    End Sub

    Private Sub Zipcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Zipcode.KeyPress
        If IsNumeric(e.KeyChar) = False And Asc(e.KeyChar) <> Keys.Back Then
            e.Handled() = True
        End If
    End Sub

    Private Sub Phone1_MaskValidationError(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinMaskedEdit.MaskValidationErrorEventArgs) Handles Phone1.MaskValidationError, Phone2.MaskValidationError, umskEndDate.MaskValidationError, umskStartDate.MaskValidationError, umskOpenTime.MaskValidationError, umskCloseTime.MaskValidationError
        Dim NextCtrl As System.Windows.Forms.Control
        Dim Str As String
        Str = sender.GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw)

        If Str = "" Then
            e.RetainFocus = False
        End If
    End Sub

    Private Sub btnSearchLoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchPlan.Click
        Dim Qry As String

        Dim dtAdapter As SqlDataAdapter
        Dim dtSet As New DataSet

        If LocSrch.Text.Trim = "" Then
            'Message modified by Michael Pastor
            MsgBox("Search field remains unspecified. Please specify your search.", MsgBoxStyle.Exclamation, "Missing Data Input")
            Exit Sub
        End If

        Qry = "Select asvc.AccountID, c.Name  from  " & ROUTESTblPath & "AccountServices asvc,  " & AppTblPath & "Customer c where asvc.AccountID = c.ID and asvc.Name like " & "'" & LocSrch.Text & "%'"

        Dim row As DataRow
        If sender.text.trim = "" Then
        ElseIf SearchOnLeave(LocSrch, LocIDSrch, ROUTESTblPath & "AccountServices", , "CompName", ",AccountID, CityName, State, Zipcode", "Locations") Then
            If ReturnRowByID(LocIDSrch.Text, row, ROUTESTblPath & "AccountServices") Then
                AcctID.Text = row("AccountID")
                'row.Table.DataSet = Nothing
                row = Nothing
                LoadData()
                Radio1.Checked = True
            End If
        End If

        'PopulateDataset2(dtAdapter, dtSet, Qry)

        'If dtSet.Tables(0).Rows.Count <> 0 Then
        '    AcctID.Text = dtSet.Tables(0).Rows(0).Item("AccountID")
        '    AcctName.Text = dtSet.Tables(0).Rows(0).Item("Name")
        '    LoadData()
        '    Radio1.Checked = True
        'Else
        '    MsgBox("No Results Found.")
        'End If
        dtSet = Nothing
        dtAdapter = Nothing




    End Sub

    Private Sub Radio1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radio1.CheckedChanged
        If sender.Checked = True Then
            AcctID.Enabled = True
            LocSrch.Enabled = False
            LocSrch.Text = ""
        End If
    End Sub

    Private Sub Radio2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radio2.CheckedChanged
        If sender.Checked = True Then
            AcctID.Enabled = False
            LocSrch.Enabled = True
            LocSrch.Text = ""
            ClearForm(Me)
            UltraGrid1.DataSource = Nothing
            LocSrch.Focus()
        End If
    End Sub

    Private Sub LocSrch_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles LocSrch.KeyUp
        TypeAhead(sender, e, ROUTESTblPath & "AccountServices", "CompName", "")
    End Sub


    Private Sub TextBox1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Leave
        Dim row As DataRow
        If sender.text.trim = "" Then
            LocID.Text = ""
            sender.text = ""
        ElseIf SearchOnLeave(sender, LocID, AppTblPath & "Address Addr", , , "*", "Locations") Then 'RapidTblPath
            If ReturnRowByID(LocID.Text, row, AppTblPath & "Address") Then 'RapidTblPath
                Street.Text = row("Street")
                City.Text = row("CityName")
                State.SelectedValue = row("StateCode")
                Zipcode.Text = row("Zipcode")
                Phone1.Text = row("Phone")
                'row.Table.DataSet = Nothing
                row = Nothing
            End If
        End If


    End Sub

    Private Sub Textbox1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyUp

        TypeAhead(sender, e, AppTblPath & "Address", "Name", "")  ' RapidTBLPath
        'sender.modified = True
    End Sub

    Private Sub UltraGrid1_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles UltraGrid1.BeforeRowsDeleted
        delugrow = UltraGrid1.Selected.Rows(0)
        delugrow = delugrow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Previous)
    End Sub



    Private Sub UltraGrid1_AfterRowsDeleted(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraGrid1.AfterRowsDeleted

        If WEIGHT_MOD = False Then Exit Sub

        Dim Cmd As SqlCommand
        Dim HasErr As Boolean

        Dim SQLString As String = "Insert into  " & WeightVars.WEIGHTTblPath & "WeightPlanTrash("
        MakeInsertUpdateStatement(Me, SQLString, False)
        HasErr = False
        Try
            If Cmd Is Nothing Then
                sqlConn.Open()
                'Dim trnSql As SqlTransaction = sqlConn.BeginTransaction()
                Cmd = New SqlCommand(SQLString, sqlConn)
            End If
            With Cmd
                .CommandText = SQLString
                .CommandType = CommandType.Text
                .ExecuteNonQuery()
            End With
        Catch Err As System.Exception
            HasErr = True
            Exit Try
        Catch Err2 As System.NullReferenceException
            HasErr = True
            Exit Try
        Catch osqlexception As SqlException
            'Message modified by Michael Pastor
            MsgBox("SQL_Error: " & osqlexception.Message, MsgBoxStyle.Critical, "Critical Error")
            HasErr = True
            Exit Try
        Finally
            If HasErr = False Then
            End If
        End Try
        sqlConn.Close()
        Cmd = Nothing

        Dim PKArray(0)() As Object
        Dim x(2) As Object

        x(0) = "ID" : x(1) = SqlDbType.Int : x(2) = Val(ManifestID.Text)

        PKArray(0) = x


        If DeleteFromDataSetV4(dtSet, SQLSelectDel2 & " Where ID = " & ManifestID.Text, PKArray) <= 0 Then
            'MsgBox("btnDelete_Click: Error!")
            Exit Sub
        End If

        If delugrow Is Nothing Then
            ClearForm(Me)
        Else
            UltraGrid1.ActiveRow = delugrow
        End If
    End Sub

    Private Sub SrvcID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles SrvcID.Leave
        If sender.Modified And sender.text.trim <> "" Then
            If Not HighLightService(sender.text) Then
                SrvcID.Undo()
                sender.Focus()
                'Message modified by Michael Pastor
                MsgBox("Unable to find Service ID.", MsgBoxStyle.Information, "Data Unavailable")
                '- MessageBox.Show("Service-ID Not Found!", "Find Service ID", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
                sender.Focus()
            End If
        End If
    End Sub

    Private Function HighLightService(ByVal Value As String) As Boolean
        Dim oRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        HighLightService = False
        oRow = UltraGrid1.ActiveRow
        If oRow Is Nothing Then oRow = Me.UltraGrid1.GetRow(Infragistics.Win.UltraWinGrid.ChildRow.First)

        m_searchInfo.lookIn = "ID"
        m_searchInfo.matchCase = False
        m_searchInfo.searchContent = SearchContentEnum.WholeField
        m_searchInfo.searchDirection = SearchDirectionEnum.All
        m_searchInfo.searchString = Value

        oRow = Me.UltraGrid1.GetRow(Infragistics.Win.UltraWinGrid.ChildRow.First)
        While Not oRow Is Nothing
            If MatchText(oRow, UltraGrid1, m_searchInfo, m_oColumn) Then
                Me.UltraGrid1.ActiveRow = oRow
                If Not Me.m_oColumn Is Nothing Then
                    Me.UltraGrid1.ActiveCell = oRow.Cells(Me.m_oColumn.Key)
                    Me.UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInRow, False, False)
                End If
                HighLightService = True
                Exit Function
            End If
            oRow = oRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next)
        End While
    End Function

    Private Sub AccountServices_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If btnEdit.Text = "&Cancel" Or btnNew.Text = "&Cancel" Then
            'Message modified by Michael Pastor
            If MessageBox.Show("Data is not saved! Are you sure you want to exit?", "Data Not Saved", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = MsgBoxResult.No Then
                '- If MsgBox("Data is not saved! Are you sure you want to exit?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                e.Cancel = True
                Exit Sub
            End If
        End If

        If Not cmdTrans Is Nothing Then
            If EditForm(Me, PrepSelectQuery(SQLEdit, " Where ID = " & ManifestID.Text), EditAction.CANCEL, cmdTrans) Then
                UltraGrid1.Enabled = True
                Group_EnDis(False)
                sender.text = "&Edit"
            Else
                'Exit Sub
            End If

        End If
        'UGSaveLayout(Me, UltraGrid1, 1)
    End Sub
    'Private Function MatchText(ByVal oRow As Infragistics.Win.UltraWinGrid.UltraGridRow) As Boolean
    '    If oRow Is Nothing Then
    '        MatchText = False
    '        Exit Function
    '    End If
    '    If oRow.ListObject Is Nothing Then
    '        MatchText = False
    '        Exit Function
    '    End If

    '    Dim strColumnKey As String = Me.m_searchInfo.lookIn
    '    Dim oCol As Infragistics.Win.UltraWinGrid.UltraGridColumn
    '    Dim strCellValue As String = ""

    '    '   Determine whether we are searching the current column or all columns
    '    Dim bSearchAllColumns = True
    '    If Me.UltraGrid1.DisplayLayout.Bands(0).Columns.Exists(strColumnKey) Then bSearchAllColumns = False

    '    '   If we are searching all columns then we must iterate through all the cells
    '    '    in this row, which we can do by using the band's Columns collection
    '    If bSearchAllColumns Then
    '        For Each oCol In Me.UltraGrid1.DisplayLayout.Bands(0).Columns
    '            If Not oRow.Cells(oCol.Key).Value Is Nothing Then
    '                If Me.Match(Me.m_searchInfo.searchString, oRow.Cells(oCol.Key).Value) Then
    '                    MatchText = True
    '                    Me.m_oColumn = oCol
    '                    Exit Function
    '                Else
    '                    MatchText = False
    '                End If
    '            End If
    '        Next
    '    Else
    '        oCol = Me.UltraGrid1.DisplayLayout.Bands(0).Columns(strColumnKey)
    '        If Not oRow.Cells(oCol.Key).Value Is Nothing Then
    '            If Me.Match(Me.m_searchInfo.searchString, oRow.Cells(oCol.Key).Value) Then
    '                MatchText = True
    '                Me.m_oColumn = oCol
    '                Exit Function
    '            End If
    '        End If
    '    End If

    'End Function

    'Private Function Match(ByVal userString As String, ByVal cellValue As String) As Boolean

    '    '   If our search is case insensitive, make both strings uppercase
    '    If Not Me.m_searchInfo.matchCase Then
    '        userString = userString.ToUpper
    '        cellValue = cellValue.ToUpper
    '    End If

    '    '   If we are searching any part of the cell value...
    '    If Me.m_searchInfo.searchContent = SearchContentEnum.AnyPartOfField Then

    '        '   If the user string is larger than the cell value, it is by definition
    '        '   a mismatch, so return false
    '        If userString.Length > cellValue.Length Then
    '            Match = False
    '            Exit Function
    '        ElseIf userString.Length = cellValue.Length Then
    '            '   If the lengths are equal, the strings must be equal as well
    '            If userString = cellValue Then Match = True Else Match = False
    '            Exit Function
    '        Else
    '            '   There is probably an easier way to do this
    '            Dim i As Integer
    '            For i = 0 To (cellValue.Length - userString.Length) - 0
    '                If userString = cellValue.Substring(i, userString.Length) Then
    '                    Match = True
    '                    Exit Function
    '                End If
    '            Next
    '            Match = False
    '            Exit Function

    '        End If

    '    ElseIf Me.m_searchInfo.searchContent = SearchContentEnum.WholeField Then
    '        If userString = cellValue Then Match = True Else Match = False
    '        Exit Function

    '    ElseIf Me.m_searchInfo.searchContent = SearchContentEnum.StartOfField Then
    '        If userString.Length >= cellValue.Length Then
    '            If userString.Substring(0, cellValue.Length) = cellValue Then
    '                Match = True
    '            Else
    '                Match = False
    '            End If
    '            Exit Function
    '        Else
    '            If cellValue.Substring(0, userString.Length) = userString Then Match = True Else Match = False
    '            Exit Function
    '        End If

    '    End If

    'End Function

    Private Sub umskStartDate_MaskChanged(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinMaskedEdit.MaskChangedEventArgs) Handles umskStartDate.MaskChanged

    End Sub

    Private Sub btnLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocation.Click
        '**************************************************
        'SF - 5/28/2010 - Added Select button to choose location and return address info
        '**************************************************
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim gLocID, gLoc, gAddrID As Infragistics.Win.UltraWinEditors.UltraTextEditor

        If AcctID.Text = "" Then Exit Sub

        SelectSQL = "Select * from Address i WHERE (Active = 'Y') and CustomerId = " & AcctID.Text & " order by Name"

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

                    TextBox1.Text = ugRow.Cells("Name").Text
                    LocID.Text = ugRow.Cells("ID").Text
                    Street.Text = ugRow.Cells("Street").Text
                    State.Text = ugRow.Cells("Statecode").Text
                    City.Text = ugRow.Cells("CityName").Text
                    Zipcode.Text = ugRow.Cells("ZipCode").Text

                    Srch = Nothing

                End If
            End Try
        End If
    End Sub
End Class
