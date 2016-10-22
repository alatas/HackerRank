'Bigger is Greater
'https://www.hackerrank.com/challenges/bigger-is-greater
'Score 35
Imports System
Imports System.Collections.Generic

Module BiggerIsGreater
    Sub Main()

        Dim n As Integer = Console.ReadLine()

        For i As Integer = 1 To n

            Dim s() As Integer = Array.ConvertAll(Of Char, Integer)(Console.ReadLine().ToCharArray, AddressOf Asc)

            If nextPerm(s) Then

                Console.WriteLine(New String(Array.ConvertAll(Of Integer, Char)(s, AddressOf Chr)))
            Else
                Console.WriteLine("no answer")
            End If
        Next
    End Sub

    Public Function nextPerm(ByRef inp As Integer()) As Boolean
        Dim i As Integer = inp.Length - 1

        Do While i > 0 AndAlso inp(i - 1) >= inp(i)
            i -= 1
        Loop

        If i <= 0 Then Return False

        Dim e As Integer = inp.Length - 1
        Do While inp(e) <= inp(i - 1)
            e -= 1
        Loop


        Dim t As Integer = inp(i - 1)
        inp(i - 1) = inp(e)
        inp(e) = t

        e = inp.Length - 1

        Do While i < e
            t = inp(i)
            inp(i) = inp(e)
            inp(e) = t
            i += 1
            e -= 1
        Loop

        Return True
    End Function
End Module
