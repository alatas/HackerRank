'Grading Students
'https://www.hackerrank.com/challenges/grading
'Score 10
Imports System
Imports System.Collections.Generic

Module Grading
    Sub Main()

        Dim n As Integer = Console.ReadLine()
        Dim l(n - 1) As String

        For i As Integer = 0 To n - 1
            Dim g = CInt(Console.ReadLine)
            If g >= 38 AndAlso (g Mod 5) >= 3 Then g += 5 - (g Mod 5)

            Console.WriteLine(g)
        Next
    End Sub
End Module
