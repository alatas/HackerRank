Imports System
Imports System.Collections.Generic

Module MorganAndAString
    Sub Main()
        Dim n As Integer = Console.ReadLine()

        For i As Integer = 1 To n
            Dim x As String = Console.ReadLine()
            Dim y As String = Console.ReadLine()

            Dim xi As Integer = 0
            Dim yi As Integer = 0

            Dim xs() As Char = x.ToCharArray
            Dim ys() As Char = y.ToCharArray

            'using cs and cf to avoid iterate whole array again and again
            Dim cs As String = -1
            Dim cf As String = -1

            Do While xi <= UBound(xs) Or yi <= UBound(ys)

                If xi > UBound(xs) Then
                    Console.Write(ys(yi))
                    yi += 1
                    Continue Do
                End If

                If yi > UBound(ys) Then
                    Console.Write(xs(xi))
                    xi += 1
                    Continue Do
                End If

                'using col for iteration through string
                Dim col As Integer = 0
                Do
                    If xi + col > UBound(xs) Then
                        Console.Write(ys(yi))
                        yi += 1
                        Exit Do
                    End If

                    If yi + col > UBound(ys) Then
                        Console.Write(xs(xi))
                        xi += 1
                        Exit Do
                    End If

                    Dim xc As Char = xs(xi + col)
                    Dim yc As Char = ys(yi + col)

                    If Asc(xc) < Asc(yc) Then
                        Console.Write(xs(xi))
                        xi += 1
                        cs = -1
                        cf = -1
                        Exit Do
                    ElseIf Asc(xc) > Asc(yc) Then
                        Console.Write(ys(yi))
                        yi += 1
                        cs = -1
                        cf = -1
                        Exit Do
                    Else
                        If (xi + col) >= cs And (xi + col) <= cf Then
                            col = cf - cs + 1
                        Else
                            cs = xi
                            cf = xi + col
                            col += 1
                        End If
                    End If
                Loop

            Loop
            Console.Write(vbCrLf)
        Next

    End Sub
End Module