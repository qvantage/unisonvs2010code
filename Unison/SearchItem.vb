Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors

Public Class SearchItem
    Inherits System.Windows.Forms.Form

    Public SearchQuery As String
    Public dtRow As DataRow
    Dim dtTable As New DataTable()


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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents SrchItem As System.Windows.Forms.TextBox
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.SrchItem = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.btnExit = New System.Windows.Forms.Button()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.AddRange(New System.Windows.Forms.Control() {Me.SrchItem, Me.Label1})
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(440, 72)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'SrchItem
        '
        Me.SrchItem.Location = New System.Drawing.Point(96, 31)
        Me.SrchItem.Name = "SrchItem"
        Me.SrchItem.TabIndex = 1
        Me.SrchItem.Text = ""
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(8, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(80, 16)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Search:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.AddRange(New System.Windows.Forms.Control() {Me.btnExit, Me.btnSearch})
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox2.Location = New System.Drawing.Point(0, 71)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(440, 40)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnExit.Location = New System.Drawing.Point(362, 16)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 21)
        Me.btnExit.TabIndex = 5
        Me.btnExit.Text = "E&xit"
        '
        'btnSearch
        '
        Me.btnSearch.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnSearch.Location = New System.Drawing.Point(3, 16)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(75, 21)
        Me.btnSearch.TabIndex = 0
        Me.btnSearch.Text = "Se&arch"
        '
        'SearchItem
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(440, 111)
        Me.Controls.AddRange(New System.Windows.Forms.Control() {Me.GroupBox2, Me.GroupBox1})
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "SearchItem"
        Me.Text = "Search"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub SearchItem_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If SearchQuery = "" Then
            'Message modified by Michael Pastor
            MsgBox("Search query remains unspecified. Please enter a search query to continue.", MsgBoxStyle.Exclamation, "Missing Data Input")
            '- MsgBox("Search Query not set.")
            Exit Sub
        End If

    End Sub

    Private Sub btnSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSearch.Click
        Dim dtAdapter As SqlDataAdapter
        Dim dtSet As New DataSet()

        If SrchItem.Text.Trim = "" Then
            'Message modified by Michael Pastor
            MsgBox("Search remains unspecified. Please enter something to search to continue.", MsgBoxStyle.Exclamation, "Missing Data Input")
            '- MsgBox("Nothing specified to search.")
            Exit Sub
        End If

        PopulateDataset2(dtAdapter, dtSet, SearchQuery & "'" & SrchItem.Text & "'")
        If dtSet.Tables(0).Rows.Count <> 0 Then
            dtTable = dtSet.Tables(0)

            dtRow = dtTable.Rows(0)

            Me.DialogResult = DialogResult.Cancel
            Me.Close()
        Else
            'Message modified by Michael Pastor
            MsgBox("No results found.", MsgBoxStyle.Exclamation, "Data Unavailable")
            '- MsgBox("No Results Found.")
        End If

    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Dispose()
    End Sub
End Class
