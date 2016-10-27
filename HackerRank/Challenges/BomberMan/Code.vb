'The Bomberman Game
'https://www.hackerrank.com/challenges/bomber-man
'Score 40
Imports System
Imports System.Collections.Generic

Module BomberMan

    Dim f(,) As Integer
    Dim r, c, n, t As Integer

    Sub Main()

        Dim inps() As String = Console.ReadLine().Split(" ")
        r = inps(0)
        c = inps(1)
        n = inps(2)

        ReDim f(r - 1, c - 1)

        For ri As Integer = 0 To r - 1
            Dim rinp() As Char = Console.ReadLine().ToCharArray
            For ci As Integer = 0 To c - 1
                If rinp(ci) = "."c Then f(ri, ci) = -1 Else f(ri, ci) = 0
            Next
        Next

        MoveNextSec()
        t = 1

        If n > 7 Then n = ((n - 3) Mod 4) + 3

        Do
            If t = n Then Exit Do
            MoveNextSec()
            FillUp()
            If t = n Then Exit Do
            MoveNextSec()
            Inflate()
        Loop

        OutPut()
    End Sub

    Sub MoveNextSec()
        For ri As Integer = 0 To r - 1
            For ci As Integer = 0 To c - 1
                If f(ri, ci) > -1 Then f(ri, ci) += 1
            Next
        Next
        t += 1
    End Sub

    Sub FillUp()
        For ri As Integer = 0 To r - 1
            For ci As Integer = 0 To c - 1
                If f(ri, ci) = -1 Then f(ri, ci) = 0
            Next
        Next
    End Sub

    Sub Inflate()
        For ri As Integer = 0 To r - 1
            For ci As Integer = 0 To c - 1
                If f(ri, ci) = 3 Then
                    If ri - 1 >= 0 AndAlso f(ri - 1, ci) > -1 AndAlso f(ri - 1, ci) < 3 Then f(ri - 1, ci) = -2
                    If ri + 1 < r AndAlso f(ri + 1, ci) > -1 AndAlso f(ri + 1, ci) < 3 Then f(ri + 1, ci) = -2
                    If ci - 1 >= 0 AndAlso f(ri, ci - 1) > -1 AndAlso f(ri, ci - 1) < 3 Then f(ri, ci - 1) = -2
                    If ci + 1 < c AndAlso f(ri, ci + 1) > -1 AndAlso f(ri, ci + 1) < 3 Then f(ri, ci + 1) = -2
                End If
            Next
        Next

        For ri As Integer = 0 To r - 1
            For ci As Integer = 0 To c - 1
                If f(ri, ci) = 3 Or f(ri, ci) = -2 Then f(ri, ci) = -1
            Next
        Next
    End Sub

    Sub OutPut()
        For ri As Integer = 0 To r - 1
            For ci As Integer = 0 To c - 1
                If f(ri, ci) = -1 Then Console.Write(".") Else Console.Write("O")
            Next
            Console.Write(vbCrLf)
        Next
    End Sub
End Module
