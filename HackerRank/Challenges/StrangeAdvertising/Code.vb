'Viral Advertising
'https://www.hackerrank.com/challenges/strange-advertising
'Score 15
Imports System
Imports System.Collections.Generic

Module StrangeAdvertising
    Sub Main()

        Dim n As Integer = Console.ReadLine()

        Dim c As Integer = 5
        Dim out As Integer = 0

        For i As Integer = 1 To n
            c = Math.Floor(c / 2)
            out += c
            c *= 3
        Next
        Console.WriteLine(out)
    End Sub
End Module
