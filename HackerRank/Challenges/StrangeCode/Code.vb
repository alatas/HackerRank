'Strange Counter
'https://www.hackerrank.com/challenges/strange-code
'Score 30
Imports System
Imports System.Collections.Generic

Module StrangeCode
    Sub Main()

        Dim n As Long = Console.ReadLine()
        Dim part As Integer = Math.Ceiling((Math.Log(n + 3) - Math.Log(2) - Math.Log(3)) / Math.Log(2))
        Dim parttop As Long = 1 + (3 * (-1 + (2 ^ part)))
        Console.WriteLine((2 ^ part * 3) + parttop - n)
    End Sub
End Module
