Imports System.ComponentModel
Imports PlayingCardEntities.Common
Imports PlayingCardControls
Imports PlayingCardEntities.Poker
Imports DamisLib
Imports DamisLib.FormsX


Public Class Form1

    Public showBackGroundImage As Boolean = True
    Public showLayoutPerformanceTip As Boolean = True


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        Me.KeyPreview = True
        Me.BackgroundImage = If(Me.showBackGroundImage, My.Resources.felt1, Nothing)
        Me.pnlTop.Visible = Me.showLayoutPerformanceTip

        ' Add any initialization after the InitializeComponent() call.
        Me.suspendAllLayout()
        Me.cvm.Reset(7)
        Me.resetSizesCardViewers()
        Me.resumeAllLayout()

    End Sub

    Private Sub suspendAllLayout()
        Me.BackgroundImage = Nothing
    End Sub

    Private Sub resumeAllLayout()
        Me.BackgroundImage = If(Me.showBackGroundImage, My.Resources.felt1, Nothing)
    End Sub

    Private Sub Cards_ListChanged(ByVal o As Object, ByVal e As EventArgs) Handles cvm.CardListChanged
        Me.btnCalculate.Enabled = Me.cvm.Cards.Length >= 5
        Me.btnClear.Enabled = Me.cvm.Cards.Length > 0
        Me.resetSizesCardViewers()
    End Sub

    Private Sub resetSizesCardViewers()
        Me.suspendAllLayout()
        For Each lmnt In Me.cvm.CardViewers
            lmnt.BorderStyle = BorderStyle.FixedSingle
            lmnt.Size = New Size(100, 125)
        Next
        Me.resumeAllLayout()
    End Sub

    Private Sub clear()
        Me.resetSizesCardViewers()
        Me.cvm.Clear()
        Me.lblBestHand.Text = String.Empty
    End Sub

    Private Sub draw7()
        Me.clear()
        Me.cvm.Cards = Deck.GetRandomCards(7)
    End Sub

    Private Sub findBestHand()
        Dim cards As Card() = Me.cvm.Cards
        If cards.Length < 5 Then
            Throw New ArgumentException("There have to be least 5 cards.")
        ElseIf cards.Distinct.Count <> cards.Count Then
            Throw New ArgumentException("Duplicate cards not allowed. All cards must be unique.")
        End If

        Dim bestHand = HandDetectors.DEFAULT.FindBestHand(cards)

        ' find the card viewers (that contain the cards that where selected by the hand detector as the winning hand) and highlight them
        Me.suspendAllLayout()
        For Each lmnt In Me.cvm.CardViewers.Where(Function(cv) bestHand.Cards.Any(Function(c) c.Equals(cv.Card)))
            lmnt.BorderStyle = BorderStyle.FixedSingle
            lmnt.Size = New Size(120, 150)
        Next
        Me.resumeAllLayout()

        Dim str = bestHand.Type.ToString
        Me.lblBestHand.Text = str
        MessageBox.Show(String.Format("Best Hand: {0}", str), "Result", MessageBoxButtons.OK)
    End Sub


    Private Sub btnDraw7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDraw7.Click
        Me.draw7()
    End Sub

    Private Sub btnFindBestHand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalculate.Click
        Try
            Me.findBestHand()
        Catch ex As ArgumentException
            MessageBox.Show(ex.Message, "Cannot find best hand", MessageBoxButtons.OK, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1)
        End Try
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        Me.clear()
    End Sub

    Private Sub llRemoveBackGroundImage_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs) Handles llRemoveBackGroundImage.LinkClicked
        If Me.showBackGroundImage Then
            Me.showBackGroundImage = False
            Me.BackgroundImage = Nothing
            Me.llRemoveBackGroundImage.Text = "Restore BackGround Image"
        Else
            Me.showBackGroundImage = True
            Me.BackgroundImage = My.Resources.felt1
            Me.llRemoveBackGroundImage.Text = "Remove BackGround Image"
        End If
    End Sub

    Private Sub Form1_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown
        If Me.cvm.SelectedCardViewers.Count <> 1 Then
            Return
        End If
        Dim cc As CardChooser = Me.cvm.CardChooser
        Select Case e.KeyData
            Case Keys.S
                cc.SelectedSuit = Suit.Spades
            Case Keys.C
                cc.SelectedSuit = Suit.Clubs
            Case Keys.H
                cc.SelectedSuit = Suit.Hearts
            Case Keys.D
                cc.SelectedSuit = Suit.Diamonds
            Case Keys.A
                cc.SelectedKind = Kind.Ace
            Case Keys.K
                cc.SelectedKind = Kind.King
            Case Keys.Q
                cc.SelectedKind = Kind.Queen
            Case Keys.J
                cc.SelectedKind = Kind.Jack
            Case Keys.T, Keys.D0, Keys.NumPad0
                cc.SelectedKind = Kind.Ten
            Case Keys.D2, Keys.NumPad2
                cc.SelectedKind = Kind.Two
            Case Keys.D3, Keys.NumPad3
                cc.SelectedKind = Kind.Three
            Case Keys.D4, Keys.NumPad4
                cc.SelectedKind = Kind.Four
            Case Keys.D5, Keys.NumPad5
                cc.SelectedKind = Kind.Five
            Case Keys.D6, Keys.NumPad6
                cc.SelectedKind = Kind.Six
            Case Keys.D7, Keys.NumPad7
                cc.SelectedKind = Kind.Seven
            Case Keys.D8, Keys.NumPad8
                cc.SelectedKind = Kind.Eight
            Case Keys.D9, Keys.NumPad9
                cc.SelectedKind = Kind.Nine
        End Select
    End Sub


#Region "run till royal flush"
    'Private Sub toggleRunTillRoyalFlush()
    '    If Me.bgw.IsBusy Then
    '        Me.bgw.CancelAsync()
    '        'Me.btnRunTillRoyalFlush.Text = "Run Till Royal Flush"
    '    Else
    '        Me.bgw.RunWorkerAsync()
    '        'Me.btnRunTillRoyalFlush.Text = "Stop"
    '    End If
    'End Sub
    'Private Sub bgw_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgw.DoWork
    '    Dim hand As IHand = Nothing
    '    Dim cards As Card()
    '    Dim t As Tuple(Of Card(), IHand)
    '    Dim i As Integer = 0
    '    Do
    '        cards = Me.draw7cards
    '        hand = Me._handDetector.FindBestHand(cards)
    '        i += 1
    '        If i Mod 100 = 0 Then
    '            t = New Tuple(Of Card(), IHand)(cards, hand)
    '            Me.bgw.ReportProgress(-1, t)
    '        End If
    '    Loop While Not Me.bgw.CancellationPending AndAlso hand.Type.Value <> IHandType.HandTypeValue.RoyalFlush
    '    If Me.bgw.CancellationPending Then
    '        e.Cancel = True
    '    Else
    '        t = New Tuple(Of Card(), IHand)(cards, hand)
    '        Me.bgw.ReportProgress(1, t)
    '    End If
    'End Sub
    'Private Sub bgw_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bgw.ProgressChanged

    '    Dim t = CType(e.UserState, Tuple(Of Card(), IHand))
    '    Dim cards = t.Item1
    '    Dim hand = t.Item2

    '    Me.cvm.Cards = cards
    '    Me.lblBestHand.Text = hand.Type.ToString
    'End Sub
    'Private Sub bgw_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw.RunWorkerCompleted
    '    If e.Cancelled Then

    '    ElseIf e.Error IsNot Nothing Then
    '        MessageBox.Show(e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
    '    Else
    '        MessageBox.Show("Royal Flush found.", "Finished", MessageBoxButtons.OK)
    '    End If
    'End Sub
    'Private Sub btnRunTillRoyalFlush_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
    '    Me.toggleRunTillRoyalFlush()
    'End Sub
    'Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    '    If Me.bgw.IsBusy Then
    '        Me.bgw.CancelAsync()
    '    End If
    'End Sub
#End Region

#Region "performance is very slow in windows forms with responsive layout and background image"
    'Private ReadOnly imageBackground_FELT As Image
    'Public showBackGroundImage As Boolean

    ' when form starts
    'Me.imageBackground_FELT = Me.BackgroundImage
    'Me.showBackGroundImage = True
    ' end when form starts

    'Private Sub LinkLabel1_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
    '    Me.showBackGroundImage = False
    '    Me.BackgroundImage = Nothing
    'End Sub

    'Private Sub LinkLabel2_LinkClicked(ByVal sender As System.Object, ByVal e As System.Windows.Forms.LinkLabelLinkClickedEventArgs)
    '    Me.showBackGroundImage = True
    '    Me.BackgroundImage = imageBackground_FELT
    'End Sub

    'Private Sub Form1_ResizeBegin(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.ResizeBegin
    '    Me.suspendAllLayout()
    'End Sub

    'Private Sub Form1_ResizeEnd(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.ResizeEnd
    '    Me.resumeAllLayout()
    'End Sub

    'Private Sub suspendAllLayout()
    '    Me.SuspendDrawing()
    '    Me.SuspendLayout()
    '    Me.BackgroundImage = Nothing
    '    Me.pnlButtons.SuspendLayout()
    '    Me.cvm.SuspendLayout()
    '    For Each lmnt In Me.cvm.Controls.Cast(Of Control)()
    '        lmnt.SuspendLayout()
    '    Next

    'End Sub

    'Private Sub resumeAllLayout()
    '    For Each lmnt In Me.cvm.Controls.Cast(Of Control)()
    '        lmnt.ResumeLayout(True)
    '    Next
    '    Me.cvm.ResumeLayout(True)
    '    Me.pnlButtons.ResumeLayout(True)
    '    Me.BackgroundImage = If(Me.showBackGroundImage, imageBackground_FELT, Nothing)
    '    Me.ResumeLayout(True)
    '    Me.ResumeDrawing(True)
    'End Sub
#End Region

    Private Sub btnCloseInfo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCloseTip.Click
        Me.lblInfo.Visible = False
        Me.btnCloseTip.Visible = False
        Me.pnlTop.BackColor = Color.Transparent
    End Sub
End Class
