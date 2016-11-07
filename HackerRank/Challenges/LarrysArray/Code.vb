'Larry's Array
'https://www.hackerrank.com/challenges/larrys-array?h_r=next-challenge&h_v=zen
'Score 40
Imports System
Imports System.Collections.Generic

Module LarrysArray
    Sub Main()
        'https://www.youtube.com/watch?v=TKXiHdgOHaU
        'https://www.cs.bham.ac.uk/~mdr/teaching/modules04/java2/TilesSolvability.html

        Dim t As Integer = Console.ReadLine()

        For i As Integer = 1 To t
            Dim n As Integer = Console.ReadLine
            Dim inps() As Integer = Array.ConvertAll(Of String, Integer)(Console.ReadLine().Split(" "), AddressOf Convert.ToInt32)

            Dim inv As Integer = 0

            For e As Integer = 0 To n - 2
                For r As Integer = e + 1 To n - 1
                    If inps(e) > inps(r) Then inv += 1
                Next
            Next


            Console.WriteLine(IIf(inv Mod 2 = 0, "YES", "NO"))
        Next
    End Sub

End Module
