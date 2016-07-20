'Find a Word
'https://www.hackerrank.com/challenges/find-a-word
'Score 15
Imports System
Imports System.Text.RegularExpressions

Module FindAWord
    Sub Main()
        Dim buffer As String = ""
        Dim n As Integer = Console.ReadLine()

        For i As Byte = 1 To n
            buffer &= Console.ReadLine() & vbCrLf
        Next

        n = Console.ReadLine()
        For i As Byte = 1 To n
            Console.WriteLine(Regex.Matches(buffer, "([^A-Za-z0-9_]|^)" & Console.ReadLine() & "(?=[^A-Za-z0-9_])", RegexOptions.MultiLine).Count)
        Next
    End Sub
End Module