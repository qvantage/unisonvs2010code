Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors
Imports CrystalDecisions.CrystalReports.ViewerObjectModel
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class WeightPlan
    Inherits System.Windows.Forms.Form
    Dim SQLSelect As String = _
            "Select mft.ID, isnull(wpgrp.Name, '') as Manifest, mft.Name, mft.AccountID, c.name as AccountName, mft.OfficeID as [Center ID]" & _
            " ,so.Name as [Wgt Center], mft.WeightID, wbd.WeightLimit, wbd.OWCharge " & _
            " ,mft.CompName as [Location Name], mft.Street,  mft.Address2, mft.CityName as City, mft.State, mft.ZipCode, mft.Phone1, mft.Phone2 " & _
            " , mft.GroupID as [Manifest ID], mft.Remarks, mft.ParentID as [Parent ID], (Select isnull(Name, '') FROM " & WeightVars.WEIGHTTblPath & "Manifests mft2 where mft2.id = mft.parentid) as Parent " & _
            " ,mft.StartDate, mft.EndDate, mft.SID " & _
            " from " & WeightVars.WEIGHTTblPath & "Manifests mft, " & WeightVars.WEIGHTTblPath & "WeightBreakdown wbd, " & AppTblPath & "Customer c, " & AppTblPath & "ServiceOffices so, " & WeightVars.WEIGHTTblPath & "WeightPlanGroups wpgrp " & _
            " WHERE mft.accountid *= c.id AND mft.officeid *= so.id AND mft.weightid *= wbd.id " & _
            " AND mft.GroupID *= wpgrp.ID " & _
            " ORDER BY mft.ID "
    Dim SQLSelectDel As String = _
            "Select mft.ID, mft.Name, mft.AccountID, mft.OfficeID as [Center ID]" & _
            " , mft.WeightID  " & _
            " ,mft.CompName as [Location Name], mft.Street,  mft.Address2, mft.CityName as City, mft.State, mft.ZipCode, mft.Phone1, mft.Phone2 " & _
            " , mft.GroupID as [Manifest ID], mft.Remarks, mft.ParentID as [Parent ID] " & _
            " ,mft.StartDate, mft.EndDate, mft.SID " & _
            " FROM " & WeightVars.WEIGHTTblPath & "Manifests mft "
    Dim SQLSelectDel2 As String = _
            "Select ID, Name, AccountID, OfficeID as [Center ID]" & _
            " , WeightID  " & _
            " ,CompName as [Location Name], Street,  mft.Address2, CityName as City, State, ZipCode, Phone1, Phone2 " & _
            " , GroupID as [Manifest ID], Remarks, ParentID as [Parent ID] " & _
            " ,StartDate, EndDate, SID " & _
            " FROM " & WeightVars.WEIGHTTblPath & "Manifests  "
    Dim SQLEdit As String = _
            "Select mft.ID, mft.Name , mft.AccountID, mft.OfficeID as [Center ID], mft.WeightID " & _
            " , mft.CompName as [Location Name], mft.Street, mft.Address2, mft.CityName as City, mft.State, mft.ZipCode, mft.Phone1, mft.Phone2, mft.GroupID as [Manifest ID], mft.Remarks, mft.ParentID as [Parent ID] " & _
            " ,mft.StartDate, mft.EndDate, mft.SID " & _
            " FROM " & WeightVars.WEIGHTTblPath & "Manifests mft " & _
            " ORDER BY mft.ID "


    Dim SQLSelectUnAssigned As String = _
            "Select mft.rowid, mft.AccountID, mft.ID as SID, c.name as AccountName " & _
            " , mft.CompName as [Location Name], mft.Street, mft.Address2, mft.CityName as City, mft.State, mft.ZipCode, mft.Phone1, mft.Phone2 " & _
            " , mft.Remarks, mft.StartDate, mft.EndDate, mft.OpenTime, mft.CloseTime, mft.DoorKey, mft.BoxKey, mft.InternalRef, mft.AccountRef " & _
            " , mft.TimeFrameID, isnull(tf.Name, '') as [Time Frame], mft.ServiceID, isnull(s.Name, '') as Service, mft.ServiceTypeID, isnull(stp.Name, '') as [Service Type] " & _
            " , mft.PackageID, isnull(p.Name, '') as Package, mft.Charge, mft.DailyAvgChg as [Daily Avg], mft.InfoSID " & _
            " , c.BCycleCode , mft.SchedType, c.NRVNU, mft.NonPrintRemark as [Non Printable Remark], mft.[Subj To Wgt], mft.[Wgt Plan ID]" & _
            " FROM (((((" & ROUTESTblPath & "AccountServices mft LEFT OUTER JOIN " & _
            " " & AppTblPath & "Customer c ON mft.accountid = c.id) LEFT OUTER JOIN " & _
            " " & ROUTESTblPath & "TimeFrames tf ON mft.TimeFrameID = tf.ID) LEFT OUTER JOIN " & _
            " " & AppTblPath & "Services s ON mft.ServiceID = s.ID) LEFT OUTER JOIN " & _
            " " & AppTblPath & "ServiceTypes stp ON mft.ServiceTypeID = stp.ID) " & _
            " LEFT OUTER JOIN " & AppTblPath & "PackageTypes p ON mft.PackageID = p.ID) " & _
            " Where mft.[Subj To Wgt] = 1 and mft.[Wgt Plan ID] = 0 AND (mft.EndDate is NULL OR mft.EndDate > getdate()) " & _
            " ORDER BY mft.ID "


    Dim AcctCriteria As String = " mft.AccountID = "

    Dim HidCols() As String = {"AccountID", "AccountName", "GROUPID"}
    Dim HidCols2() As String = {"AccountID", "AccountName"}

    Dim MeText As String
    Dim dtSet As New DataSet
    Dim dtSetUnAssigned As New DataSet
    Dim dvStates As New DataView
    Dim cmdTrans As SqlCommand
    Dim m_oColumn As Infragistics.Win.UltraWinGrid.UltraGridColumn = Nothing
    Dim delugrow As Infragistics.Win.UltraWinGrid.UltraGridRow

    'Routes Module
    Public xAcctID As String
    Public xSID As String
    Public xLocName As String
    Public xStreet As String
    Public xAddress2 As String
    Public xCity As String
    Public xStateIndex As Integer
    Public xZipcode As String
    Public xPhone1 As String
    Public xPhone2 As String
    Public xStartDate As String
    Dim NewWeightBySID As Boolean

    Private m_iFromCLRowID As Integer

    Private m_sBarcodeOnEntry As String
    Private m_iTrackingLinkRowIdOnEntry As Integer

    Private m_bCalledByWeightPlan As Boolean = False
    Public Property CalledByWeightPlan() As Boolean
        Get
            Return m_bCalledByWeightPlan
        End Get
        Set(ByVal Value As Boolean)
            m_bCalledByWeightPlan = Value
        End Set
    End Property

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
    Friend WithEvents btnDelete As System.Windows.Forms.Button
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
    Friend WithEvents btnWeight As System.Windows.Forms.Button
    Friend WithEvents btnOffice As System.Windows.Forms.Button
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents ManifestName As System.Windows.Forms.TextBox
    Friend WithEvents OWCharge As System.Windows.Forms.TextBox
    Friend WithEvents WeightLimit As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents WeightID As System.Windows.Forms.TextBox
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
    Friend WithEvents btnGroup As System.Windows.Forms.Button
    Friend WithEvents GroupID As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Group As System.Windows.Forms.TextBox
    Friend WithEvents btnSearchPlan As System.Windows.Forms.Button
    Friend WithEvents Radio1 As System.Windows.Forms.RadioButton
    Friend WithEvents PlanSrch As System.Windows.Forms.TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Radio2 As System.Windows.Forms.RadioButton
    Friend WithEvents Remarks As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents LocID As System.Windows.Forms.TextBox
    Friend WithEvents btnParent As System.Windows.Forms.Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents ParentPlan As System.Windows.Forms.TextBox
    Friend WithEvents ParentPlanID As System.Windows.Forms.TextBox
    Friend WithEvents umskStartDate As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents umskEndDate As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents UltraGrid2 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents tbSID As System.Windows.Forms.TextBox
    Friend WithEvents btnNewFromSID As System.Windows.Forms.Button
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Address2 As System.Windows.Forms.TextBox
    Friend WithEvents lblBarcode As System.Windows.Forms.Label
    Friend WithEvents txtBarcode As System.Windows.Forms.TextBox
    Friend WithEvents btnBarcode As System.Windows.Forms.Button
    Friend WithEvents btnDeleteBarcode As System.Windows.Forms.Button
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents mlFromLoc As System.Windows.Forms.TextBox
    Friend WithEvents mlToLoc As System.Windows.Forms.TextBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents dUpDn As System.Windows.Forms.DomainUpDown
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents ugBarcodes As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents cbThirdPartyFormat As System.Windows.Forms.CheckBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnNewFromSID = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
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
        Me.PlanSrch = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.Radio2 = New System.Windows.Forms.RadioButton
        Me.Radio1 = New System.Windows.Forms.RadioButton
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.mlToLoc = New System.Windows.Forms.TextBox
        Me.mlFromLoc = New System.Windows.Forms.TextBox
        Me.Address2 = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.tbSID = New System.Windows.Forms.TextBox
        Me.umskStartDate = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
        Me.umskEndDate = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.ParentPlanID = New System.Windows.Forms.TextBox
        Me.btnParent = New System.Windows.Forms.Button
        Me.Label19 = New System.Windows.Forms.Label
        Me.ParentPlan = New System.Windows.Forms.TextBox
        Me.LocID = New System.Windows.Forms.TextBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Remarks = New System.Windows.Forms.TextBox
        Me.btnGroup = New System.Windows.Forms.Button
        Me.GroupID = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Group = New System.Windows.Forms.TextBox
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
        Me.btnWeight = New System.Windows.Forms.Button
        Me.btnOffice = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.ManifestName = New System.Windows.Forms.TextBox
        Me.OWCharge = New System.Windows.Forms.TextBox
        Me.WeightLimit = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.WeightID = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.OFFICEID = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.OfficeName = New System.Windows.Forms.TextBox
        Me.lblBarcode = New System.Windows.Forms.Label
        Me.txtBarcode = New System.Windows.Forms.TextBox
        Me.btnBarcode = New System.Windows.Forms.Button
        Me.btnDeleteBarcode = New System.Windows.Forms.Button
        Me.btnAcct = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.AcctName = New System.Windows.Forms.TextBox
        Me.dUpDn = New System.Windows.Forms.DomainUpDown
        Me.Label25 = New System.Windows.Forms.Label
        Me.btnPrint = New System.Windows.Forms.Button
        Me.ugBarcodes = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.Splitter1 = New System.Windows.Forms.Splitter
        Me.UltraGrid2 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.cbThirdPartyFormat = New System.Windows.Forms.CheckBox
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.ugBarcodes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnNewFromSID)
        Me.GroupBox1.Controls.Add(Me.btnExit)
        Me.GroupBox1.Controls.Add(Me.btnDelete)
        Me.GroupBox1.Controls.Add(Me.btnNew)
        Me.GroupBox1.Controls.Add(Me.btnSave)
        Me.GroupBox1.Controls.Add(Me.btnEdit)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(0, 532)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1104, 40)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'btnNewFromSID
        '
        Me.btnNewFromSID.Location = New System.Drawing.Point(317, 16)
        Me.btnNewFromSID.Name = "btnNewFromSID"
        Me.btnNewFromSID.Size = New System.Drawing.Size(96, 21)
        Me.btnNewFromSID.TabIndex = 4
        Me.btnNewFromSID.Text = "Ne&w From SID"
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnExit.Location = New System.Drawing.Point(1026, 16)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 21)
        Me.btnExit.TabIndex = 5
        Me.btnExit.Text = "E&xit"
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(230, 16)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 21)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.Visible = False
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
        Me.btnSearchPlan.Location = New System.Drawing.Point(540, 40)
        Me.btnSearchPlan.Name = "btnSearchPlan"
        Me.btnSearchPlan.Size = New System.Drawing.Size(72, 21)
        Me.btnSearchPlan.TabIndex = 8
        Me.btnSearchPlan.Text = "Se&arch"
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.UltraGrid1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel2.Location = New System.Drawing.Point(0, 404)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(1104, 128)
        Me.Panel2.TabIndex = 1
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGrid1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(1104, 128)
        Me.UltraGrid1.TabIndex = 0
        Me.UltraGrid1.Text = "Account Weight-Plans"
        '
        'AcctID
        '
        Me.AcctID.Location = New System.Drawing.Point(120, 6)
        Me.AcctID.Name = "AcctID"
        Me.AcctID.Size = New System.Drawing.Size(64, 20)
        Me.AcctID.TabIndex = 2
        Me.AcctID.Tag = ".AccountID"
        Me.AcctID.Text = ""
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(56, 8)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 16)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Acct. ID:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cbThirdPartyFormat)
        Me.Panel1.Controls.Add(Me.PlanSrch)
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
        Me.Panel1.Controls.Add(Me.dUpDn)
        Me.Panel1.Controls.Add(Me.Label25)
        Me.Panel1.Controls.Add(Me.btnPrint)
        Me.Panel1.Controls.Add(Me.ugBarcodes)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1104, 288)
        Me.Panel1.TabIndex = 0
        '
        'PlanSrch
        '
        Me.PlanSrch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.PlanSrch.Location = New System.Drawing.Point(120, 40)
        Me.PlanSrch.Name = "PlanSrch"
        Me.PlanSrch.Size = New System.Drawing.Size(96, 20)
        Me.PlanSrch.TabIndex = 7
        Me.PlanSrch.Tag = ""
        Me.PlanSrch.Text = ""
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(56, 40)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(64, 16)
        Me.Label15.TabIndex = 6
        Me.Label15.Text = "Plan :"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Radio2
        '
        Me.Radio2.Location = New System.Drawing.Point(32, 40)
        Me.Radio2.Name = "Radio2"
        Me.Radio2.Size = New System.Drawing.Size(16, 11)
        Me.Radio2.TabIndex = 5
        '
        'Radio1
        '
        Me.Radio1.Location = New System.Drawing.Point(32, 8)
        Me.Radio1.Name = "Radio1"
        Me.Radio1.Size = New System.Drawing.Size(16, 11)
        Me.Radio1.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label24)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.mlToLoc)
        Me.GroupBox2.Controls.Add(Me.mlFromLoc)
        Me.GroupBox2.Controls.Add(Me.Address2)
        Me.GroupBox2.Controls.Add(Me.Label22)
        Me.GroupBox2.Controls.Add(Me.tbSID)
        Me.GroupBox2.Controls.Add(Me.umskStartDate)
        Me.GroupBox2.Controls.Add(Me.umskEndDate)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.ParentPlanID)
        Me.GroupBox2.Controls.Add(Me.btnParent)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.ParentPlan)
        Me.GroupBox2.Controls.Add(Me.LocID)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.Remarks)
        Me.GroupBox2.Controls.Add(Me.btnGroup)
        Me.GroupBox2.Controls.Add(Me.GroupID)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.Group)
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
        Me.GroupBox2.Controls.Add(Me.btnWeight)
        Me.GroupBox2.Controls.Add(Me.btnOffice)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.ManifestName)
        Me.GroupBox2.Controls.Add(Me.OWCharge)
        Me.GroupBox2.Controls.Add(Me.WeightLimit)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.WeightID)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.OFFICEID)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.OfficeName)
        Me.GroupBox2.Controls.Add(Me.lblBarcode)
        Me.GroupBox2.Controls.Add(Me.txtBarcode)
        Me.GroupBox2.Controls.Add(Me.btnBarcode)
        Me.GroupBox2.Controls.Add(Me.btnDeleteBarcode)
        Me.GroupBox2.Location = New System.Drawing.Point(0, 64)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(952, 216)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(696, 104)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(48, 16)
        Me.Label24.TabIndex = 117
        Me.Label24.Text = "To :"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(696, 40)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(48, 16)
        Me.Label23.TabIndex = 116
        Me.Label23.Text = "From :"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.TopRight
        '
        'mlToLoc
        '
        Me.mlToLoc.BackColor = System.Drawing.SystemColors.Window
        Me.mlToLoc.ForeColor = System.Drawing.SystemColors.WindowText
        Me.mlToLoc.Location = New System.Drawing.Point(744, 112)
        Me.mlToLoc.Multiline = True
        Me.mlToLoc.Name = "mlToLoc"
        Me.mlToLoc.ReadOnly = True
        Me.mlToLoc.Size = New System.Drawing.Size(200, 70)
        Me.mlToLoc.TabIndex = 115
        Me.mlToLoc.Text = ""
        '
        'mlFromLoc
        '
        Me.mlFromLoc.BackColor = System.Drawing.SystemColors.Window
        Me.mlFromLoc.ForeColor = System.Drawing.SystemColors.WindowText
        Me.mlFromLoc.Location = New System.Drawing.Point(744, 39)
        Me.mlFromLoc.Multiline = True
        Me.mlFromLoc.Name = "mlFromLoc"
        Me.mlFromLoc.ReadOnly = True
        Me.mlFromLoc.Size = New System.Drawing.Size(200, 70)
        Me.mlFromLoc.TabIndex = 114
        Me.mlFromLoc.Text = ""
        '
        'Address2
        '
        Me.Address2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Address2.Location = New System.Drawing.Point(88, 63)
        Me.Address2.Name = "Address2"
        Me.Address2.Size = New System.Drawing.Size(240, 20)
        Me.Address2.TabIndex = 2
        Me.Address2.Tag = ".ADDRESS2"
        Me.Address2.Text = ""
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(564, 40)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(64, 16)
        Me.Label22.TabIndex = 14
        Me.Label22.Text = "Schd. SID:"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'tbSID
        '
        Me.tbSID.Enabled = False
        Me.tbSID.Location = New System.Drawing.Point(628, 40)
        Me.tbSID.Name = "tbSID"
        Me.tbSID.Size = New System.Drawing.Size(64, 20)
        Me.tbSID.TabIndex = 15
        Me.tbSID.Tag = ".SID"
        Me.tbSID.Text = ""
        '
        'umskStartDate
        '
        Me.umskStartDate.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Date
        Me.umskStartDate.InputMask = "mm/dd/yyyy"
        Me.umskStartDate.Location = New System.Drawing.Point(88, 183)
        Me.umskStartDate.Name = "umskStartDate"
        Me.umskStartDate.Size = New System.Drawing.Size(74, 20)
        Me.umskStartDate.TabIndex = 9
        Me.umskStartDate.Tag = ".StartDate........Now"
        Me.umskStartDate.Text = "//"
        '
        'umskEndDate
        '
        Me.umskEndDate.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Date
        Me.umskEndDate.InputMask = "mm/dd/yyyy"
        Me.umskEndDate.Location = New System.Drawing.Point(254, 183)
        Me.umskEndDate.Name = "umskEndDate"
        Me.umskEndDate.Size = New System.Drawing.Size(74, 20)
        Me.umskEndDate.TabIndex = 10
        Me.umskEndDate.Tag = ".ENDDate"
        Me.umskEndDate.Text = "//"
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(190, 186)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(64, 16)
        Me.Label20.TabIndex = 109
        Me.Label20.Text = "End Date:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(24, 186)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(64, 16)
        Me.Label21.TabIndex = 108
        Me.Label21.Text = "Start Date:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ParentPlanID
        '
        Me.ParentPlanID.Location = New System.Drawing.Point(640, 184)
        Me.ParentPlanID.Name = "ParentPlanID"
        Me.ParentPlanID.Size = New System.Drawing.Size(24, 20)
        Me.ParentPlanID.TabIndex = 86
        Me.ParentPlanID.Tag = ".ParentID......Parent ID"
        Me.ParentPlanID.Text = ""
        Me.ParentPlanID.Visible = False
        '
        'btnParent
        '
        Me.btnParent.Location = New System.Drawing.Point(634, 159)
        Me.btnParent.Name = "btnParent"
        Me.btnParent.Size = New System.Drawing.Size(58, 21)
        Me.btnParent.TabIndex = 25
        Me.btnParent.TabStop = False
        Me.btnParent.Text = "Select"
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(360, 160)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(72, 16)
        Me.Label19.TabIndex = 85
        Me.Label19.Text = "Parent :"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ParentPlan
        '
        Me.ParentPlan.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ParentPlan.Location = New System.Drawing.Point(432, 159)
        Me.ParentPlan.Name = "ParentPlan"
        Me.ParentPlan.Size = New System.Drawing.Size(192, 20)
        Me.ParentPlan.TabIndex = 24
        Me.ParentPlan.Tag = ".Parent.view"
        Me.ParentPlan.Text = ""
        '
        'LocID
        '
        Me.LocID.Location = New System.Drawing.Point(8, 32)
        Me.LocID.Name = "LocID"
        Me.LocID.Size = New System.Drawing.Size(24, 20)
        Me.LocID.TabIndex = 82
        Me.LocID.Tag = ""
        Me.LocID.Text = ""
        Me.LocID.Visible = False
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(24, 164)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(64, 16)
        Me.Label18.TabIndex = 81
        Me.Label18.Text = "Remarks :"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Remarks
        '
        Me.Remarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Remarks.Location = New System.Drawing.Point(88, 159)
        Me.Remarks.Name = "Remarks"
        Me.Remarks.Size = New System.Drawing.Size(240, 20)
        Me.Remarks.TabIndex = 8
        Me.Remarks.Tag = ".Remarks"
        Me.Remarks.Text = ""
        '
        'btnGroup
        '
        Me.btnGroup.Location = New System.Drawing.Point(634, 135)
        Me.btnGroup.Name = "btnGroup"
        Me.btnGroup.Size = New System.Drawing.Size(58, 21)
        Me.btnGroup.TabIndex = 23
        Me.btnGroup.TabStop = False
        Me.btnGroup.Text = "Select"
        '
        'GroupID
        '
        Me.GroupID.Location = New System.Drawing.Point(504, 112)
        Me.GroupID.Name = "GroupID"
        Me.GroupID.Size = New System.Drawing.Size(24, 20)
        Me.GroupID.TabIndex = 21
        Me.GroupID.Tag = ".GroupID......Manifest ID"
        Me.GroupID.Text = ""
        Me.GroupID.Visible = False
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(360, 136)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(72, 16)
        Me.Label16.TabIndex = 79
        Me.Label16.Text = "Manifest :"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Group
        '
        Me.Group.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Group.Location = New System.Drawing.Point(432, 135)
        Me.Group.Name = "Group"
        Me.Group.Size = New System.Drawing.Size(192, 20)
        Me.Group.TabIndex = 22
        Me.Group.Tag = ".Manifest.view"
        Me.Group.Text = ""
        '
        'Phone2
        '
        Me.Phone2.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.Phone2.InputMask = "(###)-###-####"
        Me.Phone2.Location = New System.Drawing.Point(238, 135)
        Me.Phone2.Name = "Phone2"
        Me.Phone2.Size = New System.Drawing.Size(90, 20)
        Me.Phone2.TabIndex = 7
        Me.Phone2.Tag = ".PHONE2"
        Me.Phone2.Text = "()--"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(182, 140)
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
        Me.Phone1.Location = New System.Drawing.Point(88, 135)
        Me.Phone1.Name = "Phone1"
        Me.Phone1.Size = New System.Drawing.Size(90, 20)
        Me.Phone1.TabIndex = 6
        Me.Phone1.Tag = ".PHONE1"
        Me.Phone1.Text = "()--"
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(24, 140)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(64, 16)
        Me.Label14.TabIndex = 73
        Me.Label14.Text = "Phone 1:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(0, 16)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 16)
        Me.Label12.TabIndex = 70
        Me.Label12.Text = "Location Name:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBox1
        '
        Me.TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox1.Location = New System.Drawing.Point(88, 15)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(240, 20)
        Me.TextBox1.TabIndex = 0
        Me.TextBox1.Tag = ".COMPNAME......Location Name"
        Me.TextBox1.Text = ""
        '
        'Zipcode
        '
        Me.Zipcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Zipcode.Location = New System.Drawing.Point(228, 111)
        Me.Zipcode.Name = "Zipcode"
        Me.Zipcode.TabIndex = 5
        Me.Zipcode.Tag = ".ZIPCODE"
        Me.Zipcode.Text = ""
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(164, 112)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 16)
        Me.Label3.TabIndex = 67
        Me.Label3.Text = "ZipCode:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'State
        '
        Me.State.Location = New System.Drawing.Point(88, 111)
        Me.State.Name = "State"
        Me.State.Size = New System.Drawing.Size(56, 21)
        Me.State.TabIndex = 4
        Me.State.Tag = ".STATE...STATE.CODE.CODE"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(48, 112)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 16)
        Me.Label4.TabIndex = 68
        Me.Label4.Text = "State:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(48, 86)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(40, 16)
        Me.Label9.TabIndex = 66
        Me.Label9.Text = "City:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'City
        '
        Me.City.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.City.Location = New System.Drawing.Point(88, 87)
        Me.City.Name = "City"
        Me.City.Size = New System.Drawing.Size(240, 20)
        Me.City.TabIndex = 3
        Me.City.Tag = ".CITYNAME......City"
        Me.City.Text = ""
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(32, 40)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(56, 16)
        Me.Label10.TabIndex = 65
        Me.Label10.Text = "Address:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Street
        '
        Me.Street.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Street.Location = New System.Drawing.Point(88, 39)
        Me.Street.Name = "Street"
        Me.Street.Size = New System.Drawing.Size(240, 20)
        Me.Street.TabIndex = 1
        Me.Street.Tag = ".STREET"
        Me.Street.Text = ""
        '
        'ManifestID
        '
        Me.ManifestID.Location = New System.Drawing.Point(328, 40)
        Me.ManifestID.Name = "ManifestID"
        Me.ManifestID.Size = New System.Drawing.Size(24, 20)
        Me.ManifestID.TabIndex = 9
        Me.ManifestID.Tag = ".ID.View"
        Me.ManifestID.Text = ""
        Me.ManifestID.Visible = False
        '
        'btnWeight
        '
        Me.btnWeight.Location = New System.Drawing.Point(504, 87)
        Me.btnWeight.Name = "btnWeight"
        Me.btnWeight.Size = New System.Drawing.Size(58, 21)
        Me.btnWeight.TabIndex = 18
        Me.btnWeight.TabStop = False
        Me.btnWeight.Text = "Select"
        '
        'btnOffice
        '
        Me.btnOffice.Location = New System.Drawing.Point(504, 39)
        Me.btnOffice.Name = "btnOffice"
        Me.btnOffice.Size = New System.Drawing.Size(58, 21)
        Me.btnOffice.TabIndex = 13
        Me.btnOffice.TabStop = False
        Me.btnOffice.Text = "Select"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(328, 16)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(104, 16)
        Me.Label8.TabIndex = 60
        Me.Label8.Text = "Weight-Plan Name:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ManifestName
        '
        Me.ManifestName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.ManifestName.Location = New System.Drawing.Point(432, 15)
        Me.ManifestName.MaxLength = 40
        Me.ManifestName.Name = "ManifestName"
        Me.ManifestName.Size = New System.Drawing.Size(260, 20)
        Me.ManifestName.TabIndex = 11
        Me.ManifestName.Tag = ".NAME"
        Me.ManifestName.Text = ""
        '
        'OWCharge
        '
        Me.OWCharge.Enabled = False
        Me.OWCharge.Location = New System.Drawing.Point(628, 111)
        Me.OWCharge.Name = "OWCharge"
        Me.OWCharge.Size = New System.Drawing.Size(64, 20)
        Me.OWCharge.TabIndex = 20
        Me.OWCharge.Tag = ".owcharge.view"
        Me.OWCharge.Text = ""
        Me.OWCharge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'WeightLimit
        '
        Me.WeightLimit.Enabled = False
        Me.WeightLimit.Location = New System.Drawing.Point(432, 111)
        Me.WeightLimit.Name = "WeightLimit"
        Me.WeightLimit.Size = New System.Drawing.Size(64, 20)
        Me.WeightLimit.TabIndex = 19
        Me.WeightLimit.Tag = ".WeightLimit.view"
        Me.WeightLimit.Text = ""
        Me.WeightLimit.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(556, 111)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(72, 16)
        Me.Label7.TabIndex = 59
        Me.Label7.Text = "O.W.Charge:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(360, 112)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(72, 16)
        Me.Label17.TabIndex = 58
        Me.Label17.Text = "Weight Limit:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(368, 88)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 16)
        Me.Label6.TabIndex = 57
        Me.Label6.Text = "Wgt. ID:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'WeightID
        '
        Me.WeightID.Location = New System.Drawing.Point(432, 87)
        Me.WeightID.Name = "WeightID"
        Me.WeightID.Size = New System.Drawing.Size(64, 20)
        Me.WeightID.TabIndex = 17
        Me.WeightID.Tag = ".Weightid"
        Me.WeightID.Text = ""
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(360, 40)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 16)
        Me.Label11.TabIndex = 55
        Me.Label11.Text = "Center ID:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'OFFICEID
        '
        Me.OFFICEID.Location = New System.Drawing.Point(432, 39)
        Me.OFFICEID.Name = "OFFICEID"
        Me.OFFICEID.Size = New System.Drawing.Size(64, 20)
        Me.OFFICEID.TabIndex = 12
        Me.OFFICEID.Tag = ".officeid......Center ID"
        Me.OFFICEID.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(352, 64)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.TabIndex = 56
        Me.Label1.Text = "Center Name:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'OfficeName
        '
        Me.OfficeName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.OfficeName.Enabled = False
        Me.OfficeName.Location = New System.Drawing.Point(432, 63)
        Me.OfficeName.Name = "OfficeName"
        Me.OfficeName.Size = New System.Drawing.Size(130, 20)
        Me.OfficeName.TabIndex = 16
        Me.OfficeName.Tag = ".OfficeNAME.view.....Wgt Center"
        Me.OfficeName.Text = ""
        '
        'lblBarcode
        '
        Me.lblBarcode.Location = New System.Drawing.Point(688, 16)
        Me.lblBarcode.Name = "lblBarcode"
        Me.lblBarcode.Size = New System.Drawing.Size(56, 16)
        Me.lblBarcode.TabIndex = 110
        Me.lblBarcode.Text = "Barcode:"
        Me.lblBarcode.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtBarcode
        '
        Me.txtBarcode.BackColor = System.Drawing.SystemColors.Window
        Me.txtBarcode.ForeColor = System.Drawing.SystemColors.WindowText
        Me.txtBarcode.Location = New System.Drawing.Point(744, 15)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.ReadOnly = True
        Me.txtBarcode.Size = New System.Drawing.Size(200, 20)
        Me.txtBarcode.TabIndex = 111
        Me.txtBarcode.Text = ""
        '
        'btnBarcode
        '
        Me.btnBarcode.Location = New System.Drawing.Point(824, 190)
        Me.btnBarcode.Name = "btnBarcode"
        Me.btnBarcode.Size = New System.Drawing.Size(58, 21)
        Me.btnBarcode.TabIndex = 112
        Me.btnBarcode.Text = "Assign"
        '
        'btnDeleteBarcode
        '
        Me.btnDeleteBarcode.Location = New System.Drawing.Point(888, 190)
        Me.btnDeleteBarcode.Name = "btnDeleteBarcode"
        Me.btnDeleteBarcode.Size = New System.Drawing.Size(58, 21)
        Me.btnDeleteBarcode.TabIndex = 113
        Me.btnDeleteBarcode.Text = "Remove"
        '
        'btnAcct
        '
        Me.btnAcct.Location = New System.Drawing.Point(538, 8)
        Me.btnAcct.Name = "btnAcct"
        Me.btnAcct.Size = New System.Drawing.Size(75, 21)
        Me.btnAcct.TabIndex = 4
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
        Me.AcctName.TabIndex = 3
        Me.AcctName.Tag = ".AccountNAME.view"
        Me.AcctName.Text = ""
        '
        'dUpDn
        '
        Me.dUpDn.Location = New System.Drawing.Point(824, 40)
        Me.dUpDn.Name = "dUpDn"
        Me.dUpDn.Size = New System.Drawing.Size(49, 20)
        Me.dUpDn.Sorted = True
        Me.dUpDn.TabIndex = 160
        Me.dUpDn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(752, 40)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(72, 16)
        Me.Label25.TabIndex = 159
        Me.Label25.Text = "# Of Copies:"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(880, 40)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(58, 20)
        Me.btnPrint.TabIndex = 118
        Me.btnPrint.Text = "Print"
        '
        'ugBarcodes
        '
        Me.ugBarcodes.Location = New System.Drawing.Point(960, 80)
        Me.ugBarcodes.Name = "ugBarcodes"
        Me.ugBarcodes.Size = New System.Drawing.Size(136, 166)
        Me.ugBarcodes.TabIndex = 1
        '
        'Splitter1
        '
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Splitter1.Location = New System.Drawing.Point(0, 401)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(1104, 3)
        Me.Splitter1.TabIndex = 2
        Me.Splitter1.TabStop = False
        '
        'UltraGrid2
        '
        Me.UltraGrid2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGrid2.Location = New System.Drawing.Point(0, 288)
        Me.UltraGrid2.Name = "UltraGrid2"
        Me.UltraGrid2.Size = New System.Drawing.Size(1104, 113)
        Me.UltraGrid2.TabIndex = 1
        Me.UltraGrid2.Tag = "UnAssigned"
        Me.UltraGrid2.Text = "UnAssigned SIDs"
        '
        'cbThirdPartyFormat
        '
        Me.cbThirdPartyFormat.Location = New System.Drawing.Point(944, 40)
        Me.cbThirdPartyFormat.Name = "cbThirdPartyFormat"
        Me.cbThirdPartyFormat.Size = New System.Drawing.Size(152, 24)
        Me.cbThirdPartyFormat.TabIndex = 162
        Me.cbThirdPartyFormat.Text = "Print in 3rd Party Format"
        '
        'WeightPlan
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.AutoScroll = True
        Me.ClientSize = New System.Drawing.Size(1104, 572)
        Me.Controls.Add(Me.UltraGrid2)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "WeightPlan"
        Me.Tag = "Manifests"
        Me.Text = "Account Weight-Plan Setup"
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.ugBarcodes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub ManifestSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Int32
        Dim dtaStates As New SqlDataAdapter
        Dim MinWinSize As System.Drawing.Size

        AddHandler Me.Activated, AddressOf Form_Activated
        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = WeightVars.WEIGHTTblPath & Me.Tag
            End If
        End If

        ' Routes Module
        NewWeightBySID = False

        Me.CenterToScreen()

        Me.KeyPreview = True
        MeText = Me.Text

        ' Set each control's length based on DB size
        SetupCtrlsLength(Me, WeightVars.WEIGHTDBName, WEIGHTDBUser, WEIGHTDBPass)

        AddHandler State.KeyPress, AddressOf CBO_Search
        AddHandler State.KeyUp, AddressOf CBO_KeyUp
        AddHandler State.Leave, AddressOf CBO_Leave
        AddHandler Me.KeyUp, AddressOf Form_KeyUp
        AddHandler umskStartDate.Validating, AddressOf umskDate_Validating
        AddHandler umskEndDate.Validating, AddressOf umskDate_Validating

        AddHandler dUpDn.KeyPress, AddressOf Value_Int_KeyPress
        dUpDn.Sorted = False
        For i = 999 To 1 Step -1
            dUpDn.Items.Add(i)
        Next
        dUpDn.Text = "1"
        dUpDn.DownButton()

        FillCombo(State, "CA")

        Group_EnDis(False)
        Radio1.Checked = True

        ' Routes Module
        If ManifestID.Text.Trim <> "" Then
            Dim localConn As New SqlConnection(strConnection)
            FormLoadByID(Val(ManifestID.Text), localConn, "")
            localConn.Close()
            localConn = Nothing
        End If
    End Sub

    Private Sub UltraGrid1_AfterRowActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraGrid1.AfterRowActivate
        'txtBarcode.Text = ""
        'mlFromLoc.Text = ""
        'mlToLoc.Text = ""

        FormLoadFromGrid(Me, sender)

        ' Populate TrackingLink Related fields
        Dim tl As New TrackingLink
        txtBarcode.Text = tl.GetBarcodeForWeightPlan(CInt(ManifestID.Text))
        DisplayBarcodeDetails()

        RecordBarcodeInfo()

        ' Populate Barcodes UltraGrid
        Dim RowId As Integer = UltraGrid1.ActiveRow.Cells(0).Text
        DisplayBarcodesList(RowId)

    End Sub

    Private Sub UltraGrid1_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraGrid1.EnabledChanged

        If sender.enabled Then

            FormLoadFromGrid(Me, sender)

            ' Populate TrackingLink Related fields
            Dim tl As New TrackingLink
            txtBarcode.Text = tl.GetBarcodeForWeightPlan(CInt(ManifestID.Text))
            DisplayBarcodeDetails()

        End If

    End Sub
    'Karina commented Aly's original code and added Btn_En()
    Private Sub Group_EnDis(ByVal status As Boolean)
        'Aly's 4 lines - original code
        ''Panel1.Enabled = status
        'GroupBox2.Enabled = status
        'btnSave.Enabled = status
        'btnSave.Text = "&Save"


        GroupBox2.Enabled = status
        btnSave.Enabled = status
        'UltraGrid1.Enabled = Not status
        btnDelete.Enabled = Not status
        Btn_En(status)
    End Sub
    Private Sub Btn_En(ByVal status As Boolean)
        btnSave.Enabled = status
        btnSave.Text = "&Save"
        If status = True Then 'Enable Editing
            If btnEdit.Text.ToUpper = "&CANCEL" Then
                btnNew.Enabled = False
            Else
                btnEdit.Enabled = False
            End If
        Else 'End Editing
            btnNew.Enabled = True
            btnEdit.Enabled = True
            btnEdit.Text = "&Edit"
            btnNew.Text = "&New"
        End If
    End Sub
    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim cnt As Integer
        Dim ID As Integer

        If AcctID.Text.Trim = "" And OFFICEID.Text.Trim = "" And WeightID.Text.Trim = "" Then
            MessageBox.Show("Account, Office (Center ID) and Weight-Breakdown are not selected.")
        End If
        If AcctID.Text.Trim = "" And OFFICEID.Text.Trim = "" Then
            MessageBox.Show("Account and Office (Center ID) are not selected.")
        End If
        If AcctID.Text.Trim = "" And WeightID.Text.Trim = "" Then
            MessageBox.Show("Account and Weight-Breakdown are not selected.")
        End If
        If OFFICEID.Text.Trim = "" And WeightID.Text.Trim = "" Then
            MessageBox.Show("Office (Center ID) and Weight-Breakdown are not selected.")
        End If
        If AcctID.Text.Trim = "" Then
            MessageBox.Show("Account is not selected.")
            Exit Sub
        End If
        If OFFICEID.Text.Trim = "" Then
            MessageBox.Show("Office (Center ID) is not selected.")
            Exit Sub
        End If
        If WeightID.Text.Trim = "" Then
            MessageBox.Show("Weight-Breakdown is not selected.")
            Exit Sub
        End If


        If EditForm(Me, SQLEdit, EditAction.ENDEDIT, cmdTrans, " Where ID = " & ManifestID.Text) Then
            Dim row As DataRow
            Dim dtA As New SqlDataAdapter
            Dim ugrow As Infragistics.Win.UltraWinGrid.UltraGridRow

            'ID = Val(ManifestID.Text)
            'ID = OFFICEID.Text
            If btnEdit.Text = "&Cancel" Then
                ID = UltraGrid1.Rows.IndexOf(UltraGrid1.ActiveRow)
            End If
            SaveBarcode()
            LoadData()
            If btnEdit.Text.ToUpper = "&CANCEL" Then
                UltraGrid1.ActiveRow = UltraGrid1.Rows.GetRowAtVisibleIndex(ID)
                UltraGrid1.ActiveRow.Selected = True
                UltraGrid1.ActiveRow.Activate()
                UltraGrid1.ActiveRow.Update()
                UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ToggleRowSel)
            Else
                UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.LastRowInBand)
            End If
            'Me.Text = MeText & " -- Record Updated."
            ''PopulateDataset2(dtA, dtSet, SQLSelect)
            ''FillUltraGrid(UltraGrid1, dtSet, 1)
            '''row = dtSet.Tables(0).Rows.Find(ID)
            'UltraGrid1.ActiveRow.Cells(0) = row.Item(0) 'Infragistics.Win.UltraWinGrid.UltraGridRow)
            'sender.text = "&New"
            UltraGrid1.Enabled = True
            UltraGrid2.Enabled = True
            btnEdit.Text = "&Edit"
            btnNew.Text = "&New"
            Group_EnDis(False)
            UltraGrid1.Focus()
            'UltraGrid1.Refresh()
            If Not Me.Owner Is Nothing And NewWeightBySID = True Then
                NewWeightBySID = False
                If TypeOf Me.Owner Is AcctSvcSchedule Then
                    Dim frm As AcctSvcSchedule
                    frm = Me.Owner
                    If Not frm Is Nothing Then
                        If frm.AcctID.Text = Me.AcctID.Text And frm.SrvcID.Text = Me.tbSID.Text Then
                            frm.WgtPlanID.Text = ManifestID.Text
                            frm.Validate()
                        End If
                    End If
                    frm = Nothing
                End If

                'frm.Validate()
                'Me.Owner.wgtplanid.text = ManifestID.Text
            End If
            ' Routes Module
            If tbSID.Text.Trim <> "" Then
                ' Does it need to update AccountServices Each Time??
                Dim UpdAcctSvcs As String = "Update " & ROUTESTblPath & "AccountServices Set [Wgt Plan ID] = " & ManifestID.Text & " where AccountID = " & AcctID.Text & " AND ID = " & tbSID.Text

                If ExecuteQuery(UpdAcctSvcs) = False Then
                    MsgBox("Failure on updating Account Service Schedules.")
                End If
            End If

        End If

    End Sub
    Private Sub SaveBarcode()
        Try
            'Make sure the barcode actually changed
            If (txtBarcode.Text <> String.Empty) And (txtBarcode.Text <> m_sBarcodeOnEntry) Then

                Dim tl As New TrackingLink

                ' Delete the previouis one, if it was not empty
                If m_sBarcodeOnEntry <> String.Empty Then
                    If (tl.Delete(m_iTrackingLinkRowIdOnEntry) = False) And (tl.HasError = True) Then
                        MsgBox(tl.ErrorMessage)
                        Exit Sub
                    End If
                End If

                ' Check to see if the new link has ever been active before
                tl.Clear()
                tl.WeightPlanID = CInt(ManifestID.Text)
                tl.CourierLabelID = m_iFromCLRowID

                ' If it has, undelete it, otherwise insert it
                If (tl.SelectInactive() = True) Then
                    tl.Undelete(tl.RowId)
                ElseIf tl.HasError = False Then
                    tl.Insert()
                Else
                    MsgBox(tl.ErrorMessage)
                    Exit Sub
                End If

            End If

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        ' Lock Records
        If ManifestID.Text.Trim = "" Then Exit Sub
        If btnNew.Text = "&Cancel" Then
            MessageBox.Show("You are in 'New' mode. Cancel or Save your current job first.")
            Exit Sub
        End If

        If sender.text.toupper = "&EDIT" Then
            If EditForm(Me, PrepSelectQuery(SQLEdit, " Where ID = " & ManifestID.Text), EditAction.START, cmdTrans) Then
                UltraGrid1.Enabled = False
                UltraGrid2.Enabled = False
                sender.text = "&Cancel" 'Karina changed place with Group_EnDis()
                Group_EnDis(True)
                TextBox1.Focus()
            End If
        Else
            If EditForm(Me, SQLSelect, EditAction.CANCEL, cmdTrans) Then
                UltraGrid1.Enabled = True
                UltraGrid2.Enabled = True
                sender.text = "&Edit" 'Karina changed palce with Group_EnDis()
                Group_EnDis(False)
                'FormLoad(Me, dvCompany)
                'Changes were Cancelled, so Restore old barcode if applicable
                RestoreBarcode()
            End If
        End If
    End Sub
    'Karina commented/changed
    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        'If Not cmdTrans Is Nothing Then
        '    If EditForm(Me, PrepSelectQuery(SQLEdit, " Where ID = " & ManifestID.Text), EditAction.CANCEL, cmdTrans) Then
        '        UltraGrid1.Enabled = True
        '        UltraGrid2.Enabled = True
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
        If sender.text = "&New" Then
            UltraGrid1.Enabled = False
            UltraGrid2.Enabled = False
            ClearForm(GroupBox2)
            sender.text = "&Cancel" 'Karina changed place with Group_EnDis()
            Group_EnDis(True)
            TextBox1.Focus()
        Else
            sender.text = "&New"
            NewWeightBySID = False
            UltraGrid1.Enabled = True
            UltraGrid2.Enabled = True
            Group_EnDis(False)
            UltraGrid1.Focus()

        End If
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim dsData As DataSet
        Dim ID As Integer
        Dim row As DataRow
        Dim BandIndex As Integer
        Dim TempSID As String

        On Error GoTo ErrTrap

        If UltraGrid1.Selected.Rows.Count = 0 Then
            MessageBox.Show("No Record is selected")
            Exit Sub
        End If

        'Routes Module
        TempSID = tbSID.Text

        UltraGrid1.DeleteSelectedRows()

        'Routes Module
        If ExecuteQuery("Update " & ROUTESTblPath & "AccountServices Set [Wgt Plan ID] = 0 where AccountID = " & AcctID.Text & " AND ID = " & TempSID) = False Then
            MsgBox("Failed to Update Weight Info for SID = " & TempSID)
        End If

        ''If UpdateDbFromDataSet(dtSet, SQLSelectDel & " Where mft.ID = " & ManifestID.Text) <= 0 Then
        ''    MsgBox("btnDelete_Click: Error!")
        ''    Exit Sub
        ''End If


        'ID = UltraGrid1.ActiveRow.Cells(0).Value
        'row = dtSet.Tables(0).Rows.Find(ID)
        'row.Delete()

        'UltraGrid1.ActiveRow.Delete()
        'dsData = UltraGrid1.DataSource
        Exit Sub
ErrTrap:
        MsgBox("Error: " & Err.Description)

    End Sub

    Private Sub Value_Int_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles AcctID.KeyPress
        If IsNumeric(e.KeyChar) = False And Asc(e.KeyChar) <> Keys.Back Then
            e.Handled = True
        End If
    End Sub

    Private Sub AcctID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles AcctID.Leave
        Dim dbRow As DataRow
        If sender.Modified = False Then Exit Sub
        If btnNew.Text.ToUpper <> "&NEW" Then Exit Sub
        If sender.Text.Trim = "" Then
            ClearForm(Me)
            UltraGrid1.DataSource = Nothing
            'ClearForm(GroupBox2) 'Karina cleans the form after changing the name
            'UltraGrid2.DataSource = Nothing 'Karina cleans the grid after changing the name
            Exit Sub
        End If
        sender.modified = False

        If Val(sender.text) > 0 Then
            If ReturnRowByID(Val(sender.Text), dbRow, AppTblPath & "CUSTOMER", " Status = 1") = False Then
                If ReturnRowByID(Val(sender.Text), dbRow, AppTblPath & "CUSTOMER", " Status = 0") = False Then
                    MsgBox("Account Does Not Exist")
                Else
                    MsgBox("Account is Inactive")
                End If
                sender.Focus()
                Exit Sub
            End If
            ClearForm(GroupBox2)
            AcctName.Text = dbRow.Item("NAME")
            sender.Modified = False
            LoadData()
        End If

    End Sub

    Private Sub LoadData()

        Try

            Dim dtAdapter As SqlDataAdapter
            If Not UltraGrid1.DataSource Is Nothing Then
                'UGSaveLayout(Me, UltraGrid1, 1)
            End If

            ClearForm(GroupBox2) 'Karina, clean GropBox2 when reload, because stays the same if empty
            dtSet.Tables.Clear()
            PopulateDataset2(dtAdapter, dtSet, PrepSelectQuery(SQLSelect, AcctCriteria & AcctID.Text))
            PopulateDataset2(dtAdapter, dtSet, PrepSelectQuery(SQLSelectUnAssigned, AcctCriteria & AcctID.Text), True)

            If dtSet.Tables(0).Rows.Count = 0 Then
                btnSave.Text = "&Save"
            Else
                btnSave.Text = "&Update"
            End If
            FillUltraGrid(UltraGrid1, dtSet, 0, HidCols)
            UGLoadLayout(Me, UltraGrid1, 1)
            UltraGrid1.DisplayLayout.GroupByBox.Hidden = False
            UltraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy

            FillUltraGrid(UltraGrid2, dtSet, 0, HidCols2, 1)
            UGLoadLayout(Me, UltraGrid2, 2)
            UltraGrid2.DisplayLayout.GroupByBox.Hidden = False
            UltraGrid2.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy

            ' Populate TrackingLink Related fields
            Dim tl As New TrackingLink
            txtBarcode.Text = tl.GetBarcodeForWeightPlan(CInt(ManifestID.Text))
            DisplayBarcodeDetails()

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Sub

    Private Sub OfficeID_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OFFICEID.Leave
        Dim dbRow As DataRow

        If sender.Modified = False Then Exit Sub
        If sender.Text.Trim = "" Then Exit Sub
        sender.modified = False

        If Val(sender.text) > 0 Then
            If ReturnRowByID(Val(sender.Text), dbRow, AppTblPath & "ServiceOffices") = False Then Exit Sub
            OfficeName.Text = dbRow.Item("NAME")
            sender.Modified = False
        End If

    End Sub

    Private Sub WeightID_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WeightID.Leave
        Dim dbRow As DataRow

        If sender.Modified = False Then Exit Sub
        If sender.Text.Trim = "" Then Exit Sub
        sender.modified = False

        If Val(sender.text) > 0 Then
            If ReturnRowByID(Val(sender.Text), dbRow, WeightVars.WEIGHTTblPath & "WeightBreakdown") = False Then
                MessageBox.Show("No records found matching the ID.")
                Exit Sub
            End If
            WeightLimit.Text = Format(Val(dbRow.Item("Weightlimit")), "#0.00")
            OWCharge.Text = Format(Val(dbRow.Item("OWcharge")), "#0.00")
            sender.Modified = False
        End If

    End Sub

    Private Sub btnAcct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcct.Click
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow

        ''Before to load - clear everything, Karina
        'ClearForm(Me)
        'UltraGrid1.DataSource = Nothing

        SelectSQL = "Select * FROM " & AppTblPath & "Customer Where Status = 1 order by Name"

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

        SelectSQL = "Select * FROM " & AppTblPath & "ServiceOffices order by Name"
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
                MsgBox("SQL_Error: " & osqlexception.Message)
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

    Private Sub btnWeight_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWeight.Click
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim Title As String

        SelectSQL = "Select * FROM " & WeightVars.WEIGHTTblPath & "WeightBreakdown order by ID"
        Title = "Weight Breakdowns"

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
                    WeightLimit.Text = Format(Val(ugRow.Cells("WeightLimit").Text), "#0.00")
                    WeightID.Text = ugRow.Cells("ID").Text
                    OWCharge.Text = Format(Val(ugRow.Cells("OWCharge").Text), "#0.00")
                    Srch = Nothing
                End If
            End Try
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

        SelectSQL = "Select * FROM " & WeightVars.WEIGHTTblPath & "WeightPlanGroups order by Name"
        Title = "Manifests"

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
                    GroupID.Text = ugRow.Cells("ID").Text
                    Group.Text = ugRow.Cells("Name").Text
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

        Dim CitiesSQL As String = "Select ID, Name as City, Zipcode, StateCode as State FROM " & AppTblPath & "City " '& " where StateCode = '" & State.SelectedValue & "'" '" AND zipcode = '" & Zipcode.Text & "'"
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
                dvCities1.Table = dsCity.Tables(AppTblPath & "City")
                If dvCities1.Table.Rows.Count > 0 Then
                    gZipcode.Text = sender.Text.ToString
                    gCity.Text = dvCities1.Table.Rows(0).Item("City")
                    gPhone.Focus()
                    gState.SelectedValue = dvCities1.Table.Rows(0).Item("State")
                Else
                    MsgBox("Zipcode not found!", MsgBoxStyle.OKOnly, MeText)
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

        TypeAhead(sender, e, AppTblPath & "City", "Name", "AND StateCode = '" & GetNextControl(sender, True).Text & "'")
        'sender.modified = True
    End Sub

    Private Sub Zipcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Zipcode.KeyPress
        If IsNumeric(e.KeyChar) = False And Asc(e.KeyChar) <> Keys.Back Then
            e.Handled() = True
        End If
    End Sub

    'Private Sub Phone1_MaskValidationError(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinMaskedEdit.MaskValidationErrorEventArgs) Handles Phone1.MaskValidationError, Phone2.MaskValidationError, umskEndDate.MaskValidationError, umskStartDate.MaskValidationError
    '    Dim NextCtrl As System.Windows.Forms.Control
    '    Dim Str As String
    '    Str = sender.GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw)
    '    If Str = "" Then
    '        e.RetainFocus = False
    '    End If
    'End Sub

    Private Sub Phone1_MaskValidationError(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinMaskedEdit.MaskValidationErrorEventArgs) Handles Phone1.MaskValidationError, Phone2.MaskValidationError, umskEndDate.MaskValidationError, umskStartDate.MaskValidationError
        Dim NextCtrl As System.Windows.Forms.Control
        Dim Str As String
        Str = sender.GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw)

        If Str = "" Then
            e.RetainFocus = False
        End If
        If sender.name = "umskOpenTime" Or sender.name = "umskCloseTime" Then
            Str = sender.GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw)
            Str = Str.PadLeft(2, "0").PadRight(4, "0")
            If Val(Str) / 100 < 24 And Val(Str) Mod 100 < 60 Then
                e.RetainFocus = False
                sender.Value = Str
            End If
        End If


    End Sub



    Private Sub btnSearchPlan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearchPlan.Click
        Dim Qry As String

        Dim dtAdapter As SqlDataAdapter
        Dim dtSet As New DataSet

        If PlanSrch.Text.Trim = "" Then
            MsgBox("Nothing specified to search.")
            Exit Sub
        End If

        Qry = "Select mft.AccountID, c.Name  from " & WeightVars.WEIGHTTblPath & "Manifests mft, " & AppTblPath & "Customer c where mft.AccountID = c.ID and mft.Name like " & "'" & PlanSrch.Text & "%'"

        PopulateDataset2(dtAdapter, dtSet, Qry)
        If dtSet.Tables(0).Rows.Count <> 0 Then
            AcctID.Text = dtSet.Tables(0).Rows(0).Item("AccountID")
            AcctName.Text = dtSet.Tables(0).Rows(0).Item("Name")
            LoadData()
            Radio1.Checked = True
        Else
            MsgBox("No Results Found.")
        End If
        dtSet = Nothing
        dtAdapter = Nothing




    End Sub

    Private Sub Radio1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radio1.CheckedChanged
        If sender.Checked = True Then
            AcctID.Enabled = True
            PlanSrch.Enabled = False
            PlanSrch.Text = ""
        End If
    End Sub

    Private Sub Radio2_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Radio2.CheckedChanged
        If sender.Checked = True Then
            AcctID.Enabled = False
            PlanSrch.Enabled = True
            PlanSrch.Text = ""
            ClearForm(Me)
            UltraGrid1.DataSource = Nothing
            PlanSrch.Focus()
        End If
    End Sub

    Private Sub PlanSrch_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles PlanSrch.KeyUp
        TypeAhead(sender, e, WeightVars.WEIGHTTblPath & "Manifests", "Name", "")
    End Sub
    'Karina added PlanSrch_Leave function to display data on leave
    Private Sub PlanSrch_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles PlanSrch.Leave
        Dim row As DataRow
        If PlanSrch.Text.Trim = "" Then
            PlanSrch.Text = ""
            'ElseIf SearchOnLeave(sender, PlanSrch, WEIGHTTblPath & "Manifests", "Name", "ID", "*", "Manifests") Then
        ElseIf SearchOnLeave(sender, PlanSrch, WeightVars.WEIGHTTblPath & "Manifests", "Name", "Name", "*", "Manifests") Then
            If ReturnRowByName(PlanSrch.Text, row, WeightVars.WEIGHTTblPath & "Manifests") Then
                'ParentPlan.Text = row("Name")
                'row.Table.DataSet = Nothing
                row = Nothing
            End If
        End If
    End Sub
    'Karina added ReturnRowByName function to let the PlanSrch field display grid with data
    Public Function ReturnRowByName(ByVal Name As String, ByRef dbRow As DataRow, ByVal dbTableName As String, Optional ByVal Condition As String = "", Optional ByVal NameFldName As String = "Name", Optional ByVal AltQuery As String = "") As Boolean
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet

        dbRow = Nothing
        ReturnRowByName = False
        If AltQuery = "" Then
            PopulateDataset2(dtAdapter, dtSet, PrepSelectQuery("Select * from " & dbTableName & " Where " & NameFldName & " = '" & Name & "'", Condition))
        Else
            PopulateDataset2(dtAdapter, dtSet, AltQuery)
        End If

        If dtSet.Tables(0).Rows.Count > 0 Then
            dbRow = dtSet.Tables(0).NewRow
            dbRow = dtSet.Tables(0).Rows(0)
            ReturnRowByName = True
            dtSet = Nothing
            dtAdapter = Nothing
        Else
            dtSet = Nothing
            dtAdapter = Nothing
        End If


    End Function

    Protected Overrides Sub Finalize()
        MyBase.Finalize()
    End Sub

    Private Sub Group_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Group.KeyUp

        TypeAhead(sender, e, WeightVars.WEIGHTTblPath & "WeightPlanGroups", "Name", "")
        'sender.modified = True
    End Sub

    Private Sub Group_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Group.Leave
        'On Error GoTo ErrTrap
        Dim daCity As New SqlDataAdapter
        Dim dsCity As New DataSet
        Dim dvCities1 As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim WGTGrpSQL As String = "Select * FROM " & WeightVars.WEIGHTTblPath & "WeightPlanGroups "

        Dim CitiesSQL As String = "Select ID, Name as City, Zipcode, StateCode as State FROM " & AppTblPath & "City " '& " where StateCode = '" & State.SelectedValue & "'" '" AND zipcode = '" & Zipcode.Text & "'"
        HasErr = False
        If sender.Modified Then
            If IsNumeric(sender.Text) Then ' GroupID
                WGTGrpSQL = WGTGrpSQL & " where ID = '" & sender.Text & "'"
                PopulateDataset2(daCity, dsCity, WGTGrpSQL)
                dvCities1.Table = dsCity.Tables("WeightPlanGroups")
                If dvCities1.Table.Rows.Count > 0 Then
                    GroupID.Text = sender.Text.ToString
                    Group.Text = dvCities1.Table.Rows(0).Item("Name")
                Else
                    MsgBox("ID not found!", MsgBoxStyle.OKOnly, MeText)
                    Group.ResetText()
                    Group.Focus()
                End If
            Else 'Blank or City Name
                If sender.text.trim() = "" Then
                    GroupID.Text = ""
                    Exit Sub
                End If
                If sender.Text.StartsWith("?") Then
                    sender.text = sender.text.substring(1)
                End If
                WGTGrpSQL = WGTGrpSQL & " where Name like '" & sender.text & "%' Order by Name"
                PopulateDataset2(daCity, dsCity, WGTGrpSQL)
                dvCities1.Table = dsCity.Tables(0) ' "WeightPlanGroups"
                If dvCities1.Table.Rows.Count > 0 Then
                    If dvCities1.Table.Rows.Count > 1 Then
                        Dim Srch As New SearchListings
                        Srch.dsList = dsCity

                        Srch.UltraGrid1.Text = "Manifests beginning with '" & sender.text & "' in '" & GetNextControl(sender, True).Text & "'"
                        Srch.Text = "Manifests"
                        Srch.ShowDialog()
                        If Srch.DialogResult <> DialogResult.OK Then
                            sender.focus()
                            Exit Sub
                        End If
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
                                Group.Text = ugRow.Cells("Name").Text
                                GroupID.Text = ugRow.Cells("ID").Text
                                Srch = Nothing
                            End If
                        End Try
                    Else ' Just one record found
                        Group.Text = dvCities1(0).Item("Name") 'ugRow.Cells("City").Text
                        GroupID.Text = dvCities1(0).Item("ID") ' ugRow.Cells("Zipcode").Text
                    End If
                Else
                    MsgBox("No matching Manifest found!", MsgBoxStyle.OKOnly, MeText)
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

    Private Sub TextBox1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles TextBox1.Leave
        Dim row As DataRow
        If sender.text.trim = "" Then
            LocID.Text = ""
            sender.text = ""
        ElseIf SearchOnLeave(sender, LocID, AppTblPath & "Address Addr", , , "*", "Locations") Then 'RapidTblPath & 
            If ReturnRowByID(LocID.Text, row, AppTblPath & "Address") Then ' RapidTblPath
                Street.Text = row("Street")
                Address2.Text = row("Address2")
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

        TypeAhead(sender, e, AppTblPath & "Address", "Name", "") ' RapidTblPath & 
        'sender.modified = True
    End Sub

    Private Sub UltraGrid1_BeforeRowsDeleted(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeRowsDeletedEventArgs) Handles UltraGrid1.BeforeRowsDeleted
        delugrow = UltraGrid1.Selected.Rows(0)
        delugrow = delugrow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Previous)
    End Sub


    Private Sub btnParent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnParent.Click
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim Title As String

        SelectSQL = "Select * FROM " & WeightVars.WEIGHTTblPath & "Manifests order by Name"
        Title = "Weight Plans"

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
                    ParentPlanID.Text = ugRow.Cells("ID").Text
                    ParentPlan.Text = ugRow.Cells("Name").Text
                    Srch = Nothing
                End If
            End Try
        End If

    End Sub

    Private Sub ParentPlan_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles ParentPlan.KeyUp
        TypeAhead(sender, e, WeightVars.WEIGHTTblPath & "Manifests", "Name", "")

    End Sub

    Private Sub ParentPlan_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ParentPlan.Leave
        Dim row As DataRow
        If ParentPlan.Text.Trim = "" Then
            ParentPlanID.Text = ""
            ParentPlan.Text = ""
        ElseIf SearchOnLeave(sender, ParentPlanID, WeightVars.WEIGHTTblPath & "Manifests", , , "*", "Manifests") Then
            If ReturnRowByID(ParentPlanID.Text, row, WeightVars.WEIGHTTblPath & "Manifests") Then
                'ParentPlan.Text = row("Name")
                'row.Table.DataSet = Nothing
                row = Nothing
            End If
        End If
    End Sub


    Private Sub UltraGrid1_AfterRowsDeleted(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraGrid1.AfterRowsDeleted

        Dim Cmd As SqlCommand
        Dim HasErr As Boolean

        Dim SQLString As String = "Insert into " & WeightVars.WEIGHTTblPath & "WeightPlanTrash("
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
            MsgBox("SQL_Error: " & osqlexception.Message)
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

    Private Function FormLoadByID(ByVal ID As Int32, ByVal Connection As SqlClient.SqlConnection, ByVal SQLString As String)

        ' Routes Module 

        Dim dbrow As DataRow
        Dim dvData1 As New DataView
        Dim SrchInfo As New clsSearchInfo

        If ReturnRowByID(ID, dbrow, Me.Tag, "", "ID") = True Then
            NewWeightBySID = False
            Me.AcctID.Text = dbrow("AccountID")
            ClearForm(GroupBox2)
            AcctName.Text = dbrow.Item("NAME")
            AcctID.Modified = False
            If btnNew.Text.ToUpper <> "&NEW" Then Exit Function
            LoadData()

            SrchInfo.searchString = ID
            SrchInfo.searchDirection = GlobalVars.SearchDirectionEnum.All
            SrchInfo.searchContent = GlobalVars.SearchContentEnum.WholeField
            SrchInfo.matchCase = False
            SrchInfo.lookIn = "ID"

            SearchGrid(Me, "ID", Me.UltraGrid1, SrchInfo)
        Else
            NewWeightBySID = True
            Me.AcctID.Text = xAcctID
            If Val(AcctID.Text) > 0 Then
                If ReturnRowByID(Val(AcctID.Text), dbrow, AppTblPath & "CUSTOMER", " Status = 1") = False Then
                    If ReturnRowByID(Val(AcctID.Text), dbrow, AppTblPath & "CUSTOMER", " Status = 0") = False Then
                        MsgBox("Account Does Not Exist")
                    Else
                        MsgBox("Account is Inactive")
                    End If
                    AcctID.Focus()
                    Exit Function
                End If
                ClearForm(GroupBox2)
                AcctName.Text = dbrow.Item("NAME")
                AcctID.Modified = False
                If btnNew.Text.ToUpper <> "&NEW" Then Exit Function
                LoadData()
                If btnNew.Text = "&New" Then
                    UltraGrid1.Enabled = False
                    UltraGrid2.Enabled = False
                    ClearForm(GroupBox2)
                    btnNew.Text = "&Cancel" 'Karina changed place with Group_EnDis()
                    Group_EnDis(True)
                    TextBox1.Text = xLocName
                    tbSID.Text = xSID
                    Street.Text = xStreet
                    Address2.Text = xAddress2
                    State.SelectedIndex = xStateIndex
                    City.Text = xCity
                    Zipcode.Text = xZipcode
                    Phone1.Text = xPhone1
                    Phone2.Text = xPhone2
                    umskStartDate.Text = xStartDate
                    TextBox1.Focus()
                End If

            End If

        End If
        dbrow = Nothing

        ''Dim dtAdapter As New SqlDataAdapter
        ''Dim dtSet As New DataSet

        ''dbrow = Nothing

        ''PopulateDataset2(dtAdapter, dtSet, SQLString)

        ''If dtSet.Tables(0).Rows.Count > 0 Then
        ''    dbrow = dtSet.Tables(0).NewRow
        ''    dbrow = dtSet.Tables(0).Rows(0)
        ''    dvData1.Table = dtSet.Tables(0)
        ''    FormLoad(Me, dvData1)
        ''    dtSet = Nothing
        ''    dtAdapter = Nothing
        ''Else
        ''    dtSet = Nothing
        ''    dtAdapter = Nothing
        ''End If

    End Function

    Private Sub umskEndDate_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles umskEndDate.Leave

        If umskEndDate.GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw) <> "" Then
            If TextBox1.Text.Substring(0, 1) <> "*" Then
                TextBox1.Text = "*" & TextBox1.Text
            End If
        Else
            If TextBox1.Text.Substring(0, 1) = "*" Then
                TextBox1.Text = TextBox1.Text.Substring(1)
            End If
        End If
    End Sub

    Private Sub btnNewFromSID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewFromSID.Click
        ' Routes Module
        'Dim x As New WeightPlan
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow

        If UltraGrid2.ActiveRow Is Nothing Then
            MsgBox("Please Highlight an unassigned Scheduled Service.")
            Exit Sub
        End If
        ugRow = UltraGrid2.ActiveRow

        ManifestID.Text = 0
        xAcctID = Me.AcctID.Text
        If btnNew.Text = "&New" Then
            UltraGrid1.Enabled = False
            UltraGrid2.Enabled = False
            ClearForm(GroupBox2)
            btnNew.Text = "&Cancel" 'Karina changed place with Group_EnDis()
            Group_EnDis(True)
            With ugRow
                tbSID.Text = .Cells("SID").Text
                TextBox1.Text = .Cells("Location Name").Text
                Street.Text = .Cells("Street").Text
                Address2.Text = .Cells("Address2").Text
                City.Text = .Cells("City").Text
                State.SelectedValue = .Cells("State").Text
                Zipcode.Text = .Cells("ZipCode").Text
                Phone1.Text = .Cells("Phone1").Text
                Phone2.Text = .Cells("Phone2").Text
                umskStartDate.Text = Format(.Cells("StartDate").Value, "MMddyyyy")
            End With
            TextBox1.Focus()
        End If
    End Sub

    'Karina 06.21.2005, changes btnExit_Click and added AccountSetup_Closing
    Private Sub AccountSetup_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If btnEdit.Text = "&Cancel" Or btnNew.Text = "&Cancel" Then
            If MsgBox("Data is not saved! Are you sure you want to exit?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                e.Cancel = True
                Exit Sub
            End If
        End If

        If Not cmdTrans Is Nothing Then
            If EditForm(Me, PrepSelectQuery(SQLEdit, " Where ID = " & ManifestID.Text), EditAction.CANCEL, cmdTrans) Then
                UltraGrid1.Enabled = True
                UltraGrid2.Enabled = True
                sender.text = "&Edit" 'Karina changed place with Group_EnDis()
                Group_EnDis(False)
            Else
                'Exit Sub
            End If

        End If
        'UGSaveLayout(Me, UltraGrid1, 1)

    End Sub


    Private Sub btnBarcode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBarcode.Click

        Dim x As New PrintContainerLabels

        x.CalledByWeightPlan = True

        x.ShowDialog()

        If x.DialogResult = DialogResult.OK Then
            Dim tl As New TrackingLink
            m_iFromCLRowID = x.FromCLRowID
            txtBarcode.Text = tl.GetBarcodeByRowID(m_iFromCLRowID)
            DisplayBarcodeDetails()
        End If

    End Sub
    Private Sub btnDeleteBarcode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteBarcode.Click
        Try
            If ugBarcodes.ActiveRow.Cells(0).Text <> String.Empty Then
                'If txtBarcode.Text <> String.Empty Then
                Dim dtAdapter As SqlDataAdapter
                Dim dtSet As New DataSet

                Dim SqlBarcodes As String = "UPDATE " & WeightVars.WEIGHTTblPath & "TRACKINGLINK SET ACTIVE = 0 WHERE CourierLabelID IN (SELECT RowID FROM " & TRCTblPath & "COURIERLABELS WHERE @TRNUM)"
                Dim TRNUMCond As String = "TrackingNum = '" & ugBarcodes.ActiveRow.Cells(0).Text & "'"
                SqlBarcodes = SqlBarcodes.Replace("@TRNUM", TRNUMCond)
                'PopulateDataset2(dtAdapter, dtSet, PrepSelectQuery(SqlBarcodes))
                If ExecuteQuery(SqlBarcodes) = False Then
                    MsgBox("Failure to DELETE the BARCODE.")
                End If

                'Dim tl As New TrackingLink

                'If tl.SelectByWeightPlanID(CInt(ManifestID.Text)) = True Then

                '    If tl.HasError = False Then

                '        If tl.RowId <> 0 Then

                '            tl.Delete() ' This does not delete, it just deactivates
                '            txtBarcode.Text = String.Empty
                '            DisplayBarcodeDetails()
                '            Exit Sub

                '        End If

                '    End If

                'End If

                'MsgBox(tl.ErrorMessage) 'If it reaches this line, an error occured along the way

            End If

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Sub
    'Original - Before addint Barcodes UltraGrid
    'Private Sub btnDeleteBarcode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeleteBarcode.Click
    '    Try

    '        If txtBarcode.Text <> String.Empty Then

    '            Dim tl As New TrackingLink

    '            If tl.SelectByWeightPlanID(CInt(ManifestID.Text)) = True Then

    '                If tl.HasError = False Then

    '                    If tl.RowId <> 0 Then

    '                        tl.Delete() ' This does not delete, it just deactivates
    '                        txtBarcode.Text = String.Empty
    '                        DisplayBarcodeDetails()
    '                        Exit Sub

    '                    End If

    '                End If

    '            End If

    '            MsgBox(tl.ErrorMessage) 'If it reaches this line, an error occured along the way

    '        End If

    '    Catch ex As Exception

    '        MsgBox(ex.Message)

    '    End Try

    'End Sub

    Private Sub RestoreBarcode()
        ' This sub-routine is called if the barcode has been changed during the session, and now must be restored to its original state
        Try

            If (m_sBarcodeOnEntry <> String.Empty) And (m_sBarcodeOnEntry <> txtBarcode.Text) Then

                Dim tl As New TrackingLink

                ' The current one must be deactivated, if it exists
                If txtBarcode.Text <> String.Empty Then

                    If tl.SelectByWeightPlanID(CInt(ManifestID.Text)) = True Then

                        tl.Delete()

                    End If

                End If

                ' The old one must be reactivated
                tl.Clear()
                tl.Undelete(m_iTrackingLinkRowIdOnEntry)
                txtBarcode.Text = m_sBarcodeOnEntry
                DisplayBarcodeDetails()

            End If

        Catch ex As Exception

        End Try


    End Sub

    Private Sub RecordBarcodeInfo()
        ' This sub-routine will memorize the barcode that was active on entry as well as the TrackingLink RowID
        Try

            m_sBarcodeOnEntry = txtBarcode.Text

            If m_sBarcodeOnEntry <> String.Empty Then

                Dim tl As New TrackingLink

                If tl.SelectByWeightPlanID(CInt(ManifestID.Text)) = True Then

                    m_iTrackingLinkRowIdOnEntry = tl.RowId

                Else

                    MsgBox(tl.ErrorMessage)

                End If

            End If

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Sub

    Private Sub DisplayBarcodeDetails()

        Try

            If txtBarcode.Text <> String.Empty Then

                Dim cl As New CourierLabels(WeightVars.WEIGHTTblPath)
                Dim bRetVal As Boolean = cl.SelectByBarcode(txtBarcode.Text)

                If bRetVal = True Then

                    ' Populate Location Fields
                    Dim sFromArray(4) As String
                    sFromArray(0) = cl.FromLocID
                    sFromArray(1) = cl.FromLocName
                    sFromArray(2) = cl.FromAdd1 & " " & cl.FromAdd2
                    sFromArray(3) = cl.FromCity & ", " & cl.FromState & " " & cl.FromZip

                    Dim sToArray(4) As String
                    sToArray(0) = cl.ToLocID
                    sToArray(1) = cl.ToLocName
                    sToArray(2) = cl.ToAdd1 & " " & cl.ToAdd2
                    sToArray(3) = cl.ToCity & ", " & cl.ToState & " " & cl.ToZip

                    mlFromLoc.Lines = sFromArray
                    mlToLoc.Lines = sToArray

                Else
                    ' Display Error Condition
                    MsgBox("Barcode Appears to be Invalid")
                End If

            Else

                mlFromLoc.Lines = Nothing
                mlToLoc.Lines = Nothing

            End If

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try

    End Sub

    Private Sub DisplayBarcodesList(ByVal RowID As Integer)
        Try
            Dim dtAdapter As SqlDataAdapter
            Dim dtSet As New DataSet

            Dim SqlBarcodes As String = "SELECT TrackingNum As BARCODES FROM " & TRCTblPath & "COURIERLABELS WHERE RowID IN (SELECT CourierLabelID FROM " & WeightVars.WEIGHTTblPath & "TRACKINGLINK WHERE Active = 1 AND @WPID)"
            Dim WPIDCond As String = "WeightPlanID = " & RowID & ""
            SqlBarcodes = SqlBarcodes.Replace("@WPID", WPIDCond)
            PopulateDataset2(dtAdapter, dtSet, PrepSelectQuery(SqlBarcodes))

            FillUltraGrid(ugBarcodes, dtSet, 0)
            UGLoadLayout(Me, ugBarcodes, 1)
            ugBarcodes.DisplayLayout.GroupByBox.Hidden = True
            ugBarcodes.DisplayLayout.Bands(0).Columns(0).PerformAutoResize()
            'ugBarcodes.DisplayLayout.Bands(0).ColHeadersVisible = False
            ugBarcodes.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub SetConnectionInfo(ByVal table As String, _
   ByVal server As String, ByVal database As String, _
   ByVal user As String, ByVal password As String, ByRef ReportDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument)

        ' Get the ConnectionInfo Object.
        Dim logOnInfo As New TableLogOnInfo
        logOnInfo = ReportDoc.Database.Tables.Item(table).LogOnInfo

        'Dim connectionInfo As New ConnectionInfo()
        'connectionInfo = ReportDoc.Database.Tables.Item(table).LogOnInfo.ConnectionInfo

        ' Set the Connection parameters.
        With logOnInfo
            .ConnectionInfo.DatabaseName = database
            .ConnectionInfo.ServerName = server
            .ConnectionInfo.UserID = user
            .ConnectionInfo.Password = password
        End With

        'logOnInfo.ConnectionInfo = ConnectionInfo

        ReportDoc.Database.Tables.Item(table).ApplyLogOnInfo(logOnInfo)

    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim RepDoc As ReportDocument
        On Error GoTo ErrTrap
        Dim sCmd As String

        If txtBarcode.Text <> String.Empty Then
            Dim cl As New CourierLabels(WeightVars.WEIGHTTblPath)
            Dim bRetVal As Boolean = cl.SelectByBarcode(txtBarcode.Text)

            If bRetVal = True Then
                Dim sFromLocID As String = cl.FromLocID
                Dim sFromCustID As String = cl.FromCustID
                Dim sToLocID As String = cl.ToLocID
                Dim sToCustID As String = cl.ToCustID

                sCmd = ""

                sCmd = "exec " & TRCTblPath & "CourLblX '" & sFromLocID & "', '" & sFromCustID & "', '" & sToLocID & "', '" & sToCustID & "'"
                If ExecuteQuery(sCmd) = False Then
                    MsgBox("Due to Errors in record creation, print aborts.")
                    Exit Sub
                End If
                sCmd = ""
                sCmd = "Select RowID FROM " & TRCTblPath & "CourierLabels where FromLocID = '" & sFromLocID & "' AND FromCustID = '" & sFromCustID & "' AND ToLocID = '" & sToLocID & "' AND ToCustID = '" & sToCustID & "' AND VOID = 'F' "

                If Not RepDoc Is Nothing Then
                    RepDoc.Dispose()
                    RepDoc = Nothing
                End If

                Me.Cursor = System.Windows.Forms.Cursors.WaitCursor()

                Dim bThirdPartyFormat As Boolean = cbThirdPartyFormat.Checked

                If bThirdPartyFormat = True Then
                    RepDoc = New Third_Party_Barcoded_Labels
                Else
                    RepDoc = New Pouch__Container_Barcodes
                End If

                RepDoc.RecordSelectionFormula = "UpperCase({CourierLabels.ParcelType}) = 'XPOUCH' AND {CourierLabels.RowID} = " & cl.RowID & ""


                SetConnectionInfo("COURIERLABELS", IPAddr, TRCDBName, TRCDBUser, TRCDBPass, RepDoc)
                SetConnectionInfo("COURIERLABELS_R", IPAddr, TRCDBName, TRCDBUser, TRCDBPass, RepDoc)

                'Override Default Page Margins for Crystal Report
                Dim myPageMargins As PageMargins
                myPageMargins = RepDoc.PrintOptions.PageMargins
                myPageMargins.leftMargin = 0
                RepDoc.PrintOptions.ApplyPageMargins(myPageMargins)

                RepDoc.PrintToPrinter(Val(dUpDn.Text), False, 1, 9999)
                Me.Cursor = System.Windows.Forms.Cursors.Default

                If m_bCalledByWeightPlan Then
                    Me.DialogResult = DialogResult.OK
                End If

                If MessageBox.Show("Do you want to charge Customer(s) for printed flip-cards?", "Miscellaneous Charges Input Prompt", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK Then
                    Dim x As New InvoiceMiscCharges
                    x.udtTranDate.DateTime = DateTime.Today
                    x.uteBillToCustID.Text = sFromCustID

                    Dim BillToCustRow As DataRow
                    x.uteBillToCustID.Modified = True
                    If SearchOnLeave(x.uteBillToCustID, x.uteBillToCustID, BILLTblPath & "Customer", "CustomerID", "CustomerID", , , " Where Active = 'Y' ") Then
                        If ReturnRowByID(x.uteBillToCustID.Text, BillToCustRow, BILLTblPath & "Customer", " Where Active = 'Y' ", "CustomerID") Then
                            x.uteBillToCustName.Text = BillToCustRow("Name")
                        End If
                    End If
                    BillToCustRow = Nothing
                    x.uteBillToCustID.Modified = False

                    x.uteQty.Text = dUpDn.Text
                    x.uteUnit.Text = "EA"
                    x.UltraTextEditor1.Text = 2
                    x.uteCharge.Text = x.uteQty.Text * x.UltraTextEditor1.Text
                    'x.ucboDescription.Text = "Miscellaneous Charge"
                    'FillUCombo(x.ucboDescription, "Miscellaneous Charge", "Where Charge_Code = 'MISC'", , BILLTblPath, False, False)
                    'AddHandler x.ucboDescription.Leave, AddressOf UCbo_Leave
                    'FillUCombo(x.ucboDescription, "Miscellaneous Charge", , , BILLTblPath, False, False)


                    x.uteDescription.Text = "Replacement Flip-Card Charge for #" & sFromLocID & " To/From #" & sToLocID & ""
                    x.uteFromCustID.Text = x.uteBillToCustID.Text
                    x.uteFromCustName.Text = x.uteBillToCustName.Text

                    x.uteFromLocID.Text = sFromLocID
                    Dim FromLocRow As DataRow
                    x.uteFromLocID.Modified = True
                    If SearchOnLeave(x.uteFromLocID, x.uteFromLocID, BILLTblPath & "Location", "LocationID", "LocationID", , , "where CustomerID = " & x.uteFromCustID.Text & " AND Active = 'Y'") Then
                        If ReturnRowByID(x.uteFromLocID.Text, FromLocRow, BILLTblPath & "Location", "Where Active = 'Y'", "LocationID") Then
                            x.uteFromLocName.Text = FromLocRow("Name")
                            x.uteFromAdd1.Text = FromLocRow("Address1")
                            x.uteFromAdd2.Text = FromLocRow("Address2")
                            x.uteFromCity.Text = FromLocRow("City")
                            x.ucFromState.Text = FromLocRow("State")
                            x.uteFromZip.Text = FromLocRow("Zip")
                            x.uteFromLocName.Text = FromLocRow("Name")
                            x.uteFromContact.Text = FromLocRow("Contact")
                            x.umeFromPhone.Text = FromLocRow("Phone")
                            x.uteFromEmail.Text = FromLocRow("Email")
                            x.FromAddID.Text = FromLocRow("AddressID")
                            'uteToCustID.Focus()
                        End If
                    End If
                    FromLocRow = Nothing
                    x.uteFromLocID.Modified = False

                    x.uteToCustID.Text = sToCustID
                    x.uteToLocID.Text = sToLocID
                    x.uteToCustName.Text = x.uteBillToCustName.Text

                    Dim ToCustRow As DataRow
                    x.uteToCustID.Modified = True
                    If SearchOnLeave(x.uteToCustID, x.uteToCustID, BILLTblPath & "Customer", "CustomerID", "CustomerID", , , " Where Active = 'Y' ") Then
                        If ReturnRowByID(x.uteToCustID.Text, ToCustRow, BILLTblPath & "Customer", " Where Active = 'Y' ", "CustomerID") Then
                            x.uteToCustName.Text = ToCustRow("Name")
                        End If
                    End If
                    ToCustRow = Nothing
                    x.uteToCustID.Modified = False

                    Dim ToLocRow As DataRow
                    x.uteToLocID.Modified = True
                    If SearchOnLeave(x.uteToLocID, x.uteToLocID, BILLTblPath & "Location", "LocationID", "LocationID", , , "where CustomerID = " & x.uteToCustID.Text & " AND Active = 'Y'") Then
                        If ReturnRowByID(x.uteToLocID.Text, ToLocRow, BILLTblPath & "Location", "Where Active = 'Y'", "LocationID") Then
                            x.uteToLocName.Text = ToLocRow("Name")
                            x.uteToAdd1.Text = ToLocRow("Address1")
                            x.uteToAdd2.Text = ToLocRow("Address2")
                            x.uteToCity.Text = ToLocRow("City")
                            x.ucToState.Text = ToLocRow("State")
                            x.uteToZip.Text = ToLocRow("Zip")
                            x.uteToLocName.Text = ToLocRow("Name")
                            x.uteToContact.Text = ToLocRow("Contact")
                            x.umeToPhone.Text = ToLocRow("Phone")
                            x.uteToEmail.Text = ToLocRow("Email")
                            x.ToAddID.Text = ToLocRow("AddressID")
                            'uteToCustID.Focus()
                        End If
                    End If
                    ToLocRow = Nothing
                    x.uteToLocID.Modified = False
                    x.bStartInNewMode = True
                    x.Show()
                End If

            Else
                MsgBox("Barcode Appears to be Invalid")
            End If
        Else : MsgBox("Barcode is not assigned to current weight-plan!")
        End If
        Exit Sub
ErrTrap:
        MsgBox(Err.Description)

    End Sub

    Private Sub ugBarcodes_AfterRowActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles ugBarcodes.AfterRowActivate
        'Dim tl As New TrackingLink
        'txtBarcode.Text = tl.GetBarcodeForWeightPlan(CInt(ManifestID.Text))
        Dim ActiveBarcode As String
        ActiveBarcode = ugBarcodes.ActiveRow.Cells(0).Text
        Try

            If ActiveBarcode <> String.Empty Then

                Dim cl As New CourierLabels(WeightVars.WEIGHTTblPath)
                Dim bRetVal As Boolean = cl.SelectByBarcode(ActiveBarcode)

                If bRetVal = True Then

                    ' Populate Location Fields
                    Dim sFromArray(4) As String
                    sFromArray(0) = cl.FromLocID
                    sFromArray(1) = cl.FromLocName
                    sFromArray(2) = cl.FromAdd1 & " " & cl.FromAdd2
                    sFromArray(3) = cl.FromCity & ", " & cl.FromState & " " & cl.FromZip

                    Dim sToArray(4) As String
                    sToArray(0) = cl.ToLocID
                    sToArray(1) = cl.ToLocName
                    sToArray(2) = cl.ToAdd1 & " " & cl.ToAdd2
                    sToArray(3) = cl.ToCity & ", " & cl.ToState & " " & cl.ToZip

                    mlFromLoc.Lines = sFromArray
                    mlToLoc.Lines = sToArray
                    txtBarcode.Text = ActiveBarcode
                Else
                    ' Display Error Condition
                    MsgBox("Barcode Appears to be Invalid")
                End If

            Else

                mlFromLoc.Lines = Nothing
                mlToLoc.Lines = Nothing

            End If

        Catch ex As Exception

            MsgBox(ex.Message)

        End Try
    End Sub
End Class
