'Sammy was here
Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors

Public Class BillingInvoiceGen
    Inherits System.Windows.Forms.Form

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
    Friend WithEvents UltraDate1 As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraDate2 As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnGenerate As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents uopBillingMethod As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents utAccountName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utAccountID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents utTotalInvoices As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents utTotalAmount As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents ucboBillingCycles As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents btnAcct As System.Windows.Forms.Button
    Friend WithEvents ucboAcctBillingCycle As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents UltraDate0 As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents utInvoiceNo As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents uCurr1 As Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents utFuel As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents ucboTerms As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Button1 As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance8 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance9 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance10 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance11 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance12 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance13 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.UltraDate1 = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.UltraDate2 = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.Button1 = New System.Windows.Forms.Button
        Me.btnNew = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnGenerate = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label7 = New System.Windows.Forms.Label
        Me.utInvoiceNo = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.ucboAcctBillingCycle = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.btnAcct = New System.Windows.Forms.Button
        Me.ucboBillingCycles = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.Label3 = New System.Windows.Forms.Label
        Me.utAccountID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utAccountName = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.uopBillingMethod = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.utFuel = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label9 = New System.Windows.Forms.Label
        Me.ucboTerms = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.Label6 = New System.Windows.Forms.Label
        Me.UltraDate0 = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.uCurr1 = New Infragistics.Win.UltraWinEditors.UltraCurrencyEditor
        Me.Label5 = New System.Windows.Forms.Label
        Me.utTotalAmount = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label4 = New System.Windows.Forms.Label
        Me.utTotalInvoices = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        CType(Me.UltraDate1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDate2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.utInvoiceNo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucboAcctBillingCycle, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucboBillingCycles, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utAccountID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utAccountName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uopBillingMethod, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.utFuel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucboTerms, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDate0, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.uCurr1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utTotalAmount, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utTotalInvoices, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UltraDate1
        '
        Appearance1.ForeColorDisabled = System.Drawing.Color.DimGray
        Me.UltraDate1.Appearance = Appearance1
        Me.UltraDate1.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.UltraDate1.Enabled = False
        Me.UltraDate1.Location = New System.Drawing.Point(328, 64)
        Me.UltraDate1.Name = "UltraDate1"
        Me.UltraDate1.Size = New System.Drawing.Size(88, 21)
        Me.UltraDate1.TabIndex = 2
        Me.UltraDate1.Value = Nothing
        '
        'UltraDate2
        '
        Me.UltraDate2.DateTime = New Date(2004, 2, 11, 0, 0, 0, 0)
        Me.UltraDate2.Location = New System.Drawing.Point(80, 64)
        Me.UltraDate2.Name = "UltraDate2"
        Me.UltraDate2.Size = New System.Drawing.Size(96, 21)
        Me.UltraDate2.TabIndex = 1
        Me.UltraDate2.Value = New Date(2004, 2, 11, 0, 0, 0, 0)
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Button1)
        Me.GroupBox4.Controls.Add(Me.btnNew)
        Me.GroupBox4.Controls.Add(Me.btnExit)
        Me.GroupBox4.Controls.Add(Me.btnGenerate)
        Me.GroupBox4.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox4.Location = New System.Drawing.Point(0, 237)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(664, 48)
        Me.GroupBox4.TabIndex = 3
        Me.GroupBox4.TabStop = False
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(376, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(144, 23)
        Me.Button1.TabIndex = 3
        Me.Button1.Text = "Toggle Invoice Read-only"
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(72, 16)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(64, 24)
        Me.btnNew.TabIndex = 1
        Me.btnNew.Text = "&New"
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Location = New System.Drawing.Point(536, 16)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(64, 24)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Text = "E&xit"
        '
        'btnGenerate
        '
        Me.btnGenerate.Location = New System.Drawing.Point(8, 16)
        Me.btnGenerate.Name = "btnGenerate"
        Me.btnGenerate.Size = New System.Drawing.Size(64, 24)
        Me.btnGenerate.TabIndex = 0
        Me.btnGenerate.Text = "&Generate"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(232, 68)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 16)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Period Start Date:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 68)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(72, 16)
        Me.Label2.TabIndex = 13
        Me.Label2.Text = "Closing Date:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.utInvoiceNo)
        Me.GroupBox1.Controls.Add(Me.ucboAcctBillingCycle)
        Me.GroupBox1.Controls.Add(Me.btnAcct)
        Me.GroupBox1.Controls.Add(Me.ucboBillingCycles)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.utAccountID)
        Me.GroupBox1.Controls.Add(Me.utAccountName)
        Me.GroupBox1.Controls.Add(Me.uopBillingMethod)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(664, 80)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(456, 18)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(88, 16)
        Me.Label7.TabIndex = 8
        Me.Label7.Text = "Starting Inv.#:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utInvoiceNo
        '
        Appearance2.ForeColorDisabled = System.Drawing.Color.Black
        Me.utInvoiceNo.Appearance = Appearance2
        Me.utInvoiceNo.Enabled = False
        Me.utInvoiceNo.Location = New System.Drawing.Point(547, 16)
        Me.utInvoiceNo.Name = "utInvoiceNo"
        Me.utInvoiceNo.Size = New System.Drawing.Size(112, 21)
        Me.utInvoiceNo.TabIndex = 7
        '
        'ucboAcctBillingCycle
        '
        Appearance3.BackColorDisabled = System.Drawing.SystemColors.ActiveBorder
        Appearance3.ForeColorDisabled = System.Drawing.Color.Black
        Me.ucboAcctBillingCycle.Appearance = Appearance3
        Me.ucboAcctBillingCycle.AutoEdit = False
        Me.ucboAcctBillingCycle.DisplayMember = ""
        Me.ucboAcctBillingCycle.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.ucboAcctBillingCycle.Enabled = False
        Me.ucboAcctBillingCycle.Location = New System.Drawing.Point(547, 39)
        Me.ucboAcctBillingCycle.Name = "ucboAcctBillingCycle"
        Me.ucboAcctBillingCycle.Size = New System.Drawing.Size(112, 21)
        Me.ucboAcctBillingCycle.TabIndex = 6
        Me.ucboAcctBillingCycle.Tag = ".BCycleCode.View.1.BillingCycles.CODE.Name"
        Me.ucboAcctBillingCycle.ValueMember = ""
        '
        'btnAcct
        '
        Me.btnAcct.Location = New System.Drawing.Point(376, 40)
        Me.btnAcct.Name = "btnAcct"
        Me.btnAcct.Size = New System.Drawing.Size(72, 21)
        Me.btnAcct.TabIndex = 4
        Me.btnAcct.Text = "Select"
        '
        'ucboBillingCycles
        '
        Appearance4.BackColorDisabled = System.Drawing.SystemColors.Control
        Appearance4.ForeColorDisabled = System.Drawing.Color.Black
        Me.ucboBillingCycles.Appearance = Appearance4
        Me.ucboBillingCycles.AutoEdit = False
        Me.ucboBillingCycles.DisplayMember = ""
        Me.ucboBillingCycles.Location = New System.Drawing.Point(112, 16)
        Me.ucboBillingCycles.Name = "ucboBillingCycles"
        Me.ucboBillingCycles.Size = New System.Drawing.Size(192, 21)
        Me.ucboBillingCycles.TabIndex = 1
        Me.ucboBillingCycles.Tag = ".BCycleCode.View.1.BillingCycles.CODE.Name"
        Me.ucboBillingCycles.ValueMember = ""
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(471, 42)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(72, 16)
        Me.Label3.TabIndex = 5
        Me.Label3.Text = "Billing Cycle:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utAccountID
        '
        Appearance5.ForeColorDisabled = System.Drawing.Color.Black
        Me.utAccountID.Appearance = Appearance5
        Me.utAccountID.Enabled = False
        Me.utAccountID.Location = New System.Drawing.Point(320, 40)
        Me.utAccountID.Name = "utAccountID"
        Me.utAccountID.Size = New System.Drawing.Size(48, 21)
        Me.utAccountID.TabIndex = 3
        '
        'utAccountName
        '
        Appearance6.ForeColorDisabled = System.Drawing.Color.Black
        Me.utAccountName.Appearance = Appearance6
        Me.utAccountName.Location = New System.Drawing.Point(112, 40)
        Me.utAccountName.Name = "utAccountName"
        Me.utAccountName.Size = New System.Drawing.Size(192, 21)
        Me.utAccountName.TabIndex = 2
        '
        'uopBillingMethod
        '
        Me.uopBillingMethod.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.uopBillingMethod.ItemAppearance = Appearance7
        Appearance8.TextHAlign = Infragistics.Win.HAlign.Left
        ValueListItem1.Appearance = Appearance8
        ValueListItem1.DataValue = "Default Item"
        ValueListItem1.DisplayText = "By Billing Cycle"
        ValueListItem2.DataValue = "ValueListItem1"
        ValueListItem2.DisplayText = "By Account"
        Me.uopBillingMethod.Items.Add(ValueListItem1)
        Me.uopBillingMethod.Items.Add(ValueListItem2)
        Me.uopBillingMethod.ItemSpacingHorizontal = 10
        Me.uopBillingMethod.ItemSpacingVertical = 10
        Me.uopBillingMethod.Location = New System.Drawing.Point(8, 16)
        Me.uopBillingMethod.Name = "uopBillingMethod"
        Me.uopBillingMethod.Size = New System.Drawing.Size(104, 48)
        Me.uopBillingMethod.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.utFuel)
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.ucboTerms)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.UltraDate0)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.UltraDate2)
        Me.GroupBox2.Controls.Add(Me.UltraDate1)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 80)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(664, 96)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Billing Period"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(443, 35)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(64, 16)
        Me.Label8.TabIndex = 23
        Me.Label8.Text = "Fuel Sur. %"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utFuel
        '
        Appearance9.ForeColorDisabled = System.Drawing.Color.Black
        Me.utFuel.Appearance = Appearance9
        Me.utFuel.Location = New System.Drawing.Point(512, 32)
        Me.utFuel.Name = "utFuel"
        Me.utFuel.Size = New System.Drawing.Size(48, 21)
        Me.utFuel.TabIndex = 22
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(230, 35)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(96, 16)
        Me.Label9.TabIndex = 21
        Me.Label9.Text = "Terms:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ucboTerms
        '
        Appearance10.BackColorDisabled = System.Drawing.SystemColors.ActiveBorder
        Appearance10.ForeColorDisabled = System.Drawing.Color.Black
        Me.ucboTerms.Appearance = Appearance10
        Me.ucboTerms.AutoEdit = False
        Me.ucboTerms.DisplayMember = ""
        Me.ucboTerms.DropDownStyle = Infragistics.Win.UltraWinGrid.UltraComboStyle.DropDownList
        Me.ucboTerms.Location = New System.Drawing.Point(328, 31)
        Me.ucboTerms.Name = "ucboTerms"
        Me.ucboTerms.Size = New System.Drawing.Size(104, 21)
        Me.ucboTerms.TabIndex = 20
        Me.ucboTerms.Tag = ".TermsID.View.1.InvoiceTerms.TermsID.Term"
        Me.ucboTerms.ValueMember = ""
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(8, 26)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(72, 16)
        Me.Label6.TabIndex = 15
        Me.Label6.Text = "Invoice Date:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UltraDate0
        '
        Me.UltraDate0.DateTime = New Date(2004, 2, 11, 0, 0, 0, 0)
        Me.UltraDate0.Location = New System.Drawing.Point(80, 24)
        Me.UltraDate0.Name = "UltraDate0"
        Me.UltraDate0.Size = New System.Drawing.Size(96, 21)
        Me.UltraDate0.TabIndex = 0
        Me.UltraDate0.Value = New Date(2004, 2, 11, 0, 0, 0, 0)
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.uCurr1)
        Me.GroupBox3.Controls.Add(Me.Label5)
        Me.GroupBox3.Controls.Add(Me.utTotalAmount)
        Me.GroupBox3.Controls.Add(Me.Label4)
        Me.GroupBox3.Controls.Add(Me.utTotalInvoices)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox3.Location = New System.Drawing.Point(0, 176)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(664, 64)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "Summary"
        '
        'uCurr1
        '
        Appearance11.BackColorDisabled = System.Drawing.SystemColors.Control
        Appearance11.ForeColorDisabled = System.Drawing.Color.Black
        Me.uCurr1.Appearance = Appearance11
        Me.uCurr1.Enabled = False
        Me.uCurr1.Location = New System.Drawing.Point(376, 24)
        Me.uCurr1.Name = "uCurr1"
        Me.uCurr1.Size = New System.Drawing.Size(100, 21)
        Me.uCurr1.TabIndex = 1
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(234, 26)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(136, 16)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Total Amount:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utTotalAmount
        '
        Appearance12.ForeColorDisabled = System.Drawing.Color.Black
        Me.utTotalAmount.Appearance = Appearance12
        Me.utTotalAmount.Enabled = False
        Me.utTotalAmount.Location = New System.Drawing.Point(488, 24)
        Me.utTotalAmount.Name = "utTotalAmount"
        Me.utTotalAmount.Size = New System.Drawing.Size(68, 21)
        Me.utTotalAmount.TabIndex = 2
        Me.utTotalAmount.Visible = False
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(8, 24)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(136, 16)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "Total Generated Invoices:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utTotalInvoices
        '
        Appearance13.ForeColorDisabled = System.Drawing.Color.Black
        Me.utTotalInvoices.Appearance = Appearance13
        Me.utTotalInvoices.Enabled = False
        Me.utTotalInvoices.Location = New System.Drawing.Point(148, 22)
        Me.utTotalInvoices.Name = "utTotalInvoices"
        Me.utTotalInvoices.Size = New System.Drawing.Size(68, 21)
        Me.utTotalInvoices.TabIndex = 0
        '
        'BillingInvoiceGen
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(664, 285)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Name = "BillingInvoiceGen"
        Me.Text = "Generate Invoice "
        CType(Me.UltraDate1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDate2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.utInvoiceNo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucboAcctBillingCycle, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucboBillingCycles, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utAccountID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utAccountName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uopBillingMethod, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.utFuel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucboTerms, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDate0, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.uCurr1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utTotalAmount, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utTotalInvoices, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Dim MeText As String
    Dim dtSet As New DataSet
    Dim dvStates As New DataView
    Dim cmdTrans As SqlCommand
    Dim dtBillingCycles As New DataTable
    Class clsBillingCycles
        Public Code As String
        Public Name As String
    End Class
    Dim BCCodes() As String = {"A", "M", "W", "D"}
    Dim BCNames() As String = {"Advanced", "Monthly", "Weekly", "Daily"}
    Dim BillingCyclesPrevVal As Object

    Class CustBillInfo
        'Public ID As Int32
        Public ID As String
        Public Name As String
        Public Contact As String
        Public Add1 As String
        Public Add2 As String
        Public City As String
        Public State As String
        Public Zip As String
        Public Phone As String
        Public Fax As String
        Public eMail As String
        Public Terms As Int16 ' Number of Days to be Added to Invoice Date for Due Date
    End Class


    Private Sub BillingInvoiceGen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        AddHandler Me.Activated, AddressOf Form_Activated
        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = BILLTblPath & Me.Tag
            End If
        End If

        'UltraDate1.DateTime = Date.Now
        UltraDate2.Nullable = True
        UltraDate2.Value = Nothing 'Date.Now
        UltraDate2.FormatString = "MM/dd/yyyy"
        'UltraDate1.MaskInput
        UltraDate1.Nullable = True
        UltraDate0.FormatString = "MM/dd/yyyy"
        UltraDate0.DateTime = Date.Now

        uopBillingMethod.CheckedIndex = 0
        utAccountName.Enabled = False
        ucboBillingCycles.Enabled = True
        btnAcct.Enabled = False

        ucboAcctBillingCycle.Text = ""
        ucboAcctBillingCycle.Value = Nothing

        utAccountName.Text = ""
        utAccountID.Text = ""


        Me.CenterToScreen()

        Me.KeyPreview = True
        AddHandler Me.KeyUp, AddressOf Form_KeyUp

        MeText = Me.Text

        ' Set each control's length based on DB size
        ''SetupCtrlsLength(Me)


        ''FillucboBillingCycles("A")

        FillUCombo(ucboBillingCycles, "A")
        AddHandler ucboBillingCycles.Leave, AddressOf UCbo_Leave
        FillUCombo(ucboAcctBillingCycle, "")
        AddHandler ucboAcctBillingCycle.Leave, AddressOf UCbo_Leave

        'Group_EnDis(False)
        utInvoiceNo.Text = GetNextInvoiceNo()
        FillUCombo(ucboTerms, "", "", "Select TermsID as fldCode, Term as fldLabel, Days from " & BILLTblPath & "InvoiceTerms order by Term")
        AddHandler ucboTerms.Leave, AddressOf UCbo_Leave
        AddHandler utFuel.KeyPress, AddressOf Value_Dec_KeyPress


    End Sub
    Private Function GetNextInvoiceNo() As String
        Dim qBill As String = "Select * From " & BILLTblPath & "BillingSetup "
        Dim qMax As String = "Select isnull(Max([Invoice_No]), 0) as MaxNo From " & BILLTblPath & "Invoices "
        Dim dsTemp As New System.Data.DataSet
        Dim daTemp As New SqlDataAdapter
        Dim row As DataRow
        Dim StartNo, NextNo, MaxNo As Integer

        GetNextInvoiceNo = ""

        If Not PopulateDataset2(daTemp, dsTemp, qBill) Is Nothing Then
            If dsTemp.Tables(0).Rows.Count > 0 Then
                row = dsTemp.Tables(0).Rows(0)
                StartNo = row("Starting Invoice No")
                NextNo = row("Next Invoice No")
            End If
        End If
        daTemp.Dispose()
        dsTemp.Dispose()
        row = Nothing

        If Not PopulateDataset2(daTemp, dsTemp, qMax) Is Nothing Then
            If dsTemp.Tables(0).Rows.Count > 0 Then
                row = dsTemp.Tables(0).Rows(0)
                MaxNo = row("MaxNo")
            End If
        End If

        If (MaxNo + 1) >= StartNo Then
            GetNextInvoiceNo = MaxNo + 1
        Else
            GetNextInvoiceNo = StartNo
        End If

        daTemp.Dispose()
        dsTemp.Dispose()
        daTemp = Nothing
        dsTemp = Nothing

    End Function

    'Private Function GetNextInvoiceNo() As String
    '    Dim qBill As String = "Select * From " & BILLTblPath & "BillingSetup "
    '    Dim qMax As String = "Select isnull(Max([Invoice No]), 0) as MaxNo From " & BILLTblPath & "BillingInvoice "
    '    Dim dsTemp As New System.Data.DataSet
    '    Dim daTemp As New SqlDataAdapter
    '    Dim row As DataRow
    '    Dim StartNo, NextNo, MaxNo As Integer

    '    GetNextInvoiceNo = ""

    '    If Not PopulateDataset2(daTemp, dsTemp, qBill) Is Nothing Then
    '        If dsTemp.Tables(0).Rows.Count > 0 Then
    '            row = dsTemp.Tables(0).Rows(0)
    '            StartNo = row("Starting Invoice No")
    '            NextNo = row("Next Invoice No")
    '        End If
    '    End If
    '    daTemp.Dispose()
    '    dsTemp.Dispose()
    '    row = Nothing

    '    If Not PopulateDataset2(daTemp, dsTemp, qMax) Is Nothing Then
    '        If dsTemp.Tables(0).Rows.Count > 0 Then
    '            row = dsTemp.Tables(0).Rows(0)
    '            MaxNo = row("MaxNo")
    '        End If
    '    End If

    '    If (MaxNo + 1) >= StartNo Then
    '        GetNextInvoiceNo = MaxNo + 1
    '    Else
    '        GetNextInvoiceNo = StartNo
    '    End If

    '    daTemp.Dispose()
    '    dsTemp.Dispose()
    '    daTemp = Nothing
    '    dsTemp = Nothing

    'End Function

    Private Sub btnGenerate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGenerate.Click
        'Dim WeekDays As New clsWeekDaysCount

        'WeekDays.Date1 = UltraDate1.Value
        'WeekDays.Date2 = UltraDate2.Value
        'CountWeekDays(WeekDays)
        Me.Cursor = Cursors.WaitCursor
        Select Case uopBillingMethod.CheckedIndex
            Case 0 'By Billing Cycle
                'GenInvByBillingCycle()
                GenInvByBCyle()
            Case 1 ' By Account
                GenInvByAccount()
        End Select
        Me.Cursor = Cursors.Default


    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        'Dim MonthDays As New clsMonthDays
        'MonthDays.Year = 2000
        'MonthDays.MonthIndex = 2
        'GetMonthDays(MonthDays)

        'UltraDate2.Value = Nothing 'Date.Now
        'UltraDate2.FormatString = "MM/dd/yyyy"
        'UltraDate0.DateTime = Date.Now

        uopBillingMethod.CheckedIndex = 0
        utAccountName.Enabled = False
        ucboBillingCycles.Enabled = True
        btnAcct.Enabled = False

        ucboAcctBillingCycle.Text = ""
        ucboAcctBillingCycle.Value = Nothing

        utAccountName.Text = ""
        utAccountID.Text = ""

        utInvoiceNo.Text = GetNextInvoiceNo()
        utTotalInvoices.Text = ""
        uCurr1.Text = "0"

    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Class UGColsDef2
        Public Name As String
        Public Type As Type
        Public Format As String
        Public NoEdit As Boolean
        Public Hide As Boolean
        Public BackColor As Color
        Public MaxLength As Byte
        Public Width As Byte
    End Class

    Enum eUGCols1
        Name
        Type
        Format
        NoEdit
        Hide
        BackColor
        MaxLength
        Width
    End Enum
    Dim UGColsDef1(7) As Object

    Private Sub FillucboBillingCycles(Optional ByVal DefVal As String = "")
        Dim Cbo As Infragistics.Win.UltraWinGrid.UltraCombo
        Dim row As DataRow
        Dim col As DataColumn
        Dim dsTmp As DataSet
        Dim BCColsData(BCCodes.Length - 1) As clsBillingCycles
        Dim BCColsData2(1)() As Object
        Dim BCCols(7) As Object
        Dim i As Integer

        dtBillingCycles.Clear()
        dtBillingCycles.Columns.Clear()
        Cbo = ucboBillingCycles

        '1st way of making a structure
        BCCols(eUGCols1.Name) = New String() {"Code", "Billing Cycle"}
        BCCols(eUGCols1.Hide) = New Boolean() {True, False}
        BCCols(eUGCols1.NoEdit) = New Boolean() {True, True}
        BCCols(eUGCols1.Type) = New Type() {GetType(System.String), GetType(System.String)}
        BCCols(eUGCols1.MaxLength) = New Integer() {1, 30}
        BCCols(eUGCols1.Format) = New String() {"", ""}
        BCCols(eUGCols1.Width) = New Integer() {0, 50}
        BCCols(eUGCols1.BackColor) = New Color() {Color.White, Color.White}

        ' 2nd way of making a structure
        For i = 0 To BCColsData.Length - 1
            BCColsData(i) = New clsBillingCycles
            BCColsData(i).Code = BCCodes(i)
            BCColsData(i).Name = BCNames(i)
        Next
        'BCColsData2(0) = New Object() {New String() {"A", "B"}, New Integer() {1, 2}}
        'BCColsData2(0) = New Object() {New Integer() {}, New String() {}}
        BCColsData2(0) = New Object() {New Integer() {}, New String() {}}
        BCColsData2(0)(0) = BCCodes
        BCColsData2(0)(1) = BCNames


        dsTmp = New DataSet
        dsTmp.Tables.Add(dtBillingCycles)
        'tbltmp = dsTmp.Tables.Add("BillingCycles")

        For i = 0 To BCCols(eUGCols1.Name).Length - 1
            dtBillingCycles.Columns.Add(BCCols(eUGCols1.Name)(i), BCCols(eUGCols1.Type)(i))
        Next
        'rowtmp = tbltmp.NewRow
        dtBillingCycles.Rows.Add(BCColsData2(0))

        Cbo.DataSource = dtBillingCycles ' dsTmp.Tables(0)

        Cbo.DisplayMember = BCCols(eUGCols1.Name)(1) 'dtView.Table.Columns("fldLabel").ToString
        Cbo.ValueMember = BCCols(eUGCols1.Name)(0) 'dtView.Table.Columns("fldCode").ToString

        If DefVal <> "" Then
            Cbo.Value = DefVal
        Else
            'Cbo.PerformAction(Infragistics.Win.UltraWinGrid.UltraComboAction.FirstRow)
        End If
        Cbo.DisplayLayout.Bands(0).HeaderVisible = False
        Cbo.DisplayLayout.Bands(0).ColHeadersVisible = False
        Cbo.DisplayLayout.Bands(0).Columns(0).Hidden = True
        Cbo.AutoEdit = True

    End Sub

    Private Sub uopBillingMethod_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles uopBillingMethod.ValueChanged
        Select Case uopBillingMethod.CheckedIndex
            Case 0 'By Billing Cycle
                utAccountName.Enabled = False
                ucboBillingCycles.Enabled = True
                ucboAcctBillingCycle.Text = ""
                ucboAcctBillingCycle.Value = Nothing
                utAccountName.Text = ""
                utAccountID.Text = ""
                btnAcct.Enabled = False
            Case 1 ' By Account
                utAccountName.Enabled = True
                ucboBillingCycles.Enabled = False
                btnAcct.Enabled = True
        End Select
    End Sub

    'Private Sub Value_Int_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles utAccountName.KeyPress
    '    If IsNumeric(e.KeyChar) = False And Asc(e.KeyChar) <> Keys.Back Then
    '        e.Handled = True
    '    End If
    'End Sub
    Private Sub Condition_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles utAccountName.KeyUp
        Dim WGTGrpSQL As String

        If e.KeyCode = Keys.Enter Then Exit Sub

        WGTGrpSQL = AppTblPath & "Customer"
        TypeAhead(sender, e, WGTGrpSQL, "Name", "")
        'sender.modified = True
    End Sub

    Private Sub utAccountName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utAccountName.Leave
        Dim row As DataRow
        Dim FldName As String
        FldName = "Name"

        If sender.text.trim = "" Then
            utAccountID.Text = ""
        ElseIf SearchOnLeave(sender, utAccountID, AppTblPath & "Customer", "ID", FldName, "*", "Accounts") Then
            If ReturnRowByID(utAccountID.Text, row, AppTblPath & "Customer", , "ID") Then
                FldName = row("BCycleCode")
                ucboAcctBillingCycle.Value = row("BCycleCode")
                row.Delete()
                row = Nothing
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
                    " , FuelSurcharge as [F.Sur], IncreaseDate as [Inc.Date], IncreaseRate as [Inc.Rate], Status, AcctGroupID, SamePayAddress, NRVNU as NonRvnuAcct" & _
                    " From " & AppTblPath & "Customer Where Status = 1 order by Name"

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
                'Message modified by Michael Pastor
                MsgBox("SQL_Error: " & osqlexception.Message, MsgBoxStyle.Critical, "Critical Error")
                '- MsgBox("SQL_Error: " & osqlexception.Message)
                Srch = Nothing
                sender.Focus()
                Exit Try
            Finally
                If HasErr = False Then
                    ugRow = Srch.UltraGrid1.ActiveRow
                    utAccountName.Text = ugRow.Cells("Name").Text
                    utAccountID.Text = ugRow.Cells("ID").Text
                    ucboAcctBillingCycle.Value = ugRow.Cells("BCycle").Text
                    Srch = Nothing
                    ClearForm(GroupBox2)
                    ClearForm(GroupBox4)
                    utAccountID.Modified = False
                    'rbWeekly.Checked = Not (rbWeekly.Checked)

                    If btnNew.Text.ToUpper = "&NEW" Then
                        'LoadGridData()
                    End If
                End If
            End Try
        End If
    End Sub

    Private Sub UltraDate2_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraDate2.Leave
        If UltraDate2.Value Is Nothing Then Exit Sub
        Dim TempDate As Date
        Dim UCbo As Infragistics.Win.UltraWinGrid.UltraCombo

        If UltraDate2.Value Is Nothing Then
            UltraDate1.Value = Nothing
            Exit Sub
        End If
        Select Case uopBillingMethod.CheckedIndex
            Case 0 ' By Billing Class
                UCbo = ucboBillingCycles
            Case 1 ' By Account
                UCbo = ucboAcctBillingCycle
        End Select
        If UCbo Is Nothing Then
            'Message modified by Michael Pastor
            MsgBox("Billing method remains unspecified. Please select a billing method to continue.", MsgBoxStyle.Exclamation, "Missing Data Input")
            '- MsgBox("Billing Method Unknown??")
            Exit Sub
        End If
        Select Case UCbo.Value
            Case "A", "M"
                TempDate = DateAdd(DateInterval.Day, 1, UltraDate2.Value)
                If Month(TempDate) = Month(UltraDate2.Value) Then
                    'Message modified by Michael Pastor
                    MsgBox("The specified closing date is an invalid closing date for this customer. Please enter a valid closing date to continue.", MsgBoxStyle.Exclamation, "Data Invalid")
                    '- MsgBox("The Selected Date is not end of the month.")
                    UltraDate2.Value = Nothing
                    UltraDate1.Value = Nothing
                    UltraDate2.Focus()
                    Exit Sub
                End If
                TempDate = DateAdd(DateInterval.Month, -1, TempDate)
                UltraDate1.Value = TempDate
            Case "W", "D"
                TempDate = DateAdd(DateInterval.Day, -6, UltraDate2.Value)
                UltraDate1.Value = TempDate
        End Select
    End Sub

    Private Sub ucboBillingCycles_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucboBillingCycles.Leave
        If ucboBillingCycles.Value <> BillingCyclesPrevVal Then
            UltraDate2.Value = Nothing
            UltraDate1.Value = Nothing
        End If
    End Sub

    Private Sub ucboBillingCycles_Enter(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucboBillingCycles.Enter
        BillingCyclesPrevVal = ucboBillingCycles.Value
    End Sub

    Private Function CreateBlankInvoice(ByVal InvID As Int32, ByVal InvDate As String, ByVal CloseDate As String, ByVal BillInfo As CustBillInfo) As Boolean
        Dim qInsert = "Insert into " & BILLTblPath & " Invoices(Invoice_NO, Invoice_Date, Due_Date, CustomerID, Name, Contact, Address1, Address2, City, State, Zip, Phone, Fax, email, Closing_Date) " & _
                         " Values(" & InvID & ", '" & InvDate & "', DateAdd(Day, " & BillInfo.Terms & ", '" & InvDate & "'), '" & BillInfo.ID & "', '" & BillInfo.Name & "', '" & BillInfo.Contact & "', '" & BillInfo.Add1 & "', '" & BillInfo.Add2 & "', '" & BillInfo.City & "', '" & BillInfo.State & "', '" & BillInfo.Zip & "', '" & BillInfo.Phone & "', '" & BillInfo.Fax & "', '" & BillInfo.eMail & "', '" & CloseDate & "')"
        ' The reason We don't use a query to fetch Customer Info is that in Unison we have a different structure for Customer Table.
        '" Select " & InvID & ", '" & InvDate & "', '" & CustID & "', c.
        CreateBlankInvoice = False

        If utTotalInvoices.Text <> "" Then
            'Message modified by Michael Pastor
            MsgBox("To start a new billing invoice, please press 'New'.", MsgBoxStyle.Information, "Information")
            '- MsgBox("Please press 'New' button to start a new billing.")
            GoTo Release
        End If
        If InvID = 0 Then
            'Message modified by Michael Pastor
            MsgBox("Invoice number remains unspecified. Please enter a valid invoice number to continue.", MsgBoxStyle.Exclamation, "Missing Data Input")
            '- MsgBox("Invoice No. not specified.")
            GoTo Release
        End If

        If ExecuteQuery(qInsert) = True Then
            CreateBlankInvoice = True
        End If
Release:

    End Function
    Private Function GetBillInfo(ByVal CustID As String) As CustBillInfo
        Dim TmpInfo As New CustBillInfo
        Dim q = " Select CustomerID, Name, Contact, Address1, Address2, City, State, Zip, Phone, eMail From " & BILLTblPath & "Customer " ' where CustomerID = '" & CustID & "'"
        Dim q2 As String = " Select * from " & BILLTblPath & "InvoiceTerms where TermsID = " & ucboTerms.Value
        Dim row As DataRow
        Dim row2 As DataRow

        If ReturnRowByID(CustID, row, BILLTblPath & "Customer", "", "CustomerID") Then
            TmpInfo.ID = CustID
            TmpInfo.Name = row("Name") & ""
            TmpInfo.Name = Replace(TmpInfo.Name, "'", "''")
            TmpInfo.Contact = row("Contact") & ""
            TmpInfo.Add1 = row("Address1") & ""
            TmpInfo.Add2 = row("Address2") & ""
            TmpInfo.City = row("City") & ""
            TmpInfo.State = row("State") & ""
            TmpInfo.Zip = row("Zip") & ""
            TmpInfo.Phone = row("Phone") & ""
            TmpInfo.Fax = "" 'row("Fax")
            TmpInfo.eMail = row("email") & ""
            TmpInfo.Terms = ucboTerms.ActiveRow.Cells("Days").Value

            'If ReturnRowByID(CustID, row2, AppTblPath & "InvoiceTerms", "", "TermsID", q2) Then
            '    TmpInfo.Terms = row("Days")
            'Else
            '    TmpInfo.Terms = 0
            'End If

            GetBillInfo = TmpInfo
        Else
            GetBillInfo = Nothing
        End If
        row = Nothing
        row2 = Nothing

    End Function

    Private Sub GenInvByAccount()
        Dim InvID, BeginInvID As Integer
        Dim dsAllAccts As New System.Data.DataSet
        Dim daAllAccts As New SqlDataAdapter
        Dim row As DataRow
        Dim BillInfo As New CustBillInfo

        BeginInvID = 0
        InvID = Val(utInvoiceNo.Text)
        If InvID = 0 Then
            'Message modified by Michael Pastor
            MsgBox("Starting invoice number remains unspecified. Please enter a valid starting invoice number to continue.", MsgBoxStyle.Exclamation, "Missing Data Input")
            '- MsgBox("Invoice No. is not specified.")
            Exit Sub
        End If
        If ucboTerms.ActiveRow Is Nothing Then
            'Message modified by Michael Pastor
            MsgBox("Invoice terms remain unspecified. Please select an invoice term to continue.", MsgBoxStyle.Exclamation, "Missing Data Input")
            '- MsgBox("Select Terms for this Billing...")
            Exit Sub
        End If
        BillInfo = GetBillInfo(utAccountID.Text)
        If CreateBlankInvoice(InvID, UltraDate0.Value, UltraDate2.Value, BillInfo) = False Then
            'Message modified by Michael Pastor
            MsgBox("Error creating Invoice '" & InvID & "'. Please revise the number.", MsgBoxStyle.Exclamation, "Data Invalid")
            '- MsgBox("Error creating Invoice '" & InvID & "'. Please revise the number.")
            Exit Sub
        End If

        RoutesBilling(InvID, utAccountID.Text, ucboAcctBillingCycle.Value, UltraDate1.Value, UltraDate2.Value)
        'HolidaysBilling(TempInvID, UltraDate1.Value, UltraDate2.Value)
        'WeightBilling(TempInvID, UltraDate1.Value, UltraDate2.Value)
        'OrdersBilling(TempInvID, UltraDate1.Value, UltraDate2.Value)
        'MiscBilling(TempInvID, UltraDate1.Value, UltraDate2.Value)
        'CreateInvoice(TempInvID) ' This overwrites previous saved totals for temp invoice

        '--This is for Tracking Module
        PricePlanBilling(InvID, utAccountID.Text, "", UltraDate1.Value, UltraDate2.Value)
        MoveMftInvToArchive(InvID)
        '--End Tracking Billing

        MiscBilling(InvID, BillInfo, UltraDate2.Value)

        'InvID = CreateInvoice(InvID, utAccountID.Text, utAccountName.Text, UltraDate0.Value, UltraDate1.Value, UltraDate2.Value, ucboBillingCycles.Value)
        'If InvID <= 0 Then
        '    MsgBox("Error Creating Invoice for Acct.: " & utAccountID.Text & "")
        '    Exit Sub
        'End If
        If InvID <> Val(utInvoiceNo.Text) Then
            utInvoiceNo.Text = InvID
        End If

        If BeginInvID = 0 Then BeginInvID = InvID

        'AssignInvoice(InvID, utAccountID.Text, UltraDate0.Value)
        'ExecuteQuery("Update " & BILLTblPath & "BillingInvoice Set [Amnt Due] = (Select ISNULL(SUM(Charge), 0) as RCharge From " & BILLTblPath & "BillingInvoiceRouteDetails where [Invoice No] = " & InvID & "), [Curr Bal] = (Select ISNULL(SUM(Charge), 0) as RCharge From " & BILLTblPath & "BillingInvoiceRouteDetails where [Invoice No] = " & InvID & ") Where [Invoice No] = " & InvID)
        CalcFuelSurcharge(utFuel.Text.Trim, InvID, BillInfo, UltraDate2.Value)

        SetInvoiceTotal(InvID)


        InvID += 1
        ' Already done in Create Invoice : ExecuteQuery("Update " & BILLTblPath & "BillingSetup Set [Next Invoice No] = " & InvID)
        ' Run Query to Total the Invoices created
        Dim sQuery As String = "Select isnull(count(Invoice_No), 0) as InvCount, isnull(Sum(Total_Amount), 0) as Total From " & BILLTblPath & "Invoices where [Invoice_No] between " & BeginInvID & " AND " & InvID - 1 & ""
        'If Not PopulateDataset2(daAllAccts, dsAllAccts, "Select isnull(count(Invoice_No), 0) as InvCount, isnull(Sum(Total_Amount), 0) as Total From " & BILLTblPath & "Invoices where [Invoice_No] between " & BeginInvID & " AND " & InvID - 1 & "") Is Nothing Then
        If Not PopulateDataset2(daAllAccts, dsAllAccts, sQuery) Is Nothing Then
            If Not dsAllAccts.Tables Is Nothing Then
                If dsAllAccts.Tables(0).Rows.Count > 0 Then
                    row = dsAllAccts.Tables(0).Rows(0)
                    utTotalAmount.Text = row("Total")
                    utTotalInvoices.Text = row("InvCount")
                    uCurr1.Text = row("Total")
                End If
            End If
        End If
Release:
        daAllAccts.Dispose()
        dsAllAccts.Dispose()
        daAllAccts = Nothing
        dsAllAccts = Nothing
        row = Nothing
    End Sub

    Private Sub SetInvoiceTotal(ByVal InvId As Int32)
        Dim qSum1 As String = "Update " & BILLTblPath & "Invoices Set Total_Amount = (Select Sum(isnull(Charge, 0)) as TotalCharge from " & BILLTblPath & "InvoiceLineItems where invoice_no = " & InvId & ") From " & BILLTblPath & "Invoices i Where i.Invoice_No =  " & InvId & ""
        If InvId = 0 Then
            'Message modified by Michael Pastor
            MsgBox("Invoice number remains unspecified. Please enter a valid invoice number to continue.", MsgBoxStyle.Exclamation, "Missing Data Input")
            '- MsgBox("Invoice No. is not specified.")
            Exit Sub
        End If
        ExecuteQuery(qSum1)
    End Sub


    Private Sub GenInvByBCyle()
        Dim InvID, BeginInvID As Integer
        Dim dsAllAccts As New System.Data.DataSet
        Dim daAllAccts As New SqlDataAdapter
        Dim row As DataRow
        Dim BillInfo As New CustBillInfo

        BeginInvID = 0
        InvID = Val(utInvoiceNo.Text)
        If InvID = 0 Then
            MsgBox("Starting invoice number remains unspecified. Please enter a valid starting invoice number to continue.", MsgBoxStyle.Exclamation, "Missing Data Input")
            Exit Sub
        End If
        If ucboTerms.ActiveRow Is Nothing Then
            MsgBox("Invoice terms remain unspecified. Please select an invoice term to continue.", MsgBoxStyle.Exclamation, "Missing Data Input")
            Exit Sub
        End If

        '  Dim qAcctsByBCycle As String = "Select ID, Name From " & AppTblPath & "Customer where BCycleCode = '" & ucboBillingCycles.Value & "' and ID='13005'"
        'Dim qAcctsByBCycle As String = "Select ID, Name ,FuelSURCHARGE From " & AppTblPath & "Customer where BCycleCode = '" & ucboBillingCycles.Value & "' and ID='13005'"
        'Dim qAcctsByBCycle As String = "Select ID, Name From " & AppTblPath & "Customer where BCycleCode = '" & ucboBillingCycles.Value & "' and ID='13017'"
        'Dim qAcctsByBCycle As String = "Select ID, Name From " & AppTblPath & "Customer where BCycleCode = '" & ucboBillingCycles.Value & "' and ID='26128'"
        ' Dim qAcctsByBCycle As String = "Select ID, Name From " & AppTblPath & "Customer where BCycleCode = '" & ucboBillingCycles.Value & "' and ID='12646'"
        ' Dim qAcctsByBCycle As String = "Select ID, Name From " & AppTblPath & "Customer where BCycleCode = '" & ucboBillingCycles.Value & "' and ID='25140'"
        Dim qAcctsByBCycle As String = "Select ID, Name ,FuelSURCHARGE From " & AppTblPath & "Customer where BCycleCode = '" & ucboBillingCycles.Value & "' "


        If PopulateDataset2(daAllAccts, dsAllAccts, qAcctsByBCycle) Is Nothing Then
            'Message modified by Michael Pastor
            MsgBox("No customer with the specified billing cycle can be found.", MsgBoxStyle.Exclamation, "Data Unavailable")
            '- MsgBox("No Customer with the specified Billing Cycle Found.")
            GoTo Release
        End If

        Dim m_accountid = ""
        Dim m_FuelSURCHARGE = ""

        For Each row In dsAllAccts.Tables(0).Rows
            m_accountid = row("ID")
            m_FuelSURCHARGE = row("FuelSURCHARGE")
            utAccountID.Text = m_accountid

            BillInfo = GetBillInfo(utAccountID.Text)
            'BillInfo = GetBillInfo(m_accountid)
            If CreateBlankInvoice(InvID, UltraDate0.Value, UltraDate2.Value, BillInfo) = False Then
                MsgBox("Error creating Invoice '" & InvID & "'. Please revise the number.", MsgBoxStyle.Exclamation, "Data Invalid")
                Exit Sub
            End If

            RoutesBilling(InvID, utAccountID.Text, ucboAcctBillingCycle.Value, UltraDate1.Value, UltraDate2.Value)
            '--This is for Tracking Module
            PricePlanBilling(InvID, utAccountID.Text, "", UltraDate1.Value, UltraDate2.Value)
            MoveMftInvToArchive(InvID)
            '--End Tracking Billing

            MiscBilling(InvID, BillInfo, UltraDate2.Value)

            If InvID <> Val(utInvoiceNo.Text) Then
                utInvoiceNo.Text = InvID
            End If

            If BeginInvID = 0 Then BeginInvID = InvID

            If m_FuelSURCHARGE = 0 Then
                CalcFuelSurcharge(utFuel.Text.Trim, InvID, BillInfo, UltraDate2.Value)
            Else
                CalcFuelSurcharge(m_FuelSURCHARGE, InvID, BillInfo, UltraDate2.Value)
            End If

            'CalcFuelSurcharge(utFuel.Text.Trim, InvID, BillInfo, UltraDate2.Value)

            SetInvoiceTotal(InvID)


            InvID += 1

        Next
    
Release:
        daAllAccts.Dispose()
        dsAllAccts.Dispose()
        Dim sQuery As String = "Select isnull(count(Invoice_No), 0) as InvCount, isnull(Sum(Total_Amount), 0) as Total From " & BILLTblPath & "Invoices where [Invoice_No] between " & BeginInvID & " AND " & InvID - 1 & ""
        'If Not PopulateDataset2(daAllAccts, dsAllAccts, "Select isnull(count(Invoice_No), 0) as InvCount, isnull(Sum(Total_Amount), 0) as Total From " & BILLTblPath & "Invoices where [Invoice_No] between " & BeginInvID & " AND " & InvID - 1 & "") Is Nothing Then
        If Not PopulateDataset2(daAllAccts, dsAllAccts, sQuery) Is Nothing Then
            If Not dsAllAccts.Tables Is Nothing Then
                If dsAllAccts.Tables(0).Rows.Count > 0 Then
                    row = dsAllAccts.Tables(0).Rows(0)
                    utTotalAmount.Text = row("Total")
                    utTotalInvoices.Text = row("InvCount")
                    uCurr1.Text = row("Total")
                End If
            End If
        End If
        daAllAccts = Nothing
        dsAllAccts = Nothing
        row = Nothing
    End Sub


    

    Private Sub GenInvByBillingCycleold()
        Dim dsAllAccts As New System.Data.DataSet
        Dim daAllAccts As New SqlDataAdapter
        Dim row As DataRow
        Dim qAcctsByBCycle As String = "Select ID, Name From " & AppTblPath & "Customer where BCycleCode = '" & ucboBillingCycles.Value & "'"
        Dim InvID, BeginInvID As Integer


        'Exit Sub



        If PopulateDataset2(daAllAccts, dsAllAccts, qAcctsByBCycle) Is Nothing Then
            'Message modified by Michael Pastor
            MsgBox("No customer with the specified billing cycle can be found.", MsgBoxStyle.Exclamation, "Data Unavailable")
            '- MsgBox("No Customer with the specified Billing Cycle Found.")
            GoTo Release
        End If
        If dsAllAccts.Tables(0) Is Nothing Then
            'Message modified by Michael Pastor
            MsgBox("No customer with the specified billing cycle can be found.", MsgBoxStyle.Exclamation, "Data Unavailable")
            '- MsgBox("No Customer with the specified Billing Cycle Found.")
            GoTo Release
        End If
        BeginInvID = 0
        InvID = Val(utInvoiceNo.Text)
        For Each row In dsAllAccts.Tables(0).Rows
            InvID = CreateInvoice(InvID, row("ID"), row("Name"), UltraDate0.Value, UltraDate1.Value, UltraDate2.Value, ucboBillingCycles.Value)
            If InvID <= 0 Then
                'Message modified by Michael Pastor
                MsgBox("Error Creating Temprary Invoice for Acct.: " & row("ID"), MsgBoxStyle.Exclamation, "Data Unavailable")
                '- MsgBox("Error Creating Temprary Invoice for Acct.: " & row("ID") & "")
                GoTo Release
            End If
            If InvID <> Val(utInvoiceNo.Text) Then

            End If
            If BeginInvID = 0 Then BeginInvID = InvID

            RoutesBilling(InvID, row("ID"), ucboBillingCycles.Value, UltraDate1.Value, UltraDate2.Value)
            AssignInvoice(InvID, row("ID"), UltraDate0.Value)
            ExecuteQuery("Update " & BILLTblPath & "BillingInvoice Set [Amnt Due] = (Select ISNULL(SUM(Charge), 0) as RCharge From " & BILLTblPath & "BillingInvoiceRouteDetails where [Invoice No] = " & InvID & "), [Curr Bal] = (Select ISNULL(SUM(Charge), 0) as RCharge From " & BILLTblPath & "BillingInvoiceRouteDetails where [Invoice No] = " & InvID & ") Where [Invoice No] = " & InvID)
            InvID += 1
        Next
        ' Already done in CreateInvoice : ExecuteQuery("Update " & BILLTblPath & "BillingSetup Set [Next Invoice No] = " & InvID)
        ' Run Query to Total the Invoices created
        daAllAccts.Dispose()
        dsAllAccts.Dispose()
        If Not PopulateDataset2(daAllAccts, dsAllAccts, "Select isnull(count([Curr Bal]), 0) as InvCount, isnull(Sum([Curr Bal]), 0) as Total From " & BILLTblPath & "BillingInvoice where [Invoice No] between " & BeginInvID & " AND " & InvID - 1 & "") Is Nothing Then
            If Not dsAllAccts.Tables Is Nothing Then
                If dsAllAccts.Tables(0).Rows.Count > 0 Then
                    row = dsAllAccts.Tables(0).Rows(0)
                    utTotalAmount.Text = row("Total")
                    utTotalInvoices.Text = row("InvCount")
                End If
            End If
        End If
Release:
        daAllAccts.Dispose()
        dsAllAccts.Dispose()
        daAllAccts = Nothing
        dsAllAccts = Nothing
        row = Nothing
    End Sub

    Private Function CreateInvoice(ByVal InvoiceNo As String, ByVal AcctID As Integer, ByVal AcctName As String, ByVal InvoiceDate As Date, ByVal PeriodBegin As Date, ByVal PeriodEnd As Date, ByVal BCycleCode As String) As Integer
        Dim qSearchExistingInv As String = "Select * From " & BILLTblPath & "BillingInvoice where [Acct ID] = " & AcctID & " AND [Fr Date] = '" & PeriodBegin & "' and [To Date] = '" & PeriodEnd & "'"
        Dim qSearchExistingInvNo As String = "Select * From " & BILLTblPath & "BillingInvoice where [Invoice No] = " & InvoiceNo & ""
        Dim dsTempInv As New System.Data.DataSet
        Dim daTempInv As New SqlDataAdapter
        'Dim qMax As String = "Select isnull(Max([Invoice No]), 0) as MaxNo From " & BILLTblPath & "BillingInvoice "
        'Dim dsTemp As New System.Data.DataSet
        'Dim daTemp As New SqlDataAdapter
        Dim MaxNo As Integer
        Dim row As DataRow

        If utTotalInvoices.Text <> "" Then
            'Message modified by Michael Pastor
            MsgBox("To start a new billing invoice, please press 'New'.", MsgBoxStyle.Information, "Information")
            '- MsgBox("Please press 'New' button to start a new billing.")
            GoTo Release
        End If
        CreateInvoice = -1
        'If Not PopulateDataset2(daTempInv, dsTempInv, qSearchExistingInvNo) Is Nothing Then
        '    If Not dsTempInv.Tables(0) Is Nothing Then

        '    End If
        'End If
        daTempInv.Dispose()
        dsTempInv.Dispose()
        'If PopulateDataset2(daTempInv, dsTempInv, qSearchExistingInv) Is Nothing Then
        '    MsgBox("Error in fetching the Invoice in CreateInvoice.")
        '    GoTo Release
        'ElseIf dsTempInv.Tables(0).Rows.Count = 0 Then
        '    ' No previously created temp invoice found
        '    If ExecuteQuery("Insert Into " & BILLTblPath & "BillingInvoice([Invoice No], [Acct ID], [Acct Name], [Invoice Date], [Fr DATE], [To DATE]) values(" & InvoiceNo & ", " & AcctID & ", '" & Replace(AcctName, "'", "''") & "', '" & InvoiceDate & "', '" & PeriodBegin & "', '" & PeriodEnd & "')") = True Then
        '        CreateInvoice = InvoiceNo
        '        ExecuteQuery("Update " & BILLTblPath & "BillingSetup Set [Next Invoice No] = " & InvoiceNo + 1 & "")
        '    End If
        '    daTempInv.Dispose()
        '    dsTempInv.Dispose()
        '    'PopulateDataset2(daTempInv, dsTempInv, qSearchExistingInv)
        '    'row = dsTempInv.Tables(0).Rows(0)
        '    'CreateInvoice = row("Invoice No")
        'Else
        '    ' A previously created temp invoice found
        '    row = dsTempInv.Tables(0).Rows(0)
        '    CreateInvoice = row("Invoice No")
        'End If

        If ExecuteQuery("Insert Into " & BILLTblPath & "BillingInvoice([Invoice No], [Acct ID], [Acct Name], [Invoice Date], [Fr DATE], [To DATE]) values(" & InvoiceNo & ", " & AcctID & ", '" & Replace(AcctName, "'", "''") & "', '" & InvoiceDate & "', '" & PeriodBegin & "', '" & PeriodEnd & "')") = True Then
            CreateInvoice = InvoiceNo
            ExecuteQuery("Update " & BILLTblPath & "BillingSetup Set [Next Invoice No] = " & InvoiceNo + 1 & "")
        Else
            'Message modified by Michael Pastor
            MsgBox("Unable to create invoice.", MsgBoxStyle.Exclamation, "Data Unavailable")
            '- MsgBox("Could not create Invoice.")
        End If
        daTempInv.Dispose()
        dsTempInv.Dispose()
        'PopulateDataset2(daTempInv, dsTempInv, qSearchExistingInv)
        'row = dsTempInv.Tables(0).Rows(0)
        'CreateInvoice = row("Invoice No")
Release:
        daTempInv.Dispose()
        dsTempInv.Dispose()
        daTempInv = Nothing
        dsTempInv = Nothing

    End Function

    Private Function AssignInvoice(ByVal InvoiceNo As String, ByVal AcctID As String, ByVal InvoiceDate As Date)
        ExecuteQuery("Update " & BILLTblPath & "BillingInvoiceRouteDetails set [Invoice Date] = '" & InvoiceDate & "', [Invoice No] = " & InvoiceNo & " where [Acct ID] = " & AcctID & " AND [Invoice No] = 0")
        ' For Other Modules ... ExecuteQuery("Update " & BILLTblPath & "BillingInvoiceRouteDetails set [Invoice Date] = '" & InvoiceDate & "', [Invoice No] = " & InvoiceNo & " where [Acct ID] = " & AcctID & " AND [Invoice No] = 0")

    End Function

    'Private Function RoutesBilling(ByVal TempInvID As Integer, ByVal AcctID As Integer, ByVal BCycleCode As String, ByVal PeriodBegin As Date, ByVal PeriodEnd As Date)
    Private Function RoutesBilling(ByVal TempInvID As Integer, ByVal AcctID As String, ByVal BCycleCode As String, ByVal PeriodBegin As Date, ByVal PeriodEnd As Date)
        Dim qSIDs As String = "Select * From " & ROUTESTblPath & "AccountServices where AccountID = '" & AcctID & "'"
        Dim dsTemp As New System.Data.DataSet
        Dim daTemp As New SqlDataAdapter
        Dim row As DataRow
        Dim ActualPeriodEnd, ActualPeriodBegin As Date
        Dim StartDateProRate, EndDateProRate, LastBillProRate As Decimal
        Dim PeriodHolidays As clsHolidays = Nothing
        Dim itemno As Int16 = 0
        Dim RetVal As BILLCALC_RETVALS

        If PopulateDataset2(daTemp, dsTemp, qSIDs) Is Nothing Then
            ' No Route Services
            daTemp.Dispose()
            dsTemp.Dispose()
            daTemp = Nothing
            dsTemp = Nothing
            Exit Function
        End If

        PeriodHolidays = GetHolidays(PeriodBegin, PeriodEnd)

        For Each row In dsTemp.Tables(0).Rows
            ActualPeriodEnd = PeriodEnd
            ActualPeriodBegin = PeriodBegin
            If TypeOf row("EndDate") Is DBNull Then
                If TypeOf row("Last Bill Date") Is DBNull Then
                    ' No End Date, No Last Bill Date
                    'If row("EndDate") < PeriodEnd Then
                    '    'EndDateProRate = 
                    '    'CalcEndDateProRate(TempInvID, 3, UltraDate0.Value, row, PeriodBegin, PeriodEnd)
                    '    ActualPeriodEnd = row("EndDate")
                    'End If
                    'StartDateProRate = 
                    'CalcStartDateProRate(TempInvID, 3, UltraDate0.Value, row, PeriodBegin)
                    ActualPeriodBegin = row("StartDate") ' Service is not billed yet
                    'RunBillingForService(AcctID, Row("ID"), PeriodBegin, ActualEndPeriod, StartDateProRate, EndDateProRate, LastBillProRate)
                Else
                    'No End Date, Has Last Bill Date
                    If row("Last Bill Date") >= PeriodEnd Then GoTo NextService
                    If row("Last Bill Date") < row("StartDate") Then
                        ''Restarted Service
                        ''???ActualPeriodBegin = row("StartDate")
                        ''Deduct or add ProRate of StartDate to the regular Billing Period Charge
                        'StartDateProRate = CalcStartDateProRate()
                        ActualPeriodBegin = row("StartDate")
                    ElseIf row("Last Bill Date") >= row("StartDate") Then
                        'LastBillProRate = CalcLastBillDateProRate()
                        ActualPeriodBegin = DateAdd(DateInterval.Day, 1, row("Last Bill Date"))
                    End If
                    'RunBillingForService(AcctID, Row("ID"), PeriodBegin, ActualEndPeriod, StartDateProRate, EndDateProRate, LastBillProRate)
                End If
            Else
                'Has End Date
                If TypeOf row("Last Bill Date") Is DBNull Then
                    ' Has End Date, No Last Bill Date
                    If row("EndDate") < PeriodEnd Then
                        'EndDateProRate = CalcEndDateProRate()
                        ActualPeriodEnd = row("EndDate")
                    End If
                    'StartDateProRate = CalcStartDateProRate()
                    ActualPeriodBegin = row("StartDate") ' Service is not billed yet
                    'RunBillingForService(AcctID, Row("ID"), PeriodBegin, ActualEndPeriod, StartDateProRate, EndDateProRate, LastBillProRate)
                Else
                    ' Has End Date, Has Last Bill Date
                    If row("Last Bill Date") >= PeriodEnd Then GoTo NextService
                    If row("Last Bill Date") >= row("EndDate") Then GoTo NextService
                    If row("EndDate") < PeriodEnd Then
                        'EndDateProRate = CalcEndDateProRate()
                        ActualPeriodEnd = row("EndDate")
                    End If
                    If row("Last Bill Date") < row("StartDate") Then
                        ''Restarted Service
                        ''???ActualPeriodBegin = row("StartDate")
                        ''Deduct or add ProRate of StartDate to the regular Billing Period Charge
                        'StartDateProRate = CalcStartDateProRate()
                        ActualPeriodBegin = row("StartDate")
                    ElseIf row("Last Bill Date") >= row("StartDate") Then
                        'LastBillProRate = CalcLastBillDateProRate()
                        ActualPeriodBegin = DateAdd(DateInterval.Day, 1, row("Last Bill Date"))
                    End If
                    'RunBillingForService(AcctID, Row("ID"), PeriodBegin, ActualEndPeriod, StartDateProRate, EndDateProRate, LastBillProRate)
                End If
            End If
            If BCycleCode = "A" And ActualPeriodBegin > PeriodBegin Then GoTo NextService
            itemno = 1

            If ActualPeriodBegin < PeriodBegin Then
                'CalcServicePeriodCahrge()
                If ActualPeriodEnd < PeriodBegin Then
                    RetVal = CalcServicePeriodCharge(TempInvID, itemno, UltraDate0.Value, row, ActualPeriodBegin, ActualPeriodEnd, BCycleCode)
                Else
                    RetVal = CalcServicePeriodCharge(TempInvID, itemno, UltraDate0.Value, row, ActualPeriodBegin, DateAdd(DateInterval.Day, -1, PeriodBegin), BCycleCode)
                End If
                ActualPeriodBegin = PeriodBegin
            End If
            If RetVal = BILLCALC_RETVALS.BILLCALC_SKIP Then GoTo NextService
            If RetVal = BILLCALC_RETVALS.BILLCALC_STOP Then Exit For

            itemno += 1
            If ActualPeriodEnd >= PeriodBegin Then
                If ActualPeriodEnd < PeriodEnd Or ActualPeriodBegin > PeriodBegin Then
                    RetVal = CalcServicePeriodCharge(TempInvID, itemno, UltraDate0.Value, row, ActualPeriodBegin, ActualPeriodEnd, BCycleCode)
                Else
                    '()
                    RetVal = CalcFullPeriodServiceCharge(TempInvID, itemno, UltraDate0.Value, row, ActualPeriodBegin, ActualPeriodEnd, BCycleCode, PeriodHolidays)
                End If
            End If
            If RetVal = BILLCALC_RETVALS.BILLCALC_SKIP Then GoTo NextService
            If RetVal = BILLCALC_RETVALS.BILLCALC_STOP Then Exit For

            'ExecuteQuery("Update " & ROUTESTblPath & "AccountServices Set [Last Bill Date] = '" & ActualPeriodEnd & "' where AccountID = " & row("AccountID") & " AND ID = " & row("ID") & "")
            ExecuteQuery("Update " & ROUTESTblPath & "AccountServices Set [Last Bill Date] = '" & ActualPeriodEnd & "' where AccountID = '" & row("AccountID") & "' AND ID = " & row("ID") & "")
NextService:
        Next
        daTemp.Dispose()
        dsTemp.Dispose()
        daTemp = Nothing
        dsTemp = Nothing
    End Function
    'Private Function PricePlanBilling(ByVal TempInvID As Integer, ByVal AcctID As Integer, ByVal BCycleCode As String, ByVal PeriodBegin As Date, ByVal PeriodEnd As Date)
    Private Function PricePlanBilling(ByVal TempInvID As Integer, ByVal AcctID As String, ByVal BCycleCode As String, ByVal PeriodBegin As Date, ByVal PeriodEnd As Date)

        Dim qPlans As String = "Select pp.PlanID, pp.Plan_Name, pp.PlanTypeCode, pp.Charge_Code, pp.From_Zone, pp.To_Zone, pp.Start_Date, pp.End_Date, pp.ModuleName, pp.TableName, pp.ColumnName, pp.ColumnPrefix, pp.ColumnSuffix, pp.Invoice_Title, pp.Taxable, pp.Description From " & BILLTblPath & "PricePlans pp, " & BILLTblPath & "PricePlanCustomer ppc where pp.planid = ppc.planid and ppc.CustomerID = '" & AcctID & "' Order by pp.PlanID"
        Dim dsTemp As New System.Data.DataSet
        Dim daTemp As New SqlDataAdapter
        Dim row As DataRow
        Dim ActualPeriodEnd, ActualPeriodBegin As Date
        Dim itemno As Int16 = 0
        Dim RetVal As BILLCALC_RETVALS
        Dim ModuleName, TableName, ColumnName, ColPrefix, ColSuffix, ChargeTitle, Desc As String
        Dim FromZone, ToZone As Int32
        Dim Taxable As Boolean
        Dim StartDate, EndDate As Date
        Dim PlanID As Int32

        If PopulateDataset2(daTemp, dsTemp, qPlans) Is Nothing Then
            ' No Plans
            daTemp.Dispose()
            dsTemp.Dispose()
            daTemp = Nothing
            dsTemp = Nothing
            Exit Function
        End If
        If dsTemp.Tables(0).Rows.Count <= 0 Then
            MsgBox("No PricePlan found for CustomerID: " & AcctID)
            Exit Function
        End If

        For Each row In dsTemp.Tables(0).Rows
            PlanID = row("PlanID")
            FromZone = IIf(row("From_Zone") Is DBNull.Value, 0, row("From_Zone"))
            ToZone = IIf(row("To_Zone") Is DBNull.Value, 0, row("To_Zone"))
            ModuleName = IIf(row("ModuleName") Is DBNull.Value, "", row("ModuleName")) ' TRACKING, ORDERING
            TableName = row("TableName") & ""
            ColumnName = row("ColumnName") & ""
            ColPrefix = row("ColumnPrefix") & ""
            ColSuffix = row("Columnsuffix") & ""
            ChargeTitle = row("Invoice_Title") & ""
            Taxable = row("Taxable")
            Desc = row("Description") & ""
            StartDate = IIf(TypeOf row("Start_Date") Is System.DBNull, Nothing, row("Start_Date"))
            EndDate = IIf(TypeOf row("End_Date") Is System.DBNull, Nothing, row("End_Date"))
            Select Case row("PlanTypeCode")
                Case "R" ' Range
                    PPCalcRangeCharge(AcctID, TempInvID, PeriodEnd, PlanID, StartDate, EndDate, ModuleName, TableName, ColumnName, ColPrefix, ColSuffix, ChargeTitle, Desc, Taxable, FromZone, ToZone)
                Case "F" ' Fixed 
                    PPCalcFixedCharge(AcctID, TempInvID, PeriodEnd, PlanID, StartDate, EndDate, ModuleName, TableName, ColumnName, ColPrefix, ColSuffix, ChargeTitle, Desc, Taxable, FromZone, ToZone)
                Case Else
                    MsgBox("Unknown PlanType")
                    Exit Function
            End Select
        Next
        daTemp.Dispose()
        dsTemp.Dispose()
        daTemp = Nothing
        dsTemp = Nothing




    End Function

    Private Sub PPCalcRangeCharge(ByVal FromCustID As String, ByVal TempInvID As Integer, ByVal InvCloseDate As Date, ByVal PlanID As Integer, ByVal StartDate As Date, ByVal EndDate As Date, ByVal ModuleName As String, ByVal TableName As String, ByVal ColumnName As String, ByVal ColPrefix As String, ByVal ColSuffix As String, ByVal ChargeTitle As String, ByVal Desc As String, ByVal Taxable As Boolean, Optional ByVal FromZone As Int32 = 0, Optional ByVal ToZone As Int32 = 0)
        Dim ToDate As Date = Nothing

        If ColumnName.Trim = "" Then
            MsgBox("Wrong Plan. No Column Name.")
            Exit Sub
        End If
        If StartDate = Nothing Then
            'Message modified by Michael Pastor
            MsgBox("Start date remains unspecified. Please select a start date to continue.", MsgBoxStyle.Exclamation, "Missing Data Input")
            '- MsgBox("Plan Start_Date is not set. Exiting ...")
            Exit Sub
        End If
        If EndDate = Nothing Then
            ToDate = InvCloseDate
        Else
            'If EndDate = String.Empty Then
            '    ToDate = InvCloseDate
            'Else
            ToDate = IIf(InvCloseDate > EndDate, EndDate, InvCloseDate)
            'End If
        End If

        If ModuleName.ToUpper = "TRACKING" Then
            'Dim qChg As String = BILLTblPath & "CalcMftCharge_RangeV2 " & PlanID & ", '" & TempInvID & "', '" & FromCustID & "', '" & StartDate & "', '" & IIf(ToDate = Nothing, "", ToDate) & "', " & FromZone & ", " & ToZone & ", '" & TableName.Trim & "', '" & ColumnName.Trim & "', '" & BILLTblPath & "' "
            Dim qChg As String = BILLTblPath & "CalcMftCharge_RangeV3 " & PlanID & ", '" & TempInvID & "', '" & FromCustID & "', '" & StartDate & "', '" & IIf(ToDate = Nothing, "", ToDate) & "', " & FromZone & ", " & ToZone & ", '" & TableName.Trim & "', '" & ColumnName.Trim & "', '" & BILLTblPath & "' "
            ExecuteQuery(qChg)

            ' 2. Add LineItems from Manifest to InvoiceLineItems
            'Dim InsertQry As String = " Insert into " & AppTblPath & "InvoiceLineItems(Invoice_No, Invoice_Date, Description, UnitPrice, Prefix, Qty, Suffix, Unit, Charge, Tax, PlanID, MftRowID) " & _
            '                          " Select mftx.Invoice_NO , (Select TOP 1 Invoice_Date from " & AppTblPath & "Invoices where invoice_No = mftx.Invoice_No ORDER BY INVOICE_dATE DESC) as Invoice_Date, '" & Desc & "' as [Description], NULL as UnitPrice, '" & ColPrefix & "' as Prefix, mftx." & ColumnName & " as Qty, '' as suffix, '" & ColSuffix & "' as unit, Charge , '" & IIf(Taxable, "T", "") & "' as Tax, " & PlanID & " as PlanID, mftx.RowID from " & AppTblPath & "MANIFESTINVOICE mftx where mftx.invoice_no = '" & TempInvID & "' and mftx.PlanID = " & PlanID
            'If ChargeTitle.Trim <> "" Then
            '    Dim qTitle As String = "Insert into  " & AppTblPath & "InvoiceLineItems(Invoice_No, Invoice_Date, Description, PlanID) " & _
            '                           " Select '" & TempInvID & "' as Invoice_NO , (Select TOP 1 Invoice_Date from " & AppTblPath & "Invoices where invoice_No = '" & TempInvID & "' ORDER BY INVOICE_dATE DESC) as Invoice_Date, '" & ChargeTitle & "' as [Description], " & PlanID & " as PlanID "
            '    'ExecuteQuery(qTitle)
            'End If
            ''ExecuteQuery(InsertQry)
        End If


        'Select mftx.Invoice_NO, (Select isnull(max(LineNum), 0)+1 from InvoiceLineItems where Invoice_No = mftx.Invoice_No ) as LineNum, (Select TOP 1 Invoice_Date from Invoices where invoice_No = mftx.Invoice_No ORDER BY INVOICE_dATE DESC) as Invoice_Date, 'Desc' as [Description], 5.6 as UnitPrice, '' as Prefix, weight as Qty, '' as suffix, 'lb' as unit, Charge from ManifestInvoice mftx where mftx.invoice_no = 123
        'SELECT     Weight, (SELECT ppc.Charge FROM PricePlanCharges ppc WHERE (mft.weight BETWEEN From_Range AND To_Range) AND ppc.planid = 456) AS WCharge
        'FROM         ManifestInvoice mft
        'WHERE     (FromCustID = 123) AND (Invoice_No IS NULL) OR
        '                      (RTRIM(Invoice_No) = '')




    End Sub

    Private Sub PPCalcFixedCharge(ByVal FromCustID As String, ByVal TempInvID As Integer, ByVal InvCloseDate As Date, ByVal PlanID As Integer, ByVal StartDate As Date, ByVal EndDate As Date, ByVal ModuleName As String, ByVal TableName As String, ByVal ColumnName As String, ByVal ColPrefix As String, ByVal ColSuffix As String, ByVal ChargeTitle As String, ByVal Desc As String, ByVal Taxable As Boolean, Optional ByVal FromZone As Int32 = 0, Optional ByVal ToZone As Int32 = 0)

        Dim ToDate As Date = Nothing

        If StartDate = Nothing Then
            'Message modified by Michael Pastor
            MsgBox("Start date remains unspecified. Please select a start date to continue.", MsgBoxStyle.Exclamation, "Missing Data Input")
            '- MsgBox("Plan Start_Date is not set. Exiting ...")
            Exit Sub
        End If
        If EndDate = Nothing Then
            ToDate = InvCloseDate
        Else
            'If EndDate = "" Then
            '    ToDate = InvCloseDate
            'Else
            ToDate = IIf(InvCloseDate > EndDate, EndDate, InvCloseDate)
            'End If
        End If

        If ModuleName.ToUpper = "TRACKING" Then
            If ColumnName.Trim <> "" Then
                'Dim qChg As String = "CalcMftCharge_FixedV2 " & PlanID & ", '" & TempInvID & "', '" & FromCustID & "', '" & StartDate & "', '" & IIf(ToDate = Nothing, "", ToDate) & "', " & FromZone & ", " & ToZone & ", '" & ColumnName.Trim & "', '" & BILLTblPath & "' "
                Dim qChg As String = BILLTblPath & "CalcMftCharge_FixedV3 " & PlanID & ", '" & TempInvID & "', '" & FromCustID & "', '" & StartDate & "', '" & IIf(ToDate = Nothing, "", ToDate) & "', " & FromZone & ", " & ToZone & ", '" & TableName.Trim & "', '" & ColumnName.Trim & "', '" & BILLTblPath & "' "
                ExecuteQuery(qChg)
            End If

            ' 2. Add LineItems from Manifest to InvoiceLineItems
            'Dim InsertQry As String = "Insert into " & AppTblPath & "InvoiceLineItems(Invoice_No, Invoice_Date, Description, UnitPrice, Prefix, Qty, Suffix, Unit, Charge, Tax, PlanID) " & _
            '                          " Select mftx.Invoice_NO , (Select TOP 1 Invoice_Date from " & AppTblPath & "Invoices where invoice_No = mftx.Invoice_No ORDER BY INVOICE_dATE DESC) as Invoice_Date, '" & Desc & "' as [Description], NULL as UnitPrice, '" & ColPrefix & "' as Prefix, mftx." & ColumnName & " as Qty, '' as suffix, '" & ColSuffix & "' as unit, Charge , '" & IIf(Taxable, "T", "") & "' as Tax, " & PlanID & " as PlanID from " & AppTblPath & "ManifestInvoice mftx where mftx.invoice_no = '" & TempInvID & "' and mftx.PlanID = " & PlanID
            'If ChargeTitle.Trim <> "" Then
            '    'Dim qTitle As String = "Insert into  " & AppTblPath & "InvoiceLineItems(Invoice_No, Invoice_Date, Description, PlanID) " & _
            '    '                      " Select mftx.Invoice_NO , (Select isnull(max(LineNum), 0)+1 from " & AppTblPath & "InvoiceLineItems where Invoice_No = mftx.Invoice_No ) as LineNum, (Select TOP 1 Invoice_Date from " & AppTblPath & "Invoices where invoice_No = mftx.Invoice_No ORDER BY INVOICE_dATE DESC) as Invoice_Date, '" & ChargeTitle & "' as [Description], NULL as UnitPrice, '' as Prefix, NULL as Qty, '' as suffix, '' as unit, 0 as Charge , '' as Tax, " & PlanID & " as PlanID from " & AppTblPath & "ManifestInvoice mftx where mftx.invoice_no = '" & TempInvID & "' and mftx.PlanID = " & PlanID
            '    Dim qTitle As String = "Insert into  " & AppTblPath & "InvoiceLineItems(Invoice_No, Invoice_Date, Description, PlanID) " & _
            '                           " Select '" & TempInvID & "' as Invoice_NO , (Select TOP 1 Invoice_Date from " & AppTblPath & "Invoices where invoice_No = '" & TempInvID & "' ORDER BY INVOICE_dATE DESC) as Invoice_Date, '" & ChargeTitle & "' as [Description], " & PlanID & " as PlanID "
            '    'Ali -- ExecuteQuery(qTitle)
            'End If
            ''Ali -- ExecuteQuery(InsertQry)
        End If


        'Select mftx.Invoice_NO, (Select isnull(max(LineNum), 0)+1 from InvoiceLineItems where Invoice_No = mftx.Invoice_No ) as LineNum, (Select TOP 1 Invoice_Date from Invoices where invoice_No = mftx.Invoice_No ORDER BY INVOICE_dATE DESC) as Invoice_Date, 'Desc' as [Description], 5.6 as UnitPrice, '' as Prefix, weight as Qty, '' as suffix, 'lb' as unit, Charge from ManifestInvoice mftx where mftx.invoice_no = 123
        'SELECT     Weight, (SELECT ppc.Charge FROM PricePlanCharges ppc WHERE (mft.weight BETWEEN From_Range AND To_Range) AND ppc.planid = 456) AS WCharge
        'FROM         ManifestInvoice mft
        'WHERE     (FromCustID = 123) AND (Invoice_No IS NULL) OR
        '                      (RTRIM(Invoice_No) = '')




    End Sub

    '    Public Const BILLCALC_OK As Int16 = 0
    Public Enum BILLCALC_RETVALS
        BILLCALC_OK = 0
        BILLCALC_SKIP = 1
        BILLCALC_STOP = 2
    End Enum

    Private Function CalcServicePeriodCharge(ByVal TempInvID As Integer, ByVal ItemNo As Integer, ByVal InvoiceDate As Date, ByRef SIDRow As DataRow, ByVal PeriodBegin As Date, ByVal PeriodEnd As Date, ByVal BCycleCode As String) As BILLCALC_RETVALS
        Dim WeekDays As New clsWeekDaysCount
        Dim qSched As String = "Select * From " & ROUTESTblPath & "ServiceSchedules where AccountID = " & SIDRow("AccountID") & " And SID = " & SIDRow("ID")
        Dim dsTemp As New System.Data.DataSet
        Dim daTemp As New SqlDataAdapter
        Dim row As DataRow
        Dim SvcDaysCount As Integer
        Dim OfflimitCharges As Decimal
        Dim Title As String = "Pro-Rate: "
        Dim Holidays As clsHolidays = Nothing
        Dim i, DaysCnt As Integer
        Dim MTWTFSS As String

        CalcServicePeriodCharge = BILLCALC_RETVALS.BILLCALC_OK

        If PeriodEnd = DateAdd(DateInterval.Day, -1, PeriodBegin) Then
            CalcServicePeriodCharge = BILLCALC_RETVALS.BILLCALC_SKIP
            GoTo Release
        ElseIf PeriodEnd < DateAdd(DateInterval.Day, -1, PeriodBegin) Then
            CalcServicePeriodCharge = BILLCALC_RETVALS.BILLCALC_STOP
            GoTo Release
        End If
        ' This routine is based on the new logic that pro-rate always adds up and full period may not be calculated
        WeekDays.Date1 = PeriodBegin
        WeekDays.Date2 = PeriodEnd

        CountWeekDays(WeekDays)
        If PopulateDataset2(daTemp, dsTemp, qSched) Is Nothing Then
            ' No Route Services
            daTemp.Dispose()
            dsTemp.Dispose()
            daTemp = Nothing
            dsTemp = Nothing
            Exit Function
        End If
        If BCycleCode = "D" Then ' In Daily, we do not include atual charges for holidays
            Holidays = GetHolidays(PeriodBegin, PeriodEnd)
        End If



        If CStr(SIDRow("SchedType")).ToUpper = "W" Then
            If BCycleCode <> "D" Then
                For Each row In dsTemp.Tables(0).Rows
                    DaysCnt = WeekDays.Days(row("Day"))
                    OfflimitCharges += DaysCnt * SIDRow("DailyAvgChg") '* (-1)
                    WeekDays.SvcDays(row("Day")) = True
                Next
            Else
                For Each row In dsTemp.Tables(0).Rows
                    DaysCnt = WeekDays.Days(row("Day"))
                    If Not Holidays Is Nothing Then
                        DaysCnt = DaysCnt - Holidays.WeekDaysCnt(row("Day"))
                    End If
                    OfflimitCharges += DaysCnt * row("Charge") '* (-1)
                    WeekDays.SvcDays(row("Day")) = True
                    WeekDays.Days(row("Day")) = DaysCnt
                Next
            End If
        Else
            If row("ServiceDate") >= PeriodBegin And row("ServiceDate") <= PeriodEnd Then
                'SvcDaysCount += 1
                'Calendar Service is not subject to Holiday?
                OfflimitCharges += row("Charge") '* (-1)
                WeekDays.SvcDays(Weekday(row("ServiceDate"), FirstDayOfWeek.Monday)) = True
            End If
        End If


        'For Each row In dsTemp.Tables(0).Rows
        '    If row("Day") > 0 Then
        '        'SvcDaysCount += WeekDays.Days(row("Day"))
        '        DaysCnt = WeekDays.Days(row("Day"))
        '        If Not Holidays Is Nothing Then
        '            DaysCnt = DaysCnt - Holidays.WeekDaysCnt(row("Day"))
        '        End If
        '        OfflimitCharges += DaysCnt * SIDRow("DailyAvgChg") '* (-1)
        '    Else
        '        If row("ServiceDate") > SIDRow("EndDate") And row("ServiceDate") <= PeriodEnd Then
        '            'SvcDaysCount += 1
        '            'Calendar Service is not subject to Holiday?
        '            OfflimitCharges += row("Charge") '* (-1)
        '        End If
        '    End If
        'Next

        For i = 1 To 7
            If WeekDays.SvcDays(i) = True Then
                MTWTFSS = MTWTFSS & WeekDays.Days(i) & WeekdayName(i, True, FirstDayOfWeek.Monday).Substring(0, 1) & "-"
            Else
                MTWTFSS = MTWTFSS & "0" & WeekdayName(i, True, FirstDayOfWeek.Monday).Substring(0, 1) & "-"
            End If
        Next

        If Holidays Is Nothing Then
            MTWTFSS = MTWTFSS & "0H"
        Else
            MTWTFSS = MTWTFSS & Holidays.dates.Length & "H"
        End If
        If MTWTFSS.Length > 50 Then
            MTWTFSS = MTWTFSS.Substring(0, 50)
        End If

        ExecuteQuery("Insert into " & BILLTblPath & "BillinginvoiceRouteDetails([Invoice Date], [Invoice No], [Acct ID], SID, [Start Date], [End Date], [Loc Name], Street, City, State, ZipCode, [Item No], Title, [Period Begin], [Period End], Charge, [WeekDays Cnt]) Values('" & InvoiceDate & "', " & TempInvID & ", " & SIDRow("AccountID") & ", " & SIDRow("ID") & ", " & IIf(TypeOf SIDRow("StartDate") Is DBNull, "NULL", "'" & SIDRow("StartDate") & "'") & ",  " & IIf(TypeOf SIDRow("EndDate") Is DBNull, "NULL", "'" & SIDRow("EndDate") & "'") & ", '" & Replace(SIDRow("CompName"), "'", "''") & "', '" & SIDRow("Street") & "', '" & SIDRow("CityName") & "', '" & SIDRow("State") & "', '" & SIDRow("Zipcode") & "', " & ItemNo & ", '" & Title & "', '" & WeekDays.Date1 & "', '" & WeekDays.Date2 & "', " & OfflimitCharges & ", '" & MTWTFSS & "')")

Release:
        Holidays = Nothing
        daTemp.Dispose()
        dsTemp.Dispose()
        daTemp = Nothing
        dsTemp = Nothing
    End Function

    Private Function CalcFullPeriodServiceCharge(ByVal TempInvID As Integer, ByVal ItemNo As Integer, ByVal InvoiceDate As Date, ByRef SIDRow As DataRow, ByVal PeriodBegin As Date, ByVal PeriodEnd As Date, ByVal BCycleCode As String, ByVal PeriodHolidays As clsHolidays) As BILLCALC_RETVALS
        Dim WeekDays As New clsWeekDaysCount
        Dim qSched As String = "Select * From " & ROUTESTblPath & "ServiceSchedules where AccountID = " & SIDRow("AccountID") & " And SID = " & SIDRow("ID")
        Dim dsTemp As New System.Data.DataSet
        Dim daTemp As New SqlDataAdapter
        Dim row As DataRow
        Dim SvcDaysCount As Integer
        Dim PeriodCharge As Decimal
        Dim Title As String = "Whole Period: "
        Dim Holidays As clsHolidays = Nothing
        Dim i, DaysCnt As Integer
        Dim MTWTFSS As String

        CalcFullPeriodServiceCharge = BILLCALC_RETVALS.BILLCALC_OK

        If PeriodEnd = DateAdd(DateInterval.Day, -1, PeriodBegin) Then
            CalcFullPeriodServiceCharge = BILLCALC_RETVALS.BILLCALC_SKIP
            GoTo Release
        ElseIf PeriodEnd < DateAdd(DateInterval.Day, -1, PeriodBegin) Then
            CalcFullPeriodServiceCharge = BILLCALC_RETVALS.BILLCALC_STOP
            GoTo Release
        End If

        ' This routine is based on the new logic that pro-rate always adds up and full period may not be calculated
        WeekDays.Date1 = PeriodBegin
        WeekDays.Date2 = PeriodEnd

        CountWeekDays(WeekDays)
        If PopulateDataset2(daTemp, dsTemp, qSched) Is Nothing Then
            ' No Route Services
            daTemp.Dispose()
            dsTemp.Dispose()
            daTemp = Nothing
            dsTemp = Nothing
            Exit Function
        End If
        If BCycleCode = "D" Then ' In Daily, we do not include atual charges for holidays
            Holidays = PeriodHolidays
        End If

        If CStr(SIDRow("SchedType")).ToUpper = "W" Then
            If BCycleCode <> "D" Then
                PeriodCharge = SIDRow("Charge")
                For Each row In dsTemp.Tables(0).Rows
                    WeekDays.SvcDays(row("Day")) = True
                Next
            Else
                For Each row In dsTemp.Tables(0).Rows
                    DaysCnt = WeekDays.Days(row("Day"))
                    If Not Holidays Is Nothing Then
                        DaysCnt = DaysCnt - Holidays.WeekDaysCnt(row("Day"))
                    End If
                    PeriodCharge += DaysCnt * row("Charge") '* (-1)
                    WeekDays.SvcDays(row("Day")) = True
                    WeekDays.Days(row("Day")) = DaysCnt
                Next
            End If
        Else
            If row("ServiceDate") >= PeriodBegin And row("ServiceDate") <= PeriodEnd Then
                'SvcDaysCount += 1
                'Calendar Service is not subject to Holiday?
                PeriodCharge += row("Charge") '* (-1)
                WeekDays.SvcDays(Weekday(row("ServiceDate"), FirstDayOfWeek.Monday)) = True
            End If
        End If
        'For Each row In dsTemp.Tables(0).Rows
        '    If row("Day") > 0 Then
        '        'SvcDaysCount += WeekDays.Days(row("Day"))
        '        DaysCnt = WeekDays.Days(row("Day"))
        '        If Not Holidays Is Nothing Then
        '            DaysCnt = DaysCnt - Holidays.WeekDaysCnt(row("Day"))
        '        End If
        '        OfflimitCharges += DaysCnt * SIDRow("DailyAvgChg") '* (-1)
        '    Else
        '        If row("ServiceDate") > SIDRow("EndDate") And row("ServiceDate") <= PeriodEnd Then
        '            'SvcDaysCount += 1
        '            'Calendar Service is not subject to Holiday?
        '            OfflimitCharges += row("Charge") '* (-1)
        '        End If
        '    End If
        'Next
        For i = 1 To 7
            If WeekDays.SvcDays(i) = True Then
                MTWTFSS = MTWTFSS & WeekDays.Days(i) & WeekdayName(i, True, FirstDayOfWeek.Monday).Substring(0, 1) & "-"
            Else
                MTWTFSS = MTWTFSS & "0" & WeekdayName(i, True, FirstDayOfWeek.Monday).Substring(0, 1) & "-"
            End If
        Next
        If Holidays Is Nothing Then
            MTWTFSS = MTWTFSS & "0H"
        Else
            MTWTFSS = MTWTFSS & Holidays.dates.Length & "H"
        End If
        If MTWTFSS.Length > 50 Then
            MTWTFSS = MTWTFSS.Substring(0, 50)
        End If

        ExecuteQuery("Insert into " & BILLTblPath & "BillinginvoiceRouteDetails([Invoice Date], [Invoice No], [Acct ID], SID, [Start Date], [End Date], [Loc Name], Street, City, State, ZipCode, [Item No], Title, [Period Begin], [Period End], Charge, [WeekDays Cnt]) Values('" & InvoiceDate & "', " & TempInvID & ", " & SIDRow("AccountID") & ", " & SIDRow("ID") & ",  " & IIf(TypeOf SIDRow("StartDate") Is DBNull, "NULL", "'" & SIDRow("StartDate") & "'") & ",  " & IIf(TypeOf SIDRow("EndDate") Is DBNull, "NULL", "'" & SIDRow("EndDate") & "'") & ", '" & Replace(SIDRow("CompName"), "'", "''") & "', '" & SIDRow("Street") & "', '" & SIDRow("CityName") & "', '" & SIDRow("State") & "', '" & SIDRow("Zipcode") & "', " & ItemNo & ", '" & Title & "', '" & WeekDays.Date1 & "', '" & WeekDays.Date2 & "', " & PeriodCharge & ", '" & MTWTFSS & "')")

Release:
        Holidays = Nothing
        daTemp.Dispose()
        dsTemp.Dispose()
        daTemp = Nothing
        dsTemp = Nothing
    End Function



    'Private Function CalcEndDateProRate(ByVal TempInvID As Integer, ByVal ItemNo As Integer, ByVal InvoiceDate As Date, ByRef SIDRow As DataRow, ByVal PeriodBegin As Date, ByVal PeriodEnd As Date)
    '    If SIDRow("EndDate") >= PeriodEnd Then Exit Function
    '    Dim WeekDays As New clsWeekDaysCount
    '    Dim qSched As String = "Select * From " & ROUTESTblPath & "ServiceSchedules where AccountID = " & SIDRow("AccountID") & " And SID = " & SIDRow("ID")
    '    Dim dsTemp As New System.Data.DataSet
    '    Dim daTemp As New SqlDataAdapter
    '    Dim row As DataRow
    '    Dim SvcDaysCount As Integer
    '    Dim OfflimitCharges As Decimal
    '    Dim Title As String = "Service Closing Pro-Rate"

    '    ' This routine is based on the new logic that pro-rate always adds up and full period may not be calculated
    '    'WeekDays.Date1 = SIDRow("EndDate")
    '    'WeekDays.Date2 = PeriodEnd
    '    WeekDays.Date1 = PeriodBegin
    '    WeekDays.Date2 = SIDRow("EndDate")

    '    CountWeekDays(WeekDays)
    '    If PopulateDataset2(daTemp, dsTemp, qSched) Is Nothing Then
    '        ' No Route Services
    '        daTemp.Dispose()
    '        dsTemp.Dispose()
    '        daTemp = Nothing
    '        dsTemp = Nothing
    '        Exit Function
    '    End If

    '    For Each row In dsTemp.Tables(0).Rows
    '        If row("Day") > 0 Then
    '            SvcDaysCount += WeekDays.Days(row("Day"))
    '        Else
    '            'If row("ServiceDate") > SIDRow("EndDate") And row("ServiceDate") <= PeriodEnd Then
    '            If row("ServiceDate") <= SIDRow("EndDate") And row("ServiceDate") >= PeriodBegin Then
    '                SvcDaysCount += 1
    '            End If
    '        End If
    '    Next
    '    OfflimitCharges = SvcDaysCount * SIDRow("DailyAvgChg") '* (-1)

    '    ExecuteQuery("Insert into " & BILLTblPath & "BillinginvoiceRouteDetails(InvoiceDate, [TempInvoice No], [Acct ID], SID, [Start Date], [End Date], [Loc Name], Street, City, State, ZipCode, [Item No], Title, [Period Begin], [Period End], Charge) Values('" & InvoiceDate & "', " & TempInvID & ", " & SIDRow("AccountID") & ", " & SIDRow("ID") & ", '" & SIDRow("StartDate") & "', '" & SIDRow("EndDate") & "', '" & SIDRow("CompName") & "', '" & SIDRow("Street") & "', '" & SIDRow("CityName") & "', '" & SIDRow("State") & "', '" & SIDRow("Zipcode") & "', " & ItemNo & ", '" & Title & "', '" & WeekDays.Date1 & "', '" & WeekDays.Date2 & "', " & OfflimitCharges & ")")

    'End Function

    'Private Function CalcStartDateProRate(ByVal TempInvID As Integer, ByVal ItemNo As Integer, ByVal InvoiceDate As Date, ByRef SIDRow As DataRow, ByVal PeriodBegin As Date, ByVal PeriodEnd As Date)
    '    Dim WeekDays As New clsWeekDaysCount
    '    Dim qSched As String = "Select * From " & ROUTESTblPath & "ServiceSchedules where AccountID = " & SIDRow("AccountID") & " And SID = " & SIDRow("ID")
    '    Dim dsTemp As New System.Data.DataSet
    '    Dim daTemp As New SqlDataAdapter
    '    Dim row As DataRow
    '    Dim SvcDaysCount As Integer
    '    Dim OfflimitCharges As Decimal
    '    Dim Title As String = "Service Closing Pro-Rate"

    '    ' This routine is based on the new logic that pro-rate always adds up and full period may not be calculated
    '    If SIDRow("StartDate") < PeriodBegin Then
    '        WeekDays.Date1 = SIDRow("StartDate")
    '        WeekDays.Date2 = PeriodBegin
    '    ElseIf SIDRow("StartDate") > PeriodBegin Then
    '        WeekDays.Date1 = SIDRow("StartDate")
    '        WeekDays.Date2 = PeriodEnd
    '        'WeekDays.Date1 = PeriodBegin
    '        'WeekDays.Date2 = SIDRow("StartDate")
    '    Else
    '        Exit Function
    '    End If
    '    CountWeekDays(WeekDays)
    '    If PopulateDataset2(daTemp, dsTemp, qSched) Is Nothing Then
    '        ' No Route Services
    '        daTemp.Dispose()
    '        dsTemp.Dispose()
    '        daTemp = Nothing
    '        dsTemp = Nothing
    '        Exit Function
    '    End If

    '    For Each row In dsTemp.Tables(0).Rows
    '        If row("Day") > 0 Then
    '            SvcDaysCount += WeekDays.Days(row("Day"))
    '        Else
    '            If row("ServiceDate") > SIDRow("EndDate") And row("ServiceDate") <= PeriodEnd Then
    '                SvcDaysCount += 1
    '            End If
    '        End If
    '    Next

    '    OfflimitCharges = SvcDaysCount * SIDRow("DailyAvgChg") '* (-1)

    '    ExecuteQuery("Insert into " & BILLTblPath & "BillinginvoiceRouteDetails(InvoiceDate, [TempInvoice No], [Acct ID], SID, [Start Date], [End Date], [Loc Name], Street, City, State, ZipCode, [Item No], Title, [Period Begin], [Period End], Charge) Values('" & InvoiceDate & "', " & TempInvID & ", " & SIDRow("AccountID") & ", " & SIDRow("ID") & ", '" & SIDRow("StartDate") & "', '" & SIDRow("EndDate") & "', '" & SIDRow("CompName") & "', '" & SIDRow("Street") & "', '" & SIDRow("CityName") & "', '" & SIDRow("State") & "', '" & SIDRow("Zipcode") & "', " & ItemNo & ", '" & Title & "', '" & WeekDays.Date1 & "', '" & WeekDays.Date2 & "', " & OfflimitCharges & ")")

    'End Function

    Private Function GetHolidays(ByVal PeriodBegin, ByVal PeriodEnd) As clsHolidays
        Dim qHol As String = "Select * From " & HOLIDAYSTblPath & "Holidays where HDate between '" & PeriodBegin & "' And '" & PeriodEnd & "'"
        Dim dsTemp As New System.Data.DataSet
        Dim daTemp As New SqlDataAdapter
        Dim row As DataRow
        Dim Hols As clsHolidays = Nothing
        Dim i As Integer


        If Not PopulateDataset2(daTemp, dsTemp, qHol) Is Nothing Then
            Hols = New clsHolidays
            ReDim Hols.dates(dsTemp.Tables(0).Rows.Count - 1)
            i = 0
            For Each row In dsTemp.Tables(0).Rows
                Hols.dates(i) = row("HDate")
                Hols.WeekDaysCnt(Weekday(row("HDate"), FirstDayOfWeek.Monday)) += 1
                i += 1
            Next
        End If
        daTemp.Dispose()
        dsTemp.Dispose()
        daTemp = Nothing
        dsTemp = Nothing
        Return (Hols)

    End Function

    Private Sub BiilingInvoiceGen_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        'If btnEdit.Text = "&Cancel" Or btnNew.Text = "&Cancel" Then
        If btnNew.Text = "&Cancel" Or (uopBillingMethod.FocusedIndex = 1 And utAccountID.Tag = False) Then
            'Message modified by Michael Pastor
            If MessageBox.Show("Data is not saved! Are you sure you want to exit?", "Data Not Saved", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = MsgBoxResult.No Then
                '- If MsgBox("Data is not saved! Are you sure you want to exit?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                e.Cancel = True
                Exit Sub
            End If
        End If

        'If Not cmdTrans Is Nothing Then
        '    If EditForm(Me, SQLSelect, EditAction.CANCEL, cmdTrans) Then
        '        sender.text = "&Edit" 'Karina changed place with Group_EnDis()
        '        Group_EnDis(False)

        '    Else
        '        'Exit Sub
        '    End If

        'End If
    End Sub

    Private Sub MiscBilling(ByVal TempInvID As Int32, ByVal billinginfo As CustBillInfo, ByVal PeriodEnd As Date)
        Dim q As String = "" & _
" Insert into " & BILLTblPath & "InvoiceLineItems(Invoice_No, Invoice_Date, TranDate, Charge_Code, Description, UnitPrice, Prefix, Qty, Suffix, Unit, Charge, Tax, MISCRowID )  " & _
" SELECT     '" & TempInvID & "' as Invoice_No, (Select TOP 1 Invoice_Date from " & BILLTblPath & "Invoices where invoice_No = '" & TempInvID & "' ORDER BY INVOICE_dATE DESC) as Invoice_Date, imc.Trandate as TranDate, imc.Charge_Code, imc.Description, " & _
" NULL as UnitPrice, '' as Prefix, imc.qty as Qty, '' as suffix, imc.Unit as Unit, imc.charge as Charge,  (case imc.taxable when 1 then 'T' else '' end) as tax, imc.rowid " & _
" FROM  " & BILLTblPath & "InvoiceMiscCharges imc " & _
" Where imc.BillToCustID = '" & billinginfo.ID & "' and imc.Invoice_No is NULL " & _
" AND imc.TranDate < dateadd(day, 1, '" & PeriodEnd & "') ;"

        Dim q2 = " Update " & BILLTblPath & "InvoiceMiscCharges Set Invoice_No = '" & TempInvID & "' " & _
                 " FROM " & BILLTblPath & "InvoiceMiscCharges imc Where imc.BillToCustID = '" & billinginfo.ID & "' and imc.Invoice_No is NULL " & _
                 " AND imc.TranDate < dateadd(day, 1, '" & PeriodEnd & "') ;"


        If ExecuteQuery(q) Then
            ExecuteQuery(q2)
        End If


    End Sub

    '    Private Sub RouteDetailsToInvoiceLineItems(ByVal TmpInvId As Int32, ByVal billingInfo As CustBillInfo, ByVal PeriodEnd As Date)

    '        Dim q As String = "" & _
    '" Insert into " & BILLTblPath & "InvoiceLineItems(Invoice_No, Invoice_Date, TranDate, Charge_Code, Description, UnitPrice, Prefix, Qty, Suffix, Unit, Charge, Tax, MISCRowID )  " & _
    '" SELECT     '" & TmpInvId & "' as Invoice_No, (Select TOP 1 Invoice_Date from " & BILLTblPath & "Invoices where invoice_No = '" & TmpInvId & "' ORDER BY INVOICE_dATE DESC) as Invoice_Date, imc.Trandate as TranDate, imc.Charge_Code, imc.Description, " & _
    '" NULL as UnitPrice, '' as Prefix, imc.qty as Qty, '' as suffix, imc.Unit as Unit, imc.charge as Charge,  (case imc.taxable when 1 then 'T' else '' end) as tax, imc.rowid " & _
    '" FROM  " & BILLTblPath & "InvoiceMiscCharges imc " & _
    '" Where imc.BillToCustID = '" & billingInfo.ID & "' and imc.Invoice_No is NULL " & _
    '" AND imc.TranDate < dateadd(day, 1, '" & PeriodEnd & "') ;"

    '        ExecuteQuery(q)

    '    End Sub


    Private Sub CalcFuelSurcharge(ByVal RatePct As Decimal, ByVal TempInvID As Int32, ByVal billinginfo As CustBillInfo, ByVal PeriodEnd As Date)
        '        Dim q As String = "" & _
        '" Insert into " & BILLTblPath & "InvoiceMiscCharges(Invoice_No, TranDate, BillToCustID, BillToCustName, Charge_Code, Description, Qty, Unit, Charge) " & _
        '" SELECT '" & TempInvID & "' as Invoice_No, '" & PeriodEnd & "' as TranDate, '" & billinginfo.ID & "' as CustID, '" & billinginfo.Name & "' as CustName, 'FUE' as Charge_Code, 'Fuel Surcharge' as Description, " & _
        '", " & RatePct & "/100. as Qty, '' as Unit " & _
        '", (Select Sum(Charge) from " & BILLTblPath & "Invoices where Invoice_No = '" & TempInvID & "') * " & RatePct & "/100. as Charge "

        If RatePct = 0 Then Exit Sub

        Dim q As String = "" & _
" Insert into " & BILLTblPath & "InvoiceLineItems(Invoice_No, Invoice_Date, Charge_Code, Description, UnitPrice, Prefix, Qty, Suffix, Unit, Charge, Tax, MISCRowID )  " & _
" SELECT     '" & TempInvID & "' as Invoice_No " & _
", (Select TOP 1 Invoice_Date from " & BILLTblPath & "Invoices where invoice_No = '" & TempInvID & "' ORDER BY INVOICE_dATE DESC) as Invoice_Date" & _
", 'FUE' as Charge_Code, 'Fuel Surcharge' as Description, " & _
" NULL as UnitPrice, '' as Prefix, " & RatePct & "/100. as Qty, '%%' as suffix, '' as Unit" & _
", (Select Sum(Charge) from " & BILLTblPath & "InvoiceLineItems where Invoice_No = '" & TempInvID & "') * " & RatePct & "/100. as Charge" & _
",  '' as tax, NULL "

        If ExecuteQuery(q) = False Then
            MsgBox("Error in Fuel Surcharge")

        End If


    End Sub

    Private Sub MoveMftInvToArchive(ByVal TempInvID As Int32)
        Dim q As String = " Insert into " & TRCTblPath & "ManifestInvoiceArchive Select * from " & TRCTblPath & "ManifestInvoice where Invoice_No = '" & TempInvID & "'"

        Dim q2 As String = "Delete From " & TRCTblPath & "ManifestInvoice where Invoice_No =  '" & TempInvID & "'"
        If ExecuteQuery(q) Then
            ExecuteQuery(q2)
        End If

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        'utInvoiceNo.Text = "20916"
        utInvoiceNo.Enabled = Not utInvoiceNo.Enabled
    End Sub

    Private Sub btnGenerate2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

    End Sub
End Class
