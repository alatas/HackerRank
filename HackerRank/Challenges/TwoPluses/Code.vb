'Ema's Supercomputer
'https://www.hackerrank.com/challenges/two-pluses
'Score 40
Imports System
Imports System.Collections.Generic

Module TwoPluses

    Sub Main()

        Dim h As String() = Console.ReadLine().Split(" ")
        Dim r, c As Integer
        r = h(0)
        c = h(1)

        Dim f(r - 1, c - 1) As Boolean

        For ri As Integer = 0 To r - 1
            Dim rinp() As Char = Console.ReadLine().ToCharArray
            For ci As Integer = 0 To c - 1
                If rinp(ci) = "B"c Then f(ri, ci) = False Else f(ri, ci) = True
            Next
        Next

        Console.WriteLine(SearchPluses(f))
    End Sub

    Function SearchPluses(f(,) As Boolean, Optional firstValue As Integer = 0) As Integer
        Dim r, c As Integer
        r = UBound(f, 1)
        c = UBound(f, 2)
        Dim out As Integer = firstValue

        For ri As Integer = 0 To r - 1
            For ci As Integer = 0 To c - 1
                Dim count As Integer = CountNeighbors(f, ri, ci)
                If GetCell(f, ri, ci) Then
                    Dim area, length As Integer

                    If count = 4 Then
                        length = 2
                        Do
                            count = CountNeighbors(f, ri, ci, length)
                            If count < 4 Then Exit Do
                            length += 1
                        Loop
                        area = (1 + ((length - 1) * 4))
                    Else
                        length = 0
                        area = 1
                    End If

                    If firstValue = 0 Then
                        Dim fi(,) As Boolean = ArrayClone(f)
                        SetCells(fi, ri, ci, False, length)
                        Dim outS As Integer = SearchPluses(fi, area)
                        If outS > out Then out = outS
                    Else
                        If firstValue * area > out Then out = firstValue * area
                    End If
                End If
            Next
        Next
        Return out
    End Function

    Sub SetCells(ByRef f(,) As Boolean, r As Integer, c As Integer, value As Boolean, length As Integer)
        SetCell(f, r, c, value)
        For i As Integer = 1 To length - 1
            SetCell(f, r + i, c, value)
            SetCell(f, r - i, c, value)
            SetCell(f, r, c + i, value)
            SetCell(f, r, c - i, value)
        Next
    End Sub

    Function CountNeighbors(f(,) As Boolean, r As Integer, c As Integer, Optional length As Integer = 1) As Integer
        Dim ret As Integer = 0
        If GetCell(f, r + length, c) Then ret += 1
        If GetCell(f, r - length, c) Then ret += 1
        If GetCell(f, r, c + length) Then ret += 1
        If GetCell(f, r, c - length) Then ret += 1
        Return ret
    End Function

    Function GetCell(f(,) As Boolean, r As Integer, c As Integer) As Boolean
        If r > UBound(f, 1) Or r < 0 Then Return False
        If c > UBound(f, 2) Or c < 0 Then Return False

        Return f(r, c)
    End Function

    Sub SetCell(ByRef f(,) As Boolean, r As Integer, c As Integer, value As Boolean)
        If r > UBound(f, 1) Or r < 0 Then Exit Sub
        If c > UBound(f, 2) Or c < 0 Then Exit Sub

        f(r, c) = value
    End Sub

    Function ArrayClone(f(,) As Boolean) As Boolean(,)
        'Array.Clone function throws some weird compilation errors on HackerRank :(
        Dim ret(UBound(f, 1), UBound(f, 2)) As Boolean
        Array.ConstrainedCopy(f, 0, ret, 0, f.Length)
        Return ret
    End Function
End Module
