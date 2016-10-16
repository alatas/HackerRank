'Sock Merchant
'https://www.hackerrank.com/challenges/sock-merchant
'Score 10
Imports System
Imports System.Collections.Generic

Module SockMerchant
    Sub Main()

        Dim n As Integer = Console.ReadLine()
        Dim inp() As String = Console.ReadLine().Split(" ")

        Array.Sort(inp)

        Dim latest As String = ""
        Dim out As Integer = 0
        For Each i As String In inp
            If i = latest Then
                out += 1
                latest = ""
            Else
                latest = i
            End If
        Next

        Console.WriteLine(out)
    End Sub
End Module
