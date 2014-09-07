<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.NotifyIcon1 = New System.Windows.Forms.NotifyIcon(Me.components)
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.显示主界面ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.退出程序ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button6 = New System.Windows.Forms.Button()
        Me.DelForbid = New System.Windows.Forms.Button()
        Me.AddForbid = New System.Windows.Forms.Button()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ClassMode = New System.Windows.Forms.ListBox()
        Me.Forbidlist = New System.Windows.Forms.ListBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Running = New System.Windows.Forms.ListBox()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.WhitePro = New System.Windows.Forms.ListBox()
        Me.ExitProgram = New System.Windows.Forms.Button()
        Me.SetAuto = New System.Windows.Forms.Button()
        Me.Button7 = New System.Windows.Forms.Button()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(11, 16)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(63, 31)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "启动监控"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button2
        '
        Me.Button2.Location = New System.Drawing.Point(82, 16)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(67, 31)
        Me.Button2.TabIndex = 2
        Me.Button2.Text = "终止监控"
        Me.Button2.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(247, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(29, 12)
        Me.Label2.TabIndex = 4
        Me.Label2.Text = "等待"
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'NotifyIcon1
        '
        Me.NotifyIcon1.ContextMenuStrip = Me.ContextMenuStrip1
        Me.NotifyIcon1.Icon = CType(resources.GetObject("NotifyIcon1.Icon"), System.Drawing.Icon)
        Me.NotifyIcon1.Text = "欢迎使用进程黑名单"
        Me.NotifyIcon1.Visible = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.显示主界面ToolStripMenuItem, Me.退出程序ToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(137, 48)
        '
        '显示主界面ToolStripMenuItem
        '
        Me.显示主界面ToolStripMenuItem.Name = "显示主界面ToolStripMenuItem"
        Me.显示主界面ToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.显示主界面ToolStripMenuItem.Text = "显示主界面"
        '
        '退出程序ToolStripMenuItem
        '
        Me.退出程序ToolStripMenuItem.Name = "退出程序ToolStripMenuItem"
        Me.退出程序ToolStripMenuItem.Size = New System.Drawing.Size(136, 22)
        Me.退出程序ToolStripMenuItem.Text = "退出程序"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Button6)
        Me.GroupBox1.Controls.Add(Me.DelForbid)
        Me.GroupBox1.Controls.Add(Me.AddForbid)
        Me.GroupBox1.Controls.Add(Me.Label6)
        Me.GroupBox1.Controls.Add(Me.ClassMode)
        Me.GroupBox1.Controls.Add(Me.Forbidlist)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Running)
        Me.GroupBox1.Location = New System.Drawing.Point(141, 53)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(446, 258)
        Me.GroupBox1.TabIndex = 6
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "选择"
        '
        'Button6
        '
        Me.Button6.Location = New System.Drawing.Point(140, 101)
        Me.Button6.Name = "Button6"
        Me.Button6.Size = New System.Drawing.Size(33, 23)
        Me.Button6.TabIndex = 8
        Me.Button6.Text = "白"
        Me.Button6.UseVisualStyleBackColor = True
        '
        'DelForbid
        '
        Me.DelForbid.Location = New System.Drawing.Point(142, 73)
        Me.DelForbid.Name = "DelForbid"
        Me.DelForbid.Size = New System.Drawing.Size(28, 22)
        Me.DelForbid.TabIndex = 7
        Me.DelForbid.Text = "<<"
        Me.DelForbid.UseVisualStyleBackColor = True
        '
        'AddForbid
        '
        Me.AddForbid.Location = New System.Drawing.Point(142, 45)
        Me.AddForbid.Name = "AddForbid"
        Me.AddForbid.Size = New System.Drawing.Size(28, 22)
        Me.AddForbid.TabIndex = 6
        Me.AddForbid.Text = ">>"
        Me.AddForbid.UseVisualStyleBackColor = True
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(325, 18)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 12)
        Me.Label6.TabIndex = 5
        Me.Label6.Text = "模式选择"
        '
        'ClassMode
        '
        Me.ClassMode.FormattingEnabled = True
        Me.ClassMode.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.ClassMode.ItemHeight = 12
        Me.ClassMode.Location = New System.Drawing.Point(327, 40)
        Me.ClassMode.Name = "ClassMode"
        Me.ClassMode.Size = New System.Drawing.Size(107, 208)
        Me.ClassMode.TabIndex = 4
        '
        'Forbidlist
        '
        Me.Forbidlist.FormattingEnabled = True
        Me.Forbidlist.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Forbidlist.ItemHeight = 12
        Me.Forbidlist.Location = New System.Drawing.Point(181, 40)
        Me.Forbidlist.Name = "Forbidlist"
        Me.Forbidlist.Size = New System.Drawing.Size(118, 208)
        Me.Forbidlist.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(179, 18)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(53, 12)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "禁止名单"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(8, 17)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(53, 12)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "正在运行"
        '
        'Running
        '
        Me.Running.FormattingEnabled = True
        Me.Running.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.Running.ItemHeight = 12
        Me.Running.Location = New System.Drawing.Point(6, 40)
        Me.Running.Name = "Running"
        Me.Running.Size = New System.Drawing.Size(128, 208)
        Me.Running.TabIndex = 0
        '
        'Button4
        '
        Me.Button4.Location = New System.Drawing.Point(322, 18)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(77, 29)
        Me.Button4.TabIndex = 8
        Me.Button4.Text = "编辑模式"
        Me.Button4.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Button5)
        Me.GroupBox2.Controls.Add(Me.Button3)
        Me.GroupBox2.Controls.Add(Me.WhitePro)
        Me.GroupBox2.Location = New System.Drawing.Point(11, 53)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(130, 258)
        Me.GroupBox2.TabIndex = 9
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "白名单"
        '
        'Button5
        '
        Me.Button5.Location = New System.Drawing.Point(71, 19)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(53, 27)
        Me.Button5.TabIndex = 2
        Me.Button5.Text = "删除"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.Location = New System.Drawing.Point(6, 19)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(50, 27)
        Me.Button3.TabIndex = 1
        Me.Button3.Text = "添加"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'WhitePro
        '
        Me.WhitePro.FormattingEnabled = True
        Me.WhitePro.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.WhitePro.ItemHeight = 12
        Me.WhitePro.Location = New System.Drawing.Point(6, 52)
        Me.WhitePro.Name = "WhitePro"
        Me.WhitePro.Size = New System.Drawing.Size(118, 196)
        Me.WhitePro.TabIndex = 0
        '
        'ExitProgram
        '
        Me.ExitProgram.Location = New System.Drawing.Point(405, 18)
        Me.ExitProgram.Name = "ExitProgram"
        Me.ExitProgram.Size = New System.Drawing.Size(77, 29)
        Me.ExitProgram.TabIndex = 10
        Me.ExitProgram.Text = "退出程序"
        Me.ExitProgram.UseVisualStyleBackColor = True
        '
        'SetAuto
        '
        Me.SetAuto.Location = New System.Drawing.Point(492, 18)
        Me.SetAuto.Name = "SetAuto"
        Me.SetAuto.Size = New System.Drawing.Size(94, 27)
        Me.SetAuto.TabIndex = 11
        Me.SetAuto.Text = "开机自启动"
        Me.SetAuto.UseVisualStyleBackColor = True
        '
        'Button7
        '
        Me.Button7.Location = New System.Drawing.Point(157, 16)
        Me.Button7.Name = "Button7"
        Me.Button7.Size = New System.Drawing.Size(78, 30)
        Me.Button7.TabIndex = 12
        Me.Button7.Text = "白名单模式"
        Me.Button7.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(599, 313)
        Me.Controls.Add(Me.Button7)
        Me.Controls.Add(Me.SetAuto)
        Me.Controls.Add(Me.ExitProgram)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Button4)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Button2)
        Me.Controls.Add(Me.Button1)
        Me.DoubleBuffered = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "进程黑名单 By SunSoft 孙瑞 @科学探索者"
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Button1 As System.Windows.Forms.Button
    Friend WithEvents Button2 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents NotifyIcon1 As System.Windows.Forms.NotifyIcon
    Friend WithEvents ContextMenuStrip1 As System.Windows.Forms.ContextMenuStrip
    Friend WithEvents 显示主界面ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents 退出程序ToolStripMenuItem As System.Windows.Forms.ToolStripMenuItem
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents ClassMode As System.Windows.Forms.ListBox
    Friend WithEvents Forbidlist As System.Windows.Forms.ListBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Running As System.Windows.Forms.ListBox
    Friend WithEvents Button4 As System.Windows.Forms.Button
    Friend WithEvents DelForbid As System.Windows.Forms.Button
    Friend WithEvents AddForbid As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents WhitePro As System.Windows.Forms.ListBox
    Friend WithEvents Button5 As System.Windows.Forms.Button
    Friend WithEvents Button3 As System.Windows.Forms.Button
    Friend WithEvents ExitProgram As System.Windows.Forms.Button
    Friend WithEvents SetAuto As System.Windows.Forms.Button
    Friend WithEvents Button6 As System.Windows.Forms.Button
    Friend WithEvents Button7 As System.Windows.Forms.Button

End Class
