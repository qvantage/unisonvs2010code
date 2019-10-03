Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors

Public Class IncreaseAccounts
    Inherits System.Windows.Forms.Form

    'changed  *= to = in query on 7 nov 2017 fo fix error
    Dim sqlIncreaseAcc As String = " Select convert(Bit, 0) as ChkBx, c.ID, c.name as Account, c.CreateDate as [Create Date], c.BCycleCode " & _
                              " , (select top 1 incdate FROM " & ROUTESTblPath & "IncreaseRatesAcct where applied = 1 AND AccountID = c.ID AND incdate < (select top 1 incdate FROM " & ROUTESTblPath & "IncreaseRatesAcct where applied = 1 AND AccountID = c.ID AND incdate < (SELECT MAX(incdate) FROM " & ROUTESTblPath & "IncreaseRatesAcct WHERE applied = 1 AND AccountID = c.ID) order by incdate desc) order by incdate desc) as [LastIncDate3] " & _
                              " , isnull((select top 1 rate FROM " & ROUTESTblPath & "IncreaseRatesAcct where applied = 1 AND AccountID = c.ID AND incdate < (select top 1 incdate FROM " & ROUTESTblPath & "IncreaseRatesAcct where applied = 1 AND AccountID = c.ID AND incdate < (SELECT MAX(incdate) FROM " & ROUTESTblPath & "IncreaseRatesAcct WHERE applied = 1 AND AccountID = c.id) order by incdate desc) order by incdate desc), 0) as [LastIncRate3] " & _
                              " , (select top 1 incdate FROM " & ROUTESTblPath & "IncreaseRatesAcct where applied = 1 AND AccountID = c.ID AND incdate < (SELECT MAX(incdate) FROM " & ROUTESTblPath & "IncreaseRatesAcct WHERE applied = 1 AND AccountID = c.ID) order by incdate desc) as [LastIncDate2] " & _
                              " , isnull((select top 1 rate FROM " & ROUTESTblPath & "IncreaseRatesAcct where applied = 1 AND AccountID = c.ID AND incdate < (SELECT MAX(incdate) FROM " & ROUTESTblPath & "IncreaseRatesAcct WHERE applied = 1 AND AccountID = c.id) order by incdate desc), 0) as [LastIncRate2] " & _
                              " , (select top 1 incdate FROM " & ROUTESTblPath & "IncreaseRatesAcct where applied = 1 AND AccountID = c.ID order by incdate desc) as [LastIncDate1] " & _
                              " , isnull((select top 1 rate FROM " & ROUTESTblPath & "IncreaseRatesAcct where applied = 1 AND AccountID = c.ID order by incdate desc), 0) as [LastIncRate1] " & _
                              " , c.FuelSURCHARGE as [Fuel Sur.], c.DISCOUNTRATE " & _
                              " , (SELECT isnull(sum(asvc.Charge), 0.00) FROM " & ROUTESTblPath & "AccountServices asvc WHERE asvc.AccountID = c.ID AND asvc.Enddate is null ) as TotChg " & _
                              " , (select top 1 incdate FROM " & ROUTESTblPath & "IncreaseRatesAcct where applied = 0 AND AccountID = c.ID order by incdate asc) as [Next Inc. Date]  " & _
                              " , isnull((select top 1 rate FROM " & ROUTESTblPath & "IncreaseRatesAcct where applied = 0 AND AccountID = c.ID order by incdate asc), 0) as [Next Inc. Rate]  " & _
                              " , (SELECT isnull(sum((1+irax.rate/100)*asvc.Charge), 0.00) FROM " & ROUTESTblPath & "AccountServices asvc, " & ROUTESTblPath & "IncreaseRatesAcct irax WHERE irax.applied = 0 AND irax.AccountID = c.ID AND irax.AccountID = asvc.AccountID AND asvc.Enddate is null ) as [NCost] " & _
                              " , isnull((select top 1 Comment FROM " & ROUTESTblPath & "IncreaseRatesAcct where applied = 0 AND AccountID = c.ID order by incdate asc), '') as Comment" & _
                              " From " & AppTblPath & "Customer c, BillingCycles b " & _
                              " where c.BCycleCode = b.Code @CondMain AND c.status = 1 " & _
                              " Order By c.Name"

    Dim MeText As String
    Dim dtSet As New DataSet()
    Dim m_oColumn As Infragistics.Win.UltraWinGrid.UltraGridColumn = Nothing
    Dim cmdTrans As SqlCommand

    Private Enum G1Col
        ChkBx
        AID
        AName
        CrDate
        BCycleCode
        LastIncDate3
        LastIncRate3
        LastIncDate2
        LastIncRate2
        LastIncDate1
        LastIncRate1
        FuelSur
        Disc
        CurrCost
        NIncDate
        NIncRate
        NIncCost
        Cmnt
        ZLastItem
    End Enum

    Class G1Cols
        Public Name As String
        Public dbFldName As String
        Public Type As Type
        Public Format As String
        Public uMask As String
        Public NoEdit As Boolean
        Public Hide As Boolean
        Public BackColor As Color
        Public MaxLength As Byte
        Public Width As Byte
        Public FldCond As String
    End Class

    Dim WCols() As G1Cols

    Dim StatusTable As New DataTable()
    Dim EnabledStatus As Boolean


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
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents cboFilter1 As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents cboFilter2 As System.Windows.Forms.ComboBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cboFilter3 As System.Windows.Forms.ComboBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents tbF1 As System.Windows.Forms.TextBox
    Friend WithEvents umskF1 As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents btnSelectAll As System.Windows.Forms.Button
    Friend WithEvents btnIncrease As System.Windows.Forms.Button
    Friend WithEvents btnUnselelct As System.Windows.Forms.Button
    Friend WithEvents umskF2 As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents umskF3 As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents CntMenu1 As System.Windows.Forms.ContextMenu
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.umskF3 = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit()
        Me.umskF2 = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit()
        Me.btnUnselelct = New System.Windows.Forms.Button()
        Me.btnIncrease = New System.Windows.Forms.Button()
        Me.btnSelectAll = New System.Windows.Forms.Button()
        Me.umskF1 = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit()
        Me.tbF1 = New System.Windows.Forms.TextBox()
        Me.cboFilter3 = New System.Windows.Forms.ComboBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.cboFilter2 = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.cboFilter1 = New System.Windows.Forms.ComboBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.CntMenu1 = New System.Windows.Forms.ContextMenu()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnPrint, Me.btnExit, Me.btnSave})
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox2.Location = New System.Drawing.Point(0, 437)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(872, 40)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'btnPrint
        '
        Me.btnPrint.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnPrint.Location = New System.Drawing.Point(78, 16)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(75, 21)
        Me.btnPrint.TabIndex = 1
        Me.btnPrint.Text = "&Print"
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnExit.Location = New System.Drawing.Point(794, 16)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 21)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Text = "E&xit"
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.umskF3, Me.umskF2, Me.btnUnselelct, Me.btnIncrease, Me.btnSelectAll, Me.umskF1, Me.tbF1, Me.cboFilter3, Me.Label2, Me.cboFilter2, Me.Label1, Me.cboFilter1, Me.Label12, Me.btnLoad})
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(872, 96)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'umskF3
        '
        Me.umskF3.Location = New System.Drawing.Point(184, 64)
        Me.umskF3.Name = "umskF3"
        Me.umskF3.Nullable = True
        Me.umskF3.ReadOnly = False
        Me.umskF3.Size = New System.Drawing.Size(176, 20)
        Me.umskF3.TabIndex = 5
        Me.umskF3.Tag = ".StartDate........Now"
        '
        'umskF2
        '
        Me.umskF2.Location = New System.Drawing.Point(184, 40)
        Me.umskF2.Name = "umskF2"
        Me.umskF2.Nullable = True
        Me.umskF2.ReadOnly = False
        Me.umskF2.Size = New System.Drawing.Size(176, 20)
        Me.umskF2.TabIndex = 3
        Me.umskF2.Tag = ".StartDate........Now"
        '
        'btnUnselelct
        '
        Me.btnUnselelct.Location = New System.Drawing.Point(760, 40)
        Me.btnUnselelct.Name = "btnUnselelct"
        Me.btnUnselelct.Size = New System.Drawing.Size(104, 21)
        Me.btnUnselelct.TabIndex = 9
        Me.btnUnselelct.Text = "&UnSelect All"
        '
        'btnIncrease
        '
        Me.btnIncrease.Location = New System.Drawing.Point(760, 16)
        Me.btnIncrease.Name = "btnIncrease"
        Me.btnIncrease.Size = New System.Drawing.Size(104, 21)
        Me.btnIncrease.TabIndex = 7
        Me.btnIncrease.Text = "Set &Increase Rate"
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Location = New System.Drawing.Point(640, 40)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(104, 21)
        Me.btnSelectAll.TabIndex = 8
        Me.btnSelectAll.Text = "&Select All"
        '
        'umskF1
        '
        Me.umskF1.Location = New System.Drawing.Point(184, 16)
        Me.umskF1.Name = "umskF1"
        Me.umskF1.Nullable = True
        Me.umskF1.ReadOnly = False
        Me.umskF1.Size = New System.Drawing.Size(176, 20)
        Me.umskF1.TabIndex = 1
        Me.umskF1.Tag = ".StartDate........Now"
        '
        'tbF1
        '
        Me.tbF1.Location = New System.Drawing.Point(640, 64)
        Me.tbF1.Name = "tbF1"
        Me.tbF1.Size = New System.Drawing.Size(19, 20)
        Me.tbF1.TabIndex = 10
        Me.tbF1.Text = ""
        Me.tbF1.Visible = False
        '
        'cboFilter3
        '
        Me.cboFilter3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFilter3.Location = New System.Drawing.Point(54, 64)
        Me.cboFilter3.Name = "cboFilter3"
        Me.cboFilter3.Size = New System.Drawing.Size(128, 21)
        Me.cboFilter3.TabIndex = 4
        Me.cboFilter3.Tag = ".HDate...Holidays.ID.Convert(Varchar,HDate,101)..HDate"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 64)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 16)
        Me.Label2.TabIndex = 81
        Me.Label2.Text = "Filter 3: "
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboFilter2
        '
        Me.cboFilter2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFilter2.Location = New System.Drawing.Point(54, 40)
        Me.cboFilter2.Name = "cboFilter2"
        Me.cboFilter2.Size = New System.Drawing.Size(128, 21)
        Me.cboFilter2.TabIndex = 2
        Me.cboFilter2.Tag = ".HDate...Holidays.ID.Convert(Varchar,HDate,101)..HDate"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 40)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 16)
        Me.Label1.TabIndex = 79
        Me.Label1.Text = "Filter 2: "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'cboFilter1
        '
        Me.cboFilter1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboFilter1.Location = New System.Drawing.Point(54, 14)
        Me.cboFilter1.Name = "cboFilter1"
        Me.cboFilter1.Size = New System.Drawing.Size(128, 21)
        Me.cboFilter1.TabIndex = 0
        Me.cboFilter1.Tag = ".HDate...Holidays.ID.Convert(Varchar,HDate,101)..HDate"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(9, 17)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(48, 16)
        Me.Label12.TabIndex = 77
        Me.Label12.Text = "Filter 1: "
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(640, 16)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(104, 21)
        Me.btnLoad.TabIndex = 6
        Me.btnLoad.Text = "&Preview Accounts"
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGrid1.Location = New System.Drawing.Point(0, 96)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(872, 341)
        Me.UltraGrid1.TabIndex = 1
        Me.UltraGrid1.Text = "Accounts & Services"
        '
        'IncreaseAccounts
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(872, 477)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.UltraGrid1, Me.GroupBox1, Me.GroupBox2})
        Me.Name = "IncreaseAccounts"
        Me.Text = "Increase Accounts Service Charges"
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub IncreaseAccounts_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        AddHandler Me.Activated, AddressOf Form_Activated
        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = ROUTESTblPath & Me.Tag
            End If
        End If

        Me.CenterToScreen()

        Me.KeyPreview = True
        MeText = Me.Text

        AddHandler Me.KeyUp, AddressOf Form_KeyUp
        ReDim WCols(G1Col.ZLastItem - 1)
        SetupSchCols()
        FillCombos()
    End Sub

    Private Sub FillCombos()
        Dim i As Int32

        cboFilter1.Items.Add("No Selection")
        cboFilter2.Items.Add("No Selection")
        cboFilter3.Items.Add("No Selection")

        For i = 1 To WCols.Length - 1
            cboFilter1.Items.Add(WCols(i).Name)
            cboFilter2.Items.Add(WCols(i).Name)
            cboFilter3.Items.Add(WCols(i).Name)
        Next

    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    'Private Sub LoadData()

    '    Dim dtAdapter As SqlDataAdapter
    '    Dim TempQuery As String

    '    If Not dtSet.Tables Is Nothing Then
    '        dtSet.Tables.Clear()
    '    End If


    '    PopulateDataset2(dtAdapter, dtSet, sqlIncreaseAcc)

    '    FillUltraGrid(UltraGrid1, dtSet, 0)
    '    'UGLoadListingLayout(UltraGrid1, TemplateID)
    '    UltraGrid1.DisplayLayout.GroupByBox.Hidden = False
    '    UltraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
    '    Me.Text = MeText

    'End Sub

    Private Sub btnLoad_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLoad.Click
        'LoadData()
        LoadGrid1()
    End Sub

    '==================================================================================
    ' Grid1 Buffer Functions ....
    '==================================================================================

    Private Sub SetupSchCols()
        Dim i As Integer
        Dim col As DataColumn

        If Not WCols(0) Is Nothing Then
            Exit Sub
        End If

        For i = 0 To WCols.Length - 1
            WCols(i) = New G1Cols()
        Next

        WCols(G1Col.ChkBx).Name = "Select"
        WCols(G1Col.ChkBx).dbFldName = ""
        WCols(G1Col.ChkBx).FldCond = ""
        WCols(G1Col.ChkBx).Type = GetType(System.Boolean)
        WCols(G1Col.ChkBx).Format = ""
        WCols(G1Col.ChkBx).uMask = ""
        WCols(G1Col.ChkBx).NoEdit = False
        WCols(G1Col.ChkBx).Hide = False
        'WCols(G1Col.ChkBx).BackColor = Color.White
        WCols(G1Col.ChkBx).Width = 20


        WCols(G1Col.AID).Name = "AcctID"
        WCols(G1Col.AID).dbFldName = "c.ID"
        WCols(G1Col.AID).FldCond = "AND c.ID = @FLDVAL"
        WCols(G1Col.AID).Type = GetType(System.Int32)
        WCols(G1Col.AID).Format = ""
        WCols(G1Col.AID).uMask = "######"
        WCols(G1Col.AID).NoEdit = True
        WCols(G1Col.AID).Hide = False
        WCols(G1Col.AID).BackColor = Color.GhostWhite
        WCols(G1Col.AID).Width = 45

        WCols(G1Col.AName).Name = "Account"
        WCols(G1Col.AName).dbFldName = "c.name"
        WCols(G1Col.AName).FldCond = "AND c.name = @FLDVAL"
        WCols(G1Col.AName).Type = GetType(System.String)
        WCols(G1Col.AName).Format = ""
        WCols(G1Col.AName).uMask = ""
        WCols(G1Col.AName).NoEdit = True
        WCols(G1Col.AName).Hide = False
        WCols(G1Col.AName).BackColor = Color.GhostWhite
        WCols(G1Col.AName).Width = 100

        WCols(G1Col.CrDate).Name = "Cr. Date"
        WCols(G1Col.CrDate).dbFldName = "c.CreateDate"
        WCols(G1Col.CrDate).FldCond = " AND convert(varchar,c.CreateDate,101) = @FLDVAL "
        WCols(G1Col.CrDate).Type = GetType(System.DateTime)
        WCols(G1Col.CrDate).Format = "MM/dd/yy"
        WCols(G1Col.CrDate).uMask = "mm/dd/yyyy"
        WCols(G1Col.CrDate).NoEdit = True
        WCols(G1Col.CrDate).Hide = False
        WCols(G1Col.CrDate).Width = 55

        WCols(G1Col.BCycleCode).Name = "BCycle"
        WCols(G1Col.BCycleCode).dbFldName = "c.BCycleCode"
        WCols(G1Col.BCycleCode).FldCond = " AND c.BCycleCode = @FLDVAL"
        WCols(G1Col.BCycleCode).Type = GetType(System.String)
        WCols(G1Col.BCycleCode).Format = ""
        WCols(G1Col.BCycleCode).uMask = ""
        WCols(G1Col.BCycleCode).NoEdit = True
        WCols(G1Col.BCycleCode).Hide = False
        'WCols(G1Col.BCycleCode).MaxLength = 4
        WCols(G1Col.BCycleCode).Width = 25

        WCols(G1Col.LastIncDate3).Name = "IncHist3"
        WCols(G1Col.LastIncDate3).dbFldName = "" '         incdate(applied = 0)   Rate(applied = 0)
        WCols(G1Col.LastIncDate3).FldCond = " and c.ID in (SELECT top 1 AccountID FROM " & ROUTESTblPath & "IncreaseRatesAcct WHERE applied = 1  AND incdate < (select top 1 incdate FROM " & ROUTESTblPath & "IncreaseRatesAcct where applied = 1 AND AccountID = c.ID AND incdate < (SELECT MAX(incdate) FROM " & ROUTESTblPath & "IncreaseRatesAcct WHERE applied = 1 ) order by IncDate desc) And incdate = @FLDVAL order by IncDate desc)"
        WCols(G1Col.LastIncDate3).Type = GetType(System.DateTime)
        WCols(G1Col.LastIncDate3).Format = "MM/dd/yy"
        WCols(G1Col.LastIncDate3).uMask = "mm/dd/yyyy"
        WCols(G1Col.LastIncDate3).NoEdit = True
        WCols(G1Col.LastIncDate3).Hide = False
        WCols(G1Col.LastIncDate3).Width = 55

        WCols(G1Col.LastIncRate3).Name = "IncR3%"
        WCols(G1Col.LastIncRate3).dbFldName = "" '         incdate(applied = 0)   Rate(applied = 0)
        WCols(G1Col.LastIncRate3).FldCond = " and c.ID in (SELECT top 1 AccountID FROM " & ROUTESTblPath & "IncreaseRatesAcct WHERE applied = 1 AND incdate < (select top 1 incdate FROM " & ROUTESTblPath & "IncreaseRatesAcct where applied = 1 AND AccountID = c.ID AND incdate < (SELECT MAX(incdate) FROM " & ROUTESTblPath & "IncreaseRatesAcct WHERE applied = 1 ) order by IncDate desc) And Rate = @FLDVAL order by IncDate desc)"
        WCols(G1Col.LastIncRate3).Type = GetType(System.Decimal)
        WCols(G1Col.LastIncRate3).Format = "##0.#0"
        WCols(G1Col.LastIncRate3).uMask = "###.##"
        WCols(G1Col.LastIncRate3).NoEdit = True
        WCols(G1Col.LastIncRate3).MaxLength = 7
        WCols(G1Col.LastIncRate3).Hide = False
        WCols(G1Col.LastIncRate3).Width = 45

        WCols(G1Col.LastIncDate2).Name = "IncHist2"
        WCols(G1Col.LastIncDate2).dbFldName = "" '         incdate(applied = 0)   Rate(applied = 0)
        WCols(G1Col.LastIncDate2).FldCond = " and c.ID in (SELECT top 1 AccountID FROM " & ROUTESTblPath & "IncreaseRatesAcct WHERE applied = 1  AND incdate < (SELECT MAX(incdate) FROM " & ROUTESTblPath & "IncreaseRatesAcct WHERE applied = 1 ) And incdate = @FLDVAL order by IncDate desc)"
        WCols(G1Col.LastIncDate2).Type = GetType(System.DateTime)
        WCols(G1Col.LastIncDate2).Format = "MM/dd/yy"
        WCols(G1Col.LastIncDate2).uMask = "mm/dd/yyyy"
        WCols(G1Col.LastIncDate2).NoEdit = True
        WCols(G1Col.LastIncDate2).Hide = False
        WCols(G1Col.LastIncDate2).Width = 55

        WCols(G1Col.LastIncRate2).Name = "IncR2%"
        WCols(G1Col.LastIncRate2).dbFldName = "" '         incdate(applied = 0)   Rate(applied = 0)
        WCols(G1Col.LastIncRate2).FldCond = " and c.ID in (SELECT top 1 AccountID FROM " & ROUTESTblPath & "IncreaseRatesAcct WHERE applied = 1 AND incdate < (SELECT MAX(incdate) FROM " & ROUTESTblPath & "IncreaseRatesAcct WHERE applied = 1 ) And Rate = @FLDVAL order by IncDate desc)"
        WCols(G1Col.LastIncRate2).Type = GetType(System.Decimal)
        WCols(G1Col.LastIncRate2).Format = "##0.#0"
        WCols(G1Col.LastIncRate2).uMask = "###.##"
        WCols(G1Col.LastIncRate2).NoEdit = True
        WCols(G1Col.LastIncRate2).MaxLength = 7
        WCols(G1Col.LastIncRate2).Hide = False
        WCols(G1Col.LastIncRate2).Width = 45

        WCols(G1Col.LastIncDate1).Name = "IncHist1"
        WCols(G1Col.LastIncDate1).dbFldName = "" '         incdate(applied = 0)   Rate(applied = 0)
        WCols(G1Col.LastIncDate1).FldCond = " and c.ID in (SELECT top 1 AccountID FROM " & ROUTESTblPath & "IncreaseRatesAcct WHERE applied = 1 And incdate = @FLDVAL order by IncDate desc)"
        WCols(G1Col.LastIncDate1).Type = GetType(System.DateTime)
        WCols(G1Col.LastIncDate1).Format = "MM/dd/yy"
        WCols(G1Col.LastIncDate1).uMask = "mm/dd/yyyy"
        WCols(G1Col.LastIncDate1).NoEdit = True
        WCols(G1Col.LastIncDate1).Hide = False
        WCols(G1Col.LastIncDate1).Width = 55

        WCols(G1Col.LastIncRate1).Name = "IncR1%"
        WCols(G1Col.LastIncRate1).dbFldName = "" '         incdate(applied = 0)   Rate(applied = 0)
        WCols(G1Col.LastIncRate1).FldCond = " and c.ID in (SELECT top 1 AccountID FROM " & ROUTESTblPath & "IncreaseRatesAcct WHERE applied = 1 And Rate = @FLDVAL order by IncDate desc)"
        WCols(G1Col.LastIncRate1).Type = GetType(System.Decimal)
        WCols(G1Col.LastIncRate1).Format = "##0.#0"
        WCols(G1Col.LastIncRate1).uMask = "###.##"
        WCols(G1Col.LastIncRate1).NoEdit = True
        WCols(G1Col.LastIncRate1).MaxLength = 7
        WCols(G1Col.LastIncRate1).Hide = False
        WCols(G1Col.LastIncRate1).Width = 45

        WCols(G1Col.FuelSur).Name = "F.Sur.(%)"
        WCols(G1Col.FuelSur).dbFldName = "c.FuelSURCHARGE"
        WCols(G1Col.FuelSur).FldCond = " AND c.FuelSURCHARGE = @FLDVAL"
        WCols(G1Col.FuelSur).Type = GetType(System.Decimal)
        WCols(G1Col.FuelSur).Format = "##0.#0"
        WCols(G1Col.FuelSur).uMask = "###.##"
        WCols(G1Col.FuelSur).NoEdit = True
        WCols(G1Col.FuelSur).Hide = False
        WCols(G1Col.FuelSur).Width = 45

        WCols(G1Col.Disc).Name = "Disc(%)"
        WCols(G1Col.Disc).dbFldName = "c.DISCOUNTRATE"
        WCols(G1Col.Disc).FldCond = " AND c.DISCOUNTRATE = @FLDVAL"
        WCols(G1Col.Disc).Type = GetType(System.Decimal)
        WCols(G1Col.Disc).Format = "#0.#0"
        WCols(G1Col.Disc).uMask = "##.##"
        WCols(G1Col.Disc).NoEdit = True
        WCols(G1Col.Disc).Hide = False
        WCols(G1Col.Disc).MaxLength = 5
        WCols(G1Col.Disc).Width = 45

        WCols(G1Col.CurrCost).Name = "Chg($)"
        WCols(G1Col.CurrCost).dbFldName = ""
        WCols(G1Col.CurrCost).FldCond = " AND c.ID in (SELECT asvc.AccountID FROM " & ROUTESTblPath & "AccountServices asvc WHERE asvc.AccountID = c.ID AND asvc.Enddate is null group by asvc.AccountID having sum(asvc.Charge) = @FLDVAL)"
        WCols(G1Col.CurrCost).Type = GetType(System.Decimal)
        WCols(G1Col.CurrCost).Format = "####0.#0"
        WCols(G1Col.CurrCost).uMask = "#####.##"
        WCols(G1Col.CurrCost).NoEdit = True
        WCols(G1Col.CurrCost).Hide = False
        WCols(G1Col.CurrCost).MaxLength = 9
        WCols(G1Col.CurrCost).Width = 60

        WCols(G1Col.NIncDate).Name = "NIncDate"
        WCols(G1Col.NIncDate).dbFldName = ""
        WCols(G1Col.NIncDate).FldCond = " and c.ID in (SELECT AccountID FROM " & ROUTESTblPath & "IncreaseRatesAcct WHERE applied = 0 And incdate = @FLDVAL)"
        WCols(G1Col.NIncDate).Type = GetType(System.DateTime)
        WCols(G1Col.NIncDate).Format = "MM/dd/yy"
        WCols(G1Col.NIncDate).uMask = "mm/dd/yyyy"
        WCols(G1Col.NIncDate).NoEdit = False
        WCols(G1Col.NIncDate).Hide = False
        'WCols(G1Col.NIncDate).MaxLength = 9
        WCols(G1Col.NIncDate).Width = 55

        WCols(G1Col.NIncRate).Name = "NIncR%"
        WCols(G1Col.NIncRate).dbFldName = "" ' Rate(applied = 0)
        WCols(G1Col.NIncRate).FldCond = " and c.ID in (SELECT AccountID FROM " & ROUTESTblPath & "IncreaseRatesAcct WHERE applied = 0 And Rate = @FLDVAL)"
        WCols(G1Col.NIncRate).Type = GetType(System.Decimal)
        WCols(G1Col.NIncRate).Format = "##0.#0"
        WCols(G1Col.NIncRate).uMask = "###.##"
        WCols(G1Col.NIncRate).NoEdit = False
        WCols(G1Col.NIncRate).Hide = False
        WCols(G1Col.NIncRate).MaxLength = 7
        WCols(G1Col.NIncRate).Width = 50

        WCols(G1Col.NIncCost).Name = "NIncCost($)"
        WCols(G1Col.NIncCost).dbFldName = "" ' Next Cost
        WCols(G1Col.NIncCost).FldCond = " AND c.ID in (SELECT irax.AccountID  FROM " & ROUTESTblPath & "AccountServices asvc, IncreaseRatesAcct irax WHERE irax.applied = 0 AND  irax.AccountID = asvc.AccountID AND asvc.Enddate is null group by irax.AccountID having sum((1+irax.rate/100)*asvc.Charge) = @FLDVAL)"
        WCols(G1Col.NIncCost).Type = GetType(System.Decimal)
        WCols(G1Col.NIncCost).Format = "####0.#0"
        WCols(G1Col.NIncCost).uMask = "#####.##"
        WCols(G1Col.NIncCost).NoEdit = True
        WCols(G1Col.NIncCost).Hide = False
        WCols(G1Col.NIncCost).MaxLength = 9
        WCols(G1Col.NIncCost).Width = 70

        WCols(G1Col.Cmnt).Name = "N.Comment"
        WCols(G1Col.Cmnt).dbFldName = "" 'Comment(applied = 0)
        WCols(G1Col.Cmnt).FldCond = " and c.ID in (SELECT AccountID FROM " & ROUTESTblPath & "IncreaseRatesAcct WHERE applied = 0 And Comment like @FLDVAL)"
        WCols(G1Col.Cmnt).Type = GetType(System.String)
        WCols(G1Col.Cmnt).Format = ""
        WCols(G1Col.Cmnt).uMask = ""
        WCols(G1Col.Cmnt).NoEdit = False
        WCols(G1Col.Cmnt).Hide = False
        WCols(G1Col.Cmnt).MaxLength = 255
        WCols(G1Col.Cmnt).Width = 100

        StatusTable.Clear()
        StatusTable.Columns.Clear()

        For i = 0 To WCols.Length - 1
            StatusTable.Columns.Add(WCols(i).Name, WCols(i).Type)
        Next

        ' -- These functions are called separately --
        'SetSchedDSBlank(StatusTable)

    End Sub

    Private Sub SetSchedDSBlank(ByRef tbl As DataTable)
        Dim row As DataRow
        Dim col As DataColumn

        StatusTable.Clear()
        'StatusTable.Columns.Clear()

        'For Each col In tbl.Columns
        '    Select Case col.DataType.FullName
        '        Case "System.Int16", "System.Int32", "System.Int64"
        '            For Each row In tbl.Rows
        '                row(col.ToString) = 0
        '            Next row
        '        Case "System.String"
        '            For Each row In tbl.Rows
        '                row(col.ToString) = ""
        '            Next row
        '        Case "System.DateTime"
        '            For Each row In tbl.Rows
        '                row(col.ToString) = DBNull.Value
        '            Next row
        '        Case "System.Decimal", "System.Double"
        '            For Each row In tbl.Rows
        '                row(col.ToString) = 0.0
        '            Next row
        '        Case "System.Boolean"
        '            For Each row In tbl.Rows
        '                row(col.ToString) = False
        '            Next row
        '    End Select
        'Next col
    End Sub


    Private Function LoadGrid1()
        Dim CritTmp As String
        If cboFilter1.SelectedIndex > 0 Then
            'select case 
            'End Select
            If WCols(cboFilter1.SelectedIndex).FldCond <> "" Then
                CritTmp = WCols(cboFilter1.SelectedIndex).FldCond.Replace("@FLDVAL", "'" & umskF1.GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals) & "'")
            End If
        End If
        If cboFilter2.SelectedIndex > 0 Then
            'select case 
            'End Select
            If WCols(cboFilter2.SelectedIndex).FldCond <> "" Then
                CritTmp = CritTmp & " " & WCols(cboFilter2.SelectedIndex).FldCond.Replace("@FLDVAL", "'" & umskF2.GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals) & "'")
            End If
        End If
        If cboFilter3.SelectedIndex > 0 Then
            'select case 
            'End Select
            If WCols(cboFilter3.SelectedIndex).FldCond <> "" Then
                CritTmp = CritTmp & " " & WCols(cboFilter3.SelectedIndex).FldCond.Replace("@FLDVAL", "'" & umskF3.GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals) & "'")
            End If
        End If

        CritTmp = sqlIncreaseAcc.Replace("@CondMain", CritTmp)
        FillDataSet(CritTmp) 'PrepSelectQuery(sqlSched, CritTmp)
        'CalcDailyAvg()

    End Function

    Private Function FillDataSet(ByVal sqlSched As String)
        Dim dtAdapter As SqlDataAdapter
        Dim dsSched As New DataSet()
        Dim dsTmp As DataSet
        Dim row, rowtmp As DataRow
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim i As Integer

        PopulateDataset2(dtAdapter, dsSched, sqlSched)

        UltraGrid1.DataSource = Nothing

        SetSchedDSBlank(StatusTable)

        If dsSched.Tables(0).Rows.Count > 0 Then
            For Each row In dsSched.Tables(0).Rows
                rowtmp = StatusTable.NewRow
                For i = 0 To WCols.Length - 1
                    rowtmp.Item(i) = row(i)
                Next
                StatusTable.Rows.Add(rowtmp)
            Next
        End If
        If StatusTable.DataSet Is Nothing Then
            dsTmp = New DataSet()
            dsTmp.Tables.Add(StatusTable)
        Else
            dsTmp = StatusTable.DataSet
        End If

        'Dim RaiseHist As String = "SELECT TOP 3 AccountID, incdate, Rate, Comment  FROM IncreaseRatesAcct WHERE applied = 1 " 'AND incdate < (SELECT MAX(incdate) FROM IncreaseRatesAcct WHERE applied = 1 AND AccountID = 1000) ORDER BY incdate DESC"
        'Dim dr As DataRelation
        'PopulateDataset2(dtAdapter, dsTmp, RaiseHist, True)
        'dr = New DataRelation("RaiseHistory", dsTmp.Tables(0).Columns("AcctID"), dsTmp.Tables(1).Columns("AccountID"), False)
        'dsTmp.Relations.Add(dr)

        FillGrid1(dsTmp)
        UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInBand, True, True)

        UltraGrid1.Update()
        UltraGrid1.UpdateData()

    End Function

    Private Function FillGrid1(ByRef dsTmp As DataSet) 'DataTable
        Dim i As Integer
        Dim ugcol As Infragistics.Win.UltraWinGrid.UltraGridColumn

        UltraGrid1.DataSource = Nothing

        'UltraGrid1.DataSource = dsTmp
        'Exit Function

        FillUltraGrid(UltraGrid1, dsTmp, 1)
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
                    GoTo Nexti
                End If
            Next ugcol
Nexti:
        Next i

        UltraGrid1.DisplayLayout.GroupByBox.Hidden = False
        UltraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy

        ''UltraGrid1.DisplayLayout.Bands(0).Columns(0).Format = "MM/dd/yy-ddd"
        'UltraGrid1.DisplayLayout.Bands(0).Columns(0).MaskInput = "mm/dd/yy"
        'UltraGrid1.DisplayLayout.Bands(0).Columns(0).MaskDataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth

        ''UltraGrid1.DisplayLayout.Bands(0).Columns("STm").Format = "HH :mm"
        'UltraGrid1.DisplayLayout.Bands(0).Columns("STm").MaskInput = "hh:mm"
        'UltraGrid1.DisplayLayout.Bands(0).Columns("STm").MaskDataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
        'UltraGrid1.DisplayLayout.Bands(0).Columns("STm").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit
        'UltraGrid1.DisplayLayout.Bands(0).Columns("STm").NullText = "    "

        ''UltraGrid1.DisplayLayout.Bands(0).Columns("CTm").Format = "HH :mm"
        'UltraGrid1.DisplayLayout.Bands(0).Columns("CTm").MaskInput = "hh:mm"
        'UltraGrid1.DisplayLayout.Bands(0).Columns("CTm").MaskDataMode = Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeBoth
        'UltraGrid1.DisplayLayout.Bands(0).Columns("CTm").Style = Infragistics.Win.UltraWinGrid.ColumnStyle.Edit
        'UltraGrid1.DisplayLayout.Bands(0).Columns("CTm").NullText = "    "

        UltraGrid1.Update()
        UltraGrid1.UpdateData()

        'dsTmp = Nothing
    End Function

    Private Sub UltraGrid1_BeforeEnterEditMode(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles UltraGrid1.BeforeEnterEditMode
        Dim i As Integer
        For i = 0 To WCols.Length - 1
            If WCols(i).NoEdit = True Then
                If UltraGrid1.ActiveCell.Column.ToString = WCols(i).Name Then   'Or UltraGrid1.ActiveCell.Column.ToString = "Charge"
                    e.Cancel = True
                    Exit Sub
                End If
            End If
        Next
        e.Cancel = False
    End Sub
    Private Sub UltraGrid1_BeforeCellUpdate(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventArgs) Handles UltraGrid1.BeforeCellUpdate
        'Dim i As Integer
        'For i = 0 To WCols.Length - 1
        '    If WCols(i).NoEdit = True Then
        '        If UltraGrid1.ActiveCell.Column.ToString = WCols(i).Name Then   'Or UltraGrid1.ActiveCell.Column.ToString = "Charge"
        '            e.Cancel = True
        '            Exit Sub
        '        End If
        '    End If
        'Next
        'e.Cancel = False
    End Sub


    Private Sub IncreaseAccounts_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not cmdTrans Is Nothing Then
            e.Cancel = False
        End If
    End Sub

    Private Sub cboFilter1_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cboFilter1.SelectedIndexChanged, cboFilter2.SelectedIndexChanged, cboFilter3.SelectedIndexChanged
        Dim gCbo As ComboBox
        Dim gumsk As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit

        Select Case sender.name
            Case "cboFilter1"
                gCbo = cboFilter1
                gumsk = umskF1
            Case "cboFilter2"
                gCbo = cboFilter2
                gumsk = umskF2
            Case "cboFilter3"
                gCbo = cboFilter3
                gumsk = umskF3
        End Select

        Select Case gCbo.SelectedIndex
            Case 0 'No Selection
                tbF1.Text = ""
                gumsk.Text = ""
                gumsk.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.AutoSense
                gumsk.InputMask = ""
            Case G1Col.CrDate, G1Col.NIncDate
                tbF1.Text = ""
                tbF1.MaxLength = WCols(gCbo.SelectedIndex).MaxLength
                gumsk.Text = ""
                gumsk.InputMask = WCols(gCbo.SelectedIndex).uMask '"mm/dd/yy"
                gumsk.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Date
            Case G1Col.CurrCost, G1Col.Disc, G1Col.FuelSur, G1Col.NIncCost, G1Col.NIncRate
                tbF1.Text = ""
                tbF1.MaxLength = WCols(gCbo.SelectedIndex).MaxLength
                gumsk.Text = ""
                gumsk.InputMask = WCols(gCbo.SelectedIndex).uMask '"mm/dd/yy"
                gumsk.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Double
            Case G1Col.AID
                tbF1.Text = ""
                tbF1.MaxLength = WCols(gCbo.SelectedIndex).MaxLength
                gumsk.Text = ""
                gumsk.InputMask = "" 'WCols(cboFilter1.SelectedIndex).uMask
                gumsk.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Integer
            Case Else
                tbF1.Text = ""
                tbF1.MaxLength = WCols(gCbo.SelectedIndex).MaxLength
                umskF1.Text = ""
                umskF1.InputMask = WCols(gCbo.SelectedIndex).uMask '"mm/dd/yy"
                umskF1.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.String
        End Select
    End Sub

    Private Sub btnSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectAll.Click
        Dim ugrow As Infragistics.Win.UltraWinGrid.UltraGridRow

        ugrow = UltraGrid1.ActiveRow
        If ugrow Is Nothing Then
            MsgBox("Please select a record to mark records at the same level.")
            Exit Sub
        End If
        If ugrow.Cells Is Nothing Then
            If ugrow.IsExpandable = True And ugrow.HasChild = True Then
                ugrow = ugrow.GetChild(Infragistics.Win.UltraWinGrid.ChildRow.First)
            Else
                Exit Sub
            End If
        Else
            ugrow = ugrow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.First)
        End If
        MarkRecords(ugrow, True)

    End Sub

    Private Sub MarkRecords(ByRef ugrow As Infragistics.Win.UltraWinGrid.UltraGridRow, ByVal Mark As Boolean)
        While Not ugrow Is Nothing
            If ugrow.Cells Is Nothing Then
                If ugrow.IsExpandable = True And ugrow.HasChild = True Then
                    'ugrow = ugrow.GetChild(Infragistics.Win.UltraWinGrid.ChildRow.First)
                    MarkRecords(ugrow.GetChild(Infragistics.Win.UltraWinGrid.ChildRow.First), Mark)
                Else
                    Exit Sub
                End If
            Else
                ugrow.Cells(0).Value = Mark
                ugrow.Update()
            End If

            ugrow = ugrow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next)
        End While
    End Sub

    Private Sub btnUnselelct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnUnselelct.Click
        Dim ugrow As Infragistics.Win.UltraWinGrid.UltraGridRow

        ugrow = UltraGrid1.ActiveRow
        If ugrow Is Nothing Then
            MsgBox("Please select a record to mark records at the same level.")
            Exit Sub
        End If
        If ugrow.Cells Is Nothing Then
            If ugrow.IsExpandable = True And ugrow.HasChild = True Then
                ugrow = ugrow.GetChild(Infragistics.Win.UltraWinGrid.ChildRow.First)
            Else
                Exit Sub
            End If
        Else
            ugrow = ugrow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.First)
        End If
        MarkRecords(ugrow, False)
    End Sub

    Private Sub umskF1_MaskValidationError(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinMaskedEdit.MaskValidationErrorEventArgs) Handles umskF1.MaskValidationError
        Dim NextCtrl As System.Windows.Forms.Control
        Dim Str As String
        Dim gCbo As ComboBox
        Select Case sender.name
            Case "umskF1"
                gCbo = cboFilter1
            Case "umskF2"
                gCbo = cboFilter2
            Case "umskF3"
                gCbo = cboFilter3
        End Select
        Str = sender.GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw)
        If Str = "" Then
            e.RetainFocus = False
        End If

        Select Case gCbo.SelectedIndex
            Case G1Col.ChkBx
                e.RetainFocus = False
            Case G1Col.AID
                If IsNumeric(Str) Then
                    e.RetainFocus = False
                End If
            Case G1Col.CurrCost, G1Col.Disc, G1Col.FuelSur, G1Col.NIncCost, G1Col.NIncRate, G1Col.LastIncRate1, G1Col.LastIncRate2, G1Col.LastIncRate3
                If IsNumeric(Str) Then
                    e.RetainFocus = False
                End If
            Case G1Col.CrDate, G1Col.NIncDate, G1Col.LastIncDate1, G1Col.LastIncDate2, G1Col.LastIncDate3
        End Select
        'If sender.name = "umskOpenTime" Or sender.name = "umskCloseTime" Then
        '    Str = sender.GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw)
        '    Str = Str.PadLeft(2, "0").PadRight(4, "0")
        '    If Val(Str) / 100 < 24 And Val(Str) Mod 100 < 60 Then
        '        e.RetainFocus = False
        '        sender.Value = Str
        '    End If
        'End If

    End Sub

    Private Sub umskF1_Validating(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles umskF1.Validating, umskF2.Validating, umskF3.Validating
        Dim DateText As String = sender.GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals)
        Dim YearSec, DaySec, MoSec, DateTextRaw As String
        Dim YearVal, MoVal, DayVal As Int32
        Dim StrArr() As String
        Dim gCbo As ComboBox
        Select Case sender.name
            Case "umskF1"
                gCbo = cboFilter1
            Case "umskF2"
                gCbo = cboFilter2
            Case "umskF3"
                gCbo = cboFilter3
        End Select

        Select Case gCbo.SelectedIndex
            Case G1Col.CrDate, G1Col.NIncDate, G1Col.LastIncDate1, G1Col.LastIncDate2, G1Col.LastIncDate3
                DateTextRaw = sender.GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw)
                YearSec = DateText.Substring(DateText.LastIndexOf("/") + 1)
                StrArr = GetCtrldbFieldInfo(sender)
                If StrArr.Length >= (TagOpts.DefaultVal + 1) Then
                    If DateTextRaw.Trim = "" And StrArr(TagOpts.DefaultVal).ToUpper = "NOW" Then
                        sender.Text = Format(Now(), "MM/dd/yyyy")
                        Exit Sub
                    End If
                End If

                If YearSec.Trim = "" Then
                    YearVal = Year(Now)
                ElseIf Val(YearSec) < 70 Then
                    YearVal = 2000 + Val(YearSec)
                    sender.text = DateText.Substring(0, DateText.LastIndexOf("/") + 1) & YearVal
                ElseIf Val(YearSec) >= 70 And Val(YearSec) < 100 Then
                    YearVal = 1900 + Val(YearSec)
                    sender.Text = DateText.Substring(0, DateText.LastIndexOf("/") + 1) & YearVal
                ElseIf Val(YearSec) >= 100 And Val(YearSec) < 1000 Then
                    MsgBox("Invalid Year!")
                    e.Cancel = True
                End If
            Case G1Col.CurrCost, G1Col.Disc, G1Col.FuelSur, G1Col.NIncCost, G1Col.NIncRate, G1Col.LastIncRate1, G1Col.LastIncRate2, G1Col.LastIncRate3
                sender.value = Format(Val(DateText), WCols(gCbo.SelectedIndex).Format)
                'e.Cancel = False
            Case Else
                e.Cancel = False
        End Select
    End Sub

    Private Sub btnIncrease_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIncrease.Click
        Dim x As New IncreaseRate()
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim RaiseVal As Decimal
        Dim RaiseDate As Date

        UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid, False, False)

        x.rbAmnt.Enabled = False
        x.ShowDialog()
        If x.DialogResult = DialogResult.OK Then
            ' Raise Selected Accounts
            RaiseVal = x.TextBox1.Text()
            RaiseDate = x.DTPicker1.Value

            If x.rbRate.Checked Then
                RaiseRate(RaiseVal, RaiseDate)
            Else
                'RaiseAmount(RaiseVal, RaiseDate)
            End If
        End If
        x = Nothing
    End Sub

    Private Sub RaiseRate(ByVal Val As Decimal, ByVal IncDate As Date)
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow

        UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid, False, False)

        For Each ugRow In UltraGrid1.Rows
            RaiseRecords(ugRow, Val, IncDate)
        Next
    End Sub

    Private Sub RaiseRecords(ByRef ugrow As Infragistics.Win.UltraWinGrid.UltraGridRow, ByVal Val As Decimal, ByVal IncDate As Date, Optional ByVal Rate As Boolean = True)
        While Not ugrow Is Nothing
            If ugrow.Cells Is Nothing Then
                If ugrow.IsExpandable = True And ugrow.HasChild = True Then
                    'ugrow = ugrow.GetChild(Infragistics.Win.UltraWinGrid.ChildRow.First)
                    RaiseRecords(ugrow.GetChild(Infragistics.Win.UltraWinGrid.ChildRow.First), Val, IncDate, Rate)
                Else
                    Exit Sub
                End If
            Else
                If ugrow.Cells(0).Value Then
                    If Rate Then
                        ugrow.Cells("N.Inc.Cost($)").Value = ugrow.Cells("Chg($)").Value * (1 + Val / 100)
                        ugrow.Cells("N.Inc.Rate(%)").Value = Val
                    Else
                        ugrow.Cells("N.Inc.Cost($)").Value = ugrow.Cells("Chg($)").Value + Val
                        ugrow.Cells("N.Inc.Rate(%)").Value = Val / ugrow.Cells("Chg($)").Value * 100
                    End If
                    ugrow.Cells("N.Inc.Date").Value = IncDate
                End If
                ugrow.Update()
            End If

            ugrow = ugrow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next)
        End While
    End Sub

    Private Sub RaiseAmount(ByVal Val As Decimal, ByVal IncDate As Date)
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow

        UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid, False, False)

        For Each ugRow In UltraGrid1.Rows
            RaiseRecords(ugRow, Val, IncDate, False)
        Next
    End Sub

    Private Function SaveAcctInc(ByRef ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow) As Boolean
        Dim DelQry As String
        Dim cmdSQLTrans As SqlCommand = Nothing
        Dim i As Integer

        SaveAcctInc = False
        On Error GoTo ErrTrap
        DelQry = "Delete FROM " & ROUTESTblPath & "IncreaseRatesAcct Where AccountID = @AcctID and Applied = 0 "

        'cmdSQLTrans = InitiateEdit(Me, "Select * FROM " & ROUTESTblPath & "IncreaseRatesAcct ")

        While Not ugRow Is Nothing
            If ugRow.Cells Is Nothing Then
                If ugRow.IsExpandable = True And ugRow.HasChild = True Then
                    SaveAcctInc(ugRow.GetChild(Infragistics.Win.UltraWinGrid.ChildRow.First))
                Else
                    Exit Function
                End If
            Else
                If ugRow.Cells(G1Col.ChkBx).Value Then
                    If ExecuteQuery(DelQry.Replace("@AcctID", ugRow.Cells(G1Col.AID).Text)) Then
                        'AcctIDList = "("
                        If ExecuteQuery("Insert Into " & ROUTESTblPath & "IncreaseRatesAcct(IncDate, AccountID, Rate, Applied, Comment) " & _
                                    " values('" & ugRow.Cells(G1Col.NIncDate).Text & "', " & ugRow.Cells(G1Col.AID).Text & _
                                    ", " & ugRow.Cells(G1Col.NIncRate).Text & ", 0, '" & ugRow.Cells(G1Col.Cmnt).Text & "')") _
                                    = False Then
                            GoTo ErrTrap
                        Else
                            SaveServiceInc(ugRow, cmdSQLTrans)
                        End If
                    Else
                        'Me.Text = MeText & " - Data NOT Saved!"
                        GoTo ErrTrap
                    End If
                    '===============================================
                    'Save Changes to Services in IncreasesServices
                    'Note that Account increase if amount, what would be the addition to each serviceID? so 
                    'Increase of Accounts should be in Rates and can not even change the cost manually!! 
                    'Just Date and Rate and Comment
                    'How about changing the Increase Date of a single SID in its screen?
                    '===============================================
                End If
            End If
            ugRow = ugRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next)
        End While

        'cmdSQLTrans.Transaction.Commit()
        'cmdSQLTrans.Transaction = Nothing
        'cmdSQLTrans.Connection.Close()
        'cmdSQLTrans.Connection = Nothing
        'cmdSQLTrans = Nothing
        SaveAcctInc = True
        Exit Function
ErrTrap:
        MsgBox("Error in SaveSched : " & Err.Description)
        'cmdSQLTrans.Transaction.Rollback()
        'cmdSQLTrans.Transaction = Nothing
        'cmdSQLTrans.Connection.Close()
        'cmdSQLTrans.Connection = Nothing
        'cmdSQLTrans = Nothing
    End Function

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow

        UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid, False, False)
        Me.Cursor = Cursors.WaitCursor

        For Each ugRow In UltraGrid1.Rows
            SaveAcctInc(ugRow)
            'Save ServiceInc : Add if not exist
        Next
        Me.Cursor = Cursors.Arrow
        'Me.Text = MeText & " - Data Saved..."
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        UltraGrid1.PrintPreview()
    End Sub

    Private Sub UltraGrid1_AfterCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles UltraGrid1.AfterCellUpdate
        Dim ugcell As Infragistics.Win.UltraWinGrid.UltraGridCell
        Dim ugrow As Infragistics.Win.UltraWinGrid.UltraGridRow

        ugcell = UltraGrid1.ActiveCell
        If ugcell.Column.ToString = WCols(G1Col.NIncRate).Name Then
            ugrow = ugcell.Row
            ugrow.Cells(G1Col.NIncCost).Value = ugrow.Cells(G1Col.CurrCost).Value * (1 + ugcell.Value / 100)
        Else
            'Select Case ugcell.Value.GetType.ToString
            '    Case "System.Byte", "System.Integer", "System.Int16", "System.Int32", "System.Int64", "System.Decimal"
            '        If ugcell.Text = "" Then
            '            ugcell.Value = 0
            '        End If
            'End Select
        End If

    End Sub


    Private Sub Ultragrid1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles UltraGrid1.MouseDown

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

    Private Function SaveServiceInc(ByRef ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow, Optional ByVal cmdSQLTrans As SqlCommand = Nothing) As Boolean
        Dim DelQry, InsQry As String
        Dim i As Integer

        SaveServiceInc = False
        On Error GoTo ErrTrap

        DelQry = "Delete FROM " & ROUTESTblPath & "IncreasesService Where AccountID = @AcctID AND Applied = 0  "

        DelQry = DelQry.Replace("@AcctID", ugRow.Cells(WCols(G1Col.AID).Name).Value)

        If ExecuteQuery(DelQry) Then
            'AcctIDList = "("
            'If ExecuteQuery("Insert Into IncreasesService(IncDate, AccountID, SID, FinalAmount, Applied, Comment) " & _
            '            " values('" & ugRow.Cells(WCols(G1Col.NIncDate).Name).Value & "', " & ugRow.Cells(WCols(G1Col.AID).Name).Value & _
            '            ", " & ugRow.Cells(G1Col.SID).Text & ", " & ugRow.Cells(G1Col.NIncCost).Text & ", 0, '" & ugRow.Cells(G1Col.Cmnt).Text & "')") _
            '            = False Then
            '    GoTo ErrTrap
            'End If
            InsQry = "Insert Into " & ROUTESTblPath & "IncreasesService(IncDate, AccountID, SID, FinalAmount, Applied, Comment) " & _
                        " Select ira.IncDate, ira.AccountID, asvc.ID, ((ira.Rate/100)+1)*asvc.charge , 0, '' " & _
                        " From " & ROUTESTblPath & "IncreaseRatesAcct ira, " & ROUTESTblPath & "AccountServices asvc where " & _
                        " ira.AccountID = asvc.AccountID and ira.applied = 0 and " & _
                        " ira.AccountID = " & ugRow.Cells(WCols(G1Col.AID).Name).Value

            If ExecuteQuery(InsQry, cmdSQLTrans) _
                        = False Then
                GoTo ErrTrap
            End If
        Else
            'Me.Text = MeText & " - Data NOT Saved!"
            GoTo ErrTrap
        End If
        '===============================================
        'Save Changes to Services in IncreasesServices
        'Note that Account increase if amount, what would be the addition to each serviceID? so 
        'Increase of Accounts should be in Rates and can not even change the cost manually!! 
        'Just Date and Rate and Comment
        'How about changing the Increase Date of a single SID in its screen?
        '===============================================

        SaveServiceInc = True
        Exit Function
ErrTrap:
        MsgBox("Error in SaveServiceInc : " & Err.Description)
    End Function

End Class
