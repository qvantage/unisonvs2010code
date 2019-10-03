﻿'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated by a tool.
'     Runtime Version: 1.1.4322.573
'
'     Changes to this file may cause incorrect behavior and will be lost if 
'     the code is regenerated.
' </autogenerated>
'------------------------------------------------------------------------------

Option Strict Off
Option Explicit On

Imports System
Imports System.Data
Imports System.Runtime.Serialization
Imports System.Xml


<Serializable(),  _
 System.ComponentModel.DesignerCategoryAttribute("code"),  _
 System.Diagnostics.DebuggerStepThrough(),  _
 System.ComponentModel.ToolboxItem(true)>  _
Public Class WeightTotalsDS
    Inherits DataSet
    
    Private tableWPGTotals As WPGTotalsDataTable
    
    Public Sub New()
        MyBase.New
        Me.InitClass
        Dim schemaChangedHandler As System.ComponentModel.CollectionChangeEventHandler = AddressOf Me.SchemaChanged
        AddHandler Me.Tables.CollectionChanged, schemaChangedHandler
        AddHandler Me.Relations.CollectionChanged, schemaChangedHandler
    End Sub
    
    Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
        MyBase.New
        Dim strSchema As String = CType(info.GetValue("XmlSchema", GetType(System.String)),String)
        If (Not (strSchema) Is Nothing) Then
            Dim ds As DataSet = New DataSet
            ds.ReadXmlSchema(New XmlTextReader(New System.IO.StringReader(strSchema)))
            If (Not (ds.Tables("WPGTotals")) Is Nothing) Then
                Me.Tables.Add(New WPGTotalsDataTable(ds.Tables("WPGTotals")))
            End If
            Me.DataSetName = ds.DataSetName
            Me.Prefix = ds.Prefix
            Me.Namespace = ds.Namespace
            Me.Locale = ds.Locale
            Me.CaseSensitive = ds.CaseSensitive
            Me.EnforceConstraints = ds.EnforceConstraints
            Me.Merge(ds, false, System.Data.MissingSchemaAction.Add)
            Me.InitVars
        Else
            Me.InitClass
        End If
        Me.GetSerializationData(info, context)
        Dim schemaChangedHandler As System.ComponentModel.CollectionChangeEventHandler = AddressOf Me.SchemaChanged
        AddHandler Me.Tables.CollectionChanged, schemaChangedHandler
        AddHandler Me.Relations.CollectionChanged, schemaChangedHandler
    End Sub
    
    <System.ComponentModel.Browsable(false),  _
     System.ComponentModel.DesignerSerializationVisibilityAttribute(System.ComponentModel.DesignerSerializationVisibility.Content)>  _
    Public ReadOnly Property WPGTotals As WPGTotalsDataTable
        Get
            Return Me.tableWPGTotals
        End Get
    End Property
    
    Public Overrides Function Clone() As DataSet
        Dim cln As WeightTotalsDS = CType(MyBase.Clone,WeightTotalsDS)
        cln.InitVars
        Return cln
    End Function
    
    Protected Overrides Function ShouldSerializeTables() As Boolean
        Return false
    End Function
    
    Protected Overrides Function ShouldSerializeRelations() As Boolean
        Return false
    End Function
    
    Protected Overrides Sub ReadXmlSerializable(ByVal reader As XmlReader)
        Me.Reset
        Dim ds As DataSet = New DataSet
        ds.ReadXml(reader)
        If (Not (ds.Tables("WPGTotals")) Is Nothing) Then
            Me.Tables.Add(New WPGTotalsDataTable(ds.Tables("WPGTotals")))
        End If
        Me.DataSetName = ds.DataSetName
        Me.Prefix = ds.Prefix
        Me.Namespace = ds.Namespace
        Me.Locale = ds.Locale
        Me.CaseSensitive = ds.CaseSensitive
        Me.EnforceConstraints = ds.EnforceConstraints
        Me.Merge(ds, false, System.Data.MissingSchemaAction.Add)
        Me.InitVars
    End Sub
    
    Protected Overrides Function GetSchemaSerializable() As System.Xml.Schema.XmlSchema
        Dim stream As System.IO.MemoryStream = New System.IO.MemoryStream
        Me.WriteXmlSchema(New XmlTextWriter(stream, Nothing))
        stream.Position = 0
        Return System.Xml.Schema.XmlSchema.Read(New XmlTextReader(stream), Nothing)
    End Function
    
    Friend Sub InitVars()
        Me.tableWPGTotals = CType(Me.Tables("WPGTotals"),WPGTotalsDataTable)
        If (Not (Me.tableWPGTotals) Is Nothing) Then
            Me.tableWPGTotals.InitVars
        End If
    End Sub
    
    Private Sub InitClass()
        Me.DataSetName = "WeightTotalsDS"
        Me.Prefix = ""
        Me.Namespace = "http://tempuri.org/WeightTotalsDS.xsd"
        Me.Locale = New System.Globalization.CultureInfo("en-US")
        Me.CaseSensitive = false
        Me.EnforceConstraints = true
        Me.tableWPGTotals = New WPGTotalsDataTable
        Me.Tables.Add(Me.tableWPGTotals)
    End Sub
    
    Private Function ShouldSerializeWPGTotals() As Boolean
        Return false
    End Function
    
    Private Sub SchemaChanged(ByVal sender As Object, ByVal e As System.ComponentModel.CollectionChangeEventArgs)
        If (e.Action = System.ComponentModel.CollectionChangeAction.Remove) Then
            Me.InitVars
        End If
    End Sub
    
    Public Delegate Sub WPGTotalsRowChangeEventHandler(ByVal sender As Object, ByVal e As WPGTotalsRowChangeEvent)
    
    <System.Diagnostics.DebuggerStepThrough()>  _
    Public Class WPGTotalsDataTable
        Inherits DataTable
        Implements System.Collections.IEnumerable
        
        Private columnName As DataColumn
        
        Private columnTranDate As DataColumn
        
        Private columnWeight As DataColumn
        
        Friend Sub New()
            MyBase.New("WPGTotals")
            Me.InitClass
        End Sub
        
        Friend Sub New(ByVal table As DataTable)
            MyBase.New(table.TableName)
            If (table.CaseSensitive <> table.DataSet.CaseSensitive) Then
                Me.CaseSensitive = table.CaseSensitive
            End If
            If (table.Locale.ToString <> table.DataSet.Locale.ToString) Then
                Me.Locale = table.Locale
            End If
            If (table.Namespace <> table.DataSet.Namespace) Then
                Me.Namespace = table.Namespace
            End If
            Me.Prefix = table.Prefix
            Me.MinimumCapacity = table.MinimumCapacity
            Me.DisplayExpression = table.DisplayExpression
        End Sub
        
        <System.ComponentModel.Browsable(false)>  _
        Public ReadOnly Property Count As Integer
            Get
                Return Me.Rows.Count
            End Get
        End Property
        
        Friend ReadOnly Property NameColumn As DataColumn
            Get
                Return Me.columnName
            End Get
        End Property
        
        Friend ReadOnly Property TranDateColumn As DataColumn
            Get
                Return Me.columnTranDate
            End Get
        End Property
        
        Friend ReadOnly Property WeightColumn As DataColumn
            Get
                Return Me.columnWeight
            End Get
        End Property
        
        Public Default ReadOnly Property Item(ByVal index As Integer) As WPGTotalsRow
            Get
                Return CType(Me.Rows(index),WPGTotalsRow)
            End Get
        End Property
        
        Public Event WPGTotalsRowChanged As WPGTotalsRowChangeEventHandler
        
        Public Event WPGTotalsRowChanging As WPGTotalsRowChangeEventHandler
        
        Public Event WPGTotalsRowDeleted As WPGTotalsRowChangeEventHandler
        
        Public Event WPGTotalsRowDeleting As WPGTotalsRowChangeEventHandler
        
        Public Overloads Sub AddWPGTotalsRow(ByVal row As WPGTotalsRow)
            Me.Rows.Add(row)
        End Sub
        
        Public Overloads Function AddWPGTotalsRow(ByVal Name As String, ByVal TranDate As Date, ByVal Weight As Decimal) As WPGTotalsRow
            Dim rowWPGTotalsRow As WPGTotalsRow = CType(Me.NewRow,WPGTotalsRow)
            rowWPGTotalsRow.ItemArray = New Object() {Name, TranDate, Weight}
            Me.Rows.Add(rowWPGTotalsRow)
            Return rowWPGTotalsRow
        End Function
        
        Public Function GetEnumerator() As System.Collections.IEnumerator Implements System.Collections.IEnumerable.GetEnumerator
            Return Me.Rows.GetEnumerator
        End Function
        
        Public Overrides Function Clone() As DataTable
            Dim cln As WPGTotalsDataTable = CType(MyBase.Clone,WPGTotalsDataTable)
            cln.InitVars
            Return cln
        End Function
        
        Protected Overrides Function CreateInstance() As DataTable
            Return New WPGTotalsDataTable
        End Function
        
        Friend Sub InitVars()
            Me.columnName = Me.Columns("Name")
            Me.columnTranDate = Me.Columns("TranDate")
            Me.columnWeight = Me.Columns("Weight")
        End Sub
        
        Private Sub InitClass()
            Me.columnName = New DataColumn("Name", GetType(System.String), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnName)
            Me.columnTranDate = New DataColumn("TranDate", GetType(System.DateTime), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnTranDate)
            Me.columnWeight = New DataColumn("Weight", GetType(System.Decimal), Nothing, System.Data.MappingType.Element)
            Me.Columns.Add(Me.columnWeight)
            Me.columnName.AllowDBNull = false
            Me.columnTranDate.AllowDBNull = false
            Me.columnWeight.ReadOnly = true
        End Sub
        
        Public Function NewWPGTotalsRow() As WPGTotalsRow
            Return CType(Me.NewRow,WPGTotalsRow)
        End Function
        
        Protected Overrides Function NewRowFromBuilder(ByVal builder As DataRowBuilder) As DataRow
            Return New WPGTotalsRow(builder)
        End Function
        
        Protected Overrides Function GetRowType() As System.Type
            Return GetType(WPGTotalsRow)
        End Function
        
        Protected Overrides Sub OnRowChanged(ByVal e As DataRowChangeEventArgs)
            MyBase.OnRowChanged(e)
            If (Not (Me.WPGTotalsRowChangedEvent) Is Nothing) Then
                RaiseEvent WPGTotalsRowChanged(Me, New WPGTotalsRowChangeEvent(CType(e.Row,WPGTotalsRow), e.Action))
            End If
        End Sub
        
        Protected Overrides Sub OnRowChanging(ByVal e As DataRowChangeEventArgs)
            MyBase.OnRowChanging(e)
            If (Not (Me.WPGTotalsRowChangingEvent) Is Nothing) Then
                RaiseEvent WPGTotalsRowChanging(Me, New WPGTotalsRowChangeEvent(CType(e.Row,WPGTotalsRow), e.Action))
            End If
        End Sub
        
        Protected Overrides Sub OnRowDeleted(ByVal e As DataRowChangeEventArgs)
            MyBase.OnRowDeleted(e)
            If (Not (Me.WPGTotalsRowDeletedEvent) Is Nothing) Then
                RaiseEvent WPGTotalsRowDeleted(Me, New WPGTotalsRowChangeEvent(CType(e.Row,WPGTotalsRow), e.Action))
            End If
        End Sub
        
        Protected Overrides Sub OnRowDeleting(ByVal e As DataRowChangeEventArgs)
            MyBase.OnRowDeleting(e)
            If (Not (Me.WPGTotalsRowDeletingEvent) Is Nothing) Then
                RaiseEvent WPGTotalsRowDeleting(Me, New WPGTotalsRowChangeEvent(CType(e.Row,WPGTotalsRow), e.Action))
            End If
        End Sub
        
        Public Sub RemoveWPGTotalsRow(ByVal row As WPGTotalsRow)
            Me.Rows.Remove(row)
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThrough()>  _
    Public Class WPGTotalsRow
        Inherits DataRow
        
        Private tableWPGTotals As WPGTotalsDataTable
        
        Friend Sub New(ByVal rb As DataRowBuilder)
            MyBase.New(rb)
            Me.tableWPGTotals = CType(Me.Table,WPGTotalsDataTable)
        End Sub
        
        Public Property Name As String
            Get
                Return CType(Me(Me.tableWPGTotals.NameColumn),String)
            End Get
            Set
                Me(Me.tableWPGTotals.NameColumn) = value
            End Set
        End Property
        
        Public Property TranDate As Date
            Get
                Return CType(Me(Me.tableWPGTotals.TranDateColumn),Date)
            End Get
            Set
                Me(Me.tableWPGTotals.TranDateColumn) = value
            End Set
        End Property
        
        Public Property Weight As Decimal
            Get
                Try 
                    Return CType(Me(Me.tableWPGTotals.WeightColumn),Decimal)
                Catch e As InvalidCastException
                    Throw New StrongTypingException("Cannot get value because it is DBNull.", e)
                End Try
            End Get
            Set
                Me(Me.tableWPGTotals.WeightColumn) = value
            End Set
        End Property
        
        Public Function IsWeightNull() As Boolean
            Return Me.IsNull(Me.tableWPGTotals.WeightColumn)
        End Function
        
        Public Sub SetWeightNull()
            Me(Me.tableWPGTotals.WeightColumn) = System.Convert.DBNull
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThrough()>  _
    Public Class WPGTotalsRowChangeEvent
        Inherits EventArgs
        
        Private eventRow As WPGTotalsRow
        
        Private eventAction As DataRowAction
        
        Public Sub New(ByVal row As WPGTotalsRow, ByVal action As DataRowAction)
            MyBase.New
            Me.eventRow = row
            Me.eventAction = action
        End Sub
        
        Public ReadOnly Property Row As WPGTotalsRow
            Get
                Return Me.eventRow
            End Get
        End Property
        
        Public ReadOnly Property Action As DataRowAction
            Get
                Return Me.eventAction
            End Get
        End Property
    End Class
End Class
