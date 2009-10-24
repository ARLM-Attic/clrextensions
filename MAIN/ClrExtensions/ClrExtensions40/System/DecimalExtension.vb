'Copyright (c) 2008, Jonathan Allen
#If IncludeUntested Then


Public Module DecimalExtension

    ''' <summary>
    ''' Returns 10^N in decimal format
    ''' </summary>
    ''' <param name="exponent"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Untested()>
    Public Function Pow10(ByVal exponent As Integer) As Decimal
        Dim result As Decimal = 1
        If exponent > 0 Then
            For i = 1 To exponent
                result *= 10
            Next
        ElseIf exponent < 0 Then
            For i = exponent To -1
                result /= 10
            Next
        End If
        Return result
    End Function

	''' <summary>
	''' Truncates the decimal to the specified precision
	''' </summary>
	''' <param name="value"></param>
	''' <param name="precision">Number of decimal places to retain. If negative, number of zeros to the left of the decimal place.</param>
	''' <returns></returns>
    ''' <remarks></remarks>
    <Untested()>
    <Extension()> Public Function TruncatePrecision(ByVal value As Decimal, ByVal precision As Integer) As Decimal
        'TODO - determine if the "slow" method is actually slower 
        Try
            Dim precisionPower = Pow10(precision)
            Return Decimal.Truncate(value * precisionPower) / precisionPower
        Catch ex As OverflowException
            'Revert to slow method
            Dim literal = value.ToString

            Select Case precision
                Case Is > 0
                    Dim dotIndex = literal.IndexOf(".")
                    If dotIndex + precision + 1 > literal.Length Then Return CDec(literal.Substring(0, dotIndex + precision + 1))
                    Return value
                Case 0
                    Return CDec(literal.Substring(0, literal.IndexOf(".")))
                Case Else
                    Return CDec(literal.Substring(0, literal.IndexOf(".") + precision) & "0".Repeat(-1 * precision))
            End Select
        End Try
    End Function

#If IncludeUntested Then


#If ClrVersion >= 35 Then
    ''' <summary>
    ''' Returns the Root Mean Square of a list of values
    ''' </summary>
    ''' <param name="source"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Untested()> <Extension()> Function RootMeanSquare(ByVal source As IList(Of Decimal)) As Decimal
        Return CDec(Math.Sqrt((Aggregate item In source Into Sum(item * item)) / CDec(source.Count)))
    End Function


    ''' <summary>
    ''' Returns the most frequently encounted number. If there is a tie, they will all be returned
    ''' </summary>
    ''' <param name="source"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Untested()> <Extension()> Function Mode(ByVal source As IList(Of Decimal)) As List(Of Decimal)
        Dim counts = (From Value In source Group By Value Into Elements = Count()).ToList
        Dim maxCount = counts.Max(Function(x) x.Elements)
        Return (From item In counts Where item.Elements = maxCount Select item.Value).ToList
    End Function

    ''' <summary>
    ''' Returns the standard deviation of a list of numbers
    ''' </summary>
    ''' <param name="source"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Untested()> <Extension()> Function StandardDeviation(ByVal source As IList(Of Decimal)) As Decimal
        Dim step1 = source.Average 'mean
        Dim step2 = From item In source Select item - step1 'deviation from mean
        Dim step3 = From item In step2 Select item * item 'square of deviation from mean
        Dim step4 = step3.Average / step3.Count 'mean of square of deviation from mean
        Dim step5 = CDec(Math.Sqrt(step4)) 'Square root of mean of square of deviation from mean

        Return step5
    End Function


    ''' <summary>
    ''' Returns the Mean Absolute Error between a predicted and actual list
    ''' </summary>
    ''' <param name="predictedList"></param>
    ''' <param name="actualList"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    <Untested()> <Extension()> Function MeanAbsoluteError(ByVal predictedList As IList(Of Decimal), ByVal actualList As IList(Of Decimal)) As Decimal
        If predictedList.Count <> actualList.Count Then Throw New ArgumentException("Lists are of unequal length")
        Dim step1 = predictedList.Join(actualList, Function(predicted, actual) Math.Abs(predicted - actual))
        Dim step2 = (step1.Sum) / predictedList.Count
        Return step2
    End Function
#End If
#End If


End Module



#End If