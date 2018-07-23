Public Class Form1
    'Dim INADictionary As New Dictionary(Of String, Integer)
    Dim filereader As String
    Dim INADictionary(0) As String

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        BuildDictionary()


    End Sub

    Private Sub BtCompare_Click(sender As Object, e As EventArgs) Handles BtCompare.Click
        'Dim TestDing As String = RichTextBoxA.Text
        'Dim TestSearch As String = RichTextBoxB.Text
        'Dim pos As Integer

        'pos = InStr(TestSearch, TestDing)
        'MsgBox(pos)

        'Remove all special texts
        'Dim TextA As String = RichTextBoxA.Text
        'Dim TextASentences As String()
        'Dim INASplitter As Char() = "."

        'TextA = TextA.Replace(vbCr, " ").Replace(vbLf, " ")
        'TextA = CleanTextFromSpecials(TextA)
        'TextASentences = TextA.Split(". ")

        Dim TextASentences As String() = BreakToSentences(RichTextBoxA.Text)

        Dim TextAStructure(,,) As String = BreakToWordForms(TextASentences)
        'The magic, (Sentence Number, Form (noun, verb, adjective), Word)
        'Dim TextAStructure(TextASentences.Count - 1, 2, 0) As String
        'Dim wordALimit As Integer = 0

        'For iterator As Integer = 0 To TextASentences.Count - 1
        '    'break to sentences
        '    Dim sentenceContainer As String() = TextASentences(iterator).Split(".")
        '    Dim wordACount As Integer = -1

        '    For jterator As Integer = 0 To sentenceContainer.Count - 1
        '        'RichTextBoxB.AppendText(Trim(sentenceContainer(jterator)) + Environment.NewLine)
        '        'break to words
        '        Dim wordContainer As String() = sentenceContainer(jterator).Split(" ")


        '        For kterator As Integer = 0 To wordContainer.Count - 1
        '            If wordContainer(kterator) IsNot "" AndAlso wordContainer(kterator) IsNot " " Then
        '                Dim wordFound As Boolean = False

        '                'Find each word's forms on dictionary
        '                For lterator As Integer = 0 To INADictionary.Count - 1
        '                    'Only run when words are not found yet
        '                    If wordFound = False Then
        '                        Dim dictionaryComparatorContainer As String()

        '                        dictionaryComparatorContainer = INADictionary(lterator).Split(" ")
        '                        'word is the exact same as on dictionary, found
        '                        If wordContainer(kterator) = dictionaryComparatorContainer(1) Then
        '                            wordACount += 1
        '                            'if array's rightmost dimension is full, resize
        '                            If wordACount > wordALimit Then
        '                                ReDim Preserve TextAStructure(TextASentences.Count - 1, 2, wordACount)
        '                                wordALimit += 1

        '                            End If
        '                            'dictionarycomparatorcontainer(1) need to be fixed to accomodate real words used
        '                            TextAStructure(iterator, CInt(dictionaryComparatorContainer(0)), wordACount) = dictionaryComparatorContainer(1)
        '                            wordFound = True
        '                        End If
        '                    End If

        '                    'PREFIX SUFFIX``````````````````````````````````
        '                    'If lterator = INADictionary.Count - 1 And wordFound = False Then

        '                    'End If
        '                Next
        '            End If
        '        Next
        '    Next
        'Next

        ''''''''''''''''''''''''''''''List of words matrix
        'For iterator As Integer = 0 To TextAStructure.GetUpperBound(0)
        '    For jterator As Integer = 0 To TextAStructure.GetUpperBound(1)
        '        For kterator As Integer = 0 To TextAStructure.GetUpperBound(2)
        '            If TextAStructure(iterator, jterator, kterator) IsNot Nothing Then
        '                RichTextBoxB.AppendText(Str(iterator) + Str(jterator) + Str(kterator) + " = " + TextAStructure(iterator, jterator, kterator) + Environment.NewLine)
        '            End If

        '        Next
        '    Next
        'Next

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''List B'''
        'Remove all special texts
        Dim TextB As String = RichTextBoxB.Text
        Dim TextBSentences As String()

        TextB = TextB.Replace(vbCr, " ").Replace(vbLf, " ")
        TextB = CleanTextFromSpecials(TextB)
        TextBSentences = TextB.Split(". ")

        'The magic, (Sentence Number, Form (noun, verb, adjective), Word)
        Dim TextBStructure(TextBSentences.Count - 1, 2, 0) As String
        Dim wordBLimit As Integer = 0

        For iterator As Integer = 0 To TextBSentences.Count - 1
            'break to sentences
            Dim sentenceContainer As String() = TextBSentences(iterator).Split(".")
            Dim wordBCount As Integer = -1

            For jterator As Integer = 0 To sentenceContainer.Count - 1
                'RichTextBoxB.AppendText(Trim(sentenceContainer(jterator)) + Environment.NewLine)
                'break to words
                Dim wordContainer As String() = sentenceContainer(jterator).Split(" ")

                For kterator As Integer = 0 To wordContainer.Count - 1
                    If wordContainer(kterator) IsNot "" AndAlso wordContainer(kterator) IsNot " " Then
                        Dim wordFound As Boolean = False

                        'Find each word's forms on dictionary
                        For lterator As Integer = 0 To INADictionary.Count - 1
                            'Only run when words are not found yet
                            If wordFound = False Then
                                Dim dictionaryComparatorContainer As String()

                                dictionaryComparatorContainer = INADictionary(lterator).Split(" ")
                                'word is the exact same as on dictionary, found
                                If wordContainer(kterator) = dictionaryComparatorContainer(1) Then
                                    wordBCount += 1
                                    'if array's rightmost dimension is full, resize
                                    If wordBCount > wordBLimit Then
                                        ReDim Preserve TextBStructure(TextBSentences.Count - 1, 2, wordBCount)
                                        wordBLimit += 1

                                    End If
                                    'dictionarycomparatorcontainer(1) need to be fixed to accomodate real words used
                                    TextBStructure(iterator, CInt(dictionaryComparatorContainer(0)), wordBCount) = dictionaryComparatorContainer(1)
                                    wordFound = True
                                End If
                            End If
                        Next
                    End If
                Next
            Next
        Next

        ''''''''''''''''''''''''''''''List of words matrix
        'For iterator As Integer = 0 To TextBStructure.GetUpperBound(0)
        '    For jterator As Integer = 0 To TextBStructure.GetUpperBound(1)
        '        For kterator As Integer = 0 To TextBStructure.GetUpperBound(2)
        '            If TextBStructure(iterator, jterator, kterator) IsNot Nothing Then
        '                RichTextBoxA.AppendText(Str(iterator) + Str(jterator) + Str(kterator) + " = " + TextBStructure(iterator, jterator, kterator) + Environment.NewLine)
        '            End If

        '        Next
        '    Next
        'Next

        ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''COMPARE TEXTS'''''''''''''''''''''''''''''''

        Dim sentencesAMatchedSentences As Integer = -1
        For iterator As Integer = 0 To TextAStructure.GetUpperBound(0)
            Dim sentencesAWordCount As Integer = -1
            Dim sentencesAWordList(0) As String
            Dim sentencesMaximumMatchedWords As Integer = -1
            Dim sentencesCurrentMatchedWords As Integer = -1

            For jterator As Integer = 0 To TextAStructure.GetUpperBound(1)
                For kterator As Integer = 0 To TextAStructure.GetUpperBound(2)
                    If TextAStructure(iterator, jterator, kterator) IsNot Nothing Then
                        sentencesAWordCount += 1
                        ReDim Preserve sentencesAWordList(sentencesAWordCount)
                        sentencesAWordList(sentencesAWordCount) = TextAStructure(iterator, jterator, kterator)
                    End If
                Next
            Next

            'compare word to all sentences on list B
            If sentencesAWordCount > -1 Then
                sentencesMaximumMatchedWords = -1
                sentencesCurrentMatchedWords = -1
                For biterator As Integer = 0 To TextBStructure.GetUpperBound(0)
                    sentencesCurrentMatchedWords = -1

                    For lterator As Integer = 0 To sentencesAWordCount
                        For bjterator As Integer = 0 To TextBStructure.GetUpperBound(1)
                            For bkterator As Integer = 0 To TextBStructure.GetUpperBound(2)
                                If sentencesAWordList(lterator) = TextBStructure(biterator, bjterator, bkterator) Then
                                    sentencesCurrentMatchedWords += 1

                                End If
                            Next
                        Next
                    Next

                    If sentencesMaximumMatchedWords < sentencesCurrentMatchedWords Then
                        sentencesMaximumMatchedWords = sentencesCurrentMatchedWords
                    End If
                Next
            End If

            'all words pairing matched in at least 1 sentences
            If sentencesMaximumMatchedWords > sentencesAWordCount - 1 Then
                sentencesAMatchedSentences += 1
            End If
        Next

        txtOutput.Text = Str(sentencesAMatchedSentences + 1) + " out of" + Str(TextAStructure.GetUpperBound(0) + 1)




        'For iterator As Integer = 0 To TextASentences.Count - 1
        '    Dim wordCount As Integer = -1
        '    Dim wordLimit As Integer = 0
        '    Dim sentenceContainer As String() = TextASentences(iterator).Split(" ")
        '    MsgBox("Iterator ")
        '    For jterator As Integer = 0 To sentenceContainer.Count - 1
        '        If wordCount > wordLimit Then
        '            ReDim TextAStructure(TextASentences.Count - 1, 2, wordCount)
        '        End If

        '        If sentenceContainer(jterator) IsNot " " AndAlso sentenceContainer(jterator) IsNot "" Then
        '            'search dictionary for word, and look up its form
        '            Dim substringValue As Integer
        '            Dim substringValueLow As Integer = 999
        '            Dim wordFound As Boolean = False

        '            For kterator As Integer = 0 To INADictionary.Count - 1
        '                Dim dictionaryTemp As String()
        '                dictionaryTemp = INADictionary(kterator).Split(" ")
        '                substringValue = InStr(sentenceContainer(jterator), dictionaryTemp(1))
        '                '*fix dictionarytemp(1)
        '                If wordFound = False Then
        '                    If sentenceContainer(jterator) = dictionaryTemp(1) Then
        '                        'found, complete match
        '                        TextAStructure(iterator, CInt(dictionaryTemp(0)), wordCount) = sentenceContainer(jterator)
        '                        wordCount += 1
        '                        wordFound = True
        '                    Else
        '                        If substringValue > 0 Then
        '                            'found, word might have prefix/suffix
        '                            If (substringValue < substringValueLow) Then
        '                                substringValueLow = substringValue
        '                                TextAStructure(iterator, CInt(dictionaryTemp(0)), wordCount) = sentenceContainer(jterator)
        '                                wordCount += 1
        '                                wordFound = True
        '                            End If
        '                        End If
        '                    End If
        '                End If
        '            Next
        '        End If
        '        MsgBox("Jterator ")
        '    Next
        'Next

    End Sub

    Function CleanTextFromSpecials(ByVal stringToCleanUp)
        Dim characterToRemove As String = ""
        characterToRemove = Chr(34) + "`~!@#$%^&*()=_+[]{}'\:|/<>?"",;"
        Dim firstThree As Char() = characterToRemove.Take(characterToRemove.Count).ToArray()
        For index = 1 To firstThree.Length - 1
            stringToCleanUp = stringToCleanUp.ToString.Replace(firstThree(index), "")
        Next
        Return stringToCleanUp
    End Function

    Function BuildDictionary()
        filereader = My.Computer.FileSystem.ReadAllText("D:\Projects\VB\Dictionary Data\kata dasar indonesia.txt")
        Dim Splitter As String() = filereader.Split(Environment.NewLine)

        Dim count As Integer = Splitter.Count()
        Dim AddToDictionary As String()
        Dim WordCount As Integer = 0

        For iterator As Integer = 0 To Splitter.Count() - 1
            AddToDictionary = Splitter(iterator).Split(" ")
            Dim WordBuilderText As String

            WordBuilderText = AddToDictionary(0)
            If AddToDictionary.Count() > 2 Then
                For WordBuilderIterator As Integer = 1 To AddToDictionary.Count - 1
                    WordBuilderText = WordBuilderText + " " + AddToDictionary(WordBuilderIterator)
                Next
            End If

            If AddToDictionary(AddToDictionary.Count - 1) = "(n)" Then
                ReDim Preserve INADictionary(WordCount)
                Dim WordBuilderContainer As String
                WordBuilderContainer = "0" + " " + WordBuilderText.Replace(vbCr, "").Replace(vbLf, "")
                INADictionary(WordCount) = WordBuilderContainer
                WordCount += 1
            ElseIf AddToDictionary(AddToDictionary.Count - 1) = "(v)" Then
                ReDim Preserve INADictionary(WordCount)
                Dim WordBuilderContainer As String
                WordBuilderContainer = "1" + " " + WordBuilderText.Replace(vbCr, "").Replace(vbLf, "")
                INADictionary(WordCount) = WordBuilderContainer
                WordCount += 1
            ElseIf AddToDictionary(AddToDictionary.Count - 1) = "(adj)" Then
                ReDim Preserve INADictionary(WordCount)
                Dim WordBuilderContainer As String
                WordBuilderContainer = "2" + " " + WordBuilderText.Replace(vbCr, "").Replace(vbLf, "")
                INADictionary(WordCount) = WordBuilderContainer
                WordCount += 1
            End If

        Next

        'Dim filereader As String

        'filereader = My.Computer.FileSystem.ReadAllText("D:\Projects\VB\Dictionary Data\kata dasar indonesia.txt")
        'Dim Splitter As String() = filereader.Split(Environment.NewLine)

        'Dim count As Integer = Splitter.Count()
        'Dim AddToDictionary As String()

        'For iterator As Integer = 0 To Splitter.Count() - 1
        '    AddToDictionary = Splitter(iterator).Split(" ")
        '    Dim WordBuilderText As String
        '    Dim WordBuilderForm As Integer

        '    WordBuilderText = AddToDictionary(0)

        '    If AddToDictionary.Count() > 2 Then
        '        For WordBuilderIterator As Integer = 1 To AddToDictionary.Count - 1
        '            WordBuilderText = WordBuilderText + " " + AddToDictionary(WordBuilderIterator)
        '        Next
        '    End If

        '    If AddToDictionary(AddToDictionary.Count - 1) = "(n)" Then
        '        WordBuilderForm = 1
        '    ElseIf AddToDictionary(AddToDictionary.Count - 1) = "(v)" Then
        '        WordBuilderForm = 2
        '    ElseIf AddToDictionary(AddToDictionary.Count - 1) = "(adj)" Then
        '        WordBuilderForm = 3
        '    Else
        '        WordBuilderForm = 0
        '    End If

        '    If WordBuilderForm > 0 Then
        '        INADictionary.Add(WordBuilderText, WordBuilderForm)
        '    End If
        'Next
        '
        '
        'Dim WordForms As New List(Of String)()

        'For iterator As Integer = 0 To Splitter.Count() - 1
        '    AddToDictionary = Splitter(iterator).Split(" ")

        '    If WordForms.Count = 0 Then
        '        WordForms.Add(AddToDictionary(1))
        '    Else
        '        Dim boolWordForm As Boolean = False
        '        For itWordForm As Integer = 0 To WordForms.Count() - 1
        '            If AddToDictionary(AddToDictionary.Count - 1) = WordForms(itWordForm) Then
        '                boolWordForm = True
        '            End If
        '        Next

        '        If boolWordForm = False Then
        '            WordForms.Add(AddToDictionary(1))
        '        End If
        '    End If
        'Next

        'For Each item As String In WordForms
        '    RichTextBoxA.AppendText(item + Environment.NewLine)
        'Next
        Return 0
    End Function

    Function BreakToSentences(ByRef TextDocument As String) As String()
        Dim OriginalText As String = TextDocument
        Dim TextSentences As String()

        OriginalText = OriginalText.Replace(vbCr, " ").Replace(vbLf, " ")
        OriginalText = CleanTextFromSpecials(OriginalText)
        TextSentences = OriginalText.Split(". ")

        Return TextSentences
    End Function

    Function BreakToWordForms(ByRef OriginalSentences As String()) As String(,,)
        Dim TextStructure(OriginalSentences.Count - 1, 2, 0) As String
        Dim WordLimit As Integer = 0
        Dim WordCount = -1

        For iterator = 0 To OriginalSentences.Count - 1
            'break to words
            Dim wordContainer As String() = OriginalSentences(iterator).Split(" ")

            For jterator As Integer = 0 To wordContainer.Count - 1
                If wordContainer(jterator) IsNot "" AndAlso wordContainer(jterator) IsNot " " Then
                    Dim wordFound As Boolean = False

                    'find each word on dictionary
                    For kterator As Integer = 0 To INADictionary.Count - 1
                        'only run when words are not found yet
                        If wordFound = False Then
                            Dim dictionaryComparatorContainer As String()

                            dictionaryComparatorContainer = INADictionary(kterator).Split(" ")
                            'word is the exact same as on dictionary, found
                            If wordContainer(jterator) = dictionaryComparatorContainer(1) Then
                                WordCount += 1

                                'if array's rightmost dimension is full, resize
                                If WordCount > WordLimit Then
                                    ReDim Preserve TextStructure(OriginalSentences.Count - 1, 2, WordCount)
                                    WordLimit += 1
                                End If

                                TextStructure(iterator, CInt(dictionaryComparatorContainer(0)), WordCount) = dictionaryComparatorContainer(1)
                                wordFound = True
                            End If
                        End If
                    Next
                End If
            Next
        Next

        Return TextStructure

    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim value(,,) As String
        value = MultiDFunction("Hello")
        MsgBox(value(0, 0, 0))
    End Sub

    Function MultiDFunction(ByVal text As String) As String(,,)
        Dim msgLen As Integer = text.Length
        Dim value(msgLen + 2, 1, 1) As String
        value(0, 0, 0) = "Hello"

        Return value

    End Function

End Class
