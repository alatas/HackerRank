'Cavity Map
'https://www.hackerrank.com/challenges/cavity-map
'Score 30
Imports System
Imports System.Collections.Generic

Module CavityMap
    Sub Main()

        Dim n As Integer = Console.ReadLine()
        Dim m(n, n) As Integer

        For j As Integer = 0 To n - 1
            Dim inps() As Integer = Array.ConvertAll(Of Char, Integer)(Console.ReadLine.ToCharArray, AddressOf CharToInt)
            For i As Integer = 0 To n - 1
                m(i, j) = inps(i)
            Next
        Next

        For j As Integer = 0 To n - 1
            For i As Integer = 0 To n - 1
                If ((i >= 1) And (i < n - 1) And (j >= 1) And (j < n - 1)) Then

                    If (m(i, j) > m(i - 1, j)) And
                    (m(i, j) > m(i, j + 1)) And
                    (m(i, j) > m(i + 1, j)) And
                    (m(i, j) > m(i, j - 1)) Then
                        Console.Write("X")
                    Else
                        Console.Write(m(i, j))
                    End If
                Else
                    Console.Write(m(i, j))
                End If
            Next
            Console.WriteLine("")
        Next

    End Sub

    Function CharToInt(c As Char) As Integer
        Return Convert.ToInt32(c) - 48
    End Function
End Module
