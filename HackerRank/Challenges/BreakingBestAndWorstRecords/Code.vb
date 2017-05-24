'Breaking the Records
'https://www.hackerrank.com/challenges/breaking-best-and-worst-records
'Score 10
Imports System
Imports System.Collections.Generic

Module BreakingBestAndWorstRecords
    Sub Main()

        Dim c As Integer = Console.ReadLine()
        Dim n() As Integer = Array.ConvertAll(Of String, Integer)(Console.ReadLine.Split(" "), AddressOf Convert.ToInt32)

        Dim h As Integer = n(0)
        Dim hc As Integer = 0
        Dim l As Integer = n(0)
        Dim lc As Integer = 0

        For Each ni as Integer In n
            If ni > h Then hc += 1 : h = ni
            If ni < l Then lc += 1 : l = ni
        Next

        Console.WriteLine(hc & " " & lc)
    End Sub
End Module
