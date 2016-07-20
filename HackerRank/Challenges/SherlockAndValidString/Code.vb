'Sherlock and Valid String
'https://www.hackerrank.com/challenges/sherlock-and-valid-string
'Score 100

Imports System
Imports System.Collections.Generic

Module SherlockAndValidString
    Sub Main()

        Dim s As String = Console.ReadLine()
        Dim ss() As Byte = System.Text.Encoding.ASCII.GetBytes(s)

        Dim cs(25) As Integer

        For Each sp As Byte In ss
            cs(sp - 97) += 1
        Next

        Array.Sort(cs)

        Dim zeroCount As Integer = 0
        Dim hfreq As Integer = 0
        Dim hfreqCount As Integer = 0

        For i As Byte = 0 To 25
            If Not cs(i) = 0 Then
                Dim count As Integer = Array.LastIndexOf(cs, cs(i)) - Array.IndexOf(cs, cs(i)) + 1
                If count > hfreqCount Then
                    hfreq = cs(i)
                    hfreqCount = count
                End If
            Else
                zeroCount += 1
            End If
        Next

        hfreqCount += zeroCount

        If hfreqCount < 25 Then Console.WriteLine("NO") Else Console.WriteLine("YES")
    End Sub
End Module
