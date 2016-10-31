'Find Digits
'https://www.hackerrank.com/challenges/find-digits
'Score 25
Imports System
Imports System.Collections.Generic

Module FindDigits
    Sub Main()

        Dim n As Integer = Console.ReadLine()

        For i As Integer = 1 To n
            Dim inp As Integer = CInt(Console.ReadLine())
            Dim inps() As Integer = Array.ConvertAll(Of Char, Integer)(CStr(inp).ToCharArray, AddressOf CharToInt)
            Dim out As Integer = 0
            For Each digit As Integer In inps
                If digit > 0 AndAlso (inp Mod digit = 0) Then out += 1
            Next

            Console.WriteLine(out)
        Next
    End Sub

    Function CharToInt(c As Char) As Integer
        Return Convert.ToInt32(c) - 48
    End Function
End Module
