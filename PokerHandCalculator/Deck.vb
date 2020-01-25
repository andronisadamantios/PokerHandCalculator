Imports PlayingCardEntities.Common

Public Class Deck

    Public Class DeckEmptyException
        Inherits System.Exception
        Public Overrides ReadOnly Property Message As String
            Get
                Return "The deck is empty."
            End Get
        End Property
    End Class

    Private _cards As Generic.Queue(Of Card)

    Protected Friend Sub New()
        _cards = New Generic.Queue(Of Card)
        Me.reset()
    End Sub

    Public Sub reset()
        Me._cards.Clear()
        For Each suit As Suit In System.Enum.GetValues(GetType(Suit))
            For Each kind As Kind In System.Enum.GetValues(GetType(Kind))
                _cards.Enqueue(New Card(suit, kind))
            Next
        Next
    End Sub


    Public Sub Shuffle()
        Randomize()
        Dim list As New List(Of Card)(Me._cards)
        For i = 1 To list.Count
            Dim ran As Integer = CInt(Math.Floor(_cards.Count * Rnd()))
            Dim card As Card = list(i - 1)
            list(i - 1) = list(ran)
            list(ran) = card
        Next
        Me._cards = New Queue(Of Card)(list)
    End Sub



    Protected Friend Function Draw() As Card
        Try
            Return _cards.Dequeue
        Catch x As ArgumentNullException
            Return Nothing
        Catch x As InvalidOperationException
            Throw New DeckEmptyException
        Catch x As Exception
            Throw x
        End Try
    End Function


End Class
