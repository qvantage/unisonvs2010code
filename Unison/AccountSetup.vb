Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors
Imports TTSI.PRINTERS


Public Class AccountSetup
    Inherits System.Windows.Forms.Form

    Dim SQLSelect As String = _
        " Select TOP 1 customer.ID AS ID, Customer.Name, Contact, Street, Address2, CityName, State, Zipcode, Phone1, Phone2" & _
        " , Fax, email, Web, Status, isnull(convert(varchar, CreateDate, 101), '') as CreateDate" & _
        " , bName, bContact, bStreet, bAddress2, bCityName, bState, bZipcode, bPhone1, bPhone2, bFax, bEmail, SamePayAddress" & _
        " , BCycleCode, LastBillDate, CreditLimit, DiscountRate, TaxRate, FuelSurcharge, IncreaseDate, IncreaseRate" & _
        " , FinanceCharge, NRVNU, HolidaySvcMj, HolidaySvcMn, HolidayNoticeMj, HolidayNoticeMn, HolidayCommentsMn , MasterCustID, MasterCustName" & _
        " From " & AppTblPath & "Customer @CONDCLAUSE @ORDCLAUSE "

    'Dim SQLSelect As String = _
    '        " Select TOP 1 CAST(customer.ID AS int) AS ID, Customer.Name, Contact, Street, Address2, CityName, State, Zipcode, Phone1, Phone2" & _
    '        " , Fax, email, Web, Status, isnull(convert(varchar, CreateDate, 101), '') as CreateDate" & _
    '        " , bName, bContact, bStreet, bAddress2, bCityName, bState, bZipcode, bPhone1, bPhone2, bFax, bEmail, SamePayAddress" & _
    '        " , BCycleCode, LastBillDate, CreditLimit, DiscountRate, TaxRate, FuelSurcharge, IncreaseDate, IncreaseRate" & _
    '        " , FinanceCharge, NRVNU, HolidaySvcMj, HolidaySvcMn, HolidayNoticeMj, HolidayNoticeMn, HolidayCommentsMn , MasterCustID, MasterCustName" & _
    '        " From " & AppTblPath & "Customer @CONDCLAUSE @ORDCLAUSE "
    ''" , isnull(ag.Name, '') as AcctGroup    , AccountGroups ag Where Customer.AcctGroupID *= ag.ID"

    'Dim Criteria As String = " Where Customer.ID = @CID "
    Dim Criteria As String = " Where Customer.ID = '@CID' "

    Dim MeText As String
    Dim dtSet As New DataSet
    Dim dvStates As New DataView()
    Dim cmdTrans As SqlCommand
    Dim sqlLoc As String = "Select * From " & AppTblPath & "Address where ACTIVE = 'Y' AND CustomerID = '@ACCTID'"


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
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents AccountID As System.Windows.Forms.TextBox
    Friend WithEvents btnSaveNew As System.Windows.Forms.Button
    Friend WithEvents btnAcct As System.Windows.Forms.Button
    Friend WithEvents btnPrev As System.Windows.Forms.Button
    Friend WithEvents btnNext As System.Windows.Forms.Button
    Friend WithEvents CInfo As System.Windows.Forms.TabPage
    Friend WithEvents BInfo As System.Windows.Forms.TabPage
    Friend WithEvents Web As System.Windows.Forms.TextBox
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents email As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Fax As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Phone2 As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Phone1 As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents State As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Zipcode As System.Windows.Forms.TextBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents City As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Contact As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents AcctName As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
    Friend WithEvents TabCtrl1 As System.Windows.Forms.TabControl
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents SamePayAddr As System.Windows.Forms.CheckBox
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents bName As System.Windows.Forms.TextBox
    Friend WithEvents bContact As System.Windows.Forms.TextBox
    Friend WithEvents bPhone1 As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents bFax As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents bZipcode As System.Windows.Forms.TextBox
    Friend WithEvents bPhone2 As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents bStreet As System.Windows.Forms.TextBox
    Friend WithEvents bEmail As System.Windows.Forms.TextBox
    Friend WithEvents bState As System.Windows.Forms.ComboBox
    Friend WithEvents bCity As System.Windows.Forms.TextBox
    Friend WithEvents cboBillingCycle As System.Windows.Forms.ComboBox
    Friend WithEvents umskLastBillDate As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents IncreaseRate As System.Windows.Forms.TextBox
    Friend WithEvents CreditLimit As System.Windows.Forms.TextBox
    Friend WithEvents umskIncreaseDate As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents FinanceCharge As System.Windows.Forms.TextBox
    Friend WithEvents CheckBox2 As System.Windows.Forms.CheckBox
    Friend WithEvents Groups As System.Windows.Forms.TabPage
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents Locations As System.Windows.Forms.TabPage
    Friend WithEvents UltraGrid2 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label38 As System.Windows.Forms.Label
    Friend WithEvents Label39 As System.Windows.Forms.Label
    Friend WithEvents Label40 As System.Windows.Forms.Label
    Friend WithEvents Label41 As System.Windows.Forms.Label
    Friend WithEvents Label42 As System.Windows.Forms.Label
    Friend WithEvents Label43 As System.Windows.Forms.Label
    Friend WithEvents Label44 As System.Windows.Forms.Label
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents utLeMail As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utLContact As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utLName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utLPass As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents utLZip As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utLCity As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utLAddress1 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents LUltraDate1 As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents umLPhone1 As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents umLFax As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents umLPhone2 As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents utLDirection As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utLMap As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents ucboLState As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents utLAddress2 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utLExt As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents utAddressID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utLCustomerID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utLastLocID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents txtDisc As System.Windows.Forms.TextBox
    Friend WithEvents txtTax As System.Windows.Forms.TextBox
    Friend WithEvents txtFuelSurch As System.Windows.Forms.TextBox
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents btnMasterAcct As System.Windows.Forms.Button
    Friend WithEvents MasterCustID As System.Windows.Forms.TextBox
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents MasterCustName As System.Windows.Forms.TextBox
    Friend WithEvents chkMnNotice As System.Windows.Forms.CheckBox
    Friend WithEvents chkMjNotice As System.Windows.Forms.CheckBox
    Friend WithEvents chkMnSvc As System.Windows.Forms.CheckBox
    Friend WithEvents chkMjSvc As System.Windows.Forms.CheckBox
    Friend WithEvents HolidayConfig As System.Windows.Forms.TabPage
    Friend WithEvents utHolidayComments As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel3 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel2 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel7 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel6 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel5 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents UltraLabel4 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents utAcctNameRO As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraLabel1 As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents Address2 As System.Windows.Forms.TextBox
    Friend WithEvents bAddress2 As System.Windows.Forms.TextBox
    Friend WithEvents utLocationID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnTopTic As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(AccountSetup))
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnSaveNew = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnNew = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.btnTopTic = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.utAcctNameRO = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraLabel1 = New Infragistics.Win.Misc.UltraLabel
        Me.btnPrev = New System.Windows.Forms.Button
        Me.btnNext = New System.Windows.Forms.Button
        Me.btnAcct = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.AccountID = New System.Windows.Forms.TextBox
        Me.TabCtrl1 = New System.Windows.Forms.TabControl
        Me.CInfo = New System.Windows.Forms.TabPage
        Me.Address2 = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.TextBox2 = New System.Windows.Forms.TextBox
        Me.CheckBox1 = New System.Windows.Forms.CheckBox
        Me.Label3 = New System.Windows.Forms.Label
        Me.Contact = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.AcctName = New System.Windows.Forms.TextBox
        Me.Phone1 = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Fax = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
        Me.Zipcode = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Phone2 = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.email = New System.Windows.Forms.TextBox
        Me.State = New System.Windows.Forms.ComboBox
        Me.Web = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.City = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.BInfo = New System.Windows.Forms.TabPage
        Me.MasterCustName = New System.Windows.Forms.TextBox
        Me.Label56 = New System.Windows.Forms.Label
        Me.Label55 = New System.Windows.Forms.Label
        Me.btnMasterAcct = New System.Windows.Forms.Button
        Me.Label54 = New System.Windows.Forms.Label
        Me.CheckBox2 = New System.Windows.Forms.CheckBox
        Me.umskIncreaseDate = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
        Me.umskLastBillDate = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
        Me.cboBillingCycle = New System.Windows.Forms.ComboBox
        Me.FinanceCharge = New System.Windows.Forms.TextBox
        Me.Label35 = New System.Windows.Forms.Label
        Me.Label34 = New System.Windows.Forms.Label
        Me.IncreaseRate = New System.Windows.Forms.TextBox
        Me.Label33 = New System.Windows.Forms.Label
        Me.txtFuelSurch = New System.Windows.Forms.TextBox
        Me.Label32 = New System.Windows.Forms.Label
        Me.txtTax = New System.Windows.Forms.TextBox
        Me.Label31 = New System.Windows.Forms.Label
        Me.Label30 = New System.Windows.Forms.Label
        Me.txtDisc = New System.Windows.Forms.TextBox
        Me.Label29 = New System.Windows.Forms.Label
        Me.CreditLimit = New System.Windows.Forms.TextBox
        Me.Label28 = New System.Windows.Forms.Label
        Me.Label26 = New System.Windows.Forms.Label
        Me.SamePayAddr = New System.Windows.Forms.CheckBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.bAddress2 = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.bContact = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.bName = New System.Windows.Forms.TextBox
        Me.bPhone1 = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label18 = New System.Windows.Forms.Label
        Me.bFax = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
        Me.bZipcode = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.Label20 = New System.Windows.Forms.Label
        Me.Label21 = New System.Windows.Forms.Label
        Me.bPhone2 = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
        Me.bStreet = New System.Windows.Forms.TextBox
        Me.bEmail = New System.Windows.Forms.TextBox
        Me.bState = New System.Windows.Forms.ComboBox
        Me.Label23 = New System.Windows.Forms.Label
        Me.Label24 = New System.Windows.Forms.Label
        Me.bCity = New System.Windows.Forms.TextBox
        Me.Label25 = New System.Windows.Forms.Label
        Me.MasterCustID = New System.Windows.Forms.TextBox
        Me.Groups = New System.Windows.Forms.TabPage
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.HolidayConfig = New System.Windows.Forms.TabPage
        Me.UltraLabel7 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel6 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel5 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel4 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel3 = New Infragistics.Win.Misc.UltraLabel
        Me.UltraLabel2 = New Infragistics.Win.Misc.UltraLabel
        Me.utHolidayComments = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.chkMnNotice = New System.Windows.Forms.CheckBox
        Me.chkMjNotice = New System.Windows.Forms.CheckBox
        Me.chkMnSvc = New System.Windows.Forms.CheckBox
        Me.chkMjSvc = New System.Windows.Forms.CheckBox
        Me.Locations = New System.Windows.Forms.TabPage
        Me.UltraGrid2 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.utLastLocID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utLCustomerID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utAddressID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utLocationID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label53 = New System.Windows.Forms.Label
        Me.utLExt = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label52 = New System.Windows.Forms.Label
        Me.utLAddress2 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.ucboLState = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.Label51 = New System.Windows.Forms.Label
        Me.utLMap = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label50 = New System.Windows.Forms.Label
        Me.utLDirection = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label49 = New System.Windows.Forms.Label
        Me.utLZip = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utLCity = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utLAddress1 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.LUltraDate1 = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.utLeMail = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utLContact = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utLName = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utLPass = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Splitter1 = New System.Windows.Forms.Splitter
        Me.Label48 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.Label38 = New System.Windows.Forms.Label
        Me.umLPhone1 = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
        Me.Label39 = New System.Windows.Forms.Label
        Me.Label40 = New System.Windows.Forms.Label
        Me.umLFax = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
        Me.Label41 = New System.Windows.Forms.Label
        Me.Label42 = New System.Windows.Forms.Label
        Me.Label43 = New System.Windows.Forms.Label
        Me.umLPhone2 = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
        Me.Label44 = New System.Windows.Forms.Label
        Me.Label45 = New System.Windows.Forms.Label
        Me.Label46 = New System.Windows.Forms.Label
        Me.Label47 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        CType(Me.utAcctNameRO, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.TabCtrl1.SuspendLayout()
        Me.CInfo.SuspendLayout()
        Me.BInfo.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.Groups.SuspendLayout()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.HolidayConfig.SuspendLayout()
        CType(Me.utHolidayComments, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Locations.SuspendLayout()
        CType(Me.UltraGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.utLastLocID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utLCustomerID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utAddressID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utLocationID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utLExt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utLAddress2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucboLState, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utLMap, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utLDirection, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utLZip, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utLCity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utLAddress1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LUltraDate1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utLeMail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utLContact, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utLName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utLPass, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.btnExit)
        Me.GroupBox1.Controls.Add(Me.btnSaveNew)
        Me.GroupBox1.Controls.Add(Me.btnDelete)
        Me.GroupBox1.Controls.Add(Me.btnNew)
        Me.GroupBox1.Controls.Add(Me.btnSave)
        Me.GroupBox1.Controls.Add(Me.btnEdit)
        Me.GroupBox1.Controls.Add(Me.btnTopTic)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(0, 421)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(594, 40)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(336, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.TabIndex = 132
        Me.Button1.Text = "Button1"
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnExit.Location = New System.Drawing.Point(516, 16)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 21)
        Me.btnExit.TabIndex = 5
        Me.btnExit.Text = "E&xit"
        '
        'btnSaveNew
        '
        Me.btnSaveNew.Location = New System.Drawing.Point(248, 16)
        Me.btnSaveNew.Name = "btnSaveNew"
        Me.btnSaveNew.Size = New System.Drawing.Size(72, 21)
        Me.btnSaveNew.TabIndex = 4
        Me.btnSaveNew.Text = "S&ave-New"
        '
        'btnDelete
        '
        Me.btnDelete.Enabled = False
        Me.btnDelete.Location = New System.Drawing.Point(186, 16)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(61, 21)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "&Delete"
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(125, 16)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(61, 21)
        Me.btnNew.TabIndex = 2
        Me.btnNew.Text = "&New"
        '
        'btnSave
        '
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnSave.Location = New System.Drawing.Point(3, 16)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(61, 21)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "&Save"
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(64, 16)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(61, 21)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "&Edit"
        '
        'btnTopTic
        '
        Me.btnTopTic.Location = New System.Drawing.Point(432, 16)
        Me.btnTopTic.Name = "btnTopTic"
        Me.btnTopTic.Size = New System.Drawing.Size(80, 21)
        Me.btnTopTic.TabIndex = 131
        Me.btnTopTic.Text = "Print Tickets"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.utAcctNameRO)
        Me.GroupBox3.Controls.Add(Me.UltraLabel1)
        Me.GroupBox3.Controls.Add(Me.btnPrev)
        Me.GroupBox3.Controls.Add(Me.btnNext)
        Me.GroupBox3.Controls.Add(Me.btnAcct)
        Me.GroupBox3.Controls.Add(Me.Label1)
        Me.GroupBox3.Controls.Add(Me.AccountID)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(594, 48)
        Me.GroupBox3.TabIndex = 0
        Me.GroupBox3.TabStop = False
        '
        'utAcctNameRO
        '
        Appearance1.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        Appearance1.ForeColor = System.Drawing.Color.Black
        Appearance1.ForeColorDisabled = System.Drawing.Color.Black
        Me.utAcctNameRO.Appearance = Appearance1
        Me.utAcctNameRO.Enabled = False
        Me.utAcctNameRO.Location = New System.Drawing.Point(272, 16)
        Me.utAcctNameRO.Name = "utAcctNameRO"
        Me.utAcctNameRO.Size = New System.Drawing.Size(208, 21)
        Me.utAcctNameRO.TabIndex = 16
        Me.utAcctNameRO.Tag = ".name.view"
        '
        'UltraLabel1
        '
        Appearance2.ForeColor = System.Drawing.Color.Black
        Appearance2.ForeColorDisabled = System.Drawing.Color.Firebrick
        Appearance2.TextHAlign = Infragistics.Win.HAlign.Center
        Appearance2.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.UltraLabel1.Appearance = Appearance2
        Me.UltraLabel1.Font = New System.Drawing.Font("Arial", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel1.Location = New System.Drawing.Point(488, 16)
        Me.UltraLabel1.Name = "UltraLabel1"
        Me.UltraLabel1.TabIndex = 15
        Me.UltraLabel1.Text = "UltraLabel1"
        '
        'btnPrev
        '
        Me.btnPrev.Image = CType(resources.GetObject("btnPrev.Image"), System.Drawing.Image)
        Me.btnPrev.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnPrev.Location = New System.Drawing.Point(209, 16)
        Me.btnPrev.Name = "btnPrev"
        Me.btnPrev.Size = New System.Drawing.Size(24, 21)
        Me.btnPrev.TabIndex = 2
        Me.btnPrev.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'btnNext
        '
        Me.btnNext.Image = CType(resources.GetObject("btnNext.Image"), System.Drawing.Image)
        Me.btnNext.ImageAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.btnNext.Location = New System.Drawing.Point(233, 16)
        Me.btnNext.Name = "btnNext"
        Me.btnNext.Size = New System.Drawing.Size(24, 21)
        Me.btnNext.TabIndex = 3
        '
        'btnAcct
        '
        Me.btnAcct.Location = New System.Drawing.Point(121, 16)
        Me.btnAcct.Name = "btnAcct"
        Me.btnAcct.Size = New System.Drawing.Size(75, 21)
        Me.btnAcct.TabIndex = 1
        Me.btnAcct.Text = "Select"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(18, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 16)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "ID:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'AccountID
        '
        Me.AccountID.Location = New System.Drawing.Point(50, 16)
        Me.AccountID.Name = "AccountID"
        Me.AccountID.Size = New System.Drawing.Size(56, 20)
        Me.AccountID.TabIndex = 0
        Me.AccountID.Tag = ".id"
        Me.AccountID.Text = ""
        '
        'TabCtrl1
        '
        Me.TabCtrl1.Controls.Add(Me.CInfo)
        Me.TabCtrl1.Controls.Add(Me.BInfo)
        Me.TabCtrl1.Controls.Add(Me.Groups)
        Me.TabCtrl1.Controls.Add(Me.HolidayConfig)
        Me.TabCtrl1.Controls.Add(Me.Locations)
        Me.TabCtrl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabCtrl1.Location = New System.Drawing.Point(0, 48)
        Me.TabCtrl1.Name = "TabCtrl1"
        Me.TabCtrl1.SelectedIndex = 0
        Me.TabCtrl1.Size = New System.Drawing.Size(594, 373)
        Me.TabCtrl1.TabIndex = 1
        '
        'CInfo
        '
        Me.CInfo.Controls.Add(Me.Address2)
        Me.CInfo.Controls.Add(Me.Label13)
        Me.CInfo.Controls.Add(Me.TextBox2)
        Me.CInfo.Controls.Add(Me.CheckBox1)
        Me.CInfo.Controls.Add(Me.Label3)
        Me.CInfo.Controls.Add(Me.Contact)
        Me.CInfo.Controls.Add(Me.Label2)
        Me.CInfo.Controls.Add(Me.AcctName)
        Me.CInfo.Controls.Add(Me.Phone1)
        Me.CInfo.Controls.Add(Me.Label12)
        Me.CInfo.Controls.Add(Me.Label6)
        Me.CInfo.Controls.Add(Me.Fax)
        Me.CInfo.Controls.Add(Me.Zipcode)
        Me.CInfo.Controls.Add(Me.Label11)
        Me.CInfo.Controls.Add(Me.Label9)
        Me.CInfo.Controls.Add(Me.Label4)
        Me.CInfo.Controls.Add(Me.Phone2)
        Me.CInfo.Controls.Add(Me.TextBox1)
        Me.CInfo.Controls.Add(Me.email)
        Me.CInfo.Controls.Add(Me.State)
        Me.CInfo.Controls.Add(Me.Web)
        Me.CInfo.Controls.Add(Me.Label7)
        Me.CInfo.Controls.Add(Me.Label5)
        Me.CInfo.Controls.Add(Me.Label8)
        Me.CInfo.Controls.Add(Me.City)
        Me.CInfo.Controls.Add(Me.Label10)
        Me.CInfo.Location = New System.Drawing.Point(4, 22)
        Me.CInfo.Name = "CInfo"
        Me.CInfo.Size = New System.Drawing.Size(586, 347)
        Me.CInfo.TabIndex = 0
        Me.CInfo.Text = "Cust.Info."
        '
        'Address2
        '
        Me.Address2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Address2.Location = New System.Drawing.Point(72, 80)
        Me.Address2.Name = "Address2"
        Me.Address2.Size = New System.Drawing.Size(224, 20)
        Me.Address2.TabIndex = 3
        Me.Address2.Tag = ".Address2"
        Me.Address2.Text = ""
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(325, 32)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(68, 16)
        Me.Label13.TabIndex = 129
        Me.Label13.Text = "Create Date:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBox2
        '
        Me.TextBox2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox2.Enabled = False
        Me.TextBox2.Location = New System.Drawing.Point(394, 30)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.Size = New System.Drawing.Size(96, 20)
        Me.TextBox2.TabIndex = 13
        Me.TextBox2.Tag = ".CreateDate.view"
        Me.TextBox2.Text = ""
        '
        'CheckBox1
        '
        Me.CheckBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBox1.Location = New System.Drawing.Point(351, 8)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(58, 16)
        Me.CheckBox1.TabIndex = 12
        Me.CheckBox1.Tag = ".Status"
        Me.CheckBox1.Text = "Active"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(16, 33)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 16)
        Me.Label3.TabIndex = 125
        Me.Label3.Text = "Contact:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Contact
        '
        Me.Contact.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Contact.Location = New System.Drawing.Point(72, 33)
        Me.Contact.Name = "Contact"
        Me.Contact.Size = New System.Drawing.Size(224, 20)
        Me.Contact.TabIndex = 1
        Me.Contact.Tag = ".contact"
        Me.Contact.Text = ""
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(24, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(40, 16)
        Me.Label2.TabIndex = 124
        Me.Label2.Text = "Name:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'AcctName
        '
        Me.AcctName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.AcctName.Location = New System.Drawing.Point(72, 8)
        Me.AcctName.Name = "AcctName"
        Me.AcctName.Size = New System.Drawing.Size(224, 20)
        Me.AcctName.TabIndex = 0
        Me.AcctName.Tag = ".name"
        Me.AcctName.Text = ""
        '
        'Phone1
        '
        Me.Phone1.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.Phone1.InputMask = "(###)-###-####"
        Me.Phone1.Location = New System.Drawing.Point(72, 201)
        Me.Phone1.Name = "Phone1"
        Me.Phone1.Size = New System.Drawing.Size(88, 20)
        Me.Phone1.TabIndex = 9
        Me.Phone1.Tag = ".PHONE1"
        Me.Phone1.Text = "()--"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(24, 129)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(40, 16)
        Me.Label12.TabIndex = 130
        Me.Label12.Text = "State:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(136, 129)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 16)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "Zip Code:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Fax
        '
        Me.Fax.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.Fax.InputMask = "(###)-###-####"
        Me.Fax.Location = New System.Drawing.Point(72, 225)
        Me.Fax.Name = "Fax"
        Me.Fax.Size = New System.Drawing.Size(88, 20)
        Me.Fax.TabIndex = 11
        Me.Fax.Tag = ".FAX"
        Me.Fax.Text = "()--"
        '
        'Zipcode
        '
        Me.Zipcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Zipcode.Location = New System.Drawing.Point(200, 129)
        Me.Zipcode.Name = "Zipcode"
        Me.Zipcode.Size = New System.Drawing.Size(96, 20)
        Me.Zipcode.TabIndex = 6
        Me.Zipcode.Tag = ".zipcode"
        Me.Zipcode.Text = ""
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(8, 201)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(56, 16)
        Me.Label11.TabIndex = 125
        Me.Label11.Text = "Phone 1:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(32, 225)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(32, 16)
        Me.Label9.TabIndex = 127
        Me.Label9.Text = "Fax:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(24, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 16)
        Me.Label4.TabIndex = 122
        Me.Label4.Text = "Street:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Phone2
        '
        Me.Phone2.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.Phone2.InputMask = "(###)-###-####"
        Me.Phone2.Location = New System.Drawing.Point(208, 201)
        Me.Phone2.Name = "Phone2"
        Me.Phone2.Size = New System.Drawing.Size(88, 20)
        Me.Phone2.TabIndex = 10
        Me.Phone2.Tag = ".PHONE2"
        Me.Phone2.Text = "()--"
        '
        'TextBox1
        '
        Me.TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox1.Location = New System.Drawing.Point(72, 56)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(224, 20)
        Me.TextBox1.TabIndex = 2
        Me.TextBox1.Tag = ".street"
        Me.TextBox1.Text = ""
        '
        'email
        '
        Me.email.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.email.Location = New System.Drawing.Point(72, 153)
        Me.email.Name = "email"
        Me.email.Size = New System.Drawing.Size(223, 20)
        Me.email.TabIndex = 7
        Me.email.Tag = ".EMAIL"
        Me.email.Text = ""
        '
        'State
        '
        Me.State.Location = New System.Drawing.Point(72, 129)
        Me.State.Name = "State"
        Me.State.Size = New System.Drawing.Size(56, 21)
        Me.State.TabIndex = 5
        Me.State.Tag = ".STATE...STATE.CODE.CODE"
        '
        'Web
        '
        Me.Web.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Web.Location = New System.Drawing.Point(72, 177)
        Me.Web.Name = "Web"
        Me.Web.Size = New System.Drawing.Size(223, 20)
        Me.Web.TabIndex = 8
        Me.Web.Tag = ".web"
        Me.Web.Text = ""
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(32, 177)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(32, 16)
        Me.Label7.TabIndex = 129
        Me.Label7.Text = "Web:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(32, 105)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 16)
        Me.Label5.TabIndex = 123
        Me.Label5.Text = "City:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(152, 201)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 16)
        Me.Label8.TabIndex = 126
        Me.Label8.Text = "Phone 2:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'City
        '
        Me.City.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.City.Location = New System.Drawing.Point(72, 105)
        Me.City.Name = "City"
        Me.City.Size = New System.Drawing.Size(224, 20)
        Me.City.TabIndex = 4
        Me.City.Tag = ".cityname"
        Me.City.Text = ""
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(24, 153)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(40, 16)
        Me.Label10.TabIndex = 128
        Me.Label10.Text = "eMail:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BInfo
        '
        Me.BInfo.Controls.Add(Me.MasterCustName)
        Me.BInfo.Controls.Add(Me.Label56)
        Me.BInfo.Controls.Add(Me.Label55)
        Me.BInfo.Controls.Add(Me.btnMasterAcct)
        Me.BInfo.Controls.Add(Me.Label54)
        Me.BInfo.Controls.Add(Me.CheckBox2)
        Me.BInfo.Controls.Add(Me.umskIncreaseDate)
        Me.BInfo.Controls.Add(Me.umskLastBillDate)
        Me.BInfo.Controls.Add(Me.cboBillingCycle)
        Me.BInfo.Controls.Add(Me.FinanceCharge)
        Me.BInfo.Controls.Add(Me.Label35)
        Me.BInfo.Controls.Add(Me.Label34)
        Me.BInfo.Controls.Add(Me.IncreaseRate)
        Me.BInfo.Controls.Add(Me.Label33)
        Me.BInfo.Controls.Add(Me.txtFuelSurch)
        Me.BInfo.Controls.Add(Me.Label32)
        Me.BInfo.Controls.Add(Me.txtTax)
        Me.BInfo.Controls.Add(Me.Label31)
        Me.BInfo.Controls.Add(Me.Label30)
        Me.BInfo.Controls.Add(Me.txtDisc)
        Me.BInfo.Controls.Add(Me.Label29)
        Me.BInfo.Controls.Add(Me.CreditLimit)
        Me.BInfo.Controls.Add(Me.Label28)
        Me.BInfo.Controls.Add(Me.Label26)
        Me.BInfo.Controls.Add(Me.SamePayAddr)
        Me.BInfo.Controls.Add(Me.GroupBox2)
        Me.BInfo.Controls.Add(Me.MasterCustID)
        Me.BInfo.Location = New System.Drawing.Point(4, 22)
        Me.BInfo.Name = "BInfo"
        Me.BInfo.Size = New System.Drawing.Size(586, 347)
        Me.BInfo.TabIndex = 1
        Me.BInfo.Text = "Billing Info."
        '
        'MasterCustName
        '
        Me.MasterCustName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.MasterCustName.Location = New System.Drawing.Point(88, 314)
        Me.MasterCustName.Name = "MasterCustName"
        Me.MasterCustName.Size = New System.Drawing.Size(224, 20)
        Me.MasterCustName.TabIndex = 12
        Me.MasterCustName.Tag = ".MasterCustName"
        Me.MasterCustName.Text = ""
        '
        'Label56
        '
        Me.Label56.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.Label56.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.Label56.Location = New System.Drawing.Point(23, 258)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(97, 16)
        Me.Label56.TabIndex = 180
        Me.Label56.Text = "Master Account:"
        Me.Label56.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label55
        '
        Me.Label55.Location = New System.Drawing.Point(8, 314)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(80, 16)
        Me.Label55.TabIndex = 179
        Me.Label55.Text = "Master Name:"
        Me.Label55.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnMasterAcct
        '
        Me.btnMasterAcct.Location = New System.Drawing.Point(168, 282)
        Me.btnMasterAcct.Name = "btnMasterAcct"
        Me.btnMasterAcct.Size = New System.Drawing.Size(75, 21)
        Me.btnMasterAcct.TabIndex = 11
        Me.btnMasterAcct.Text = "Select"
        '
        'Label54
        '
        Me.Label54.Location = New System.Drawing.Point(32, 284)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(56, 16)
        Me.Label54.TabIndex = 176
        Me.Label54.Text = "Master ID:"
        Me.Label54.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CheckBox2
        '
        Me.CheckBox2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.CheckBox2.Location = New System.Drawing.Point(328, 224)
        Me.CheckBox2.Name = "CheckBox2"
        Me.CheckBox2.Size = New System.Drawing.Size(96, 16)
        Me.CheckBox2.TabIndex = 9
        Me.CheckBox2.Tag = ".NRVNU"
        Me.CheckBox2.Text = "Non Revenu:"
        '
        'umskIncreaseDate
        '
        Me.umskIncreaseDate.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Date
        Me.umskIncreaseDate.InputMask = "mm/dd/yyyy"
        Me.umskIncreaseDate.Location = New System.Drawing.Point(408, 176)
        Me.umskIncreaseDate.Name = "umskIncreaseDate"
        Me.umskIncreaseDate.ReadOnly = True
        Me.umskIncreaseDate.Size = New System.Drawing.Size(72, 20)
        Me.umskIncreaseDate.TabIndex = 7
        Me.umskIncreaseDate.Tag = ".INCREASEDATE"
        Me.umskIncreaseDate.Text = "//"
        '
        'umskLastBillDate
        '
        Me.umskLastBillDate.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.Date
        Me.umskLastBillDate.InputMask = "mm/dd/yyyy"
        Me.umskLastBillDate.Location = New System.Drawing.Point(408, 34)
        Me.umskLastBillDate.Name = "umskLastBillDate"
        Me.umskLastBillDate.ReadOnly = True
        Me.umskLastBillDate.Size = New System.Drawing.Size(72, 20)
        Me.umskLastBillDate.TabIndex = 1
        Me.umskLastBillDate.Tag = ".LastBillDate........"
        Me.umskLastBillDate.Text = "//"
        '
        'cboBillingCycle
        '
        Me.cboBillingCycle.Location = New System.Drawing.Point(408, 12)
        Me.cboBillingCycle.Name = "cboBillingCycle"
        Me.cboBillingCycle.Size = New System.Drawing.Size(110, 21)
        Me.cboBillingCycle.TabIndex = 0
        Me.cboBillingCycle.Tag = ".BCycleCode...BillingCycles.CODE.Name"
        '
        'FinanceCharge
        '
        Me.FinanceCharge.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.FinanceCharge.Location = New System.Drawing.Point(408, 200)
        Me.FinanceCharge.Name = "FinanceCharge"
        Me.FinanceCharge.Size = New System.Drawing.Size(110, 20)
        Me.FinanceCharge.TabIndex = 8
        Me.FinanceCharge.Tag = ".FINANCECHARGE"
        Me.FinanceCharge.Text = ""
        '
        'Label35
        '
        Me.Label35.Location = New System.Drawing.Point(320, 200)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(88, 16)
        Me.Label35.TabIndex = 174
        Me.Label35.Text = "Finance Charge:"
        Me.Label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label34
        '
        Me.Label34.Location = New System.Drawing.Point(328, 176)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(80, 16)
        Me.Label34.TabIndex = 172
        Me.Label34.Text = "Increase Date:"
        Me.Label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'IncreaseRate
        '
        Me.IncreaseRate.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.IncreaseRate.Location = New System.Drawing.Point(408, 152)
        Me.IncreaseRate.Name = "IncreaseRate"
        Me.IncreaseRate.Size = New System.Drawing.Size(110, 20)
        Me.IncreaseRate.TabIndex = 6
        Me.IncreaseRate.Tag = ".INCREASERATE"
        Me.IncreaseRate.Text = ""
        '
        'Label33
        '
        Me.Label33.Location = New System.Drawing.Point(320, 152)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(88, 16)
        Me.Label33.TabIndex = 170
        Me.Label33.Text = "Increase % :"
        Me.Label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtFuelSurch
        '
        Me.txtFuelSurch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtFuelSurch.Location = New System.Drawing.Point(408, 128)
        Me.txtFuelSurch.Name = "txtFuelSurch"
        Me.txtFuelSurch.Size = New System.Drawing.Size(110, 20)
        Me.txtFuelSurch.TabIndex = 5
        Me.txtFuelSurch.Tag = ".FuelSURCHARGE"
        Me.txtFuelSurch.Text = ""
        '
        'Label32
        '
        Me.Label32.Location = New System.Drawing.Point(319, 128)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(87, 16)
        Me.Label32.TabIndex = 168
        Me.Label32.Text = "Fuel Surcharge:"
        Me.Label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtTax
        '
        Me.txtTax.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtTax.Location = New System.Drawing.Point(408, 104)
        Me.txtTax.Name = "txtTax"
        Me.txtTax.Size = New System.Drawing.Size(110, 20)
        Me.txtTax.TabIndex = 4
        Me.txtTax.Tag = ".TaxRate"
        Me.txtTax.Text = ""
        '
        'Label31
        '
        Me.Label31.Location = New System.Drawing.Point(328, 104)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(80, 16)
        Me.Label31.TabIndex = 166
        Me.Label31.Text = "Sales Tax % :"
        Me.Label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label30
        '
        Me.Label30.Location = New System.Drawing.Point(334, 37)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(72, 16)
        Me.Label30.TabIndex = 164
        Me.Label30.Text = "Last B. Date:"
        Me.Label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtDisc
        '
        Me.txtDisc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.txtDisc.Location = New System.Drawing.Point(408, 80)
        Me.txtDisc.Name = "txtDisc"
        Me.txtDisc.Size = New System.Drawing.Size(110, 20)
        Me.txtDisc.TabIndex = 3
        Me.txtDisc.Tag = ".DiscountRate"
        Me.txtDisc.Text = ""
        '
        'Label29
        '
        Me.Label29.Location = New System.Drawing.Point(334, 85)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(72, 16)
        Me.Label29.TabIndex = 162
        Me.Label29.Text = "Discount % :"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'CreditLimit
        '
        Me.CreditLimit.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.CreditLimit.Location = New System.Drawing.Point(408, 58)
        Me.CreditLimit.Name = "CreditLimit"
        Me.CreditLimit.Size = New System.Drawing.Size(110, 20)
        Me.CreditLimit.TabIndex = 2
        Me.CreditLimit.Tag = ".CreditLimit"
        Me.CreditLimit.Text = ""
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(331, 64)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(76, 16)
        Me.Label28.TabIndex = 160
        Me.Label28.Text = "Credit Limit:"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label26
        '
        Me.Label26.Location = New System.Drawing.Point(331, 17)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(79, 16)
        Me.Label26.TabIndex = 156
        Me.Label26.Text = "Billing Cycle:"
        Me.Label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'SamePayAddr
        '
        Me.SamePayAddr.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SamePayAddr.Location = New System.Drawing.Point(23, 8)
        Me.SamePayAddr.Name = "SamePayAddr"
        Me.SamePayAddr.Size = New System.Drawing.Size(194, 16)
        Me.SamePayAddr.TabIndex = 0
        Me.SamePayAddr.Tag = ".SamePayAddress"
        Me.SamePayAddr.Text = " Same as Company Address : "
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.bAddress2)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.bContact)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.bName)
        Me.GroupBox2.Controls.Add(Me.bPhone1)
        Me.GroupBox2.Controls.Add(Me.Label17)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.bFax)
        Me.GroupBox2.Controls.Add(Me.bZipcode)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.Label21)
        Me.GroupBox2.Controls.Add(Me.bPhone2)
        Me.GroupBox2.Controls.Add(Me.bStreet)
        Me.GroupBox2.Controls.Add(Me.bEmail)
        Me.GroupBox2.Controls.Add(Me.bState)
        Me.GroupBox2.Controls.Add(Me.Label23)
        Me.GroupBox2.Controls.Add(Me.Label24)
        Me.GroupBox2.Controls.Add(Me.bCity)
        Me.GroupBox2.Controls.Add(Me.Label25)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 8)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(304, 240)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'bAddress2
        '
        Me.bAddress2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.bAddress2.Location = New System.Drawing.Point(64, 95)
        Me.bAddress2.Name = "bAddress2"
        Me.bAddress2.Size = New System.Drawing.Size(224, 20)
        Me.bAddress2.TabIndex = 3
        Me.bAddress2.Tag = ".bAddress2"
        Me.bAddress2.Text = ""
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(8, 48)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(48, 16)
        Me.Label14.TabIndex = 147
        Me.Label14.Text = "Contact:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'bContact
        '
        Me.bContact.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.bContact.Location = New System.Drawing.Point(64, 48)
        Me.bContact.Name = "bContact"
        Me.bContact.Size = New System.Drawing.Size(224, 20)
        Me.bContact.TabIndex = 1
        Me.bContact.Tag = ".bcontact"
        Me.bContact.Text = ""
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(16, 24)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(40, 16)
        Me.Label15.TabIndex = 13
        Me.Label15.Text = "Name:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'bName
        '
        Me.bName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.bName.Location = New System.Drawing.Point(64, 24)
        Me.bName.Name = "bName"
        Me.bName.Size = New System.Drawing.Size(224, 20)
        Me.bName.TabIndex = 0
        Me.bName.Tag = ".bname"
        Me.bName.Text = ""
        '
        'bPhone1
        '
        Me.bPhone1.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.bPhone1.InputMask = "(###)-###-####"
        Me.bPhone1.Location = New System.Drawing.Point(64, 190)
        Me.bPhone1.Name = "bPhone1"
        Me.bPhone1.Size = New System.Drawing.Size(80, 20)
        Me.bPhone1.TabIndex = 8
        Me.bPhone1.Tag = ".BPHONE1"
        Me.bPhone1.Text = "()--"
        '
        'Label17
        '
        Me.Label17.Location = New System.Drawing.Point(16, 142)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(40, 16)
        Me.Label17.TabIndex = 152
        Me.Label17.Text = "State:"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label18
        '
        Me.Label18.Location = New System.Drawing.Point(128, 142)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(56, 16)
        Me.Label18.TabIndex = 144
        Me.Label18.Text = "Zip Code:"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'bFax
        '
        Me.bFax.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.bFax.InputMask = "(###)-###-####"
        Me.bFax.Location = New System.Drawing.Point(64, 214)
        Me.bFax.Name = "bFax"
        Me.bFax.Size = New System.Drawing.Size(80, 20)
        Me.bFax.TabIndex = 10
        Me.bFax.Tag = ".BFAX"
        Me.bFax.Text = "()--"
        '
        'bZipcode
        '
        Me.bZipcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.bZipcode.Location = New System.Drawing.Point(192, 142)
        Me.bZipcode.Name = "bZipcode"
        Me.bZipcode.Size = New System.Drawing.Size(96, 20)
        Me.bZipcode.TabIndex = 6
        Me.bZipcode.Tag = ".bzipcode"
        Me.bZipcode.Text = ""
        '
        'Label19
        '
        Me.Label19.Location = New System.Drawing.Point(0, 190)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(56, 16)
        Me.Label19.TabIndex = 146
        Me.Label19.Text = "Phone 1:"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(24, 214)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(32, 16)
        Me.Label20.TabIndex = 149
        Me.Label20.Text = "Fax:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label21
        '
        Me.Label21.Location = New System.Drawing.Point(16, 72)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(40, 16)
        Me.Label21.TabIndex = 141
        Me.Label21.Text = "Street:"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'bPhone2
        '
        Me.bPhone2.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.bPhone2.InputMask = "(###)-###-####"
        Me.bPhone2.Location = New System.Drawing.Point(208, 190)
        Me.bPhone2.Name = "bPhone2"
        Me.bPhone2.Size = New System.Drawing.Size(80, 20)
        Me.bPhone2.TabIndex = 9
        Me.bPhone2.Tag = ".BPHONE2"
        Me.bPhone2.Text = "()--"
        '
        'bStreet
        '
        Me.bStreet.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.bStreet.Location = New System.Drawing.Point(64, 72)
        Me.bStreet.Name = "bStreet"
        Me.bStreet.Size = New System.Drawing.Size(224, 20)
        Me.bStreet.TabIndex = 2
        Me.bStreet.Tag = ".bstreet"
        Me.bStreet.Text = ""
        '
        'bEmail
        '
        Me.bEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.bEmail.Location = New System.Drawing.Point(64, 166)
        Me.bEmail.Name = "bEmail"
        Me.bEmail.Size = New System.Drawing.Size(223, 20)
        Me.bEmail.TabIndex = 7
        Me.bEmail.Tag = ".bEMAIL"
        Me.bEmail.Text = ""
        '
        'bState
        '
        Me.bState.Location = New System.Drawing.Point(64, 142)
        Me.bState.Name = "bState"
        Me.bState.Size = New System.Drawing.Size(56, 21)
        Me.bState.TabIndex = 5
        Me.bState.Tag = ".bSTATE...STATE.CODE.CODE"
        '
        'Label23
        '
        Me.Label23.Location = New System.Drawing.Point(24, 118)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(32, 16)
        Me.Label23.TabIndex = 143
        Me.Label23.Text = "City:"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label24
        '
        Me.Label24.Location = New System.Drawing.Point(144, 190)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(56, 16)
        Me.Label24.TabIndex = 148
        Me.Label24.Text = "Phone 2:"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'bCity
        '
        Me.bCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.bCity.Location = New System.Drawing.Point(64, 118)
        Me.bCity.Name = "bCity"
        Me.bCity.Size = New System.Drawing.Size(224, 20)
        Me.bCity.TabIndex = 4
        Me.bCity.Tag = ".bcityname"
        Me.bCity.Text = ""
        '
        'Label25
        '
        Me.Label25.Location = New System.Drawing.Point(16, 166)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(40, 16)
        Me.Label25.TabIndex = 150
        Me.Label25.Text = "eMail:"
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'MasterCustID
        '
        Me.MasterCustID.Location = New System.Drawing.Point(88, 282)
        Me.MasterCustID.Name = "MasterCustID"
        Me.MasterCustID.Size = New System.Drawing.Size(56, 20)
        Me.MasterCustID.TabIndex = 10
        Me.MasterCustID.Tag = ".MasterCustID"
        Me.MasterCustID.Text = ""
        '
        'Groups
        '
        Me.Groups.Controls.Add(Me.UltraGrid1)
        Me.Groups.Location = New System.Drawing.Point(4, 22)
        Me.Groups.Name = "Groups"
        Me.Groups.Size = New System.Drawing.Size(586, 347)
        Me.Groups.TabIndex = 3
        Me.Groups.Text = "Group Membership"
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGrid1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(586, 347)
        Me.UltraGrid1.TabIndex = 2
        Me.UltraGrid1.Tag = "TrackingListing"
        Me.UltraGrid1.Text = "Groups Membership"
        '
        'HolidayConfig
        '
        Me.HolidayConfig.Controls.Add(Me.UltraLabel7)
        Me.HolidayConfig.Controls.Add(Me.UltraLabel6)
        Me.HolidayConfig.Controls.Add(Me.UltraLabel5)
        Me.HolidayConfig.Controls.Add(Me.UltraLabel4)
        Me.HolidayConfig.Controls.Add(Me.UltraLabel3)
        Me.HolidayConfig.Controls.Add(Me.UltraLabel2)
        Me.HolidayConfig.Controls.Add(Me.utHolidayComments)
        Me.HolidayConfig.Controls.Add(Me.chkMnNotice)
        Me.HolidayConfig.Controls.Add(Me.chkMjNotice)
        Me.HolidayConfig.Controls.Add(Me.chkMnSvc)
        Me.HolidayConfig.Controls.Add(Me.chkMjSvc)
        Me.HolidayConfig.Location = New System.Drawing.Point(4, 22)
        Me.HolidayConfig.Name = "HolidayConfig"
        Me.HolidayConfig.Size = New System.Drawing.Size(586, 347)
        Me.HolidayConfig.TabIndex = 2
        Me.HolidayConfig.Text = "Holiday Config"
        '
        'UltraLabel7
        '
        Appearance3.ForeColor = System.Drawing.Color.Black
        Appearance3.ForeColorDisabled = System.Drawing.Color.Black
        Appearance3.TextHAlign = Infragistics.Win.HAlign.Right
        Appearance3.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.UltraLabel7.Appearance = Appearance3
        Me.UltraLabel7.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel7.Location = New System.Drawing.Point(272, 16)
        Me.UltraLabel7.Name = "UltraLabel7"
        Me.UltraLabel7.Size = New System.Drawing.Size(88, 16)
        Me.UltraLabel7.TabIndex = 189
        Me.UltraLabel7.Text = "Minor Holidays"
        '
        'UltraLabel6
        '
        Appearance4.ForeColor = System.Drawing.Color.Black
        Appearance4.ForeColorDisabled = System.Drawing.Color.Black
        Appearance4.TextHAlign = Infragistics.Win.HAlign.Right
        Appearance4.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.UltraLabel6.Appearance = Appearance4
        Me.UltraLabel6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel6.Location = New System.Drawing.Point(160, 16)
        Me.UltraLabel6.Name = "UltraLabel6"
        Me.UltraLabel6.Size = New System.Drawing.Size(88, 16)
        Me.UltraLabel6.TabIndex = 188
        Me.UltraLabel6.Text = "Major Holidays"
        '
        'UltraLabel5
        '
        Appearance5.ForeColor = System.Drawing.Color.Black
        Appearance5.ForeColorDisabled = System.Drawing.Color.Black
        Appearance5.TextHAlign = Infragistics.Win.HAlign.Right
        Appearance5.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.UltraLabel5.Appearance = Appearance5
        Me.UltraLabel5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel5.Location = New System.Drawing.Point(80, 72)
        Me.UltraLabel5.Name = "UltraLabel5"
        Me.UltraLabel5.Size = New System.Drawing.Size(88, 16)
        Me.UltraLabel5.TabIndex = 187
        Me.UltraLabel5.Text = "Send Notice"
        '
        'UltraLabel4
        '
        Appearance6.ForeColor = System.Drawing.Color.Black
        Appearance6.ForeColorDisabled = System.Drawing.Color.Black
        Appearance6.TextHAlign = Infragistics.Win.HAlign.Right
        Appearance6.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.UltraLabel4.Appearance = Appearance6
        Me.UltraLabel4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel4.Location = New System.Drawing.Point(80, 48)
        Me.UltraLabel4.Name = "UltraLabel4"
        Me.UltraLabel4.Size = New System.Drawing.Size(88, 16)
        Me.UltraLabel4.TabIndex = 186
        Me.UltraLabel4.Text = "Holiday Service"
        '
        'UltraLabel3
        '
        Appearance7.ForeColor = System.Drawing.Color.Black
        Appearance7.ForeColorDisabled = System.Drawing.Color.Black
        Appearance7.TextHAlign = Infragistics.Win.HAlign.Right
        Appearance7.TextVAlign = Infragistics.Win.VAlign.Middle
        Me.UltraLabel3.Appearance = Appearance7
        Me.UltraLabel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel3.Location = New System.Drawing.Point(16, 112)
        Me.UltraLabel3.Name = "UltraLabel3"
        Me.UltraLabel3.Size = New System.Drawing.Size(81, 24)
        Me.UltraLabel3.TabIndex = 184
        Me.UltraLabel3.Text = "Minor Holiday Comments:"
        '
        'UltraLabel2
        '
        Appearance8.ForeColor = System.Drawing.Color.Black
        Appearance8.ForeColorDisabled = System.Drawing.Color.Black
        Appearance8.TextHAlign = Infragistics.Win.HAlign.Left
        Appearance8.TextVAlign = Infragistics.Win.VAlign.Top
        Me.UltraLabel2.Appearance = Appearance8
        Me.UltraLabel2.Font = New System.Drawing.Font("Arial Black", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraLabel2.Location = New System.Drawing.Point(9, 160)
        Me.UltraLabel2.Name = "UltraLabel2"
        Me.UltraLabel2.Size = New System.Drawing.Size(568, 104)
        Me.UltraLabel2.TabIndex = 183
        Me.UltraLabel2.Text = "For each category (Major or Minor):" & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "IF HOLIDAY SERVICE IS NOT SELECTED, no Holid" & _
        "ay Notice can be generated for this customer." & Microsoft.VisualBasic.ChrW(13) & Microsoft.VisualBasic.ChrW(10) & "IF HOLIDAY SERVICE IS SELECTED,  " & _
        "Holiday Notice can be generated WHEN proper selection is made."
        '
        'utHolidayComments
        '
        Appearance9.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
        Appearance9.ForeColor = System.Drawing.Color.Black
        Appearance9.ForeColorDisabled = System.Drawing.Color.Black
        Me.utHolidayComments.Appearance = Appearance9
        Me.utHolidayComments.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utHolidayComments.Location = New System.Drawing.Point(106, 120)
        Me.utHolidayComments.Name = "utHolidayComments"
        Me.utHolidayComments.Size = New System.Drawing.Size(463, 21)
        Me.utHolidayComments.TabIndex = 182
        Me.utHolidayComments.Tag = ".HolidayCommentsMn"
        '
        'chkMnNotice
        '
        Me.chkMnNotice.Location = New System.Drawing.Point(312, 72)
        Me.chkMnNotice.Name = "chkMnNotice"
        Me.chkMnNotice.Size = New System.Drawing.Size(16, 16)
        Me.chkMnNotice.TabIndex = 21
        Me.chkMnNotice.Tag = ".HolidayNoticeMn"
        '
        'chkMjNotice
        '
        Me.chkMjNotice.Location = New System.Drawing.Point(200, 72)
        Me.chkMjNotice.Name = "chkMjNotice"
        Me.chkMjNotice.Size = New System.Drawing.Size(16, 16)
        Me.chkMjNotice.TabIndex = 20
        Me.chkMjNotice.Tag = ".HolidayNoticeMj"
        '
        'chkMnSvc
        '
        Me.chkMnSvc.Location = New System.Drawing.Point(312, 48)
        Me.chkMnSvc.Name = "chkMnSvc"
        Me.chkMnSvc.Size = New System.Drawing.Size(16, 16)
        Me.chkMnSvc.TabIndex = 19
        Me.chkMnSvc.Tag = ".HolidaySvcMn"
        '
        'chkMjSvc
        '
        Me.chkMjSvc.Location = New System.Drawing.Point(200, 48)
        Me.chkMjSvc.Name = "chkMjSvc"
        Me.chkMjSvc.Size = New System.Drawing.Size(16, 16)
        Me.chkMjSvc.TabIndex = 18
        Me.chkMjSvc.Tag = ".HolidaySvcMj"
        '
        'Locations
        '
        Me.Locations.Controls.Add(Me.UltraGrid2)
        Me.Locations.Controls.Add(Me.GroupBox4)
        Me.Locations.Location = New System.Drawing.Point(4, 22)
        Me.Locations.Name = "Locations"
        Me.Locations.Size = New System.Drawing.Size(586, 347)
        Me.Locations.TabIndex = 4
        Me.Locations.Tag = "ADDRESS"
        Me.Locations.Text = "Locations"
        '
        'UltraGrid2
        '
        Me.UltraGrid2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGrid2.Location = New System.Drawing.Point(0, 192)
        Me.UltraGrid2.Name = "UltraGrid2"
        Me.UltraGrid2.Size = New System.Drawing.Size(586, 155)
        Me.UltraGrid2.TabIndex = 0
        Me.UltraGrid2.Tag = "TrackingListing"
        Me.UltraGrid2.Text = "Locations"
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.utLastLocID)
        Me.GroupBox4.Controls.Add(Me.utLCustomerID)
        Me.GroupBox4.Controls.Add(Me.utAddressID)
        Me.GroupBox4.Controls.Add(Me.utLocationID)
        Me.GroupBox4.Controls.Add(Me.Label53)
        Me.GroupBox4.Controls.Add(Me.utLExt)
        Me.GroupBox4.Controls.Add(Me.Label52)
        Me.GroupBox4.Controls.Add(Me.utLAddress2)
        Me.GroupBox4.Controls.Add(Me.ucboLState)
        Me.GroupBox4.Controls.Add(Me.Label51)
        Me.GroupBox4.Controls.Add(Me.utLMap)
        Me.GroupBox4.Controls.Add(Me.Label50)
        Me.GroupBox4.Controls.Add(Me.utLDirection)
        Me.GroupBox4.Controls.Add(Me.Label49)
        Me.GroupBox4.Controls.Add(Me.utLZip)
        Me.GroupBox4.Controls.Add(Me.utLCity)
        Me.GroupBox4.Controls.Add(Me.utLAddress1)
        Me.GroupBox4.Controls.Add(Me.LUltraDate1)
        Me.GroupBox4.Controls.Add(Me.utLeMail)
        Me.GroupBox4.Controls.Add(Me.utLContact)
        Me.GroupBox4.Controls.Add(Me.utLName)
        Me.GroupBox4.Controls.Add(Me.utLPass)
        Me.GroupBox4.Controls.Add(Me.Splitter1)
        Me.GroupBox4.Controls.Add(Me.Label48)
        Me.GroupBox4.Controls.Add(Me.Label16)
        Me.GroupBox4.Controls.Add(Me.Label38)
        Me.GroupBox4.Controls.Add(Me.umLPhone1)
        Me.GroupBox4.Controls.Add(Me.Label39)
        Me.GroupBox4.Controls.Add(Me.Label40)
        Me.GroupBox4.Controls.Add(Me.umLFax)
        Me.GroupBox4.Controls.Add(Me.Label41)
        Me.GroupBox4.Controls.Add(Me.Label42)
        Me.GroupBox4.Controls.Add(Me.Label43)
        Me.GroupBox4.Controls.Add(Me.umLPhone2)
        Me.GroupBox4.Controls.Add(Me.Label44)
        Me.GroupBox4.Controls.Add(Me.Label45)
        Me.GroupBox4.Controls.Add(Me.Label46)
        Me.GroupBox4.Controls.Add(Me.Label47)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox4.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(586, 192)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        '
        'utLastLocID
        '
        Me.utLastLocID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utLastLocID.Enabled = False
        Me.utLastLocID.Location = New System.Drawing.Point(520, 15)
        Me.utLastLocID.Name = "utLastLocID"
        Me.utLastLocID.Size = New System.Drawing.Size(56, 21)
        Me.utLastLocID.TabIndex = 178
        Me.utLastLocID.Tag = ""
        '
        'utLCustomerID
        '
        Me.utLCustomerID.Location = New System.Drawing.Point(32, 64)
        Me.utLCustomerID.Name = "utLCustomerID"
        Me.utLCustomerID.Size = New System.Drawing.Size(15, 21)
        Me.utLCustomerID.TabIndex = 177
        Me.utLCustomerID.Tag = ".CUSTOMERID"
        Me.utLCustomerID.Visible = False
        '
        'utAddressID
        '
        Me.utAddressID.Location = New System.Drawing.Point(8, 64)
        Me.utAddressID.Name = "utAddressID"
        Me.utAddressID.Size = New System.Drawing.Size(15, 21)
        Me.utAddressID.TabIndex = 176
        Me.utAddressID.Tag = ".ID.view"
        Me.utAddressID.Visible = False
        '
        'utLocationID
        '
        Me.utLocationID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utLocationID.Location = New System.Drawing.Point(360, 15)
        Me.utLocationID.Name = "utLocationID"
        Me.utLocationID.Size = New System.Drawing.Size(56, 21)
        Me.utLocationID.TabIndex = 10
        Me.utLocationID.Tag = ".LocationID"
        '
        'Label53
        '
        Me.Label53.Location = New System.Drawing.Point(296, 16)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(64, 16)
        Me.Label53.TabIndex = 175
        Me.Label53.Text = "Loc. ID:"
        Me.Label53.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utLExt
        '
        Me.utLExt.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utLExt.Location = New System.Drawing.Point(202, 135)
        Me.utLExt.Name = "utLExt"
        Me.utLExt.Size = New System.Drawing.Size(85, 21)
        Me.utLExt.TabIndex = 7
        Me.utLExt.Tag = ".EXTENSION"
        '
        'Label52
        '
        Me.Label52.Location = New System.Drawing.Point(168, 138)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(32, 16)
        Me.Label52.TabIndex = 173
        Me.Label52.Text = "Ext.:"
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utLAddress2
        '
        Me.utLAddress2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utLAddress2.Location = New System.Drawing.Point(68, 64)
        Me.utLAddress2.Name = "utLAddress2"
        Me.utLAddress2.Size = New System.Drawing.Size(220, 21)
        Me.utLAddress2.TabIndex = 2
        Me.utLAddress2.Tag = ".Address2"
        '
        'ucboLState
        '
        Me.ucboLState.AutoEdit = False
        Me.ucboLState.DisplayMember = ""
        Me.ucboLState.Location = New System.Drawing.Point(68, 112)
        Me.ucboLState.Name = "ucboLState"
        Me.ucboLState.Size = New System.Drawing.Size(48, 21)
        Me.ucboLState.TabIndex = 4
        Me.ucboLState.Tag = ".STATECODE...STATE.CODE.CODE"
        Me.ucboLState.ValueMember = ""
        '
        'Label51
        '
        Me.Label51.Location = New System.Drawing.Point(448, 16)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(64, 16)
        Me.Label51.TabIndex = 11
        Me.Label51.Text = "Last LocID:"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utLMap
        '
        Me.utLMap.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utLMap.Location = New System.Drawing.Point(360, 112)
        Me.utLMap.Name = "utLMap"
        Me.utLMap.Size = New System.Drawing.Size(40, 21)
        Me.utLMap.TabIndex = 16
        Me.utLMap.Tag = ".MAPCODE"
        '
        'Label50
        '
        Me.Label50.Location = New System.Drawing.Point(293, 114)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(65, 16)
        Me.Label50.TabIndex = 167
        Me.Label50.Text = "Map Code:"
        Me.Label50.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utLDirection
        '
        Me.utLDirection.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utLDirection.Location = New System.Drawing.Point(360, 136)
        Me.utLDirection.Multiline = True
        Me.utLDirection.Name = "utLDirection"
        Me.utLDirection.Size = New System.Drawing.Size(216, 40)
        Me.utLDirection.TabIndex = 18
        Me.utLDirection.Tag = ".DIRECTION"
        '
        'Label49
        '
        Me.Label49.Location = New System.Drawing.Point(301, 136)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(56, 16)
        Me.Label49.TabIndex = 165
        Me.Label49.Text = "Direction:"
        Me.Label49.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utLZip
        '
        Me.utLZip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utLZip.Location = New System.Drawing.Point(202, 112)
        Me.utLZip.Name = "utLZip"
        Me.utLZip.Size = New System.Drawing.Size(85, 21)
        Me.utLZip.TabIndex = 5
        Me.utLZip.Tag = ".ZIPCODE"
        '
        'utLCity
        '
        Me.utLCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utLCity.Location = New System.Drawing.Point(68, 88)
        Me.utLCity.Name = "utLCity"
        Me.utLCity.Size = New System.Drawing.Size(220, 21)
        Me.utLCity.TabIndex = 3
        Me.utLCity.Tag = ".CITYNAME"
        '
        'utLAddress1
        '
        Me.utLAddress1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utLAddress1.Location = New System.Drawing.Point(68, 40)
        Me.utLAddress1.Name = "utLAddress1"
        Me.utLAddress1.Size = New System.Drawing.Size(220, 21)
        Me.utLAddress1.TabIndex = 1
        Me.utLAddress1.Tag = ".STREET"
        '
        'LUltraDate1
        '
        Me.LUltraDate1.DateTime = New Date(2004, 9, 27, 0, 0, 0, 0)
        Me.LUltraDate1.Enabled = False
        Me.LUltraDate1.Location = New System.Drawing.Point(480, 112)
        Me.LUltraDate1.Name = "LUltraDate1"
        Me.LUltraDate1.Size = New System.Drawing.Size(96, 21)
        Me.LUltraDate1.TabIndex = 17
        Me.LUltraDate1.Tag = ".CREATEDATE.view"
        Me.LUltraDate1.Value = New Date(2004, 9, 27, 0, 0, 0, 0)
        '
        'utLeMail
        '
        Me.utLeMail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utLeMail.Location = New System.Drawing.Point(359, 65)
        Me.utLeMail.Name = "utLeMail"
        Me.utLeMail.Size = New System.Drawing.Size(216, 21)
        Me.utLeMail.TabIndex = 14
        Me.utLeMail.Tag = ".email"
        '
        'utLContact
        '
        Me.utLContact.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utLContact.Location = New System.Drawing.Point(360, 40)
        Me.utLContact.Name = "utLContact"
        Me.utLContact.Size = New System.Drawing.Size(216, 21)
        Me.utLContact.TabIndex = 13
        Me.utLContact.Tag = ".CONTACT"
        '
        'utLName
        '
        Me.utLName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utLName.Location = New System.Drawing.Point(68, 17)
        Me.utLName.Name = "utLName"
        Me.utLName.Size = New System.Drawing.Size(220, 21)
        Me.utLName.TabIndex = 0
        Me.utLName.Tag = ".NAME"
        '
        'utLPass
        '
        Me.utLPass.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utLPass.Location = New System.Drawing.Point(359, 89)
        Me.utLPass.Name = "utLPass"
        Me.utLPass.Size = New System.Drawing.Size(216, 21)
        Me.utLPass.TabIndex = 15
        Me.utLPass.Tag = ".WEB_PASSWORD"
        '
        'Splitter1
        '
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Splitter1.Location = New System.Drawing.Point(3, 186)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(580, 3)
        Me.Splitter1.TabIndex = 156
        Me.Splitter1.TabStop = False
        '
        'Label48
        '
        Me.Label48.Location = New System.Drawing.Point(407, 115)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(72, 16)
        Me.Label48.TabIndex = 155
        Me.Label48.Text = "Create Date:"
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(309, 43)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(48, 16)
        Me.Label16.TabIndex = 146
        Me.Label16.Text = "Contact:"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label38
        '
        Me.Label38.Location = New System.Drawing.Point(22, 20)
        Me.Label38.Name = "Label38"
        Me.Label38.Size = New System.Drawing.Size(40, 16)
        Me.Label38.TabIndex = 145
        Me.Label38.Text = "Name:"
        Me.Label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'umLPhone1
        '
        Me.umLPhone1.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.umLPhone1.InputMask = "(###)-###-####"
        Me.umLPhone1.Location = New System.Drawing.Point(68, 136)
        Me.umLPhone1.Name = "umLPhone1"
        Me.umLPhone1.Size = New System.Drawing.Size(85, 20)
        Me.umLPhone1.TabIndex = 6
        Me.umLPhone1.Tag = ".PHONE"
        Me.umLPhone1.Text = "()--"
        '
        'Label39
        '
        Me.Label39.Location = New System.Drawing.Point(20, 112)
        Me.Label39.Name = "Label39"
        Me.Label39.Size = New System.Drawing.Size(40, 16)
        Me.Label39.TabIndex = 152
        Me.Label39.Text = "State:"
        Me.Label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label40
        '
        Me.Label40.Location = New System.Drawing.Point(140, 114)
        Me.Label40.Name = "Label40"
        Me.Label40.Size = New System.Drawing.Size(56, 16)
        Me.Label40.TabIndex = 136
        Me.Label40.Text = "Zip Code:"
        Me.Label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'umLFax
        '
        Me.umLFax.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.umLFax.InputMask = "(###)-###-####"
        Me.umLFax.Location = New System.Drawing.Point(202, 158)
        Me.umLFax.Name = "umLFax"
        Me.umLFax.Size = New System.Drawing.Size(85, 20)
        Me.umLFax.TabIndex = 9
        Me.umLFax.Tag = ".FAX"
        Me.umLFax.Text = "()--"
        '
        'Label41
        '
        Me.Label41.Location = New System.Drawing.Point(4, 136)
        Me.Label41.Name = "Label41"
        Me.Label41.Size = New System.Drawing.Size(56, 16)
        Me.Label41.TabIndex = 147
        Me.Label41.Text = "Phone 1:"
        Me.Label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label42
        '
        Me.Label42.Location = New System.Drawing.Point(168, 158)
        Me.Label42.Name = "Label42"
        Me.Label42.Size = New System.Drawing.Size(32, 16)
        Me.Label42.TabIndex = 149
        Me.Label42.Text = "Fax:"
        Me.Label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label43
        '
        Me.Label43.Location = New System.Drawing.Point(20, 42)
        Me.Label43.Name = "Label43"
        Me.Label43.Size = New System.Drawing.Size(40, 16)
        Me.Label43.TabIndex = 143
        Me.Label43.Text = "Street:"
        Me.Label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'umLPhone2
        '
        Me.umLPhone2.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.umLPhone2.InputMask = "(###)-###-####"
        Me.umLPhone2.Location = New System.Drawing.Point(68, 160)
        Me.umLPhone2.Name = "umLPhone2"
        Me.umLPhone2.Size = New System.Drawing.Size(85, 20)
        Me.umLPhone2.TabIndex = 8
        Me.umLPhone2.Tag = ".PHONE2"
        Me.umLPhone2.Text = "()--"
        '
        'Label44
        '
        Me.Label44.Location = New System.Drawing.Point(293, 89)
        Me.Label44.Name = "Label44"
        Me.Label44.Size = New System.Drawing.Size(64, 16)
        Me.Label44.TabIndex = 151
        Me.Label44.Text = "Password:"
        Me.Label44.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label45
        '
        Me.Label45.Location = New System.Drawing.Point(28, 88)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(32, 16)
        Me.Label45.TabIndex = 144
        Me.Label45.Text = "City:"
        Me.Label45.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label46
        '
        Me.Label46.Location = New System.Drawing.Point(8, 160)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(56, 16)
        Me.Label46.TabIndex = 148
        Me.Label46.Text = "Phone 2:"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label47
        '
        Me.Label47.Location = New System.Drawing.Point(316, 65)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(40, 16)
        Me.Label47.TabIndex = 150
        Me.Label47.Text = "eMail:"
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'AccountSetup
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(594, 461)
        Me.Controls.Add(Me.TabCtrl1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "AccountSetup"
        Me.Tag = "CUSTOMER"
        Me.Text = "Account Setup"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.utAcctNameRO, System.ComponentModel.ISupportInitialize).EndInit()
        Me.TabCtrl1.ResumeLayout(False)
        Me.CInfo.ResumeLayout(False)
        Me.BInfo.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.Groups.ResumeLayout(False)
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.HolidayConfig.ResumeLayout(False)
        CType(Me.utHolidayComments, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Locations.ResumeLayout(False)
        CType(Me.UltraGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.utLastLocID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utLCustomerID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utAddressID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utLocationID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utLExt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utLAddress2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucboLState, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utLMap, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utLDirection, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utLZip, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utLCity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utLAddress1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LUltraDate1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utLeMail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utLContact, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utLName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utLPass, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region




    Private Sub AccountSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim MinWinSize As System.Drawing.Size

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

        AddHandler State.KeyPress, AddressOf CBO_Search
        AddHandler State.KeyUp, AddressOf CBO_KeyUp
        AddHandler State.Leave, AddressOf CBO_Leave
        AddHandler Me.KeyUp, AddressOf Form_KeyUp
        AddHandler umskIncreaseDate.Validating, AddressOf umskDate_Validating
        AddHandler umskLastBillDate.Validating, AddressOf umskDate_Validating

        AddHandler txtTax.KeyPress, AddressOf Value_Dec_KeyPress
        AddHandler txtDisc.KeyPress, AddressOf Value_Dec_KeyPress
        'AddHandler AccountID.KeyPress, AddressOf Value_Int_KeyPress
        AddHandler CreditLimit.KeyPress, AddressOf Value_Dec_KeyPress
        AddHandler IncreaseRate.KeyPress, AddressOf Value_Dec_KeyPress
        AddHandler FinanceCharge.KeyPress, AddressOf Value_Dec_KeyPress
        AddHandler txtFuelSurch.KeyPress, AddressOf Value_Dec_KeyPress

        FillCombo(State, "CA")
        FillCombo(bState, "CA")
        FillCombo(cboBillingCycle, "")

        FillUCombo(ucboLState, "CA")
        'FillUCombo(ucboLActive, "", "", "SELECT FldCode, FldLabel FROM (SELECT '1' as ord, 'Y' AS FldCode, 'YES' AS FldLabel UNION SELECT '1' as ord, 'N' AS FldCode, 'No' AS FldLabel) DERIVEDTBL ORDER BY FldCode")
        LUltraDate1.Nullable = True
        LUltraDate1.Value = Nothing
        LUltraDate1.FormatString = "MM/dd/yyyy"



        MinWinSize.Width = email.Left + email.Width + 50

        Me.MinimumSize = MinWinSize
        chkMjNotice.Enabled = chkMjSvc.Checked
        chkMnNotice.Enabled = chkMnSvc.Checked



        Group_EnDis(False)
        EnableLocations(False)

        UltraLabel1.Text = ""
        CheckBox1.Checked = True
        CheckBox1.Checked = False

        btnTopTic.Enabled = False

    End Sub

    Private Sub AccountID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles AccountID.Leave
        Dim dtAdapter As SqlDataAdapter
        Dim dvAcct As New DataView()
        Dim dtSet2 As New DataSet()
        Dim TempQuery As String

        If btnNew.Text.ToUpper = "&CANCEL" Then Exit Sub
        If sender.Modified = False Then Exit Sub
        If sender.Text.Trim = "" Then Exit Sub
        sender.Modified = False

        LoadData(AccountID.Text)

    End Sub

    Private Sub LoadData(Optional ByVal IDValue As String = "", Optional ByVal Direction As String = "C")
        Dim dtAdapter As SqlDataAdapter
        Dim dvAcct As New DataView()
        Dim dtSet2 As New DataSet()
        Dim TempQuery As String
        Dim CritTmp, OrderText As String

        If Val(IDValue) >= 0 Then
            CritTmp = Criteria.Replace("@CID", IDValue)
        Else
            CritTmp = ""
        End If

        Select Case Direction.ToUpper
            Case "N"
                If CritTmp = "" Then
                    CritTmp = Criteria.Replace("@CID", "0")
                End If
                CritTmp = CritTmp.Replace("=", ">")
                OrderText = " ORDER BY Customer.ID ASC "
            Case "C"
                OrderText = ""
            Case "P"
                If CritTmp = "" Then
                    CritTmp = Criteria.Replace("@CID", "999999999")
                End If
                CritTmp = CritTmp.Replace("=", "<")
                OrderText = " ORDER BY Customer.ID DESC "
        End Select

        'TempQuery = PrepSelectQuery(SQLSelect, CritTmp)
        TempQuery = SQLSelect.Replace("@CONDCLAUSE", CritTmp)
        TempQuery = TempQuery.Replace("@ORDCLAUSE", OrderText)

        'Dim Time1, Time2 As Date
        'Time1 = Date.Now

        PopulateDataset2(dtAdapter, dtSet2, TempQuery)

        If dtSet2 Is Nothing Then Exit Sub
        If dtSet2.Tables Is Nothing Then Exit Sub
        If dtSet2.Tables(0) Is Nothing Then Exit Sub

        If dtSet2.Tables(0).Rows.Count = 0 Then
            If Direction.ToUpper = "C" Then
                Group_EnDis(True)
                ClearForm(TabCtrl1)
                utAcctNameRO.Text = ""
                AcctName.Focus()
                'Change for Tab Based : ClearForm(GroupBox2)
                btnNew.Text = "&Cancel"
                btnSave.Text = "&Save"
            Else
                'Message modified by Michael Pastor
                MsgBox("No Records found.", MsgBoxStyle.Exclamation, "Data Unavailable")
            End If
        Else
            Group_EnDis(False)
            btnSave.Text = "&Save"
            btnEdit.Text = "&Edit"
            btnNew.Text = "&New"

            dvAcct.Table = dtSet2.Tables(0)

            'Old Style
            '================================
            'If Direction.ToUpper = "N" Then
            '    dvAcct.RowFilter = "ID = Min(ID)"
            'ElseIf Direction.ToUpper = "P" Then
            '    dvAcct.RowFilter = "ID = Max(ID)"
            'End If

            'Time2 = Date.Now
            'MsgBox("Time1 = " & Format(Time1, "hh:mm:ss") & " - Time2 = " & Format(Time2, "hh:mm:ss"))

            FormLoad(Me, dvAcct)
            If SamePayAddr.Checked Then
                SamePayAddr_Sync()
            End If
        End If

        dtSet2 = Nothing
        Select Case TabCtrl1.SelectedIndex
            Case 3 'Groups
                LoadDataGroup()
            Case 4 ' Locations
                LoadDataLocations()
        End Select

    End Sub


    Private Sub State_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles State.SelectedIndexChanged, bState.SelectedIndexChanged, ucboLState.ValueChanged
        Select Case sender.name
            Case "State"
                If sender.Focused Then
                    City.Text = ""
                    City.Modified = False
                    Zipcode.Text = ""
                    Zipcode.Modified = False
                Else
                End If
            Case "bState"
                If sender.Focused Then
                    bCity.Text = ""
                    bCity.Modified = False
                    bZipcode.Text = ""
                    bZipcode.Modified = False
                Else
                End If
            Case "ucboLState"
                If sender.Focused Then
                    utLCity.Text = ""
                    utLCity.Modified = False
                    utLZip.Text = ""
                    utLZip.Modified = False
                Else
                End If
        End Select
    End Sub

    Private Sub Phone1_MaskValidationError(ByVal sender As System.Object, ByVal e As Infragistics.Win.UltraWinMaskedEdit.MaskValidationErrorEventArgs) Handles Phone1.MaskValidationError, Phone2.MaskValidationError, Fax.MaskValidationError, umskIncreaseDate.MaskValidationError, umskLastBillDate.MaskValidationError, umLPhone1.MaskValidationError, umLPhone2.MaskValidationError
        Dim NextCtrl As System.Windows.Forms.Control
        Dim Str As String
        Str = sender.GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw)

        If Str = "" Then
            e.RetainFocus = False
        End If
    End Sub
    Private Sub EnableLocations(ByVal status As Boolean)

        Dim TabPg As TabPage

        btnSave.Enabled = status

        If btnNew.Text.ToUpper = "&CANCEL" Then
            btnSaveNew.Enabled = True
        Else
            btnSaveNew.Enabled = False
        End If

        ' Tab Based: GroupBox2.Enabled = status
        GroupBox4.Enabled = status
        UltraGrid2.Enabled = Not status

        btnSave.Text = "&Save"
        btnPrev.Enabled = Not status
        btnNext.Enabled = Not status
    End Sub
    Private Sub Group_EnDis(ByVal status As Boolean)
        Dim TabPg As TabPage

        btnSave.Enabled = status
        GroupBox3.Enabled = Not status
        If btnNew.Text.ToUpper = "&CANCEL" Then
            GroupBox3.Enabled = True
            btnAcct.Enabled = False
            btnSaveNew.Enabled = True
        Else
            'GroupBox3.Enabled = False
            btnAcct.Enabled = True
            btnSaveNew.Enabled = False
        End If

        ' Tab Based: GroupBox2.Enabled = status
        For Each TabPg In TabCtrl1.TabPages
            If TabPg.Name = "Locations" Then
                GoTo NextFor
            End If
            TabPg.Enabled = status
NextFor:
        Next
        btnSave.Text = "&Save"
        btnPrev.Enabled = Not status
        btnNext.Enabled = Not status
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim cnt As Integer
        'Dim ID As Integer
        Dim ID As String
        Dim sqlLocs As String

        If Not CheckMinimalInput() Is Nothing Then Exit Sub

        'If MasterCustName.Text <> Name.Trim Then
        '    MsgBox("Error: Wrong Master Account Name!")
        '    MasterCustName.Text = ""
        '    MasterCustID.Text = ""
        '    Exit Sub
        'End If
        If TabCtrl1.SelectedIndex = 4 Then
            If btnNew.Text = "&New" And utAddressID.Text.Trim = "" Then Exit Sub
            sqlLocs = sqlLoc.Replace("@ACCTID", AccountID.Text.Trim)
            If EditForm(TabCtrl1.SelectedTab, sqlLocs, EditAction.ENDEDIT, cmdTrans, " WHERE Address.ID = " & utAddressID.Text) Then
                'btnEdit.Text = "&Edit"
                'Me.Text = MeText & " -- Record Updated."
                'PopulateDataset2(dtA, dtSet, SQLSelect)
                'sender.text = "&New"
                ClearForm(TabCtrl1.SelectedTab)
                LoadDataLocations()
                Group_EnDis(False)
                EnableLocations(False)
                AccountID.Enabled = True
                btnEdit.Text = "&Edit"
                btnNew.Text = "&New"
                btnSave.Text = "&Save"

            End If
        Else
            sqlLocs = SQLSelect.Replace("@CONDCLAUSE", " WHERE Customer.ID = '" & AccountID.Text & "'")
            sqlLocs = sqlLocs.Replace("@ORDCLAUSE", "")
            sqlLocs = sqlLocs.Replace("TOP 1", "")
            If SamePayAddr.Checked Then
                SamePayAddr_Sync()
            End If

            If EditForm(Me, sqlLocs, EditAction.ENDEDIT, cmdTrans, " WHERE Customer.ID = '" & AccountID.Text & "'") Then
                'Dim row As DataRow
                'Dim dtA As New SqlDataAdapter

                ID = AccountID.Text
                btnEdit.Text = "&Edit"
                btnNew.Text = "&New"
                'Me.Text = MeText & " -- Record Updated."
                'PopulateDataset2(dtA, dtSet, SQLSelect)
                LoadData(AccountID.Text.Trim)
                'sender.text = "&New"
                Group_EnDis(False)
            End If
        End If

    End Sub

    Private Function CheckMinimalInput() As Object
        CheckMinimalInput = Nothing
        If AccountID.Text.Trim = "" Then
            'Message modified by Michael Pastor
            MsgBox("Account ID remains unspecified.", MsgBoxStyle.Exclamation, "Missing Data Input")
            CheckMinimalInput = AccountID
            Exit Function
        End If
        'If Val(AccountID.Text.Trim) <= 0 Then
        If AccountID.Text.Trim = String.Empty Then
            'Message modified by Michael Pastor
            MsgBox("Account ID is invalid. Please re-enter an Account ID.", MsgBoxStyle.Exclamation, "Data Invalid")
            CheckMinimalInput = AccountID
            Exit Function
        End If
        If AccountID.Text = MasterCustID.Text Then
            'Message modified by Michael Pastor
            MsgBox("Account ID and Master ID are identical. Please re-enter the two IDs.", MsgBoxStyle.Exclamation, "Data Invalid")
            '- MsgBox("Error: AccountID and MasterID can not be the same!")
            CheckMinimalInput = AccountID
            Exit Function
        End If
        If AcctName.Text.Trim = "" Then
            'Message modified by Michael Pastor
            MsgBox("Account Name remains unspecified.", MsgBoxStyle.Exclamation, "Missing Data Input")
            '- MsgBox("Please input Account Name.")
            CheckMinimalInput = AcctName
            Exit Function
        End If
        'If Contact.Text.Trim = "" Then
        '    MsgBox("Please input Contact Name.")
        '    CheckMinimalInput = Contact
        '    Exit Function
        'End If
        If TextBox1.Text.Trim = "" Then
            'Message modified by Michael Pastor
            MsgBox("Street Address remains unspecified.", MsgBoxStyle.Exclamation, "Missing Data Input")
            '- MsgBox("Please input Street Address.")
            CheckMinimalInput = TextBox1
            Exit Function
        End If
        If City.Text.Trim = "" Then
            'Message modified by Michael Pastor
            MsgBox("City remains unspecified.", MsgBoxStyle.Exclamation, "Missing Data Input")
            '- MsgBox("Please input City Name.")
            CheckMinimalInput = City
            Exit Function
        End If
        If Zipcode.Text.Trim = "" Then
            'Message modified by Michael Pastor
            MsgBox("Zip Code remains unspecified.", MsgBoxStyle.Exclamation, "Missing Data Input")
            '- MsgBox("Please input Zip Code.")
            CheckMinimalInput = Zipcode
            Exit Function
        End If


    End Function

    Private Sub btnSaveNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveNew.Click

        Dim sqlLocs As String

        If btnNew.Text = "&New" Then
            MessageBox.Show("You have to be in 'New' mode to be able to use this button.")
            Exit Sub
        End If
        If TabCtrl1.SelectedIndex = 4 Then
            If btnNew.Text = "&New" And utAddressID.Text.Trim = "" Then Exit Sub
            sqlLocs = sqlLoc.Replace("@ACCTID", AccountID.Text.Trim)
            If EditForm(TabCtrl1.SelectedTab, sqlLocs, EditAction.ENDEDIT, cmdTrans, " WHERE Address.ID = " & utAddressID.Text) Then
                Dim row As DataRow
                Dim dtA As New SqlDataAdapter

                'btnEdit.Text = "&Edit"
                'Me.Text = MeText & " -- Record Updated."
                'PopulateDataset2(dtA, dtSet, SQLSelect)
                'sender.text = "&New"
                ClearForm(TabCtrl1.SelectedTab)
                EnableLocations(True)
                'AccountID.Focus()
                btnSave.Text = "&Save"
            End If
        Else
            sqlLocs = SQLSelect.Replace("@CONDCLAUSE", " WHERE Customer.ID = '" & AccountID.Text & "'")
            sqlLocs = sqlLocs.Replace("@ORDCLAUSE", "")
            sqlLocs = sqlLocs.Replace("TOP 1", "")
            If EditForm(Me, SQLSelect, EditAction.ENDEDIT, cmdTrans, " WHERE Customer.ID = '" & AccountID.Text & "'") Then
                Dim row As DataRow
                Dim dtA As New SqlDataAdapter

                'btnEdit.Text = "&Edit"
                'Me.Text = MeText & " -- Record Updated."
                'PopulateDataset2(dtA, dtSet, SQLSelect)
                'LoadData(AccountID.Text.Trim)
                'sender.text = "&New"
                ClearForm(Me)
                Group_EnDis(True)
                AccountID.Focus()
                btnSave.Text = "&Save"
            End If
        End If

    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        ' Lock Records
        Dim sqlLocs As String

        If btnNew.Text = "&Cancel" Then
            'Message modified by Michael Pastor
            MsgBox("You are in 'New' mode. Cancel or Save your current job first.", MsgBoxStyle.Exclamation, "Current Mode: New")
            '- MessageBox.Show("You are in 'New' mode. Cancel or Save your current job first.")
            Exit Sub
        End If
        If AccountID.Text.Trim = "" Then Exit Sub
        If sender.text.toupper = "&EDIT" Then
            If TabCtrl1.SelectedIndex = 4 Then
                If utAddressID.Text.Trim = "" Then Exit Sub
                sqlLocs = sqlLoc.Replace("@ACCTID", AccountID.Text.Trim)
                If EditForm(TabCtrl1.SelectedTab, PrepSelectQuery(sqlLocs, " AND Address.ID = " & utAddressID.Text.Trim), EditAction.START, cmdTrans) Then
                    sender.text = "&Cancel"
                    'AccountID.Enabled = False
                    Group_EnDis(True)
                    'tabctrl1.TabPages(4).Enabled = True
                    EnableLocations(True)
                    'btnSaveNew.Enabled = False
                End If
            Else
                sqlLocs = SQLSelect.Replace("@CONDCLAUSE", " WHERE Customer.ID = '" & AccountID.Text & "'")
                sqlLocs = sqlLocs.Replace("@ORDCLAUSE", "")
                sqlLocs = sqlLocs.Replace("TOP 1", "")
                If EditForm(Me, sqlLocs, EditAction.START, cmdTrans, " WHERE Customer.ID = '" & AccountID.Text & "'") Then
                    ' PrepSelectQuery(SQLSelect, " AND Customer.ID = " & AccountID.Text)
                    sender.text = "&Cancel"
                    'AccountID.Enabled = False
                    Group_EnDis(True)
                    'btnSaveNew.Enabled = False
                End If
            End If
        Else
            If TabCtrl1.SelectedIndex = 4 Then
                If utAddressID.Text.Trim = "" Then Exit Sub
                sqlLocs = sqlLoc.Replace("@ACCTID", AccountID.Text.Trim)
                If EditForm(TabCtrl1.SelectedTab, PrepSelectQuery(sqlLocs, " AND Address.ID = " & utAddressID.Text.Trim), EditAction.CANCEL, cmdTrans) Then
                    sender.text = "&Edit"
                    'LoadData(AccountID.Text)
                    LoadDataLocations()
                    'AccountID.Enabled = True
                    Group_EnDis(False)
                    EnableLocations(False)
                    'btnSaveNew.Enabled = True
                    'FormLoad(Me, dvCompany)
                End If
            Else
                sqlLocs = SQLSelect.Replace("@CONDCLAUSE", " WHERE Customer.ID = '" & AccountID.Text & "'")
                sqlLocs = sqlLocs.Replace("@ORDCLAUSE", "")
                sqlLocs = sqlLocs.Replace("TOP 1", "")
                If EditForm(Me, sqlLocs, EditAction.CANCEL, cmdTrans, " WHERE Customer.ID = '" & AccountID.Text & "'") Then
                    sender.text = "&Edit"
                    LoadData(AccountID.Text.Trim)
                    'AccountID.Enabled = True
                    Group_EnDis(False)
                    'btnSaveNew.Enabled = True
                    'FormLoad(Me, dvCompany)
                End If
            End If
        End If
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        'UltraGrid1.DeleteSelectedRows()
        If btnEdit.Text = "&Cancel" Then
            'Message modified by Michael Pastor
            MsgBox("You are in 'Edit' mode. Cancel or Save your current job first.", MsgBoxStyle.Exclamation, "Current Mode: Edit")
            Exit Sub
        End If
        If sender.text = "&New" Then
            If TabCtrl1.SelectedIndex = 4 Then
                ClearForm(TabCtrl1.SelectedTab)
                utLCustomerID.Text = AccountID.Text
                sender.text = "&Cancel"
                btnSave.Text = "&Save"
                'Group_EnDis(True)
                EnableLocations(True)
                AccountID.Enabled = False
                utLName.Focus()
            Else
                ClearForm(Me)
                sender.text = "&Cancel"
                btnSave.Text = "&Save"
                Group_EnDis(True)
                AccountID.Focus()
            End If
        Else
            sender.text = "&New"
            btnSave.Text = "&Update"
            If TabCtrl1.SelectedIndex = 4 Then
                AccountID.Enabled = True
                EnableLocations(False)
            Else
                Group_EnDis(False)
            End If

        End If
    End Sub
    'ORIGINAL - CORRECT
    'Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
    '    If AccountID.Text.Trim = "" Then Exit Sub

    '    Select Case TabCtrl1.SelectedIndex
    '        Case 4 ' Locations
    '            If utAddressID.Text.Trim = "" Then Exit Sub
    '            'Message modified by Michael Pastor
    '            If MessageBox.Show("Are you sure you want to DELETE the current location?", "Data Deletion", MsgBoxStyle.YesNo, MessageBoxIcon.Exclamation) = MsgBoxResult.Yes Then
    '                Dim sqlDel = "Update " & AppTblPath & "Address Set Active = 'N' where ID = " & utAddressID.Text.Trim
    '                Dim sqlDel2 = "Update " & TRCTblPath & "CourierLabels Set Void = 'T' where ( (FromCustID = '" & AccountID.Text.Trim & "' and fromlocid = '" & utLocationID.Text & "') OR (ToCustID = '" & AccountID.Text.Trim & "' and ToLocID = '" & utLocationID.Text & "') ) AND ParcelType like '%POUCH%' "
    '                If ExecuteQuery(sqlDel) = False Then
    '                    'Message modified by Michael Pastor
    '                    MsgBox("Unable to delete selected location.", MsgBoxStyle.Exclamation, "Delete/Void Error")
    '                    '- MsgBox("Error Deleting the loaction!")
    '                    Exit Sub
    '                End If
    '                If TRCTblPath <> "" Then
    '                    If ExecuteQuery(sqlDel2) = False Then
    '                        'Message modified by Michael Pastor
    '                        MsgBox("Unable to void selected Pouch Label.", MsgBoxStyle.Exclamation, "Delete/Void Error")
    '                        '- MsgBox("Error Voiding the Pouch Labels!")
    '                        Exit Sub
    '                    End If
    '                End If
    '                LoadDataLocations()
    '            End If

    '    End Select

    'End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        If AccountID.Text.Trim = "" Then Exit Sub

        Select Case TabCtrl1.SelectedIndex
            Case 4 ' Locations
                If utAddressID.Text.Trim = "" Then Exit Sub
                'Message modified by Michael Pastor

                ''Karina - display info on Location Delete
                'Dim Title1 As String = "Barcodes"
                'Dim Title2 As String = "Weight-Plans"
                'Dim Title3 As String = "Locations"
                'Dim HasErr As Boolean
                'Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
                'Dim SelectSQL1, SelectSQL2, SelectSQL3, CondSQL1, CondSQL2, CondSQL3 As String
                'Dim dtView1 As New DataView
                'Dim dtView2 As New DataView
                'Dim dtView3 As New DataView
                'Dim dtAdapter1 As New SqlDataAdapter
                'Dim dtAdapter2 As New SqlDataAdapter
                'Dim dtAdapter3 As New SqlDataAdapter
                'Dim dtSet1 As New DataSet
                'Dim dtSet2 As New DataSet
                'Dim dtSet3 As New DataSet

                ''Display Barcodes
                'SelectSQL1 = "Select * FROM " & TRCTblPath & "CourierLabels"
                'CondSQL1 = " Where (FromCustID = '" & AccountID.Text & "' OR ToCustId = '" & AccountID.Text & "') order by TrackingNum"
                'SelectSQL1 = SelectSQL1 & CondSQL1

                ''Display Weigh-Plans
                'SelectSQL2 = "Select * FROM " & WEIGHTTblPath & "MANIFESTS"
                'CondSQL2 = " Where (NAME like '%" & utLocationID.Text & "%' AND AccountId = '" & AccountID.Text & "') order by Name"
                'SelectSQL2 = SelectSQL2 & CondSQL2

                ''Display Locations
                'SelectSQL3 = "Select * FROM " & AppTblPath & "ADDRESS"
                'CondSQL3 = " Where (LocationID like '%" & utLocationID.Text & "%' AND CustomerId = '" & AccountID.Text & "') order by LocationID"
                'SelectSQL3 = SelectSQL3 & CondSQL3


                'PopulateDataset2(dtAdapter1, dtSet1, SelectSQL1)
                'PopulateDataset2(dtAdapter2, dtSet2, SelectSQL2)
                'PopulateDataset2(dtAdapter3, dtSet3, SelectSQL3)

                'dtView1.Table = dtSet1.Tables(0)
                'dtView2.Table = dtSet2.Tables(0)
                'dtView3.Table = dtSet3.Tables(0)
                'If (dtView1.Table.Rows.Count > 0 Or dtView2.Table.Rows.Count > 0 Or dtView3.Table.Rows.Count > 0) Then
                '    Dim ListInfo As New ListingInfo
                '    ListInfo.dsList1 = dtSet1
                '    ListInfo.dsList2 = dtSet2
                '    ListInfo.dsList3 = dtSet3


                '    ListInfo.UltraGrid1.Text = Title1
                '    ListInfo.UltraGrid2.Text = Title2
                '    ListInfo.UltraGrid3.Text = Title3
                '    ListInfo.ShowDialog()
                '    If ListInfo.DialogResult <> DialogResult.OK Then Exit Sub
                '    Try
                '        Dim cnt As Integer
                '        cnt = ListInfo.UltraGrid1.Rows.Count
                '    Catch Err As System.Exception
                '        ListInfo = Nothing
                '        sender.Focus()
                '        HasErr = True
                '        Exit Try
                '    Catch Err2 As System.NullReferenceException
                '        ListInfo = Nothing
                '        sender.Focus()
                '        HasErr = True
                '        Exit Try
                '    Catch osqlexception As SqlException
                '        MsgBox("SQL_Error: " & osqlexception.Message, MsgBoxStyle.Critical, "Critical Error")
                '        ListInfo = Nothing
                '        sender.Focus()
                '        Exit Try
                '    Finally
                '        If HasErr = False Then
                '            ugRow = ListInfo.UltraGrid1.ActiveRow
                '            MasterCustID.Text = ugRow.Cells("ID").Text
                '            MasterCustName.Text = ugRow.Cells("Name").Text
                '            ListInfo = Nothing
                '        End If
                '    End Try
                'End If
                ''Karina - END - display info on Location Delete


                '''Count the # of * in locationID
                'Dim starLocID As String
                'Dim starSQL As String
                'Dim count As Integer
                'Dim dtAdapter1 As New SqlDataAdapter
                'Dim dtSet1 As New DataSet
                'Dim dtView1 As New DataView
                'Dim value As String

                'starLocID = "SELECT COUNT(" & utAddressID.Text & ") As CountLocID FROM " & AppTblPath & "Address where locationID like '%" & utLocationID.Text & "' AND CustomerID = " & AccountID.Text & ""
                ''count = Execute
                'PopulateDataset2(dtAdapter1, dtSet1, starLocID)
                'dtView1.Table = dtSet1.Tables(0)
                'value = dtSet1.Tables(0).Rows(0).


                '''END - Count the # of * in locationID

                'If MessageBox.Show("Are you sure you want to DELETE the current location?", "Data Deletion", MsgBoxStyle.YesNo, MessageBoxIcon.Exclamation) = MsgBoxResult.Yes Then
                '    Dim sqlDel = "Update " & AppTblPath & "Address Set Active = 'N' where ID = " & utAddressID.Text.Trim
                '    Dim sqlDel2 = "Update " & TRCTblPath & "CourierLabels Set Void = 'T' where ( (FromCustID = '" & AccountID.Text.Trim & "' and fromlocid = '" & utLocationID.Text & "') OR (ToCustID = '" & AccountID.Text.Trim & "' and ToLocID = '" & utLocationID.Text & "') ) AND ParcelType like '%POUCH%' "
                '    If ExecuteQuery(sqlDel) = False Then
                '        'Message modified by Michael Pastor
                '        MsgBox("Unable to delete selected location.", MsgBoxStyle.Exclamation, "Delete/Void Error")
                '        '- MsgBox("Error Deleting the loaction!")
                '        Exit Sub
                '    End If
                '    If TRCTblPath <> "" Then
                '        If ExecuteQuery(sqlDel2) = False Then
                '            'Message modified by Michael Pastor
                '            MsgBox("Unable to void selected Pouch Label.", MsgBoxStyle.Exclamation, "Delete/Void Error")
                '            '- MsgBox("Error Voiding the Pouch Labels!")
                '            Exit Sub
                '        End If
                '    End If
                '    LoadDataLocations()
                'End If

                ''END - Karina - display info on Location Delete

                'Original
                '   If MessageBox.Show("Are you sure you want to DELETE the current location?", "Data Deletion", MsgBoxStyle.YesNo, MessageBoxIcon.Exclamation) = MsgBoxResult.Yes Then
                If MessageBox.Show("Are you sure you want to DELETE the current location?", "Data Deletion", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = MsgBoxResult.Yes Then
                    Dim sqlDel = "Update " & AppTblPath & "Address Set Active = 'N' where ID = " & utAddressID.Text.Trim
                    Dim sqlDel2 = "Update " & TRCTblPath & "CourierLabels Set Void = 'T' where ( (FromCustID = '" & AccountID.Text.Trim & "' and fromlocid = '" & utLocationID.Text & "') OR (ToCustID = '" & AccountID.Text.Trim & "' and ToLocID = '" & utLocationID.Text & "') ) AND ParcelType like '%POUCH%' "
                    If ExecuteQuery(sqlDel) = False Then
                        'Message modified by Michael Pastor
                        MsgBox("Unable to delete selected location.", MsgBoxStyle.Exclamation, "Delete/Void Error")
                        '- MsgBox("Error Deleting the loaction!")
                        Exit Sub
                    End If
                    If TRCTblPath <> "" Then
                        If ExecuteQuery(sqlDel2) = False Then
                            'Message modified by Michael Pastor
                            MsgBox("Unable to void selected Pouch Label.", MsgBoxStyle.Exclamation, "Delete/Void Error")
                            '- MsgBox("Error Voiding the Pouch Labels!")
                            Exit Sub
                        End If
                    End If
                    LoadDataLocations()
                End If

        End Select

    End Sub

    'Original Aly's code
    Private Sub btnAcct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAcct.Click
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow

        SelectSQL = "Select * From " & AppTblPath & "Customer order by Name"

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
                    'AcctName.Text = ugRow.Cells("Name").Text
                    AccountID.Text = ugRow.Cells("ID").Text
                    Srch = Nothing
                    AccountID.Modified = True
                    Dim ev As New System.EventArgs
                    AccountID_Leave(AccountID, ev)
                End If
            End Try
        End If
    End Sub

    Private Sub Value_Int_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles AccountID.KeyPress, MasterCustID.KeyPress
        Dim s As String = sender.Text
        If s.Length < 4 Then
            If IsNumeric(e.KeyChar) = False And Asc(e.KeyChar) <> Keys.Back And e.KeyChar <> "-" Then
                e.Handled = True
            End If
        End If
    End Sub

    Private Sub btnPrev_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrev.Click
        'LoadData(Val(AccountID.Text), "P")
        LoadData(AccountID.Text.Trim, "P")
    End Sub

    Private Sub btnNext_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNext.Click
        LoadData(AccountID.Text.Trim, "N")
    End Sub

    Private Sub SamePayAddr_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SamePayAddr.CheckedChanged
        Dim Ctrl As Control, Ctrl2 As Control

        If SamePayAddr.Checked Then
            SamePayAddr_Sync()
        End If
        GroupBox2.Enabled = Not SamePayAddr.Checked
    End Sub

    Private Sub SamePayAddr_Sync()
        bName.Text = AcctName.Text
        bStreet.Text = TextBox1.Text.Trim
        bAddress2.Text = Address2.Text.Trim
        bCity.Text = City.Text
        bState.SelectedIndex = State.SelectedIndex
        bZipcode.Text = Zipcode.Text
        bPhone1.Text = Phone1.Text
        bPhone2.Text = Phone2.Text
        bFax.Text = Fax.Text
        bEmail.Text = email.Text
    End Sub

    Private Sub chkMjSvc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMjSvc.CheckedChanged
        chkMjNotice.Enabled = chkMjSvc.Checked
        If chkMjSvc.Checked = False Then
            chkMjNotice.Checked = False
        End If
    End Sub

    Private Sub chkMnSvc_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkMnSvc.CheckedChanged
        chkMnNotice.Enabled = chkMnSvc.Checked
        If chkMnSvc.Checked = False Then
            chkMnNotice.Checked = False
        End If
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If Not btnNew.Text = "&Cancel" Then
            If CheckBox1.Checked = True Then
                UltraLabel1.Text = "Active"
                UltraLabel1.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                UltraLabel1.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.False
                UltraLabel1.Enabled = True

            Else

                If CheckBox1.Focus = True Then
                    ''MsgBox("Account can not be inactivated until all billing is finalized!", MsgBoxStyle.Excl, "Account Inactivation!")
                    Dim strUserPassword As String

                    strUserPassword = InputBox("Account can not be inactivated until all billing is finalized! Please enter your password to inactivate the account!", "Account Status Confirmation")
                    If strUserPassword = "iamsure" Then
                        UltraLabel1.Text = "Inactive"
                        UltraLabel1.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                        UltraLabel1.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
                        UltraLabel1.Enabled = False
                    ElseIf strUserPassword <> "iamsure" And strUserPassword <> "" Then
                        MsgBox("Incorrect password provided! Account stays active!", MsgBoxStyle.Exclamation, "Account Status")
                        UltraLabel1.Text = "Active"
                        UltraLabel1.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                        UltraLabel1.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.False
                        UltraLabel1.Enabled = True
                        CheckBox1.Checked = True
                    ElseIf strUserPassword = "" Then
                        UltraLabel1.Text = "Active"
                        UltraLabel1.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                        UltraLabel1.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.False
                        UltraLabel1.Enabled = True
                        CheckBox1.Checked = True
                    End If
                Else
                    UltraLabel1.Text = "Inactive"
                    UltraLabel1.Appearance.FontData.Bold = Infragistics.Win.DefaultableBoolean.True
                    UltraLabel1.Appearance.FontData.Italic = Infragistics.Win.DefaultableBoolean.True
                    UltraLabel1.Enabled = False
                End If
            End If
        End If
    End Sub

    Private Sub TabCtrl1_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles TabCtrl1.Click

        Dim bActive As Boolean = False

        Select Case TabCtrl1.SelectedIndex
            Case 0 'Info
                bActive = False
            Case 1 ' Billing
                bActive = False
            Case 2 ' Groups
                bActive = False
                LoadDataGroup()
            Case 3 ' Holidays
                bActive = False
            Case 4 ' Locations
                LoadDataLocations()
                If utLName.TextLength > 0 Then bActive = True Else bActive = False
        End Select

        btnDelete.Enabled = bActive
        btnTopTic.Enabled = bActive

    End Sub

    Private Sub LoadDataGroup()
        Dim sqlGroup As String
        Dim dtAdapter As SqlDataAdapter
        Dim dsGroup As DataSet
        Dim HidCols() As String = {"gcm.ClubID"}
        Dim SummFld As String
        Dim i As Int16

        If AccountID.Text.Trim = "" Then Exit Sub

        'sqlGroup = "Select gcm.GroupID, g.Group_Name, gcm.ClubID, gc.Club_Name From " & AppTblPath & "GroupClubMembers gcm left outer join " & AppTblPath & " Groups g on gcm.GroupID = g.GroupID left outer join " & AppTblPath & " GroupClubs gc on gcm.ClubID = gc.ClubID Where gcm.MemberID = " & AccountID.Text & " Order by g.Group_Name, gc.Club_Name "
        sqlGroup = "Select gcm.GroupID, g.Group_Name, gcm.ClubID, gc.Club_Name From " & AppTblPath & "GroupClubMembers gcm left outer join " & AppTblPath & " Groups g on gcm.GroupID = g.GroupID left outer join " & AppTblPath & " GroupClubs gc on gcm.ClubID = gc.ClubID Where gcm.MemberID = '" & AccountID.Text & "' Order by g.Group_Name, gc.Club_Name "

        PopulateDataset2(dtAdapter, dsGroup, sqlGroup)

        For i = 0 To dsGroup.Tables(0).Columns.Count - 1
            dsGroup.Tables(0).Columns(i).ReadOnly = True
        Next
        'dsgroup.Tables(0).Columns(0).ReadOnly = False

        FillUltraGrid(UltraGrid1, dsGroup, -1, HidCols, 0)
        'UltraGrid1.DataSource = dsgroup
        'UGLoadLayout(Me, UltraGrid1, 1)
        UltraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True
        UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect
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

        SummFld = "Club_Name"
        UltraGrid1.DisplayLayout.Bands(0).Summaries.Add(SummFld, Infragistics.Win.UltraWinGrid.SummaryType.Count, UltraGrid1.DisplayLayout.Bands(0).Columns(SummFld), Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn)
        UltraGrid1.DisplayLayout.Bands(0).Summaries(SummFld).Appearance.TextHAlign = Infragistics.Win.HAlign.Right
        UltraGrid1.DisplayLayout.Bands(0).SummaryFooterCaption = ""
        UltraGrid1.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False


        UltraGrid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus

        UltraGrid1.DisplayLayout.GroupByBox.Hidden = False
        UltraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid, False, False)

        dsGroup.Dispose()
        dsGroup = Nothing

    End Sub

    Private Sub LoadDataLocations()
        Dim sqlLocs As String
        Dim dtAdapter As SqlDataAdapter
        Dim dsLocs As DataSet
        Dim HidCols() As String = {"CustomerID", "ID"}
        Dim SummFld As String
        Dim i As Int16

        If AccountID.Text.Trim = "" Then Exit Sub

        sqlLocs = sqlLoc.Replace("@ACCTID", AccountID.Text.Trim)

        ClearForm(TabCtrl1.TabPages(4))

        PopulateDataset2(dtAdapter, dsLocs, sqlLocs)

        For i = 0 To dsLocs.Tables(0).Columns.Count - 1
            dsLocs.Tables(0).Columns(i).ReadOnly = True
        Next
        'dsgroup.Tables(0).Columns(0).ReadOnly = False

        FillUltraGrid(UltraGrid2, dsLocs, -1, HidCols, 0)
        'Ultragrid2.DataSource = dsgroup
        'UGLoadLayout(Me, Ultragrid2, 1)
        UltraGrid2.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True
        UltraGrid2.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.CellSelect
        UltraGrid2.DisplayLayout.AutoFitColumns = False
        For i = 0 To UltraGrid2.DisplayLayout.Bands(0).Columns.Count - 1
            UltraGrid2.DisplayLayout.Bands(0).Columns(i).TabStop = True
            UltraGrid2.DisplayLayout.Bands(0).Columns(i).CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Next

        UltraGrid2.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.True

        'Ultragrid2.DisplayLayout.Bands(0).Summaries.Add("Mileage", Infragistics.Win.UltraWinGrid.SummaryType.Sum, Ultragrid2.DisplayLayout.Bands(0).Columns("Mileage"), Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn)
        'Ultragrid2.DisplayLayout.Bands(0).Summaries("Mileage").Appearance.TextHAlign = Infragistics.Win.HAlign.Right
        'Ultragrid2.DisplayLayout.Bands(0).SummaryFooterCaption = ""
        'Ultragrid2.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False

        SummFld = "LocationID"
        UltraGrid2.DisplayLayout.Bands(0).Summaries.Add(SummFld, Infragistics.Win.UltraWinGrid.SummaryType.Count, UltraGrid2.DisplayLayout.Bands(0).Columns(SummFld), Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn)
        UltraGrid2.DisplayLayout.Bands(0).Summaries(SummFld).Appearance.TextHAlign = Infragistics.Win.HAlign.Right
        UltraGrid2.DisplayLayout.Bands(0).SummaryFooterCaption = ""
        UltraGrid2.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False


        UltraGrid2.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus

        UltraGrid2.DisplayLayout.GroupByBox.Hidden = False
        UltraGrid2.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        UltraGrid2.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid, False, False)

        dsLocs.Dispose()
        dsLocs = Nothing

        Dim row As DataRow
        'sqlLocs = "Select isnull(Max(LocationID), '') as MaxLocID From " & AppTblPath & "Address where ACTIVE = 'Y' AND CUSTOMERID = " & AccountID.Text.Trim
        sqlLocs = "Select isnull(Max(LocationID), '') as MaxLocID From " & AppTblPath & "Address where ACTIVE = 'Y' AND CUSTOMERID = '" & AccountID.Text.Trim & "'"

        utLastLocID.Text = ""

        If ReturnRowByID(AccountID.Text, row, AppTblPath & "Address", "", "ID", sqlLocs) Then
            utLastLocID.Text = row("MaxLocID")
            row.Delete()
        End If
        row = Nothing

    End Sub
    Private Sub UltraGrid2_AfterRowActivate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraGrid2.AfterRowActivate
        FormLoadFromGrid(TabCtrl1.TabPages(4), sender)
        If utLName.TextLength > 0 Then btnTopTic.Enabled = True Else btnTopTic.Enabled = False
        'If Not UltraGrid1.ActiveRow.ListObject Is Nothing Then
        'utBranch.Text = UltraGrid1.ActiveRow.Cells("Branch").Value
        'MsgBox("Hey!")

        'End If
        'm_row = UltraGrid1.ActiveRow
        'If Not m_row Is Nothing Then
        '    If Not m_row.ListObject Is Nothing Then
        '        UltraGrid1.ActiveRow.Update()
        '    End If
        'End If
    End Sub

    Private Sub UltraGrid2_AfterRowUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.RowEventArgs) Handles UltraGrid2.AfterRowUpdate
        'If Not m_row Is Nothing Then
        FormLoadFromGrid(TabCtrl1.TabPages(4), UltraGrid1)
        'End If
    End Sub

    Private Sub UltraGrid2_EnabledChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles UltraGrid2.EnabledChanged
        If sender.enabled And UltraGrid1.Rows.Count > 0 Then
            'FormLoadFromGrid(Me, sender)
        End If
    End Sub

    Private Sub bCity_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles bCity.KeyUp, utLCity.KeyUp, City.KeyUp
        Dim TableName As String

        If e.KeyCode = Keys.Enter Then Exit Sub

        TableName = AppTblPath & "City"
        TypeAhead(sender, e, TableName, "Name", "")

        'TypeAhead(sender, e, "City", "Name", "AND StateCode = '" & GetNextControl(sender, True).Text & "'")
        'sender.modified = True
    End Sub

    Private Sub utLCity_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utLCity.Leave, City.Leave, bCity.Leave
        Dim row As DataRow
        Dim FldName As String
        Dim gZip, gCity As Control
        Dim gState As Object
        FldName = "Name"

        Select Case sender.name
            Case "utLCity"
                gZip = utLZip
                gState = ucboLState
                gCity = utLCity
            Case "City"
                gZip = Zipcode
                gState = State
                gCity = City
            Case "bCity"
                gZip = bZipcode
                gState = bState
                gCity = bCity
            Case Else
                'Message modified by Michael Pastor
                MsgBox("Wrong Control.", MsgBoxStyle.Exclamation, "Data Invalid")
                'MsgBox("Wrong Control!")
                Exit Sub
        End Select

        If sender.text.trim = "" Then
            sender.modified = False
            sender.Text = ""
            gZip.Text = ""
        ElseIf SearchOnLeave(sender, gZip, AppTblPath & "City", "Zipcode", FldName, "*", "Cities") Then
            If ReturnRowByID(gZip.Text, row, AppTblPath & "City", , "Zipcode") Then
                If TypeOf gState Is ComboBox Then
                    gState.SelectedValue = row("StateCode")
                Else
                    gState.value = row("StateCode")
                End If
                gZip.Text = row("ZipCode")
                gCity.Text = row("Name")
                'ucboAcctBillingCycle.Value = row("BCycleCode")
            End If
            row.Delete()
            row = Nothing
        End If

    End Sub

    Private Sub bZipcode_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles bZipcode.KeyPress, utLZip.KeyPress, Zipcode.KeyPress
        If IsNumeric(e.KeyChar) = False And Asc(e.KeyChar) <> Keys.Back Then
            e.Handled() = True
        End If
    End Sub

    Private Sub utLZip_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utLZip.Leave, Zipcode.Leave, bZipcode.Leave
        Dim row As DataRow
        Dim FldName As String
        Dim gZip, gCity As Control
        Dim gState As Object

        FldName = "ZIPCODE"

        Select Case sender.name
            Case "utLZip"
                gZip = utLZip
                gState = ucboLState
                gCity = utLCity
            Case "Zipcode"
                gZip = Zipcode
                gState = State
                gCity = City
            Case "bZipcode"
                gZip = bZipcode
                gState = bState
                gCity = bCity
            Case Else
                'Message modified by Michael Pastor
                MsgBox("Wrong Control.", MsgBoxStyle.Exclamation, "Data Invalid")
                'MsgBox("Wrong Control!")
                Exit Sub
        End Select

        If sender.text.trim = "" Then
            sender.modified = False
            sender.Text = ""
            gCity.Text = ""
        ElseIf SearchOnLeave(sender, gZip, AppTblPath & "City", "Zipcode", FldName, "*", "Cities") Then
            If ReturnRowByID(gZip.Text, row, AppTblPath & "City", , "Zipcode") Then
                If TypeOf gState Is ComboBox Then
                    gState.SelectedValue = row("StateCode")
                Else
                    gState.value = row("StateCode")
                End If
                gZip.Text = row("ZipCode")
                gCity.Text = row("Name")
                'ucboAcctBillingCycle.Value = row("BCycleCode")
            End If
            row.Delete()
            row = Nothing
        End If
    End Sub

    'Karina 06.16.2005, I commented here code and added AccountSetup_Closing
    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        'If Not cmdTrans Is Nothing Then
        '    If EditForm(Me, SQLSelect, EditAction.CANCEL, cmdTrans) Then
        '        Group_EnDis(False)
        '        sender.text = "&Edit"
        '    Else
        '        'Exit Sub
        '    End If

        'End If
        Me.Close()
    End Sub
    'Karina 06.16.2005
    Private Sub AccountSetup_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Dim sqllocs As String

        If btnEdit.Text = "&Cancel" Or btnNew.Text = "&Cancel" Then
            'Message modified by Michael Pastor
            If MessageBox.Show("Data is not saved! Are you sure you want to exit?", "Data Not Saved", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = MsgBoxResult.No Then
                e.Cancel = True
                Exit Sub
            End If
        End If

        If Not cmdTrans Is Nothing Then
            sqllocs = SQLSelect.Replace("@CONDCLAUSE", " WHERE Customer.ID = '" & AccountID.Text & "'")
            sqllocs = sqllocs.Replace("@ORDCLAUSE", "")
            sqllocs = sqllocs.Replace("TOP 1", "")
            If EditForm(Me, sqllocs, EditAction.CANCEL, cmdTrans, " WHERE Customer.ID = '" & AccountID.Text & "'") Then
                'UltraGrid1.Enabled = True
                Group_EnDis(False)
                sender.text = "&Edit"
            Else
                'Exit Sub
            End If

        End If
        'UGSaveLayout(Me, UltraGrid1, 1)

    End Sub

    Private Sub btnMasterAcct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnMasterAcct.Click
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim Title As String

        SelectSQL = "Select * FROM " & AppTblPath & "Customer order by Name"
        Title = "Master Account"

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
                    MasterCustID.Text = ugRow.Cells("ID").Text
                    MasterCustName.Text = ugRow.Cells("Name").Text
                    Srch = Nothing
                End If
            End Try
        End If

    End Sub
    Private Sub MasterCustName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MasterCustName.KeyUp
        TypeAhead(sender, e, AppTblPath & "Customer", "Name", "")
    End Sub
    Private Sub MasterCustName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MasterCustName.Leave
        Dim row As DataRow
        If sender.text.trim = "" Then
            MasterCustID.Text = ""
            sender.text = ""
        ElseIf SearchOnLeave(sender, MasterCustID, AppTblPath & "Customer", , , "*", "") Then  'RapidTblPath & 
            If ReturnRowByID(MasterCustID.Text, row, AppTblPath & "Customer") Then ' RapidTblPath
                MasterCustID.Text = row("ID")
                MasterCustName.Text = row("Name")
                row = Nothing
            End If
        End If

    End Sub
    Private Sub MasterCustID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles MasterCustID.Leave
        Dim row As DataRow
        If sender.text.trim = "" Then
            MasterCustName.Text = ""
            sender.text = ""
        ElseIf SearchOnLeave(sender, MasterCustName, AppTblPath & "Customer", , , "*", "") Then  'RapidTblPath & 
            If ReturnRowByID(MasterCustName.Text, row, AppTblPath & "Customer") Then ' RapidTblPath
                MasterCustID.Text = row("ID")
                MasterCustName.Text = row("Name")
                row = Nothing
            End If
        End If

    End Sub
    Private Sub MasterCustID_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MasterCustID.KeyUp
        TypeAhead(sender, e, AppTblPath & "Customer", "ID", "")
    End Sub

    Private Sub btnTopTic_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTopTic.Click

        If utLName.TextLength > 0 Then

            Dim sTab As String = "          "
            Dim TopTicReport As New TopTic1Form

            With TopTicReport

                .AccountNumber = AccountID.Text
                .Address = RTrim(utLName.Text) & sTab & RTrim(utLAddress1.Text) & " " & RTrim(utLAddress2.Text)
                If RTrim(umLPhone1.GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw)).Length > 0 Then
                    .Address = .Address & sTab & umLPhone1.Text
                End If
                .Geography = RTrim(utLCity.Text) & sTab & RTrim(ucboLState.Text) & sTab & RTrim(utLZip.Text)
                .Line = Nothing

                .ShowDialog()

            End With

        Else
            MessageBox.Show("No Location Selected.  Nothing to Print.")
            btnTopTic.Enabled = False

        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim x As New NoteEditor
        x.ShowDialog()
    End Sub

End Class
