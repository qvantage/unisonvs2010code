Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors
Imports CrystalDecisions.CrystalReports.ViewerObjectModel
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class TimeCardComplianceForm
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
        'TimeCardComplianceForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(792, 573)
        Me.Controls.Add(Me.cvReport1)
        Me.Name = "TimeCardComplianceForm"
        Me.Text = "TimeCardComplianceForm"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private _strDbConnection As String = Nothing
    Private _strSqlCommand As String = Nothing
    Private _oRpt As TimeCardComplianceReport = Nothing

    Public Property SqlCommand() As String
        Get
            SqlCommand = _strSqlCommand
        End Get
        Set(ByVal Value As String)
            _strSqlCommand = Value
        End Set
    End Property

    Protected ReadOnly Property Report() As TimeCardComplianceReport
        Get
            If IsNothing(_oRpt) Then
                _oRpt = New TimeCardComplianceReport
            End If
            Report = _oRpt
        End Get
    End Property



    Private Sub TimeCardComplianceForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strConn, strConnBak As String

        strConn = strConnection2.Replace("@DB", CFGDBName)
        strConn = strConn.Replace("@USER", CFGDBUser)
        strConn = strConn.Replace("@PASS", CFGDBPass)

        strConnBak = strConnection
        strConnection = strConn
        sqlConn.ConnectionString = strConn

        cvReport1.Enabled = False

        Dim connLocal As New SqlConnection(strConnection)
        Dim daLocal As New SqlDataAdapter
        Dim dsData As New TimeCardComplianceDS

        daLocal.SelectCommand = New SqlCommand

        With daLocal.SelectCommand
            .Connection = connLocal
            .CommandType = CommandType.Text
            .CommandText = SqlCommand
        End With

        Try

            connLocal.Open()

            With daLocal
                .AcceptChangesDuringFill = True
                .MissingSchemaAction = MissingSchemaAction.AddWithKey
                .Fill(dsData, "TimeCardCompliance")
                Report.SetDataSource(dsData)
                Report.SummaryInfo.ReportTitle = "Time Card Compliance Report"
            End With

        Catch ex As Exception

            MsgBox("Error:  " & ex.Message, MsgBoxStyle.Critical, "")

        End Try

        With cvReport1

            .Enabled = True
            .ReportSource = Nothing
            .ParameterFieldInfo = Nothing
            .ShowRefreshButton = False
            .DisplayGroupTree = False

            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
            .ReportSource = Report
            Me.Cursor = System.Windows.Forms.Cursors.Default

        End With

        connLocal.Close()
        strConnection = strConnBak

    End Sub

End Class
