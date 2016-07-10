Public Structure ChallengeDef
    Property Id As String
    Property Name As String
    Property Link As String
    ReadOnly Property Type As Type
        Get
            Return System.Type.GetType("alatas.HackerRank." & Id)
        End Get
    End Property
End Structure