Imports System.Data
Imports System.Data.SqlClient

Public Class InvoiceDelete
    Inherits System.Windows.Forms.Form
    Dim MeText As String
    Dim dtSet As New DataSet
    'Dim cmdTrans As SqlCommand
    Dim HidCols() As String = {"RowID"}
    'Dim DataModified As Boolean
    Dim m_oColumn As Infragistics.Win.UltraWinGrid.UltraGridColumn = Nothing

    Dim TemplateID As Integer
    Dim Template As String
    Dim rbCurrIdx As Int16

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
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents utInvoice As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnInvoice As System.Windows.Forms.Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents btnAcct As System.Windows.Forms.Button
    Friend WithEvents utAcct As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents utAcctID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents UltraDate2 As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraDate1 As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents rbInvNo As System.Windows.Forms.RadioButton
    Friend WithEvents rbCloseDate As System.Windows.Forms.RadioButton
    Friend WithEvents rbInvDate As System.Windows.Forms.RadioButton
    Friend WithEvents rbAcct As System.Windows.Forms.RadioButton
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnDisplay As System.Windows.Forms.Button
    Friend WithEvents CntMenu1 As System.Windows.Forms.ContextMenu
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.utInvoice = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.btnInvoice = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.btnAcct = New System.Windows.Forms.Button
        Me.utAcct = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label1 = New System.Windows.Forms.Label
        Me.utAcctID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.btnDelete = New System.Windows.Forms.Button
        Me.UltraDate2 = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.UltraDate1 = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.rbInvNo = New System.Windows.Forms.RadioButton
        Me.rbCloseDate = New System.Windows.Forms.RadioButton
        Me.rbInvDate = New System.Windows.Forms.RadioButton
        Me.rbAcct = New System.Windows.Forms.RadioButton
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.btnDisplay = New System.Windows.Forms.Button
        Me.CntMenu1 = New System.Windows.Forms.ContextMenu
        Me.GroupBox1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.utInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        CType(Me.utAcct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utAcctID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDate2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraDate1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnDisplay)
        Me.GroupBox1.Controls.Add(Me.Panel2)
        Me.GroupBox1.Controls.Add(Me.Panel1)
        Me.GroupBox1.Controls.Add(Me.btnDelete)
        Me.GroupBox1.Controls.Add(Me.UltraDate2)
        Me.GroupBox1.Controls.Add(Me.UltraDate1)
        Me.GroupBox1.Controls.Add(Me.rbInvNo)
        Me.GroupBox1.Controls.Add(Me.rbCloseDate)
        Me.GroupBox1.Controls.Add(Me.rbInvDate)
        Me.GroupBox1.Controls.Add(Me.rbAcct)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(720, 152)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.utInvoice)
        Me.Panel2.Controls.Add(Me.btnInvoice)
        Me.Panel2.Location = New System.Drawing.Point(118, 112)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(192, 32)
        Me.Panel2.TabIndex = 168
        '
        'utInvoice
        '
        Appearance1.ForeColorDisabled = System.Drawing.Color.Black
        Me.utInvoice.Appearance = Appearance1
        Me.utInvoice.Location = New System.Drawing.Point(6, 5)
        Me.utInvoice.Name = "utInvoice"
        Me.utInvoice.Size = New System.Drawing.Size(104, 21)
        Me.utInvoice.TabIndex = 151
        '
        'btnInvoice
        '
        Me.btnInvoice.Location = New System.Drawing.Point(110, 6)
        Me.btnInvoice.Name = "btnInvoice"
        Me.btnInvoice.Size = New System.Drawing.Size(72, 21)
        Me.btnInvoice.TabIndex = 152
        Me.btnInvoice.Text = "Se&lect"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.btnAcct)
        Me.Panel1.Controls.Add(Me.utAcct)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.utAcctID)
        Me.Panel1.Location = New System.Drawing.Point(115, 11)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(453, 32)
        Me.Panel1.TabIndex = 167
        '
        'btnAcct
        '
        Me.btnAcct.Location = New System.Drawing.Point(360, 6)
        Me.btnAcct.Name = "btnAcct"
        Me.btnAcct.Size = New System.Drawing.Size(80, 21)
        Me.btnAcct.TabIndex = 147
        Me.btnAcct.Text = "Se&lect"
        '
        'utAcct
        '
        Me.utAcct.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utAcct.Location = New System.Drawing.Point(8, 6)
        Me.utAcct.Name = "utAcct"
        Me.utAcct.Size = New System.Drawing.Size(216, 21)
        Me.utAcct.TabIndex = 143
        Me.utAcct.Tag = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(224, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 23)
        Me.Label1.TabIndex = 148
        Me.Label1.Text = "Acct.ID:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utAcctID
        '
        Me.utAcctID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utAcctID.Location = New System.Drawing.Point(280, 6)
        Me.utAcctID.Name = "utAcctID"
        Me.utAcctID.Size = New System.Drawing.Size(72, 21)
        Me.utAcctID.TabIndex = 146
        Me.utAcctID.Tag = ""
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(472, 120)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(88, 21)
        Me.btnDelete.TabIndex = 163
        Me.btnDelete.Text = "&Delete Invoice"
        '
        'UltraDate2
        '
        Me.UltraDate2.DateTime = New Date(2004, 9, 27, 0, 0, 0, 0)
        Me.UltraDate2.Location = New System.Drawing.Point(123, 88)
        Me.UltraDate2.Name = "UltraDate2"
        Me.UltraDate2.Size = New System.Drawing.Size(96, 21)
        Me.UltraDate2.TabIndex = 150
        Me.UltraDate2.Value = New Date(2004, 9, 27, 0, 0, 0, 0)
        '
        'UltraDate1
        '
        Me.UltraDate1.DateTime = New Date(2004, 9, 27, 0, 0, 0, 0)
        Me.UltraDate1.Location = New System.Drawing.Point(123, 56)
        Me.UltraDate1.Name = "UltraDate1"
        Me.UltraDate1.Size = New System.Drawing.Size(96, 21)
        Me.UltraDate1.TabIndex = 149
        Me.UltraDate1.Value = New Date(2004, 9, 27, 0, 0, 0, 0)
        '
        'rbInvNo
        '
        Me.rbInvNo.Location = New System.Drawing.Point(8, 120)
        Me.rbInvNo.Name = "rbInvNo"
        Me.rbInvNo.Size = New System.Drawing.Size(96, 16)
        Me.rbInvNo.TabIndex = 3
        Me.rbInvNo.Text = "By Invoice No."
        '
        'rbCloseDate
        '
        Me.rbCloseDate.Location = New System.Drawing.Point(8, 90)
        Me.rbCloseDate.Name = "rbCloseDate"
        Me.rbCloseDate.Size = New System.Drawing.Size(104, 16)
        Me.rbCloseDate.TabIndex = 2
        Me.rbCloseDate.Text = "By Closing Date"
        '
        'rbInvDate
        '
        Me.rbInvDate.Location = New System.Drawing.Point(8, 56)
        Me.rbInvDate.Name = "rbInvDate"
        Me.rbInvDate.Size = New System.Drawing.Size(104, 16)
        Me.rbInvDate.TabIndex = 1
        Me.rbInvDate.Text = "By Invoice Date"
        '
        'rbAcct
        '
        Me.rbAcct.Location = New System.Drawing.Point(8, 22)
        Me.rbAcct.Name = "rbAcct"
        Me.rbAcct.Size = New System.Drawing.Size(96, 16)
        Me.rbAcct.TabIndex = 0
        Me.rbAcct.Text = "By Account"
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGrid1.Location = New System.Drawing.Point(0, 152)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(720, 325)
        Me.UltraGrid1.TabIndex = 145
        Me.UltraGrid1.Tag = "TrackingListing"
        Me.UltraGrid1.Text = "Invoice Summary"
        '
        'btnDisplay
        '
        Me.btnDisplay.Location = New System.Drawing.Point(376, 120)
        Me.btnDisplay.Name = "btnDisplay"
        Me.btnDisplay.Size = New System.Drawing.Size(88, 21)
        Me.btnDisplay.TabIndex = 169
        Me.btnDisplay.Text = "D&isplay"
        '
        'InvoiceDelete
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(720, 477)
        Me.Controls.Add(Me.UltraGrid1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "InvoiceDelete"
        Me.Text = "Delete Invoice"
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.utInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        CType(Me.utAcct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utAcctID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDate2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraDate1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub InvoiceDelete_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()

        AddHandler Me.Activated, AddressOf Form_Activated

        Me.KeyPreview = True
        MeText = Me.Text

        ' Set each control's length based on DB size
        'SetupCtrlsLength(Me)

        AddHandler Me.KeyUp, AddressOf Form_KeyUp
        'AddHandler utStartMile.KeyPress, AddressOf Value_Int_KeyPress
        'AddHandler utInvoiceNo.KeyPress, AddressOf Value_Int_KeyPress
        '
        'cmdTrans = Nothing


        utAcct.MaxLength = 30
        utAcct.Enabled = True
        btnAcct.Enabled = True
        utAcctID.MaxLength = 10


        UltraGrid1.Text = "Invoice Summaries"

        rbAcct.Checked = True

    End Sub

    Private Sub utAcct_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utAcct.Leave
        Dim row As DataRow
        Dim gAcct, gAcctID As Infragistics.Win.UltraWinEditors.UltraTextEditor

        Select Case sender.Name
            Case "utAcct"
                gAcct = utAcct
                gAcctID = utAcctID
        End Select

        If sender.Modified = False Then Exit Sub

        If sender.text.trim = "" Then
            gAcctID.Text = ""
            sender.text = ""
            'btnSave.Enabled = False
        Else
            ' This for Accounts With Numbers Only Name!!
            'If IsNumeric(sender.text) Then
            '    sender.text = "?" & sender.text
            '    sender.modified = True
            'End If
            If SearchOnLeave(sender, gAcctID, "" & BILLTblPath & "Customer", "CustomerID", "Name", "*", "Accounts", " Where Active = 'Y'") Then
                'If ReturnRowByID(utTruckInventID.Text, row, "TrucksManagement.dbo.Inventory", "", "Truck_Invent_ID") Then
                '    'utLicPlate.Text = row("Lic_Plate")
                '    'utTruckInventID.Text = row("Truck_Invent_ID")
                '    row = Nothing
                'Else
                '    MsgBox("Truck Not Found.")
                '    utTruckInventID.Text = ""
                '    utTruckID.Text = ""
                'End If
            Else
                'MsgBox("Truck Not Found.")
                gAcctID.Text = ""
                gAcct.Text = ""
                sender.focus()
            End If
        End If
        sender.Modified = False

    End Sub

    Private Sub utAcct_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles utAcct.KeyUp
        TypeAhead(sender, e, "" & BILLTblPath & "Customer", "Name", " Where Active = 'Y'")
    End Sub

    Private Sub utAcctID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utAcctID.Leave
        Dim row As DataRow
        Dim gAcct, gAcctID As Infragistics.Win.UltraWinEditors.UltraTextEditor

        Select Case sender.Name
            Case "utAcctID"
                gAcct = utAcct
                gAcctID = utAcctID
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
            If SearchOnLeave(sender, gAcctID, "" & BILLTblPath & "Customer", "CustomerID", "CustomerID", "*", "Accounts", " Where Active = 'Y'") Then
                If ReturnRowByID(gAcctID.Text, row, "" & BILLTblPath & "Customer", "", "CustomerID") Then
                    gAcct.Text = row("Name")
                    row = Nothing
                Else
                    'Message modified by Michael Pastor
                    MsgBox("Account cannot be found.", MsgBoxStyle.Exclamation.OKOnly, "Data Unavailable")
                    'MsgBox("Account Not Found.")
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
        End Select

        SelectSQL = "Select * from " & BILLTblPath & "Customer i WHERE (Active = 'Y') order by Name"

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
                'MsgBox("SQL_Error: " & osqlexception.Message)
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

    Private Sub btnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplay.Click

        LoadData()

    End Sub

    Private Sub LoadData()

        Dim dtAdapter As SqlDataAdapter
        Dim i As Integer
        Dim SQLSelect, SQLSelect2, Cond As String


        ' For Routesheet based on Scans:  SUBSTRING(ThirdPartyBarcode, 2 - 57 / ASCII(LEFT(ThirdPartyBarcode, 1)), LEN(ThirdPartyBarcode)) AS XThirdPartyBarcodeNum, '' as RteSheetTime, '' as RteSheetAddr,
        '  (Select Count(mft2.RowID) From " & TRCTblPath & "Manifest mft2 where convert(varchar, mft2.[DATETIME], 112) = convert(varchar, mft.[DATETIME], 112) AND mft2.ToAddID = mft.ToAddID AND mft2.FromCustID = mft.FromCustID) as Pkg_Count 
        SQLSelect = " Select Invoice_No, CustomerID, Invoice_Date, Closing_Date, Due_Date, Total_Amount, Name, Contact, Address1, Address2, City, State, Zip, Phone, Fax, Email " & _
                    " from " & _
                    " " & BILLTblPath & "Invoices i " & _
                    " Where  " & _
                    " @INVCOND " & _
                    " order by i.Invoice_Date "

        SQLSelect2 = "Select ili.Invoice_No, mft.TrackingNum, mft.ToLocID, mft.ToLocName, mft.ToCity, mft.ToState, mft.ToZip, ili.TranDate, ili.Description, ili.Qty, ili.Unit, ili.Charge from " & BILLTblPath & "InvoiceLineItems ili left outer join " & TRCTblPath & "Manifest mft on ili.MftRowID = mft.RowID " & _
                     " where(ili.invoice_No = @INVNO) AND ili.charge is not NULL order by LineNum; "

        Select Case rbCurrIdx
            Case 0 ' Acct
                If utAcctID.Text.Trim = "" Then
                    'Message modified by Michael Pastor
                    MsgBox("Account ID remains unspecified. Please enter a valid Account ID to continue.", MsgBoxStyle.Exclamation.OKOnly, "Missing Data Input")
                    'MsgBox("Account is not selected.")
                    Exit Sub
                End If
                Cond = " i.CustomerID = '" & utAcctID.Text.Trim & "'"
            Case 1 ' InvDate
                If UltraDate1.Value Is Nothing Then
                    'Message modified by Michael Pastor
                    MsgBox("Invoice date remains unspecified. Please select a valid invoice date to continue.", MsgBoxStyle.Exclamation.OKOnly, "Missing Data Input")
                    'MsgBox("Invoice_Date is not set.")
                    Exit Sub
                End If
                Cond = " i.Invoice_Date = '" & UltraDate1.Text & "'"
            Case 2 ' ClDate
                If UltraDate2.Value Is Nothing Then
                    'Message modified by Michael Pastor
                    MsgBox("Closing date remains unspecified. Please select a valid closing date to continue.", MsgBoxStyle.Exclamation.OKOnly, "Missing Data Input")
                    'MsgBox("Closing_Date is not set.")
                    Exit Sub
                End If
                Cond = " i.Closing_Date = '" & UltraDate2.Text & "'"
            Case 3 'InvNo
                If utInvoice.Text.Trim = "" Then
                    'Message modified by Michael Pastor
                    MsgBox("Invoice remains unspecified. Please enter a valid invoice to continue.", MsgBoxStyle.Exclamation.OKOnly, "Missing Data Input")
                    MsgBox("Invoice is not selected.")
                    Exit Sub
                End If
                Cond = " i.Invoice_No = '" & utInvoice.Text.Trim & "'"
        End Select
        'SQLSelect = SQLSelect.Replace("@DATERNG", "AND CONVERT(datetime, CONVERT(varchar, e.ScanDate, 101)) between '" & UltraDate1.Text & "' AND dateadd(d, 1,'" & UltraDate2.Text & "')")

        '-- Date
        SQLSelect = SQLSelect.Replace("@INVCOND", Cond)

        PopulateDataset2(dtAdapter, dtSet, SQLSelect)

        For i = 0 To dtSet.Tables(0).Columns.Count - 1
            dtSet.Tables(0).Columns(i).ReadOnly = True
        Next
        'dtSet.Tables(0).Columns(0).ReadOnly = False

        FillUltraGrid(UltraGrid1, dtSet, -1, HidCols, 0)
        'UltraGrid1.DataSource = dtSet
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

        Dim SumCol As String = "Invoice_No"
        UltraGrid1.DisplayLayout.Bands(0).Summaries.Add(SumCol, Infragistics.Win.UltraWinGrid.SummaryType.Count, UltraGrid1.DisplayLayout.Bands(0).Columns(SumCol), Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn)
        UltraGrid1.DisplayLayout.Bands(0).Summaries(SumCol).Appearance.TextHAlign = Infragistics.Win.HAlign.Right
        UltraGrid1.DisplayLayout.Bands(0).SummaryFooterCaption = ""
        UltraGrid1.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False


        UltraGrid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnCellChangeOrLostFocus

        UltraGrid1.DisplayLayout.GroupByBox.Hidden = False
        UltraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.FirstRowInGrid, False, False)
        'UltraGrid1.Text = "Packages"
    End Sub
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
        'Message modified by Michael Pastor
        MsgBox("Error: " & Err.Description, MsgBoxStyle.Critical, "Critical Error")
        'MsgBox("Error : " & Err.Description)
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

    Private Sub rbAcct_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles rbAcct.CheckedChanged, rbCloseDate.CheckedChanged, rbInvDate.CheckedChanged, rbInvNo.CheckedChanged

        Select Case sender.Name.toupper
            Case "RBACCT"
                rbCurrIdx = 0
                Panel1.Visible = True
                utAcct.Text = ""
                utAcctID.Text = ""

                Panel2.Visible = False
                UltraDate1.Visible = False
                UltraDate2.Visible = False

            Case "RBINVDATE"
                rbCurrIdx = 1
                UltraDate1.Visible = True
                UltraDate1.Nullable = True
                UltraDate1.Value = Date.Today 'DateAdd(DateInterval.Day, -1, Date.Today)
                UltraDate1.FormatString = "MM/dd/yyyy"

                Panel1.Visible = False
                Panel2.Visible = False
                UltraDate2.Visible = False
            Case "RBCLOSEDATE"
                rbCurrIdx = 2
                UltraDate2.Visible = True
                UltraDate2.Nullable = True
                UltraDate2.Value = Date.Today 'DateAdd(DateInterval.Day, -1, Date.Today)
                UltraDate2.FormatString = "MM/dd/yyyy"

                Panel1.Visible = False
                Panel2.Visible = False
                UltraDate1.Visible = False
            Case "RBINVNO"
                rbCurrIdx = 3
                Panel2.Visible = True
                utInvoice.Text = ""

                Panel1.Visible = False
                UltraDate1.Visible = False
                UltraDate2.Visible = False
        End Select
    End Sub
    Class clsCustInfo
        Public CustomerID As String
        Public Name As String
        Public Address1 As String
        Public Address2 As String
        Public City As String
        Public State As String
        Public Zip As String
        Public Contact As String
        Public Phone As String
        Public eMail As String
        Public CourCode As String
        Public Active As String
        Public LocIDSuff As String
    End Class

    Dim CustInfo As New clsCustInfo
    Dim InvoiceNo As Int32
    Dim CustomerID, Customer As String
    Dim Invoicedate, InvoiceAmount, InvoiceDueDate As String

    Private Sub btnInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInvoice.Click
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow

        SelectSQL = "Select Invoice_No, Invoice_Date, i.CustomerID, c.Name as Customer, Total_Amount, Due_DATE from " & BILLTblPath & "Invoices i, " & BILLTblPath & "Customer c where i.customerid = c.customerid order by Invoice_Date Desc"

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
                'Message modified by Michael Pastor
                MsgBox("SQL_Error: " & osqlexception.Message, MsgBoxStyle.Critical, "Critical Error")
                'MsgBox("SQL_Error: " & osqlexception.Message)
                Srch = Nothing
                sender.Focus()
                Exit Try
            Finally
                If HasErr = False Then
                    ugRow = Srch.UltraGrid1.ActiveRow
                    'AcctName.Text = ugRow.Cells("Name").Text
                    utInvoice.Text = ugRow.Cells("Invoice_No").Text
                    InvoiceNo = ugRow.Cells("Invoice_No").Value
                    CustomerID = ugRow.Cells("CustomerID").Value
                    Customer = ugRow.Cells("Customer").Value
                    Invoicedate = Format(ugRow.Cells("Invoice_Date").Value, "yyyyMMdd")
                    InvoiceAmount = Format(ugRow.Cells("tOTAL_aMOUNT").Value, "#0.00")
                    InvoiceAmount = InvoiceAmount.Replace(".", "")

                    If ugRow.Cells("Due_Date").Value Is DBNull.Value Then
                        InvoiceDueDate = Format(ugRow.Cells("Invoice_Date").Value, "yyyyMMdd")
                    Else
                        InvoiceDueDate = Format(ugRow.Cells("Due_Date").Value, "yyyyMMdd")
                    End If

                    Srch = Nothing
                    utInvoice.Modified = False
                End If
            End Try
        End If

        dtSet.Dispose()
        dtAdapter.Dispose()
        dtSet = Nothing
        dtAdapter = Nothing

        If HasErr Then Exit Sub
        Dim qryCust As String = "Select * from " & BILLTblPath & "Customer where customerid = " & CustomerID
        dtAdapter = New SqlDataAdapter
        dtSet = New DataSet
        PopulateDataset2(dtAdapter, dtSet, qryCust)
        Dim row As DataRow
        If dtSet.Tables.Count <= 0 Then
            'Message modified by Michael Pastor
            MsgBox("No data can be found.", MsgBoxStyle.Exclamation.OKOnly, "Data Unavailable")
            'MsgBox("No Data.")
            utInvoice.Text = ""
            Exit Sub
        End If
        If dtSet.Tables(0).Rows.Count <= 0 Then
            'Message modified by Michael Pastor
            MsgBox("No data can be found.", MsgBoxStyle.Exclamation.OKOnly, "Data Unavailable")
            'MsgBox("No Data.")
            utInvoice.Text = ""
            Exit Sub
        End If
        row = dtSet.Tables(0).Rows(0)
        CustInfo.CustomerID = row("CustomerID") & ""
        CustInfo.Name = row("Name") & ""
        CustInfo.Address1 = row("Address1") & ""
        CustInfo.Address2 = row("Address2") & ""
        CustInfo.City = row("City") & ""
        CustInfo.State = row("State") & ""
        CustInfo.Zip = row("Zip") & ""
        CustInfo.Contact = row("Contact") & ""
        CustInfo.Phone = row("Phone") & ""
        CustInfo.eMail = row("email") & ""
        CustInfo.CourCode = row("CourierCode") & ""
        CustInfo.Active = row("Active") & ""
        CustInfo.LocIDSuff = row("LocIDSuffix") & ""

        dtSet.Dispose()
        dtAdapter.Dispose()
        dtSet = Nothing
        dtAdapter = Nothing

    End Sub

    Private Sub utInvoice_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utInvoice.Leave
        Dim SelectSQL As String
        Dim dbrow As DataRow
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow

        If sender.Text.Trim = "" Then Exit Sub
        SelectSQL = "Select Invoice_No, Invoice_Date, i.CustomerID, c.Name as Customer, Total_Amount, Due_DATE from " & BILLTblPath & "Invoices i, " & BILLTblPath & "Customer c where i.customerid = c.customerid and i.Invoice_No = " & utInvoice.Text & " order by Invoice_Date Desc"
        If ReturnRowByID(utInvoice.Text, dbrow, BILLTblPath & "Invoices", "", "Invoice_No", SelectSQL) = False Then
            'Message modified by Michael Pastor
            MsgBox("Invoice cannot be found.", MsgBoxStyle.Exclamation.OKOnly, "Data Unavailable")
            'MsgBox("Invoice Not Found.")
            utInvoice.Text = ""
            Exit Sub
        End If

        'utInvoice.Text = ugRow.Cells("Invoice_No").Text
        InvoiceNo = dbrow("Invoice_No")
        CustomerID = dbrow("CustomerID")
        Customer = dbrow("Customer")
        Invoicedate = Format(dbrow("Invoice_Date"), "yyyyMMdd")
        InvoiceAmount = Format(dbrow("TOTAL_AMOUNT"), "#0.00")
        InvoiceAmount = InvoiceAmount.Replace(".", "")

        If dbrow("Due_Date") Is DBNull.Value Then
            InvoiceDueDate = Format(dbrow("Invoice_Date"), "yyyyMMdd")
        Else
            InvoiceDueDate = Format(dbrow("Due_Date"), "yyyyMMdd")
        End If


        Dim qryCust As String = "Select * from " & BILLTblPath & "Customer where customerid = '" & CustomerID & "'"
        If ReturnRowByID("", dbrow, BILLTblPath & "Customer", "", "CustomerID", qryCust) = False Then
            'Message modified by Michael Pastor
            MsgBox("Customer cannot be found.", MsgBoxStyle.Exclamation.OKOnly, "Data Unavailable")
            'MsgBox("Customer Not Found.")
            utInvoice.Text = ""
            Exit Sub
        End If
        CustInfo.CustomerID = dbrow("CustomerID") & ""
        CustInfo.Name = dbrow("Name") & ""
        CustInfo.Address1 = dbrow("Address1") & ""
        CustInfo.Address2 = dbrow("Address2") & ""
        CustInfo.City = dbrow("City") & ""
        CustInfo.State = dbrow("State") & ""
        CustInfo.Zip = dbrow("Zip") & ""
        CustInfo.Contact = dbrow("Contact") & ""
        CustInfo.Phone = dbrow("Phone") & ""
        CustInfo.eMail = dbrow("email") & ""
        CustInfo.CourCode = dbrow("CourierCode") & ""
        CustInfo.Active = dbrow("Active") & ""
        CustInfo.LocIDSuff = dbrow("LocIDSuffix") & ""

        dbrow = Nothing

    End Sub

    Private Sub btnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim InvNo As String

        If UltraGrid1.ActiveRow Is Nothing Then
            'Message modified by Michael Pastor
            MsgBox("Invoice remains unspecified. Please select an invoice to continue.", MsgBoxStyle.Exclamation.OKOnly, "Data Unavailable")
            'MsgBox("No invoice selected.")
            Exit Sub
        End If
        If UltraGrid1.ActiveRow.ListObject Is Nothing Then
            'Message modified by Michael Pastor
            MsgBox("Invoice remains unspecified. Please select an invoice to continue.", MsgBoxStyle.Exclamation.OKOnly, "Data Unavailable")
            'MsgBox("No invoice selected.")
            Exit Sub
        End If
        If UltraGrid1.ActiveRow.Cells("Invoice_No").Value <= 0 Then
            'Message modified by Michael Pastor
            MsgBox("Invoice number remains unspecified. Please select an invoice number to continue.", MsgBoxStyle.Exclamation.OKOnly, "Data Unavailable")
            'MsgBox("No invoice number.")
            Exit Sub
        End If

        InvNo = UltraGrid1.ActiveRow.Cells("Invoice_No").Value
        'Message modified by Michael Pastor
        If MsgBox("Are you sure to delete invoice number " & UltraGrid1.ActiveRow.Cells("Invoice_No").Value & "?", MsgBoxStyle.Exclamation.YesNo) = MsgBoxResult.Yes Then
            'If MsgBox("Are you sure to delete invoice number " & UltraGrid1.ActiveRow.Cells("Invoice_No").Value & "?", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            Dim x As New EnterTextBox
            x.Label1.Text = "Invopice No.:"
            x.Label2.Text = ""
            x.Label2.Visible = False
            x.btnBrowse1.Visible = True

            x.Text = "Please type in the invoice number you want to DELETE ..."
            x.TextBox1.Enabled = True
            x.TextBox1.Text = ""
            x.TextBox2.Visible = False

            x.btnSave.Text = "&Delete"
            'x.Show()
            x.ShowDialog(Me)
            If x.DialogResult = DialogResult.OK Then
                If x.TextBox1.Text.Trim = "" Then
                    'Message modified by Michael Pastor
                    MsgBox("Invoice number remains unspecified. Please enter an invoice number to continue.", MsgBoxStyle.Exclamation.OKOnly, "Data Unavailable")
                    'MsgBox("No invoice number specified.")
                    Exit Sub
                End If
                If InvNo <> x.TextBox1.Text Then
                    'Message modified by Michael Pastor
                    MsgBox("The selected invoice does not match with the specified number. Invoice deletion aborted.", MsgBoxStyle.Exclamation.OKOnly, "Data Deletion")
                    'MsgBox("The selected invoice does not match with the typed-in number. Invoice is not deleted.")
                    x.Dispose()
                    x = Nothing
                    Exit Sub
                End If
                x.Dispose()
                x = Nothing
                Me.Cursor = Cursors.WaitCursor
                Dim qInvDelete As String = BILLTblPath & "DeleteInvoice " & InvNo & ", 'TRACKING', '" & BILLTblPath & "', '" & TRCTblPath & "'"
                If ExecuteQuery(qInvDelete) = False Then
                    'Message modified by Michael Pastor
                    MsgBox("Invoice deletion failed.", MsgBoxStyle.Exclamation.OKOnly, "Data Deletion")
                    'MsgBox("Deletion failed.")
                End If
                LoadData()
                Me.Cursor = Cursors.Default
            End If
        End If

        Exit Sub

ErrTrap:
        If Err.Number > 0 Then
            'Message modified by Michael Pastor
            MsgBox("Error in btnNewGroup_Click : " & Err.Description, MsgBoxStyle.Critical, "Critical Error")
            'MsgBox("Error in btnNewGroup_Click : " & Err.Description)
        End If


    End Sub
End Class
