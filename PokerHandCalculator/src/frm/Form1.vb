﻿Imports System.ComponentModel
Imports PlayingCardEntities.Common
Imports PlayingCardControls
Imports PlayingCardEntities.Poker
Imports DamisLib


Public Class Form1

    Private ReadOnly _handDetector As PlayingCardEntities.Poker.IHandDetector
    Private _deck As Deck



    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        Me.KeyPreview = True
        ' store the image extracted from the resources of the form to a variable

        ' Add any initialization after the InitializeComponent() call.
        Me._deck = New Deck(True)
        Me._handDetector = PlayingCardEntities.Poker.HandDetectors.DEFAULT

        Me.cvm.Reset(7)

    End Sub

    Private Sub Cards_ListChanged(ByVal o As Object, ByVal e As EventArgs) Handles cvm.CardListChanged
        Me.btnCalculate.Enabled = Me.cvm.Cards.Length >= 5
    End Sub


    Private Function draw7cards() As Card()
        Me._deck.Reset(True)
        Return DamisLib.EnumerableInfinite(Of Card).Get(AddressOf Me._deck.Draw).Take(7).ToArray
    End Function

    Private Sub draw7()
        If Me.InvokeRequired Then
            Me.Invoke(New System.Action(AddressOf Me.draw7))
            Return
        End If

        For Each lmnt In Me.cvm.CardViewers
            lmnt.BorderStyle = BorderStyle.FixedSingle
            lmnt.Size = New Size(128, 160)
        Next
        Me.cvm.Cards = Me.draw7cards
    End Sub

    Private Sub findBestHand()
        Dim cards As Card() = Me.cvm.Cards
        If cards.Length < 5 Then
            Return
        End If

        Dim bestHand = Me._handDetector.FindBestHand(cards)

        ' find the card viewers (that contain the cards that where selected by the hand detector as the winning hand) and highlight them
        For Each lmnt In Me.cvm.CardViewers.Where(Function(cv) bestHand.Cards.Any(Function(c) c.Equals(cv.Card)))
            lmnt.BorderStyle = BorderStyle.FixedSingle
            lmnt.Size = New Size(160, 200)
        Next

        Dim str = bestHand.Type.ToString
        Me.lblBestHand.Text = str
        MessageBox.Show(String.Format("Best Hand: {0}", str), "Result", MessageBoxButtons.OK)
    End Sub

    Private Sub toggleRunTillRoyalFlush()
        If Me.bgw.IsBusy Then
            Me.bgw.CancelAsync()
            'Me.btnRunTillRoyalFlush.Text = "Run Till Royal Flush"
        Else
            Me.bgw.RunWorkerAsync()
            'Me.btnRunTillRoyalFlush.Text = "Stop"
        End If
    End Sub
    Private Sub bgw_DoWork(ByVal sender As System.Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles bgw.DoWork
        Dim hand As IHand = Nothing
        Dim cards As Card()
        Dim t As Tuple(Of Card(), IHand)
        Dim i As Integer = 0
        Do
            cards = Me.draw7cards
            hand = Me._handDetector.FindBestHand(cards)
            i += 1
            If i Mod 100 = 0 Then
                t = New Tuple(Of Card(), IHand)(cards, hand)
                Me.bgw.ReportProgress(-1, t)
            End If
        Loop While Not Me.bgw.CancellationPending AndAlso hand.Type.Value <> IHandType.HandTypeValue.RoyalFlush
        If Me.bgw.CancellationPending Then
            e.Cancel = True
        Else
            t = New Tuple(Of Card(), IHand)(cards, hand)
            Me.bgw.ReportProgress(1, t)
        End If
    End Sub
    Private Sub bgw_ProgressChanged(ByVal sender As System.Object, ByVal e As System.ComponentModel.ProgressChangedEventArgs) Handles bgw.ProgressChanged

        Dim t = CType(e.UserState, Tuple(Of Card(), IHand))
        Dim cards = t.Item1
        Dim hand = t.Item2

        Me.cvm.Cards = cards
        Me.lblBestHand.Text = hand.Type.ToString
    End Sub
    Private Sub bgw_RunWorkerCompleted(ByVal sender As System.Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles bgw.RunWorkerCompleted
        If e.Cancelled Then

        ElseIf e.Error IsNot Nothing Then
            MessageBox.Show(e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Else
            MessageBox.Show("Royal Flush found.", "Finished", MessageBoxButtons.OK)
        End If
    End Sub




    Private Sub btnDraw7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDraw7.Click
        Me.draw7()
    End Sub
    Private Sub btnFindBestHand_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalculate.Click
        Me.findBestHand()
    End Sub
    Private Sub btnRunTillRoyalFlush_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        Me.toggleRunTillRoyalFlush()
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        If Me.bgw.IsBusy Then
            Me.bgw.CancelAsync()
        End If
    End Sub



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



End Class
