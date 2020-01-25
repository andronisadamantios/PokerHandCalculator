Imports PlayingCardEntities.Common
Imports PlayingCardControls


Public Class Form1



    Private _cvs As CardViewer()
    Private _handDetector As PlayingCardEntities.Poker.IHandDetector
    Private _deck As Deck
    Private _cards As List(Of Card)

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        Me.KeyPreview = True

        ' Add any initialization after the InitializeComponent() call.
        Me._cvs = Me.FlowLayoutPanel1.Controls.OfType(Of CardViewer).OrderBy(Function(p) p.Name).ToArray
        Me._handDetector = PlayingCardEntities.Poker.HandDetector.SINGLE_INSTANCE
        Me._deck = New Deck
        Me._cards = New List(Of Card)(7)
    End Sub


    'Private Sub debug()
    '    ' royal flush
    '    Me.cards.Clear() : Me.resetPBs()
    '    For i = 1 To 7
    '        Me.cards.Add(New Card(Suit.Clubs, CType(15 - i, Kind)))
    '    Next
    '    Me.updatePBs()
    '    btnCalcualte_Click(Nothing, Nothing)

    '    'straight flush
    '    Me.cards.Clear() : Me.resetPBs()
    '    For i = 1 To 7
    '        Me.cards.Add(New Card(Suit.Clubs, CType(10 - i, Kind)))
    '    Next
    '    Me.updatePBs()
    '    btnCalcualte_Click(Nothing, Nothing)

    '    'kind 4
    '    Me.cards.Clear() : Me.resetPBs()
    '    Me.cards.Add(New Card(Suit.Clubs, Kind.Ace))
    '    Me.cards.Add(New Card(Suit.Hearts, Kind.Ace))
    '    Me.cards.Add(New Card(Suit.Diamonds, Kind.Ace))
    '    Me.cards.Add(New Card(Suit.Spades, Kind.Ace))
    '    Me.cards.Add(New Card(Suit.Hearts, Kind.Jack))
    '    Me.cards.Add(New Card(Suit.Diamonds, Kind.Five))
    '    Me.cards.Add(New Card(Suit.Spades, Kind.Four))
    '    Me.updatePBs()
    '    btnCalcualte_Click(Nothing, Nothing)

    '    'full house
    '    Me.cards.Clear() : Me.resetPBs()
    '    Me.cards.Add(New Card(Suit.Clubs, Kind.Ace))
    '    Me.cards.Add(New Card(Suit.Hearts, Kind.Ace))
    '    Me.cards.Add(New Card(Suit.Diamonds, Kind.Ace))
    '    Me.cards.Add(New Card(Suit.Spades, Kind.Jack))
    '    Me.cards.Add(New Card(Suit.Hearts, Kind.Jack))
    '    Me.cards.Add(New Card(Suit.Diamonds, Kind.Five))
    '    Me.cards.Add(New Card(Suit.Spades, Kind.Four))
    '    Me.updatePBs()
    '    btnCalcualte_Click(Nothing, Nothing)

    '    ' flush
    '    Me.cards.Clear() : Me.resetPBs()
    '    Me.cards.Add(New Card(Suit.Clubs, Kind.Eight))
    '    Me.cards.Add(New Card(Suit.Clubs, Kind.Jack))
    '    Me.cards.Add(New Card(Suit.Clubs, Kind.Ace))
    '    Me.cards.Add(New Card(Suit.Clubs, Kind.Five))
    '    Me.cards.Add(New Card(Suit.Clubs, Kind.Four))
    '    Me.cards.Add(New Card(Suit.Diamonds, Kind.Ten))
    '    Me.cards.Add(New Card(Suit.Spades, Kind.Ten))
    '    Me.updatePBs()
    '    btnCalcualte_Click(Nothing, Nothing)

    '    ' straight
    '    Me.cards.Clear() : Me.resetPBs()
    '    For i = 1 To 7
    '        Me.cards.Add(New Card(CType(i Mod 4, Suit), CType(13 - i, Kind)))
    '    Next
    '    Me.updatePBs()
    '    btnCalcualte_Click(Nothing, Nothing)

    '    ' kind 3
    '    Me.cards.Clear() : Me.resetPBs()
    '    Me.cards.Add(New Card(Suit.Clubs, Kind.Eight))
    '    Me.cards.Add(New Card(Suit.Clubs, Kind.Eight))
    '    Me.cards.Add(New Card(Suit.Diamonds, Kind.Eight))
    '    Me.cards.Add(New Card(Suit.Clubs, Kind.Five))
    '    Me.cards.Add(New Card(Suit.Clubs, Kind.Four))
    '    Me.cards.Add(New Card(Suit.Diamonds, Kind.Ten))
    '    Me.cards.Add(New Card(Suit.Spades, Kind.Nine))
    '    Me.updatePBs()
    '    btnCalcualte_Click(Nothing, Nothing)

    '    ' kind 2x2
    '    Me.cards.Clear() : Me.resetPBs()
    '    Me.cards.Add(New Card(Suit.Clubs, Kind.Eight))
    '    Me.cards.Add(New Card(Suit.Clubs, Kind.Eight))
    '    Me.cards.Add(New Card(Suit.Diamonds, Kind.Five))
    '    Me.cards.Add(New Card(Suit.Clubs, Kind.Five))
    '    Me.cards.Add(New Card(Suit.Clubs, Kind.Four))
    '    Me.cards.Add(New Card(Suit.Diamonds, Kind.Ten))
    '    Me.cards.Add(New Card(Suit.Spades, Kind.Nine))
    '    Me.updatePBs()
    '    btnCalcualte_Click(Nothing, Nothing)

    '    ' kind 2
    '    Me.cards.Clear() : Me.resetPBs()
    '    Me.cards.Add(New Card(Suit.Clubs, Kind.Eight))
    '    Me.cards.Add(New Card(Suit.Clubs, Kind.Eight))
    '    Me.cards.Add(New Card(Suit.Diamonds, Kind.Seven))
    '    Me.cards.Add(New Card(Suit.Clubs, Kind.Five))
    '    Me.cards.Add(New Card(Suit.Clubs, Kind.Four))
    '    Me.cards.Add(New Card(Suit.Diamonds, Kind.Ten))
    '    Me.cards.Add(New Card(Suit.Spades, Kind.Nine))
    '    Me.updatePBs()
    '    btnCalcualte_Click(Nothing, Nothing)

    '    ' high card
    '    Me.cards.Clear() : Me.resetPBs()
    '    Me.cards.Add(New Card(Suit.Clubs, Kind.Two))
    '    Me.cards.Add(New Card(Suit.Clubs, Kind.Eight))
    '    Me.cards.Add(New Card(Suit.Diamonds, Kind.Seven))
    '    Me.cards.Add(New Card(Suit.Clubs, Kind.Five))
    '    Me.cards.Add(New Card(Suit.Clubs, Kind.Four))
    '    Me.cards.Add(New Card(Suit.Diamonds, Kind.Ten))
    '    Me.cards.Add(New Card(Suit.Spades, Kind.Nine))
    '    Me.updatePBs()
    '    btnCalcualte_Click(Nothing, Nothing)


    'End Sub
    'Private Sub Form1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
    '    If e.KeyCode = Keys.A Then
    '        debug()
    '    End If
    'End Sub

    Private Sub resetUI()
        Me.lblBestHand.Text = ""
        For Each cv In Me._cvs
            cv.BorderStyle = BorderStyle.None
            cv.Size = New Size(160, 200)
            cv.Card = Nothing
        Next
    End Sub

    Private Function getImage(ByVal c As Card) As System.Drawing.Image
        Dim strKind As String
        If c.Kind < 11 Then
            strKind = CInt(c.Kind).ToString
        Else
            strKind = c.Kind.ToString.Substring(0, 1).ToUpper
        End If
        Return My.Resources.ResourceManager.GetObject(c.Suit.ToString.ToLower + strKind, Nothing)
    End Function

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me._deck.Shuffle()
    End Sub

    Private Sub btnDraw7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDraw7.Click
        Try
            Me._cards.Clear()
            Me.resetUI()
            For i = 1 To 7
                Dim c = Me._deck.Draw
                Me._cards.Add(c)
                Me._cvs(i - 1).Card = c
            Next
        Catch ex As DeckEmptyException
            Me._cards.Clear()
            Me._deck = New Deck
            Me._deck.Shuffle()
            btnDraw7_Click(sender, e)
        End Try
    End Sub

    Private Sub btnCalcualte_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalcualte.Click
        Dim a = Stopwatch.StartNew
        Dim best = Me._handDetector.GetBestHandWithIndexes(Me._cards.ToArray)
        a.Stop()

        Dim indexes = best.Value

        For Each index In indexes
            Me._cvs(index).BorderStyle = BorderStyle.FixedSingle
            Me._cvs(index).Size = New Size(200, 250)
        Next
        Dim strBestHand = best.Key.Type.ToString
        Me.lblBestHand.Text = strBestHand
        MsgBox(String.Format("Best Hand: {0}" + System.Environment.NewLine + "Ticks taken to calculate: {1}", strBestHand, a.ElapsedTicks.ToString))
    End Sub

End Class
