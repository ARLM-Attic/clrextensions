Imports System.Text
#If ClrVersion > 0 Then
Imports System.Data
#End If

'Copyright (c) 2008, Jonathan Allen



#If 1 = 1 Then

Public Module ExceptionExtension


    ''' <summary>
    ''' Gets detailed information from an exception object and all its inner exceptions
    ''' </summary>
    ''' <param name="Exception"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
     <Extension()>  Function ToStringDetailed(ByVal exception As Exception) As String
        If exception Is Nothing Then Throw New ArgumentNullException("exception")

        Dim result As New StringBuilder()

        Dim localException = exception

        Do Until localException Is Nothing
            result.AppendLine(exception.ToString)

#If ClrVersion > 0 Then
            If TypeOf exception Is SqlClient.SqlException Then
                result.AppendLine()
                result.AppendLine(SqlExceptionDetails(DirectCast(exception, SqlClient.SqlException)))
            End If
#End If

            'TODO - Add any other 'tricky' exceptions here

            localException = exception.InnerException
        Loop


        Return result.ToString

    End Function

#If ClrVersion > 0 Then

    ''' <summary>
    ''' Returns the detailed exception information from a SqlException, including its error collection
    ''' </summary>
    ''' <param name="sqlException"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
     <Extension()>  Function SqlExceptionDetails(ByVal sqlException As SqlClient.SqlException) As String
        If sqlException Is Nothing Then Throw New ArgumentNullException("sqlException")

        Dim result As New StringBuilder(sqlException.ToString)

        result.AppendLine("SQL Exception Details")

        result.AppendLine(vbTab & "ErrorCode: " & sqlException.ErrorCode)
        result.AppendLine(vbTab & "Source: " & sqlException.Source)
        result.AppendLine(vbTab & "Number: " & sqlException.Number)
        result.AppendLine(vbTab & "State: " & sqlException.State)
        result.AppendLine(vbTab & "Class: " & sqlException.Class)
        result.AppendLine(vbTab & "Server: " & sqlException.Server)
        result.AppendLine(vbTab & "Message: " & sqlException.Message)
        result.AppendLine(vbTab & "Procedure: " & sqlException.Procedure)
        result.AppendLine(vbTab & "LineNumber: " & sqlException.LineNumber)

        For i As Integer = 0 To sqlException.Errors.Count - 1 Step 1
            Dim item = sqlException.Errors(i)

            result.AppendLine(vbTab & "Error Index #" & i)
            result.AppendLine(vbTab & vbTab & "Source: " & item.Source)
            result.AppendLine(vbTab & vbTab & "Number: " & item.Number)
            result.AppendLine(vbTab & vbTab & "State: " & item.State)
            result.AppendLine(vbTab & vbTab & "Class: " & item.Class)
            result.AppendLine(vbTab & vbTab & "Server: " & item.Server)
            result.AppendLine(vbTab & vbTab & "Message: " & item.Message)
            result.AppendLine(vbTab & vbTab & "Procedure: " & item.Procedure)
            result.AppendLine(vbTab & vbTab & "LineNumber: " & item.LineNumber)
        Next

        Return result.ToString
    End Function
#End If

End Module
#End If
