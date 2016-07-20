'Building a Smart IDE: Identifying comments
'https://www.hackerrank.com/challenges/ide-identifying-comments
'Score 20
Imports System
Imports System.Text.RegularExpressions

Module IdeIdentifyingComments
    Sub Main()
        Dim buffer As String = ""
        Dim lastLine As String = ""

        lastLine = Console.ReadLine()
        Do Until lastLine Is Nothing
            buffer &= lastLine & vbCrLf
            lastLine = Console.ReadLine()
        Loop

        For Each m As Match In Regex.Matches(buffer, "\/\/.*?$|(\/\*(\s|\S)*?\*\/)", RegexOptions.Multiline Or RegexOptions.IgnoreCase)
            Console.WriteLine(Regex.Replace(m.Value.Trim(), "^((?:\s|\t)+)", "", RegexOptions.Multiline))
        Next
    End Sub
End Module