Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors
Imports CrystalDecisions.CrystalReports.ViewerObjectModel
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Enum BadgeFormat
    TPC = 0
    CFC = 1
    TTI = 2
    TPCR = 3
    CFCR = 4
    TTIR = 5
    NONE = 999
End Enum


Public Class EmployeeBadgePreview
    Inherits System.Windows.Forms.Form

    Private _strDbConnection As String = Nothing
    Private _strSqlCommand As String = Nothing

    Private _eBadgeFormat As BadgeFormat = BadgeFormat.TPC
    Private _oRpt0 As EmployeeBadgeReport = Nothing
    Private _oRpt1 As EmployeeBadgeReportCFC = Nothing
    Private _oRpt2 As EmployeeBadgeReportTTI = Nothing
    Private _oRpt3 As EmployeeBadgeReportTPCr = Nothing
    Private _oRpt4 As EmployeeBadgeReportCFCr = Nothing
    Private _oRpt5 As EmployeeBadgeReportTTIr = Nothing

    Public Property SqlCommand() As String
        Get
            SqlCommand = _strSqlCommand
        End Get
        Set(ByVal Value As String)
            _strSqlCommand = Value
        End Set
    End Property

    Public Property ReportFormat() As BadgeFormat
        Get
            Return _eBadgeFormat
        End Get
        Set(ByVal Value As BadgeFormat)
            _eBadgeFormat = Value
        End Set
    End Property

    Protected ReadOnly Property Report0() As EmployeeBadgeReport
        Get
            If IsNothing(_oRpt0) Then
                _oRpt0 = New EmployeeBadgeReport
            End If
            Report0 = _oRpt0
        End Get
    End Property

    Protected ReadOnly Property Report1() As EmployeeBadgeReportCFC
        Get
            If IsNothing(_oRpt1) Then
                _oRpt1 = New EmployeeBadgeReportCFC
            End If
            Report1 = _oRpt1
        End Get
    End Property

    Protected ReadOnly Property Report2() As EmployeeBadgeReportTTI
        Get
            If IsNothing(_oRpt2) Then
                _oRpt2 = New EmployeeBadgeReportTTI
            End If
            Report2 = _oRpt2
        End Get
    End Property

    Protected ReadOnly Property Report3() As EmployeeBadgeReportTPCr
        Get
            If IsNothing(_oRpt3) Then
                _oRpt3 = New EmployeeBadgeReportTPCr
            End If
            Report3 = _oRpt3
        End Get
    End Property

    Protected ReadOnly Property Report4() As EmployeeBadgeReportCFCr
        Get
            If IsNothing(_oRpt4) Then
                _oRpt4 = New EmployeeBadgeReportCFCr
            End If
            Report4 = _oRpt4
        End Get
    End Property

    Protected ReadOnly Property Report5() As EmployeeBadgeReportTTIr
        Get
            If IsNothing(_oRpt5) Then
                _oRpt5 = New EmployeeBadgeReportTTIr
            End If
            Report5 = _oRpt5
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
        Me.cvReport1.DisplayGroupTree = False
        Me.cvReport1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.cvReport1.Location = New System.Drawing.Point(0, 0)
        Me.cvReport1.Name = "cvReport1"
        Me.cvReport1.ReportSource = Nothing
        Me.cvReport1.Size = New System.Drawing.Size(659, 436)
        Me.cvReport1.TabIndex = 0
        '
        'EmployeeBadgePreview
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(659, 436)
        Me.Controls.Add(Me.cvReport1)
        Me.Name = "EmployeeBadgePreview"
        Me.Text = "Print Employees' Badge Preview Form"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub EmployeeBadgePreview_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
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

            With daLocal
                .AcceptChangesDuringFill = True
                .MissingSchemaAction = MissingSchemaAction.AddWithKey
                .Fill(dsData, "EmployeeBadge")
                Select Case _eBadgeFormat
                    Case BadgeFormat.TPC
                        Report0.SetDataSource(dsData)
                        Report0.SummaryInfo.ReportTitle = "Employee Badge"
                    Case BadgeFormat.CFC
                        Report1.SetDataSource(dsData)
                        Report1.SummaryInfo.ReportTitle = "Employee Badge"
                    Case BadgeFormat.TTI
                        Report2.SetDataSource(dsData)
                        Report2.SummaryInfo.ReportTitle = "Employee Badge"
                    Case BadgeFormat.TPCR
                        Report3.SetDataSource(dsData)
                        Report3.SummaryInfo.ReportTitle = "Representative Badge"
                    Case BadgeFormat.CFCR
                        Report4.SetDataSource(dsData)
                        Report4.SummaryInfo.ReportTitle = "Representative Badge"
                    Case BadgeFormat.TTIR
                        Report5.SetDataSource(dsData)
                        Report5.SummaryInfo.ReportTitle = "Representative Badge"
                End Select
            End With

            With cvReport1

                .Enabled = True
                .ReportSource = Nothing
                .ParameterFieldInfo = Nothing
                .ShowRefreshButton = False
                .DisplayGroupTree = False

                Me.Cursor = System.Windows.Forms.Cursors.WaitCursor
                Select Case _eBadgeFormat
                    Case BadgeFormat.TPC
                        .ReportSource = Report0
                    Case BadgeFormat.CFC
                        .ReportSource = Report1
                    Case BadgeFormat.TTI
                        .ReportSource = Report2
                    Case BadgeFormat.TPCR
                        .ReportSource = Report3
                    Case BadgeFormat.CFCR
                        .ReportSource = Report4
                    Case BadgeFormat.TTIR
                        .ReportSource = Report5
                End Select
                Me.Cursor = System.Windows.Forms.Cursors.Default

            End With

            strConnection = strConnBak

        Catch ex As Exception

            MsgBox("Error:  " & ex.Message, MsgBoxStyle.Critical, "")
        End Try
    End Sub
End Class
