Option Strict On

Imports PlayingCardEntities.Common

Public Enum HandType
    None
    HighCard
    Kind2
    Kind2x2
    Kind3
    Straight
    Flush
    FullHouse
    Kind4
    StraightFlush
    RoyalFlush
End Enum



Public Class Hand

    Implements IComparable
    Implements IComparable(Of Hand)



    Private _cards As Card()
    Private _isStraight As Boolean?
    Private _isFlush As Boolean?
    Private _containsA As Boolean?
    Private _handType As HandType?
    Private _isOrdered As Boolean = False
    Private _kickers As Kind()
    Private _grouping As ILookup(Of Kind, Card)


    Private ReadOnly Property lookup As ILookup(Of Kind, Card)
        Get
            If Me._grouping Is Nothing Then
                Me._grouping = Me.Cards.ToLookup(Function(c) c.Kind) '.OrderByDescending(Function(g) g.Count)
            End If
            Return Me._grouping
        End Get
    End Property

    Public ReadOnly Property HandType As HandType
        Get
            If Not Me._handType.HasValue Then
                If Me.IsStraight AndAlso Me.IsFlush Then
                    If Me.ContainsA Then
                        Me._handType = HandType.RoyalFlush
                    Else
                        Me._handType = HandType.StraightFlush
                    End If
                    Return Me._handType.Value
                End If
                Dim groupings = Me.lookup.OrderByDescending(Function(g) g.Count).ToArray
                If groupings(0).Count = 4 Then
                    Me._handType = HandType.Kind4
                ElseIf Me.lookup.Count = 2 Then
                    Me._handType = HandType.FullHouse
                ElseIf Me.IsFlush Then
                    Me._handType = HandType.Flush
                ElseIf Me.IsStraight Then
                    Me._handType = HandType.Straight
                ElseIf groupings(0).Count = 3 Then
                    Me._handType = HandType.Kind3
                ElseIf groupings(0).Count = 2 Then
                    If groupings(1).Count = 2 Then
                        Me._handType = HandType.Kind2x2
                    Else
                        Me._handType = HandType.Kind2
                    End If
                Else
                    Me._handType = HandType.HighCard
                End If
            End If
            Return Me._handType.Value
        End Get
    End Property

    Public ReadOnly Property Cards As IEnumerable(Of Card)
        Get
            Return Me._cards.AsEnumerable
        End Get
    End Property

    Public ReadOnly Property Kickers As IEnumerable(Of Kind)
        Get
            If Me._kickers Is Nothing Then
                Select Case Me.HandType
                    Case _
                            PokerHandCalculator.HandType.RoyalFlush, _
                            PokerHandCalculator.HandType.StraightFlush, _
                            PokerHandCalculator.HandType.Flush, _
                            PokerHandCalculator.HandType.Straight, _
                            PokerHandCalculator.HandType.HighCard
                        Me._kickers = Me._cards.OrderByDescending(Function(c) c.Kind).Select(Function(c) c.Kind).ToArray
                    Case _
                            PokerHandCalculator.HandType.Kind4, _
                            PokerHandCalculator.HandType.FullHouse, _
                            PokerHandCalculator.HandType.Kind3, _
                            PokerHandCalculator.HandType.Kind2x2, _
                            PokerHandCalculator.HandType.Kind2
                        Me._kickers = Me.lookup.OrderByDescending(Function(g) g.Count).Select(Function(g) g.Key).ToArray
                End Select
            End If
            Return Me._kickers
        End Get
    End Property

    Public ReadOnly Property IsFull As Boolean
        Get
            Return Me._cards.Length = 5
        End Get
    End Property
    Public ReadOnly Property ContainsA As Boolean
        Get
            If Not Me._containsA.HasValue Then
                Me._containsA = Me._cards.Any(Function(c) c.Kind = Kind.Ace)
                'Me._containsA = Me.arCards(Me.arCards.Length - 1).Kind = Kind.Ace
            End If
            Return Me._containsA.Value
        End Get
    End Property



    Public ReadOnly Property IsFlush() As Boolean
        Get
            If Not Me.IsFull Then Return False
            If Not Me._isFlush.HasValue Then
                If Me._cards Is Nothing OrElse Me._cards.Length = 0 Then
                    Me._isFlush = False
                End If
                Dim s As Suit = Me._cards.First.Suit
                Me._isFlush = Me.IsFull AndAlso Me._cards.All(Function(c) c.Suit = s)
            End If
            Return Me._isFlush.Value
        End Get
    End Property
    Public ReadOnly Property IsStraight() As Boolean
        Get
            If Not Me.IsFull Then Return False
            If Not Me._isStraight.HasValue Then
                Me._cards = Me._cards.OrderBy(Function(c) c.Kind).ToArray
                Me._isOrdered = True
                Dim k As Kind = Me._cards(0).Kind
                Me._isStraight = True
                For i = 1 To Me._cards.GetUpperBound(0)
                    If Me._cards(i).Kind - k <> 1 Then
                        Me._isStraight = False
                        Exit For
                    End If
                    k = Me._cards(i).Kind
                Next
            End If
            Return Me._isStraight.Value
        End Get
    End Property



    Public Sub New(cards As IEnumerable(Of Card))
        If cards.Count > 5 Then Throw New ArgumentException
        Me._cards = cards.ToArray
    End Sub


    Public Function CompareTo(obj As Object) As Integer Implements System.IComparable.CompareTo
        Return CompareTo(CType(obj, Hand))
    End Function

    Public Function CompareTo1(other As Hand) As Integer Implements System.IComparable(Of Hand).CompareTo
        If Not Me.HandType.Equals(other.HandType) Then
            Return Me.HandType.CompareTo(other.HandType)
        Else
            Dim int As Integer = 0
            Dim enmrt = Me.Kickers.GetEnumerator
            Dim enmrtOther = other.Kickers.GetEnumerator
            While (int = 0 And enmrt.MoveNext And enmrtOther.MoveNext)
                int = enmrt.Current.CompareTo(enmrtOther.Current)
            End While
            Return int
        End If
    End Function
End Class
