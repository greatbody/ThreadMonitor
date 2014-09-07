<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form 重写 Dispose，以清理组件列表。
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

    'Windows 窗体设计器所必需的
    Private components As System.ComponentModel.IContainer

    '注意: 以下过程是 Windows 窗体设计器所必需的
    '可以使用 Windows 窗体设计器修改它。
    '不要使用代码编辑器修改它。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.MoShi = New System.Windows.Forms.ListBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.NewXM = New System.Windows.Forms.TextBox()
        Me.XiangMu = New System.Windows.Forms.ListBox()
        Me.GroupBox3 = New System.Windows.Forms.GroupBox()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button2)
        Me.GroupBox1.Controls.Add(Me.Button1)
        Me.GroupBox1.Controls.Add(Me.MoShi)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(130, 291)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "模式"
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(67, 17)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(55, 22)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "删除"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(7, 17)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(55, 22)
        Me.Button1.TabIndex = 1
        Me.Button1.Text = "新建"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'MoShi
        '
        Me.MoShi.FormattingEnabled = True
        Me.MoShi.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.MoShi.ItemHeight = 12
        Me.MoShi.Location = New System.Drawing.Point(7, 45)
        Me.MoShi.Name = "MoShi"
        Me.MoShi.Size = New System.Drawing.Size(115, 244)
        Me.MoShi.TabIndex = 0
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button4)
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.Controls.Add(Me.NewXM)
        Me.GroupBox2.Controls.Add(Me.XiangMu)
        Me.GroupBox2.Location = New System.Drawing.Point(141, 3)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(192, 291)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "项目编辑"
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(140, 14)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(42, 24)
        Me.Button4.TabIndex = 3
        Me.Button4.Text = "删除"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(92, 14)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(42, 24)
        Me.Button3.TabIndex = 2
        Me.Button3.Text = "新增"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'NewXM
        '
        Me.NewXM.Location = New System.Drawing.Point(8, 17)
        Me.NewXM.Name = "NewXM"
        Me.NewXM.Size = New System.Drawing.Size(79, 21)
        Me.NewXM.TabIndex = 1
        '
        'XiangMu
        '
        Me.XiangMu.FormattingEnabled = True
        Me.XiangMu.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.XiangMu.ItemHeight = 12
        Me.XiangMu.Location = New System.Drawing.Point(8, 45)
        Me.XiangMu.Name = "XiangMu"
        Me.XiangMu.Size = New System.Drawing.Size(174, 244)
        Me.XiangMu.TabIndex = 0
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.CheckBox1)
        Me.GroupBox3.Location = New System.Drawing.Point(341, 3)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(208, 289)
        Me.GroupBox3.TabIndex = 2
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "选项"
        '
        'CheckBox1
        '
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Location = New System.Drawing.Point(15, 21)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(108, 16)
        Me.CheckBox1.TabIndex = 0
        Me.CheckBox1.Text = "结束进程后提示"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(560, 302)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form2"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "模式创建编辑"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents MoShi As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents NewXM As System.Windows.Forms.TextBox
    Friend WithEvents XiangMu As System.Windows.Forms.ListBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents CheckBox1 As System.Windows.Forms.CheckBox
End Class
