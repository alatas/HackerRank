'Non-Divisible Subset
'https://www.hackerrank.com/challenges/non-divisible-subset
'Score 20
Imports System
Imports System.Collections.Generic

Module NonDivisibleSubset
    Sub Main()

        Dim line As String() = Console.ReadLine().Split(" ")
        Dim n As Integer = CInt(line(0))
        Dim k As Integer = CInt(line(1))

        Dim inps() As String = Console.ReadLine().Split(" ")
        Dim inp() As Integer = Array.ConvertAll(Of String, Integer)(inps, AddressOf ToInt)

        Dim ns(k - 1) As Integer
        For Each i As Integer In inp
            ns(i Mod k) += 1
        Next

        Dim out As Integer = Math.Min(ns(0), 1)

        For i As Integer = 1 To Math.Floor(k / 2)
            If i <> k - i Then
                out += Math.Max(ns(i), ns(k - i))
            End If
        Next

        If k Mod 2 = 0 Then
            out += 1
        End If

        Console.WriteLine(out)
    End Sub

    Function ToInt(s As String) As Integer
        Return CInt(s)
    End Function
End Module
