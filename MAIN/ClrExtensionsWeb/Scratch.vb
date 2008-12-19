Imports System.Web
Imports System.Web.Script.Serialization
Imports System.Runtime.Serialization.Json
Imports System.IO

Public Module Scratch
	Sub test()

	End Sub
End Module

Public Module ObjectExtension
	Public Function ToContractJson(Of T)(ByVal this As T) As String
		Dim serializer = New DataContractJsonSerializer(GetType(T))

        Dim stream = New MemoryStream()
		serializer.WriteObject(stream, this)

		Return Text.Encoding.UTF8.GetString(stream.ToArray())
	End Function

	Public Function FromContractJson(Of T)(ByVal this As String) As T
        Dim stream = New MemoryStream(Text.Encoding.UTF8.GetBytes(this))

		Dim serializer = New DataContractJsonSerializer(GetType(T))
		Return CType(serializer.ReadObject(stream), T)
	End Function

End Module