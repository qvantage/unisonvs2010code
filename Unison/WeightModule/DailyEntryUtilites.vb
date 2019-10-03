Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors

Public Class DailyEntryUtilites
    Inherits System.Windows.Forms.Form
    Dim strCurrentDate As String
    Dim SQLSelect As String = _
            "Select de.TranDate, de.ManifestID , de.ManifestName as [Acct. WgtPlan], de.OfficeID as [Office ID], de.AccountID as [Account ID], de.AccountName as [Account Name], de.Weight, de.WeightLimit as [Weight Limit], de.OWCharge, de.Charge " & _
            " FROM " & WeightVars.WEIGHTTblPath & "DailyEntry de " ', Manifests mft Where de.ManifestID = mft.ID " ' " Where TranDate = '" & "' ORDER BY AccountName"

    '"SELECT CONVERT(varchar, GETDATE(), 101),"
    Dim SQLInsSelect = " mft.ID AS ManifestID, " & _
                        " mft.OfficeID, mft.AccountID, c.name AS AccountName " & _
                        " ,mft.Name AS Manifest " & _
                        " ,wbd.WeightLimit as [Weight Limit], wbd.OWCharge " & _
                        " , mft.GroupID, isnull(wgtgrp.Name, '') as GroupName, mft.ParentID " & _
                        " FROM " & WeightVars.WEIGHTTblPath & "Manifests mft, " & WeightVars.WEIGHTTblPath & "WeightBreakdown wbd, " & AppTblPath & "Customer c, " & AppTblPath & "ServiceOffices so, " & WeightVars.WEIGHTTblPath & "WeightPlanGroups wgtgrp " & _
                        " WHERE mft.accountid = c.id AND mft.officeid *= so.id AND " & _
                        " mft.weightid *= wbd.id AND c.status = 1" & _
                        " AND mft.GroupID *= wgtgrp.ID " & _
                        " AND (mft.StartDate <= @TranDate or mft.StartDate is NULL) and ( mft.enddate >= @TranDate or mft.EndDate is NULL) " & _
                        " ORDER BY c.name " ', '0.00' as Weight 

    '" AND (mft.StartDate <= getdate() or mft.StartDate is NULL) and ( mft.enddate >= getdate() or mft.EndDate is NULL) " & _
    ' if enddate = getdate but dataentry for day before?
    Dim SQLInsert = "INSERT INTO " & WeightVars.WEIGHTTblPath & "dailyentry (TranDate, ManifestID, OfficeID, AccountID, AccountName, ManifestName, WeightLimit, OWCharge, WeightPlanGroupID, WeightPlanGroup, ParentID)"
    Dim SQLInsertNewMft = " AND mft.id NOT IN (SELECT manifestid FROM " & WeightVars.WEIGHTTblPath & "dailyentry " 'WHERE WeightPlanGroupID = " & GroupID.Text & " AND trandate = '" '12/23/2002')"

    Dim NewTrans As Boolean
    Dim PrevDate As String
    Dim PrevGroupID As Integer

    Dim MeText As String
    Dim dtSet As New DataSet
    Dim m_oColumn As Infragistics.Win.UltraWinGrid.UltraGridColumn = Nothing

    Dim WgtTotal As Decimal


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
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents DTPicker1 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents CntMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents btnFinalize As System.Windows.Forms.Button
    Friend WithEvents btnGroup As System.Windows.Forms.Button
    Friend WithEvents GroupID As System.Windows.Forms.TextBox
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Group As System.Windows.Forms.TextBox
    Friend WithEvents btnRun As System.Windows.Forms.Button
    Friend WithEvents TotalWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnSaveLayout As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents DTPicker2 As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.DTPicker2 = New System.Windows.Forms.DateTimePicker
        Me.Label1 = New System.Windows.Forms.Label
        Me.TotalWeight = New System.Windows.Forms.TextBox
        Me.btnRun = New System.Windows.Forms.Button
        Me.btnGroup = New System.Windows.Forms.Button
        Me.GroupID = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.Group = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.DTPicker1 = New System.Windows.Forms.DateTimePicker
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnSaveLayout = New System.Windows.Forms.Button
        Me.btnFinalize = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.CntMenu1 = New System.Windows.Forms.ContextMenu
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.DTPicker2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.TotalWeight)
        Me.GroupBox1.Controls.Add(Me.btnRun)
        Me.GroupBox1.Controls.Add(Me.btnGroup)
        Me.GroupBox1.Controls.Add(Me.GroupID)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.Group)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.DTPicker1)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(507, 88)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(240, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 88
        Me.Label2.Text = "To Date:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DTPicker2
        '
        Me.DTPicker2.Location = New System.Drawing.Point(312, 48)
        Me.DTPicker2.Name = "DTPicker2"
        Me.DTPicker2.Size = New System.Drawing.Size(128, 20)
        Me.DTPicker2.TabIndex = 87
        Me.DTPicker2.Tag = ".TranDate"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(304, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 86
        Me.Label1.Text = "Total Weight:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label1.Visible = False
        '
        'TotalWeight
        '
        Me.TotalWeight.Enabled = False
        Me.TotalWeight.Location = New System.Drawing.Point(384, 16)
        Me.TotalWeight.Name = "TotalWeight"
        Me.TotalWeight.TabIndex = 4
        Me.TotalWeight.Text = ""
        Me.TotalWeight.Visible = False
        '
        'btnRun
        '
        Me.btnRun.Location = New System.Drawing.Point(520, 24)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(96, 21)
        Me.btnRun.TabIndex = 3
        Me.btnRun.Text = "&Load Manifest"
        Me.btnRun.Visible = False
        '
        'btnGroup
        '
        Me.btnGroup.Location = New System.Drawing.Point(248, 16)
        Me.btnGroup.Name = "btnGroup"
        Me.btnGroup.Size = New System.Drawing.Size(48, 21)
        Me.btnGroup.TabIndex = 1
        Me.btnGroup.Text = "Select"
        '
        'GroupID
        '
        Me.GroupID.Location = New System.Drawing.Point(624, 24)
        Me.GroupID.Name = "GroupID"
        Me.GroupID.Size = New System.Drawing.Size(64, 20)
        Me.GroupID.TabIndex = 81
        Me.GroupID.Tag = ".GroupID"
        Me.GroupID.Text = ""
        Me.GroupID.Visible = False
        '
        'Label16
        '
        Me.Label16.Location = New System.Drawing.Point(16, 16)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(72, 16)
        Me.Label16.TabIndex = 83
        Me.Label16.Text = "Manifest :"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Group
        '
        Me.Group.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Group.Location = New System.Drawing.Point(88, 16)
        Me.Group.Name = "Group"
        Me.Group.Size = New System.Drawing.Size(152, 20)
        Me.Group.TabIndex = 0
        Me.Group.Tag = ".Plan Group.view"
        Me.Group.Text = ""
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(24, 48)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 16)
        Me.Label5.TabIndex = 19
        Me.Label5.Text = "From Date:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'DTPicker1
        '
        Me.DTPicker1.Location = New System.Drawing.Point(96, 48)
        Me.DTPicker1.Name = "DTPicker1"
        Me.DTPicker1.Size = New System.Drawing.Size(128, 20)
        Me.DTPicker1.TabIndex = 2
        Me.DTPicker1.Tag = ".TranDate"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnSaveLayout)
        Me.GroupBox2.Controls.Add(Me.btnFinalize)
        Me.GroupBox2.Controls.Add(Me.btnExit)
        Me.GroupBox2.Controls.Add(Me.btnSave)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 200)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(503, 40)
        Me.GroupBox2.TabIndex = 2
        Me.GroupBox2.TabStop = False
        '
        'btnSaveLayout
        '
        Me.btnSaveLayout.Location = New System.Drawing.Point(504, 16)
        Me.btnSaveLayout.Name = "btnSaveLayout"
        Me.btnSaveLayout.Size = New System.Drawing.Size(88, 21)
        Me.btnSaveLayout.TabIndex = 3
        Me.btnSaveLayout.Text = "Save &Layout"
        Me.btnSaveLayout.Visible = False
        '
        'btnFinalize
        '
        Me.btnFinalize.Location = New System.Drawing.Point(88, 16)
        Me.btnFinalize.Name = "btnFinalize"
        Me.btnFinalize.Size = New System.Drawing.Size(75, 21)
        Me.btnFinalize.TabIndex = 1
        Me.btnFinalize.Text = "&Finalize"
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Location = New System.Drawing.Point(416, 16)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 21)
        Me.btnExit.TabIndex = 2
        Me.btnExit.Text = "E&xit"
        '
        'btnSave
        '
        Me.btnSave.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnSave.Location = New System.Drawing.Point(3, 16)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 21)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "&Update"
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Location = New System.Drawing.Point(421, 90)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(86, 23)
        Me.UltraGrid1.TabIndex = 1
        Me.UltraGrid1.Text = "Weight Entry"
        Me.UltraGrid1.Visible = False
        '
        'Label3
        '
        Me.Label3.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label3.Location = New System.Drawing.Point(13, 97)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(118, 18)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Description of Utilities:"
        '
        'Label4
        '
        Me.Label4.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label4.Location = New System.Drawing.Point(126, 118)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(323, 30)
        Me.Label4.TabIndex = 4
        Me.Label4.Text = "Update will recalculate and update the weight charges for all entries in a specif" & _
        "ic manifest over the specified date range."
        '
        'Label6
        '
        Me.Label6.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label6.Location = New System.Drawing.Point(71, 118)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 17)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "UPDATE:"
        '
        'Label7
        '
        Me.Label7.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label7.Location = New System.Drawing.Point(72, 160)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(58, 17)
        Me.Label7.TabIndex = 6
        Me.Label7.Text = "FINALIZE:"
        '
        'Label8
        '
        Me.Label8.ForeColor = System.Drawing.SystemColors.ActiveCaption
        Me.Label8.Location = New System.Drawing.Point(126, 160)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(323, 30)
        Me.Label8.TabIndex = 7
        Me.Label8.Text = "Finalize will mark all entries in the specified date range as 'Finalized' so that" & _
        " no further changes can be made to them."
        '
        'DailyEntryUtilites
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(514, 249)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.UltraGrid1)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "DailyEntryUtilites"
        Me.Tag = "DailyEntry"
        Me.Text = "Daily Weight Entry"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub DailyEntry_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        AddHandler Me.Activated, AddressOf Form_Activated
        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = WeightVars.WEIGHTTblPath & Me.Tag
            End If
        End If

        NewTrans = False
        WgtTotal = 0
        Me.CenterToScreen()

        Me.KeyPreview = True
        MeText = Me.Text

        ' Set each control's length based on DB size
        SetupCtrlsLength(Me, WeightVars.WEIGHTDBName, WEIGHTDBUser, WEIGHTDBPass)


        AddHandler Me.KeyUp, AddressOf Form_KeyUp
        DTPicker1.Format = DateTimePickerFormat.Custom
        DTPicker1.CustomFormat = "MM/dd/yyyy"
        DTPicker1.Value = Date.Today

        DTPicker2.Format = DateTimePickerFormat.Custom
        DTPicker2.CustomFormat = "MM/dd/yyyy"
        DTPicker2.Value = Date.Today

        'PrevDate = Format(DTPicker1.Value, "MM/dd/yyyy")

        'Dim keyMapping As New Infragistics.Win.UltraWinGrid.GridKeyActionMapping(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode, Infragistics.Win.UltraWinGrid.UltraGridState.CellFirst, Infragistics.Win.UltraWinGrid.UltraGridState.CellFirst And Infragistics.Win.UltraWinGrid.UltraGridState.RowLast, Infragistics.Win.SpecialKeys.All, 0)
        'UltraGrid1.KeyActionMappings.Add(keyMapping)


        'Dim map As New Infragistics.Win.KeyActionMappingBase()
        'map = UltraGrid1.KeyActionMappings.GetActionMappings(Keys.Enter, Infragistics.Win.UltraWinGrid.UltraGridAction.LastCellInGrid, Infragistics.Win.SpecialKeys.All)
        'map.GetUpperBound(0)
        'map.KeyCode = Keys.Enter
        'map.StateRequired = Infragistics.Win.UltraWinGrid.UltraGridAction.LastCellInGrid
        'map.ActionCode = Infragistics.Win.UltraWinGrid.UltraGridAction.DeactivateCell

    End Sub


    Private Function InsertBlankRecs(ByVal SelectQry As String) As Boolean
        Dim SQLString As String
        Dim Cmd As SqlCommand
        On Error GoTo ErrTrap

        SQLString = SQLInsert & " " & SelectQry

        sqlConn.Open()

        Dim trnSql As SqlTransaction = sqlConn.BeginTransaction()
        Cmd = New SqlCommand(SQLString, sqlConn, trnSql)

        With Cmd
            .CommandType = CommandType.Text
            .ExecuteNonQuery()
            .Transaction.Commit()
            .Connection.Close()
            'NewTrans = True
        End With

        Cmd = Nothing

        Exit Function
ErrTrap:
        MsgBox("InsertBlankRecs: " & Err.Description)
        If Not Cmd Is Nothing Then
            Cmd.Transaction.Rollback()
        End If
        sqlConn.Close()
        Cmd = Nothing
    End Function

    Private Sub UltraGrid1_BeforeCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.BeforeCellUpdateEventArgs) Handles UltraGrid1.BeforeCellUpdate
        If e.Cell.Column.ToString = "Weight" Or e.Cell.Column.ToString = "Charge" Then
            e.Cancel = False
        Else
            e.Cancel = True
        End If
    End Sub

    Private Sub UltraGrid1_BeforeEnterEditMode(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles UltraGrid1.BeforeEnterEditMode

        If UltraGrid1.ActiveCell.Column.ToString = "Weight" Then  'Or UltraGrid1.ActiveCell.Column.ToString = "Charge"
            'WgtTotal -= UltraGrid1.ActiveRow.Cells("Weight").Value       '  ugrow.Cells("Weight").Value
            e.Cancel = False
        Else
            e.Cancel = True
        End If

    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        'Dim cnt As Integer
        'Dim ID As Integer
        'Dim ugcol As Infragistics.Win.UltraWinGrid.UltraGridColumn
        'Dim ugrow As Infragistics.Win.UltraWinGrid.UltraGridRow
        'Dim row As DataRow

        'UltraGrid1.DisplayLayout.Bands(0).Columns("Charge").Hidden = False

        ''For Each ugrow In UltraGrid1.Rows
        ''    If ugrow.Cells("Weight").Value > ugrow.Cells("Weight Limit").Value Then
        ''        ugrow.Cells("Charge").Value = (ugrow.Cells("Weight").Value - ugrow.Cells("Weight Limit").Value) * ugrow.Cells("OWCharge").Value
        ''    Else
        ''        ugrow.Cells("Charge").Value = 0.0
        ''    End If
        ''    UltraGrid1.Update()
        ''    UltraGrid1.UpdateData()
        ''Next

        '''For Each row In dtSet.Tables(0).Rows
        '''    If row("Weight") > row("Weight Limit") Then
        '''        row("Charge") = (row("Weight") - row("Weight Limit")) * row("OWCharge")
        '''    Else
        '''        row("Charge") = 0.0
        '''    End If
        '''Next
        'UltraGrid1.DisplayLayout.Bands(0).Columns("Charge").Hidden = True

        'SelectTmp = SQLSelect & " Where de.WeightPlanGroupID = " & GroupID.Text & " AND  TranDate = '" & Format(DTPicker1.Value, "MM/dd/yyyy") & "' ORDER BY AccountName"

        'If UpdateDbFromDataSet(dtSet, SQLSelect & " Where de.WeightPlanGroupID = " & GroupID.Text & " AND TranDate = '" & Format(DTPicker1.Value, "MM/dd/yyyy") & "' ORDER BY AccountName") <= 0 Then  ' & " Where de.WeightPlanGroupID = " & GroupID.Text & " AND TranDate = '" & Format(DTPicker1.Value, "MM/dd/yyyy") & "' ORDER BY AccountName"
        '    MsgBox("Save: No Records Updated!")
        'End If

        Dim UpdCmd As SqlCommand
        UpdCmd = New SqlCommand("Update " & WeightVars.WEIGHTTblPath & "DailyEntry Set Weight = @Wgt, Charge = @Chrg where TranDate = @TrDate and ManifestID = @WgtPlanID")
        UpdCmd.Parameters.Add("@Wgt", SqlDbType.Decimal, 5, "Weight")
        UpdCmd.Parameters.Add("@Chrg", SqlDbType.Decimal, 5, "Charge")

        Dim CondParam1 As SqlParameter = UpdCmd.Parameters.Add("@TrDate", SqlDbType.DateTime)
        CondParam1.SourceColumn = "TranDate"
        CondParam1.SourceVersion = DataRowVersion.Original

        Dim CondParam2 As SqlParameter = UpdCmd.Parameters.Add("@WgtPlanID", SqlDbType.Int)
        CondParam2.SourceColumn = "ManifestID"
        CondParam2.SourceVersion = DataRowVersion.Original

        '''''BEGIN LOOP
        'DeleteUnSavedTransactions()
        strCurrentDate = Format(DTPicker1.Value, "MM/dd/yyyy")
        While Date.Compare(DTPicker2.Value, CDate(strCurrentDate)) >= 0
            LoadData(strCurrentDate)
            UpdateDbFromDataSetV3(dtSet, SQLSelect & " Where de.WeightPlanGroupID = " & GroupID.Text & " AND TranDate = '" & strCurrentDate & "' ORDER BY AccountName", UpdCmd)
            strCurrentDate = Format(CDate(strCurrentDate).AddDays(1), "MM/dd/yyyy")
            ''If UpdateDbFromDataSetV2(dtSet.GetChanges, SQLSelect & " Where de.WeightPlanGroupID = " & GroupID.Text & " AND TranDate = '" & Format(DTPicker1.Value, "MM/dd/yyyy") & "' ORDER BY AccountName", "") <= 0 Then
            ''    'MsgBox("btnDelete_Click: Error!")
            ''End If
            '''''END LOOP
        End While
        NewTrans = False
        sender.focus()
        MsgBox("Update Completed for The Range Specified")
    End Sub


    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click

        'If NewTrans Then
        '    DeleteUnSavedTransactions()
        'End If
        'If UltraGrid1.Rows.Count > 0 Then
        '    UGSaveLayout(Me, UltraGrid1, 1)
        'End If
        Me.Close()
    End Sub

    Private Function DeleteUnSavedTransactions()
        If PrevDate = "" Then Exit Function
        Dim SQLString As String
        Dim Cmd As SqlCommand
        On Error GoTo ErrTrap

        SQLString = "Delete FROM " & WeightVars.WEIGHTTblPath & "DailyEntry where WeightPlanGroupID = " & PrevGroupID & " AND TranDate = '" & PrevDate & "'"

        sqlConn.Open()

        Dim trnSql As SqlTransaction = sqlConn.BeginTransaction()
        Cmd = New SqlCommand(SQLString, sqlConn, trnSql)

        With Cmd
            .CommandType = CommandType.Text
            .ExecuteNonQuery()
            .Transaction.Commit()
            .Connection.Close()
            NewTrans = False
        End With

        Cmd = Nothing

        Exit Function
ErrTrap:
        MsgBox("DeleteUnSavedTransacions: " & Err.Description)
        If Not Cmd Is Nothing Then
            Cmd.Transaction.Rollback()
        End If
        sqlConn.Close()
        Cmd = Nothing


    End Function

    Private Sub DTPicker1_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles DTPicker1.ValueChanged
        If NewTrans Then
            'DeleteUnSavedTransactions()
        End If

        If GroupID.Text.Trim <> "" Then
            'LoadData()
        End If

        'Dim dtAdapter As SqlDataAdapter
        'Dim SelectTmp As String
        ''Dim SelectTmp2 As String
        'Dim Finalized As Boolean
        'Dim i As Integer
        'Dim HiddenCols() As String = {"TranDate", "Weight Limit", "OWCharge"} ', "Charge"

        'If NewTrans Then
        '    DeleteUnSavedTransactions()
        'End If
        'NewTrans = False
        'PrevDate = Format(DTPicker1.Value, "MM/dd/yyyy")
        'SelectTmp = SQLSelect & " Where de.WeightPlanGroupID = " & GroupID.Text & " AND TranDate = '" & Format(DTPicker1.Value, "MM/dd/yyyy") & "' ORDER BY AccountName"
        'Finalized = IsFinalized()
        'PopulateDataset2(dtAdapter, dtSet, SelectTmp)

        'FillUltraGrid(UltraGrid1, dtSet, 4, HiddenCols)
        'UGLoadLayout(Me, UltraGrid1, 1)
        'If Finalized Then
        '    UltraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False
        'Else
        '    'InsertNewPlans()
        '    UltraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True
        'End If

        'If dtSet.Tables(0).Rows.Count = 0 Then
        '    btnSave.Text = "&Save"
        'Else
        '    btnSave.Text = "&Update"
        'End If

        'UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit

        'For i = 0 To 5
        '    UltraGrid1.DisplayLayout.Bands(0).Columns(i).TabStop = False
        'Next
        'UltraGrid1.DisplayLayout.Bands(0).Columns(9).TabStop = False
    End Sub

    Private Sub UltraGrid1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles UltraGrid1.KeyPress
        'If UltraGrid1.ActiveRow.Index = UltraGrid1.Rows(UltraGrid1.Rows.Count - 1).Index Then
        '    If Asc(e.KeyChar) = Keys.Enter Then
        '        e.Handled = True
        '        btnSave.Focus()
        '    Else
        '        e.Handled = False
        '    End If
        'End If
        ''If Asc(e.KeyChar) = Keys.Enter Then
        ''    e.Handled = True
        ''    SendKeys.Send("{TAB}")
        ''ElseIf Asc(e.KeyChar) = Keys.Down Then
        ''    e.Handled = True
        ''    UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell, False, False)
        ''ElseIf Asc(e.KeyChar) = Keys.Up Then
        ''    e.Handled = True
        ''    UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell, False, False)
        ''Else
        ''    e.Handled = False
        ''End If
    End Sub

    Private Sub UltraGrid1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles UltraGrid1.KeyUp
        'If UltraGrid1.ActiveRow.Index = UltraGrid1.Rows(UltraGrid1.Rows.Count - 1).Index Then
        '    If e.KeyCode = Keys.Enter Or e.KeyCode = Keys.Tab Then
        '        e.Handled = True
        '        btnSave.Focus()
        '    Else
        '        e.Handled = False
        '    End If
        'End If
    End Sub

    Private Sub UltraGrid1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles UltraGrid1.KeyDown
        'If UltraGrid1.ActiveRow.Index = UltraGrid1.Rows(UltraGrid1.Rows.Count - 1).Index Then
        '    If e.KeyCode = Keys.Enter Then
        '        e.Handled = True
        '        'btnSave.Focus()
        '        ultragrid1.KeyActionMappings.Add(
        '    Else
        '        e.Handled = False
        '    End If
        'End If
        If e.KeyCode = Keys.Down Then
            e.Handled = True
            UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode, False, False)
            UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.BelowCell, False, False)
            UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, False, False)
        ElseIf e.KeyCode = Keys.Up Then
            e.Handled = True
            UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.ExitEditMode, False, False)
            UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.AboveCell, False, False)
            UltraGrid1.PerformAction(Infragistics.Win.UltraWinGrid.UltraGridAction.EnterEditMode, False, False)
        Else
            e.Handled = False
        End If

    End Sub
    Private Sub Ultragrid1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles UltraGrid1.MouseDown

        If e.Button = MouseButtons.Right Then

            Dim oHeaderUI As Infragistics.Win.UltraWinGrid.HeaderUIElement
            Dim oCaptionUI As Infragistics.Win.UltraWinGrid.CaptionAreaUIElement
            Dim oUIElement As Infragistics.Win.UIElement
            Dim oUIElementTmp As Infragistics.Win.UIElement
            Dim point As Point = New Point(e.X, e.Y)


            oUIElement = Me.UltraGrid1.DisplayLayout.UIElement.ElementFromPoint(point)
            If oUIElement Is Nothing Then Exit Sub
            'Infragistics.Win.UltraWinGrid.BandHeadersUIElement()
            'Infragistics.Win.UltraWinGrid.CaptionAreaUIElement()
            'Infragistics.Win.UltraWinGrid.CardAreaUIElement()
            'Infragistics.Win.UltraWinGrid.CardCaptionUIElement()
            'Infragistics.Win.UltraWinGrid.CardLabelAreaUIElement()
            'Infragistics.Win.UltraWinGrid.CardLabelUIElement()
            'Infragistics.Win.UltraWinGrid.CellUIElement()
            'Infragistics.Win.UltraWinGrid.DataAreaUIElement()
            'Infragistics.Win.UltraWinGrid.PageHeaderUIElement()
            'Infragistics.Win.UltraWinGrid.PreRowAreaUIElement()
            'Infragistics.Win.UltraWinGrid.RowCellAreaUIElement()
            'Infragistics.Win.UltraWinGrid.RowSelectorUIElement()
            'Infragistics.Win.UltraWinGrid.RowUIElement()
            'Infragistics.Win.UltraWinGrid.SortIndicatorUIElement()
            'Infragistics.Win.UltraWinGrid.UltraGridUIElement()

            oUIElementTmp = oUIElement.GetAncestor(GetType(Infragistics.Win.UltraWinGrid.HeaderUIElement))
            If oUIElementTmp Is Nothing Then
                oUIElementTmp = oUIElement.GetAncestor(GetType(Infragistics.Win.UltraWinGrid.CaptionAreaUIElement))
                If oUIElementTmp Is Nothing Then
                    Return
                End If
            End If
            oUIElement = oUIElementTmp
            If Not oUIElement.GetType() Is GetType(Infragistics.Win.UltraWinGrid.HeaderUIElement) Then
                If Not oUIElement.GetType() Is GetType(Infragistics.Win.UltraWinGrid.CaptionAreaUIElement) Then
                    Exit Sub
                Else
                    oCaptionUI = oUIElement
                End If
            Else
                oHeaderUI = oUIElement
            End If

            If oCaptionUI Is Nothing Then
                CntMenu1.MenuItems.Clear()
                'CntMenu1.MenuItems.Add("Hide", New EventHandler(AddressOf mnuHide_Click))
                'CntMenu1.MenuItems.Add("Unhide")
                CntMenu1.MenuItems.Add("Add to Sort (Asc)", New EventHandler(AddressOf mnuSortAsc_Click))
                CntMenu1.MenuItems.Add("Add to Sort (Desc)", New EventHandler(AddressOf mnuSortDesc_Click))


                Dim oColHeader As Infragistics.Win.UltraWinGrid.ColumnHeader = Nothing
                m_oColumn = Nothing
                oColHeader = oHeaderUI.SelectableItem
                m_oColumn = oColHeader.Column
                If m_oColumn Is Nothing Then Exit Sub


                Dim ugcol As Infragistics.Win.UltraWinGrid.UltraGridColumn
                'If CntMenu1.MenuItems.Item(1).MenuItems.Count > 0 Then
                '    CntMenu1.MenuItems.Item(1).MenuItems.Clear()
                '    CntMenu1.MenuItems.RemoveAt(1)
                '    CntMenu1.MenuItems.Add("Unhide")
                '    CntMenu1.MenuItems(CntMenu1.MenuItems.Count).Index = 1
                'End If
                For Each ugcol In UltraGrid1.DisplayLayout.Bands(0).Columns
                    If ugcol.Hidden = True Then
                        'CntMenu1.MenuItems(1).MenuItems.Add(ugcol.ToString, New EventHandler(AddressOf SubMnuUnHide_Click))
                    End If
                Next

                CntMenu1.Show(UltraGrid1, point)
            Else 'Caption Click
                CntMenu1.MenuItems.Clear()
                CntMenu1.MenuItems.Add("AutoFit", New EventHandler(AddressOf mnuAutoFit_Click))
                CntMenu1.MenuItems(0).Checked = UltraGrid1.DisplayLayout.AutoFitColumns
                CntMenu1.Show(UltraGrid1, point)

            End If


        End If

    End Sub

    Private Sub mnuAutoFit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If CntMenu1.MenuItems(0).Checked Then
            CntMenu1.MenuItems(0).Checked = False
        Else
            CntMenu1.MenuItems(0).Checked = True
        End If
        UltraGrid1.DisplayLayout.AutoFitColumns = CntMenu1.MenuItems(0).Checked

    End Sub

    Private Sub mnuHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles mnuHide.Click
        If Not m_oColumn Is Nothing Then
            m_oColumn.Hidden = True
        End If
    End Sub
    Private Sub SubMnuUnHide_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim ugCol As Infragistics.Win.UltraWinGrid.UltraGridColumn

        For Each ugCol In UltraGrid1.DisplayLayout.Bands(0).Columns
            If ugCol.ToString = sender.text Then
                ugCol.Hidden = False
            End If
        Next

    End Sub

    Private Sub mnuSortAsc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles mnuSortAsc.Click
        UltraGrid1.DisplayLayout.Bands(0).SortedColumns.Add(m_oColumn, False)
    End Sub

    Private Sub mnuSortDesc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) 'Handles mnuSortDesc.Click
        UltraGrid1.DisplayLayout.Bands(0).SortedColumns.Add(Me.m_oColumn, True)
    End Sub

    Private Sub UltraGrid1_InitializeRow(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.InitializeRowEventArgs) Handles UltraGrid1.InitializeRow
        Dim i As Integer
        Dim ugrow As Infragistics.Win.UltraWinGrid.UltraGridRow

        ugrow = e.Row


        If ugrow.Cells("Weight").Value > ugrow.Cells("Weight Limit").Value Then
            ugrow.Cells("Charge").Value = (ugrow.Cells("Weight").Value - ugrow.Cells("Weight Limit").Value) * ugrow.Cells("OWCharge").Value
        Else
            ugrow.Cells("Charge").Value = 0.0
        End If


    End Sub

    Private Sub DailyEntry_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing

        ''Karina, do not save in Edit mode
        'If btnSave.Text = "&Update" Then
        '    If MsgBox("Data is not saved! Are you sure you want to exit?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
        '        e.Cancel = True
        '        Exit Sub
        '    End If
        'End If

        If NewTrans Then
            DeleteUnSavedTransactions()
        End If

    End Sub


    Private Sub btnFinalize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFinalize.Click

        strCurrentDate = Format(DTPicker1.Value, "MM/dd/yyyy")
        Dim SQLString As String
        Dim Cmd As SqlCommand

        While Date.Compare(DTPicker2.Value, CDate(strCurrentDate)) >= 0

            If UpdateDbFromDataSet(dtSet, SQLSelect & " Where de.WeightPlanGroupID = " & GroupID.Text & " AND TranDate = '" & strCurrentDate & "' ORDER BY AccountName") <= 0 Then
                'MsgBox("btnDelete_Click: Error!")
            End If
            NewTrans = False
            sender.focus()

            On Error GoTo ErrTrap

            SQLString = "Update " & WeightVars.WEIGHTTblPath & "dailyentry set Finalize = 1 Where WeightPlanGroupID = " & GroupID.Text & " AND TranDate = '" & strCurrentDate & "' AND WeightPlanGroupID = " & GroupID.Text

            sqlConn.Open()

            Dim trnSql As SqlTransaction = sqlConn.BeginTransaction()
            Cmd = New SqlCommand(SQLString, sqlConn, trnSql)

            With Cmd
                .CommandType = CommandType.Text
                .ExecuteNonQuery()
                .Transaction.Commit()
                .Connection.Close()
            End With

            Cmd = Nothing

            UltraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False

            strCurrentDate = Format(CDate(strCurrentDate).AddDays(1), "MM/dd/yyyy")
        End While

        Exit Sub
ErrTrap:
        MsgBox("btnFinalize_Click: " & Err.Description)
        If Not Cmd Is Nothing Then
            Cmd.Transaction.Rollback()
        End If
        sqlConn.Close()
        Cmd = Nothing

    End Sub

    Private Function IsFinalized() As Boolean
        Dim Cmd As SqlCommand
        Dim dr As SqlDataReader
        Dim TagName As String
        Dim SelectTmp2 As String
        On Error GoTo ErrTrap

        IsFinalized = False

        sqlConn.Open()

        Cmd = New SqlCommand("Select Finalize FROM " & WeightVars.WEIGHTTblPath & "DailyEntry de where de.WeightPlanGroupID = " & GroupID.Text & " AND TranDate = '" & strCurrentDate & "'", sqlConn)

        With Cmd
            .CommandType = CommandType.Text
            '.ExecuteNonQuery()
            dr = .ExecuteReader
        End With

        If dr.Read() = True Then
            Dim result As Boolean

            IsFinalized = dr("Finalize")
            result = dr("Finalize")
            dr.Close()
            Cmd.Connection.Close()

            'Update Pricing
            If result = False Then
                sqlConn.Open()
                Cmd.CommandText = "UPDATE " & WeightVars.WEIGHTTblPath & "DailyEntry SET owcharge = (SELECT wbd.owcharge FROM " & WeightVars.WEIGHTTblPath & "WeightBreakdown wbd, " & WeightVars.WEIGHTTblPath & "Manifests mft WHERE mft.id = " & WeightVars.WEIGHTTblPath & "DailyEntry.manifestid AND wbd.id = mft.weightid) " & _
                ", weightlimit = (SELECT wbd.WeightLimit FROM " & WeightVars.WEIGHTTblPath & "WeightBreakdown wbd, " & WeightVars.WEIGHTTblPath & "Manifests mft WHERE mft.id = " & WeightVars.WEIGHTTblPath & "DailyEntry.manifestid AND wbd.id = mft.weightid) " & _
                ", charge = ((" & WeightVars.WEIGHTTblPath & "DailyEntry.weight - " & WeightVars.WEIGHTTblPath & "DailyEntry.weightlimit) * owcharge + ABS(" & WeightVars.WEIGHTTblPath & "DailyEntry.weight - " & WeightVars.WEIGHTTblPath & "DailyEntry.weightlimit) * owcharge) / 2 " & _
                ", ManifestName = (SELECT isnull(mft.Name, " & WeightVars.WEIGHTTblPath & "DailyEntry.ManifestName) FROM " & WeightVars.WEIGHTTblPath & "Manifests mft WHERE mft.id =* " & WeightVars.WEIGHTTblPath & "DailyEntry.manifestid) " & _
                ", AccountName = (SELECT isnull(acc.Name, " & WeightVars.WEIGHTTblPath & "DailyEntry.AccountName) FROM " & AppTblPath & "Customer acc WHERE acc.id =* " & WeightVars.WEIGHTTblPath & "DailyEntry.Accountid) " & _
                ", WeightPlanGroupID = (SELECT isnull(mft.GroupID, 0) FROM " & WeightVars.WEIGHTTblPath & "Manifests mft WHERE mft.id =* " & WeightVars.WEIGHTTblPath & "DailyEntry.manifestid) " & _
                ", WeightPlanGroup = (SELECT isnull(wgtgrp.Name, " & WeightVars.WEIGHTTblPath & "DailyEntry.WeightPlanGroup) FROM " & WeightVars.WEIGHTTblPath & "Manifests mft, " & WeightVars.WEIGHTTblPath & "WeightPlanGroups wgtgrp WHERE mft.id = " & WeightVars.WEIGHTTblPath & "DailyEntry.manifestid and mft.GroupID = WGTGRP.ID) " & _
                " WHERE WeightPlanGroupID = " & GroupID.Text & " AND trandate = '" & strCurrentDate & "' AND manifestid IN (SELECT id FROM " & WeightVars.WEIGHTTblPath & "manifests) "

                With Cmd
                    .Connection = sqlConn
                    .CommandType = CommandType.Text
                    .ExecuteNonQuery()
                    .Connection.Close()
                End With

                InsertNewPlans()
            End If


        Else
            dr.Close()
            Cmd.Connection.Close()
            SelectTmp2 = "Select '" & strCurrentDate & "' as TranDate, " & SQLInsSelect
            SelectTmp2 = SelectTmp2.Replace("@TranDate", "'" & strCurrentDate & "'")

            SelectTmp2 = PrepSelectQuery(SelectTmp2, " AND mft.GroupID = " & GroupID.Text)
            InsertBlankRecs(SelectTmp2)
            NewTrans = True
        End If
        Cmd = Nothing


        Exit Function
ErrTrap:
        MsgBox("IsFinalized : " & Err.Number & " - " & Err.Description)
        dr.Close()
        Cmd.Connection.Close()
        Cmd = Nothing
        IsFinalized = True
    End Function

    Private Function InsertNewPlans()
        Dim SelectNew As String
        Dim SelectTmp2 As String

        SelectTmp2 = "Select '" & strCurrentDate & "' as TranDate, " & SQLInsSelect
        SelectTmp2 = SelectTmp2.Replace("@TranDate", "'" & strCurrentDate & "'")

        SelectNew = PrepSelectQuery(SelectTmp2, SQLInsertNewMft & " WHERE WeightPlanGroupID = " & GroupID.Text & " AND trandate = '" & strCurrentDate & "') AND mft.groupid = " & GroupID.Text)

        InsertBlankRecs(SelectNew)
    End Function


    Private Sub Manifest_Leave(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Group.Leave
        'On Error GoTo ErrTrap
        Dim daCity As New SqlDataAdapter
        Dim dsCity As New DataSet
        Dim dvCities1 As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow

        Dim GroupSQL As String = "Select ID, Name as Manifest FROM " & WeightVars.WEIGHTTblPath & "WeightPlanGroups " '& " where StateCode = '" & State.SelectedValue & "'" '" AND zipcode = '" & Zipcode.Text & "'"
        HasErr = False
        If sender.Modified Then
            If IsNumeric(sender.Text) Then ' Zipcode
                GroupSQL = GroupSQL & " where ID = '" & sender.Text & "'"
                PopulateDataset2(daCity, dsCity, GroupSQL)
                dvCities1.Table = dsCity.Tables("WeightPlanGroups")
                If dvCities1.Table.Rows.Count > 0 Then
                    GroupID.Text = sender.Text.ToString
                    sender.Text = dvCities1.Table.Rows(0).Item("Manifest")
                Else
                    MsgBox("Manifest not found!", MsgBoxStyle.OKOnly, MeText)
                    ClearData()
                End If
            Else 'Blank or City Name
                If sender.text.trim() = "" Then
                    UltraGrid1.DataSource = Nothing
                    Exit Sub
                End If
                If sender.Text.StartsWith("?") Then
                    sender.text = sender.text.substring(1)
                End If
                GroupSQL = GroupSQL & " where Name like '" & sender.text & "%' Order by Name"
                PopulateDataset2(daCity, dsCity, GroupSQL)
                dvCities1.Table = dsCity.Tables(WeightVars.WEIGHTTblPath & "WeightPlanGroups")
                If dvCities1.Table Is Nothing Then GoTo ErrTrap
                If dvCities1.Table.Rows.Count > 0 Then
                    If dvCities1.Table.Rows.Count > 1 Then
                        Dim Srch As New SearchListings
                        Srch.dsList = dsCity

                        Srch.UltraGrid1.Text = "Manifests beginning with '" & sender.text & "'"
                        Srch.Text = "Manifests"
                        Srch.ShowDialog()
                        If Srch.DialogResult <> DialogResult.OK Then
                            ClearData()
                            Exit Sub
                        End If
                        Try
                            Dim cnt As Integer
                            cnt = Srch.UltraGrid1.Rows.Count
                        Catch Err As System.Exception
                            'MsgBox("Zipcode Leave: " & Err.Message)
                            Srch = Nothing
                            sender.Focus()
                            HasErr = True
                            Exit Try
                        Catch Err2 As System.NullReferenceException
                            ' CANCEL PRESSED
                            Srch = Nothing
                            sender.Focus()
                            HasErr = True
                            Exit Try
                        Catch osqlexception As SqlException
                            MsgBox("SQL_Error: " & osqlexception.Message)
                            Srch = Nothing
                            sender.Focus()
                            Exit Try
                        Finally
                            If HasErr = False Then
                                ugRow = Srch.UltraGrid1.ActiveRow
                                Group.Text = ugRow.Cells("Manifest").Text
                                GroupID.Text = ugRow.Cells("ID").Text
                                Srch = Nothing
                            End If
                        End Try
                    Else ' Just one record found
                        Group.Text = dvCities1(0).Item("manifest") 'ugRow.Cells("City").Text
                        GroupID.Text = dvCities1(0).Item("ID") ' ugRow.Cells("Zipcode").Text

                    End If
                Else
                    MsgBox("No matching Manifest found!", MsgBoxStyle.OKOnly, MeText)
                    ClearData()
                    Group.Focus()
                End If
            End If
            sender.Modified = False
        End If
        daCity.Dispose()
        daCity = Nothing
        dsCity.Dispose()
        dsCity = Nothing
        'If GroupID.Text.Trim <> "" Then
        '    LoadData()
        'End If
        Exit Sub
ErrTrap:
        MsgBox("Manifest Error: " & Err.Description)
        daCity.Dispose()
        daCity = Nothing
        dsCity.Dispose()
        dsCity = Nothing
        dvCities1.Dispose()
        dvCities1 = Nothing
    End Sub

    Private Sub Group_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Group.KeyUp

        TypeAhead(sender, e, WeightVars.WEIGHTTblPath & "WeightPlanGroups", "Name", "")
        'sender.modified = True
    End Sub

    'Private Sub Zipcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Zipcode.KeyPress
    '    If IsNumeric(e.KeyChar) = False And Asc(e.KeyChar) <> Keys.Back Then
    '        e.Handled() = True
    '    End If
    'End Sub

    Private Sub LoadData()
        Dim dtAdapter As SqlDataAdapter
        Dim SelectTmp As String
        'Dim SelectTmp2 As String
        Dim Finalized As Boolean
        Dim i As Integer
        Dim HiddenCols() As String = {"TranDate", "Weight Limit", "OWCharge"} ', "Charge"

        If GroupID.Text.Trim = "" Then Exit Sub

        If NewTrans Then
            DeleteUnSavedTransactions()
        End If
        NewTrans = False
        PrevDate = strCurrentDate
        PrevGroupID = GroupID.Text
        SelectTmp = SQLSelect & " Where de.WeightPlanGroupID = " & GroupID.Text & " AND  TranDate = '" & strCurrentDate & "' ORDER BY AccountName"
        Finalized = IsFinalized()
        PopulateDataset2(dtAdapter, dtSet, SelectTmp)

        FillUltraGrid(UltraGrid1, dtSet, 4, HiddenCols)
        UGLoadLayout(Me, UltraGrid1, 1)
        If Finalized Then
            UltraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False
        Else
            'InsertNewPlans()
            UltraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True
        End If
        CalcTotals()
        TotalWeight.Text = WgtTotal

        'to refresh the dataSet
        UltraGrid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnRowChange
        UltraGrid1.UpdateData()
        UltraGrid1.Rows.Refresh(Infragistics.Win.UltraWinGrid.RefreshRow.RefreshDisplay)

        If dtSet.Tables(0).Rows.Count = 0 Then
            btnSave.Text = "&Save"
        Else
            btnSave.Text = "&Update"
        End If

        UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit

        For i = 0 To 5
            UltraGrid1.DisplayLayout.Bands(0).Columns(i).TabStop = False
        Next
        UltraGrid1.DisplayLayout.Bands(0).Columns(9).TabStop = False


    End Sub

    Private Sub LoadData(ByVal strDate As String)
        Dim dtAdapter As SqlDataAdapter
        Dim SelectTmp As String
        'Dim SelectTmp2 As String
        Dim Finalized As Boolean
        Dim i As Integer
        Dim HiddenCols() As String = {"TranDate", "Weight Limit", "OWCharge"} ', "Charge"

        If GroupID.Text.Trim = "" Then Exit Sub

        If NewTrans Then
            DeleteUnSavedTransactions()
        End If
        NewTrans = False
        PrevDate = strDate 'Format(DTPicker1.Value, "MM/dd/yyyy")
        PrevGroupID = GroupID.Text
        SelectTmp = SQLSelect & " Where de.WeightPlanGroupID = " & GroupID.Text & " AND  TranDate = '" & strDate & "' ORDER BY AccountName"
        Finalized = IsFinalized()
        PopulateDataset2(dtAdapter, dtSet, SelectTmp)

        FillUltraGrid(UltraGrid1, dtSet, 4, HiddenCols)
        UGLoadLayout(Me, UltraGrid1, 1)
        If Finalized Then
            UltraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False
        Else
            'InsertNewPlans()
            UltraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True
        End If
        CalcTotals()
        TotalWeight.Text = WgtTotal

        'to refresh the dataSet
        UltraGrid1.UpdateMode = Infragistics.Win.UltraWinGrid.UpdateMode.OnRowChange
        UltraGrid1.UpdateData()
        UltraGrid1.Rows.Refresh(Infragistics.Win.UltraWinGrid.RefreshRow.RefreshDisplay)

        If dtSet.Tables(0).Rows.Count = 0 Then
            btnSave.Text = "&Save"
        Else
            btnSave.Text = "&Update"
        End If

        UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit

        For i = 0 To 5
            UltraGrid1.DisplayLayout.Bands(0).Columns(i).TabStop = False
        Next
        UltraGrid1.DisplayLayout.Bands(0).Columns(9).TabStop = False


    End Sub


    Private Sub ClearData()
        Group.Text = ""
        GroupID.Text = ""
        UltraGrid1.DataSource = Nothing
    End Sub

    Private Sub btnRun_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRun.Click
        LoadData()
    End Sub

    Private Sub btnGroup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnGroup.Click
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim Title As String

        SelectSQL = "Select * FROM " & WeightVars.WEIGHTTblPath & "WeightPlanGroups order by Name"
        Title = "Manifests"

        PopulateDataset2(dtAdapter, dtSet, SelectSQL)
        dtView.Table = dtSet.Tables(0)
        If dtView.Table.Rows.Count > 0 Then
            Dim Srch As New SearchListings
            Srch.dsList = dtSet

            Srch.UltraGrid1.Text = Title
            Srch.Text = Title
            Srch.ShowDialog()
            If Srch.DialogResult <> DialogResult.OK Then Exit Sub
            Try
                Dim cnt As Integer
                cnt = Srch.UltraGrid1.Rows.Count
            Catch Err As System.Exception
                'MsgBox("Zipcode Leave: " & Err.Message)
                Srch = Nothing
                sender.Focus()
                HasErr = True
                Exit Try
            Catch Err2 As System.NullReferenceException
                ' CANCEL PRESSED
                Srch = Nothing
                sender.Focus()
                HasErr = True
                Exit Try
            Catch osqlexception As SqlException
                MsgBox("SQL_Error: " & osqlexception.Message)
                Srch = Nothing
                sender.Focus()
                Exit Try
            Finally
                If HasErr = False Then
                    ugRow = Srch.UltraGrid1.ActiveRow
                    GroupID.Text = ugRow.Cells("ID").Text
                    Group.Text = ugRow.Cells("Name").Text
                    Srch = Nothing
                End If
            End Try
        End If

    End Sub

    Private Sub CalcTotals()
        Dim ugrow As Infragistics.Win.UltraWinGrid.UltraGridRow
        WgtTotal = 0

        For Each ugrow In UltraGrid1.Rows
            WgtTotal += ugrow.Cells("Weight").Value
        Next
    End Sub

    Private Sub UltraGrid1_AfterCellUpdate(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinGrid.CellEventArgs) Handles UltraGrid1.AfterCellUpdate
        If e.Cell.Column.ToString = "Weight" And e.Cell.DataChanged Then
            'If UltraGrid1.ActiveRow.Cells("Weight").DataChanged Then
            'UltraGrid1.ActiveRow.Cells("Weight").IsInEditMode()
            WgtTotal -= e.Cell.OriginalValue
            WgtTotal += e.Cell.Value
            TotalWeight.Text = WgtTotal
        End If
    End Sub

    Private Sub UltraGrid1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraGrid1.Leave
        If Not UltraGrid1.ActiveCell Is Nothing Then
            UltraGrid1.ActiveCell.Selected = True
        End If
        If Not UltraGrid1.ActiveRow Is Nothing Then
            UltraGrid1.ActiveRow.Update()
        End If
    End Sub

    Private Sub btnSaveLayout_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSaveLayout.Click
        If UltraGrid1.Rows.Count > 0 Then
            UGSaveLayout(Me, UltraGrid1, 1)
        End If
    End Sub

    Private Sub Label7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Label7.Click

    End Sub
End Class
