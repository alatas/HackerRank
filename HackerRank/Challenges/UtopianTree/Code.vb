'Utopian Tree
'https://www.hackerrank.com/challenges/utopian-tree
'Score 20
Imports System
Imports System.Collections.Generic

Module UtopianTree
    Sub Main()

        Dim n As Integer = Console.ReadLine()

        For t As Integer = 1 To n
            Dim c As Integer = Console.ReadLine()
            Dim l As Integer = 1
            For ci As Integer = 1 To c
                If ci Mod 2 Then l *= 2 Else l += 1
            Next

            Console.WriteLine(l)
        Next
    End Sub
End Module
