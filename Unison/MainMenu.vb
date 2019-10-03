Imports System.Data.OleDb
Imports System.Data

Public Class Form1
    Inherits System.Windows.Forms.Form
    Dim objDataAdapter As New OleDbDataAdapter()
    Dim objDataset As DataSet = New DataSet()
    Dim SYSPASSOK, ROUTEPASSOK, WEIGHTPASSOK, TRUCKSPASSOK, HRPASSOK As Boolean
#Region " Windows Form Designer generated code "
    Private LastMouseDown As Point

    Public Sub New()
        MyBase.New()

        'This call is required by the Windows Form Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            objDataset = Nothing
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
    Friend WithEvents MainMenu1 As System.Windows.Forms.MainMenu
    Friend WithEvents MenuItem1 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem2 As System.Windows.Forms.MenuItem
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents MenuItem3 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem7 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem9 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem13 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem14 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem15 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem4 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem5 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem8 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem10 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem16 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem17 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem18 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem11 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem6 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem12 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem19 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem21 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem22 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem23 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem24 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem20 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem25 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem26 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem27 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem28 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem29 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem30 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem32 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem33 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem34 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem35 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem36 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem37 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem38 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem39 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem40 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem41 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem42 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem43 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem44 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem45 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem46 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem47 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem48 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem49 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem50 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem51 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem52 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem53 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem54 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem55 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem56 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem57 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem58 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem59 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem31 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem60 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem61 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem62 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem63 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem64 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem65 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem67 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem68 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem69 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem70 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem71 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem72 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem73 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem74 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem75 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem76 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem77 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem78 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem79 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem80 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem81 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem82 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem83 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem84 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem85 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem86 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem87 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem88 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem89 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem90 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem91 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem92 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem93 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem94 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem95 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem96 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem97 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem98 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem99 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem100 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem101 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem102 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem103 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem104 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem105 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem106 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem107 As System.Windows.Forms.MenuItem
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MenuItem108 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem109 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem110 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem111 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem112 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem113 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem114 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem115 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem116 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem117 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem118 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem119 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem120 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem121 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem122 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem123 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem125 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem124 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem126 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem127 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem66 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem128 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem129 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem130 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem131 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem132 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem133 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem134 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem135 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem136 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem137 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem138 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem139 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem140 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem141 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem142 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem143 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem144 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem145 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem146 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem147 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem148 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem149 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem150 As System.Windows.Forms.MenuItem
    Friend WithEvents MenuItem151 As System.Windows.Forms.MenuItem
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader
        Me.MainMenu1 = New System.Windows.Forms.MainMenu
        Me.MenuItem1 = New System.Windows.Forms.MenuItem
        Me.MenuItem6 = New System.Windows.Forms.MenuItem
        Me.MenuItem59 = New System.Windows.Forms.MenuItem
        Me.MenuItem3 = New System.Windows.Forms.MenuItem
        Me.MenuItem4 = New System.Windows.Forms.MenuItem
        Me.MenuItem12 = New System.Windows.Forms.MenuItem
        Me.MenuItem21 = New System.Windows.Forms.MenuItem
        Me.MenuItem22 = New System.Windows.Forms.MenuItem
        Me.MenuItem123 = New System.Windows.Forms.MenuItem
        Me.MenuItem24 = New System.Windows.Forms.MenuItem
        Me.MenuItem8 = New System.Windows.Forms.MenuItem
        Me.MenuItem116 = New System.Windows.Forms.MenuItem
        Me.MenuItem150 = New System.Windows.Forms.MenuItem
        Me.MenuItem151 = New System.Windows.Forms.MenuItem
        Me.MenuItem2 = New System.Windows.Forms.MenuItem
        Me.MenuItem20 = New System.Windows.Forms.MenuItem
        Me.MenuItem26 = New System.Windows.Forms.MenuItem
        Me.MenuItem5 = New System.Windows.Forms.MenuItem
        Me.MenuItem11 = New System.Windows.Forms.MenuItem
        Me.MenuItem51 = New System.Windows.Forms.MenuItem
        Me.MenuItem10 = New System.Windows.Forms.MenuItem
        Me.MenuItem16 = New System.Windows.Forms.MenuItem
        Me.MenuItem17 = New System.Windows.Forms.MenuItem
        Me.MenuItem28 = New System.Windows.Forms.MenuItem
        Me.MenuItem14 = New System.Windows.Forms.MenuItem
        Me.MenuItem50 = New System.Windows.Forms.MenuItem
        Me.MenuItem15 = New System.Windows.Forms.MenuItem
        Me.MenuItem18 = New System.Windows.Forms.MenuItem
        Me.MenuItem27 = New System.Windows.Forms.MenuItem
        Me.MenuItem19 = New System.Windows.Forms.MenuItem
        Me.MenuItem25 = New System.Windows.Forms.MenuItem
        Me.MenuItem23 = New System.Windows.Forms.MenuItem
        Me.MenuItem29 = New System.Windows.Forms.MenuItem
        Me.MenuItem30 = New System.Windows.Forms.MenuItem
        Me.MenuItem131 = New System.Windows.Forms.MenuItem
        Me.MenuItem13 = New System.Windows.Forms.MenuItem
        Me.MenuItem115 = New System.Windows.Forms.MenuItem
        Me.MenuItem117 = New System.Windows.Forms.MenuItem
        Me.MenuItem32 = New System.Windows.Forms.MenuItem
        Me.MenuItem33 = New System.Windows.Forms.MenuItem
        Me.MenuItem34 = New System.Windows.Forms.MenuItem
        Me.MenuItem35 = New System.Windows.Forms.MenuItem
        Me.MenuItem36 = New System.Windows.Forms.MenuItem
        Me.MenuItem37 = New System.Windows.Forms.MenuItem
        Me.MenuItem38 = New System.Windows.Forms.MenuItem
        Me.MenuItem39 = New System.Windows.Forms.MenuItem
        Me.MenuItem40 = New System.Windows.Forms.MenuItem
        Me.MenuItem41 = New System.Windows.Forms.MenuItem
        Me.MenuItem42 = New System.Windows.Forms.MenuItem
        Me.MenuItem43 = New System.Windows.Forms.MenuItem
        Me.MenuItem44 = New System.Windows.Forms.MenuItem
        Me.MenuItem45 = New System.Windows.Forms.MenuItem
        Me.MenuItem113 = New System.Windows.Forms.MenuItem
        Me.MenuItem114 = New System.Windows.Forms.MenuItem
        Me.MenuItem118 = New System.Windows.Forms.MenuItem
        Me.MenuItem46 = New System.Windows.Forms.MenuItem
        Me.MenuItem49 = New System.Windows.Forms.MenuItem
        Me.MenuItem107 = New System.Windows.Forms.MenuItem
        Me.MenuItem102 = New System.Windows.Forms.MenuItem
        Me.MenuItem103 = New System.Windows.Forms.MenuItem
        Me.MenuItem104 = New System.Windows.Forms.MenuItem
        Me.MenuItem105 = New System.Windows.Forms.MenuItem
        Me.MenuItem106 = New System.Windows.Forms.MenuItem
        Me.MenuItem101 = New System.Windows.Forms.MenuItem
        Me.MenuItem111 = New System.Windows.Forms.MenuItem
        Me.MenuItem47 = New System.Windows.Forms.MenuItem
        Me.MenuItem48 = New System.Windows.Forms.MenuItem
        Me.MenuItem96 = New System.Windows.Forms.MenuItem
        Me.MenuItem97 = New System.Windows.Forms.MenuItem
        Me.MenuItem98 = New System.Windows.Forms.MenuItem
        Me.MenuItem99 = New System.Windows.Forms.MenuItem
        Me.MenuItem100 = New System.Windows.Forms.MenuItem
        Me.MenuItem52 = New System.Windows.Forms.MenuItem
        Me.MenuItem53 = New System.Windows.Forms.MenuItem
        Me.MenuItem54 = New System.Windows.Forms.MenuItem
        Me.MenuItem55 = New System.Windows.Forms.MenuItem
        Me.MenuItem56 = New System.Windows.Forms.MenuItem
        Me.MenuItem57 = New System.Windows.Forms.MenuItem
        Me.MenuItem58 = New System.Windows.Forms.MenuItem
        Me.MenuItem31 = New System.Windows.Forms.MenuItem
        Me.MenuItem60 = New System.Windows.Forms.MenuItem
        Me.MenuItem61 = New System.Windows.Forms.MenuItem
        Me.MenuItem62 = New System.Windows.Forms.MenuItem
        Me.MenuItem108 = New System.Windows.Forms.MenuItem
        Me.MenuItem109 = New System.Windows.Forms.MenuItem
        Me.MenuItem110 = New System.Windows.Forms.MenuItem
        Me.MenuItem120 = New System.Windows.Forms.MenuItem
        Me.MenuItem132 = New System.Windows.Forms.MenuItem
        Me.MenuItem63 = New System.Windows.Forms.MenuItem
        Me.MenuItem64 = New System.Windows.Forms.MenuItem
        Me.MenuItem65 = New System.Windows.Forms.MenuItem
        Me.MenuItem124 = New System.Windows.Forms.MenuItem
        Me.MenuItem126 = New System.Windows.Forms.MenuItem
        Me.MenuItem127 = New System.Windows.Forms.MenuItem
        Me.MenuItem67 = New System.Windows.Forms.MenuItem
        Me.MenuItem89 = New System.Windows.Forms.MenuItem
        Me.MenuItem68 = New System.Windows.Forms.MenuItem
        Me.MenuItem90 = New System.Windows.Forms.MenuItem
        Me.MenuItem95 = New System.Windows.Forms.MenuItem
        Me.MenuItem134 = New System.Windows.Forms.MenuItem
        Me.MenuItem135 = New System.Windows.Forms.MenuItem
        Me.MenuItem136 = New System.Windows.Forms.MenuItem
        Me.MenuItem91 = New System.Windows.Forms.MenuItem
        Me.MenuItem92 = New System.Windows.Forms.MenuItem
        Me.MenuItem93 = New System.Windows.Forms.MenuItem
        Me.MenuItem94 = New System.Windows.Forms.MenuItem
        Me.MenuItem69 = New System.Windows.Forms.MenuItem
        Me.MenuItem70 = New System.Windows.Forms.MenuItem
        Me.MenuItem76 = New System.Windows.Forms.MenuItem
        Me.MenuItem77 = New System.Windows.Forms.MenuItem
        Me.MenuItem73 = New System.Windows.Forms.MenuItem
        Me.MenuItem78 = New System.Windows.Forms.MenuItem
        Me.MenuItem72 = New System.Windows.Forms.MenuItem
        Me.MenuItem74 = New System.Windows.Forms.MenuItem
        Me.MenuItem79 = New System.Windows.Forms.MenuItem
        Me.MenuItem87 = New System.Windows.Forms.MenuItem
        Me.MenuItem133 = New System.Windows.Forms.MenuItem
        Me.MenuItem71 = New System.Windows.Forms.MenuItem
        Me.MenuItem75 = New System.Windows.Forms.MenuItem
        Me.MenuItem80 = New System.Windows.Forms.MenuItem
        Me.MenuItem83 = New System.Windows.Forms.MenuItem
        Me.MenuItem81 = New System.Windows.Forms.MenuItem
        Me.MenuItem82 = New System.Windows.Forms.MenuItem
        Me.MenuItem84 = New System.Windows.Forms.MenuItem
        Me.MenuItem86 = New System.Windows.Forms.MenuItem
        Me.MenuItem112 = New System.Windows.Forms.MenuItem
        Me.MenuItem119 = New System.Windows.Forms.MenuItem
        Me.MenuItem121 = New System.Windows.Forms.MenuItem
        Me.MenuItem125 = New System.Windows.Forms.MenuItem
        Me.MenuItem66 = New System.Windows.Forms.MenuItem
        Me.MenuItem85 = New System.Windows.Forms.MenuItem
        Me.MenuItem122 = New System.Windows.Forms.MenuItem
        Me.MenuItem88 = New System.Windows.Forms.MenuItem
        Me.MenuItem128 = New System.Windows.Forms.MenuItem
        Me.MenuItem129 = New System.Windows.Forms.MenuItem
        Me.MenuItem130 = New System.Windows.Forms.MenuItem
        Me.MenuItem137 = New System.Windows.Forms.MenuItem
        Me.MenuItem138 = New System.Windows.Forms.MenuItem
        Me.MenuItem140 = New System.Windows.Forms.MenuItem
        Me.MenuItem141 = New System.Windows.Forms.MenuItem
        Me.MenuItem139 = New System.Windows.Forms.MenuItem
        Me.MenuItem142 = New System.Windows.Forms.MenuItem
        Me.MenuItem143 = New System.Windows.Forms.MenuItem
        Me.MenuItem144 = New System.Windows.Forms.MenuItem
        Me.MenuItem145 = New System.Windows.Forms.MenuItem
        Me.MenuItem147 = New System.Windows.Forms.MenuItem
        Me.MenuItem148 = New System.Windows.Forms.MenuItem
        Me.MenuItem149 = New System.Windows.Forms.MenuItem
        Me.MenuItem146 = New System.Windows.Forms.MenuItem
        Me.MenuItem7 = New System.Windows.Forms.MenuItem
        Me.MenuItem9 = New System.Windows.Forms.MenuItem
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MainMenu1
        '
        Me.MainMenu1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem1, Me.MenuItem2, Me.MenuItem13, Me.MenuItem32, Me.MenuItem46, Me.MenuItem52, Me.MenuItem31, Me.MenuItem69, Me.MenuItem128, Me.MenuItem137})
        '
        'MenuItem1
        '
        Me.MenuItem1.Index = 0
        Me.MenuItem1.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem6, Me.MenuItem59, Me.MenuItem3, Me.MenuItem4, Me.MenuItem12, Me.MenuItem21, Me.MenuItem22, Me.MenuItem123, Me.MenuItem24, Me.MenuItem8, Me.MenuItem116, Me.MenuItem150})
        Me.MenuItem1.Text = CType(configurationAppSettings.GetValue("MenuItem1.Name", GetType(System.String)), String)
        '
        'MenuItem6
        '
        Me.MenuItem6.Index = 0
        Me.MenuItem6.Text = "Basic Employee  Setup"
        '
        'MenuItem59
        '
        Me.MenuItem59.Index = 1
        Me.MenuItem59.Text = "Groups Setup"
        '
        'MenuItem3
        '
        Me.MenuItem3.Index = 2
        Me.MenuItem3.Text = "Account Setup"
        '
        'MenuItem4
        '
        Me.MenuItem4.Index = 3
        Me.MenuItem4.Text = "Service Office Setup"
        '
        'MenuItem12
        '
        Me.MenuItem12.Index = 4
        Me.MenuItem12.Text = "Routes Setup"
        '
        'MenuItem21
        '
        Me.MenuItem21.Index = 5
        Me.MenuItem21.Text = "Package Types"
        '
        'MenuItem22
        '
        Me.MenuItem22.Index = 6
        Me.MenuItem22.Text = "Service Types"
        '
        'MenuItem123
        '
        Me.MenuItem123.Index = 7
        Me.MenuItem123.Text = "Vehicle Types"
        '
        'MenuItem24
        '
        Me.MenuItem24.Index = 8
        Me.MenuItem24.Text = "Services"
        '
        'MenuItem8
        '
        Me.MenuItem8.Index = 9
        Me.MenuItem8.Text = "Account Service Setup"
        '
        'MenuItem116
        '
        Me.MenuItem116.Index = 10
        Me.MenuItem116.Text = "Billing Cycle Setup"
        '
        'MenuItem150
        '
        Me.MenuItem150.Index = 11
        Me.MenuItem150.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem151})
        Me.MenuItem150.Text = "Zip Zone Review"
        '
        'MenuItem151
        '
        Me.MenuItem151.Index = 0
        Me.MenuItem151.Text = "Zips in Zones"
        '
        'MenuItem2
        '
        Me.MenuItem2.Index = 1
        Me.MenuItem2.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem20, Me.MenuItem26, Me.MenuItem27, Me.MenuItem23, Me.MenuItem29})
        Me.MenuItem2.Text = "&Scheduled Jobs"
        '
        'MenuItem20
        '
        Me.MenuItem20.Index = 0
        Me.MenuItem20.Text = "Services Schedule"
        '
        'MenuItem26
        '
        Me.MenuItem26.Index = 1
        Me.MenuItem26.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem5, Me.MenuItem11, Me.MenuItem51, Me.MenuItem10, Me.MenuItem16, Me.MenuItem17, Me.MenuItem28})
        Me.MenuItem26.Text = "Holidays Processing"
        '
        'MenuItem5
        '
        Me.MenuItem5.Index = 0
        Me.MenuItem5.Text = "Holiday Setup"
        '
        'MenuItem11
        '
        Me.MenuItem11.Index = 1
        Me.MenuItem11.Text = "Notice Formats"
        '
        'MenuItem51
        '
        Me.MenuItem51.Index = 2
        Me.MenuItem51.Text = "Mass Account Holiday Setup"
        '
        'MenuItem10
        '
        Me.MenuItem10.Index = 3
        Me.MenuItem10.Text = "Notice && Format Selection"
        '
        'MenuItem16
        '
        Me.MenuItem16.Index = 4
        Me.MenuItem16.Text = "Response Processing"
        '
        'MenuItem17
        '
        Me.MenuItem17.Index = 5
        Me.MenuItem17.Text = "Account Requirements && Charges"
        '
        'MenuItem28
        '
        Me.MenuItem28.Index = 6
        Me.MenuItem28.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem14, Me.MenuItem50, Me.MenuItem15, Me.MenuItem18})
        Me.MenuItem28.Text = "Holidays Listings"
        '
        'MenuItem14
        '
        Me.MenuItem14.Index = 0
        Me.MenuItem14.Text = "Accounts Holiday Status"
        '
        'MenuItem50
        '
        Me.MenuItem50.Index = 1
        Me.MenuItem50.Text = "Response Report"
        '
        'MenuItem15
        '
        Me.MenuItem15.Index = 2
        Me.MenuItem15.Text = "No Service Request"
        '
        'MenuItem18
        '
        Me.MenuItem18.Index = 3
        Me.MenuItem18.Text = "Account Requirements && Charges"
        '
        'MenuItem27
        '
        Me.MenuItem27.Index = 2
        Me.MenuItem27.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem19, Me.MenuItem25})
        Me.MenuItem27.Text = "Administrative Tools"
        '
        'MenuItem19
        '
        Me.MenuItem19.Index = 0
        Me.MenuItem19.Text = "Account Increases"
        '
        'MenuItem25
        '
        Me.MenuItem25.Index = 1
        Me.MenuItem25.Text = "Scheduled Service Charge Raise"
        '
        'MenuItem23
        '
        Me.MenuItem23.Index = 3
        Me.MenuItem23.Text = "Time Frames"
        '
        'MenuItem29
        '
        Me.MenuItem29.Index = 4
        Me.MenuItem29.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem30, Me.MenuItem131})
        Me.MenuItem29.Text = "Sch.Jobs Listings"
        '
        'MenuItem30
        '
        Me.MenuItem30.Index = 0
        Me.MenuItem30.Text = "Group Membership"
        '
        'MenuItem131
        '
        Me.MenuItem131.Index = 1
        Me.MenuItem131.Text = "Print Routes Schedule"
        '
        'MenuItem13
        '
        Me.MenuItem13.Index = 2
        Me.MenuItem13.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem115, Me.MenuItem117})
        Me.MenuItem13.Text = "&Listings"
        '
        'MenuItem115
        '
        Me.MenuItem115.Index = 0
        Me.MenuItem115.Text = "Account Listing"
        '
        'MenuItem117
        '
        Me.MenuItem117.Index = 1
        Me.MenuItem117.Text = "Phone Listing"
        '
        'MenuItem32
        '
        Me.MenuItem32.Index = 3
        Me.MenuItem32.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem33, Me.MenuItem38, Me.MenuItem39, Me.MenuItem43, Me.MenuItem113})
        Me.MenuItem32.Text = "Weight Module"
        '
        'MenuItem33
        '
        Me.MenuItem33.Index = 0
        Me.MenuItem33.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem34, Me.MenuItem35, Me.MenuItem36, Me.MenuItem37})
        Me.MenuItem33.Text = "Weight Module Setups"
        '
        'MenuItem34
        '
        Me.MenuItem34.Index = 0
        Me.MenuItem34.Text = "Region "
        '
        'MenuItem35
        '
        Me.MenuItem35.Index = 1
        Me.MenuItem35.Text = "Weight Charge"
        '
        'MenuItem36
        '
        Me.MenuItem36.Index = 2
        Me.MenuItem36.Text = "Manifest"
        '
        'MenuItem37
        '
        Me.MenuItem37.Index = 3
        Me.MenuItem37.Text = "Weight-Plan"
        '
        'MenuItem38
        '
        Me.MenuItem38.Index = 1
        Me.MenuItem38.Text = "Weight Entry"
        '
        'MenuItem39
        '
        Me.MenuItem39.Index = 2
        Me.MenuItem39.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem40, Me.MenuItem41, Me.MenuItem42})
        Me.MenuItem39.Text = "Weight Module Reports"
        '
        'MenuItem40
        '
        Me.MenuItem40.Index = 0
        Me.MenuItem40.Text = "Account Transactions"
        '
        'MenuItem41
        '
        Me.MenuItem41.Index = 1
        Me.MenuItem41.Text = "Blank Manifest"
        '
        'MenuItem42
        '
        Me.MenuItem42.Index = 2
        Me.MenuItem42.Text = "Sigma Print"
        '
        'MenuItem43
        '
        Me.MenuItem43.Index = 3
        Me.MenuItem43.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem44, Me.MenuItem45})
        Me.MenuItem43.Text = "Weight Module Listings"
        '
        'MenuItem44
        '
        Me.MenuItem44.Index = 0
        Me.MenuItem44.Text = "Plans"
        '
        'MenuItem45
        '
        Me.MenuItem45.Index = 1
        Me.MenuItem45.Text = "Weights"
        '
        'MenuItem113
        '
        Me.MenuItem113.Index = 4
        Me.MenuItem113.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem114, Me.MenuItem118})
        Me.MenuItem113.Text = "Administration Tools"
        '
        'MenuItem114
        '
        Me.MenuItem114.Index = 0
        Me.MenuItem114.Text = "Weight Inputs Table"
        '
        'MenuItem118
        '
        Me.MenuItem118.Index = 1
        Me.MenuItem118.Text = "Weight Entry Utilities"
        '
        'MenuItem46
        '
        Me.MenuItem46.Index = 4
        Me.MenuItem46.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem49, Me.MenuItem101, Me.MenuItem111, Me.MenuItem47})
        Me.MenuItem46.Text = "Billing"
        '
        'MenuItem49
        '
        Me.MenuItem49.Index = 0
        Me.MenuItem49.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem107, Me.MenuItem102, Me.MenuItem103, Me.MenuItem104, Me.MenuItem105, Me.MenuItem106})
        Me.MenuItem49.Text = "Setup"
        '
        'MenuItem107
        '
        Me.MenuItem107.Index = 0
        Me.MenuItem107.Text = "Billing Settings"
        '
        'MenuItem102
        '
        Me.MenuItem102.Index = 1
        Me.MenuItem102.Text = "Price-Plan Module"
        '
        'MenuItem103
        '
        Me.MenuItem103.Index = 2
        Me.MenuItem103.Text = "Price-Plan Zone"
        '
        'MenuItem104
        '
        Me.MenuItem104.Index = 3
        Me.MenuItem104.Text = "Price-Plan"
        '
        'MenuItem105
        '
        Me.MenuItem105.Index = 4
        Me.MenuItem105.Text = "Price-Plan Customer"
        '
        'MenuItem106
        '
        Me.MenuItem106.Index = 5
        Me.MenuItem106.Text = "Copy Price-Plan"
        '
        'MenuItem101
        '
        Me.MenuItem101.Index = 1
        Me.MenuItem101.Text = "Input Miscellaneous Charges"
        '
        'MenuItem111
        '
        Me.MenuItem111.Index = 2
        Me.MenuItem111.Text = "Miscellaneous Charges Listing"
        '
        'MenuItem47
        '
        Me.MenuItem47.Index = 3
        Me.MenuItem47.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem48, Me.MenuItem96, Me.MenuItem97, Me.MenuItem98, Me.MenuItem99, Me.MenuItem100})
        Me.MenuItem47.Text = "Invoice Processing"
        '
        'MenuItem48
        '
        Me.MenuItem48.Index = 0
        Me.MenuItem48.Text = "Generate Invoices"
        '
        'MenuItem96
        '
        Me.MenuItem96.Index = 1
        Me.MenuItem96.Text = "Invoice Listing"
        '
        'MenuItem97
        '
        Me.MenuItem97.Index = 2
        Me.MenuItem97.Text = "Charge Distribution"
        '
        'MenuItem98
        '
        Me.MenuItem98.Index = 3
        Me.MenuItem98.Text = "Print Invoice"
        '
        'MenuItem99
        '
        Me.MenuItem99.Index = 4
        Me.MenuItem99.Text = "Export Invoice to EDI"
        '
        'MenuItem100
        '
        Me.MenuItem100.Index = 5
        Me.MenuItem100.Text = "Delete Invoice "
        '
        'MenuItem52
        '
        Me.MenuItem52.Index = 5
        Me.MenuItem52.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem53, Me.MenuItem54, Me.MenuItem55, Me.MenuItem56, Me.MenuItem57, Me.MenuItem58})
        Me.MenuItem52.Text = "Trucks Management"
        '
        'MenuItem53
        '
        Me.MenuItem53.Index = 0
        Me.MenuItem53.Text = "Provider Setup"
        '
        'MenuItem54
        '
        Me.MenuItem54.Index = 1
        Me.MenuItem54.Text = "Trucks Inventory"
        '
        'MenuItem55
        '
        Me.MenuItem55.Index = 2
        Me.MenuItem55.Text = "Daily Activity Input"
        '
        'MenuItem56
        '
        Me.MenuItem56.Index = 3
        Me.MenuItem56.Text = "Provider Invoice Assignment"
        '
        'MenuItem57
        '
        Me.MenuItem57.Index = 4
        Me.MenuItem57.Text = "Trucks History"
        '
        'MenuItem58
        '
        Me.MenuItem58.Index = 5
        Me.MenuItem58.Text = "Trucks Inventory Listing"
        '
        'MenuItem31
        '
        Me.MenuItem31.Index = 6
        Me.MenuItem31.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem60, Me.MenuItem108, Me.MenuItem63, Me.MenuItem67, Me.MenuItem91})
        Me.MenuItem31.Text = "Tracking System"
        '
        'MenuItem60
        '
        Me.MenuItem60.Index = 0
        Me.MenuItem60.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem61, Me.MenuItem62})
        Me.MenuItem60.Text = "Tracking Setup"
        '
        'MenuItem61
        '
        Me.MenuItem61.Index = 0
        Me.MenuItem61.Text = "City Setup"
        '
        'MenuItem62
        '
        Me.MenuItem62.Index = 1
        Me.MenuItem62.Text = "Branch-ZipCode"
        '
        'MenuItem108
        '
        Me.MenuItem108.Index = 1
        Me.MenuItem108.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem109, Me.MenuItem110, Me.MenuItem120, Me.MenuItem132})
        Me.MenuItem108.Text = "Import"
        '
        'MenuItem109
        '
        Me.MenuItem109.Index = 0
        Me.MenuItem109.Text = "Import IPI Files"
        '
        'MenuItem110
        '
        Me.MenuItem110.Index = 1
        Me.MenuItem110.Text = "Import EDI Files"
        '
        'MenuItem120
        '
        Me.MenuItem120.Index = 2
        Me.MenuItem120.Text = "Import Scan List"
        '
        'MenuItem132
        '
        Me.MenuItem132.Index = 3
        Me.MenuItem132.Text = "Import Scan List From Unison"
        '
        'MenuItem63
        '
        Me.MenuItem63.Index = 2
        Me.MenuItem63.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem64, Me.MenuItem65, Me.MenuItem124})
        Me.MenuItem63.Text = "Tracking Operations"
        '
        'MenuItem64
        '
        Me.MenuItem64.Index = 0
        Me.MenuItem64.Text = "Add Event"
        '
        'MenuItem65
        '
        Me.MenuItem65.Index = 1
        Me.MenuItem65.Text = "Pre-Print S -Labels"
        '
        'MenuItem124
        '
        Me.MenuItem124.Index = 2
        Me.MenuItem124.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem126, Me.MenuItem127})
        Me.MenuItem124.Text = "Pouch Labels"
        '
        'MenuItem126
        '
        Me.MenuItem126.Enabled = False
        Me.MenuItem126.Index = 0
        Me.MenuItem126.Text = "Print Pouch Labels"
        '
        'MenuItem127
        '
        Me.MenuItem127.Index = 1
        Me.MenuItem127.Text = "Create Pouch Labels"
        '
        'MenuItem67
        '
        Me.MenuItem67.Index = 3
        Me.MenuItem67.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem89, Me.MenuItem68, Me.MenuItem90, Me.MenuItem95, Me.MenuItem134})
        Me.MenuItem67.Text = "Management Reports"
        '
        'MenuItem89
        '
        Me.MenuItem89.Index = 0
        Me.MenuItem89.Text = "Basic Tracking Listing"
        '
        'MenuItem68
        '
        Me.MenuItem68.Index = 1
        Me.MenuItem68.Text = "Tracking Listing"
        '
        'MenuItem90
        '
        Me.MenuItem90.Index = 2
        Me.MenuItem90.Text = "Exception Reports"
        '
        'MenuItem95
        '
        Me.MenuItem95.Index = 3
        Me.MenuItem95.Text = "Billing Summary Report"
        '
        'MenuItem134
        '
        Me.MenuItem134.Index = 4
        Me.MenuItem134.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem135, Me.MenuItem136})
        Me.MenuItem134.Text = "Scan List Reports"
        '
        'MenuItem135
        '
        Me.MenuItem135.Index = 0
        Me.MenuItem135.Text = "Suspicious Scans"
        '
        'MenuItem136
        '
        Me.MenuItem136.Index = 1
        Me.MenuItem136.Text = "Weight Capture Summary"
        '
        'MenuItem91
        '
        Me.MenuItem91.Index = 4
        Me.MenuItem91.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem92, Me.MenuItem93, Me.MenuItem94})
        Me.MenuItem91.Text = "Operations Reports"
        '
        'MenuItem92
        '
        Me.MenuItem92.Index = 0
        Me.MenuItem92.Text = "Delivery Manifest"
        '
        'MenuItem93
        '
        Me.MenuItem93.Index = 1
        Me.MenuItem93.Text = "Shipping Reports"
        '
        'MenuItem94
        '
        Me.MenuItem94.Index = 2
        Me.MenuItem94.Text = "Shipment Destinations"
        '
        'MenuItem69
        '
        Me.MenuItem69.Index = 7
        Me.MenuItem69.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem70, Me.MenuItem71, Me.MenuItem75, Me.MenuItem80, Me.MenuItem85, Me.MenuItem122, Me.MenuItem88})
        Me.MenuItem69.Text = "HR"
        '
        'MenuItem70
        '
        Me.MenuItem70.Index = 0
        Me.MenuItem70.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem76, Me.MenuItem77, Me.MenuItem73, Me.MenuItem78, Me.MenuItem72, Me.MenuItem74, Me.MenuItem79, Me.MenuItem87, Me.MenuItem133})
        Me.MenuItem70.Text = "HR Setup"
        '
        'MenuItem76
        '
        Me.MenuItem76.Index = 0
        Me.MenuItem76.Text = "Departments"
        '
        'MenuItem77
        '
        Me.MenuItem77.Index = 1
        Me.MenuItem77.Text = "Dept. Classes"
        '
        'MenuItem73
        '
        Me.MenuItem73.Index = 2
        Me.MenuItem73.Text = "Branch Fuel Surcharge"
        '
        'MenuItem78
        '
        Me.MenuItem78.Index = 3
        Me.MenuItem78.Text = "Deduction Items"
        '
        'MenuItem72
        '
        Me.MenuItem72.Index = 4
        Me.MenuItem72.Text = "Employee Setup"
        '
        'MenuItem74
        '
        Me.MenuItem74.Index = 5
        Me.MenuItem74.Text = "Misc. Income Items"
        '
        'MenuItem79
        '
        Me.MenuItem79.Index = 6
        Me.MenuItem79.Text = "WC Setup"
        '
        'MenuItem87
        '
        Me.MenuItem87.Index = 7
        Me.MenuItem87.Text = "Employees Schedule"
        '
        'MenuItem133
        '
        Me.MenuItem133.Index = 8
        Me.MenuItem133.Text = "Employees Badge Print"
        '
        'MenuItem71
        '
        Me.MenuItem71.Index = 1
        Me.MenuItem71.Text = "Period Ending Input"
        '
        'MenuItem75
        '
        Me.MenuItem75.Index = 2
        Me.MenuItem75.Text = "Process Payroll"
        '
        'MenuItem80
        '
        Me.MenuItem80.Index = 3
        Me.MenuItem80.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem83, Me.MenuItem81, Me.MenuItem82, Me.MenuItem84, Me.MenuItem86, Me.MenuItem112, Me.MenuItem119, Me.MenuItem121, Me.MenuItem125, Me.MenuItem66})
        Me.MenuItem80.Text = "Reports && Listings"
        '
        'MenuItem83
        '
        Me.MenuItem83.Index = 0
        Me.MenuItem83.Text = "Employee Listing"
        '
        'MenuItem81
        '
        Me.MenuItem81.Index = 1
        Me.MenuItem81.Text = "Period Ending Listing"
        '
        'MenuItem82
        '
        Me.MenuItem82.Index = 2
        Me.MenuItem82.Text = "Processed Period Income && Deduction Report"
        '
        'MenuItem84
        '
        Me.MenuItem84.Index = 3
        Me.MenuItem84.Text = "UnProcessed Deductions && Misc.Income Listing"
        '
        'MenuItem86
        '
        Me.MenuItem86.Index = 4
        Me.MenuItem86.Text = "Time Card Input Listing"
        '
        'MenuItem112
        '
        Me.MenuItem112.Index = 5
        Me.MenuItem112.Text = "YTD Listing"
        '
        'MenuItem119
        '
        Me.MenuItem119.Index = 6
        Me.MenuItem119.Text = "Print Time Card Labels"
        '
        'MenuItem121
        '
        Me.MenuItem121.Index = 7
        Me.MenuItem121.Text = "Print Expense Check Stubs"
        '
        'MenuItem125
        '
        Me.MenuItem125.Index = 8
        Me.MenuItem125.Text = "Mileage Input Listing"
        '
        'MenuItem66
        '
        Me.MenuItem66.Index = 9
        Me.MenuItem66.Text = "Vehicle Listing"
        '
        'MenuItem85
        '
        Me.MenuItem85.Index = 4
        Me.MenuItem85.Text = "Time Card Input"
        '
        'MenuItem122
        '
        Me.MenuItem122.Index = 5
        Me.MenuItem122.Text = "Mileage Input"
        '
        'MenuItem88
        '
        Me.MenuItem88.Index = 6
        Me.MenuItem88.Text = "Process Time Card Inputs"
        Me.MenuItem88.Visible = False
        '
        'MenuItem128
        '
        Me.MenuItem128.Index = 8
        Me.MenuItem128.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem129})
        Me.MenuItem128.Text = "Orders"
        Me.MenuItem128.Visible = False
        '
        'MenuItem129
        '
        Me.MenuItem129.Index = 0
        Me.MenuItem129.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem130})
        Me.MenuItem129.Text = "Order Listings"
        '
        'MenuItem130
        '
        Me.MenuItem130.Index = 0
        Me.MenuItem130.Text = "Rapid Order History"
        '
        'MenuItem137
        '
        Me.MenuItem137.Index = 9
        Me.MenuItem137.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem138, Me.MenuItem144})
        Me.MenuItem137.Text = "Settlement"
        '
        'MenuItem138
        '
        Me.MenuItem138.Index = 0
        Me.MenuItem138.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem140, Me.MenuItem141, Me.MenuItem139, Me.MenuItem142, Me.MenuItem143})
        Me.MenuItem138.Text = "smSetup"
        '
        'MenuItem140
        '
        Me.MenuItem140.Index = 0
        Me.MenuItem140.Text = "Settings"
        '
        'MenuItem141
        '
        Me.MenuItem141.Index = 1
        Me.MenuItem141.Text = "Price Plan Modules"
        '
        'MenuItem139
        '
        Me.MenuItem139.Index = 2
        Me.MenuItem139.Text = "Price Plan Zone"
        '
        'MenuItem142
        '
        Me.MenuItem142.Index = 3
        Me.MenuItem142.Text = "Price Plan Setup"
        '
        'MenuItem143
        '
        Me.MenuItem143.Index = 4
        Me.MenuItem143.Text = "Price Plan Customer"
        '
        'MenuItem144
        '
        Me.MenuItem144.Index = 1
        Me.MenuItem144.MenuItems.AddRange(New System.Windows.Forms.MenuItem() {Me.MenuItem145, Me.MenuItem147, Me.MenuItem148, Me.MenuItem149, Me.MenuItem146})
        Me.MenuItem144.Text = "Processing"
        '
        'MenuItem145
        '
        Me.MenuItem145.Index = 0
        Me.MenuItem145.Text = "Generate"
        '
        'MenuItem147
        '
        Me.MenuItem147.Index = 1
        Me.MenuItem147.Text = "Listings"
        '
        'MenuItem148
        '
        Me.MenuItem148.Index = 2
        Me.MenuItem148.Text = "Cost Distribution"
        '
        'MenuItem149
        '
        Me.MenuItem149.Index = 3
        Me.MenuItem149.Text = "Print"
        '
        'MenuItem146
        '
        Me.MenuItem146.Index = 4
        Me.MenuItem146.Text = "Delete"
        '
        'MenuItem7
        '
        Me.MenuItem7.Index = -1
        Me.MenuItem7.Text = "Print Account Transactions"
        '
        'MenuItem9
        '
        Me.MenuItem9.Index = -1
        Me.MenuItem9.Text = "Print Blank Manifest"
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label4)
        Me.Panel1.Controls.Add(Me.Label3)
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(720, 241)
        Me.Panel1.TabIndex = 2
        '
        'Label4
        '
        Me.Label4.Location = New System.Drawing.Point(76, 176)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(100, 16)
        Me.Label4.TabIndex = 13
        Me.Label4.Text = "IPI Path:"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(76, 128)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(100, 16)
        Me.Label3.TabIndex = 12
        Me.Label3.Text = "EDI Path:"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label2
        '
        Me.Label2.Location = New System.Drawing.Point(188, 176)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(448, 44)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Label2"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(188, 128)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(448, 40)
        Me.Label1.TabIndex = 10
        Me.Label1.Text = "Label1"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Form1
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(720, 241)
        Me.Controls.Add(Me.Panel1)
        Me.Menu = Me.MainMenu1
        Me.Name = "Form1"
        Me.Text = "Unison "
        Me.Panel1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub MainMenu_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Dim objConnection As OleDbConnection = _
        '    New OleDbConnection("Provider = SQLOLEDB;" & _
        '    " Data Source = NTSRVR1; Initial Catalog = UNISON;" & _
        '    " User ID = sa;password = 4183771")

        'objConnection.Open()

        'objDataAdapter.SelectCommand = New OleDbCommand()
        'objDataAdapter.SelectCommand.Connection = objConnection
        'objDataAdapter.SelectCommand.CommandText = "Select * from CompanyProfile"
        'objDataAdapter.SelectCommand.CommandType = CommandType.Text
        'Try
        '    objDataAdapter.SelectCommand.ExecuteNonQuery()
        'Catch er As Exception
        '    MsgBox(er.ToString & er.Message)
        'Catch err As SystemException
        '    MsgBox(err.Message)
        'End Try
        'objDataAdapter.Fill(objDataset, "CompanyProfile")
        'objConnection.Close()
        'objDataAdapter = Nothing
        'objConnection = Nothing
        'DataGrid1.DataSource = objDataset
        'DataGrid1.DataMember = "CompanyProfile"

        ''strConnection = "Server = 192.80.90.200; " & _
        ''                              "Database = RoutesModule; " & _
        ''                              "User ID = Routes; Password = routes"
        ''sqlConn.ConnectionString = strConnection

        Me.KeyPreview = True

        'LocalIP = "" : RemoteIP = ""
        'If CheckSetupINI() = False Then
        '    Me.Close()
        'End If
        ''Me.Text = Me.Text & "- Connected To: " & LocalName

        'IPAddr = IIf(LocalIP <> "", LocalIP, RemoteIP) '"192.80.90.200"
        ''IPAddr = "66.14.100.162"
        ''IPAddr = "192.168.1.102"

        'strConnection = "Server = " & IPAddr & ";Database = " & AppDBName & "; " & "User ID = " & AppDBUser & "; Password = " & AppDBPass & ""
        'strConnection2 = "Server = " & IPAddr & ";Database = @DB;User ID = @USER;Password= @PASS"
        'sqlConn.ConnectionString = strConnection


        'Me.Text = Me.Text & "  v.4.22 Security+Weight+Holidays+Trucks+HR+Tracking+TrackingBilling " & " -- Comp: " & LoginInfo.CompanyName & ", User: " & LoginInfo.UserName
        'Me.Text = Me.Text & "  V4.26b" & " -- Company: " & LoginInfo.CompanyName & ", User: " & LoginInfo.UserName
        'Me.Text = Me.Text & "  V4.26c" & " -- Company: " & LoginInfo.CompanyName & ", User: " & LoginInfo.UserName
        '   a) Fixes Overlapping Miles bug in Mileage Input
        '   b) Removes Weekly Input Screen Option from Mileage Input
        'Me.Text = Me.Text & "  V4.27a Dev" & " -- Company: " & LoginInfo.CompanyName & ", User: " & LoginInfo.UserName
        '   a) Adds "Past Date" Check to MileageInput logic
        'Me.Text = Me.Text & "  V4.27b" & " -- Company: " & LoginInfo.CompanyName & ", User: " & LoginInfo.UserName
        '   a) Adds support for OdometerReset feature.
        'Me.Text = Me.Text & "  V4.27c" & " -- Company: " & LoginInfo.CompanyName & ", User: " & LoginInfo.UserName
        '   a) Check for Equal End Points during Mileage Input Separatly from Violation Checks
        'Me.Text = Me.Text & "  MCV4.29 Dev" & " -- Company: " & LoginInfo.CompanyName & ", User: " & LoginInfo.UserName
        '   a) Order Expense Report by Company, Office, EmployeeID instead of just EmployeeID
        'Me.Text = Me.Text & "  MCV4.29a Dev" & " -- Company: " & LoginInfo.CompanyName & ", User: " & LoginInfo.UserName
        '   a) Check-in all prior to creating CFC Badge 
        'Me.Text = Me.Text & "  MCV4.30" & " -- Company: " & LoginInfo.CompanyName & ", User: " & LoginInfo.UserName
        '   a) Added Export to Excel Functionality to Truck History Form
        '   b) Moved the "Print Badge" button out of the editable group box
        '   c) Dynamic Badge Report Selection
        '   d) Added Ability to Print Comet Style Tickets
        '   e) Completed "Add Event" Functionality
        '   f) Expanded Options for Printing Flip-cards
        '   g) Cleaned up some of the code in BillingInvoiceGen.vb
        '   h) Added ability to suppress inactive weight plans within the weight plan setup form
        '   i) Fixed bug whereby Weight Transactions by Summary by Club would not display
        '   j) Fixed bug whereby the weight entry listing displayed duplicate rows when account belonged to more than one account
        '   k) Fixed bug whereby the weight entry listing's rows could not be summarized
        'Me.Text = Me.Text & "  MCV4.30c DEV" & " -- Company: " & LoginInfo.CompanyName & ", User: " & LoginInfo.UserName
        '   a) Added Export to Excel Functionality to Daily Weight Entry Listing (DailyEntryListing.vb)
        '   b) Added PlanId column to Daily Weight Entry Listing
        '   c) Added EDI Segments for Ref2 & Ref3 database fields for Ingram-Micro (ExportInvoice.vb)
        '   d) Suppressed "Show Summary" button in "Print Invoice" form since it does not make sense. (InvoicePrint.vb)
        '   e) Add SETTLEMENT Module to Unison. (All Settlement files, LoginScreen.vb, MainMenu.vb)
        '   f) Add Floral Supply Syndicate and Ingram Books - North to the Delivery Manifest drop-down list. (DeliveryManifest.vb)
        '   g) Unknown changes to RouteSheet.rpt
        '   h) Group Membership was not loading until after Holiday tab was loaded; fixed. (AccountSetup.vb)
        '   i) Add support for VarChar account numbers
        'Me.Text = Me.Text & "  MCV4.30d DEV" & " -- Company: " & LoginInfo.CompanyName & ", User: " & LoginInfo.UserName
        '   a) Added Accounts 12035 and 11117 (Partners West & MedExpress) to Delivery Manifest drop-down
        'Me.Text = Me.Text & "  MCV4.30e DEV" & " -- Company: " & LoginInfo.CompanyName & ", User: " & LoginInfo.UserName
        '   a) Added Depot Filter to Delivery Manifest Report Form
        'Me.Text = Me.Text & "  MCV4.30f DEV" & " -- Company: " & LoginInfo.CompanyName & ", User: " & LoginInfo.UserName
        '   a) Sorted Delivery Manifest Report by City, Zip, Street
        'Me.Text = Me.Text & "  MCV4.30g DEV" & " -- Company: " & LoginInfo.CompanyName & ", User: " & LoginInfo.UserName
        '   a) Fix crash when plan ends before closing date during billing.
        '   b) Remove special Peninsula Messenger handling in Settlement module
        '   c) Add New Label Format, SLabelsVer2H, which is like the 2x4 but says "HOLD FOR PICKUP AT DEPOT: ________________________"
        '   d) Revise verbage on ID Badge "Confirmation of Recipt & Acknowlegement of Policy" form for all ID badges.
        '   e) Introduce Zip Code Maintenance
        '   f) Add "All Accounts" option to Invoice & Settlement listings
        'Me.Text = Me.Text & "  MCV4.31h DEV" & " -- Company: " & LoginInfo.CompanyName & ", User: " & LoginInfo.UserName
        '   a) Fix MileageInput for new employees who have no entry in Odometer reset
        '   b) Add OWL to Delivery Manifest List
        'Me.Text = Me.Text & "  MCV4.31i DEV" & " -- Company: " & LoginInfo.CompanyName & ", User: " & LoginInfo.UserName
        '   a) Add OWL to Delivery Manifest List
        '   b) Add PIA Chowchilla Stamp Option
        '   c) Add PIA Vacaville Stamp Option
        '   d) Make PIA Stamps Totally DB Driven
        'Me.Text = Me.Text & "  MCV4.31j" & " -- Company: " & LoginInfo.CompanyName & ", User: " & LoginInfo.UserName
        '   a) Make Delivery Manifest Customer Drop-down Dynamic.  It is now driven by VIEW dbo.DeliveryManifestCustomers
        '   b) Simplify and make AddEvent work for "Driver Delivered"
        '   c) Implement phase one of "Customer Rights Managent" which only allows certain users to see certain customers.  Intial test with one hard-coded user in FilteredCustomerList DB function
        'Me.Text = Me.Text & "  MCV4.31k" & " -- Company: " & LoginInfo.CompanyName & ", User: " & LoginInfo.UserName
        '   a) Make Delivery Manifest Customer Drop-down Dynamic.  It is now driven by VIEW dbo.DeliveryManifestCustomers
        '   b) Simplify and make AddEvent work for "Driver Delivered"
        '   c) Implement phase one of "Customer Rights Managent" which only allows certain users to see certain customers.  Intial test with one hard-coded user in FilteredCustomerList DB function
        'Me.Text = Me.Text & "  MCV4.31l" & " -- Company: " & LoginInfo.CompanyName & ", User: " & LoginInfo.UserName
        '   a) Fix comparison error that was preventing entry of valid EndDates for Billing plans
        '   b) Fix comparison error that was preventing entry of valid EndDates for Settlement plans
        '   c) Added overloaded range function to clsFieldValidator to safely compare Int16 types
        '   d) Added support for 3x1 inch time card labels
        '   e) Simplified AddEvent so that only DD's can be entered and exact barcode must be known
        '   f) Added support for PIA stamps
        'Me.Text = Me.Text & "  MCV4.31m" & " -- Company: " & LoginInfo.CompanyName & ", User: " & LoginInfo.UserName
        '   a) Display RefNum in Printed Invoice's Description field
        'Me.Text = Me.Text & "  MCV4.31n" & " -- Company: " & LoginInfo.CompanyName & ", User: " & LoginInfo.UserName
        '   a) Expanded window in ADD EVENT from -30 days to -90 days; also refresh Grid View upon adding an event.
        '   b) Set index for Pickup (4) as default vehicle type when adding a new vehicle to an employee.  Previously set to string, "PICKUP"
        '   c) Corrected bad assumption when exporting an invoice to EDI whereby a specifically formatted RFF was assumed.
        'Me.Text = Me.Text & "  MCV4.31o Pre-Release 1" & " -- Company: " & LoginInfo.CompanyName & ", User: " & LoginInfo.UserName
        ''   a) Made MaxLength of barcode fiels dynamic based on radio button choice
        'Me.Text = Me.Text & "  MCV4.31p Pre-Release" & " -- Company: " & LoginInfo.CompanyName & ", User: " & LoginInfo.UserName
        ''   a) Added PayRate colunn to the HR Timecard Input listing form.
        'Me.Text = Me.Text & "  MCV4.31q Pre-Release" & " -- Company: " & LoginInfo.CompanyName & ", User: " & LoginInfo.UserName
        Me.Text = Me.Text & "  MCV2019.3" & " -- Company: " & LoginInfo.CompanyName & ", User: " & LoginInfo.UserName
        '   a) Re-introduce Tracking Number Search into ADD EVENT


        Label1.Text = EDIPath
        Label2.Text = IPIPath

        ValidateAccess(MainMenu1, LoginInfo.UserID, LoginInfo.CompanyCode)

    End Sub


    Private Sub MenuItem3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem3.Click
        Dim x As New AccountSetup()
        x.Show()
    End Sub

    Private Sub MenuItem4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem4.Click
        Dim x As New ServiceOfficeSetup()
        x.Show()

    End Sub

    Private Sub MenuItem5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem5.Click
        Dim x As New HolidaySetup()
        x.Show()

    End Sub

    Private Sub MenuItem11_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem11.Click
        Dim x As New NoticeFormats()
        x.Show()
    End Sub

    Private Sub MenuItem8_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem8.Click
        Dim x As New AccountServices()
        x.Show()
    End Sub

    Private Sub MenuItem10_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem10.Click
        Dim x As New NoticeSetup()
        x.Show()
    End Sub

    Private Sub MenuItem16_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem16.Click
        Dim x As New RespProcess()
        x.Show()
    End Sub

    Private Sub MenuItem17_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem17.Click
        Dim x As New RequiredServices()
        x.Show()
    End Sub

    Private Sub MenuItem18_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem18.Click
        Dim x As New RequiredServicesListing()
        x.Show()
    End Sub

    Private Sub MenuItem14_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem14.Click
        Dim x As New AccountsListing()
        x.Show()
    End Sub

    Private Sub MenuItem15_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem15.Click
        Dim x As New NoSvcRequiredListing()
        x.Show()
    End Sub

    Private Sub MenuItem6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem6.Click
        Dim x As New EmployeesBase()
        x.Show()
    End Sub

    Private Sub MenuItem12_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem12.Click
        Dim x As New RoutesSetup()
        x.Show()
    End Sub

    Private Sub MenuItem21_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem21.Click
        Dim x As New PackageTypes()
        x.SQLSelect = "Select ID, Name as Code, SortID, Description from PackageTypes ORDER BY SortID"
        x.Text = "Package Types"
        x.Tag = "PackageTypes"
        x.UltraGrid1.Text = "Package Types"
        x.Label1.Text = "Code :"
        x.Value.Tag = ".Name......Code"
        x.SortColIdx = 2
        x.Show()
    End Sub

    Private Sub MenuItem22_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem22.Click
        Dim x As New CodeLabelForm
        x.SQLSelect = "Select ID, Name from ServiceTypes ORDER BY Name"
        x.Text = "Service Types"
        x.Tag = "ServiceTypes"
        x.UltraGrid1.Text = "Service Types"
        x.Label1.Text = "Service Type :"
        x.Value.Tag = ".Name"
        x.CLDB = AppDBName
        x.CLDBUser = AppDBUser
        x.CLDBPass = AppDBPass
        x.SortColIdx = 1
        x.Show()

    End Sub

    Private Sub MenuItem23_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem23.Click
        Dim x As New CodeLabelForm
        x.SQLSelect = "Select ID, Name from " & ROUTESTblPath & "TimeFrames ORDER BY Name"
        x.Text = "Time Frames"
        x.Tag = "TimeFrames"
        x.UltraGrid1.Text = "Time Frames"
        x.Label1.Text = "Time Frame :"
        x.Value.Tag = ".Name"
        'x.CLDB = AppDBName
        x.CLDB = ROUTESDBName '"UN_ROUTES"
        x.CLDBUser = AppDBUser
        x.CLDBPass = AppDBPass
        x.SortColIdx = 1
        x.p_AppTblPath = ROUTESTblPath ' "UN_ROUTES.dbo."
        x.Show()

    End Sub

    Private Sub MenuItem24_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem24.Click
        Dim x As New CodeLabelForm
        x.SQLSelect = "Select ID, Name from Services ORDER BY Name"
        x.Text = "Services"
        x.Tag = "Services"
        x.UltraGrid1.Text = "Services"
        x.Label1.Text = "Service :"
        x.Value.Tag = ".Name"
        x.CLDB = AppDBName
        x.CLDBUser = AppDBUser
        x.CLDBPass = AppDBPass
        x.SortColIdx = 1
        x.Show()

    End Sub

    Private Sub MenuItem20_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem20.Click
        Dim x As New AcctSvcSchedule()
        x.Show()
    End Sub

    Private Sub MenuItem19_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem19.Click
        Dim x As New IncreaseAccounts()
        x.Show()
    End Sub

    Private Sub MenuItem25_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem25.Click
        Dim x As New IncreaseServices()
        x.Show()
    End Sub

    Private Sub MenuItem30_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem30.Click
        Dim x As New RteSvcGroupMembersListing()
        x.Show()
    End Sub

    'Private Sub MenuItem31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem31.Click
    '    Dim x As New AccountGroup
    '    x.Show()
    'End Sub

    Private Sub MenuItem34_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem34.Click
        Dim x As New CodeLabelForm
        x.SQLSelect = "Select ID, Name from Regions ORDER BY Name"
        x.Text = "Region Setup"
        x.Tag = "REGIONS"
        x.UltraGrid1.Text = "Regions"
        x.Label1.Text = "Region:"
        x.Value.Tag = ".Name"
        x.CLDB = AppDBName
        x.CLDBUser = AppDBUser
        x.CLDBPass = AppDBPass
        x.SortColIdx = 1
        x.Show()
    End Sub

    Private Sub MenuItem35_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem35.Click
        Dim x As New WeightBreakdown
        x.Show()
    End Sub

    Private Sub MenuItem36_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem36.Click
        Dim x As New WeightPlanGroup
        x.Show()
    End Sub

    Private Sub MenuItem37_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem37.Click
        Dim x As New WeightPlan
        x.Show()
    End Sub

    Private Sub MenuItem38_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem38.Click
        Dim x As New DailyEntry
        x.Show()
    End Sub

    Private Sub MenuItem40_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem40.Click
        Dim x As New Report
        x.Show()
    End Sub

    Private Sub MenuItem41_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem41.Click
        Dim x As New WeightEntryBlankPrint
        x.Show()
    End Sub

    Private Sub MenuItem42_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem42.Click
        Dim x As New SigmaPrint
        x.Show()
    End Sub

    Private Sub MenuItem44_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem44.Click
        Dim x As New WeightPlanListing1
        x.Show()
    End Sub

    Private Sub MenuItem45_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem45.Click
        Dim x As New DailyEntryListing
        x.Show()
    End Sub

    Private Sub MenuItem48_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem48.Click
        Dim x As New BillingInvoiceGen
        x.Show()
    End Sub

    Private Sub MenuItem49_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem49.Click
    End Sub

    Private Sub MenuItem50_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem50.Click
        Dim x As New ResponseReport
        x.Show()
    End Sub

    Private Sub MenuItem51_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem51.Click
        Dim x As New MassAcctHolidaySetup
        x.Show()
    End Sub

    Private Sub MenuItem53_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem53.Click
        Dim x As New ProviderSetup
        x.Show()
    End Sub

    Private Sub MenuItem54_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem54.Click
        Dim x As New TrucksInventory
        x.Show()
    End Sub

    Private Sub MenuItem55_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem55.Click
        Dim x As New TrucksActivity
        x.Show()
    End Sub

    Private Sub MenuItem56_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem56.Click
        Dim x As New InvoiceAssignment
        x.Show()
    End Sub

    Private Sub MenuItem57_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem57.Click
        Dim x As New TrucksHistory
        x.Show()
    End Sub

    Private Sub MenuItem58_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem58.Click
        Dim x As New TrucksInventoryListing
        x.Show()
    End Sub

    Private Sub MenuItem59_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem59.Click
        Dim x As New GroupsSetup
        x.Show()
    End Sub

    Private Sub MenuItem61_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem61.Click
        If ValidateAccess(sender, LoginInfo.UserID, LoginInfo.CompanyCode) Then
            'Dim x As New BranchZip
            'x.Show()
        Else
            'Message modified by Michael Pastor
            MsgBox("Authorization denied.", MsgBoxStyle.Exclamation, "Authorization Denied")
            '- MsgBox("Authorization Denied.")
        End If
    End Sub

    Private Sub MenuItem62_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem62.Click
        Dim x As New BranchZip
        x.Show()
    End Sub

    Private Sub MenuItem64_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem64.Click
        Dim x As New AddEvent
        x.Show()
    End Sub

    Private Sub MenuItem65_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem65.Click
        Dim x As New PrePrintSLabel
        x.Show()
    End Sub

    Private Sub MenuItem66_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Dim x As New PrintContainerLabels
        x.Show()
    End Sub

    Private Sub MenuItem68_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem68.Click
        Dim x As New Listing1
        x.Show()
    End Sub

    Private Sub MenuItem72_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem72.Click
        Dim x As New EmployeeSetup
        x.Show()
    End Sub

    Private Sub MenuItem76_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem76.Click
        Dim x As New DeptSetup
        ' x.SQLSelect = "Select DeptNo, Department, Active from " & HRTblPath & "DEPARTMENTS ORDER BY DeptNo"
        x.Show()
    End Sub

    Private Sub MenuItem78_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem78.Click
        Dim x As New DeductionSetup
        ' x.SQLSelect = "Select DeductionID, Deduction, Active From " & HRTblPath & "DEDACTIONS ORDER BY DeductionID"
        x.Show()
    End Sub

    Private Sub MenuItem74_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem74.Click
        Dim x As New MiscIncomeSetup
        x.Show()
    End Sub

    Private Sub MenuItem77_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem77.Click
        Dim x As New DeptClassesSetup
        x.Show()
    End Sub

    Private Sub MenuItem79_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem79.Click
        Dim x As New WCCodesSetup
        x.Show()
    End Sub


    Private Sub MenuItem73_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem73.Click
        Dim x As New BranchFuelSurchSetup
        x.Show()
    End Sub


    Private Sub MenuItem71_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem71.Click
        'Dim x As New TotalHoursInput
        Dim x As New TotalHoursInput2
        x.Show()
    End Sub

    Private Sub MenuItem75_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem75.Click
        Dim x As New ProcessPayroll
        x.Show()
    End Sub

    Private Sub MenuItem81_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem81.Click
        Dim x As New PayPeriodListing
        x.Show()
    End Sub

    Private Sub MenuItem82_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem82.Click
        Dim x As New PeriodIncomeDeductionReport
        x.Show()
    End Sub

    Private Sub MenuItem83_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem83.Click
        Dim x As New EmployeeListing
        x.Show()
    End Sub

    Private Sub MenuItem84_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem84.Click
        Dim x As New UnProcDedIncomeListing
        x.Show()

    End Sub

    Private Sub MenuItem69_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem69.Click
        HRPASSOK = True
    End Sub

    Private Sub MenuItem69_Select(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItem69.Select

        If HRPASSOK Then Exit Sub

        'If GetPassword("hrps") Then
        '    MsgBox("Password validated. HR Menu is now open for use.")
        '    MenuItem69.PerformClick()
        'End If
    End Sub

    Private Sub MenuItem52_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem52.Click
        TRUCKSPASSOK = True
    End Sub

    Private Sub MenuItem52_Select(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItem52.Select
        If TRUCKSPASSOK Then Exit Sub

        'If GetPassword("mack") Then
        '    MsgBox("Password validated. Trucks Menu is now open for use.")
        '    MenuItem52.PerformClick()
        'End If
    End Sub

    Private Sub MenuItem32_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem32.Click
        WEIGHTPASSOK = True
    End Sub

    Private Sub MenuItem32_Select(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItem32.Select
        If WEIGHTPASSOK Then Exit Sub

        'If GetPassword("pnd") Then
        '    MsgBox("Password validated. Weight Module Menu is now open for use.")
        '    MenuItem32.PerformClick()
        'End If
    End Sub

    Private Sub MenuItem2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem2.Click
        ROUTEPASSOK = True
    End Sub

    Private Sub MenuItem2_Select(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItem2.Select
        If ROUTEPASSOK Then Exit Sub

        'If GetPassword("sgb") Then
        '    MsgBox("Password validated. Routes Module Menu is now open for use.")
        '    MenuItem2.PerformClick()
        'End If
    End Sub

    Private Sub MenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem1.Click
        SYSPASSOK = True
    End Sub

    Private Sub MenuItem1_Select(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItem1.Select
        If SYSPASSOK Then Exit Sub

        'If GetPassword("wow") Then
        '    MsgBox("Password validated. System Menu is now open for use.")
        '    MenuItem1.PerformClick()
        'End If
    End Sub

    Private Sub Form1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        If e.KeyCode = Keys.F6 Then
            SYSPASSOK = True : ROUTEPASSOK = True : WEIGHTPASSOK = True : TRUCKSPASSOK = True : HRPASSOK = True
        End If
    End Sub

    Private Sub Form1_Closed(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Closed

    End Sub

    Private Sub MenuItem26_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem26.Click

    End Sub

    Private Sub Form1_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.GotFocus
        'MenuItem1.Enabled = ValidateAccess(MenuItem1, LoginInfo.UserID, LoginInfo.CompanyCode)
        'MenuItem2.Enabled = ValidateAccess(MenuItem2, LoginInfo.UserID, LoginInfo.CompanyCode)
        'ValidateAccess(MainMenu1, LoginInfo.UserID, LoginInfo.CompanyCode)
    End Sub

    Private Sub MenuItem85_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem85.Click
        'Date
        Dim x As New TimeCardInputGetPayrollEnding
        'x.ScreenCode = "DE"
        x.ShowDialog()
    End Sub

    Private Sub MenuItem86_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem86.Click
        Dim x As New TimeCardListing
        x.Show()
    End Sub

    Private Sub MenuItem87_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem87.Click
        Dim x As New EmployeeSchedule
        x.Show()
    End Sub

    Private Sub MenuItem88_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem88.Click
        Dim x As New ProcessTimeCardInput
        x.Show()
    End Sub

    Private Sub MenuItem89_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem89.Click
        'Tracking Basic Listing
        Dim x As New ItemTrackingListing
        x.Show()
    End Sub

    Private Sub MenuItem90_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem90.Click
        'Tracking Exception Reports
        Dim x As New ExceptionReports
        x.Show()
    End Sub

    Private Sub MenuItem95_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem95.Click
        'Tracking Billing Summary report

        Dim x As New DeliveryManifest

        x.Server = LocalIP 'RemoteIP
        x.btnSummary.Text = "Display"
        x.btnRun.Visible = False
        x.Text = "Billing Report"
        x.Name = "BillingSummary"
        x.Show()

    End Sub

    Private Sub MenuItem92_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem92.Click
        'Tracking Delivery Manifest

        Dim x As New DeliveryManifest
        x.Server = LocalIP
        x.Show()
    End Sub

    Private Sub MenuItem93_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem93.Click
        'Tracking Shipping Reports

        Dim x As New TransReport
        x.Server = LocalIP
        x.Show()
    End Sub

    Private Sub MenuItem94_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem94.Click
        'Tracking

        Dim x As New ShipmentDestinations

        x.Text = "Shipment Destinations Listing"
        x.Show()
    End Sub
    '====================
    ' Invoice Listing
    '====================

    Private Sub MenuItem96_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem96.Click
        Dim x As New InvoiceListing
        x.Show()
    End Sub
    '====================
    ' Invoice Charge Distribution
    '====================

    Private Sub MenuItem97_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem97.Click
        Dim x As New InvoiceChargeDistribution
        x.Show()
    End Sub

    '====================
    ' Print Invoice Details in Crystal Reports
    '====================
    Private Sub MenuItem98_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem98.Click
        Dim x As New InvoicePrint
        x.Show()
    End Sub

    '====================
    ' Export Invoice to EDI
    '====================
    Private Sub MenuItem99_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem99.Click
        Dim x As New ExportInvoice
        x.Show()
    End Sub

    '====================
    ' Delete Invoice
    '====================
    Private Sub MenuItem100_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem100.Click
        Dim x As New InvoiceDelete
        x.Show()
    End Sub

    '====================
    ' Input Miscellaneous Charges
    '====================
    Private Sub MenuItem101_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem101.Click
        Dim x As New InvoiceMiscCharges
        x.Show()
    End Sub

    '====================
    ' Price-Plan Module Setup
    '====================
    Private Sub MenuItem102_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem102.Click
        Dim x As New PricePlanModules
        x.Show()
    End Sub

    '====================
    ' Price-Plan Zone Setup
    '====================
    Private Sub MenuItem103_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem103.Click
        Dim x As New PricePlanZonesSetup
        x.Show()
    End Sub

    '====================
    ' Price-Plan Setup
    '====================
    Private Sub MenuItem104_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem104.Click
        Dim x As New PricePlanSetup
        x.Show()
    End Sub

    '====================
    ' Price-Plan Customer Assignment
    '====================
    Private Sub MenuItem105_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem105.Click
        Dim x As New PricePlanCustomer
        x.Show()
    End Sub

    '====================
    ' Price-Plan Copy
    '====================
    Private Sub MenuItem106_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem106.Click
        Dim x As New CopyPricePlan
        x.Show()
    End Sub
    '====================
    ' Billing Settings
    '====================
    Private Sub MenuItem107_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem107.Click
        Dim x As New BillingSetup
        x.Show()
    End Sub
    '====================
    '   Import ScanList
    '====================
    'Private Sub MenuItem120_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem120.Click

    '    If ValidateAccess(sender, LoginInfo.UserID, LoginInfo.CompanyCode) = False Then
    '        MessageBox.Show("Authorization Failed.", "Validation Error")
    '        Exit Sub
    '    End If

    '    ImportScanList("IMPORTFILE2.CSV") ' FileName
    '    MessageBox.Show("Import Complete", "Import Scan List Status")

    'End Sub

    '====================
    ' Import IPI
    '====================
    Private Sub MenuItem109_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem109.Click
        'Dim x As New EnterTextBox
        'Dim FileName As String

        On Error GoTo ErrTrap

        If ValidateAccess(sender, LoginInfo.UserID, LoginInfo.CompanyCode) = False Then
            'Message modified by Michael Pastor
            MsgBox("Authorization failed.", MsgBoxStyle.Exclamation, "Authorization Failed")
            '- MsgBox("Authorization Failed.")
            Exit Sub
        End If

        ImportIPI("") ' FileName

        Exit Sub
ErrTrap:
        If Err.Number > 0 Then
            'Message modified by Michael Pastor
            MsgBox("Error in btnNewGroup_Click : " & Err.Description, MsgBoxStyle.Critical, "Critical Error")
            '- MsgBox("Error in btnNewGroup_Click : " & Err.Description)
        End If


    End Sub

    '====================
    ' Import EDI
    '====================
    Private Sub MenuItem110_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem110.Click
        'FileOpen(1, "ShipMft.txt", OpenMode.Random, OpenAccess.Read, OpenShare.Default)
        'microsoft.VisualBasic.
        Dim x As New ImportEDI
        x.Show()

    End Sub

    Private Sub MenuItem31_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem31.Click

    End Sub

    '===================
    ' Tracking Menu
    '===================
    Private Sub MenuItem31_Select(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItem31.Select
        'MsgBox("Select")
        ValidateAccess(sender, LoginInfo.UserID, LoginInfo.CompanyCode)
    End Sub

    Private Sub MenuItem31_Popup(ByVal sender As Object, ByVal e As System.EventArgs) Handles MenuItem31.Popup
        'MsgBox("Pop")
    End Sub

    Private Sub MenuItem111_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem111.Click
        Dim x As New InvoiceMiscChargesListing
        x.Show()
    End Sub

    '===================
    ' Employee Year-To-Date Listing
    '===================
    Private Sub MenuItem112_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem112.Click
        Dim x As New EmployeeListingYearToDate
        x.Show()
    End Sub

    '===================
    ' Weight Inputs Table
    '===================
    Private Sub MenuItem114_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem114.Click
        Dim x As New WeightInputsTable
        x.Show()
    End Sub

    '===================
    ' Accounts Listing
    '===================
    Private Sub MenuItem115_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem115.Click
        Dim x As New AccountsListingGeneral
        x.Show()
    End Sub

    Private Sub MenuItem116_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem116.Click
        Dim x As New BillingCycleSetup
        x.Show()
    End Sub

    Private Sub MenuItem117_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem117.Click
        Dim x As New PhoneListing
        x.Show()
    End Sub

    Private Sub MenuItem118_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem118.Click
        Dim x As New DailyEntryUtilites
        x.Show()
    End Sub

    Private Sub MenuItem119_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem119.Click
        Dim x As New frmTimeCardLabel
        'Dim x As New TimeCardLabelsForm
        x.Show()
    End Sub

    Private Sub MenuItem121_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem121.Click

        'Prepare the SqlCommand for the Report
        Dim x As New ExpenseBreakdownForm

        x.Show()

    End Sub

    Private Sub MenuItem122_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem122.Click
        Dim x As New MileageInputGetPayrollEnding
        x.ShowDialog()
    End Sub

    Private Sub MenuItem123_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem123.Click
        'Dim x As New VehicleTypes
        'x.Show()
        Dim x As New CodeLabelForm
        x.SQLSelect = "Select ID, Description from " & HRTblPath & "VehicleTypes ORDER BY Description"
        x.Text = "Vehicle Types"
        x.Tag = "VehicleTypes"
        x.UltraGrid1.Text = "Vehicle Types"
        x.Label1.Text = "Vehicle Type :"
        x.Value.Tag = ".Description"
        'x.CLDB = AppDBName
        x.CLDB = HRDBName
        x.CLDBUser = AppDBUser
        x.CLDBPass = AppDBPass
        x.SortColIdx = 1
        x.p_AppTblPath = HRTblPath
        x.Value.MaxLength = 16
        x.Show()
    End Sub

    Private Sub MenuItem125_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem125.Click
        Dim x As New MileageListing
        x.Show()
    End Sub

    Private Sub MenuItem127_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem127.Click
        Dim x As New PrintContainerLabels
        x.Show()
    End Sub
    Private Sub MenuItem126_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem126.Click
        Dim x As New PrintPouchLabels
        x.Show()
    End Sub

    Private Sub MenuItem66_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem66.Click
        Dim x As New VehicleListing
        x.Show()
    End Sub

    Private Sub MenuItem130_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem130.Click
        Dim x As New RapidOrderHistory
        x.Show()
    End Sub

    Private Sub MenuItem131_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem131.Click
        Dim x As New PrintRoutesSheets
        x.Show()
    End Sub

    Private Sub MenuItem133_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem133.Click
        Dim x As New EmployeeBadgeForm
        x.Show()
    End Sub

    Private Sub MenuItem135_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem135.Click
        Dim x As New SuspiciousScans
        x.Show()
    End Sub

    Private Sub MenuItem136_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem136.Click
        Dim x As New WeightCaptureSummary
        x.Show()
    End Sub

    '====================
    ' Settlement Price Plan Zone Setup
    '====================
    Private Sub MenuItem139_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem139.Click
        Dim x As New smPricePlanZonesSetup
        x.Show()
    End Sub

    '====================
    ' Settlement Settings
    '====================
    Private Sub MenuItem140_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem140.Click
        Dim x As New smBillingSetup
        x.Show()
    End Sub

    '====================
    ' Settlement Price Plan Module Setup
    '====================
    Private Sub MenuItem141_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem141.Click
        Dim x As New smPricePlanModules
        x.Show()
    End Sub

    '====================
    ' Settlement Price Plan Setup
    '====================
    Private Sub MenuItem142_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem142.Click
        Dim x As New smPricePlanSetup
        x.Show()
    End Sub

    '====================
    ' Price-Plan Customer Assignment
    '====================
    Private Sub MenuItem143_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem143.Click
        Dim x As New smPricePlanCustomer
        x.Show()
    End Sub

    Private Sub MenuItem145_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem145.Click
        Dim x As New smBillingInvoiceGen
        x.Show()
    End Sub

    '====================
    ' Delete Settlement Invoice
    '====================
    Private Sub MenuItem146_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem146.Click
        Dim x As New smInvoiceDelete
        x.Show()
    End Sub

    '===================
    ' Settlement Listing
    '===================
    Private Sub MenuItem147_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem147.Click
        Dim x As New smInvoiceListing
        x.Show()
    End Sub

    '=============================
    ' Settlement Cost Distribution
    '=============================
    Private Sub MenuItem148_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem148.Click
        Dim x As New smInvoiceChargeDistribution
        x.Show()
    End Sub

    '=================
    ' Print Settlement Details in Crystal Reports
    '=================
    Private Sub MenuItem149_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem149.Click
        Dim x As New smInvoicePrint
        x.Show()
    End Sub

    '======================
    ' Zips In Zones Listing
    '======================
    Private Sub MenuItem151_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MenuItem151.Click

        Dim x As New ZipsInZones
        x.Show()

    End Sub
End Class
