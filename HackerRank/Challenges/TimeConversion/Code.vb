'Time Conversion
'https://www.hackerrank.com/challenges/time-conversion
'Score 15
Imports System
Imports System.Collections.Generic

Module TimeConversion
    Sub Main()

        Dim i As String = Console.ReadLine()
        Dim am As Boolean = (i.Substring(8, 2) = "AM")
        Dim h As Integer = i.Substring(0, 2)

        If h = 12 And am Then
            Console.WriteLine("00" & i.Substring(2, 6))
        ElseIf am Then
            Console.WriteLine(i.Substring(0, 8))
        ElseIf h = 12 And Not am Then
            Console.WriteLine("12" & i.Substring(2, 6))
        Else
            Console.WriteLine(CStr(h + 12) & i.Substring(2, 6))
        End If
    End Sub
End Module
