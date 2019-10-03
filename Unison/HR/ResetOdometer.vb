Public Class ResetOdometer
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
    Friend WithEvents lblResetDate As System.Windows.Forms.Label
    Friend WithEvents udtResetDate As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents btnOK As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.lblResetDate = New System.Windows.Forms.Label
        Me.udtResetDate = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnOK = New System.Windows.Forms.Button
        CType(Me.udtResetDate, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lblResetDate
        '
        Me.lblResetDate.Location = New System.Drawing.Point(9, 10)
        Me.lblResetDate.Name = "lblResetDate"
        Me.lblResetDate.Size = New System.Drawing.Size(95, 23)
        Me.lblResetDate.TabIndex = 0
        Me.lblResetDate.Text = "Enter Reset Date"
        Me.lblResetDate.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'udtResetDate
        '
        Appearance1.ForeColor = System.Drawing.Color.Black
        Appearance1.ForeColorDisabled = System.Drawing.Color.Black
        Me.udtResetDate.Appearance = Appearance1
        Me.udtResetDate.DateTime = New Date(2004, 9, 27, 0, 0, 0, 0)
        Me.udtResetDate.Location = New System.Drawing.Point(110, 11)
        Me.udtResetDate.Name = "udtResetDate"
        Me.udtResetDate.Size = New System.Drawing.Size(104, 21)
        Me.udtResetDate.TabIndex = 215
        Me.udtResetDate.Tag = ""
        Me.udtResetDate.Value = New Date(2004, 9, 27, 0, 0, 0, 0)
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(4, 43)
        Me.Label1.Name = "Label1"
        Me.Label1.TabIndex = 216
        Me.Label1.Text = "Reason for Reset"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(111, 47)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(334, 20)
        Me.TextBox1.TabIndex = 217
        Me.TextBox1.Text = "TextBox1"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(366, 87)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.TabIndex = 218
        Me.btnCancel.Text = "Cancel"
        '
        'btnOK
        '
        Me.btnOK.Location = New System.Drawing.Point(283, 87)
        Me.btnOK.Name = "btnOK"
        Me.btnOK.TabIndex = 219
        Me.btnOK.Text = "Ok"
        '
        'ResetOdometer
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(452, 114)
        Me.Controls.Add(Me.btnOK)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.udtResetDate)
        Me.Controls.Add(Me.lblResetDate)
        Me.Name = "ResetOdometer"
        Me.Text = "ResetOdometer"
        CType(Me.udtResetDate, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click

    End Sub
End Class
