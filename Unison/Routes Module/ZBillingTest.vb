Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common
Imports System.Collections
Imports System.Text

Public Class frmBillingZTest
    Inherits System.Windows.Forms.Form

    Public Class DGV 'data grid view
        Private _lRowId As Integer
        Private _StartBilling As Date
        Private _EndBilling As Date
        Private _BillingDuration As Integer
        Private _Status As String
        Private _SIDSD As Date
        Private _SIDED As Date
        Private _SIDLBD As Date
        Private _SBP As Date
        Private _EBP As Date

        'Private _row As String
        Public Sub New(ByVal col_StartBilling As Date, ByVal col_EndBilling As Date, ByVal _BillingDuration As Integer, ByVal _Status As String, ByVal _SIDSD As Date, ByVal _SIDED As Date, ByVal _SBP As Date, ByVal _EBP As Date)
            _lRowId = RowId
            _StartBilling = col_StartBilling
            _EndBilling = col_EndBilling
            _BillingDuration = col_BillingDuration
            _Status = col_Status
            _SIDSD = col_SIDSD
            _SIDED = col_SIDED
            _SBP = col_SBP
            _EBP = col_EBP
        End Sub

        Public Property RowId() As Integer
            Get
                Return _lRowId
            End Get
            Set(ByVal Value As Integer)
                _lRowId = Value
            End Set
        End Property

        Public Sub New(ByVal p_iRowID As Long)
            RowId = p_iRowID
        End Sub
        'Public Sub New(ByVal row As String)
        '    _row = row
        'End Sub

        Public Property col_StartBilling() As Date
            Get
                Return _StartBilling
            End Get
            Set(ByVal Value As Date)
                _StartBilling = Value
            End Set
        End Property

        Public Property col_EndBilling() As Date
            Get
                Return _EndBilling
            End Get
            Set(ByVal Value As Date)
                _EndBilling = Value
            End Set
        End Property

        Public Property col_BillingDuration() As Integer
            Get
                Return _BillingDuration
            End Get
            Set(ByVal Value As Integer)
                _BillingDuration = Value
            End Set
        End Property

        Public Property col_Status() As String
            Get
                Return _Status
            End Get
            Set(ByVal Value As String)
                _Status = Value
            End Set
        End Property

        Public Property col_SIDSD() As Date
            Get
                Return _SIDSD
            End Get
            Set(ByVal Value As Date)
                _SIDSD = Value
            End Set
        End Property

        Public Property col_SIDED() As Date
            Get
                Return _SIDED
            End Get
            Set(ByVal Value As Date)
                _SIDED = Value
            End Set
        End Property

        Public Property col_SIDLBD() As Date
            Get
                Return _SIDLBD
            End Get
            Set(ByVal Value As Date)
                _SIDLBD = Value
            End Set
        End Property

        Public Property col_SBP() As Date
            Get
                Return _SBP
            End Get
            Set(ByVal Value As Date)
                _SBP = Value
            End Set
        End Property

        Public Property col_EBP() As Date
            Get
                Return _EBP
            End Get
            Set(ByVal Value As Date)
                _EBP = Value
            End Set
        End Property
    End Class



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
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents udSIDLBD As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents btnTest As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents udSIDSD As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents udSIDED As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents udEBP As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents udSBP As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnFirstRun As System.Windows.Forms.Button
    Friend WithEvents btnDB As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label5 = New System.Windows.Forms.Label
        Me.udEBP = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.udSIDLBD = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.btnTest = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.udSBP = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.udSIDSD = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label4 = New System.Windows.Forms.Label
        Me.udSIDED = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.btnFirstRun = New System.Windows.Forms.Button
        Me.btnDB = New System.Windows.Forms.Button
        CType(Me.udEBP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udSIDLBD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udSBP, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udSIDSD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udSIDED, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(257, 42)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(44, 21)
        Me.Label5.TabIndex = 172
        Me.Label5.Text = "EBP:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'udEBP
        '
        Me.udEBP.DateTime = New Date(2010, 7, 14, 0, 0, 0, 0)
        Me.udEBP.Location = New System.Drawing.Point(307, 39)
        Me.udEBP.Name = "udEBP"
        Me.udEBP.Size = New System.Drawing.Size(105, 24)
        Me.udEBP.TabIndex = 4
        Me.udEBP.Value = New Date(2010, 7, 14, 0, 0, 0, 0)
        '
        'udSIDLBD
        '
        Me.udSIDLBD.DateTime = New Date(2010, 7, 14, 0, 0, 0, 0)
        Me.udSIDLBD.Location = New System.Drawing.Point(87, 70)
        Me.udSIDLBD.Name = "udSIDLBD"
        Me.udSIDLBD.Size = New System.Drawing.Size(105, 24)
        Me.udSIDLBD.TabIndex = 2
        Me.udSIDLBD.Value = New Date(2010, 7, 14, 0, 0, 0, 0)
        '
        'btnTest
        '
        Me.btnTest.Location = New System.Drawing.Point(916, 128)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(90, 27)
        Me.btnTest.TabIndex = 5
        Me.btnTest.Text = "Run It"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(257, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(44, 21)
        Me.Label1.TabIndex = 167
        Me.Label1.Text = "SBP:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'udSBP
        '
        Me.udSBP.DateTime = New Date(2010, 7, 14, 0, 0, 0, 0)
        Me.udSBP.Location = New System.Drawing.Point(306, 8)
        Me.udSBP.Name = "udSBP"
        Me.udSBP.Size = New System.Drawing.Size(106, 24)
        Me.udSBP.TabIndex = 3
        Me.udSBP.Value = New Date(2010, 7, 14, 0, 0, 0, 0)
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(15, 72)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 21)
        Me.Label2.TabIndex = 173
        Me.Label2.Text = "SIDLBD:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(15, 9)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(66, 21)
        Me.Label3.TabIndex = 175
        Me.Label3.Text = "SIDSD:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'udSIDSD
        '
        Me.udSIDSD.DateTime = New Date(2010, 7, 14, 0, 0, 0, 0)
        Me.udSIDSD.Location = New System.Drawing.Point(87, 8)
        Me.udSIDSD.Name = "udSIDSD"
        Me.udSIDSD.Size = New System.Drawing.Size(105, 24)
        Me.udSIDSD.TabIndex = 0
        Me.udSIDSD.Value = New Date(2010, 7, 14, 0, 0, 0, 0)
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(15, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(66, 21)
        Me.Label4.TabIndex = 177
        Me.Label4.Text = "SIDED:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'udSIDED
        '
        Me.udSIDED.DateTime = New Date(2010, 7, 14, 0, 0, 0, 0)
        Me.udSIDED.Location = New System.Drawing.Point(87, 39)
        Me.udSIDED.Name = "udSIDED"
        Me.udSIDED.Size = New System.Drawing.Size(105, 24)
        Me.udSIDED.TabIndex = 1
        Me.udSIDED.Value = New Date(2010, 7, 14, 0, 0, 0, 0)
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.UltraGrid1.Location = New System.Drawing.Point(0, 160)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(1011, 232)
        Me.UltraGrid1.TabIndex = 6
        Me.UltraGrid1.TabStop = False
        Me.UltraGrid1.Text = "Billing Details"
        '
        'btnFirstRun
        '
        Me.btnFirstRun.Location = New System.Drawing.Point(916, 7)
        Me.btnFirstRun.Name = "btnFirstRun"
        Me.btnFirstRun.Size = New System.Drawing.Size(90, 27)
        Me.btnFirstRun.TabIndex = 178
        Me.btnFirstRun.Text = "First Run"
        '
        'btnDB
        '
        Me.btnDB.Location = New System.Drawing.Point(787, 7)
        Me.btnDB.Name = "btnDB"
        Me.btnDB.Size = New System.Drawing.Size(118, 27)
        Me.btnDB.TabIndex = 179
        Me.btnDB.Text = "SID Info From DB"
        '
        'frmBillingZTest
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(1011, 392)
        Me.Controls.Add(Me.btnDB)
        Me.Controls.Add(Me.btnFirstRun)
        Me.Controls.Add(Me.UltraGrid1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.udSIDED)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.udSIDSD)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.udEBP)
        Me.Controls.Add(Me.udSIDLBD)
        Me.Controls.Add(Me.btnTest)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.udSBP)
        Me.Name = "frmBillingZTest"
        Me.Text = "ZAK Billing Test"
        CType(Me.udEBP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udSIDLBD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udSBP, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udSIDSD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udSIDED, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTest.Click
        Dim oSIDIn As SID = New SID("1")
        Dim oSIDCollection As New SIDCollection

        'GetServiceIdBillingStatusZ(oSIDIn, udSIDSD.Value, udSIDED.Value, udSIDLBD.Value, udSBP.Value, udEBP.Value)
        oSIDCollection.Add(oSIDIn)

        Dim oSIDOut As SID
        If oSIDCollection.Count = 0 Then
            MessageBox.Show("NO DATA", "NO DATA", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation)
            Exit Sub
        End If
        oSIDOut = oSIDCollection(0)

        Dim billingDetails As DGV
        billingDetails = New DGV("1")
        'Values returned by the GetServiceIdBillingStatusZ() function 
        billingDetails.col_BillingDuration = oSIDOut.Duration
        billingDetails.col_EndBilling = dtEndOfBillingPeriod
        billingDetails.col_StartBilling = dtStartOfBillingPeriod
        billingDetails.col_Status = oSIDOut.Status

        'Values from the form
        billingDetails.col_SIDSD = udSIDSD.Value
        billingDetails.col_SIDED = udSIDED.Value
        billingDetails.col_SIDLBD = udSIDLBD.Value
        billingDetails.col_SBP = udSBP.Value
        billingDetails.col_EBP = udEBP.Value

        Dim Table1 As DataTable
        Table1 = New DataTable("Billing Details")
        Dim Row1 As DataRow
        Try
            Dim RowId As DataColumn = New DataColumn("RowId")
            RowId.DataType = System.Type.GetType("System.String")
            Table1.Columns.Add(RowId)

            Dim StartBilling As DataColumn = New DataColumn("StartBilling")
            StartBilling.DataType = System.Type.GetType("System.String")
            Table1.Columns.Add(StartBilling)

            Dim EndBilling As DataColumn = New DataColumn("EndBilling")
            EndBilling.DataType = System.Type.GetType("System.String")
            Table1.Columns.Add(EndBilling)

            Dim BillingDuration As DataColumn = New DataColumn("BillingDuration")
            BillingDuration.DataType = System.Type.GetType("System.String")
            Table1.Columns.Add(BillingDuration)

            Dim Status As DataColumn = New DataColumn("Status")
            Status.DataType = System.Type.GetType("System.String")
            Table1.Columns.Add(Status)

            Dim SIDSD As DataColumn = New DataColumn("SIDSD")
            SIDSD.DataType = System.Type.GetType("System.String")
            Table1.Columns.Add(SIDSD)

            Dim SIDED As DataColumn = New DataColumn("SIDED")
            SIDED.DataType = System.Type.GetType("System.String")
            Table1.Columns.Add(SIDED)

            Dim SIDLBD As DataColumn = New DataColumn("SIDLBD")
            SIDLBD.DataType = System.Type.GetType("System.String")
            Table1.Columns.Add(SIDLBD)

            Dim SBP As DataColumn = New DataColumn("SBP")
            SBP.DataType = System.Type.GetType("System.String")
            Table1.Columns.Add(SBP)

            Dim EBP As DataColumn = New DataColumn("EBP")
            EBP.DataType = System.Type.GetType("System.String")
            Table1.Columns.Add(EBP)

            Row1 = Table1.NewRow()
            Row1.Item("RowId") = billingDetails.RowId
            If billingDetails.col_StartBilling.ToShortDateString = NullDate Then
                Row1.Item("StartBilling") = "EMPTY"
            Else
                Row1.Item("StartBilling") = billingDetails.col_StartBilling.ToShortDateString
            End If
            If billingDetails.col_EndBilling.ToShortDateString = NullDate Then
                Row1.Item("EndBilling") = "EMPTY"
            Else
                Row1.Item("EndBilling") = billingDetails.col_EndBilling.ToShortDateString
            End If

            Row1.Item("BillingDuration") = billingDetails.col_BillingDuration
            If billingDetails.col_Status = "True" Then
                billingDetails.col_Status = "Billable"
            Else
                billingDetails.col_Status = "Not Billable"
            End If
            Row1.Item("Status") = billingDetails.col_Status

            If billingDetails.col_SIDSD.ToShortDateString = NullDate Then
                Row1.Item("SIDSD") = "EMPTY"
            Else
                Row1.Item("SIDSD") = billingDetails.col_SIDSD.ToShortDateString
            End If
            If billingDetails.col_SIDED.ToShortDateString = NullDate Then
                Row1.Item("SIDED") = "EMPTY"
            Else
                Row1.Item("SIDED") = billingDetails.col_SIDED.ToShortDateString
            End If
            If billingDetails.col_SIDLBD.ToShortDateString = NullDate Then
                Row1.Item("SIDLBD") = "EMPTY"
            Else
                Row1.Item("SIDLBD") = billingDetails.col_SIDLBD.ToShortDateString
            End If
            If billingDetails.col_SBP.ToShortDateString = NullDate Then
                Row1.Item("SBP") = "EMPTY"
            Else
                Row1.Item("SBP") = billingDetails.col_SBP.ToShortDateString
            End If
            If billingDetails.col_EBP.ToShortDateString = NullDate Then
                Row1.Item("EBP") = "EMPTY"
            Else
                Row1.Item("EBP") = billingDetails.col_EBP.ToShortDateString
            End If

            Table1.Rows.Add(Row1)
        Catch ex As Exception

        End Try

        Dim ds As New DataSet
        ds = New DataSet
        ds.Tables.Add(Table1)
        UltraGrid1.SetDataBinding(ds, "Billing Details")
        
        oSIDIn = Nothing
        oSIDCollection = Nothing
       
    End Sub

    Private Sub frmBillingZTest_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.udSIDLBD.DateTime = Date.Today
        Me.udSIDSD.DateTime = Date.Today
        Me.udSIDED.DateTime = Date.Today
        Me.udSBP.DateTime = Date.Today
        Me.udEBP.DateTime = Date.Today
    End Sub

    Private Sub btnFirstRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFirstRun.Click
        Dim oSIDIn As SID = New SID("1")
        Dim oSIDCollection As New SIDCollection

        dtStartOfBillingPeriod = udSBP.Value
        dtEndOfBillingPeriod = udEBP.Value

        oSIDIn.StartDate = udSIDSD.Value
        oSIDIn.EndDate = udSIDED.Value
        oSIDIn.LastBilledDate = udSIDLBD.Value
        oSIDIn.condition = RoutesVars.SIDCondition.Closed
        oSIDIn.Status = False

        SIDIsBillable(oSIDIn, dtStartOfBillingPeriod, dtEndOfBillingPeriod)
        SetSIDCondition(oSIDIn, dtStartOfBillingPeriod, dtEndOfBillingPeriod)
        SetSIDBillingWindow(oSIDIn, dtEndOfBillingPeriod)

        Dim Table2 As DataTable
        Dim oBaseChargeCollection As New BaseChargeCollection
        Dim oBaseChargeIn As BaseCharge ' = New BaseCharge("1")

        If oSIDIn.Status = True Then
            CalculateSIDCharges(oSIDIn, dtEndOfBillingPeriod)
        End If

        Table2 = New DataTable("Billing Deatils with Monthly Charges for First Run")
        Dim Row1 As DataRow
        Try
            Dim RowId As DataColumn = New DataColumn("RowId")
            RowId.DataType = System.Type.GetType("System.String")
            Table2.Columns.Add(RowId)

            Dim NumberOfCharges As DataColumn = New DataColumn("NumberOfCharges")
            NumberOfCharges.DataType = System.Type.GetType("System.String")
            Table2.Columns.Add(NumberOfCharges)

            Dim FirstCharge As DataColumn = New DataColumn("FirstCharge")
            FirstCharge.DataType = System.Type.GetType("System.String")
            Table2.Columns.Add(FirstCharge)

            Dim LastCharge As DataColumn = New DataColumn("LastCharge")
            LastCharge.DataType = System.Type.GetType("System.String")
            Table2.Columns.Add(LastCharge)

            Dim TotalCharge As DataColumn = New DataColumn("TotalCharge")
            TotalCharge.DataType = System.Type.GetType("System.String")
            Table2.Columns.Add(TotalCharge)


            Row1 = Table2.NewRow()
            Row1.Item("RowId") = 1


            If oSIDIn.Status = True Then
                Row1.Item("NumberOfCharges") = oSIDIn.Charges.Count
                Row1.Item("FirstCharge") = oSIDIn.Charges.Item(0).Amount
                Row1.Item("LastCharge") = oSIDIn.Charges.Item(oSIDIn.Charges.Count - 1).Amount

                Dim calcTotalCharge As Decimal = 0
                Dim calcNumberCharges As Integer = Row1.Item("NumberOfCharges") - 1
                While calcNumberCharges >= 0
                    calcTotalCharge = calcTotalCharge + oSIDIn.Charges.Item(calcNumberCharges).Amount
                    calcNumberCharges = calcNumberCharges - 1
                End While

                Row1.Item("TotalCharge") = calcTotalCharge
            Else
                Row1.Item("NumberOfCharges") = 0
                Row1.Item("FirstCharge") = 0
                Row1.Item("LastCharge") = 0
                Row1.Item("TotalCharge") = 0
            End If

            Table2.Rows.Add(Row1)


            'oSIDCollection.Add(oSIDIn)

            'Dim oSIDOut As SID
            'If oSIDCollection.Count = 0 Then
            '    MessageBox.Show("NO DATA!", "NO DATA", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation)
            '    Exit Sub
            'End If

            'oSIDOut = oSIDCollection(0)

            'Dim Table1 As DataTable
            'Table1 = New DataTable("Billing Details For The First Run")
            'Dim Row1 As DataRow
            'Try
            '    Dim RowId As DataColumn = New DataColumn("RowId")
            '    RowId.DataType = System.Type.GetType("System.String")
            '    Table1.Columns.Add(RowId)

            '    Dim Status As DataColumn = New DataColumn("Status")
            '    Status.DataType = System.Type.GetType("System.String")
            '    Table1.Columns.Add(Status)

            '    Dim Condition As DataColumn = New DataColumn("Condition")
            '    Condition.DataType = System.Type.GetType("System.String")
            '    Table1.Columns.Add(Condition)

            '    Dim SIDSD As DataColumn = New DataColumn("SIDSD")
            '    SIDSD.DataType = System.Type.GetType("System.String")
            '    Table1.Columns.Add(SIDSD)

            '    Dim SIDED As DataColumn = New DataColumn("SIDED")
            '    SIDED.DataType = System.Type.GetType("System.String")
            '    Table1.Columns.Add(SIDED)

            '    Dim SIDLBD As DataColumn = New DataColumn("SIDLBD")
            '    SIDLBD.DataType = System.Type.GetType("System.String")
            '    Table1.Columns.Add(SIDLBD)

            '    Dim SBP As DataColumn = New DataColumn("SBP")
            '    SBP.DataType = System.Type.GetType("System.String")
            '    Table1.Columns.Add(SBP)

            '    Dim EBP As DataColumn = New DataColumn("EBP")
            '    EBP.DataType = System.Type.GetType("System.String")
            '    Table1.Columns.Add(EBP)

            '    Row1 = Table1.NewRow()
            '    Row1.Item("RowId") = oSIDOut.RowId

            '    If oSIDOut.Status = "True" Then
            '        Row1.Item("Status") = "Billable"
            '    Else
            '        Row1.Item("Status") = "Not Billable"
            '    End If

            '    'Karina, consider using Select Case statements instead of nested ElseIf statements when possible
            '    Dim sCondition As String
            '    Select Case oSIDOut.condition
            '        Case RoutesVars.SIDCondition.Closed
            '            sCondition = "Closed"
            '        Case RoutesVars.SIDCondition.Existing
            '            sCondition = "Existing"
            '        Case RoutesVars.SIDCondition.FutureStart
            '            sCondition = "FutureStart"
            '        Case RoutesVars.SIDCondition.NewStart
            '            sCondition = "NewStart"
            '        Case RoutesVars.SIDCondition.Restart
            '            sCondition = "Restart"
            '        Case RoutesVars.SIDCondition.Fault
            '            sCondition = "Fault"
            '        Case Else
            '            sCondition = "Undefined"
            '    End Select
            '    Row1.Item("Condition") = sCondition

            '    If oSIDOut.StartDate.ToShortDateString = NullDate Then
            '        Row1.Item("SIDSD") = "EMPTY"
            '    Else
            '        Row1.Item("SIDSD") = oSIDOut.StartDate.ToShortDateString
            '    End If
            '    If oSIDOut.EndDate.ToShortDateString = NullDate Then
            '        Row1.Item("SIDED") = "EMPTY"
            '    Else
            '        Row1.Item("SIDED") = oSIDOut.EndDate.ToShortDateString
            '    End If
            '    If oSIDOut.LastBilledDate.ToShortDateString = NullDate Then
            '        Row1.Item("SIDLBD") = "EMPTY"
            '    Else
            '        Row1.Item("SIDLBD") = oSIDOut.LastBilledDate.ToShortDateString
            '    End If
            '    If dtStartOfBillingPeriod.ToShortDateString = NullDate Then
            '        Row1.Item("SBP") = "EMPTY"
            '    Else
            '        Row1.Item("SBP") = dtStartOfBillingPeriod.ToShortDateString
            '    End If
            '    If dtStartOfBillingPeriod.ToShortDateString = NullDate Then
            '        Row1.Item("EBP") = "EMPTY"
            '    Else
            '        Row1.Item("EBP") = dtEndOfBillingPeriod.ToShortDateString
            '    End If

            '    Table1.Rows.Add(Row1)
        Catch ex As Exception

        End Try


        Dim dsTable2 As New DataSet
        dsTable2 = New DataSet
        dsTable2.Tables.Add(Table2)
        UltraGrid1.SetDataBinding(dsTable2, "Billing Deatils with Monthly Charges for First Run")

        oSIDIn = Nothing
        oSIDCollection = Nothing
    End Sub

    Private Sub btnDB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDB.Click
        Dim strSQL As String
        Dim dtAdapter As SqlDataAdapter
        Dim dtSet As New DataSet
        Dim i As Integer = 0
        Dim row As DataRow
        Dim oSIDIn As SID '= New SID("1")
        Dim oSIDCollection As New SIDCollection
        Dim dsTable2 As New DataSet

        strSQL = "SELECT * FROM " & ROUTESTblPath & "AccountServices ORDER BY accountid, id "
        PopulateDataset2(dtAdapter, dtSet, strSQL)

        'Dim Row1 As DataRow
        Dim Table2 As DataTable
        'dsTable2 = New DataSet
        'dsTable2.Tables.Add(Table2)

        If dtSet.Tables(0).Rows.Count > 0 Then
            For Each row In dtSet.Tables(0).Rows
                i = i + 1
                oSIDIn = New SID(row("rowid"))
                dtStartOfBillingPeriod = udSBP.Value
                dtEndOfBillingPeriod = udEBP.Value

                If row("StartDate") Is DBNull.Value Then
                    oSIDIn.StartDate = NullDate
                Else
                    oSIDIn.StartDate = row("StartDate")
                End If

                If row("EndDate") Is DBNull.Value Then
                    oSIDIn.EndDate = NullDate
                Else
                    oSIDIn.EndDate = row("EndDate")
                End If

                'If IsDBNull(CDate(row("Last Bill Date").ToString())) Then
                '    oSIDIn.LastBilledDate = NullDate
                'Else
                '    oSIDIn.LastBilledDate = row("Last Bill Date")
                'End If


                If row("Last Bill Date").Value Is DBNull.Value Then
                    row("Last Bill Date") = NullDate
                Else
                    oSIDIn.LastBilledDate = row("Last Bill Date")
                End If

                oSIDIn.condition = RoutesVars.SIDCondition.Closed
                oSIDIn.Status = False

                SIDIsBillable(oSIDIn, dtStartOfBillingPeriod, dtEndOfBillingPeriod)
                SetSIDCondition(oSIDIn, dtStartOfBillingPeriod, dtEndOfBillingPeriod)
                SetSIDBillingWindow(oSIDIn, dtEndOfBillingPeriod)


                Dim oBaseChargeCollection As New BaseChargeCollection
                Dim oBaseChargeIn As BaseCharge ' = New BaseCharge("1")

                If oSIDIn.Status = True Then
                    CalculateSIDCharges(oSIDIn, dtEndOfBillingPeriod)
                End If

                Table2 = New DataTable("Billing Details with Monthly Charges for First Run")
                Dim Row1 As DataRow
                Try
                    Dim RowId As DataColumn = New DataColumn("RowId")
                    RowId.DataType = System.Type.GetType("System.String")
                    Table2.Columns.Add(RowId)

                    Dim NumberOfCharges As DataColumn = New DataColumn("NumberOfCharges")
                    NumberOfCharges.DataType = System.Type.GetType("System.String")
                    Table2.Columns.Add(NumberOfCharges)

                    Dim FirstCharge As DataColumn = New DataColumn("FirstCharge")
                    FirstCharge.DataType = System.Type.GetType("System.String")
                    Table2.Columns.Add(FirstCharge)

                    Dim LastCharge As DataColumn = New DataColumn("LastCharge")
                    LastCharge.DataType = System.Type.GetType("System.String")
                    Table2.Columns.Add(LastCharge)

                    Dim TotalCharge As DataColumn = New DataColumn("TotalCharge")
                    TotalCharge.DataType = System.Type.GetType("System.String")
                    Table2.Columns.Add(TotalCharge)


                    Row1 = Table2.NewRow()
                    Row1.Item("RowId") = i


                    If oSIDIn.Status = True Then
                        Row1.Item("NumberOfCharges") = oSIDIn.Charges.Count
                        Row1.Item("FirstCharge") = oSIDIn.Charges.Item(0).Amount
                        Row1.Item("LastCharge") = oSIDIn.Charges.Item(oSIDIn.Charges.Count - 1).Amount

                        Dim calcTotalCharge As Decimal = 0
                        Dim calcNumberCharges As Integer = Row1.Item("NumberOfCharges") - 1
                        While calcNumberCharges >= 0
                            calcTotalCharge = calcTotalCharge + oSIDIn.Charges.Item(calcNumberCharges).Amount
                            calcNumberCharges = calcNumberCharges - 1
                        End While

                        Row1.Item("TotalCharge") = calcTotalCharge
                    Else
                        Row1.Item("NumberOfCharges") = 0
                        Row1.Item("FirstCharge") = 0
                        Row1.Item("LastCharge") = 0
                        Row1.Item("TotalCharge") = 0
                    End If

                    dsTable2.Tables(0).Rows.Add(Row1)
                    ''Table2.Rows.Add(Row1)
                    'Dim dsTable2 As New DataSet
                    ''dsTable2 = New DataSet
                    ''dsTable2.Tables.Add(Table2)
                Catch ex As Exception

                End Try


                'Dim dsTable2 As New DataSet
                'dsTable2 = New DataSet
                'dsTable2.Tables.Add(Table2)
                'UltraGrid1.SetDataBinding(dsTable2, "Billing Deatils with Monthly Charges for First Run")

                'oSIDIn = Nothing
                'oSIDCollection = Nothing
            Next
        End If

        UltraGrid1.SetDataBinding(dsTable2, "Billing Details with Monthly Charges for First Run")
        oSIDIn = Nothing
        oSIDCollection = Nothing

    End Sub
End Class
