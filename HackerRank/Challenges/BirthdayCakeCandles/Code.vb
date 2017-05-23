'Birthday Cake Candles
'https://www.hackerrank.com/challenges/birthday-cake-candles
'Score 10
Imports System
Imports System.Collections.Generic

Module BirthdayCakeCandles
    Sub Main()

        Dim n As Integer = Console.ReadLine()
        Dim inps() As Integer = Array.ConvertAll(Of String, Integer)(Console.ReadLine().Split(" "), AddressOf Convert.ToInt32)

        Dim s As Integer = 0
        Dim m As Integer = 0

        For Each inp As Integer In inps
            If inp > m Then
                m = inp
                s = 1
            ElseIf inp = m Then
                s += 1
            End If
        Next

        Console.WriteLine(s)
    End Sub
End Module
