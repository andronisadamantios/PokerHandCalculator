<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnDraw7 = New System.Windows.Forms.Button
        Me.FlowLayoutPanel1 = New System.Windows.Forms.FlowLayoutPanel
        Me.CardViewer1 = New PlayingCardControls.CardViewer
        Me.CardViewer2 = New PlayingCardControls.CardViewer
        Me.CardViewer3 = New PlayingCardControls.CardViewer
        Me.CardViewer4 = New PlayingCardControls.CardViewer
        Me.CardViewer5 = New PlayingCardControls.CardViewer
        Me.CardViewer6 = New PlayingCardControls.CardViewer
        Me.CardViewer7 = New PlayingCardControls.CardViewer
        Me.btnCalcualte = New System.Windows.Forms.Button
        Me.pnlButtons = New System.Windows.Forms.Panel
        Me.TableLayoutPanel1 = New System.Windows.Forms.TableLayoutPanel
        Me.lblBestHand = New System.Windows.Forms.Label
        Me.FlowLayoutPanel1.SuspendLayout()
        Me.pnlButtons.SuspendLayout()
        Me.TableLayoutPanel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnDraw7
        '
        Me.btnDraw7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDraw7.Location = New System.Drawing.Point(1069, 6)
        Me.btnDraw7.Name = "btnDraw7"
        Me.btnDraw7.Size = New System.Drawing.Size(164, 52)
        Me.btnDraw7.TabIndex = 0
        Me.btnDraw7.Text = "Draw 7 Cards"
        Me.btnDraw7.UseVisualStyleBackColor = True
        '
        'FlowLayoutPanel1
        '
        Me.FlowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.FlowLayoutPanel1.AutoSize = True
        Me.FlowLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.FlowLayoutPanel1.Controls.Add(Me.CardViewer1)
        Me.FlowLayoutPanel1.Controls.Add(Me.CardViewer2)
        Me.FlowLayoutPanel1.Controls.Add(Me.CardViewer3)
        Me.FlowLayoutPanel1.Controls.Add(Me.CardViewer4)
        Me.FlowLayoutPanel1.Controls.Add(Me.CardViewer5)
        Me.FlowLayoutPanel1.Controls.Add(Me.CardViewer6)
        Me.FlowLayoutPanel1.Controls.Add(Me.CardViewer7)
        Me.FlowLayoutPanel1.Location = New System.Drawing.Point(325, 274)
        Me.FlowLayoutPanel1.Name = "FlowLayoutPanel1"
        Me.FlowLayoutPanel1.Size = New System.Drawing.Size(756, 135)
        Me.FlowLayoutPanel1.TabIndex = 1
        '
        'CardViewer1
        '
        Me.CardViewer1.AlwaysShow = True
        Me.CardViewer1.Card = Nothing
        Me.CardViewer1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CardViewer1.Location = New System.Drawing.Point(4, 5)
        Me.CardViewer1.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CardViewer1.MinimumSize = New System.Drawing.Size(40, 50)
        Me.CardViewer1.Name = "CardViewer1"
        Me.CardViewer1.Size = New System.Drawing.Size(100, 125)
        Me.CardViewer1.TabIndex = 0
        Me.CardViewer1.WithLabel = False
        '
        'CardViewer2
        '
        Me.CardViewer2.AlwaysShow = True
        Me.CardViewer2.Card = Nothing
        Me.CardViewer2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CardViewer2.Location = New System.Drawing.Point(112, 5)
        Me.CardViewer2.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CardViewer2.MinimumSize = New System.Drawing.Size(40, 50)
        Me.CardViewer2.Name = "CardViewer2"
        Me.CardViewer2.Size = New System.Drawing.Size(100, 125)
        Me.CardViewer2.TabIndex = 0
        Me.CardViewer2.WithLabel = False
        '
        'CardViewer3
        '
        Me.CardViewer3.AlwaysShow = True
        Me.CardViewer3.Card = Nothing
        Me.CardViewer3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CardViewer3.Location = New System.Drawing.Point(220, 5)
        Me.CardViewer3.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CardViewer3.MinimumSize = New System.Drawing.Size(40, 50)
        Me.CardViewer3.Name = "CardViewer3"
        Me.CardViewer3.Size = New System.Drawing.Size(100, 125)
        Me.CardViewer3.TabIndex = 0
        Me.CardViewer3.WithLabel = False
        '
        'CardViewer4
        '
        Me.CardViewer4.AlwaysShow = True
        Me.CardViewer4.Card = Nothing
        Me.CardViewer4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CardViewer4.Location = New System.Drawing.Point(328, 5)
        Me.CardViewer4.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CardViewer4.MinimumSize = New System.Drawing.Size(40, 50)
        Me.CardViewer4.Name = "CardViewer4"
        Me.CardViewer4.Size = New System.Drawing.Size(100, 125)
        Me.CardViewer4.TabIndex = 0
        Me.CardViewer4.WithLabel = False
        '
        'CardViewer5
        '
        Me.CardViewer5.AlwaysShow = True
        Me.CardViewer5.Card = Nothing
        Me.CardViewer5.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CardViewer5.Location = New System.Drawing.Point(436, 5)
        Me.CardViewer5.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CardViewer5.MinimumSize = New System.Drawing.Size(40, 50)
        Me.CardViewer5.Name = "CardViewer5"
        Me.CardViewer5.Size = New System.Drawing.Size(100, 125)
        Me.CardViewer5.TabIndex = 0
        Me.CardViewer5.WithLabel = False
        '
        'CardViewer6
        '
        Me.CardViewer6.AlwaysShow = True
        Me.CardViewer6.Card = Nothing
        Me.CardViewer6.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CardViewer6.Location = New System.Drawing.Point(544, 5)
        Me.CardViewer6.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CardViewer6.MinimumSize = New System.Drawing.Size(40, 50)
        Me.CardViewer6.Name = "CardViewer6"
        Me.CardViewer6.Size = New System.Drawing.Size(100, 125)
        Me.CardViewer6.TabIndex = 0
        Me.CardViewer6.WithLabel = False
        '
        'CardViewer7
        '
        Me.CardViewer7.AlwaysShow = True
        Me.CardViewer7.Card = Nothing
        Me.CardViewer7.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CardViewer7.Location = New System.Drawing.Point(652, 5)
        Me.CardViewer7.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.CardViewer7.MinimumSize = New System.Drawing.Size(40, 50)
        Me.CardViewer7.Name = "CardViewer7"
        Me.CardViewer7.Size = New System.Drawing.Size(100, 125)
        Me.CardViewer7.TabIndex = 0
        Me.CardViewer7.WithLabel = False
        '
        'btnCalcualte
        '
        Me.btnCalcualte.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCalcualte.Location = New System.Drawing.Point(1239, 6)
        Me.btnCalcualte.Name = "btnCalcualte"
        Me.btnCalcualte.Size = New System.Drawing.Size(164, 52)
        Me.btnCalcualte.TabIndex = 0
        Me.btnCalcualte.Text = "Calculate Hand"
        Me.btnCalcualte.UseVisualStyleBackColor = True
        '
        'pnlButtons
        '
        Me.pnlButtons.AutoSize = True
        Me.pnlButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlButtons.Controls.Add(Me.btnCalcualte)
        Me.pnlButtons.Controls.Add(Me.btnDraw7)
        Me.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlButtons.Location = New System.Drawing.Point(0, 584)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(1406, 61)
        Me.pnlButtons.TabIndex = 2
        '
        'TableLayoutPanel1
        '
        Me.TableLayoutPanel1.ColumnCount = 1
        Me.TableLayoutPanel1.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Controls.Add(Me.FlowLayoutPanel1, 0, 1)
        Me.TableLayoutPanel1.Controls.Add(Me.lblBestHand, 0, 0)
        Me.TableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TableLayoutPanel1.Location = New System.Drawing.Point(0, 0)
        Me.TableLayoutPanel1.Name = "TableLayoutPanel1"
        Me.TableLayoutPanel1.RowCount = 2
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100.0!))
        Me.TableLayoutPanel1.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.TableLayoutPanel1.Size = New System.Drawing.Size(1406, 584)
        Me.TableLayoutPanel1.TabIndex = 3
        '
        'lblBestHand
        '
        Me.lblBestHand.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblBestHand.AutoSize = True
        Me.lblBestHand.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBestHand.Location = New System.Drawing.Point(703, 27)
        Me.lblBestHand.Name = "lblBestHand"
        Me.lblBestHand.Size = New System.Drawing.Size(0, 46)
        Me.lblBestHand.TabIndex = 2
        Me.lblBestHand.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(12.0!, 25.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1406, 645)
        Me.Controls.Add(Me.TableLayoutPanel1)
        Me.Controls.Add(Me.pnlButtons)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Margin = New System.Windows.Forms.Padding(4)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.FlowLayoutPanel1.ResumeLayout(False)
        Me.pnlButtons.ResumeLayout(False)
        Me.TableLayoutPanel1.ResumeLayout(False)
        Me.TableLayoutPanel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnDraw7 As System.Windows.Forms.Button
    Friend WithEvents FlowLayoutPanel1 As System.Windows.Forms.FlowLayoutPanel
    Friend WithEvents btnCalcualte As System.Windows.Forms.Button
    Friend WithEvents pnlButtons As System.Windows.Forms.Panel
    Friend WithEvents TableLayoutPanel1 As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents lblBestHand As System.Windows.Forms.Label
    Friend WithEvents CardViewer1 As PlayingCardControls.CardViewer
    Friend WithEvents CardViewer2 As PlayingCardControls.CardViewer
    Friend WithEvents CardViewer3 As PlayingCardControls.CardViewer
    Friend WithEvents CardViewer4 As PlayingCardControls.CardViewer
    Friend WithEvents CardViewer5 As PlayingCardControls.CardViewer
    Friend WithEvents CardViewer6 As PlayingCardControls.CardViewer
    Friend WithEvents CardViewer7 As PlayingCardControls.CardViewer

End Class
