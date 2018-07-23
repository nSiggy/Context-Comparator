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
        Me.RichTextBoxA = New System.Windows.Forms.RichTextBox()
        Me.RichTextBoxB = New System.Windows.Forms.RichTextBox()
        Me.BtCompare = New System.Windows.Forms.Button()
        Me.txtOutput = New System.Windows.Forms.TextBox()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.SuspendLayout()
        '
        'RichTextBoxA
        '
        Me.RichTextBoxA.Location = New System.Drawing.Point(12, 29)
        Me.RichTextBoxA.Name = "RichTextBoxA"
        Me.RichTextBoxA.Size = New System.Drawing.Size(358, 253)
        Me.RichTextBoxA.TabIndex = 0
        Me.RichTextBoxA.Text = ""
        '
        'RichTextBoxB
        '
        Me.RichTextBoxB.Location = New System.Drawing.Point(407, 29)
        Me.RichTextBoxB.Name = "RichTextBoxB"
        Me.RichTextBoxB.Size = New System.Drawing.Size(381, 253)
        Me.RichTextBoxB.TabIndex = 1
        Me.RichTextBoxB.Text = ""
        '
        'BtCompare
        '
        Me.BtCompare.Location = New System.Drawing.Point(258, 331)
        Me.BtCompare.Name = "BtCompare"
        Me.BtCompare.Size = New System.Drawing.Size(75, 23)
        Me.BtCompare.TabIndex = 2
        Me.BtCompare.Text = "Compare"
        Me.BtCompare.UseVisualStyleBackColor = True
        '
        'txtOutput
        '
        Me.txtOutput.Location = New System.Drawing.Point(354, 331)
        Me.txtOutput.Name = "txtOutput"
        Me.txtOutput.ReadOnly = True
        Me.txtOutput.Size = New System.Drawing.Size(100, 20)
        Me.txtOutput.TabIndex = 3
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(354, 373)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 4
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'RichTextBox1
        '
        Me.RichTextBox1.Location = New System.Drawing.Point(477, 300)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.Size = New System.Drawing.Size(330, 350)
        Me.RichTextBox1.TabIndex = 5
        Me.RichTextBox1.Text = ""
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(835, 650)
        Me.Controls.Add(Me.RichTextBox1)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.txtOutput)
        Me.Controls.Add(Me.BtCompare)
        Me.Controls.Add(Me.RichTextBoxB)
        Me.Controls.Add(Me.RichTextBoxA)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents RichTextBoxA As RichTextBox
    Friend WithEvents RichTextBoxB As RichTextBox
    Friend WithEvents BtCompare As Button
    Friend WithEvents txtOutput As TextBox
    Friend WithEvents Button1 As Button
    Friend WithEvents RichTextBox1 As RichTextBox
End Class
