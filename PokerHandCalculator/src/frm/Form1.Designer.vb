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
        Me.btnCalculate = New System.Windows.Forms.Button
        Me.pnlButtons = New System.Windows.Forms.Panel
        Me.btnClear = New System.Windows.Forms.Button
        Me.lblBestHand = New System.Windows.Forms.Label
        Me.cvm = New PlayingCardControls.CardViewerMulti
        Me.tlpMain = New System.Windows.Forms.TableLayoutPanel
        Me.pnlButtons.SuspendLayout()
        Me.tlpMain.SuspendLayout()
        Me.SuspendLayout()
        '
        'btnDraw7
        '
        Me.btnDraw7.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnDraw7.Location = New System.Drawing.Point(362, 6)
        Me.btnDraw7.Margin = New System.Windows.Forms.Padding(2)
        Me.btnDraw7.Name = "btnDraw7"
        Me.btnDraw7.Size = New System.Drawing.Size(170, 43)
        Me.btnDraw7.TabIndex = 0
        Me.btnDraw7.Text = "Draw 7 Cards"
        Me.btnDraw7.UseVisualStyleBackColor = True
        '
        'btnCalculate
        '
        Me.btnCalculate.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnCalculate.Enabled = False
        Me.btnCalculate.Location = New System.Drawing.Point(536, 6)
        Me.btnCalculate.Margin = New System.Windows.Forms.Padding(2)
        Me.btnCalculate.Name = "btnCalculate"
        Me.btnCalculate.Size = New System.Drawing.Size(170, 43)
        Me.btnCalculate.TabIndex = 0
        Me.btnCalculate.Text = "Calculate Hand"
        Me.btnCalculate.UseVisualStyleBackColor = True
        '
        'pnlButtons
        '
        Me.pnlButtons.AutoSize = True
        Me.pnlButtons.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.pnlButtons.BackColor = System.Drawing.Color.Transparent
        Me.pnlButtons.Controls.Add(Me.btnClear)
        Me.pnlButtons.Controls.Add(Me.btnCalculate)
        Me.pnlButtons.Controls.Add(Me.btnDraw7)
        Me.pnlButtons.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.pnlButtons.Location = New System.Drawing.Point(0, 412)
        Me.pnlButtons.Margin = New System.Windows.Forms.Padding(2)
        Me.pnlButtons.Name = "pnlButtons"
        Me.pnlButtons.Size = New System.Drawing.Size(892, 51)
        Me.pnlButtons.TabIndex = 2
        '
        'btnClear
        '
        Me.btnClear.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnClear.Enabled = False
        Me.btnClear.Location = New System.Drawing.Point(711, 6)
        Me.btnClear.Margin = New System.Windows.Forms.Padding(2)
        Me.btnClear.Name = "btnClear"
        Me.btnClear.Size = New System.Drawing.Size(170, 43)
        Me.btnClear.TabIndex = 0
        Me.btnClear.Text = "Clear"
        Me.btnClear.UseVisualStyleBackColor = True
        '
        'lblBestHand
        '
        Me.lblBestHand.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.lblBestHand.AutoSize = True
        Me.lblBestHand.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBestHand.Location = New System.Drawing.Point(446, 22)
        Me.lblBestHand.Margin = New System.Windows.Forms.Padding(2, 0, 2, 0)
        Me.lblBestHand.Name = "lblBestHand"
        Me.lblBestHand.Size = New System.Drawing.Size(0, 39)
        Me.lblBestHand.TabIndex = 2
        Me.lblBestHand.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'cvm
        '
        Me.cvm.AlwaysShow = False
        Me.cvm.Anchor = System.Windows.Forms.AnchorStyles.None
        Me.cvm.AutoSize = True
        Me.cvm.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.cvm.BackColor = System.Drawing.Color.Transparent
        Me.cvm.Cards = New PlayingCardEntities.Common.Card(-1) {}
        Me.cvm.Location = New System.Drawing.Point(446, 247)
        Me.cvm.Margin = New System.Windows.Forms.Padding(4)
        Me.cvm.Name = "cvm"
        Me.cvm.Size = New System.Drawing.Size(0, 0)
        Me.cvm.TabIndex = 3
        Me.cvm.WithLabels = False
        Me.cvm.WrapContents = False
        '
        'tlpMain
        '
        Me.tlpMain.BackColor = System.Drawing.Color.Transparent
        Me.tlpMain.ColumnCount = 1
        Me.tlpMain.ColumnStyles.Add(New System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.Controls.Add(Me.lblBestHand, 0, 0)
        Me.tlpMain.Controls.Add(Me.cvm, 0, 1)
        Me.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill
        Me.tlpMain.Location = New System.Drawing.Point(0, 0)
        Me.tlpMain.Margin = New System.Windows.Forms.Padding(2)
        Me.tlpMain.Name = "tlpMain"
        Me.tlpMain.RowCount = 2
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 83.0!))
        Me.tlpMain.RowStyles.Add(New System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100.0!))
        Me.tlpMain.Size = New System.Drawing.Size(892, 412)
        Me.tlpMain.TabIndex = 3
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(120.0!, 120.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi
        Me.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch
        Me.ClientSize = New System.Drawing.Size(892, 463)
        Me.Controls.Add(Me.tlpMain)
        Me.Controls.Add(Me.pnlButtons)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.KeyPreview = True
        Me.Name = "Form1"
        Me.ShowIcon = False
        Me.Text = "Poker Hand Calculator"
        Me.pnlButtons.ResumeLayout(False)
        Me.tlpMain.ResumeLayout(False)
        Me.tlpMain.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnDraw7 As System.Windows.Forms.Button
    Friend WithEvents btnCalculate As System.Windows.Forms.Button
    Friend WithEvents pnlButtons As System.Windows.Forms.Panel
    Friend WithEvents lblBestHand As System.Windows.Forms.Label
    Friend WithEvents cvm As PlayingCardControls.CardViewerMulti
    Friend WithEvents tlpMain As System.Windows.Forms.TableLayoutPanel
    Friend WithEvents btnClear As System.Windows.Forms.Button

End Class
