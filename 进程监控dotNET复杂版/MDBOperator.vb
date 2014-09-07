Imports ADODB

Module MDBOperator
    Public currentClass As String = ""
    Public conn As ADODB.Connection
    Public res As ADODB.Recordset
    Private isConnect As Boolean = False
    Sub OpenTable(ByVal MdbPath As String) '【功能：建立数据库连接；状态：完成】
        Try
            conn = New ADODB.Connection
            conn.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            conn.Open("PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" & MdbPath & ";")
            isConnect = True
        Catch
            Kill(MdbPath)
            Debug.Print("Error")
        End Try
    End Sub
    Sub OpenTable(ByVal MdbPath As String, ByVal passWord As String) '【功能：建立数据库连接；状态：完成】
        Try
            conn = New ADODB.Connection
            conn.CursorLocation = ADODB.CursorLocationEnum.adUseClient
            conn.Open("PROVIDER=Microsoft.Jet.OLEDB.4.0;Data Source=" & MdbPath & ";")
            isConnect = True
        Catch
            Kill(MdbPath)
            Debug.Print("Error")
        End Try
    End Sub
    Sub CloseTable() '【功能：关闭数据库连接；状态：完成】
        Try
            conn.Close()
            isConnect = False
        Catch ex As Exception
            Debug.Print("Error:Connection Stopped Already")
        End Try
    End Sub
    Function isForbid(ByVal processName As String) As Boolean
        Dim r As Recordset
        r = New Recordset
        r.Open("select * from ForbidList where forbid like '" & processName & "'", conn, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockOptimistic)
        If r.RecordCount = 0 Then
            r.Close()
            r = Nothing
            isForbid = False
            Exit Function
        End If
        r.Close()
        r = Nothing
        isForbid = True
    End Function
    Sub XMAdd(ByVal s As String)  '加【模式】中的项目到数据库
        If XMExist(s) = False Then
            Dim lr As ADODB.Recordset
            lr = New ADODB.Recordset
            lr.Open("KeyValue", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
            With lr
                .AddNew()
                .Fields("KeyString").Value = currentClass
                .Fields("ValueString").Value = s
                .Update()
            End With
            lr.Close()
            lr = Nothing
        End If
    End Sub
    Function XMExist(ByVal strXM As String) As Boolean  '测试【模式】中的【项目】是否已经存在于数据库
        Dim k As ADODB.Recordset
        k = New ADODB.Recordset
        k.Open("select * from KeyValue where ValueString='" & strXM & "' and KeyString='" & currentClass & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
        If k.RecordCount = 0 Then
            k.Close()
            k = Nothing
            XMExist = False
            Exit Function
        End If
        k.Close()
        k = Nothing
        XMExist = True
    End Function
    Sub XMDel(ByVal s As String)
        Dim Mrs As ADODB.Recordset
        Mrs = New ADODB.Recordset
        Mrs.Open("delete from KeyValue where KeyString='" & currentClass & "' and ValueString='" & s & "'", conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
        Mrs = Nothing
    End Sub
    Sub AddWhite(ByVal whiteStr As String) '加白名单到列表和数据库
        '默认输入的内容为小写字母
        If Form1.WhitePro.Items.Contains(whiteStr) = False Then '如果列表中没有，则添加
            Form1.WhitePro.Items.Add(whiteStr)
        End If
        '数据库中如果有，则跳出；如果没有，则添加
        res = New ADODB.Recordset
        res.Open("select * from ForbidList where forbid='" & whiteStr & "'", conn, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockOptimistic)
        If res.RecordCount > 0 Then
            res.Close()
            res = Nothing
            Exit Sub
        End If
        res.Close()

        res = New Recordset
        res.Open("ForbidList", conn, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockOptimistic)
        With res
            .AddNew()
            .Fields("forbid").Value = whiteStr
            .Update()
        End With
        res.Close()
        res = Nothing
    End Sub
    Sub DelWhite(ByVal strWhite As String) 'ok at 13-08-13 删除选定的白名单
        res = New Recordset
        res.Open("delete from ForbidList where forbid='" & LCase(strWhite) & "'", conn, CursorTypeEnum.adOpenStatic, LockTypeEnum.adLockOptimistic)
        res = Nothing
    End Sub
    Sub ReleaseDB()
        If IO.File.Exists(Application.StartupPath & "\threadforbid.mdb") = False Then
            Dim k() As Byte = My.Resources.threadforbid
            Dim ko As New IO.FileStream(Application.StartupPath & "\threadforbid.mdb", IO.FileMode.Create)
            ko.Write(k, 0, k.Length)
            ko.Close()
        End If
    End Sub
End Module
