Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors
Imports CrystalDecisions.CrystalReports.ViewerObjectModel
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared
Imports System.Windows.Forms

Public Class PrintLabels
    Inherits System.Windows.Forms.Form
    Dim RepDoc As ReportDocument

    Dim MeText As String
    Public CustID, LocID, StartCounter As String
    Public AddressID As Int32

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
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnDisplay As System.Windows.Forms.Button
    Friend WithEvents utQty As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ucboLabels As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents btnTest As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnTest = New System.Windows.Forms.Button
        Me.ucboLabels = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnDisplay = New System.Windows.Forms.Button
        Me.utQty = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        CType(Me.ucboLabels, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utQty, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnTest)
        Me.GroupBox1.Controls.Add(Me.ucboLabels)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btnDisplay)
        Me.GroupBox1.Controls.Add(Me.utQty)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(624, 64)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'btnTest
        '
        Me.btnTest.Location = New System.Drawing.Point(440, 32)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.TabIndex = 18
        Me.btnTest.Text = "OOS TPCS"
        Me.btnTest.Visible = False
        '
        'ucboLabels
        '
        Me.ucboLabels.AutoEdit = False
        Me.ucboLabels.DisplayMember = ""
        Me.ucboLabels.Location = New System.Drawing.Point(292, 37)
        Me.ucboLabels.Name = "ucboLabels"
        Me.ucboLabels.Size = New System.Drawing.Size(140, 21)
        Me.ucboLabels.TabIndex = 1
        Me.ucboLabels.Tag = "LabelForms.Form_Name..1.LabelForms.RowID.Form_Name"
        Me.ucboLabels.ValueMember = ""
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(208, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 16)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "Label Type:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnDisplay
        '
        Me.btnDisplay.Location = New System.Drawing.Point(512, 36)
        Me.btnDisplay.Name = "btnDisplay"
        Me.btnDisplay.Size = New System.Drawing.Size(88, 21)
        Me.btnDisplay.TabIndex = 2
        Me.btnDisplay.Text = "&Print"
        '
        'utQty
        '
        Me.utQty.Location = New System.Drawing.Point(96, 38)
        Me.utQty.MaxLength = 3
        Me.utQty.Name = "utQty"
        Me.utQty.Size = New System.Drawing.Size(56, 21)
        Me.utQty.TabIndex = 0
        Me.utQty.Tag = ""
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 10
        Me.Label2.Text = "Labels Qty.:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(592, 16)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Location"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PrintLabels
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(624, 69)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "PrintLabels"
        Me.Text = "Print Labels"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.ucboLabels, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utQty, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub PrintLabels_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        'AddHandler Me.Activated, AddressOf Form_Activated
        'If Not Me.Tag Is Nothing Then
        '    If Me.Tag <> "" Then
        '        Me.Tag = TRCTblPath & Me.Tag
        '    End If
        'End If

        Me.CenterToScreen()

        Me.KeyPreview = True
        MeText = Me.Text

        ' Set each control's length based on DB size
        'SetupCtrlsLength(Me)

        AddHandler Me.KeyUp, AddressOf Form_KeyUp
        AddHandler utQty.KeyPress, AddressOf Value_Int_KeyPress

        'Karin Changed
        'FillUCombo(ucboLabels, "", "", "Select * From " & TRCTblPath & "LabelForms Order by Form_Name ")
        FillUCombo(ucboLabels, "", "", "Select * From " & TRCTblPath & "LabelForms Order by Form_Name ", TRCTblPath)
        AddHandler ucboLabels.Leave, AddressOf UCbo_Leave

    End Sub

    Private Sub btnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplay.Click

        Dim Range1, Range2 As String
        Dim LastNum As Int16

        If CustID.Trim = "" Then
            MsgBox("No Account Specified.")
            Exit Sub
        End If
        If LocID.Trim = "" Then
            MsgBox("No Location Specified.")
            Exit Sub
        End If
        If StartCounter.Trim = "" Then
            MsgBox("No StartCounter Specified.")
            Exit Sub
        End If
        If utQty.Text.Trim = "" Then
            utQty.Text = ""
            MsgBox("Please specify number of Labels to be printed.")
            Exit Sub
        End If
        If Val(utQty.Text.Trim) > 60 Then
            'utQty.Text = ""
            MsgBox("You can not print more than 60 labels per batch.")
            Exit Sub
        End If

        Dim paramDiscreteValue1 As New ParameterDiscreteValue
        Dim paramDiscreteValue2 As New ParameterDiscreteValue

        Dim paramFields1 As New ParameterFields

        Dim paramField1 As New ParameterField
        Dim paramField2 As New ParameterField


        'If Not RepDoc.IsLoaded() Then
        '    '    RepDoc.Load()
        'Else
        '    RepDoc.Close()
        '    '    RepDoc.Load()
        'End If
        If Not RepDoc Is Nothing Then
            RepDoc.Dispose()
            RepDoc = Nothing
        End If

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor()

        Dim ugrow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim BoxObj As CrystalDecisions.CrystalReports.Engine.BoxObject
        Dim BoxObj2 As CrystalDecisions.CrystalReports.Engine.BoxObject
        Dim Section As CrystalDecisions.CrystalReports.Engine.Section
        Dim TextObj As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim TextObj2 As CrystalDecisions.CrystalReports.Engine.TextObject
        Dim TextObjTo As CrystalDecisions.CrystalReports.Engine.TextObject

        'Dim FillCol As New System.Drawing.Color
        Dim x As Object
        'x.name = "SLabelsColor1x4"

        For Each ugrow In ucboLabels.Rows
            If ugrow.Cells("Form_Name").Value = ucboLabels.Text Then
                Select Case ugrow.Cells("Report").Value
                    Case "SLabelsVer2H"
                        RepDoc = New SLabelsVer2Hold

                        Section = RepDoc.ReportDefinition.Sections("DetailSection1")
                        Section.SectionFormat.BackgroundColor = Color.FromName(ugrow.Cells("COLOR").Value)

                    Case "SLabelsVer2"
                        RepDoc = New SLabelsVer2

                        Section = RepDoc.ReportDefinition.Sections("DetailSection1")
                        Section.SectionFormat.BackgroundColor = Color.FromName(ugrow.Cells("COLOR").Value)
                        'TextObj = RepDoc.ReportDefinition.ReportObjects("Text7")
                        'TextObj.Color = Color.FromName(ugrow.Cells("COLOR").Value)
                        'TextObj2 = RepDoc.ReportDefinition.ReportObjects("Text4")
                        'TextObj2.Color = Color.FromName(ugrow.Cells("COLOR").Value)

                    Case "SLabelsColor1x4"
                        RepDoc = New SLabelsColor1x4
                        'Select Case ugrow.Cells("COLOR").Value.toupper
                        '    Case "RED"
                        '        BoxObj = RepDoc.ReportDefinition.ReportObjects("Box2")
                        '        BoxObj.ObjectFormat.EnableSuppress = True
                        '        BoxObj = RepDoc.ReportDefinition.ReportObjects("Box3")
                        '        BoxObj.ObjectFormat.EnableSuppress = True
                        '    Case "BLUE"
                        '        BoxObj = RepDoc.ReportDefinition.ReportObjects("Box1")
                        '        BoxObj.ObjectFormat.EnableSuppress = True
                        '        BoxObj = RepDoc.ReportDefinition.ReportObjects("Box3")
                        '        BoxObj.ObjectFormat.EnableSuppress = True
                        '    Case "GREEN"
                        '        BoxObj = RepDoc.ReportDefinition.ReportObjects("Box2")
                        '        BoxObj.ObjectFormat.EnableSuppress = True
                        '        BoxObj = RepDoc.ReportDefinition.ReportObjects("Box1")
                        '        BoxObj.ObjectFormat.EnableSuppress = True
                        '    Case Else
                        '        BoxObj = RepDoc.ReportDefinition.ReportObjects("Box1")
                        '        BoxObj.ObjectFormat.EnableSuppress = True
                        '        BoxObj = RepDoc.ReportDefinition.ReportObjects("Box2")
                        '        BoxObj.ObjectFormat.EnableSuppress = True
                        '        BoxObj = RepDoc.ReportDefinition.ReportObjects("Box3")
                        '        BoxObj.ObjectFormat.EnableSuppress = True
                        'End Select

                        Section = RepDoc.ReportDefinition.Sections("DetailSection1")
                        Section.SectionFormat.BackgroundColor = Color.FromName(ugrow.Cells("COLOR").Value)
                        TextObj = RepDoc.ReportDefinition.ReportObjects("Text3")
                        TextObj.Text = Format(ugrow.Cells("PRICE").Value, "$###.00")

                        'BoxObj = RepDoc.ReportDefinition.ReportObjects("Box4")
                        'BoxObj.FillColor = BoxObj.FillColor.FromName(ugrow.Cells("COLOR").Value)  'BoxObj.FillColor.FromArgb(System.Drawing.Color.Blue.ToArgb)

                        'BoxObj.Border.BorderColor = Drawing.Color.FromName("Red")
                        'BoxObj.FillColor = New System.drawing.Color 'BoxObj.FillColor.FromName("Red")  'BoxObj.FillColor.FromArgb(System.Drawing.Color.Blue.ToArgb)
                        'FillCol = BoxObj.FillColor.FromArgb(System.Drawing.Color.Blue.A, System.Drawing.Color.Blue.R, System.Drawing.Color.Blue.G, System.Drawing.Color.Blue.B)
                    Case "SLabelsChowchilla1x4"

                        RepDoc = New SLabelsColor1x4

                        Section = RepDoc.ReportDefinition.Sections("DetailSection1")
                        Section.SectionFormat.BackgroundColor = Color.FromName(ugrow.Cells("COLOR").Value)
                        'TextObj = RepDoc.ReportDefinition.ReportObjects("Text3")
                        'TextObj.Text = Format(ugrow.Cells("PRICE").Value, "$###.00")

                        TextObjTo = RepDoc.ReportDefinition.ReportObjects("Text1")
                        TextObjTo.Text = "PIA CHOWCHILLA"

                        TextObj = RepDoc.ReportDefinition.ReportObjects("Text5")
                        TextObj.Text = "TO:"

                    Case "SLabelsPia1x4"

                        RepDoc = New SLabelsColor1x4

                        Section = RepDoc.ReportDefinition.Sections("DetailSection1")
                        Section.SectionFormat.BackgroundColor = Color.FromName(ugrow.Cells("COLOR").Value)
                        'TextObj = RepDoc.ReportDefinition.ReportObjects("Text3")
                        'TextObj.Text = Format(ugrow.Cells("PRICE").Value, "$###.00")

                        TextObjTo = RepDoc.ReportDefinition.ReportObjects("Text1")
                        'TextObjTo.Text = "PIA VACAVILLE"
                        TextObjTo.Text = ugrow.Cells("ParcelType").Text

                        TextObj = RepDoc.ReportDefinition.ReportObjects("Text5")
                        TextObj.Text = "TO:"

                    Case Else
                        MsgBox("Invalid Report name.")
                        Exit Sub
                End Select
                Exit For
            End If
        Next
        If RepDoc Is Nothing Then Exit Sub


        ''      SelectSQL = "SELECT DailyEntry.AccountID, CUSTOMER.STREET, CUSTOMER.CITYNAME, CUSTOMER.STATE, CUSTOMER.ZIPCODE, CUSTOMER.PHONE1, DailyEntry.TranDate, DailyEntry.Weight, DailyEntry.WeightLimit, DailyEntry.OWCharge, DailyEntry.ManifestName, DailyEntry.Charge, DailyEntry.AccountName, DailyEntry.ManifestID " & _
        ''" FROM   WeightModule.dbo.DailyEntry DailyEntry INNER JOIN WeightModule.dbo.CUSTOMER CUSTOMER ON DailyEntry.AccountID=CUSTOMER.ID " & _
        ''" ORDER BY DailyEntry.AccountID, DailyEntry.ManifestID"
        ''      PopulateDataset2(dtAdapter, dtSet2, SelectSQL)

        'If AcctSelection2.Checked Then
        '    If AcctID.Text = "" Then
        '        MessageBox.Show("Account is not selected.")
        '        Exit Sub
        '    End If
        '    'Report1.SelectionFormula = "{DailyEntry.AccountID} = " & AcctID.Text & " and {DailyEntry.TranDate} >= datevalue('" & DTPicker1.Value & "') and {DailyEntry.TranDate} <= datevalue('" & DTPicker2.Value & "')"
        '    RepDoc.RecordSelectionFormula = "{DailyEntry.AccountID} = " & AcctID.Text & " and {DailyEntry.TranDate} >= datevalue('" & DTPicker1.Value & "') and {DailyEntry.TranDate} <= datevalue('" & DTPicker2.Value & "') and {DailyEntry.Charge} > 0 "
        'ElseIf AcctSelection.Checked Then
        '    'Report1.SelectionFormula = "{DailyEntry.TranDate} >= datevalue('" & DTPicker1.Value & "') and {DailyEntry.TranDate} <= datevalue('" & DTPicker2.Value & "')"
        '    RepDoc.RecordSelectionFormula = "{DailyEntry.TranDate} >= datevalue('" & DTPicker1.Value & "') and {DailyEntry.TranDate} <= datevalue('" & DTPicker2.Value & "') and {DailyEntry.Charge} > 0"
        'Else
        '    RepDoc.RecordSelectionFormula = "{Customer.AcctGroupID} = " & GroupID.Text & " and {DailyEntry.TranDate} >= datevalue('" & DTPicker1.Value & "') and {DailyEntry.TranDate} <= datevalue('" & DTPicker2.Value & "') and {DailyEntry.Charge} > 0 "
        'End If

        'RepDoc.SetDataSource(dtSet2) ' ("Provider = SQLOLEDB; DATA SOURCE = 192.80.90.200; INITIAL CATALOG = WEIGHTMODULE; USER ID = sa; PASSWORD = 4183771")
        If (Val(StartCounter) + Val(utQty.Text) - 1) > 9999 Then
            Range1 = "(" & StartCounter & " to 9999)"
            Range2 = " OR {Counter.Counter}  in " & "(1 to " & CStr(Val(utQty.Text) - (9999 - Val(StartCounter) + 1) - 1) & ")"
            LastNum = (Val(utQty.Text) - (9999 - Val(StartCounter) + 1) - 1)
        Else
            Range1 = "(" & StartCounter & " to " & CStr(Val(StartCounter) + Val(utQty.Text) - 1) & ")"
            Range2 = ""
            LastNum = (Val(StartCounter) + Val(utQty.Text) - 1)
        End If
        RepDoc.RecordSelectionFormula = "{LOCATION.CustomerID} = '" & CustID & "' and {LOCATION.LocationID} = '" & LocID & "' AND {Counter.Counter}  in " & Range1 & Range2

        If Not TextObjTo Is Nothing Then
            If TextObjTo.Text.Substring(0, 3).CompareTo("PIA") = 0 Then
                SaveLastLabel(CustID, LocID, LastNum, utQty.Text.Trim, AddressID, Range1, Range2, ugrow.Cells("ParcelType").Text, ugrow.Cells("RowID").Value)
            Else
                SaveLastLabel(CustID, LocID, LastNum, utQty.Text.Trim, AddressID, Range1, Range2, ugrow.Cells("COLOR").Value & " Label", ugrow.Cells("RowID").Value)
            End If
        Else
            SaveLastLabel(CustID, LocID, LastNum, utQty.Text.Trim, AddressID, Range1, Range2, ugrow.Cells("COLOR").Value & " Label", ugrow.Cells("RowID").Value)
        End If

        'paramDiscreteValue1.Value = Format(DTPicker1.Value, "MM/dd/yyyy")
        'paramDiscreteValue2.Value = Format(DTPicker2.Value, "MM/dd/yyyy")

        'paramField1.ParameterFieldName = "fromdate"
        'paramField1.CurrentValues.Add(paramDiscreteValue1)

        'paramField2.ParameterFieldName = "ToDate"
        'paramField2.CurrentValues.Add(paramDiscreteValue2)

        'paramFields1.Add(paramField1)
        'paramFields1.Add(paramField2)

        'Karina commented and changed
        'SetConnectionInfo("LOCATION", IPAddr, "TOP", "tpctrk", "top", RepDoc)
        'SetConnectionInfo("COUNTER", IPAddr, "TOP", "tpctrk", "top", RepDoc)
        'SetConnectionInfo("LOCATION", IPAddr, TRCDBName, TRCDBUser, TRCDBPass, RepDoc)
        'SetConnectionInfo("COUNTER", IPAddr, TRCDBName, TRCDBUser, TRCDBPass, RepDoc)
        SetConnectionInfo("LOCATION", IPAddr, TRCDBName, TRCDBUser, TRCDBPass, RepDoc)
        SetConnectionInfo("COUNTER", IPAddr, TRCDBName, TRCDBUser, TRCDBPass, RepDoc)

        ''Report1.Visible = False
        'Report1.Enabled = True
        'Report1.ReportSource = Nothing
        'Report1.ParameterFieldInfo = Nothing
        'Report1.ShowRefreshButton = False

        'Report1.DisplayGroupTree = False
        ''Report1.ParameterFieldInfo = paramFields1
        'Me.Cursor = System.Windows.Forms.Cursors.WaitCursor()

        'Report1.ReportSource = RepDoc '"AcctWGTReport.RPT"
        ''Report1.PrintReport()

        'Me.Cursor = System.Windows.Forms.Cursors.Default


        RepDoc.PrintToPrinter(1, False, 1, 9999)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        btnDisplay.Enabled = False
        Me.Close()

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

    Private Sub SaveLastLabel(ByVal CustomerID As String, ByVal LocationID As String, ByVal LastNum As String, ByVal LastQty As String, ByVal AddrID As Int32, ByVal Range1 As String, ByVal Range2 As String, ByVal ParcelType As String, ByVal LabelRowID As Int32)
        Dim SqlIns, SqlDel As String
        SqlDel = "Delete " & TRCTblPath & "PrePrintedLabels where CustomerID = '" & CustomerID & "' AND Locationid = '" & LocationID & "'"
        SqlIns = "Insert into " & TRCTblPath & "PrePrintedLabels(CustomerID, LocationID, LastPrintedNum, LastQty, AddressID) values('" & CustomerID & "', '" & LocationID & "', '" & LastNum & "', " & LastQty & ", " & AddrID & ")"
        If ExecuteQuery(SqlDel) Then
            If ExecuteQuery(SqlIns) Then
                'MsgBox("Labels Updated Successfully.")
            Else
                MsgBox("Labels Insertion Error.")
            End If
        Else
            MsgBox("Labels Deletion Error.")
        End If
        Range1 = Range1.Replace("(", " ")
        Range1 = Range1.Replace(")", " ")
        Range1 = Range1.Replace("TO", "AND")
        Range1 = Range1.Replace("to", "AND")

        Range2 = Range2.Replace("(", " ")
        Range2 = Range2.Replace(")", " ")
        Range2 = Range2.Replace("TO", "AND")
        Range2 = Range2.Replace("to", "AND")
        Range2 = Range2.Replace("IN", "BETWEEN")
        Range2 = Range2.Replace("in", "BETWEEN")

        SqlDel = "" ' "Delete " & TRCTblPath & "CourierLabels where remarks = 'PREPRINTED' and FromAddID = " & AddressID
        'SqlIns = "Insert into " & TRCTblPath & "CourierLabels(TrackingNum, EmployeeID, FromCustID, FromCustName, FromAddID, FromLocID, FromLocName, FromAdd1, FromAdd2, FromCity, FromState, FromZip, FromContact, FromPhone, FromEmail, Remarks, ParcelType, LabelRowID) " & _
        '         " Select 'TPCS'+'" & CStr(AddressID).PadLeft(7, "0") & "'+SUBSTRING(CONVERT(varchar, Counter.Counter / 10000.), 3, 4) AS TrackingNum, '1', l.CustomerID, c.name, l.AddressID, l.LocationID, l.name, l.Address1, l.Address2, l.City, l.State, l.Zip, l.Contact, l.Phone, l.email, 'PREPRINTED', '" & ParcelType & "', " & LabelRowID & " from " & TRCTblPath & "Location l, " & TRCTblPath & "Customer c, " & TRCTblPath & "Counter where l.customerid = c.customerid and l.addressid = " & AddressID & " and counter.counter between " & Range1 & Range2
        'Karina changed
        SqlIns = "Insert into " & TRCTblPath & "CourierLabels(TrackingNum, EmployeeID, FromCustID, FromCustName, FromAddID, FromLocID, FromLocName, FromAdd1, FromAdd2, FromCity, FromState, FromZip, FromContact, FromPhone, FromEmail, Remarks, ParcelType, LabelRowID) " & _
         " Select 'TPCS'+'" & CStr(AddressID).PadLeft(7, "0") & "'+SUBSTRING(CONVERT(varchar, Counter / 10000.), 3, 4) AS TrackingNum, '1', l.CustomerID, c.name, l.AddressID, l.LocationID, l.name, l.Address1, l.Address2, l.City, l.State, l.Zip, l.Contact, l.Phone, l.email, 'PREPRINTED', '" & ParcelType & "', " & LabelRowID & " from " & TRCTblPath & "Location l, " & TRCTblPath & "Customer c, " & TRCTblPath & "Counter where l.customerid = c.customerid and l.addressid = " & AddressID & " and counter between " & Range1 & Range2

        'If ExecuteQuery(SqlDel) Then
        '    If ExecuteQuery(SqlIns) Then
        '        'MsgBox("Labels Inserted Successfully.")
        '    Else
        '        MsgBox("Labels Insertion Error.")
        '    End If
        'Else
        '    MsgBox("Labels Deletion Error.")
        'End If
        ' A customer may order more while they have some labels unused so deleting is wrong.

        If ExecuteQuery(SqlIns) Then
            'MsgBox("Labels Inserted Successfully.")
        Else
            MsgBox("Labels Insertion Error.")
        End If


    End Sub

    Private Sub btnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTest.Click

        Dim Range1, Range2 As String
        Dim LastNum As Int16

        If (Val(StartCounter) + Val(utQty.Text) - 1) > 9999 Then
            Range1 = "(" & StartCounter & " to 9999)"
            Range2 = " OR {Counter.Counter}  in " & "(1 to " & CStr(Val(utQty.Text) - (9999 - Val(StartCounter) + 1) - 1) & ")"
            LastNum = (Val(utQty.Text) - (9999 - Val(StartCounter) + 1) - 1)
        Else
            Range1 = "(" & StartCounter & " to " & CStr(Val(StartCounter) + Val(utQty.Text) - 1) & ")"
            Range2 = ""
            LastNum = (Val(StartCounter) + Val(utQty.Text) - 1)
        End If
        ''SaveLastLabel(CustID, LocID, LastNum, utQty.Text.Trim, AddressID, Range1, Range2, ugrow.Cells("COLOR").Value & " Label", ugrow.Cells("RowID").Value)
        SaveLastLabel("10000", "1", LastNum, utQty.Text.Trim, AddressID, Range1, Range2, "RED Label", 1)

    End Sub
End Class
