'Jumping on the Clouds: Revisited
'https://www.hackerrank.com/challenges/jumping-on-the-clouds-revisited
'Score 15
Imports System
Imports System.Collections.Generic

Module JumpingOnTheCloudsRevisited
    Sub Main()

        Dim n As Integer() = Array.ConvertAll(Of String, Integer)(Console.ReadLine().Split(" "), AddressOf Convert.ToInt32)
        Dim inp As Integer() = Array.ConvertAll(Of String, Integer)(Console.ReadLine().Split(" "), AddressOf Convert.ToInt32)

        Dim en As Byte = 100

        For e As Integer = 0 To n(0) - 1 Step n(1)
            If inp(e) = 1 Then en -= 2
            en -= 1
        Next

        Console.WriteLine(en)
    End Sub
End Module
