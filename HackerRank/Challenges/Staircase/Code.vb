'Staircase
'https://www.hackerrank.com/challenges/staircase
'Score 10
Imports System
Imports System.Collections.Generic

Module Staircase
    Sub Main()

        Dim n As Integer = Console.ReadLine()

        For i As Integer = n To 1 Step -1
            Console.WriteLine(StrDup(i - 1, " ") & StrDup(n - i + 1, "#"))
        Next
    End Sub
End Module
