'The Grid Search
'https://www.hackerrank.com/challenges/the-grid-search
'Score 30
Imports System
Imports System.Collections.Generic

Module TheGridSearch
    Sub Main()

        Dim n As Integer = Console.ReadLine()

        For t As Integer = 1 To n

            Dim m() As String = GetMatrix()
            Dim s() As String = GetMatrix()

            Dim ret As String = ""

            For y As Integer = 0 To UBound(m)

                Dim x As Integer = -1

                Do
                    x = m(y).IndexOf(s(0), x + 1)

                    If x >= 0 Then
                        If y + UBound(s) <= UBound(m) Then
                            For ys As Integer = 1 To UBound(s)
                                If m(y + ys).IndexOf(s(ys)) <> x Then ret = "NO" : Exit For
                            Next
                        End If

                        If ret = "" Then ret = "YES" Else ret = ""
                    Else
                        Exit Do
                    End If

                    If ret = "YES" Then Exit For
                Loop
            Next

            If ret = "" Then ret = "NO"
            Console.WriteLine(ret)
        Next
    End Sub

    Function GetMatrix() As String()
        Dim l() As Integer = Array.ConvertAll(Of String, Integer)(Console.ReadLine().Split(" "), AddressOf Convert.ToInt32)
        Dim ret(l(0) - 1) As String

        For i As Integer = 1 To l(0)
            ret(i - 1) = Console.ReadLine
        Next

        Return ret
    End Function
End Module
