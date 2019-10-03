Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors
Public Class CopyPricePlan
    Inherits System.Windows.Forms.Form
    Dim MeText As String
    Dim dtAdapter As New SqlDataAdapter
    Dim dtSet As New DataSet
    Dim dtView As New DataView
    Dim cmdTrans As SqlCommand
    Dim sqlSelPP As String = "Select pp.PlanID, pp.Plan_Name, pp.Charge_Code, ppt.PlanType, pp.From_Zone, " & _
                             "pp.To_Zone, pp.Start_Date, pp.End_Date, pp.ModuleName, pp.TableName, pp.ColumnName, " & _
                             "pp.ColumnPrefix, pp.ColumnSuffix, pp.Invoice_Title, pp.Taxable, pp.Description From " & BILLTblPath & "PricePlans pp, " & BILLTblPath & "PricePlanTypes ppt where ppt.PlanTypeCode = pp.PlanTypeCode Order by pp.Plan_Name"
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents utSource As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utTargetName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnSelect As System.Windows.Forms.Button
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents utPlanID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.utSource = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utTargetName = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.btnSelect = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnCancel = New System.Windows.Forms.Button
        Me.utPlanID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Panel1 = New System.Windows.Forms.Panel
        CType(Me.utSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utTargetName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utPlanID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(32, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(48, 16)
        Me.Label1.TabIndex = 19
        Me.Label1.Text = "Source:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(0, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(80, 16)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "Target Name:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utSource
        '
        Me.utSource.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utSource.Location = New System.Drawing.Point(80, 8)
        Me.utSource.MaxLength = 40
        Me.utSource.Name = "utSource"
        Me.utSource.Size = New System.Drawing.Size(200, 21)
        Me.utSource.TabIndex = 0
        Me.utSource.Tag = ""
        '
        'utTargetName
        '
        Me.utTargetName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utTargetName.Location = New System.Drawing.Point(80, 40)
        Me.utTargetName.MaxLength = 40
        Me.utTargetName.Name = "utTargetName"
        Me.utTargetName.Size = New System.Drawing.Size(200, 21)
        Me.utTargetName.TabIndex = 2
        Me.utTargetName.Tag = ".Plan_Name.PricePlans"
        '
        'btnSelect
        '
        Me.btnSelect.Location = New System.Drawing.Point(288, 10)
        Me.btnSelect.Name = "btnSelect"
        Me.btnSelect.Size = New System.Drawing.Size(75, 21)
        Me.btnSelect.TabIndex = 1
        Me.btnSelect.Text = "S&elect"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(288, 72)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 21)
        Me.btnExit.TabIndex = 5
        Me.btnExit.Text = "E&xit"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(8, 72)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(75, 21)
        Me.btnSave.TabIndex = 3
        Me.btnSave.Text = "&Save"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(88, 72)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(75, 21)
        Me.btnCancel.TabIndex = 4
        Me.btnCancel.Text = "&Cancel"
        '
        'utPlanID
        '
        Me.utPlanID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utPlanID.Location = New System.Drawing.Point(8, 8)
        Me.utPlanID.MaxLength = 40
        Me.utPlanID.Name = "utPlanID"
        Me.utPlanID.Size = New System.Drawing.Size(24, 21)
        Me.utPlanID.TabIndex = 27
        Me.utPlanID.TabStop = False
        Me.utPlanID.Tag = ""
        Me.utPlanID.Visible = False
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.utPlanID)
        Me.Panel1.Controls.Add(Me.utTargetName)
        Me.Panel1.Controls.Add(Me.utSource)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(288, 64)
        Me.Panel1.TabIndex = 28
        '
        'CopyPricePlan
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(368, 102)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.btnCancel)
        Me.Controls.Add(Me.btnSave)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnSelect)
        Me.Name = "CopyPricePlan"
        Me.Tag = ""
        Me.Text = "Copy Price Plan"
        CType(Me.utSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utTargetName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utPlanID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub CopyPricePlan_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.CenterToScreen()

        AddHandler Me.Activated, AddressOf Form_Activated

        If Not Me.Tag Is Nothing Then
            If Me.Tag.trim <> "" Then
            End If
        End If
        Me.KeyPreview = True
        MeText = Me.Text

        'Set each control's length based on DB size
        'SetupCtrlsLength(Me, AppDBName, AppDBUser, AppDBPass)

        AddHandler Me.KeyUp, AddressOf Form_KeyUp
    End Sub
    'Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
    '    Dim x As New SearchPricePlan
    '    x.Show()
    'End Sub
    Private Sub btnSelect_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelect.Click
        Dim SelectSQL As String
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim dtView As New DataView
        Dim SrchPP As New SearchPricePlan
        PopulateDataset2(dtAdapter, dtSet, sqlSelPP)

        dtView.Table = dtSet.Tables(0)
        If dtView.Table.Rows.Count > 0 Then
            SrchPP.dsList = dtSet
            'SrchPP.UltraGrid1.ActiveRow = SrchPP.UltraGrid1.GetRow(Infragistics.Win.UltraWinGrid.ChildRow.First)
            'SrchPP.UltraGrid1.ActiveRow.Selected = True

            SrchPP.ShowDialog()
            If SrchPP.DialogResult <> DialogResult.OK Then Exit Sub
            Try
                Dim cnt As Integer
                cnt = SrchPP.UltraGrid1.Rows.Count
            Catch Err As System.Exception
                SrchPP = Nothing
                sender.Focus()
                HasErr = True
                Exit Try
            Catch Err2 As System.NullReferenceException
                SrchPP = Nothing
                sender.Focus()
                HasErr = True
                Exit Try
            Catch osqlexception As SqlException
                'Message modified by Michael Pastor
                MsgBox("SQL_Error: " & osqlexception.Message, MsgBoxStyle.Critical, "Critical Error")
                'MsgBox("SQL_Error: " & osqlexception.Message)
                SrchPP = Nothing
                sender.Focus()
                Exit Try
            Finally
                If HasErr = False Then
                    ugRow = SrchPP.UltraGrid1.ActiveRow

                    utSource.Text = ugRow.Cells("Plan_Name").Text
                    utPlanID.Text = ugRow.Cells("PlanID").Text

                End If
                SrchPP = Nothing
            End Try
        End If

    End Sub
    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim planName As String = utTargetName.Text
        Dim sqlSelPPSave As String = "Insert into " & BILLTblPath & "PricePlans(Plan_Name, Charge_Code, PlanTypeCode, From_Zone, To_Zone, Start_Date, End_Date, ModuleName, TableName, ColumnPrefix, ColumnSuffix, Invoice_Title, Taxable, Description) Select '" & utTargetName.Text.Trim & "', Charge_Code, PlanTypeCode, From_Zone, To_Zone, Start_Date, End_Date, ModuleName, TableName, ColumnPrefix, ColumnSuffix, Invoice_Title, Taxable, Description From " & BILLTblPath & "PricePlans where PlanID = " & utPlanID.Text & ""
        Dim sqlSelLastID As String = "Select Top 1 * from " & BILLTblPath & "PricePlans where Plan_Name = '" & utTargetName.Text.Trim & "' order by PlanID DESC"


        If utSource.Text.Trim = "" And Not utTargetName.Text.Trim = "" Then
            'Message modified by Michael Pastor
            MsgBox("Source remains unspecified.", MsgBoxStyle.Exclamation, "Missing Data Input")
            'MsgBox("To SAVE the Price Plan Name input the Source!", MsgBoxStyle.Exclamation, "Copy Price Plan Name Error")
            Exit Sub
        End If
        If utTargetName.Text.Trim = "" And Not utSource.Text.Trim = "" Then
            'Message modified by Michael Pastor
            MsgBox("Target name remains unspecified.", MsgBoxStyle.Exclamation, "Missing Data Input")
            'MsgBox("To SAVE the Price Plan Name create the Target Name!", MsgBoxStyle.Exclamation, "Copy Price Plan Name Error")
            Exit Sub
        End If
        If utSource.Text.Trim = "" And utTargetName.Text.Trim = "" Then
            Exit Sub
        End If
        '''''KArina
        ''''Dim SrchStr As String = " & utTargetName.Text.Trim & "
        ''''SrchStr = SrchStr.Replace(" ", "")
        '''''Karina
        ExecuteQuery(sqlSelPPSave, cmdTrans)

        PopulateDataset2(dtAdapter, dtSet, sqlSelLastID)
        Dim PlanIDLast As Integer = dtSet.Tables(0).Rows(0).Item(0)
        Dim sqlInsPPC As String = "Insert into " & BILLTblPath & "PricePlanCharges (PlanID, From_Range, To_Range, Charge) Select '" & PlanIDLast & "', From_Range, To_Range, Charge from " & BILLTblPath & "PricePlanCharges where PlanID = " & utPlanID.Text & ""
        ExecuteQuery(sqlInsPPC, cmdTrans)
        'Message modified by Michael Pastor
        MsgBox("The Price Plan Name '" & utSource.Text & "' was copied and saved successfully as '" & utTargetName.Text.Trim & "'.", MsgBoxStyle.OKOnly, "Save Successful")
        'MsgBox("The Price Plan Name '" & utSource.Text & "' was copied and saved successfully as '" & utTargetName.Text.Trim & "'!", MsgBoxStyle.OKOnly, "Copy of Plan Price")
        utPlanID.Text = ""
        utSource.Text = ""
        utTargetName.Text = ""
    End Sub

    Private Sub utSource_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles utSource.KeyUp
        TypeAhead(sender, e, BILLTblPath & "PricePlans", "Plan_Name")
    End Sub
    Private Sub utSource_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utSource.Leave
        Dim row As DataRow

        If sender.Modified = False Then Exit Sub

        If sender.text.trim = "" Then
            utPlanID.Text = ""
            sender.text = ""
            Exit Sub
        Else
            If SearchOnLeave(sender, sender, BILLTblPath & "PricePlans", "Plan_Name", "Plan_Name") = False Then
                'MsgBox("Account not found.")
                utSource.Text = ""
                utPlanID.Text = ""
                Exit Sub
            Else
                If ReturnRowByName(utSource.Text, row, BILLTblPath & "PricePlans", , "Plan_Name") Then
                    utPlanID.Text = row("PlanID")
                End If
            End If

            row = Nothing
            sender.Modified = False
        End If
        sender.focus()
    End Sub
    Public Function ReturnRowByName(ByVal Name As String, ByRef dbRow As DataRow, ByVal dbTableName As String, Optional ByVal Condition As String = "", Optional ByVal NameFldName As String = "Name", Optional ByVal AltQuery As String = "") As Boolean
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet

        dbRow = Nothing
        ReturnRowByName = False
        If AltQuery = "" Then
            PopulateDataset2(dtAdapter, dtSet, PrepSelectQuery("Select * from " & dbTableName & " Where " & NameFldName & " = '" & Name & "'", Condition))
        Else
            PopulateDataset2(dtAdapter, dtSet, AltQuery)
        End If

        If dtSet.Tables(0).Rows.Count > 0 Then
            dbRow = dtSet.Tables(0).NewRow
            dbRow = dtSet.Tables(0).Rows(0)
            ReturnRowByName = True
            dtSet = Nothing
            dtAdapter = Nothing
        Else
            dtSet = Nothing
            dtAdapter = Nothing
        End If
    End Function

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If utTargetName.Text = "" And utSource.Text = "" Then
            Exit Sub
        End If
        'Message modified by Michael Pastor
        If MsgBox("Do you want to cancel curent copying of price plan name?", MsgBoxStyle.Exclamation.YesNo, "Data Not Saved") = MsgBoxResult.No Then
            'If MsgBox("Do you want to CANCEL curent Coppying of Price Plan Name?", MsgBoxStyle.YesNo, "Copy Price Plan Name Cancel") = MsgBoxResult.No Then
            Exit Sub
        End If
        EditForm(Me, sqlSelPP, EditAction.CANCEL, cmdTrans)

        utPlanID.Text = ""
        utSource.Text = ""
        utTargetName.Text = ""
    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub CopyPricePlan_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        'Karina, Warn the user on EXITING/CLOSING window when in Edit/New modes.
        If Not utSource.Text = "" Or Not utTargetName.Text = "" Then
            'Message modified by Michael Pastor
            If MessageBox.Show("Data is not saved! Are you sure you want to exit?", "Data Not Saved", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = MsgBoxResult.No Then
                'If MsgBox("Data is not saved! Are you sure that you want to exit?", MsgBoxStyle.YesNo, "Copy Price Plan Warning") = MsgBoxResult.No Then
                e.Cancel = True
                Exit Sub
            End If
        End If

        If Not cmdTrans Is Nothing Then
            EditForm(Me, sqlSelPP, EditAction.CANCEL, cmdTrans)
        End If
    End Sub
End Class
