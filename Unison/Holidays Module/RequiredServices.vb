Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors

Public Class RequiredServices
    Inherits System.Windows.Forms.Form
    Dim SelectQuery As String = "SELECT convert(bit,ISNULL(hrte.HCharge / hrte.HCharge, 0)) AS [Select Svc.], @HDate AS [Hol. Date], a.AccountID, a.ID AS SID " & _
                                " , ISNULL(hrte.HCharge, (SELECT h.Charge From " & HOLIDAYSTblPath & "Holidays h WHERE h.hdate = @HDate)) AS [Hol. Charge], a.CompName AS Location, a.Street, a.CityName as City, a.State, a.ZipCode" & _
                                " FROM " & HOLIDAYSTblPath & "HolidayRoutes hrte, " & ROUTESTblPath & "AccountServices a WHERE a.ID *= hrte.ServiceID AND " & _
                                " a.AccountID *= hrte.AccountID AND hrte.HDate = @HDate AND a.AccountID = @AcctID" & _
                                " AND a.StartDate <= @HDate and ( a.enddate >= @HDate or a.EndDate is NULL) " & _
                                " ORDER BY a.ID"

    Dim MeText As String
    Dim dtSet, dsBuffer As New DataSet()
    Dim cmdTrans As SqlCommand
    Dim HidCols() As String = {"Hol. Date", "AccountID"}

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
    Friend WithEvents btnDisplay As System.Windows.Forms.Button
    Friend WithEvents cboHDate As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents AcctID As System.Windows.Forms.TextBox
    Friend WithEvents Account As System.Windows.Forms.TextBox
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.AcctID = New System.Windows.Forms.TextBox
        Me.Account = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnDisplay = New System.Windows.Forms.Button
        Me.cboHDate = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.AcctID)
        Me.GroupBox1.Controls.Add(Me.Account)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.btnDisplay)
        Me.GroupBox1.Controls.Add(Me.cboHDate)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(760, 56)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'AcctID
        '
        Me.AcctID.Location = New System.Drawing.Point(576, 17)
        Me.AcctID.Name = "AcctID"
        Me.AcctID.Size = New System.Drawing.Size(21, 20)
        Me.AcctID.TabIndex = 2
        Me.AcctID.Text = ""
        Me.AcctID.Visible = False
        '
        'Account
        '
        Me.Account.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Account.Location = New System.Drawing.Point(320, 17)
        Me.Account.Name = "Account"
        Me.Account.Size = New System.Drawing.Size(248, 20)
        Me.Account.TabIndex = 1
        Me.Account.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(248, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 71
        Me.Label1.Text = "Account:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnDisplay
        '
        Me.btnDisplay.Location = New System.Drawing.Point(641, 16)
        Me.btnDisplay.Name = "btnDisplay"
        Me.btnDisplay.Size = New System.Drawing.Size(88, 21)
        Me.btnDisplay.TabIndex = 3
        Me.btnDisplay.Text = "D&isplay"
        '
        'cboHDate
        '
        Me.cboHDate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboHDate.Location = New System.Drawing.Point(88, 18)
        Me.cboHDate.Name = "cboHDate"
        Me.cboHDate.Size = New System.Drawing.Size(144, 21)
        Me.cboHDate.TabIndex = 0
        Me.cboHDate.Tag = ".HDate...Holidays.ID.Convert(Varchar,HDate,101)..HDate"
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(16, 20)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(64, 16)
        Me.Label12.TabIndex = 65
        Me.Label12.Text = "Holiday :"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnExit)
        Me.GroupBox2.Controls.Add(Me.btnSave)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox2.Location = New System.Drawing.Point(0, 349)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(760, 40)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnExit.Location = New System.Drawing.Point(682, 16)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 21)
        Me.btnExit.TabIndex = 1
        Me.btnExit.Text = "E&xit"
        '
        'btnSave
        '
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnSave.Location = New System.Drawing.Point(3, 16)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 21)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "&Save"
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGrid1.Location = New System.Drawing.Point(0, 56)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(760, 293)
        Me.UltraGrid1.TabIndex = 1
        Me.UltraGrid1.Text = "Account Services"
        '
        'RequiredServices
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(760, 389)
        Me.Controls.Add(Me.UltraGrid1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "RequiredServices"
        Me.Text = "Account Requirements & Charges"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub RequiredServices_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        AddHandler Me.Activated, AddressOf Form_Activated
        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = HOLIDAYSTblPath & Me.Tag
            End If
        End If

        Me.CenterToScreen()

        Me.KeyPreview = True
        MeText = Me.Text

        ' Set each control's length based on DB size
        'SetupCtrlsLength(Me)

        AddHandler Me.KeyUp, AddressOf Form_KeyUp

        'Karina's changes - specification of the pass to the table
        FillCombo(cboHDate, "", " Where year(hdate) in (" & Date.Today.Year & ", " & Date.Today.Year + 1 & ")", "", HOLIDAYSTblPath)

    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub RequiredServices_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        dtSet.Dispose()
        dtSet = Nothing
    End Sub

    Private Sub btnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDisplay.Click

        LoadData()
    End Sub

    Private Sub cboHDate_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cboHDate.SelectedIndexChanged
        UltraGrid1.DataSource = Nothing
        AcctID.Text = ""
        Account.Text = ""
    End Sub

    Private Sub LoadData()

        Dim dtAdapter As SqlDataAdapter
        Dim i As Integer
        Dim TempQuery As String
        Dim ugcol As Infragistics.Win.UltraWinGrid.UltraGridColumn

        If AcctID.Text = "" Then
            'Message modified by Michael Pastor
            MsgBox("Account ID remains unspecified. Please enter a valid account ID.", MsgBoxStyle.Exclamation, "Missing Data Input")
            '- MessageBox.Show("Please enter correct Account name.")
            Exit Sub
        End If
        If Not UltraGrid1.DataSource Is Nothing Then
            'UGSaveLayout(Me, UltraGrid1, 1)
        End If

        TempQuery = SelectQuery.Replace("@HDate", "'" & cboHDate.Text & "'")
        TempQuery = TempQuery.Replace("@AcctID", AcctID.Text)

        PopulateDataset2(dtAdapter, dtSet, PrepSelectQuery(TempQuery, ""))

        btnSave.Text = "&Save"
        FillUltraGrid2(UltraGrid1, dtSet, 1, HidCols, dsBuffer)
        FillUltraGrid(UltraGrid1, dsBuffer, 3, HidCols)
        'UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, False, False)
        'UGLoadLayout(Me, UltraGrid1, 1)
        'UltraGrid1.DisplayLayout.GroupByBox.Hidden = False
        'UltraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        UltraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True
        UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit

        For Each ugcol In UltraGrid1.DisplayLayout.Bands(0).Columns
            If ugcol.ToString <> "Select Svc." And ugcol.ToString <> "Hol. Charge" Then
                ugcol.TabStop = False
            End If
        Next

    End Sub

    Private Sub Account_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Account.KeyUp
        TypeAhead(sender, e, HOLIDAYSTblPath & "Notices", "AccountName", " HDate = '" & cboHDate.Text & "'")
        'sender.modified = True
    End Sub

    Private Sub Account_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles Account.Leave
        Dim row As DataRow
        If sender.text.trim = "" Then
            AcctID.Text = ""
            sender.text = ""
        ElseIf SearchOnLeave(sender, AcctID, HOLIDAYSTblPath & "Notices", "AccountID", "AccountName", "", "Accounts Responded", " HDate = '" & cboHDate.Text & "' ") Then ' Ali: Used to be this condition : "NeedService = 1"
            If ReturnRowByID(AcctID.Text, row, AppTblPath & "Customer") Then
                Account.Text = row("Name")
                'row.Table.DataSet = Nothing
                row = Nothing
                'LoadData()
            End If
        End If
    End Sub

    Private Sub UltraGrid1_BeforeEnterEditMode(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles UltraGrid1.BeforeEnterEditMode

        If UltraGrid1.ActiveCell.Column.ToString = "Select Svc." Or UltraGrid1.ActiveCell.Column.ToString = "Hol. Charge" Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If

    End Sub


    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim DeleteQuery As String = "Delete From " & HOLIDAYSTblPath & "HolidayRoutes Where HDate = '" & cboHDate.Text & "' and AccountID = " & AcctID.Text
        Dim i As Integer
        Dim ugcol As Infragistics.Win.UltraWinGrid.UltraGridColumn
        Dim ugrow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim InsertQuery As String = "Insert into " & HOLIDAYSTblPath & "HolidayRoutes(Hdate, AccountID, ServiceID, HCharge) Values('" & cboHDate.Text & "', " & AcctID.Text & ", @SID, @HChg)"
        Dim TempInsert As String

        If UltraGrid1.Rows Is Nothing Then
            'Message modified by Michael Pastor
            '- REQUIRES ADDITIONAL MODIFICATION.
            MsgBox("No records displayed!..", MsgBoxStyle.Exclamation, "Data Unavailable")
            '- MessageBox.Show("No records displayed!")
            Exit Sub
        End If
        If UltraGrid1.Rows.Count <= 0 Then
            'Message modified by Michael Pastor
            '- REQUIRES ADDITIONAL MODIFICATION.
            MsgBox("No records displayed!..", MsgBoxStyle.Exclamation, "Data Unavailable")
            '- MessageBox.Show("No records displayed!")
            Exit Sub
        End If


        ExecuteQuery(DeleteQuery)
        For Each ugrow In UltraGrid1.Rows
            If ugrow.Cells("Select Svc.").Text = True Then
                TempInsert = InsertQuery.Replace("@SID", ugrow.Cells("SID").Text)
                TempInsert = TempInsert.Replace("@HChg", ugrow.Cells("Hol. Charge").Text)
                ExecuteQuery(TempInsert)
            End If
        Next
        LoadData()

    End Sub

    Private Sub UltraGrid1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraGrid1.Leave
        If Not UltraGrid1.ActiveCell Is Nothing Then
            UltraGrid1.ActiveCell.Selected = True
        End If
        If Not UltraGrid1.ActiveRow Is Nothing Then
            UltraGrid1.ActiveRow.Update()
        End If
    End Sub

End Class
