'Detect the Email Addresses
'https://www.hackerrank.com/challenges/detect-the-email-addresses
'Score 15
Imports System
Imports System.Collections.Generic
Imports System.Text.RegularExpressions

Module DetectTheEmailAddresses
    Sub Main()
        Dim buffer As String = ""
        Dim n As Integer = Console.ReadLine()

        For i As Byte = 1 To n
            buffer &= Console.ReadLine() & vbCrLf
        Next

        Dim list As New List(Of String)
        For Each m As Match In Regex.Matches(buffer, "([A-Za-z0-9.-_]*\@[A-Za-z0-9.-_]*(\.[A-Za-z]+)+)", RegexOptions.MultiLine)
            If Not list.Contains(m.Value) Then list.Add(m.Value)
        Next
        list.Sort(New BasicLexicographicalCompare())
        Console.WriteLine(Join(list.ToArray(), ";"))
    End Sub
End Module

Public Class BasicLexicographicalCompare
    Implements IComparer(Of String)

    Public Function Compare(ByVal x As String, ByVal y As String) As Integer Implements IComparer(Of String).Compare
        Return String.Compare(x, y, StringComparison.Ordinal)
    End Function
End Class