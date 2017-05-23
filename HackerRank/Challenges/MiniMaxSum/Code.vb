'Mini-Max Sum
'https://www.hackerrank.com/challenges/mini-max-sum
'Score 10

Module MiniMaxSum
    Sub Main()
        Dim n() As Long = Array.ConvertAll(Of String, Long)(Console.ReadLine().Split(" "), AddressOf Convert.ToInt64)
        Array.Sort(n)
        Console.Write((n(0) + n(1) + n(2) + n(3)) & " " & (n(1) + n(2) + n(3) + n(4)))
    End Sub
End Module
