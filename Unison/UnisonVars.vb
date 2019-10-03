Imports System.Data
Imports System.Data.SqlClient

Module UnisonVars
    Public ROUTES_MOD As Boolean = True
    Public HOLIDAYS_MOD As Boolean = True
    Public HR_MOD As Boolean = True
    Public TRACKING_MOD As Boolean = True
    Public TRUCKS_MOD As Boolean = True
    Public WEIGHT_MOD As Boolean = True


    Public AppDBName As String = "UNISON" ' "UNISON" '
    Public AppDBUser As String = "Unison" '"Routes"
    Public AppDBPass As String = "unison" '"routes"
    Public AppTblPath As String 'SAM-MULTIPLE = AppDBName & ".dbo."
    Public RapidTblPath As String = "RTMGMT.dbo."

    Public TRACKING_MODULE As Boolean = True
    Public HOLIDAYS_MODULE As Boolean = True
    Public WEIGHT_MODULE As Boolean = True
    Public ROUTES_MODULE As Boolean = True
    Public TRUCKS_MODULE As Boolean = True
    Public BILLING_MODULE As Boolean = True

    Public Enum enGroups
        Wgt
        Trk
    End Enum
    Public ModuleGroup() As String = {"W", "Z"}
    Public Enum enGrpMemType
        Acct
    End Enum
    Public GrpMemType() As String = {"A"}


    '=================================================
    '=================   Security  ===================
    '=================================================
    Public CFGDBName As String = "UN_CFG" ' "UNISON" '
    Public CFGDBUser As String = "UNCNF" '"Routes"
    Public CFGDBPass As String = "unesco" '"routes"
    'Public CFGDBName As String = "UN_CFG" ' "UNISON" '
    'Public CFGDBUser As String = "sa" '"Routes"
    'Public CFGDBPass As String = "Sammy@qv" '"routes"
    Public CFGTblPath As String = CFGDBName & ".dbo."

    Class clsLoginInfo
        Public UserID As String
        Public Password As String
        Public UserName As String
        Public EmployeeID As String
        Public WorkCompanyCode As String
        Public CompanyCode As String
        Public CompanyName As String
        Public DBPrefix As String
    End Class

    Public LoginInfo As New clsLoginInfo

    Public Function ValidateAccess(ByVal Obj As Object, ByVal UserID As String, ByVal CompanyCode As String) As Boolean
        Dim Mnu As Menu
        Dim MnuItm As MenuItem
        Dim Frm As Form
        Dim i As Int32
        Dim da As New SqlDataAdapter
        Dim ds As DataSet
        'Dim sqlSelect As String = "Select * from " & CFGTblPath & "UN_Rights where Company_Code = '" & CompanyCode & "' And UserID = '" & UserID & "'"
        Dim sqlSelect As String = _
        "SELECT Obj_Name, SUM([View]) AS [VIEW], SUM(Edit) AS Edit, SUM([Delete]) AS [DELETE], SUM([Print]) AS [PRINT] " & _
        "FROM (SELECT * FROM " & CFGTblPath & "UN_Rights WHERE Company_Code = '" & CompanyCode & "' And UserID = '" & UserID & "' " & _
        "      UNION " & _
        "      SELECT * FROM " & CFGTblPath & "UN_Rights WHERE Company_Code = '" & CompanyCode & "' And userid IN  (SELECT Group_Code FROM " & CFGTblPath & "UN_UserMemberships WHERE UserID = '" & UserID & "')) u " & _
        "GROUP BY Obj_Name " & _
        "ORDER BY Obj_Name "

        Dim dv As DataView
        Dim Ctrls() As Control

        Dim connstr, connstrBAK As String

        ValidateAccess = False

        connstr = strConnection2.Replace("@DB", CFGDBName)
        connstr = connstr.Replace("@USER", CFGDBUser)
        connstr = connstr.Replace("@PASS", CFGDBPass)

        'Dim localConn As New SqlConnection(connstr)
        'DataAdapter.SelectCommand = New SqlCommand
        '''dsRapid.ReadXmlSchema("RapidDataSet.xsd")
        ''dsRapid.DataSetName = "RapidDataSet2"
        connstrBAK = strConnection
        strConnection = connstr
        sqlConn.ConnectionString = connstr 'strConnection

        PopulateDataset2(da, ds, sqlSelect)
        dv = ds.Tables(0).DefaultView

        strConnection = connstrBAK
        sqlConn.ConnectionString = strConnection


        Select Case Obj.GetType.ToString
            Case "System.Windows.Forms.MainMenu"
                Mnu = Obj
                For i = 0 To Mnu.MenuItems.Count - 1
                    dv.RowFilter = " Obj_Name = '" & Mnu.MenuItems(i).Text & "'"
                    If dv.Count > 0 Then
                        If dv(0).Item("View") = 0 Then
                            Mnu.MenuItems(i).Enabled = False
                        Else
                            Mnu.MenuItems(i).Enabled = True
                        End If
                    Else
                        Mnu.MenuItems(i).Enabled = False
                    End If
                Next
            Case "System.Windows.Forms.MenuItem"
                MnuItm = Obj
                dv.RowFilter = " Obj_Name = '" & MnuItm.Text & "'"

                If dv.Count > 0 Then
                    If dv(0).Item("View") >= 1 Then
                        ValidateAccess = True
                        If MnuItm.IsParent = True Then
                            For i = 0 To MnuItm.MenuItems.Count - 1
                                dv.RowFilter = " Obj_Name = '" & MnuItm.MenuItems(i).Text & "'"
                                If dv.Count > 0 Then
                                    If dv(0).Item("View") = 0 Then
                                        MnuItm.MenuItems(i).Enabled = False
                                    Else
                                        MnuItm.MenuItems(i).Enabled = True
                                    End If
                                Else
                                    MnuItm.MenuItems(i).Enabled = False
                                End If
                            Next
                        End If ' IsParent
                    End If ' Viewable
                End If ' There is a row
                Exit Select
            Case "System.Windows.Forms.Form"
            Case Else
                Frm = Obj
                dv.RowFilter = " Obj_Name = '" & Frm.Name & "'"
                If dv.Count > 0 Then
                    If dv(0).Item("View") >= 1 Then
                        ValidateAccess = True
                        If dv(0).Item("Edit") = 0 Then
                            Ctrls = ReturnCtrlByName(Frm, "System.Windows.Forms.Button", "EDIT")
                            If Not Ctrls Is Nothing Then
                                For i = 0 To Ctrls.Length - 1
                                    Ctrls(i).Enabled = False
                                Next
                                Ctrls.Clear(Ctrls, 0, Ctrls.Length)
                            End If
                            Ctrls = Nothing

                            Ctrls = ReturnCtrlByName(Frm, "System.Windows.Forms.Button", "NEW")
                            If Not Ctrls Is Nothing Then
                                For i = 0 To Ctrls.Length - 1
                                    Ctrls(i).Enabled = False
                                Next
                                Ctrls.Clear(Ctrls, 0, Ctrls.Length)
                            End If
                            Ctrls = Nothing
                        End If

                        If dv(0).Item("Delete") = 0 Then
                            Ctrls = ReturnCtrlByName(Frm, "System.Windows.Forms.Button", "DELETE")
                            If Not Ctrls Is Nothing Then
                                For i = 0 To Ctrls.Length - 1
                                    Ctrls(i).Enabled = False
                                Next
                                Ctrls.Clear(Ctrls, 0, Ctrls.Length)
                            End If
                            Ctrls = Nothing
                        End If

                        If dv(0).Item("Print") = 0 Then
                            Ctrls = ReturnCtrlByName(Frm, "System.Windows.Forms.Button", "PRINT")
                            If Not Ctrls Is Nothing Then
                                For i = 0 To Ctrls.Length - 1
                                    Ctrls(i).Enabled = False
                                Next
                                Ctrls.Clear(Ctrls, 0, Ctrls.Length)
                            End If
                            Ctrls = Nothing

                            Ctrls = ReturnCtrlByName(Frm, "System.Windows.Forms.Button", "PREVIEW")
                            If Not Ctrls Is Nothing Then
                                For i = 0 To Ctrls.Length - 1
                                    Ctrls(i).Enabled = False
                                Next
                                Ctrls.Clear(Ctrls, 0, Ctrls.Length)
                            End If
                            Ctrls = Nothing

                            Ctrls = ReturnCtrlByName(Frm, "System.Windows.Forms.Button", "EXPORT")
                            If Not Ctrls Is Nothing Then
                                For i = 0 To Ctrls.Length - 1
                                    Ctrls(i).Enabled = False
                                Next
                                Ctrls.Clear(Ctrls, 0, Ctrls.Length)
                            End If
                            Ctrls = Nothing
                        End If
                    End If
                End If
                Exit Select
        End Select

        ds.Dispose()
        ds = Nothing
        da.Dispose()
        da = Nothing

    End Function

    Public Sub Form_Activated(ByVal sender As Object, ByVal e As System.EventArgs)
        If ValidateAccess(sender, LoginInfo.UserID, LoginInfo.CompanyCode) = False Then
            'Message modified by Michael Pastor
            MsgBox("Authorization denied.", MsgBoxStyle.Exclamation, "Authorization Denied")
            '- MsgBox("Authorization Denied.")
            sender.Close()
        End If
    End Sub

    Public Function ReturnCtrlByName(ByVal Container As Object, ByVal CtrlType As String, ByVal CtrlName As String) As Control()
        ReturnCtrlByName = Nothing

        Dim ctrl, ctrltmp, ctrlarr1(), ctrlarr2() As Control
        Dim i, cnt As Int32

        If Container Is Nothing Then
            'Message modified by Michael Pastor
            MsgBox("Container remains unspecified.", MsgBoxStyle.Exclamation, "Missing Data Input")
            '- MsgBox("Container is NULL.")
            Exit Function
        End If

        If CtrlType = "" Then
            'Message modified by Michael Pastor
            MsgBox("Control Type remains unspecified.", MsgBoxStyle.Exclamation, "Missing Data Input")
            '- MsgBox("ControlType is empty.")
            Exit Function
        End If

        CtrlName = CtrlName.Trim.ToUpper
        If CtrlName = "" Then
            'Message modified by Michael Pastor
            MsgBox("Control Name remains unspecified.", MsgBoxStyle.Exclamation, "Missing Data Input")
            '- MsgBox("ControlName is empty.")
            Exit Function
        End If

        For Each ctrl In Container.controls
            Select Case ctrl.GetType.ToString
                Case CtrlType
                    If ctrl.Name.Replace("&", "").ToUpper.IndexOf(CtrlName) > 0 Then
                        ReDim Preserve ctrlarr1(cnt)
                        ctrlarr1(cnt) = ctrl
                        cnt += 1
                        'Exit Function
                    End If
                Case "System.Windows.Forms.GroupBox", "System.Windows.Forms.Panel"
                    ctrlarr2 = ReturnCtrlByName(ctrl, CtrlType, CtrlName)
                    If Not ctrlarr2 Is Nothing Then
                        ReDim Preserve ctrlarr1(cnt + ctrlarr2.Length - 1)
                        For i = 0 To ctrlarr2.Length - 1
                            ctrlarr1(cnt) = ctrlarr2(i)
                            cnt += 1
                        Next
                        'Exit Function
                    End If
            End Select
        Next
        ReturnCtrlByName = ctrlarr1
    End Function

    Public Function FetchTimeCardEmployees(ByRef dtSet As System.Data.DataSet, Optional ByVal Division As String = "", Optional ByVal OfficeID As Int32 = 0, Optional ByVal Condition As String = "") As Boolean
        Dim da As SqlDataAdapter
        Dim localConn As New SqlConnection(strConnection)
        Dim sqlEmplList As String '= "Select e.ID as EmployeeID, rtrim(e.LastName)+', '+rtrim(e.FirstName) as Employee,e.OfficeID, isnull(so.Name, 'N/A') as Office,  e.Company as Division, e.Status  From " & HRTblPath & "Employees e left outer join " & HRTblPath & "ServiceOffices so on e.OfficeId = so.ID where e.STATUS = 'A' AND e.OfficeID in (Select OfficeID from UN_HRTimeCardOfficeRights where UserID = '" & LoginInfo.UserID & "' AND Company_Code = '" & LoginInfo.CompanyCode & "' AND Division = '" & Division & "' ) AND Company = '" & Division & "' ORDER BY e.ID "
        'Dim sqlEmplTmpList As String = "Select e.ID as EmployeeID, rtrim(e.LastName)+', '+rtrim(e.FirstName) as Employee,e.OfficeID, isnull(so.Name, 'N/A') as Office,  e.Company as Division, e.Status  From " & HRTblPath & "Employees e left outer join " & HRTblPath & "ServiceOffices so on e.OfficeId = so.ID where e.STATUS = 'A' AND e.OfficeID in (Select OfficeID from UN_HRTimeCardOfficeRights where UserID = '" & LoginInfo.UserID & "' AND Company_Code = '" & LoginInfo.CompanyCode & "' @@OFFICEID ) @@DIV  ORDER BY e.ID "
        Dim sqlEmplTmpList As String = "Select e.ID as EmployeeID, rtrim(e.LastName)+', '+rtrim(e.FirstName) as Employee,e.OfficeID, isnull(so.Name, 'N/A') as Office,  e.Company as Division, e.Status  From " & HRTblPath & "Employees e left outer join " & HRTblPath & "ServiceOffices so on e.OfficeId = so.ID where e.STATUS = 'A' AND e.OfficeID in (Select OfficeID from UN_HRTimeCardOfficeRights where TimeCardInput = 1 AND UserID IN (Select Group_Code as UserID from UN_UserMemberships where userid = '" & LoginInfo.UserID & "' UNION Select '" & LoginInfo.UserID & "' as UserID) AND Company_Code = '" & LoginInfo.CompanyCode & "' @@OFFICEID ) @@DIV  ORDER BY e.ID "
        Dim sqlSelect As String
        Dim connstr, connstrBAK As String

        On Error GoTo ErrTrap

        FetchTimeCardEmployees = False

        'If strSQL.Trim = "" Then Exit Function

        If dtSet Is Nothing Then
            dtSet = New DataSet
        Else
            If dtSet.Tables.Count > 0 Then
                'MsgBox("The provided Dataset is already having information in it.")
                dtSet.Tables.Clear()
                dtSet.Dispose()
                dtSet = Nothing
                dtSet = New DataSet
            End If
        End If

        connstr = strConnection2.Replace("@DB", CFGDBName)
        connstr = connstr.Replace("@USER", CFGDBUser)
        connstr = connstr.Replace("@PASS", CFGDBPass)

        'Dim localConn As New SqlConnection(connstr)
        'DataAdapter.SelectCommand = New SqlCommand
        '''dsRapid.ReadXmlSchema("RapidDataSet.xsd")
        ''dsRapid.DataSetName = "RapidDataSet2"
        connstrBAK = strConnection
        strConnection = connstr
        sqlConn.ConnectionString = connstr 'strConnection

        da = New SqlDataAdapter
        sqlEmplList = sqlEmplTmpList.Replace("@@DIV", IIf(Division <> "", " AND Company = '" & Division & "'", ""))
        sqlEmplList = sqlEmplList.Replace("@@OFFICEID", IIf(officeid <> 0, " AND OfficeID = " & officeid & "", ""))
        sqlSelect = PrepSelectQuery(sqlEmplList, Condition)
        If PopulateDataset2(da, dtSet, sqlSelect) Is Nothing Then GoTo ErrTrap

        FetchTimeCardEmployees = True

ErrTrap:
        strConnection = connstrBAK
        sqlConn.ConnectionString = strConnection

        da.Dispose()
        da = Nothing

    End Function

    Public Function FetchAllTimeCardEmployees(ByRef dtSet As System.Data.DataSet, Optional ByVal Division As String = "", Optional ByVal OfficeID As Int32 = 0, Optional ByVal Condition As String = "") As Boolean
        Dim da As SqlDataAdapter
        Dim localConn As New SqlConnection(strConnection)
        Dim sqlEmplList As String '= "Select e.ID as EmployeeID, rtrim(e.LastName)+', '+rtrim(e.FirstName) as Employee,e.OfficeID, isnull(so.Name, 'N/A') as Office,  e.Company as Division, e.Status  From " & HRTblPath & "Employees e left outer join " & HRTblPath & "ServiceOffices so on e.OfficeId = so.ID where e.STATUS = 'A' AND e.OfficeID in (Select OfficeID from UN_HRTimeCardOfficeRights where UserID = '" & LoginInfo.UserID & "' AND Company_Code = '" & LoginInfo.CompanyCode & "' AND Division = '" & Division & "' ) AND Company = '" & Division & "' ORDER BY e.ID "
        'Dim sqlEmplTmpList As String = "Select e.ID as EmployeeID, rtrim(e.LastName)+', '+rtrim(e.FirstName) as Employee,e.OfficeID, isnull(so.Name, 'N/A') as Office,  e.Company as Division, e.Status  From " & HRTblPath & "Employees e left outer join " & HRTblPath & "ServiceOffices so on e.OfficeId = so.ID where e.STATUS = 'A' AND e.OfficeID in (Select OfficeID from UN_HRTimeCardOfficeRights where UserID = '" & LoginInfo.UserID & "' AND Company_Code = '" & LoginInfo.CompanyCode & "' @@OFFICEID ) @@DIV  ORDER BY e.ID "
        Dim sqlEmplTmpList As String = "Select e.ID as EmployeeID, rtrim(e.LastName)+', '+rtrim(e.FirstName) as Employee,e.OfficeID, isnull(so.Name, 'N/A') as Office,  e.Company as Division, e.Status  From " & HRTblPath & "Employees e left outer join " & HRTblPath & "ServiceOffices so on e.OfficeId = so.ID where e.OfficeID in (Select OfficeID from UN_HRTimeCardOfficeRights where TimeCardInput = 1 AND UserID IN (Select Group_Code as UserID from UN_UserMemberships where userid = '" & LoginInfo.UserID & "' UNION Select '" & LoginInfo.UserID & "' as UserID) AND Company_Code = '" & LoginInfo.CompanyCode & "' @@OFFICEID ) @@DIV  ORDER BY e.ID "
        Dim sqlSelect As String
        Dim connstr, connstrBAK As String

        On Error GoTo ErrTrap

        FetchAllTimeCardEmployees = False

        'If strSQL.Trim = "" Then Exit Function

        If dtSet Is Nothing Then
            dtSet = New DataSet
        Else
            If dtSet.Tables.Count > 0 Then
                'MsgBox("The provided Dataset is already having information in it.")
                dtSet.Tables.Clear()
                dtSet.Dispose()
                dtSet = Nothing
                dtSet = New DataSet
            End If
        End If

        connstr = strConnection2.Replace("@DB", CFGDBName)
        connstr = connstr.Replace("@USER", CFGDBUser)
        connstr = connstr.Replace("@PASS", CFGDBPass)

        'Dim localConn As New SqlConnection(connstr)
        'DataAdapter.SelectCommand = New SqlCommand
        '''dsRapid.ReadXmlSchema("RapidDataSet.xsd")
        ''dsRapid.DataSetName = "RapidDataSet2"
        connstrBAK = strConnection
        strConnection = connstr
        sqlConn.ConnectionString = connstr 'strConnection

        da = New SqlDataAdapter
        sqlEmplList = sqlEmplTmpList.Replace("@@DIV", IIf(Division <> "", " AND Company = '" & Division & "'", ""))
        sqlEmplList = sqlEmplList.Replace("@@OFFICEID", IIf(OfficeID <> 0, " AND OfficeID = " & OfficeID & "", ""))
        sqlSelect = PrepSelectQuery(sqlEmplList, Condition)
        If PopulateDataset2(da, dtSet, sqlSelect) Is Nothing Then GoTo ErrTrap

        FetchAllTimeCardEmployees = True

ErrTrap:
        strConnection = connstrBAK
        sqlConn.ConnectionString = strConnection

        da.Dispose()
        da = Nothing

    End Function


    Public Function FetchEmployeeActivityDetails(ByRef dtSet As System.Data.DataSet, ByVal Condition As String) As Boolean
        Dim da As SqlDataAdapter
        Dim localConn As New SqlConnection(strConnection)
        Dim sqlEmplList As String '= "Select e.ID as EmployeeID, rtrim(e.LastName)+', '+rtrim(e.FirstName) as Employee,e.OfficeID, isnull(so.Name, 'N/A') as Office,  e.Company as Division, e.Status  From " & HRTblPath & "Employees e left outer join " & HRTblPath & "ServiceOffices so on e.OfficeId = so.ID where e.STATUS = 'A' AND e.OfficeID in (Select OfficeID from UN_HRTimeCardOfficeRights where UserID = '" & LoginInfo.UserID & "' AND Company_Code = '" & LoginInfo.CompanyCode & "' AND Division = '" & Division & "' ) AND Company = '" & Division & "' ORDER BY e.ID "
        '"SELECT     ead.RowID, ead.EmployeeID, e.FirstName, e.LastName, ead.Division, ead.OfficeID, ead.Office, ead.CheckInDate, ead.TimeIn, ead.CheckOutDate, " & _
        '                      " ead.TimeOut, ead.BreakTime, ead.DeptNo, ead.PayRate, ead.TotalHrs, ead.RegHrs, ead.OTHrs, ead.DTHrs, ead.WeekEnding, " & _
        '                      " ead.PayrollEnding, ead.LastUpdate, ead.Processed, ead.UserID AS OperatorID " & _
        '" FROM " & HRTblPath & "EMPLOYEEACTIVITYDETAIL AS ead INNER JOIN " & _
        '                      CFGTblPath & "UN_HRTimeCardOfficeRights AS tcr ON ead.OfficeID = tcr.OfficeID " & _
        '" LEFT OUTER JOIN " & HRTblPath & "Employees e on ead.EmployeeID = e.ID " & _
        '" WHERE     (tcr.UserID = '" & LoginInfo.UserID & "' AND tcr.Company_Code = '" & LoginInfo.CompanyCode & "') " 'AND (tcr.OfficeID LIKE '%') AND (ead.Division LIKE '%') AND (ead.EmployeeID like '%') 
        Dim sqlEmplTmpList As String = _
"SELECT DISTINCT  ead.RowID, ead.EmployeeID, e.FirstName, e.LastName, ead.Division, ead.OfficeID, ead.Office, ead.CheckInDate, ead.TimeIn, ead.CheckOutDate, " & _
                      " ead.TimeOut, ead.BreakTime, ead.DeptNo, ead.PayRate, ead.TotalHrs, ead.RegHrs, ead.OTHrs, ead.DTHrs, ead.WeekEnding, " & _
                      " ead.PayrollEnding, ead.LastUpdate, ead.Processed, ead.UserID AS OperatorID " & _
" FROM " & HRTblPath & "EMPLOYEEACTIVITYDETAIL AS ead INNER JOIN " & _
                      CFGTblPath & "UN_HRTimeCardOfficeRights AS tcr ON ead.OfficeID = tcr.OfficeID " & _
" LEFT OUTER JOIN " & HRTblPath & "Employees e on ead.EmployeeID = e.ID " & _
" WHERE     (tcr.TimeCardInput = 1 AND tcr.UserID IN (Select Group_Code as UserID from " & CFGTblPath & "UN_UserMemberships where userid = '" & LoginInfo.UserID & "' UNION Select '" & LoginInfo.UserID & "' as UserID) AND tcr.Company_Code = '" & LoginInfo.CompanyCode & "') "


        Dim sqlSelect As String
        Dim connstr, connstrBAK As String

        On Error GoTo ErrTrap

        FetchEmployeeActivityDetails = False

        'If strSQL.Trim = "" Then Exit Function

        If dtSet Is Nothing Then
            dtSet = New DataSet
        Else
            If dtSet.Tables.Count > 0 Then
                'MsgBox("The provided Dataset is already having information in it.")
                dtSet.Tables.Clear()
                dtSet.Dispose()
                dtSet = Nothing
                dtSet = New DataSet
            End If
        End If

        connstr = strConnection2.Replace("@DB", CFGDBName)
        connstr = connstr.Replace("@USER", CFGDBUser)
        connstr = connstr.Replace("@PASS", CFGDBPass)

        'Dim localConn As New SqlConnection(connstr)
        'DataAdapter.SelectCommand = New SqlCommand
        '''dsRapid.ReadXmlSchema("RapidDataSet.xsd")
        ''dsRapid.DataSetName = "RapidDataSet2"
        connstrBAK = strConnection
        strConnection = connstr
        sqlConn.ConnectionString = connstr 'strConnection

        da = New SqlDataAdapter
        sqlSelect = PrepSelectQuery(sqlEmplTmpList, Condition)
        If PopulateDataset2(da, dtSet, sqlSelect) Is Nothing Then GoTo ErrTrap

        FetchEmployeeActivityDetails = True

ErrTrap:
        strConnection = connstrBAK
        sqlConn.ConnectionString = strConnection

        da.Dispose()
        da = Nothing

    End Function


    Public Function FetchMileageInput(ByRef dtSet As System.Data.DataSet, ByVal Condition As String) As Boolean
        Dim da As SqlDataAdapter
        Dim localConn As New SqlConnection(strConnection)
        Dim sqlEmplList As String '= "Select e.ID as EmployeeID, rtrim(e.LastName)+', '+rtrim(e.FirstName) as Employee,e.OfficeID, isnull(so.Name, 'N/A') as Office,  e.Company as Division, e.Status  From " & HRTblPath & "Employees e left outer join " & HRTblPath & "ServiceOffices so on e.OfficeId = so.ID where e.STATUS = 'A' AND e.OfficeID in (Select OfficeID from UN_HRTimeCardOfficeRights where UserID = '" & LoginInfo.UserID & "' AND Company_Code = '" & LoginInfo.CompanyCode & "' AND Division = '" & Division & "' ) AND Company = '" & Division & "' ORDER BY e.ID "
        '"SELECT     ead.RowID, ead.EmployeeID, e.FirstName, e.LastName, ead.Division, ead.OfficeID, ead.Office, ead.CheckInDate, ead.TimeIn, ead.CheckOutDate, " & _
        '                      " ead.TimeOut, ead.BreakTime, ead.DeptNo, ead.PayRate, ead.TotalHrs, ead.RegHrs, ead.OTHrs, ead.DTHrs, ead.WeekEnding, " & _
        '                      " ead.PayrollEnding, ead.LastUpdate, ead.Processed, ead.UserID AS OperatorID " & _
        '" FROM " & HRTblPath & "EMPLOYEEACTIVITYDETAIL AS ead INNER JOIN " & _
        '                      CFGTblPath & "UN_HRTimeCardOfficeRights AS tcr ON ead.OfficeID = tcr.OfficeID " & _
        '" LEFT OUTER JOIN " & HRTblPath & "Employees e on ead.EmployeeID = e.ID " & _
        '" WHERE     (tcr.UserID = '" & LoginInfo.UserID & "' AND tcr.Company_Code = '" & LoginInfo.CompanyCode & "') " 'AND (tcr.OfficeID LIKE '%') AND (ead.Division LIKE '%') AND (ead.EmployeeID like '%') 
        Dim sqlMileageTmpList As String = _
"SELECT DISTINCT  ead.RowID, ead.EmployeeID, e.FirstName, e.LastName, ead.Division, ead.OfficeID, ead.Office, ead.VehicleLicPlate, " & _
                      " ead.Route, ead.CheckInDate, ead.MileageIn, ead.MileageOut, ead.WeekEnding, ead.PayrollEnding, ead.LastUpdate, ead.Processed, " & _
                      " ead.TotalMileage, ead.UserID AS OperatorID " & _
" FROM " & HRTblPath & "MileageInput AS ead LEFT OUTER JOIN " & HRTblPath & "Employees e on ead.EmployeeID = e.ID"

        Dim sqlSelect As String
        Dim connstr, connstrBAK As String

        On Error GoTo ErrTrap

        FetchMileageInput = False

        'If strSQL.Trim = "" Then Exit Function

        If dtSet Is Nothing Then
            dtSet = New DataSet
        Else
            If dtSet.Tables.Count > 0 Then
                'MsgBox("The provided Dataset is already having information in it.")
                dtSet.Tables.Clear()
                dtSet.Dispose()
                dtSet = Nothing
                dtSet = New DataSet
            End If
        End If

        connstr = strConnection2.Replace("@DB", CFGDBName)
        connstr = connstr.Replace("@USER", CFGDBUser)
        connstr = connstr.Replace("@PASS", CFGDBPass)

        'Dim localConn As New SqlConnection(connstr)
        'DataAdapter.SelectCommand = New SqlCommand
        '''dsRapid.ReadXmlSchema("RapidDataSet.xsd")
        ''dsRapid.DataSetName = "RapidDataSet2"
        connstrBAK = strConnection
        strConnection = connstr
        sqlConn.ConnectionString = connstr 'strConnection

        da = New SqlDataAdapter
        sqlSelect = PrepSelectQuery(sqlMileageTmpList, Condition)
        If PopulateDataset2(da, dtSet, sqlSelect) Is Nothing Then GoTo ErrTrap

        FetchMileageInput = True

ErrTrap:
        strConnection = connstrBAK
        sqlConn.ConnectionString = strConnection

        da.Dispose()
        da = Nothing

    End Function
End Module
