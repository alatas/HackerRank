'Simple Array Sum
'https://www.hackerrank.com/challenges/simple-array-sum
'Score 10
Imports System
Imports System.Collections.Generic

Module SimpleArraySum
    Sub Main()

        Dim n As Integer = Console.ReadLine()
        Dim line As String = Console.ReadLine()

        Dim p() As String = line.Split(" ")
        Dim sum As Integer = 0
        For i As Integer = 0 To n - 1
            sum += CInt(p(i))
        Next
        Console.WriteLine(sum)
    End Sub
End Module
