Imports System.IO

Module Bootstrapper
    Sub Main()
        Using sread As New StreamReader(AppContext.BaseDirectory & "..\..\..\HackerRank\In.txt", True),
           swrite As New StreamWriter(AppContext.BaseDirectory & "\Out_code.txt", False)

            Console.SetIn(sread)
            Console.SetOut(swrite)
            HackerRank.Main()
        End Using
    End Sub
End Module
