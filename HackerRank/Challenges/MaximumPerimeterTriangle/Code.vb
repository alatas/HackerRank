'Maximum Perimeter Triangle
'https://www.hackerrank.com/challenges/maximum-perimeter-triangle
'Score 20
Imports System
Imports System.Collections.Generic

Module MaximumPerimeterTriangle
    Sub Main()

        Dim n As Integer = Console.ReadLine()
        Dim s = Console.ReadLine().Split(" ")
        Dim l(n - 1) As Integer

        For e As Integer = 0 To n - 1
            l(e) = CInt(s(e))
        Next

        Array.Sort(l)

        Dim i As Integer = n - 3
        While (i >= 0 AndAlso (l(i + 2) >= l(i) + l(i + 1)))
            i -= 1
        End While

        If i >= 0 Then
            Console.WriteLine(l(i) & " " & l(i + 1) & " " & l(i + 2))
        Else
            Console.WriteLine(-1)
        End If
    End Sub
End Module
