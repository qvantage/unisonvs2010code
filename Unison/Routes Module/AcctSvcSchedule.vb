Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors

Public Class AcctSvcSchedule
    Inherits System.Windows.Forms.Form
    Friend WithEvents rbWeekly As System.Windows.Forms.RadioButton
    Friend WithEvents rbCalendar As System.Windows.Forms.RadioButton
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    '.COMPNAME......Location Name
    '.CITYNAME......City
    Dim SQLSelect As String = _
            "Select mft.rowid, mft.AccountID, mft.ID as SID, c.name as AccountName " & _
            " , mft.CompName as [Location Name], mft.Street, mft.CityName as City, mft.State, mft.ZipCode, mft.Phone1, mft.Phone2 " & _
            " , mft.Remarks, mft.StartDate, mft.EndDate, mft.OpenTime, mft.CloseTime, mft.DoorKey, mft.BoxKey, mft.InternalRef, mft.AccountRef " & _
            " , mft.TimeFrameID, isnull(tf.Name, '') as [Time Frame], mft.ServiceID, isnull(s.Name, '') as Service, mft.ServiceTypeID, isnull(stp.Name, '') as [Service Type] " & _
            " , mft.PackageID, isnull(p.Name, '') as Package, mft.Charge, mft.DailyAvgChg as [Daily Avg], mft.InfoSID " & _
            " , c.BCycleCode , mft.SchedType, c.NRVNU, mft.NonPrintRemark as [Non Printable Remark], mft.[Subj To Wgt], mft.[Wgt Plan ID]" & _
            " , mft.[Last Bill Date] " & _
            " FROM (((((" & ROUTESTblPath & "AccountServices mft LEFT OUTER JOIN " & _
            " " & AppTblPath & "Customer c ON mft.accountid = c.id) LEFT OUTER JOIN " & _
            " " & ROUTESTblPath & "TimeFrames tf ON mft.TimeFrameID = tf.ID) LEFT OUTER JOIN " & _
            " " & AppTblPath & "Services s ON mft.ServiceID = s.ID) LEFT OUTER JOIN " & _
            " " & AppTblPath & "ServiceTypes stp ON mft.ServiceTypeID = stp.ID) " & _
            " LEFT OUTER JOIN " & AppTblPath & "PackageTypes p ON mft.PackageID = p.ID) " & _
            " ORDER BY mft.ID "

    '" WHERE mft.accountid *= c.id AND mft.TimeFrameID *= tf.ID " & _
    '" AND mft.ServiceID *= s.ID AND mft.ServiceTypeID *= stp.ID " & _
    '" AND mft.PackageID *= p.ID AND c.BillingCycleID *= bc.ID " & _
    '" from AccountServices mft, Customer c, TimeFrames tf, Services s, ServiceTypes stp, PackageTypes p " & _
    '" , BillingCycles  bc " & _

    Dim SQLSelectDel As String = _
            "Select mft.ID, mft.AccountID, mft.OfficeID as [Office ID]" & _
            " , mft.CompName as [Location Name], mft.Street, mft.CityName as City, mft.State, mft.ZipCode, mft.Phone1, mft.Phone2 " & _
            " , mft.Remarks, mft.StartDate, mft.EndDate, mft.OpenTime, mft.CloseTime, mft.DoorKey, mft.BoxKey, mft.InternalRef, mft.AccountRef, mft.NonPrintRemark as [Non Printable Remark], mft.[Subj To Wgt], mft.[Wgt Plan ID] " & _
            " , mft.[Last Bill Date] " & _
            " FROM " & ROUTESTblPath & "AccountServices mft "

    Dim SQLSelectDel2 As String = _
            "Select ID, AccountID, OfficeID as [Office ID]" & _
            " , WeightID  " & _
            " ,CompName as [Location Name], Street, CityName as City, State, ZipCode, Phone1, Phone2 " & _
            " , Remarks, StartDate, EndDate, OpenTime, CloseTime, DoorKey, BoxKey, InternalRef, AccountRef, NonPrintRemark as [Non Printable Remark], [Subj To Wgt], [Wgt Plan ID] " & _
            " , [Last Bill Date] " & _
            " FROM " & ROUTESTblPath & "AccountServices  "

    Dim SQLEdit As String = _
            "Select mft.AddressId, mft.ID, mft.AccountID, mft.OfficeID as [Office ID]" & _
            " , mft.CompName as [Location Name], mft.Street, mft.CityName as City, mft.State, mft.ZipCode, mft.Phone1, mft.Phone2 " & _
            " , mft.Remarks, mft.StartDate, mft.EndDate, mft.OpenTime, mft.CloseTime, mft.DoorKey, mft.BoxKey, mft.InternalRef, mft.AccountRef, mft.NonPrintRemark as [Non Printable Remark], mft.[Subj To Wgt], mft.[Wgt Plan ID] " & _
            " , mft.[Last Bill Date] " & _
            " FROM " & ROUTESTblPath & "AccountServices mft " & _
            " ORDER BY mft.ID "

    Dim HidCols() As String = {"Tbl", "RowID", "Remarks"}

    Dim AcctCriteria As String = " mft.AccountID = @AcctID "
    Dim SIDCriteria As String = " mft.ID = @SID "

    Dim MeText As String
    Dim dtSet As New DataSet()
    Dim dvStates As New DataView()
    Dim cmdTrans As SqlCommand
    Dim SbjWgtModified As Boolean

    Dim m_oColumn As Infragistics.Win.UltraWinGrid.UltraGridColumn = Nothing
    Private m_searchInfo As clsSearchInfo = New clsSearchInfo()

    Dim StatusTable As New DataTable()

    Private Const MTWTF = 31
    Private Const MTWT = 15
    Private Const MWF = 21
    Private Const TT = 10
    Private Const SS = 96

    Private p_bRestartMode As Boolean = False

    Class SchedCols
        Public AID As Integer
        Public SID As Integer
        Public SvcDate As Date
        Public iDay As Integer
        Public Ofc As Integer
        Public Rte As String
        Public STm As String
        Public CTm As String
        Public Stp As Integer
        Public Chg As Decimal
    End Class

    Dim SCH_WEEKLY As Boolean

    Class SchCols
        Public Name As String
        Public Type As Type
        Public Format As String
        Public NoEdit As Boolean
        Public Hide As Boolean
        Public BackColor As Color
        Public MaxLength As Byte
        Public Width As Byte
    End Class

    Dim WCols(7) As SchCols
    Dim EnabledStatus As Boolean

    Dim StartDateOldValue, EndDateOldValue As String

    Const ROUTELEN As Int16 = 6

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
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents umskStartDate As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents umskCloseTime As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents umskOpenTime As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents umskEndDate As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents chkBoxKey As System.Windows.Forms.CheckBox
    Friend WithEvents chkDoorKey As System.Windows.Forms.CheckBox
    Friend WithEvents LocID As TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Remarks As TextBox
    Friend WithEvents Phone2 As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Phone1 As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As TextBox
    'Friend WithEvents TextBox1 As RoutesModule.MyTextBox

    Friend WithEvents Zipcode As TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    'RoutesModule.MyComboBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents City As TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Street As TextBox
    Friend WithEvents btnAcct As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents AcctName As TextBox
    Friend WithEvents AcctID As TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents SrvcID As TextBox
    Friend WithEvents btnPrev As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents TextBox10 As TextBox
    Friend WithEvents TextBox11 As TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents UltraGrid2 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnSID As System.Windows.Forms.Button
    Friend WithEvents RowID As TextBox
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents ucboSvcType As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents ucboTimeFrame As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents ucboService As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents ucboPackage As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents ucboState As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents btnSIDGroup As System.Windows.Forms.Button
    Friend WithEvents chkNRvnu As System.Windows.Forms.CheckBox
    Friend WithEvents Panel3 As System.Windows.Forms.Panel
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Charge As TextBox
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents DailyAvg As TextBox
    Friend WithEvents MyTextBox1 As TextBox
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents cboBillingCycle As System.Windows.Forms.ComboBox
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents CntMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents chkSbjWgt As System.Windows.Forms.CheckBox
    Friend WithEvents btnWgtPlans As System.Windows.Forms.Button
    Friend WithEvents WgtPlanID As TextBox
    Friend WithEvents UltraDate1 As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents btnLocation As System.Windows.Forms.Button
    Friend WithEvents btnDel1 As System.Windows.Forms.Button
    Friend WithEvents txtGridOfc As System.Windows.Forms.TextBox
    Friend WithEvents txtGridRte As System.Windows.Forms.TextBox
    Friend WithEvents txtGridStp As System.Windows.Forms.TextBox
    Friend WithEvents btnDel7 As System.Windows.Forms.Button
    Friend WithEvents btnDel6 As System.Windows.Forms.Button
    Friend WithEvents btnDel5 As System.Windows.Forms.Button
    Friend WithEvents btnDel4 As System.Windows.Forms.Button
    Friend WithEvents btnDel3 As System.Windows.Forms.Button
    Friend WithEvents btnDel2 As System.Windows.Forms.Button
    Friend WithEvents txtID As System.Windows.Forms.TextBox
    Friend WithEvents btnChangeSchedule As System.Windows.Forms.Button
    Friend WithEvents btnChangeDay As System.Windows.Forms.Button

    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(AcctSvcSchedule))
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnChangeDay = New System.Windows.Forms.Button
        Me.btnChangeSchedule = New System.Windows.Forms.Button
        Me.txtGridStp = New System.Windows.Forms.TextBox
        Me.txtGridRte = New System.Windows.Forms.TextBox
        Me.txtGridOfc = New System.Windows.Forms.TextBox
        Me.btnDel7 = New System.Windows.Forms.Button
        Me.btnDel6 = New System.Windows.Forms.Button
        Me.btnDel5 = New System.Windows.Forms.Button
        Me.btnDel4 = New System.Windows.Forms.Button
        Me.btnDel3 = New System.Windows.Forms.Button
        Me.btnDel2 = New System.Windows.Forms.Button
        Me.btnDel1 = New System.Windows.Forms.Button
        Me.btnLocation = New System.Windows.Forms.Button
        Me.Label29 = New System.Windows.Forms.Label
        Me.UltraDate1 = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.WgtPlanID = New System.Windows.Forms.TextBox
        Me.MyTextBox1 = New System.Windows.Forms.TextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.ucboState = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.Label27 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.ucboPackage = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.ucboService = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.ucboTimeFrame = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.ucboSvcType = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.rbMWF = New System.Windows.Forms.RadioButton
        Me.rbMTWTF = New System.Windows.Forms.RadioButton
        Me.rbMTWT = New System.Windows.Forms.RadioButton
        Me.rbTT = New System.Windows.Forms.RadioButton
        Me.rbOther = New System.Windows.Forms.RadioButton
        Me.rbSS = New System.Windows.Forms.RadioButton
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.rbCalendar = New System.Windows.Forms.RadioButton
        Me.rbWeekly = New System.Windows.Forms.RadioButton
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label22 = New System.Windows.Forms.Label
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.Label2 = New System.Windows.Forms.Label
        Me.AcctName = New System.Windows.Forms.TextBox
        Me.umskStartDate = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
        Me.Label20 = New System.Windows.Forms.Label
        Me.umskCloseTime = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
        Me.Label17 = New System.Windows.Forms.Label
        Me.umskOpenTime = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
        Me.Label16 = New System.Windows.Forms.Label
        Me.umskEndDate = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
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
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.City = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Street = New System.Windows.Forms.TextBox
        Me.RowID = New System.Windows.Forms.TextBox
        Me.TextBox10 = New System.Windows.Forms.TextBox
        Me.TextBox11 = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.chkSbjWgt = New System.Windows.Forms.CheckBox
        Me.btnPrev = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.Label21 = New System.Windows.Forms.Label
        Me.SrvcID = New System.Windows.Forms.TextBox
        Me.btnAcct = New System.Windows.Forms.Button
        Me.AcctID = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.txtID = New System.Windows.Forms.TextBox
        Me.chkNRvnu = New System.Windows.Forms.CheckBox
        Me.btnSID = New System.Windows.Forms.Button
        Me.btnSIDGroup = New System.Windows.Forms.Button
        Me.btnWgtPlans = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnNew = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Panel3 = New System.Windows.Forms.Panel
        Me.cboBillingCycle = New System.Windows.Forms.ComboBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Charge = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.DailyAvg = New System.Windows.Forms.TextBox
        Me.UltraGrid2 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.CntMenu1 = New System.Windows.Forms.ContextMenu
        Me.GroupBox2.SuspendLayout()
        CType(Me.UltraDate1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucboState, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucboPackage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucboService, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucboTimeFrame, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucboSvcType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.UltraGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnChangeDay)
        Me.GroupBox2.Controls.Add(Me.btnChangeSchedule)
        Me.GroupBox2.Controls.Add(Me.txtGridStp)
        Me.GroupBox2.Controls.Add(Me.txtGridRte)
        Me.GroupBox2.Controls.Add(Me.txtGridOfc)
        Me.GroupBox2.Controls.Add(Me.btnDel7)
        Me.GroupBox2.Controls.Add(Me.btnDel6)
        Me.GroupBox2.Controls.Add(Me.btnDel5)
        Me.GroupBox2.Controls.Add(Me.btnDel4)
        Me.GroupBox2.Controls.Add(Me.btnDel3)
        Me.GroupBox2.Controls.Add(Me.btnDel2)
        Me.GroupBox2.Controls.Add(Me.btnDel1)
        Me.GroupBox2.Controls.Add(Me.btnLocation)
        Me.GroupBox2.Controls.Add(Me.Label29)
        Me.GroupBox2.Controls.Add(Me.UltraDate1)
        Me.GroupBox2.Controls.Add(Me.WgtPlanID)
        Me.GroupBox2.Controls.Add(Me.MyTextBox1)
        Me.GroupBox2.Controls.Add(Me.Label28)
        Me.GroupBox2.Controls.Add(Me.ucboState)
        Me.GroupBox2.Controls.Add(Me.Label27)
        Me.GroupBox2.Controls.Add(Me.Label26)
        Me.GroupBox2.Controls.Add(Me.ucboPackage)
        Me.GroupBox2.Controls.Add(Me.ucboService)
        Me.GroupBox2.Controls.Add(Me.ucboTimeFrame)
        Me.GroupBox2.Controls.Add(Me.ucboSvcType)
        Me.GroupBox2.Controls.Add(Me.Panel2)
        Me.GroupBox2.Controls.Add(Me.Panel1)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.Label11)
        Me.GroupBox2.Controls.Add(Me.Label22)
        Me.GroupBox2.Controls.Add(Me.UltraGrid1)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.AcctName)
        Me.GroupBox2.Controls.Add(Me.umskStartDate)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.umskCloseTime)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.umskOpenTime)
        Me.GroupBox2.Controls.Add(Me.Label16)
        Me.GroupBox2.Controls.Add(Me.umskEndDate)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
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
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.City)
        Me.GroupBox2.Controls.Add(Me.Label10)
        Me.GroupBox2.Controls.Add(Me.Street)
        Me.GroupBox2.Controls.Add(Me.RowID)
        Me.GroupBox2.Controls.Add(Me.TextBox10)
        Me.GroupBox2.Controls.Add(Me.TextBox11)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.chkSbjWgt)
        Me.GroupBox2.Location = New System.Drawing.Point(217, -1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(935, 369)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        '
        'btnChangeDay
        '
        Me.btnChangeDay.Location = New System.Drawing.Point(840, 16)
        Me.btnChangeDay.Name = "btnChangeDay"
        Me.btnChangeDay.Size = New System.Drawing.Size(72, 24)
        Me.btnChangeDay.TabIndex = 26
        Me.btnChangeDay.Text = "Change..."
        '
        'btnChangeSchedule
        '
        Me.btnChangeSchedule.Location = New System.Drawing.Point(264, 16)
        Me.btnChangeSchedule.Name = "btnChangeSchedule"
        Me.btnChangeSchedule.Size = New System.Drawing.Size(72, 24)
        Me.btnChangeSchedule.TabIndex = 25
        Me.btnChangeSchedule.Text = "Change..."
        '
        'txtGridStp
        '
        Me.txtGridStp.Location = New System.Drawing.Point(416, 18)
        Me.txtGridStp.Name = "txtGridStp"
        Me.txtGridStp.Size = New System.Drawing.Size(9, 22)
        Me.txtGridStp.TabIndex = 170
        Me.txtGridStp.Tag = ".RowID.View"
        Me.txtGridStp.Text = ""
        Me.txtGridStp.Visible = False
        '
        'txtGridRte
        '
        Me.txtGridRte.Location = New System.Drawing.Point(400, 18)
        Me.txtGridRte.Name = "txtGridRte"
        Me.txtGridRte.Size = New System.Drawing.Size(10, 22)
        Me.txtGridRte.TabIndex = 169
        Me.txtGridRte.Tag = ".RowID.View"
        Me.txtGridRte.Text = ""
        Me.txtGridRte.Visible = False
        '
        'txtGridOfc
        '
        Me.txtGridOfc.Location = New System.Drawing.Point(384, 18)
        Me.txtGridOfc.Name = "txtGridOfc"
        Me.txtGridOfc.Size = New System.Drawing.Size(10, 22)
        Me.txtGridOfc.TabIndex = 168
        Me.txtGridOfc.Tag = ".RowID.View"
        Me.txtGridOfc.Text = ""
        Me.txtGridOfc.Visible = False
        '
        'btnDel7
        '
        Me.btnDel7.Location = New System.Drawing.Point(845, 222)
        Me.btnDel7.Name = "btnDel7"
        Me.btnDel7.Size = New System.Drawing.Size(77, 20)
        Me.btnDel7.TabIndex = 166
        Me.btnDel7.Text = "&Delete"
        '
        'btnDel6
        '
        Me.btnDel6.Location = New System.Drawing.Point(845, 196)
        Me.btnDel6.Name = "btnDel6"
        Me.btnDel6.Size = New System.Drawing.Size(77, 21)
        Me.btnDel6.TabIndex = 165
        Me.btnDel6.Text = "&Delete"
        '
        'btnDel5
        '
        Me.btnDel5.Location = New System.Drawing.Point(845, 172)
        Me.btnDel5.Name = "btnDel5"
        Me.btnDel5.Size = New System.Drawing.Size(77, 21)
        Me.btnDel5.TabIndex = 164
        Me.btnDel5.Text = "&Delete"
        '
        'btnDel4
        '
        Me.btnDel4.Location = New System.Drawing.Point(845, 147)
        Me.btnDel4.Name = "btnDel4"
        Me.btnDel4.Size = New System.Drawing.Size(77, 20)
        Me.btnDel4.TabIndex = 163
        Me.btnDel4.Text = "&Delete"
        '
        'btnDel3
        '
        Me.btnDel3.Location = New System.Drawing.Point(845, 123)
        Me.btnDel3.Name = "btnDel3"
        Me.btnDel3.Size = New System.Drawing.Size(77, 21)
        Me.btnDel3.TabIndex = 162
        Me.btnDel3.Text = "&Delete"
        '
        'btnDel2
        '
        Me.btnDel2.Location = New System.Drawing.Point(845, 99)
        Me.btnDel2.Name = "btnDel2"
        Me.btnDel2.Size = New System.Drawing.Size(77, 21)
        Me.btnDel2.TabIndex = 161
        Me.btnDel2.Text = "&Delete"
        '
        'btnDel1
        '
        Me.btnDel1.Location = New System.Drawing.Point(845, 74)
        Me.btnDel1.Name = "btnDel1"
        Me.btnDel1.Size = New System.Drawing.Size(77, 21)
        Me.btnDel1.TabIndex = 160
        Me.btnDel1.Text = "&Delete"
        '
        'btnLocation
        '
        Me.btnLocation.Location = New System.Drawing.Point(355, 83)
        Me.btnLocation.Name = "btnLocation"
        Me.btnLocation.Size = New System.Drawing.Size(66, 24)
        Me.btnLocation.TabIndex = 3
        Me.btnLocation.Text = "Select"
        '
        'Label29
        '
        Me.Label29.Location = New System.Drawing.Point(518, 271)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(87, 19)
        Me.Label29.TabIndex = 157
        Me.Label29.Text = "Last Bill Date"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UltraDate1
        '
        Appearance1.BackColorDisabled = System.Drawing.SystemColors.Control
        Appearance1.ForeColorDisabled = System.Drawing.Color.Black
        Me.UltraDate1.Appearance = Appearance1
        Me.UltraDate1.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.UltraDate1.Enabled = False
        Me.UltraDate1.Location = New System.Drawing.Point(610, 267)
        Me.UltraDate1.Name = "UltraDate1"
        Me.UltraDate1.Size = New System.Drawing.Size(105, 24)
        Me.UltraDate1.TabIndex = 19
        Me.UltraDate1.Tag = ".[Last Bill Date].view"
        Me.UltraDate1.Value = Nothing
        '
        'WgtPlanID
        '
        Me.WgtPlanID.Location = New System.Drawing.Point(336, 18)
        Me.WgtPlanID.Name = "WgtPlanID"
        Me.WgtPlanID.Size = New System.Drawing.Size(9, 22)
        Me.WgtPlanID.TabIndex = 154
        Me.WgtPlanID.Tag = ".Wgt Plan ID.view"
        Me.WgtPlanID.Text = ""
        Me.WgtPlanID.Visible = False
        '
        'MyTextBox1
        '
        Me.MyTextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.MyTextBox1.Location = New System.Drawing.Point(528, 305)
        Me.MyTextBox1.Name = "MyTextBox1"
        Me.MyTextBox1.Size = New System.Drawing.Size(307, 22)
        Me.MyTextBox1.TabIndex = 23
        Me.MyTextBox1.Tag = ".NonPrintRemark......Non Printable Remark"
        Me.MyTextBox1.Text = ""
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(432, 308)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(96, 19)
        Me.Label28.TabIndex = 153
        Me.Label28.Text = "Non Prn.Rem.:"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ucboState
        '
        Me.ucboState.AutoEdit = False
        Me.ucboState.DisplayMember = ""
        Me.ucboState.Location = New System.Drawing.Point(271, 135)
        Me.ucboState.Name = "ucboState"
        Me.ucboState.Size = New System.Drawing.Size(58, 24)
        Me.ucboState.TabIndex = 5
        Me.ucboState.Tag = ".STATE...STATE.CODE.CODE"
        Me.ucboState.ValueMember = ""
        '
        'Label27
        '
        Me.Label27.Location = New System.Drawing.Point(10, 18)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(57, 19)
        Me.Label27.TabIndex = 151
        Me.Label27.Text = "Box Key"
        Me.Label27.Visible = False
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(10, 32)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(67, 18)
        Me.Label26.TabIndex = 150
        Me.Label26.Text = "Door Key"
        Me.Label26.Visible = False
        '
        'ucboPackage
        '
        Me.ucboPackage.AutoEdit = False
        Me.ucboPackage.DisplayMember = ""
        Me.ucboPackage.Location = New System.Drawing.Point(82, 197)
        Me.ucboPackage.Name = "ucboPackage"
        Me.ucboPackage.Size = New System.Drawing.Size(81, 24)
        Me.ucboPackage.TabIndex = 9
        Me.ucboPackage.Tag = ".PackageID...PackageTypes.ID.Name"
        Me.ucboPackage.ValueMember = ""
        '
        'ucboService
        '
        Me.ucboService.AutoEdit = False
        Me.ucboService.DisplayMember = ""
        Me.ucboService.Location = New System.Drawing.Point(211, 198)
        Me.ucboService.Name = "ucboService"
        Me.ucboService.Size = New System.Drawing.Size(87, 24)
        Me.ucboService.TabIndex = 10
        Me.ucboService.Tag = ".ServiceID...Services.ID.Name"
        Me.ucboService.ValueMember = ""
        '
        'ucboTimeFrame
        '
        Me.ucboTimeFrame.AutoEdit = False
        Me.ucboTimeFrame.DisplayMember = ""
        Me.ucboTimeFrame.Location = New System.Drawing.Point(83, 231)
        Me.ucboTimeFrame.Name = "ucboTimeFrame"
        Me.ucboTimeFrame.Size = New System.Drawing.Size(80, 24)
        Me.ucboTimeFrame.TabIndex = 12
        Me.ucboTimeFrame.Tag = ".TimeFrameID...TimeFrames.ID.Name"
        Me.ucboTimeFrame.ValueMember = ""
        '
        'ucboSvcType
        '
        Me.ucboSvcType.AutoEdit = False
        Me.ucboSvcType.DisplayMember = ""
        Me.ucboSvcType.Location = New System.Drawing.Point(362, 198)
        Me.ucboSvcType.Name = "ucboSvcType"
        Me.ucboSvcType.Size = New System.Drawing.Size(60, 24)
        Me.ucboSvcType.TabIndex = 11
        Me.ucboSvcType.Tag = ".ServiceTypeID...ServiceTypes.ID.Name"
        Me.ucboSvcType.ValueMember = ""
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.rbMWF)
        Me.Panel2.Controls.Add(Me.rbMTWTF)
        Me.Panel2.Controls.Add(Me.rbMTWT)
        Me.Panel2.Controls.Add(Me.rbTT)
        Me.Panel2.Controls.Add(Me.rbOther)
        Me.Panel2.Controls.Add(Me.rbSS)
        Me.Panel2.Enabled = False
        Me.Panel2.Location = New System.Drawing.Point(426, 9)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(413, 37)
        Me.Panel2.TabIndex = 0
        '
        'rbMWF
        '
        Me.rbMWF.Location = New System.Drawing.Point(167, 9)
        Me.rbMWF.Name = "rbMWF"
        Me.rbMWF.Size = New System.Drawing.Size(66, 19)
        Me.rbMWF.TabIndex = 2
        Me.rbMWF.Text = "MWF"
        '
        'rbMTWTF
        '
        Me.rbMTWTF.Location = New System.Drawing.Point(13, 9)
        Me.rbMTWTF.Name = "rbMTWTF"
        Me.rbMTWTF.Size = New System.Drawing.Size(77, 19)
        Me.rbMTWTF.TabIndex = 0
        Me.rbMTWTF.Text = "MTWTF"
        '
        'rbMTWT
        '
        Me.rbMTWT.Location = New System.Drawing.Point(90, 9)
        Me.rbMTWT.Name = "rbMTWT"
        Me.rbMTWT.Size = New System.Drawing.Size(67, 19)
        Me.rbMTWT.TabIndex = 1
        Me.rbMTWT.Text = "MTWT"
        '
        'rbTT
        '
        Me.rbTT.Location = New System.Drawing.Point(234, 9)
        Me.rbTT.Name = "rbTT"
        Me.rbTT.Size = New System.Drawing.Size(47, 19)
        Me.rbTT.TabIndex = 3
        Me.rbTT.Text = "TT"
        '
        'rbOther
        '
        Me.rbOther.Location = New System.Drawing.Point(356, 9)
        Me.rbOther.Name = "rbOther"
        Me.rbOther.Size = New System.Drawing.Size(65, 19)
        Me.rbOther.TabIndex = 5
        Me.rbOther.Text = "Other"
        '
        'rbSS
        '
        Me.rbSS.Location = New System.Drawing.Point(282, 9)
        Me.rbSS.Name = "rbSS"
        Me.rbSS.Size = New System.Drawing.Size(76, 19)
        Me.rbSS.TabIndex = 4
        Me.rbSS.Text = "Sat-Sun"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.rbCalendar)
        Me.Panel1.Controls.Add(Me.rbWeekly)
        Me.Panel1.Enabled = False
        Me.Panel1.Location = New System.Drawing.Point(80, 9)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(184, 37)
        Me.Panel1.TabIndex = 0
        '
        'rbCalendar
        '
        Me.rbCalendar.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rbCalendar.Location = New System.Drawing.Point(96, 9)
        Me.rbCalendar.Name = "rbCalendar"
        Me.rbCalendar.Size = New System.Drawing.Size(80, 19)
        Me.rbCalendar.TabIndex = 0
        Me.rbCalendar.Tag = ".SchedType........C"
        Me.rbCalendar.Text = "Calender"
        Me.rbCalendar.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'rbWeekly
        '
        Me.rbWeekly.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.rbWeekly.Location = New System.Drawing.Point(8, 6)
        Me.rbWeekly.Name = "rbWeekly"
        Me.rbWeekly.Size = New System.Drawing.Size(72, 27)
        Me.rbWeekly.TabIndex = 0
        Me.rbWeekly.Tag = ".SchedType........W"
        Me.rbWeekly.Text = "Weekly"
        Me.rbWeekly.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(11, 231)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(71, 18)
        Me.Label23.TabIndex = 133
        Me.Label23.Text = "Time Frm :"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(30, 197)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(48, 19)
        Me.Label19.TabIndex = 128
        Me.Label19.Text = "Pkg. :"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(167, 201)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(38, 18)
        Me.Label11.TabIndex = 126
        Me.Label11.Text = "Svc. :"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label22
        '
        Me.Label22.Location = New System.Drawing.Point(298, 202)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(67, 18)
        Me.Label22.TabIndex = 121
        Me.Label22.Text = "Svc.Typ :"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Location = New System.Drawing.Point(432, 50)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(403, 199)
        Me.UltraGrid1.TabIndex = 26
        Me.UltraGrid1.Tag = "ServiceSchedules"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(1, 53)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(76, 19)
        Me.Label2.TabIndex = 110
        Me.Label2.Text = "Acct Name:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'AcctName
        '
        Me.AcctName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.AcctName.Enabled = False
        Me.AcctName.Location = New System.Drawing.Point(84, 53)
        Me.AcctName.Name = "AcctName"
        Me.AcctName.Size = New System.Drawing.Size(338, 22)
        Me.AcctName.TabIndex = 1
        Me.AcctName.Tag = ".AccountNAME.view.1"
        Me.AcctName.Text = ""
        '
        'umskStartDate
        '
        Me.umskStartDate.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Date
        Me.umskStartDate.InputMask = "mm/dd/yyyy"
        Me.umskStartDate.Location = New System.Drawing.Point(83, 269)
        Me.umskStartDate.Name = "umskStartDate"
        Me.umskStartDate.Size = New System.Drawing.Size(86, 22)
        Me.umskStartDate.TabIndex = 15
        Me.umskStartDate.Tag = ".StartDate........Now"
        Me.umskStartDate.Text = "//"
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(221, 305)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(77, 18)
        Me.Label20.TabIndex = 105
        Me.Label20.Text = "Cust. Ref.:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'umskCloseTime
        '
        Me.umskCloseTime.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.umskCloseTime.Location = New System.Drawing.Point(378, 231)
        Me.umskCloseTime.Name = "umskCloseTime"
        Me.umskCloseTime.Size = New System.Drawing.Size(44, 22)
        Me.umskCloseTime.TabIndex = 14
        Me.umskCloseTime.Tag = ".CloseTime"
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(294, 234)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(86, 19)
        Me.Label17.TabIndex = 102
        Me.Label17.Text = "Close Time :"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'umskOpenTime
        '
        Me.umskOpenTime.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.umskOpenTime.Location = New System.Drawing.Point(251, 231)
        Me.umskOpenTime.Name = "umskOpenTime"
        Me.umskOpenTime.Size = New System.Drawing.Size(44, 22)
        Me.umskOpenTime.TabIndex = 13
        Me.umskOpenTime.Tag = ".OpenTime"
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(162, 234)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(85, 19)
        Me.Label16.TabIndex = 100
        Me.Label16.Text = "Open Time::"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'umskEndDate
        '
        Me.umskEndDate.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Date
        Me.umskEndDate.InputMask = "mm/dd/yyyy"
        Me.umskEndDate.Location = New System.Drawing.Point(240, 269)
        Me.umskEndDate.Name = "umskEndDate"
        Me.umskEndDate.Size = New System.Drawing.Size(86, 22)
        Me.umskEndDate.TabIndex = 16
        Me.umskEndDate.Tag = ".ENDDate"
        Me.umskEndDate.Text = "//"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(163, 269)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(77, 18)
        Me.Label7.TabIndex = 98
        Me.Label7.Text = "End Date:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(5, 269)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(77, 18)
        Me.Label6.TabIndex = 97
        Me.Label6.Text = "Start Date::"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkBoxKey
        '
        Me.chkBoxKey.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkBoxKey.Location = New System.Drawing.Point(422, 271)
        Me.chkBoxKey.Name = "chkBoxKey"
        Me.chkBoxKey.Size = New System.Drawing.Size(96, 19)
        Me.chkBoxKey.TabIndex = 18
        Me.chkBoxKey.Tag = ".BoxKey"
        Me.chkBoxKey.Text = "Box Key"
        Me.chkBoxKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkDoorKey
        '
        Me.chkDoorKey.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkDoorKey.Location = New System.Drawing.Point(336, 271)
        Me.chkDoorKey.Name = "chkDoorKey"
        Me.chkDoorKey.Size = New System.Drawing.Size(86, 19)
        Me.chkDoorKey.TabIndex = 17
        Me.chkDoorKey.Tag = ".DoorKey"
        Me.chkDoorKey.Text = "Door Key"
        Me.chkDoorKey.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LocID
        '
        Me.LocID.Location = New System.Drawing.Point(352, 18)
        Me.LocID.Name = "LocID"
        Me.LocID.Size = New System.Drawing.Size(9, 22)
        Me.LocID.TabIndex = 82
        Me.LocID.Tag = ".AddressId"
        Me.LocID.Text = ""
        Me.LocID.Visible = False
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(6, 339)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(77, 19)
        Me.Label18.TabIndex = 81
        Me.Label18.Text = "Remarks :"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Remarks
        '
        Me.Remarks.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Remarks.Location = New System.Drawing.Point(82, 336)
        Me.Remarks.Name = "Remarks"
        Me.Remarks.Size = New System.Drawing.Size(753, 22)
        Me.Remarks.TabIndex = 24
        Me.Remarks.Tag = ".Remarks"
        Me.Remarks.Text = ""
        '
        'Phone2
        '
        Me.Phone2.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.Phone2.InputMask = "(###)-###-####"
        Me.Phone2.Location = New System.Drawing.Point(316, 165)
        Me.Phone2.Name = "Phone2"
        Me.Phone2.Size = New System.Drawing.Size(105, 22)
        Me.Phone2.TabIndex = 8
        Me.Phone2.Tag = ".PHONE2"
        Me.Phone2.Text = "()--"
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(244, 167)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(67, 19)
        Me.Label13.TabIndex = 74
        Me.Label13.Text = "Phone 2:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Phone1
        '
        Me.Phone1.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.Phone1.InputMask = "(###)-###-####"
        Me.Phone1.Location = New System.Drawing.Point(83, 164)
        Me.Phone1.Name = "Phone1"
        Me.Phone1.Size = New System.Drawing.Size(105, 22)
        Me.Phone1.TabIndex = 7
        Me.Phone1.Tag = ".PHONE1"
        Me.Phone1.Text = "()--"
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(10, 167)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(67, 19)
        Me.Label14.TabIndex = 73
        Me.Label14.Text = "Phone 1:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(16, 83)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(67, 19)
        Me.Label12.TabIndex = 70
        Me.Label12.Text = "Location :"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBox1
        '
        Me.TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox1.Location = New System.Drawing.Point(84, 83)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(262, 22)
        Me.TextBox1.TabIndex = 2
        Me.TextBox1.Tag = ".COMPNAME......Location Name"
        Me.TextBox1.Text = ""
        '
        'Zipcode
        '
        Me.Zipcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Zipcode.Location = New System.Drawing.Point(367, 135)
        Me.Zipcode.Name = "Zipcode"
        Me.Zipcode.Size = New System.Drawing.Size(55, 22)
        Me.Zipcode.TabIndex = 6
        Me.Zipcode.Tag = ".ZIPCODE"
        Me.Zipcode.Text = ""
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(326, 136)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 19)
        Me.Label3.TabIndex = 67
        Me.Label3.Text = "Zip :"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(224, 137)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 19)
        Me.Label4.TabIndex = 68
        Me.Label4.Text = "State:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(29, 136)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 19)
        Me.Label9.TabIndex = 66
        Me.Label9.Text = "City:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'City
        '
        Me.City.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.City.Location = New System.Drawing.Point(82, 136)
        Me.City.Name = "City"
        Me.City.Size = New System.Drawing.Size(144, 22)
        Me.City.TabIndex = 4
        Me.City.Tag = ".CITYNAME......City"
        Me.City.Text = ""
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(16, 110)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(67, 18)
        Me.Label10.TabIndex = 65
        Me.Label10.Text = "Address:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Street
        '
        Me.Street.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Street.Location = New System.Drawing.Point(82, 110)
        Me.Street.Name = "Street"
        Me.Street.Size = New System.Drawing.Size(340, 22)
        Me.Street.TabIndex = 3
        Me.Street.Tag = ".STREET"
        Me.Street.Text = ""
        '
        'RowID
        '
        Me.RowID.Location = New System.Drawing.Point(368, 18)
        Me.RowID.Name = "RowID"
        Me.RowID.Size = New System.Drawing.Size(10, 22)
        Me.RowID.TabIndex = 9
        Me.RowID.Tag = ".RowID.View"
        Me.RowID.Text = ""
        Me.RowID.Visible = False
        '
        'TextBox10
        '
        Me.TextBox10.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox10.Location = New System.Drawing.Point(83, 305)
        Me.TextBox10.Name = "TextBox10"
        Me.TextBox10.Size = New System.Drawing.Size(134, 22)
        Me.TextBox10.TabIndex = 21
        Me.TextBox10.Tag = ".InternalRef"
        Me.TextBox10.Text = ""
        '
        'TextBox11
        '
        Me.TextBox11.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox11.Location = New System.Drawing.Point(298, 305)
        Me.TextBox11.Name = "TextBox11"
        Me.TextBox11.Size = New System.Drawing.Size(129, 22)
        Me.TextBox11.TabIndex = 22
        Me.TextBox11.Tag = ".AccountRef"
        Me.TextBox11.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(10, 305)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 18)
        Me.Label1.TabIndex = 95
        Me.Label1.Text = "Intrnl. Ref.:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'chkSbjWgt
        '
        Me.chkSbjWgt.Location = New System.Drawing.Point(730, 270)
        Me.chkSbjWgt.Name = "chkSbjWgt"
        Me.chkSbjWgt.Size = New System.Drawing.Size(103, 18)
        Me.chkSbjWgt.TabIndex = 20
        Me.chkSbjWgt.Tag = ".[Subj To Wgt]."
        Me.chkSbjWgt.Text = "Subj. to Wgt."
        '
        'btnPrev
        '
        Me.btnPrev.Enabled = False
        Me.btnPrev.Image = CType(resources.GetObject("btnPrev.Image"), System.Drawing.Image)
        Me.btnPrev.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPrev.Location = New System.Drawing.Point(125, 74)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(29, 24)
        Me.btnPrev.TabIndex = 4
        '
        'btnNext
        '
        Me.btnNext.Enabled = False
        Me.btnNext.Image = CType(resources.GetObject("btnNext.Image"), System.Drawing.Image)
        Me.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNext.Location = New System.Drawing.Point(154, 74)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(28, 24)
        Me.btnNext.TabIndex = 5
        '
        'Label21
        '
        Me.Label21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label21.Location = New System.Drawing.Point(4, 52)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(38, 18)
        Me.Label21.TabIndex = 112
        Me.Label21.Text = "SID :"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SrvcID
        '
        Me.SrvcID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.SrvcID.Location = New System.Drawing.Point(47, 50)
        Me.SrvcID.Name = "SrvcID"
        Me.SrvcID.Size = New System.Drawing.Size(57, 22)
        Me.SrvcID.TabIndex = 2
        Me.SrvcID.Tag = ".ID.view.....SID"
        Me.SrvcID.Text = ""
        '
        'btnAcct
        '
        Me.btnAcct.Location = New System.Drawing.Point(121, 18)
        Me.btnAcct.Name = "btnAcct"
        Me.btnAcct.Size = New System.Drawing.Size(66, 25)
        Me.btnAcct.TabIndex = 1
        Me.btnAcct.Text = "Select"
        '
        'AcctID
        '
        Me.AcctID.Location = New System.Drawing.Point(48, 18)
        Me.AcctID.Name = "AcctID"
        Me.AcctID.Size = New System.Drawing.Size(58, 22)
        Me.AcctID.TabIndex = 0
        Me.AcctID.Tag = ".AccountID"
        Me.AcctID.Text = ""
        '
        'Label5
        '
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(2, 20)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(39, 18)
        Me.Label5.TabIndex = 108
        Me.Label5.Text = "Ac #:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.txtID)
        Me.GroupBox3.Controls.Add(Me.chkNRvnu)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.AcctID)
        Me.GroupBox3.Controls.Add(Me.btnAcct)
        Me.GroupBox3.Controls.Add(Me.SrvcID)
        Me.GroupBox3.Controls.Add(Me.btnPrev)
        Me.GroupBox3.Controls.Add(Me.btnSID)
        Me.GroupBox3.Controls.Add(Me.btnNext)
        Me.GroupBox3.Controls.Add(Me.Label21)
        Me.GroupBox3.Controls.Add(Me.btnSIDGroup)
        Me.GroupBox3.Controls.Add(Me.btnWgtPlans)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(203, 175)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Account && Service IDs"
        '
        'txtID
        '
        Me.txtID.Location = New System.Drawing.Point(48, 76)
        Me.txtID.Name = "txtID"
        Me.txtID.Size = New System.Drawing.Size(48, 22)
        Me.txtID.TabIndex = 172
        Me.txtID.Tag = ".ID"
        Me.txtID.Text = ""
        Me.txtID.Visible = False
        '
        'chkNRvnu
        '
        Me.chkNRvnu.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkNRvnu.Location = New System.Drawing.Point(10, 83)
        Me.chkNRvnu.Name = "chkNRvnu"
        Me.chkNRvnu.Size = New System.Drawing.Size(19, 19)
        Me.chkNRvnu.TabIndex = 144
        Me.chkNRvnu.Tag = ".NRVNU.view"
        Me.chkNRvnu.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.chkNRvnu.Visible = False
        '
        'btnSID
        '
        Me.btnSID.Enabled = False
        Me.btnSID.Location = New System.Drawing.Point(121, 50)
        Me.btnSID.Name = "btnSID"
        Me.btnSID.Size = New System.Drawing.Size(67, 24)
        Me.btnSID.TabIndex = 3
        Me.btnSID.Text = "Select"
        '
        'btnSIDGroup
        '
        Me.btnSIDGroup.Location = New System.Drawing.Point(48, 111)
        Me.btnSIDGroup.Name = "btnSIDGroup"
        Me.btnSIDGroup.Size = New System.Drawing.Size(96, 24)
        Me.btnSIDGroup.TabIndex = 7
        Me.btnSIDGroup.Text = "Groups"
        '
        'btnWgtPlans
        '
        Me.btnWgtPlans.Location = New System.Drawing.Point(48, 144)
        Me.btnWgtPlans.Name = "btnWgtPlans"
        Me.btnWgtPlans.Size = New System.Drawing.Size(96, 24)
        Me.btnWgtPlans.TabIndex = 154
        Me.btnWgtPlans.Text = "Weight Plan"
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Location = New System.Drawing.Point(106, 46)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(76, 24)
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "E&xit"
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(19, 15)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(77, 24)
        Me.btnNew.TabIndex = 0
        Me.btnNew.Text = "&New"
        '
        'btnEdit
        '
        Me.btnEdit.Enabled = False
        Me.btnEdit.Location = New System.Drawing.Point(106, 15)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(76, 24)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "&Edit"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(19, 46)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(77, 24)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "&Save"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnEdit)
        Me.GroupBox1.Controls.Add(Me.btnSave)
        Me.GroupBox1.Controls.Add(Me.btnNew)
        Me.GroupBox1.Controls.Add(Me.btnExit)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 295)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(201, 74)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Panel3)
        Me.GroupBox4.Location = New System.Drawing.Point(10, 183)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(201, 111)
        Me.GroupBox4.TabIndex = 2
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Charges"
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.cboBillingCycle)
        Me.Panel3.Controls.Add(Me.Label31)
        Me.Panel3.Controls.Add(Me.Label8)
        Me.Panel3.Controls.Add(Me.Charge)
        Me.Panel3.Controls.Add(Me.Label15)
        Me.Panel3.Controls.Add(Me.DailyAvg)
        Me.Panel3.Location = New System.Drawing.Point(11, 18)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(181, 84)
        Me.Panel3.TabIndex = 11
        '
        'cboBillingCycle
        '
        Me.cboBillingCycle.Enabled = False
        Me.cboBillingCycle.Location = New System.Drawing.Point(73, 57)
        Me.cboBillingCycle.Name = "cboBillingCycle"
        Me.cboBillingCycle.Size = New System.Drawing.Size(100, 24)
        Me.cboBillingCycle.TabIndex = 2
        Me.cboBillingCycle.Tag = ".BCycleCode.View.1.BillingCycles.CODE.Name"
        '
        'Label31
        '
        Me.Label31.Location = New System.Drawing.Point(6, 60)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(64, 18)
        Me.Label31.TabIndex = 142
        Me.Label31.Text = "B. Cycle :"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(16, 29)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(57, 18)
        Me.Label8.TabIndex = 122
        Me.Label8.Text = "D.Avg. :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Charge
        '
        Me.Charge.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Charge.Location = New System.Drawing.Point(73, 3)
        Me.Charge.Name = "Charge"
        Me.Charge.Size = New System.Drawing.Size(71, 22)
        Me.Charge.TabIndex = 0
        Me.Charge.Tag = ".Charge"
        Me.Charge.Text = "0"
        Me.Charge.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(22, 3)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(48, 19)
        Me.Label15.TabIndex = 121
        Me.Label15.Text = "Chg. :"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DailyAvg
        '
        Me.DailyAvg.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.DailyAvg.Location = New System.Drawing.Point(73, 29)
        Me.DailyAvg.Name = "DailyAvg"
        Me.DailyAvg.ReadOnly = True
        Me.DailyAvg.Size = New System.Drawing.Size(71, 22)
        Me.DailyAvg.TabIndex = 1
        Me.DailyAvg.TabStop = False
        Me.DailyAvg.Tag = ".DailyAvgChg......Daily Avg"
        Me.DailyAvg.Text = "0"
        Me.DailyAvg.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'UltraGrid2
        '
        Me.UltraGrid2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UltraGrid2.Location = New System.Drawing.Point(0, 372)
        Me.UltraGrid2.Name = "UltraGrid2"
        Me.UltraGrid2.Size = New System.Drawing.Size(1159, 249)
        Me.UltraGrid2.TabIndex = 4
        Me.UltraGrid2.TabStop = False
        Me.UltraGrid2.Text = "Account Services"
        '
        'AcctSvcSchedule
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(1159, 621)
        Me.Controls.Add(Me.UltraGrid2)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D
        Me.Name = "AcctSvcSchedule"
        Me.Tag = "AccountServices"
        Me.Text = "Account Service Schedule"
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.UltraDate1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucboState, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucboPackage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucboService, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucboTimeFrame, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucboSvcType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox4.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.UltraGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region


    Private Sub AcctSvcSchedule_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dtaStates As New SqlDataAdapter()
        Dim MinWinSize As System.Drawing.Size


        AddHandler Me.Activated, AddressOf Form_Activated
        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = ROUTESTblPath & Me.Tag
            End If
        End If

        EnabledStatus = True
        btnWgtPlans.Enabled = False
        Me.CenterToScreen()

        Me.KeyPreview = True
        MeText = Me.Text

        ' Set each control's length based on DB size
        SetupCtrlsLength(Me, ROUTESDBName, ROUTESDBUser, ROUTESDBPass)

        'AddHandler State.KeyPress, AddressOf CBO_Search
        'AddHandler State.KeyUp, AddressOf CBO_KeyUp
        'AddHandler State.Leave, AddressOf CBO_Leave

        'AddHandler cboSvcType.KeyPress, AddressOf CBO_Search
        'AddHandler cboSvcType.KeyUp, AddressOf CBO_KeyUp
        'AddHandler cboSvcType.Leave, AddressOf CBO_Leave

        'AddHandler cboTimeFrame.KeyPress, AddressOf CBO_Search
        'AddHandler cboTimeFrame.KeyUp, AddressOf CBO_KeyUp
        'AddHandler cboTimeFrame.Leave, AddressOf CBO_Leave

        'AddHandler cboService.KeyPress, AddressOf CBO_Search
        'AddHandler cboService.KeyUp, AddressOf CBO_KeyUp
        'AddHandler cboService.Leave, AddressOf CBO_Leave

        'AddHandler cboPackage.KeyPress, AddressOf CBO_Search
        'AddHandler cboPackage.KeyUp, AddressOf CBO_KeyUp
        'AddHandler cboPackage.Leave, AddressOf CBO_Leave

        'AddHandler Me.KeyUp, AddressOf Form_KeyUp
        AddHandler umskStartDate.Validating, AddressOf umskDate_Validating
        AddHandler umskEndDate.Validating, AddressOf umskDate_Validating

        'FillCombo(State, "CA")
        'FillCombo(cboSvcType, "")
        'FillCombo(cboTimeFrame, "")
        'FillCombo(cboService, "")
        'FillCombo(cboPackage, "")

        FillUCombo(ucboState, "CA")
        FillUCombo(ucboSvcType, "")
        FillUCombo(ucboTimeFrame, "", "", "", ROUTESTblPath)
        FillUCombo(ucboService, "")
        FillUCombo(ucboPackage, "")
        FillCombo(cboBillingCycle, "")

        AddHandler ucboSvcType.Leave, AddressOf UCbo_Leave
        AddHandler ucboSvcType.Leave, AddressOf UCbo_Leave
        AddHandler ucboService.Leave, AddressOf UCbo_Leave
        AddHandler ucboPackage.Leave, AddressOf UCbo_Leave
        AddHandler ucboState.Leave, AddressOf UCbo_Leave

        rbWeekly.Checked = True

        SetupSchCols()
        AddWeeklyRows()
        'SetSchedDSBlank(StatusTable)

        '''PrepData(StatusTable)
        ''SetupSchedGrid(StatusTable)

        'cboStatus.DataSource = StatusTable
        'cboStatus.DisplayMember = "Status"
        'cboStatus.ValueMember = "Code"
        Group_EnDis(False)
        umskOpenTime.InputMask = "hh:mm"
        umskCloseTime.InputMask = "hh:mm"

        SvcCancelGroupChk()
        SbjWgtModified = False

        dtaStates = Nothing
    End Sub

    Private Sub Group_EnDis(ByVal status As Boolean)
        'Make Group Read-Only
        'ReadOnlyControls(Container, True/False)
        ReadOnlyControls(GroupBox2, Not status)
        'GroupBox2.Enabled = status

        GroupBox3.Enabled = Not status
        GroupBox4.Enabled = status
        'GroupBox5.Enabled = status
        btnSave.Enabled = status
        'SrvcID.Enabled = Not status
        btnSave.Text = "&Save"
        EnabledStatus = status
        'Label24.ForeColor = Color.Black
        'Label24.BackColor = Color.Beige
        'Label25.ForeColor = Color.Black
    End Sub

    ''Private Sub LoadData()

    ''    Dim dtAdapter As SqlDataAdapter
    ''    Dim CritTmp As String
    ''    Dim dvSrvc As New DataView()

    ''    If Not UltraGrid2.DataSource Is Nothing Then
    ''        'UGSaveLayout(Me, Ultragrid2, 1)
    ''    End If

    ''    CritTmp = AcctCriteria.Replace("@AcctID", AcctID.Text) & " AND " & SIDCriteria.Replace("@SID", SrvcID.Text)
    ''    CritTmp = PrepSelectQuery(SQLSelect, CritTmp)

    ''    If PopulateDataset2(dtAdapter, dtSet, CritTmp) Is Nothing Then
    ''        Exit Sub
    ''    End If

    ''    btnSave.Text = "&Save"

    ''    dvSrvc.Table = dtSet.Tables(0)
    ''    FormLoad(Me, dvSrvc)
    ''    dvSrvc = Nothing

    ''    SCH_WEEKLY = rbWeekly.Checked

    ''    'If Val(InfoSID.Text) > 0 Then
    ''    '    HighLightService(InfoSID.Text)
    ''    'End If
    ''End Sub

    Private Sub LoadGrid2Data(ByVal dtTable As DataTable)
        'Dim dstmp As New DataSet()
        'Dim tbltmp As New DataTable()
        'tbltmp = dtTable

        'dstmp.Tables.Add(tbltmp)

        btnSave.Text = "&Save"

        FillUltraGrid(UltraGrid2, dtTable, 1, HidCols)
        'UGLoadLayout(Me, UltraGrid2, 1)

        UltraGrid2.DisplayLayout.GroupByBox.Hidden = False
        UltraGrid2.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        UltraGrid2.DisplayLayout.Bands(0).AutoPreviewField = "Remarks"
        UltraGrid2.DisplayLayout.Bands(0).AutoPreviewEnabled = True
        With UltraGrid2.DisplayLayout.Override
            .RowSpacingAfter = 5
            .RowPreviewAppearance.BackColor = System.Drawing.Color.Aqua ' UltraGrid2.DisplayLayout.Override.RowAppearance.BackColor 'SystemColors.Window
            .RowPreviewAppearance.ForeColor = SystemColors.WindowText
        End With
        'UltraGrid2.DisplayLayout.AddNewBox.Hidden = False
    End Sub

    Private Sub LoadGridData()


        'If dtSet.Tables.Count > 1 Then
        '    If dtSet.Tables(1).Rows(0)("Tbl") = "GRP" Then
        '        LoadGrid2Data(dtSet.Tables(1))
        '    ElseIf dtSet.Tables.Count > 2 Then
        '        If dtSet.Tables(2).Rows(0)("Tbl") = "GRP" Then
        '            LoadGrid2Data(dtSet.Tables(2))
        '        End If
        '    End If
        'End If


        If dtSet.Tables.Count > 1 Then
            If dtSet.Tables(2).Rows.Count > 0 Then
                If Not UltraGrid2.DataSource Is Nothing Then
                    'UltraGrid2.DataSource = dtSet.Tables(2)
                    LoadGrid2Data(dtSet.Tables(2))
                Else
                    'UltraGrid2.DataSource = dtSet.Tables(2)
                    LoadGrid2Data(dtSet.Tables(2))
                End If
            Else
                Dim tbl As DataView
                tbl = UltraGrid2.DataSource
                If Not tbl Is Nothing Then
                    If tbl.Table.Rows.Count > 0 Then
                        tbl.Table.Rows.Clear()
                    End If
                End If
                tbl = Nothing
                'LoadGrid2Data(dtSet.Tables(2))
                'UltraGrid2.DataSource = Nothing
            End If
        End If

        Exit Sub


        Dim dtAdapter As SqlDataAdapter
        Dim CritTmp As String

        If Not UltraGrid2.DataSource Is Nothing Then
            'UGSaveLayout(Me, Ultragrid2, 1)
        End If

        ''--------------------------------------------
        ''All Account's SIDs
        'CritTmp = AcctCriteria.Replace("@AcctID", AcctID.Text)
        ''--------------------------------------------
        ''All SIDs in membered groups
        ''============================================
        CritTmp = " Where convert(varchar, mft.AccountID)+convert(varchar,mft.ID) in (Select convert(varchar, AccountID)+convert(varchar,SID) FROM " & ROUTESTblPath & "ServiceGroupMembers where SGroupID in (select sgroupID FROM " & ROUTESTblPath & "ServiceGroupMembers Where AccountID = " & AcctID.Text & " AND SID = " & SrvcID.Text & "))"
        ''============================================

        ''Dim tm1, tm2, tm3 As DateTime
        ''tm1 = Now
        CritTmp = PrepSelectQuery(SQLSelect, CritTmp)
        If PopulateDataset2(dtAdapter, dtSet, CritTmp) Is Nothing Then
            Exit Sub
        End If

        ''tm2 = Now
        ''MsgBox("LoadGridDate : After Populate : " & tm2.Subtract(tm1).ToString)

        If dtSet.Tables(0).Rows.Count = 0 Then
        End If
        btnSave.Text = "&Save"

        ''tm3 = Now

        FillUltraGrid(UltraGrid2, dtSet, 1, HidCols)

        ''tm2 = Now
        ''MsgBox("LoadGridData : After FillUltrGrid, Total : " & tm2.Subtract(tm1).ToString & " - Fill Time : " & tm2.Subtract(tm3).ToString)

        ''tm3 = Now

        UGLoadLayout(Me, UltraGrid2, 1)

        ''tm2 = Now
        ''MsgBox("LoadGridData : After Layout, Total : " & tm2.Subtract(tm1).ToString & " - LoadLayout Time : " & tm2.Subtract(tm3).ToString)

        UltraGrid2.DisplayLayout.GroupByBox.Hidden = False
        UltraGrid2.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        UltraGrid2.DisplayLayout.Bands(0).AutoPreviewField = "Remarks"
        UltraGrid2.DisplayLayout.Bands(0).AutoPreviewEnabled = True
        With UltraGrid2.DisplayLayout.Override
            .RowSpacingAfter = 5
            .RowPreviewAppearance.BackColor = System.Drawing.Color.Aqua ' UltraGrid2.DisplayLayout.Override.RowAppearance.BackColor 'SystemColors.Window
            .RowPreviewAppearance.ForeColor = SystemColors.WindowText
        End With
        'UltraGrid2.DisplayLayout.AddNewBox.Hidden = False

        dtAdapter = Nothing
    End Sub

    Private Sub Value_Int_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles AcctID.KeyPress, SrvcID.KeyPress, Zipcode.KeyPress
        If IsNumeric(e.KeyChar) = False And Asc(e.KeyChar) <> Keys.Back Then
            e.Handled = True
        End If
    End Sub

    Private Sub Value_Dec_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If IsNumeric(e.KeyChar) = False And Asc(e.KeyChar) <> Keys.Back And e.KeyChar <> "." Then
            e.Handled = True
        End If
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim cnt As Integer
        Dim ID As Integer
        Dim Condition As String
        Dim dtrow As DataRow

        If AcctID.Text.Trim = "" Then
            MessageBox.Show("Account is not selected.")
            Exit Sub
        End If

        'Me.TextBox1.Modified = True
        'If Not SearchOnLeave(Me.TextBox1, LocID, AppTblPath & "Address Addr", , , "*", "Locations", "customerid = " & AcctID.Text) Then
        '    MessageBox.Show("Invalid Location.")
        '    Me.btnLocation.Focus()
        '    Exit Sub
        'End If

        If TextBox1.Text.Trim = "" Then
            MessageBox.Show("Location information must be entered.")
            TextBox1.Focus()
            Exit Sub
        End If

        If Street.Text.Trim = "" Then
            MessageBox.Show("Street information must be entered.")
            Street.Focus()
            Exit Sub
        End If

        If City.Text.Trim = "" Then
            MessageBox.Show("City information must be entered.")
            City.Focus()
            Exit Sub
        End If

        If ucboState.Text.Trim = "" Then
            MessageBox.Show("State information must be entered.")
            ucboState.Focus()
            Exit Sub
        End If

        If Zipcode.Text.Trim = "" Then
            MessageBox.Show("Zipcode information must be entered.")
            Zipcode.Focus()
            Exit Sub
        End If

        ' ucboState.Text.Trim = "" Or Zipcode.Text.Trim = "") And btnNew.Text = "&Cancel" 

        If TypeOf umskStartDate.Value Is DBNull Then
            MessageBox.Show("Start Date must be entered.")
            umskStartDate.Focus()
            Exit Sub
        End If

        If SrvcID.Text.Trim = "" And btnNew.Text = "&New" Then
            MessageBox.Show("ServiceID is not valid.")
            Exit Sub
        End If

        If TextBox10.Text.Length > 20 Then
            TextBox10.Text = Mid(TextBox10.Text, 1, 20)
        End If

        If btnNew.Text = "&New" Then
            Condition = " Where AccountID = " & AcctID.Text & " AND ID = " & SrvcID.Text
        Else
            Condition = " Where AccountID = " & AcctID.Text

            If ReturnRowByID(AcctID.Text, dtrow, ROUTESTblPath & "AccountServices as1", "AND as1.id = (SELECT MAX(id) FROM " & ROUTESTblPath & "accountservices as2 WHERE as2.accountid = as1.accountid)", "AccountID") Then
                txtID.Text = dtrow("ID") + 1
            Else
                txtID.Text = "1"
            End If
        End If

        If (LocID.Text = "0" Or LocID.Text = "") And Zipcode.Text <> "" Then
            If ReturnRowByID(Zipcode.Text, dtrow, "City", , "Zipcode") Then
                'If ReturnRowByID(LocID.Text, dtrow, "Address") Then
                LocID.Text = dtrow("ID")
            End If
        End If

        If CheckSched() = False Then Exit Sub

        If (umskEndDate.GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw) <> "") And (p_bRestartMode = False) Then
            If IsFutureDate(umskEndDate.GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth)) <> 1 Then
                If chkNRvnu.Checked Then
                    'Check if it's single with another Non revenu Account in any group
                    Dim FindSID As String = "Select SGroupID FROM " & ROUTESTblPath & "ServiceGroupMembers, " & AppTblPath & "Customer c where SGroupID in (Select SGroupID FROM " & ROUTESTblPath & "ServiceGroupMembers where AccountID = " & AcctID.Text & " AND SID = " & SrvcID.Text & " group by SGroupID having Count(SGroupID) = 2) and c.NRVNU = 1 AND SID <> " & SrvcID.Text & " AND AccountID = c.ID "
                    Dim dtAdapter As SqlDataAdapter
                    Dim dtSetTmp As New DataSet
                    Dim i As Integer

                    If Not PopulateDataset2(dtAdapter, dtSetTmp, FindSID) Is Nothing Then
                        If dtSetTmp.Tables(0).Rows.Count > 0 Then
                            Dim GrpList As String
                            GrpList = dtSetTmp.Tables(0).Rows(0).Item(0)
                            For i = 1 To dtSetTmp.Tables(0).Rows.Count - 1
                                GrpList = GrpList & ", " & dtSetTmp.Tables(0).Rows(i).Item(0)
                            Next
                            MsgBox("Group(s) that have NonRevenue Service(s) :" & vbCrLf & GrpList)
                            dtSetTmp.Dispose()
                            dtSetTmp = Nothing
                            Exit Sub
                        End If
                    End If
                    dtSetTmp.Dispose()
                    dtSetTmp = Nothing
                    dtAdapter = Nothing
                End If
                If TextBox1.Text.Substring(0, 1) <> "*" Then
                    TextBox1.Text = "*" & TextBox1.Text
                End If
            End If
        Else
            p_bRestartMode = False
            'If umskEndDate.GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw) = "" Then
            If TextBox1.Text <> "" Then
                If TextBox1.Text.Substring(0, 1) = "*" Then
                    TextBox1.Text = TextBox1.Text.Substring(1)
                End If
            End If
            'End If
        End If

        If EditForm(Me, SQLEdit, EditAction.ENDEDIT, cmdTrans, Condition) Then
            Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
            Dim row As DataRow
            If btnNew.Text <> "&New" Then
                If ReturnRowByID(AcctID.Text, row, ROUTESTblPath & "AccountServices as1", "AND as1.id = (SELECT MAX(id) FROM " & ROUTESTblPath & "accountservices as2 WHERE as2.accountid = as1.accountid)", "AccountID") Then
                    SrvcID.Text = row("ID")
                    row = Nothing
                End If
            End If
            SaveSched()
            If umskEndDate.GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw) <> "" Then
                'Check to See if Account is Non revenue account
                If chkNRvnu.Checked Then
                    SvcCancelGroupChk()
                    'Dim DelSID As String = "Delete FROM " & ROUTESTblPath & "ServiceGroupMembers where AccountID = " & AcctID.Text & " AND SID = " & SrvcID.Text
                    'If ExecuteQuery(DelSID) = False Then
                    '    MsgBox("Error Deleting from Members Table.")
                    'End If
                End If
            End If
            btnEdit.Text = "&Edit"
            btnNew.Text = "&New"
            'Weight Module
            If SbjWgtModified = True And chkSbjWgt.Checked = False And WgtPlanID.Text.Trim <> "" Then
                ' Also Refresh any Open Weight Screen??
                If ExecuteQuery("Update " & WeightVars.WEIGHTTblPath & "Manifests set EndDate = getdate(), Name = '*'+Name Where ID = " & WgtPlanID.Text.Trim & " AND EndDate is NULL") = False Then
                    MsgBox("Error Updating Weight Plan Record.")
                End If
            End If
            If umskEndDate.GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw) <> "" And WgtPlanID.Text.Trim <> "" Then
                ' Also Refresh any Open Weight Screen??
                If ExecuteQuery("Update " & WeightVars.WEIGHTTblPath & "Manifests set EndDate = '" & umskEndDate.GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth) & "', Name = '*'+Name Where ID = " & WgtPlanID.Text.Trim & " AND EndDate is NULL") = False Then
                    MsgBox("Error Updating Weight Plan Record.")
                End If
            End If
            SbjWgtModified = False

            If SrvcID.Text.Trim = "" Then
                LoadBySID(SrvcID, "P")
            Else
                LoadBySID(SrvcID)
            End If
            LoadGridData()
            'ugRow = UltraGrid2.GetRow(Infragistics.Win.UltraWinGrid.ChildRow.Last)
            'SrvcID.Text = ugRow.Cells("ID").Value
            'ugRow = Nothing

            'Me.Text = MeText & " -- Record Updated."
            ''UltraGrid2.Enabled = True
            Group_EnDis(False)
            ''UltraGrid2.Focus()
            'UltraGrid2.Refresh()
            EnDisRadioBtns(True)
        End If

    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click

        Panel1.Enabled = False
        Panel2.Enabled = False

        ' Lock Records
        'If RowID.Text.Trim = "" Then Exit Sub
        If btnNew.Text = "&Cancel" Then
            MessageBox.Show("You are in 'New' mode. Cancel or Save your current job first.")
            Exit Sub
        End If

        If sender.text.toupper = "&EDIT" Then
            If EditForm(Me, PrepSelectQuery(SQLEdit, " Where RowID = " & RowID.Text), EditAction.START, cmdTrans) Then
                ''UltraGrid2.Enabled = False
                Me.Charge.TabIndex = 0
                Group_EnDis(True)
                EnDisDeleteBtns()
                EnDisRadioBtns(False)
                'Disable the Panel1
                'Panel1.Enabled = True
                UltraGrid1.DisplayLayout.Appearance.ForeColor = System.Drawing.Color.Black
                sender.text = "&Cancel"
                DailyBCycle()
                TextBox1.Focus()
                'Dim oRow As Infragistics.Win.UltraWinGrid.UltraGridRow
                'oRow = UltraGrid2.ActiveRow
                'If oRow Is Nothing Then oRow = Me.UltraGrid2.GetRow(Infragistics.Win.UltraWinGrid.ChildRow.First)
                'UltraGrid1.ActiveRow = oRow
                UltraGrid1.ActiveRow = UltraGrid1.Rows(1)
                UltraGrid1.ActiveRow = UltraGrid1.Rows(0)
                'If oRow.Cells("Ofc").Text <> "" And oRow.Cells("Rte").Text <> "" And oRow.Cells("Stp").Text <> "" Then
                'btnDel1.Enabled = True
                'End If
            End If
        Else
            If EditForm(Me, SQLSelect, EditAction.CANCEL, cmdTrans) Then
                ''UltraGrid2.Enabled = True
                LoadBySID(SrvcID)
                Group_EnDis(False)
                sender.text = "&Edit"
                'FormLoad(Me, dvCompany)
            End If
        End If
    End Sub

    Private Sub EnDisDeleteBtns()
        Me.btnDel1.Enabled = False
        Me.btnDel2.Enabled = False
        Me.btnDel3.Enabled = False
        Me.btnDel4.Enabled = False
        Me.btnDel5.Enabled = False
        Me.btnDel6.Enabled = False
        Me.btnDel7.Enabled = False

    End Sub

    Private Sub EnDisRadioBtns(ByVal boolOnOff As Boolean)
        'Me.rbMTWTF.Enabled = boolOnOff
        'Me.rbMTWT.Enabled = boolOnOff
        'Me.rbMWF.Enabled = boolOnOff
        'Me.rbTT.Enabled = boolOnOff
        'Me.rbSS.Enabled = boolOnOff
        'Me.rbOther.Enabled = boolOnOff

        Me.rbMTWTF.TabStop = boolOnOff
        Me.rbMTWT.TabStop = boolOnOff
        Me.rbMWF.TabStop = boolOnOff
        Me.rbTT.TabStop = boolOnOff
        Me.rbSS.TabStop = boolOnOff
        Me.rbOther.TabStop = boolOnOff
        Me.rbWeekly.TabStop = boolOnOff
        Me.rbCalendar.TabStop = boolOnOff
        Me.rbWeekly.Enabled = True
        Me.rbCalendar.Enabled = True
    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        'If Not cmdTrans Is Nothing Then
        '    If EditForm(Me, PrepSelectQuery(SQLEdit, " Where RowID = " & RowID.Text), EditAction.CANCEL, cmdTrans) Then
        '        Group_EnDis(False)
        '        sender.text = "&Edit"
        '    Else
        '        'Exit Sub
        '    End If

        'End If
        ''UGSaveLayout(Me, Ultragrid2, 1)
        Me.Close()
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click

        Panel1.Enabled = False
        Panel2.Enabled = False
        'Ultragrid2.DeleteSelectedRows()
        If Val(AcctID.Text) <= 0 Then
            MsgBox("Please select an Account.")
            Exit Sub
        End If

        If btnEdit.Text = "&Cancel" Then
            MessageBox.Show("You are in 'Edit' mode. Cancel or Save your current job first.")
            Exit Sub
        End If
        If sender.text = "&New" Then
            ''UltraGrid2.Enabled = False
            sender.text = "&Cancel"
            ClearForm(GroupBox2)
            ClearForm(GroupBox4)
            Group_EnDis(True)
            EnDisDeleteBtns()
            DailyBCycle()
            Charge.Text = "0.00"
            DailyAvg.Text = "0.00"
            'InfoSID.Text = "0"
            SrvcID.Text = ""
            EnDisRadioBtns(True)
            If rbWeekly.Checked = True Then
                ResetSchedGrid()
            Else
                rbWeekly.Checked = True
            End If

            LoadNewSID()
            LoadGrid1()
            'Disable the Panel1
            'Panel1.Enabled = True
            TextBox1.Focus()

        Else
            SrvcID.Text = ""
            ClearForm(GroupBox2)
            ClearForm(GroupBox4)
            'Clear Grid1
            If rbWeekly.Checked = True Then
                ResetSchedGrid()
            Else
                rbWeekly.Checked = True
            End If
            'Disable the Panel1
            'Panel1.Enabled = False
            sender.text = "&New"
            ''UltraGrid1.Enabled = True
            Group_EnDis(False)

            UltraGrid2.Focus()
        End If
    End Sub

    Private Sub LoadNewSID(Optional ByVal Sender As TextBox = Nothing, Optional ByVal Direction As String = "C")
        Dim dtAdapter As SqlDataAdapter
        Dim dvAcct As New DataView
        Dim dtSet2 As New DataSet
        Dim TempQuery As String
        Dim CritTmp As String
        Dim dvSrvc As New DataView
        Dim IDValue As String = ""
        Dim spAcctID, spSIDSign, spSID As String

        Dim tm1, tm2, tm3 As DateTime
        tm1 = Now

        If Not Sender Is Nothing Then
            IDValue = Sender.Text
        End If
        'If Sender.Text.Trim = "" Then Exit Sub

        If Val(IDValue) > 0 Then
            CritTmp = SIDCriteria.Replace("@SID", IDValue)
        Else
            CritTmp = ""
        End If

        spSID = IDValue

        Select Case Direction.ToUpper
            Case "N"
                If CritTmp = "" Then
                    CritTmp = SIDCriteria.Replace("@SID", "0")
                    spSID = "0"
                End If
                CritTmp = CritTmp.Replace("=", ">")
                spSIDSign = ">"
            Case "C"
                spSIDSign = "="
            Case "P"
                If CritTmp = "" Then
                    CritTmp = SIDCriteria.Replace("@SID", "32000")
                    spSID = "32000"
                End If
                CritTmp = CritTmp.Replace("=", "<")
                spSIDSign = "<"
        End Select

        CritTmp = AcctCriteria.Replace("@AcctID", AcctID.Text) & " AND " & CritTmp

        spAcctID = AcctID.Text.Trim

        dtSet = GetspData(spAcctID, spSID, spSIDSign)

        dtAdapter = Nothing
        dvAcct = Nothing
        dtSet2 = Nothing
        dvSrvc = Nothing

    End Sub

    Private Sub AcctID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles AcctID.Leave
        Dim dbRow As DataRow
        If sender.Modified = False Then Exit Sub
        If sender.Text.Trim = "" Then
            ClearForm(Me)
            sender.Modified = False
            'Ultragrid2.DataSource = Nothing
            Exit Sub
        End If
        sender.modified = False

        If Val(sender.text) > 0 Then
            If ReturnRowByID(Val(sender.Text), dbRow, "CUSTOMER", " Status = 1") = False Then
                MsgBox("Account not found.")
                sender.Focus()
                sender.text = ""
                sender.Modified = False
                Exit Sub
            End If
            ClearForm(GroupBox2)
            ClearForm(GroupBox4)
            AcctName.Text = dbRow.Item("NAME")
            cboBillingCycle.SelectedValue = dbRow.Item("BCycleCode")

            sender.Modified = False
            SrvcID.Text = ""
            'Clear Grid1
            If rbWeekly.Checked = True Then
                ResetSchedGrid()
            Else
                rbWeekly.Checked = True
            End If

            If btnNew.Text.ToUpper <> "&NEW" Then Exit Sub
            'LoadGridData()
            UltraGrid2.DataSource = Nothing

            Call btnNext_Click(New System.Object, New System.EventArgs)

            If SrvcID.Text.Trim = "" Then
                Me.btnPrev.Enabled = False
                Me.btnNext.Enabled = False
                Me.btnSID.Enabled = False
                Me.btnSIDGroup.Enabled = False
                Me.SrvcID.Enabled = False
                Me.AcctID.Focus()
            Else
                Me.btnPrev.Enabled = True
                Me.btnNext.Enabled = True
                Me.btnSID.Enabled = True
                Me.btnSIDGroup.Enabled = True
                Me.SrvcID.Enabled = True
            End If


        End If

    End Sub
    Private Sub btnAcct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcct.Click
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet2 As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow

        SelectSQL = "Select ID, Name, CreateDate as [Create Date], Contact, Street, Cityname as City, State, ZipCode, Phone1, Phone2, Fax, Web " & _
                    " , LastBillDate as [L.Bill Date], BCycleCode as BCycle, DiscountRate as [Disc.Rate], TaxRate as [Tax Rate] " & _
                    " , FuelSurcharge as [F.Sur], IncreaseDate as [Inc.Date], IncreaseRate as [Inc.Rate], Status, AcctGroupID, SamePayAddress, NRVNU as NonRvnuAcct, BCycleCode" & _
                    " FROM " & AppTblPath & "Customer Where Status = 1 order by Name"

        PopulateDataset2(dtAdapter, dtSet2, SelectSQL)
        dtView.Table = dtSet2.Tables(0)
        If dtView.Table.Rows.Count > 0 Then
            Dim Srch As New SearchListings
            Srch.dsList = dtSet2

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
                    cboBillingCycle.SelectedValue = ugRow.Cells("BCycleCode").Text
                    Srch = Nothing
                    ClearForm(GroupBox2)
                    ClearForm(GroupBox4)
                    AcctID.Modified = False
                    SrvcID.Text = ""
                    UltraGrid2.DataSource = Nothing
                    'rbWeekly.Checked = Not (rbWeekly.Checked)
                    If rbWeekly.Checked = True Then
                        ResetSchedGrid()
                    Else
                        rbWeekly.Checked = True
                    End If

                    If btnNew.Text.ToUpper = "&NEW" Then
                        'LoadGridData()
                        'Click on AcctID Select button displays first Location ID of the chosen account
                        Call btnNext_Click(New System.Object, New System.EventArgs)
                    End If
                End If

                dtAdapter = Nothing
                dtSet2 = Nothing
                dtView = Nothing
            End Try
        End If
    End Sub

    Private Sub State_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If sender.Focused Then
            City.Text = ""
            City.Modified = False
            Zipcode.Text = ""
            Zipcode.Modified = False
        Else
        End If
    End Sub

    Private Sub ucboState_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucboState.ValueChanged
        If sender.Focused Then
            City.Text = ""
            City.Modified = False
            Zipcode.Text = ""
            Zipcode.Modified = False
        Else
        End If
    End Sub

    Private Sub ucboState_RowSelected(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowSelectedEventArgs) Handles ucboState.RowSelected
        'City.Text = ""
        City.Modified = False
        Zipcode.Text = ""
        Zipcode.Modified = False
    End Sub


    Private Sub City_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles City.Leave, Zipcode.Leave
        Dim row As DataRow
        Dim FldName As String
        If sender.name = "City" Then
            FldName = "Name"
        Else
            FldName = "Zipcode"
        End If
        If sender.text.trim = "" Then
            LocID.Text = ""
            sender.text = ""
        ElseIf SearchOnLeave(sender, Zipcode, AppTblPath & "City", "ZipCode", FldName, "*", "Cities") Then
            If ReturnRowByID(Zipcode.Text, row, "City", , "Zipcode") Then
                'State.SelectedValue = row("StateCode")
                ucboState.Value = row("StateCode")
                Zipcode.Text = row("Zipcode")
                City.Text = row("Name")
                row = Nothing
            End If
        End If
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
        If sender.name = "umskOpenTime" Or sender.name = "umskCloseTime" Then
            Str = sender.GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw)
            Str = Str.PadLeft(2, "0").PadRight(4, "0")
            If Val(Str) / 100 < 24 And Val(Str) Mod 100 < 60 Then
                e.RetainFocus = False
                sender.Value = Str
            End If
        End If


    End Sub

    Private Sub TextBox1_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.Leave
        '**************************************************************************
        'SF - 5/5/2010 - Added CustomerID as new parameter for SearchOnLeave
        '**************************************************************************
        'Dim row As DataRow
        'If sender.text.trim = "" Then
        '    LocID.Text = ""
        '    sender.text = ""

        'ElseIf SearchOnLeave(sender, LocID, AppTblPath & "Address Addr", , , "*", "Locations", "customerid = " & AcctID.Text) Then
        '    If ReturnRowByID(LocID.Text, row, "Address") Then
        '        Street.Text = row("Street")
        '        City.Text = row("CityName")
        '        'State.SelectedValue = row("StateCode")
        '        ucboState.Value = row("StateCode")
        '        Zipcode.Text = row("Zipcode")
        '        Phone1.Text = row("Phone")
        '        'row.Table.DataSet = Nothing
        '        row = Nothing
        '    End If
        'End If

        Dim row As DataRow
        cleanNoRecords = False
        If sender.text.trim = "" Then
            LocID.Text = ""
            sender.text = ""
            'Exit Sub
            'End If
        ElseIf SearchOnLeave(sender, LocID, AppTblPath & "Address Addr", , , "*", "Locations", "customerid = " & AcctID.Text) Then
            If ReturnRowByID(LocID.Text, row, AppTblPath & "Address") Then
                Street.Text = row("Street")
                City.Text = row("CityName")
                'State.SelectedValue = row("StateCode")
                ucboState.Value = row("StateCode")
                Zipcode.Text = row("Zipcode")
                Phone1.Text = row("Phone")
                'row.Table.DataSet = Nothing
                row = Nothing
            End If
            'Else
            'MessageBox.Show("Invalid Location")
        End If

        If cleanNoRecords = True Then
            TextBox1.Text = ""
            Street.Text = ""
            City.Text = ""
            Phone1.Text = ""
            Phone2.Text = ""
            ucboState.Text = "CA"
            Zipcode.Text = ""
            Me.TextBox1.Focus()
            cleanNoRecords = False
            Exit Sub
        End If
        'sender.Modified = True
        'If Not SearchOnLeave(sender, LocID, AppTblPath & "Address Addr", , , "*", "Locations", "customerid = " & AcctID.Text) Then
        '    MessageBox.Show("Invalid Location")
        '    Me.btnLocation.Focus()
        'End If


    End Sub

    Private Sub Textbox1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles TextBox1.KeyUp
        '**************************************************************************
        'SF - 5/4/2010 - Added CustomerID as new parameter for TypeAhead
        '**************************************************************************
        TypeAhead(sender, e, AppTblPath & "Address", "Name", "customerid = " & AcctID.Text)
        'sender.modified = True
    End Sub

    Private Sub SrvcID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles SrvcID.Leave
        If sender.Modified Then
            If sender.text.trim = "" Then
                ClearForm(GroupBox2)
                ClearForm(GroupBox4)
                'Clear Grid1
                If rbWeekly.Checked = True Then
                    ResetSchedGrid()
                Else
                    rbWeekly.Checked = True
                End If
                UltraGrid2.DataSource = Nothing
            Else
                LoadBySID(sender)
            End If
        End If
    End Sub
    Private Function LoadPage()

    End Function

    Private Sub LoadBySID(Optional ByVal Sender As TextBox = Nothing, Optional ByVal Direction As String = "C")
        Dim dtAdapter As SqlDataAdapter
        Dim dvAcct As New DataView
        Dim dtSet2 As New DataSet
        Dim TempQuery As String
        Dim CritTmp As String
        Dim dvSrvc As New DataView
        Dim IDValue As String = ""
        Dim spAcctID, spSIDSign, spSID As String

        Dim tm1, tm2, tm3 As DateTime
        tm1 = Now

        If Not Sender Is Nothing Then
            IDValue = Sender.Text
        End If
        'If Sender.Text.Trim = "" Then Exit Sub

        If Val(IDValue) > 0 Then
            CritTmp = SIDCriteria.Replace("@SID", IDValue)
        Else
            CritTmp = ""
        End If

        spSID = IDValue

        Select Case Direction.ToUpper
            Case "N"
                If CritTmp = "" Then
                    CritTmp = SIDCriteria.Replace("@SID", "0")
                    spSID = "0"
                End If
                CritTmp = CritTmp.Replace("=", ">")
                spSIDSign = ">"
            Case "C"
                spSIDSign = "="
            Case "P"
                If CritTmp = "" Then
                    CritTmp = SIDCriteria.Replace("@SID", "32000")
                    spSID = "32000"
                End If
                CritTmp = CritTmp.Replace("=", "<")
                spSIDSign = "<"
        End Select

        CritTmp = AcctCriteria.Replace("@AcctID", AcctID.Text) & " AND " & CritTmp

        spAcctID = AcctID.Text.Trim

        dtSet = GetspData(spAcctID, spSID, spSIDSign)
        'If True Then
        If dtSet Is Nothing Then GoTo NoRecs
        If dtSet.Tables Is Nothing Then GoTo NoRecs
        If dtSet.Tables(0) Is Nothing Then GoTo NoRecs

        If dtSet.Tables(0).Rows.Count = 0 Then
            'Display Information Message when the "first" record displayed and there are no previous records found
            'and if "last" record displayed pop-up the same message
            MsgBox("No Records Found!", MsgBoxStyle.Exclamation, "Data Unavailable")
            GoTo NoRecs
        Else
            btnPrev.Enabled = True
            Group_EnDis(False)
            btnSave.Text = "&Save"
            btnEdit.Text = "&Edit"
            btnNew.Text = "&New"

            dvAcct.Table = dtSet.Tables(0)
            If Direction.ToUpper = "N" Then
                dvAcct.RowFilter = "SID = Min(SID)"
            ElseIf Direction.ToUpper = "P" Then
                dvAcct.RowFilter = "SID = Max(SID)"
            End If

            FormLoad(Me, dvAcct)

            SCH_WEEKLY = rbWeekly.Checked

            LoadGrid1()

            ''tm2 = Now
            ''MsgBox("LoadBy SID : After LoadGrid1 : " & tm2.Subtract(tm1).ToString & ", FUnc.Time: " & tm2.Subtract(tm3).ToString)

            tm3 = Now
            LoadGridData()
            SbjWgtModified = False
            ''tm2 = Now
            ''MsgBox("LoadBy SID : After LoadGridData : " & tm2.Subtract(tm1).ToString & ", FUnc.Time: " & tm2.Subtract(tm3).ToString)

        End If

        dtSet2 = Nothing
        Sender.Modified = False

        'Check if end-date is past or present.  If it is and there is not '*' in the name, go through the "End" procedure.
        If umskEndDate.GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw) <> "" Then
            If (IsFutureDate(umskEndDate.GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth)) < 1) And (TextBox1.Text.Substring(0, 1) <> "*") Then
                btnEdit.PerformClick()
                btnSave.PerformClick()
            End If
        End If

        Exit Sub
        'End If

        TempQuery = PrepSelectQuery(SQLSelect, CritTmp)
        PopulateDataset2(dtAdapter, dtSet2, TempQuery)
        If dtSet2 Is Nothing Then GoTo NoRecs
        If dtSet2.Tables Is Nothing Then GoTo NoRecs
        If dtSet2.Tables(0) Is Nothing Then GoTo NoRecs

        If dtSet2.Tables(0).Rows.Count = 0 Then
            'Display Information Message when the "first" record is displayed and there are no previous records found
            MsgBox("No Records Found!", MsgBoxStyle.Exclamation, "Data Unavailable")
            GoTo NoRecs
        Else
            Group_EnDis(False)
            btnSave.Text = "&Save"
            btnEdit.Text = "&Edit"
            btnNew.Text = "&New"

            dvAcct.Table = dtSet2.Tables(0)
            If Direction.ToUpper = "N" Then
                dvAcct.RowFilter = "SID = Min(SID)"
            ElseIf Direction.ToUpper = "P" Then
                dvAcct.RowFilter = "SID = Max(SID)"
            End If

            tm1 = Now

            FormLoad(Me, dvAcct)

            ''tm2 = Now
            ''MsgBox("LoadBy SID : After FormLoad : " & tm2.Subtract(tm1).ToString)

            SCH_WEEKLY = rbWeekly.Checked

            'If Val(InfoSID.Text) > 0 Then
            '    HighLightService(InfoSID.Text)
            'End If
            'Exit Sub
            ''tm3 = Now
            LoadGrid1()

            ''tm2 = Now
            ''MsgBox("LoadBy SID : After LoadGrid1 : " & tm2.Subtract(tm1).ToString & ", FUnc.Time: " & tm2.Subtract(tm3).ToString)

            tm3 = Now
            LoadGridData()

            tm2 = Now
            MsgBox("LoadBy SID : After LoadGridData : " & tm2.Subtract(tm1).ToString & ", FUnc.Time: " & tm2.Subtract(tm3).ToString)

        End If

        dtSet2 = Nothing
        Sender.Modified = False

        dtAdapter = Nothing
        dvAcct = Nothing
        dvSrvc = Nothing

        Exit Sub
NoRecs:
        If Direction.ToUpper <> "C" Then
        Else
            MsgBox("Service ID does not exist.")
            ClearForm(GroupBox2)
            ClearForm(GroupBox4)
        End If
        'Sender.Text = ""
        Sender.Focus()
        Sender.Modified = False
        dtSet2 = Nothing
    End Sub

    ''Private Sub LoadBySID2(ByRef Sender As TextBox)
    ''    Dim row As DataRow

    ''    If Val(Sender.Text.Trim) > 0 Then
    ''        If ReturnRowByID(SrvcID.Text, row, "AccountServices", "AccountID = " & AcctID.Text) Then  ' & " and ID = " & SrvcID.Text
    ''            LoadData()
    ''            'SetupSchedGrid(StatusTable)
    ''            ''FillSched()
    ''            LoadGrid1()

    ''            'If Val(InfoSID.Text.Trim) > 0 Then
    ''            '    HighLightService(Sender.Text)
    ''            'End If
    ''            'If Not HighLightService(sender.text) Then
    ''            '    SrvcID.Undo()
    ''            '    sender.Focus()
    ''            '    MessageBox.Show("Service-ID Not Found!", "Find Service ID", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1)
    ''            '    sender.Focus()
    ''            'End If
    ''        Else
    ''            MsgBox("Service ID does not exist.")
    ''            Sender.Text = ""
    ''            Sender.Focus()
    ''            Sender.Modified = False
    ''        End If
    ''    Else
    ''        MsgBox("Invalid Value.")
    ''    End If

    ''End Sub


    Private Function HighLightService(ByVal Value As String) As Boolean
        Dim oRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        HighLightService = False
        oRow = UltraGrid2.ActiveRow
        If oRow Is Nothing Then oRow = Me.UltraGrid2.GetRow(Infragistics.Win.UltraWinGrid.ChildRow.First)

        m_searchInfo.lookIn = "ID"
        m_searchInfo.matchCase = False
        m_searchInfo.searchContent = SearchContentEnum.WholeField
        m_searchInfo.searchDirection = SearchDirectionEnum.All
        m_searchInfo.searchString = Value

        oRow = Me.UltraGrid2.GetRow(Infragistics.Win.UltraWinGrid.ChildRow.First)
        While Not oRow Is Nothing
            If MatchText(oRow, UltraGrid2, m_searchInfo, m_oColumn) Then
                Me.UltraGrid2.ActiveRow = oRow
                If Not Me.m_oColumn Is Nothing Then
                    Me.UltraGrid2.ActiveCell = oRow.Cells(Me.m_oColumn.Key)
                    Me.UltraGrid2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstCellInRow, False, False)
                End If
                HighLightService = True
                Exit Function
            End If
            oRow = oRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next)
        End While
    End Function

    'Private Sub btnInfSID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    '    Dim SelectSQL As String
    '    Dim dtAdapter As New SqlDataAdapter()
    '    Dim dtSet As New DataSet()
    '    Dim dtView As New DataView()
    '    Dim HasErr As Boolean
    '    Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
    '    Dim SQLTmp As String

    '    If AcctID.Text.Trim = "" Then
    '        MsgBox("Please select an Account first.")
    '        Exit Sub
    '    End If

    '    SelectSQL = "Select asv.ID as SID, asv.CompName as Location, asv.Street, asv.CityName as City, asv.ZipCode " & _
    '                ", asv.StartDate, asv.EndDate " & _
    '                " from AccountServices asv Where AccountID = @AcctID order by ID"

    '    SQLTmp = SelectSQL.Replace("@AcctID", AcctID.Text)

    '    PopulateDataset2(dtAdapter, dtSet, SQLTmp)
    '    dtView.Table = dtSet.Tables(0)
    '    If dtView.Table.Rows.Count > 0 Then
    '        Dim Srch As New SearchListings()
    '        Srch.dsList = dtSet

    '        Srch.UltraGrid1.Text = "Account Services"
    '        Srch.Text = "Account Services"
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
    '                'InfoSID.Text = ugRow.Cells("SID").Text
    '                Srch = Nothing
    '            End If
    '        End Try
    '    End If
    'End Sub

    Private Sub BtnSID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSID.Click
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet2 As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow

        If AcctID.Text.Trim = "" Then
            MsgBox("Please select an Account first.")
            Exit Sub
        End If

        SelectSQL = "Select asv.ID as SID, asv.CompName as [Location Name], asv.Street, asv.CityName as City, asv.ZipCode " & _
                    ", asv.StartDate, asv.EndDate, asv.charge " & _
                    ",(Select top 1 m.OfficeID FROM " & ROUTESTblPath & "ServiceSchedules m where m.AccountID = asv.AccountID and m.sid = asv.id order by m.Day) as [Office ID]" & _
                    ",(Select top 1 m.RouteNo FROM " & ROUTESTblPath & "ServiceSchedules m where m.AccountID = asv.AccountID and m.sid = asv.id order by m.Day) as Rte" & _
                    ",(Select top 1 m.StopNo FROM " & ROUTESTblPath & "ServiceSchedules m where m.AccountID = asv.AccountID and m.sid = asv.id order by m.Day) as Stp" & _
                    ",(case isnull((SELECT DISTINCT m.day FROM " & ROUTESTblPath & "ServiceSchedules m where m.AccountID = asv.AccountID and m.sid = asv.id and m.day = 1), 0) when '1' then 'Y' else 'N' end) as Mo " & _
                    ",(case isnull((SELECT DISTINCT m.day FROM " & ROUTESTblPath & "ServiceSchedules m where m.AccountID = asv.AccountID and m.sid = asv.id and m.day = 2), 0) when '2' then 'Y' else 'N' end) as Tu " & _
                    ",(case isnull((SELECT DISTINCT m.day FROM " & ROUTESTblPath & "ServiceSchedules m where m.AccountID = asv.AccountID and m.sid = asv.id and m.day = 3), 0) when '3' then 'Y' else 'N' end) as We" & _
                    ",(case isnull((SELECT DISTINCT m.day FROM " & ROUTESTblPath & "ServiceSchedules m where m.AccountID = asv.AccountID and m.sid = asv.id and m.day = 4), 0) when '4' then 'Y' else 'N' end) as Th" & _
                    ",(case isnull((SELECT DISTINCT m.day FROM " & ROUTESTblPath & "ServiceSchedules m where m.AccountID = asv.AccountID and m.sid = asv.id and m.day = 5), 0) when '5' then 'Y' else 'N' end) as Fr" & _
                    ",(case isnull((SELECT DISTINCT m.day FROM " & ROUTESTblPath & "ServiceSchedules m where m.AccountID = asv.AccountID and m.sid = asv.id and m.day = 6), 0) when '6' then 'Y' else 'N' end) as Sa" & _
                    ",(case isnull((SELECT DISTINCT m.day FROM " & ROUTESTblPath & "ServiceSchedules m where m.AccountID = asv.AccountID and m.sid = asv.id and m.day = 7), 0) when '7' then 'Y' else 'N' end) as Su" & _
                    " FROM " & ROUTESTblPath & "AccountServices asv Where AccountID = " & AcctID.Text & " order by ID"

        PopulateDataset2(dtAdapter, dtSet2, SelectSQL)
        dtView.Table = dtSet2.Tables(0)
        If dtView.Table.Rows.Count > 0 Then
            Dim Srch As New SearchListings
            Srch.dsList = dtSet2

            Srch.UltraGrid1.Text = "Account Services"
            Srch.Text = "Account Services"
            Srch.Tag = "ASVC_SELECTSID_LIST"
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
                    SrvcID.Text = ugRow.Cells("SID").Text
                    Srch = Nothing
                    If btnNew.Text.ToUpper = "&NEW" Then
                        'LoadData()
                        LoadBySID(SrvcID)
                    End If
                End If
                dtAdapter = Nothing
                dtSet2 = Nothing
                dtView = Nothing
            End Try
        End If

    End Sub


    Private Sub UltraGrid1_BeforeCellUpdate(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventArgs) Handles UltraGrid1.BeforeCellUpdate
        If e.Cell.Column.ToString = "Day" Then
            e.Cancel = True
        ElseIf e.Cell.Column.ToString = "Chg" And DailyBCycle() = False Then 'UltraGrid1.ActiveCell.Column.ToString
            e.Cancel = True
        Else
            e.Cancel = False
        End If


    End Sub

    Private Sub UltraGrid1_BeforeEnterEditMode(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles UltraGrid1.BeforeEnterEditMode
        If UltraGrid1.ActiveCell.Column.ToString = "Day" Then    'Or UltraGrid1.ActiveCell.Column.ToString = "Charge"
            e.Cancel = True
        ElseIf UltraGrid1.ActiveCell.Column.ToString = "Chg" And DailyBCycle() = False Then
            e.Cancel = True
        Else
            e.Cancel = False
        End If
    End Sub

    Private Function DailyBCycle() As Boolean
        If cboBillingCycle.SelectedValue <> "D" Then
            DailyBCycle = False
            Charge.ReadOnly = False
        Else
            DailyBCycle = True
            Charge.ReadOnly = True
        End If
    End Function

    Friend WithEvents rbMWF As System.Windows.Forms.RadioButton
    Friend WithEvents rbTT As System.Windows.Forms.RadioButton
    Friend WithEvents rbMTWT As System.Windows.Forms.RadioButton
    Friend WithEvents rbSS As System.Windows.Forms.RadioButton
    Friend WithEvents rbMTWTF As System.Windows.Forms.RadioButton
    Friend WithEvents rbOther As System.Windows.Forms.RadioButton

    Private Sub rbMTWTF_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbMTWTF.CheckedChanged, rbMTWT.CheckedChanged, rbMWF.CheckedChanged, rbSS.CheckedChanged, rbTT.CheckedChanged
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim cRow As New SchedCols

        Try

            If GroupBox2.Enabled = False Then Exit Sub

            If sender.Checked = False Then Exit Sub

            For Each ugRow In UltraGrid1.Rows
                If Val(ugRow.Cells("Ofc").Value) > 0 Then Exit For
            Next
            If Not ugRow Is Nothing Then
                cRow.SvcDate = IIf(ugRow.Cells("SvcDate").Value Is DBNull.Value, "01/01/1900", ugRow.Cells("SvcDate").Value)
                cRow.iDay = ugRow.Index
                cRow.Ofc = ugRow.Cells("Ofc").Value
                cRow.Rte = ugRow.Cells("Rte").Value
                If Not ugRow.Cells("STm").Value Is DBNull.Value Then cRow.STm = ugRow.Cells("STm").Value
                If Not ugRow.Cells("CTm").Value Is DBNull.Value Then cRow.STm = ugRow.Cells("CTm").Value
                cRow.Stp = ugRow.Cells("Stp").Value
                cRow.Chg = ugRow.Cells("Chg").Value

                Select Case sender.name
                    Case "rbMTWTF"
                        SetUGRows(cRow, MTWTF)
                    Case "rbMTWT"
                        SetUGRows(cRow, MTWT)
                    Case "rbMWF"
                        SetUGRows(cRow, MWF)
                    Case "rbTT"
                        SetUGRows(cRow, TT)
                    Case "rbSS"
                        SetUGRows(cRow, SS)
                    Case Else
                End Select
            End If
            cRow = Nothing

        Catch ex As Exception
            ex.ToString()
        End Try
    End Sub

    Private Sub SetUGRows(ByVal cRow As SchedCols, ByVal Days As Integer)
        Dim ugRow2 As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim i As Integer
        Dim tbl As DataTable

        For i = 0 To UltraGrid1.Rows.Count - 1
            If ((2 ^ i) And Days) > 0 Then
                UltraGrid1.Rows(i).Cells("Ofc").Value = cRow.Ofc
                UltraGrid1.Rows(i).Cells("Rte").Value = cRow.Rte
                UltraGrid1.Rows(i).Cells("Rte").Text.ToUpper()
                If cRow.STm <> Nothing Then UltraGrid1.Rows(i).Cells("STm").Value = cRow.STm
                If cRow.CTm <> Nothing Then UltraGrid1.Rows(i).Cells("CTm").Value = cRow.CTm
                UltraGrid1.Rows(i).Cells("Stp").Value = cRow.Stp
                UltraGrid1.Rows(i).Cells("Chg").Value = cRow.Chg
                UltraGrid1.Rows(i).Refresh()
                UltraGrid1.Rows(i).Update()
            Else
                UltraGrid1.Rows(i).Cells("Ofc").Value = 0
                UltraGrid1.Rows(i).Cells("Rte").Value = ""
                UltraGrid1.Rows(i).Cells("Rte").Text.ToUpper()
                UltraGrid1.Rows(i).Cells("STm").Value = DBNull.Value
                UltraGrid1.Rows(i).Cells("CTm").Value = DBNull.Value
                UltraGrid1.Rows(i).Cells("Stp").Value = 0
                UltraGrid1.Rows(i).Cells("Chg").Value = 0.0
            End If
        Next
        UltraGrid1.Update()
        UltraGrid1.UpdateData()
        tbl = Nothing
    End Sub

    Private Sub AcctSvcSchedule_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        '**************************************************************************
        'SF - 6/07/2010 - Modifed code to dispose tSet, dvStates and cmdTrans
        '**************************************************************************

        'Karina, Warn the user on EXITING/CLOSING window when in Edit/New modes.
        If btnEdit.Text = "&Cancel" Or btnNew.Text = "&Cancel" Then
            If MsgBox("Data is not saved! Are you sure you want to exit?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                e.Cancel = True
                Exit Sub
            End If
        End If

        If Not cmdTrans Is Nothing Then
            If EditForm(Me, PrepSelectQuery(SQLEdit, " Where RowID = " & RowID.Text), EditAction.CANCEL, cmdTrans) Then
                Group_EnDis(False)
                sender.text = "&Edit"
            Else
                'Exit Sub
            End If
            e.Cancel = False
        End If

        dtSet = Nothing
        dvStates = Nothing
        cmdTrans = Nothing

    End Sub

    Private Function CheckOfcRteStp() As Boolean
        Dim ugcell As Infragistics.Win.UltraWinGrid.UltraGridCell
        Dim row As DataRow
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow

        CheckOfcRteStp = False

        For Each ugRow In UltraGrid1.Rows
            If ugRow.Cells("Ofc").Text = "0" And ugRow.Cells("Rte").Text = "" And ugRow.Cells("Stp").Text = "0" Then
                CheckOfcRteStp = True
                Exit Function
            End If
            ugcell = ugRow.Cells("Ofc")
            If ugcell.Value = 0 Then GoTo NextRow
            If ReturnRowByID(ugcell.Value, row, "SERVICEOFFICES", "where Active = 1") = False Then
                MessageBox.Show("Invalid OfficeID for record #" & ugRow.Index + 1 & ". ")
                Exit Function
            End If
            ugcell = ugRow.Cells("Rte")
            Dim strRoute As String = ugcell.Value

            If strRoute.Length = 1 Then
                If Val(strRoute) >= 0 And Val(strRoute) <= 9 Then
                    strRoute = "0" & strRoute
                End If
            End If

            'If ReturnRowByID(ugcell.Value, row, AppTblPath & "ROUTES2", " OFFICEID = " & CStr(ugRow.Cells("Ofc").Value), " ROUTEID") = False Then
            If ReturnRowByID(strRoute, row, AppTblPath & "ROUTES2", " OFFICEID = " & CStr(ugRow.Cells("Ofc").Value), " ROUTEID") = False Then
                MessageBox.Show("Invalid Route for record #" & ugRow.Index + 1 & ". ")
                Exit Function
            End If
            ugcell = ugRow.Cells("Stp")
            If SCH_WEEKLY Then
                Dim dtAdapter As SqlDataAdapter
                Dim dtSet2 As New DataSet
                Dim CritTmp As String

                If SrvcID.Text.Trim = "" Then
                    CritTmp = "Select asv.rowid FROM " & ROUTESTblPath & "AccountServices asv, " & ROUTESTblPath & "ServiceSchedules ss where asv.AccountID = ss.AccountID and asv.id = ss.sid and ss.Day = " & ugRow.Index + 1 & " AND ss.OFFICEID = " & ugRow.Cells("Ofc").Value & " AND ss.RouteNo = '" & ugRow.Cells("Rte").Value & "' AND asv.EndDate is null AND ss.StopNo = '" & ugRow.Cells("Stp").Value & "'"
                Else
                    CritTmp = "Select asv.rowid from " & ROUTESTblPath & "AccountServices asv, " & ROUTESTblPath & "ServiceSchedules ss where asv.AccountID = ss.AccountID and asv.id = ss.sid and ss.Day = " & ugRow.Index + 1 & " AND ss.OFFICEID = " & ugRow.Cells("Ofc").Value & " AND ss.RouteNo = '" & ugRow.Cells("Rte").Value & "' AND asv.EndDate is null AND ss.StopNo = '" & ugRow.Cells("Stp").Value & "' AND ss.id NOT IN (SELECT ID FROM " & ROUTESTblPath & "serviceschedules ss2 WHERE ss2.AccountID = " & AcctID.Text & " AND ss2.SID = " & SrvcID.Text & ")"     'Ali: If AcctID+SID <> did not work: and ID <> " & ugRow.Cells("ID").Value
                End If

                PopulateDataset2(dtAdapter, dtSet2, CritTmp)
                If Not dtSet2 Is Nothing Then
                    If dtSet2.Tables(0).Rows.Count > 0 Then
                        'If ReturnRowByID(ugcell.Value, row, "ServiceSchedules", " Day = " & UltraGrid1.ActiveRow.Index + 1 & " AND OFFICEID = " & UltraGrid1.ActiveRow.Cells("Ofc").Value & " AND RouteNo = '" & UltraGrid1.ActiveRow.Cells("Rte").Value & "' ") Then
                        MessageBox.Show("Invalid Stop for record #" & ugRow.Index + 1 & ". ")
                        dtSet2 = Nothing
                        dtAdapter = Nothing
                        Exit Function
                    End If
                End If
                dtAdapter = Nothing
                dtSet2 = Nothing
            End If

            row = Nothing
NextRow:
        Next
        CheckOfcRteStp = True

    End Function

    Private Function CheckSched() As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        CheckSched = True

        Try
            For Each ugRow In UltraGrid1.Rows

                If ugRow.Cells("Ofc").Text = "" And ugRow.Cells("Rte").Text = "" And ugRow.Cells("Stp").Text = "" Then
                    CheckSched = CheckOfcRteStp()
                    CheckSched = True
                    Exit Function
                End If

                If (Val(ugRow.Cells("Ofc").Value) = 0 And ugRow.Cells("Rte").Text.Trim = "" And Val(ugRow.Cells("Stp").Value) = 0) Or _
                (Val(ugRow.Cells("Ofc").Value) > 0 And ugRow.Cells("Rte").Text.Trim <> "" And Val(ugRow.Cells("Stp").Value) > 0) Then
                Else
                    'MessageBox.Show("Record #" & ugRow.Index + 1 & " in Schedule grid has invalid values. Save Cancelled.")
                    MessageBox.Show("Please make sure that OfficeId, RouteNumber and StopNumber have valid values in Schedule Grid. Save Cancelled!")
                    CheckSched = False
                    Exit Function
                End If

            Next
            CheckSched = CheckOfcRteStp()

        Catch ex As Exception
            CheckSched = False
            Exit Function
        End Try

    End Function

    Private Function SaveSched()
        '**************************************************************************
        'SF - 5/18/2010 - Commented out the Delete statement
        '**************************************************************************
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim cRow As New SchedCols
        Dim DelQry As String
        Dim cmdSQLTrans As SqlCommand
        Dim i As Integer

        On Error GoTo ErrTrap
        If btnNew.Text = "&New" Then
            'DelQry = "Delete FROM " & ROUTESTblPath & "" & UltraGrid1.Tag & " Where AccountID = " & AcctID.Text & " and SID = " & SrvcID.Text
        Else
            DelQry = ""
        End If
        cRow.AID = Val(AcctID.Text)
        cRow.SID = Val(SrvcID.Text)
        cmdSQLTrans = InitiateEdit(Me, "Select * FROM " & ROUTESTblPath & "" & UltraGrid1.Tag & " Where AccountID = " & cRow.AID & " AND SID = " & cRow.SID)

        If ExecuteQuery(DelQry, cmdSQLTrans) Then
            For Each ugRow In UltraGrid1.Rows
                If Not ugRow.Cells("Ofc").Value Is DBNull.Value Then
                    If Val(ugRow.Cells("Ofc").Value) > 0 Then
                        cRow.SvcDate = IIf(ugRow.Cells("SvcDate").Value Is DBNull.Value, "01/01/1900", ugRow.Cells("SvcDate").Value)
                        cRow.iDay = ugRow.Index + 1
                        cRow.Ofc = ugRow.Cells("Ofc").Value
                        cRow.Rte = ugRow.Cells("Rte").Value
                        If Val(cRow.Rte) >= 0 And Val(cRow.Rte) <= 9 Then
                            cRow.Rte = "0" & cRow.Rte
                        End If
                        cRow.Rte = ugRow.Cells("Rte").Value
                        cRow.STm = ugRow.Cells("STm").GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw)
                        cRow.CTm = ugRow.Cells("CTm").GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw)
                        cRow.Stp = ugRow.Cells("Stp").Value
                        cRow.Chg = ugRow.Cells("Chg").Value

                        If ExecuteQuery("Insert Into " & ROUTESTblPath & "" & UltraGrid1.Tag & "(AccountID, SID, ServiceDate, Day, RouteNo, StopNo, OfficeID, STime, CTime, Charge) values(" & _
                         cRow.AID & ", " & cRow.SID & ", '" & cRow.SvcDate & "', " & cRow.iDay & ", '" & cRow.Rte & "', " & cRow.Stp & ", " & cRow.Ofc & _
                         ", '" & cRow.STm & "', '" & cRow.CTm & "', " & cRow.Chg & ")", cmdSQLTrans) = False Then

                        End If
                    End If
                End If
            Next
            'Me.Text = MeText & " - Data Saved..."
        Else
            'Me.Text = MeText & " - Data NOT Saved!"
            GoTo ErrTrap
        End If
        'cmdSQLTrans.Transaction.Commit()
        'cmdSQLTrans.Transaction = Nothing
        cmdSQLTrans.Connection.Close()
        cmdSQLTrans.Connection = Nothing
        cmdSQLTrans = Nothing
        cRow = Nothing
        Exit Function
ErrTrap:
        MsgBox("Error in SaveSched : " & Err.Description)
        cRow = Nothing
        cmdSQLTrans.Transaction.Rollback()
        cmdSQLTrans.Transaction = Nothing
        cmdSQLTrans.Connection.Close()
        cmdSQLTrans.Connection = Nothing
        cmdSQLTrans = Nothing
    End Function

    Private Sub GroupBox2_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupBox2.EnabledChanged
        If GroupBox2.Enabled Then
            'TextBox1.ForeColor = System.Drawing.Color.Red
            'TextBox1.BackColor = System.Drawing.Color.Beige
            ''Label12.ForeColor = System.Drawing.Color.Black
        Else
            'TextBox1.ForeColor = System.Drawing.Color.Blue
            'TextBox1.BackColor = System.Drawing.Color.AliceBlue
            ''Label12.ForeColor = System.Drawing.Color.Red
            ''Label12.BackColor = System.Drawing.Color.AliceBlue
        End If
    End Sub

    Private Sub UltraGrid1_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraGrid1.EnabledChanged
        'If sender.Enabled Then
        '    UltraGrid1.DisplayLayout.Appearance.ForeColor = System.Drawing.Color.Black
        '    sender.ForeColor = System.Drawing.Color.Black
        'Else
        '    UltraGrid1.DisplayLayout.Appearance.ForeColor = System.Drawing.Color.BlueViolet
        '    sender.ForeColor = System.Drawing.Color.Azure
        'End If

    End Sub

    Private Sub TextBox1_EnabledChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.EnabledChanged
        If sender.Enabled Then
            'TextBox1.ForeColor = System.Drawing.Color.Red
            '    Label12.ForeColor = System.Drawing.Color.Black
            'Else
            '    TextBox1.ForeColor = System.Drawing.Color.Red
            '    TextBox1.BackColor = System.Drawing.Color.AliceBlue
            '    Label12.ForeColor = System.Drawing.Color.Red
            '    Label12.BackColor = System.Drawing.Color.AliceBlue
        End If

    End Sub

    Private Sub TextBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TextBox1.Enter
        'TextBox1.ForeColor = System.Drawing.Color.Red
        'TextBox1.BackColor = System.Drawing.Color.Beige
    End Sub

    Private Sub rbWeekly_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbWeekly.CheckedChanged, rbCalendar.CheckedChanged
        'If rbWeekly.TabStop() = True Or rbCalendar.TabStop() = True Then
        '    If Me.TabIndex <> 0 Then
        '        'MessageBox.Show("Selecting this radio button will change the data, are you sure you want to do it?")
        '        MsgBox("Selecting this radio button will change the data, are you sure you want to do it?", MsgBoxStyle.Exclamation, "WARNING - Change of Data")
        '        Me.TabIndex = Me.TabIndex - 1
        '    End If
        'Else
        'End If

        SCH_WEEKLY = rbWeekly.Checked
        ResetSchedGrid()
        If btnNew.Text = "&Cancel" And Not SCH_WEEKLY Then
            UltraGrid1.DisplayLayout.Bands(0).AddNew()
        End If
    End Sub
    Private Sub ResetSchedGrid()
        SetSchedDSBlank(StatusTable)
        HideWeekly(Not SCH_WEEKLY)
        'SetupSchedGrid(StatusTable)
        'LoadGrid1()
        'UltraGrid1.DataSource = Nothing

    End Sub


    '===================================================================
    Private Sub SetupSchCols()
        Dim i As Integer
        Dim col As DataColumn

        If Not WCols(0) Is Nothing Then
            Exit Sub
        End If

        For i = 0 To WCols.Length - 1
            WCols(i) = New SchCols
        Next

        WCols(0).Name = "SvcDate"
        WCols(0).Type = GetType(System.DateTime)
        WCols(0).Format = "MM/dd/yy-ddd"
        WCols(0).NoEdit = False
        WCols(0).Hide = True
        WCols(0).BackColor = Color.GhostWhite
        WCols(0).Width = 77

        WCols(1).Name = "Day"
        WCols(1).Type = GetType(System.String)
        WCols(1).Format = ""
        WCols(1).NoEdit = True
        WCols(1).Hide = False
        WCols(1).BackColor = Color.GhostWhite
        WCols(1).Width = 40

        WCols(2).Name = "Ofc"
        WCols(2).Type = GetType(System.Byte)
        WCols(2).Format = ""
        WCols(2).NoEdit = False
        WCols(2).Hide = False
        WCols(2).MaxLength = 3
        WCols(2).Width = 30

        WCols(3).Name = "Rte"
        WCols(3).Type = GetType(System.String)
        WCols(3).Format = ""
        WCols(3).NoEdit = False
        WCols(3).Hide = False
        WCols(3).MaxLength = ROUTELEN
        WCols(3).Width = 49

        WCols(4).Name = "STm"
        WCols(4).Type = GetType(System.DateTime)
        WCols(4).Format = "HH :mm"
        WCols(4).NoEdit = False
        WCols(4).Hide = False
        WCols(4).Width = 42

        WCols(5).Name = "CTm"
        WCols(5).Type = GetType(System.DateTime)
        WCols(5).Format = "HH :mm"
        WCols(5).NoEdit = False
        WCols(5).Hide = False
        WCols(5).Width = 42

        WCols(6).Name = "Stp"
        WCols(6).Type = GetType(System.Int16)
        WCols(6).Format = ""
        WCols(6).NoEdit = False
        WCols(6).Hide = False
        WCols(6).MaxLength = 3
        WCols(6).Width = 40

        WCols(7).Name = "Chg"
        WCols(7).Type = GetType(System.Decimal)
        WCols(7).Format = "###0.#0"
        WCols(7).NoEdit = False
        WCols(7).Hide = False
        WCols(7).MaxLength = 6
        WCols(7).Width = 55

        StatusTable.Clear()
        StatusTable.Columns.Clear()

        For i = 0 To WCols.Length - 1
            StatusTable.Columns.Add(WCols(i).Name, WCols(i).Type)
        Next

        ' -- These functions are called separately --
        'AddWeeklyRows()
        'SetSchedDSBlank(StatusTable)

    End Sub

    Private Sub AddWeeklyRows()
        Dim row As DataRow

        row = StatusTable.NewRow
        row("Day") = "Mon" ': row("Status") = "Active"
        StatusTable.Rows.Add(row)

        row = StatusTable.NewRow
        row("Day") = "Tue"
        StatusTable.Rows.Add(row)

        row = StatusTable.NewRow
        row("Day") = "Wed"
        StatusTable.Rows.Add(row)

        row = StatusTable.NewRow
        row("Day") = "Thu"
        StatusTable.Rows.Add(row)

        row = StatusTable.NewRow
        row("Day") = "Fri"
        StatusTable.Rows.Add(row)

        row = StatusTable.NewRow
        row("Day") = "Sat"
        StatusTable.Rows.Add(row)

        row = StatusTable.NewRow
        row("Day") = "Sun"
        StatusTable.Rows.Add(row)

        SetSchedDSBlank(StatusTable)

    End Sub

    Private Sub SetSchedDSBlank(ByRef tbl As DataTable)
        Dim row As DataRow

        For Each row In tbl.Rows
            row("Ofc") = 0
            row("Rte") = ""
            row("STm") = DBNull.Value
            row("CTm") = DBNull.Value
            row("Stp") = 0
            row("Chg") = 0.0
        Next
    End Sub


    Private Function LoadGrid1() As String

        If dtSet.Tables.Count > 1 Then
            If dtSet.Tables(1).Rows.Count > 0 Then
                If dtSet.Tables(1).Rows(0)("Tbl") = "SCH" Then
                    Dim dvSched As New DataView
                    Dim row, rowtmp As DataRow
                    Dim WDays As Integer
                    Dim dsTmp As DataSet

                    dvSched.Table = dtSet.Tables(1)

                    UltraGrid1.DataSource = Nothing

                    If SCH_WEEKLY Then  'And TypeOf dsSched.Tables(0).Rows(0).Item("SvcDate") Is System.DBNull
                        HideWeekly(False)
                        SetSchedDSBlank(StatusTable)
                        If dvSched.Table.Rows.Count > 0 Then
                            For Each row In dvSched.Table.Rows
                                StatusTable.Rows(row("Day") - 1).Item("Ofc") = row("Ofc")
                                StatusTable.Rows(row("Day") - 1).Item("Rte") = row("Rte")
                                StatusTable.Rows(row("Day") - 1).Item("STm") = row("STm")
                                StatusTable.Rows(row("Day") - 1).Item("CTm") = row("CTm")
                                StatusTable.Rows(row("Day") - 1).Item("Stp") = row("Stp")
                                StatusTable.Rows(row("Day") - 1).Item("Chg") = row("Chg")
                                WDays = WDays + 2 ^ (row("Day") - 1)
                            Next
                        End If
                        Select Case WDays
                            Case MTWTF
                                rbMTWTF.Checked = True
                            Case MTWT
                                rbMTWT.Checked = True
                            Case MWF
                                rbMWF.Checked = True
                            Case TT
                                rbTT.Checked = True
                            Case SS
                                rbSS.Checked = True
                            Case Else
                                rbOther.Checked = True
                        End Select
                        If StatusTable.DataSet Is Nothing Then
                            dsTmp = New DataSet
                            dsTmp.Tables.Add(StatusTable)
                        Else
                            dsTmp = StatusTable.DataSet
                        End If
                    Else
                        HideWeekly(True)

                        Dim tbltmp As New DataTable
                        tbltmp = dvSched.Table

                        dsTmp = New DataSet
                        dsTmp.Tables.Add(tbltmp)
                    End If
                    FillGrid1(dsTmp)
                    UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInBand, True, True)
                    CalcDailyAvg()

                    dsTmp = Nothing
                    dvSched = Nothing
                    row = Nothing
                    rowtmp = Nothing
                End If
            Else
                Dim dsTmp As DataSet
                Dim dvSched As New DataView

                If SCH_WEEKLY Then  'And TypeOf dsSched.Tables(0).Rows(0).Item("SvcDate") Is System.DBNull
                    HideWeekly(False)
                    SetSchedDSBlank(StatusTable)
                    If StatusTable.DataSet Is Nothing Then
                        dsTmp = New DataSet
                        dsTmp.Tables.Add(StatusTable)
                    Else
                        dsTmp = StatusTable.DataSet
                    End If
                Else
                    'HideWeekly(True)
                    'dvSched.Table = dtSet.Tables(1)

                    'Dim tbltmp As New DataTable
                    'tbltmp = dvSched.Table

                    'dsTmp = New DataSet
                    'dsTmp.Tables.Add(tbltmp)
                    HideWeekly(True)
                    SetSchedDSBlank(StatusTable)
                    If StatusTable.DataSet Is Nothing Then
                        dsTmp = New DataSet
                        dsTmp.Tables.Add(StatusTable)
                    Else
                        dsTmp = StatusTable.DataSet
                    End If
                End If
                FillGrid1(dsTmp)
                UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInBand, True, True)
                CalcDailyAvg()
                dsTmp = Nothing
                dvSched = Nothing

            End If
        Else
            Dim dsTmp As DataSet
            Dim dvSched As New DataView
            HideWeekly(False)
            SetSchedDSBlank(StatusTable)
            If StatusTable.DataSet Is Nothing Then
                dsTmp = New DataSet
                dsTmp.Tables.Add(StatusTable)
            Else
                dsTmp = StatusTable.DataSet
            End If

            FillGrid1(dsTmp)
            UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInBand, True, True)
            CalcDailyAvg()
            dsTmp = Nothing
            dvSched = Nothing
        End If

        Exit Function


        Dim CritTmp As String
        'Dim sqlSched As String = " Select ID, Day, ServiceDate as SvcDate, OfficeID as Ofc, RouteNo as Rte, REPLACE(SPACE(4 - len(stime)) + stime, ' ', '0') as STm, REPLACE(SPACE(4 - len(Ctime)) + Ctime, ' ', '0') as CTm, StopNo as Stp, Charge as Chg from ServiceSchedules where AccountID = " & AcctID.Text & " @SID Order by ID" '" AND SID = " & SrvcID.Text &
        Dim sqlSched As String = " Select ID, Day, ServiceDate as SvcDate, OfficeID as Ofc, RouteNo as Rte, STime as STm, CTime as CTm, StopNo as Stp, Charge as Chg FROM " & ROUTESTblPath & "ServiceSchedules where AccountID = " & AcctID.Text & " @SID Order by ID" '" AND SID = " & SrvcID.Text &
        Dim sqlSchedC As String = " Select ServiceDate as SvcDate, OfficeID as Ofc, RouteNo as Rte,  STime as STm,  CTime as CTm, StopNo as Stp, Charge as Chg FROM " & ROUTESTblPath & "ServiceSchedules where AccountID = " & AcctID.Text & " @SID Order by ID" '" AND SID = " & SrvcID.Text &
        'Dim sqlSchedC As String = " Select SvcDate, Ofc, Rte,  STm,  CTm, Stp, Chg from CalendarSchedules where AccountID = " & AcctID.Text & " @SID Order by SvcDate" '" AND SID = " & SrvcID.Text &
        ' Datename(dw,ServiceDate) as [Day],

        If Val(AcctID.Text) <= 0 Then
            'MsgBox("AccountID not valid.")
            Exit Function
        End If
        If SCH_WEEKLY = True Then
            WCols(0).Hide = True
            CritTmp = sqlSched
        Else
            WCols(0).Hide = False
            CritTmp = sqlSchedC
        End If
        If btnNew.Text <> "&Cancel" And SrvcID.Text.Trim <> "" Then
            If Val(SrvcID.Text) < 1 Then
                MsgBox("ServiceID not valid.")
                Exit Function
            End If
            CritTmp = CritTmp.Replace("@SID", " AND SID = " & SrvcID.Text)
        Else
            CritTmp = CritTmp.Replace("@SID", " AND SID = -1")
        End If

        FillDataSet(CritTmp)
        CalcDailyAvg()


    End Function

    Private Function FillDataSet(ByVal sqlSched As String)
        'Dim SchedHidCols() As String = {"ID", "SID"}

        Dim dtAdapter As SqlDataAdapter
        Dim dsSched As New DataSet
        Dim dsTmp As DataSet
        Dim row, rowtmp As DataRow
        Dim STm, CTm As String
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim WDays As Integer

        ''Dim tm1, tm2, tm3 As DateTime
        ''tm1 = Now

        PopulateDataset2(dtAdapter, dsSched, sqlSched)
        ''Exit Function
        ''tm2 = Now
        ''MsgBox("FillDataSet : After Populate : " & tm2.Subtract(tm1).ToString)

        UltraGrid1.DataSource = Nothing

        If SCH_WEEKLY Then  'And TypeOf dsSched.Tables(0).Rows(0).Item("SvcDate") Is System.DBNull

            ''tm3 = Now

            HideWeekly(False)
            SetSchedDSBlank(StatusTable)

            ''tm2 = Now
            ''MsgBox("FillDataSet : After DSBlank, Total : " & tm2.Subtract(tm1).ToString & ", DSBlank : " & tm2.Subtract(tm3).ToString)

            If dsSched.Tables(0).Rows.Count > 0 Then
                'StatusTable.Clear()
                'AddWeeklyRows()

                ''tm3 = Now

                For Each row In dsSched.Tables(0).Rows
                    'Day #1 = Mon, Day #7 = Sun
                    'STm = row("STm") : STm = STm.PadLeft(4, "0")
                    'CTm = row("CTm") : CTm = CTm.PadLeft(4, "0")

                    StatusTable.Rows(row("Day") - 1).Item("Ofc") = row("Ofc")
                    StatusTable.Rows(row("Day") - 1).Item("Rte") = row("Rte")
                    StatusTable.Rows(row("Day") - 1).Item("STm") = row("STm")
                    StatusTable.Rows(row("Day") - 1).Item("CTm") = row("CTm")
                    StatusTable.Rows(row("Day") - 1).Item("Stp") = row("Stp")
                    StatusTable.Rows(row("Day") - 1).Item("Chg") = row("Chg")

                    'UltraGrid1.Rows(row("Day") - 1).Cells("Ofc").Value = row("Ofc")
                    'UltraGrid1.Rows(row("Day") - 1).Cells("Rte").Value = row("Rte")
                    'UltraGrid1.Rows(row("Day") - 1).Cells("STm").Value = STm
                    'UltraGrid1.Rows(row("Day") - 1).Cells("CTm").Value = CTm
                    'UltraGrid1.Rows(row("Day") - 1).Cells("Stp").Value = row("Stp")
                    'UltraGrid1.Rows(row("Day") - 1).Cells("Chg").Value = row("Chg")
                    WDays = WDays + 2 ^ (row("Day") - 1)
                Next

                ''tm2 = Now
                ''MsgBox("FillDataSet : After Manual Fillout For, Total : " & tm2.Subtract(tm1).ToString & ", FOR Loop : " & tm2.Subtract(tm3).ToString)

            End If
            Select Case WDays
                Case MTWTF
                    rbMTWTF.Checked = True
                Case MTWT
                    rbMTWT.Checked = True
                Case MWF
                    rbMWF.Checked = True
                Case TT
                    rbTT.Checked = True
                Case SS
                    rbSS.Checked = True
                Case Else
                    rbOther.Checked = True
            End Select
            If StatusTable.DataSet Is Nothing Then
                dsTmp = New DataSet
                dsTmp.Tables.Add(StatusTable)
            Else
                dsTmp = StatusTable.DataSet
            End If
        Else
            'If SCH_WEEKLY Xor dsSched.Tables(0).Rows(0).Item("SvcDate") Is Nothing Then
            '    MsgBox("Inconsistent Data for Schedule Type.")
            'End If
            HideWeekly(True)
            'StatusTable.Clear()



            'For Each row In dsSched.Tables(0).Rows
            '    STm = row("STm") : STm = STm.PadLeft(4, "0")
            '    CTm = row("CTm") : CTm = CTm.PadLeft(4, "0")

            '    StatusTable.Rows(row("Day") - 1).Item("Ofc") = row("Ofc")
            '    StatusTable.Rows(row("Day") - 1).Item("Rte") = row("Rte")
            '    StatusTable.Rows(row("Day") - 1).Item("STm") = STm
            '    StatusTable.Rows(row("Day") - 1).Item("CTm") = CTm
            '    StatusTable.Rows(row("Day") - 1).Item("Stp") = row("Stp")
            '    StatusTable.Rows(row("Day") - 1).Item("Chg") = row("Chg")
            'Next row

            dsTmp = dsSched
        End If
        ''tm3 = Now
        FillGrid1(dsTmp)
        ''tm2 = Now
        ''MsgBox("FillDataSet : After FillGrid1, Total : " & tm2.Subtract(tm1).ToString & ", FillGrid1 : " & tm2.Subtract(tm3).ToString)

        UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInBand, True, True)

        dtAdapter = Nothing
        dsSched = Nothing
        dsTmp = Nothing
        row = Nothing
        rowtmp = Nothing
    End Function

    Private Function FillGrid1(ByRef dsTmp As DataSet) 'DataTable
        Dim i As Integer
        Dim ugcol As Infragistics.Win.UltraWinGrid.UltraGridColumn

        UltraGrid1.DataSource = Nothing

        'UltraGrid1.DataSource = dsTmp
        'Exit Function

        FillUltraGrid(UltraGrid1, dsTmp)
        'AddDayCol()

        UltraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True
        UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit
        'UltraGrid1.DisplayLayout.AutoFitColumns = True


        For i = 0 To WCols.Length - 1
            For Each ugcol In UltraGrid1.DisplayLayout.Bands(0).Columns
                If WCols(i).Name = ugcol.ToString Then
                    ugcol.TabStop = Not WCols(i).NoEdit
                    ugcol.Hidden = WCols(i).Hide
                    ugcol.Format = WCols(i).Format
                    'ugcol.MaskInput = WCols(i).Format
                    ugcol.Width = WCols(i).Width
                    If Not WCols(i).BackColor.Equals(Color.Black) Then
                        ugcol.CellAppearance.BackColor = WCols(i).BackColor
                    End If
                    ugcol.FieldLen = WCols(i).MaxLength
                    GoTo Nexti
                End If
            Next ugcol
Nexti:
        Next i

        'UltraGrid1.DisplayLayout.Bands(0).Columns(0).Format = "MM/dd/yy-ddd"
        UltraGrid1.DisplayLayout.Bands(0).Columns(0).MaskInput = "mm/dd/yy"
        UltraGrid1.DisplayLayout.Bands(0).Columns(0).MaskDataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth

        'UltraGrid1.DisplayLayout.Bands(0).Columns("STm").Format = "HH :mm"
        UltraGrid1.DisplayLayout.Bands(0).Columns("STm").MaskInput = "hh:mm"

        UltraGrid1.DisplayLayout.Bands(0).Columns("STm").MaskDataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
        UltraGrid1.DisplayLayout.Bands(0).Columns("STm").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit
        UltraGrid1.DisplayLayout.Bands(0).Columns("STm").NullText = "    "

        'UltraGrid1.DisplayLayout.Bands(0).Columns("CTm").Format = "HH :mm"
        UltraGrid1.DisplayLayout.Bands(0).Columns("CTm").MaskInput = "hh:mm"
        UltraGrid1.DisplayLayout.Bands(0).Columns("CTm").MaskDataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
        UltraGrid1.DisplayLayout.Bands(0).Columns("CTm").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit
        UltraGrid1.DisplayLayout.Bands(0).Columns("CTm").NullText = "    "

        UltraGrid1.Update()
        UltraGrid1.UpdateData()

        'dsTmp = Nothing
    End Function

    Private Sub AddDayCol()
        Dim ugcol As Infragistics.Win.UltraWinGrid.UltraGridColumn

        ugcol = UltraGrid1.DisplayLayout.Bands(0).Columns.Add("Day", "Day")
        ugcol.DataType = GetType(System.String)
        ugcol.Header.VisiblePosition = 1
    End Sub

    Private Sub HideWeekly(ByVal Status As Boolean)
        'Disable the Panel2
        'Panel2.Visible = Not Status
        Panel3.Visible = Not Status
        'WCols(0).Hide = Not Status
        If Status Then
            Charge.Text = "0.00" : DailyAvg.Text = "0.00"
        End If
    End Sub

    '===================================================================
    '===================================================================
    '===================================================================
    '===================================================================
    '===================================================================
    '===================================================================
    '===================================================================


    'Private Sub PrepData(ByRef tbl As DataTable)
    '    Dim row As DataRow
    '    Dim col As DataColumn
    '    Dim i As Integer

    '    tbl.Clear()
    '    tbl.Columns.Clear()
    '    If WCols(0) Is Nothing Then
    '        SetupSchCols()
    '    End If


    '    If SCH_WEEKLY = True Then
    '        WCols(2).Hide = True
    '        WCols(3).Hide = False
    '    Else
    '        WCols(2).Hide = False
    '        WCols(3).Hide = True
    '    End If




    '    For i = 0 To WCols.Length - 1
    '        'If WCols(i).Hide = False Then
    '        col = tbl.Columns.Add(WCols(i).Name, WCols(i).Type)
    '        'End If
    '    Next

    '    'tbl.Columns.Add("Day", GetType(System.String))
    '    'tbl.Columns.Add("Ofc", GetType(System.Int32))
    '    'tbl.Columns.Add("Rte", GetType(System.String))
    '    'tbl.Columns.Add("STm", GetType(System.String))
    '    'tbl.Columns.Add("CTm", GetType(System.String))
    '    'tbl.Columns.Add("Stp", GetType(System.Int16))
    '    'tbl.Columns.Add("Chg", GetType(System.Decimal))

    '    If SCH_WEEKLY = True Then
    '        row = tbl.NewRow
    '        row("Day") = "Mon" ': row("Status") = "Active"
    '        tbl.Rows.Add(row)

    '        row = tbl.NewRow
    '        row("Day") = "Tue"
    '        tbl.Rows.Add(row)

    '        row = tbl.NewRow
    '        row("Day") = "Wed"
    '        tbl.Rows.Add(row)

    '        row = tbl.NewRow
    '        row("Day") = "Thu"
    '        tbl.Rows.Add(row)

    '        row = tbl.NewRow
    '        row("Day") = "Fri"
    '        tbl.Rows.Add(row)

    '        row = tbl.NewRow
    '        row("Day") = "Sat"
    '        tbl.Rows.Add(row)

    '        row = tbl.NewRow
    '        row("Day") = "Sun"
    '        tbl.Rows.Add(row)

    '        SetSchedDSBlank(tbl)
    '    End If


    'End Sub

    'Private Function SetupSchedGrid(ByRef tbl As Object) 'DataTable
    '    Dim i As Integer
    '    Dim dsTmp As DataSet
    '    If TypeOf (tbl) Is System.Data.DataTable Then
    '        If tbl.DataSet Is Nothing Then
    '            dsTmp = New DataSet()
    '            dsTmp.Tables.Add(tbl)
    '        Else
    '            dsTmp = tbl.dataset
    '        End If
    '    Else
    '        dsTmp = tbl
    '    End If
    '    Dim ugcol As Infragistics.Win.UltraWinGrid.UltraGridColumn

    '    UltraGrid1.DataSource = Nothing

    '    If SCH_WEEKLY = True Then
    '        FillUltraGrid(UltraGrid1, dsTmp)
    '    Else
    '        'ultragrid1.DisplayLayout.AddNewBox.
    '        Dim row As DataRow

    '        row = dsTmp.Tables(0).NewRow()
    '        dsTmp.Tables(0).Rows.Add(row)
    '        'UltraGrid1.DataSource = StatusTable
    '        FillUltraGrid(UltraGrid1, dsTmp)
    '        UltraGrid1.DisplayLayout.Bands(0).AddNew()
    '    End If

    '    UltraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True
    '    UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit
    '    UltraGrid1.DisplayLayout.AutoFitColumns = True

    '    For Each ugcol In UltraGrid1.DisplayLayout.Bands(0).Columns
    '        If ugcol.ToString = "STm" Or ugcol.ToString = "CTm" Then
    '            ugcol.MaskInput = "##:##"
    '            ugcol.MaskDisplayMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
    '            ugcol.MinWidth = 0
    '        End If
    '    Next ugcol

    '    For i = 0 To WCols.Length - 1
    '        If WCols(i).Name = UltraGrid1.DisplayLayout.Bands(0).Columns(i).ToString Then
    '            UltraGrid1.DisplayLayout.Bands(0).Columns(i).TabStop = Not WCols(i).NoEdit
    '            UltraGrid1.DisplayLayout.Bands(0).Columns(i).Hidden = WCols(i).Hide
    '            If Not WCols(i).BackColor.Equals(Color.Black) Then
    '                UltraGrid1.DisplayLayout.Bands(0).Columns(i).CellAppearance.BackColor = WCols(i).BackColor
    '            End If
    '        End If
    '    Next

    '    ''For i = 1 To 1
    '    ''    UltraGrid1.DisplayLayout.Bands(0).Columns(i).TabStop = False
    '    ''Next

    '    dsTmp = Nothing

    'End Function

    'Private Function FillSched()
    '    'Dim SchedHidCols() As String = {"ID", "SID"}
    '    Dim sqlSched As String = " Select ID, Day, ServiceDate as SvcDate, OfficeID as Ofc, RouteNo as Rte, REPLACE(SPACE(4 - len(stime)) + stime, ' ', '0') as STm, REPLACE(SPACE(4 - len(Ctime)) + Ctime, ' ', '0') as CTm, StopNo as Stp, Charge as Chg from ServiceSchedules where AccountID = " & AcctID.Text & " AND SID = " & SrvcID.Text & " Order by ID"

    '    Dim dtAdapter As SqlDataAdapter
    '    Dim dsSched As New DataSet()
    '    Dim row, rowtmp As DataRow
    '    Dim CritTmp, STm, CTm As String
    '    Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
    '    Dim WDays As Integer

    '    'crittmp.PadRight(
    '    If Val(AcctID.Text) <= 0 Or Val(SrvcID.Text) <= 1 Then
    '        Exit Function
    '    End If
    '    'CritTmp = AcctCriteria.Replace("@AcctID", AcctID.Text)
    '    PopulateDataset2(dtAdapter, dsSched, PrepSelectQuery(sqlSched, CritTmp))

    '    If SCH_WEEKLY Then
    '        PrepData(StatusTable)
    '        SetSchedDSBlank(StatusTable)
    '    Else
    '        StatusTable.Clear()
    '    End If
    '    If dsSched.Tables(0).Rows.Count > 0 Then
    '        If SCH_WEEKLY And TypeOf dsSched.Tables(0).Rows(0).Item("SvcDate") Is System.DBNull Then
    '            HideWeekly(False)
    '            SetupSchedGrid(StatusTable)
    '            For Each row In dsSched.Tables(0).Rows
    '                'Day #1 = Mon, Day #7 = Sun
    '                STm = row("STm") : STm = STm.PadLeft(4, "0")
    '                CTm = row("CTm") : CTm = CTm.PadLeft(4, "0")

    '                UltraGrid1.Rows(row("Day") - 1).Cells("Ofc").Value = row("Ofc")
    '                UltraGrid1.Rows(row("Day") - 1).Cells("Rte").Value = row("Rte")
    '                UltraGrid1.Rows(row("Day") - 1).Cells("STm").Value = STm
    '                UltraGrid1.Rows(row("Day") - 1).Cells("CTm").Value = CTm
    '                UltraGrid1.Rows(row("Day") - 1).Cells("Stp").Value = row("Stp")
    '                UltraGrid1.Rows(row("Day") - 1).Cells("Chg").Value = row("Chg")
    '                WDays = WDays + 2 ^ (row("Day") - 1)
    '            Next
    '            Select Case WDays
    '                Case MTWTF
    '                    rbMTWTF.Checked = True
    '                Case MTWT
    '                    rbMTWT.Checked = True
    '                Case MWF
    '                    rbMWF.Checked = True
    '                Case TT
    '                    rbTT.Checked = True
    '                Case SS
    '                    rbSS.Checked = True
    '                Case Else
    '                    rbOther.Checked = True
    '            End Select
    '        Else
    '            If SCH_WEEKLY Xor dsSched.Tables(0).Rows(0).Item("SvcDate") Is Nothing Then
    '                MsgBox("Inconsistent Data for Schedule Type.")
    '            End If
    '            HideWeekly(True)
    '            SetupSchedGrid(dsSched)
    '        End If
    '        UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInBand, True, True)
    '    Else
    '    End If

    '    UltraGrid1.Update()
    '    UltraGrid1.UpdateData()

    'End Function



    Private Sub btnOpenInfSID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSIDGroup.Click
        'UltraGrid1.DisplayLayout.Bands(0).AddNew()
        If Val(AcctID.Text) <= 0 Then
            Exit Sub
        End If
        If Val(SrvcID.Text) <= 0 Then
            Exit Sub
        End If
        Dim x As New RouteSvcGroups
        x.iAccountID = Val(AcctID.Text)
        x.Account.Text = AcctName.Text
        x.iSID = Val(SrvcID.Text)
        x.ShowDialog(Me)
        LoadGridData()

    End Sub

    Private Sub UltraGrid1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles UltraGrid1.KeyPress
        Dim ugcell As Infragistics.Win.UltraWinGrid.UltraGridCell

        If Not UltraGrid1.ActiveCell Is Nothing Then
            If Not UltraGrid1.ActiveCell.Value Is DBNull.Value Then
                If Asc(e.KeyChar) = 13 Or Asc(e.KeyChar) = 9 Then
                    Dim row As DataRow

                    ugcell = UltraGrid1.ActiveCell
                    If CStr(ugcell.Text) = "00 :00" Then
                        ugcell.Value = DBNull.Value
                        Exit Sub
                    End If
                    UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode, False, False)
                    If CStr(ugcell.Text) = "00 :00" Then
                        If Not (ugcell.Column.Header.Caption = "STm" Or ugcell.Column.Header.Caption = "CTm") Then
                            ugcell.Value = DBNull.Value
                        End If
                        UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, False, False)
                        e.Handled = False
                        SendKeys.Send("{TAB}")
                        'UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode, False, False)
                        Exit Sub
                    End If
                    UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, False, False)
                End If
            End If
        End If

        Dim str As String

        If Asc(e.KeyChar) = 13 Then
            If UltraGrid1.ActiveRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next) Is Nothing And Not UltraGrid1.ActiveCell Is Nothing Then
                If UltraGrid1.ActiveCell.Column.ToString = "Chg" Then
                    UltraGrid1.ActiveCell.Selected = True
                    If SCH_WEEKLY Then Exit Sub
                    UltraGrid1.DisplayLayout.Bands(0).AddNew()
                    UltraGrid1.ActiveCell = UltraGrid1.Rows(UltraGrid1.Rows.Count - 1).Cells("SvcDate")
                    UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, False, False)
                    UltraGrid1.ActiveCell.SelLength = 0 '= Len(CStr(UltraGrid1.ActiveCell.Value))
                    e.Handled = True
                    'UltraGrid1.ActiveCell.Selected = True
                Else
                    If TypeOf sender Is TextBox Then
                        Dim CtrlTBX As TextBox
                        CtrlTBX = sender.ActiveControl
                        If CtrlTBX.AcceptsReturn Then Exit Sub
                    End If
                    e.Handled = True
                    SendKeys.Send("{TAB}")
                End If
                'UltraGrid1.DisplayLayout.Bands(0).Columns("Day") = Weekday(e.Cell.Value)
            Else
                If TypeOf sender Is TextBox Then
                    Dim CtrlTBX As TextBox
                    CtrlTBX = sender.ActiveControl
                    If CtrlTBX.AcceptsReturn Then Exit Sub
                End If
                e.Handled = True
                SendKeys.Send("{TAB}")
            End If
        End If

    End Sub

    Private Sub UltraGrid1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles UltraGrid1.KeyDown
        If Not UltraGrid1.ActiveCell Is Nothing Then
            If Not UltraGrid1.ActiveCell.Value Is DBNull.Value Then
                If e.KeyCode = 13 Or e.KeyCode = 9 Then
                    Dim ugcell As Infragistics.Win.UltraWinGrid.UltraGridCell
                    Dim row As DataRow

                    ugcell = UltraGrid1.ActiveCell
                    If CStr(ugcell.Text) = "00 :00" Then
                        ugcell.Value = DBNull.Value
                        Exit Sub
                    End If
                    'UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode, false, false)
                    'umskOpenTime.InputMask = "hh:mm"
                    If ugcell.Column.Header.Caption = "STm" Or ugcell.Column.Header.Caption = "CTm" Then
                        Dim strTime As String
                        strTime = CStr(ugcell.Text)

                        If Not IsTime(strTime) Then
                            MessageBox.Show("Please enter a valid time as hh:mm")
                            ugcell.Value = ""
                            Exit Sub
                        End If
                    End If
                    'If CStr(ugcell.Text) = "00 :00" Then
                    '    ugcell.Value = DBNull.Value
                    '    Exit Sub
                    'End If

                    If ugcell.Value Is DBNull.Value Then Exit Sub
                    If CStr(ugcell.Value) = "" Or CStr(ugcell.Value) = "0" Then Exit Sub
                    Select Case UltraGrid1.ActiveCell.Column.ToString
                        Case "Ofc"
                            If ReturnRowByID(ugcell.Value, row, "SERVICEOFFICES", "Where Active = 1") Then Exit Sub
                            MessageBox.Show("Invalid OfficeID.")
                            ugcell.Value = 0
                            ugcell.Activate()
                            e.Handled = True
                        Case "Rte"
                            'UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode, False, False)
                            If CStr(UltraGrid1.ActiveRow.Cells("Ofc").Value) = "" Or CStr(UltraGrid1.ActiveRow.Cells("Ofc").Value) = "0" Then
                                MsgBox("OfficeID not entererd.")
                                ugcell.Value = ""
                                UltraGrid1.ActiveRow.Cells("Ofc").Activate()
                            End If
                            If Len(CStr(ugcell.Value)) < ROUTELEN Then
                                'This logic is invalid. RouteNo is 6 Chars with officeid in it. 
                                'ugcell.Value = CStr(ugcell.Value).PadLeft(4, "0")
                                'Exit Sub
                            End If
                            Dim strRoute As String = ugcell.Value

                            If strRoute.Length = 1 Then
                                If Val(strRoute) >= 0 And Val(strRoute) <= 9 Then
                                    strRoute = "0" & strRoute
                                End If
                            End If

                            'If Val(ugcell.Value) >= 0 Or Val(ugcell.Value) <= 9 Then
                            '    ugcell.Value = "0" & ugcell.Value
                            'End If
                            'If ReturnRowByID(ugcell.Value, row, AppTblPath & "ROUTES2", " OFFICEID = " & CStr(UltraGrid1.ActiveRow.Cells("Ofc").Value), " ROUTEID") Then Exit Sub
                            If ReturnRowByID(strRoute, row, AppTblPath & "ROUTES2", " OFFICEID = " & CStr(UltraGrid1.ActiveRow.Cells("Ofc").Value), " ROUTEID") Then Exit Sub
                            MessageBox.Show("Invalid Route.")
                            ugcell.Value = ""
                            ugcell.Activate()
                            e.Handled = True
                            UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, False, False)
                        Case "Stp"
                            'UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode, False, False)
                            If CStr(UltraGrid1.ActiveRow.Cells("Ofc").Value) = "" Or CStr(UltraGrid1.ActiveRow.Cells("Ofc").Value) = "0" Then
                                MsgBox("OfficeID not entererd.")
                                ugcell.Value = 0
                                UltraGrid1.ActiveRow.Cells("Ofc").Activate()
                            End If
                            If UltraGrid1.ActiveRow.Cells("Rte").Value = "" Then
                                MsgBox("Route not entererd.")
                                ugcell.Value = 0
                                UltraGrid1.ActiveRow.Cells("Rte").Activate()
                            End If

                            If SCH_WEEKLY Then
                                Dim dtAdapter As SqlDataAdapter
                                Dim dtSet2 As New DataSet
                                Dim CritTmp As String

                                If btnNew.Text = "&Cancel" And btnSave.Enabled Then
                                    CritTmp = "Select asv.rowid FROM " & ROUTESTblPath & "AccountServices asv, " & ROUTESTblPath & "ServiceSchedules ss where asv.AccountID = ss.AccountID and asv.id = ss.sid and ss.Day = " & UltraGrid1.ActiveRow.Index + 1 & " AND ss.OFFICEID = " & UltraGrid1.ActiveRow.Cells("Ofc").Value & " AND ss.RouteNo = '" & UltraGrid1.ActiveRow.Cells("Rte").Value & "' AND asv.EndDate is Null AND ss.StopNo = '" & UltraGrid1.ActiveRow.Cells("Stp").Value & "' AND ss.id NOT IN (SELECT ID FROM " & ROUTESTblPath & "serviceschedules ss2 WHERE ss2.RouteNo = " & UltraGrid1.ActiveRow.Cells("Rte").Value & " AND ss2.StopNo = " & UltraGrid1.ActiveRow.Cells("Stp").Value & ")"
                                Else
                                    CritTmp = "Select asv.rowid FROM " & ROUTESTblPath & "AccountServices asv, " & ROUTESTblPath & "ServiceSchedules ss where asv.AccountID = ss.AccountID and asv.id = ss.sid and ss.Day = " & UltraGrid1.ActiveRow.Index + 1 & " AND ss.OFFICEID = " & UltraGrid1.ActiveRow.Cells("Ofc").Value & " AND ss.RouteNo = '" & UltraGrid1.ActiveRow.Cells("Rte").Value & "' AND asv.EndDate is Null AND ss.StopNo = '" & UltraGrid1.ActiveRow.Cells("Stp").Value & "' AND ss.id NOT IN (SELECT ID FROM " & ROUTESTblPath & "serviceschedules ss2 WHERE ss2.AccountID = " & AcctID.Text & " AND ss2.SID = " & SrvcID.Text & ")"
                                End If


                                PopulateDataset2(dtAdapter, dtSet2, CritTmp)
                                If Not dtSet2 Is Nothing Then
                                    If dtSet2.Tables(0).Rows.Count > 0 Then
                                        'If ReturnRowByID(ugcell.Value, row, "ServiceSchedules", " Day = " & UltraGrid1.ActiveRow.Index + 1 & " AND OFFICEID = " & UltraGrid1.ActiveRow.Cells("Ofc").Value & " AND RouteNo = '" & UltraGrid1.ActiveRow.Cells("Rte").Value & "' ") Then
                                        MessageBox.Show("This Stop already existes. Please use another number.")
                                        dtSet2 = Nothing
                                        dtAdapter = Nothing
                                    Else
                                        Exit Sub
                                    End If
                                Else
                                    Exit Sub
                                End If
                                dtAdapter = Nothing
                                dtSet2 = Nothing
                            End If
                            'ugcell.Value = 0
                            ugcell.Activate()
                            e.Handled = True
                        Case "STm"
                            ugcell.Selected = True
                            'LibBug: ugcell.SelStart = 1
                            'LibBug: ugcell.SelLength = 5
                            'ugcell.Selected = True
                            'LibBug: ugcell.SelText = ugcell.GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth)
                            'e.Handled = True
                            'SendKeys.Flush()
                            UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, False, False)
                        Case "CTm"
                            ugcell.Selected = True
                            'LibBug: ugcell.SelStart = 1
                            'LibBug: ugcell.SelLength = 5
                            'ugcell.Selected = True
                            'LibBug: ugcell.SelText = ugcell.GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth)
                            'e.Handled = True
                            'SendKeys.Flush()
                            UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, False, False)
                    End Select
                End If
            End If
        End If

    End Sub

    Private Sub UltraGrid1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles UltraGrid1.KeyUp
        If e.KeyCode = 13 Or e.KeyCode = 9 Then
            Dim ugcell As Infragistics.Win.UltraWinGrid.UltraGridCell

            ugcell = UltraGrid1.ActiveCell
            If ugcell Is Nothing Then Exit Sub

            Select Case UltraGrid1.ActiveCell.Column.ToString
                Case "CTm"
                    ugcell.SelStart = 0
                    'ugcell.SelLength = 6
                    'ugcell.Selected = True
                    'UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, False, False)
                    'SendKeys.Send("{Home}")
                    'UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode, False, False)
                    'UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, False, False)

            End Select
        End If
    End Sub

    Private Sub AcctSvcSchedule_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles MyBase.KeyPress
        If Asc(e.KeyChar) = 13 Then
            If TypeOf sender.ActiveControl Is TextBox Then
                Dim CtrlTBX As TextBox
                CtrlTBX = sender.ActiveControl
                If CtrlTBX.AcceptsReturn Then Exit Sub
            End If
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If

    End Sub

    'Private Sub UltraGrid1_CellChange(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles UltraGrid1.CellChange
    '    If e.Cell.Column.ToString = "SvcDate" Then
    '        'UltraGrid1.ActiveRow.Cells("Day").Value = Weekday(e.Cell.Value)
    '    End If

    'End Sub

    Private Sub UltraGrid1_CellListSelect(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles UltraGrid1.CellListSelect
        If e.Cell.Column.ToString = "SvcDate" Then
            'UltraGrid1.ActiveRow.Cells("Day").Value = Weekday(e.Cell.Value)
        End If
    End Sub

    'Private Sub UltraGrid1_AfterCellCancelUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles UltraGrid1.AfterCellCancelUpdate
    '    If e.Cell.Column.ToString = "SvcDate" Then
    '        'UltraGrid1.ActiveRow.Cells("Day").Value = Weekday(e.Cell.Value)
    '    End If

    'End Sub

    'Private Sub UltraGrid1_AfterCellActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraGrid1.AfterCellActivate
    '    'UltraGrid1.ActiveRow.Cells("Day").Value = Weekday(UltraGrid1.ActiveCell.Value)

    'End Sub

    'Private Sub UltraGrid1_AfterCellListCloseUp(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles UltraGrid1.AfterCellListCloseUp
    '    If e.Cell.Column.ToString = "SvcDate" Then
    '        'UltraGrid1.ActiveRow.Cells("Day").Value = WeekdayName(Weekday(e.Cell.Value), True)
    '    End If
    'End Sub

    'Private Sub UltraGrid1_AfterExitEditMode(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraGrid1.AfterExitEditMode

    'End Sub

    Private Sub UltraGrid1_AfterCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles UltraGrid1.AfterCellUpdate
        Dim ugcell As Infragistics.Win.UltraWinGrid.UltraGridCell
        Dim row As DataRow

        ugcell = e.Cell 'UltraGrid1.ActiveCell

        If ugcell.Column.ToString = "STm" Then
            ugcell.Selected = True
            'LibBug: ugcell.SelStart = 0
            'LibBug: ugcell.SelLength = 6
            'ugcell.Selected = True
            'ugcell.SelText = ugcell.Text
        ElseIf ugcell.Column.ToString = "CTm" Then
            ugcell.Selected = True
        ElseIf ugcell.Column.ToString = "Chg" Then
            CalcDailyAvg()

        Else
            Select Case ugcell.Value.GetType.ToString
                Case "System.Byte", "System.Integer", "System.Int16", "System.Int32", "System.Int64", "System.Decimal"
                    If ugcell.Text = "" Then
                        ugcell.Value = 0
                    End If
            End Select
        End If

        'Dim ugcell As Infragistics.Win.UltraWinGrid.UltraGridCell
        'Dim row As DataRow

        ugcell = UltraGrid1.ActiveCell
        If ugcell Is Nothing Then Exit Sub

        If CStr(ugcell.Value) = "" Or CStr(ugcell.Value) = "0" Then Exit Sub
        Select Case UltraGrid1.ActiveCell.Column.ToString
            Case "Ofc"
                If ReturnRowByID(ugcell.Value, row, "SERVICEOFFICES") Then Exit Sub
                MessageBox.Show("Invalid OfficeID.")
                ugcell.Value = 0
                ugcell.Activate()
            Case "Rte"
                If CStr(UltraGrid1.ActiveRow.Cells("Ofc").Value) = "" Or CStr(UltraGrid1.ActiveRow.Cells("Ofc").Value) = "0" Then
                    MsgBox("OfficeID not entererd.")
                    ugcell.Value = ""
                    UltraGrid1.ActiveRow.Cells("Ofc").Activate()
                End If
                If Len(CStr(ugcell.Value)) < 4 Then
                    'ugcell.Value = CStr(ugcell.Value).PadLeft(4, "0")
                    'Exit Sub
                End If
                Dim strRoute As String = ugcell.Value

                If strRoute.Length = 1 Then
                    If Val(strRoute) >= 0 And Val(strRoute) <= 9 Then
                        strRoute = "0" & strRoute
                    End If
                End If

                'If ReturnRowByID(ugcell.Value, row, "ROUTES2", " OFFICEID = " & CStr(UltraGrid1.ActiveRow.Cells("Ofc").Value), "RouteId") Then Exit Sub
                If ReturnRowByID(strRoute, row, "ROUTES2", " OFFICEID = " & CStr(UltraGrid1.ActiveRow.Cells("Ofc").Value), "RouteId") Then Exit Sub

                MessageBox.Show("Invalid Route.")
                ugcell.Value = ""
                ugcell.Activate()
                e.Cell.SelStart = 1
                'UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.PrevCellInBand, False, False)
            Case "Stp"
                If CStr(UltraGrid1.ActiveRow.Cells("Ofc").Value) = "" Or CStr(UltraGrid1.ActiveRow.Cells("Ofc").Value) = "0" Then
                    MsgBox("OfficeID not entererd.")
                    ugcell.Value = ""
                    UltraGrid1.ActiveRow.Cells("Ofc").Activate()
                End If
                If UltraGrid1.ActiveRow.Cells("Rte").Value = "" Or UltraGrid1.ActiveRow.Cells("Rte").Value = "0000" Then
                    MsgBox("Route not entererd.")
                    ugcell.Value = 0
                    UltraGrid1.ActiveRow.Cells("Rte").Activate()
                End If

                If SCH_WEEKLY Then
                    If ReturnRowByID(ugcell.Value, row, ROUTESTblPath & "ServiceSchedules", " Day = " & UltraGrid1.ActiveRow.Index + 1 & " AND OFFICEID = " & UltraGrid1.ActiveRow.Cells("Ofc").Value & " AND RouteNo = '" & UltraGrid1.ActiveRow.Cells("Rte").Value & "'") Then
                        MessageBox.Show("This Stop already existes. Please use another number.")
                    Else
                        Exit Sub
                    End If
                Else
                    Exit Sub
                End If
                ugcell.Value = 0
                ugcell.Activate()
        End Select
    End Sub
    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        If AcctID.Text.Trim = "" Then Exit Sub
        LoadBySID(SrvcID, "N")
    End Sub

    Private Sub btnPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrev.Click
        If AcctID.Text.Trim = "" Then Exit Sub
        LoadBySID(SrvcID, "P")
    End Sub

    Private Sub Decimal_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs)
        sender.text = Format(Val(sender.text), "#0.#0")
    End Sub

    Private Sub Charge_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Charge.Leave
        Charge.Text = Format(Val(Charge.Text), "####0.#0")
        CalcDailyAvg()
    End Sub

    Private Function CalcDailyAvg() As Decimal
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim DAvg, DailyTotal As Decimal
        Dim RowCnt As Int16

        For Each ugRow In UltraGrid1.Rows
            If Not ugRow.Cells("Ofc").Value Is DBNull.Value Then
                If ugRow.Cells("Ofc").Value > 0 Then
                    RowCnt += 1
                    If Not ugRow.Cells("Chg").Value Is DBNull.Value Then
                        DailyTotal += ugRow.Cells("Chg").Value
                    End If
                End If
            End If
        Next
        If RowCnt = 0 Then
            DAvg = 0
            DailyAvg.Text = Format(DAvg, "#0.#0")
        Else
            If cboBillingCycle.SelectedValue <> "D" Then
                Charge.Text = Format(Val(Charge.Text), "#0.#0")
                Select Case cboBillingCycle.SelectedValue
                    Case "W" 'Weekly
                        DAvg = Val(Charge.Text) / RowCnt
                    Case "M" 'Monthly
                        DAvg = Val(Charge.Text) / (RowCnt * 52 / 12)
                    Case "A" 'Advance Monthly
                        DAvg = Val(Charge.Text) / (RowCnt * 52 / 12)
                    Case "B" 'BiWeekly
                        DAvg = Val(Charge.Text) / (RowCnt * 52 / 26)
                End Select
                DailyAvg.Text = Format(DAvg, "#0.#0")
            Else
                DAvg = DailyTotal / RowCnt
                DailyAvg.Text = Format(DAvg, "#0.#0")
                Charge.Text = Format(DailyTotal, "#0.#0")
            End If
        End If
        CalcDailyAvg = DAvg
    End Function


    Private Sub UltraGrid1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles UltraGrid1.Validating
        Dim i As Int16
        i = 1
    End Sub

    Private Sub UltraGrid1_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraGrid1.Validated
        Dim i As Int16
        i = 1
    End Sub

    Private Sub SvcCancelGroupChk()

        'Check to See if Account is Non revenue account then delete it from groups
        Dim DelSID2 As String = "Delete " & ROUTESTblPath & "ServiceGroupMembers from " & AppTblPath & "Customer, " & ROUTESTblPath & "AccountServices where " & AppTblPath & "customer.NRVNU = 1 AND  " & ROUTESTblPath & "ServiceGroupMembers.AccountID = " & AppTblPath & "Customer.ID AND " & ROUTESTblPath & "ServiceGroupMembers.SID = " & ROUTESTblPath & "AccountServices.ID AND " & ROUTESTblPath & "AccountServices.EndDate is not null and " & ROUTESTblPath & "AccountServices.EndDate < getdate()"
        If ExecuteQuery(DelSID2) = False Then
            MsgBox("Error Deleting from Members Table.")
        End If

    End Sub

    Private Sub umskEndDate_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles umskEndDate.Leave
        Dim i As Int16
        If umskEndDate.Text <> EndDateOldValue Then
            If (TypeOf umskEndDate.Value Is DBNull) Or (TextBox1.Text.Substring(0, 1) = "*") Then
                If MsgBox("Is this a restart?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "End Date Removed") = MsgBoxResult.Yes Then
                    EndDateOldValue = umskEndDate.Text
                    p_bRestartMode = True
                    umskStartDate.Focus()
                End If
            ElseIf Not TypeOf umskStartDate.Value Is DBNull Then
                If CDate(umskEndDate.Text) < CDate(umskStartDate.Text) Then
                    'Set End Date One Day Before Start for Not Billing Purposes
                    If UltraDate1.Value Is Nothing Or TypeOf UltraDate1.Value Is DBNull Then
                        If MsgBox("Do you want to prevent this service from being billed?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "End Date before Start Date") = MsgBoxResult.Yes Then
                            umskEndDate.Text = DateAdd(DateInterval.Day, -1, CDate(umskStartDate.Text))
                        Else
                            umskEndDate.Text = EndDateOldValue
                        End If
                    Else
                        MsgBox("This Service has been billed and you can not set the 'End Date' before Start Date.")
                        umskEndDate.Text = EndDateOldValue
                        Exit Sub
                    End If
                End If
            Else ' Start Date is mistakenly Blank
                'NOOP
            End If
        End If
    End Sub
    Private Sub umskEndDate_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles umskEndDate.Enter
        EndDateOldValue = umskEndDate.Text
    End Sub

    Private Sub umskStartDate_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles umskStartDate.Leave
        Dim i As Int16
        If sender.Text <> StartDateOldValue Then
            If TypeOf sender.Value Is DBNull Then
                MsgBox("Start Date can not be blank.")
                umskStartDate.Text = StartDateOldValue
            ElseIf Not TypeOf umskEndDate.Value Is DBNull Then
                If CDate(umskEndDate.Text) < CDate(umskStartDate.Text) Then
                    'Set Start Date One Day After EndDate for Not Billing Purposes
                    If UltraDate1.Value Is Nothing Or TypeOf UltraDate1.Value Is DBNull Then
                        If MsgBox("Do you want to prevent this service from being billed?", MsgBoxStyle.YesNo + MsgBoxStyle.Question, "End Date before Start Date") = MsgBoxResult.Yes Then
                            umskStartDate.Text = DateAdd(DateInterval.Day, 1, CDate(umskEndDate.Text))
                        Else
                            umskStartDate.Text = StartDateOldValue
                        End If
                    Else
                        MsgBox("This Service has been billed and you can not set the 'Start Date' After End Date.")
                        umskStartDate.Text = StartDateOldValue
                        Exit Sub
                    End If
                End If
            Else ' End Date is NULL, Could be a Restart or Date Adjustment
                ' NOOP
            End If
        End If
    End Sub
    Private Sub umskStartDate_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles umskStartDate.Enter
        StartDateOldValue = sender.Text
    End Sub

    Private Sub Ultragrid2_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles UltraGrid2.MouseDown

        If e.Button = MouseButtons.Right Then

            Dim oHeaderUI As Infragistics.Win.UltraWinGrid.HeaderUIElement
            Dim oCaptionUI As Infragistics.Win.UltraWinGrid.CaptionAreaUIElement
            Dim oUIElement As Infragistics.Win.UIElement
            Dim oUIElementTmp As Infragistics.Win.UIElement
            Dim point As Point = New Point(e.X, e.Y)


            oUIElement = Me.UltraGrid2.DisplayLayout.UIElement.ElementFromPoint(point)
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
                'CntMenu1.MenuItems.Add("Find", New EventHandler(AddressOf mnuFind_Click))
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
                For Each ugcol In UltraGrid2.DisplayLayout.Bands(0).Columns
                    If ugcol.Hidden = True Then
                        CntMenu1.MenuItems(1).MenuItems.Add(ugcol.ToString, New EventHandler(AddressOf SubMnuUnHide_Click))
                    End If
                Next

                CntMenu1.Show(UltraGrid2, point)
            Else 'Caption Click
                CntMenu1.MenuItems.Clear()
                CntMenu1.MenuItems.Add("AutoFit", New EventHandler(AddressOf mnuAutoFit_Click))
                CntMenu1.MenuItems(0).Checked = UltraGrid2.DisplayLayout.AutoFitColumns
                CntMenu1.MenuItems.Add("Save Layout", New EventHandler(AddressOf mnuSaveLayout_Click))
                CntMenu1.Show(UltraGrid2, point)

            End If


        End If

    End Sub

    Private Sub mnuAutoFit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If CntMenu1.MenuItems(0).Checked Then
            CntMenu1.MenuItems(0).Checked = False
        Else
            CntMenu1.MenuItems(0).Checked = True
        End If
        UltraGrid2.DisplayLayout.AutoFitColumns = CntMenu1.MenuItems(0).Checked

    End Sub

    Private Sub mnuSaveLayout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If Not UltraGrid2.DataSource Is Nothing Then
            If UGSaveLayout(Me, UltraGrid2, 1) = True Then
                MsgBox("Layout Saved.")
            Else
                MsgBox("Error Saving Layout.")
            End If
        End If
    End Sub

    Private Sub mnuHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles mnuHide.Click
        If Not m_oColumn Is Nothing Then
            m_oColumn.Hidden = True
        End If
    End Sub
    Private Sub SubMnuUnHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ugCol As Infragistics.Win.UltraWinGrid.UltraGridColumn

        For Each ugCol In UltraGrid2.DisplayLayout.Bands(0).Columns
            If ugCol.ToString = sender.text Then
                ugCol.Hidden = False
            End If
        Next

    End Sub

    Private Sub mnuSortAsc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles mnuSortAsc.Click
        UltraGrid2.DisplayLayout.Bands(0).SortedColumns.Add(m_oColumn, False)
    End Sub

    Private Sub mnuSortDesc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles mnuSortDesc.Click
        UltraGrid2.DisplayLayout.Bands(0).SortedColumns.Add(Me.m_oColumn, True)
    End Sub

    Private Sub ucboSvcType_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ucboSvcType.KeyPress, ucboPackage.KeyPress, ucboService.KeyPress, ucboState.KeyPress, ucboTimeFrame.KeyPress
        If Asc(e.KeyChar) = 13 Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnWgtPlans_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnWgtPlans.Click

        ' Weight Module 

        'Dim x As New WeightPlan
        'If SbjWgtModified = True Then
        '    If MsgBox("System should SAVE the service before openning the Weight-Plan screen. doyou want to continue?", MsgBoxStyle.YesNo, "Save Scheduled Service") = MsgBoxResult.No Then
        '        x = Nothing
        '        Exit Sub
        '    End If
        'End If
        'If Val(WgtPlanID.Text) <> 0 Then
        '    x.ManifestID.Text = WgtPlanID.Text
        '    x.xAcctID = Me.AcctID.Text
        '    x.Show()
        'Else
        '    x.StartPosition = FormStartPosition.CenterScreen
        '    x.ManifestID.Text = WgtPlanID.Text
        '    x.xAcctID = Me.AcctID.Text
        '    x.xSID = SrvcID.Text
        '    x.xLocName = Me.TextBox1.Text
        '    x.xStreet = Me.Street.Text
        '    x.xCity = Me.City.Text
        '    x.xStateIndex = Me.ucboState.SelectedRow.Index
        '    x.xZipcode = Me.Zipcode.Text
        '    x.xPhone1 = Me.Phone1.Text
        '    x.xPhone2 = Me.Phone2.Text
        '    x.xStartDate = Me.umskStartDate.Text
        '    x.Owner = Me
        '    'x.BringToFront()
        '    x.Show()
        'End If

    End Sub

    Private Sub chkSbjWgt_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSbjWgt.CheckedChanged
        ' Weight Module 

        btnWgtPlans.Enabled = chkSbjWgt.Checked
        SbjWgtModified = True

    End Sub

    Private Sub AcctSvcSchedule_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Validating
        'Me.LoadBySID(SrvcID)
    End Sub

    Private Sub AcctSvcSchedule_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        'Me.LoadBySID(SrvcID)
    End Sub

    Private Sub AcctSvcSchedule_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Validated
        'Me.LoadBySID(SrvcID)
    End Sub

    Public Function GetspData(ByVal AccountID As String, ByVal SID As String, ByVal SIDSign As String) As DataSet
        '**************************************************************************
        'SF - 5/5/2010 - Modified Stored Procedure SvcSched to include ADDRESSID and changed Stored Proedure 
        '                name to SvcSched2.  Sammy will remove SvcSched later
        '**************************************************************************
        Dim cnProcedure As New SqlConnection(strConnection)

        Dim cmd As New SqlCommand(ROUTESTblPath & "SvcSched2", cnProcedure)
        cmd.CommandType = CommandType.StoredProcedure
        ' Set up parameter for stored procedure 
        Dim prmAcctID As New SqlParameter
        prmAcctID.ParameterName = "@@AccountID"
        prmAcctID.SqlDbType = SqlDbType.VarChar
        prmAcctID.Size = 10
        prmAcctID.Value = AccountID

        cmd.Parameters.Add(prmAcctID)

        Dim prmSID As New SqlParameter
        prmSID.ParameterName = "@@SID"
        prmSID.SqlDbType = SqlDbType.VarChar
        prmSID.Size = 10
        prmSID.Value = SID

        cmd.Parameters.Add(prmSID)

        Dim prmSIDSign As New SqlParameter
        prmSIDSign.ParameterName = "@@SIDSign"
        prmSIDSign.SqlDbType = SqlDbType.VarChar
        prmSIDSign.Size = 1
        prmSIDSign.Value = SIDSign

        cmd.Parameters.Add(prmSIDSign)

        Dim daGetRecs As New SqlDataAdapter(cmd)
        Dim dsOrders As New DataSet
        daGetRecs.Fill(dsOrders, "Orders")

        GetspData = dsOrders

        dsOrders = Nothing
        daGetRecs = Nothing
    End Function

    Private Sub btnLocation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLocation.Click
        '**************************************************
        'SF - 5/4/2010 - Added Select button to choose location and return address info
        '**************************************************
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim gLocID, gLoc, gAddrID As Infragistics.Win.UltraWinEditors.UltraTextEditor

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
                    ucboState.Text = ugRow.Cells("Statecode").Text
                    City.Text = ugRow.Cells("CityName").Text
                    Zipcode.Text = ugRow.Cells("ZipCode").Text

                    Srch = Nothing

                End If
                dtAdapter = Nothing
                dtSet = Nothing
                dtView = Nothing
            End Try
        End If
    End Sub

    Private Sub btnDel1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDel1.Click
        DeleteRouteFromGrid()
    End Sub

    Private Sub UltraGrid1_AfterRowActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraGrid1.AfterRowActivate
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow

        If Not UltraGrid1.Enabled Then Exit Sub
        Try
            EnDisDeleteBtns()

            ugRow = UltraGrid1.ActiveRow

            If ugRow.Cells("Ofc").Text <> "" And ugRow.Cells("Rte").Text <> "" And ugRow.Cells("Stp").Text <> "" Then

                Select Case ugRow.Index
                    Case 0
                        btnDel1.Enabled = True
                    Case 1
                        btnDel2.Enabled = True
                    Case 2
                        btnDel3.Enabled = True
                    Case 3
                        btnDel4.Enabled = True
                    Case 4
                        btnDel5.Enabled = True
                    Case 5
                        btnDel6.Enabled = True
                    Case 6
                        btnDel7.Enabled = True
                End Select
                Me.txtGridOfc.Text = ugRow.Cells("Ofc").Text
                Me.txtGridRte.Text = ugRow.Cells("Rte").Text
                Me.txtGridStp.Text = ugRow.Cells("Stp").Text
            End If
        Catch ex As Exception

        End Try

    End Sub

    Private Sub btnDel2_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDel2.Click
        DeleteRouteFromGrid()
    End Sub

    Private Sub DeleteRouteFromGrid()
        '**************************************************
        'SF - 6/8/2010 - This routine will delete the selected route from the grid
        '**************************************************
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim cRow As New SchedCols
        Dim row As DataRow
        Dim DelQry As String
        Dim lngDay As Long

        Try

            Select Case UltraGrid1.ActiveRow.Index
                Case 0
                    lngDay = 1
                Case 1
                    lngDay = 2
                Case 2
                    lngDay = 3
                Case 3
                    lngDay = 4
                Case 4
                    lngDay = 5
                Case 5
                    lngDay = 6
                Case 6
                    lngDay = 7
            End Select

            DelQry = "Delete FROM " & ROUTESTblPath & "" & UltraGrid1.Tag & " "
            DelQry = DelQry & "Where AccountID = " & AcctID.Text & " And SID = " & SrvcID.Text
            DelQry = DelQry & " AND OfficeId = " & txtGridOfc.Text & " And RouteNo = " & txtGridRte.Text
            DelQry = DelQry & " AND Day = " & lngDay
            DelQry = DelQry & " AND StopNo = " & txtGridStp.Text

            If ExecuteQuery(DelQry, , True) Then
                LoadBySID(SrvcID)
                Call BtnSave_Click(New System.Object, New System.EventArgs)

            End If

        Catch ex As Exception

        Finally
            cRow = Nothing
            row = Nothing
        End Try
    End Sub

    Private Sub btnDel3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDel3.Click
        DeleteRouteFromGrid()
    End Sub

    Private Sub btnDel4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDel4.Click
        DeleteRouteFromGrid()
    End Sub

    Private Sub btnDel5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDel5.Click
        DeleteRouteFromGrid()
    End Sub

    Private Sub btnDel6_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDel6.Click
        DeleteRouteFromGrid()
    End Sub

    Private Sub btnDel7_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnDel7.Click
        DeleteRouteFromGrid()
    End Sub

    Public Function IsTime(ByVal Time As Object) As Boolean
        '*****************************************************************
        '* This subroutine determines if a value is a valid time 
        '* (not  date).
        '************************************************************
        Dim strHour() As String

        Try
            strHour = CStr(Time).Split(":")

            If (strHour(0) >= "0" And strHour(0) <= "23") Or strHour(0) = "00" Or strHour(0) = "0" Or strHour(0) = "_0" Or strHour(0) = "_1" Or strHour(0) = "_2" Or strHour(0) = "_3" Or strHour(0) = "_4" Or strHour(0) = "_5" Or strHour(0) = "_6" Or strHour(0) = "_7" Or strHour(0) = "_8" Or strHour(0) = "_9" Then
                'If strHour(0) > "01" And strHour(0) < "12" Then
                'If strHour(1) >= "00" And strHour(1) <= "59" Then
                If (strHour(1) >= "00" And strHour(1) <= "59") Or strHour(1) = "__" Then
                    IsTime = True
                End If
            End If
        Catch ex As Exception

        Finally

        End Try

    End Function

    Public Function OnlyHours(ByVal time As String, ByRef strNewTime As String) As Boolean
        '*****************************************************************
        '* This subroutine determines if a value only has hours
        '************************************************************
        Dim strHour() As String

        Try
            strHour = CStr(time).Split(":")

            If (strHour(0) >= "0" And strHour(0) <= "23") Or strHour(0) = "00" Or strHour(0) = "0" Or strHour(0) = "_1" Or strHour(0) = "_2" Or strHour(0) = "_3" Or strHour(0) = "_4" Or strHour(0) = "_5" Or strHour(0) = "_6" Or strHour(0) = "_7" Or strHour(0) = "_8" Or strHour(0) = "_9" Then
                'If strHour(0) > "01" And strHour(0) < "12" Then
                If strHour(1) = "__" Then
                    OnlyHours = True
                    strNewTime = strHour(0) & ":00"
                End If
                'If strHour(1) >= "00" And strHour(1) <= "59" Then
                '    OnlyHours = True
                'End If
            End If
        Catch ex As Exception

        Finally

        End Try
    End Function


    Private Sub UltraGrid1_CellDataError(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellDataErrorEventArgs) Handles UltraGrid1.CellDataError
        e.RaiseErrorEvent = False
        e.RestoreOriginalValue = True
        e.StayInEditMode = True
        Dim ugcell As Infragistics.Win.UltraWinGrid.UltraGridCell
        Dim row As DataRow

        ugcell = UltraGrid1.ActiveCell
        If CStr(ugcell.Text) = "00 :00" Then
            ugcell.Value = DBNull.Value
            Exit Sub
        End If
        'UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode, false, false)
        'umskOpenTime.InputMask = "hh:mm"
        If ugcell.Column.Header.Caption = "STm" Or ugcell.Column.Header.Caption = "CTm" Then
            Dim strTime As String
            Dim strNewTime As String
            strTime = CStr(ugcell.Text)

            If OnlyHours(strTime, strNewTime) Then
                'MessageBox.Show("Please enter a valid time as hh:mm")
                ugcell.Value = strNewTime
                Exit Sub
            End If
        End If
    End Sub

    Private Sub SrvcID_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SrvcID.TextChanged
        If SrvcID.Text.Trim <> "" Then
            Me.btnEdit.Enabled = True
        Else
            Me.btnEdit.Enabled = False
        End If
    End Sub

    Private Sub UltraGrid1_InitializeLayout(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeLayoutEventArgs) Handles UltraGrid1.InitializeLayout
        Dim i As Integer

        For i = 0 To UltraGrid1.Rows.Count - 1
            UltraGrid1.Rows(i).Cells("Rte").Text.ToUpper()
        Next
    End Sub

    Private Sub btnChangeSchedule_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeSchedule.Click
        If MessageBox.Show("Are you sure, that you want to change the schedule type of the service?", "WARNING - Change of Schedule Service  Type", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = DialogResult.OK Then
            Panel1.Enabled = True
        Else
            Panel1.Enabled = False
        End If
    End Sub

    Private Sub btnChangeDay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnChangeDay.Click
        If MessageBox.Show("Are you sure, that you want to change the service days on the schedule?", "WARNING - Change of Schedule Service Days", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) = DialogResult.OK Then
            Panel2.Enabled = True
        Else
            Panel2.Enabled = False
        End If
    End Sub
End Class
