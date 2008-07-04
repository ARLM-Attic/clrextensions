<Obsolete("Untested")> Public Module LongExtension

	Private Const GB As Long = CLng(1024 ^ 3)
	Private Const MB As Long = CLng(1024 ^ 2)
	Private Const KB As Long = CLng(1024 ^ 1)
	Private Const B As Long = 1



	<Extension()> Public Function ToByteSize(ByVal bytes As Long) As String
		Select Case CDbl(bytes)
			Case Is >= GB
				Return (bytes / (GB)).ToString("##0.##") & " GB"
			Case Is >= MB
				Return (bytes / MB).ToString("##0.##") & " MB"
			Case Is >= KB
				Return (bytes / KB).ToString("##0.##") & " KB"
			Case Else
				Return bytes & " B"
		End Select
	End Function


	<Extension()> Public Function ParseByteSize(ByVal this As String) As Long
		If this Is Nothing Then Throw New ArgumentNullException("this")


		Dim temp As String = this.Replace(" ", "").ToUpper

		Try
			If temp.EndsWith("GB") Then
				Return CLng(GB * CDec(temp.Substring(0, temp.Length - 2)))
			ElseIf temp.EndsWith("MB") Then
				Return CLng(MB * CDec(temp.Substring(0, temp.Length - 2)))
			ElseIf temp.EndsWith("KB") Then
				Return CLng(KB * CDec(temp.Substring(0, temp.Length - 2)))
			ElseIf temp.EndsWith("B") Then
				Return CLng(temp.Substring(0, temp.Length - 1))
			Else
				Return CLng(temp)
			End If
		Catch ex As OverflowException
			Throw New FormatException("Cannot parse string")
		End Try

	End Function
End Module




