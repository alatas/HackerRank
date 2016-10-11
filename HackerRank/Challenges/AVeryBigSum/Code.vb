'A Very Big Sum
'https://www.hackerrank.com/challenges/a-very-big-sum
'Score 10
Imports System
Imports System.Collections.Generic

Module AVeryBigSum
    Sub Main()

        Dim n As Integer = Console.ReadLine()
        Dim line As String = Console.ReadLine()

        Dim p() As String = line.Split(" ")
        Dim sum As Long = 0
        For i = 0 To n - 1
            sum += CInt(p(i))
        Next
        Console.WriteLine(sum)
    End Sub
End Module
