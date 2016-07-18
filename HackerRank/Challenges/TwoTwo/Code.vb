Imports System
Imports System.Collections.Generic
Imports System.Globalization
Imports System.Numerics

Module TwoTwo
    Sub Main()

        Dim n As Integer = Console.ReadLine()
        Dim Root As New Node

        For e As Integer = 0 To 800
            Root.Build(StringtoByteArray(BigInteger.Pow(2, e).ToString, True))
        Next

        For i As Integer = 1 To n
            Dim A As String = Console.ReadLine()
            Console.WriteLine(Root.Search(StrReverse(A)))
        Next
    End Sub

    Function StringtoByteArray(inp As String, Optional reverse As Boolean = False) As Byte()
        Dim bs As Byte() = System.Text.Encoding.ASCII.GetBytes(inp)
        If reverse Then Array.Reverse(bs)
        For i As Integer = 0 To UBound(bs)
            bs(i) = bs(i) - 48
        Next
        Return bs
    End Function
End Module

Public Class Node
    Sub New()
        MyBase.New
    End Sub

    Sub New(val As Byte)
        MyBase.New
        Value = val
    End Sub

    Sub Build(inp() As Byte)
        If UBound(inp) = -1 Then HasMeaning = True : Exit Sub

        Dim c As Byte = inp(0)
        Dim n As Node = GetNode(c)

        Dim na(UBound(inp) - 1) As Byte
        Array.Copy(inp, 1, na, 0, UBound(inp))
        If n IsNot Nothing Then
            n.Build(na)
        Else
            Dim nNew As New Node(c)
            Nodes(nNew.Value) = nNew
            nNew.Build(na)
        End If
    End Sub

    Function Search(inp As String) As Integer
        Return Search(StringtoByteArray(inp))
    End Function

    Function Search(ByRef inp As Byte()) As Integer
        Dim ret As Integer = 0

        For i As Integer = 0 To UBound(inp)

            Dim n As Node = GetNode(inp(i))
            If n IsNot Nothing Then
                Dim ms As Integer = 0
                n.SearchDeep(inp, i + 1, ms)
                ret += ms
            End If
        Next

        Return ret
    End Function

    Public Sub SearchDeep(ByRef inp As Byte(), index As Integer, ByRef matches As Integer)
        If HasMeaning Then matches += 1

        If index <= UBound(inp) Then
            Dim n As Node = GetNode(inp(index))
            If n IsNot Nothing Then
                n.SearchDeep(inp, index + 1, matches)
            End If
        End If
    End Sub

    Private _Nodes(9) As Node
    Property Nodes As Node()
        Get
            Return _Nodes
        End Get
        Set(value As Node())
            _Nodes = value
        End Set
    End Property

    Private _Value As Byte
    Property Value As Byte
        Get
            Return _Value
        End Get
        Set(val As Byte)
            _Value = val
        End Set
    End Property

    Function HasNode(c As Byte) As Boolean
        Return Nodes(c) Is Nothing
    End Function

    Function GetNode(c As Byte) As Node
        Return Nodes(c)
    End Function

    Private _HasMeaning As Boolean = False
    Property HasMeaning As Boolean
        Get
            Return _HasMeaning
        End Get
        Set(value As Boolean)
            _HasMeaning = value
        End Set
    End Property

    Public Overrides Function ToString() As String
        Return Value
    End Function
End Class