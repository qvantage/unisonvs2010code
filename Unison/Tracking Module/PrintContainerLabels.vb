Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors
Imports CrystalDecisions.CrystalReports.ViewerObjectModel
Imports CrystalDecisions.Windows.Forms
Imports CrystalDecisions.CrystalReports.Engine
Imports CrystalDecisions.Shared

Public Class PrintContainerLabels
    Inherits System.Windows.Forms.Form

    Dim MeText As String

    Dim dtSet As New DataSet

    Private m_bCalledByWeightPlan As Boolean = False
    Public Property CalledByWeightPlan() As Boolean
        Get
            Return m_bCalledByWeightPlan
        End Get
        Set(ByVal Value As Boolean)
            m_bCalledByWeightPlan = Value
        End Set
    End Property

    Private m_iFromCLRowID As Integer = 0
    Public ReadOnly Property FromCLRowID() As Integer
        Get
            Return m_iFromCLRowID
        End Get
    End Property

    Private m_iLabelsAdded As Integer = 0

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
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents utFrAcctID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utFrAcct As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnFrAcct As System.Windows.Forms.Button
    Friend WithEvents utFrLoc As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utFrLocID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnFrLoc As System.Windows.Forms.Button
    Friend WithEvents btnPrint As System.Windows.Forms.Button
    Friend WithEvents utFrAddrID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utToAddrID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utToLocID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnToLoc As System.Windows.Forms.Button
    Friend WithEvents utToLoc As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utToAcctID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utToAcct As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnToAcct As System.Windows.Forms.Button
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnAdd As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents dUpDn As System.Windows.Forms.DomainUpDown
    Friend WithEvents btnAssign As System.Windows.Forms.Button
    Friend WithEvents btnCancel As System.Windows.Forms.Button
    Friend WithEvents cbThirdPartyFormat As System.Windows.Forms.CheckBox
    Friend WithEvents uopAcctType As Infragistics.Win.UltraWinEditors.UltraOptionSet
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim ValueListItem1 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Dim ValueListItem2 As Infragistics.Win.ValueListItem = New Infragistics.Win.ValueListItem
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cbThirdPartyFormat = New System.Windows.Forms.CheckBox
        Me.btnCancel = New System.Windows.Forms.Button
        Me.btnAssign = New System.Windows.Forms.Button
        Me.dUpDn = New System.Windows.Forms.DomainUpDown
        Me.Label3 = New System.Windows.Forms.Label
        Me.btnPrint = New System.Windows.Forms.Button
        Me.uopAcctType = New Infragistics.Win.UltraWinEditors.UltraOptionSet
        Me.Label11 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnAdd = New System.Windows.Forms.Button
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.utToAddrID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label6 = New System.Windows.Forms.Label
        Me.utToLocID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.btnToLoc = New System.Windows.Forms.Button
        Me.utToLoc = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label7 = New System.Windows.Forms.Label
        Me.utToAcctID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utToAcct = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.btnToAcct = New System.Windows.Forms.Button
        Me.Label8 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.utFrAddrID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label4 = New System.Windows.Forms.Label
        Me.utFrLocID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.btnFrLoc = New System.Windows.Forms.Button
        Me.utFrLoc = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label2 = New System.Windows.Forms.Label
        Me.utFrAcctID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utFrAcct = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.btnFrAcct = New System.Windows.Forms.Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.GroupBox1.SuspendLayout()
        CType(Me.uopAcctType, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.utToAddrID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utToLocID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utToLoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utToAcctID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utToAcct, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.utFrAddrID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utFrLocID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utFrLoc, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utFrAcctID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utFrAcct, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cbThirdPartyFormat)
        Me.GroupBox1.Controls.Add(Me.btnCancel)
        Me.GroupBox1.Controls.Add(Me.btnAssign)
        Me.GroupBox1.Controls.Add(Me.dUpDn)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.btnPrint)
        Me.GroupBox1.Controls.Add(Me.uopAcctType)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(0, 437)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(680, 72)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'cbThirdPartyFormat
        '
        Me.cbThirdPartyFormat.Location = New System.Drawing.Point(296, 40)
        Me.cbThirdPartyFormat.Name = "cbThirdPartyFormat"
        Me.cbThirdPartyFormat.Size = New System.Drawing.Size(168, 24)
        Me.cbThirdPartyFormat.TabIndex = 4
        Me.cbThirdPartyFormat.Text = "Print in 3rd Party Format"
        '
        'btnCancel
        '
        Me.btnCancel.Location = New System.Drawing.Point(544, 16)
        Me.btnCancel.Name = "btnCancel"
        Me.btnCancel.Size = New System.Drawing.Size(128, 21)
        Me.btnCancel.TabIndex = 5
        Me.btnCancel.Text = "E&xit"
        '
        'btnAssign
        '
        Me.btnAssign.Location = New System.Drawing.Point(8, 16)
        Me.btnAssign.Name = "btnAssign"
        Me.btnAssign.Size = New System.Drawing.Size(128, 21)
        Me.btnAssign.TabIndex = 0
        Me.btnAssign.Text = "Assign Only"
        '
        'dUpDn
        '
        Me.dUpDn.Location = New System.Drawing.Point(232, 40)
        Me.dUpDn.Name = "dUpDn"
        Me.dUpDn.Size = New System.Drawing.Size(48, 20)
        Me.dUpDn.Sorted = True
        Me.dUpDn.TabIndex = 2
        Me.dUpDn.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(144, 40)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(80, 16)
        Me.Label3.TabIndex = 157
        Me.Label3.Text = "No. Of Copies:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnPrint
        '
        Me.btnPrint.Location = New System.Drawing.Point(152, 16)
        Me.btnPrint.Name = "btnPrint"
        Me.btnPrint.Size = New System.Drawing.Size(128, 21)
        Me.btnPrint.TabIndex = 1
        Me.btnPrint.Text = "&Print"
        '
        'uopAcctType
        '
        Appearance1.TextTrimming = Infragistics.Win.TextTrimming.EllipsisWord
        Me.uopAcctType.Appearance = Appearance1
        Me.uopAcctType.BorderStyle = Infragistics.Win.UIElementBorderStyle.None
        Me.uopAcctType.CheckedIndex = 0
        Me.uopAcctType.ItemAppearance = Appearance2
        ValueListItem1.DataValue = ""
        ValueListItem1.DisplayText = "TPC Account"
        ValueListItem2.DataValue = ""
        ValueListItem2.DisplayText = "TTI Account"
        Me.uopAcctType.Items.Add(ValueListItem1)
        Me.uopAcctType.Items.Add(ValueListItem2)
        Me.uopAcctType.ItemSpacingVertical = 7
        Me.uopAcctType.Location = New System.Drawing.Point(296, 16)
        Me.uopAcctType.Name = "uopAcctType"
        Me.uopAcctType.Size = New System.Drawing.Size(168, 25)
        Me.uopAcctType.TabIndex = 3
        Me.uopAcctType.Text = "TPC Account"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(16, 72)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(72, 16)
        Me.Label11.TabIndex = 141
        Me.Label11.Text = "Location:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnAdd)
        Me.GroupBox2.Controls.Add(Me.GroupBox5)
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(680, 216)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'btnAdd
        '
        Me.btnAdd.Location = New System.Drawing.Point(544, 184)
        Me.btnAdd.Name = "btnAdd"
        Me.btnAdd.Size = New System.Drawing.Size(128, 21)
        Me.btnAdd.TabIndex = 2
        Me.btnAdd.Text = "&Add To List"
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.utToAddrID)
        Me.GroupBox5.Controls.Add(Me.Label6)
        Me.GroupBox5.Controls.Add(Me.utToLocID)
        Me.GroupBox5.Controls.Add(Me.btnToLoc)
        Me.GroupBox5.Controls.Add(Me.utToLoc)
        Me.GroupBox5.Controls.Add(Me.Label7)
        Me.GroupBox5.Controls.Add(Me.utToAcctID)
        Me.GroupBox5.Controls.Add(Me.utToAcct)
        Me.GroupBox5.Controls.Add(Me.btnToAcct)
        Me.GroupBox5.Controls.Add(Me.Label8)
        Me.GroupBox5.Controls.Add(Me.Label9)
        Me.GroupBox5.Location = New System.Drawing.Point(344, 24)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(328, 152)
        Me.GroupBox5.TabIndex = 1
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Address 2:"
        '
        'utToAddrID
        '
        Me.utToAddrID.Enabled = False
        Me.utToAddrID.Location = New System.Drawing.Point(272, 102)
        Me.utToAddrID.Name = "utToAddrID"
        Me.utToAddrID.Size = New System.Drawing.Size(24, 21)
        Me.utToAddrID.TabIndex = 155
        Me.utToAddrID.Tag = ""
        Me.utToAddrID.Visible = False
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(40, 102)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 23)
        Me.Label6.TabIndex = 156
        Me.Label6.Text = "Loc.ID:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utToLocID
        '
        Me.utToLocID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utToLocID.Enabled = False
        Me.utToLocID.Location = New System.Drawing.Point(96, 102)
        Me.utToLocID.Name = "utToLocID"
        Me.utToLocID.Size = New System.Drawing.Size(72, 21)
        Me.utToLocID.TabIndex = 4
        Me.utToLocID.Tag = ""
        '
        'btnToLoc
        '
        Me.btnToLoc.Location = New System.Drawing.Point(184, 102)
        Me.btnToLoc.Name = "btnToLoc"
        Me.btnToLoc.Size = New System.Drawing.Size(80, 21)
        Me.btnToLoc.TabIndex = 5
        Me.btnToLoc.Text = "Se&lect"
        '
        'utToLoc
        '
        Me.utToLoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utToLoc.Location = New System.Drawing.Point(96, 72)
        Me.utToLoc.Name = "utToLoc"
        Me.utToLoc.Size = New System.Drawing.Size(216, 21)
        Me.utToLoc.TabIndex = 3
        Me.utToLoc.Tag = ""
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(38, 40)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(56, 23)
        Me.Label7.TabIndex = 146
        Me.Label7.Text = "Acct.ID:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utToAcctID
        '
        Me.utToAcctID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utToAcctID.Location = New System.Drawing.Point(96, 40)
        Me.utToAcctID.Name = "utToAcctID"
        Me.utToAcctID.Size = New System.Drawing.Size(72, 21)
        Me.utToAcctID.TabIndex = 1
        Me.utToAcctID.Tag = ""
        '
        'utToAcct
        '
        Me.utToAcct.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utToAcct.Location = New System.Drawing.Point(96, 16)
        Me.utToAcct.Name = "utToAcct"
        Me.utToAcct.Size = New System.Drawing.Size(216, 21)
        Me.utToAcct.TabIndex = 0
        Me.utToAcct.Tag = ""
        '
        'btnToAcct
        '
        Me.btnToAcct.Location = New System.Drawing.Point(184, 43)
        Me.btnToAcct.Name = "btnToAcct"
        Me.btnToAcct.Size = New System.Drawing.Size(80, 21)
        Me.btnToAcct.TabIndex = 2
        Me.btnToAcct.Text = "Se&lect"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(22, 18)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(72, 16)
        Me.Label8.TabIndex = 142
        Me.Label8.Text = "Account:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(16, 72)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(72, 16)
        Me.Label9.TabIndex = 141
        Me.Label9.Text = "Location:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.utFrAddrID)
        Me.GroupBox4.Controls.Add(Me.Label4)
        Me.GroupBox4.Controls.Add(Me.utFrLocID)
        Me.GroupBox4.Controls.Add(Me.btnFrLoc)
        Me.GroupBox4.Controls.Add(Me.utFrLoc)
        Me.GroupBox4.Controls.Add(Me.Label2)
        Me.GroupBox4.Controls.Add(Me.utFrAcctID)
        Me.GroupBox4.Controls.Add(Me.utFrAcct)
        Me.GroupBox4.Controls.Add(Me.btnFrAcct)
        Me.GroupBox4.Controls.Add(Me.Label1)
        Me.GroupBox4.Controls.Add(Me.Label11)
        Me.GroupBox4.Location = New System.Drawing.Point(8, 24)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(328, 152)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "Address 1:"
        '
        'utFrAddrID
        '
        Me.utFrAddrID.Enabled = False
        Me.utFrAddrID.Location = New System.Drawing.Point(272, 102)
        Me.utFrAddrID.Name = "utFrAddrID"
        Me.utFrAddrID.Size = New System.Drawing.Size(24, 21)
        Me.utFrAddrID.TabIndex = 155
        Me.utFrAddrID.Tag = ""
        Me.utFrAddrID.Visible = False
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(40, 102)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(56, 23)
        Me.Label4.TabIndex = 156
        Me.Label4.Text = "Loc.ID:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utFrLocID
        '
        Me.utFrLocID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utFrLocID.Enabled = False
        Me.utFrLocID.Location = New System.Drawing.Point(96, 102)
        Me.utFrLocID.Name = "utFrLocID"
        Me.utFrLocID.Size = New System.Drawing.Size(72, 21)
        Me.utFrLocID.TabIndex = 4
        Me.utFrLocID.Tag = ""
        '
        'btnFrLoc
        '
        Me.btnFrLoc.Location = New System.Drawing.Point(184, 102)
        Me.btnFrLoc.Name = "btnFrLoc"
        Me.btnFrLoc.Size = New System.Drawing.Size(80, 21)
        Me.btnFrLoc.TabIndex = 5
        Me.btnFrLoc.Text = "Se&lect"
        '
        'utFrLoc
        '
        Me.utFrLoc.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utFrLoc.Location = New System.Drawing.Point(96, 72)
        Me.utFrLoc.Name = "utFrLoc"
        Me.utFrLoc.Size = New System.Drawing.Size(216, 21)
        Me.utFrLoc.TabIndex = 3
        Me.utFrLoc.Tag = ""
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(38, 40)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(56, 23)
        Me.Label2.TabIndex = 146
        Me.Label2.Text = "Acct.ID:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utFrAcctID
        '
        Me.utFrAcctID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utFrAcctID.Location = New System.Drawing.Point(96, 40)
        Me.utFrAcctID.Name = "utFrAcctID"
        Me.utFrAcctID.Size = New System.Drawing.Size(72, 21)
        Me.utFrAcctID.TabIndex = 1
        Me.utFrAcctID.Tag = ""
        '
        'utFrAcct
        '
        Me.utFrAcct.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utFrAcct.Location = New System.Drawing.Point(96, 16)
        Me.utFrAcct.Name = "utFrAcct"
        Me.utFrAcct.Size = New System.Drawing.Size(216, 21)
        Me.utFrAcct.TabIndex = 0
        Me.utFrAcct.Tag = ""
        '
        'btnFrAcct
        '
        Me.btnFrAcct.Location = New System.Drawing.Point(184, 43)
        Me.btnFrAcct.Name = "btnFrAcct"
        Me.btnFrAcct.Size = New System.Drawing.Size(80, 21)
        Me.btnFrAcct.TabIndex = 2
        Me.btnFrAcct.Text = "Se&lect"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(22, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 142
        Me.Label1.Text = "Account:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGrid1.Location = New System.Drawing.Point(0, 216)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(680, 221)
        Me.UltraGrid1.TabIndex = 1
        Me.UltraGrid1.Text = "Labels To Be Printed"
        '
        'PrintContainerLabels
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(680, 509)
        Me.Controls.Add(Me.UltraGrid1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Name = "PrintContainerLabels"
        Me.Text = "Create Pouch Labels"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.uopAcctType, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.utToAddrID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utToLocID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utToLoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utToAcctID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utToAcct, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        CType(Me.utFrAddrID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utFrLocID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utFrLoc, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utFrAcctID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utFrAcct, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub PrintContainerLabels_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim i As Int32

        AddHandler Me.Activated, AddressOf Form_Activated
        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = TRCTblPath & Me.Tag
            End If
        End If

        Me.CenterToScreen()

        Me.KeyPreview = True
        MeText = Me.Text

        ' Set each control's length based on DB size
        'SetupCtrlsLength(Me)

        AddHandler Me.KeyUp, AddressOf Form_KeyUp
        AddHandler dUpDn.KeyPress, AddressOf Value_Int_KeyPress
        'AddHandler utStartMile.KeyPress, AddressOf Value_Int_KeyPress
        'AddHandler utInvoiceNo.KeyPress, AddressOf Value_Int_KeyPress
        '
        'cmdTrans = Nothing

        utFrAcct.MaxLength = 40
        utFrAcct.Enabled = True
        btnFrAcct.Enabled = True
        utFrAcctID.MaxLength = 10

        utToAcct.MaxLength = 40
        utToAcct.Enabled = True
        btnToAcct.Enabled = True
        utToAcctID.MaxLength = 10

        utFrLoc.MaxLength = 40
        utFrLocID.Enabled = False
        utFrLoc.Enabled = False
        btnFrLoc.Enabled = False
        utFrLocID.MaxLength = 10

        utToLoc.MaxLength = 40
        utToLoc.Enabled = False
        utToLocID.Enabled = False
        btnToLoc.Enabled = False
        utToLocID.MaxLength = 10

        UltraGrid1.Text = "Labels To Be Printed"
        UltraGrid1.DisplayLayout.Override.AllowUpdate = Infragistics.Win.DefaultableBoolean.False
        UltraGrid1.DisplayLayout.Override.CellClickAction = Infragistics.Win.UltraWinGrid.CellClickAction.RowSelect
        dUpDn.Sorted = False
        For i = 999 To 1 Step -1
            dUpDn.Items.Add(i)
        Next
        dUpDn.Text = "1"
        dUpDn.DownButton()

        If m_bCalledByWeightPlan Then
            btnAssign.Visible = True
            btnPrint.Visible = False
            'btnPrint.Text = "Assign and Print"
            Label3.Visible = False
            dUpDn.Visible = False

            btnCancel.Text = "Cancel"
            'UltraGrid1.Text = "Labels To Be Printed and/or Assigned"
            cbThirdPartyFormat.Visible = False
            UltraGrid1.Text = "Labels To Be Assigned"
        Else
            btnAssign.Visible = False
            btnPrint.Text = "Print"
        End If

    End Sub

    Private Sub utAcct_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utFrAcct.Leave, utToAcct.Leave
        Dim row As DataRow

        Dim gAcctID, gAcct As Infragistics.Win.UltraWinEditors.UltraTextEditor

        Select Case sender.name
            Case "utFrAcct"
                gAcctID = utFrAcctID
                gAcct = utFrAcct

            Case "utToAcct"
                gAcctID = utToAcctID
                gAcct = utToAcct

        End Select

        'Karina
        ''Karina
        'If utFrAcctID.Modified = True Or utFrAcct.Modified = True Then
        '    utFrLoc.ResetText()
        '    utFrLocID.ResetText()
        'End If
        ''Karina
        'If utToAcctID.Modified = True Or utToAcct.Modified = True Then
        '    utToLoc.ResetText()
        '    utToLocID.ResetText()
        'End If

        'If sender.Modified = False Then
        '    Exit Sub
        'Else
        'End If
        'If sender.text.Trim = "" Then Exit Sub 'Karina added and commented under
        'Karina added
        'If gAcctID.Modified = True Or gAcct.Modified = True Then
        '    utFrLoc.ResetText()
        '    utFrLocID.ResetText()
        'End If
        'utFrLoc.ResetText()
        'utFrLocID.ResetText()
        'utToLoc.ResetText()
        'utToLocID.ResetText()

        If sender.text.trim = "" Then
            gAcctID.Text = ""
            sender.text = ""
            'btnSave.Enabled = False
        Else
            ' This for Accounts With Numbers Only Name!!
            'If IsNumeric(sender.text) Then
            '    sender.text = "?" & sender.text
            '    sender.modified = True
            'End If
            If SearchOnLeave(sender, gAcctID, TRCTblPath & "Customer", "CustomerID", "Name", "*", "Accounts", " Where Active = 'Y'") Then
                'If ReturnRowByID(utTruckInventID.Text, row, "TrucksManagement.dbo.Inventory", "", "Truck_Invent_ID") Then
                '    'utLicPlate.Text = row("Lic_Plate")
                '    'utTruckInventID.Text = row("Truck_Invent_ID")
                '    row = Nothing
                'Else
                '    MsgBox("Truck Not Found.")
                '    utTruckInventID.Text = ""
                '    utTruckID.Text = ""
                'End If
            Else
                'MsgBox("Truck Not Found.")
                gAcctID.Text = ""
                gAcct.Text = ""
                'sender.undo() 'Karina
                'sender.ClearUndo() 'Karina
                'sender.Modified = False 'Karina
                sender.focus()
            End If
        End If
        sender.Modified = False
        'Karina
        'sender.ResetText()
        'sender.Focus()


    End Sub

    Private Sub utAcct_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles utFrAcct.KeyUp, utToAcct.KeyUp
        TypeAhead(sender, e, TRCTblPath & "Customer", "Name", " Where Active = 'Y'")
    End Sub

    Private Sub utAcctID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utFrAcctID.Leave, utToAcctID.Leave
        Dim row As DataRow

        Dim gAcctID, gAcct As Infragistics.Win.UltraWinEditors.UltraTextEditor




        Select Case sender.name
            Case "utFrAcctID"
                gAcctID = utFrAcctID
                gAcct = utFrAcct
            Case "utToAcctID"
                gAcctID = utToAcctID
                gAcct = utToAcct
        End Select



        If sender.Modified = False Then Exit Sub
        'Karina
        ' sender.Modified = False


        If sender.text.trim = "" Then
            gAcct.Text = ""
            sender.text = ""
            'btnSave.Enabled = False
        Else
            ' This for Accounts With Numbers Only Name!!
            'If IsNumeric(sender.text) Then
            '    sender.text = "?" & sender.text
            '    sender.modified = True
            'End If
            If SearchOnLeave(sender, gAcctID, TRCTblPath & "Customer", "CustomerID", "CustomerID", "*", "Accounts", " Where Active = 'Y'") Then
                If ReturnRowByID(gAcctID.Text, row, TRCTblPath & "Customer", "", "CustomerID") Then
                    gAcct.Text = row("Name")
                    row = Nothing
                Else
                    MsgBox("Account Not Found.")
                    gAcctID.Text = ""
                    gAcct.Text = ""
                End If
            Else
                'MsgBox("Truck Not Found.")
                gAcctID.Text = ""
                gAcct.Text = ""
                sender.focus()
            End If
        End If
        sender.Modified = False

    End Sub

    Private Sub btnAcct_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFrAcct.Click, btnToAcct.Click
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow

        Dim gAcctID, gAcct As Infragistics.Win.UltraWinEditors.UltraTextEditor

        Select Case sender.name
            Case "btnFrAcct"
                gAcctID = utFrAcctID
                gAcct = utFrAcct
            Case "btnToAcct"
                gAcctID = utToAcctID
                gAcct = utToAcct
        End Select


        SelectSQL = "Select * from " & TRCTblPath & "Customer i WHERE (Active = 'Y') order by Name"

        PopulateDataset2(dtAdapter, dtSet, SelectSQL)
        dtView.Table = dtSet.Tables(0)
        If dtView.Table.Rows.Count > 0 Then
            Dim Srch As New SearchListings
            Srch.dsList = dtSet

            Srch.UltraGrid1.Text = "Truck Providers"
            Srch.Text = "Truck Providers"
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
                    'AcctName.Text = ugRow.Cells("Name").Text
                    gAcct.Text = ugRow.Cells("Name").Text
                    gAcctID.Text = ugRow.Cells("CustomerID").Text
                    Srch = Nothing
                    gAcct.Modified = False
                    gAcctID.Modified = False

                    'utProviderID.Modified = True
                    'Karina uncommented
                    'utFrAcctID.Leave, utToAcctID.Leave
                    'Dim ev As New System.EventArgs
                    'utAcctID_Leave(utFrAcctID, ev)
                    ' utAcctID_Leave(utFrAcctID, ev)
                End If
            End Try
        End If



    End Sub


    Private Sub btnFrLoc_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFrLoc.Click, btnToLoc.Click
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim gLocID, gLoc, gAddrID, gAcctID As Infragistics.Win.UltraWinEditors.UltraTextEditor

        If utFrAcctID.Text.Trim = "" Then
            MsgBox("From Account not Selected.")
            Exit Sub
        End If

        Select Case sender.name
            Case "btnFrLoc"
                gLocID = utFrLocID
                gLoc = utFrLoc
                gAddrID = utFrAddrID
                gAcctID = utFrAcctID
            Case "btnToLoc"
                gLocID = utToLocID
                gLoc = utToLoc
                gAddrID = utToAddrID
                gAcctID = utToAcctID
        End Select


        SelectSQL = "Select * from " & TRCTblPath & "Location i WHERE (Active = 'Y') AND CustomerID = '" & gAcctID.Text.Trim & "' order by Name"

        PopulateDataset2(dtAdapter, dtSet, SelectSQL)
        dtView.Table = dtSet.Tables(0)
        If dtView.Table.Rows.Count > 0 Then
            Dim Srch As New SearchListings
            Srch.dsList = dtSet

            Srch.UltraGrid1.Text = "Truck Providers"
            Srch.Text = "Truck Providers"
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

                    gLoc.Text = ugRow.Cells("Name").Text
                    gLocID.Text = ugRow.Cells("LocationID").Text
                    gAddrID.Text = ugRow.Cells("AddressID").Text

                    Srch = Nothing
                    gLoc.Modified = False
                    gLocID.Modified = False
                    gAddrID.Modified = False
                    'utProviderID.Modified = True
                    'Dim ev As New System.EventArgs
                    'utInventID_Leave(utInventID, ev)
                End If
            End Try
        End If
    End Sub

    Private Sub utPoint_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utFrLoc.Leave, utToLoc.Leave
        Dim row As DataRow
        Dim gLocID, gLoc, gAddrID, gAcctID As Infragistics.Win.UltraWinEditors.UltraTextEditor

        Select Case sender.name
            Case "utFrLoc"
                gLocID = utFrLocID
                gLoc = utFrLoc
                gAddrID = utFrAddrID
                gAcctID = utFrAcctID
            Case "utToLoc"
                gLocID = utToLocID
                gLoc = utToLoc
                gAddrID = utToAddrID
                gAcctID = utToAcctID
        End Select
        If sender.Modified = False Then Exit Sub

        If sender.text.trim = "" Then
            gLocID.Text = ""
            gAddrID.Text = ""
            sender.text = ""
            'btnSave.Enabled = False
        Else
            ' This for Accounts With Numbers Only Name!!
            If IsNumeric(sender.text) Then
                sender.text = "?" & sender.text
                sender.modified = True
            End If
            If SearchOnLeave(sender, gAddrID, TRCTblPath & "Location", "AddressID", "Name", "*", "Locations", " Where Active = 'Y' AND CustomerID = '" & gAcctID.Text.Trim & "'") Then
                If ReturnRowByID(gAddrID.Text, row, TRCTblPath & "Location", "", "AddressID") Then
                    gLoc.Text = row("Name")
                    gLocID.Text = row("LocationID")
                    row = Nothing
                Else
                    MsgBox("Point Not Found.")
                    gLoc.Text = ""
                    gLocID.Text = ""
                    gAddrID.Text = ""
                End If
            Else
                'MsgBox("Truck Not Found.")
                gLoc.Text = ""
                gLocID.Text = ""
                gAddrID.Text = ""
                sender.focus()
            End If
        End If
        sender.Modified = False
    End Sub

    Private Sub utPoint_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles utFrLoc.KeyUp, utToLoc.KeyUp
        Dim gLocID, gLoc, gAddrID, gAcctID As Infragistics.Win.UltraWinEditors.UltraTextEditor

        Select Case sender.name
            Case "utFrLoc"
                gLocID = utFrLocID
                gLoc = utFrLoc
                gAddrID = utFrAddrID
                gAcctID = utFrAcctID
            Case "utToLoc"
                gLocID = utToLocID
                gLoc = utToLoc
                gAddrID = utToAddrID
                gAcctID = utToAcctID
        End Select

        TypeAhead(sender, e, TRCTblPath & "Location", "Name", " Where Active = 'Y' AND CustomerID = '" & gAcctID.Text.Trim & "'")
    End Sub

    Private Sub utLocID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles utFrLocID.Leave, utToLocID.Leave
        Dim row As DataRow
        Dim gLocID, gLoc, gAddrID, gAcctID As Infragistics.Win.UltraWinEditors.UltraTextEditor

        Select Case sender.name
            Case "utFrLocID"
                gLocID = utFrLocID
                gLoc = utFrLoc
                gAddrID = utFrAddrID
                gAcctID = utFrAcctID
            Case "utToLocID"
                gLocID = utToLocID
                gLoc = utToLoc
                gAddrID = utToAddrID
                gAcctID = utToAcctID
        End Select

        If sender.Modified = False Then Exit Sub

        If sender.text.trim = "" Then
            gLoc.Text = ""
            gAddrID.Text = ""
            sender.text = ""
            'btnSave.Enabled = False
        Else
            ' This for Accounts With Numbers Only Name!!
            If IsNumeric(sender.text) Then
                sender.text = "?" & sender.text
                sender.modified = True
            End If
            If SearchOnLeave(sender, gAddrID, TRCTblPath & "Location", "AddressID", "LocationID", "*", "Locations", " Where Active = 'Y' AND CustomerID = '" & gAcctID.Text.Trim & "'") Then
                If ReturnRowByID(gAddrID.Text, row, TRCTblPath & "Location", "", "AddressID") Then
                    gLoc.Text = row("Name")
                    row = Nothing
                Else
                    MsgBox("Account Not Found.")
                    gLoc.Text = ""
                    gLocID.Text = ""
                    gAddrID.Text = ""
                End If
            Else
                'MsgBox("Truck Not Found.")
                gLoc.Text = ""
                gLocID.Text = ""
                gAddrID.Text = ""
                sender.focus()
            End If
        End If

        sender.Modified = False


    End Sub

    Private Sub utFrAcctID_ValueChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles utFrAcctID.ValueChanged, utToAcctID.ValueChanged
        'Private Sub utFrAcctID_ValueChanged(ByVal sender As Object)
        Dim gLocID, gLoc, gAddrID As Infragistics.Win.UltraWinEditors.UltraTextEditor
        Dim gBtn As Button

        Select Case sender.name
            Case "utFrAcctID"
                gLocID = utFrLocID
                gLoc = utFrLoc
                gAddrID = utFrAddrID
                gBtn = btnFrLoc
            Case "utToAcctID"
                gLocID = utToLocID
                gLoc = utToLoc
                gAddrID = utToAddrID
                gBtn = btnToLoc
        End Select

        ''Karina - empty location fields, while changing company
        'utFrLoc.Text = ""
        'utFrLocID.Text = ""


        If sender.text.trim = "" Then
            gLoc.Enabled = False
            gLocID.Enabled = False
            gBtn.Enabled = False
            gAddrID.Text = ""
            gLoc.Text = ""
            gLocID.Text = ""
        Else
            gAddrID.Text = ""
            gLoc.Text = ""
            gLocID.Text = ""
            gLoc.Enabled = True
            gLocID.Enabled = True
            gBtn.Enabled = True
        End If
    End Sub

    Private Sub btnAdd_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAdd.Click

        If (m_bCalledByWeightPlan) And (m_iLabelsAdded > 0) Then
            MsgBox("You can only assign 1 movement to a weight plan.")
            Exit Sub
        End If

        Dim dtTable As DataTable
        Dim row As DataRow
        Dim col As DataColumn
        If utFrLocID.Text.Trim = "" Or utToLocID.Text.Trim = "" Then
            MsgBox("Incomplete information.")
            Exit Sub
        End If
        If dtSet.Tables.Count <= 0 Then
            dtTable = dtSet.Tables.Add("Labels")
            col = New DataColumn("FrAcctID", GetType(System.String))
            col.MaxLength = 10
            dtTable.Columns.Add(col)

            col = New DataColumn("FrAcct", GetType(System.String))
            col.MaxLength = 70
            dtTable.Columns.Add(col)

            col = dtTable.Columns.Add("FrLocID", GetType(System.String))
            col.MaxLength = 10
            col = dtTable.Columns.Add("FrLoc", GetType(System.String))
            col.MaxLength = 70

            col = dtTable.Columns.Add("ToAcctID", GetType(System.String))
            col.MaxLength = 10
            col = dtTable.Columns.Add("ToAcct", GetType(System.String))
            col.MaxLength = 70

            col = dtTable.Columns.Add("ToLocID", GetType(System.String))
            col.MaxLength = 10
            col = dtTable.Columns.Add("ToLoc", GetType(System.String))
            col.MaxLength = 70
        Else
            dtTable = dtSet.Tables(0)
        End If
        row = dtTable.NewRow
        row("FrAcctID") = utFrAcctID.Text
        row("FrAcct") = utFrAcct.Text

        row("FrLocID") = utFrLocID.Text
        row("FrLoc") = utFrLoc.Text

        row("ToAcctID") = utToAcctID.Text
        row("ToAcct") = utToAcct.Text

        row("ToLocID") = utToLocID.Text
        row("ToLoc") = utToLoc.Text

        dtTable.Rows.Add(row)
        If UltraGrid1.DataSource Is Nothing Then
            Dim EvenRowApp As New Infragistics.Win.Appearance

            EvenRowApp.BackColor = System.Drawing.Color.Yellow
            UltraGrid1.DataSource = dtSet

            UltraGrid1.DisplayLayout.Bands(0).Summaries.Add("FrLocID", Infragistics.Win.UltraWinGrid.SummaryType.Count, UltraGrid1.DisplayLayout.Bands(0).Columns("FrLocID"), Infragistics.Win.UltraWinGrid.SummaryPosition.UseSummaryPositionColumn)
            UltraGrid1.DisplayLayout.Bands(0).Summaries("FrLocID").Appearance.TextHAlign = Infragistics.Win.HAlign.Right
            UltraGrid1.DisplayLayout.Bands(0).SummaryFooterCaption = ""
            UltraGrid1.DisplayLayout.Override.SummaryFooterCaptionVisible = Infragistics.Win.DefaultableBoolean.False
            UltraGrid1.DisplayLayout.Override.RowAlternateAppearance = EvenRowApp
            UltraGrid1.DisplayLayout.Override.MaxSelectedRows = 1
        End If
        UltraGrid1.Refresh()
        UltraGrid1.Update()

        m_iLabelsAdded = UltraGrid1.Rows.Count

    End Sub

    Private Sub PrintContainerLabels_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If dtSet.Tables.Count > 0 Then
            dtSet.Tables(0).Rows.Clear()
            dtSet.Tables(0).Dispose()
            dtSet.Dispose()
            dtSet = Nothing
        End If
    End Sub

    Private Sub btnPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPrint.Click
        Dim ugrow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim dbrow As DataRow
        Dim RepDoc As ReportDocument
        Dim RowIDs As String

        On Error GoTo ErrTrap


        Dim sCmd As String

        For Each ugrow In UltraGrid1.Rows
            sCmd = ""
            sCmd = "exec " & TRCTblPath & "CourLblX '" & ugrow.Cells("FrLocID").Value & "', '" & ugrow.Cells("FrAcctID").Value & "', '" & ugrow.Cells("ToLocID").Value & "', '" & ugrow.Cells("ToAcctID").Value & "'"
            If ExecuteQuery(sCmd) = False Then
                MsgBox("Due to Errors in record creation, print aborts.")
                Exit Sub
            End If
            sCmd = ""
            sCmd = "Select RowID FROM " & TRCTblPath & "CourierLabels where FromLocID = '" & ugrow.Cells("FrLocID").Value & "' AND FromCustID = '" & ugrow.Cells("FrAcctID").Value & "' AND ToLocID = '" & ugrow.Cells("ToLocID").Value & "' AND ToCustID = '" & ugrow.Cells("ToAcctID").Value & "' AND VOID = 'F' "
            If ReturnRowByID("", dbrow, "", "", "", sCmd) = False Then
                MsgBox("Error: Can not find the label record. Aborting Print.")
                Exit Sub
            End If
            RowIDs = RowIDs & dbrow("RowID") & ","
            If m_bCalledByWeightPlan Then
                m_iFromCLRowID = CInt(dbrow("RowID"))   'Assumes only 1 row will be in the grid.  Enforced by test in btnAdd_Click
            End If
        Next

        If Not RepDoc Is Nothing Then
            RepDoc.Dispose()
            RepDoc = Nothing
        End If

        Me.Cursor = System.Windows.Forms.Cursors.WaitCursor()

        Dim bThirdPartyFormat As Boolean = cbThirdPartyFormat.Checked

        If bThirdPartyFormat = True Then
            RepDoc = New Third_Party_Barcoded_Labels
        Else
            RepDoc = New Pouch__Container_Barcodes
        End If

        ''TO-DO Modify this so it does not conflict with thirdparty barcode report
        ''Print Labels with "correct" phone number and account type.
        'If uopAcctType.CheckedIndex() = 0 Then
        '    Dim firstLabelPhone, secondLabelPhone, firstLabelAcct, secondLabelAcct As CrystalDecisions.CrystalReports.Engine.TextObject
        '    firstLabelPhone = CType(RepDoc.ReportDefinition.ReportObjects.Item("txtFirstPhone"), CrystalDecisions.CrystalReports.Engine.TextObject)
        '    firstLabelPhone.Text = "(800) 273 - 9314"

        '    firstLabelAcct = CType(RepDoc.ReportDefinition.ReportObjects.Item("txtFirstAcct"), CrystalDecisions.CrystalReports.Engine.TextObject)
        '    firstLabelAcct.Text = "TPC / CFC"

        '    secondLabelPhone = CType(RepDoc.ReportDefinition.ReportObjects.Item("txtSecondPhone"), CrystalDecisions.CrystalReports.Engine.TextObject)
        '    secondLabelPhone.Text = "(800) 273 - 9314"

        '    secondLabelAcct = CType(RepDoc.ReportDefinition.ReportObjects.Item("txtSecondAcct"), CrystalDecisions.CrystalReports.Engine.TextObject)
        '    secondLabelAcct.Text = "TPC / CFC"
        'Else
        '    Dim firstLabelPhone, secondLabelPhone, firstLabelAcct, secondLabelAcct As CrystalDecisions.CrystalReports.Engine.TextObject
        '    firstLabelPhone = CType(RepDoc.ReportDefinition.ReportObjects.Item("txtFirstPhone"), CrystalDecisions.CrystalReports.Engine.TextObject)
        '    firstLabelPhone.Text = "(323) 478 - 1313"

        '    firstLabelAcct = CType(RepDoc.ReportDefinition.ReportObjects.Item("txtFirstAcct"), CrystalDecisions.CrystalReports.Engine.TextObject)
        '    firstLabelAcct.Text = "TTI"

        '    secondLabelPhone = CType(RepDoc.ReportDefinition.ReportObjects.Item("txtSecondPhone"), CrystalDecisions.CrystalReports.Engine.TextObject)
        '    secondLabelPhone.Text = "(323) 478 - 1313"

        '    secondLabelAcct = CType(RepDoc.ReportDefinition.ReportObjects.Item("txtSecondAcct"), CrystalDecisions.CrystalReports.Engine.TextObject)
        '    secondLabelAcct.Text = "TTI"
        'End If


        RepDoc.RecordSelectionFormula = "UpperCase({CourierLabels.ParcelType}) = 'XPOUCH' AND {CourierLabels.RowID} in [" & RowIDs.Substring(0, Len(RowIDs) - 1) & "]"
        ' AND {CourierLabels.FromLocID} = '' AND {CourierLabels.ToCustID} = '' AND {CourierLabels.ToLocID} = ''
        'Karina commented and changed
        'SetConnectionInfo("COURIERLABELS", IPAddr, "TOP", "tpctrk", "top", RepDoc)
        'SetConnectionInfo("COURIERLABELS_R", IPAddr, "TOP", "tpctrk", "top", RepDoc)

        'SetConnectionInfoOld("COURIERLABELS", IPAddr, TRCDBName, TRCDBUser, TRCDBPass, RepDoc)
        'SetConnectionInfoOld("COURIERLABELS_R", IPAddr, TRCDBName, TRCDBUser, TRCDBPass, RepDoc)

        SetConnectionInfo(IPAddr, TRCDBName, TRCDBUser, TRCDBPass, RepDoc)

        'Override Default Page Margins for Crystal Report
        Dim myPageMargins As PageMargins
        myPageMargins = RepDoc.PrintOptions.PageMargins
        myPageMargins.leftMargin = 0
        RepDoc.PrintOptions.ApplyPageMargins(myPageMargins)

        RepDoc.PrintToPrinter(Val(dUpDn.Text), False, 1, 9999)
        Me.Cursor = System.Windows.Forms.Cursors.Default

        If m_bCalledByWeightPlan Then
            Me.DialogResult = DialogResult.OK
        End If

        Exit Sub
ErrTrap:
        MsgBox(Err.Description)
    End Sub

    Private Sub SetConnectionInfo(ByVal server As String, ByVal database As String, _
    ByVal user As String, ByVal password As String, ByRef ReportDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument)


        Dim connectionInfo As New ConnectionInfo
        connectionInfo.ServerName = server
        connectionInfo.DatabaseName = database
        connectionInfo.UserID = user
        connectionInfo.Password = password

        Dim tables As Tables = ReportDoc.Database.Tables
        Dim tableLogonInfo As TableLogOnInfo
        For Each table As CrystalDecisions.CrystalReports.Engine.Table In tables
            tableLogonInfo = table.LogOnInfo
            tableLogonInfo.ConnectionInfo = connectionInfo
            table.ApplyLogOnInfo(tableLogonInfo)
        Next


        '' Get the ConnectionInfo Object.
        'Dim logOnInfo As New TableLogOnInfo
        'logOnInfo = ReportDoc.Database.Tables.Item(p_table).LogOnInfo

        ''connectionInfo = ReportDoc.Database.Tables.Item(table).LogOnInfo.ConnectionInfo

        '' Set the Connection parameters.
        'With logOnInfo
        '    .ConnectionInfo.DatabaseName = database
        '    .ConnectionInfo.ServerName = server
        '    .ConnectionInfo.UserID = user
        '    .ConnectionInfo.Password = password
        'End With

        ''logOnInfo.ConnectionInfo = ConnectionInfo

        'ReportDoc.Database.Tables.Item(p_table).ApplyLogOnInfo(logOnInfo)

    End Sub

    Private Sub SetConnectionInfoOld(ByVal table As String, _
    ByVal server As String, ByVal database As String, _
    ByVal user As String, ByVal password As String, ByRef ReportDoc As CrystalDecisions.CrystalReports.Engine.ReportDocument)

        ' Get the ConnectionInfo Object.
        Dim logOnInfo As New TableLogOnInfo
        logOnInfo = ReportDoc.Database.Tables.Item(table).LogOnInfo

        'Dim connectionInfo As New ConnectionInfo()
        'connectionInfo = ReportDoc.Database.Tables.Item(table).LogOnInfo.ConnectionInfo

        ' Set the Connection parameters.
        With logOnInfo
            .ConnectionInfo.DatabaseName = database
            .ConnectionInfo.ServerName = server
            .ConnectionInfo.UserID = user
            .ConnectionInfo.Password = password
        End With

        'logOnInfo.ConnectionInfo = ConnectionInfo

        ReportDoc.Database.Tables.Item(table).ApplyLogOnInfo(logOnInfo)

    End Sub

    Private Sub btnAssign_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAssign.Click
        ' This method assumes the form was called from the Weight Plan screen in Modal mode because btnAssign is only visible when that is the case

        Dim ugrow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim dbrow As DataRow
        Dim RepDoc As ReportDocument

        On Error GoTo ErrTrap


        Dim sCmd As String

        For Each ugrow In UltraGrid1.Rows
            sCmd = ""
            sCmd = "exec " & TRCTblPath & "CourLblX '" & ugrow.Cells("FrLocID").Value & "', '" & ugrow.Cells("FrAcctID").Value & "', '" & ugrow.Cells("ToLocID").Value & "', '" & ugrow.Cells("ToAcctID").Value & "'"
            If ExecuteQuery(sCmd) = False Then
                MsgBox("Due to Errors in record creation, print aborts.")
                Exit Sub
            End If
            sCmd = ""
            sCmd = "Select RowID FROM " & TRCTblPath & "CourierLabels where FromLocID = '" & ugrow.Cells("FrLocID").Value & "' AND FromCustID = '" & ugrow.Cells("FrAcctID").Value & "' AND ToLocID = '" & ugrow.Cells("ToLocID").Value & "' AND ToCustID = '" & ugrow.Cells("ToAcctID").Value & "' AND VOID = 'F' "
            If ReturnRowByID("", dbrow, "", "", "", sCmd) = False Then
                MsgBox("Error: Can not find the label record. Aborting Print.")
                Exit Sub
            End If
            m_iFromCLRowID = CInt(dbrow("RowID"))
        Next

        Me.DialogResult = DialogResult.OK

        Exit Sub
ErrTrap:
        MsgBox(Err.Description)
    End Sub

    Private Sub btnCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCancel.Click
        If m_bCalledByWeightPlan Then
            Me.DialogResult = DialogResult.Cancel
        Else
            Me.Close()
        End If
    End Sub

    Private Sub GroupBox2_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox2.Enter

    End Sub
End Class
