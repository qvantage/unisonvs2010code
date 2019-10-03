Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors
Imports CrystalDecisions.CrystalReports.ViewerObjectModel
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class WeightInputsTable
    Inherits System.Windows.Forms.Form
    Dim RepDoc As ReportDocument

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
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents CrystalReportViewer1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    Friend WithEvents udpFrom As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents udpTo As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnDisplay As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.udpTo = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.udpFrom = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.CrystalReportViewer1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnDisplay = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.udpTo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udpFrom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.udpTo)
        Me.GroupBox1.Controls.Add(Me.udpFrom)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(792, 48)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(376, 16)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 21)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "To Date:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(144, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 21)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "From Date:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'udpTo
        '
        Me.udpTo.Location = New System.Drawing.Point(425, 16)
        Me.udpTo.Name = "udpTo"
        Me.udpTo.TabIndex = 2
        '
        'udpFrom
        '
        Me.udpFrom.Location = New System.Drawing.Point(209, 16)
        Me.udpFrom.Name = "udpFrom"
        Me.udpFrom.TabIndex = 1
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CrystalReportViewer1)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox3.Location = New System.Drawing.Point(0, 48)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(792, 478)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        '
        'CrystalReportViewer1
        '
        Me.CrystalReportViewer1.ActiveViewIndex = -1
        Me.CrystalReportViewer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.CrystalReportViewer1.Location = New System.Drawing.Point(3, 16)
        Me.CrystalReportViewer1.Name = "CrystalReportViewer1"
        Me.CrystalReportViewer1.ReportSource = Nothing
        Me.CrystalReportViewer1.Size = New System.Drawing.Size(786, 459)
        Me.CrystalReportViewer1.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnExit)
        Me.GroupBox2.Controls.Add(Me.btnDisplay)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox2.Location = New System.Drawing.Point(0, 526)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(792, 40)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(688, 16)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.TabIndex = 1
        Me.btnExit.Text = "E&xit"
        '
        'btnDisplay
        '
        Me.btnDisplay.Location = New System.Drawing.Point(600, 16)
        Me.btnDisplay.Name = "btnDisplay"
        Me.btnDisplay.TabIndex = 0
        Me.btnDisplay.Text = "D&isplay"
        '
        'WeightInputsTable
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(792, 566)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "WeightInputsTable"
        Me.Text = "WeightInputsTable"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.udpTo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udpFrom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub WeightInputsTable_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        AddHandler Me.Activated, AddressOf Form_Activated
        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = WeightVars.WEIGHTTblPath & Me.Tag
            End If
        End If

        Me.KeyPreview = True

        AddHandler Me.KeyUp, AddressOf Form_KeyUp

    End Sub

    Private Sub UltraButton1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim DataAdapter As New SqlDataAdapter
        Dim dsWeightTotals As New WeightTotalsDS
        Dim strSQL, Cond As String
        Dim i As Int16

        If Not RepDoc Is Nothing Then
            RepDoc.Dispose()
            RepDoc = Nothing
        End If

        RepDoc = New WeightTotals_CR9_All_WPGs_UNISON

        Cond = " where [TranDate] between '" & udpFrom.Text & "' and '" & udpTo.Text & "'"
        strSQL = "Select * from " & WeightVars.WEIGHTTblPath & "WPGTotals " & Cond

        Try

            PopulateDataset2(DataAdapter, dsWeightTotals, strSQL)
            RepDoc.SetDataSource(dsWeightTotals.Tables(0))

        Catch ex As System.Data.SqlClient.SqlException
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "")
            Exit Sub
            'Catch ex As System.Data.ConstraintException
            '    MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "")
        End Try

        CrystalReportViewer1.Enabled = True
        CrystalReportViewer1.ReportSource = Nothing
        CrystalReportViewer1.ParameterFieldInfo = Nothing
        CrystalReportViewer1.ShowRefreshButton = True
        CrystalReportViewer1.DisplayGroupTree = False


        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor()

        CrystalReportViewer1.ReportSource = RepDoc

        Me.Cursor = System.Windows.Forms.Cursors.Default

    End Sub

    Private Sub UltraButton2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.Close()
    End Sub

    Private Sub btnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplay.Click
        Dim DataAdapter As New SqlDataAdapter
        Dim dsWeightTotals As New WeightTotalsDS
        Dim strSQL, Cond As String
        Dim i As Int16

        If Not RepDoc Is Nothing Then
            RepDoc.Dispose()
            RepDoc = Nothing
        End If

        RepDoc = New WeightTotals_CR9_All_WPGs_UNISON

        Cond = " where [TranDate] between '" & udpFrom.Text & "' and '" & udpTo.Text & "'"
        strSQL = "Select * from " & WeightVars.WEIGHTTblPath & "WPGTotals " & Cond

        Try

            PopulateDataset2(DataAdapter, dsWeightTotals, strSQL)
            RepDoc.SetDataSource(dsWeightTotals.Tables(0))

        Catch ex As System.Data.SqlClient.SqlException
            MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "")
            Exit Sub
            'Catch ex As System.Data.ConstraintException
            '    MsgBox("Error: " & ex.Message, MsgBoxStyle.Critical, "")
        End Try

        CrystalReportViewer1.Enabled = True
        CrystalReportViewer1.ReportSource = Nothing
        CrystalReportViewer1.ParameterFieldInfo = Nothing
        CrystalReportViewer1.ShowRefreshButton = True
        CrystalReportViewer1.DisplayGroupTree = False


        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor()

        CrystalReportViewer1.ReportSource = RepDoc

        Me.Cursor = System.Windows.Forms.Cursors.Default

    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()

    End Sub
End Class
