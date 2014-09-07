Imports Microsoft.Win32
Imports System.Reflection.Assembly
Imports SunSoftUtility
Public Class Form1
    Dim k As Threading.Thread
    Dim listBoxT As Threading.Thread
    Dim forbitThread As String
    Dim windowstateMe As String = "open"
    '【*********************以下为过程************************】
    Sub AutoRun() 'ok at 13-08-12 【完成】
        SaveSetting("sunsoft", "systemtask", "initmode", currentClass)
        k = New Threading.Thread(AddressOf killTast)
        k.Start()
    End Sub
    Sub killTast() 'ok at 13-08-12 【完成：独立线程，监视正在执行的进程】
        '策略：
        '1、读取当前列表，存入list类对象，然后，清除list类中的白名单中的项
        '2、获取当前模式下的禁止列表，遍历现存线程，判断每个线程是否属于黑名单

        Dim sProcesses() As System.Diagnostics.Process
        Dim sProcess As System.Diagnostics.Process
        Dim WhiteList As New List(Of String)
        Dim BlackList As New List(Of String)
        'checks=Split(forbitThread, 

        While (True)
            '获取黑名单，白名单,放在线程的无限循环里面，保证黑名单可以实时修改
            BlackList.Clear()
            WhiteList.Clear()
            For Each thStr As String In Forbidlist.Items
                BlackList.Add(thStr)
            Next
            For Each ij As String In WhitePro.Items '将白名单导入
                WhiteList.Add(ij)
            Next
            Try
                sProcesses = System.Diagnostics.Process.GetProcesses()
                For Each sProcess In sProcesses
                    '如果这个进程项的名字在白名单中，则忽略，如果不在，则看是否在黑名单中
                    'Debug.Print(sProcess.MainModule.FileName)  输出进程的文件路径
                    If WhiteList.Contains(LCase(sProcess.ProcessName)) = False Then '如果不在白名单，则看看是否在黑名单
                        If BlackList.Contains(LCase(sProcess.ProcessName)) = True Then
                            If sProcess.Id <> System.Diagnostics.Process.GetCurrentProcess.Id Then  '不会杀掉自己
                                If GetSetting("sunsoft", "systemtask", "popifend") = "true" Or GetSetting("sunsoft", "systemtask", "popifend") = "" Then
                                    NotifyIcon1.BalloonTipText = "结束 " & sProcess.ProcessName & " 进程"
                                    NotifyIcon1.BalloonTipTitle = "提示"
                                    NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
                                    NotifyIcon1.ShowBalloonTip(5)
                                End If
                                sProcess.Kill()
                            End If
                        End If
                    End If
                Next
                Threading.Thread.Sleep(100)
            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try
        End While
    End Sub

    Public Function IsInstanceRunning() As Boolean '返回本实例是否正在运行的信息
        Dim checkInstance As New SunSoftUtility.MultiThread
        If checkInstance.preInstanceCheck() = True Then
            Return True
            Exit Function
        End If
        Return False
        Exit Function
        '        Dim current As Process = System.Diagnostics.Process.GetCurrentProcess()
        '        Dim processes As Process() = System.Diagnostics.Process.GetProcessesByName(current.ProcessName)
        '        'Loop through the running processes in with the same name 
        '        Dim p As Process
        '        For Each p In processes
        '            'Ignore the current process 
        '            If p.Id <> current.Id Then
        '                'Make sure that the process is running from the exe file. 
        '                If System.Reflection.Assembly.GetExecutingAssembly().Location.Replace("/", "\") = current.MainModule.FileName Then
        '                    'Return the other process instance. 
        '                    Return True
        '                End If
        '            End If
        '        Next
        '        'No other instance was found, return null. 
        '        Return False
    End Function 'RunningInstance

    Sub UpdateCurrentTask() 'ok at 13-08-12 负责在独立线程实时更新正在运行的线程的变化【完成】
        '负责更新显示的进程
        Dim kProcess() As System.Diagnostics.Process
        Dim kProc As System.Diagnostics.Process
        Dim TaskList As New List(Of String)
        Dim BoxList As New List(Of String)
        While (True)
            kProcess = System.Diagnostics.Process.GetProcesses()
            TaskList.Clear()
            BoxList.Clear()
            For Each kProc In kProcess
                '将进程名保存如列表
                TaskList.Add(kProc.ProcessName)
            Next
            For j As Integer = 0 To Running.Items.Count - 1
                '将列表中的项目保存
                BoxList.Add(Running.Items.Item(j))
            Next
            '开始比对列表中现存的，如果列表中的项不存在于进程中，则会被剔除
            For ji As Integer = BoxList.Count - 1 To 0 Step -1
                Dim i As String = BoxList.Item(ji)
                If TaskList.Contains(i) = True Then
                Else
                    Invoke(New vRemoveRunning(AddressOf RemoveRunning), i)
                    BoxList.Remove(i)
                End If
            Next
            '开始比较进程与列表，列表中不存在的进程中的项，将被加入
            For ji As Integer = TaskList.Count - 1 To 0 Step -1
                Dim i As String = TaskList.Item(ji)
                If BoxList.Contains(i) = True Then
                Else
                    BoxList.Add(i)
                    Invoke(New vAddRunning(AddressOf AddRunning), i)
                End If
            Next
            Threading.Thread.Sleep(500)
        End While
    End Sub
    Sub RefreshClass(ByVal ctStr As String) '刷新ClassMode中的显示
        Dim rtss As ADODB.Recordset
        currentClass = ctStr
        '重新加载ForbidList这个listbox
        ClassMode.Items.Clear()
        rtss = New ADODB.Recordset
        rtss.Open("select * from TaskClass", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
        If rtss.RecordCount = 0 Then
            rtss.Close()
            rtss = Nothing
            Exit Sub
        End If
        Do While Not rtss.EOF
            ClassMode.Items.Add(rtss.Fields("ClassName").Value)
            rtss.MoveNext()
        Loop
        rtss.Close()
        rtss = Nothing
        ClassMode.SelectedIndex = ClassMode.Items.IndexOf(currentClass)
    End Sub

    '【***************委托函数过程及声明***************】
    Sub AddRunning(ByVal s As String) '【完成】
        Running.Items.Add(s)
    End Sub
    Delegate Sub vAddRunning(ByVal s As String) '【完成】

    Sub RemoveRunning(ByVal s As String) '【完成】
        Running.Items.Remove(s)
    End Sub
    Delegate Sub vRemoveRunning(ByVal s As String) '【完成】

    '【**********以下为事件处理函数**********】
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        SaveSetting("sunsoft", "systemtask", "initmode", currentClass)
        Try
            k.Abort()
        Catch ex As Exception

        End Try
        k = New Threading.Thread(AddressOf killTast)
        k.Start()
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Try
            k.Abort()
        Catch ex As Exception
            Debug.Print("error:can't stop task")
        End Try
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        SaveSetting("sunsoft", "systemtask", "initmode", currentClass)
        e.Cancel = True
        windowstateMe = "hide"
        Me.Hide()
    End Sub

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim rts As ADODB.Recordset
        '设置ToolTip
        Dim k As ToolTip
        Dim runs As ToolTip

        k = New ToolTip()
        k.AutoPopDelay = 3000
        k.InitialDelay = 50
        k.ToolTipTitle = "提示"
        k.SetToolTip(WhitePro, "按D键删除选定项")

        runs = New ToolTip()
        runs.AutoPopDelay = 3000
        runs.InitialDelay = 50
        runs.ToolTipTitle = "提示"
        runs.SetToolTip(Running, "按W键加入白名单" & vbCrLf & "按B键加入当前模式的黑名单")

        '
        currentClass = GetSetting("sunsoft", "systemtask", "initmode")
        If IsInstanceRunning() = True Then
            If Command() = "autorun" Then
            Else
                MsgBox("进程已启动，请勿多开程序！")
            End If
            NotifyIcon1.Dispose()
            End
        Else
            SaveSetting("sunsoft", "systemtask", "multi", "running")
        End If
        ReleaseDB() '释放数据库
        Call OpenTable(Application.StartupPath & "\threadforbid.mdb")
        '加载白名单【虽然是“ForbidList”但是实质上存储的是白名单，因为懒得改数据库】
        res = New ADODB.Recordset
        res.Open("select * from ForbidList", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
        If res.RecordCount = 0 Then
        Else
            Do While Not res.EOF
                WhitePro.Items.Add(res.Fields("forbid").Value)
                res.MoveNext()
            Loop
        End If
        res.Close()

        '开始加载模式
        rts = New ADODB.Recordset
        rts.Open("select * from TaskClass", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
        If rts.RecordCount = 0 Then
        Else
            Do While Not rts.EOF
                ClassMode.Items.Add(rts.Fields("ClassName").Value)
                rts.MoveNext()
            Loop
        End If
        ClassMode.SelectedIndex = ClassMode.Items.IndexOf(currentClass)
        rts.Close()
        listBoxT = New Threading.Thread(AddressOf UpdateCurrentTask)
        listBoxT.Start()
    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Static kInit As Integer = 0
        Try
            If k.IsAlive = True Then
                Label2.Text = "监控中"
            Else
                Label2.Text = "等待"
            End If
        Catch ex As Exception
            Debug.Print("尚未启动线程")
        End Try
        If Command() = "autorun" And kInit = 0 Then
            AutoRun()
            windowstateMe = "hide"
            Me.Hide()
            kInit = 1
        End If
    End Sub

    Private Sub 显示主界面ToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles 显示主界面ToolStripMenuItem.Click
        Me.Show()
    End Sub

    Private Sub 退出程序ToolStripMenuItem_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles 退出程序ToolStripMenuItem.Click, ExitProgram.Click
        listBoxT.Abort()
        NotifyIcon1.Dispose()
        Call CloseTable()
        SaveSetting("sunsoft", "systemtask", "multi", "")
        Do While GetSetting("sunsoft", "systemtask", "multi") <> ""
            SaveSetting("sunsoft", "systemtask", "multi", "")
        Loop
        Me.Dispose()
        End
    End Sub

    Private Sub NotifyIcon1_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles NotifyIcon1.MouseUp
        If e.Button = Windows.Forms.MouseButtons.Left Then
            If windowstateMe = "open" Then
                Me.Hide()
                windowstateMe = "hide"
            ElseIf windowstateMe = "hide" Then
                Me.Show()
                windowstateMe = "open"
            End If
        End If
    End Sub


    Private Sub AddForbid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AddForbid.Click
        'ok at 13-08-13 修改，将调用函数全部设置为小写输入作为参数
        '添加到禁止名单，同时写入数据库的更改
        '判断currentClass是否存在
        If currentClass = "" Then
            MsgBox("请启动一个监控模式或者新建一个模式")
            Exit Sub
        End If
        If Running.SelectedIndex >= 0 Then
            '移动到currentClass
            Dim strTask As String = ""
            strTask = Running.Items.Item(Running.SelectedIndex)
            Forbidlist.Items.Add(LCase(strTask))
            XMAdd(LCase(strTask))
        End If
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click 'ok at 13-08-12 【完成】
        Form2.Show()
    End Sub

    Private Sub DelForbid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DelForbid.Click
        'ok at 13-08-13 修改，将调用函数全部设置为小写输入作为参数
        If Forbidlist.Items.Count = 0 Then Exit Sub
        If currentClass = "" Then
            MsgBox("请启动一个监控模式")
            Exit Sub
        End If
        If Forbidlist.SelectedIndex >= 0 Then
            '移动到currentClass
            Dim strTask As String = ""
            strTask = Forbidlist.Items.Item(Forbidlist.SelectedIndex)
            XMDel(LCase(strTask))
            Forbidlist.Items.Remove(strTask)
        End If
    End Sub

    Private Sub ClassMode_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ClassMode.MouseUp
        If ClassMode.SelectedIndex = -1 Then Exit Sub
        currentClass = ClassMode.Items.Item(ClassMode.SelectedIndex)
        '重新加载ForbidList这个listbox
        Forbidlist.Items.Clear()
        res = New ADODB.Recordset
        res.Open("select * from KeyValue where KeyString='" & currentClass & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
        If res.RecordCount = 0 Then
            res.Close()
            res = Nothing
            Exit Sub
        End If
        Do While Not res.EOF
            Forbidlist.Items.Add(res.Fields("ValueString").Value)
            res.MoveNext()
        Loop
        res.Close()
        res = Nothing
    End Sub
    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        '已经小写处理
        Dim inputStr As String = InputBox("请输入白名单程序名", "白名单")
        If inputStr = "" Then Exit Sub '如果输入为空，则无反应
        Call AddWhite(LCase(inputStr)) '加入到数据库，并且加入到列表中
    End Sub

    Private Sub Button5_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button5.Click
        '已进行小写处理【完成】
        Call WhitePro_Delete()
    End Sub

    Private Sub ClassMode_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ClassMode.SelectedIndexChanged
        '使用ClassMode.SelectedIndex=某某某赋值的方式修改index，也会引发此事件
        'ok at 13-08-13 【完成】
        If ClassMode.SelectedIndex = -1 Then Exit Sub
        currentClass = ClassMode.Items.Item(ClassMode.SelectedIndex)
        '重新加载ForbidList这个listbox
        Forbidlist.Items.Clear()
        res = New ADODB.Recordset
        res.Open("select * from KeyValue where KeyString='" & currentClass & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
        If res.RecordCount = 0 Then
            res.Close()
            res = Nothing
            Exit Sub
        End If
        Do While Not res.EOF
            Forbidlist.Items.Add(res.Fields("ValueString").Value)
            res.MoveNext()
        Loop
        res.Close()
        res = Nothing
        SaveSetting("sunsoft", "systemtask", "initmode", currentClass)
    End Sub

    Private Sub SetAuto_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SetAuto.Click
        'ok at 13-08-13 设置开机自动启动
        Dim kReg As RegistryKey
        MsgBox("如果弹出添加启动项的警告，请允许本次添加操作", MsgBoxStyle.Information, "添加开机启动")
        kReg = Registry.LocalMachine
        kReg = kReg.OpenSubKey("SOFTWARE\Microsoft\Windows\CurrentVersion\Run", True)
        'kReg.CreateSubKey("ThreadManager", RegistryKeyPermissionCheck.ReadWriteSubTree)  '这个是给Run再添加一个ThreadManager子项
        kReg.SetValue("ThreadManager", """" & GetExecutingAssembly.Location & """ autorun") '需要引用System.Reflection.Assembly，这个是给Run这个项，添加一个键值对
        kReg.Close()
        kReg = Nothing
    End Sub

    Private Sub Button6_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button6.Click
        'ok at 13-08-13【完成】
        '添加白名单
        If Running.Items.Count = 0 Then Exit Sub
        If Running.SelectedIndex = -1 Then Exit Sub
        Call AddWhite(LCase(Running.Items.Item(Running.SelectedIndex))) '加入到数据库，并且加入到列表中
    End Sub

    Private Sub Running_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Running.KeyPress
        e.Handled = True
    End Sub

    Private Sub Running_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Running.KeyUp
        Dim lastIndex As Integer = Running.SelectedIndex
        If e.KeyCode = Windows.Forms.Keys.W Then
            If Running.Items.Count = 0 Then Exit Sub
            If lastIndex = -1 Then Exit Sub
            Call AddWhite(LCase(Running.Items.Item(lastIndex))) '加入到数据库，并且加入到列表中
        ElseIf e.KeyCode = Windows.Forms.Keys.B Then
            If currentClass = "" Then
                MsgBox("请启动一个监控模式或者新建一个模式")
                Exit Sub
            End If
            If lastIndex >= 0 Then
                '移动到currentClass
                Dim strTask As String = ""
                strTask = Running.Items.Item(lastIndex)
                If Forbidlist.Items.Contains(LCase(strTask)) = False Then
                    Forbidlist.Items.Add(LCase(strTask))
                    XMAdd(LCase(strTask))
                End If
            End If
            End If
            If Running.Items.Count = 0 Then
            ElseIf Running.Items.Count > 0 Then
                If Running.Items.Count >= lastIndex + 1 Then
                    Running.SelectedIndex = lastIndex '保持不变
                Else
                    Running.SelectedIndex = Running.Items.Count - 1
                End If
            End If
    End Sub

    Private Sub WhitePro_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles WhitePro.KeyPress
        e.Handled = True
    End Sub

    Private Sub WhitePro_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles WhitePro.KeyUp
        If e.KeyCode = Windows.Forms.Keys.D Then
            Call WhitePro_Delete()
        End If
    End Sub
    Sub WhitePro_Delete()  '删除选定项
        Dim lastIndex As Integer = WhitePro.SelectedIndex
        If WhitePro.Items.Count = 0 Then Exit Sub '没有项目存在于列表框
        If lastIndex >= 0 Then
            DelWhite(LCase(WhitePro.SelectedItem))
            WhitePro.Items.RemoveAt(lastIndex)
        End If
        '移动默认位置
        If WhitePro.Items.Count = 0 Then
        ElseIf WhitePro.Items.Count > 0 Then
            If WhitePro.Items.Count >= lastIndex + 1 Then
                WhitePro.SelectedIndex = lastIndex '保持不变
            Else
                WhitePro.SelectedIndex = WhitePro.Items.Count - 1
            End If
        End If
    End Sub
    Private Sub WhitePro_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles WhitePro.SelectedIndexChanged

    End Sub

    Private Sub Running_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Running.SelectedIndexChanged

    End Sub

    Private Sub Button7_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button7.Click
        Try
            k.Abort()
        Catch ex As Exception

        End Try
        k = New Threading.Thread(AddressOf WhiteMode)
        k.Start()
    End Sub

    Sub WhiteMode()
        'entering white mode:
        'allow white to run only
        '策略：
        '1、读取当前列表，存入list类对象，然后，清除list类中的白名单中的项
        '2、获取当前模式下的禁止列表，遍历现存线程，判断每个线程是否属于黑名单

        Dim sProcesses() As System.Diagnostics.Process
        Dim sProcess As System.Diagnostics.Process
        Dim WhiteList As New List(Of String)
        'checks=Split(forbitThread, 
        While (True)
            '获取黑名单，白名单,放在线程的无限循环里面，保证黑名单可以实时修改
            WhiteList.Clear()
            For Each ij As String In WhitePro.Items '将白名单导入
                WhiteList.Add(ij)
            Next
            Try
                sProcesses = System.Diagnostics.Process.GetProcesses()
                For Each sProcess In sProcesses
                    '如果这个进程项的名字在白名单中，则忽略，如果不在，则看是否在黑名单中
                    'Debug.Print(sProcess.MainModule.FileName)  输出进程的文件路径
                    If WhiteList.Contains(LCase(sProcess.ProcessName)) = False Then '如果不在白名单，则结束
                        If sProcess.Id <> System.Diagnostics.Process.GetCurrentProcess.Id Then  '不会杀掉自己
                            If GetSetting("sunsoft", "systemtask", "popifend") = "true" Or GetSetting("sunsoft", "systemtask", "popifend") = "" Then
                                NotifyIcon1.BalloonTipText = "结束 " & sProcess.ProcessName & " 进程"
                                NotifyIcon1.BalloonTipTitle = "提示"
                                NotifyIcon1.BalloonTipIcon = ToolTipIcon.Info
                                NotifyIcon1.ShowBalloonTip(5)
                            End If
                            sProcess.Kill()
                        End If
                    End If
                Next
                Threading.Thread.Sleep(100)
            Catch ex As Exception
                Debug.Print(ex.Message)
            End Try
        End While
    End Sub

End Class
