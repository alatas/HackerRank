'Manasa and Stones
'https://www.hackerrank.com/challenges/manasa-and-stones
'Score 30
Imports System
Imports System.Collections.Generic

Module ManasaAndStones
    Sub Main()

        Dim t As Integer = Console.ReadLine()

        For i As Integer = 1 To t
            Dim n As Integer = Console.ReadLine()
            n -= 1

            Dim a_ As Integer = Console.ReadLine()
            Dim b_ As Integer = Console.ReadLine()
            Dim a As Integer = Math.Min(a_, b_)
            Dim b As Integer = Math.Max(a_, b_)

            Dim ret As Integer = a * n
            Dim mx As Integer = b * n

            Dim diff As Integer = b - a
            If a = b Then
                Console.WriteLine(ret)
            Else
                Dim out As New List(Of String)
                While ret <= mx
                    out.Add(ret.ToString)
                    ret += diff
                End While
                Console.WriteLine(Join(out.ToArray, " "))
            End If
        Next
    End Sub
End Module
