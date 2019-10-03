Public Class RepresentWhichCompany
    Inherits System.Windows.Forms.Form

    Private m_eBadgeFormat As BadgeFormat = BadgeFormat.NONE
    Private m_sMeText As String

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
    Friend WithEvents rbCFC As System.Windows.Forms.RadioButton
    Friend WithEvents rbTTI As System.Windows.Forms.RadioButton
    Friend WithEvents rbTPC As System.Windows.Forms.RadioButton
    Friend WithEvents btnOK As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.rbTPC = New System.Windows.Forms.RadioButton
        Me.rbTTI = New System.Windows.Forms.RadioButton
        Me.rbCFC = New System.Windows.Forms.RadioButton
        Me.btnOK = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.rbTPC)
        Me.GroupBox1.Controls.Add(Me.rbTTI)
        Me.GroupBox1.Controls.Add(Me.rbCFC)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(273, 114)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Select the company this employee will represent..."
        '
        'rbTPC
        '
        Me.rbTPC.Location = New System.Drawing.Point(13, 21)
        Me.rbTPC.Name = "rbTPC"
        Me.rbTPC.Size = New System.Drawing.Size(229, 24)
        Me.rbTPC.TabIndex = 2
        Me.rbTPC.Text = "Top Priority Couriers, Inc."
        '
        'rbTTI
        '
        Me.rbTTI.Location = New System.Drawing.Point(14, 74)
        Me.rbTTI.Name = "rbTTI"
        Me.rbTTI.Size = New System.Drawing.Size(229, 24)
        Me.rbTTI.TabIndex = 1
        Me.rbTTI.Text = "TeleTrac, Inc."
        '
        'rbCFC
        '
        Me.rbCFC.Location = New System.Drawing.Point(15, 48)
        Me.rbCFC.Name = "rbCFC"
        Me.rbCFC.Size = New System.Drawing.Size(229, 24)
        Me.rbCFC.TabIndex = 0
        Me.rbCFC.Text = "CFC Network"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(197, 122)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.TabIndex = 1
        Me.btnOK.Text = "OK"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(117, 122)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.TabIndex = 2
        Me.btnCancel.Text = "Cancel"
        '
        'RepresentWhichCompany
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(278, 155)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "RepresentWhichCompany"
        Me.Tag = "RepresentWhichCompany"
        Me.Text = "Represents Which Company"
        Me.GroupBox1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Public ReadOnly Property FormatSelected() As BadgeFormat
        Get
            Return m_eBadgeFormat
        End Get
    End Property

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

        If rbTPC.Checked = True Then m_eBadgeFormat = BadgeFormat.TPCR
        If rbCFC.Checked = True Then m_eBadgeFormat = BadgeFormat.CFCR
        If rbTTI.Checked = True Then m_eBadgeFormat = BadgeFormat.TTIR

        Me.Close()

    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        m_eBadgeFormat = BadgeFormat.NONE
        Me.Close()
    End Sub

    Private Sub RepresentWhichCompany_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        StandardFormPrep(Me, m_sMeText, HRTblPath)
        Me.CenterToScreen()
        m_eBadgeFormat = BadgeFormat.NONE
    End Sub
End Class
