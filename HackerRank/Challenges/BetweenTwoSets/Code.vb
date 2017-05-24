'Between Two Sets
'https://www.hackerrank.com/challenges/between-two-sets
'Score 10
Imports System
Imports System.Collections.Generic

Module BetweenTwoSets
    Sub Main()

        Console.ReadLine()

        Dim A() As Integer = Array.ConvertAll(Of String, Integer)(Console.ReadLine().Split(" "), AddressOf Convert.ToInt32)

        Dim B() As Integer = Array.ConvertAll(Of String, Integer)(Console.ReadLine().Split(" "), AddressOf Convert.ToInt32)

        Array.Sort(A)
        Array.Sort(B)

        Dim out As Integer = 0
        For x As Integer = A(0) To B(UBound(B))
            Dim ok As Boolean = True
            For Each Ai As Integer In A
                If Not (x Mod Ai = 0) Then ok = False
            Next

            For Each Bi As Integer In B
                If Not (Bi Mod x = 0) Then ok = False
            Next

            If ok Then out += 1
        Next

        Console.WriteLine(out)
    End Sub
End Module
