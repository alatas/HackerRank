'Beautiful Triplets
'https://www.hackerrank.com/challenges/beautiful-triplets
'Score 20
Imports System
Imports System.Collections.Generic

Module BeautifulTriplets
    Sub Main()

        Dim n() As Integer = Array.ConvertAll(Of String, Integer)(Console.ReadLine().Split(" "), AddressOf Convert.ToInt32)

        Dim inp() As Integer = Array.ConvertAll(Of String, Integer)(Console.ReadLine().Split(" "), AddressOf Convert.ToInt32)

        Dim out As Integer = 0

        For i As Integer = 0 To n(0) - 3
            For j As Integer = i To n(0) - 2
                If inp(j) - inp(i) > n(1) Then Exit For

                For k As Integer = j To n(0) - 1
                    If inp(k) - inp(j) > n(1) Then Exit For

                    If inp(k) - inp(j) = n(1) And inp(j) - inp(i) = n(1) Then out += 1
                Next
            Next
        Next

        Console.WriteLine(out)
    End Sub
End Module
