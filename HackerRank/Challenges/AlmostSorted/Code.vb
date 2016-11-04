'Almost Sorted
'https://www.hackerrank.com/challenges/almost-sorted
'Score 50
Imports System
Imports System.Collections.Generic

Module AlmostSorted
    Sub Main()

        Dim c As Integer = Console.ReadLine()

        Dim inp() As Integer = Array.ConvertAll(Of String, Integer)(Console.ReadLine().Split(" "), AddressOf Convert.ToInt32)

        Dim l, n As Integer
        Dim ret As String = ""
        Dim part() As Integer

        l = IsSorted(inp, True)
        n = IsSortedReverse(inp, False)


        If n - l = 1 Then
            Dim swp As Integer = inp(l - 1)
            inp(l - 1) = inp(n - 1)
            inp(n - 1) = swp
            If (IsSorted(inp, True) = 0) Then ret = "swap"
        Else
            ReDim part(n - l - 2)
            Array.Copy(inp, l, part, 0, n - l - 1)
            If IsSorted(part, True) = 0 Then ret = "swap"
        End If

        If ret = "" Then
            ReDim part(n - l)
            Array.Copy(inp, l - 1, part, 0, n - l + 1)
            If IsSorted(part, False) = 0 Then ret = "reverse"
        End If

        Console.WriteLine(If(ret <> "", "yes", "no"))
        If ret <> "" Then Console.WriteLine(ret & " " & l & " " & n)
    End Sub

    Function IsSorted(inp() As Integer, asc As Boolean) As Integer
        Dim last As Integer = If(asc, -1, 1000001)


        For i As Integer = 0 To UBound(inp)
            If (asc AndAlso inp(i) > last) Or (Not asc AndAlso inp(i) < last) Then
                last = inp(i)
            Else
                Return i
            End If
        Next

        Return 0
    End Function

    Function IsSortedReverse(inp() As Integer, asc As Boolean) As Integer
        Dim last As Integer = If(asc, -1, 1000001)


        For i As Integer = UBound(inp) To 0 Step -1
            If (asc AndAlso inp(i) > last) Or (Not asc AndAlso inp(i) < last) Then
                last = inp(i)
            Else
                Return i + 2
            End If
        Next

        Return 0
    End Function
End Module
