'Angry Professor
'https://www.hackerrank.com/challenges/angry-professor
'Score 20
Imports System
Imports System.Collections.Generic

Module AngryProfessor
    Sub Main()

        Dim n As Integer = Console.ReadLine()

        For t As Integer = 1 To n
            Dim line() As String = Console.ReadLine().Split(" ")
            Dim k As Integer = CInt(line(1))

            Dim inp() As String = Console.ReadLine().Split(" ")
            Dim arrived() As String = Array.FindAll(Of String)(inp, AddressOf HasArrived)
            If UBound(arrived) + 1 >= k Then Console.WriteLine("NO") Else Console.WriteLine("YES")
        Next
    End Sub

    Function HasArrived(inp As String) As Boolean
        Return (CInt(inp) <= 0)
    End Function
End Module
