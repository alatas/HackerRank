'Minimum Distances
'https://www.hackerrank.com/challenges/minimum-distances
'Score 20
Imports System
Imports System.Collections.Generic

Module MinimumDistances
    Sub Main()

        Dim n As Integer = Console.ReadLine()

        Dim inp() As Integer = Array.ConvertAll(Of String, Integer)(Console.ReadLine().Split(" "), AddressOf Convert.ToInt32)

        Dim out As Integer = n + 1

        For i As Integer = 0 To n - 2
            Dim pairIndex As Integer = Array.IndexOf(Of Integer)(inp, inp(i), i + 1)
            If pairIndex <> -1 AndAlso (pairIndex - i) < out Then
                out = (pairIndex - i)
            End If
        Next

        If out = n + 1 Then out = -1
        Console.WriteLine(out)
    End Sub
End Module
