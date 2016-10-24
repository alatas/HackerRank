'Flatland Space Stations
'https://www.hackerrank.com/challenges/flatland-space-stations
'Score 25
Imports System
Imports System.Collections.Generic

Module FlatlandSpaceStations
    Sub Main()

        Dim n As Integer() = Array.ConvertAll(Of String, Integer)(Console.ReadLine().Split(" "), AddressOf Convert.ToInt32)
        Dim inp As Integer() = Array.ConvertAll(Of String, Integer)(Console.ReadLine().Split(" "), AddressOf Convert.ToInt32)
        Dim c(n(0) - 1) As Integer

        Dim lastSta As Integer = -1
        For i As Integer = 0 To n(0) - 1
            If Array.IndexOf(inp, i) >= 0 Then
                lastSta = i
                c(i) = 0
            ElseIf lastSta <> -1 Then
                c(i) = i - lastSta
            Else
                c(i) = -1
            End If
        Next

        lastSta = -1
        For i As Integer = n(0) - 1 To 0 Step -1
            If c(i) = 0 Then
                lastSta = i
            ElseIf lastSta <> -1 AndAlso c(i) > lastSta - i Then
                c(i) = lastSta - i
            ElseIf lastSta <> -1 AndAlso c(i) = -1 Then
                c(i) = lastSta - i
            End If
        Next

        Array.Sort(c)
        Array.Reverse(c)
        Console.WriteLine(c(0))
    End Sub
End Module
