'Detecting Valid Latitude and Longitude Pairs
'https://www.hackerrank.com/challenges/detecting-valid-latitude-and-longitude
'Score 20
Imports System
Imports System.Text.RegularExpressions
Imports System.Globalization.CultureInfo

Module DetectingValidLatitudeAndLongitude
    Sub Main()
        Dim buffer As String = ""
        Dim n As Integer = Console.ReadLine()

        For i As Integer = 1 To n
            Console.WriteLine(IIf(IsValid(Console.ReadLine()), "Valid", "Invalid"))
        Next
    End Sub

    Function IsValid(inp As String) As Boolean
        Dim m As Match = Regex.Match(inp, "\(([+\-]?\d{1,2}(?:\.\d+)?)\,\s([+\-]?\d{1,3}(?:\.\d+)?)\)", RegexOptions.Singleline Or RegexOptions.CultureInvariant Or RegexOptions.IgnoreCase)
        If m IsNot Nothing AndAlso m.Success Then
            Return IsBetween(Decimal.Parse(m.Groups(1).Value, InvariantCulture), -90.0, 90.0) AndAlso IsBetween(Decimal.Parse(m.Groups(2).Value, InvariantCulture), -180.0, 180.0)
        Else
            Return False
        End If
    End Function

    Function IsBetween(Val As Decimal, Min As Decimal, Max As Decimal) As Boolean
        Return (Val >= Min And Val <= Max)
    End Function
End Module