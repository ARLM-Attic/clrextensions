Imports System.Data.SqlClient
Imports System.Text
Imports System.Runtime.CompilerServices

#If 1 = 1 Then

Namespace Data
	Module SqlClientExtensions
		
		<Extension()>
		Public Function ToSqlString(ByVal command As SqlCommand) As String
			If command Is Nothing Then Throw New ArgumentNullException("command", "command is nothing.")

			Dim out As New StringBuilder
			out.Append(command.CommandText)

			If command.Parameters.Count > 0 Then
				Dim stringParams = String.Join(", ", (From p In command.Parameters.Cast(Of SqlClient.SqlParameter)() Select sp = ToSqlString(p)).ToArray)
				out.Append(" ")
				out.Append(stringParams)
			End If

			Return out.ToString
		End Function

		
		<Extension()>
		Public Function ToSqlString(ByVal parameter As SqlParameter) As String
			If parameter Is Nothing Then Throw New ArgumentNullException("parameter", "parameter is nothing.")

			If parameter.Value Is Nothing Then
				Return parameter.ParameterName & " = NULL"
			ElseIf parameter.Value Is DBNull.Value Then
				Return parameter.ParameterName & " = NULL"
			ElseIf TypeOf parameter.Value Is String Or TypeOf parameter.Value Is Date Or TypeOf parameter.Value Is TimeSpan Then
				Return parameter.ParameterName & " = '" & parameter.Value.ToString & "'"
			Else
				Return parameter.ParameterName & " = " & parameter.Value.ToString
			End If
		End Function
	End Module
End Namespace

#End If
