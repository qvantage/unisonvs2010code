Imports System.Windows.Forms
Imports System.Drawing

'Public Class MyTextBox
'    Inherits TextBox

'    'Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
'    '    Dim drawBrush As SolidBrush = New SolidBrush(ForeColor)

'    '    MyBase.OnPaint(e)
'    '    e.Graphics.DrawString(Text, Font, drawBrush, 0.0F, 0.0F)
'    '    If Me.ReadOnly Then
'    '        'e.Graphics.DrawString(Text, Font, drawBrush, 0.0F, 0.0F)
'    '    End If
'    'End Sub

'    'Public Sub New()
'    '    MyBase.New()

'    '    'Me.SetStyle(ControlStyles.UserPaint, True)

'    '    'Me.SetStyle(ControlStyles.AllPaintingInWmPain, True)

'    'End Sub

'    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
'        If Me.ReadOnly AndAlso (m.Msg = &HA1 OrElse m.Msg = &H201) Then
'            Return
'        End If
'        MyBase.WndProc(m)
'    End Sub
'End Class


'Public Class MyComboBox
'    Inherits System.Windows.Forms.ComboBox

'    'Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
'    '    Dim drawBrush As SolidBrush = New SolidBrush(ForeColor)

'    '    MyBase.OnPaint(e)
'    '    e.Graphics.DrawString(Text, Font, drawBrush, 0.0F, 0.0F)
'    'End Sub

'    'Public Sub New()
'    '    MyBase.New()

'    '    Me.SetStyle(ControlStyles.UserPaint, True)

'    '    'Me.SetStyle(ControlStyles.AllPaintingInWmPain, True)

'    'End Sub

'    Protected Overrides Sub WndProc(ByRef m As System.Windows.Forms.Message)
'        If Me.TabStop = False AndAlso (m.Msg = &HA1 OrElse m.Msg = &H201) Then
'            Return
'        End If
'        MyBase.WndProc(m)
'    End Sub
'End Class



'Public Class RoundButton : Inherits UserControl
'    Public BackgroundColor As Color = Color.Blue
'    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
'        Dim graphics As Graphics = e.Graphics
'        Dim penWidth As Integer = 4
'        Dim pen As Pen = New Pen(Color.Black, 4)
'        Dim fontHeight As Integer = 10
'        Dim font As Font = New Font("Arial", fontHeight)
'        Dim brush As SolidBrush = New SolidBrush(BackgroundColor)
'        graphics.FillEllipse(brush, 0, 0, Width, Height)
'        Dim textBrush As SolidBrush = New SolidBrush(Color.Black)
'        graphics.DrawEllipse(pen, CInt(penWidth / 2), _
'          CInt(penWidth / 2), Width - penWidth, Height - penWidth)
'        graphics.DrawString(Text, font, textBrush, penWidth, _
'          Height / 2 - fontHeight)
'    End Sub
'End Class

'Public Class CustomClasses

'End Class
