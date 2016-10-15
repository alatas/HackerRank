'Kangaroo
'https://www.hackerrank.com/challenges/kangaroo
'Score 10
Imports System
Imports System.Collections.Generic

Module Kangaroo
    Sub Main()

        Dim line As String() = Console.ReadLine().Split(" ")
        Dim x1 As Integer = CInt(line(0))
        Dim v1 As Integer = CInt(line(1))
        Dim x2 As Integer = CInt(line(2))
        Dim v2 As Integer = CInt(line(3))

        Dim jmp As Integer = 1
        Dim lastdiff As Integer = x2 - x1

        Do
            Dim diff As Integer = (x2 + (v2 * jmp)) - (x1 + (v1 * jmp))
            If diff = 0 Then Console.WriteLine("YES") : Exit Sub
            If diff >= lastdiff Or diff < 0 Then Exit Do
            lastdiff = diff
            jmp += 1
        Loop
        Console.WriteLine("NO")
    End Sub
End Module
