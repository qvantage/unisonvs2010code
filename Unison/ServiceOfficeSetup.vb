Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors

Public Class ServiceOfficeSetup
    Inherits System.Windows.Forms.Form
    Dim SQLSelect As String = _
            "Select ID, Name, Contact, Street, Address2, City, State, Zipcode, Phone1, Phone2, " & _
            " Fax, email, web, RegionID, Password, Active From " & AppTblPath & "ServiceOffices WHERE ACTIVE = @ACTV ORDER BY ID" ' 


    Dim Srch As SearchListings

    Dim HidCols() As String = {"REGIONID", "ACTIVE"} 'Karina added Active


    Dim MeText As String
    Dim dtSet As New DataSet()
    Dim dvStates As New DataView()
    Dim cmdTrans As SqlCommand
    Dim m_oColumn As Infragistics.Win.UltraWinGrid.UltraGridColumn = Nothing


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

            dtSet = Nothing

            If btnEdit.Text.ToUpper <> "&EDIT" Then
                If EditForm(Me, SQLSelect, EditAction.CANCEL, cmdTrans) Then
                    Group_EnDis(False)
                    btnEdit.Text = "&Edit"
                Else 'Exit Sub ?

                End If
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
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Web As System.Windows.Forms.TextBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents UltraGrid1 As Infragistics.Win.UltraWinGrid.UltraGrid
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnAsgnZones As System.Windows.Forms.Button
    Friend WithEvents btnDelete As System.Windows.Forms.Button
    Friend WithEvents btnNew As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents btnEdit As System.Windows.Forms.Button
    Friend WithEvents OFFICEID As System.Windows.Forms.TextBox
    Friend WithEvents email As System.Windows.Forms.TextBox
    Friend WithEvents Fax As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents Phone2 As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents Phone1 As Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
    Friend WithEvents Zipcode As System.Windows.Forms.TextBox
    Friend WithEvents State As System.Windows.Forms.ComboBox
    Friend WithEvents City As System.Windows.Forms.TextBox
    Friend WithEvents Street As System.Windows.Forms.TextBox
    Friend WithEvents OfficeName As System.Windows.Forms.TextBox
    Friend WithEvents CntMenu1 As System.Windows.Forms.ContextMenu
    Friend WithEvents cboRegion As System.Windows.Forms.ComboBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Address2 As System.Windows.Forms.TextBox
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Contact As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents btnActivation As System.Windows.Forms.Button
    Friend WithEvents cbxActive As System.Windows.Forms.CheckBox
    Friend WithEvents btnDeActivate As System.Windows.Forms.Button
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.btnDeActivate = New System.Windows.Forms.Button
        Me.btnActivation = New System.Windows.Forms.Button
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnAsgnZones = New System.Windows.Forms.Button
        Me.btnDelete = New System.Windows.Forms.Button
        Me.btnNew = New System.Windows.Forms.Button
        Me.btnSave = New System.Windows.Forms.Button
        Me.btnEdit = New System.Windows.Forms.Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.cbxActive = New System.Windows.Forms.CheckBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.Label13 = New System.Windows.Forms.Label
        Me.Contact = New System.Windows.Forms.TextBox
        Me.Address2 = New System.Windows.Forms.TextBox
        Me.cboRegion = New System.Windows.Forms.ComboBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.Web = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.OFFICEID = New System.Windows.Forms.TextBox
        Me.email = New System.Windows.Forms.TextBox
        Me.Label10 = New System.Windows.Forms.Label
        Me.Fax = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
        Me.Label9 = New System.Windows.Forms.Label
        Me.Phone2 = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
        Me.Label8 = New System.Windows.Forms.Label
        Me.Phone1 = New Infragistics.Win.UltraWinMaskedEdit.UltraMaskedEdit
        Me.Label7 = New System.Windows.Forms.Label
        Me.Zipcode = New System.Windows.Forms.TextBox
        Me.Label5 = New System.Windows.Forms.Label
        Me.State = New System.Windows.Forms.ComboBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.City = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Street = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.OfficeName = New System.Windows.Forms.TextBox
        Me.Panel2 = New System.Windows.Forms.Panel
        Me.UltraGrid1 = New Infragistics.Win.UltraWinGrid.UltraGrid
        Me.CntMenu1 = New System.Windows.Forms.ContextMenu
        Me.GroupBox1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel2.SuspendLayout()
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnDeActivate)
        Me.GroupBox1.Controls.Add(Me.btnActivation)
        Me.GroupBox1.Controls.Add(Me.btnExit)
        Me.GroupBox1.Controls.Add(Me.btnAsgnZones)
        Me.GroupBox1.Controls.Add(Me.btnDelete)
        Me.GroupBox1.Controls.Add(Me.btnNew)
        Me.GroupBox1.Controls.Add(Me.btnSave)
        Me.GroupBox1.Controls.Add(Me.btnEdit)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox1.Location = New System.Drawing.Point(0, 451)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(838, 40)
        Me.GroupBox1.TabIndex = 2
        Me.GroupBox1.TabStop = False
        '
        'btnDeActivate
        '
        Me.btnDeActivate.Location = New System.Drawing.Point(360, 16)
        Me.btnDeActivate.Name = "btnDeActivate"
        Me.btnDeActivate.Size = New System.Drawing.Size(75, 21)
        Me.btnDeActivate.TabIndex = 7
        Me.btnDeActivate.Text = "DeActi&vate"
        '
        'btnActivation
        '
        Me.btnActivation.Location = New System.Drawing.Point(248, 16)
        Me.btnActivation.Name = "btnActivation"
        Me.btnActivation.Size = New System.Drawing.Size(104, 21)
        Me.btnActivation.TabIndex = 6
        Me.btnActivation.Text = "Show &InActive"
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnExit.Location = New System.Drawing.Point(760, 16)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(75, 21)
        Me.btnExit.TabIndex = 5
        Me.btnExit.Text = "E&xit"
        '
        'btnAsgnZones
        '
        Me.btnAsgnZones.Location = New System.Drawing.Point(456, 16)
        Me.btnAsgnZones.Name = "btnAsgnZones"
        Me.btnAsgnZones.Size = New System.Drawing.Size(96, 21)
        Me.btnAsgnZones.TabIndex = 4
        Me.btnAsgnZones.Text = "Ex&port to CSV"
        Me.btnAsgnZones.Visible = False
        '
        'btnDelete
        '
        Me.btnDelete.Location = New System.Drawing.Point(656, 16)
        Me.btnDelete.Name = "btnDelete"
        Me.btnDelete.Size = New System.Drawing.Size(75, 21)
        Me.btnDelete.TabIndex = 3
        Me.btnDelete.Text = "&Delete"
        Me.btnDelete.Visible = False
        '
        'btnNew
        '
        Me.btnNew.Location = New System.Drawing.Point(155, 16)
        Me.btnNew.Name = "btnNew"
        Me.btnNew.Size = New System.Drawing.Size(75, 21)
        Me.btnNew.TabIndex = 2
        Me.btnNew.Text = "&New"
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
        'btnEdit
        '
        Me.btnEdit.Location = New System.Drawing.Point(79, 16)
        Me.btnEdit.Name = "btnEdit"
        Me.btnEdit.Size = New System.Drawing.Size(75, 21)
        Me.btnEdit.TabIndex = 1
        Me.btnEdit.Text = "&Edit"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.cbxActive)
        Me.Panel1.Controls.Add(Me.Label14)
        Me.Panel1.Controls.Add(Me.TextBox1)
        Me.Panel1.Controls.Add(Me.Label13)
        Me.Panel1.Controls.Add(Me.Contact)
        Me.Panel1.Controls.Add(Me.Address2)
        Me.Panel1.Controls.Add(Me.cboRegion)
        Me.Panel1.Controls.Add(Me.Label12)
        Me.Panel1.Controls.Add(Me.Web)
        Me.Panel1.Controls.Add(Me.Label6)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Controls.Add(Me.OFFICEID)
        Me.Panel1.Controls.Add(Me.email)
        Me.Panel1.Controls.Add(Me.Label10)
        Me.Panel1.Controls.Add(Me.Fax)
        Me.Panel1.Controls.Add(Me.Label9)
        Me.Panel1.Controls.Add(Me.Phone2)
        Me.Panel1.Controls.Add(Me.Label8)
        Me.Panel1.Controls.Add(Me.Phone1)
        Me.Panel1.Controls.Add(Me.Label7)
        Me.Panel1.Controls.Add(Me.Zipcode)
        Me.Panel1.Controls.Add(Me.Label5)
        Me.Panel1.Controls.Add(Me.State)
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.City)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Street)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.OfficeName)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(838, 160)
        Me.Panel1.TabIndex = 0
        '
        'cbxActive
        '
        Me.cbxActive.Location = New System.Drawing.Point(672, 120)
        Me.cbxActive.Name = "cbxActive"
        Me.cbxActive.TabIndex = 29
        Me.cbxActive.Tag = ".ACTIVE"
        Me.cbxActive.Text = "Active"
        Me.cbxActive.Visible = False
        '
        'Label14
        '
        Me.Label14.Location = New System.Drawing.Point(240, 82)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(120, 16)
        Me.Label14.TabIndex = 28
        Me.Label14.Text = "Web Logon Password:"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'TextBox1
        '
        Me.TextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.TextBox1.Location = New System.Drawing.Point(360, 80)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(162, 20)
        Me.TextBox1.TabIndex = 11
        Me.TextBox1.Tag = ".PASSWORD"
        Me.TextBox1.Text = ""
        '
        'Label13
        '
        Me.Label13.Location = New System.Drawing.Point(16, 56)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(72, 16)
        Me.Label13.TabIndex = 26
        Me.Label13.Text = "Contact:"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Contact
        '
        Me.Contact.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Contact.Location = New System.Drawing.Point(88, 56)
        Me.Contact.Name = "Contact"
        Me.Contact.Size = New System.Drawing.Size(152, 20)
        Me.Contact.TabIndex = 2
        Me.Contact.Tag = ".CONTACT"
        Me.Contact.Text = ""
        '
        'Address2
        '
        Me.Address2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Address2.Location = New System.Drawing.Point(360, 32)
        Me.Address2.Name = "Address2"
        Me.Address2.Size = New System.Drawing.Size(240, 20)
        Me.Address2.TabIndex = 7
        Me.Address2.Tag = ".Address2"
        Me.Address2.Text = ""
        '
        'cboRegion
        '
        Me.cboRegion.Location = New System.Drawing.Point(672, 80)
        Me.cboRegion.Name = "cboRegion"
        Me.cboRegion.Size = New System.Drawing.Size(144, 21)
        Me.cboRegion.TabIndex = 14
        Me.cboRegion.Tag = ".REGIONID...REGIONS.ID.NAME"
        Me.cboRegion.Visible = False
        '
        'Label12
        '
        Me.Label12.Location = New System.Drawing.Point(624, 72)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(48, 32)
        Me.Label12.TabIndex = 23
        Me.Label12.Text = "Region :"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Label12.Visible = False
        '
        'Web
        '
        Me.Web.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Web.Location = New System.Drawing.Point(360, 128)
        Me.Web.Name = "Web"
        Me.Web.Size = New System.Drawing.Size(240, 20)
        Me.Web.TabIndex = 13
        Me.Web.Tag = ".web"
        Me.Web.Text = ""
        '
        'Label6
        '
        Me.Label6.Location = New System.Drawing.Point(296, 128)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(64, 16)
        Me.Label6.TabIndex = 20
        Me.Label6.Text = "Web:"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(24, 8)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(64, 16)
        Me.Label11.TabIndex = 11
        Me.Label11.Text = "Office ID:"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'OFFICEID
        '
        Me.OFFICEID.Location = New System.Drawing.Point(88, 8)
        Me.OFFICEID.Name = "OFFICEID"
        Me.OFFICEID.Size = New System.Drawing.Size(64, 20)
        Me.OFFICEID.TabIndex = 0
        Me.OFFICEID.Tag = ".id"
        Me.OFFICEID.Text = ""
        '
        'email
        '
        Me.email.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.email.Location = New System.Drawing.Point(360, 104)
        Me.email.Name = "email"
        Me.email.Size = New System.Drawing.Size(240, 20)
        Me.email.TabIndex = 12
        Me.email.Tag = ".EMAIL"
        Me.email.Text = ""
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(296, 104)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(64, 16)
        Me.Label10.TabIndex = 19
        Me.Label10.Text = "eMail:"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Fax
        '
        Me.Fax.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.Fax.InputMask = "(###)-###-####"
        Me.Fax.Location = New System.Drawing.Point(88, 128)
        Me.Fax.Name = "Fax"
        Me.Fax.TabIndex = 5
        Me.Fax.Tag = ".FAX"
        Me.Fax.Text = "()--"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(24, 128)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(64, 16)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "Fax:"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Phone2
        '
        Me.Phone2.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.Phone2.InputMask = "(###)-###-####"
        Me.Phone2.Location = New System.Drawing.Point(88, 104)
        Me.Phone2.Name = "Phone2"
        Me.Phone2.TabIndex = 4
        Me.Phone2.Tag = ".PHONE2"
        Me.Phone2.Text = "()--"
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(32, 104)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(56, 16)
        Me.Label8.TabIndex = 14
        Me.Label8.Text = "Phone 2:"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Phone1
        '
        Me.Phone1.EditAs = Infragistics.Win.UltraWinMaskedEdit.EditAsType.UseSpecifiedMask
        Me.Phone1.InputMask = "(###)-###-####"
        Me.Phone1.Location = New System.Drawing.Point(88, 80)
        Me.Phone1.Name = "Phone1"
        Me.Phone1.TabIndex = 3
        Me.Phone1.Tag = ".PHONE1"
        Me.Phone1.Text = "()--"
        '
        'Label7
        '
        Me.Label7.Location = New System.Drawing.Point(24, 80)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(64, 16)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "Phone 1:"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Zipcode
        '
        Me.Zipcode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Zipcode.Location = New System.Drawing.Point(672, 56)
        Me.Zipcode.Name = "Zipcode"
        Me.Zipcode.Size = New System.Drawing.Size(56, 20)
        Me.Zipcode.TabIndex = 10
        Me.Zipcode.Tag = ".ZIPCODE"
        Me.Zipcode.Text = ""
        '
        'Label5
        '
        Me.Label5.Location = New System.Drawing.Point(648, 56)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(24, 16)
        Me.Label5.TabIndex = 18
        Me.Label5.Text = "Zip:"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'State
        '
        Me.State.Location = New System.Drawing.Point(576, 56)
        Me.State.Name = "State"
        Me.State.Size = New System.Drawing.Size(56, 21)
        Me.State.TabIndex = 9
        Me.State.Tag = ".STATE...STATE.CODE.CODE"
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(536, 56)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(40, 16)
        Me.Label4.TabIndex = 21
        Me.Label4.Text = "State:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(296, 56)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(64, 16)
        Me.Label3.TabIndex = 17
        Me.Label3.Text = "City:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'City
        '
        Me.City.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.City.Location = New System.Drawing.Point(360, 56)
        Me.City.Name = "City"
        Me.City.Size = New System.Drawing.Size(162, 20)
        Me.City.TabIndex = 8
        Me.City.Tag = ".CITY"
        Me.City.Text = ""
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(296, 8)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(64, 16)
        Me.Label2.TabIndex = 16
        Me.Label2.Text = "Address:"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Street
        '
        Me.Street.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.Street.Location = New System.Drawing.Point(360, 8)
        Me.Street.Name = "Street"
        Me.Street.Size = New System.Drawing.Size(240, 20)
        Me.Street.TabIndex = 6
        Me.Street.Tag = ".STREET"
        Me.Street.Text = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(16, 32)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(72, 16)
        Me.Label1.TabIndex = 12
        Me.Label1.Text = "Office Name:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'OfficeName
        '
        Me.OfficeName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.OfficeName.Location = New System.Drawing.Point(88, 32)
        Me.OfficeName.Name = "OfficeName"
        Me.OfficeName.Size = New System.Drawing.Size(152, 20)
        Me.OfficeName.TabIndex = 1
        Me.OfficeName.Tag = ".NAME"
        Me.OfficeName.Text = ""
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.UltraGrid1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 160)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(838, 291)
        Me.Panel2.TabIndex = 44
        '
        'UltraGrid1
        '
        Me.UltraGrid1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.UltraGrid1.Location = New System.Drawing.Point(0, 0)
        Me.UltraGrid1.Name = "UltraGrid1"
        Me.UltraGrid1.Size = New System.Drawing.Size(838, 291)
        Me.UltraGrid1.TabIndex = 0
        Me.UltraGrid1.Text = "Service Offices"
        '
        'ServiceOfficeSetup
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.CancelButton = Me.btnExit
        Me.ClientSize = New System.Drawing.Size(838, 491)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox1)
        Me.MaximizeBox = False
        Me.Name = "ServiceOfficeSetup"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Tag = "SERVICEOFFICES"
        Me.Text = "Service Office Setup"
        Me.GroupBox1.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel2.ResumeLayout(False)
        CType(Me.UltraGrid1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region



    Private Sub ServiceOfficeSetup_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim dtaStates As New SqlDataAdapter
        Dim MinWinSize As System.Drawing.Size

        AddHandler Me.Activated, AddressOf Form_Activated
        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = AppTblPath & Me.Tag
            End If
        End If

        Me.CenterToScreen()

        Me.KeyPreview = True
        MeText = Me.Text

        ' Set each control's length based on DB size
        SetupCtrlsLength(Me, AppDBName, AppDBUser, AppDBPass)

        AddHandler State.KeyPress, AddressOf CBO_Search
        AddHandler State.KeyUp, AddressOf CBO_KeyUp
        AddHandler State.Leave, AddressOf CBO_Leave
        AddHandler Me.KeyUp, AddressOf Form_KeyUp



        'cCommon.PopulateDataset(strSQL)

        btnSave.Text = "&Save"

        FillCombo(State, "CA")

        LoadData()

        'FillCombo(cboRegion, "")


        'Dim colorWhite As System.Drawing.Color = System.Drawing.Color.White
        'Dim colorBlue As System.Drawing.Color = System.Drawing.Color.Blue
        'With Me.UltraGrid1.DisplayLayout
        '    With .AddNewBox

        '        With .Appearance
        '            .BackColor = colorBlue
        '            .ForeColor = colorWhite
        '            .FontData.SizeInPoints = 14
        '        End With

        '        With .ButtonAppearance
        '            .BackColor = colorWhite
        '            .ForeColor = colorBlue
        '            .FontData.SizeInPoints = 14
        '        End With

        '        .Hidden = False
        '        .ButtonConnectorColor = colorBlue
        '        .ButtonConnectorStyle = Infragistics.Win.UIElementBorderStyle.Raised
        '        .ButtonStyle = Infragistics.Win.UIElementButtonStyle.Button3D
        '    End With
        'End With


        'FormLoad(Me, dvOffice)
        MinWinSize.Width = email.Left + email.Width + 50

        With UltraGrid1.DisplayLayout.Bands(0).Header
            MinWinSize.Height = UltraGrid1.Rows(0).Height * 8 + Panel1.Height
        End With
        'clientsize.
        Me.MinimumSize = MinWinSize

        Group_EnDis(False)


        'Panel1.ForeColor = System.Drawing.Color.Yellow
        'SystemColors.GrayText = System.Drawing.Color.Aqua



    End Sub
    'To reshresh the UltraGrid with after made changes
    Private Sub LoadData()
        Dim dtAdapter As SqlDataAdapter
        PopulateDataset2(dtAdapter, dtSet, SQLSelect.Replace("@ACTV", "1"))
        FillUltraGrid(UltraGrid1, dtSet, 1, HidCols)
        UGLoadLayout(Me, UltraGrid1, 1)
    End Sub

    Private Sub UltraGrid1_AfterRowActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraGrid1.AfterRowActivate
        FormLoadFromGrid(Me, sender)
    End Sub

    Private Sub UltraGrid1_EnabledChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles UltraGrid1.EnabledChanged
        If sender.enabled Then
            FormLoadFromGrid(Me, sender)
        End If
    End Sub

    Private Sub State_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles State.SelectedIndexChanged
        If sender.Focused Then
            City.Text = ""
            City.Modified = False
            Zipcode.Text = ""
            Zipcode.Modified = False
        Else
        End If
    End Sub

    Private Sub City_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles City.Leave, Zipcode.Leave
        Dim row As DataRow
        Dim FldName As String
        Dim gZip, gCity As Control
        Dim gState As Object

        Select Case sender.name
            Case "City"
                gZip = Zipcode
                gState = State
                gCity = City
                FldName = "Name"
            Case "Zipcode"
                gZip = Zipcode
                gState = State
                gCity = City
                FldName = "Zipcode"
            Case Else
                'Message modified by Michael Pastor
                MsgBox("Wrong Control.", MsgBoxStyle.Exclamation, "Data Invalid")
                '- MsgBox("Wrong Control!")
                Exit Sub
        End Select

        If sender.text.trim = "" Then
            sender.modified = False
            sender.Text = ""
            gZip.Text = ""
            gCity.Text = ""
        ElseIf SearchOnLeave(sender, gZip, AppTblPath & "City", "Zipcode", FldName, "*", "Cities") Then
            If ReturnRowByID(gZip.Text, row, AppTblPath & "City", , "Zipcode") Then
                If TypeOf gState Is ComboBox Then
                    gState.SelectedValue = row("StateCode")
                Else
                    gState.value = row("StateCode")
                End If
                gZip.Text = row("ZipCode")
                gCity.Text = row("Name")
                'ucboAcctBillingCycle.Value = row("BCycleCode")
            End If
            row.Delete()
            row = Nothing
        End If
    End Sub
    'Karina added, don't let the user enter alpha in numberic field
    Private Sub Value_Int_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles OFFICEID.KeyPress
        If IsNumeric(e.KeyChar) = False And Asc(e.KeyChar) <> Keys.Back And e.KeyChar <> "-" Then
            e.Handled = True
        End If
    End Sub
    Private Sub City_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles City.KeyUp

        TypeAhead(sender, e, AppTblPath & "City", "Name", "AND StateCode = '" & GetNextControl(sender, True).Text & "'")
        'sender.modified = True
    End Sub

    Private Sub Zipcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Zipcode.KeyPress
        If IsNumeric(e.KeyChar) = False And Asc(e.KeyChar) <> Keys.Back Then
            e.Handled() = True
        End If
    End Sub

    Private Sub Phone1_MaskValidationError(ByVal sender As Object, ByVal e As Infragistics.Win.UltraWinMaskedEdit.MaskValidationErrorEventArgs) Handles Phone1.MaskValidationError, Phone2.MaskValidationError, Fax.MaskValidationError
        Dim NextCtrl As System.Windows.Forms.Control
        Dim Str As String
        Str = sender.GetText(Infragistics.Win.UltraWinMaskedEdit.MaskMode.Raw)

        If Str = "" Then
            e.RetainFocus = False
        End If
    End Sub

    Private Sub Group_EnDis(ByVal status As Boolean)
        Panel1.Enabled = status
        btnSave.Enabled = status
        btnActivation.Enabled = Not status
        btnDeActivate.Enabled = Not status
    End Sub

    Private Sub BtnSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSave.Click
        Dim cnt As Integer
        Dim ID As Integer

        'Karina "Field empty - don't save"
        If OfficeName.Text.Trim = "" Then
            'Message modified by Michael Pastor
            MsgBox("Office name remains unspecified. Please enter a valid office name to continue.", MsgBoxStyle.Exclamation, "Missing Data Input")
            MsgBox("Enter Office Name!")
            Exit Sub
        End If

        If EditForm(Me, SQLSelect.Replace("@ACTV", 1), EditAction.ENDEDIT, cmdTrans, " Where ID = " & OFFICEID.Text) Then
            Dim row As DataRow
            Dim dtA As New SqlDataAdapter

            ID = OFFICEID.Text
            btnEdit.Text = "&Edit"
            btnSave.Text = "&Save"
            'Me.Text = MeText & " -- Record Updated."
            PopulateDataset2(dtA, dtSet, SQLSelect.Replace("@ACTV", 1))
            FillUltraGrid(UltraGrid1, dtSet, 1, HidCols)
            UGLoadLayout(Me, UltraGrid1, 1)
            'UltraGrid1.ActiveRow = UltraGrid1.Rows.GetRowAtVisibleIndexOffset(

            row = dtSet.Tables(0).Rows.Find(ID)
            'UltraGrid1.ActiveRow.Cells(0) = row.Item(0) 'Infragistics.Win.UltraWinGrid.UltraGridRow)
            'sender.text = "&New"
            btnNew.Enabled = True
            UltraGrid1.Enabled = True
            Group_EnDis(False)
            UltraGrid1.Focus()
            UltraGrid1.Refresh()
        End If

    End Sub

    Private Sub BtnEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnEdit.Click
        ' Lock Records
        btnNew.Enabled = False
        If OFFICEID.Text.Trim = "" Then Exit Sub
        If btnNew.Text = "&Cancel" Then
            'Message modified by Michael Pastor
            MsgBox("You are in 'New' mode. Cancel or Save your current job first.", MsgBoxStyle.Exclamation, "Current Mode: New")
            '- MessageBox.Show("You are in 'New' mode. Cancel or Save your current job first.")
            Exit Sub
        End If

        If sender.text.toupper = "&EDIT" Then
            If EditForm(Me, PrepSelectQuery(SQLSelect.Replace("@ACTV", 1), " Where ID = " & OFFICEID.Text), EditAction.START, cmdTrans) Then
                UltraGrid1.Enabled = False
                Group_EnDis(True)
                sender.text = "&Cancel"
            End If
        Else
            If EditForm(Me, SQLSelect.Replace("@ACTV", 1), EditAction.CANCEL, cmdTrans) Then
                UltraGrid1.Enabled = True
                Group_EnDis(False)
                sender.text = "&Edit"
                'FormLoad(Me, dvCompany)
                btnNew.Enabled = True
            End If
        End If

    End Sub

    Private Sub BtnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click

        Me.Close()

    End Sub

    Private Sub btnNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNew.Click
        If btnEdit.Text = "&Cancel" Then
            'Message modified by Michael Pastor
            MsgBox("You are in 'Edit' mode. Cancel or Save your current job first.", MsgBoxStyle.Exclamation, "Current Mode: Edit")
            '- MessageBox.Show("You are in 'Edit' mode. Cancel or Save your current job first.")
            Exit Sub
        End If
        If sender.text = "&New" Then
            UltraGrid1.Enabled = False
            ClearForm(Me)
            Group_EnDis(True)
            sender.text = "&Cancel"
            OFFICEID.Focus()
        Else
            sender.text = "&New"
            UltraGrid1.Enabled = True
            Group_EnDis(False)
            UltraGrid1.Focus()

        End If
    End Sub

    Private Sub BtnDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDelete.Click
        Dim dsData As DataSet
        Dim ID As Integer
        Dim row As DataRow
        Dim ugrow As Infragistics.Win.UltraWinGrid.UltraGridRow

        'Karina
        If UltraGrid1.Selected.Rows.Count = 0 Then Exit Sub

        If UltraGrid1.Selected.Rows.Count = UltraGrid1.Rows.Count Then
            ID = -1
        Else
            ugrow = UltraGrid1.Selected.Rows(0)
            If ugrow.Index > 0 Then
                ID = ugrow.Index - 1
            Else
                ID = 0
            End If
        End If

        UltraGrid1.DeleteSelectedRows()

        If UpdateDbFromDataSet(dtSet, SQLSelect.Replace("@ACTV", 1)) <= 0 Then
            'MsgBox("btnDelete_Click: Error!") 'Karina, don't need this MsgBox
            Exit Sub
        End If
        If ID >= 0 Then
            UltraGrid1.ActiveRow = UltraGrid1.Rows.GetItem(ID)
        Else
            ClearForm(Me)
        End If
        'ID = UltraGrid1.ActiveRow.Cells(0).Value
        'row = dtSet.Tables(0).Rows.Find(ID)
        'row.Delete()

        'UltraGrid1.ActiveRow.Delete()
        'dsData = UltraGrid1.DataSource


    End Sub
    Private Sub OFFICEID_Leave(ByVal sender As Object, ByVal e As System.EventArgs) Handles OFFICEID.Leave
        ''Dim dtAdapter As SqlDataAdapter
        ''Dim dvAcct As New DataView
        ''Dim dtSet2 As New DataSet
        ''Dim TempQuery As String
        ''Dim CritTmp As String
        ''Dim row As DataRow
        ''Dim EmplCriteria As String = " WHERE eb.ID = @OfficeID "
        ''CritTmp = EmplCriteria.Replace("@OfficeID", OFFICEID.Text)

        ''If sender.Modified = False Then Exit Sub
        ''If sender.Text.Trim = "" Then Exit Sub
        ''If btnNew.Text = "&Cancel" Or btnEdit.Text = "&Cancel" Then
        ''    If ReturnRowByID(OFFICEID.Text, row, AppTblPath & "SERVICEOFFICES") Then
        ''        MsgBox("This ID is already assigned. Try other number.")
        ''        OFFICEID.Undo()
        ''        OFFICEID.ClearUndo()
        ''        OFFICEID.Modified = False
        ''        OFFICEID.Focus()
        ''        Exit Sub
        ''    End If
        ''End If

        ''sender.Modified = False

        ''TempQuery = PrepSelectQuery(SQLSelect, CritTmp)

        ''PopulateDataset2(dtAdapter, dtSet2, TempQuery)
        ''If dtSet2 Is Nothing Then Exit Sub
        ''If dtSet2.Tables Is Nothing Then Exit Sub
        ''If dtSet2.Tables(0) Is Nothing Then Exit Sub

        '''If dtSet2.Tables(0).Rows.Count = 0 Then
        '''    Group_EnDis(True)
        '''    ClearForm(Panel1)
        '''    OfficeName.Focus()
        '''    btnNew.Text = "&Cancel"
        '''    btnSave.Text = "&Save"
        '''Else
        '''    Group_EnDis(False)
        '''    btnSave.Text = "&Save"
        '''    btnEdit.Text = "&Edit"
        '''    btnNew.Text = "&New"

        '''    dvAcct.Table = dtSet2.Tables(0)
        '''    FormLoad(Me, dvAcct)
        '''End If

        ''dtSet2 = Nothing
        'Aly(Start)
        Dim dtSetTmp As DataSet

        If sender.text.trim <> "" Then
            If sender.modified Then
                dtSetTmp = SearchDB(SQLSelect.Replace("@ACTV", 1), "ID = " & sender.text)
                If Not (dtSetTmp Is Nothing) Then
                    'Message modified by Michael Pastor
                    MsgBox("Office ID already exists. Please enter a unique office ID to continue.", MsgBoxStyle.Exclamation, "Data Invalid")
                    '- MsgBox("Error: This ID already exists in the system!")
                    dtSetTmp = Nothing
                    sender.focus()
                    Exit Sub
                End If
                'If btnNew.Text = "&Cancel" Then
                'End If
            End If
        Else
            dtSetTmp = SearchDB(SQLSelect.Replace("@ACTV", 1), "ID = (Select Max(ID) from " & Me.Tag & ")")
            If Not (dtSetTmp Is Nothing) Then
                sender.Text = dtSetTmp.Tables(0).Rows(0).Item("ID") + 1
            Else
                sender.Text = 1
            End If
            dtSetTmp = Nothing
            sender.modified = False
        End If
        'Aly End
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
                CntMenu1.MenuItems.Add("Hide", New EventHandler(AddressOf mnuHide_Click))
                CntMenu1.MenuItems.Add("Unhide")
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
                        CntMenu1.MenuItems(1).MenuItems.Add(ugcol.ToString, New EventHandler(AddressOf SubMnuUnHide_Click))
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

    Private Sub ServiceOfficeSetup_SizeChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.SizeChanged
        'Dim WinWidth, MinWidth As Integer
        'WinWidth = Me.Width + 0.1 * Me.Width
        'MinWidth = State.Left + State.Width

        'If WinWidth < MinWidth Then
        '    Me.Width = MinWidth
        'End If

    End Sub

    Private Sub btnAsgnZones_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnAsgnZones.Click
        UltraGrid1.Print()
        'ExportUltraGrid(UltraGrid1)
    End Sub

    ' Closing window 6.14.2005
    Private Sub ServiceOfficeSetup_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        If btnEdit.Text = "&Cancel" Or btnNew.Text = "&Cancel" Then
            'Message modified by Michael Pastor
            If MessageBox.Show("Data is not saved! Are you sure you want to exit?", "Data Not Saved", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) = MsgBoxResult.No Then
                '- If MsgBox("Data is not saved! Are you sure you want to exit?", MsgBoxStyle.YesNo) = MsgBoxResult.No Then
                e.Cancel = True
                Exit Sub
            End If
        End If

        If Not cmdTrans Is Nothing Then
            If EditForm(Me, SQLSelect.Replace("@ACTV", 1), EditAction.CANCEL, cmdTrans) Then
                UltraGrid1.Enabled = True
                Group_EnDis(False)
                sender.text = "&Edit"
            Else
                'Exit Sub
            End If

        End If
        UGSaveLayout(Me, UltraGrid1, 1)

    End Sub
    Private Sub btnActivation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnActivation.Click
        'Dim x As New SearchListings
        Dim InactiveQry As String = SQLSelect.Replace("@ACTV", 0)
        Srch = New SearchListings
        Dim dtadapter As SqlDataAdapter
        Dim HasErr As Boolean
        Dim ugRow As Infragistics.Win.UltraWinGrid.UltraGridRow
        'Dim HidCols() As String = {"ACTIVE"} 'Karina added Active

        PopulateDataset2(dtadapter, dtSet, InactiveQry)

        If dtSet.Tables(0).Rows.Count > 0 Then

            Srch.dsList = dtSet

            Srch.UltraGrid1.Text = "InActive Offices"
            Srch.Text = "InActive Offices"

            Srch.GenFunc = AddressOf ActivateOffice

            'AddHandler Srch.btnGen.Click, AddressOf ActivateOffice

            Srch.btnGen.Text = "Activate"
            Srch.btnGen.Left = Srch.Button1.Left
            Srch.btnGen.Top = Srch.Button1.Top

            Srch.btnGen.Enabled = True
            Srch.btnGen.Visible = True

            Srch.Button1.Visible = False 'Karina

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
                'Message modified by Michael Pastor
                MsgBox("SQL_Error: " & osqlexception.Message, MsgBoxStyle.Critical, "Critical Error")
                '- MsgBox("SQL_Error: " & osqlexception.Message)
                Srch = Nothing
                sender.Focus()
                Exit Try
            Finally
                If HasErr = False Then
                    ugRow = Srch.UltraGrid1.ActiveRow
                    Srch = Nothing
                    LoadData()
                End If
            End Try
        Else
            MsgBox("No InActive offices found.")
        End If

    End Sub
    Private Sub btnDisplay_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDeActivate.Click
        If MsgBox("Are You sure that you want to inactivate this office? ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            If Not UltraGrid1.Rows Is Nothing Then
                ExecuteQuery("Update " & AppTblPath & "ServiceOffices set Active = 0 where ID = " & OFFICEID.Text)
                DialogResult = DialogResult.OK
                LoadData()
            End If
        End If
    End Sub

    Private Sub LoadActiveOffices(ByVal Criteria As System.Object)
        Dim dtAdapter As SqlDataAdapter

        Dim CritTmp As String

        CritTmp = Criteria
        PopulateDataset2(dtAdapter, dtSet, PrepSelectQuery(SQLSelect.Replace("@ACTV", 1), CritTmp))

        FillUltraGrid(UltraGrid1, dtSet, 1, HidCols)
        UGLoadLayout(Me, UltraGrid1, 1)
        UltraGrid1.DisplayLayout.GroupByBox.Hidden = False
        UltraGrid1.DisplayLayout.ViewStyleBand = Infragistics.Win.UltraWinGrid.ViewStyleBand.OutlookGroupBy

    End Sub

    Private Sub ActivateOffice(ByVal sender As System.Object, ByVal e As System.EventArgs)
        If MsgBox("Are You sure you that want to activate this office? ", MsgBoxStyle.YesNo) = MsgBoxResult.Yes Then
            If Not Srch.m_oRow Is Nothing Then
                ExecuteQuery("Update " & AppTblPath & "ServiceOffices set Active = 1 where id = " & Srch.m_oRow.Cells("ID").Value)
                Srch.DialogResult = DialogResult.OK
                Srch.Close()
            End If
        End If
    End Sub


End Class
