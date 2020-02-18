Imports System.ComponentModel
Imports PlayingCardEntities.Common
Imports PlayingCardControls


Public Class Form1


    Private WithEvents _cc As CardChooser
    Private _cvLastClicked As CardViewer
    Private _cvs As CardViewer()
    Private _handDetector As PlayingCardEntities.Poker.IHandDetector
    Private _deck As Deck
    Private WithEvents _cards As BindingList(Of Card)

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()
        Me.KeyPreview = True

        ' Add any initialization after the InitializeComponent() call.
        Me._cc = New CardChooser
        Me._cvs = Me.FlowLayoutPanel1.Controls.OfType(Of CardViewer).OrderBy(Function(p) p.Name).ToArray
        Me._handDetector = PlayingCardEntities.Poker.HandDetector.SINGLE_INSTANCE
        Me._deck = New Deck
        Me._cards = New BindingList(Of Card)
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

    Private Sub Cards_ListChanged(ByVal o As Object, ByVal e As ListChangedEventArgs) Handles _cards.ListChanged
        Select Case e.ListChangedType
            Case ListChangedType.ItemAdded, ListChangedType.ItemChanged
                Me._cvs(e.NewIndex).Card = Me._cards.Item(e.NewIndex)
            Case ListChangedType.ItemDeleted
                Me._cvs(e.NewIndex).Card = Nothing
            Case ListChangedType.Reset
                For Each lmnt In Me._cvs
                    lmnt.Card = Nothing
                Next
        End Select
    End Sub

    Private Sub resetUI()
        Me.lblBestHand.Text = ""
        For Each cv In Me._cvs
            cv.BorderStyle = BorderStyle.None
            cv.Size = New Size(160, 200)
            cv.Card = Nothing
        Next
    End Sub

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
        Dim str = best.Key.Type.ToString
        Me.lblBestHand.Text = str
        str = String.Format("Best Hand: {0}" + System.Environment.NewLine + "Ticks taken to calculate: {1}ms", str, a.ElapsedMilliseconds)
        MessageBox.Show(str, "Results", MessageBoxButtons.OK)
    End Sub

    Private Sub CardViewer_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CardViewer1.MouseDown, CardViewer2.MouseDown, CardViewer3.MouseDown, CardViewer4.MouseDown, CardViewer5.MouseDown, CardViewer6.MouseDown, CardViewer7.MouseDown
        Dim cv As CardViewer = CType(sender, CardViewer)
        Me._cvLastClicked = cv
        If cv.Card IsNot Nothing Then
            Me._cc.SelectedSuit = cv.Card.Suit
            Me._cc.SelectedKind = cv.Card.Kind
        End If

        Me._cc.Show(cv, e.Location)

    End Sub

    Private Sub CardChooser_CardReady(ByVal o As Object, ByVal e As EventArgs) Handles _cc.CardReady
        If Me._cvLastClicked Is Nothing Then
            Return
        End If
        Dim index = Array.IndexOf(Me._cvs, Me._cvLastClicked)
        Me._cards.Item(index) = New Card(Me._cc.SelectedSuit, Me._cc.SelectedKind)
    End Sub

End Class
