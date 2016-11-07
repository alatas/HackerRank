'Chocolate Feast 
'https://www.hackerrank.com/challenges/chocolate-feast?h_r=next-challenge&h_v=zen
'Score 25
Imports System
Imports System.Collections.Generic

Module ChocolateFeast
    Sub Main()

        Dim t As Integer = Console.ReadLine()

        For i As Integer = 1 To t
            Dim inp() As Integer = Array.ConvertAll(Of String, Integer)(Console.ReadLine().Split(" "), AddressOf Convert.ToInt32)
            Dim n, c, m As Integer
            n = inp(0)
            c = inp(1)
            m = inp(2)

            Dim out As Integer = Fix(n / c)
            Dim w As Integer = out

            Do While w >= m
                out += Fix(w / m)
                w = Fix(w / m) + (w Mod m)
            Loop

            Console.WriteLine(out)
        Next
    End Sub
End Module
