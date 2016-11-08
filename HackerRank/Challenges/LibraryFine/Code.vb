'Library Fine
'https://www.hackerrank.com/challenges/library-fine
'Score 15
Imports System
Imports System.Collections.Generic

Module LibraryFine
    Sub Main()

        Dim d As Date = Date.ParseExact(Console.ReadLine(), "d M yyyy", System.Globalization.CultureInfo.InvariantCulture)
        Dim e As Date = Date.ParseExact(Console.ReadLine(), "d M yyyy", System.Globalization.CultureInfo.InvariantCulture)

        If d <= e Then
            Console.WriteLine(0)
        ElseIf e.Month = d.Month And e.Year = d.Year Then
            Console.WriteLine(DateDiff(DateInterval.Day, e, d) * 15)
        ElseIf e.Year = d.Year Then
            Console.WriteLine(DateDiff(DateInterval.Month, e, d) * 500)
        Else
            Console.WriteLine(10000)
        End If
    End Sub
End Module
