Public Class MDBConnector
    Private conn As ADODB.Connection
    Private res As ADODB.Recordset
    Private isConnect As Boolean = False
    Private MdbFile As String = ""
    Sub New()
        isConnect = False
    End Sub
    Sub New(ByVal MdbPath As String)
        MdbFile = MdbPath '赋值给内部变量
        Call OpenTable(MdbFile) '打开数据连接
    End Sub
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
    Function ExcuteSQL(ByVal sqlStr As String) As ADODB.Recordset
        If isConnect = False Then
            ExcuteSQL = Nothing
        End If
        res = New ADODB.Recordset
        res.Open(sqlStr, conn, ADODB.CursorTypeEnum.adOpenStatic, ADODB.LockTypeEnum.adLockOptimistic)
        ExcuteSQL = res.Clone
        res.Close()
        res = Nothing
    End Function
End Class
