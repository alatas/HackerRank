'Bon Appétit
'https://www.hackerrank.com/challenges/bon-appetit
'Score 10
Imports System
Imports System.Collections.Generic

Module BonAppetit
    Sub Main()

        Dim l() As Integer = Array.ConvertAll(Of String, Integer)(Console.ReadLine.Split(" "), AddressOf Convert.ToInt32)
        Dim i() As Integer = Array.ConvertAll(Of String, Integer)(Console.ReadLine.Split(" "), AddressOf Convert.ToInt32)
        Dim a As Integer = Console.ReadLine

        Dim sum As Integer = 0
        For e As Integer = 0 To l(0) - 1
            If Not l(1) = e Then sum += i(e)
        Next

        If Math.Floor(sum / 2) = a Then
            Console.WriteLine("Bon Appetit")
        Else
            Console.WriteLine(a - Math.Floor(sum / 2))
        End If
    End Sub
End Module
