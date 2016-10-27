'Absolute Permutation
'https://www.hackerrank.com/challenges/absolute-permutation
'Score 40
Imports System
Imports System.Collections.Generic

Module AbsolutePermutation
    Sub Main()

        For t As Integer = 1 To CInt(Console.ReadLine())
            Dim inp() As String = Console.ReadLine().Split(" ")
            Dim n, k As Integer
            n = CInt(inp(0))
            k = CInt(inp(1))

            Dim out As New List(Of String)

            If (k = 0) Then
                For i As Integer = 1 To n
                    out.Add(i)
                Next
            ElseIf (n Mod (2 * k)) Then
                out.Add(-1)
            Else
                Dim a As Boolean = False
                For i As Integer = 1 To n
                    If a Then
                        out.Add(i - k)
                    Else
                        out.Add(i + k)
                    End If

                    If (i Mod k = 0) Then a = Not a
                Next
            End If

            Console.WriteLine(Join(out.ToArray, " "))
        Next
    End Sub
End Module
