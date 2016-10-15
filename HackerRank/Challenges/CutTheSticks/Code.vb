'Cut the sticks
'https://www.hackerrank.com/challenges/cut-the-sticks
'Score 25
Imports System
Imports System.Collections.Generic

Module CutTheSticks
    Sub Main()

        Dim n As Integer = Console.ReadLine()
        Dim inps() As String = Console.ReadLine().Split(" ")
        Dim inp() As Integer = Array.ConvertAll(Of String, Integer)(inps, New Converter(Of String, Integer)(AddressOf ToInt))
        Array.Sort(inp)

        Do
            Console.WriteLine(UBound(inp) + 1)
            min = inp(0)
            inp = Array.FindAll(Of Integer)(inp, AddressOf Cut)
            If UBound(inp) = -1 Then Exit Do
        Loop

    End Sub

    Dim min As Integer = 0

    Function Cut(inp As Integer) As Boolean
        Return (inp > min)
    End Function

    Function ToInt(inp As String) As Integer
        Return CInt(inp)
    End Function
End Module
