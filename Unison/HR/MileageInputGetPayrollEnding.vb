Imports System.Windows.Forms
Imports System.Data.SqlClient

Public Class MileageInputGetPayrollEnding
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
    Friend WithEvents ubtnOK As Infragistics.Win.Misc.UltraButton
    Friend WithEvents ulblScreen As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ErrorProvider1 As System.Windows.Forms.ErrorProvider
    Friend WithEvents uopsInputScreen As Infragistics.Win.UltraWinEditors.UltraOptionSet
    Friend WithEvents ubtnCancel As Infragistics.Win.Misc.UltraButton
    Friend WithEvents ulblSelectPayroll As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents ulblSelectDivision As Infragistics.Win.Misc.UltraLabel
    Friend WithEvents udtPayrollEnding As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents ucboDivision As Infragistics.Win.UltraWinGrid.UltraCombo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Me.ubtnOK = New Infragistics.Win.Misc.UltraButton
        Me.ulblScreen = New Infragistics.Win.Misc.UltraLabel
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider
        Me.uopsInputScreen = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.ubtnCancel = New Infragistics.Win.Misc.UltraButton
        Me.ulblSelectPayroll = New Infragistics.Win.Misc.UltraLabel
        Me.ulblSelectDivision = New Infragistics.Win.Misc.UltraLabel
        Me.udtPayrollEnding = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.ucboDivision = New Infragistics.Win.UltraWinGrid.UltraCombo
        CType(Me.uopsInputScreen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtPayrollEnding, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucboDivision, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ubtnOK
        '
        Me.ubtnOK.Location = New System.Drawing.Point(123, 123)
        Me.ubtnOK.Name = "ubtnOK"
        Me.ubtnOK.TabIndex = 12
        Me.ubtnOK.Text = "&OK"
        '
        'ulblScreen
        '
        Me.ulblScreen.Location = New System.Drawing.Point(19, 67)
        Me.ulblScreen.Name = "ulblScreen"
        Me.ulblScreen.Size = New System.Drawing.Size(96, 23)
        Me.ulblScreen.TabIndex = 8
        Me.ulblScreen.Text = "Preferred Screen:"
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'uopsInputScreen
        '
        Me.uopsInputScreen.BorderStyle = Infragistics.Win.UIElementBorderStyle.Inset
        Me.uopsInputScreen.ItemAppearance = Appearance1
        ValueListItem1.DataValue = "DE"
        ValueListItem1.DisplayText = "Daily Input Screen"
        Me.uopsInputScreen.Items.Add(ValueListItem1)
        Me.uopsInputScreen.ItemSpacingVertical = 8
        Me.uopsInputScreen.Location = New System.Drawing.Point(123, 67)
        Me.uopsInputScreen.Name = "uopsInputScreen"
        Me.uopsInputScreen.Size = New System.Drawing.Size(152, 26)
        Me.uopsInputScreen.TabIndex = 11
        '
        'ubtnCancel
        '
        Me.ubtnCancel.Location = New System.Drawing.Point(203, 123)
        Me.ubtnCancel.Name = "ubtnCancel"
        Me.ubtnCancel.TabIndex = 13
        Me.ubtnCancel.Text = "E&xit"
        '
        'ulblSelectPayroll
        '
        Me.ulblSelectPayroll.Location = New System.Drawing.Point(3, 35)
        Me.ulblSelectPayroll.Name = "ulblSelectPayroll"
        Me.ulblSelectPayroll.Size = New System.Drawing.Size(112, 23)
        Me.ulblSelectPayroll.TabIndex = 7
        Me.ulblSelectPayroll.Text = "Payroll Ending Date:"
        '
        'ulblSelectDivision
        '
        Me.ulblSelectDivision.Location = New System.Drawing.Point(67, 3)
        Me.ulblSelectDivision.Name = "ulblSelectDivision"
        Me.ulblSelectDivision.Size = New System.Drawing.Size(48, 23)
        Me.ulblSelectDivision.TabIndex = 6
        Me.ulblSelectDivision.Text = "Division:"
        '
        'udtPayrollEnding
        '
        Me.udtPayrollEnding.DateTime = New Date(2006, 4, 6, 0, 0, 0, 0)
        Me.udtPayrollEnding.Location = New System.Drawing.Point(123, 35)
        Me.udtPayrollEnding.Name = "udtPayrollEnding"
        Me.udtPayrollEnding.Size = New System.Drawing.Size(88, 21)
        Me.udtPayrollEnding.TabIndex = 10
        Me.udtPayrollEnding.Value = New Date(2006, 4, 6, 0, 0, 0, 0)
        '
        'ucboDivision
        '
        Me.ucboDivision.DisplayMember = ""
        Me.ucboDivision.Location = New System.Drawing.Point(123, 3)
        Me.ucboDivision.Name = "ucboDivision"
        Me.ucboDivision.Size = New System.Drawing.Size(88, 21)
        Me.ucboDivision.TabIndex = 9
        Me.ucboDivision.Tag = ".Division...Divisions.Division.Division"
        Me.ucboDivision.ValueMember = ""
        '
        'MileageInputGetPayrollEnding
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(286, 148)
        Me.Controls.Add(Me.ulblScreen)
        Me.Controls.Add(Me.uopsInputScreen)
        Me.Controls.Add(Me.ubtnCancel)
        Me.Controls.Add(Me.ulblSelectPayroll)
        Me.Controls.Add(Me.ulblSelectDivision)
        Me.Controls.Add(Me.udtPayrollEnding)
        Me.Controls.Add(Me.ucboDivision)
        Me.Controls.Add(Me.ubtnOK)
        Me.Name = "MileageInputGetPayrollEnding"
        Me.Tag = ".Divisions"
        Me.Text = "Select Division & Payroll Ending Date"
        CType(Me.uopsInputScreen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtPayrollEnding, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucboDivision, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region
#Region "Private Members"

    Private _clsWorkDate As clsWorkDate
    Private _iValueChanged As Integer = 0
    Private _dt As Date
    Private _freq As String
    Private _wed As String
    Dim DivisionChanged As Boolean = False
    Dim MeText As String = ""
#End Region

#Region "Public Members"

    Public dtPayrollEndingDate As Date
    Public strDivision As String
    Public strInputScreen As String = "DE"

#End Region
#Region "Common Events"

    Private Sub frmLogin_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler Me.Activated, AddressOf Form_Activated
        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = HRTblPath & Me.Tag
            End If
        End If

        Me.CenterToScreen()

        Me.KeyPreview = True
        MeText = Me.Text

        AddHandler Me.KeyUp, AddressOf Form_KeyUp
        AddHandler uopsInputScreen.KeyUp, AddressOf Form_KeyUp

        udtPayrollEnding.Nullable = True

        FillUCombo(ucboDivision, "CFC", , , HRTblPath)
        udtPayrollEnding.Value = _clsWorkDate.PayrollEndDate(Date.Now)

        uopsInputScreen.CheckedIndex = 0

    End Sub

    Private Sub ubtnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubtnCancel.Click
        Me.Close()
    End Sub

    Private Sub ubtnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ubtnOK.Click
        If (ErrorProvider1.GetError(udtPayrollEnding).ToString <> "") Then
            udtPayrollEnding.SelectAll()
        Else
            Me.Visible = False
            Dim x As New MileageInput
            x.ScreenCode = uopsInputScreen.Items(uopsInputScreen.CheckedIndex).DataValue
            x.strDivision = ucboDivision.Value
            x.datePayrollEndDate = udtPayrollEnding.Value
            x.InitWorkDate(_dt, _freq, _wed)
            x.ShowDialog()
            Me.Close()
        End If

    End Sub

#End Region
#Region "Helper Functions"

    Private Sub SetError(ByRef ctl As Control, ByVal e As System.ComponentModel.CancelEventArgs, ByVal str As String)
        Beep()
        e.Cancel = True
        Me.ErrorProvider1.SetError(ctl, str)
    End Sub

    Private Sub ClearError(ByRef ctl As Control)
        Me.ErrorProvider1.SetError(ctl, "")
    End Sub

    'Private Sub InitDivisionList()

    '    'Prepare to use the returned data values
    '    Dim strSQL As String
    '    Dim dtaCbo As New SqlDataAdapter
    '    Dim dtSet As DataSet
    '    Dim dtView As New DataView

    '    strSQL = "select division from " & HRTblPath & "divisions order by division"

    '    PopulateDataset2(dtaCbo, dtSet, strSQL)

    '    dtView.Table = dtSet.Tables(0)
    '    ucboDivision.DataSource = dtView
    '    ucboDivision.DisplayMember = dtView.Table.Columns("division").ToString
    '    ucboDivision.ValueMember = dtView.Table.Columns("division").ToString
    '    ucboDivision.Value = "CFC"

    'End Sub

    Private Sub InitWorkDate()

        If Not IsNothing(_clsWorkDate) Then _clsWorkDate = Nothing

        'Prepare to use the returned data values
        Dim strSQL As String
        Dim dtaCbo As New SqlDataAdapter
        Dim dtSet As DataSet
        Dim dtView As New DataView
        Dim dtRow As DataRow

        strSQL = "SELECT InitialPayPeriodEnding, PayPeriodFreq, WeekEndingDay FROM " & HRTblPath & "divisions WHERE division = '" & strDivision & "'"

        PopulateDataset2(dtaCbo, dtSet, strSQL)

        dtView.Table = dtSet.Tables(0)
        dtRow = dtView.Table.Rows(0)
        _dt = CDate(dtRow("InitialPayPeriodEnding"))
        _freq = dtRow("PayPeriodFreq")
        _wed = dtRow("WeekEndingDay")
        '_clsWorkDate = New clsWorkDate(CDate(dtRow("InitialPayPeriodEnding")), dtRow("PayPeriodFreq"), dtRow("WeekEndingDay"))
        _clsWorkDate = New clsWorkDate(_dt, _freq, _wed)


        'clean up, no longer needed
        dtRow = Nothing

        dtView.Dispose()
        dtView = Nothing
        dtSet.Dispose()
        dtSet = Nothing
        dtaCbo.Dispose()
        dtaCbo = Nothing

    End Sub

#End Region
    Private Sub ucboDivision_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucboDivision.TextChanged
        DivisionChanged = True
    End Sub
    Private Sub udtPayrollEnding_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles udtPayrollEnding.ValueChanged
        If udtPayrollEnding.Text.IndexOf(udtPayrollEnding.PromptChar) >= 0 Then
            Exit Sub
        End If
        If ucboDivision.Text <> "" And Not _clsWorkDate Is Nothing Then
            Dim dt As Date
            dt = _clsWorkDate.PayrollEndDate(udtPayrollEnding.Value)
            If dt <> udtPayrollEnding.Value Then
                udtPayrollEnding.Value = dt
            End If
        End If
        'End If
    End Sub
    Private Sub udtPayrollEnding_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles udtPayrollEnding.Leave
        udtPayrollEnding.Value = _clsWorkDate.PayrollEndDate(udtPayrollEnding.Value)
    End Sub
    Private Sub ucboDivision_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ucboDivision.ValueChanged
        'If DivisionChanged = False Then Exit Sub
        If ucboDivision.Text = "" Then
            strDivision = ""
            udtPayrollEnding.Value = Nothing
            Exit Sub
        End If
        strDivision = ucboDivision.Value
        InitWorkDate()
        'If _iValueChanged >= 2 Then _iValueChanged = 1
        udtPayrollEnding.Value = _clsWorkDate.PayrollEndDate(Date.Now)

    End Sub

End Class
