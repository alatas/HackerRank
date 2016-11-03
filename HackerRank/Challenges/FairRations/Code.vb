'Fair Rations
'https://www.hackerrank.com/challenges/fair-rations
'Score 25
Imports System
Imports System.Collections.Generic

Module FairRations
    Sub Main()

        Dim n As Integer = Console.ReadLine()
        Dim inps() As Integer = Array.ConvertAll(Of String, Integer)(Console.ReadLine().Split(" "), AddressOf Convert.ToInt32)

        Dim s As Integer = 0
        Dim a As Boolean = False

        For Each inp As Integer In inps
            a = (a + inp) Mod 2
            s += a * 2
        Next

        If a Then
            Console.WriteLine("NO")
        Else
            Console.WriteLine(Math.Abs(s))
        End If

    End Sub
End Module
