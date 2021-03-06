﻿'Copyright (c) 2008, Jonathan Allen

Public Module VBLanguageExtension




    ''' <summary>
    ''' Duplicates the functionality of CBool, but with support for nullable types
    ''' </summary>
    ''' <param name="value">Value to be converted into an integer</param>
    ''' <returns>This returns Nothing if the value is Nothing, DBNull, or an empty string</returns>
    ''' <remarks>This will throw the appropriate exception if the conversion fails</remarks>
    Public Function CBool2(ByVal value As Object) As Boolean?
        If value Is Nothing Then Return Nothing
        If value Is DBNull.Value Then Return Nothing
        If value.ToString = "" Then Return Nothing
        Return CBool(value)
    End Function

    ''' <summary>
    ''' Duplicates the functionality of CBool, but with support for nullable types
    ''' </summary>
    ''' <param name="value">Value to be converted into an integer</param>
    ''' <param name="default">Default value to be returned in the case of nulls</param>
    ''' <returns>This returns the default value if the value is Nothing, DBNull, or an empty string</returns>
    ''' <remarks>This will throw the appropriate exception if the conversion fails</remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId:="bool")>
    Public Function CBool2(ByVal value As Object, ByVal [default] As Boolean) As Boolean
        If value Is Nothing Then Return [default]
        If value Is DBNull.Value Then Return [default]
        If value.ToString = "" Then Return [default]
        Return CBool(value)
    End Function




    ''' <summary>
    ''' Duplicates the functionality of CByte, but with support for nullable types
    ''' </summary>
    ''' <param name="value">Value to be converted into an integer</param>
    ''' <returns>This returns Nothing if the value is Nothing, DBNull, or an empty string</returns>
    ''' <remarks>This will throw the appropriate exception if the conversion fails</remarks>
    Public Function CByte2(ByVal value As Object) As Byte?
        If value Is Nothing Then Return Nothing
        If value Is DBNull.Value Then Return Nothing
        If value.ToString = "" Then Return Nothing
        Return CByte(value)
    End Function

    ''' <summary>Nothing
    ''' Duplicates the functionality of CByte, but with support for nullable types
    ''' </summary>
    ''' <param name="value">Value to be converted into an integer</param>
    ''' <param name="default">Default value to be returned in the case of nulls</param>
    ''' <returns>This returns the default value if the value is Nothing, DBNull, or an empty string</returns>
    ''' <remarks>This will throw the appropriate exception if the conversion fails</remarks>
    Public Function CByte2(ByVal value As Object, ByVal [default] As Byte) As Byte
        If value Is Nothing Then Return [default]
        If value Is DBNull.Value Then Return [default]
        If value.ToString = "" Then Return [default]
        Return CByte(value)
    End Function




    ''' <summary>
    ''' Duplicates the functionality of CChar, but with support for nullable types
    ''' </summary>
    ''' <param name="value">Value to be converted into an integer</param>
    ''' <returns>This returns Nothing if the value is Nothing, DBNull, or an empty string</returns>
    ''' <remarks>This will throw the appropriate exception if the conversion fails</remarks>
    Public Function CChar2(ByVal value As Object) As Char?
        If value Is Nothing Then Return Nothing
        If value Is DBNull.Value Then Return Nothing
        If value.ToString = "" Then Return Nothing
        Return CChar(value)
    End Function

    ''' <summary>Nothing
    ''' Duplicates the functionality of CChar, but with support for nullable types
    ''' </summary>
    ''' <param name="value">Value to be converted into an integer</param>
    ''' <param name="default">Default value to be returned in the case of nulls</param>
    ''' <returns>This returns the default value if the value is Nothing, DBNull, or an empty string</returns>
    ''' <remarks>This will throw the appropriate exception if the conversion fails</remarks>
    Public Function CChar2(ByVal value As Object, ByVal [default] As Char) As Char
        If value Is Nothing Then Return [default]
        If value Is DBNull.Value Then Return [default]
        If value.ToString = "" Then Return [default]
        Return CChar(value)
    End Function

    ''' <summary>
    ''' Duplicates the functionality of CDate, but with support for nullable types
    ''' </summary>
    ''' <param name="value">Value to be converted into an integer</param>
    ''' <returns>This returns Nothing if the value is Nothing, DBNull, or an empty string</returns>
    ''' <remarks>This will throw the appropriate exception if the conversion fails</remarks>
    Public Function CDate2(ByVal value As Object) As Date?
        If value Is Nothing Then Return Nothing
        If value Is DBNull.Value Then Return Nothing
        If value.ToString = "" Then Return Nothing
        Return CDate(value)
    End Function

    ''' <summary>Nothing
    ''' Duplicates the functionality of CDate, but with support for nullable types
    ''' </summary>
    ''' <param name="value">Value to be converted into an integer</param>
    ''' <param name="default">Default value to be returned in the case of nulls</param>
    ''' <returns>This returns the default value if the value is Nothing, DBNull, or an empty string</returns>
    ''' <remarks>This will throw the appropriate exception if the conversion fails</remarks>
    Public Function CDate2(ByVal value As Object, ByVal [default] As Date) As Date
        If value Is Nothing Then Return [default]
        If value Is DBNull.Value Then Return [default]
        If value.ToString = "" Then Return [default]
        Return CDate(value)
    End Function





    ''' <summary>
    ''' Duplicates the functionality of CDbl, but with support for nullable types
    ''' </summary>
    ''' <param name="value">Value to be converted into an integer</param>
    ''' <returns>This returns Nothing if the value is Nothing, DBNull, or an empty string</returns>
    ''' <remarks>This will throw the appropriate exception if the conversion fails</remarks>
    Public Function CDbl2(ByVal value As Object) As Double?
        If value Is Nothing Then Return Nothing
        If value Is DBNull.Value Then Return Nothing
        If value.ToString = "" Then Return Nothing
        Return CDbl(value)
    End Function

    ''' <summary>Nothing
    ''' Duplicates the functionality of CDbl, but with support for nullable types
    ''' </summary>
    ''' <param name="value">Value to be converted into an integer</param>
    ''' <param name="default">Default value to be returned in the case of nulls</param>
    ''' <returns>This returns the default value if the value is Nothing, DBNull, or an empty string</returns>
    ''' <remarks>This will throw the appropriate exception if the conversion fails</remarks>
    Public Function CDbl2(ByVal value As Object, ByVal [default] As Double) As Double
        If value Is Nothing Then Return [default]
        If value Is DBNull.Value Then Return [default]
        If value.ToString = "" Then Return [default]
        Return CDbl(value)
    End Function

    ''' <summary>
    ''' Duplicates the functionality of CDec, but with support for nullable types
    ''' </summary>
    ''' <param name="value">Value to be converted into an integer</param>
    ''' <returns>This returns Nothing if the value is Nothing, DBNull, or an empty string</returns>
    ''' <remarks>This will throw the appropriate exception if the conversion fails</remarks>
    Public Function CDec2(ByVal value As Object) As Decimal?
        If value Is Nothing Then Return Nothing
        If value Is DBNull.Value Then Return Nothing
        If value.ToString = "" Then Return Nothing
        Return CDec(value)
    End Function

    ''' <summary>Nothing
    ''' Duplicates the functionality of CDec, but with support for nullable types
    ''' </summary>
    ''' <param name="value">Value to be converted into an integer</param>
    ''' <param name="default">Default value to be returned in the case of nulls</param>
    ''' <returns>This returns the default value if the value is Nothing, DBNull, or an empty string</returns>
    ''' <remarks>This will throw the appropriate exception if the conversion fails</remarks>
    Public Function CDec2(ByVal value As Object, ByVal [default] As Decimal) As Decimal
        If value Is Nothing Then Return [default]
        If value Is DBNull.Value Then Return [default]
        If value.ToString = "" Then Return [default]
        Return CDec(value)
    End Function



    ''' <summary>
    ''' Duplicates the functionality of CSByte, but with support for nullable types
    ''' </summary>
    ''' <param name="value">Value to be converted into an integer</param>
    ''' <returns>This returns Nothing if the value is Nothing, DBNull, or an empty string</returns>
    ''' <remarks>This will throw the appropriate exception if the conversion fails</remarks>
    <CLSCompliant(False)>
    Public Function CSByte2(ByVal value As Object) As SByte?
        If value Is Nothing Then Return Nothing
        If value Is DBNull.Value Then Return Nothing
        If value.ToString = "" Then Return Nothing
        Return CSByte(value)
    End Function

    ''' <summary>Nothing
    ''' Duplicates the functionality of CSByte, but with support for nullable types
    ''' </summary>
    ''' <param name="value">Value to be converted into an integer</param>
    ''' <param name="default">Default value to be returned in the case of nulls</param>
    ''' <returns>This returns the default value if the value is Nothing, DBNull, or an empty string</returns>
    ''' <remarks>This will throw the appropriate exception if the conversion fails</remarks>
    <CLSCompliant(False)>
    Public Function CSByte2(ByVal value As Object, ByVal [default] As SByte) As SByte
        If value Is Nothing Then Return [default]
        If value Is DBNull.Value Then Return [default]
        If value.ToString = "" Then Return [default]
        Return CSByte(value)
    End Function




    ''' <summary>
    ''' Duplicates the functionality of CShort, but with support for nullable types
    ''' </summary>
    ''' <param name="value">Value to be converted into an integer</param>
    ''' <returns>This returns Nothing if the value is Nothing, DBNull, or an empty string</returns>
    ''' <remarks>This will throw the appropriate exception if the conversion fails</remarks>
    Public Function CShort2(ByVal value As Object) As Short?
        If value Is Nothing Then Return Nothing
        If value Is DBNull.Value Then Return Nothing
        If value.ToString = "" Then Return Nothing
        Return CShort(value)
    End Function

    ''' <summary>Nothing
    ''' Duplicates the functionality of CShort, but with support for nullable types
    ''' </summary>
    ''' <param name="value">Value to be converted into an integer</param>
    ''' <param name="default">Default value to be returned in the case of nulls</param>
    ''' <returns>This returns the default value if the value is Nothing, DBNull, or an empty string</returns>
    ''' <remarks>This will throw the appropriate exception if the conversion fails</remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId:="short")>
    Public Function CShort2(ByVal value As Object, ByVal [default] As Short) As Short
        If value Is Nothing Then Return [default]
        If value Is DBNull.Value Then Return [default]
        If value.ToString = "" Then Return [default]
        Return CShort(value)
    End Function




    ''' <summary>
    ''' Duplicates the functionality of CInt, but with support for nullable types
    ''' </summary>
    ''' <param name="value">Value to be converted into an integer</param>
    ''' <returns>This returns Nothing if the value is Nothing, DBNull, or an empty string</returns>
    ''' <remarks>This will throw the appropriate exception if the conversion fails</remarks>
    Public Function CInt2(ByVal value As Object) As Integer?
        If value Is Nothing Then Return Nothing
        If value Is DBNull.Value Then Return Nothing
        If value.ToString = "" Then Return Nothing
        Return CInt(value)
    End Function

    ''' <summary>Nothing
    ''' Duplicates the functionality of CInt, but with support for nullable types
    ''' </summary>
    ''' <param name="value">Value to be converted into an integer</param>
    ''' <param name="default">Default value to be returned in the case of nulls</param>
    ''' <returns>This returns the default value if the value is Nothing, DBNull, or an empty string</returns>
    ''' <remarks>This will throw the appropriate exception if the conversion fails</remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId:="int")>
    Public Function CInt2(ByVal value As Object, ByVal [default] As Integer) As Integer
        If value Is Nothing Then Return [default]
        If value Is DBNull.Value Then Return [default]
        If value.ToString = "" Then Return [default]
        Return CInt(value)
    End Function

    ''' <summary>
    ''' Duplicates the functionality of CLng, but with support for nullable types
    ''' </summary>
    ''' <param name="value">Value to be converted into an integer</param>
    ''' <returns>This returns Nothing if the value is Nothing, DBNull, or an empty string</returns>
    ''' <remarks>This will throw the appropriate exception if the conversion fails</remarks>
    Public Function CLng2(ByVal value As Object) As Long?
        If value Is Nothing Then Return Nothing
        If value Is DBNull.Value Then Return Nothing
        If value.ToString = "" Then Return Nothing
        Return CLng(value)
    End Function

    ''' <summary>Nothing
    ''' Duplicates the functionality of CLng, but with support for nullable types
    ''' </summary>
    ''' <param name="value">Value to be converted into an integer</param>
    ''' <param name="default">Default value to be returned in the case of nulls</param>
    ''' <returns>This returns the default value if the value is Nothing, DBNull, or an empty string</returns>
    ''' <remarks>This will throw the appropriate exception if the conversion fails</remarks>
    Public Function CLng2(ByVal value As Object, ByVal [default] As Long) As Long
        If value Is Nothing Then Return [default]
        If value Is DBNull.Value Then Return [default]
        If value.ToString = "" Then Return [default]
        Return CLng(value)
    End Function









    ''' <summary>
    ''' Duplicates the functionality of CSng, but with support for nullable types
    ''' </summary>
    ''' <param name="value">Value to be converted into an integer</param>
    ''' <returns>This returns Nothing if the value is Nothing, DBNull, or an empty string</returns>
    ''' <remarks>This will throw the appropriate exception if the conversion fails</remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId:="Sng")>
    Public Function CSng2(ByVal value As Object) As Single?
        If value Is Nothing Then Return Nothing
        If value Is DBNull.Value Then Return Nothing
        If value.ToString = "" Then Return Nothing
        Return CSng(value)
    End Function

    ''' <summary>Nothing
    ''' Duplicates the functionality of CSng, but with support for nullable types
    ''' </summary>
    ''' <param name="value">Value to be converted into an integer</param>
    ''' <param name="default">Default value to be returned in the case of nulls</param>
    ''' <returns>This returns the default value if the value is Nothing, DBNull, or an empty string</returns>
    ''' <remarks>This will throw the appropriate exception if the conversion fails</remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId:="Sng")>
    Public Function CSng2(ByVal value As Object, ByVal [default] As Single) As Single
        If value Is Nothing Then Return [default]
        If value Is DBNull.Value Then Return [default]
        If value.ToString = "" Then Return [default]
        Return CSng(value)
    End Function







    ''' <summary>
    ''' Duplicates the functionality of CUInt, but with support for nullable types
    ''' </summary>
    ''' <param name="value">Value to be converted into an integer</param>
    ''' <returns>This returns Nothing if the value is Nothing, DBNull, or an empty string</returns>
    ''' <remarks>This will throw the appropriate exception if the conversion fails</remarks>
    <CLSCompliant(False)>
    Public Function CUInt2(ByVal value As Object) As UInteger?
        If value Is Nothing Then Return Nothing
        If value Is DBNull.Value Then Return Nothing
        If value.ToString = "" Then Return Nothing
        Return CUInt(value)
    End Function

    ''' <summary>Nothing
    ''' Duplicates the functionality of CUInt, but with support for nullable types
    ''' </summary>
    ''' <param name="value">Value to be converted into an integer</param>
    ''' <param name="default">Default value to be returned in the case of nulls</param>
    ''' <returns>This returns the default value if the value is Nothing, DBNull, or an empty string</returns>
    ''' <remarks>This will throw the appropriate exception if the conversion fails</remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId:="int")> <CLSCompliant(False)>
    Public Function CUInt2(ByVal value As Object, ByVal [default] As UInteger) As UInteger
        If value Is Nothing Then Return [default]
        If value Is DBNull.Value Then Return [default]
        If value.ToString = "" Then Return [default]
        Return CUInt(value)
    End Function

    ''' <summary>Nothing
    ''' Duplicates the functionality of CULng, but with support for nullable types
    ''' </summary>
    ''' <param name="value">Value to be converted into an integer</param>
    ''' <param name="default">Default value to be returned in the case of nulls</param>
    ''' <returns>This returns the default value if the value is Nothing, DBNull, or an empty string</returns>
    ''' <remarks>This will throw the appropriate exception if the conversion fails</remarks>
    <CLSCompliant(False)>
    Public Function CULng2(ByVal value As Object, ByVal [default] As ULong) As ULong
        If value Is Nothing Then Return [default]
        If value Is DBNull.Value Then Return [default]
        If value.ToString = "" Then Return [default]
        Return CULng(value)
    End Function





    ''' <summary>
    ''' Duplicates the functionality of CUShort, but with support for nullable types
    ''' </summary>
    ''' <param name="value">Value to be converted into an integer</param>
    ''' <returns>This returns Nothing if the value is Nothing, DBNull, or an empty string</returns>
    ''' <remarks>This will throw the appropriate exception if the conversion fails</remarks>
    <CLSCompliant(False)>
    Public Function CUShort2(ByVal value As Object) As UShort?
        If value Is Nothing Then Return Nothing
        If value Is DBNull.Value Then Return Nothing
        If value.ToString = "" Then Return Nothing
        Return CUShort(value)
    End Function

    ''' <summary>
    ''' Duplicates the functionality of CStr, but with support for database nulls
    ''' </summary>
    ''' <param name="value">Value to be converted into a string</param>
    ''' <param name="default">Default value to be returned in the case of nulls</param>
    ''' <returns>This returns the default value if the value is Nothing, or an empty string. </returns>
    ''' <remarks>This will throw the appropriate exception if the conversion fails</remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId:="Str")>
    Public Function CStr2(ByVal value As Object, ByVal [default] As String) As String
        Return ObjectExtension.ToStringSafe(value, [default])
    End Function

    ''' <summary>
    ''' Duplicates the functionality of CStr, but with support for database nulls
    ''' </summary>
    ''' <param name="value">Value to be converted into an integer</param>
    ''' <returns>This returns Nothing if the value is Nothing or DBNull</returns>
    ''' <remarks>This will throw the appropriate exception if the conversion fails</remarks>
    <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId:="Str")>
    Public Function CStr2(ByVal value As Object) As String
        Return ObjectExtension.ToStringSafe(value)
    End Function


    '''' <summary>
    '''' Duplicates the functionality of CStr, but with better handling for nullable value types
    '''' </summary>
    '''' <typeparam name="T">Type of nullable value being converted</typeparam>
    '''' <param name="value">Value being checked</param>
    '''' <returns>This returns Nothing or the result of calling ToString.</returns>
    '''' <remarks></remarks>
    Public Function CStr2(Of T As Structure)(ByVal value As Nullable(Of T)) As String
        If value.HasValue Then Return value.ToString Else Return Nothing
    End Function

    '''' <summary>
    '''' Duplicates the functionality of CStr, but with better handling for nullable value types
    '''' </summary>
    '''' <typeparam name="T">Type of nullable value being converted</typeparam>
    '''' <param name="value">Value being checked</param>
    '''' <param name="default">Default value to be returned in the case of nulls</param>
    '''' <returns>This returns Nothing or the result of calling ToString.</returns>
    '''' <remarks></remarks>
    Public Function CStr2(Of T As Structure)(ByVal value As Nullable(Of T), ByVal [default] As String) As String
        If value.HasValue Then Return value.ToString Else Return [default]
    End Function

    ''' <summary>
    ''' Duplicates the functionality of CByte, but with the semantics of TryCast
    ''' </summary>
    ''' <param name="value">Value to be converted into an integer</param>
    ''' <returns>This returns Nothing if the value is Nothing, DBNull, or an empty string</returns>
    ''' <remarks>This will return nothing if the conversion fails</remarks>
    Public Function TryCByte(ByVal value As Object) As Byte?
        If value Is Nothing Then Return Nothing
        If value Is DBNull.Value Then Return Nothing
        If value.ToString = "" Then Return Nothing
        Try
            Return CByte(value)
        Catch ex As FormatException
            Return Nothing
        Catch ex As InvalidCastException
            Return Nothing
        Catch ex As OverflowException
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Duplicates the functionality of CDate, but with the semantics of TryCast
    ''' </summary>
    ''' <param name="value">Value to be converted into an integer</param>
    ''' <returns>This returns Nothing if the value is Nothing, DBNull, or an empty string</returns>
    ''' <remarks>This will return nothing if the conversion fails</remarks>
    Public Function TryCDate(ByVal value As Object) As Date?
        If value Is Nothing Then Return Nothing
        If value Is DBNull.Value Then Return Nothing
        If value.ToString = "" Then Return Nothing
        Try
            Return CDate(value)
        Catch ex As FormatException
            Return Nothing
        Catch ex As InvalidCastException
            Return Nothing
        Catch ex As OverflowException
            Return Nothing
        End Try
    End Function


    ''' <summary>
    ''' Duplicates the functionality of CDec, but with the semantics of TryCast
    ''' </summary>
    ''' <param name="value">Value to be converted into an integer</param>
    ''' <returns>This returns Nothing if the value is Nothing, DBNull, or an empty string</returns>
    ''' <remarks>This will return nothing if the conversion fails</remarks>
    Public Function TryCDec(ByVal value As Object) As Decimal?
        If value Is Nothing Then Return Nothing
        If value Is DBNull.Value Then Return Nothing
        If value.ToString = "" Then Return Nothing
        Try
            Return CDec(value)
        Catch ex As FormatException
            Return Nothing
        Catch ex As InvalidCastException
            Return Nothing
        Catch ex As OverflowException
            Return Nothing
        End Try
    End Function


    ''' <summary>
    ''' Duplicates the functionality of CShort, but with the semantics of TryCast
    ''' </summary>
    ''' <param name="value">Value to be converted into an integer</param>
    ''' <returns>This returns Nothing if the value is Nothing, DBNull, or an empty string</returns>
    ''' <remarks>This will return nothing if the conversion fails</remarks>
    Public Function TryCShort(ByVal value As Object) As Short?
        If value Is Nothing Then Return Nothing
        If value Is DBNull.Value Then Return Nothing
        If value.ToString = "" Then Return Nothing
        Try
            Return CShort(value)
        Catch ex As FormatException
            Return Nothing
        Catch ex As InvalidCastException
            Return Nothing
        Catch ex As OverflowException
            Return Nothing
        End Try
    End Function

    ''' <summary>
    ''' Duplicates the functionality of CLng, but with the semantics of TryCast
    ''' </summary>
    ''' <param name="value">Value to be converted into an integer</param>
    ''' <returns>This returns Nothing if the value is Nothing, DBNull, or an empty string</returns>
    ''' <remarks>This will return nothing if the conversion fails</remarks>
	Public Function TryCLng(ByVal value As Object) As Long?
		If value Is Nothing Then Return Nothing
		If value Is DBNull.Value Then Return Nothing
		If value.ToString = "" Then Return Nothing
		Try
			Return CLng(value)
		Catch ex As FormatException
			Return Nothing
		Catch ex As InvalidCastException
			Return Nothing
		Catch ex As OverflowException
			Return Nothing
		End Try
	End Function


    ''' <summary>
    ''' Duplicates the functionality of CUInt, but with the semantics of TryCast
    ''' </summary>
    ''' <param name="value">Value to be converted into an integer</param>
    ''' <returns>This returns Nothing if the value is Nothing, DBNull, or an empty string</returns>
    ''' <remarks>This will return nothing if the conversion fails</remarks>
	<CLSCompliant(False)>
	Public Function TryCUInt(ByVal value As Object) As UInteger?
		If value Is Nothing Then Return Nothing
		If value Is DBNull.Value Then Return Nothing
		If value.ToString = "" Then Return Nothing
		Try
			Return CUInt(value)
		Catch ex As FormatException
			Return Nothing
		Catch ex As InvalidCastException
			Return Nothing
		Catch ex As OverflowException
			Return Nothing
		End Try
	End Function


    ''' <summary>Nothing
    ''' Duplicates the functionality of CUShort, but with support for nullable types
    ''' </summary>
    ''' <param name="value">Value to be converted into an integer</param>
    ''' <param name="default">Default value to be returned in the case of nulls</param>
    ''' <returns>This returns the default value if the value is Nothing, DBNull, or an empty string</returns>
    ''' <remarks>This will throw the appropriate exception if the conversion fails</remarks>
	<System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1720:IdentifiersShouldNotContainTypeNames", MessageId:="short")> <CLSCompliant(False)>
	Public Function CUShort2(ByVal value As Object, ByVal [default] As UShort) As UShort
		If value Is Nothing Then Return [default]
		If value Is DBNull.Value Then Return [default]
		If value.ToString = "" Then Return [default]
		Return CUShort(value)
	End Function

    ''' <summary>
    ''' Duplicates the functionality of CBool, but with the semantics of TryCast
    ''' </summary>
    ''' <param name="value">Value to be converted into an integer</param>
    ''' <returns>This returns Nothing if the value is Nothing, DBNull, or an empty string</returns>
    ''' <remarks>This will return nothing if the conversion fails</remarks>
	Public Function TryCBool(ByVal value As Object) As Boolean?
		If value Is Nothing Then Return Nothing
		If value Is DBNull.Value Then Return Nothing
		If value.ToString = "" Then Return Nothing
		Try
			Return CBool(value)
		Catch ex As FormatException
			Return Nothing
		Catch ex As InvalidCastException
			Return Nothing
		Catch ex As OverflowException
			Return Nothing
		End Try
	End Function

    ''' <summary>
    ''' Duplicates the functionality of CDbl, but with the semantics of TryCast
    ''' </summary>
    ''' <param name="value">Value to be converted into an integer</param>
    ''' <returns>This returns Nothing if the value is Nothing, DBNull, or an empty string</returns>
    ''' <remarks>This will return nothing if the conversion fails</remarks>
	Public Function TryCDbl(ByVal value As Object) As Double?
		If value Is Nothing Then Return Nothing
		If value Is DBNull.Value Then Return Nothing
		If value.ToString = "" Then Return Nothing
		Try
			Return CDbl(value)
		Catch ex As FormatException
			Return Nothing
		Catch ex As InvalidCastException
			Return Nothing
		Catch ex As OverflowException
			Return Nothing
		End Try
	End Function

    ''' <summary>
    ''' Duplicates the functionality of CInt, but with the semantics of TryCast
    ''' </summary>
    ''' <param name="value">Value to be converted into an integer</param>
    ''' <returns>This returns Nothing if the value is Nothing, DBNull, or an empty string</returns>
    ''' <remarks>This will return nothing if the conversion fails</remarks>
	Public Function TryCInt(ByVal value As Object) As Integer?
		If value Is Nothing Then Return Nothing
		If value Is DBNull.Value Then Return Nothing
		If value.ToString = "" Then Return Nothing
		Try
			Return CInt(value)
		Catch ex As FormatException
			Return Nothing
		Catch ex As InvalidCastException
			Return Nothing
		Catch ex As OverflowException
			Return Nothing
		End Try
	End Function

    ''' <summary>
    ''' Duplicates the functionality of CULng, but with support for nullable types
    ''' </summary>
    ''' <param name="value">Value to be converted into an integer</param>
    ''' <returns>This returns Nothing if the value is Nothing, DBNull, or an empty string</returns>
    ''' <remarks>This will throw the appropriate exception if the conversion fails</remarks>
	<CLSCompliant(False)>
	Public Function CULng2(ByVal value As Object) As ULong?
		If value Is Nothing Then Return Nothing
		If value Is DBNull.Value Then Return Nothing
		If value.ToString = "" Then Return Nothing
		Return CULng(value)
	End Function

    ''' <summary>
    ''' Duplicates the functionality of CUShort, but with the semantics of TryCast
    ''' </summary>
    ''' <param name="value">Value to be converted into an integer</param>
    ''' <returns>This returns Nothing if the value is Nothing, DBNull, or an empty string</returns>
    ''' <remarks>This will return nothing if the conversion fails</remarks>
	<CLSCompliant(False)>
	Public Function TryCUShort(ByVal value As Object) As UShort?
		If value Is Nothing Then Return Nothing
		If value Is DBNull.Value Then Return Nothing
		If value.ToString = "" Then Return Nothing
		Try
			Return CUShort(value)
		Catch ex As FormatException
			Return Nothing
		Catch ex As InvalidCastException
			Return Nothing
		Catch ex As OverflowException
			Return Nothing
		End Try
	End Function

    ''' <summary>
    ''' Duplicates the functionality of CChar, but with the semantics of TryCast
    ''' </summary>
    ''' <param name="value">Value to be converted into an integer</param>
    ''' <returns>This returns Nothing if the value is Nothing, DBNull, or an empty string</returns>
    ''' <remarks>This will return nothing if the conversion fails</remarks>
	Public Function TryCChar(ByVal value As Object) As Char?
		If value Is Nothing Then Return Nothing
		If value Is DBNull.Value Then Return Nothing
		If value.ToString = "" Then Return Nothing
		Try
			Return CChar(value)
		Catch ex As FormatException
			Return Nothing
		Catch ex As InvalidCastException
			Return Nothing
		Catch ex As OverflowException
			Return Nothing
		End Try
	End Function

    ''' <summary>
    ''' Duplicates the functionality of CSng, but with the semantics of TryCast
    ''' </summary>
    ''' <param name="value">Value to be converted into an integer</param>
    ''' <returns>This returns Nothing if the value is Nothing, DBNull, or an empty string</returns>
    ''' <remarks>This will return nothing if the conversion fails</remarks>
	<System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId:="Sng")>
	Public Function TryCSng(ByVal value As Object) As Single?
		If value Is Nothing Then Return Nothing
		If value Is DBNull.Value Then Return Nothing
		If value.ToString = "" Then Return Nothing
		Try
			Return CSng(value)
		Catch ex As FormatException
			Return Nothing
		Catch ex As InvalidCastException
			Return Nothing
		Catch ex As OverflowException
			Return Nothing
		End Try
	End Function

    ''' <summary>
    ''' Duplicates the functionality of CSByte, but with the semantics of TryCast
    ''' </summary>
    ''' <param name="value">Value to be converted into an integer</param>
    ''' <returns>This returns Nothing if the value is Nothing, DBNull, or an empty string</returns>
    ''' <remarks>This will return nothing if the conversion fails</remarks>
	<CLSCompliant(False)>
	Public Function TryCSByte(ByVal value As Object) As SByte?
		If value Is Nothing Then Return Nothing
		If value Is DBNull.Value Then Return Nothing
		If value.ToString = "" Then Return Nothing
		Try
			Return CSByte(value)
		Catch ex As FormatException
			Return Nothing
		Catch ex As InvalidCastException
			Return Nothing
		Catch ex As OverflowException
			Return Nothing
		End Try
	End Function

    ''' <summary>
    ''' Duplicates the functionality of CULng, but with the semantics of TryCast
    ''' </summary>
    ''' <param name="value">Value to be converted into an integer</param>
    ''' <returns>This returns Nothing if the value is Nothing, DBNull, or an empty string</returns>
    ''' <remarks>This will return nothing if the conversion fails</remarks>
	<CLSCompliant(False)>
	Public Function TryCULng(ByVal value As Object) As ULong?
		If value Is Nothing Then Return Nothing
		If value Is DBNull.Value Then Return Nothing
		If value.ToString = "" Then Return Nothing
		Try
			Return CULng(value)
		Catch ex As FormatException
			Return Nothing
		Catch ex As InvalidCastException
			Return Nothing
		Catch ex As OverflowException
			Return Nothing
		End Try
	End Function


	Public Function CTimeSpan(ByVal value As Object) As TimeSpan
		If TypeOf value Is String Then Return TimeSpan.Parse(CStr(value))
		Return CType(value, TimeSpan)
	End Function

	Public Function CTimeSpan2(ByVal value As Object, ByVal [default] As TimeSpan) As TimeSpan
		If value Is Nothing Then Return [default]
		If value Is DBNull.Value Then Return [default]
		If value.ToString = "" Then Return [default]

        Return CTimeSpan(value)
	End Function

	Public Function CTimeSpan2(ByVal value As Object) As TimeSpan?
		If value Is Nothing Then Return Nothing
		If value Is DBNull.Value Then Return Nothing
		If value.ToString = "" Then Return Nothing

		Return CTimeSpan(value)
	End Function

End Module
