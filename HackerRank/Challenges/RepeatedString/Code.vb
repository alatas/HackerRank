'Repeated String
'https://www.hackerrank.com/challenges/repeated-string
'Score 20
Imports System
Imports System.Collections.Generic

Module RepeatedString
    Sub Main()
        Dim s As String = Console.ReadLine()
        Dim n As Long = CLng(Console.ReadLine())

        Dim count As Long = Fix(n / s.Length) * CountA(s)
        If s.Length Mod n > 0 Then count += CountA(Left(s, n Mod s.Length))

        Console.WriteLine(count)
    End Sub

    Function CountA(str As String) As Integer
        Dim c() As Char = str.ToCharArray()
        Return UBound(Array.FindAll(Of Char)(c, AddressOf IsA)) + 1
    End Function

    Function IsA(c As Char) As Boolean
        Return c = "a"c
    End Function
End Module
