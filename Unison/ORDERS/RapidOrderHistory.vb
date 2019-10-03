Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors

Public Class RapidOrderHistory
    Inherits System.Windows.Forms.Form

    Dim MeText As String
    Dim dtSet As New DataSet

    Dim TemplateID As Integer
    Dim Template As String

    Dim OrderTable As New DataTable

    Dim OrderNumberFlag As Boolean = False
    Dim InvoiceNumberFlag As Boolean = False

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
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents ucboCompany As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnDisplay As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents dpToDate As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents dpFromDate As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents btnAccount As System.Windows.Forms.Button
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents utAccountID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utAccount As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utOrderNumber As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utInvoiceNumber As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents ucboPickupOffice As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents ucboDeliveryOffice As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents ugOrderListing As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents uchOrdNum As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    Friend WithEvents uchInvNum As Infragistics.Win.UltraWinEditors.UltraCheckEditor
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.Label9 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.uchInvNum = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.uchOrdNum = New Infragistics.Win.UltraWinEditors.UltraCheckEditor
        Me.ucboDeliveryOffice = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.ucboPickupOffice = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.utInvoiceNumber = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utOrderNumber = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utAccount = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.btnAccount = New System.Windows.Forms.Button
        Me.utAccountID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label3 = New System.Windows.Forms.Label
        Me.ucboCompany = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.dpToDate = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.dpFromDate = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnExcel = New System.Windows.Forms.Button
        Me.btnPrint = New System.Windows.Forms.Button
        Me.btnDisplay = New System.Windows.Forms.Button
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.MenuItem4 = New System.Windows.Forms.MenuItem
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
        Me.ugOrderListing = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.GroupBox1.SuspendLayout()
        CType(Me.ucboDeliveryOffice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucboPickupOffice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utInvoiceNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utOrderNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utAccount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utAccountID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucboCompany, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dpToDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.dpFromDate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.ugOrderListing, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(748, 77)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(56, 16)
        Me.Label9.TabIndex = 107
        Me.Label9.Text = "Company:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label9.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.uchInvNum)
        Me.GroupBox1.Controls.Add(Me.uchOrdNum)
        Me.GroupBox1.Controls.Add(Me.ucboDeliveryOffice)
        Me.GroupBox1.Controls.Add(Me.ucboPickupOffice)
        Me.GroupBox1.Controls.Add(Me.utInvoiceNumber)
        Me.GroupBox1.Controls.Add(Me.utOrderNumber)
        Me.GroupBox1.Controls.Add(Me.utAccount)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.btnAccount)
        Me.GroupBox1.Controls.Add(Me.utAccountID)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.ucboCompany)
        Me.GroupBox1.Controls.Add(Me.dpToDate)
        Me.GroupBox1.Controls.Add(Me.dpFromDate)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(816, 123)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'uchInvNum
        '
        Me.uchInvNum.Location = New System.Drawing.Point(368, 95)
        Me.uchInvNum.Name = "uchInvNum"
        Me.uchInvNum.Size = New System.Drawing.Size(104, 20)
        Me.uchInvNum.TabIndex = 127
        Me.uchInvNum.Text = "Invoice Number:"
        '
        'uchOrdNum
        '
        Me.uchOrdNum.Location = New System.Drawing.Point(7, 95)
        Me.uchOrdNum.Name = "uchOrdNum"
        Me.uchOrdNum.Size = New System.Drawing.Size(97, 20)
        Me.uchOrdNum.TabIndex = 126
        Me.uchOrdNum.Text = "Order Number:"
        '
        'ucboDeliveryOffice
        '
        Me.ucboDeliveryOffice.DisplayMember = ""
        Me.ucboDeliveryOffice.Location = New System.Drawing.Point(472, 69)
        Me.ucboDeliveryOffice.Name = "ucboDeliveryOffice"
        Me.ucboDeliveryOffice.Size = New System.Drawing.Size(200, 21)
        Me.ucboDeliveryOffice.TabIndex = 125
        Me.ucboDeliveryOffice.Tag = ".Division...Divisions.Division.Division"
        Me.ucboDeliveryOffice.Text = "ALL"
        Me.ucboDeliveryOffice.ValueMember = ""
        '
        'ucboPickupOffice
        '
        Me.ucboPickupOffice.DisplayMember = ""
        Me.ucboPickupOffice.Location = New System.Drawing.Point(104, 69)
        Me.ucboPickupOffice.Name = "ucboPickupOffice"
        Me.ucboPickupOffice.Size = New System.Drawing.Size(200, 21)
        Me.ucboPickupOffice.TabIndex = 8
        Me.ucboPickupOffice.Tag = ".Division...Divisions.Division.Division"
        Me.ucboPickupOffice.Text = "ALL"
        Me.ucboPickupOffice.ValueMember = ""
        '
        'utInvoiceNumber
        '
        Appearance1.ForeColor = System.Drawing.Color.Black
        Appearance1.ForeColorDisabled = System.Drawing.Color.Black
        Me.utInvoiceNumber.Appearance = Appearance1
        Me.utInvoiceNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utInvoiceNumber.Location = New System.Drawing.Point(472, 95)
        Me.utInvoiceNumber.Name = "utInvoiceNumber"
        Me.utInvoiceNumber.Size = New System.Drawing.Size(200, 21)
        Me.utInvoiceNumber.TabIndex = 7
        Me.utInvoiceNumber.Tag = ""
        Me.utInvoiceNumber.Text = "ALL"
        '
        'utOrderNumber
        '
        Appearance2.ForeColor = System.Drawing.Color.Black
        Appearance2.ForeColorDisabled = System.Drawing.Color.Black
        Me.utOrderNumber.Appearance = Appearance2
        Me.utOrderNumber.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utOrderNumber.Location = New System.Drawing.Point(104, 95)
        Me.utOrderNumber.Name = "utOrderNumber"
        Me.utOrderNumber.Size = New System.Drawing.Size(200, 21)
        Me.utOrderNumber.TabIndex = 6
        Me.utOrderNumber.Tag = ""
        Me.utOrderNumber.Text = "ALL"
        '
        'utAccount
        '
        Appearance3.ForeColor = System.Drawing.Color.Black
        Appearance3.ForeColorDisabled = System.Drawing.Color.Black
        Me.utAccount.Appearance = Appearance3
        Me.utAccount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utAccount.Location = New System.Drawing.Point(104, 42)
        Me.utAccount.Name = "utAccount"
        Me.utAccount.Size = New System.Drawing.Size(400, 21)
        Me.utAccount.TabIndex = 3
        Me.utAccount.Tag = ""
        Me.utAccount.Text = "ALL"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(522, 44)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(49, 16)
        Me.Label8.TabIndex = 124
        Me.Label8.Text = "Acct.ID:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(380, 69)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(90, 16)
        Me.Label6.TabIndex = 123
        Me.Label6.Text = "Delivery Office:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(21, 69)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(81, 16)
        Me.Label5.TabIndex = 119
        Me.Label5.Text = "Pickup Office:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnAccount
        '
        Me.btnAccount.Location = New System.Drawing.Point(688, 42)
        Me.btnAccount.Name = "btnAccount"
        Me.btnAccount.Size = New System.Drawing.Size(75, 20)
        Me.btnAccount.TabIndex = 5
        Me.btnAccount.Text = "Select"
        '
        'utAccountID
        '
        Appearance4.ForeColor = System.Drawing.Color.Black
        Appearance4.ForeColorDisabled = System.Drawing.Color.Black
        Me.utAccountID.Appearance = Appearance4
        Me.utAccountID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utAccountID.Location = New System.Drawing.Point(572, 42)
        Me.utAccountID.Name = "utAccountID"
        Me.utAccountID.Size = New System.Drawing.Size(100, 21)
        Me.utAccountID.TabIndex = 4
        Me.utAccountID.Tag = ".OfficeID"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(21, 43)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 16)
        Me.Label3.TabIndex = 113
        Me.Label3.Text = "Account:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ucboCompany
        '
        Appearance5.BackColorDisabled = System.Drawing.Color.Silver
        Appearance5.ForeColor = System.Drawing.Color.Black
        Appearance5.ForeColorDisabled = System.Drawing.Color.Black
        Me.ucboCompany.Appearance = Appearance5
        Me.ucboCompany.AutoEdit = False
        Me.ucboCompany.DisplayMember = ""
        Me.ucboCompany.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.ucboCompany.Location = New System.Drawing.Point(742, 94)
        Me.ucboCompany.Name = "ucboCompany"
        Me.ucboCompany.Size = New System.Drawing.Size(68, 21)
        Me.ucboCompany.TabIndex = 0
        Me.ucboCompany.Tag = ".Name..1.RapidCompanies.Name.Name"
        Me.ucboCompany.ValueMember = ""
        Me.ucboCompany.Visible = False
        '
        'dpToDate
        '
        Me.dpToDate.DateTime = New Date(2006, 3, 31, 0, 0, 0, 0)
        Me.dpToDate.Location = New System.Drawing.Point(272, 15)
        Me.dpToDate.Name = "dpToDate"
        Me.dpToDate.Size = New System.Drawing.Size(100, 21)
        Me.dpToDate.TabIndex = 2
        Me.dpToDate.Tag = ""
        Me.dpToDate.Value = New Date(2006, 3, 31, 0, 0, 0, 0)
        '
        'dpFromDate
        '
        Me.dpFromDate.DateTime = New Date(2006, 3, 31, 0, 0, 0, 0)
        Me.dpFromDate.Location = New System.Drawing.Point(104, 15)
        Me.dpFromDate.Name = "dpFromDate"
        Me.dpFromDate.Size = New System.Drawing.Size(100, 21)
        Me.dpFromDate.TabIndex = 1
        Me.dpFromDate.Tag = ""
        Me.dpFromDate.Value = New Date(2006, 3, 31, 0, 0, 0, 0)
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(221, 17)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(50, 16)
        Me.Label2.TabIndex = 109
        Me.Label2.Text = "To Date:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(30, 17)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 16)
        Me.Label1.TabIndex = 108
        Me.Label1.Text = "From Date:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnExit)
        Me.GroupBox2.Controls.Add(Me.btnExcel)
        Me.GroupBox2.Controls.Add(Me.btnPrint)
        Me.GroupBox2.Controls.Add(Me.btnDisplay)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox2.Location = New System.Drawing.Point(0, 576)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(816, 55)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Location = New System.Drawing.Point(704, 22)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(88, 21)
        Me.btnExit.TabIndex = 3
        Me.btnExit.Text = "E&xit"
        '
        'btnExcel
        '
        Me.btnExcel.Location = New System.Drawing.Point(500, 22)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(88, 21)
        Me.btnExcel.TabIndex = 2
        Me.btnExcel.Text = "Export to E&xcel"
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(388, 22)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(88, 21)
        Me.btnPrint.TabIndex = 1
        Me.btnPrint.Text = "&Print"
        '
        'btnDisplay
        '
        Me.btnDisplay.Location = New System.Drawing.Point(27, 22)
        Me.btnDisplay.Name = "btnDisplay"
        Me.btnDisplay.Size = New System.Drawing.Size(88, 21)
        Me.btnDisplay.TabIndex = 0
        Me.btnDisplay.Text = "D&isplay"
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem2, Me.MenuItem3, Me.MenuItem4})
        Me.MenuItem1.Text = "Templates"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 0
        Me.MenuItem2.Text = "Load"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 1
        Me.MenuItem3.Text = "Save As"
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 2
        Me.MenuItem4.Text = "Delete"
        '
        'UltraGridExcelExporter1
        '
        Me.UltraGridExcelExporter1.FileLimitBehaviour = Infragistics.Win.UltraWinGrid.ExcelExport.FileLimitBehaviour.ThrowException
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'ugOrderListing
        '
        Me.ugOrderListing.Dock = System.Windows.Forms.DockStyle.Fill
        Me.ugOrderListing.Location = New System.Drawing.Point(0, 123)
        Me.ugOrderListing.Name = "ugOrderListing"
        Me.ugOrderListing.Size = New System.Drawing.Size(816, 453)
        Me.ugOrderListing.TabIndex = 3
        Me.ugOrderListing.Tag = "RapidOrderListing"
        Me.ugOrderListing.Text = "Rapid Order Listing"
        '
        'RapidOrderHistory
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(816, 631)
        Me.Controls.Add(Me.ugOrderListing)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Menu = Me.MainMenu1
        Me.Name = "RapidOrderHistory"
        Me.Tag = "OrderHistory"
        Me.Text = "Order History"
        Me.TopMost = True
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.ucboDeliveryOffice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucboPickupOffice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utInvoiceNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utOrderNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utAccount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utAccountID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucboCompany, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dpToDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.dpFromDate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.ugOrderListing, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub RapidOrderHistory_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        StandardFormPrep()

        FillUCombo(ucboCompany, "TOP PRIORITY", "", "", ORDERTblPath)
        AddHandler ucboCompany.Leave, AddressOf UCbo_Leave

        GetPickupOfficeIds()
        GetDeliveryOfficeIds()

        dpFromDate.Value = Now.Date
        dpToDate.Value = Now.Date

        uchOrdNum.Checked = False
        uchInvNum.Checked = False
        utOrderNumber.Enabled = False
        utInvoiceNumber.Enabled = False

    End Sub

    Private Sub uchOrdNum_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uchOrdNum.CheckedChanged
        If uchOrdNum.Checked = True Then
            utOrderNumber.Enabled = True
            dpFromDate.Enabled = False
            dpToDate.Enabled = False
            utAccount.Enabled = False
            utAccount.Text = "ALL"
            utAccountID.Enabled = False
            utAccountID.Text = ""
            btnAccount.Enabled = False
            ucboPickupOffice.Enabled = False
            ucboPickupOffice.Text = "ALL"
            ucboDeliveryOffice.Enabled = False
            ucboDeliveryOffice.Text = "ALL"
            uchInvNum.Enabled = False
            utInvoiceNumber.Enabled = False
            utInvoiceNumber.Text = "ALL"
        Else
            utOrderNumber.Enabled = False
            utOrderNumber.Text = "ALL"
            dpFromDate.Enabled = True
            dpToDate.Enabled = True
            utAccount.Enabled = True
            utAccountID.Enabled = True
            btnAccount.Enabled = True
            ucboPickupOffice.Enabled = True
            ucboDeliveryOffice.Enabled = True
            uchInvNum.Enabled = True
        End If
    End Sub

    Private Sub uchInvNum_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uchInvNum.CheckedChanged
        If uchInvNum.Checked = True Then
            utInvoiceNumber.Enabled = True
            utOrderNumber.Enabled = False
            utOrderNumber.Text = "ALL"
            dpFromDate.Enabled = False
            dpToDate.Enabled = False
            utAccount.Enabled = False
            utAccount.Text = "ALL"
            utAccountID.Enabled = False
            utAccountID.Text = ""
            btnAccount.Enabled = False
            ucboPickupOffice.Enabled = False
            ucboPickupOffice.Text = "ALL"
            ucboDeliveryOffice.Enabled = False
            ucboDeliveryOffice.Text = "ALL"
            uchOrdNum.Enabled = False
        Else
            utInvoiceNumber.Enabled = False
            utInvoiceNumber.Text = "ALL"
            dpFromDate.Enabled = True
            dpToDate.Enabled = True
            utAccount.Enabled = True
            utAccountID.Enabled = True
            btnAccount.Enabled = True
            ucboPickupOffice.Enabled = True
            ucboDeliveryOffice.Enabled = True
            uchOrdNum.Enabled = True
        End If
    End Sub

    Private Sub PrepData(ByRef tbl As DataTable)
        Dim row As DataRow
        Dim col As DataColumn

        tbl.Columns.Add("Code", GetType(System.String))
        tbl.Columns.Add("OrderNumber", GetType(System.String))

        row = tbl.NewRow
        row("Code") = "A" : row("OrderNumber") = "ALL"
        tbl.Rows.Add(row)
    End Sub
    Private Sub StandardFormPrep()

        'Standard Code for Most Unison Form's Load Event
        AddHandler Me.Activated, AddressOf Form_Activated
        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = ORDERTblPath & Me.Tag
            End If
        End If

        Me.CenterToScreen()

        Me.KeyPreview = True

        MeText = Me.Text

    End Sub


    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow

        SelectSQL = "Select ID, Name from ListingsTemplates Where ListName = '" & Me.Tag & "' order by Name"

        PopulateDataset2(dtAdapter, dtSet, SelectSQL)
        dtView.Table = dtSet.Tables(0)
        If dtView.Table.Rows.Count > 0 Then
            Dim Srch As New SearchListings
            Srch.dsList = dtSet

            Srch.UltraGrid1.Text = "Templates"
            Srch.Text = "Listing Templates"
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
                '- MsgBox("SQL_Error: " & osqlexception.Message)
                Srch = Nothing
                sender.Focus()
                Exit Try
            Finally
                If HasErr = False Then
                    ugRow = Srch.UltraGrid1.ActiveRow

                    TemplateID = ugRow.Cells("ID").Text
                    If Not ugOrderListing.DataSource Is Nothing Then
                        UGLoadListingLayout(ugOrderListing, TemplateID)
                    End If
                    Me.Text = MeText & " - Using Layout : " & ugRow.Cells("Name").Text
                    Template = ugRow.Cells("Name").Text
                End If
            End Try
            Srch = Nothing
        End If
    End Sub

    Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem3.Click
        Dim x As New EnterTextBox

        x.Text = "Save Template"
        x.TextBox1.Text = Template
        x.TextBox2.Visible = False
        x.Label2.Visible = False
        x.ShowDialog()
        If x.DialogResult <> DialogResult.OK Then Exit Sub
        If Template <> x.TextBox1.Text.Trim Then
            TemplateID = 0
        End If
        Template = x.TextBox1.Text.Trim
        UGSaveListingLayout(Me, ugOrderListing, TemplateID, Template)
        x = Nothing
        If TemplateID = 0 Then
            'Message modified by Michael Pastor
            MsgBox("Unable to save template.", MsgBoxStyle.Exclamation, "Data Not Saved")
            '- MsgBox("Failed")
        End If
    End Sub

    Private Sub MenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem4.Click
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView

        SelectSQL = "Select ID, Name from ListingsTemplates Where ListName = '" & Me.Tag & "' order by Name"

        PopulateDataset2(dtAdapter, dtSet, SelectSQL)
        dtView.Table = dtSet.Tables(0)
        If dtView.Table.Rows.Count > 0 Then
            Dim Srch As New SearchListings
            Srch.dsList = dtSet
            Srch.sqlSelect = SelectSQL
            Srch.btnDelete.Visible = True
            Srch.Button1.Enabled = False

            Srch.UltraGrid1.Text = "Templates"
            Srch.Text = "Listing Templates"
            Srch.ShowDialog()
            'If Srch.DialogResult <> DialogResult.OK Then Exit Sub
            Srch = Nothing
        End If
    End Sub

    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        Dim x As New EnterTextBox
        Dim FileName As String

        On Error GoTo ErrTrap

        If ugOrderListing.ActiveRow Is Nothing Then GoTo ErrTrap

        x.Label1.Text = "File Name:"
        x.Label2.Text = ""
        x.Label2.Visible = False
        x.btnBrowse1.Visible = True

        x.Text = "File Name"
        x.TextBox1.Enabled = True
        'x.TextBox1.Text = "c :\RapidOrderHistoryListing.xls"
        x.TextBox1.Text = ".\RapidOrderHistoryListing.xls"
        x.TextBox2.Visible = False
        'x.Show()
        x.ShowDialog(Me)
        If x.DialogResult = DialogResult.OK Then
            If x.TextBox1.Text.Trim = "" Then
                'Message modified by Michael Pastor
                MsgBox("File name remains unspecified. Please enter a file name to continue.", MsgBoxStyle.Exclamation, "Missing Data Input")
                '- MsgBox("No file name specified.")
                Exit Sub
            End If
            FileName = x.TextBox1.Text
            x.Dispose()
            x = Nothing
            Me.UltraGridExcelExporter1.Export(Me.ugOrderListing, FileName)
        End If
        Exit Sub
ErrTrap:
        If Err.Number > 0 Then
            'Message modified by Michael Pastor
            MsgBox("Error in btnNewGroup_Click : " & Err.Description, MsgBoxStyle.Critical, "Critical Error")
            '- MsgBox("Error in btnNewGroup_Click : " & Err.Description)
        End If

    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        'ugOrderListing.PrintPreview(Infragistics.Win.UltraWinGrid.RowPropertyCategories.All)

        '<PROTOTYPE CODE>
        Dim strSqlCommand As String
        strSqlCommand = "select OrdersId, OrderDate, PUDate, DLDate, OrderRef1, OrderRef2, CourierLabelId, OrderStatus, StatusComments as StatusComment, OrderOrigin, Invoice_No, CustomerId, CustomerPO, AuthorizedBy, PUAddressId, PULocationID, PUName, PUStreet, PUAddress2 as PUAddress, PUCity, PUState, PUZip, PUContact, PUAttn, PURef1, PURef2, DLAddressId, DLLocationID, DLName, DLStreet, DLAddress2 as DLAddress, DLCity, DLState, DLZip, DLContact,DLAttn, DLRef1, DLRef2, COD, CODAmount, DeclaredValue, FreightCollect, NeedPricing, InsertDate, InsertUserId, UpdateDate, UpdateUserId, cl.TrackingNum from un_orders_tbd.dbo.orders o join un_tracking.dbo.courierlabels cl on o.CourierLabelId = cl.RowId and o.OrdersId = 3"
        '</PROTOTYPE CODE>

        Dim x As New OrderLabelForm
        x.SqlCommand = strSqlCommand
        x.Show()

    End Sub

    Private Sub btnAccount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAccount.Click
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim gAcct, gAcctID As Infragistics.Win.UltraWinEditors.UltraTextEditor

        gAcct = utAccount
        gAcctID = utAccountID


        SelectSQL = "Select * from " & TRCTblPath & "Customer i WHERE (Active = 'Y') order by Name"

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
                '- MsgBox("SQL_Error: " & osqlexception.Message)
                Srch = Nothing
                sender.Focus()
                Exit Try
            Finally
                If HasErr = False Then
                    ugRow = Srch.UltraGrid1.ActiveRow
                    'AcctName.Text = ugRow.Cells("Name").Text
                    gAcct.Text = ugRow.Cells("Name").Text
                    gAcctID.Text = ugRow.Cells("CustomerID").Text
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

    Private Sub utAccount_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles utAccount.KeyUp
        TypeAhead(sender, e, "" & TRCTblPath & "Customer", "Name", " Where Active = 'Y'")
    End Sub

    Private Sub utAccount_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles utAccount.Leave
        Dim row As DataRow
        Dim gAcct, gAcctID As Infragistics.Win.UltraWinEditors.UltraTextEditor

        gAcct = utAccount
        gAcctID = utAccountID


        If sender.Modified = False Then
            utOrderNumber.Focus()
            Exit Sub
        End If

        If sender.text.trim = "" Then
            gAcctID.Text = ""
            sender.text = ""
        Else
            If utAccount.Text = "ALL" Then
                gAcctID.Text = ""
                utOrderNumber.Focus()
                Exit Sub
            End If
            If SearchOnLeave(sender, gAcctID, "" & TRCTblPath & "Customer", "CustomerID", "Name", "*", "Accounts", " Where Active = 'Y'") Then
            Else
                gAcctID.Text = ""
                gAcct.Text = ""
                sender.focus()
            End If
        End If
        sender.Modified = False
    End Sub

    Private Sub utAccountID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utAccountID.Leave
        Dim row As DataRow
        Dim gAcct, gAcctID As Infragistics.Win.UltraWinEditors.UltraTextEditor

        gAcct = utAccount
        gAcctID = utAccountID

        If sender.Modified = False Then Exit Sub

        If sender.text.trim = "" Then
            gAcct.Text = ""
            sender.text = ""
        Else
            If SearchOnLeave(sender, gAcctID, "" & TRCTblPath & "Customer", "CustomerID", "CustomerID", "*", "Accounts", " Where Active = 'Y'") Then
                If ReturnRowByID(gAcctID.Text, row, "" & TRCTblPath & "Customer", "", "CustomerID") Then
                    gAcct.Text = row("Name")
                    row = Nothing
                Else
                    'Message modified by Michael Pastor
                    MsgBox("Account not found.", MsgBoxStyle.Information, "Data Unavailable")
                    '- MsgBox("Account Not Found.")
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

    Private Sub utOrderNumber_Int_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles utOrderNumber.KeyPress
        If OrderNumberFlag = False Then
            If utOrderNumber.Text = "" Or utOrderNumber.Text = "ALL" Then
                If e.KeyChar = "a" Or e.KeyChar = "A" Then
                    utOrderNumber.Text = "ALL"
                    utInvoiceNumber.Focus()
                    e.Handled = False
                End If
            End If
            If utOrderNumber.Text = "" Or utOrderNumber.Text = "ALL" Or IsNumeric(utOrderNumber.Text) Then
                If IsNumeric(e.KeyChar) = False And Asc(e.KeyChar) <> Keys.Back Then
                    e.Handled = True
                End If
            End If
        Else
            If e.KeyChar = "a" Or e.KeyChar = "A" Then
                utOrderNumber.Text = "ALL"
                utInvoiceNumber.Focus()
                e.Handled = False
            End If
            If IsNumeric(utOrderNumber.Text) Then
                utOrderNumber.Text = ""
                If IsNumeric(e.KeyChar) = False And Asc(e.KeyChar) <> Keys.Back Then
                    e.Handled = True
                End If
            End If
            OrderNumberFlag = False
        End If
    End Sub

    Private Sub utOrderNumber_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utOrderNumber.Leave
        If sender.Modified = False Then Exit Sub
        OrderNumberFlag = True
    End Sub

    Private Sub utInvoiceNumber_Int_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles utInvoiceNumber.KeyPress
        If InvoiceNumberFlag = False Then
            If utInvoiceNumber.Text = "" Or utInvoiceNumber.Text = "ALL" Then
                If e.KeyChar = "a" Or e.KeyChar = "A" Then
                    utInvoiceNumber.Text = "ALL"
                    ucboPickupOffice.Focus()
                    e.Handled = False
                End If
            End If
            If utInvoiceNumber.Text = "" Or utInvoiceNumber.Text = "ALL" Or IsNumeric(utInvoiceNumber.Text) Then
                If IsNumeric(e.KeyChar) = False And Asc(e.KeyChar) <> Keys.Back Then
                    e.Handled = True
                End If
            End If
        Else
            If e.KeyChar = "a" Or e.KeyChar = "A" Then
                utInvoiceNumber.Text = "ALL"
                ucboPickupOffice.Focus()
                e.Handled = False
            End If
            If IsNumeric(utInvoiceNumber.Text) Then
                utInvoiceNumber.Text = ""
                If IsNumeric(e.KeyChar) = False And Asc(e.KeyChar) <> Keys.Back Then
                    e.Handled = True
                End If
            End If
            InvoiceNumberFlag = False
        End If
    End Sub

    Private Sub utInvoiceNumber_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utInvoiceNumber.Leave
        If sender.Modified = False Then Exit Sub
        InvoiceNumberFlag = True
    End Sub

    Private Function GetPickupOfficeIds() As Boolean
        Dim dtAdapter As SqlDataAdapter
        Dim dtSet As New DataSet
        Dim strSQL As String

        'Initialzie DataSet
        strSQL = "SELECT ID, Name FROM " & HRTblPath & "ServiceOffices union SELECT 999 as [id], 'ALL' as [name] ORDER BY ID"
        PopulateDataset2(dtAdapter, dtSet, strSQL)

        If dtSet.Tables(0).Rows.Count >= 1 Then
            'Initialize the UltraCombo
            ucboPickupOffice.DataSource = dtSet.Tables(0)
            ucboPickupOffice.ValueMember = dtSet.Tables(0).Columns("ID").ToString
            ucboPickupOffice.DisplayMember = dtSet.Tables(0).Columns("Name").ToString
            ucboPickupOffice.DisplayLayout.Bands(0).ColHeadersVisible = False
            GetPickupOfficeIds = True
            'Hide the ID column
            Dim ugcol As Infragistics.Win.UltraWinGrid.UltraGridColumn
            For Each ugcol In ucboPickupOffice.DisplayLayout.Bands(0).Columns
                If StrComp(ugcol.ToString, "ID") = 0 Then
                    ugcol.Hidden = True
                End If
            Next
            '<<<NOTE:  Use FillUCombo when know how to keep ValidOfficeId() from breaking.>>>
        Else
            ucboPickupOffice.Text = ""
            GetPickupOfficeIds = False
        End If
    End Function

    Private Function ValidPickupOfficeId(ByVal p_strName As String) As Boolean
        Dim dataRow As DataRow
        Dim dataRows As DataRow()
        Dim iCount As Integer = 0

        If IsNumeric(p_strName) Then
            dataRows = ucboPickupOffice.DataSource.Select("ID = " & p_strName)
        Else
            dataRows = ucboPickupOffice.DataSource.Select("Name = '" & p_strName & "'")
        End If

        For Each dataRow In dataRows
            iCount += 1
        Next

        ValidPickupOfficeId = IIf(iCount > 0, True, False)
    End Function

    Private Sub ucboPickupOffice_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ucboPickupOffice.Validating
        If Not ValidPickupOfficeId(ucboPickupOffice.Text) Then
            SetError(ucboPickupOffice, e, "Please Enter or Select a valid Pickup Office")
        End If
    End Sub

    Private Sub SetError(ByRef ctl As Control, ByVal e As System.ComponentModel.CancelEventArgs, ByVal str As String)
        Beep()
        e.Cancel = True
        Me.ErrorProvider1.SetError(ctl, str)
    End Sub

    Private Sub ucboPickupOffice_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucboPickupOffice.Enter
        If ErrorProvider1.GetError(ucboPickupOffice).ToString <> "" Then
            ucboPickupOffice.Select()
        End If
    End Sub

    Private Sub ucboPickupOffice_Validated(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucboPickupOffice.Validated
        ClearError(ucboPickupOffice)
    End Sub

    Private Sub ClearError(ByRef ctl As Control)
        Me.ErrorProvider1.SetError(ctl, "")
    End Sub

    Private Function GetDeliveryOfficeIds() As Boolean
        Dim dtAdapter As SqlDataAdapter
        Dim dtSet As New DataSet
        Dim strSQL As String

        'Initialzie DataSet
        strSQL = "SELECT ID, Name FROM " & HRTblPath & "ServiceOffices union SELECT 999 as [id], 'ALL' as [name] ORDER BY ID"
        PopulateDataset2(dtAdapter, dtSet, strSQL)

        If dtSet.Tables(0).Rows.Count >= 1 Then
            'Initialize the UltraCombo
            ucboDeliveryOffice.DataSource = dtSet.Tables(0)
            ucboDeliveryOffice.ValueMember = dtSet.Tables(0).Columns("ID").ToString
            ucboDeliveryOffice.DisplayMember = dtSet.Tables(0).Columns("Name").ToString
            ucboDeliveryOffice.DisplayLayout.Bands(0).ColHeadersVisible = False
            GetDeliveryOfficeIds = True
            'Hide the ID column
            Dim ugcol As Infragistics.Win.UltraWinGrid.UltraGridColumn
            For Each ugcol In ucboDeliveryOffice.DisplayLayout.Bands(0).Columns
                If StrComp(ugcol.ToString, "ID") = 0 Then
                    ugcol.Hidden = True
                End If
            Next
            '<<<NOTE:  Use FillUCombo when know how to keep ValidOfficeId() from breaking.>>>
        Else
            ucboDeliveryOffice.Text = ""
            GetDeliveryOfficeIds = False
        End If
    End Function

    Private Function ValidDeliveryOfficeId(ByVal p_strName As String) As Boolean
        Dim dataRow As DataRow
        Dim dataRows As DataRow()
        Dim iCount As Integer = 0

        If IsNumeric(p_strName) Then
            dataRows = ucboDeliveryOffice.DataSource.Select("ID = " & p_strName)
        Else
            dataRows = ucboDeliveryOffice.DataSource.Select("Name = '" & p_strName & "'")
        End If

        For Each dataRow In dataRows
            iCount += 1
        Next

        ValidDeliveryOfficeId = IIf(iCount > 0, True, False)
    End Function

    Private Sub ucboDeliveryOffice_Validating(ByVal sender As System.Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles ucboDeliveryOffice.Validating
        If Not ValidDeliveryOfficeId(ucboDeliveryOffice.Text) Then
            SetError(ucboDeliveryOffice, e, "Please Enter or Select a valid Delivery Office")
        End If
    End Sub

    Private Sub ucboDeliveryOffice_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ucboDeliveryOffice.Enter
        If ErrorProvider1.GetError(ucboDeliveryOffice).ToString <> "" Then
            ucboDeliveryOffice.Select()
        End If
    End Sub

    Private Sub ucboDeliveryOffice_Validated(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ucboDeliveryOffice.Validated
        ClearError(ucboDeliveryOffice)
    End Sub

    Private Sub btnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        LoadData()
    End Sub

    Private Sub LoadData()
        Dim dtAdapter As SqlDataAdapter
        Dim i As Integer
        Dim SQLSelect, Company, FromDate, ToDate, Account, OrderNumber, InvoiceNumber, PickupOffice, DeliveryOffice, SummCol As String

        SQLSelect = "SELECT * FROM UN_ORDERS_TBD.DBO.ORDERS"

        'SQLSelect = "Select roh.RowId, roh.OrderID, roh.InvoiceID, roh.UserName, roh.OrderDate, roh.CustomerID, roh.CustomerName, roh.Caller, " & _
        '    "roh.CallerPhone, roh.Service, roh.PickUpName, roh.PickUpAddress, roh.PickUpCity, roh.PickUpState, roh.PickUpZip, " & _
        '    "roh.PickUpInstructions, roh.PickUpDate, roh.PickUpTime, roh.DeliverName, roh.DeliverAddress, " & _
        '    "roh.DeliverCity, roh.DeliverState, roh.DeliverZip, roh.DeliverInstructions, roh.DeliverDate, roh.DeliverTime, roh.Reference, " & _
        '    "roh.ZoneID, roh.PickUpOfficeID, roh.PickUpOffice, roh.DeliverOfficeID, roh.DeliverOffice, roh.Qty1, roh.ChargeType1, roh.PriceTable1, " & _
        '    "roh.Charge1, roh.Qty2, roh.ChargeType2, roh.PriceTable2, roh.Charge2, roh.Qty3, roh.ChargeType3, roh.PriceTable3, roh.Charge3, " & _
        '    "roh.OtherDesc1, roh.OtherCharge1, roh.OtherDesc2, roh.OtherCharge2, roh.SubTotal, roh.Discount, roh.DeclaredValue, roh.InsuranceFee, " & _
        '    "roh.CODAmount, roh.CODFee, roh.TotalAmount, roh.FreightCollectFlag, roh.FrieghtAmount as FreightAmount, roh.Status, roh.LastModifiedDate " & _
        '    "FROM " & ORDERTblPath & "RapidOrderHistory As roh WHERE @COMP @FRDT @TODT @ACCNT @ORDN @INVN @PCKOF @DLVOF"


        'ugOrderListing.DataSource = Nothing
        'ugOrderListing.ResetDisplayLayout()
        'ugOrderListing.Layouts.Clear()

        'Me.Cursor = Cursors.WaitCursor()

        'Application.DoEvents()


        ''-----Validating Date
        'If dpFromDate.Text > dpToDate.Text Then
        '    'Message modified by Michael Pastor
        '    MsgBox("'To' date is sooner than 'From' date.", MsgBoxStyle.Exclamation, "Data Invalid")
        '    '- MsgBox("ERROR: 'To Date' is LESS then 'From Date'!")
        '    Exit Sub
        'End If

        ''-----COMPANY
        'If ucboCompany.Text = "" Or ucboCompany.Text = "TOP PRIORITY" Then
        '    Company = " roh.CustomerID like '%' "
        'Else
        '    Company = " roh.CustomerID = '' "
        'End If

        ''-----FROM DATE
        'If dpFromDate.Text = "" Then
        '    FromDate = " AND roh.OrderDate like '%' "
        'Else
        '    FromDate = " AND roh.OrderDate >= '" & dpFromDate.Text.Trim & " 00:00:00.000' "
        'End If

        ''-----TO DATE
        'If dpToDate.Text = "" Then
        '    ToDate = " AND roh.OrderDate like '%' "
        'Else
        '    ToDate = " AND roh.OrderDate <= '" & dpToDate.Text.Trim & " 23:59:59.000' "
        'End If

        ''-----ACCOUNT
        'If utAccount.Text = "" Or utAccount.Text = "ALL" Then
        '    Account = " AND roh.CustomerID like '%' "
        'Else
        '    Account = " AND roh.CustomerID = '" & utAccountID.Text.Trim & "' "
        'End If

        ''-----ORDER NUMBER
        'If utOrderNumber.Text = "" Or utOrderNumber.Text = "ALL" Then
        '    OrderNumber = " AND roh.OrderID like '%' "
        'Else
        '    OrderNumber = " AND roh.OrderID = '" & utOrderNumber.Text.Trim & "' "
        'End If

        ''-----INVOICE NUMBER
        'If utInvoiceNumber.Text = "" Or utInvoiceNumber.Text = "ALL" Then
        '    InvoiceNumber = " AND roh.InvoiceID like '%' "
        'Else
        '    InvoiceNumber = " AND roh.InvoiceID = '" & utInvoiceNumber.Text.Trim & "' "
        'End If

        ''-----PICKUP OFFICE
        'If ucboPickupOffice.Text = "ALL" Then
        '    PickupOffice = " AND roh.PickupOffice like '%' "
        'Else
        '    PickupOffice = " AND roh.PickupOffice = '" & ucboPickupOffice.Text.Trim & "' "
        'End If

        ''-----DELIVERY OFFICE
        'If ucboDeliveryOffice.Text = "ALL" Then
        '    DeliveryOffice = " AND roh.DeliverOffice like '%' "
        'Else
        '    DeliveryOffice = " AND roh.DeliverOffice = '" & ucboDeliveryOffice.Text.Trim & "' "
        'End If

        'SQLSelect = SQLSelect.Replace("@COMP", Company)
        'SQLSelect = SQLSelect.Replace("@ACCNT", Account)
        'SQLSelect = SQLSelect.Replace("@ORDN", OrderNumber)
        'SQLSelect = SQLSelect.Replace("@INVN", InvoiceNumber)
        'SQLSelect = SQLSelect.Replace("@PCKOF", PickupOffice)
        'SQLSelect = SQLSelect.Replace("@DLVOF", DeliveryOffice)

        'If Not ugOrderListing.DataSource Is Nothing Then
        'End If

        ''-----IGNOR DATE IF SERCHED BY INVOICE ORDER OR INVOICE NUMBER
        'If ((utOrderNumber.Text <> "" And utOrderNumber.Text <> "ALL") Or (utInvoiceNumber.Text <> "" And utInvoiceNumber.Text <> "ALL")) Then
        '    FromDate = " AND roh.OrderDate like '%' "
        '    ToDate = " AND roh.OrderDate like '%' "
        'End If

        'SQLSelect = SQLSelect.Replace("@FRDT", FromDate)
        'SQLSelect = SQLSelect.Replace("@TODT", ToDate)

        PopulateDataset2(dtAdapter, dtSet, SQLSelect)

        For i = 0 To dtSet.Tables(0).Columns.Count - 1
            dtSet.Tables(0).Columns(i).ReadOnly = True
        Next

        FillUltraGrid(ugOrderListing, dtSet, -1, , 0)
        ugOrderListing.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True
        ugOrderListing.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        ugOrderListing.DisplayLayout.AutoFitColumns = False
        For i = 0 To ugOrderListing.DisplayLayout.Bands(0).Columns.Count - 1
            ugOrderListing.DisplayLayout.Bands(0).Columns(i).TabStop = True
            ugOrderListing.DisplayLayout.Bands(0).Columns(i).CellActivation = Infragistics.Win.UltraWinGrid.Activation.ActivateOnly
        Next

        ugOrderListing.DisplayLayout.Override.AllowRowSummaries = Infragistics.Win.UltraWinGrid.AllowRowSummaries.True

        SummCol = "OrderSID"
        ugOrderListing.DisplayLayout.Bands(0).Summaries.Add(SummCol, Infragistics.Win.UltraWinGrid.SummaryType.Count, ugOrderListing.DisplayLayout.Bands(0).Columns(SummCol), Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn)
        ugOrderListing.DisplayLayout.Bands(0).Summaries(SummCol).Appearance.TextHAlign = Infragistics.Win.HAlign.Right
        ugOrderListing.DisplayLayout.Bands(0).SummaryFooterCaption = ""
        ugOrderListing.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False


        ugOrderListing.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus

        ugOrderListing.DisplayLayout.GroupByBox.Hidden = False
        ugOrderListing.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        ugOrderListing.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid, False, False)
        'UltraGrid1.Text = "Packages"

        Me.Cursor = Cursors.Default
    End Sub

End Class
