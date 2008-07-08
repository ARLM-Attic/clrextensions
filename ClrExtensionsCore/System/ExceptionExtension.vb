<Obsolete("Untested")> Public Module ExceptionExtension
	'TODO Add a function to dump the detailed SQL exceptions that are not normally part of SqlException.ToString


    <Extension()> Public Function ToStringDetailed(ByVal Exception As Exception) As String
        Dim result As New Text.StringBuilder(Exception.ToString)

        If TypeOf Exception Is SqlClient.SqlException Then
            result.AppendLine()
            result.AppendLine(SqlExceptionDetails(DirectCast(Exception, SqlClient.SqlException)))
        End If


        Return result.ToString

    End Function



    <Extension()> Public Function SqlExceptionDetails(ByVal sqlException As SqlClient.SqlException) As String
        Dim result As New Text.StringBuilder(sqlException.ToString)

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


End Module
