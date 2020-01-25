Imports PlayingCardEntities.Common


Public Class Form1

    Private deck As Deck
    Private WithEvents cards As List(Of Card)


    Private _pbs As PictureBox()

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        Me.KeyPreview = True

        ' Add any initialization after the InitializeComponent() call.
        Me._pbs = Me.FlowLayoutPanel1.Controls.OfType(Of PictureBox).OrderBy(Function(p) p.Name).ToArray
        Me.cards = New List(Of Card)(7)
    End Sub




    Private Sub debug()
        ' royal flush
        Me.cards.Clear() : Me.resetPBs()
        For i = 1 To 7
            Me.cards.Add(New Card(Suit.Clubs, CType(15 - i, Kind)))
        Next
        Me.updatePBs()
        btnCalcualte_Click(Nothing, Nothing)

        'straight flush
        Me.cards.Clear() : Me.resetPBs()
        For i = 1 To 7
            Me.cards.Add(New Card(Suit.Clubs, CType(10 - i, Kind)))
        Next
        Me.updatePBs()
        btnCalcualte_Click(Nothing, Nothing)

        'kind 4
        Me.cards.Clear() : Me.resetPBs()
        Me.cards.Add(New Card(Suit.Clubs, Kind.Ace))
        Me.cards.Add(New Card(Suit.Hearts, Kind.Ace))
        Me.cards.Add(New Card(Suit.Diamonds, Kind.Ace))
        Me.cards.Add(New Card(Suit.Spades, Kind.Ace))
        Me.cards.Add(New Card(Suit.Hearts, Kind.Jack))
        Me.cards.Add(New Card(Suit.Diamonds, Kind.Five))
        Me.cards.Add(New Card(Suit.Spades, Kind.Four))
        Me.updatePBs()
        btnCalcualte_Click(Nothing, Nothing)

        'full house
        Me.cards.Clear() : Me.resetPBs()
        Me.cards.Add(New Card(Suit.Clubs, Kind.Ace))
        Me.cards.Add(New Card(Suit.Hearts, Kind.Ace))
        Me.cards.Add(New Card(Suit.Diamonds, Kind.Ace))
        Me.cards.Add(New Card(Suit.Spades, Kind.Jack))
        Me.cards.Add(New Card(Suit.Hearts, Kind.Jack))
        Me.cards.Add(New Card(Suit.Diamonds, Kind.Five))
        Me.cards.Add(New Card(Suit.Spades, Kind.Four))
        Me.updatePBs()
        btnCalcualte_Click(Nothing, Nothing)

        ' flush
        Me.cards.Clear() : Me.resetPBs()
        Me.cards.Add(New Card(Suit.Clubs, Kind.Eight))
        Me.cards.Add(New Card(Suit.Clubs, Kind.Jack))
        Me.cards.Add(New Card(Suit.Clubs, Kind.Ace))
        Me.cards.Add(New Card(Suit.Clubs, Kind.Five))
        Me.cards.Add(New Card(Suit.Clubs, Kind.Four))
        Me.cards.Add(New Card(Suit.Diamonds, Kind.Ten))
        Me.cards.Add(New Card(Suit.Spades, Kind.Ten))
        Me.updatePBs()
        btnCalcualte_Click(Nothing, Nothing)

        ' straight
        Me.cards.Clear() : Me.resetPBs()
        For i = 1 To 7
            Me.cards.Add(New Card(CType(i Mod 4, Suit), CType(13 - i, Kind)))
        Next
        Me.updatePBs()
        btnCalcualte_Click(Nothing, Nothing)

        ' kind 3
        Me.cards.Clear() : Me.resetPBs()
        Me.cards.Add(New Card(Suit.Clubs, Kind.Eight))
        Me.cards.Add(New Card(Suit.Clubs, Kind.Eight))
        Me.cards.Add(New Card(Suit.Diamonds, Kind.Eight))
        Me.cards.Add(New Card(Suit.Clubs, Kind.Five))
        Me.cards.Add(New Card(Suit.Clubs, Kind.Four))
        Me.cards.Add(New Card(Suit.Diamonds, Kind.Ten))
        Me.cards.Add(New Card(Suit.Spades, Kind.Nine))
        Me.updatePBs()
        btnCalcualte_Click(Nothing, Nothing)

        ' kind 2x2
        Me.cards.Clear() : Me.resetPBs()
        Me.cards.Add(New Card(Suit.Clubs, Kind.Eight))
        Me.cards.Add(New Card(Suit.Clubs, Kind.Eight))
        Me.cards.Add(New Card(Suit.Diamonds, Kind.Five))
        Me.cards.Add(New Card(Suit.Clubs, Kind.Five))
        Me.cards.Add(New Card(Suit.Clubs, Kind.Four))
        Me.cards.Add(New Card(Suit.Diamonds, Kind.Ten))
        Me.cards.Add(New Card(Suit.Spades, Kind.Nine))
        Me.updatePBs()
        btnCalcualte_Click(Nothing, Nothing)

        ' kind 2
        Me.cards.Clear() : Me.resetPBs()
        Me.cards.Add(New Card(Suit.Clubs, Kind.Eight))
        Me.cards.Add(New Card(Suit.Clubs, Kind.Eight))
        Me.cards.Add(New Card(Suit.Diamonds, Kind.Seven))
        Me.cards.Add(New Card(Suit.Clubs, Kind.Five))
        Me.cards.Add(New Card(Suit.Clubs, Kind.Four))
        Me.cards.Add(New Card(Suit.Diamonds, Kind.Ten))
        Me.cards.Add(New Card(Suit.Spades, Kind.Nine))
        Me.updatePBs()
        btnCalcualte_Click(Nothing, Nothing)

        ' high card
        Me.cards.Clear() : Me.resetPBs()
        Me.cards.Add(New Card(Suit.Clubs, Kind.Two))
        Me.cards.Add(New Card(Suit.Clubs, Kind.Eight))
        Me.cards.Add(New Card(Suit.Diamonds, Kind.Seven))
        Me.cards.Add(New Card(Suit.Clubs, Kind.Five))
        Me.cards.Add(New Card(Suit.Clubs, Kind.Four))
        Me.cards.Add(New Card(Suit.Diamonds, Kind.Ten))
        Me.cards.Add(New Card(Suit.Spades, Kind.Nine))
        Me.updatePBs()
        btnCalcualte_Click(Nothing, Nothing)


    End Sub

    Private Sub resetPBs()
        For Each pb In Me._pbs
            pb.BorderStyle = BorderStyle.None
            pb.Size = New Size(160, 200)
            pb.Image = Nothing
        Next
    End Sub

    Private Sub updatePBs()
        For i = 1 To 7
            Me._pbs(i - 1).BorderStyle = BorderStyle.None
            Me._pbs(i - 1).Size = New Size(160, 200)
            Me._pbs(i - 1).Image = Me.getImage(Me.cards.Item(i - 1))
        Next
    End Sub

    Private Sub clearCards()
        Me.cards.Clear()
    End Sub

    Private Sub draw7()
        Try
            Me.clearCards()
            For i = 1 To 7
                Me.cards.Add(Me.deck.Draw)
            Next
            Me.updatePBs()
        Catch ex As Deck.DeckEmptyException
            Me.clearCards()
            Me.deck.reset()
            Me.deck.Shuffle()
            draw7()
        End Try
    End Sub



    Private Function getImage(c As Card) As System.Drawing.Image
        Dim strKind As String
        If c.Kind < 11 Then
            strKind = CInt(c.Kind).ToString
        Else
            strKind = c.Kind.ToString.Substring(0, 1).ToUpper
        End If
        Return My.Resources.ResourceManager.GetObject(c.Suit.ToString.ToLower + strKind, Nothing)
    End Function

    Private Sub Form1_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        If e.KeyCode = Keys.A Then
            debug()
        End If
    End Sub

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        Me.deck = New Deck
        Me.deck.Shuffle()
    End Sub

    Private Sub btnDraw_Click(sender As System.Object, e As System.EventArgs) Handles btnDraw.Click
        Me.lblBestHand.Text = ""
        draw7()
    End Sub

    Private Sub btnCalcualte_Click(sender As System.Object, e As System.EventArgs) Handles btnCalcualte.Click
        Dim a = Stopwatch.StartNew
        Dim best = getBestHand(Me.cards)
        a.Stop()

        Dim indexes = best.Value

        For Each index In indexes
            Me._pbs(index).BorderStyle = BorderStyle.FixedSingle
            Me._pbs(index).Size = New Size(200, 250)
        Next
        Dim strBestHand = best.Key.HandType.ToString
        Me.lblBestHand.Text = strBestHand
        ' todo: center flp
        MsgBox(String.Format("Best Hand: {0}" + System.Environment.NewLine + "Ticks taken to calculate: {1}", strBestHand, a.ElapsedTicks.ToString))
    End Sub
End Class
