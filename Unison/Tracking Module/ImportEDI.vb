Imports System.Data
Imports System.Data.SqlClient
'Imports Microsoft.VisualBasic
Imports System.IO

Public Class ImportEDI
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
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents btnImport As System.Windows.Forms.Button
    Friend WithEvents btnStop As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.Label1 = New System.Windows.Forms.Label
        Me.btnImport = New System.Windows.Forms.Button
        Me.btnStop = New System.Windows.Forms.Button
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Location = New System.Drawing.Point(64, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(216, 23)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Label1"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'btnImport
        '
        Me.btnImport.Location = New System.Drawing.Point(40, 88)
        Me.btnImport.Name = "btnImport"
        Me.btnImport.Size = New System.Drawing.Size(104, 23)
        Me.btnImport.TabIndex = 1
        Me.btnImport.Text = "Start"
        '
        'btnStop
        '
        Me.btnStop.Location = New System.Drawing.Point(200, 88)
        Me.btnStop.Name = "btnStop"
        Me.btnStop.Size = New System.Drawing.Size(104, 23)
        Me.btnStop.TabIndex = 2
        Me.btnStop.Text = "Stop"
        '
        'Timer1
        '
        '
        'ImportEDI
        '
        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.ClientSize = New System.Drawing.Size(344, 149)
        Me.Controls.Add(Me.btnStop)
        Me.Controls.Add(Me.btnImport)
        Me.Controls.Add(Me.Label1)
        Me.Name = "ImportEDI"
        Me.Text = "ImportEDI"
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private Sub ImportEDI_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        AddHandler Me.Activated, AddressOf Form_Activated

        If Not Me.Tag Is Nothing Then
            If Me.Tag <> "" Then
                Me.Tag = TRCTblPath & Me.Tag
            End If
        End If

        Me.CenterToScreen()

        Me.KeyPreview = True
        MeText = Me.Text
        Label1.Text = "System is Stopped."

    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        'ImportEDIFile()

        Timer1.Interval = 0.5 * 60 * 1000
        Timer1.Enabled = True
        Timer1.Start()
        Label1.Text = "Checking For EDI Uploads Every " & Timer1.Interval / 1000 & " Sec.s ..."

    End Sub
    Private Sub InitSetArr(ByRef SetArr As Set204)
        Dim i As Int32

        ReDim SetArr.B2(eB2._END - 1)
        For i = 0 To SetArr.B2.Length - 1
            SetArr.B2(i) = ""
        Next

        ReDim SetArr.B2A(eB2A._END - 1)
        For i = 0 To SetArr.B2A.Length - 1
            SetArr.B2A(i) = ""
        Next

        ReDim SetArr.G62(eG62._END - 1)
        For i = 0 To SetArr.G62.Length - 1
            SetArr.G62(i) = ""
        Next

        ReDim SetArr.L11AAO(eL11._END - 1)
        For i = 0 To SetArr.L11AAO.Length - 1
            SetArr.L11AAO(i) = ""
        Next
        ReDim SetArr.L11MA(eL11._END - 1)
        For i = 0 To SetArr.L11MA.Length - 1
            SetArr.L11MA(i) = ""
        Next
        ReDim SetArr.L3(eL3._END - 1)
        For i = 0 To SetArr.L3.Length - 1
            SetArr.L3(i) = ""
        Next

        ReDim SetArr.N1Sh(eN1._END - 1)
        For i = 0 To SetArr.N1Sh.Length - 1
            SetArr.N1Sh(i) = ""
        Next

        ReDim SetArr.N3Sh(eN3._END - 1)
        For i = 0 To SetArr.N3Sh.Length - 1
            SetArr.N3Sh(i) = ""
        Next

        ReDim SetArr.N4Sh(eN4._END - 1)
        For i = 0 To SetArr.N4Sh.Length - 1
            SetArr.N4Sh(i) = ""
        Next

        ReDim SetArr.S5(eS5._END - 1)
        For i = 0 To SetArr.S5.Length - 1
            SetArr.S5(i) = ""
        Next

        ReDim SetArr.SE(eSE._END - 1)
        For i = 0 To SetArr.SE.Length - 1
            SetArr.SE(i) = ""
        Next

        ReDim SetArr.ST(eST._END - 1)
        For i = 0 To SetArr.ST.Length - 1
            SetArr.ST(i) = ""
        Next

    End Sub
    Private Sub InitDLInfo(ByRef DLInfo As DLInfo204)
        Dim i As Int32

        For i = 0 To DLInfo.AT8.Length - 1
            DLInfo.AT8(i) = ""
        Next
        For i = 0 To DLInfo.G61.Length - 1
            DLInfo.G61(i) = ""
        Next
        For i = 0 To DLInfo.L112I.Length - 1
            DLInfo.L112I(i) = ""
        Next
        For i = 0 To DLInfo.L11AC.Length - 1
            DLInfo.L11AC(i) = ""
        Next
        For i = 0 To DLInfo.L11ACI.Length - 1
            DLInfo.L11ACI(i) = ""
        Next
        For i = 0 To DLInfo.L11FR.Length - 1
            DLInfo.L11FR(i) = ""
        Next
        For i = 0 To DLInfo.L11PO.Length - 1
            DLInfo.L11PO(i) = ""
        Next
        For i = 0 To DLInfo.LAD.Length - 1
            DLInfo.LAD(i) = ""
        Next
        For i = 0 To DLInfo.N1DL.Length - 1
            DLInfo.N1DL(i) = ""
        Next
        For i = 0 To DLInfo.N3DL.Length - 1
            DLInfo.N3DL(i) = ""
        Next
        For i = 0 To DLInfo.N4DL.Length - 1
            DLInfo.N4DL(i) = ""
        Next

    End Sub

    Private Sub ImportEDIFile()
        Dim srObj As StreamReader
        Dim strLine, SplitStr(), SplitStrTmp(), Lines(), IPAddr, IPName As String
        Dim ImpData As New I204
        Dim i, j, k, v, SetNo, ParcelQty As Int32
        Dim Element, Segment, SubElem As String
        Dim PrevSeg As String = ""
        Dim TmpStrArr() As String
        Dim FilesArr(), FileName(), ValidFiles() As String

        EDIPath = EDIPath.ToUpper
        If System.IO.Directory.Exists(EDIPath) Then
            Dim sr As StreamReader
            FilesArr = System.IO.Directory.GetFiles(EDIPath)
            j = 0
            For i = 0 To FilesArr.Length - 1
                FilesArr(i) = FilesArr(i).ToUpper
                FileName = FilesArr(i).Split(".")
                If FileName(0) = EDIPath & "\" & "FTPTPCO" Then
                    ReDim Preserve ValidFiles(j)
                    ValidFiles(j) = FilesArr(i)
                    j += 1
                End If
            Next i
        Else
            MsgBox("Path Does not Exist for EDI:" & EDIPath)
            Exit Sub
        End If

        If ValidFiles Is Nothing Then
            Exit Sub
        End If

        Element = "^" : Segment = "~" : SubElem = ">"
        For i = 0 To ValidFiles.Length - 1

            SetNo = 0 : ParcelQty = 0

            srObj = New StreamReader(ValidFiles(i)) ' "204ORGTEST.txt"
            If srObj Is Nothing Then
                GoTo NextI
            End If

            'Read the first line of text.

            strLine = srObj.ReadLine
            If strLine Is Nothing Then GoTo NextI

            While Not strLine Is Nothing
                If strLine Is Nothing Then Exit Sub
                strLine = strLine.ToUpper
                Lines = strLine.Split(Segment)
                For j = 0 To Lines.Length - 1

                    If Lines(j).Trim = "" Then GoTo NextJ

                    SplitStr = Lines(j).Split(Element)
                    If SplitStr(0) = "GS" And Not ImpData.GS(0) Is Nothing Then
                        MsgBox("More than one group in a file.")
                        GoTo Err1
                    End If
                    If SplitStr(0) <> "N3" And SplitStr(0) <> "N4" Then
                        PrevSeg = ""
                    End If
                    'InitSetArr(ImpData.SetArr(0))
                    Select Case SplitStr(0)
                        Case "ISA"
                            ImpData.ISA = Lines(j).Split(Element)
                            If ImpData.ISA(eISA.VerID) <> "00403" Then
                                MsgBox("Invalid version, " & SplitStr(11))
                                Exit Sub
                            End If

                            ReDim Preserve ImpData.ISA(eISA._END - 1)
                            TmpStrArr = ImpData.ISA
                        Case "GS"
                            ImpData.GS = Lines(j).Split(Element)

                            ReDim Preserve ImpData.GS(eGS._END - 1)
                            TmpStrArr = ImpData.GS

                        Case "ST"
                            SetNo += 1
                            ParcelQty = 0

                            ReDim Preserve ImpData.SetArr(SetNo)
                            ImpData.SetArr(SetNo - 1) = New Set204

                            InitSetArr(ImpData.SetArr(SetNo - 1))

                            ImpData.SetArr(SetNo - 1).ST = Lines(j).Split(Element)
                            If ImpData.SetArr(SetNo - 1).ST(eST.SetID) <> "204" Then
                                MsgBox("Invalid File ID: " & ImpData.SetArr(SetNo - 1).ST(eST.SetID))
                                Exit Sub
                            End If

                            ReDim Preserve ImpData.SetArr(SetNo - 1).ST(eST._END - 1)
                            TmpStrArr = ImpData.SetArr(SetNo - 1).ST

                        Case "B2"
                            ImpData.SetArr(SetNo - 1).B2 = Lines(j).Split(Element)

                            ReDim Preserve ImpData.SetArr(SetNo - 1).B2(eB2._END - 1)
                            TmpStrArr = ImpData.SetArr(SetNo - 1).B2

                        Case "B2A"
                            ImpData.SetArr(SetNo - 1).B2A = Lines(j).Split(Element)
                            ReDim Preserve ImpData.SetArr(SetNo - 1).B2A(eB2A._END - 1)
                            TmpStrArr = ImpData.SetArr(SetNo - 1).B2A
                        Case "L11"
                            Select Case SplitStr(eL11.RefQu)
                                Case "MA"
                                    ImpData.SetArr(SetNo - 1).L11MA = Lines(j).Split(Element)
                                    ReDim Preserve ImpData.SetArr(SetNo - 1).L11MA(eL11._END - 1)
                                    TmpStrArr = ImpData.SetArr(SetNo - 1).L11MA
                                Case "AAO"
                                    ImpData.SetArr(SetNo - 1).L11AAO = Lines(j).Split(Element)
                                    ReDim Preserve ImpData.SetArr(SetNo - 1).L11AAO(eL11._END - 1)
                                    TmpStrArr = ImpData.SetArr(SetNo - 1).L11AAO
                                Case "2I"
                                    ImpData.SetArr(SetNo - 1).DLInfo(ParcelQty - 1).L112I = Lines(j).Split(Element)
                                    ReDim Preserve ImpData.SetArr(SetNo - 1).DLInfo(ParcelQty - 1).L112I(eL11._END - 1)
                                    TmpStrArr = ImpData.SetArr(SetNo - 1).DLInfo(ParcelQty - 1).L112I
                                Case "ACI"
                                    ImpData.SetArr(SetNo - 1).DLInfo(ParcelQty - 1).L11ACI = Lines(j).Split(Element)
                                    ReDim Preserve ImpData.SetArr(SetNo - 1).DLInfo(ParcelQty - 1).L11ACI(eL11._END - 1)
                                    TmpStrArr = ImpData.SetArr(SetNo - 1).DLInfo(ParcelQty - 1).L11ACI
                                Case "PO"
                                    ImpData.SetArr(SetNo - 1).DLInfo(ParcelQty - 1).L11PO = Lines(j).Split(Element)
                                    ReDim Preserve ImpData.SetArr(SetNo - 1).DLInfo(ParcelQty - 1).L11PO(eL11._END - 1)
                                    TmpStrArr = ImpData.SetArr(SetNo - 1).DLInfo(ParcelQty - 1).L11PO
                                Case "FR"
                                    ImpData.SetArr(SetNo - 1).DLInfo(ParcelQty - 1).L11FR = Lines(j).Split(Element)
                                    ReDim Preserve ImpData.SetArr(SetNo - 1).DLInfo(ParcelQty - 1).L11FR(eL11._END - 1)
                                    TmpStrArr = ImpData.SetArr(SetNo - 1).DLInfo(ParcelQty - 1).L11FR
                                Case "AC"
                                    ImpData.SetArr(SetNo - 1).DLInfo(ParcelQty - 1).L11AC = Lines(j).Split(Element)
                                    ReDim Preserve ImpData.SetArr(SetNo - 1).DLInfo(ParcelQty - 1).L11AC(eL11._END - 1)
                                    TmpStrArr = ImpData.SetArr(SetNo - 1).DLInfo(ParcelQty - 1).L11AC
                                Case Else
                                    MsgBox("Error in L11: " & SplitStr(eL11.RefQu))
                                    GoTo Err1
                            End Select
                        Case "G62"
                            ImpData.SetArr(SetNo - 1).G62 = Lines(j).Split(Element)
                            ReDim Preserve ImpData.SetArr(SetNo - 1).G62(eG62._END - 1)
                            TmpStrArr = ImpData.SetArr(SetNo - 1).G62
                        Case "N1"
                            Select Case SplitStr(eN1.EntID)
                                Case "SH"
                                    PrevSeg = "SH"
                                    ImpData.SetArr(SetNo - 1).N1Sh = Lines(j).Split(Element)

                                    ReDim Preserve ImpData.SetArr(SetNo - 1).N1Sh(eN1._END - 1)
                                    TmpStrArr = ImpData.SetArr(SetNo - 1).N1Sh
                                Case "CN"
                                    PrevSeg = "CN"
                                    ImpData.SetArr(SetNo - 1).DLInfo(ParcelQty - 1).N1DL = Lines(j).Split(Element)
                                    ReDim Preserve ImpData.SetArr(SetNo - 1).DLInfo(ParcelQty - 1).N1DL(eN1._END - 1)
                                    TmpStrArr = ImpData.SetArr(SetNo - 1).DLInfo(ParcelQty - 1).N1DL
                                Case Else
                                    PrevSeg = "N1"
                                    MsgBox("Error in N1: " & SplitStr(eN1.EntID))
                                    GoTo Err1
                            End Select
                        Case "N3"
                            Select Case PrevSeg 'SplitStr(eN1.EntID)
                                Case "SH"
                                    ImpData.SetArr(SetNo - 1).N3Sh = Lines(j).Split(Element)
                                    ReDim Preserve ImpData.SetArr(SetNo - 1).N3Sh(eN3._END - 1)
                                    TmpStrArr = ImpData.SetArr(SetNo - 1).N3Sh
                                Case "CN"
                                    ImpData.SetArr(SetNo - 1).DLInfo(ParcelQty - 1).N3DL = Lines(j).Split(Element)
                                    ReDim Preserve ImpData.SetArr(SetNo - 1).DLInfo(ParcelQty - 1).N3DL(eN3._END - 1)
                                    TmpStrArr = ImpData.SetArr(SetNo - 1).DLInfo(ParcelQty - 1).N3DL
                                Case Else
                                    MsgBox("Error in N3: " & PrevSeg)
                                    GoTo Err1
                            End Select
                        Case "N4"
                            Select Case PrevSeg 'SplitStr(eN1.EntID)
                                Case "SH"
                                    ImpData.SetArr(SetNo - 1).N4Sh = Lines(j).Split(Element)
                                    ReDim Preserve ImpData.SetArr(SetNo - 1).N4Sh(eN4._END - 1)
                                    TmpStrArr = ImpData.SetArr(SetNo - 1).N4Sh
                                Case "CN"
                                    ImpData.SetArr(SetNo - 1).DLInfo(ParcelQty - 1).N4DL = Lines(j).Split(Element)
                                    ReDim Preserve ImpData.SetArr(SetNo - 1).DLInfo(ParcelQty - 1).N4DL(eN4._END - 1)
                                    TmpStrArr = ImpData.SetArr(SetNo - 1).DLInfo(ParcelQty - 1).N4DL
                                Case Else
                                    MsgBox("Error in N4: " & PrevSeg)
                                    GoTo Err1
                            End Select
                            PrevSeg = ""

                        Case "S5" ' Begin of DL info
                            ParcelQty += 1
                            ReDim Preserve ImpData.SetArr(SetNo - 1).DLInfo(ParcelQty)
                            ImpData.SetArr(SetNo - 1).DLInfo(ParcelQty - 1) = New DLInfo204

                            InitDLInfo(ImpData.SetArr(SetNo - 1).DLInfo(ParcelQty - 1))

                            ImpData.SetArr(SetNo - 1).S5 = Lines(j).Split(Element)
                            ReDim Preserve ImpData.SetArr(SetNo - 1).S5(eS5._END - 1)
                            TmpStrArr = ImpData.SetArr(SetNo - 1).S5
                            'Case "L11"
                        Case "AT8"
                            ImpData.SetArr(SetNo - 1).DLInfo(ParcelQty - 1).AT8 = Lines(j).Split(Element)
                            ReDim Preserve ImpData.SetArr(SetNo - 1).DLInfo(ParcelQty - 1).AT8(eAT8._END - 1)
                            TmpStrArr = ImpData.SetArr(SetNo - 1).DLInfo(ParcelQty - 1).AT8
                        Case "LAD"
                            ImpData.SetArr(SetNo - 1).DLInfo(ParcelQty - 1).LAD = Lines(j).Split(Element)
                            ReDim Preserve ImpData.SetArr(SetNo - 1).DLInfo(ParcelQty - 1).LAD(eLAD._END - 1)
                            TmpStrArr = ImpData.SetArr(SetNo - 1).DLInfo(ParcelQty - 1).LAD
                            'Case "N1"
                            'Case "N3"
                            'Case "N4"
                        Case "G61"
                            ImpData.SetArr(SetNo - 1).DLInfo(ParcelQty - 1).G61 = Lines(j).Split(Element)
                            ReDim Preserve ImpData.SetArr(SetNo - 1).DLInfo(ParcelQty - 1).G61(eG61._END - 1)
                            TmpStrArr = ImpData.SetArr(SetNo - 1).DLInfo(ParcelQty - 1).G61
                        Case "L3"
                            ImpData.SetArr(SetNo - 1).L3 = Lines(j).Split(Element)
                            ReDim Preserve ImpData.SetArr(SetNo - 1).L3(eL3._END - 1)
                            TmpStrArr = ImpData.SetArr(SetNo - 1).L3
                        Case "SE"
                            ImpData.SetArr(SetNo - 1).SE = Lines(j).Split(Element)
                            ReDim Preserve ImpData.SetArr(SetNo - 1).SE(eSE._END - 1)
                            TmpStrArr = ImpData.SetArr(SetNo - 1).SE
                        Case "GE"
                            ImpData.GE = Lines(j).Split(Element)
                            ReDim Preserve ImpData.GE(eGE._END - 1)
                            TmpStrArr = ImpData.GE
                        Case "IEA"
                            ImpData.IEA = Lines(j).Split(Element)
                            ReDim Preserve ImpData.IEA(eIEA._END - 1)
                            TmpStrArr = ImpData.IEA
                    End Select
                    For v = 0 To TmpStrArr.Length - 1
                        If TmpStrArr(v) Is Nothing Then
                            TmpStrArr(v) = ""
                        End If
                    Next v

NextJ:
                Next j
                strLine = srObj.ReadLine
            End While

            If Not srObj Is Nothing Then
                srObj.Close()
                'srObj.DiscardBufferedData()
                srObj = Nothing
            End If
            'Insert into DB
            Dim sqlInsert, FrLocID As String
            Dim l, z, y, FrAddressID, ToAddressID As Int32, row As DataRow
            Dim ACCTINGRAM As String

            For k = 0 To ImpData.SetArr.Length - 1 - 1 ' 2nd -1 is: dim x(1) --> len = 2 so 2-1 = 1 (0, 1) so 1-1 = 0 (only one item) (our parcel qty numbering started with 1

                ACCTINGRAM = ImpData.SetArr(k).N1Sh(eN1.IDCod) 'Carrier Acct# Roseburg = 25140, Ontario = 25141 . "26000" Is for test
                While ReturnRowByID(ImpData.SetArr(k).N1Sh(eN1.IDCod), row, TRCTblPath & "Location", " CustomerID = '" & ACCTINGRAM & "'", "LocationID") = False
                    sqlInsert = "Insert into  " & TRCTblPath & "Location(CustomerID, LocationID, Name, Address1, Address2, City, State, Zip, Contact, Phone, Active, Email, Password) " & _
                                " values ('" & ACCTINGRAM & "', '" & ImpData.SetArr(k).N1Sh(eN1.IDCod).Replace("'", "''") & "', '" & ImpData.SetArr(k).N1Sh(eN1.Name).Replace("'", "''") & "', '" & ImpData.SetArr(k).N3Sh(eN3.Add1) & "', '" & ImpData.SetArr(k).N3Sh(eN3.Add2) & "', '" & ImpData.SetArr(k).N4Sh(eN4.City) & "', '" & ImpData.SetArr(k).N4Sh(eN4.State) & "', '" & ImpData.SetArr(k).N4Sh(eN4.Zip) & "', '" & "', '" & "', 'Y', '', ''" & ") "
                    If ExecuteQuery(sqlInsert) = False Then
                        MsgBox("Error Inserting into Location (FromAddres).")
                        Exit Sub
                    End If
                End While
                FrLocID = row("LocationID")
                FrAddressID = row("AddressID")
                row = Nothing
                For l = 0 To ImpData.SetArr(k).DLInfo.Length - 1 - 1

                    ' Begin Update Location Info

                    'If ReturnRowByID(ImpData.SetArr(k).DLInfo(l).N1DL(eN1.IDCod), row, TRCTblpath & "Location", " CustomerID = '" & ACCTINGRAM & "'", "LocationID") = False Then
                    '    sqlInsert = "Insert into  " & TRCTblpath & "Location(CustomerID, LocationID, Name, Address1, Address2, City, State, Zip, Contact, Phone, Active, Email, Password) " & _
                    '                " values ('" & ACCTINGRAM & "', '" & ImpData.SetArr(k).DLInfo(l).N1DL(eN1.IDCod) & "', '" & ImpData.SetArr(k).DLInfo(l).N1DL(eN1.Name).ToUpper & "', '" & ImpData.SetArr(k).DLInfo(l).N3DL(eN3.Add1).ToUpper & "', '" & ImpData.SetArr(k).DLInfo(l).N3DL(eN3.Add2).ToUpper & "', '" & ImpData.SetArr(k).DLInfo(l).N4DL(eN4.City).ToUpper & "', '" & ImpData.SetArr(k).DLInfo(l).N4DL(eN4.State).ToUpper & "', '" & ImpData.SetArr(k).DLInfo(l).N4DL(eN4.Zip) & "', '" & ImpData.SetArr(k).DLInfo(l).G61(eG61.Name).ToUpper & "', '" & ImpData.SetArr(k).DLInfo(l).G61(eG61.TelNo) & "', 'Y', '', ''" & ") "
                    '    If ExecuteQuery(sqlInsert) = False Then
                    '        MsgBox("Error Inserting into Location (ToAddress).")
                    '        Exit Sub
                    '    End If
                    'Else ' Update Info
                    '    sqlInsert = "Update " & TRCTblpath & "Location Set Name = '" & ImpData.SetArr(k).DLInfo(l).N1DL(eN1.Name).ToUpper & "', Address1 = '" & ImpData.SetArr(k).DLInfo(l).N3DL(eN3.Add1).ToUpper & "', Address2 = '" & ImpData.SetArr(k).DLInfo(l).N3DL(eN3.Add2).ToUpper & "', City = '" & ImpData.SetArr(k).DLInfo(l).N4DL(eN4.City).ToUpper & "', State = '" & ImpData.SetArr(k).DLInfo(l).N4DL(eN4.State).ToUpper & "', Zip = '" & ImpData.SetArr(k).DLInfo(l).N4DL(eN4.Zip) & "', Contact = '" & ImpData.SetArr(k).DLInfo(l).G61(eG61.Name).ToUpper & "', Phone = '" & ImpData.SetArr(k).DLInfo(l).G61(eG61.TelNo) & "' " & _
                    '                " Where CustomerID = '" & ACCTINGRAM & "' AND LocationID = '" & ImpData.SetArr(k).DLInfo(l).N1DL(eN1.IDCod) & "'"
                    '    If ExecuteQuery(sqlInsert) = False Then
                    '        MsgBox("Error Inserting into Location (ToAddress).")
                    '        Exit Sub
                    '    End If
                    'End If
                    'row = Nothing

                    ' END Update Location Info

                    If ReturnRowByID(ImpData.GS(eGS.IDate) & ImpData.SetArr(k).DLInfo(l).L112I(eL11.RefID), row, TRCTblPath & "Manifest", " FromCustID = '" & ACCTINGRAM & "'", "RowID") = True Then
                        If row("FromAddID") = FrAddressID And row("ToLocID") = ImpData.SetArr(k).DLInfo(l).N1DL(eN1.IDCod) Then
                            GoTo NextL
                        End If
                    End If
                    While ReturnRowByID(ImpData.SetArr(k).DLInfo(l).N1DL(eN1.IDCod), row, TRCTblPath & "Location", " CustomerID = '" & ACCTINGRAM & "'", "LocationID") = False
                        sqlInsert = "Insert into  " & TRCTblPath & "Location(CustomerID, LocationID, Name, Address1, Address2, City, State, Zip, Contact, Phone, Active, Email, Password) " & _
                                    " values ('" & ACCTINGRAM & "', '" & ImpData.SetArr(k).DLInfo(l).N1DL(eN1.IDCod) & "', '" & ImpData.SetArr(k).DLInfo(l).N1DL(eN1.Name).Replace("'", "''") & "', '" & ImpData.SetArr(k).DLInfo(l).N3DL(eN3.Add1) & "', '" & ImpData.SetArr(k).DLInfo(l).N3DL(eN3.Add2) & "', '" & ImpData.SetArr(k).DLInfo(l).N4DL(eN4.City) & "', '" & ImpData.SetArr(k).DLInfo(l).N4DL(eN4.State) & "', '" & ImpData.SetArr(k).DLInfo(l).N4DL(eN4.Zip) & "', '" & ImpData.SetArr(k).DLInfo(l).G61(eG61.Name).Replace("'", "''") & "', '" & ImpData.SetArr(k).DLInfo(l).G61(eG61.TelNo) & "', 'Y', '', ''" & ") "
                        If ExecuteQuery(sqlInsert) = False Then
                            MsgBox("Error Inserting into Location (ToAddress).")
                            Exit Sub
                        End If
                    End While
                    ToAddressID = row("AddressID")
                    row = Nothing
                    sqlInsert = "Insert into " & TRCTblPath & "Manifest(TrackingNum, RefNum, FromAddID, FromCustID, FromCustName, FromLocID, FromLocName, FromAdd1, FromAdd2, FromCity, FromState, FromZip, FromContact, FromPhone, FromEmail, ToAddID, ToCustID, ToCustName, ToLocID, ToLocName, ToAdd1, ToAdd2, ToCity, ToState, ToZip, ToContact, ToPhone, ToEmail, Weight, Pieces, SentBy, ParcelType, ServiceLevel, SpecialHandle, BillType, BillNum, DateTime, VOID, RowID) " & _
                                " Values('" & ImpData.SetArr(k).DLInfo(l).L112I(eL11.RefID) & "', 'Mft#=" & ImpData.SetArr(k).B2(eB2.MftNo) & "', '" & FrAddressID & "', '" & ACCTINGRAM & "', '" & ImpData.SetArr(k).N1Sh(eN1.Name).Replace("'", "''") & "', '" & FrLocID & "', '" & ImpData.SetArr(k).N1Sh(eN1.Name).Replace("'", "''") & "', '" & ImpData.SetArr(k).N3Sh(eN3.Add1) & "', '" & ImpData.SetArr(k).N3Sh(eN3.Add2) & "', '" & ImpData.SetArr(k).N4Sh(eN4.City) & "', '" & ImpData.SetArr(k).N4Sh(eN4.State) & "', '" & ImpData.SetArr(k).N4Sh(eN4.Zip) & "', '', '', '', '" & ToAddressID & "', '" & ACCTINGRAM & "', 'INGRAM', '" & ImpData.SetArr(k).DLInfo(l).N1DL(eN1.IDCod) & "', '" & ImpData.SetArr(k).DLInfo(l).N1DL(eN1.Name).Replace("'", "''") & "', '" & ImpData.SetArr(k).DLInfo(l).N3DL(eN3.Add1) & "', '" & ImpData.SetArr(k).DLInfo(l).N3DL(eN3.Add2) & "', '" & ImpData.SetArr(k).DLInfo(l).N4DL(eN4.City) & "', '" & ImpData.SetArr(k).DLInfo(l).N4DL(eN4.State) & "', '" & ImpData.SetArr(k).DLInfo(l).N4DL(eN4.Zip) & "', '" & ImpData.SetArr(k).DLInfo(l).G61(eG61.Name).Replace("'", "''") & "', '" & ImpData.SetArr(k).DLInfo(l).G61(eG61.TelNo) & "', '', '" & ImpData.SetArr(k).DLInfo(l).AT8(eAT8.Wgt) & "', '" & CStr(Val(ImpData.SetArr(k).DLInfo(l).AT8(eAT8.Qty)) / Val(ImpData.SetArr(k).DLInfo(l).AT8(eAT8.Qty))) & "', '', 'BOX', '', 'AAO," & ImpData.SetArr(k).L11AAO(eL11.RefID) & "-" & ImpData.SetArr(k).L11AAO(eL11.Desc) & "', '', '', convert(datetime, '" & ImpData.GS(eGS.IDate) & "', 112), 'F', '" & ImpData.GS(eGS.IDate) & ImpData.SetArr(k).DLInfo(l).L112I(eL11.RefID) & "') "
                    ' TR# is INGRAM's, RefNum = MftNum
                    If ExecuteQuery(sqlInsert) = False Then
                        MsgBox("Error Inserting into Manifest.")
                        Exit Sub
                    End If
                    sqlInsert = "Insert into " & TRCTblPath & "ManifestInvoice(RowID, DateTime, TrackingNum, BillNum, FromAddID, FromCustID, FromLocID, FromZip, ToAddID, ToCustID, ToLocID, ToZip, Weight, ParcelType, Pieces, Ref1, Ref2, Ref3, Ref4, Ref5) " & _
                                " Values('" & ImpData.GS(eGS.IDate) & ImpData.SetArr(k).DLInfo(l).L112I(eL11.RefID) & "', convert(datetime, '" & ImpData.GS(eGS.IDate) & "', 112), '" & ImpData.SetArr(k).DLInfo(l).L112I(eL11.RefID) & "', '', '" & FrAddressID & "', '" & ACCTINGRAM & "', '" & FrLocID & "', '" & ImpData.SetArr(k).N4Sh(eN4.Zip) & "', '" & ToAddressID & "', '" & ACCTINGRAM & "', '" & ImpData.SetArr(k).DLInfo(l).N1DL(eN1.IDCod) & "', '" & ImpData.SetArr(k).DLInfo(l).N4DL(eN4.Zip) & "', '" & ImpData.SetArr(k).DLInfo(l).AT8(eAT8.Wgt) & "', 'BOX', 1, 'LAD," & ImpData.SetArr(k).DLInfo(l).LAD(eLAD.LdVal).Replace("'", "''") & "', 'ACI," & ImpData.SetArr(k).DLInfo(l).L11ACI(eL11.RefID).Replace("'", "''") & "', 'PO," & ImpData.SetArr(k).DLInfo(l).L11PO(eL11.RefID).Replace("'", "''") & "', 'FR," & ImpData.SetArr(k).DLInfo(l).L11FR(eL11.RefID).Replace("'", "''") & "', 'AC," & ImpData.SetArr(k).DLInfo(l).L11AC(eL11.RefID).Replace("'", "''") & "')"
                    If ExecuteQuery(sqlInsert) = False Then
                        MsgBox("Error Inserting into ManifestInvoice.")
                        Exit Sub
                    End If

                    sqlInsert = "Insert into " & TRCTblPath & "Event(EventCode, ScanDate, TrackingNum, ThirdPartyBarcode, ToCity, ParcelType, Weight, Pieces, Void, ToAddID, ToLocID, ToLocName, RefNum, FromAddID, FromCustID, FromCustName, FromLocID, FromLocName) " & _
                                " Values('L', convert(datetime, '" & ImpData.GS(eGS.IDate) & "', 112), '', '" & ImpData.SetArr(k).DLInfo(l).L112I(eL11.RefID) & "', '" & ImpData.SetArr(k).DLInfo(l).N4DL(eN4.City) & "', 'BOX', '" & ImpData.SetArr(k).DLInfo(l).AT8(eAT8.Wgt) & "', '1/1', 'F', '" & ToAddressID & "', '" & ImpData.SetArr(k).DLInfo(l).N1DL(eN1.IDCod) & "', '" & ImpData.SetArr(k).DLInfo(l).N1DL(eN1.Name).Replace("'", "''") & "', 'Mft#=" & ImpData.SetArr(k).B2(eB2.MftNo) & "', '" & FrAddressID & "', '" & ACCTINGRAM & "', '" & ImpData.SetArr(k).N1Sh(eN1.Name).Replace("'", "''") & "', '" & FrLocID & "', '" & ImpData.SetArr(k).N1Sh(eN1.Name).Replace("'", "''") & "')"
                    If ExecuteQuery(sqlInsert) = False Then
                        MsgBox("Error Inserting into Event. TR#: '" & ImpData.SetArr(k).DLInfo(l).L112I(eL11.RefID) & "'")
                        Exit Sub
                    End If
NextL:
                Next l
                'MsgBox("Set #" & k & ", " & l & " parcels added to the system...")
            Next k
            'srObj.DiscardBufferedData()
            'srObj = Nothing
NextI:
            If Not srObj Is Nothing Then
                srObj.Close()
                'srObj.DiscardBufferedData()
                srObj = Nothing
            End If
            Dim tmpstr() As String
            tmpstr = ValidFiles(i).Split(".")
            tmpstr(0) = tmpstr(0) & "_ARC"
            File.Move(ValidFiles(i), tmpstr(0) & "." & tmpstr(1))
            tmpstr = Nothing

        Next i ' File Counter


Err1:
        If Not srObj Is Nothing Then
            srObj.Close()
            'srObj.DiscardBufferedData()
            srObj = Nothing
        End If

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        ImportEDIFile()
    End Sub

    Private Sub btnStop_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStop.Click
        Timer1.Stop()
        Label1.Text = "System is Stopped."

    End Sub

    Private Sub ImportEDI_Closing(ByVal sender As Object, ByVal e As System.ComponentModel.CancelEventArgs) Handles MyBase.Closing
        Timer1.Stop()
    End Sub
End Class
