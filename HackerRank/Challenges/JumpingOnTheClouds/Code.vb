'Jumping on the Clouds
'https://www.hackerrank.com/challenges/jumping-on-the-clouds
'Score 20
Imports System
Imports System.Collections.Generic

Module JumpingOnTheClouds
    Sub Main()

        Dim n As Integer = Console.ReadLine()
        Dim c = Console.ReadLine().Split(" ")

        Dim j As Integer = 0

        For i As Integer = 0 To n - 2
            If i + 2 <= n - 1 AndAlso c(i + 2) = "0" Then
                i += 1
            End If

            j += 1
        Next

        Console.WriteLine(j)
    End Sub
End Module
