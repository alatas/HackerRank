'Happy Ladybugs
'https://www.hackerrank.com/challenges/happy-ladybugs
'Score 30
Imports System
Imports System.Collections.Generic

Module HappyLadybugs
    Sub Main()

        Dim n As Integer = Console.ReadLine()

        For t As Integer = 1 To n
            Dim l As Integer = Console.ReadLine()
            Dim inp As String = Console.ReadLine()
            Dim inps() As Char = inp.ToCharArray
            Dim ret As String = "YES"

            If inp.IndexOf("_") = -1 Then

                Dim total As Integer = 0
                For i As Integer = 0 To l - 1
                    Dim prev As Char = If(i = 0, Char.MinValue, inp(i - 1))
                    Dim nxt As Char = If(i = l - 1, Char.MinValue, inp(i + 1))
                    If prev <> inps(i) And nxt <> inps(i) Then ret = "NO" : Exit For
                Next
            Else
                Array.Sort(inps)
                Dim last As Char = Char.MinValue
                Dim total As Integer = 0
                For Each c As Char In inps
                    If c <> last Then
                        If total = 1 Then ret = "NO" : Exit For
                        last = c
                        total = 1
                    Else
                        total += 1
                    End If
                Next
            End If

            Console.WriteLine(ret)
        Next
    End Sub
End Module
