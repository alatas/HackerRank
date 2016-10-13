'Circular Array Rotation
'https://www.hackerrank.com/challenges/circular-array-rotation
'Score 20
Imports System
Imports System.Collections.Generic

Module CircularArrayRotation
    Sub Main()

        Dim params() As String = Console.ReadLine().Split(" ")
        Dim n As Integer = CInt(params(0))
        Dim k As Integer = CInt(params(1))
        Dim q As Integer = CInt(params(2))

        Dim inp(n - 1) As String
        Array.Copy(Console.ReadLine().Split(" "), inp, n)

        k = k Mod n
        Dim out(n - 1) As String

        Array.Copy(inp, n - k, out, 0, k)
        Array.Copy(inp, 0, out, k, n - k)

        For qi As Integer = 1 To q
            Dim qa As Integer = Console.ReadLine
            Console.WriteLine(out(qa))
        Next
    End Sub
End Module
