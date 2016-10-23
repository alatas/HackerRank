'Save the Prisoner!
'https://www.hackerrank.com/challenges/save-the-prisoner
'Score 15
Imports System
Imports System.Collections.Generic

Module SaveThePrisoner
    Sub Main()

        Dim n As Integer = Console.ReadLine()
        For i As Integer = 1 To n
            Dim inp() As Long = Array.ConvertAll(Of String, Int64)(Console.ReadLine.Split(" "), AddressOf Convert.ToInt64)
            Dim out As Long = ((inp(1) + inp(2)) Mod inp(0)) - 1
            Console.WriteLine(If(out = 0, inp(0), out))
        Next
    End Sub
End Module
