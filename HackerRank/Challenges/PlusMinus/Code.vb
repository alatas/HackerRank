'Plus Minus
'https://www.hackerrank.com/challenges/plus-minus
'Score 10
Imports System
Imports System.Collections.Generic
Imports System.Globalization

Module PlusMinus
    Sub Main()
        Dim n As Decimal = Console.ReadLine()
        Dim ns() As String = Console.ReadLine.Split(" ")

        Dim c(1) As Integer
        For i As Integer = 0 To n - 1
            If CInt(ns(i)) > 0 Then
                c(0) += 1
            ElseIf CInt(ns(i)) < 0 Then
                c(1) += 1
            End If
        Next

        Console.WriteLine((c(0) / n).ToString("0.000000", CultureInfo.GetCultureInfo("en-US")))
        Console.WriteLine((c(1) / n).ToString("0.000000", CultureInfo.GetCultureInfo("en-US")))
        Console.WriteLine(((n - c(0) - c(1)) / n).ToString("0.000000", CultureInfo.GetCultureInfo("en-US")))
    End Sub
End Module
