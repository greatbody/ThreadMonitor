Public Class Form2
    Sub FillXMByMS(ByVal s As String) '通过模式的内容，填充项目列表
        Dim krs As ADODB.Recordset
        krs = New ADODB.Recordset
        XiangMu.Items.Clear()
        krs.Open("select * from KeyValue where KeyString='" & s & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
        If krs.RecordCount > 0 Then
            Do While Not krs.EOF = True
                XiangMu.Items.Add(krs.Fields("ValueString").Value)
                krs.MoveNext()
            Loop
        End If
        krs.Close()
        krs = Nothing
        NewXM.Text = ""
        NewXM.Focus()
    End Sub

    Private Sub Form2_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
        If GetSetting("sunsoft", "systemtask", "popifend") = "true" Or GetSetting("sunsoft", "systemtask", "popifend") = "" Then
            CheckBox1.CheckState = CheckState.Checked
        Else
            CheckBox1.CheckState = CheckState.Unchecked
        End If
    End Sub

    Private Sub Form2_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Form1.RefreshClass(currentClass)
    End Sub
    Private Sub Form2_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        '加载模式的内容
        Dim rs As ADODB.Recordset
        rs = New ADODB.Recordset
        rs.Open("select * from TaskClass", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
        If rs.RecordCount > 0 Then
            Do While Not rs.EOF = True
                MoShi.Items.Add(rs.Fields("ClassName").Value)
                rs.MoveNext()
            Loop
        End If
        rs.Close()
        rs = Nothing
    End Sub

    Private Sub MoShi_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles MoShi.Click
        If MoShi.Items.Count > 0 Then
            If MoShi.SelectedIndex >= 0 Then
                Call FillXMByMS(MoShi.Items.Item(MoShi.SelectedIndex))
                currentClass = MoShi.Items.Item(MoShi.SelectedIndex)
            End If
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        '模式，无需小写处理【完成】
        Dim kTemp As String = InputBox("请输入模式名", "输入")
        If kTemp <> "" Then
            MoShi.Items.Add(kTemp)  'listbox加入【模式】
            Call AddMoShi(kTemp) '数据库中加入此【模式】
            MoShi.SelectedIndex = MoShi.Items.IndexOf(kTemp) '在listbox中选定此【模式】
            currentClass = kTemp '当前模式设置为新添加的模式
            Call FillXMByMS(currentClass) '初始化模式项目编辑器
        End If
        If Form1.ClassMode.Items.Count = 0 Then
            Form1.RefreshClass(currentClass)
            Form1.ClassMode.SelectedIndex = 0
        End If
    End Sub
    Sub DelMoShi(ByVal MoShi As String)
        '删除模式，无需小写处理【完成】
        Dim Mrs As ADODB.Recordset
        Mrs = New ADODB.Recordset
        Mrs.Open("delete from TaskClass where ClassName='" & MoShi & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
        Mrs = Nothing
    End Sub
    Sub AddMoShi(ByVal s As String)
        '增加模式，不需要小写处理【完成】
        If MoShiExist(s) = False Then
            Dim Mrs As ADODB.Recordset
            Mrs = New ADODB.Recordset
            Mrs.Open("TaskClass", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
            With Mrs
                .AddNew()
                .Fields("ClassName").Value = s
                .Update()
            End With
            Mrs.Close()
            Mrs = Nothing
        End If
    End Sub
    Function MoShiExist(ByVal ModeName As String) As Boolean
        '模式，不需要进行小写处理【完成】
        Dim Mrs As ADODB.Recordset
        Mrs = New ADODB.Recordset
        Mrs.Open("select * from TaskClass where ClassName='" & ModeName & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
        If Mrs.RecordCount = 0 Then
            Mrs.Close()
            Mrs = Nothing
            MoShiExist = False
            Exit Function
        End If
        MoShiExist = True
        Mrs.Close()
        Mrs = Nothing
    End Function

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        '已经小写处理，针对模式中的每一个进程名，会进行小写处理
        If currentClass = "" Then Exit Sub '如果尚未选定类别
        If NewXM.Text = "" Then
            MsgBox("请先填写内容")
            NewXM.Focus()
            Exit Sub
        End If
        Call XMAdd(LCase(NewXM.Text)) '加到数据库
        XiangMu.Items.Add(LCase(NewXM.Text)) '加到listbox
        NewXM.Text = ""
        NewXM.Focus()
    End Sub

    Private Sub CheckBox1_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CheckBox1.CheckedChanged
        If CheckBox1.CheckState = CheckState.Checked Then
            SaveSetting("sunsoft", "systemtask", "popifend", "true")
        ElseIf CheckBox1.CheckState = CheckState.Unchecked Then
            SaveSetting("sunsoft", "systemtask", "popifend", "false")
        End If
    End Sub
End Class