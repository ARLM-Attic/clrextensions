Imports System.Linq.Expressions

#If IncludeUntested Then

Namespace CodeGeneration
	Public Module ExpressionUtilities

		<Untested()> Public Function CreateFunction(Of TArg1, TResult)(ByVal body As Func(Of Expression, UnaryExpression)) As Func(Of TArg1, TResult)
			Dim arg1 = Expression.Parameter(GetType(Integer), "arg1")
			Return DirectCast(Expression.Lambda(body(arg1), arg1).Compile, Global.System.Func(Of TArg1, TResult))
		End Function

		<Untested()> Public Function CreateFunction(Of TArg1, TArg2, TResult)(ByVal body As Func(Of Expression, Expression, BinaryExpression)) As Func(Of TArg1, TArg2, TResult)
			Dim arg1 = Expression.Parameter(GetType(Integer), "arg1")
			Dim arg2 = Expression.Parameter(GetType(Integer), "arg2")
			Return DirectCast(Expression.Lambda(body(arg1, arg2), arg1, arg2).Compile, Global.System.Func(Of TArg1, TArg2, TResult))
		End Function

	End Module

	''' <summary>
	''' 
	''' </summary>
	''' <typeparam name="T"></typeparam>
	''' <remarks>All of the functions are lazy-loaded</remarks>
	<Untested()> Public Class MathOperators(Of T)

		<Untested()> Public Function Add() As Func(Of T, T, T)
			Static m_Add As Func(Of T, T, T) = CreateFunction(Of T, T, T)(AddressOf Expression.AddChecked)
			Return m_Add
		End Function

		<Untested()> Public Function Subtract() As Func(Of T, T, T)
			Static m_Add As Func(Of T, T, T) = CreateFunction(Of T, T, T)(AddressOf Expression.SubtractChecked)
			Return m_Add
		End Function

	End Class
End Namespace

#End If