Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors
Imports CrystalDecisions.CrystalReports.ViewerObjectModel
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class TimeCardEventsAnalysisForm
    Inherits System.Windows.Forms.Form

    Private _dsAnalysis As TimeCardEventsAnalysisDS = Nothing
    Private _oRpt As TimeCardEventsAnalysisReport = Nothing

    Public Property DataSource() As TimeCardEventsAnalysisDS
        Get
            DataSource = _dsAnalysis
        End Get
        Set(ByVal Value As TimeCardEventsAnalysisDS)
            _dsAnalysis = Value
        End Set
    End Property

    Protected ReadOnly Property Report() As TimeCardEventsAnalysisReport
        Get
            If IsNothing(_oRpt) Then
                _oRpt = New TimeCardEventsAnalysisReport
            End If
            Report = _oRpt
        End Get
    End Property

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
    Friend WithEvents cvReport1 As CrystalDecisions.Windows.Forms.CrystalReportViewer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.cvReport1 = New CrystalDecisions.Windows.Forms.CrystalReportViewer
        Me.SuspendLayout()
        '
        'cvReport1
        '
        Me.cvReport1.ActiveViewIndex = -1
        Me.cvReport1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cvReport1.Location = New System.Drawing.Point(0, 0)
        Me.cvReport1.Name = "cvReport1"
        Me.cvReport1.ReportSource = Nothing
        Me.cvReport1.Size = New System.Drawing.Size(792, 573)
        Me.cvReport1.TabIndex = 0
        '
        'TimeCardEventsAnalysisForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(792, 573)
        Me.Controls.Add(Me.cvReport1)
        Me.Name = "TimeCardEventsAnalysisForm"
        Me.Text = "TimeCardEventsAnalysisForm"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub TimeCardEventsAnalysisForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor

        cvReport1.Enabled = False

        Report.SetDataSource(DataSource)
        Report.SummaryInfo.ReportTitle = "Time Card Period Analysis"

        With cvReport1

            .Enabled = True
            .ReportSource = Nothing
            .ParameterFieldInfo = Nothing
            .ShowRefreshButton = False
            .DisplayGroupTree = False

            .ReportSource = Report

        End With

        Me.Cursor = System.Windows.Forms.Cursors.Default

    End Sub

End Class
