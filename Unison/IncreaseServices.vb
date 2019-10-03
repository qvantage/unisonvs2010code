Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors

Public Class IncreaseServices
    Inherits System.Windows.Forms.Form
    Dim sqlIncreaseAcc As String = " Select convert(Bit, 0) as ChkBx, asvc.ID as SID, asvc.CompName as Location" & _
                              " , asvc.CityName, asvc.State, asvc.Charge" & _
                              " , isnull((select top 1 FinalAmount FROM " & ROUTESTblPath & "IncreasesService where applied = 0 AND AccountID = @AcctID AND SID = asvc.ID order by incdate asc), asvc.Charge)  as [NCost]  " & _
                              " , isnull((select top 1 Comment FROM " & ROUTESTblPath & "IncreasesService where applied = 0 AND AccountID = @AcctID  AND SID = asvc.ID order by incdate asc), '') as Comment" & _
                              " FROM " & ROUTESTblPath & "AccountServices asvc " & _
                              " where asvc.AccountID = @AcctID " & _
                              " Order By asvc.ID"

    '" , (select top 1 incdate from IncreasesService where applied = 0 AND AccountID = @AcctID and SID = asvc.ID order by incdate asc) as [Next Inc. Date]  " & _
    Dim SQLSelect As String = _
            " Select c.ID, C.Name, Contact, Street, CityName, State, Zipcode, Phone1, Phone2" & _
            " , Fax, email, Web, Status, AcctGroupID, SubjHoliday, isnull(convert(varchar, CreateDate, 101), '') as CreateDate" & _
            " , bName, bContact, bStreet, bCityName, bState, bZipcode, bPhone1, bPhone2, bFax, bEmail, SamePayAddress" & _
            " , BCycleCode, LastBillDate, CreditLimit, DiscountRate, TaxRate, FuelSurcharge, IncreaseDate, IncreaseRate" & _
            " , FinanceCharge " & _
            " , (select top 1 incdate FROM " & ROUTESTblPath & "IncreaseRatesAcct where applied = 1 AND AccountID = c.ID order by incdate desc) as [LastIncDate1] " & _
            " , isnull((select top 1 rate FROM " & ROUTESTblPath & "IncreaseRatesAcct where applied = 1 AND AccountID = c.ID order by incdate desc), 0) as [LastIncRate1] " & _
            " , (SELECT isnull(sum(asvc.Charge), 0.00) FROM " & ROUTESTblPath & "AccountServices asvc WHERE asvc.AccountID = c.ID AND asvc.Enddate is null ) as TotChg " & _
            " , (select top 1 incdate FROM " & ROUTESTblPath & "IncreaseRatesAcct where applied = 0 AND AccountID = c.ID order by incdate asc) as [NIncDate]  " & _
            " , isnull((select top 1 rate FROM " & ROUTESTblPath & "IncreaseRatesAcct where applied = 0 AND AccountID = c.ID order by incdate asc), 0) as [NIncRate]  " & _
            " , (SELECT isnull(sum((1+irax.rate/100)*asvc.Charge), 0.00) FROM " & ROUTESTblPath & "AccountServices asvc," & ROUTESTblPath & " IncreaseRatesAcct irax WHERE irax.applied = 0 AND irax.AccountID = c.ID AND irax.AccountID = asvc.AccountID AND asvc.Enddate is null ) as [NCost] " & _
            " , isnull((select top 1 Comment FROM " & ROUTESTblPath & "IncreaseRatesAcct where applied = 0 AND AccountID = c.ID order by incdate asc), '') as NComment" & _
            " FROM " & AppTblPath & "Customer c"
    '" , isnull(ag.Name, '') as AcctGroup    , AccountGroups ag Where Customer.AcctGroupID *= ag.ID"

    Dim Criteria As String = " Where C.ID = @CID "


    Dim MeText As String
    Dim dtSet As New DataSet()
    Dim m_oColumn As Infragistics.Win.UltraWinGrid.UltraGridColumn = Nothing
    Dim cmdTrans As SqlCommand

    Private Enum G1Col
        ChkBx
        SID
        LName
        City
        State
        CurrCost
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

    Dim GOrgCellVal As Decimal

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
    Friend WithEvents btnUnselelct As System.Windows.Forms.Button
    Friend WithEvents btnIncrease As System.Windows.Forms.Button
    Friend WithEvents btnSelectAll As System.Windows.Forms.Button
    Friend WithEvents btnLoad As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnPrev As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents btnAcct As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents AccountID As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents AcctName As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents umskIncreaseDate As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents IncreaseRate As System.Windows.Forms.TextBox
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BCycle As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TextBox3 As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents TextBox5 As System.Windows.Forms.TextBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents TextBox4 As System.Windows.Forms.TextBox
    Friend WithEvents TextBox6 As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents TextBox7 As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents CntMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents umskNIncreaseDate As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(IncreaseServices))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.TextBox7 = New System.Windows.Forms.TextBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.TextBox4 = New System.Windows.Forms.TextBox()
        Me.TextBox6 = New System.Windows.Forms.TextBox()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.umskNIncreaseDate = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.IncreaseRate = New System.Windows.Forms.TextBox()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.umskIncreaseDate = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.BCycle = New System.Windows.Forms.TextBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.AcctName = New System.Windows.Forms.TextBox()
        Me.btnPrev = New System.Windows.Forms.Button()
        Me.btnNext = New System.Windows.Forms.Button()
        Me.btnAcct = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.AccountID = New System.Windows.Forms.TextBox()
        Me.btnUnselelct = New System.Windows.Forms.Button()
        Me.btnIncrease = New System.Windows.Forms.Button()
        Me.btnSelectAll = New System.Windows.Forms.Button()
        Me.btnLoad = New System.Windows.Forms.Button()
        Me.TextBox3 = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.TextBox5 = New System.Windows.Forms.TextBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnPrint = New System.Windows.Forms.Button()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid()
        Me.CntMenu1 = New System.Windows.Forms.ContextMenu()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.Label9, Me.TextBox7, Me.GroupBox3, Me.BCycle, Me.Label3, Me.Label13, Me.TextBox2, Me.Label2, Me.AcctName, Me.btnPrev, Me.btnNext, Me.btnAcct, Me.Label1, Me.AccountID, Me.btnUnselelct, Me.btnIncrease, Me.btnSelectAll, Me.btnLoad, Me.TextBox3, Me.Label7, Me.TextBox5, Me.Label8})
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(832, 144)
        Me.GroupBox1.TabIndex = 3
        Me.GroupBox1.TabStop = False
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(184, 52)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 24)
        Me.Label9.TabIndex = 187
        Me.Label9.Text = "Next Inc. Remarks :"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBox7
        '
        Me.TextBox7.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox7.Enabled = False
        Me.TextBox7.Location = New System.Drawing.Point(264, 48)
        Me.TextBox7.Multiline = True
        Me.TextBox7.Name = "TextBox7"
        Me.TextBox7.Size = New System.Drawing.Size(312, 56)
        Me.TextBox7.TabIndex = 186
        Me.TextBox7.Tag = ".NComment.View"
        Me.TextBox7.Text = ""
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.AddRange(New System.Windows.Forms.Control() {Me.TextBox4, Me.TextBox6, Me.Label6, Me.TextBox1, Me.Label4, Me.umskNIncreaseDate, Me.Label5, Me.IncreaseRate, Me.Label34, Me.umskIncreaseDate, Me.Label33})
        Me.GroupBox3.Location = New System.Drawing.Point(584, 8)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(240, 104)
        Me.GroupBox3.TabIndex = 185
        Me.GroupBox3.TabStop = False
        '
        'TextBox4
        '
        Me.TextBox4.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox4.Enabled = False
        Me.TextBox4.Location = New System.Drawing.Point(160, 77)
        Me.TextBox4.Name = "TextBox4"
        Me.TextBox4.Size = New System.Drawing.Size(72, 20)
        Me.TextBox4.TabIndex = 189
        Me.TextBox4.Tag = ".NCost.View"
        Me.TextBox4.Text = ""
        '
        'TextBox6
        '
        Me.TextBox6.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox6.Enabled = False
        Me.TextBox6.Location = New System.Drawing.Point(77, 77)
        Me.TextBox6.Name = "TextBox6"
        Me.TextBox6.Size = New System.Drawing.Size(72, 20)
        Me.TextBox6.TabIndex = 187
        Me.TextBox6.Tag = ".TotChg.View"
        Me.TextBox6.Text = ""
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(8, 79)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(71, 16)
        Me.Label6.TabIndex = 188
        Me.Label6.Text = "Total Chg.($)"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBox1
        '
        Me.TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox1.Enabled = False
        Me.TextBox1.Location = New System.Drawing.Point(160, 30)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(72, 20)
        Me.TextBox1.TabIndex = 183
        Me.TextBox1.Tag = ".NINCRATE.View"
        Me.TextBox1.Text = ""
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(179, 12)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 16)
        Me.Label4.TabIndex = 186
        Me.Label4.Text = "Next"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'umskNIncreaseDate
        '
        Me.umskNIncreaseDate.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Date
        Me.umskNIncreaseDate.InputMask = "mm/dd/yyyy"
        Me.umskNIncreaseDate.Location = New System.Drawing.Point(160, 54)
        Me.umskNIncreaseDate.Name = "umskNIncreaseDate"
        Me.umskNIncreaseDate.Nullable = True
        Me.umskNIncreaseDate.ReadOnly = True
        Me.umskNIncreaseDate.Size = New System.Drawing.Size(72, 20)
        Me.umskNIncreaseDate.TabIndex = 184
        Me.umskNIncreaseDate.Tag = ".NINCDATE.View"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(96, 12)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 16)
        Me.Label5.TabIndex = 185
        Me.Label5.Text = "Last"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'IncreaseRate
        '
        Me.IncreaseRate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.IncreaseRate.Enabled = False
        Me.IncreaseRate.Location = New System.Drawing.Point(77, 30)
        Me.IncreaseRate.Name = "IncreaseRate"
        Me.IncreaseRate.Size = New System.Drawing.Size(72, 20)
        Me.IncreaseRate.TabIndex = 176
        Me.IncreaseRate.Tag = ".LastINCRate1.View"
        Me.IncreaseRate.Text = ""
        '
        'Label34
        '
        Me.Label34.Location = New System.Drawing.Point(13, 56)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(56, 16)
        Me.Label34.TabIndex = 182
        Me.Label34.Text = "Inc. Date:"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'umskIncreaseDate
        '
        Me.umskIncreaseDate.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Date
        Me.umskIncreaseDate.InputMask = "mm/dd/yyyy"
        Me.umskIncreaseDate.Location = New System.Drawing.Point(77, 54)
        Me.umskIncreaseDate.Name = "umskIncreaseDate"
        Me.umskIncreaseDate.Nullable = True
        Me.umskIncreaseDate.ReadOnly = True
        Me.umskIncreaseDate.Size = New System.Drawing.Size(72, 20)
        Me.umskIncreaseDate.TabIndex = 177
        Me.umskIncreaseDate.Tag = ".LastIncDATE1.View"
        '
        'Label33
        '
        Me.Label33.Location = New System.Drawing.Point(13, 30)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(64, 16)
        Me.Label33.TabIndex = 181
        Me.Label33.Text = "Avg. Inc.% :"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BCycle
        '
        Me.BCycle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.BCycle.Enabled = False
        Me.BCycle.Location = New System.Drawing.Point(104, 117)
        Me.BCycle.Name = "BCycle"
        Me.BCycle.Size = New System.Drawing.Size(24, 20)
        Me.BCycle.TabIndex = 184
        Me.BCycle.Tag = ".BCycleCode.View"
        Me.BCycle.Text = ""
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(32, 117)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 183
        Me.Label3.Text = "Billing Cycle:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(32, 93)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(68, 16)
        Me.Label13.TabIndex = 131
        Me.Label13.Text = "Create Date:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBox2
        '
        Me.TextBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox2.Enabled = False
        Me.TextBox2.Location = New System.Drawing.Point(104, 93)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(72, 20)
        Me.TextBox2.TabIndex = 130
        Me.TextBox2.Tag = ".CreateDate.view"
        Me.TextBox2.Text = ""
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(121, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 16)
        Me.Label2.TabIndex = 126
        Me.Label2.Text = "Account :"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'AcctName
        '
        Me.AcctName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.AcctName.Location = New System.Drawing.Point(181, 16)
        Me.AcctName.Name = "AcctName"
        Me.AcctName.Size = New System.Drawing.Size(224, 20)
        Me.AcctName.TabIndex = 125
        Me.AcctName.Tag = ".name"
        Me.AcctName.Text = ""
        '
        'btnPrev
        '
        Me.btnPrev.Image = CType(resources.GetObject("btnPrev.Image"), System.Drawing.Bitmap)
        Me.btnPrev.Location = New System.Drawing.Point(521, 16)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(24, 21)
        Me.btnPrev.TabIndex = 12
        '
        'btnNext
        '
        Me.btnNext.Image = CType(resources.GetObject("btnNext.Image"), System.Drawing.Bitmap)
        Me.btnNext.Location = New System.Drawing.Point(545, 16)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(24, 21)
        Me.btnNext.TabIndex = 14
        '
        'btnAcct
        '
        Me.btnAcct.Location = New System.Drawing.Point(433, 16)
        Me.btnAcct.Name = "btnAcct"
        Me.btnAcct.Size = New System.Drawing.Size(75, 21)
        Me.btnAcct.TabIndex = 15
        Me.btnAcct.Text = "Select"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 16)
        Me.Label1.TabIndex = 13
        Me.Label1.Text = "ID:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'AccountID
        '
        Me.AccountID.Location = New System.Drawing.Point(48, 16)
        Me.AccountID.Name = "AccountID"
        Me.AccountID.Size = New System.Drawing.Size(56, 20)
        Me.AccountID.TabIndex = 11
        Me.AccountID.Tag = ".id"
        Me.AccountID.Text = ""
        '
        'btnUnselelct
        '
        Me.btnUnselelct.Location = New System.Drawing.Point(720, 115)
        Me.btnUnselelct.Name = "btnUnselelct"
        Me.btnUnselelct.Size = New System.Drawing.Size(104, 21)
        Me.btnUnselelct.TabIndex = 9
        Me.btnUnselelct.Text = "&UnSelect All"
        '
        'btnIncrease
        '
        Me.btnIncrease.Location = New System.Drawing.Point(479, 115)
        Me.btnIncrease.Name = "btnIncrease"
        Me.btnIncrease.Size = New System.Drawing.Size(104, 21)
        Me.btnIncrease.TabIndex = 7
        Me.btnIncrease.Text = "Change &Increase"
        '
        'btnSelectAll
        '
        Me.btnSelectAll.Location = New System.Drawing.Point(600, 115)
        Me.btnSelectAll.Name = "btnSelectAll"
        Me.btnSelectAll.Size = New System.Drawing.Size(104, 21)
        Me.btnSelectAll.TabIndex = 8
        Me.btnSelectAll.Text = "&Select All"
        '
        'btnLoad
        '
        Me.btnLoad.Location = New System.Drawing.Point(359, 115)
        Me.btnLoad.Name = "btnLoad"
        Me.btnLoad.Size = New System.Drawing.Size(104, 21)
        Me.btnLoad.TabIndex = 6
        Me.btnLoad.Text = "&Undo Changes"
        '
        'TextBox3
        '
        Me.TextBox3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox3.Enabled = False
        Me.TextBox3.Location = New System.Drawing.Point(104, 45)
        Me.TextBox3.Name = "TextBox3"
        Me.TextBox3.Size = New System.Drawing.Size(64, 20)
        Me.TextBox3.TabIndex = 175
        Me.TextBox3.Tag = ".FuelSURCHARGE.View"
        Me.TextBox3.Text = ""
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(8, 45)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(91, 16)
        Me.Label7.TabIndex = 180
        Me.Label7.Text = "Fuel Surcharge:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBox5
        '
        Me.TextBox5.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox5.Enabled = False
        Me.TextBox5.Location = New System.Drawing.Point(104, 69)
        Me.TextBox5.Name = "TextBox5"
        Me.TextBox5.Size = New System.Drawing.Size(64, 20)
        Me.TextBox5.TabIndex = 173
        Me.TextBox5.Tag = ".DiscountRate.View"
        Me.TextBox5.Text = ""
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(24, 69)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 16)
        Me.Label8.TabIndex = 178
        Me.Label8.Text = "Discount % :"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnPrint, Me.btnExit, Me.btnSave})
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox2.Location = New System.Drawing.Point(0, 341)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(832, 40)
        Me.GroupBox2.TabIndex = 4
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
        Me.btnExit.Location = New System.Drawing.Point(754, 16)
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
        'UltraGrid1
        '
        Me.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGrid1.Location = New System.Drawing.Point(0, 144)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(832, 197)
        Me.UltraGrid1.TabIndex = 5
        Me.UltraGrid1.Text = "Scheduled  Services"
        '
        'IncreaseServices
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(832, 381)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.UltraGrid1, Me.GroupBox1, Me.GroupBox2})
        Me.Name = "IncreaseServices"
        Me.Text = "Increase Scheduled Service Charges"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub IncreaseServices_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

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

    End Sub

    Private Sub AccountID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles AccountID.Leave

        If sender.Modified = False Then Exit Sub
        If sender.Text.Trim = "" Then Exit Sub
        sender.Modified = False

        LoadData(AccountID.Text)
        LoadGrid1()

    End Sub

    Private Sub LoadData(Optional ByVal IDValue As String = "", Optional ByVal Direction As String = "C")
        Dim dtAdapter As SqlDataAdapter
        Dim dvAcct As New DataView()
        Dim dtSet2 As New DataSet()
        Dim TempQuery As String
        Dim CritTmp As String

        If Val(IDValue) > 0 Then
            CritTmp = Criteria.Replace("@CID", "'" + IDValue + "'")
        Else
            CritTmp = ""
        End If

        Select Case Direction.ToUpper
            Case "N"
                If CritTmp = "" Then
                    CritTmp = Criteria.Replace("@CID", "0")
                End If
                CritTmp = CritTmp.Replace("=", ">")
            Case "C"
            Case "P"
                If CritTmp = "" Then
                    CritTmp = Criteria.Replace("@CID", "999999999")
                End If
                CritTmp = CritTmp.Replace("=", "<")
        End Select



        TempQuery = SQLSelect & CritTmp 'PrepSelectQuery(SQLSelect, CritTmp)

        PopulateDataset2(dtAdapter, dtSet2, TempQuery)
        If dtSet2 Is Nothing Then Exit Sub
        If dtSet2.Tables Is Nothing Then Exit Sub
        If dtSet2.Tables(0) Is Nothing Then Exit Sub

        If dtSet2.Tables(0).Rows.Count = 0 Then
            MessageBox.Show("No Records found.")
        Else
            btnSave.Text = "&Save"

            dvAcct.Table = dtSet2.Tables(0)
            If Direction.ToUpper = "N" Then
                dvAcct.RowFilter = "ID = Min(ID)"
            ElseIf Direction.ToUpper = "P" Then
                dvAcct.RowFilter = "ID = Max(ID)"
            End If
            FormLoad(Me, dvAcct)
        End If

        dtSet2 = Nothing
        dvAcct = Nothing

    End Sub

    Private Sub btnAcct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcct.Click
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter()
        Dim dtSet As New DataSet()
        Dim dtView As New DataView()
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow

        SelectSQL = "Select * FROM " & AppTblPath & "Customer order by Name"

        PopulateDataset2(dtAdapter, dtSet, SelectSQL)
        dtView.Table = dtSet.Tables(0)
        If dtView.Table.Rows.Count > 0 Then
            Dim Srch As New SearchListings()
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
                    AccountID.Text = ugRow.Cells("ID").Text
                    Srch = Nothing
                    AccountID.Modified = True
                    Dim ev As New System.EventArgs()
                    AccountID_Leave(AccountID, ev)
                End If
            End Try
        End If
    End Sub

    Private Sub Value_Int_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles AccountID.KeyPress
        If IsNumeric(e.KeyChar) = False And Asc(e.KeyChar) <> Keys.Back And e.KeyChar <> "-" Then
            e.Handled = True
        End If
    End Sub

    Private Sub btnPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrev.Click
        LoadData(Val(AccountID.Text), "P")
        LoadGrid1()
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        LoadData(Val(AccountID.Text), "N")
        LoadGrid1()
    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub LoadGridData()

        Dim dtAdapter As SqlDataAdapter
        Dim TempQuery As String

        If Not dtSet.Tables Is Nothing Then
            dtSet.Tables.Clear()
        End If


        PopulateDataset2(dtAdapter, dtSet, sqlIncreaseAcc)

        FillUltraGrid(UltraGrid1, dtSet, 0)
        'UGLoadListingLayout(UltraGrid1, TemplateID)
        UltraGrid1.DisplayLayout.GroupByBox.Hidden = False
        UltraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        Me.Text = MeText

    End Sub
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


        WCols(G1Col.SID).Name = "Svc.ID"
        WCols(G1Col.SID).dbFldName = "asvc.ID"
        WCols(G1Col.SID).FldCond = "AND asvc.ID = @FLDVAL"
        WCols(G1Col.SID).Type = GetType(System.Int32)
        WCols(G1Col.SID).Format = ""
        WCols(G1Col.SID).uMask = "######"
        WCols(G1Col.SID).NoEdit = True
        WCols(G1Col.SID).Hide = False
        WCols(G1Col.SID).BackColor = Color.GhostWhite
        WCols(G1Col.SID).Width = 50

        WCols(G1Col.LName).Name = "Location Name"
        WCols(G1Col.LName).dbFldName = "asvc.CompName"
        WCols(G1Col.LName).FldCond = " AND asvc.CompName = @FLDVAL"
        WCols(G1Col.LName).Type = GetType(System.String)
        WCols(G1Col.LName).Format = ""
        WCols(G1Col.LName).uMask = ""
        WCols(G1Col.LName).NoEdit = True
        WCols(G1Col.LName).Hide = False
        WCols(G1Col.LName).BackColor = Color.GhostWhite
        WCols(G1Col.LName).Width = 100

        WCols(G1Col.City).Name = "City"
        WCols(G1Col.City).dbFldName = "asvc.CityName"
        WCols(G1Col.City).FldCond = " AND asvc.CityName = @FLDVAL"
        WCols(G1Col.City).Type = GetType(System.String)
        WCols(G1Col.City).Format = ""
        WCols(G1Col.City).uMask = ""
        WCols(G1Col.City).NoEdit = True
        WCols(G1Col.City).Hide = False
        'WCols(G1Col.City).BackColor = Color.GhostWhite
        WCols(G1Col.City).Width = 80

        WCols(G1Col.State).Name = "State"
        WCols(G1Col.State).dbFldName = "asvc.State"
        WCols(G1Col.State).FldCond = " AND asvc.State = @FLDVAL"
        WCols(G1Col.State).Type = GetType(System.String)
        WCols(G1Col.State).Format = ""
        WCols(G1Col.State).uMask = ""
        WCols(G1Col.State).NoEdit = True
        WCols(G1Col.State).Hide = False
        'WCols(G1Col.State).BackColor = Color.GhostWhite
        WCols(G1Col.State).Width = 40

        WCols(G1Col.CurrCost).Name = "Chg($)"
        WCols(G1Col.CurrCost).dbFldName = "asvc.Charge"
        WCols(G1Col.CurrCost).FldCond = " AND asvc.Charge = @FLDVAL"
        WCols(G1Col.CurrCost).Type = GetType(System.Decimal)
        WCols(G1Col.CurrCost).Format = "####0.#0"
        WCols(G1Col.CurrCost).uMask = "#####.##"
        WCols(G1Col.CurrCost).NoEdit = True
        WCols(G1Col.CurrCost).Hide = False
        WCols(G1Col.CurrCost).MaxLength = 9
        WCols(G1Col.CurrCost).Width = 60

        'WCols(G1Col.NIncDate).Name = "N.Inc.Date"
        'WCols(G1Col.NIncDate).dbFldName = ""
        'WCols(G1Col.NIncDate).FldCond = " and asvc.ID in (SELECT SID FROM IncreasesService WHERE applied = 0 And AccountID = @AcctID AND incdate = @FLDVAL)"
        'WCols(G1Col.NIncDate).Type = GetType(System.DateTime)
        'WCols(G1Col.NIncDate).Format = "MM/dd/yy"
        'WCols(G1Col.NIncDate).uMask = "mm/dd/yyyy"
        'WCols(G1Col.NIncDate).NoEdit = True
        'WCols(G1Col.NIncDate).Hide = False
        ''WCols(G1Col.NIncDate).MaxLength = 9
        'WCols(G1Col.NIncDate).Width = 70

        WCols(G1Col.NIncCost).Name = "N.Inc.Cost($)"
        WCols(G1Col.NIncCost).dbFldName = "" ' Next Cost
        WCols(G1Col.NIncCost).FldCond = " AND asvc.ID in (SELECT isvc.SID FROM " & ROUTESTblPath & "IncreasesService isvc WHERE isvc.applied = 0 AND isvc.AccountID = @AcctID And isvc.FinalAmount = @FLDVAL)"
        WCols(G1Col.NIncCost).Type = GetType(System.Decimal)
        WCols(G1Col.NIncCost).Format = "####0.#0"
        WCols(G1Col.NIncCost).uMask = "#####.##"
        WCols(G1Col.NIncCost).NoEdit = False
        WCols(G1Col.NIncCost).Hide = False
        WCols(G1Col.NIncCost).MaxLength = 9
        WCols(G1Col.NIncCost).Width = 80

        WCols(G1Col.Cmnt).Name = "N.Comment"
        WCols(G1Col.Cmnt).dbFldName = "" 'Comment(applied = 0)
        WCols(G1Col.Cmnt).FldCond = " and asvc.ID in (SELECT SID FROM " & ROUTESTblPath & "IncreasesServices WHERE applied = 0 AND AccountID = @AcctID And Comment = @FLDVAL)"
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

        If AccountID.Text.Trim = "" Then Exit Function

        CritTmp = sqlIncreaseAcc.Replace("@AcctID", AccountID.Text) 'CritTmp
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
    Private Sub btnIncrease_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnIncrease.Click
        Dim x As New IncreaseRate()
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim RaiseVal As Decimal
        Dim RaiseDate As Date

        UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid, False, False)

        x.ShowDialog()
        If x.DialogResult = DialogResult.OK Then
            ' Raise Selected Accounts
            RaiseVal = x.TextBox1.Text()
            RaiseDate = x.DTPicker1.Value

            If x.rbRate.Checked Then
                RaiseRate(RaiseVal, RaiseDate)
            Else
                RaiseAmount(RaiseVal, RaiseDate)
            End If
        End If
        umskNIncreaseDate.Value = RaiseDate
        x = Nothing
    End Sub

    Private Sub RaiseRate(ByVal Val As Decimal, ByVal IncDate As Date)
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim TotalCost, NTotalCost As Decimal

        UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid, False, False)

        For Each ugRow In UltraGrid1.Rows
            RaiseRecords(ugRow, Val, IncDate, True, TotalCost, NTotalCost)
        Next
        'If TotalCost <> 0 Then
        '    TextBox1.Text = Val '(NTotalCost / TotalCost - 1) * 100
        '    TextBox4.Text = NTotalCost
        'End If
    End Sub

    Private Sub RaiseRecords(ByRef ugrow As Infragistics.Win.UltraWinGrid.UltraGridRow, ByRef Val As Decimal, ByRef IncDate As Date, Optional ByVal Rate As Boolean = True, Optional ByVal TotalCost As Decimal = -1, Optional ByVal NTotalCost As Decimal = -1)

        While Not ugrow Is Nothing
            If ugrow.Cells Is Nothing Then
                If ugrow.IsExpandable = True And ugrow.HasChild = True Then
                    'ugrow = ugrow.GetChild(Infragistics.Win.UltraWinGrid.ChildRow.First)
                    RaiseRecords(ugrow.GetChild(Infragistics.Win.UltraWinGrid.ChildRow.First), Val, IncDate, Rate, TotalCost, NTotalCost)
                Else
                    Exit Sub
                End If
            Else
                If ugrow.Cells(0).Value Then
                    If Rate Then
                        ugrow.Cells("N.Inc.Cost($)").Value = ugrow.Cells("Chg($)").Value * (1 + Val / 100)
                    Else
                        ugrow.Cells("N.Inc.Cost($)").Value = ugrow.Cells("Chg($)").Value + Val
                    End If
                    'ugrow.Cells("N.Inc.Date").Value = IncDate
                    ugrow.Update()
                Else
                    ugrow.CancelUpdate()
                End If
                If TotalCost >= 0 Then
                    NTotalCost += ugrow.Cells("N.Inc.Cost($)").Value
                    TotalCost += ugrow.Cells("Chg($)").Value
                End If
            End If

            ugrow = ugrow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next)
        End While
    End Sub

    Private Sub RaiseAmount(ByVal Val As Decimal, ByVal IncDate As Date)
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim TotalCost, NTotalCost As Decimal

        UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid, False, False)

        For Each ugRow In UltraGrid1.Rows
            RaiseRecords(ugRow, Val, IncDate, False, TotalCost, NTotalCost)
        Next
        'If TotalCost <> 0 Then
        '    TextBox1.Text = (NTotalCost / TotalCost - 1) * 100
        '    TextBox4.Text = NTotalCost
        'End If
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

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow

        UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid, False, False)
        Me.Cursor = Cursors.WaitCursor

        For Each ugRow In UltraGrid1.Rows
            SaveServiceInc(ugRow)
        Next
        SaveAcctInc()
        Me.Cursor = Cursors.Arrow
        'Me.Text = MeText & " - Data Saved..."
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        UltraGrid1.PrintPreview()
    End Sub

    Private Function SaveAcctInc() As Boolean
        Dim DelQry As String
        Dim cmdSQLTrans As New SqlCommand()
        Dim i As Integer

        If AccountID.Text.Trim = "" Then
            MsgBox("AccountID is Empty.")
            Exit Function
        End If

        SaveAcctInc = False
        On Error GoTo ErrTrap

        DelQry = "Delete FROM " & ROUTESTblPath & "IncreaseRatesAcct Where AccountID = " & AccountID.Text & " and Applied = 0 "
        If ExecuteQuery(DelQry) Then
            'AcctIDList = "("
            If ExecuteQuery("Insert Into " & ROUTESTblPath & "IncreaseRatesAcct(IncDate, AccountID, Rate, Applied, Comment) " & _
                        " values('" & umskNIncreaseDate.GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals) & "', " & AccountID.Text & _
                        ", " & TextBox1.Text & ", 0, '" & TextBox7.Text & "')") _
                        = False Then
                GoTo ErrTrap
            End If
        Else
            'Me.Text = MeText & " - Data NOT Saved!"
            GoTo ErrTrap
        End If

        Exit Function
ErrTrap:
        MsgBox("Error in SaveAcctInc : " & Err.Description)
    End Function

    Private Function SaveServiceInc(ByRef ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow) As Boolean
        Dim DelQry, DelQryTmp As String
        Dim cmdSQLTrans As New SqlCommand()
        Dim i As Integer

        SaveServiceInc = False
        On Error GoTo ErrTrap
        If AccountID.Text.Trim = "" Then
            MsgBox("AccountID is Empty.")
            Exit Function
        End If
        If UltraGrid1.Rows Is Nothing Then
            MsgBox("No service exists.")
            Exit Function
        End If
        If UltraGrid1.Rows.Count <= 0 Then
            MsgBox("No service exists.")
            Exit Function
        End If

        DelQry = "Delete FROM " & ROUTESTblPath & "IncreasesService Where AccountID = @AcctID and SID = @SID AND Applied = 0  "

        'cmdSQLTrans = InitiateEdit(Me, "Select * from IncreaseRatesAcct ")

        While Not ugRow Is Nothing
            If ugRow.Cells Is Nothing Then
                If ugRow.IsExpandable = True And ugRow.HasChild = True Then
                    SaveServiceInc(ugRow.GetChild(Infragistics.Win.UltraWinGrid.ChildRow.First))
                Else
                    Exit Function
                End If
            Else
                If ugRow.Cells(G1Col.ChkBx).Value Then
                    DelQryTmp = DelQry.Replace("@SID", ugRow.Cells(G1Col.SID).Text)
                    DelQryTmp = DelQryTmp.Replace("@AcctID", AccountID.Text)

                    If ExecuteQuery(DelQryTmp) Then
                        'AcctIDList = "("
                        If ExecuteQuery("Insert Into " & ROUTESTblPath & "IncreasesService(IncDate, AccountID, SID, FinalAmount, Applied, Comment) " & _
                                    " values('" & umskNIncreaseDate.GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.IncludeLiterals) & "', " & AccountID.Text & _
                                    ", " & ugRow.Cells(G1Col.SID).Text & ", " & ugRow.Cells(G1Col.NIncCost).Text & ", 0, '" & ugRow.Cells(G1Col.Cmnt).Text & "')") _
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
                End If
            End If
            ugRow = ugRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next)
        End While

        'cmdSQLTrans.Transaction.Commit()
        'cmdSQLTrans.Transaction = Nothing
        'cmdSQLTrans.Connection.Close()
        'cmdSQLTrans.Connection = Nothing
        'cmdSQLTrans = Nothing
        SaveServiceInc = True
        Exit Function
ErrTrap:
        MsgBox("Error in SaveServiceInc : " & Err.Description)
        'cmdSQLTrans.Transaction.Rollback()
        'cmdSQLTrans.Transaction = Nothing
        'cmdSQLTrans.Connection.Close()
        'cmdSQLTrans.Connection = Nothing
        'cmdSQLTrans = Nothing
    End Function

    '    Private Function CalcAvgRate()
    '        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
    '        Dim TotChg, TotNCost As Decimal

    '        UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid, False, False)

    '        For Each ugRow In UltraGrid1.Rows
    '            CalcTotInc(ugRow, TotChg, TotNCost)
    '        Next
    '        If TotChg <> 0 Then
    '            TextBox1.Text = (TotNCost / TotChg - 1) * 100
    '            TextBox4.Text = TotNCost
    '        End If

    '    End Function

    '    Private Function CalcTotInc(ByRef ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow, ByRef TotChg As Decimal, ByRef TotNCost As Decimal) As Boolean
    '        Dim i As Integer

    '        CalcTotInc = False
    '        On Error GoTo ErrTrap
    '        If AccountID.Text.Trim = "" Then
    '            MsgBox("AccountID is Empty.")
    '            Exit Function
    '        End If
    '        If UltraGrid1.Rows Is Nothing Then
    '            MsgBox("No service exists.")
    '            Exit Function
    '        End If
    '        If UltraGrid1.Rows.Count <= 0 Then
    '            MsgBox("No service exists.")
    '            Exit Function
    '        End If

    '        While Not ugRow Is Nothing
    '            If ugRow.Cells Is Nothing Then
    '                If ugRow.IsExpandable = True And ugRow.HasChild = True Then
    '                    CalcTotInc(ugRow.GetChild(Infragistics.Win.UltraWinGrid.ChildRow.First), TotChg, TotNCost)
    '                Else
    '                    Exit Function
    '                End If
    '            Else
    '                ugRow.Update()
    '                If TotChg >= 0 Then
    '                    TotNCost += ugRow.Cells("N.Inc.Cost($)").Value
    '                    TotChg += ugRow.Cells("Chg($)").Value
    '                End If
    '            End If

    '            ugRow = ugRow.GetSibling(Infragistics.Win.UltraWinGrid.SiblingRow.Next)
    '        End While

    '        CalcTotInc = True
    '        Exit Function
    'ErrTrap:
    '        MsgBox("Error in CalcTotInc : " & Err.Description)
    '    End Function

    Private Sub UltraGrid1_BeforeCellUpdate(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventArgs) Handles UltraGrid1.BeforeCellUpdate
        If e.Cell.Column.ToString = WCols(G1Col.NIncCost).Name Then
            GOrgCellVal = e.Cell.Value
        End If
        'e.Cancel = False
    End Sub
    Private Sub UltraGrid1_AfterCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles UltraGrid1.AfterCellUpdate
        If e.Cell.Column.ToString = WCols(G1Col.NIncCost).Name Then
            TextBox4.Text = Val(TextBox4.Text) - GOrgCellVal + e.Cell.Value
        End If
        If Val(TextBox6.Text) = 0 Then
            TextBox6.Text = 0.01
            TextBox1.Text = Format((Val(TextBox4.Text) / Val(TextBox6.Text) - 1) * 100, "#0.#0")
            TextBox6.Text = 0.0
        Else
            TextBox1.Text = Format((Val(TextBox4.Text) / Val(TextBox6.Text) - 1) * 100, "#0.#0")
        End If

    End Sub

    Private Sub AcctName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles AcctName.KeyUp
        TypeAhead(sender, e, AppTblPath & "Customer", "Name", "")
        'sender.modified = True
    End Sub

    Private Sub AcctName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles AcctName.Leave
        Dim row As DataRow
        If sender.text.trim = "" Then
            AccountID.Text = ""
            sender.text = ""
        ElseIf SearchOnLeave(sender, AccountID, ROUTESTblPath & "Customer", "ID", "Name", "", "Accounts", "") Then
            'If ReturnRowByID(AccountID.Text, row, "Customer") Then
            '    AcctName.Text = row("Name")
            '    'row.Table.DataSet = Nothing
            '    row = Nothing
            '    'LoadData()
            'End If
            LoadData(AccountID.Text)
            LoadGrid1()
        End If
    End Sub

End Class
