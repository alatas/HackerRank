'Service Lane
'https://www.hackerrank.com/challenges/service-lane
'Score 20
Imports System
Imports System.Collections.Generic

Module ServiceLane
    Sub Main()

        Dim n() As Integer = Array.ConvertAll(Of String, Integer)(Console.ReadLine().Split(" "), AddressOf Convert.ToInt32)
        Dim inp() As Integer = Array.ConvertAll(Of String, Integer)(Console.ReadLine().Split(" "), AddressOf Convert.ToInt32)

        For i As Integer = 1 To n(1)
            Dim tinp() As Integer = Array.ConvertAll(Of String, Integer)(Console.ReadLine().Split(" "), AddressOf Convert.ToInt32)

            Dim part(tinp(1) - tinp(0)) As Integer
            Array.ConstrainedCopy(inp, tinp(0), part, 0, tinp(1) - tinp(0) + 1)
            Array.Sort(part)
            Console.WriteLine(part(0))
        Next
    End Sub
End Module
