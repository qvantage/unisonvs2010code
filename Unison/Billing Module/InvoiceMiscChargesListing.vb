Imports System.Data.SqlClient
Imports System.Drawing.SystemColors

Public Class InvoiceMiscChargesListing
    Inherits System.Windows.Forms.Form

    Dim MeText As String
    Dim m_oColumn As Infragistics.Win.UltraWinGrid.UltraGridColumn = Nothing

    Dim TemplateID As Integer
    Dim Template As String

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
    Friend WithEvents UltraDate2 As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnExcel As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents btnDisplay As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents UltraDate1 As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents utAcct As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utAcctID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnAcct As System.Windows.Forms.Button
    Friend WithEvents CntMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents utInvoice As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents uopInvoice As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents btnInvoice As System.Windows.Forms.Button
    Friend WithEvents uopAcct As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents UltraGridExcelExporter1 As Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem3 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim Appearance4 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance5 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance6 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance7 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem4 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem5 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.utInvoice = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.uopInvoice = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.btnInvoice = New System.Windows.Forms.Button
        Me.UltraDate2 = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label2 = New System.Windows.Forms.Label
        Me.btnExcel = New System.Windows.Forms.Button
        Me.btnPrint = New System.Windows.Forms.Button
        Me.btnDisplay = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.utAcct = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utAcctID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.uopAcct = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.btnAcct = New System.Windows.Forms.Button
        Me.UltraDate1 = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label11 = New System.Windows.Forms.Label
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.CntMenu1 = New System.Windows.Forms.ContextMenu
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.MenuItem4 = New System.Windows.Forms.MenuItem
        Me.UltraGridExcelExporter1 = New Infragistics.Win.UltraWinGrid.ExcelExport.UltraGridExcelExporter
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.utInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uopInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDate2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.utAcct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utAcctID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uopAcct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDate1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.GroupBox5)
        Me.GroupBox1.Controls.Add(Me.UltraDate2)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.btnExcel)
        Me.GroupBox1.Controls.Add(Me.btnPrint)
        Me.GroupBox1.Controls.Add(Me.btnDisplay)
        Me.GroupBox1.Controls.Add(Me.GroupBox2)
        Me.GroupBox1.Controls.Add(Me.UltraDate1)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(752, 144)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.utInvoice)
        Me.GroupBox5.Controls.Add(Me.uopInvoice)
        Me.GroupBox5.Controls.Add(Me.btnInvoice)
        Me.GroupBox5.Location = New System.Drawing.Point(8, 48)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(280, 88)
        Me.GroupBox5.TabIndex = 165
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Invoice Status"
        '
        'utInvoice
        '
        Appearance1.ForeColor = System.Drawing.Color.Black
        Appearance1.ForeColorDisabled = System.Drawing.Color.Black
        Me.utInvoice.Appearance = Appearance1
        Me.utInvoice.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utInvoice.Location = New System.Drawing.Point(104, 59)
        Me.utInvoice.Name = "utInvoice"
        Me.utInvoice.Size = New System.Drawing.Size(80, 21)
        Me.utInvoice.TabIndex = 1
        Me.utInvoice.Tag = ".OfficeID"
        '
        'uopInvoice
        '
        Appearance2.TextTrimming = Infragistics.Win.TextTrimming.EllipsisWord
        Me.uopInvoice.Appearance = Appearance2
        Me.uopInvoice.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.uopInvoice.ItemAppearance = Appearance3
        ValueListItem1.DataValue = "All"
        ValueListItem1.DisplayText = "All"
        ValueListItem2.DataValue = "Not Invoiced"
        ValueListItem2.DisplayText = "Not Invoiced"
        ValueListItem3.DataValue = "Invoiced"
        ValueListItem3.DisplayText = "Invoiced"
        Me.uopInvoice.Items.Add(ValueListItem1)
        Me.uopInvoice.Items.Add(ValueListItem2)
        Me.uopInvoice.Items.Add(ValueListItem3)
        Me.uopInvoice.ItemSpacingVertical = 7
        Me.uopInvoice.Location = New System.Drawing.Point(16, 16)
        Me.uopInvoice.Name = "uopInvoice"
        Me.uopInvoice.Size = New System.Drawing.Size(88, 64)
        Me.uopInvoice.TabIndex = 0
        '
        'btnInvoice
        '
        Me.btnInvoice.Location = New System.Drawing.Point(196, 59)
        Me.btnInvoice.Name = "btnInvoice"
        Me.btnInvoice.Size = New System.Drawing.Size(75, 20)
        Me.btnInvoice.TabIndex = 3
        Me.btnInvoice.Text = "Select"
        '
        'UltraDate2
        '
        Me.UltraDate2.DateTime = New Date(2004, 9, 27, 0, 0, 0, 0)
        Me.UltraDate2.Location = New System.Drawing.Point(296, 18)
        Me.UltraDate2.Name = "UltraDate2"
        Me.UltraDate2.Size = New System.Drawing.Size(96, 21)
        Me.UltraDate2.TabIndex = 1
        Me.UltraDate2.Value = New Date(2004, 9, 27, 0, 0, 0, 0)
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(224, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 164
        Me.Label2.Text = "To Date:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnExcel
        '
        Me.btnExcel.Location = New System.Drawing.Point(651, 16)
        Me.btnExcel.Name = "btnExcel"
        Me.btnExcel.Size = New System.Drawing.Size(88, 21)
        Me.btnExcel.TabIndex = 7
        Me.btnExcel.Text = "Export to E&xcel"
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(563, 16)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(88, 21)
        Me.btnPrint.TabIndex = 6
        Me.btnPrint.Text = "&Print"
        '
        'btnDisplay
        '
        Me.btnDisplay.Location = New System.Drawing.Point(475, 16)
        Me.btnDisplay.Name = "btnDisplay"
        Me.btnDisplay.Size = New System.Drawing.Size(88, 21)
        Me.btnDisplay.TabIndex = 5
        Me.btnDisplay.Text = "D&isplay"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.utAcct)
        Me.GroupBox2.Controls.Add(Me.utAcctID)
        Me.GroupBox2.Controls.Add(Me.uopAcct)
        Me.GroupBox2.Controls.Add(Me.btnAcct)
        Me.GroupBox2.Location = New System.Drawing.Point(296, 48)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(448, 88)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Account"
        '
        'utAcct
        '
        Appearance4.ForeColor = System.Drawing.Color.Black
        Appearance4.ForeColorDisabled = System.Drawing.Color.Black
        Me.utAcct.Appearance = Appearance4
        Me.utAcct.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utAcct.Location = New System.Drawing.Point(176, 40)
        Me.utAcct.Name = "utAcct"
        Me.utAcct.Size = New System.Drawing.Size(176, 21)
        Me.utAcct.TabIndex = 2
        Me.utAcct.Tag = ""
        '
        'utAcctID
        '
        Appearance5.ForeColor = System.Drawing.Color.Black
        Appearance5.ForeColorDisabled = System.Drawing.Color.Black
        Me.utAcctID.Appearance = Appearance5
        Me.utAcctID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utAcctID.Location = New System.Drawing.Point(112, 40)
        Me.utAcctID.Name = "utAcctID"
        Me.utAcctID.Size = New System.Drawing.Size(56, 21)
        Me.utAcctID.TabIndex = 1
        Me.utAcctID.Tag = ".OfficeID"
        '
        'uopAcct
        '
        Appearance6.TextTrimming = Infragistics.Win.TextTrimming.EllipsisWord
        Me.uopAcct.Appearance = Appearance6
        Me.uopAcct.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.uopAcct.ItemAppearance = Appearance7
        ValueListItem4.DataValue = "All Accounts"
        ValueListItem4.DisplayText = "All Accounts"
        ValueListItem5.DataValue = "By Account"
        ValueListItem5.DisplayText = "By Account"
        Me.uopAcct.Items.Add(ValueListItem4)
        Me.uopAcct.Items.Add(ValueListItem5)
        Me.uopAcct.ItemSpacingVertical = 7
        Me.uopAcct.Location = New System.Drawing.Point(16, 16)
        Me.uopAcct.Name = "uopAcct"
        Me.uopAcct.Size = New System.Drawing.Size(96, 46)
        Me.uopAcct.TabIndex = 0
        '
        'btnAcct
        '
        Me.btnAcct.Location = New System.Drawing.Point(360, 41)
        Me.btnAcct.Name = "btnAcct"
        Me.btnAcct.Size = New System.Drawing.Size(75, 20)
        Me.btnAcct.TabIndex = 3
        Me.btnAcct.Text = "Select"
        '
        'UltraDate1
        '
        Me.UltraDate1.DateTime = New Date(2004, 9, 27, 0, 0, 0, 0)
        Me.UltraDate1.Location = New System.Drawing.Point(92, 17)
        Me.UltraDate1.Name = "UltraDate1"
        Me.UltraDate1.Size = New System.Drawing.Size(96, 21)
        Me.UltraDate1.TabIndex = 0
        Me.UltraDate1.Value = New Date(2004, 9, 27, 0, 0, 0, 0)
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(8, 20)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(80, 16)
        Me.Label11.TabIndex = 142
        Me.Label11.Text = "From Date:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGrid1.Location = New System.Drawing.Point(0, 144)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(752, 429)
        Me.UltraGrid1.TabIndex = 2
        Me.UltraGrid1.Tag = "HRSINPUTLISTING"
        Me.UltraGrid1.Text = "HR Pay Period Listing"
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
        'InvoiceMiscChargesListing
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(752, 573)
        Me.Controls.Add(Me.UltraGrid1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Menu = Me.MainMenu1
        Me.Name = "InvoiceMiscChargesListing"
        Me.Tag = "InvoiceMiscChargesListing"
        Me.Text = "Miscellaneous Charges Listing"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.utInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uopInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDate2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.utAcct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utAcctID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uopAcct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDate1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub InvoiceMiscChargesListing_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler Me.Activated, AddressOf Form_Activated
        Me.CenterToScreen()

        Me.KeyPreview = True
        MeText = Me.Text

        ' Set each control's length based on DB size
        'SetupCtrlsLength(Me)

        AddHandler Me.KeyUp, AddressOf Form_KeyUp
        'AddHandler utStartMile.KeyPress, AddressOf Value_Int_KeyPress
        'AddHandler utInvoiceNo.KeyPress, AddressOf Value_Int_KeyPress
        '
        'cmdTrans = Nothing

        UltraDate1.Nullable = True
        UltraDate1.Value = Date.Today 'DateAdd(DateInterval.Day, -1, Date.Today)
        UltraDate1.FormatString = "MM/dd/yyyy"

        UltraDate2.Nullable = True
        UltraDate2.Value = Date.Today 'DateAdd(DateInterval.Day, -1, Date.Today)
        UltraDate2.FormatString = "MM/dd/yyyy"

        utInvoice.MaxLength = 10

        utInvoice.Enabled = False
        btnInvoice.Enabled = False

        utAcctID.Enabled = False
        utAcct.Enabled = False
        btnAcct.Enabled = False

        UltraGrid1.Text = "Misc. Charges Listing"

        uopInvoice.CheckedIndex = 1 ' Not Invoiced
        uopAcct.CheckedIndex = 0 ' All

        'FillUCombo(ucboCompany, "", "", "", HRTblPath)
        'AddHandler ucboCompany.Leave, AddressOf UCbo_Leave

    End Sub

    Private Sub uopInvoice_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles uopInvoice.ValueChanged
        If uopInvoice.CheckedIndex = 2 Then
            utInvoice.Enabled = True
            btnInvoice.Enabled = True
        Else
            utInvoice.Enabled = False
            btnInvoice.Enabled = False
        End If
    End Sub

    Private Sub btnInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInvoice.Click
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim gAcct, gAcctID As Infragistics.Win.UltraWinEditors.UltraTextEditor
        Select Case sender.Name
            Case "btnInvoice"
                gAcct = utInvoice
                gAcctID = utInvoice
            Case Else
                MsgBox("Unknown Button")
                Exit Sub
        End Select

        SelectSQL = "Select Invoice_No, CustomerID, Name, Invoice_Date, Closing_Date, Due_Date from " & BILLTblPath & "Invoices order by Invoice_No "

        PopulateDataset2(dtAdapter, dtSet, SelectSQL)
        dtView.Table = dtSet.Tables(0)
        If dtView.Table.Rows.Count > 0 Then
            Dim Srch As New SearchListings
            Srch.dsList = dtSet

            Srch.UltraGrid1.Text = "Invoices"
            Srch.Text = "Invoices"
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
                    gAcct.Text = ugRow.Cells("Invoice_No").Text
                    gAcctID.Text = ugRow.Cells("Invoice_No").Text
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

    Private Sub utInvoice_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utInvoice.Leave
        Dim row As DataRow
        Dim gAcct, gAcctID As Infragistics.Win.UltraWinEditors.UltraTextEditor

        Select Case sender.Name
            Case "utInvoice"
                gAcct = utInvoice
                gAcctID = utInvoice
            Case Else
                MsgBox("Invalid Control: " & sender.name)
                Exit Sub
        End Select

        If sender.Modified = False Then Exit Sub

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
            If SearchOnLeave(sender, gAcctID, "" & BILLTblPath & "Invoices", "Invoice_No", "Invoice_No", " CustomerID, Name, Invoice_Date, Closing_Date, Due_Date ", "Invoices", "") Then
                'If ReturnRowByID(gAcctID.Text, row, BILLTblPath & "Invoices", "", "Invoice_No") Then
                '    gAcct.Text = row("Name")
                '    row = Nothing
                'Else
                '    MsgBox("Account Not Found.")
                '    gAcctID.Text = ""
                '    gAcct.Text = ""
                'End If
            Else
                'MsgBox("Not Found.")
                gAcctID.Text = ""
                gAcct.Text = ""
                sender.focus()
            End If
        End If
        sender.Modified = False

    End Sub

    Private Sub uopAcct_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles uopAcct.ValueChanged
        If uopAcct.CheckedIndex = 0 Then
            utAcctID.Enabled = False
            utAcct.Enabled = False
            btnAcct.Enabled = False
        Else
            utAcctID.Enabled = True
            utAcct.Enabled = True
            btnAcct.Enabled = True
        End If
    End Sub

    Private Sub utAcctID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utAcctID.Leave
        Dim row As DataRow
        Dim gAcct, gAcctID As Infragistics.Win.UltraWinEditors.UltraTextEditor

        Select Case sender.Name
            Case "utAcctID"
                gAcct = utAcct
                gAcctID = utAcctID
            Case Else
                MsgBox("Invalid Control: " & sender.name)
                Exit Sub
        End Select

        If sender.Modified = False Then Exit Sub

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
            If SearchOnLeave(sender, gAcctID, "" & BILLTblPath & "Customer", "CustomerID", "CustomerID", "*", "Accounts", "") Then
                If ReturnRowByID(gAcctID.Text, row, BILLTblPath & "Customer", "", "CustomerID") Then
                    gAcct.Text = row("Name")
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
            Case Else
                MsgBox("Unknown Button")
                Exit Sub
        End Select

        SelectSQL = "Select * from " & BILLTblPath & "Customer order by CustomerID "

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

    Private Sub utAcct_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utAcct.Leave
        Dim row As DataRow

        If sender.Modified = False Then Exit Sub

        If sender.text.trim = "" Then
            utAcctID.Text = ""
            sender.text = ""
            'btnSave.Enabled = False
        Else
            ' This for Accounts With Numbers Only Name!!
            'If IsNumeric(sender.text) Then
            '    sender.text = "?" & sender.text
            '    sender.modified = True
            'End If
            If SearchOnLeave(sender, utAcctID, BILLTblPath & "Customer", "CustomerID", "Name", "*", "Accounts", "") Then
                'If ReturnRowByID(utTruckInventID.Text, row, "TrucksManagement.dbo.Inventory", "", "Truck_Invent_ID") Then
                '    'utLicPlate.Text = row("Lic_Plate")
                '    'utTruckInventID.Text = row("Truck_Invent_ID")
                '    row = Nothing
                'Else
                '    MsgBox("Truck Not Found.")
                '    utTruckInventID.Text = ""
                '    utTruckID.Text = ""
                'End If
                'ucboCompany.Focus()
            Else
                'MsgBox("Truck Not Found.")
                utAcctID.Text = ""
                sender.Text = ""
                sender.focus()
            End If
        End If
        sender.Modified = False

    End Sub

    Private Sub utAcct_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles utAcct.KeyUp
        TypeAhead(sender, e, BILLTblPath & "Customer", "Name", "")
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        UltraGrid1.PrintPreview(Infragistics.Win.UltraWinGrid.RowPropertyCategories.All)
    End Sub

    Private Sub btnExcel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExcel.Click
        Dim x As New EnterTextBox
        Dim FileName As String

        On Error GoTo ErrTrap

        If UltraGrid1.ActiveRow Is Nothing Then GoTo ErrTrap

        x.Label1.Text = "File Name:"
        x.Label2.Text = ""
        x.Label2.Visible = False
        x.btnBrowse1.Visible = True

        x.Text = "File Name"
        x.TextBox1.Enabled = True
        'x.TextBox1.Text = "c :\TrackingListing.xls"
        x.TextBox1.Text = ".\TrackingListing.xls"
        x.TextBox2.Visible = False
        'x.Show()
        x.ShowDialog(Me)
        If x.DialogResult = DialogResult.OK Then
            If x.TextBox1.Text.Trim = "" Then
                MsgBox("No file name specified.")
                Exit Sub
            End If
            FileName = x.TextBox1.Text
            x.Dispose()
            x = Nothing
            Me.UltraGridExcelExporter1.Export(Me.UltraGrid1, FileName)
        End If
        Exit Sub
ErrTrap:
        If Err.Number > 0 Then
            MsgBox("Error in btnNewGroup_Click : " & Err.Description)
        End If
    End Sub

    Private Sub btnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        LoadData()
    End Sub

    Private Sub LoadData()

        Dim dtAdapter As SqlDataAdapter
        Dim i As Integer
        Dim SQLSelect, DateRngCond, InvCond, AcctCond, SummCol As String
        Dim dtSet As New DataSet
        'Dim cmdTrans As SqlCommand
        Dim HidCols() As String = {""}


        SQLSelect = "SELECT RowID, Invoice_No, TranDate, BillToCustID, BillToCustName, Charge_Code, Description, Qty, Unit, Charge, Taxable, TrackingNum, Ref1, Ref2, Ref3, " & _
                    " FromAddID, FromCustID, FromCustName, FromLocID, FromLocName, FromAdd1, FromAdd2, FromCity, FromState, FromZip, FromContact, FromPhone, " & _
                    " FromEmail, ToAddID, ToCustID, ToCustName, ToLocID, ToLocName, ToAdd1, ToAdd2, ToCity, ToState, ToZip, ToContact, ToPhone, ToEmail " & _
                    " FROM   " & BILLTblPath & "InvoiceMiscCharges " & _
                    " WHERE @@DATERNG @@INVOICE @@ACCT "


        If UltraDate1.Value Is Nothing Then
            MsgBox("Period Date is not set.")
            Exit Sub
        End If
        If UltraDate2.Value Is Nothing Then
            MsgBox("ToDate is not set.")
            Exit Sub
        End If
        'SQLSelect = SQLSelect.Replace("@DATERNG", "AND CONVERT(datetime, CONVERT(varchar, e.ScanDate, 101)) between '" & UltraDate1.Text & "' AND dateadd(d, 1,'" & UltraDate2.Text & "')")
        DateRngCond = " TranDate >= '" & UltraDate1.Text & "' AND  TranDate < dateadd(d, 1,'" & UltraDate2.Text & "') "
        ' Moved to the last step
        'SQLSelect = SQLSelect.Replace("@DATERNG", DateRngCond)

        Select Case uopInvoice.CheckedIndex
            Case 0 'All 
                InvCond = ""
            Case 1 ' Not Invoiced
                InvCond = " AND (Invoice_No is NULL or Invoice_No = 0) "
            Case 2 'Invoiced
                If utInvoice.Text.Trim = "" Then
                    MsgBox("Invoice# not specified.")
                    Exit Sub
                End If
                InvCond = " AND Invoice_No = '" & utInvoice.Text.Trim & "'"
        End Select
        SQLSelect = SQLSelect.Replace("@@INVOICE", InvCond)

        Select Case uopAcct.CheckedIndex
            Case 0 'All Accounts
                AcctCond = ""
            Case 1 'By Account
                If utAcctID.Text.Trim = "" Then
                    MsgBox("Account not specified.")
                    Exit Sub
                End If
                AcctCond = " AND BillToCustID = '" & utAcctID.Text & "'"
        End Select
        SQLSelect = SQLSelect.Replace("@@ACCT", AcctCond)

        If Not UltraGrid1.DataSource Is Nothing Then
            'UGSaveLayout(Me, UltraGrid1, 1)
        End If

        ' Moved From Top to cover any changes to date selection that each option may need
        SQLSelect = SQLSelect.Replace("@@DATERNG", DateRngCond)

        PopulateDataset2(dtAdapter, dtSet, SQLSelect)

        For i = 0 To dtSet.Tables(0).Columns.Count - 1
            dtSet.Tables(0).Columns(i).ReadOnly = True
        Next
        'dtSet.Tables(0).Columns(0).ReadOnly = False

        FillUltraGrid(UltraGrid1, dtSet, -1, HidCols, 0)
        'UltraGrid1.DataSource = dtSet
        'UGLoadLayout(Me, UltraGrid1, 1)
        UltraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True
        UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
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

        SummCol = "TranDate"
        UltraGrid1.DisplayLayout.Bands(0).Summaries.Add(SummCol, Infragistics.Win.UltraWinGrid.SummaryType.Count, UltraGrid1.DisplayLayout.Bands(0).Columns(SummCol), Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn)
        UltraGrid1.DisplayLayout.Bands(0).Summaries(SummCol).Appearance.TextHAlign = Infragistics.Win.HAlign.Right
        UltraGrid1.DisplayLayout.Bands(0).SummaryFooterCaption = ""
        UltraGrid1.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False


        UltraGrid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus

        UltraGrid1.DisplayLayout.GroupByBox.Hidden = False
        UltraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid, False, False)
        'UltraGrid1.Text = "Packages"
    End Sub

    ' =============================================================================================
    ' ==================================     MENU ROUTINES     ====================================
    ' =============================================================================================

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



    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click ' Load Template
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
                MsgBox("SQL_Error: " & osqlexception.Message)
                Srch = Nothing
                sender.Focus()
                Exit Try
            Finally
                If HasErr = False Then
                    ugRow = Srch.UltraGrid1.ActiveRow

                    TemplateID = ugRow.Cells("ID").Text
                    If Not UltraGrid1.DataSource Is Nothing Then
                        UGLoadListingLayout(UltraGrid1, TemplateID)
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
        UGSaveListingLayout(Me, UltraGrid1, TemplateID, Template)
        x = Nothing
        If TemplateID = 0 Then
            MsgBox("Failed")
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

End Class
