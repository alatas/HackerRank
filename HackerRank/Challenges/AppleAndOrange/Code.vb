'Apple and Orange
'https://www.hackerrank.com/challenges/apple-and-orange
'Score 10
Imports System
Imports System.Collections.Generic

Module AppleAndOrange
    Dim s, t, a, b, m, n As Integer
    Sub Main()
        GetInput(s, t)
        GetInput(a, b)
        GetInput(m, n)

        Console.WriteLine(Array.FindAll(Of String)(Console.ReadLine.Split(" "), AddressOf Apples).Length)
        Console.WriteLine(Array.FindAll(Of String)(Console.ReadLine.Split(" "), AddressOf Oranges).Length)

    End Sub

    Function Apples(inp As String) As Boolean
        Dim val As Integer = a + CInt(inp)
        Return (val <= t And val >= s)
    End Function

    Function Oranges(inp As String) As Boolean
        Dim val As Integer = b + CInt(inp)
        Return (val <= t And val >= s)
    End Function

    Sub GetInput(ByRef first As Integer, ByRef second As Integer)
        Dim inp() As String = Console.ReadLine.Split(" ")
        first = inp(0)
        second = inp(1)
    End Sub
End Module
