'Ashton and String
'https://www.hackerrank.com/challenges/ashton-and-string
'Score 100
Imports System
Imports System.Collections.Generic
Imports System.Text

Module AshtonAndString
    Sub Main()

        Dim n As Integer = Console.ReadLine()
        For t As Byte = 1 To n
            Dim inp As String = Console.ReadLine
            Dim sf As Integer = Console.ReadLine

            Dim sa As New AshtonString(inp)
            Console.WriteLine(sa.Find(sf))
        Next
    End Sub

End Module

Class AshtonString
    Implements IComparer(Of Integer)

    Private suffixArray(100001) As Integer
    Private LCP(100001) As Integer

    Private rank(100001) As Integer
    Private tmp(100001) As Integer

    Private str As String
    Private strLen As Integer

    Private e As Integer

    Public Sub New(inp As String)
        str = inp
        strLen = str.Length
        BuildSuffixArray()
        BuildLCP()
    End Sub

    Public Function Find(searchingFor As Long) As String

        For i As Integer = 0 To strLen - 1
            Dim L As Integer = LCP(i)
            Dim left As Integer = strLen - suffixArray(i + 1)
            Dim sum As Long = (L + 1 + left) * CLng(left - L) \ 2

            If searchingFor > sum Then
                searchingFor -= sum
            Else
                For j As Integer = L + 1 To left
                    If searchingFor <= j Then
                        Dim index As Integer = suffixArray(i + 1) + searchingFor
                        Return (str.Chars(index - 1))
                    Else
                        searchingFor -= j
                    End If
                Next j
            End If
        Next i
        Return ""
    End Function

    Public Function Compare(x As Integer, y As Integer) As Integer Implements IComparer(Of Integer).Compare

        If rank(x) <> rank(y) Then
            Return If(rank(x) < rank(y), -1, 0)
        End If

        Dim xx As Integer = If(x + e <= strLen, rank(x + e), -1)
        Dim yy As Integer = If(y + e <= strLen, rank(y + e), -1)
        If xx = yy Then Return 0

        Return If(xx < yy, -1, 0)
    End Function

    '*******************
    'HackerRank's VB compiler has a different compare behavior, 
    'Please use compare method below when submitting
    '*******************
    'Public Function Compare(x As Integer, y As Integer) As Integer Implements IComparer(Of Integer).Compare
    '    If rank(x) <> rank(y) Then
    '        Return If(rank(x) >= rank(y), 1, -1)
    '    End If
    '
    '    Dim xx As Integer = If(x + e <= strLen, rank(x + e), -1)
    '    Dim yy As Integer = If(y + e <= strLen, rank(y + e), -1)
    '    If xx = yy Then Return 0
    '
    '    Return If(xx >= yy, 1, -1)
    'End Function
    '*******************

    Private Sub BuildSuffixArray()

        For i As Integer = 0 To strLen
            suffixArray(i) = i
            rank(i) = (If(i < strLen, Asc(str.Chars(i)), -1))
        Next

        e = 1

        Do While e <= strLen
            Array.Sort(Of Integer)(suffixArray, 0, strLen + 1, Me)

            tmp(suffixArray(0)) = 0

            For i As Integer = 1 To strLen
                tmp(suffixArray(i)) = tmp(suffixArray(i - 1)) + (If(Compare(suffixArray(i - 1), suffixArray(i)), 1, 0))
            Next

            For i As Integer = 0 To strLen
                rank(i) = tmp(i)
            Next

            e *= 2
        Loop
    End Sub

    Private Sub BuildLCP()

        For i As Integer = 0 To strLen
            rank(suffixArray(i)) = i
        Next

        LCP(0) = 0

        Dim t As Integer
        Dim r As Integer

        For r = 0 To strLen - 1
            Dim j As Integer = suffixArray(rank(r) - 1)

            If t > 0 Then t -= 1

            Do While r + t < strLen AndAlso j + t < strLen
                If str.Chars(r + t) <> str.Chars(j + t) Then Exit Do

                t += 1
            Loop

            LCP(rank(r) - 1) = t
        Next
    End Sub
End Class