'Diagonal Difference
'https://www.hackerrank.com/challenges/diagonal-difference
'Score 10
Imports System
Imports System.Collections.Generic

Module DiagonalDifference
    Sub Main()

        Dim n As Integer = Console.ReadLine()
        Dim l(n - 1)() As String

        For i As Integer = 0 To n - 1
            l(i) = Console.ReadLine().Split(" ")
        Next

        Dim d1, d2 As Integer
        For i As Integer = 0 To n - 1
            d1 += CInt(l(i)(i))
            d2 += CInt(l(i)(n - 1 - i))
        Next

        Console.WriteLine(Math.Abs(d1 - d2))
    End Sub
End Module
