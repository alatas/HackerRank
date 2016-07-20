'Building a Smart IDE: Programming Language Detection
'https://www.hackerrank.com/challenges/programming-language-detection
'Score 30
Imports System
Imports System.Collections.Generic
Imports System.Text.RegularExpressions

Module ProgrammingLanguageDetection
    Sub Main()
        Dim buffer As String = ""
        Dim lastLine As String = ""

        Dim c As String() = New String() {"iter", "size", "printf", "scanf", "jter", "#include", "stdio", "#define", "sizeof", "malloc", "typedef", "stdlib"}
        Dim j As String() = New String() {"System", "println", "public", "io", "import", "java", "new", "InputStreamReader", "IOException", "static", "parseInt", "catch", "Integer", "NumberFormatException", "javax"}
        Dim p As String() = New String() {"Current", "print", "self", "def", "stack", "init__"}


        lastLine = Console.ReadLine()
        Do Until lastLine Is Nothing
            buffer &= lastLine & vbCrLf
            lastLine = Console.ReadLine()
        Loop

        buffer = Regex.Replace(buffer, "(#.*?$)|(\/\/.*?$)|(\/\*(\s|\S)*?\*\/)", "", RegexOptions.MultiLine Or RegexOptions.IgnoreCase)

        Dim points(2) As Integer
        Dim langs As String() = New String() {"C", "Java", "Python"}

        For Each m As Match In Regex.Matches(buffer, "([A-Za-z#][A-Za-z0-9#_]*)[\s\t\n\r().=""'<>,;+{}\[\]\\*&%@!\-]+", RegexOptions.MultiLine Or RegexOptions.IgnoreCase)
            If Array.IndexOf(c, m.Groups(1).Value) > -1 Then points(0) += 1
            If Array.IndexOf(j, m.Groups(1).Value) > -1 Then points(1) += 1
            If Array.IndexOf(p, m.Groups(1).Value) > -1 Then points(2) += 1
        Next

        Console.WriteLine(langs(MaxValIndex(points)))
    End Sub

    Function MaxValIndex(arr() As Integer) As Integer
        Dim maxIndex As Byte = 0

        For i As Byte = 1 To UBound(arr)
            If arr(i) >= arr(maxIndex) Then maxIndex = i
        Next
        Return maxIndex
    End Function
End Module