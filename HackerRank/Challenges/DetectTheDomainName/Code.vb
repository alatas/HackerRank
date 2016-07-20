'Detect the Domain Name
'https://www.hackerrank.com/challenges/detect-the-domain-name
'Score 15
Imports System
Imports System.Collections.Generic
Imports System.Text.RegularExpressions

Module DetectTheDomainName
    Sub Main()
        Dim buffer As String = ""
        Dim n As Integer = Console.ReadLine()

        For i As Integer = 1 To n
            buffer &= Console.ReadLine() & vbCrLf
        Next

        Dim list As New List(Of String)
        For Each m As Match In Regex.Matches(buffer, "https?:\/\/(?:ww[w0-9]{1}\.)?([A-Za-z0-9_.-]*\.[A-Za-z]*){1}", RegexOptions.MultiLine Or RegexOptions.IgnoreCase)
            Dim domain As String = m.Groups(1).Value.Trim()
            If domain <> "" And Not list.Contains(domain) Then list.Add(domain)
        Next

        list.Sort(New BasicLexicographicalOrder())
        Console.WriteLine(Join(list.ToArray(), ";"))
    End Sub
End Module

Public Class BasicLexicographicalOrder
    Implements IComparer(Of String)

    Public Function Compare(ByVal x As String, ByVal y As String) As Integer Implements IComparer(Of String).Compare
        Return String.Compare(x, y, StringComparison.Ordinal)
    End Function
End Class
