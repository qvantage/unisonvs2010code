Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors
Imports CrystalDecisions.CrystalReports.ViewerObjectModel
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class TimeCardVerificationForm
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
        'TimeCardVerificationForm
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(792, 573)
        Me.Controls.Add(Me.cvReport1)
        Me.Name = "TimeCardVerificationForm"
        Me.Text = "TimeCardVerificationForm"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private _strDbConnection As String = Nothing
    Private _strSqlCommand As String = Nothing
    Private _oRpt As TimeCardVerificationReport = Nothing

    Public Property SqlCommand() As String
        Get
            SqlCommand = _strSqlCommand
        End Get
        Set(ByVal Value As String)
            _strSqlCommand = Value
        End Set
    End Property

    Protected ReadOnly Property TimeCardVerificationReport() As TimeCardVerificationReport
        Get
            If IsNothing(_oRpt) Then
                _oRpt = New TimeCardVerificationReport
            End If
            TimeCardVerificationReport = _oRpt
        End Get
    End Property

    Private Sub TimeCardVerificationForm_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Dim connstr, connstrBAK As String

        connstr = strConnection2.Replace("@DB", CFGDBName)
        connstr = connstr.Replace("@USER", CFGDBUser)
        connstr = connstr.Replace("@PASS", CFGDBPass)

        connstrBAK = strConnection
        strConnection = connstr
        sqlConn.ConnectionString = connstr

        cvReport1.Enabled = False

        Dim localConn As New SqlConnection(strConnection)
        Dim DataAdapter As New SqlDataAdapter
        Dim dsRapid As New TimeCardInputActivityDS

        DataAdapter.SelectCommand = New SqlCommand

        With DataAdapter.SelectCommand
            .Connection = localConn
            .CommandType = CommandType.Text
            .CommandText = SqlCommand
        End With

        Try

            localConn.Open()

            With DataAdapter
                .AcceptChangesDuringFill = True
                .MissingSchemaAction = MissingSchemaAction.AddWithKey
                .Fill(dsRapid, "TimeCardInputActivity")
                TimeCardVerificationReport.SetDataSource(dsRapid)
                TimeCardVerificationReport.GroupFooterSection1.SectionFormat.EnableNewPageAfter = True
                TimeCardVerificationReport.SummaryInfo.ReportTitle = "Time Card Verification"
            End With

        Catch ex As Exception

            MsgBox("Error:  " & ex.Message, MsgBoxStyle.Critical, "")

        End Try

        '' These two lines were apparently a test of some sort, but I'm not sure so instead of undoing the checkout I'll check the file in with
        '' these lines commented out.
        ''TimeCardVerificationReport.ExportToDisk(ExportFormatType.PortableDocFormat, "C :\\LookAtMe.pdf")
        ''TimeCardVerificationReport.Close()

        With cvReport1

            .Enabled = True
            .ReportSource = Nothing
            .ParameterFieldInfo = Nothing
            .ShowRefreshButton = Nothing
            .DisplayGroupTree = False

            Me.Cursor = System.Windows.Forms.Cursors.WaitCursor()
            .ReportSource = TimeCardVerificationReport
            Me.Cursor = System.Windows.Forms.Cursors.Default()
        End With

        localConn.Close()
        strConnection = connstrBAK

    End Sub
End Class
