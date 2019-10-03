Imports System.Data
Imports System.Data.SqlClient
Imports System.Data.Common
Imports System.Collections


Imports System.Text


Public Class frmBillingTest
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ASBID As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents btnTest As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents udSIDLBD As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents udBillingClosingDate As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents btnZTest As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.ASBID = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnTest = New System.Windows.Forms.Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.udSIDLBD = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label5 = New System.Windows.Forms.Label
        Me.udBillingClosingDate = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.btnZTest = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        CType(Me.ASBID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udSIDLBD, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udBillingClosingDate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ASBID
        '
        Me.ASBID.DateTime = New Date(2010, 7, 14, 0, 0, 0, 0)
        Me.ASBID.Location = New System.Drawing.Point(416, 10)
        Me.ASBID.Name = "ASBID"
        Me.ASBID.Size = New System.Drawing.Size(106, 24)
        Me.ASBID.TabIndex = 152
        Me.ASBID.Value = New Date(2010, 7, 14, 0, 0, 0, 0)
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(6, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(403, 32)
        Me.Label1.TabIndex = 154
        Me.Label1.Text = "(" & AppTblPath & "CUSTOMER-->CREATEDATE has a lot of ""NULL"") ASBD:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnTest
        '
        Me.btnTest.Location = New System.Drawing.Point(231, 217)
        Me.btnTest.Name = "btnTest"
        Me.btnTest.Size = New System.Drawing.Size(90, 27)
        Me.btnTest.TabIndex = 156
        Me.btnTest.Text = "Run It"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(4, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(411, 32)
        Me.Label3.TabIndex = 160
        Me.Label3.Text = "(" & ROUTESTblPath & "AccountServices-->Last Bill Date has a lot of ""NULL"") SIDLBD:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'udSIDLBD
        '
        Me.udSIDLBD.DateTime = New Date(2010, 7, 14, 0, 0, 0, 0)
        Me.udSIDLBD.Location = New System.Drawing.Point(416, 54)
        Me.udSIDLBD.Name = "udSIDLBD"
        Me.udSIDLBD.Size = New System.Drawing.Size(105, 24)
        Me.udSIDLBD.TabIndex = 157
        Me.udSIDLBD.Value = New Date(2010, 7, 14, 0, 0, 0, 0)
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(79, 175)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(330, 30)
        Me.Label5.TabIndex = 163
        Me.Label5.Text = "(Either WhenAccountClosed or BillingClosingDate) Billing Closing Date = AEBD:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'udBillingClosingDate
        '
        Me.udBillingClosingDate.DateTime = New Date(2010, 7, 14, 0, 0, 0, 0)
        Me.udBillingClosingDate.Location = New System.Drawing.Point(416, 178)
        Me.udBillingClosingDate.Name = "udBillingClosingDate"
        Me.udBillingClosingDate.Size = New System.Drawing.Size(105, 24)
        Me.udBillingClosingDate.TabIndex = 161
        Me.udBillingClosingDate.Value = New Date(2010, 7, 14, 0, 0, 0, 0)
        '
        'btnZTest
        '
        Me.btnZTest.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnZTest.Location = New System.Drawing.Point(447, 253)
        Me.btnZTest.Name = "btnZTest"
        Me.btnZTest.TabIndex = 164
        Me.btnZTest.Text = "Z Test"
        '
        'Label2
        '
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(241, 254)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(192, 23)
        Me.Label2.TabIndex = 165
        Me.Label2.Text = "AcctID: 5137, SID: 1"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmBillingTest
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(530, 287)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnZTest)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.udBillingClosingDate)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.udSIDLBD)
        Me.Controls.Add(Me.btnTest)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.ASBID)
        Me.Name = "frmBillingTest"
        Me.Text = "Billing Test"
        CType(Me.ASBID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udSIDLBD, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udBillingClosingDate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTest.Click
        '**************************************************************************
        'SF - 5/24/2010 - Button to test billing collection class.
        '**************************************************************************
        Dim strSQL As String
        Dim dtAdapter As SqlDataAdapter
        Dim i As Integer
        Dim intLoop As Long
        Dim dtSet As New DataSet
        Dim intBtn As Long

        Dim oSIDIn As SID
        Dim oSIDCollection As New SIDCollection


        Dim strData As String

        'clsSid = New SIDsInfo

        Dim row As DataRow

        strSQL = "SELECT * FROM " & ROUTESTblPath & "AccountServices ORDER BY accountid, id "

        PopulateDataset2(dtAdapter, dtSet, strSQL)

        'Call clsSid.Init()
        'clsItms = New Items

        If dtSet.Tables(0).Rows.Count > 0 Then
            For Each row In dtSet.Tables(0).Rows
                i = i + 1
                oSIDIn = New SID(row("rowid"))


                'If GetServiceIdBillingStatus(row, oSIDIn, udBilingDate.Value, ASBID.Value, AEBID.Value) = True Then
                'If GetServiceIdBillingStatus(row, oSIDIn, udBillingClosingDate.Value, udSIDLBD.Value, ASBID.Value) = True Then
                '    'MessageBox.Show("RowId #" & row("rowid") & " is active for this billing period")
                '    oSIDCollection.Add(oSIDIn)
                '    'oSIDIn = Nothing
                'Else

                'End If
                
            Next
        End If

        strData = ""
        For Each oSIDOut As SID In oSIDCollection
            strData = ""
            strData = "Acct: " & oSIDOut.AcctId & vbTab
            strData = strData & "SID: " & oSIDOut.SID & vbCrLf
            strData = strData & "Start of Billing: " & dtStartOfBillingPeriod & vbCrLf
            strData = strData & "End of Billing: " & dtEndOfBillingPeriod & vbCrLf
            strData = strData & "Duration: " & oSIDOut.Duration & vbCrLf


            'TESTING For Billing Correctness - Temporary!? - Delete when not needed
            Dim strSQL2 As String = "SELECT * FROM " & AppTblPath & "CUSTOMER where ID = " & oSIDOut.AcctId & ""
            Dim dtAdapter2 As SqlDataAdapter
            Dim dtSet2 As New DataSet
            PopulateDataset2(dtAdapter2, dtSet2, strSQL2)
            Dim row2 As DataRow
            Dim ASBD As String
            Dim AEBD As String
            If dtSet.Tables(0).Rows.Count > 0 Then
                If dtSet2.Tables(0).Rows(0).ItemArray(26) Is DBNull.Value Then
                    ASBD = "DBNull"
                Else
                    ASBD = dtSet2.Tables(0).Rows(0).ItemArray(26)
                End If
            End If
            'If dtSet.Tables(0).Rows.Count > 0 Then
            '    If dtSet2.Tables(0).Rows(0).ItemArray(27) Is DBNull.Value Then
            '        AEBD = "DBNull"
            '    Else
            '        AEBD = dtSet2.Tables(0).Rows(0).ItemArray(27)
            '    End If
            'End If
            strData = strData & vbCrLf & vbCrLf & "SIDSD - Service ID Start Date in DB: " & oSIDOut.StartDate & vbCrLf
            strData = strData & "SIDED - Service ID End Date in DB: " & oSIDOut.EndDate & vbCrLf
            strData = strData & "SIDLBD - Service ID Last Billing Date in DB: " & oSIDOut.LastBilledDate & vbCrLf
            strData = strData & "ASBD - Account Start Billing Date in DB: " & ASBD & vbCrLf
            'strData = strData & "AEBD - Account End Billing Date in DB: " & AEBD & vbCrLf
            strData = strData & vbCrLf & "Status: " & oSIDOut.Status & vbCrLf
            'strData = strData & "Scope: " & oSIDOut.Scope & vbCrLf
            'strData = strData & "Restart: " & oSIDOut.Restart & vbCrLf


            'intBtn = MessageBox.Show(strData, Me.Text, vbOKCancel)
            intBtn = MessageBox.Show(strData, Me.Text, MessageBoxButtons.OK)

            If intBtn = 2 Then
                Exit For
            End If
        Next


        oSIDIn = Nothing
        oSIDCollection = Nothing
        dtAdapter = Nothing
        dtSet = Nothing
    End Sub
    Private Sub btnZTest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnZTest.Click
        Dim strSQL As String
        Dim dtAdapter As SqlDataAdapter
        Dim i As Integer
        Dim intLoop As Long
        Dim dtSet As New DataSet
        Dim intBtn As Long

        Dim oSIDIn As SID
        Dim oSIDCollection As New SIDCollection


        Dim strData As String

        'clsSid = New SIDsInfo

        Dim row As DataRow

        strSQL = "SELECT * FROM " & ROUTESTblPath & "AccountServices WHERE Accountid=5137 and ID=1 ORDER BY accountid, id "

        PopulateDataset2(dtAdapter, dtSet, strSQL)

        'Call clsSid.Init()
        'clsItms = New Items

        If dtSet.Tables(0).Rows.Count > 0 Then
            For Each row In dtSet.Tables(0).Rows
                i = i + 1
                oSIDIn = New SID(row("rowid"))


                'If GetServiceIdBillingStatus(row, oSIDIn, udBilingDate.Value, ASBID.Value, AEBID.Value) = True Then
                'If GetServiceIdBillingStatus(row, oSIDIn, udBillingClosingDate.Value, udSIDLBD.Value, ASBID.Value) = True Then
                '    'MessageBox.Show("RowId #" & row("rowid") & " is active for this billing period")
                '    oSIDCollection.Add(oSIDIn)
                '    'oSIDIn = Nothing
                'Else

                'End If
                
            Next
        End If

        strData = ""
        For Each oSIDOut As SID In oSIDCollection
            strData = ""
            strData = "Acct: " & oSIDOut.AcctId & vbTab
            strData = strData & "SID: " & oSIDOut.SID & vbCrLf
            strData = strData & "Start of Billing: " & dtStartOfBillingPeriod & vbCrLf
            strData = strData & "End of Billing: " & dtEndOfBillingPeriod & vbCrLf
            strData = strData & "Duration: " & oSIDOut.Duration & vbCrLf


            'TESTING For Billing Correctness - Temporary!? - Delete when not needed
            Dim strSQL2 As String = "SELECT * FROM " & AppTblPath & "CUSTOMER where ID = " & oSIDOut.AcctId & ""
            Dim dtAdapter2 As SqlDataAdapter
            Dim dtSet2 As New DataSet
            PopulateDataset2(dtAdapter2, dtSet2, strSQL2)
            Dim row2 As DataRow
            Dim ASBD As String
            Dim AEBD As String
            If dtSet.Tables(0).Rows.Count > 0 Then
                If dtSet2.Tables(0).Rows(0).ItemArray(26) Is DBNull.Value Then
                    ASBD = "DBNull"
                Else
                    ASBD = dtSet2.Tables(0).Rows(0).ItemArray(26)
                End If
            End If
            'If dtSet.Tables(0).Rows.Count > 0 Then
            '    If dtSet2.Tables(0).Rows(0).ItemArray(27) Is DBNull.Value Then
            '        AEBD = "DBNull"
            '    Else
            '        AEBD = dtSet2.Tables(0).Rows(0).ItemArray(27)
            '    End If
            'End If
            strData = strData & vbCrLf & vbCrLf & "SIDSD - Service ID Start Date in DB: " & oSIDOut.StartDate & vbCrLf
            strData = strData & "SIDED - Service ID End Date in DB: " & oSIDOut.EndDate & vbCrLf
            strData = strData & "SIDLBD - Service ID Last Billing Date in DB: " & oSIDOut.LastBilledDate & vbCrLf
            strData = strData & "ASBD - Account Start Billing Date in DB: " & ASBD & vbCrLf
            'strData = strData & "AEBD - Account End Billing Date in DB: " & AEBD & vbCrLf
            strData = strData & vbCrLf & "Status: " & oSIDOut.Status & vbCrLf
            'strData = strData & "Scope: " & oSIDOut.Scope & vbCrLf
            'strData = strData & "Restart: " & oSIDOut.Restart & vbCrLf


            'intBtn = MessageBox.Show(strData, Me.Text, vbOKCancel)
            intBtn = MessageBox.Show(strData, Me.Text, MessageBoxButtons.OK)

            If intBtn = 2 Then
                Exit For
            End If
        Next


        oSIDIn = Nothing
        oSIDCollection = Nothing
        dtAdapter = Nothing
        dtSet = Nothing
    End Sub
    Private Sub frmBillingTest_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.udBilingDate.DateTime = Date.Today
        Me.udSIDLBD.DateTime = Date.Today
        Me.ASBID.DateTime = Date.Today
        'Me.AEBID.DateTime = Date.Today
        Me.udBillingClosingDate.DateTime = Date.Today

    End Sub

   
End Class
