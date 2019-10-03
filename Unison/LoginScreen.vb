Imports System.Data
Imports System.Data.SqlClient
Imports System.Drawing.SystemColors

Public Class LoginScreen
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
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents btnExit As System.Windows.Forms.Button
    Friend WithEvents btnLogin As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents ucboCompany As Infragistics.Win.UltraWinGrid.UltraCombo
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents utPassword As Infragistics.Win.UltraWinEditors.UltraTextEditor
    Friend WithEvents utUserID As Infragistics.Win.UltraWinEditors.UltraTextEditor
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim Appearance1 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance2 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Dim Appearance3 As Infragistics.Win.Appearance = New Infragistics.Win.Appearance
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.btnExit = New System.Windows.Forms.Button
        Me.btnLogin = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.utPassword = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label1 = New System.Windows.Forms.Label
        Me.utUserID = New Infragistics.Win.UltraWinEditors.UltraTextEditor
        Me.Label20 = New System.Windows.Forms.Label
        Me.ucboCompany = New Infragistics.Win.UltraWinGrid.UltraCombo
        Me.Label28 = New System.Windows.Forms.Label
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.utPassword, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.utUserID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ucboCompany, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.btnExit)
        Me.GroupBox3.Controls.Add(Me.btnLogin)
        Me.GroupBox3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.GroupBox3.Location = New System.Drawing.Point(0, 149)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(368, 40)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        '
        'btnExit
        '
        Me.btnExit.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.btnExit.Dock = System.Windows.Forms.DockStyle.Right
        Me.btnExit.Location = New System.Drawing.Point(304, 16)
        Me.btnExit.Name = "btnExit"
        Me.btnExit.Size = New System.Drawing.Size(61, 21)
        Me.btnExit.TabIndex = 1
        Me.btnExit.Text = "E&xit"
        '
        'btnLogin
        '
        Me.btnLogin.Dock = System.Windows.Forms.DockStyle.Left
        Me.btnLogin.Location = New System.Drawing.Point(3, 16)
        Me.btnLogin.Name = "btnLogin"
        Me.btnLogin.Size = New System.Drawing.Size(61, 21)
        Me.btnLogin.TabIndex = 0
        Me.btnLogin.Text = "&Login"
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.utPassword)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.utUserID)
        Me.GroupBox2.Controls.Add(Me.Label20)
        Me.GroupBox2.Controls.Add(Me.ucboCompany)
        Me.GroupBox2.Controls.Add(Me.Label28)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.GroupBox2.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(368, 149)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'utPassword
        '
        Appearance1.ForeColor = System.Drawing.Color.Black
        Appearance1.ForeColorDisabled = System.Drawing.Color.Black
        Me.utPassword.Appearance = Appearance1
        Me.utPassword.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utPassword.Location = New System.Drawing.Point(96, 80)
        Me.utPassword.Name = "utPassword"
        Me.utPassword.PasswordChar = Microsoft.VisualBasic.ChrW(42)
        Me.utPassword.Size = New System.Drawing.Size(150, 21)
        Me.utPassword.TabIndex = 2
        Me.utPassword.Tag = ""
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(32, 83)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 16)
        Me.Label1.TabIndex = 175
        Me.Label1.Text = "Password:"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'utUserID
        '
        Appearance2.ForeColor = System.Drawing.Color.Black
        Appearance2.ForeColorDisabled = System.Drawing.Color.Black
        Me.utUserID.Appearance = Appearance2
        Me.utUserID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper
        Me.utUserID.Location = New System.Drawing.Point(96, 56)
        Me.utUserID.Name = "utUserID"
        Me.utUserID.Size = New System.Drawing.Size(150, 21)
        Me.utUserID.TabIndex = 1
        Me.utUserID.Tag = ""
        '
        'Label20
        '
        Me.Label20.Location = New System.Drawing.Point(32, 59)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(64, 16)
        Me.Label20.TabIndex = 173
        Me.Label20.Text = "UserID:"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'ucboCompany
        '
        Appearance3.ForeColor = System.Drawing.Color.Black
        Appearance3.ForeColorDisabled = System.Drawing.Color.Black
        Me.ucboCompany.Appearance = Appearance3
        Me.ucboCompany.AutoEdit = False
        Me.ucboCompany.DisplayMember = ""
        Me.ucboCompany.Location = New System.Drawing.Point(96, 30)
        Me.ucboCompany.Name = "ucboCompany"
        Me.ucboCompany.Size = New System.Drawing.Size(216, 21)
        Me.ucboCompany.TabIndex = 0
        Me.ucboCompany.Tag = ".ompany..1.UN_Companies.Company_Code.Company_Name"
        Me.ucboCompany.ValueMember = ""
        '
        'Label28
        '
        Me.Label28.Location = New System.Drawing.Point(40, 32)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(56, 16)
        Me.Label28.TabIndex = 122
        Me.Label28.Text = "Company:"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LoginScreen
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(368, 189)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox3)
        Me.Name = "LoginScreen"
        Me.Text = "Login to Unison"
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.utPassword, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.utUserID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ucboCompany, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub LoginScreen_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'AddHandler Me.Activated, AddressOf Form_Activated
        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = HRTblPath & Me.Tag
            End If
        End If

        Me.CenterToScreen()

        Me.KeyPreview = True
        MeText = Me.Text

        ' Set each control's length based on DB size
        'SetupCtrlsLength(Me)

        AddHandler Me.KeyUp, AddressOf Form_KeyUp

        LocalIP = "" : RemoteIP = ""
        If CheckSetupINI() = False Then
            Me.Close()
        End If

        '==========================================
        ' Get IPIPath
        '==========================================
        GetImportPath()

        EDIPath = EDIPath.ToUpper
        IPIPath = IPIPath.ToUpper

        If EDIPath.Substring(EDIPath.Length - 1, 1) = "\" Then
            EDIPath = EDIPath.Substring(0, EDIPath.Length - 1)
        End If
        If IPIPath.Substring(IPIPath.Length - 1, 1) = "\" Then
            IPIPath = IPIPath.Substring(0, IPIPath.Length - 1)
        End If


        '================   END GETIPIPATH  ===============

        'Me.Text = Me.Text & "- Connected To: " & LocalName

        IPAddr = IIf(LocalIP <> "", LocalIP, RemoteIP) '"192.80.90.200"
        'IPAddr = "66.14.100.162"
        'IPAddr = "192.168.1.102"

        strConnection2 = "Server = " & IPAddr & ";Database = @DB;User ID = @USER;Password= @PASS"
        sqlConn.ConnectionString = strConnection2

        Dim connstr As String

        connstr = strConnection2.Replace("@DB", CFGDBName)
        connstr = connstr.Replace("@USER", CFGDBUser)
        connstr = connstr.Replace("@PASS", CFGDBPass)

        'Dim localConn As New SqlConnection(connstr)
        'DataAdapter.SelectCommand = New SqlCommand
        '''dsRapid.ReadXmlSchema("RapidDataSet.xsd")
        ''dsRapid.DataSetName = "RapidDataSet2"
        strConnection = connstr
        sqlConn.ConnectionString = strConnection

        'PopulateDataset2(DataAdapter, dsRapid, "Select * from Address where OwnerID = " & utAccountID.Text & " AND NAME not like '*%' AND OWNERTYPE <> 'C' Order by Name")
        'PopulateDataset2(DataAdapter, dsRapid, "Select * from Address CustAddress where OwnerID = " & utAccountID.Text & " AND NAME not like '*%' AND OwnerType = 'C' Order by Name", True)
        FillUCombo(ucboCompany, "", "", "Select Company_Code, Company_Name, DB_Prefix From " & CFGTblPath & "UN_Companies order by Company_Name ", CFGTblPath, False, True)
        AddHandler ucboCompany.Leave, AddressOf UCbo_Leave
        ucboCompany.Focus()
        ucboCompany.Select()


    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        Me.Close()
    End Sub

    Private Sub btnLogin_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnLogin.Click
        Dim DataAdapter As New SqlDataAdapter
        Dim dsDSet As DataSet
        Dim row As DataRow
        Dim sqlLogin As String = "Select * from " & CFGTblPath & "UN_Users Where UserID = '" & utUserID.Text & "' And Password = '" & utPassword.Text & "'"
        Dim sqlRights As String = "Select Obj_Name, SUM([View]) AS [VIEW], SUM(Edit) AS Edit, SUM([Delete]) AS [DELETE], SUM([Print]) AS [PRINT] from " & CFGTblPath & "UN_Rights where Company_Code = '" & ucboCompany.Value & "' And UserID IN (Select Group_Code as UserID from UN_UserMemberships where userid = '" & utUserID.Text & "' UNION Select '" & utUserID.Text & "' as UserID) group by Obj_Name ORDER BY Obj_Name "
        '" & utUserID.Text & "'"

        If ReturnRowByID("", row, "", "", "", sqlLogin) = True Then
            PopulateDataset2(DataAdapter, dsDSet, sqlRights)
            If dsDSet.Tables(0).Rows.Count > 0 Then
                Dim X As New Form1
                LoginInfo.UserName = row("Full_Name")
                LoginInfo.EmployeeID = row("EmployeeID")
                LoginInfo.WorkCompanyCode = row("Company_Code")

                row = Nothing
                ReturnRowByID("", row, "", "", "", "Select * from " & CFGTblPath & "UN_Companies where Company_Code = '" & ucboCompany.Value & "'")
                If row Is Nothing Then
                    'Message modified by Michael Pastor
                    MsgBox("Unable to retrieve company information.", MsgBoxStyle.Exclamation, "Data Unavailable")
                    '- MsgBox("Error retrieving Company Info.")
                    Exit Sub
                End If

                LoginInfo.UserID = utUserID.Text
                LoginInfo.Password = utPassword.Text
                LoginInfo.CompanyCode = ucboCompany.Value
                LoginInfo.CompanyName = row("Company_Name")
                LoginInfo.DBPrefix = row("DB_Prefix")

                AppDBName = AppDBName & IIf(Len(LoginInfo.DBPrefix) > 0, "_", "") & LoginInfo.DBPrefix
                AppTblPath = AppDBName & ".dbo."

                'SAM-MULTIPLE:  Set Database and Application names for various modules
                If String.Compare(LoginInfo.CompanyCode, "TPC") = 0 Then
                    HRDBName = "UN_HR"
                    WeightVars.WEIGHTDBName = "UN_WEIGHT"
                    TrucksVars.TRUCKSDBName = "UN_TRUCKS"
                    TRCDBName = "UN_TRACKING"
                    ROUTESDBName = "UN_ROUTES"
                    ORDERDBName = "UN_ORDERS"
                    HOLIDAYSDBName = "UN_HOLIDAYS"
                    BILLDBName = "UN_BILLING"
                    smBILLDBName = "UN_SETTLEMENT"
                Else
                    HRDBName = LoginInfo.DBPrefix & IIf(Len(LoginInfo.DBPrefix) > 0, "_", "") & "HR"
                    WeightVars.WEIGHTDBName = LoginInfo.DBPrefix & IIf(Len(LoginInfo.DBPrefix) > 0, "_", "") & "WEIGHT"
                    TrucksVars.TRUCKSDBName = LoginInfo.DBPrefix & IIf(Len(LoginInfo.DBPrefix) > 0, "_", "") & "TRUCKS"
                    TRCDBName = LoginInfo.DBPrefix & IIf(Len(LoginInfo.DBPrefix) > 0, "_", "") & "TRACKING"
                    ROUTESDBName = LoginInfo.DBPrefix & IIf(Len(LoginInfo.DBPrefix) > 0, "_", "") & "ROUTES"
                    ORDERDBName = LoginInfo.DBPrefix & IIf(Len(LoginInfo.DBPrefix) > 0, "_", "") & "ORDERS"
                    HOLIDAYSDBName = LoginInfo.DBPrefix & IIf(Len(LoginInfo.DBPrefix) > 0, "_", "") & "HOLIDAYS"
                    BILLDBName = LoginInfo.DBPrefix & IIf(Len(LoginInfo.DBPrefix) > 0, "_", "") & "BILLING"
                    smBILLDBName = LoginInfo.DBPrefix & IIf(Len(LoginInfo.DBPrefix) > 0, "_", "") & "SETTLEMENT"
                End If
                HRTblPath = HRDBName & ".dbo."
                WeightVars.WEIGHTTblPath = WeightVars.WEIGHTDBName & ".dbo."
                TrucksVars.TRUCKSTblPath = TrucksVars.TRUCKSDBName & ".dbo."
                TRCTblPath = TRCDBName & ".dbo."
                ROUTESTblPath = ROUTESDBName & ".dbo."
                ORDERTblPath = ORDERDBName & ".dbo."
                HOLIDAYSTblPath = HOLIDAYSDBName & ".dbo."
                BILLTblPath = BILLDBName & ".dbo."
                smBILLTblPath = smBILLDBName & ".dbo."

                strConnection = "Server = " & IPAddr & ";Database = " & AppDBName & "; " & "User ID = " & AppDBUser & "; Password = " & AppDBPass & ""
                sqlConn.ConnectionString = strConnection
                Me.Hide()
                X.ShowDialog()
                Me.Close()
            Else
                'Message modified by Michael Pastor
                MsgBox("Authorization denied for this company.", MsgBoxStyle.Exclamation, "Authorization Denied")
                '- MsgBox("Authorization failed for this company.")
                Exit Sub
            End If
        Else
            'Message modified by Michael Pastor
            MsgBox("Authorization denied.", MsgBoxStyle.Exclamation, "Authorization Denied")
            '- MsgBox("Authorization failed.")
            Exit Sub
        End If
    End Sub
End Class

'SAM:  I'm not sure if these are still necessary?
'Public Class ButtonProperties

'    Public Visible As Boolean
'    Public Text As String
'    Public IsDefault As Boolean

'    Public Sub New()
'        Visible = True
'        Text = "Button"
'        IsDefault = False
'    End Sub

'End Class

'Public Class FormProperties

'    Public Height As Integer
'    Public Width As Integer
'    Public Name As Integer

'    Public Sub New()
'        Height = 480
'        Width = 640
'        Name = "IMPORTANT MESSAGE"
'    End Sub

'End Class

'Public Class TextProperties

'    Public Text As String
'    Public Color As System.Drawing.Color
'    Public TextAlign As System.Drawing.ContentAlignment

'    Private m_oFont As System.Drawing.Font

'    Public Property Font() As System.Drawing.Font
'        Get
'            Return m_oFont
'        End Get
'        Set(ByVal Value As System.Drawing.Font)
'            m_oFont = Nothing
'            m_oFont = Value
'        End Set
'    End Property
'End Class
