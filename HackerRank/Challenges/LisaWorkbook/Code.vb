'Lisa's Workbook
'https://www.hackerrank.com/challenges/lisa-workbook
'Score 25
Imports System
Imports System.Collections.Generic

Module LisaWorkbook
    Sub Main()

        Dim n As Integer() = Array.ConvertAll(Of String, Integer)(Console.ReadLine().Split(" "), AddressOf Convert.ToInt32)
        Dim inp As Integer() = Array.ConvertAll(Of String, Integer)(Console.ReadLine().Split(" "), AddressOf Convert.ToInt32)

        Dim p As Integer = 1
        Dim out As Integer = 0
        For c As Integer = 1 To n(0)
            For q As Integer = 1 To inp(c - 1)
                If q = p Then out += 1
                If (q Mod n(1)) = 0 Or q = inp(c - 1) Then p += 1
            Next
        Next
        Console.WriteLine(out)
    End Sub
End Module
