Option Strict On

Imports PlayingCardEntities.Common


Public Module calc

    Private _perms As Integer()()

    Private ReadOnly Property perms_5_7 As Integer()()
        Get
            If _perms Is Nothing Then
                _perms = PermutationsCombinations.EF.get(False, False).getEnumerator(7, 5).ToArray
                ' not needed, because they are 0-based by default
                'For i = 0 To _perms.GetUpperBound(0)
                '    For j = 0 To _perms(i).GetUpperBound(0)
                '        _perms(i)(j) -= 1
                '    Next
                'Next
            End If
            Return _perms
        End Get
    End Property

    Public Function getBestHand(cards As IEnumerable(Of Card)) As KeyValuePair(Of Hand, Integer())
        Return getHandsMeIndexes(cards).OrderByDescending(Function(h) h.Key).First
    End Function

    Private Function getHandsMeIndexes(cards As IEnumerable(Of Card)) As IDictionary(Of Hand, Integer())
        Dim cards1 = cards.ToArray
        Dim hands As New Dictionary(Of Hand, Integer())
        Dim h As Hand
        For Each p In perms_5_7
            h = New Hand(p.Select(Function(int1) cards1(int1)))
            hands.Add(h, p)
        Next
        Return hands
    End Function
End Module