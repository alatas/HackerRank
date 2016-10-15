'Divisible Sum Pairs
'https://www.hackerrank.com/challenges/divisible-sum-pairs
'Score 10
Imports System
Imports System.Collections.Generic

Module DivisibleSumPairs
    Sub Main()

        Dim line As String() = Console.ReadLine().Split(" ")
        Dim n As Integer = CInt(line(0))
        Dim divide As Integer = CInt(line(1))

        Dim inp() As String = Console.ReadLine().Split(" ")

        Dim count As Integer = 0
        For i As Integer = 0 To n - 2
            For j As Integer = i + 1 To n - 1
                If (CInt(inp(i)) + CInt(inp(j))) Mod divide = 0 Then count += 1
            Next
        Next

        Console.WriteLine(count)
    End Sub
End Module
