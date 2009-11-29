﻿'Copyright (c) 2008, Jonathan Allen

Imports System.data
Imports ClrExtensions.Collections

#If IncludeUntested Then


Public Module EnumerableExtension

    ''' <summary>
    ''' This converts an IEnumerable to an IEnumerable(Of Object)
    ''' </summary>
    ''' <param name="this"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Pure()> <Untested()> <Extension()> Public Function ToIEnumerable(ByVal this As IEnumerable) As IEnumerable(Of Object)
        Contract.Ensures(Contract.Result(Of IEnumerable(Of Object))() IsNot Nothing)
        Return New ObjectEnumerable(this)
    End Function

    ''' <summary>
    ''' This converts an IEnumerable to a strongly typed IEnumerable(Of T).
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="this"></param>
    ''' <returns></returns>
    ''' <remarks>This will throw an exception if one the values cannot be case into the correct type</remarks>
    <Pure()> <Untested()> <Extension()> Public Function ToIEnumerable(Of T)(ByVal this As IEnumerable) As IEnumerable(Of T)
        Contract.Ensures(Contract.Result(Of IEnumerable(Of T))() IsNot Nothing)
        Return New TypeEnumerable(Of T)(this)
    End Function

#If ClrVersion >= 35 Then
    ''' <summary>
    ''' This converts a collection of objects into a DataTable. The columns are determined by the properties of the specified type.
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="this"></param>
    ''' <returns></returns>
    ''' <remarks>Properties that only exist in subtypes will not be saved</remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")>
    <Untested()>
    <Extension()>
    <Pure()>
    Public Function ToDataTable(Of T)(ByVal this As IEnumerable(Of T)) As DataTable
        If this Is Nothing Then Throw New ArgumentNullException("this")
        Contract.Ensures(Contract.Result(Of DataTable)() IsNot Nothing)

        Dim result As New DataTable

        Dim props = (From p In GetType(T).GetProperties Where p.CanRead And p.GetGetMethod.GetParameters.Count = 0).ToList


        For Each prop In props
            result.Columns.Add(New DataColumn(prop.Name, prop.GetGetMethod.ReturnType))
        Next

        For Each item In this
            Dim row = result.NewRow
            For Each prop In props
                Try
                    row(prop.Name) = prop.GetValue(item, Nothing)
                Catch ex As Exception
                    'Errors are suppressed
                End Try
            Next
        Next

        Return result
    End Function


    ''' <summary>
    ''' This converts a collection of objects into a data table.
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="this"></param>
    ''' <param name="properties">The list of properties to be used as column names</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope")>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes")>
    <Pure()>
    <Untested()> <Extension()> Public Function ToDataTable(Of T)(ByVal this As IEnumerable(Of T), ByVal ParamArray properties() As String) As DataTable
        If this Is Nothing Then Throw New ArgumentNullException("this")
        If properties Is Nothing Then Throw New ArgumentNullException("properties")
        Contract.Ensures(Contract.Result(Of DataTable)() IsNot Nothing)

        Dim result As New DataTable

        'Create the list of properties from the names
        Dim allProps = (From p In GetType(T).GetProperties Where p.CanRead And p.GetGetMethod.GetParameters.Count = 0).ToList

        Dim props As New List(Of Reflection.PropertyInfo)
        For Each name In properties
            Dim n = name
            Dim prop = allProps.First(Function(p) p.Name = n)
            If prop IsNot Nothing Then props.Add(prop) Else Throw New ArgumentException("The property " & name & " couldn't be found or isn't compatible with this function.")
        Next

        For Each prop In props
            result.Columns.Add(New DataColumn(prop.Name, prop.GetGetMethod.ReturnType))
        Next

        For Each item In this
            Dim row = result.NewRow
            For Each prop In props
                Try
                    row(prop.Name) = prop.GetValue(item, Nothing)
                Catch ex As Exception
                    'Errors are suppressed
                End Try
            Next
        Next

        Return result
    End Function

#End If


    ''' <summary>
    ''' Performs the Action delegate on each item in the enumeration
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="this"></param>
    ''' <param name="action"></param>
    ''' <remarks></remarks>
    <Untested()> <Extension()> Public Sub ForEach(Of T)(ByVal this As IEnumerable(Of T), ByVal action As Action(Of T))
        If this Is Nothing Then Throw New ArgumentNullException("this")
        If action Is Nothing Then Throw New ArgumentNullException("action")
        Contract.EndContractBlock()

        For Each item In this
            action(item)
        Next
    End Sub

    ''' <summary>
    ''' Performs the Action delegate on each item in the enumeration
    ''' </summary>
    ''' <param name="this"></param>
    ''' <param name="action"></param>
    ''' <remarks></remarks>
    <Untested()> <Extension()> Public Sub ForEach(ByVal this As IEnumerable, ByVal action As Action(Of Object))
        If this Is Nothing Then Throw New ArgumentNullException("this")
        If action Is Nothing Then Throw New ArgumentNullException("action")
        Contract.EndContractBlock()

        For Each item In this
            action(item)
        Next
    End Sub


    ''' <summary>
    ''' Determines if the predicate is true for all items in the collection.
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="source"></param>
    ''' <param name="predicate">The predicate in the form of a Function(Of T, Boolean)</param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Pure()> <Untested()> <Extension()>
    Public Function TrueForAll(Of T)(ByVal source As IEnumerable(Of T), ByVal predicate As Func(Of T, Boolean)) As Boolean
        If source Is Nothing Then Throw New ArgumentNullException("source")
        If predicate Is Nothing Then Throw New ArgumentNullException("predicate")
        Contract.EndContractBlock()

        For Each item In source
            If Not predicate.Invoke(item) Then Return False
        Next
        Return True
    End Function

    ''' <summary>
    ''' Determines if the predicate is true for all items in the collection.
    ''' </summary>
    ''' <typeparam name="T"></typeparam>
    ''' <param name="source"></param>
    ''' <param name="predicate"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Pure()> <Untested()> <Extension()> Public Function TrueForAll(Of T)(ByVal source As IEnumerable(Of T), ByVal predicate As Predicate(Of T)) As Boolean
        If source Is Nothing Then Throw New ArgumentNullException("source")
        If predicate Is Nothing Then Throw New ArgumentNullException("predicate")
        Contract.EndContractBlock()

        For Each item In source
            If Not predicate.Invoke(item) Then Return False
        Next
        Return True
    End Function



End Module



#End If

