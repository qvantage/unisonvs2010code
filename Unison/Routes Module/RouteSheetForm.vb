Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors
Imports CrystalDecisions.CrystalReports.ViewerObjectModel
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class RouteSheetForm
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
        Me.cvReport1.Size = New System.Drawing.Size(784, 539)
        Me.cvReport1.TabIndex = 0
        '
        'RouteSheetForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(784, 539)
        Me.Controls.Add(Me.cvReport1)
        Me.Name = "RouteSheetForm"
        Me.Text = "RouteSheetForm"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private _strDbConnection As String = Nothing
    Private _strSqlCommand As String = Nothing
    Private _oRpt As RouteSheetReport = Nothing
    'Private _oRpt As TestReport = Nothing

    Public Property SqlCommand() As String
        Get
            SqlCommand = _strSqlCommand
        End Get
        Set(ByVal Value As String)
            _strSqlCommand = Value
        End Set
    End Property

    Protected ReadOnly Property Report() As RouteSheetReport
        'Protected ReadOnly Property Report() As TestReport
        Get
            If IsNothing(_oRpt) Then
                _oRpt = New RouteSheetReport
                '_oRpt = New TestReport
            End If
            Report = _oRpt
        End Get
    End Property

    Private Sub RouteSheetForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim strConn, strConnBak As String

        Try
            strConn = strConnection2.Replace("@DB", AppDBName)
            strConn = strConn.Replace("@USER", AppDBUser)
            strConn = strConn.Replace("@PASS", AppDBPass)

            strConnBak = strConnection
            strConnection = strConn
            sqlConn.ConnectionString = strConn

            cvReport1.Enabled = False

            Dim connLocal As New SqlConnection(strConnection)
            Dim daLocal As New SqlDataAdapter
            Dim dsData As New RouteSheetDS

            daLocal.SelectCommand = New SqlCommand

            'Dim cnProcedure As New SqlConnection(strConnection)

            'Dim cmd As New SqlCommand(ROUTESTblPath & "RouteSheet", cnProcedure)
            'cmd.CommandType = CommandType.StoredProcedure

            With daLocal.SelectCommand
                .Connection = connLocal
                .CommandType = CommandType.Text
                .CommandText = SqlCommand
            End With


            connLocal.Open()

            'Dim daGetRecs As New SqlDataAdapter(cmd)
            'Dim dsRoutes As New RouteSheetDS
            'daGetRecs.Fill(dsRoutes, "RouteSheet")

            With daLocal
                .AcceptChangesDuringFill = True
                .MissingSchemaAction = MissingSchemaAction.AddWithKey
                .Fill(dsData, "RouteSheets")
                Report.SetDataSource(dsData)
                Report.SummaryInfo.ReportTitle = "Route Sheet"
            End With

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

            'connLocal.Close()
            strConnection = strConnBak

        Catch ex As Exception

            MsgBox("Error:  " & ex.Message, MsgBoxStyle.Critical, "")

        End Try


    End Sub
End Class
