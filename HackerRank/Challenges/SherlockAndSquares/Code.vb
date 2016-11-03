'Sherlock and Squares
'https://www.hackerrank.com/challenges/sherlock-and-squares
'Score 20
Imports System
Imports System.Collections.Generic

Module SherlockAndSquares
    Sub Main()

        Dim n As Integer = Console.ReadLine()

        For t As Integer = 1 To n
            Dim inps() As String = Console.ReadLine().Split(" ")

            Dim low As Integer = inps(0)
            Dim high As Integer = inps(1)

            Dim lowi As Integer = Math.Ceiling(Math.Sqrt(low))
            Dim highi As Integer = Math.Floor(Math.Sqrt(high))

            If lowi > highi Then
                Console.WriteLine(0)
            Else
                Console.WriteLine(highi - lowi + 1)
            End If
        Next
    End Sub
End Module
