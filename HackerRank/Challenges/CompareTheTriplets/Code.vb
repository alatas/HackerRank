'Compare the Triplets
'https://www.hackerrank.com/challenges/compare-the-triplets
'Score 10
Imports System
Imports System.Collections.Generic

Module CompareTheTriplets
    Sub Main()

        Dim a As String = Console.ReadLine()
        Dim b As String = Console.ReadLine()

        Dim pa() As String = a.Split(" ")
        Dim pb() As String = b.Split(" ")

        Dim oa, ob As Integer

        For i As Integer = 0 To UBound(pa)
            If CInt(pa(i)) > CInt(pb(i)) Then
                oa += 1
            ElseIf CInt(pb(i)) > CInt(pa(i)) Then
                ob += 1
            End If
        Next

        Console.WriteLine(oa & " " & ob)
    End Sub
End Module
