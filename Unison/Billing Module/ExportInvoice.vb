Imports System.Data
Imports System.Data.SqlClient
'Imports Microsoft.VisualBasic
Imports System.IO

Public Class ExportInvoice
    Inherits System.Windows.Forms.Form

    Dim MeText As String

    Dim InvoiceNo As Int32
    Dim CustomerID, Customer As String
    Dim Invoicedate, InvoiceAmount, InvoiceDueDate As String
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnInvoice As System.Windows.Forms.Button
    Friend WithEvents utInvoice As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnExport As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnExport = New System.Windows.Forms.Button
        Me.btnInvoice = New System.Windows.Forms.Button
        Me.utInvoice = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.utInvoice, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnExport)
        Me.GroupBox1.Controls.Add(Me.btnInvoice)
        Me.GroupBox1.Controls.Add(Me.utInvoice)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(616, 109)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'btnExport
        '
        Me.btnExport.Location = New System.Drawing.Point(112, 72)
        Me.btnExport.Name = "btnExport"
        Me.btnExport.Size = New System.Drawing.Size(72, 21)
        Me.btnExport.TabIndex = 7
        Me.btnExport.Text = "E&xport"
        '
        'btnInvoice
        '
        Me.btnInvoice.Location = New System.Drawing.Point(216, 27)
        Me.btnInvoice.Name = "btnInvoice"
        Me.btnInvoice.Size = New System.Drawing.Size(72, 21)
        Me.btnInvoice.TabIndex = 6
        Me.btnInvoice.Text = "Se&lect"
        '
        'utInvoice
        '
        Appearance1.ForeColorDisabled = System.Drawing.Color.Black
        Me.utInvoice.Appearance = Appearance1
        Me.utInvoice.Location = New System.Drawing.Point(104, 25)
        Me.utInvoice.Name = "utInvoice"
        Me.utInvoice.Size = New System.Drawing.Size(104, 21)
        Me.utInvoice.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(32, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Invoice No.:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ExportInvoice
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(616, 109)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "ExportInvoice"
        Me.Text = "Export Invoice to EDI"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.utInvoice, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub ExportInvoice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler Me.Activated, AddressOf Form_Activated

        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = BILLTblPath & Me.Tag
            End If
        End If


        Me.CenterToScreen()

        Me.KeyPreview = True
        MeText = Me.Text

    End Sub

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
        Dim qryCust As String = "Select * from " & BILLTblPath & "Customer where customerid = '" & CustomerID & "'"
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

    Private Sub btnExport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExport.Click
        Dim FilesArr(), FileName(), ValidFiles() As String
        Dim srObj As StreamReader
        Dim swObj As StreamWriter
        Dim i, j As Int32
        Dim InvFileName As String = "FTPTPCI."
        Dim StrLine, Date8ISO, Date6ISO, Time4, MMDDTime As String
        Dim Element, Segment, SubElem As String
        Dim SegCnt As Int32

        InvFileName = InvFileName & Format(Date.Now, "MMddHHmm")
        Element = "^" : Segment = "~" : SubElem = ">"
        If utInvoice.Text.Trim = "" Then
            'Message modified by Michael Pastor
            MsgBox("Invoice number remains unspecified.", MsgBoxStyle.Exclamation.OKOnly, "Missing Data Input")
            'MsgBox("No Invoice Number.")
            Exit Sub
        End If
        If IsNumeric(utInvoice.Text) = False Then
            'Message modified by Michael Pastor
            MsgBox("The invoice number is invalid. Please enter a valid invoice number.", MsgBoxStyle.Exclamation.OKOnly, "Data Invalid")
            'MsgBox("Invoice Number is not numeric.")
            Exit Sub
        End If

        EDIPath = EDIPath.ToUpper
        Date8ISO = Format(Date.Now, "yyyyMMyy")
        Date6ISO = Format(Date.Now, "yyMMdd")
        Time4 = Format(Date.Now, "HHmm")
        MMDDTime = Format(Date.Now, "MMddHHmm")
        SegCnt = 0

        If System.IO.Directory.Exists(EDIPath) Then
            Dim qryManifest As String = "Select m.*, mi.Invoice_NO, mi.Charge, mi.Ref1, mi.Ref2, mi.Ref3, mi.Ref4, mi.Ref5 from " & TRCTblPath & "Manifest m, " & TRCTblPath & "ManifestInvoiceArchive mi where mi.Invoice_No = " & InvoiceNo & " AND m.rowid = mi.rowid Order by m.[DateTime]"
            Dim qryInv As String = "Select * from " & BILLTblPath & "Invoices where Invoice_No = " & InvoiceNo & ""
            'Dim qryWgtTotal As String = "Select sum(Weight) as Total_Weight, Sum(Charge) as Total_Wgt_Charge, Count(RowID) as Total_Pieces from " & BILLTblPath & "ManifestInvoiceArchive where Invoice_No = " & InvoiceNo & " AND Charge is not NULL "
            Dim qryWgtTotal As String = "Select sum(Qty) as Total_Weight, Sum(Charge) as Total_Wgt_Charge, Count(LineNum) as Total_Pieces from " & BILLTblPath & "InvoiceLineItems where Invoice_No = " & InvoiceNo & " AND Charge is not NULL "
            Dim qryInvLines As String = "Select ili.* from " & BILLTblPath & "InvoiceLineItems ili where ili.Invoice_No = " & InvoiceNo & " AND ili.CHARGE is Not NULL order by ili.LineNum"

            Dim dtAdapter As New SqlDataAdapter
            Dim dtSet As New DataSet
            Dim TmpStr As String

            PopulateDataset2(dtAdapter, dtSet, qryManifest)
            PopulateDataset2(dtAdapter, dtSet, qryInv, True)
            PopulateDataset2(dtAdapter, dtSet, qryWgtTotal, True)
            PopulateDataset2(dtAdapter, dtSet, qryInvLines, True)
            Dim row As DataRow
            If dtSet.Tables.Count <= 0 Then
                'Message modified by Michael Pastor
                MsgBox("No data can be found.", MsgBoxStyle.Exclamation.OKOnly, "Data Unavailable")
                'MsgBox("No Data.")
                utInvoice.Text = ""
                Exit Sub
            End If
            If dtSet.Tables(0).Rows.Count <= 0 Then
                If dtSet.Tables(3).Rows.Count <= 0 Then
                    'Message modified by Michael Pastor
                    MsgBox("No data can be found.", MsgBoxStyle.Exclamation.OKOnly, "Data Unavailable")
                    'MsgBox("No Data.")
                    utInvoice.Text = ""
                    Exit Sub
                End If
            End If
            If dtSet.Tables(1).Rows.Count <= 0 Then
                'Message modified by Michael Pastor
                MsgBox("Invoice cannot be found.", MsgBoxStyle.Exclamation.OKOnly, "Data Unavailable")
                'MsgBox("Error: No Invoice Found.")
                Exit Sub
            End If
            If dtSet.Tables(2).Rows.Count <= 0 Then
                'Message modified by Michael Pastor
                MsgBox("Total weight cannot be found.", MsgBoxStyle.Exclamation.OKOnly, "Data Unavailable")
                'MsgBox("Error: No Total Weight Fetched.")
                Exit Sub
            End If
            If dtSet.Tables(3).Rows.Count <= 0 Then
                'Message modified by Michael Pastor
                MsgBox("Rows for invoice lineitems cannot be found.", MsgBoxStyle.Exclamation.OKOnly, "Data Unavailable")
                'MsgBox("Error: No Rows for Invoice LineItems Fetched.")
                Exit Sub
            End If

            'FilesArr = System.IO.Directory.GetFiles(EDIPath)
            swObj = New StreamWriter(EDIPath & "\" & InvFileName, False)

            'Read the first line of text.

            StrLine = "ISA" & Element & "00" & Element & Space(10) & Element & "00" & Element & Space(10) & Element & "02" & Element & "TPC" & Space(15 - 3) & Element & "ZZ" & Element & "INGRAM" & Space(15 - Len("INGRAM")) & Element & Date6ISO & Element & Time4 & Element & "U" & Element & "00400" & Element & MMDDTime & "1" & Element & "0" & Element & "P" & Element & SubElem & Segment
            swObj.WriteLine(StrLine)

            StrLine = "GS" & Element & "IM" & Element & "TPC" & Element & "INGRAM" & Element & Date6ISO & Element & Time4 & Element & MMDDTime & Element & "X" & Element & "00403" & Segment
            swObj.WriteLine(StrLine)

            StrLine = "ST" & Element & "210" & Element & MMDDTime & "3" & Segment
            SegCnt += 1
            swObj.WriteLine(StrLine)

            StrLine = "B3" & Element & Element & InvoiceNo & Element & Element & "PP" & Element & Element & Invoicedate & Element & InvoiceAmount & Space(4).Replace(" ", Element) & "TPC" & Element & InvoiceDueDate & Segment
            SegCnt += 1
            swObj.WriteLine(StrLine)

            StrLine = "N1" & Element & "SH" & Element & Customer & Element & "ZZ" & Element & CustomerID & Segment
            SegCnt += 1
            swObj.WriteLine(StrLine)

            StrLine = "N3" & Element & CustInfo.Address1 & Element & CustInfo.Address2 & Segment
            SegCnt += 1
            swObj.WriteLine(StrLine)

            StrLine = "N4" & Element & CustInfo.City & Element & CustInfo.State & Element & CustInfo.Zip & Element & "US" & Segment
            SegCnt += 1
            swObj.WriteLine(StrLine)

            Try

                For i = 1 To dtSet.Tables(0).Rows.Count
                    row = dtSet.Tables(0).Rows(i - 1)

                    StrLine = "LX" & Element & i & Segment
                    SegCnt += 1
                    swObj.WriteLine(StrLine)

                    If Not row("TrackingNum") Is Nothing Then
                        StrLine = "N9" & Element & "2I" & Space(1).Replace(" ", Element) & row("TrackingNum") & Element & Element & Format(row("DateTime"), "yyyyMMdd") & Space(3).Replace(" ", Element) & "ZZ" & SubElem & "PP" & Segment
                        SegCnt += 1
                        swObj.WriteLine(StrLine)
                    End If
                    If row("RefNum") <> "" Then
                        Dim sRefNum As String = row("RefNum")
                        If sRefNum.Length >= 7 Then
                            TmpStr = row("RefNum").substring(6)
                        Else
                            TmpStr = row("RefNum")
                        End If
                        StrLine = "N9" & Element & "MA" & Element & TmpStr.Trim & Segment
                        SegCnt += 1
                        swObj.WriteLine(StrLine)
                    End If
                    If row("Ref2") <> "" Then
                        TmpStr = row("Ref2").substring(4)
                        StrLine = "N9" & Element & "ACI" & Element & TmpStr.Trim & Segment
                        SegCnt += 1
                        swObj.WriteLine(StrLine)
                    End If
                    If row("Ref3") <> "" Then
                        TmpStr = row("Ref3").substring(3)
                        StrLine = "N9" & Element & "PO" & Element & TmpStr.Trim & Segment
                        SegCnt += 1
                        swObj.WriteLine(StrLine)
                    End If
                    StrLine = "L0" & Space(4).Replace(" ", Element) & row("Weight") & Element & "B" & Element & Element & Element & "1" & Element & "PKG" & Element & Element & "L" & Segment
                    SegCnt += 1
                    swObj.WriteLine(StrLine)

                    'Charge code = FRGT
                    StrLine = "L1" & Space(4).Replace(" ", Element) & CStr(row("Charge")).Replace(".", "") & Space(4).Replace(" ", Element) & "400" & Segment
                    SegCnt += 1
                    swObj.WriteLine(StrLine)

                    StrLine = "N1" & Element & "CN" & Element & row("ToLocName") & Segment
                    SegCnt += 1
                    swObj.WriteLine(StrLine)

                    StrLine = "N3" & Element & row("ToAdd1") & Element & row("ToAdd2") & "" & Segment
                    SegCnt += 1
                    swObj.WriteLine(StrLine)

                    StrLine = "N4" & Element & row("ToCity") & Element & row("ToSTATE") & "" & Element & row("ToZIP") & Element & "US" & Segment
                    SegCnt += 1
                    swObj.WriteLine(StrLine)
                Next

            Catch ex As Exception

                MsgBox("Problem with " & row("TrackingNum") & " " & ex.Message)
                Return

            End Try

            Dim dv As New DataView
            Dim jj As Int32
            Dim ChargeCode As String = ""

            dv = dtSet.Tables(3).DefaultView
            dv.RowFilter = " CHARGE_CODE <> 'FRGT'"
            For jj = 0 To dv.Count - 1

                row = dv.Item(jj).Row

                If TypeOf row("Charge") Is System.DBNull Then GoTo NextJJ

                Select Case row("Charge_Code").toupper
                    Case "FUE"
                        ChargeCode = "FUE"
                    Case "DSC"
                        ChargeCode = "DSC"
                    Case "LH"
                        ChargeCode = "LHS"
                    Case "CONN"
                        ChargeCode = "COC"
                        'Case Nothing
                        '    GoTo NextJJ
                    Case Else
                        ChargeCode = "MSC"
                End Select

                StrLine = "LX" & Element & i & Segment
                i += 1
                SegCnt += 1
                swObj.WriteLine(StrLine)

                StrLine = "L0" & Space(4).Replace(" ", Element) & row("Qty") & Element & "B" & Segment '& Space(3).Replace(" ", Element) & "1" & Element & "PKG" & Element & Element & "L" & Segment
                SegCnt += 1
                swObj.WriteLine(StrLine)

                StrLine = "L1" & Space(4).Replace(" ", Element) & CStr(row("Charge")).Replace(".", "") & Space(4).Replace(" ", Element) & ChargeCode & Space(4).Replace(" ", Element) & row("Description") & Segment
                SegCnt += 1
                swObj.WriteLine(StrLine)
NextJJ:
            Next jj



            'row = dtSet.Tables(1).Rows(0)
            'StrLine = "L3" & Element & dtSet.Tables(2).Rows(0).Item("Total_Weight") & Element & "B" & Element & Element & Element & CStr(row("Total_Amount")).Replace(".", "") & Space(6).Replace(" ", Element) & dtSet.Tables(2).Rows(0).Item("Total_Pieces") & Segment
            'SegCnt += 1
            'swObj.WriteLine(StrLine)

            SegCnt += 1
            StrLine = "SE" & Element & SegCnt & Element & MMDDTime & "3" & Segment
            swObj.WriteLine(StrLine)

            StrLine = "GE" & Element & "1" & Element & MMDDTime & Segment
            swObj.WriteLine(StrLine)

            StrLine = "IEA" & Element & "1" & Element & MMDDTime & "1" & Segment
            swObj.WriteLine(StrLine)

            swObj.Flush()
            swObj.Close()
            'Message modified by Michael Pastor
            MsgBox("Export Complete.", MsgBoxStyle.Exclamation.OKOnly, "Save Successful")
            'MsgBox("Export Complete")
        Else
            'Message modified by Michael Pastor
            MsgBox("Path does not exist.", MsgBoxStyle.Exclamation.OKOnly, "Data Unavailable")
            'MsgBox("Path does not exist")
        End If

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
End Class
