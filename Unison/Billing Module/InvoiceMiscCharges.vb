Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors
Public Class InvoiceMiscCharges
    Inherits System.Windows.Forms.Form

    '    Dim SQLSelect As String = "Select RowID, TranDate, BillToCustID, BillToCustName, " & _
    '"Description, Qty, Unit, Charge, TrackingNum, Ref1, Ref2, Ref3, FromAddID, FromCustID, " & _
    '"FromCustName, FromLocID, FromLocName, FromAdd1, FromAdd2, FromCity, FromState, " & _
    '"FromZip, FromContact, FromPhone, FromEmail, ToAddID, ToCustID, ToCustName, ToLocID, " & _
    '"ToLocName, ToAdd1, ToAdd2, ToCity, ToState, ToZip, ToContact, ToPhone, ToEmail FROM " & BillTblPath & "InvoiceMiscCharges"

    Dim SQLSelect As String = "Select imc.RowID, imc.TranDate, imc.BillToCustID, imc.BillToCustName, " & _
   "imc.Description, imc.Qty, imc.Unit, icc.Description, imc.Charge_Code, imc.Charge, imc.TrackingNum, imc.Ref1, imc.Ref2, imc.Ref3, imc.FromAddID, imc.FromCustID, " & _
   "imc.FromCustName, imc.FromLocID, imc.FromLocName, imc.FromAdd1, imc.FromAdd2, imc.FromCity, imc.FromState, " & _
   "imc.FromZip, imc.FromContact, imc.FromPhone, imc.FromEmail, imc.ToAddID, imc.ToCustID, imc.ToCustName, imc.ToLocID, " & _
   "imc.ToLocName, imc.ToAdd1, imc.ToAdd2, imc.ToCity, imc.ToState, imc.ToZip, imc.ToContact, imc.ToPhone, imc.ToEmail FROM " & BILLTblPath & "InvoiceMiscCharges imc, " & BILLTblPath & "InvoiceChargeCodes icc where icc.Charge_Code = imc.Charge_Code"

    Dim HidCols() As String = {"Charge_Code"}
    Dim cmdTrans As SqlCommand
    Dim dtSet As New DataSet
    Dim MeText As String
    Public bStartInNewMode As Boolean = False

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
    Friend WithEvents uteToContact As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents uteToEmail As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents umeToPhone As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents uteToLocName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents uteToCustName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents ucToState As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents uteToZip As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents uteToCity As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents uteToCustID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents uteFromCustName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents uteFromCustID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label54 As System.Windows.Forms.Label
    Friend WithEvents Label55 As System.Windows.Forms.Label
    Friend WithEvents Label56 As System.Windows.Forms.Label
    Friend WithEvents uteRef3 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents uteRef2 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents uteRef1 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label57 As System.Windows.Forms.Label
    Friend WithEvents Label58 As System.Windows.Forms.Label
    Friend WithEvents Label59 As System.Windows.Forms.Label
    Friend WithEvents uteTrackingNum As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label60 As System.Windows.Forms.Label
    Friend WithEvents uteBillToCustName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents uteBillToCustID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label61 As System.Windows.Forms.Label
    Friend WithEvents Label62 As System.Windows.Forms.Label
    Friend WithEvents uteDescription As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents uteCharge As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents uteUnit As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents uteQty As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label64 As System.Windows.Forms.Label
    Friend WithEvents Label65 As System.Windows.Forms.Label
    Friend WithEvents Label66 As System.Windows.Forms.Label
    Friend WithEvents Label67 As System.Windows.Forms.Label
    Friend WithEvents Label68 As System.Windows.Forms.Label
    Friend WithEvents udtTranDate As Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
    Friend WithEvents btnClear As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents ucFromState As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents uteFromContact As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label46 As System.Windows.Forms.Label
    Friend WithEvents uteFromEmail As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label47 As System.Windows.Forms.Label
    Friend WithEvents umeFromPhone As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents Label48 As System.Windows.Forms.Label
    Friend WithEvents uteFromLocName As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents uteFromZip As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents uteFromCity As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents uteFromAdd2 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents uteFromAdd1 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label50 As System.Windows.Forms.Label
    Friend WithEvents Label51 As System.Windows.Forms.Label
    Friend WithEvents Label52 As System.Windows.Forms.Label
    Friend WithEvents Label53 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents btnSelectDelivery As System.Windows.Forms.Button
    Friend WithEvents btnSelectPickup As System.Windows.Forms.Button
    Friend WithEvents uteFromLocID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents uteToLocID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents uteToAdd2 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents uteToAdd1 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnSelToCustID As System.Windows.Forms.Button
    Friend WithEvents btnSelFromCustID As System.Windows.Forms.Button
    Friend WithEvents btnSelBillToCust As System.Windows.Forms.Button
    Friend WithEvents FromAddID As System.Windows.Forms.TextBox
    Friend WithEvents ToAddID As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents utRowID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents UltraTextEditor1 As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents ucboDescription As Infragistics.Win.UltraWinGrid.UltraCombo
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label13 = New System.Windows.Forms.Label
        Me.UltraTextEditor1 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.utRowID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label12 = New System.Windows.Forms.Label
        Me.btnSelBillToCust = New System.Windows.Forms.Button
        Me.btnSelToCustID = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.btnSelectDelivery = New System.Windows.Forms.Button
        Me.uteToContact = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label1 = New System.Windows.Forms.Label
        Me.uteToEmail = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label2 = New System.Windows.Forms.Label
        Me.umeToPhone = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
        Me.Label3 = New System.Windows.Forms.Label
        Me.uteToLocName = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label4 = New System.Windows.Forms.Label
        Me.uteToZip = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.uteToCity = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.uteToAdd2 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.uteToAdd1 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.uteToLocID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label15 = New System.Windows.Forms.Label
        Me.ucToState = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.ToAddID = New System.Windows.Forms.TextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.FromAddID = New System.Windows.Forms.TextBox
        Me.uteFromLocID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label14 = New System.Windows.Forms.Label
        Me.ucFromState = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.uteFromContact = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label46 = New System.Windows.Forms.Label
        Me.uteFromLocName = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label49 = New System.Windows.Forms.Label
        Me.uteFromZip = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.uteFromCity = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.uteFromAdd2 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.uteFromAdd1 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label50 = New System.Windows.Forms.Label
        Me.Label51 = New System.Windows.Forms.Label
        Me.Label52 = New System.Windows.Forms.Label
        Me.Label53 = New System.Windows.Forms.Label
        Me.btnSelectPickup = New System.Windows.Forms.Button
        Me.umeFromPhone = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
        Me.Label48 = New System.Windows.Forms.Label
        Me.Label47 = New System.Windows.Forms.Label
        Me.uteFromEmail = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.uteToCustName = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.uteToCustID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.uteFromCustName = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.uteFromCustID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label54 = New System.Windows.Forms.Label
        Me.Label55 = New System.Windows.Forms.Label
        Me.Label56 = New System.Windows.Forms.Label
        Me.uteRef3 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.uteRef2 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.uteRef1 = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label57 = New System.Windows.Forms.Label
        Me.Label58 = New System.Windows.Forms.Label
        Me.Label59 = New System.Windows.Forms.Label
        Me.uteTrackingNum = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label60 = New System.Windows.Forms.Label
        Me.uteBillToCustName = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.uteBillToCustID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label61 = New System.Windows.Forms.Label
        Me.Label62 = New System.Windows.Forms.Label
        Me.uteDescription = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.uteCharge = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.uteUnit = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.uteQty = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label64 = New System.Windows.Forms.Label
        Me.Label65 = New System.Windows.Forms.Label
        Me.Label66 = New System.Windows.Forms.Label
        Me.Label67 = New System.Windows.Forms.Label
        Me.Label68 = New System.Windows.Forms.Label
        Me.udtTranDate = New Infragistics.Win.UltraWinEditors.UltraDateTimeEditor
        Me.btnSelFromCustID = New System.Windows.Forms.Button
        Me.ucboDescription = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.btnClear = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnNew = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Panel1.SuspendLayout()
        CType(Me.UltraTextEditor1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utRowID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.uteToContact, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uteToEmail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uteToLocName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uteToZip, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uteToCity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uteToAdd2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uteToAdd1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uteToLocID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucToState, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.uteFromLocID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucFromState, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uteFromContact, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uteFromLocName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uteFromZip, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uteFromCity, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uteFromAdd2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uteFromAdd1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uteFromEmail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uteToCustName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uteToCustID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uteFromCustName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uteFromCustID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uteRef3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uteRef2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uteRef1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uteTrackingNum, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uteBillToCustName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uteBillToCustID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uteDescription, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uteCharge, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uteUnit, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.uteQty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.udtTranDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucboDescription, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.UltraTextEditor1)
        Me.Panel1.Controls.Add(Me.utRowID)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.btnSelBillToCust)
        Me.Panel1.Controls.Add(Me.btnSelToCustID)
        Me.Panel1.Controls.Add(Me.GroupBox2)
        Me.Panel1.Controls.Add(Me.GroupBox1)
        Me.Panel1.Controls.Add(Me.uteToCustName)
        Me.Panel1.Controls.Add(Me.uteToCustID)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.uteFromCustName)
        Me.Panel1.Controls.Add(Me.uteFromCustID)
        Me.Panel1.Controls.Add(Me.Label54)
        Me.Panel1.Controls.Add(Me.Label55)
        Me.Panel1.Controls.Add(Me.Label56)
        Me.Panel1.Controls.Add(Me.uteRef3)
        Me.Panel1.Controls.Add(Me.uteRef2)
        Me.Panel1.Controls.Add(Me.uteRef1)
        Me.Panel1.Controls.Add(Me.Label57)
        Me.Panel1.Controls.Add(Me.Label58)
        Me.Panel1.Controls.Add(Me.Label59)
        Me.Panel1.Controls.Add(Me.uteTrackingNum)
        Me.Panel1.Controls.Add(Me.Label60)
        Me.Panel1.Controls.Add(Me.uteBillToCustName)
        Me.Panel1.Controls.Add(Me.uteBillToCustID)
        Me.Panel1.Controls.Add(Me.Label61)
        Me.Panel1.Controls.Add(Me.Label62)
        Me.Panel1.Controls.Add(Me.uteDescription)
        Me.Panel1.Controls.Add(Me.uteCharge)
        Me.Panel1.Controls.Add(Me.uteUnit)
        Me.Panel1.Controls.Add(Me.uteQty)
        Me.Panel1.Controls.Add(Me.Label64)
        Me.Panel1.Controls.Add(Me.Label65)
        Me.Panel1.Controls.Add(Me.Label66)
        Me.Panel1.Controls.Add(Me.Label67)
        Me.Panel1.Controls.Add(Me.Label68)
        Me.Panel1.Controls.Add(Me.udtTranDate)
        Me.Panel1.Controls.Add(Me.btnSelFromCustID)
        Me.Panel1.Controls.Add(Me.ucboDescription)
        Me.Panel1.Location = New System.Drawing.Point(-10, -18)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(711, 581)
        Me.Panel1.TabIndex = 0
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(204, 67)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(76, 18)
        Me.Label13.TabIndex = 24
        Me.Label13.Text = "Unit Cost $:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'UltraTextEditor1
        '
        Me.UltraTextEditor1.Location = New System.Drawing.Point(280, 65)
        Me.UltraTextEditor1.MaxLength = 20
        Me.UltraTextEditor1.Name = "UltraTextEditor1"
        Me.UltraTextEditor1.Size = New System.Drawing.Size(60, 24)
        Me.UltraTextEditor1.TabIndex = 4
        Me.UltraTextEditor1.Tag = ""
        '
        'utRowID
        '
        Me.utRowID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utRowID.Location = New System.Drawing.Point(336, 212)
        Me.utRowID.MaxLength = 20
        Me.utRowID.Name = "utRowID"
        Me.utRowID.Size = New System.Drawing.Size(60, 24)
        Me.utRowID.TabIndex = 33
        Me.utRowID.Tag = ".RowID.view"
        Me.utRowID.Visible = False
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(470, 67)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(88, 18)
        Me.Label12.TabIndex = 27
        Me.Label12.Text = "Charge Code:"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnSelBillToCust
        '
        Me.btnSelBillToCust.Location = New System.Drawing.Point(360, 28)
        Me.btnSelBillToCust.Name = "btnSelBillToCust"
        Me.btnSelBillToCust.Size = New System.Drawing.Size(57, 24)
        Me.btnSelBillToCust.TabIndex = 20
        Me.btnSelBillToCust.Text = "Select"
        '
        'btnSelToCustID
        '
        Me.btnSelToCustID.Location = New System.Drawing.Point(307, 415)
        Me.btnSelToCustID.Name = "btnSelToCustID"
        Me.btnSelToCustID.Size = New System.Drawing.Size(58, 25)
        Me.btnSelToCustID.TabIndex = 40
        Me.btnSelToCustID.Text = "Select"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.btnSelectDelivery)
        Me.GroupBox2.Controls.Add(Me.uteToContact)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.uteToEmail)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.umeToPhone)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.uteToLocName)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.uteToZip)
        Me.GroupBox2.Controls.Add(Me.uteToCity)
        Me.GroupBox2.Controls.Add(Me.uteToAdd2)
        Me.GroupBox2.Controls.Add(Me.uteToAdd1)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.uteToLocID)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.ucToState)
        Me.GroupBox2.Controls.Add(Me.ToAddID)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 443)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(688, 139)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Delivery Location:"
        '
        'btnSelectDelivery
        '
        Me.btnSelectDelivery.Location = New System.Drawing.Point(211, 18)
        Me.btnSelectDelivery.Name = "btnSelectDelivery"
        Me.btnSelectDelivery.Size = New System.Drawing.Size(58, 25)
        Me.btnSelectDelivery.TabIndex = 11
        Me.btnSelectDelivery.Text = "Select"
        '
        'uteToContact
        '
        Me.uteToContact.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.uteToContact.Location = New System.Drawing.Point(413, 46)
        Me.uteToContact.MaxLength = 20
        Me.uteToContact.Name = "uteToContact"
        Me.uteToContact.Size = New System.Drawing.Size(270, 24)
        Me.uteToContact.TabIndex = 3
        Me.uteToContact.Tag = ".ToContact"
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(355, 46)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(58, 19)
        Me.Label1.TabIndex = 15
        Me.Label1.Text = "Contact:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'uteToEmail
        '
        Me.uteToEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.uteToEmail.Location = New System.Drawing.Point(564, 102)
        Me.uteToEmail.MaxLength = 20
        Me.uteToEmail.Name = "uteToEmail"
        Me.uteToEmail.Size = New System.Drawing.Size(120, 24)
        Me.uteToEmail.TabIndex = 9
        Me.uteToEmail.Tag = ".ToEmail"
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(518, 102)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(48, 18)
        Me.Label2.TabIndex = 20
        Me.Label2.Text = "E-mail:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'umeToPhone
        '
        Me.umeToPhone.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.umeToPhone.InputMask = "(###)-###-####"
        Me.umeToPhone.Location = New System.Drawing.Point(564, 74)
        Me.umeToPhone.Name = "umeToPhone"
        Me.umeToPhone.Size = New System.Drawing.Size(120, 22)
        Me.umeToPhone.TabIndex = 5
        Me.umeToPhone.Tag = ".ToPhone"
        Me.umeToPhone.Text = "()--"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(518, 74)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(48, 18)
        Me.Label3.TabIndex = 19
        Me.Label3.Text = "Phone:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'uteToLocName
        '
        Me.uteToLocName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.uteToLocName.Location = New System.Drawing.Point(413, 18)
        Me.uteToLocName.MaxLength = 20
        Me.uteToLocName.Name = "uteToLocName"
        Me.uteToLocName.Size = New System.Drawing.Size(270, 24)
        Me.uteToLocName.TabIndex = 1
        Me.uteToLocName.Tag = ".ToLocName"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(365, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(48, 19)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "Name:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'uteToZip
        '
        Me.uteToZip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.uteToZip.Location = New System.Drawing.Point(365, 102)
        Me.uteToZip.MaxLength = 20
        Me.uteToZip.Name = "uteToZip"
        Me.uteToZip.Size = New System.Drawing.Size(60, 24)
        Me.uteToZip.TabIndex = 8
        Me.uteToZip.Tag = ".ToZip"
        '
        'uteToCity
        '
        Me.uteToCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.uteToCity.Location = New System.Drawing.Point(77, 102)
        Me.uteToCity.MaxLength = 20
        Me.uteToCity.Name = "uteToCity"
        Me.uteToCity.Size = New System.Drawing.Size(120, 24)
        Me.uteToCity.TabIndex = 6
        Me.uteToCity.Tag = ".ToCity"
        '
        'uteToAdd2
        '
        Me.uteToAdd2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.uteToAdd2.Location = New System.Drawing.Point(77, 74)
        Me.uteToAdd2.MaxLength = 20
        Me.uteToAdd2.Name = "uteToAdd2"
        Me.uteToAdd2.Size = New System.Drawing.Size(270, 24)
        Me.uteToAdd2.TabIndex = 4
        Me.uteToAdd2.Tag = ".ToAdd2"
        '
        'uteToAdd1
        '
        Me.uteToAdd1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.uteToAdd1.Location = New System.Drawing.Point(77, 46)
        Me.uteToAdd1.MaxLength = 20
        Me.uteToAdd1.Name = "uteToAdd1"
        Me.uteToAdd1.Size = New System.Drawing.Size(270, 24)
        Me.uteToAdd1.TabIndex = 2
        Me.uteToAdd1.Tag = ".ToAdd1"
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(336, 102)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(29, 18)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Zip:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(221, 102)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(48, 18)
        Me.Label6.TabIndex = 17
        Me.Label6.Text = "State:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(38, 102)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(39, 18)
        Me.Label7.TabIndex = 16
        Me.Label7.Text = "City:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(10, 46)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(67, 19)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Address:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'uteToLocID
        '
        Me.uteToLocID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.uteToLocID.Location = New System.Drawing.Point(77, 18)
        Me.uteToLocID.MaxLength = 20
        Me.uteToLocID.Name = "uteToLocID"
        Me.uteToLocID.Size = New System.Drawing.Size(120, 24)
        Me.uteToLocID.TabIndex = 0
        Me.uteToLocID.Tag = ".ToLocID"
        '
        'Label15
        '
        Me.Label15.Location = New System.Drawing.Point(48, 18)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(29, 19)
        Me.Label15.TabIndex = 10
        Me.Label15.Text = "ID:"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ucToState
        '
        Me.ucToState.AutoEdit = False
        Me.ucToState.DisplayMember = ""
        Me.ucToState.Location = New System.Drawing.Point(269, 102)
        Me.ucToState.Name = "ucToState"
        Me.ucToState.Size = New System.Drawing.Size(60, 24)
        Me.ucToState.TabIndex = 7
        Me.ucToState.Tag = ".ToSTATE...STATE.CODE.CODE"
        Me.ucToState.ValueMember = ""
        '
        'ToAddID
        '
        Me.ToAddID.Location = New System.Drawing.Point(326, 18)
        Me.ToAddID.Name = "ToAddID"
        Me.ToAddID.Size = New System.Drawing.Size(29, 22)
        Me.ToAddID.TabIndex = 12
        Me.ToAddID.TabStop = False
        Me.ToAddID.Tag = ".ToAddID"
        Me.ToAddID.Text = ""
        Me.ToAddID.Visible = False
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.FromAddID)
        Me.GroupBox1.Controls.Add(Me.uteFromLocID)
        Me.GroupBox1.Controls.Add(Me.Label14)
        Me.GroupBox1.Controls.Add(Me.ucFromState)
        Me.GroupBox1.Controls.Add(Me.uteFromContact)
        Me.GroupBox1.Controls.Add(Me.Label46)
        Me.GroupBox1.Controls.Add(Me.uteFromLocName)
        Me.GroupBox1.Controls.Add(Me.Label49)
        Me.GroupBox1.Controls.Add(Me.uteFromZip)
        Me.GroupBox1.Controls.Add(Me.uteFromCity)
        Me.GroupBox1.Controls.Add(Me.uteFromAdd2)
        Me.GroupBox1.Controls.Add(Me.uteFromAdd1)
        Me.GroupBox1.Controls.Add(Me.Label50)
        Me.GroupBox1.Controls.Add(Me.Label51)
        Me.GroupBox1.Controls.Add(Me.Label52)
        Me.GroupBox1.Controls.Add(Me.Label53)
        Me.GroupBox1.Controls.Add(Me.btnSelectPickup)
        Me.GroupBox1.Controls.Add(Me.umeFromPhone)
        Me.GroupBox1.Controls.Add(Me.Label48)
        Me.GroupBox1.Controls.Add(Me.Label47)
        Me.GroupBox1.Controls.Add(Me.uteFromEmail)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.Location = New System.Drawing.Point(10, 268)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(691, 138)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pick-up Location:"
        '
        'FromAddID
        '
        Me.FromAddID.Location = New System.Drawing.Point(326, 18)
        Me.FromAddID.Name = "FromAddID"
        Me.FromAddID.Size = New System.Drawing.Size(29, 23)
        Me.FromAddID.TabIndex = 12
        Me.FromAddID.TabStop = False
        Me.FromAddID.Tag = ".FromAddID"
        Me.FromAddID.Text = ""
        Me.FromAddID.Visible = False
        '
        'uteFromLocID
        '
        Me.uteFromLocID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.uteFromLocID.Location = New System.Drawing.Point(77, 21)
        Me.uteFromLocID.MaxLength = 20
        Me.uteFromLocID.Name = "uteFromLocID"
        Me.uteFromLocID.Size = New System.Drawing.Size(120, 25)
        Me.uteFromLocID.TabIndex = 0
        Me.uteFromLocID.Tag = ".FromLocID"
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(48, 21)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(29, 18)
        Me.Label14.TabIndex = 10
        Me.Label14.Text = "ID:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ucFromState
        '
        Me.ucFromState.AutoEdit = False
        Me.ucFromState.DisplayMember = ""
        Me.ucFromState.Location = New System.Drawing.Point(269, 104)
        Me.ucFromState.Name = "ucFromState"
        Me.ucFromState.Size = New System.Drawing.Size(60, 25)
        Me.ucFromState.TabIndex = 7
        Me.ucFromState.Tag = ".FromSTATE...STATE.CODE.CODE"
        Me.ucFromState.ValueMember = ""
        '
        'uteFromContact
        '
        Me.uteFromContact.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.uteFromContact.Location = New System.Drawing.Point(413, 46)
        Me.uteFromContact.MaxLength = 20
        Me.uteFromContact.Name = "uteFromContact"
        Me.uteFromContact.Size = New System.Drawing.Size(270, 25)
        Me.uteFromContact.TabIndex = 3
        Me.uteFromContact.Tag = ".FromContact"
        '
        'Label46
        '
        Me.Label46.Location = New System.Drawing.Point(355, 46)
        Me.Label46.Name = "Label46"
        Me.Label46.Size = New System.Drawing.Size(58, 19)
        Me.Label46.TabIndex = 15
        Me.Label46.Text = "Contact:"
        Me.Label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'uteFromLocName
        '
        Me.uteFromLocName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.uteFromLocName.Location = New System.Drawing.Point(413, 18)
        Me.uteFromLocName.MaxLength = 20
        Me.uteFromLocName.Name = "uteFromLocName"
        Me.uteFromLocName.Size = New System.Drawing.Size(270, 25)
        Me.uteFromLocName.TabIndex = 1
        Me.uteFromLocName.Tag = ".FromLocName"
        '
        'Label49
        '
        Me.Label49.Location = New System.Drawing.Point(365, 18)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(48, 19)
        Me.Label49.TabIndex = 13
        Me.Label49.Text = "Name:"
        Me.Label49.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'uteFromZip
        '
        Me.uteFromZip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.uteFromZip.Location = New System.Drawing.Point(365, 104)
        Me.uteFromZip.MaxLength = 20
        Me.uteFromZip.Name = "uteFromZip"
        Me.uteFromZip.Size = New System.Drawing.Size(60, 25)
        Me.uteFromZip.TabIndex = 8
        Me.uteFromZip.Tag = ".FromZip"
        '
        'uteFromCity
        '
        Me.uteFromCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.uteFromCity.Location = New System.Drawing.Point(77, 104)
        Me.uteFromCity.MaxLength = 20
        Me.uteFromCity.Name = "uteFromCity"
        Me.uteFromCity.Size = New System.Drawing.Size(144, 25)
        Me.uteFromCity.TabIndex = 6
        Me.uteFromCity.Tag = ".FromCity"
        '
        'uteFromAdd2
        '
        Me.uteFromAdd2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.uteFromAdd2.Location = New System.Drawing.Point(77, 76)
        Me.uteFromAdd2.MaxLength = 20
        Me.uteFromAdd2.Name = "uteFromAdd2"
        Me.uteFromAdd2.Size = New System.Drawing.Size(270, 25)
        Me.uteFromAdd2.TabIndex = 4
        Me.uteFromAdd2.Tag = ".FromAdd2"
        '
        'uteFromAdd1
        '
        Me.uteFromAdd1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.uteFromAdd1.Location = New System.Drawing.Point(77, 48)
        Me.uteFromAdd1.MaxLength = 20
        Me.uteFromAdd1.Name = "uteFromAdd1"
        Me.uteFromAdd1.Size = New System.Drawing.Size(270, 25)
        Me.uteFromAdd1.TabIndex = 2
        Me.uteFromAdd1.Tag = ".FromAdd1"
        '
        'Label50
        '
        Me.Label50.Location = New System.Drawing.Point(336, 104)
        Me.Label50.Name = "Label50"
        Me.Label50.Size = New System.Drawing.Size(29, 18)
        Me.Label50.TabIndex = 18
        Me.Label50.Text = "Zip:"
        Me.Label50.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label51
        '
        Me.Label51.Location = New System.Drawing.Point(221, 104)
        Me.Label51.Name = "Label51"
        Me.Label51.Size = New System.Drawing.Size(48, 18)
        Me.Label51.TabIndex = 17
        Me.Label51.Text = "State:"
        Me.Label51.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label52
        '
        Me.Label52.Location = New System.Drawing.Point(38, 104)
        Me.Label52.Name = "Label52"
        Me.Label52.Size = New System.Drawing.Size(39, 18)
        Me.Label52.TabIndex = 16
        Me.Label52.Text = "City:"
        Me.Label52.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label53
        '
        Me.Label53.Location = New System.Drawing.Point(10, 48)
        Me.Label53.Name = "Label53"
        Me.Label53.Size = New System.Drawing.Size(67, 19)
        Me.Label53.TabIndex = 14
        Me.Label53.Text = "Address:"
        Me.Label53.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'btnSelectPickup
        '
        Me.btnSelectPickup.Location = New System.Drawing.Point(211, 21)
        Me.btnSelectPickup.Name = "btnSelectPickup"
        Me.btnSelectPickup.Size = New System.Drawing.Size(58, 24)
        Me.btnSelectPickup.TabIndex = 11
        Me.btnSelectPickup.Text = "Select"
        '
        'umeFromPhone
        '
        Me.umeFromPhone.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.umeFromPhone.InputMask = "(###)-###-####"
        Me.umeFromPhone.Location = New System.Drawing.Point(564, 74)
        Me.umeFromPhone.Name = "umeFromPhone"
        Me.umeFromPhone.Size = New System.Drawing.Size(120, 23)
        Me.umeFromPhone.TabIndex = 5
        Me.umeFromPhone.Tag = ".FromPhone"
        Me.umeFromPhone.Text = "()--"
        '
        'Label48
        '
        Me.Label48.Location = New System.Drawing.Point(516, 74)
        Me.Label48.Name = "Label48"
        Me.Label48.Size = New System.Drawing.Size(48, 18)
        Me.Label48.TabIndex = 19
        Me.Label48.Text = "Phone:"
        Me.Label48.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label47
        '
        Me.Label47.Location = New System.Drawing.Point(516, 102)
        Me.Label47.Name = "Label47"
        Me.Label47.Size = New System.Drawing.Size(48, 18)
        Me.Label47.TabIndex = 20
        Me.Label47.Text = "E-mail:"
        Me.Label47.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'uteFromEmail
        '
        Me.uteFromEmail.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.uteFromEmail.Location = New System.Drawing.Point(564, 102)
        Me.uteFromEmail.MaxLength = 20
        Me.uteFromEmail.Name = "uteFromEmail"
        Me.uteFromEmail.Size = New System.Drawing.Size(120, 25)
        Me.uteFromEmail.TabIndex = 9
        Me.uteFromEmail.Tag = ".FromEmail"
        '
        'uteToCustName
        '
        Me.uteToCustName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.uteToCustName.Location = New System.Drawing.Point(442, 415)
        Me.uteToCustName.MaxLength = 20
        Me.uteToCustName.Name = "uteToCustName"
        Me.uteToCustName.Size = New System.Drawing.Size(242, 24)
        Me.uteToCustName.TabIndex = 14
        Me.uteToCustName.Tag = ".ToCustName"
        '
        'uteToCustID
        '
        Me.uteToCustID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.uteToCustID.Location = New System.Drawing.Point(182, 415)
        Me.uteToCustID.MaxLength = 20
        Me.uteToCustID.Name = "uteToCustID"
        Me.uteToCustID.Size = New System.Drawing.Size(120, 24)
        Me.uteToCustID.TabIndex = 13
        Me.uteToCustID.Tag = ".ToCustID"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(394, 415)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(48, 19)
        Me.Label9.TabIndex = 41
        Me.Label9.Text = "Name:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(154, 415)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(28, 19)
        Me.Label10.TabIndex = 39
        Me.Label10.Text = "ID:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(10, 415)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(134, 19)
        Me.Label11.TabIndex = 38
        Me.Label11.Text = "To Customer Info:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'uteFromCustName
        '
        Me.uteFromCustName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.uteFromCustName.Location = New System.Drawing.Point(442, 240)
        Me.uteFromCustName.MaxLength = 20
        Me.uteFromCustName.Name = "uteFromCustName"
        Me.uteFromCustName.Size = New System.Drawing.Size(242, 24)
        Me.uteFromCustName.TabIndex = 12
        Me.uteFromCustName.Tag = ".FromCustName"
        '
        'uteFromCustID
        '
        Me.uteFromCustID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.uteFromCustID.Location = New System.Drawing.Point(182, 240)
        Me.uteFromCustID.MaxLength = 20
        Me.uteFromCustID.Name = "uteFromCustID"
        Me.uteFromCustID.Size = New System.Drawing.Size(120, 24)
        Me.uteFromCustID.TabIndex = 11
        Me.uteFromCustID.Tag = ".FromCustID"
        '
        'Label54
        '
        Me.Label54.Location = New System.Drawing.Point(394, 240)
        Me.Label54.Name = "Label54"
        Me.Label54.Size = New System.Drawing.Size(48, 18)
        Me.Label54.TabIndex = 36
        Me.Label54.Text = "Name:"
        Me.Label54.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label55
        '
        Me.Label55.Location = New System.Drawing.Point(154, 240)
        Me.Label55.Name = "Label55"
        Me.Label55.Size = New System.Drawing.Size(28, 18)
        Me.Label55.TabIndex = 37
        Me.Label55.Text = "ID:"
        Me.Label55.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label56
        '
        Me.Label56.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label56.Location = New System.Drawing.Point(10, 240)
        Me.Label56.Name = "Label56"
        Me.Label56.Size = New System.Drawing.Size(134, 18)
        Me.Label56.TabIndex = 34
        Me.Label56.Text = "From Customer Info:"
        Me.Label56.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'uteRef3
        '
        Me.uteRef3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.uteRef3.Location = New System.Drawing.Point(384, 185)
        Me.uteRef3.MaxLength = 20
        Me.uteRef3.Name = "uteRef3"
        Me.uteRef3.Size = New System.Drawing.Size(317, 24)
        Me.uteRef3.TabIndex = 10
        Me.uteRef3.Tag = ".Ref3"
        '
        'uteRef2
        '
        Me.uteRef2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.uteRef2.Location = New System.Drawing.Point(384, 157)
        Me.uteRef2.MaxLength = 20
        Me.uteRef2.Name = "uteRef2"
        Me.uteRef2.Size = New System.Drawing.Size(317, 24)
        Me.uteRef2.TabIndex = 9
        Me.uteRef2.Tag = ".Ref2"
        '
        'uteRef1
        '
        Me.uteRef1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.uteRef1.Location = New System.Drawing.Point(384, 129)
        Me.uteRef1.MaxLength = 20
        Me.uteRef1.Name = "uteRef1"
        Me.uteRef1.Size = New System.Drawing.Size(317, 24)
        Me.uteRef1.TabIndex = 8
        Me.uteRef1.Tag = ".Ref1"
        '
        'Label57
        '
        Me.Label57.Location = New System.Drawing.Point(336, 185)
        Me.Label57.Name = "Label57"
        Me.Label57.Size = New System.Drawing.Size(38, 18)
        Me.Label57.TabIndex = 32
        Me.Label57.Text = "Ref3:"
        Me.Label57.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label58
        '
        Me.Label58.Location = New System.Drawing.Point(336, 157)
        Me.Label58.Name = "Label58"
        Me.Label58.Size = New System.Drawing.Size(38, 18)
        Me.Label58.TabIndex = 31
        Me.Label58.Text = "Ref2:"
        Me.Label58.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label59
        '
        Me.Label59.Location = New System.Drawing.Point(336, 129)
        Me.Label59.Name = "Label59"
        Me.Label59.Size = New System.Drawing.Size(38, 19)
        Me.Label59.TabIndex = 30
        Me.Label59.Text = "Ref1:"
        Me.Label59.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'uteTrackingNum
        '
        Me.uteTrackingNum.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.uteTrackingNum.Location = New System.Drawing.Point(432, 102)
        Me.uteTrackingNum.MaxLength = 20
        Me.uteTrackingNum.Name = "uteTrackingNum"
        Me.uteTrackingNum.Size = New System.Drawing.Size(269, 24)
        Me.uteTrackingNum.TabIndex = 7
        Me.uteTrackingNum.Tag = ".TrackingNum"
        '
        'Label60
        '
        Me.Label60.Location = New System.Drawing.Point(336, 102)
        Me.Label60.Name = "Label60"
        Me.Label60.Size = New System.Drawing.Size(96, 18)
        Me.Label60.TabIndex = 29
        Me.Label60.Text = "Tracking Num:"
        Me.Label60.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'uteBillToCustName
        '
        Me.uteBillToCustName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.uteBillToCustName.Location = New System.Drawing.Point(470, 28)
        Me.uteBillToCustName.MaxLength = 20
        Me.uteBillToCustName.Name = "uteBillToCustName"
        Me.uteBillToCustName.Size = New System.Drawing.Size(230, 24)
        Me.uteBillToCustName.TabIndex = 100
        Me.uteBillToCustName.Tag = ".BillToCustName"
        '
        'uteBillToCustID
        '
        Me.uteBillToCustID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.uteBillToCustID.Location = New System.Drawing.Point(248, 28)
        Me.uteBillToCustID.MaxLength = 20
        Me.uteBillToCustID.Name = "uteBillToCustID"
        Me.uteBillToCustID.Size = New System.Drawing.Size(106, 24)
        Me.uteBillToCustID.TabIndex = 1
        Me.uteBillToCustID.Tag = ".BillToCustID"
        '
        'Label61
        '
        Me.Label61.Location = New System.Drawing.Point(422, 28)
        Me.Label61.Name = "Label61"
        Me.Label61.Size = New System.Drawing.Size(48, 18)
        Me.Label61.TabIndex = 21
        Me.Label61.Text = "Name:"
        Me.Label61.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label62
        '
        Me.Label62.Location = New System.Drawing.Point(160, 28)
        Me.Label62.Name = "Label62"
        Me.Label62.Size = New System.Drawing.Size(88, 18)
        Me.Label62.TabIndex = 42
        Me.Label62.Text = "Customer ID:"
        Me.Label62.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'uteDescription
        '
        Me.uteDescription.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.uteDescription.Location = New System.Drawing.Point(19, 120)
        Me.uteDescription.Multiline = True
        Me.uteDescription.Name = "uteDescription"
        Me.uteDescription.Size = New System.Drawing.Size(317, 92)
        Me.uteDescription.TabIndex = 6
        Me.uteDescription.Tag = ".Description"
        '
        'uteCharge
        '
        Me.uteCharge.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.uteCharge.Location = New System.Drawing.Point(392, 65)
        Me.uteCharge.MaxLength = 20
        Me.uteCharge.Name = "uteCharge"
        Me.uteCharge.ReadOnly = True
        Me.uteCharge.Size = New System.Drawing.Size(77, 24)
        Me.uteCharge.TabIndex = 26
        Me.uteCharge.Tag = ".Charge"
        '
        'uteUnit
        '
        Me.uteUnit.Location = New System.Drawing.Point(144, 65)
        Me.uteUnit.MaxLength = 20
        Me.uteUnit.Name = "uteUnit"
        Me.uteUnit.Size = New System.Drawing.Size(60, 24)
        Me.uteUnit.TabIndex = 3
        Me.uteUnit.Tag = ".Unit"
        '
        'uteQty
        '
        Me.uteQty.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.uteQty.Location = New System.Drawing.Point(48, 65)
        Me.uteQty.MaxLength = 20
        Me.uteQty.Name = "uteQty"
        Me.uteQty.Size = New System.Drawing.Size(60, 24)
        Me.uteQty.TabIndex = 2
        Me.uteQty.Tag = ".Qty"
        '
        'Label64
        '
        Me.Label64.Location = New System.Drawing.Point(336, 67)
        Me.Label64.Name = "Label64"
        Me.Label64.Size = New System.Drawing.Size(56, 18)
        Me.Label64.TabIndex = 25
        Me.Label64.Text = "Total $:"
        Me.Label64.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label65
        '
        Me.Label65.Location = New System.Drawing.Point(106, 67)
        Me.Label65.Name = "Label65"
        Me.Label65.Size = New System.Drawing.Size(38, 18)
        Me.Label65.TabIndex = 23
        Me.Label65.Text = "Unit:"
        Me.Label65.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label66
        '
        Me.Label66.Location = New System.Drawing.Point(4, 67)
        Me.Label66.Name = "Label66"
        Me.Label66.Size = New System.Drawing.Size(38, 18)
        Me.Label66.TabIndex = 22
        Me.Label66.Text = "Qty:"
        Me.Label66.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label67
        '
        Me.Label67.Location = New System.Drawing.Point(10, 102)
        Me.Label67.Name = "Label67"
        Me.Label67.Size = New System.Drawing.Size(76, 18)
        Me.Label67.TabIndex = 28
        Me.Label67.Text = "Description:"
        Me.Label67.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label68
        '
        Me.Label68.Location = New System.Drawing.Point(10, 28)
        Me.Label68.Name = "Label68"
        Me.Label68.Size = New System.Drawing.Size(38, 18)
        Me.Label68.TabIndex = 18
        Me.Label68.Text = "Date:"
        Me.Label68.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'udtTranDate
        '
        Appearance1.BackColorDisabled = System.Drawing.SystemColors.Control
        Appearance1.ForeColorDisabled = System.Drawing.Color.Black
        Me.udtTranDate.Appearance = Appearance1
        Me.udtTranDate.DateTime = New Date(1753, 1, 1, 0, 0, 0, 0)
        Me.udtTranDate.Location = New System.Drawing.Point(48, 28)
        Me.udtTranDate.Name = "udtTranDate"
        Me.udtTranDate.Size = New System.Drawing.Size(106, 24)
        Me.udtTranDate.TabIndex = 0
        Me.udtTranDate.Tag = ".TranDate"
        Me.udtTranDate.Value = Nothing
        '
        'btnSelFromCustID
        '
        Me.btnSelFromCustID.Location = New System.Drawing.Point(307, 240)
        Me.btnSelFromCustID.Name = "btnSelFromCustID"
        Me.btnSelFromCustID.Size = New System.Drawing.Size(58, 24)
        Me.btnSelFromCustID.TabIndex = 35
        Me.btnSelFromCustID.Text = "Select"
        '
        'ucboDescription
        '
        Me.ucboDescription.AutoEdit = False
        Me.ucboDescription.DisplayMember = ""
        Me.ucboDescription.Location = New System.Drawing.Point(558, 65)
        Me.ucboDescription.Name = "ucboDescription"
        Me.ucboDescription.Size = New System.Drawing.Size(146, 24)
        Me.ucboDescription.TabIndex = 5
        Me.ucboDescription.Tag = ".Charge_Code...InvoiceChargeCodes.Charge_Code.Description"
        Me.ucboDescription.ValueMember = ""
        '
        'btnClear
        '
        Me.btnClear.Location = New System.Drawing.Point(264, 17)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(77, 25)
        Me.btnClear.TabIndex = 3
        Me.btnClear.Text = "&Clear"
        '
        'btnExit
        '
        Me.btnExit.Location = New System.Drawing.Point(595, 17)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(77, 25)
        Me.btnExit.TabIndex = 4
        Me.btnExit.Text = "E&xit"
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(186, 17)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(77, 25)
        Me.btnNew.TabIndex = 2
        Me.btnNew.Text = "&New"
        '
        'btnSave
        '
        Me.btnSave.Location = New System.Drawing.Point(19, 17)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(77, 25)
        Me.btnSave.TabIndex = 0
        Me.btnSave.Text = "&Save"
        '
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(96, 17)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(90, 25)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "&Edit"
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnClear)
        Me.GroupBox3.Controls.Add(Me.btnExit)
        Me.GroupBox3.Controls.Add(Me.btnNew)
        Me.GroupBox3.Controls.Add(Me.btnSave)
        Me.GroupBox3.Controls.Add(Me.btnEdit)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox3.Location = New System.Drawing.Point(0, 568)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(700, 46)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        '
        'InvoiceMiscCharges
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(6, 15)
        Me.ClientSize = New System.Drawing.Size(700, 614)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "InvoiceMiscCharges"
        Me.Tag = "InvoiceMiscCharges"
        Me.Text = "Miscellaneous Charges"
        Me.Panel1.ResumeLayout(False)
        CType(Me.UltraTextEditor1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utRowID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.uteToContact, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uteToEmail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uteToLocName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uteToZip, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uteToCity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uteToAdd2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uteToAdd1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uteToLocID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucToState, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.uteFromLocID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucFromState, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uteFromContact, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uteFromLocName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uteFromZip, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uteFromCity, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uteFromAdd2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uteFromAdd1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uteFromEmail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uteToCustName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uteToCustID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uteFromCustName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uteFromCustID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uteRef3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uteRef2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uteRef1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uteTrackingNum, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uteBillToCustName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uteBillToCustID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uteDescription, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uteCharge, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uteUnit, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.uteQty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.udtTranDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucboDescription, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region
    Private Sub InvoiceMiscCharges_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim MinWinSize As System.Drawing.Size

        AddHandler Me.Activated, AddressOf Form_Activated

        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = BILLTblPath & Me.Tag
            End If
        End If

        Me.CenterToScreen()
        AddHandler Me.KeyUp, AddressOf Form_KeyUp

        Me.KeyPreview = True
        MeText = Me.Text

        ' Set each control's length based on DB size
        SetupCtrlsLength(Me, AppDBName, AppDBUser, AppDBPass)

        LoadData()

        Group_EnDis(False)

        If bStartInNewMode = True Then
            btnNew.PerformClick()
            'uteBillToCustID.Focus()
        End If
    End Sub

    Private Sub LoadData()
        AddHandler ucFromState.Leave, AddressOf UCbo_Leave
        AddHandler ucToState.Leave, AddressOf UCbo_Leave

        If bStartInNewMode = False Then
            AddHandler ucboDescription.Leave, AddressOf UCbo_Leave
            'FillUCombo(ucboDescription, "", "", "", BILLTblPath)
            FillUCombo(ucboDescription, "", "", "", BILLTblPath)
            'FillUCombo(ucboDescription, "")
            ucboDescription.Text = ""
        Else
            'Me.ucboDescription.Tag = ".Charge_Code.View.1.InvoiceChargeCodes.Charge_Code.Description"
            'AddHandler ucboDescription.Leave, AddressOf UCbo_Leave
            'FillUCombo(ucboDescription, "Miscellaneous Charge", "", "", BILLTblPath)
            FillUCombo(ucboDescription, "", "", "", BILLTblPath)
            ucboDescription.Text = "Miscellaneous Charge"
            'ucboDescription.Tag = ".BCycleCode.View.1.BillingCycles.CODE.Name"
            'FillUCombo(ucboDescription, "MISC", "", "", BILLTblPath)
            'AddHandler ucboDescription.Leave, AddressOf UCbo_Leave
            'ucboDescription.Text = "MISC"
            'ucboDescription.Text = "MISC"
        End If
        'FillUCombo(ucFromState, "CA")
        'FillUCombo(ucToState, "CA")
        FillUCombo(ucFromState, "", "", "", BILLTblPath)
        FillUCombo(ucToState, "", "", "", BILLTblPath)
    End Sub
    Private Sub Group_EnDis(ByVal status As Boolean)
        btnSave.Enabled = status
        Btn_En(status)
        ucboDescription.Enabled = status
    End Sub
    Private Sub Btn_En(ByVal status As Boolean)
        If status = True Then 'Enable Editing
            Panel1.Enabled = True
            btnSave.Enabled = True
            btnClear.Enabled = True
        Else 'End Editing
            Panel1.Enabled = False
            btnSave.Enabled = False
            btnClear.Enabled = False
            btnNew.Enabled = True
        End If
    End Sub

    Private Sub btnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        SaveData()
    End Sub

    Private Sub SaveData()
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        Dim Condition As String

        If udtTranDate.Text.Trim = "" Then
            MsgBox("Date field is empty!", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        ElseIf uteCharge.Text.Trim = "" Then
            MsgBox("Charge field is empty!", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        ElseIf uteDescription.Text.Trim = "" Then
            MsgBox("Description field is empty!", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        ElseIf uteBillToCustID.Text.Trim = "" Then
            MsgBox("Bill To Customer ID field is empty!", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        ElseIf uteBillToCustName.Text.Trim = "" Then
            MsgBox("Bill To Customer Name field is empty!", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        ElseIf ucboDescription.Text.Trim = "" Then
            MsgBox("Description of Charge Code field is empty!", MsgBoxStyle.Exclamation, "Error")
            Exit Sub
        End If

        If uteQty.Text.Trim = "" Then
            uteQty.Text = 0
        End If

        If btnEdit.Text = "&Cancel" Then
            Condition = " WHERE RowID = " & utRowID.Text & " "
        Else
            Condition = ""
        End If

        If EditForm(Me, SQLSelect, EditAction.ENDEDIT, cmdTrans, Condition) Then
            'Dim row As DataRow
            Dim dtA As New SqlDataAdapter

            PopulateDataset2(dtA, dtSet, SQLSelect)

            btnNew.Text = "&New"
            btnEdit.Text = "&Edit"
            Group_EnDis(False)
            LoadData()
            ClearForm(Me)
            If bStartInNewMode = True Then
                Me.Close()
            End If
        End If
    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        'If btnEdit.Text = "&Cancel" Then
        '    MessageBox.Show("You are in 'Edit' mode. Cancel or Save your current job first.")
        '    Exit Sub
        'End If
        'Debug.Write("btnNew_Click")
        If bStartInNewMode = True Then
            If sender.text = "&New" Then
                GroupBox1.Enabled = True
                GroupBox2.Enabled = True
                sender.text = "&Cancel"
                Group_EnDis(True)
                btnEdit.Enabled = False
                'uteBillToCustID.Focus()
                udtTranDate.Focus()
            Else
                If MessageBox.Show("Do you want to cansel the charge of Customer(s) for printed flip-cards?", "Cancel of Miscellaneous Charges Input Prompt", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) = DialogResult.OK Then
                    Me.Close()
                End If
            End If
        Else
            If sender.text = "&New" Then
                ClearForm(Me)
                'FillUCombo(ucFromState, "CA")
                'FillUCombo(ucToState, "CA")
                GroupBox1.Enabled = False
                GroupBox2.Enabled = False
                sender.text = "&Cancel"
                Group_EnDis(True)
                udtTranDate.Focus()
            Else
                ClearForm(Me)
                sender.text = "&New"
                Group_EnDis(False)
                'btnSave.Enabled = True
                'btnSave.Focus()
            End If
        End If
    End Sub
    Private Sub Value_Int_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles uteQty.KeyPress, uteToZip.KeyPress
        If IsNumeric(e.KeyChar) = False And Asc(e.KeyChar) <> Keys.Back And e.KeyChar <> "-" And e.KeyChar <> "." And e.KeyChar <> "," Then
            e.Handled = True
        End If
    End Sub
    Private Sub Value_Dec_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles uteCharge.KeyPress
        If IsNumeric(e.KeyChar) = False And Asc(e.KeyChar) <> Keys.Back And e.KeyChar <> "-" And e.KeyChar <> "." Then
            e.Handled = True
        End If
    End Sub

    Private Sub ucboSvcType_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles ucToState.KeyPress
        If Asc(e.KeyChar) = 13 Then
            e.Handled = True
            SendKeys.Send("{TAB}")
        End If
    End Sub

    Private Sub btnSelectPickup_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelectDelivery.Click, btnSelectPickup.Click
        Dim SelectSQL As String
        Dim SelectSQL2 As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow

        If btnSelectPickup.Focused = True Then
            If uteFromCustID.Text.Trim = "" Then
                MsgBox("To chouse Pick-Up Location, fill in From Customer ID field!", MsgBoxStyle.Exclamation, "Error")
                Exit Sub
            End If
            SelectSQL = "Select LocationID, Name, Address1, Address2, City, State, Zip, Contact, Phone, Active, Email, AddressID from  " & BILLTblPath & "LOCATION where Active = 'Y' AND CustomerID = '" & uteFromCustID.Text & "' order by Name"
            PopulateDataset2(dtAdapter, dtSet, SelectSQL)
        Else
            If uteToCustID.Text.Trim = "" Then
                MsgBox("To chouse Delivery Location, fill in To Customer ID field!", MsgBoxStyle.Exclamation, "Error")
                Exit Sub
            End If
            SelectSQL = "Select LocationID, Name, Address1, Address2, City, State, Zip, Contact, Phone, Active, Email, AddressID from  " & BILLTblPath & "LOCATION where Active = 'Y' AND CustomerID = '" & uteToCustID.Text & "' order by Name"
            PopulateDataset2(dtAdapter, dtSet, SelectSQL)
        End If

        dtView.Table = dtSet.Tables(0)
        If dtView.Table.Rows.Count > 0 Then
            Dim Srch As New SearchListings
            Srch.dsList = dtSet

            Srch.Text = "Locations of Miscellaneous Charges"
            If btnSelectPickup.Focused = True Then
                Srch.UltraGrid1.Text = "Pick-Up Locations"
            Else
                Srch.UltraGrid1.Text = "Delivery Locations"
            End If

            Srch.ShowDialog()
            If Srch.DialogResult <> DialogResult.OK Then Exit Sub
            Try
                Dim cnt As Integer
                cnt = Srch.UltraGrid1.Rows.Count
            Catch Err As System.Exception
                Srch = Nothing
                sender.Focus()
                HasErr = True
                Exit Try
            Catch Err2 As System.NullReferenceException
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

                    If btnSelectPickup.Focused = True Then
                        uteFromLocID.Text = ugRow.Cells("LocationID").Text
                        uteFromAdd1.Text = ugRow.Cells("Address1").Text
                        uteFromAdd2.Text = ugRow.Cells("Address2").Text
                        uteFromCity.Text = ugRow.Cells("City").Text
                        ucFromState.Text = ugRow.Cells("State").Text
                        uteFromZip.Text = ugRow.Cells("Zip").Text
                        uteFromLocName.Text = ugRow.Cells("Name").Text
                        uteFromContact.Text = ugRow.Cells("Contact").Text
                        umeFromPhone.Text = ugRow.Cells("Phone").Text
                        uteFromEmail.Text = ugRow.Cells("Email").Text
                        FromAddID.Text = ugRow.Cells("AddressID").Text
                    End If
                    If btnSelectDelivery.Focused = True Then
                        uteToLocID.Text = ugRow.Cells("LocationID").Text
                        uteToAdd1.Text = ugRow.Cells("Address1").Text
                        uteToAdd2.Text = ugRow.Cells("Address2").Text
                        uteToCity.Text = ugRow.Cells("City").Text
                        ucToState.Text = ugRow.Cells("State").Text
                        uteToZip.Text = ugRow.Cells("Zip").Text
                        uteToLocName.Text = ugRow.Cells("Name").Text
                        uteToContact.Text = ugRow.Cells("Contact").Text
                        umeToPhone.Text = ugRow.Cells("Phone").Text
                        uteToEmail.Text = ugRow.Cells("Email").Text
                        ToAddID.Text = ugRow.Cells("AddressID").Text
                    End If
                    Srch = Nothing
                End If
            End Try
        End If

    End Sub

    Private Sub uteFromLocID_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles uteFromLocID.KeyUp, uteToLocID.KeyUp
        TypeAhead(sender, e, BILLTblPath & "Location", "LocationID")
    End Sub
    Private Sub uteFromLocID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles uteFromLocID.Leave, uteToLocID.Leave
        Dim row As DataRow
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow

        If sender.Modified = False Then Exit Sub

        If sender.text.trim = "" Then
            If uteFromLocID.ContainsFocus = True Then
                uteFromAdd1.Text = ""
                uteFromAdd2.Text = ""
                uteFromCity.Text = ""
                ucFromState.Text = ""
                uteFromZip.Text = ""
                uteFromLocName.Text = ""
                uteFromContact.Text = ""
                umeFromPhone.Text = ""
                uteFromEmail.Text = ""
                uteFromLocID.Focus()
            End If
            If uteToLocID.ContainsFocus = True Then
                'uteToLocID.Text = ""
                uteToAdd1.Text = ""
                uteToAdd2.Text = ""
                uteToCity.Text = ""
                ucToState.Text = ""
                uteToZip.Text = ""
                uteToLocName.Text = ""
                uteToContact.Text = ""
                umeToPhone.Text = ""
                uteToEmail.Text = ""
                uteToLocID.Focus()
            End If
            sender.text = ""
            Exit Sub
        ElseIf uteFromLocID.ContainsFocus = True Then
            If SearchOnLeave(sender, sender, BILLTblPath & "Location", "LocationID", "LocationID", , , "where CustomerID = " & uteFromCustID.Text & " AND Active = 'Y'") Then
                If ReturnRowByID(uteFromLocID.Text, row, BILLTblPath & "Location", "Where Active = 'Y'", "LocationID") Then
                    uteFromLocName.Text = row("Name")
                    uteFromAdd1.Text = row("Address1")
                    uteFromAdd2.Text = row("Address2")
                    uteFromCity.Text = row("City")
                    ucFromState.Text = row("State")
                    uteFromZip.Text = row("Zip")
                    uteFromLocName.Text = row("Name")
                    uteFromContact.Text = row("Contact")
                    umeFromPhone.Text = row("Phone")
                    uteFromEmail.Text = row("Email")
                    FromAddID.Text = row("AddressID")
                    uteToCustID.Focus()
                End If
            End If
        ElseIf uteToLocID.ContainsFocus = True Then
            If SearchOnLeave(sender, sender, BILLTblPath & "Location", "LocationID", "LocationID", , , "where CustomerID = " & uteToCustID.Text & " AND Active = 'Y'") Then
                If ReturnRowByID(uteToLocID.Text, row, BILLTblPath & "Location", "Where Active = 'Y'", "LocationID") Then
                    uteToLocName.Text = row("Name")
                    uteToAdd1.Text = row("Address1")
                    uteToAdd2.Text = row("Address2")
                    uteToCity.Text = row("City")
                    ucToState.Text = row("State")
                    uteToZip.Text = row("Zip")
                    uteToLocName.Text = row("Name")
                    uteToContact.Text = row("Contact")
                    umeToPhone.Text = row("Phone")
                    uteToEmail.Text = row("Email")
                    ToAddID.Text = row("AddressID")
                    btnSave.Focus()
                End If
            End If
        End If
        row = Nothing
        sender.Modified = False
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        If MsgBox("Are you sure that you want to clear all data?", MsgBoxStyle.YesNo, "Invoice Miscellaneous Charges") = MsgBoxResult.No Then
            Exit Sub
        End If
        'FillUCombo(ucboDescription, "")
        ClearForm(Me)
        LoadData()
        'FillUCombo(ucboDescription, "")
    End Sub
    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub InvoiceMiscCharges_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        'If btnNew.Text = "&Cancel" Then
        If bStartInNewMode = False Then

            If btnEdit.Text = "&Cancel" Or btnNew.Text = "&Cancel" Then
                If MsgBox("Data is not saved! Are you sure you want to exit?", MsgBoxStyle.YesNo, "Invoice Miscellaneous Charges") = MsgBoxResult.No Then
                    e.Cancel = True
                    Exit Sub
                End If
            End If

            If Not cmdTrans Is Nothing Then
                If EditForm(Me, SQLSelect, EditAction.CANCEL, cmdTrans) Then
                    Group_EnDis(False)
                    sender.text = "&New"
                Else
                End If
            End If
        End If
    End Sub

    Private Sub btnSelFromCustID_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSelToCustID.Click, btnSelFromCustID.Click, btnSelBillToCust.Click
        Dim SelectSQL As String
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow

        SelectSQL = "Select * from  " & BILLTblPath & "CUSTOMER Where Active = 'Y' Order by CustomerID"
        PopulateDataset2(dtAdapter, dtSet, SelectSQL)

        dtView.Table = dtSet.Tables(0)
        If dtView.Table.Rows.Count > 0 Then
            Dim Srch As New SearchListings
            Srch.dsList = dtSet

            Srch.Text = "List of Customers for Miscellaneous Charges"
            If btnSelFromCustID.Focused = True Then
                Srch.UltraGrid1.Text = "List of From Customers"
            ElseIf btnSelToCustID.Focused = True Then
                Srch.UltraGrid1.Text = "List of To Customers"
            Else
                Srch.UltraGrid1.Text = "List of Bill To Customers"
            End If
            'End If

            Srch.ShowDialog()
            If Srch.DialogResult <> DialogResult.OK Then Exit Sub
            Try
                Dim cnt As Integer
                cnt = Srch.UltraGrid1.Rows.Count
            Catch Err As System.Exception
                Srch = Nothing
                sender.Focus()
                HasErr = True
                Exit Try
            Catch Err2 As System.NullReferenceException
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

                    If btnSelFromCustID.Focused = True Then
                        uteFromCustID.Text = ugRow.Cells("CustomerID").Text
                        uteFromCustName.Text = ugRow.Cells("Name").Text
                        GroupBox1.Enabled = True
                    End If
                    If btnSelToCustID.Focused = True Then
                        uteToCustID.Text = ugRow.Cells("CustomerID").Text
                        uteToCustName.Text = ugRow.Cells("Name").Text
                        GroupBox2.Enabled = True
                    End If
                    If btnSelBillToCust.Focused = True Then
                        uteBillToCustID.Text = ugRow.Cells("CustomerID").Text
                        uteBillToCustName.Text = ugRow.Cells("Name").Text
                    End If
                    Srch = Nothing
                End If
            End Try
        End If

    End Sub

    Private Sub uteFromCustID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles uteFromCustID.Leave, uteToCustID.Leave, uteBillToCustID.Leave
        Dim row As DataRow
        'Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow

        If sender.Modified = False Then Exit Sub

        If sender.text.trim = "" Then
            If uteFromCustID.ContainsFocus = True Then
                uteFromCustID.Text = ""
                uteFromCustName.Text = ""
                'uteFromCustID.Focus()
            End If
            If uteToCustID.ContainsFocus = True Then
                uteToCustID.Text = ""
                uteToCustName.Text = ""
                'uteToCustID.Focus()
            End If
            If uteBillToCustID.ContainsFocus = True Then
                uteBillToCustID.Text = ""
                uteBillToCustName.Text = ""
                'uteBillToCustID.Focus()
            End If
            sender.text = ""
            Exit Sub

        ElseIf uteFromCustID.ContainsFocus = True Then
            If SearchOnLeave(sender, sender, BILLTblPath & "Customer", "CustomerID", "CustomerID", , , " Where Active = 'Y' ") Then
                If ReturnRowByID(uteFromCustID.Text, row, BILLTblPath & "Customer", " Where Active = 'Y' ", "CustomerID") Then
                    uteFromCustName.Text = row("Name")
                    GroupBox1.Enabled = True
                    uteFromLocID.Focus()
                End If
            End If
        ElseIf uteToCustID.ContainsFocus = True Then
            If SearchOnLeave(sender, sender, BILLTblPath & "Customer", "CustomerID", "CustomerID", , , " Where Active = 'Y' ") Then
                If ReturnRowByID(uteToCustID.Text, row, BILLTblPath & "Customer", " Where Active = 'Y' ", "CustomerID") Then
                    uteToCustName.Text = row("Name")
                    GroupBox2.Enabled = True
                    uteToLocID.Focus()
                End If
            End If
        ElseIf uteBillToCustID.ContainsFocus = True Then
            If SearchOnLeave(sender, sender, BILLTblPath & "Customer", "CustomerID", "CustomerID", , , " Where Active = 'Y' ") Then
                If ReturnRowByID(uteBillToCustID.Text, row, BILLTblPath & "Customer", " Where Active = 'Y' ", "CustomerID") Then
                    uteBillToCustName.Text = row("Name")
                    ''uteTrackingNum.Focus()
                    uteQty.Focus()
                End If
            End If
        End If
        row = Nothing
        'sender.focus()
        sender.Modified = False
    End Sub
    Private Sub uteFromCustID_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles uteFromCustID.KeyUp, uteToCustID.KeyUp, uteBillToCustID.KeyUp
        TypeAhead(sender, e, BILLTblPath & "Customer", "CustomerID")
    End Sub
    Private Sub uteFromCustName_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles uteFromCustName.KeyUp, uteToCustName.KeyUp, uteBillToCustName.KeyUp
        TypeAhead(sender, e, BILLTblPath & "Customer", "Name")
    End Sub
    Private Sub uteFromCustName_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles uteFromCustName.Leave, uteToCustName.Leave, uteBillToCustName.Leave
        Dim row As DataRow
        'Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow

        If sender.Modified = False Then Exit Sub

        If sender.text.trim = "" Then
            If uteFromCustName.ContainsFocus = True Then
                uteFromCustID.Text = ""
                'uteFromCustName.Text = ""
                'uteFromCustName.Focus()
            End If
            If uteToCustName.ContainsFocus = True Then
                uteToCustID.Text = ""
                'uteToCustName.Text = ""
                'uteToCustName.Focus()
            End If
            If uteBillToCustName.ContainsFocus = True Then
                uteBillToCustID.Text = ""
                'uteBillToCustName.Focus()
            End If
            sender.text = ""
            Exit Sub

        ElseIf uteFromCustName.ContainsFocus = True Then
            If SearchOnLeave(sender, sender, BILLTblPath & "Customer", "Name", "Name") Then
                If ReturnRowByName(uteFromCustName.Text, row, BILLTblPath & "Customer", "", "Name") Then
                    uteFromCustID.Text = row("CustomerID")
                    GroupBox1.Enabled = True
                    uteFromLocID.Focus()
                End If
            End If
        ElseIf uteToCustName.ContainsFocus = True Then
            If SearchOnLeave(sender, sender, BILLTblPath & "Customer", "Name", "Name") Then
                If ReturnRowByName(uteToCustName.Text, row, BILLTblPath & "Customer", "", "Name") Then
                    uteToCustID.Text = row("CustomerID")
                    GroupBox2.Enabled = True
                    uteToLocID.Focus()
                End If
            End If
        ElseIf uteBillToCustName.ContainsFocus = True Then
            If SearchOnLeave(sender, sender, BILLTblPath & "Customer", "Name", "Name") Then
                If ReturnRowByName(uteBillToCustName.Text, row, BILLTblPath & "Customer", "", "Name") Then
                    uteBillToCustID.Text = row("CustomerID")
                    'GroupBox2.Enabled = True
                    'uteToLocID.Focus()
                    ''uteTrackingNum.Focus()
                    uteQty.Focus()
                End If
            End If
        End If
        'row.Delete()
        row = Nothing
        'sender.focus()
        sender.Modified = False
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

    Private Sub uteFromCity_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles uteFromCity.KeyUp ', uteToCity.KeyUp

        TypeAhead(sender, e, BILLTblPath & "City", "Name", "AND StateCode = '" & GetNextControl(sender, True).Text & "'")
        'sender.modified = True
    End Sub
    Private Sub uteFromZip_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles uteFromZip.KeyPress
        If IsNumeric(e.KeyChar) = False And Asc(e.KeyChar) <> Keys.Back Then
            e.Handled() = True
        End If
    End Sub
    Private Sub uteFromCity_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles uteFromCity.Leave, uteFromZip.Leave
        Dim row As DataRow
        Dim FldName As String
        Dim gZip, gCity As Control
        Dim gState As Object

        Select Case sender.name
            Case "uteFromCity"
                gZip = uteFromZip
                gState = ucFromState
                gCity = uteFromCity
                FldName = "Name"
            Case "uteFromZip"
                gZip = uteFromZip
                gState = ucFromState
                gCity = uteFromCity
                FldName = "Zipcode"
            Case Else
                MsgBox("Wrong Control!")
                Exit Sub
        End Select

        If sender.text.trim = "" Then
            sender.modified = False
            sender.Text = ""
            gZip.Text = ""
            gCity.Text = ""
            gState.Text = ""
        ElseIf SearchOnLeave(sender, gZip, BILLTblPath & "City", "Zipcode", FldName, "*", "Cities") Then
            If ReturnRowByID(gZip.Text, row, BILLTblPath & "City", , "Zipcode") Then
                If TypeOf gState Is ComboBox Then
                    gState.SelectedValue = row("StateCode")
                Else
                    gState.value = row("StateCode")
                End If
                gZip.Text = row("ZipCode")
                gCity.Text = row("Name")
                'ucboAcctBillingCycle.Value = row("BCycleCode")
            End If
            'row.Delete()
            row = Nothing
        End If
    End Sub

    Private Sub uteToCity_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles uteToCity.KeyUp

        TypeAhead(sender, e, BILLTblPath & "City", "Name", "AND StateCode = '" & GetNextControl(sender, True).Text & "'")
        'sender.modified = True
    End Sub
    Private Sub uteToZip_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles uteToZip.KeyPress
        If IsNumeric(e.KeyChar) = False And Asc(e.KeyChar) <> Keys.Back Then
            e.Handled() = True
        End If
    End Sub
    Private Sub uteToCity_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles uteToCity.Leave, uteToZip.Leave
        Dim row As DataRow
        Dim FldName As String
        Dim gZip, gCity As Control
        Dim gState As Object

        Select Case sender.name
            Case "uteToCity"
                gZip = uteToZip
                gState = ucToState
                gCity = uteToCity
                FldName = "Name"
            Case "uteToZip"
                gZip = uteToZip
                gState = ucToState
                gCity = uteToCity
                FldName = "Zipcode"
            Case Else
                MsgBox("Wrong Control!")
                Exit Sub
        End Select

        If sender.text.trim = "" Then
            sender.modified = False
            sender.Text = ""
            gZip.Text = ""
            gCity.Text = ""
            gState.Text = ""
        ElseIf SearchOnLeave(sender, gZip, BILLTblPath & "City", "Zipcode", FldName, "*", "Cities") Then
            If ReturnRowByID(gZip.Text, row, BILLTblPath & "City", , "Zipcode") Then
                If TypeOf gState Is ComboBox Then
                    gState.SelectedValue = row("StateCode")
                Else
                    gState.value = row("StateCode")
                End If
                gZip.Text = row("ZipCode")
                gCity.Text = row("Name")
                'ucboAcctBillingCycle.Value = row("BCycleCode")
            End If
            'row.Delete()
            row = Nothing
        End If
    End Sub
    Private Sub Value_Char_KeyPress(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyPressEventArgs)
        If IsArray(e.KeyChar) = False Then 'And Asc(e.KeyChar) <> Keys.Back 'And e.KeyChar <> "-" Then
            e.Handled = True
        End If
    End Sub
    'Function just permanent feature
    Private Sub uteQty_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles uteQty.Leave
        'Dim row As DataRow

        If sender.Modified = False Then Exit Sub
        If sender.text.trim = "" Then
            uteCharge.Text = ""
            sender.text = ""
            Exit Sub
        End If
        If UltraTextEditor1.Text.Trim <> "" Then
            If IsNumeric(UltraTextEditor1.Text.Trim) Then
                Dim sTotal As Double
                sTotal = CDbl(sender.Text) * CDbl(UltraTextEditor1.Text.Trim)
                Math.Round(sTotal, 3)
                sTotal.ToString("N")
                uteCharge.Text = sTotal
            End If
        End If
        'sender.focus()
    End Sub

    Private Sub btnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        Dim sqlEditQuery As String = "Select RowID, Invoice_No, TranDate, BillToCustID, BillToCustName, Charge_Code, Description, Qty, Unit, Charge, Taxable, TrackingNum, Ref1, Ref2, Ref3, " & _
                                " FromAddID, FromCustID, FromCustName, FromLocID, FromLocName, FromAdd1, FromAdd2, FromCity, FromState, FromZip, FromContact, FromPhone, " & _
                                " FromEmail, ToAddID, ToCustID, ToCustName, ToLocID, ToLocName, ToAdd1, ToAdd2, ToCity, ToState, ToZip, ToContact, ToPhone, ToEmail " & _
                                " FROM " & BILLTblPath & "InvoiceMiscCharges "
        Dim CritTmp As String = " WHERE RowID = @@ROWID "
        Dim dtAdapter As New SqlDataAdapter
        Dim dtSet As New DataSet
        Dim dtView As New DataView
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow


        If btnNew.Text = "&Cancel" Then
            MessageBox.Show("You are in 'New' mode. Cancel or Save your current job first.")
            Exit Sub
        End If


        ' Lock Records
        If sender.text.toupper = "&EDIT" Then
            If PopulateDataset2(dtAdapter, dtSet, sqlEditQuery & " WHERE Invoice_No is NULL or Invoice_No = 0 " & " ORDER BY TranDate, BillToCustID ") Is Nothing Then
                Exit Sub
            End If

            dtView.Table = dtSet.Tables(0)
            If dtView.Table.Rows.Count > 0 Then
                Dim Srch As New SearchListings
                Srch.dsList = dtSet

                Srch.Text = "List of Unbilled Miscellaneous Charges"
                Srch.UltraGrid1.Text = "List of Unbilled Miscellaneous Charges"

                Srch.ShowDialog()
                If Srch.DialogResult <> DialogResult.OK Then Exit Sub
                Try
                    Dim cnt As Integer
                    cnt = Srch.UltraGrid1.Rows.Count
                Catch Err As System.Exception
                    Srch = Nothing
                    sender.Focus()
                    HasErr = True
                    Exit Try
                Catch Err2 As System.NullReferenceException
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
                        utRowID.Text = ugRow.Cells("RowID").Value
                        CritTmp = CritTmp.Replace("@@ROWID", utRowID.Text)
                        'LoadData2(utRowID.Text)
                        Dim dvSelection As New DataView

                        dvSelection.Table = dtSet.Tables(0)
                        dvSelection.RowFilter = "RowID=" & CStr(ugRow.Cells("RowID").Value)

                        FormLoad(Me, dvSelection)

                        Srch.Dispose()
                        Srch = Nothing
                        dvSelection.Dispose()
                        dvSelection = Nothing
                        ugRow.Dispose()
                        ugRow = Nothing
                    End If
                End Try
            End If


            If EditForm(Me, PrepSelectQuery(sqlEditQuery, CritTmp), EditAction.START, cmdTrans) Then
                If uteFromCustID.Text.Trim = "" Then
                    GroupBox1.Enabled = False
                End If
                If uteToCustID.Text.Trim = "" Then
                    GroupBox2.Enabled = False
                End If
                sender.text = "&Cancel"
                Group_EnDis(True)
                udtTranDate.Focus()
            End If
        Else
            If EditForm(Me, sqlEditQuery, EditAction.CANCEL, cmdTrans) Then
                Group_EnDis(False)
                sender.text = "&Edit"
            End If
        End If

        dtView.Dispose()
        dtView = Nothing
        dtSet.Dispose()
        dtSet = Nothing
        dtAdapter.Dispose()
        dtAdapter = Nothing
    End Sub


    Private Sub UltraTextEditor1_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraTextEditor1.Leave
        Dim row As DataRow

        If sender.Modified = False Then Exit Sub
        If sender.text.trim = "" Then
            uteCharge.Text = ""
            sender.text = ""
            Exit Sub
        Else
            Dim sTotal As Double
            sTotal = CDbl(uteQty.Text) * CDbl(sender.text)
            Math.Round(sTotal, 3)
            sTotal.ToString("N")
            uteCharge.Text = sTotal
        End If
        'sender.focus()

    End Sub

    'Private Sub uteBillToCustID_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles uteBillToCustID.CausesValidationChanged

    '    Debug.Write("uteBillToCustID_GotFocus")
    '    If bStartInNewMode = True Then
    '        UltraTextEditor1.Focus()
    '    End If
    'End Sub

    'Private Sub UltraTextEditor1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraTextEditor1.GotFocus

    '    If bStartInNewMode = True Then
    '        uteFromCustID.Focus()
    '    End If
    'End Sub

    'Private Sub uteFromCustID_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles uteFromCustID.GotFocus
    '    If bStartInNewMode = True Then
    '        uteToCustID.Focus()
    '    End If
    'End Sub

    'Private Sub uteToCustID_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles uteToCustID.GotFocus
    '    If bStartInNewMode = True Then
    '        btnSave.Focus()
    '    End If
    'End Sub


End Class
