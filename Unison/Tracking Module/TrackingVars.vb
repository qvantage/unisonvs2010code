Imports System.IO
Imports System.Text
Imports System.Data.SqlClient
Imports TTSI.BARCODES
Imports TTSI.UTILITES

Module Module1
    Public TRCDBName As String '= "UN_TRACKING"
    Public TRCDBUser As String = "Unison" '"tpctrk"
    Public TRCDBPass As String = "unison" '"top"
    Public TRCTblPath As String '= TRCDBName & ".dbo."

    '====================   Import Structures   =========================

    '-------------------- IPI Files
    Enum eIPIImp
        _01TRNUM = 0
        _02PKGID
        _03DATE
        _04CUSTID
        _05LOCID
        _06LOC
        _07Add1
        _08Add2
        _09CITY
        _10STATE
        _11ZIP
        _12PHONE
        _13WGT
        _END
    End Enum


    '===================   Import Functions    =============================
    Private Function DailyEntryExists(ByVal p_sShortDate As String, ByVal p_iWeightPlanID As Integer) As Boolean

        Try
            ' Data Access Variables
            Dim oDataAdapter As SqlDataAdapter
            Dim oDataSet As DataSet
            Dim oDailyEntry As DataRow
            Dim iRowCount As Integer

            ' Utility Variables
            Dim sb As New StringBuilder
            Dim sCmd As String

            ' Check to see if there is already a row for this record.  The primary key is {TranDate,ManifestID}.
            sb.Append("SELECT COUNT(*) AS RowsFound FROM ")
            sb.Append(WeightVars.WEIGHTTblPath)
            sb.Append("DAILYENTRY WHERE TranDate = '")
            sb.Append(p_sShortDate)
            sb.Append("' and ManifestID = '")
            sb.Append(p_iWeightPlanID)
            sb.Append("'")

            sCmd = sb.ToString()

            PopulateDataset2(oDataAdapter, oDataSet, sCmd)

            iRowCount = oDataSet.Tables(0).Rows(0).Item("RowsFound")

            If iRowCount = 1 Then
                Return True
            Else
                Return False
            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message)
            Return False

        End Try

    End Function

    Private Function GetParentWeightPlan(ByVal p_iWeightPlanID As Integer) As Integer

        Try
            ' Data Access Variables
            Dim oDataAdapter As SqlDataAdapter
            Dim oDataSet As DataSet
            Dim oDailyEntry As DataRow
            Dim iRowCount As Integer

            ' Utility Variables
            Dim sb As New StringBuilder
            Dim sCmd As String

            ' Check to see if this weight plan has a parent
            sb.Append("select ParentID from ")
            sb.Append(WeightVars.WEIGHTTblPath)
            sb.Append("Manifests where [id] = ")
            sb.Append(p_iWeightPlanID)

            sCmd = sb.ToString()

            PopulateDataset2(oDataAdapter, oDataSet, sCmd)

            iRowCount = oDataSet.Tables(0).Rows.Count

            If iRowCount = 1 Then
                Return oDataSet.Tables(0).Rows(0).Item("ParentID")
            Else
                Return 0
            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message)
            Return False

        End Try

    End Function


    Private Function DailyEntryUpdateString(ByVal p_sShortDate As String, ByVal p_iWeightPlanID As Integer, ByVal p_fWeight As Decimal) As String

        Try
            ' Data Access Variables
            Dim oDataAdapter As SqlDataAdapter
            Dim oDataSet As DataSet
            Dim oDataRow As DataRow
            Dim iRowCount As Integer

            ' Command Component Variables
            Dim fOldWeight, fNewWeight, fWeightLimit, fOverCharge, fNewCharge, fChargableWeight As Decimal

            ' Utility Variables
            Dim sb As New StringBuilder
            Dim sCmd As String

            ' Get the current weight, limit and overcharge for this record
            sb.Append("SELECT Weight, WeightLimit, OWCharge FROM ")
            sb.Append(WeightVars.WEIGHTTblPath)
            sb.Append("DAILYENTRY WHERE TranDate = '")
            sb.Append(p_sShortDate)
            sb.Append("' and ManifestID = '")
            sb.Append(p_iWeightPlanID)
            sb.Append("'")

            sCmd = sb.ToString()
            sb.Remove(0, sb.Length)

            PopulateDataset2(oDataAdapter, oDataSet, sCmd)

            iRowCount = oDataSet.Tables(0).Rows.Count

            If iRowCount = 1 Then

                oDataRow = oDataSet.Tables(0).Rows(0)
                fOverCharge = oDataRow.Item("OWCharge")
                fOldWeight = oDataRow.Item("Weight")
                fWeightLimit = oDataRow.Item("WeightLimit")

                fNewWeight = fOldWeight + p_fWeight
                fChargableWeight = fNewWeight - fWeightLimit
                If fChargableWeight > 0 Then
                    fNewCharge = fChargableWeight * fOverCharge
                Else
                    fNewCharge = 0
                End If

                sb.Append("UPDATE ")
                sb.Append(WeightVars.WEIGHTTblPath)
                sb.Append("DailyEntry SET Weight = ")
                sb.Append(fNewWeight)
                sb.Append(", Charge = ")
                sb.Append(fNewCharge)
                sb.Append(" WHERE TranDate = '")
                sb.Append(p_sShortDate)
                sb.Append("' and ManifestID = '")
                sb.Append(p_iWeightPlanID)
                sb.Append("'")

                Return sb.ToString()

            Else
                Return String.Empty
            End If

        Catch ex As Exception

            MessageBox.Show(ex.Message)
            Return String.Empty

        End Try

    End Function

    Private Function DailyEntryInsertString(ByVal p_sTranDate As String, ByVal p_iWeightPlanID As Integer, ByVal p_fWeight As Decimal) As String

        Dim sb As New StringBuilder

        ' Construct the Insert Statement
        sb.Append("INSERT INTO ")
        sb.Append(WeightVars.WEIGHTTblPath)
        sb.Append("DailyEntry SELECT '")
        sb.Append(p_sTranDate)
        sb.Append("' as TranDate, ")
        sb.Append("m.[ID] as ManifestID,")
        sb.Append("m.OfficeID as OfficeID,")
        sb.Append("m.AccountID as AccountID,")
        sb.Append("c.[name] as AccountName,")
        sb.Append("m.[Name] as ManifestName,")
        sb.Append(p_fWeight)
        sb.Append(" as Weight,")
        sb.Append("wbd.WeightLimit as WeightLimit,")
        sb.Append("wbd.OWCharge as OWCharge,")
        sb.Append("ROUND(((")
        sb.Append(p_fWeight)
        sb.Append(" - wbd.WeightLimit) + ABS(")
        sb.Append(p_fWeight)
        sb.Append(" - wbd.WeightLimit)) / 2 * wbd.OWCharge,2) as Charge,")
        sb.Append("0 as Finalize,")
        sb.Append("wpg.[id] as WeightPlanGroupID,")
        sb.Append("wpg.[name] as WeightPlanGroup,")
        sb.Append("m.ParentID as ParentID,")
        sb.Append("0 as [Invoice No] ")
        sb.Append("from	")
        sb.Append(WeightVars.WEIGHTTblPath)
        sb.Append("manifests m,")
        sb.Append(WeightVars.WEIGHTTblPath)
        sb.Append("WeightBreakdown wbd,")
        sb.Append(WeightVars.WEIGHTTblPath)
        sb.Append("WeightPlanGroups wpg,")
        sb.Append(AppTblPath)
        sb.Append("Customer c ")
        sb.Append("where	m.[id] = ")
        sb.Append(p_iWeightPlanID)
        sb.Append(" and wbd.[id] = m.WeightID and wpg.[id] = m.GroupID and c.[id] = m.AccountID")

        Return sb.ToString()

    End Function

    'Private Function InputDailyEntryRecord(ByVal p_oRec As ScanRecord, ByVal p_oCLRow As DataRow, ByVal p_oTLRow As DataRow) As Boolean

    '    ' Utility variables
    '    Dim bRetVal1 As Boolean = True
    '    Dim bRetVal2 As Boolean = True

    '    ' Convert Barcode Strings into Specific Barcode Objects for Easier Manipulation
    '    Dim oBC As New TPCBarcode(p_oRec.Barcode)

    '    ' Extract the necessary information from the CourierLabels Record
    '    Dim iWeight As Decimal = p_oRec.Weight
    '    Dim iWeightPlanID As Integer = p_oTLRow.Item("WeightPlanID")
    '    Dim sTranDate As String '= p_oRec.TimeStamp.ToShortDateString
    '    'If p_oRec.TimeStamp.Hour < 7 Then
    '    '    sTranDate = p_oRec.TimeStamp.AddDays(-1).ToShortDateString
    '    'Else
    '    '    sTranDate = p_oRec.TimeStamp.ToShortDateString
    '    'End If
    '    sTranDate = p_oRec.BatchDate

    '    ' Round the weight up or down for billing purposes.  Rule: If decimal portion of weight is > 0.25, round up, otherwide round down
    '    Dim iPortion As Integer = IntegerPortion(iWeight)
    '    Dim fPortion As Decimal = DecimalPortion(iWeight)

    '    If fPortion > 0.25 Then
    '        iWeight = iPortion + 1 'Round UP
    '    Else
    '        iWeight = iPortion ' Round Down
    '    End If

    '    ' Utility Variables
    '    Dim sCmd As String

    '    If DailyEntryExists(sTranDate, iWeightPlanID) Then
    '        'Prepare an Update Statement
    '        sCmd = DailyEntryUpdateString(sTranDate, iWeightPlanID, iWeight)
    '    Else
    '        'Prepare an Insert Statement
    '        sCmd = DailyEntryInsertString(sTranDate, iWeightPlanID, iWeight)
    '    End If

    '    ' Execute the Insert/Update
    '    bRetVal1 = ExecuteQuery(sCmd)

    '    ' Determine if the weight plan has a parent weight plan.  If it does, create a Daily entry for the parent as well.
    '    Dim iParentWeightPlan As Integer = GetParentWeightPlan(iWeightPlanID)

    '    'If iParentWeightPlan <> 0 Then
    '    '    If DailyEntryExists(sTranDate, iParentWeightPlan) Then
    '    '        'Prepare an Update Statement
    '    '        sCmd = DailyEntryUpdateString(sTranDate, iParentWeightPlan, iWeight)
    '    '    Else
    '    '        'Prepare an Insert Statement
    '    '        sCmd = DailyEntryInsertString(sTranDate, iParentWeightPlan, iWeight)
    '    '    End If
    '    '    'Execute the Insert/Update
    '    '    bRetVal2 = ExecuteQuery(sCmd)
    '    'End If

    '    ' Loop Backwards to Apply Charges to all Ancestors (if any)
    '    Do While iParentWeightPlan <> 0

    '        If DailyEntryExists(sTranDate, iParentWeightPlan) Then
    '            sCmd = DailyEntryUpdateString(sTranDate, iParentWeightPlan, iWeight)
    '        Else
    '            sCmd = DailyEntryInsertString(sTranDate, iParentWeightPlan, iWeight)
    '        End If

    '        bRetVal2 = ExecuteQuery(sCmd)

    '        iParentWeightPlan = GetParentWeightPlan(iParentWeightPlan)

    '    Loop

    '    'Return true if either statement succeeded, False if they both failed.
    '    If (bRetVal1 = False) And (bRetVal2 = False) Then
    '        Return False
    '    Else
    '        Return True
    '    End If

    'End Function

    Private Function InsertEventRecord(ByVal p_oRec As ScanRecord, Optional ByVal p_oRow As DataRow = Nothing) As Boolean

        ' Convert Barcode Strings into Specific Barcode Objects for Easier Manipulation
        Dim oBC As New TPCBarcode(p_oRec.Barcode)
        Dim oOP As New TPCOperatorBC(p_oRec.OperatorId)
        Dim oPT As New TPCPointBC(p_oRec.PointId)

        ' Declare Variables That Will Differ Based on Value of p_oRow
        Dim sToCity, sParcelType, sToLocID, sToAddID, sToLocName, sFromAddID, sFromCustID, sFromCustName, sFromLocID, sFromLocName As String
        Dim sEmpty As String = String.Empty

        ' Declare Utility Variables
        Dim sb As New StringBuilder

        ' Initialzie Variables based on Value of p_oRow
        If Not IsNothing(p_oRow) Then

            sToCity = p_oRow("ToCity")
            sParcelType = p_oRow("ParcelType")
            sToLocID = p_oRow("ToLocID")
            sToAddID = p_oRow("ToAddID")
            sToLocName = p_oRow("ToLocName")
            sFromAddID = p_oRow("FromAddID")
            sFromCustID = p_oRow("FromCustID")
            sFromCustName = p_oRow("FromCustName")
            sFromLocID = p_oRow("FromLocID")
            sFromLocName = p_oRow("FromLocName")

        Else

            sToCity = sEmpty
            sParcelType = sEmpty
            sToLocID = sEmpty
            sToAddID = "NULL"
            sToLocName = sEmpty
            sFromAddID = "NULL"
            sFromCustID = sEmpty
            sFromCustName = sEmpty
            sFromLocID = sEmpty
            sFromLocName = sEmpty

        End If

        ' Construct the Insert Statement
        sb.Append("Insert into ")
        sb.Append(TRCTblPath)
        sb.Append("Event ")
        sb.Append("(EventCode, ScanDate, OperatorID, PointID, TicketNum, TrackingNum, ThirdPartyBarcode, ")
        sb.Append("ContainerBarcode, DeliveryOption, DeliveryComments, ToCity, ParcelType, Weight, Pieces, Void, ToLocID, ToAddID, ")
        sb.Append("ToLocName, RefNum, FromAddID, FromCustID, FromCustName, FromLocID, FromLocName, HHid, BatchNum, SignaturePath) ")
        sb.Append("VALUES ('")
        sb.Append(p_oRec.EventCode)
        sb.Append("', '")
        sb.Append(p_oRec.TimeStamp)
        sb.Append("', '")
        sb.Append(p_oRec.OperatorId)
        sb.Append("', '")
        sb.Append(p_oRec.PointId)
        sb.Append("', '', '") 'TicketNum is Empty
        sb.Append(oBC.Barcode)
        sb.Append("', '', '', '', '', '") 'ThirdPartyBarcode, ContainerBarcode, DeliveryOption & DeliveryComments are Empty
        sb.Append(sToCity)
        sb.Append("', '")
        sb.Append(sParcelType)
        sb.Append("', ")
        sb.Append(p_oRec.Weight)
        sb.Append(", 1, 'F', '") ' Pieces & Void are hard-coded to default values
        sb.Append(sToLocID)
        sb.Append("', ")
        sb.Append(sToAddID)
        sb.Append(", '")
        sb.Append(sToLocName)
        sb.Append("',NULL, ") ' RefNum is set to NULL
        sb.Append(sFromAddID)
        sb.Append(", '")
        sb.Append(sFromCustID)
        sb.Append("', '")
        sb.Append(sFromCustName)
        sb.Append("', '")
        sb.Append(sFromLocID)
        sb.Append("', '")
        sb.Append(sFromLocName)
        sb.Append("', '02W1', '', '')") 'HHid, BatchNum & SignaturePath use hard-coded value

        ' Execute the Insert
        Dim sInsert As String = sb.ToString()
        Return ExecuteQuery(sInsert)

    End Function

    'Private Function ImportTPCTrkRec(ByVal p_oRec As ScanRecord) As Boolean

    '    Dim bReturnValue As Boolean = True

    '    Try

    '        ' Convert Barcode Strings into Specific Barcode Objects
    '        Dim oBC As New TPCBarcode(p_oRec.Barcode)

    '        ' Declare Variable for Datatbase access
    '        Dim oDataAdapter As SqlDataAdapter
    '        Dim oDataSet As DataSet
    '        Dim iCourierLabelID As Integer

    '        ' Declare Utility Variables
    '        Dim sb As New StringBuilder

    '        ' Determine if this Barcode is recorded in the CourierLabel Table and Act Accordingly
    '        ' It does not matter if it is voided or not; we want to record as much detail as possible for the scan.
    '        sb.Append("SELECT * FROM ")
    '        sb.Append(TRCTblPath)
    '        sb.Append("CourierLabels WHERE TrackingNum = '")
    '        sb.Append(oBC.Barcode)
    '        sb.Append("'")

    '        PopulateDataset2(oDataAdapter, oDataSet, sb.ToString())

    '        If Not oDataSet Is Nothing Then

    '            Dim iCourierLabelRows As Integer = oDataSet.Tables(0).Rows.Count
    '            Dim oCourierLabelRow As DataRow = Nothing

    '            Select Case iCourierLabelRows

    '                Case 0 ' Info From ScanRecord Only; no entry in Event table possible.

    '                    bReturnValue = InsertEventRecord(p_oRec)

    '                Case 1 ' Combine Info From CourierLabel ScanRecord

    '                    oCourierLabelRow = oDataSet.Tables(0).Rows(0)
    '                    iCourierLabelID = oCourierLabelRow.Item("RowID")

    '                    bReturnValue = InsertEventRecord(p_oRec, oCourierLabelRow)

    '                    If bReturnValue = True Then

    '                        ' Determine if this Barcode is recorded in the TrackingLink Table and Act Accordingly
    '                        ' Does not matter if Active or not.
    '                        sb.Remove(0, sb.Length)
    '                        sb.Append("SELECT * FROM ")
    '                        sb.Append(TrucksVars.WEIGHTTblPath)
    '                        sb.Append("TrackingLink WHERE CourierLabelID = ")
    '                        sb.Append(iCourierLabelID)
    '                        sb.Append(" Order by RowId desc")

    '                        oDataSet.Dispose()

    '                        PopulateDataset2(oDataAdapter, oDataSet, sb.ToString())

    '                        If Not oDataSet Is Nothing Then

    '                            If oDataSet.Tables(0).Rows.Count > 0 Then 'Only most current assignment (past or present) is taken into account

    '                                bReturnValue = InputDailyEntryRecord(p_oRec, oCourierLabelRow, oDataSet.Tables(0).Rows(0))

    '                                If bReturnValue = False Then
    '                                    'TO-DO
    '                                    'Entry into Event table should be rolled back.  If a tracking number has a link to a 
    '                                    'weight plan, but the charge cannot be inserted, then the entire record should be rejected.
    '                                End If

    '                            End If

    '                            'CX-00932-2337640-1485

    '                        Else

    '                            bReturnValue = True 'No Link to Weight Plan.  Not a fatal error.

    '                        End If

    '                    Else

    '                        bReturnValue = False 'Error Inserting into Event Table

    '                    End If

    '            End Select

    '        Else

    '            bReturnValue = False 'Problem Quering Database

    '        End If

    '    Catch ex As Exception

    '        MessageBox.Show(ex.Message)
    '        Return False

    '    End Try

    '    Return bReturnValue

    'End Function

    'Private Function ImportTPCTrkRecOld(ByVal p_oRec As ScanRecord) As Boolean

    '    Dim bReturnValue As Boolean = True

    '    Try

    '        ' Convert Barcode Strings into Specific Barcode Objects
    '        Dim oBC As New TPCBarcode(p_oRec.Barcode)

    '        ' Declare Variable for Datatbase access
    '        Dim oDataAdapter As SqlDataAdapter
    '        Dim oDataSet As DataSet
    '        Dim iCourierLabelID As Integer

    '        ' Declare Utility Variables
    '        Dim sb As New StringBuilder

    '        ' Determine if this Barcode is recoreded in the CourierLabel Table and Act Accordingly
    '        sb.Append("SELECT * FROM ")
    '        sb.Append(TRCTblPath)
    '        sb.Append("CourierLabels WHERE Void = 'F' and TrackingNum = '")
    '        sb.Append(oBC.Barcode)
    '        sb.Append("'")

    '        PopulateDataset2(oDataAdapter, oDataSet, sb.ToString())

    '        If Not oDataSet Is Nothing Then

    '            Dim iCourierLabelRows As Integer = oDataSet.Tables(0).Rows.Count
    '            Dim oCourierLabelRow As DataRow = Nothing

    '            Select Case iCourierLabelRows

    '                Case 0 ' Info From ScanRecord Only

    '                    bReturnValue = InsertEventRecord(p_oRec)

    '                Case 1 ' Combine Info From CourierLabel ScanRecord

    '                    oCourierLabelRow = oDataSet.Tables(0).Rows(0)
    '                    iCourierLabelID = oCourierLabelRow.Item("RowID")

    '                    bReturnValue = InsertEventRecord(p_oRec, oCourierLabelRow)

    '                    If bReturnValue = True Then

    '                        ' Determine if this Barcode is recorded in the TrackingLink Table and Act Accordingly
    '                        sb.Remove(0, sb.Length)
    '                        sb.Append("SELECT * FROM ")
    '                        sb.Append(TrucksVars.WEIGHTTblPath)
    '                        sb.Append("TrackingLink WHERE Active = 1 and CourierLabelID = ")
    '                        sb.Append(iCourierLabelID)

    '                        oDataSet.Dispose()

    '                        PopulateDataset2(oDataAdapter, oDataSet, sb.ToString())

    '                        If Not oDataSet Is Nothing Then

    '                            If oDataSet.Tables(0).Rows.Count = 1 Then

    '                                bReturnValue = InputDailyEntryRecord(p_oRec, oCourierLabelRow, oDataSet.Tables(0).Rows(0))

    '                                If bReturnValue = False Then
    '                                    'TO-DO
    '                                    'Entry into Event table should be rolled back.  If a tracking number has a link to a 
    '                                    'weight plan, but the charge cannot be inserted, then the entire record should be rejected.
    '                                End If

    '                            End If

    '                        Else

    '                            bReturnValue = True 'No Link to Weight Plan.  Not a fatal error.

    '                        End If

    '                    Else

    '                        bReturnValue = False 'Error Inserting into Event Table

    '                    End If

    '            End Select

    '        Else

    '            bReturnValue = False 'Problem Quering Database

    '        End If

    '    Catch ex As Exception

    '        MessageBox.Show(ex.Message)
    '        Return False

    '    End Try

    '    Return bReturnValue

    'End Function

    Private Function ImportUnityHossRec(ByVal p_oRec As ScanRecord) As Boolean

        '  There will be 3 categories of HOSS barcodes to process
        '   1) We have both the Destination & Source Location in our Database
        '       a) this will result in the most complete Event record entry since all data will be at our fingertips
        '   2) We have the Destination but not the Source in our Database
        '       a) this will result in complete info for the Source fields, but empty data for the source records
        '   3) We have neither the Source nor the Destination in our Database
        '       a) this will result in as much data as we can muster from the barcode itself

        '   Besides the destination and source location info, we still need to determine who is the paying customer for the movement.
        '   In order to do that we would need to import C info from the HOSS manifests and then map that C number to our Unison account 
        '   numbers.  Even then, we will only have access to the full C information for customers who concer our branches.
        '
        '   Given that we need so much info, the first implementation of this function will only record the data that we know to be
        '   100% accurate.

        Dim bRetVal As Boolean

        Try

            ' Extract the various parts of the Barcode
            Dim oBarcode As New HossBarcode(p_oRec.Barcode)

            ' Determine if Destination Location is Unique throughout System
            Dim oToLoc As New Location
            oToLoc.GetIfUniqueLocId(oBarcode.DestinationCode)

            ' Determine if Source Location is Unique throughout System
            Dim oFromLoc As New Location
            oFromLoc.GetIfUniqueLocId(oBarcode.SourceCode)

            ' Create an Event with all know data
            Dim oEvent As New TrackingEvent

            ' Assign Values to oEvent and Persist
            oEvent.EventCode = p_oRec.EventCode
            oEvent.ScanDate = p_oRec.TimeStamp
            oEvent.OperatorId = New TPCOperatorBC(p_oRec.OperatorId)
            oEvent.PointId = New TPCPointBC(p_oRec.PointId)
            oEvent.ThirdPartyBarcode = oBarcode
            oEvent.ParcelType = oBarcode.ServiceType
            oEvent.Weight = p_oRec.Weight
            oEvent.Pieces = "1/1"
            oEvent.Void = False
            If Not oToLoc.IsEmpty Then
                oEvent.ToLocationId = oToLoc.LocationID
                oEvent.ToAddressId = oToLoc.AddressId
                oEvent.ToLocationName = oToLoc.Name
            End If
            If Not oFromLoc.IsEmpty Then
                oEvent.FromLocationId = oFromLoc.LocationID
                oEvent.FromAddressId = oFromLoc.AddressId
                oEvent.FromLocationName = oFromLoc.Name
            End If

            bRetVal = oEvent.Insert()
            'bRetVal = True

        Catch ex As Exception

            MessageBox.Show(ex.Message)
            bRetVal = False

        End Try

        Return bRetVal

    End Function

    Private Function ImportThirdPartyRec(ByVal p_oRec As ScanRecord) As Boolean

        Dim strRec As String

        strRec = p_oRec.EventCode & " + " & _
        p_oRec.OperatorId & " + " & _
        p_oRec.PointId & " + " & _
        p_oRec.Barcode & " + " & _
        p_oRec.Weight & " + " & _
        p_oRec.TimeStamp

        Dim oBarcode As New Barcode(p_oRec.Barcode)

        ''Dim strCaption As String
        ''strCaption = "ImportThirdPartyRec(" & p_oRec.BarcodeName & ")"
        ''MessageBox.Show(strRec, strCaption)

        ' Create an Event with all know data
        Dim oEvent As New TrackingEvent

        ' Assign Values to oEvent and Persist
        oEvent.EventCode = p_oRec.EventCode
        oEvent.ScanDate = p_oRec.TimeStamp
        oEvent.OperatorId = New TPCOperatorBC(p_oRec.OperatorId)
        oEvent.PointId = New TPCPointBC(p_oRec.PointId)
        oEvent.ThirdPartyBarcode = oBarcode
        oEvent.Weight = p_oRec.Weight
        oEvent.Pieces = "1/1"
        oEvent.Void = False

        Return oEvent.Insert()

    End Function

    'Friend Function ImportScanList(Optional ByVal SingleFileName As String = "") As Boolean

    '    If System.IO.Directory.Exists(ScanListPath) Then

    '        If SingleFileName <> "" Then

    '            Dim strFullFileName As String = ScanListPath & "\" & SingleFileName
    '            Dim oScanList As New ScanList(strFullFileName)

    '            If oScanList.FileName = "" Then

    '                MessageBox.Show(oScanList.ErrorMessage)

    '            Else

    '                For Each oRec As ScanRecord In oScanList.Records
    '                    Select Case oRec.BarcodeFormat
    '                        Case BarcodeFactory.BarcodeFormat.TPC_Tracking
    '                            ImportTPCTrkRec(oRec)
    '                        Case BarcodeFactory.BarcodeFormat.Unity_HOSS
    '                            ImportUnityHossRec(oRec)
    '                        Case BarcodeFactory.BarcodeFormat.Unknown
    '                            ImportThirdPartyRec(oRec)
    '                        Case BarcodeFactory.BarcodeFormat.TPC_Operator, BarcodeFactory.BarcodeFormat.TPC_Point
    '                            ' These formats are not imported
    '                        Case Else
    '                            '  Create an exception log to show which records were not imported
    '                            MessageBox.Show(oScanList.ErrorMessage, "Unreadable Format")
    '                    End Select

    '                Next

    '            End If

    '        Else

    '            Dim saFiles() As String = System.IO.Directory.GetFiles(ScanListPath)
    '            Dim sCurrentFile As String

    '            For Each sCurrentFile In saFiles



    '            Next

    '        End If

    '    End If

    'End Function

    'Friend Function ImportScanListFromUnison2() As Boolean



    'End Function

    'Friend Function ImportScanListFromUnison() As Boolean

    '    Dim bReturnValue As Boolean = True

    '    ' Data Access Variables
    '    Dim oDataAdapter As SqlDataAdapter
    '    Dim oDataSet As DataSet
    '    Dim oDailyEntry As DataRow
    '    Dim iRowCount As Integer

    '    ' Utility Variables
    '    Dim sb As New StringBuilder
    '    Dim sCmd As String

    '    Try

    '        ' Get Data from ScanList table
    '        sb.Append("select")
    '        sb.Append(" RowId,")
    '        'EventCode
    '        sb.Append(" EventCode + '|' +")
    '        'OperatorID
    '        sb.Append(" OperatorID + '|' +")
    '        'PointId
    '        sb.Append(" PointId + '|' +")
    '        'Barcode
    '        sb.Append(" rtrim(Barcode) + '|' +")
    '        'Weight
    '        sb.Append(" cast(Weight as varchar) + '|' +")
    '        'X
    '        sb.Append(" case when charindex('of',x) = 0 then x else rtrim(substring(x,1,len(x) - (charindex('of',x) + 1))) end  + '|' +")
    '        'ScanError
    '        sb.Append(" ScanError + '|' +")
    '        'BatchID
    '        sb.Append(" cast(BatchId as varchar) + '|' +")
    '        'ScanDate
    '        sb.Append(" case when datepart(month,ScanDate) < 10 then '0' + cast(datepart(month,ScanDate) as varchar) else cast(datepart(month,ScanDate) as varchar) end +")
    '        sb.Append(" case when datepart(day,ScanDate) < 10 then '0' + cast(datepart(day,ScanDate) as varchar) else cast(datepart(day,ScanDate) as varchar) end +	cast(datepart(year,ScanDate) as varchar) +")
    '        sb.Append(" case when datepart(hour,ScanDate) < 10 then '0' + cast(datepart(hour,ScanDate) as varchar) else cast(datepart(hour,ScanDate) as varchar) end +")
    '        sb.Append(" case when datepart(minute,ScanDate) < 10 then '0' + cast(datepart(minute,ScanDate) as varchar) else cast(datepart(minute,ScanDate) as varchar) end +")
    '        sb.Append(" case when datepart(second,ScanDate) < 10 then '0' + cast(datepart(second,ScanDate) as varchar) else cast(datepart(second,ScanDate) as varchar) end + '|' +")
    '        'BatchDate
    '        sb.Append(" case when datepart(month,BatchDate) < 10 then '0' + cast(datepart(month,BatchDate) as varchar) else cast(datepart(month,BatchDate) as varchar) end +")
    '        sb.Append(" case when datepart(day,BatchDate) < 10 then '0' + cast(datepart(day,BatchDate) as varchar) else cast(datepart(day,BatchDate) as varchar) end +	cast(datepart(year,BatchDate) as varchar) +")
    '        sb.Append(" case when datepart(hour,BatchDate) < 10 then '0' + cast(datepart(hour,BatchDate) as varchar) else cast(datepart(hour,BatchDate) as varchar) end +")
    '        sb.Append(" case when datepart(minute,BatchDate) < 10 then '0' + cast(datepart(minute,BatchDate) as varchar) else cast(datepart(minute,BatchDate) as varchar) end +")
    '        sb.Append(" case when datepart(second,BatchDate) < 10 then '0' + cast(datepart(second,BatchDate) as varchar) else cast(datepart(second,BatchDate) as varchar) end + '|' +")
    '        sb.Append(" cast(ErrorLog as varchar) as RecordString")
    '        sb.Append(" from " & TRCTblPath & "scanlist")
    '        sb.Append(" where ScanError % 10 = 0 and Processed = 0")

    '        sCmd = sb.ToString()

    '        PopulateDataset2(oDataAdapter, oDataSet, sCmd)

    '        If Not oDataSet Is Nothing Then

    '            If oDataSet.Tables.Count = 1 Then

    '                If oDataSet.Tables(0).Rows.Count > 0 Then

    '                    Dim iRowId As Integer = oDataSet.Tables(0).Rows(0).Item("RowId")
    '                    Dim oScanList As New ScanList(oDataSet)
    '                    Dim i As Integer = -1

    '                    If Not oScanList.Records Is Nothing Then

    '                        For Each oRec As ScanRecord In oScanList.Records

    '                            i = i + 1
    '                            iRowId = oDataSet.Tables(0).Rows(i).Item("RowId")

    '                            If Not ImportScanListRecord(oRec) Then

    '                                If MessageBox.Show(oRec.ErrorMessage + ". Do you want to continue?", "Error Importing Record at RowID " & iRowId.ToString(), MessageBoxButtons.YesNo, MessageBoxIcon.Warning) = DialogResult.No Then

    '                                    bReturnValue = False
    '                                    Exit For

    '                                End If

    '                            Else

    '                                sb.Length = 0
    '                                sb.Append("UPDATE " & TRCTblPath & "scanlist SET Processed = 1, ProcessDate = '" & Date.Now().ToShortDateString & " " & Date.Now().ToShortTimeString & "' WHERE RowId = " & iRowId)
    '                                sCmd = sb.ToString()
    '                                bReturnValue = ExecuteQuery(sCmd)

    '                                If bReturnValue = False Then

    '                                    MessageBox.Show("ScanList Record at RowId " & iRowId & " was processed properly, but its flag was not updated", "Problem Importing ScanList Record", MessageBoxButtons.OK, MessageBoxIcon.Warning)

    '                                End If

    '                            End If

    '                        Next

    '                    Else

    '                        MessageBox.Show(oScanList.ErrorMessage, "Import ScanList Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '                        bReturnValue = False

    '                    End If

    '                Else

    '                    MessageBox.Show("No Records Founds to Import", "Import ScanList Status", MessageBoxButtons.OK, MessageBoxIcon.Information)
    '                    bReturnValue = True

    '                End If

    '            Else

    '                MessageBox.Show("There were no records to import", "Import ScanList Status", MessageBoxButtons.OK)
    '                bReturnValue = True

    '            End If

    '        Else

    '            MessageBox.Show("Database Error", "Import ScanList Status", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '            bReturnValue = False

    '        End If

    '    Catch ex As Exception

    '        bReturnValue = False

    '    End Try


    '    Return bReturnValue

    'End Function

    'Private Function ImportScanListRecord(ByVal p_oRec As ScanRecord) As Boolean

    '    Dim bReturnValue As Boolean = False

    '    Try

    '        Select Case p_oRec.BarcodeFormat
    '            Case BarcodeFactory.BarcodeFormat.TPC_Tracking
    '                bReturnValue = ImportTPCTrkRec(p_oRec)
    '            Case BarcodeFactory.BarcodeFormat.Unity_HOSS
    '                bReturnValue = ImportUnityHossRec(p_oRec)
    '            Case BarcodeFactory.BarcodeFormat.Unknown
    '                bReturnValue = ImportThirdPartyRec(p_oRec)
    '            Case BarcodeFactory.BarcodeFormat.TPC_Operator, BarcodeFactory.BarcodeFormat.TPC_Point
    '                ' These formats are not imported
    '            Case Else
    '                '  Create an exception log to show which records were not imported
    '                'MessageBox.Show(oScanList.ErrorMessage, "Unreadable Format")
    '        End Select

    '    Catch ex As Exception

    '        bReturnValue = False

    '    End Try

    '    Return bReturnValue

    'End Function

    '====================
    ' IPI Text Files sent by email
    '====================

    Friend Function ImportIPI(Optional ByVal SingleFileName As String = "")
        Dim FileRdr As StreamReader
        Dim Cols(), ColsTmp(), Line, qUpdLoc, qAddLoc, qAddMft, qAddMftInv, qAddEvent As String
        Dim FilesArr(), FileName(), ValidFiles(), FileNameSplit() As String
        Dim i, j, k As Int32
        Dim FndQuote As Boolean = False
        Dim Delimiter, BlockChar, DelimiterReplacer As String

        On Error GoTo ErrTrap

        Delimiter = ","
        BlockChar = """"
        DelimiterReplacer = ""

        IPIPath = IPIPath.ToUpper
        If System.IO.Directory.Exists(IPIPath) Then
            Dim sr As StreamReader
            FilesArr = System.IO.Directory.GetFiles(IPIPath)
            j = 0
            For i = 0 To FilesArr.Length - 1
                FilesArr(i) = FilesArr(i).ToUpper
                FileName = FilesArr(i).Split(".")
                FileNameSplit = FileName(0).Split("_")
                If FileNameSplit.Length <= 1 Then
                    GoTo NextFile
                End If
                If ((FileNameSplit(0) & "_" & FileNameSplit(1))).ToUpper = ((IPIPath & "\" & "TP_LOG")).ToUpper Or ((FileNameSplit(0) & "_" & FileNameSplit(1))).ToUpper = ((IPIPath & "\" & "f_TP")).ToUpper Then
                    ReDim Preserve ValidFiles(j)
                    ValidFiles(j) = FilesArr(i)
                    j += 1
                End If
NextFile:
            Next i
        Else
            MsgBox("Path Does not Exist for IPI:" & IPIPath)
            Exit Function
        End If

        If ValidFiles Is Nothing Then
            Exit Function
        End If



        For i = 0 To ValidFiles.Length - 1

            'Read the first line of text.

            FileRdr = New StreamReader(ValidFiles(i))

            Line = FileRdr.ReadLine()
            If Line Is Nothing Then GoTo NextI

            While Not Line Is Nothing
                ColsTmp = Line.Split(Delimiter)
                If (ColsTmp.Length) <> eIPIImp._END Then
                    ReDim Cols(eIPIImp._END - 1)
                    k = 0
                    For j = 0 To ColsTmp.Length - 1
                        If ColsTmp(j).Length = 0 Then
                            Cols(k) = ColsTmp(j)
                            k += 1
                            GoTo NextJ
                        End If
                        If FndQuote Then
                            If ColsTmp(j).Substring(ColsTmp(j).Length - 1) = BlockChar Then
                                Cols(k) = Cols(k) & DelimiterReplacer & ColsTmp(j).Substring(0, ColsTmp(j).Length - 1)
                                FndQuote = False
                                k += 1
                            Else
                                Cols(k) = Cols(k) & DelimiterReplacer & ColsTmp(j)
                            End If
                        Else
                            If ColsTmp(j).Substring(0, 1) = BlockChar Then
                                Cols(k) = ColsTmp(j).Substring(1)
                                FndQuote = True
                            Else
                                Cols(k) = ColsTmp(j)
                                k += 1
                            End If
                        End If
NextJ:
                    Next j
                    If k <> eIPIImp._END Then
                        MsgBox("Error: Cols count mismatch: k= " & k)
                        FileRdr.Close()
                        FileRdr = Nothing
                        Exit Function
                    End If
                Else
                    Cols = ColsTmp
                End If

                Cols(eIPIImp._01TRNUM) = Cols(eIPIImp._01TRNUM).Trim.ToUpper.Replace("'", "''")
                Cols(eIPIImp._02PKGID) = Cols(eIPIImp._02PKGID).Trim.ToUpper.Replace("'", "''")
                Cols(eIPIImp._03DATE) = Cols(eIPIImp._03DATE).Trim.ToUpper.Replace("'", "''")
                Cols(eIPIImp._04CUSTID) = Cols(eIPIImp._04CUSTID).Trim.ToUpper.Replace("'", "''")
                Cols(eIPIImp._05LOCID) = Cols(eIPIImp._05LOCID).Trim.ToUpper.Replace("'", "''")
                Cols(eIPIImp._06LOC) = Cols(eIPIImp._06LOC).Trim.ToUpper.Replace("'", "''")
                Cols(eIPIImp._07Add1) = Cols(eIPIImp._07Add1).Trim.ToUpper.Replace("'", "''")
                Cols(eIPIImp._08Add2) = Cols(eIPIImp._08Add2).Trim.ToUpper.Replace("'", "''")
                Cols(eIPIImp._09CITY) = Cols(eIPIImp._09CITY).Trim.ToUpper.Replace("'", "''")
                Cols(eIPIImp._10STATE) = Cols(eIPIImp._10STATE).Trim.ToUpper.Replace("'", "''")
                Cols(eIPIImp._11ZIP) = Cols(eIPIImp._11ZIP).Trim.ToUpper.Replace("'", "''").Replace("-", "").Replace("0000", "")
                Cols(eIPIImp._12PHONE) = Cols(eIPIImp._12PHONE).Trim.ToUpper.Replace("'", "''")
                Cols(eIPIImp._13WGT) = Cols(eIPIImp._13WGT).Trim.ToUpper.Replace("'", "''")

                'Begin Update Exsiting Location Address
                'qUpdLoc = " Update " & TRCTblpath & "location " & _
                '          " set " & _
                '          " name = l2.name, Address1 = l2.Address1, Address2 = l2.Address2, City = l2.City, State = l2.State, Zip = l2.Zip, Phone = l2.Phone " & _
                '          " from " & TRCTblpath & "location l , " & _
                '          " (Select '" & Cols(eIPIImp._04CUSTID) & "' as CustomerID, '" & Cols(eIPIImp._05LOCID) & "' as LocationID, '" & Cols(eIPIImp._06LOC) & "' as Name, '" & Cols(eIPIImp._07Add1) & "' as Address1, '" & Cols(eIPIImp._08Add2) & "' as Address2, '" & Cols(eIPIImp._09CITY) & "' as City, '" & Cols(eIPIImp._10STATE) & "' as State, '" & Cols(eIPIImp._11ZIP) & "' as Zip, '" & Cols(eIPIImp._12PHONE) & "' as Phone) l2 " & _
                '          " Where l.locationid = l2.locationid AND l.customerid = '" & Cols(eIPIImp._04CUSTID) & "' ;"
                qUpdLoc = ""
                'End Update Location

                qAddLoc = " Insert into " & TRCTblPath & "Location (CustomerID, LocationID, name, Address1, Address2, state, city, zip, Phone, Active) " & _
                          " Select '" & Cols(eIPIImp._04CUSTID) & "' as CustomerID, '" & Cols(eIPIImp._05LOCID) & "' as LocationID, '" & Cols(eIPIImp._06LOC) & "' as Name, '" & Cols(eIPIImp._07Add1) & "' as Address1, '" & Cols(eIPIImp._08Add2) & "' as Address2, '" & Cols(eIPIImp._10STATE) & "' as State, '" & Cols(eIPIImp._09CITY).Trim.ToUpper & "' as City, replace('" & Cols(eIPIImp._11ZIP).Trim.ToUpper & "', '-', '') as Zip, '" & Cols(eIPIImp._12PHONE) & "' as Phone, 'Y' as Active " & _
                          " " & _
                          " where '" & Cols(eIPIImp._05LOCID) & "' not in (Select l.LocationID from " & TRCTblPath & "Location l where l.CustomerID = '" & Cols(eIPIImp._04CUSTID) & "'); "

                qAddMft = " Insert into " & TRCTblPath & "Manifest(TrackingNum, RefNum, FromAddID, FromCustID, FromCustName, FromLocID, FromLocName, FromAdd1, FromAdd2, FromCity, FromState, FromZip, FromContact, FromPhone, FromEmail, ToAddID, ToCustID, ToCustName, ToLocID, ToLocName, ToAdd1, ToAdd2, ToCity, ToState, ToZip, ToContact, ToPhone, ToEmail, Weight, Pieces, SentBy, ParcelType, ServiceLevel, SpecialHandle, BillType, BillNum, DateTime, RowID, VOID) " & _
                          " Select '" & Cols(eIPIImp._01TRNUM) & "' as TrackingNum, substring('" & Cols(eIPIImp._01TRNUM) & "', 6, 2) as RefNum, " & _
                          " fl.AddressID as FromAddID, fl.CustomerID as FromCustID, fcust.Name as FromCustName, fl.LocationID as FromLocID, fl.Name as FromLocName, fl.Address1 as FromAdd1, fl.Address2 as FromAdd2, fl.City as FromCity, fl.State as FromState, fl.zip as FromZip, fl.contact as FromContact, fl.Phone as FromPhone, fl.email as FromEmail, " & _
                          " tl.AddressID as ToAddID, fl.CustomerID as ToCustID, fcust.Name as ToCustName, tl.LocationID as ToLocID, tl.name as ToLocName, isnull(tl.Address1, '') as ToAdd1, isnull(tl.Address2, '') as ToAdd2, tl.City as ToCity, tl.State as ToState, tl.zip as ToZip, tl.Contact as ToContact, tl.Phone as ToPhone, tl.email as ToEmail, " & _
                          " '" & Cols(eIPIImp._13WGT) & "' as Weight, '1' as Pieces, 'MIS' as SentBy, 'BOX' as ParcelType, '' as ServiceLevel, '' as SpecialHandle, '' as BillType, '' as BillNum, '" & Cols(eIPIImp._03DATE) & "' as [DateTime], convert(varchar, convert(datetime, '" & Cols(eIPIImp._03DATE) & "'), 112)+'" & Cols(eIPIImp._01TRNUM) & "' as RowID, 'F' as Void " & _
                          " From " & _
                          " ((" & TRCTblPath & "Customer fcust left outer join " & TRCTblPath & "Location fl on fl.customerid = fcust.customerid  and fl.locationid = fcust.customerid) left outer join " & TRCTblPath & "Location tl on tl.customerid = fcust.Customerid and tl.locationID = '" & Cols(eIPIImp._05LOCID) & "') " & _
                          " where  fcust.CustomerID = '" & Cols(eIPIImp._04CUSTID) & "' " & _
                          "  AND '" & Cols(eIPIImp._01TRNUM) & "' not in (Select ex.TrackingNum From " & TRCTblPath & "Manifest ex where ex.[DateTime] >= convert(datetime, '" & Cols(eIPIImp._03DATE) & "') AND ex.TrackingNum = '" & Cols(eIPIImp._01TRNUM) & "');"

                qAddMftInv = " Insert into " & TRCTblPath & "ManifestInvoice(RowID, DateTime, TrackingNum, BillNum, FromCustID, FromAddID, FromLocID, FromZip, ToCustID, ToAddID, ToLocID, ToZip, Weight, ParcelType, Invoice_No, Pieces, Charge, PlanID, Ref1, Ref2, Ref3, Ref4, Ref5) " & _
                             " Select convert(varchar, convert(datetime, '" & Cols(eIPIImp._03DATE) & "'), 112)+'" & Cols(eIPIImp._01TRNUM) & "' as RowID, '" & Cols(eIPIImp._03DATE) & "' as [DateTime], '" & Cols(eIPIImp._01TRNUM) & "' as TrackingNum, '' as BillNum, " & _
                             " fl.CustomerID as FromCustID, fl.AddressID as FromAddID, fl.LocationID as FromLocId, fl.Zip as FromZip, fl.CustomerID as ToCustID, " & _
                             " tl.AddressID as ToAddID, tl.LocationID as ToLocId, tl.Zip as ToZip, '" & Cols(eIPIImp._13WGT) & "' as Weight, 'BOX' as ParcelType, NULL as Invoice_No, '1' as Pieces, " & _
                             " NULL as Charge, NULL as PlanID, substring('" & Cols(eIPIImp._01TRNUM) & "', 6, 2) as Ref1, '" & Cols(eIPIImp._02PKGID) & "' as Ref2, '' as Ref3, '' as Ref4, '' as Ref5 " & _
                             " From " & _
                             " ((" & TRCTblPath & "Customer fcust left outer join " & TRCTblPath & "Location fl on fl.customerid = fcust.CustomerID and fl.locationid = fcust.CustomerID) left outer join " & TRCTblPath & "Location tl on tl.customerid = fcust.CustomerID and tl.locationID = '" & Cols(eIPIImp._05LOCID) & "') " & _
                             " where fcust.CustomerID = '" & Cols(eIPIImp._04CUSTID) & "' AND '" & Cols(eIPIImp._01TRNUM) & "' not in (Select ex.TrackingNum From " & TRCTblPath & "ManifestInvoice ex where ex.[DateTime] >= convert(datetime, '" & Cols(eIPIImp._03DATE) & "') AND ex.TrackingNum = '" & Cols(eIPIImp._01TRNUM) & "');"

                qAddEvent = " Insert into " & TRCTblPath & "Event(EventCode, ScanDate, OperatorID, PointID, TicketNum, TrackingNum, ThirdPartyBarcode, ContainerBarcode, DeliveryOption, DeliveryComments, ToCity, ParcelType, Weight, Pieces, Void, ToLocID, ToAddID, ToLocName, RefNum, FromAddID, FromCustID, FromCustName, FromLocID, FromLocName, HHid, BatchNum, SignaturePath) " & _
                            " Select 'L' as EventCode, '" & Cols(eIPIImp._03DATE) & "' as ScanDate, '1' as OperatorID, NULL as PointID, NULL as TicketNum, '' as TrackingNum, " & _
                            " '" & Cols(eIPIImp._01TRNUM) & "' as ThirdPartyBarcode, NULL as ContainerBarcode, NULL as DeliveryOption, '' as DeliveryComments, tl.City as ToCity, " & _
                            " 'BOX' as ParcelType, '" & Cols(eIPIImp._13WGT) & "' as Weight, '1' as Pieces, 'F' as Void, tl.LocationID as ToLocID, tl.AddressID as ToAddID, " & _
                            " tl.Name as ToLocName, substring('" & Cols(eIPIImp._01TRNUM) & "', 6, 2) as RefNum, " & _
                            " fl.AddressID as FromAddID, fl.CustomerID as FromCustID, fcust.Name as FromCustName, fl.LocationID as FromLocID, " & _
                            " fl.Name as FromLocName, NULL as HHid, NULL as BatchNum, NULL as SignaturePath " & _
                            " From " & _
                            " ((" & TRCTblPath & "Customer fcust left outer join " & TRCTblPath & "Location fl on fl.customerid = fcust.customerid and fl.locationid = fcust.customerid) left outer join " & TRCTblPath & "Location tl on tl.customerid = fcust.customerid and tl.locationID = '" & Cols(eIPIImp._05LOCID) & "') " & _
                            " Where fcust.CustomerID = '" & Cols(eIPIImp._04CUSTID) & "' AND '" & Cols(eIPIImp._01TRNUM) & "' not in (Select ex.ThirdPartyBarcode From " & TRCTblPath & "Event ex where ex.ScanDate >= convert(datetime, '" & Cols(eIPIImp._03DATE) & "') AND ex.EventCode = 'L' AND ex.ThirdPartyBarcode = '" & Cols(eIPIImp._01TRNUM) & "'); "

                If ExecuteQuery(qUpdLoc + qAddLoc + qAddMft + qAddMftInv + qAddEvent) = False Then
                    MsgBox("Error inserting rows.")
                    FileRdr.Close()
                    FileRdr = Nothing
                    Exit Function
                End If
                'Cols.Clear(Cols, 0, Cols.Length - 1)
                Cols = Nothing
                Line = FileRdr.ReadLine()
            End While

NextI:
            FileRdr.Close()
            FileRdr = Nothing
            'Dim tmpstr() As String
            'tmpstr = ValidFiles(i).Split(".")
            FileNameSplit = ValidFiles(i).Split("\")
            FileNameSplit(FileNameSplit.Length - 1) = "ARC_" & FileNameSplit(FileNameSplit.Length - 1)
            File.Move(ValidFiles(i), IPIPath & "\" & FileNameSplit(FileNameSplit.Length - 1))
            'tmpstr = Nothing
        Next i
        Exit Function
ErrTrap:
        If Err.Number > 0 Then
            MsgBox("IPIImport Error: " & Err.Description)
            'Resume
        End If
    End Function

End Module