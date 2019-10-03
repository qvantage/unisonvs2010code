Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors

Public Class PricePlanCustomer
    Inherits System.Windows.Forms.Form

    Dim SqlSelect As String = "Select c.Name, c.CustomerId, ppc.PlanID From " & BILLTblPath & "Customer c, " & BILLTblPath & "PricePlanCustomer ppc where c.CustomerID=ppc.CustomerID"
    Dim dtSet As New DataSet
    Dim dtAdapter As SqlDataAdapter
    Dim MeText As String
    Dim cmdTrans As SqlCommand

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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents btnSelectName As System.Windows.Forms.Button
    Friend WithEvents btnSelectID As System.Windows.Forms.Button
    Friend WithEvents utName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents UltraGrid2 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents btnRelieve As System.Windows.Forms.Button
    Friend WithEvents chkSelAllA As System.Windows.Forms.CheckBox
    Friend WithEvents chkSelAllUA As System.Windows.Forms.CheckBox
    Friend WithEvents btnExit As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.utID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.btnSelectID = New System.Windows.Forms.Button
        Me.btnSelectName = New System.Windows.Forms.Button
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.utName = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.UltraGrid2 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.btnAdd = New System.Windows.Forms.Button
        Me.btnRelieve = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.chkSelAllA = New System.Windows.Forms.CheckBox
        Me.chkSelAllUA = New System.Windows.Forms.CheckBox
        Me.Panel1.SuspendLayout()
        CType(Me.utID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGrid2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.utID)
        Me.Panel1.Controls.Add(Me.btnSelectID)
        Me.Panel1.Controls.Add(Me.btnSelectName)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.utName)
        Me.Panel1.Location = New System.Drawing.Point(8, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(488, 56)
        Me.Panel1.TabIndex = 0
        '
        'utID
        '
        Me.utID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utID.Location = New System.Drawing.Point(104, 32)
        Me.utID.MaxLength = 40
        Me.utID.Name = "utID"
        Me.utID.Size = New System.Drawing.Size(100, 21)
        Me.utID.TabIndex = 2
        Me.utID.Tag = ".CustomerID"
        '
        'btnSelectID
        '
        Me.btnSelectID.Location = New System.Drawing.Point(408, 32)
        Me.btnSelectID.Name = "btnSelectID"
        Me.btnSelectID.Size = New System.Drawing.Size(75, 21)
        Me.btnSelectID.TabIndex = 23
        Me.btnSelectID.Text = "Select"
        Me.btnSelectID.Visible = False
        '
        'btnSelectName
        '
        Me.btnSelectName.Location = New System.Drawing.Point(408, 8)
        Me.btnSelectName.Name = "btnSelectName"
        Me.btnSelectName.Size = New System.Drawing.Size(75, 21)
        Me.btnSelectName.TabIndex = 1
        Me.btnSelectName.Text = "Select"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(8, 32)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(96, 16)
        Me.Label2.TabIndex = 19
        Me.Label2.Text = "Customer ID:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(8, 8)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(96, 16)
        Me.Label1.TabIndex = 18
        Me.Label1.Text = "Customer Name:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utName
        '
        Me.utName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utName.Location = New System.Drawing.Point(104, 8)
        Me.utName.MaxLength = 40
        Me.utName.Name = "utName"
        Me.utName.Size = New System.Drawing.Size(300, 21)
        Me.utName.TabIndex = 0
        Me.utName.Tag = ".Name"
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraGrid1.Location = New System.Drawing.Point(8, 64)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(368, 216)
        Me.UltraGrid1.TabIndex = 0
        Me.UltraGrid1.Text = "UnAssigned Price Plans to the Customer"
        '
        'UltraGrid2
        '
        Me.UltraGrid2.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.UltraGrid2.Location = New System.Drawing.Point(384, 64)
        Me.UltraGrid2.Name = "UltraGrid2"
        Me.UltraGrid2.Size = New System.Drawing.Size(368, 216)
        Me.UltraGrid2.TabIndex = 1
        Me.UltraGrid2.Text = "Assigned Price Plans to the Customer"
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(16, 288)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(75, 21)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.Text = "&Add"
        '
        'btnRelieve
        '
        Me.btnRelieve.Location = New System.Drawing.Point(392, 288)
        Me.btnRelieve.Name = "btnRelieve"
        Me.btnRelieve.Size = New System.Drawing.Size(75, 21)
        Me.btnRelieve.TabIndex = 4
        Me.btnRelieve.Text = "&Relieve"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(680, 288)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 21)
        Me.btnExit.TabIndex = 6
        Me.btnExit.Text = "E&xit"
        '
        'chkSelAllA
        '
        Me.chkSelAllA.Location = New System.Drawing.Point(104, 288)
        Me.chkSelAllA.Name = "chkSelAllA"
        Me.chkSelAllA.TabIndex = 3
        Me.chkSelAllA.Text = "Select All"
        '
        'chkSelAllUA
        '
        Me.chkSelAllUA.Location = New System.Drawing.Point(480, 288)
        Me.chkSelAllUA.Name = "chkSelAllUA"
        Me.chkSelAllUA.TabIndex = 5
        Me.chkSelAllUA.Text = "Select All"
        '
        'PricePlanCustomer
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(760, 318)
        Me.Controls.Add(Me.chkSelAllUA)
        Me.Controls.Add(Me.chkSelAllA)
        Me.Controls.Add(Me.btnExit)
        Me.Controls.Add(Me.btnRelieve)
        Me.Controls.Add(Me.btnAdd)
        Me.Controls.Add(Me.UltraGrid2)
        Me.Controls.Add(Me.UltraGrid1)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "PricePlanCustomer"
        Me.Tag = "Customer"
        Me.Text = "Price Plan Customer"
        Me.Panel1.ResumeLayout(False)
        CType(Me.utID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGrid2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub PricePlanCustomer_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.CenterToScreen()

        AddHandler Me.Activated, AddressOf Form_Activated

        Me.KeyPreview = True
        MeText = Me.Text

        utName.Focus()
        SetupCtrlsLength(Me, AppDBName, AppDBUser, AppDBPass)
        AddHandler Me.KeyUp, AddressOf Form_KeyUp
        Group_EnDis(False)
    End Sub

    Private Sub LoadData()
        Dim dtAdapter As SqlDataAdapter
        Dim CritTmp As String
        Dim i As Int32
        Dim HidCols() As String = {"PlanID"}
        Dim SqlSelectUG2 As String = "Select Convert(bit, 0) as CHK, pp.PlanID, pp.Plan_Name, pp.Start_Date, pp.End_Date From " & BILLTblPath & "PricePlans pp, " & BILLTblPath & "PricePlanCustomer ppc, " & BILLTblPath & "Customer c where pp.PlanID=ppc.PlanID and ppc.CustomerID = c.CustomerID and ppc.CustomerID = '" & utID.Text & "'"

        PopulateDataset2(dtAdapter, dtSet, SqlSelectUG2)
        FillUltraGrid(UltraGrid2, dtSet, 1, HidCols) ', HidCols
        'Display Layout of the UltraGrid1
        For i = 1 To dtSet.Tables(0).Columns.Count - 1
            dtSet.Tables(0).Columns(i).ReadOnly = True
        Next
        dtSet.Tables(0).Columns(0).ReadOnly = False

        UltraGrid2.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True
        UltraGrid2.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit

        UltraGrid2.DisplayLayout.GroupByBox.Hidden = False
        UltraGrid2.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        For i = 1 To UltraGrid2.DisplayLayout.Bands(0).Columns.Count - 1
            UltraGrid2.DisplayLayout.Bands(0).Columns(i).TabStop = False
            UltraGrid2.DisplayLayout.Bands(0).Columns(i).CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Next
        'END - Display Layout of the UltraGrid1

        'Collect Plans from UG2 which Customer2 ha2
        Dim count As Int32
        Dim SqlSelectUG1 As String
        Dim SelPlans As String = "("
        For count = 0 To UltraGrid2.Rows.Count - 1
            SelPlans = SelPlans & UltraGrid2.Rows(count).Cells("PlanID").Value & ", "
        Next

        If SelPlans = "(" Then
            'MsgBox("Zip Code was not selected!", MsgBoxStyle.Exclamation)
            SqlSelectUG1 = "Select Convert(bit, 0) as CHK, pp.PlanID, pp.Plan_Name, pp.Start_Date, pp.End_Date From " & BILLTblPath & "PricePlans pp"
        Else
            SelPlans = SelPlans.Substring(0, Len(SelPlans) - 2) & ")"
            SqlSelectUG1 = "Select Convert(bit, 0) as CHK, pp.PlanID, pp.Plan_Name, pp.Start_Date, pp.End_Date From " & BILLTblPath & "PricePlans pp where pp.PlanID not in " & SelPlans & ""

        End If


        'Dim SqlSelectUG1 As String = "Select Distinct Convert(bit, 0) as CHK, pp.PlanID, pp.Plan_Name, pp.Start_Date, pp.End_Date From " & AppTblPath & "PricePlans pp, PricePlanCustomer ppc, Customer c where not pp.PlanID=ppc.PlanID and ppc.CustomerID = c.CustomerID and NOT ppc.CustomerID = " & utID.Text & ""
        PopulateDataset2(dtAdapter, dtSet, SqlSelectUG1)
        FillUltraGrid(UltraGrid1, dtSet, 1, HidCols) ', HidCols
        'Display Layout of the UltraGrid1
        For i = 1 To dtSet.Tables(0).Columns.Count - 1
            dtSet.Tables(0).Columns(i).ReadOnly = True
        Next
        dtSet.Tables(0).Columns(0).ReadOnly = False

        UltraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.True
        UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.Edit

        UltraGrid1.DisplayLayout.GroupByBox.Hidden = False
        UltraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy
        For i = 1 To UltraGrid1.DisplayLayout.Bands(0).Columns.Count - 1
            UltraGrid1.DisplayLayout.Bands(0).Columns(i).TabStop = False
            UltraGrid1.DisplayLayout.Bands(0).Columns(i).CellActivation = Infragistics.Win.UltraWinGrid.Activation.NoEdit
        Next
        'End - Display Layout of the UltraGrid1

        chkSelAllA.Checked = False
        chkSelAllUA.Checked = False
    End Sub

    Private Sub Group_EnDis(ByVal status As Boolean)
        UltraGrid1.Enabled = status
        UltraGrid2.Enabled = status
        Btn_En(status)
    End Sub

    Private Sub Btn_En(ByVal status As Boolean)
        If status = True Then
            UltraGrid1.Enabled = True
            UltraGrid2.Enabled = True
            btnAdd.Enabled = True
            btnRelieve.Enabled = True
            chkSelAllA.Enabled = True
            chkSelAllUA.Enabled = True
        Else
            UltraGrid1.Enabled = False
            UltraGrid2.Enabled = False
            btnAdd.Enabled = False
            btnRelieve.Enabled = False
            chkSelAllA.Enabled = False
            chkSelAllUA.Enabled = False
        End If
    End Sub
    Private Sub btnSelectName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectName.Click, btnSelectID.Click
        Dim SQLSelName, SQLSelID As String
        Dim SrchCustomer As New SearchListings
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow

        If btnSelectName.Focused = True Then
            SQLSelName = "Select Name, CustomerID, Address1, Address2, City, State, Zip, Contact, Phone, CourierCode, LocIDSuffix From " & BILLTblPath & "Customer where Active = 'Y' order by Name"
            PopulateDataset2(dtAdapter, dtSet, SQLSelName)
        Else
            SQLSelID = "Select CustomerID, Name, Address1, Address2, City, State, Zip, Contact, Phone, CourierCode, LocIDSuffix From " & BILLTblPath & "Customer where Active = 'Y' order by CustomerID"
            PopulateDataset2(dtAdapter, dtSet, SQLSelID)
        End If

        dtView.Table = dtSet.Tables(0)
        If dtView.Table.Rows.Count > 0 Then
            SrchCustomer.dsList = dtSet

            SrchCustomer.UltraGrid1.Text = "Price Plan Customers"
            SrchCustomer.Text = "Customer's Information"

            SrchCustomer.ShowDialog()
            If SrchCustomer.DialogResult <> DialogResult.OK Then Exit Sub
            Try
                Dim snt As Integer = SrchCustomer.UltraGrid1.Rows.Count
            Catch Err As System.Exception
                SrchCustomer = Nothing
                sender.Focus()
                HasErr = True
                Exit Try
            Catch Err2 As System.NullReferenceException
                SrchCustomer = Nothing
                sender.Focus()
                HasErr = True
                Exit Try
            Catch osqlexception As SqlException
                MsgBox("SQL_Error: " & osqlexception.Message)
                SrchCustomer = Nothing
                sender.Focus()
                Exit Try
            Finally
                If HasErr = False Then
                    ugRow = SrchCustomer.UltraGrid1.ActiveRow
                    If btnSelectName.Focused = True Then
                        utName.Text = ugRow.Cells("Name").Text
                        utID.Text = ugRow.Cells("CustomerID").Text
                        Dim SqlSelectPlanID As String = "Select c.Name, c.CustomerId, ppc.PlanID From " & BILLTblPath & "Customer c, " & BILLTblPath & "PricePlanCustomer ppc where c.CustomerID=ppc.CustomerID"
                    Else
                        utID.Text = ugRow.Cells("CustomerID").Text
                        utName.Text = ugRow.Cells("Name").Text
                    End If
                    Group_EnDis(True)
                    LoadData()
                End If
                SrchCustomer = Nothing
            End Try
        End If
    End Sub
    Private Sub utID_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles utID.KeyUp
        TypeAhead(sender, e, BILLTblPath & "Customer", "CustomerID")
    End Sub
    Private Sub utName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles utName.KeyUp
        TypeAhead(sender, e, BILLTblPath & "Customer", "Name")
    End Sub
    Private Sub utID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utID.Leave, utName.Leave
        Dim row As DataRow

        If sender.Modified = False Then Exit Sub

        If sender.text.trim = "" Then
            If utID.ContainsFocus = True Then
                utName.Text = ""
            ElseIf utName.ContainsFocus = True Then
                utID.Text = ""
            End If
            sender.text = ""
            Group_EnDis(False)
            UltraGrid1.DataSource = Nothing
            UltraGrid2.DataSource = Nothing
            Exit Sub
        Else
            If utID.ContainsFocus = True Then
                If SearchOnLeave(sender, sender, BILLTblPath & "Customer", "CustomerID", "CustomerID", , , "where Active = 'Y'") = False Then
                    'MsgBox("Account not found.")
                    utID.Text = ""
                    utName.Text = ""
                    Group_EnDis(False)
                    UltraGrid1.DataSource = Nothing
                    UltraGrid2.DataSource = Nothing
                    utID.Focus()
                    Exit Sub
                Else
                    If ReturnRowByID(utID.Text, row, BILLTblPath & "Customer", "", "CustomerID") Then
                        utName.Text = row("Name")
                    End If
                End If
            ElseIf utName.ContainsFocus = True Then
                If SearchOnLeave(sender, sender, BILLTblPath & "Customer", "Name", "Name") = False Then
                    'MsgBox("Account not found.")
                    utID.Text = ""
                    utName.Text = ""
                    Group_EnDis(False)
                    UltraGrid1.DataSource = Nothing
                    UltraGrid2.DataSource = Nothing
                    utName.Focus()
                    Exit Sub
                Else
                    If ReturnRowByName(utName.Text, row, BILLTblPath & "Customer", "where Active = 'Y'", "Name") Then
                        utID.Text = row("CustomerID")
                    End If
                End If
            End If
            Group_EnDis(True)
            LoadData()
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

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click
        Dim i As Int32
        Dim notChecked As Boolean

        For i = 0 To UltraGrid1.Rows.Count - 1
            If UltraGrid1.Rows(i).Cells("CHK").Value = "1" Then
                notChecked = False
                Exit For
            Else
                notChecked = True
            End If
        Next

        If notChecked = True Then
            MsgBox("To Assign Price Plan(s) to the Customer, select Price Plan(s) first!", MsgBoxStyle.Exclamation, "Warning")
            Exit Sub
        Else
            If MsgBox("Are you sure that you want to Assign Price Plan(s) to the selected customer?", MsgBoxStyle.YesNo, "Assigning Price Plan(s) to the Customer!") = MsgBoxResult.Yes Then
                For i = 0 To UltraGrid1.Rows.Count - 1
                    If UltraGrid1.Rows(i).Cells("CHK").Value = "1" Then
                        Dim InsQry As String
                        InsQry = "Insert into " & BILLTblPath & "PricePlanCustomer(PlanID, CustomerID) Select " & UltraGrid1.Rows(i).Cells("PlanID").Text & ", '" & utID.Text & "'"
                        ExecuteQuery(InsQry)
                    End If
                Next
            Else
                Exit Sub
            End If
        End If
        LoadData()

        UltraGrid1.Focus()
        UltraGrid1.ActiveRow = UltraGrid1.Rows.GetRowAtVisibleIndex(0)
    End Sub
    Private Sub btnRelieve_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRelieve.Click
        Dim i As Int32
        Dim notChecked As Boolean

        For i = 0 To UltraGrid2.Rows.Count - 1
            If UltraGrid2.Rows(i).Cells("CHK").Value = "1" Then
                notChecked = False
                Exit For
            Else
                notChecked = True
            End If
        Next

        If notChecked = True Then
            MsgBox("To Relieve/UnAssign Price Plan(s) to the Customer, select Price Plan(s) first!", MsgBoxStyle.Exclamation, "Warning")
            Exit Sub
        Else
            If MsgBox("Are you sure that you want to Relieve/Assign Price Plan(s) to the selected customer?", MsgBoxStyle.YesNo, "Assigning Price Plan(s) to the Customer!") = MsgBoxResult.Yes Then
                For i = 0 To UltraGrid2.Rows.Count - 1
                    If UltraGrid2.Rows(i).Cells("CHK").Value = "1" Then
                        Dim DelQry As String
                        DelQry = "Delete " & BILLTblPath & "PricePlanCustomer where PlanID = " & UltraGrid2.Rows(i).Cells("PlanID").Text & " and CustomerID = '" & utID.Text & "'"
                        ExecuteQuery(DelQry)
                    End If
                Next
            Else
                Exit Sub
            End If
        End If
        LoadData()

        UltraGrid2.Focus()
        UltraGrid2.ActiveRow = UltraGrid2.Rows.GetRowAtVisibleIndex(0)
    End Sub

    Private Sub chkSelAllA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSelAllA.CheckedChanged
        Dim i As Int32
        For i = 0 To UltraGrid1.Rows.Count - 1
            UltraGrid1.Rows(i).Cells("CHK").Value = chkSelAllA.Checked
            UltraGrid1.Rows(i).Update()
        Next
    End Sub

    Private Sub chkSelAllUA_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkSelAllUA.CheckedChanged
        Dim i As Int32
        For i = 0 To UltraGrid2.Rows.Count - 1
            UltraGrid2.Rows(i).Cells("CHK").Value = chkSelAllUA.Checked
            UltraGrid2.Rows(i).Update()
        Next

    End Sub


    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub
    Private Sub PricePlanCustomer_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If Not cmdTrans Is Nothing Then
            If EditForm(Me, SqlSelect, EditAction.CANCEL, cmdTrans) Then
                Group_EnDis(False)
                sender.text = "&Edit"
            Else
            End If
        End If
    End Sub
End Class
