Imports System.Data
Imports System.Data.SqlClient

Public Class ProcessPayroll
    Inherits System.Windows.Forms.Form
    Dim MeText As String

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
    Friend WithEvents UltraDate1 As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnProcess As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.UltraDate1 = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.Label11 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnProcess = New System.Windows.Forms.Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.UltraDate1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.UltraDate1)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(248, 61)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'UltraDate1
        '
        Me.UltraDate1.DateTime = New Date(2004, 9, 27, 0, 0, 0, 0)
        Me.UltraDate1.Location = New System.Drawing.Point(110, 17)
        Me.UltraDate1.Name = "UltraDate1"
        Me.UltraDate1.Size = New System.Drawing.Size(96, 21)
        Me.UltraDate1.TabIndex = 16
        Me.UltraDate1.Tag = ".PayrollDate"
        Me.UltraDate1.Value = New Date(2004, 9, 27, 0, 0, 0, 0)
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(16, 19)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(88, 16)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "Period Ending:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnExit)
        Me.GroupBox3.Controls.Add(Me.btnProcess)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox3.Location = New System.Drawing.Point(0, 61)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(248, 40)
        Me.GroupBox3.TabIndex = 5
        Me.GroupBox3.TabStop = False
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnExit.Location = New System.Drawing.Point(181, 16)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(64, 21)
        Me.btnExit.TabIndex = 1
        Me.btnExit.Text = "E&xit"
        '
        'btnProcess
        '
        Me.btnProcess.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnProcess.Location = New System.Drawing.Point(3, 16)
        Me.btnProcess.Name = "btnProcess"
        Me.btnProcess.Size = New System.Drawing.Size(64, 21)
        Me.btnProcess.TabIndex = 0
        Me.btnProcess.Text = "P&rocess"
        '
        'ProcessPayroll
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(248, 101)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Name = "ProcessPayroll"
        Me.Text = "Process Payroll"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.UltraDate1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub ProcessPayroll_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        AddHandler Me.Activated, AddressOf Form_Activated
        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = HRTblPath & Me.Tag
            End If
        End If
        MeText = Me.Text

        Me.StartPosition = FormStartPosition.CenterScreen

        UltraDate1.Nullable = True
        UltraDate1.Value = DateAdd(DateInterval.Day, 0, Date.Today)
        UltraDate1.FormatString = "MM/dd/yyyy"

    End Sub

    Private Sub btnProcess_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnProcess.Click
        Dim sqlCopyDed As String = "Insert into " & HRTblPath & "EmployeeMiscCharges(PayrollDate, EmployeeID, DeptNo, Type, ChargeID, Description, Amount, Processed) Select @PAYDATE, ed.EmployeeID, '0' as DeptNo, 'D' as Type, ed.DeductionID as ChargeID, d.Deduction as Description, ed.Amount as Amount, 1 as Processed from " & HRTblPath & "EmployeeDeductions ed inner join " & HRTblPath & "Deductions d on ed.DeductionId = d.DeductionID where ed.EmployeeID in (Select ea.EmployeeID from " & HRTblPath & "EmployeeActivity ea where ea.PayrollDate = @PAYDATE) ; "
        Dim sqlProcessPay As String = "Update " & HRTblPath & "EmployeeActivity Set Processed = 1 where PayrollDate = @PAYDATE ; "
        Dim sqlProcessIncome As String = "Update " & HRTblPath & "EmployeeMiscCharges Set Processed = 1 where PayrollDate = @PAYDATE AND Processed = 0 ; "

        Dim sqlProcessTimeCard As String = "Update " & HRTblPath & "EmployeeActivityDetail Set Processed = 1 where PayrollEnding = @PAYDATE ; "
        Dim sqlInsertPayrollEnding As String = "Insert into " & HRTblPath & "ProcessedPayrollEndings(PayrollEnding, Processed, Company) Select TOP 1 @PAYDATE as PayrollEnding, '1' as Processed, Division from " & HRTblPath & "EmployeeActivityDetail ead where ead.payrollending = @PAYDATE  group by ead.division order by division ; "

        Dim AIO As String
        Dim cmd As SqlCommand
        Dim trnSql As SqlTransaction
        Dim HasError As Boolean = True
        Dim x As New MessageDialog

        If GetPassword("procok") = False Then Exit Sub


        AIO = sqlProcessTimeCard & sqlInsertPayrollEnding & sqlCopyDed & sqlProcessPay & sqlProcessIncome
        AIO = AIO.Replace("@PAYDATE", "'" & UltraDate1.Text & "'")

        Try
            x.btnOK.Enabled = False
            x.ulMessage.Text = "Processing ..."
            x.Show()

            sqlConn.Open()
            trnSql = sqlConn.BeginTransaction()
            cmd = New SqlCommand(AIO, sqlConn, trnSql)
            With cmd
                .CommandType = CommandType.Text
                .ExecuteNonQuery()
            End With

            cmd.Transaction.Commit()
            HasError = False
        Catch Err As System.Exception
            MsgBox("Error: " & Err.Message)
            cmd.Transaction.Rollback()
            'Exit Try
        Catch Err As System.NullReferenceException
            MsgBox("Error: " & Err.Message)
            cmd.Transaction.Rollback()
        Catch Err As SqlException
            MsgBox("Error: " & Err.Message)
            cmd.Transaction.Rollback()
        Finally
            If HasError Then
                x.ulMessage.Text = "Process Failed."
                x.btnOK.Enabled = True
                Me.Text = MeText & " -- Payroll Date '" & UltraDate1.Text & "' Process Failed."
            Else
                x.ulMessage.Text = "Process Successful"
                x.btnOK.Enabled = True
                Me.Text = MeText & " -- Payroll Date '" & UltraDate1.Text & "' Processed Successfully."
            End If
            cmd.Connection.Close()
            cmd = Nothing
        End Try



    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
End Class
