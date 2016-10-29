Imports System.IO
Imports System.Reflection

<TestClass()> Public Class UnitTest
    Public Property TestContext As TestContext

    Private ChallengesDir As DirectoryInfo
    Private ChallengeDefs As List(Of ChallengeDef)

    <TestInitialize> Public Sub Init()
        ChallengesDir = New DirectoryInfo($"{TestContext.TestDir}..\..\..\HackerRank\Challenges")
        Dim xchs As XDocument = XDocument.Load(Path.Combine(ChallengesDir.FullName, "Challenges.xml"))

        ChallengeDefs = (From x In xchs.<challenges>.<challenge> Select New ChallengeDef With {.Id = x.@Id, .Name = x.@Name, .Link = x.@Link}).ToList
    End Sub

    <TestMethod()> Public Sub TestOneChallengeOneInput()
        '-- CHANGE THIS OR SET EMPTY FOR LATEST CHALLENGE --
        Const ChallengeId = ""
        '---------------------------------------------------

        Const TestId = "6"

        Dim def As ChallengeDef
        If ChallengeId = "" Then
            def = ChallengeDefs.LastOrDefault
        Else
            def = ChallengeDefs.Where(Function(t) t.Id = ChallengeId).FirstOrDefault
        End If

        If def.Name = "" Then Assert.Fail("Challenge definition cannot be found!")

        Dim method = def.Type.GetMethod("Main", BindingFlags.Public Or BindingFlags.Static)
        If method Is Nothing Then Assert.Fail("Challenge main proc cannot be found!")

        Dim folder As New DirectoryInfo(Path.Combine(ChallengesDir.FullName, def.Id))
        If Not folder.Exists Then Assert.Fail($"Challenge folder cannot be found! {folder.FullName}")

        Dim inFile As New FileInfo(Path.Combine(folder.FullName, $"In\In{TestId}.txt"))
        If Not inFile.Exists Then Assert.Fail($"Test input file cannot be found! {inFile.FullName}")

        Dim outFile As New FileInfo(Path.Combine(folder.FullName, $"Out\Out{TestId}.txt"))
        If Not outFile.Exists Then Assert.Fail($"Test output file cannot be found! {outFile.FullName}")

        Assert.IsTrue(TestIt(def, [Delegate].CreateDelegate(GetType(Action), method), inFile, outFile))
    End Sub

    <TestMethod()> Public Sub TestOneChallengeAllInputs()
        '-- CHANGE THIS OR SET EMPTY FOR LATEST CHALLENGE --
        Const ChallengeId = ""
        '---------------------------------------------------

        Dim def As ChallengeDef
        If ChallengeId = "" Then
            def = ChallengeDefs.LastOrDefault
        Else
            def = ChallengeDefs.Where(Function(t) t.Id = ChallengeId).FirstOrDefault
        End If

        If def.Name = "" Then Assert.Fail("Challenge definition cannot be found!")

        Dim method = def.Type.GetMethod("Main", BindingFlags.Public Or BindingFlags.Static)
        If method Is Nothing Then Assert.Fail("Challenge main proc cannot be found!")

        Dim folder As New DirectoryInfo(Path.Combine(ChallengesDir.FullName, def.Id))
        If Not folder.Exists Then Assert.Fail($"Challenge folder cannot be found! {folder.FullName}")

        Dim inFolder As New DirectoryInfo(Path.Combine(folder.FullName, "In"))
        If Not inFolder.Exists Then Assert.Fail($"Test input folder cannot be found! {inFolder.FullName}")

        For Each inFile In inFolder.GetFiles("In*.txt")
            Dim outFile As New FileInfo(Path.Combine(folder.FullName, $"Out\Out{inFile.Name.Substring(2)}"))
            If Not outFile.Exists Then Assert.Fail($"Test output file cannot be found! {outFile.FullName}")

            Assert.IsTrue(TestIt(def, [Delegate].CreateDelegate(GetType(Action), method), inFile, outFile))
        Next
    End Sub

    <TestMethod()> Public Sub TestAllChallengesAllInputs()
        For Each def In ChallengeDefs
            Dim method = def.Type.GetMethod("Main", BindingFlags.Public Or BindingFlags.Static)
            If method Is Nothing Then Assert.Fail("Challenge main proc cannot be found!")

            Dim folder As New DirectoryInfo(Path.Combine(ChallengesDir.FullName, def.Id))
            If Not folder.Exists Then Assert.Fail($"Challenge folder cannot be found! {folder.FullName}")

            Dim inFolder As New DirectoryInfo(Path.Combine(folder.FullName, "In"))
            If Not inFolder.Exists Then Assert.Fail($"Test input folder cannot be found! {inFolder.FullName}")

            For Each inFile In inFolder.GetFiles("In*.txt")
                Dim outFile As New FileInfo(Path.Combine(folder.FullName, $"Out\Out{inFile.Name.Substring(2)}"))
                If Not outFile.Exists Then Assert.Fail($"Test output file cannot be found! {outFile.FullName}")

                Assert.IsTrue(TestIt(def, [Delegate].CreateDelegate(GetType(Action), method), inFile, outFile))
            Next
        Next
    End Sub

    <TestMethod()> Public Sub TestAllChallengesOneInputs()
        For Each def In ChallengeDefs
            Dim method = def.Type.GetMethod("Main", BindingFlags.Public Or BindingFlags.Static)
            If method Is Nothing Then Assert.Fail("Challenge main proc cannot be found!")

            Dim folder As New DirectoryInfo(Path.Combine(ChallengesDir.FullName, def.Id))
            If Not folder.Exists Then Assert.Fail($"Challenge folder cannot be found! {folder.FullName}")

            Dim inFolder As New DirectoryInfo(Path.Combine(folder.FullName, "In"))
            If Not inFolder.Exists Then Assert.Fail($"Test input folder cannot be found! {inFolder.FullName}")

            Dim inFile = (From i In inFolder.GetFiles("In*.txt") Order By i.Length Select i).FirstOrDefault
            Dim outFile As New FileInfo(Path.Combine(folder.FullName, $"Out\Out{inFile.Name.Substring(2)}"))

            If Not outFile.Exists Then Assert.Fail($"Test output file cannot be found! {outFile.FullName}")
            Assert.IsTrue(TestIt(def, [Delegate].CreateDelegate(GetType(Action), method), inFile, outFile))
        Next
    End Sub

    Private Function TestIt(def As ChallengeDef, method As Action, inFile As FileInfo, outFile As FileInfo) As Boolean
        Dim resultFile As String = $"{TestContext.TestResultsDirectory}\Result_{outFile.Name}"

        Debug.WriteLine($"Testing [{def.Name}] {inFile.Name} -> {outFile.Name}")
        Debug.WriteLine(def.Link)
        Debug.WriteLine("")
        Debug.WriteLine($"Input File: {inFile.FullName}")
        Debug.WriteLine($"Output File (expected): {outFile.FullName}")
        Debug.WriteLine("")
        Debug.WriteLine($"Output File (actual): {resultFile}")
        Debug.WriteLine("")
        Dim swatch As New Stopwatch
        swatch.Start()

        Using sread As New StreamReader(inFile.FullName, True),
         swrite As New StreamWriter(resultFile, False)
            Console.SetIn(sread)
            Console.SetOut(swrite)
            method.DynamicInvoke()
        End Using

        TestContext.AddResultFile(resultFile)

        Dim returnVal As Boolean = True

        Using sexpected As New StreamReader(outFile.FullName, True), sresult As New StreamReader(resultFile, True)
            Dim i As Integer = 1

            Do
                If sexpected.EndOfStream And sresult.EndOfStream Then Exit Do
                If sexpected.EndOfStream <> sresult.EndOfStream Then returnVal = False : Exit Do

                Dim texpected As String = sexpected.ReadLine
                Dim tresult As String = sresult.ReadLine
                Dim result = texpected = tresult
                Debug.WriteLine($"Line {i} {IIf(result, "same", "different")}")

                If Not result Then
                    Debug.WriteLine($"{vbTab}diffs (up to five)")
                    returnVal = False
                    Dim diff As New DiffPlex.Differ
                    Dim dret = diff.CreateCharacterDiffs(texpected, tresult, False, False)
                    For Each b In dret.DiffBlocks.Take(5)
                        Debug.WriteLine($"{vbTab}--{b.DeleteStartA}. [{b.DeleteCountA }] ...{texpected.Substring(b.DeleteStartA, IIf(b.DeleteCountA > 10, 10, b.DeleteCountA))}...")
                        Debug.WriteLine($"{vbTab}++{b.InsertStartB}. [{b.InsertCountB }] ...{tresult.Substring(b.InsertStartB, IIf(b.InsertCountB > 10, 10, b.InsertCountB))}...")
                        Debug.WriteLine("")
                    Next
                End If
                i += 1
            Loop
        End Using

        Debug.WriteLine($"Total Elapsed {swatch.ElapsedMilliseconds }msec{vbCrLf}")
        swatch.Stop()

        Return returnVal
    End Function
End Class