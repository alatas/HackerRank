'Detect HTML links
'https://www.hackerrank.com/challenges/detect-html-links
'Score 10
Imports System
Imports System.Text.RegularExpressions

Module DetectHtmlLinks
    Sub Main()
        Dim buffer As String = ""
        Dim lastLine As String = ""

        lastLine = Console.ReadLine()
        Do Until lastLine = ""
            buffer &= lastLine
            lastLine = Console.ReadLine()
        Loop

        For Each m As Match In Regex.Matches(buffer, "\<a\s.*?href\=(?:""|')(?<link>.*?)(?=(?:""|')).*?\>(?<title>.*?)\<\/a\>", RegexOptions.Multiline Or RegexOptions.IgnoreCase)
            Console.WriteLine(m.Groups("link").Value.Trim() & "," & CleanTag(m.Groups("title").Value.Trim()))
        Next
    End Sub

    Function CleanTag(inp As String) As String
        Return Regex.Replace(inp, "\<.*?(?=\>)\>", "")
    End Function
End Module