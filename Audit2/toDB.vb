Imports MySql.Data.MySqlClient
Imports System.Data.OleDb
Module toDB
    Public conn As OleDbConnection
    Public CMD As OleDbCommand
    Public DS As New DataSet
    Public DA As OleDbDataAdapter
    Public RD, rh As OleDbDataReader
    Public dt As DataTable
    Public lokasiData As String
    Private bindingSource1 As New BindingSource()
    Public Sub koneksi()
        lokasiData = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=audit.mdb"
        Try
            conn = New OleDbConnection(lokasiData)
            conn.Open()
        Catch ex As Exception
            MessageBox.Show("Gagal")
        End Try
    End Sub
    Public Sub itemCombo()
        If conn.State = ConnectionState.Open Then
            conn.Close()
            conn.Open()
        Else
            conn.Open()
        End If
        Dim query As String
        'Dim a As Integer
        query = "select namaCabang from ListCabang ORDER BY namaCabang asc"
        CMD = New OleDbCommand(query, conn)
        RD = CMD.ExecuteReader
        While RD.Read

            Input.cmbNamacabang.Items.Add(RD.Item(0))
            Laporan_Audit.cmbNC.Items.Add(RD.Item(0))
            Upload.cmbCabang.Items.Add(RD.Item(0))
        End While
        conn.Close()
    End Sub
    Public Sub itemNomorAudit(ByVal nc As String)
        If conn.State = ConnectionState.Open Then
            conn.Close()
            conn.Open()
        Else
            conn.Open()
        End If
        Dim query As String
        'Dim a As Integer
        query = "select idInfo from infoopname where lokasi='" & nc & "' ORDER BY idInfo asc"
        CMD = New OleDbCommand(query, conn)
        RD = CMD.ExecuteReader
        If RD.HasRows Then
            While RD.Read
                Laporan_Audit.cmbNoAudit.Items.Add(RD.Item(0))
            End While
        Else
            MsgBox("Data Audit Tidak Ditemukan", MsgBoxStyle.Information, "Informasi")
        End If

        conn.Close()
    End Sub
    Public Sub Bukudgv()
        If conn.State = ConnectionState.Open Then
            conn.Close()
            conn.Open()
        Else
            conn.Open()
        End If
        DA = New OleDbDataAdapter("select b.isbn,b.kodeBuku,b.judul,b.jilid,b.jenjang,b.noRak, op.idInfo as Stock_Sistem,op.sFisik AS Stock_Nyata,op.kodeBuku as Sample,op.SampleNyata,op.isbn as Rusak,op.RusakNyata,op.keterangan from buku b LEFT JOIN opname op on b.isbn=op.isbn Where b.isbn='' ", conn)
        DS.Reset()
        DS.Clear()
        DS.Tables.Clear()
        DA.Fill(DS)
        Input.DataGridView1.DataSource = DS.Tables(0)
        conn.Close()
    End Sub
    Sub ViewBuku2(ByVal param As String, ByVal baris As Integer, ByVal nc As String)
        If conn.State = ConnectionState.Open Then
            conn.Close()
            conn.Open()
        Else
            conn.Open()
        End If
        CMD = New OleDbCommand("select b.*,Iif(IsNull(ds." & nc & "),0,ds." & nc & "),Iif(IsNull(ss." & nc & "),0,ss." & nc & "),Iif(IsNull(sc." & nc & "),0,sc." & nc & ") from ((buku b LEFT join dummyStock ds on b.kodeBuku=ds.kodeBuku) LEFT join stocksample ss on b.kodeBuku=ss.kodeBuku) LEFT JOIN stockcacad as sc ON b.kodeBuku=sc.kodeBuku  where isbn='" & param & "'", conn)
        RD = CMD.ExecuteReader
        RD.Read()
        If RD.HasRows Then
            Input.DataGridView1.Rows(baris).Cells(1).Value = RD.Item(1)
            Input.DataGridView1.Rows(baris).Cells(2).Value = RD.Item(3)
            Input.DataGridView1.Rows(baris).Cells(3).Value = RD.Item(4)
            Input.DataGridView1.Rows(baris).Cells(4).Value = RD.Item(5)
            Input.DataGridView1.Rows(baris).Cells(5).Value = RD.Item(2)
            Input.DataGridView1.Rows(baris).Cells(6).Value = RD.Item(6).ToString
            Input.DataGridView1.Rows(baris).Cells(8).Value = RD.Item(7).ToString
            Input.DataGridView1.Rows(baris).Cells(10).Value = RD.Item(8).ToString
            Input.DataGridView1.Rows(baris).Cells(1).ReadOnly = True
            Input.DataGridView1.Rows(baris).Cells(2).ReadOnly = True
            Input.DataGridView1.Rows(baris).Cells(3).ReadOnly = True
            Input.DataGridView1.Rows(baris).Cells(4).ReadOnly = True
            Input.DataGridView1.Rows(baris).Cells(5).ReadOnly = True
            Input.DataGridView1.Rows(baris).Cells(6).ReadOnly = True
            Input.DataGridView1.Rows(baris).Cells(8).ReadOnly = True
            Input.DataGridView1.Rows(baris).Cells(10).ReadOnly = True
        Else
            MsgBox("ISBN Tidak Ditemukan !!", MsgBoxStyle.Information)
        End If

    End Sub
    Public Sub simpanOpname(ByVal idInfo As String, ByVal isbn As String, ByVal kb As String, ByVal s As String, ByVal sn As String, ByVal rn As String, ByVal ket As String)
        If conn.State = ConnectionState.Open Then
            conn.Close()
            conn.Open()
        Else
            conn.Open()
        End If
        CMD = New OleDbCommand("select * from opname where isbn='" & isbn & "' and idInfo='" & idInfo & "'", conn)
        RD = CMD.ExecuteReader
        RD.Read()
        If Not RD.HasRows Then
            Try
                conn.Close()
                conn.Open()
                Dim query As String
                query = "insert into opname (idInfo,isbn,kodeBuku,sFisik,SampleNyata,RusakNyata,keterangan) values('" & idInfo & "','" & isbn & "','" & kb & "','" & s & "','" & sn & "','" & rn & "','" & ket & "')"
                CMD = New OleDbCommand(query, conn)
                CMD.ExecuteNonQuery()
                CMD.Dispose()
                Input.BtnSimpan.Text = "Update"
                Input.btnExport.Enabled = True
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        Else
            conn.Close()
            conn.Open()
            Dim query As String
            query = "update opname set sFisik='" & s & "',SampleNyata='" & sn & "','" & rn & "', keterangan='" & ket & "' where isbn='" & isbn & "' and idInfo='" & idInfo & "'"
            CMD = New OleDbCommand(query, conn)
            CMD.ExecuteNonQuery()
            CMD.Dispose()
        End If
        conn.Close()
    End Sub
    Public Sub simpanInfo(ByVal idinfo As String, ByVal lok As String, ByVal tgl As String)
        If conn.State = ConnectionState.Open Then
            conn.Close()
            conn.Open()
        Else
            conn.Open()
        End If
        CMD = New OleDbCommand("select * from infoopname where idInfo='" & idinfo & "'", conn)
        RD = CMD.ExecuteReader
        RD.Read()
        If Not RD.HasRows Then
            Try
                conn.Close()
                conn.Open()
                Dim query As String
                query = "insert into infoopname (idInfo,lokasi,Tanggal) values('" & idinfo & "','" & lok & "','" & tgl & "')"
                CMD = New OleDbCommand(query, conn)
                CMD.ExecuteNonQuery()
                CMD.Dispose()
                Input.BtnSimpan.Text = "Update"
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try
        End If
        conn.Close()
    End Sub
    Public Sub ReportAudit(ByVal nc As String, ByVal idInfo As String)
        If conn.State = ConnectionState.Open Then
            conn.Close()
            conn.Open()
        Else
            conn.Open()
        End If
        DA = New OleDbDataAdapter("select b.isbn,b.kodeBuku,b.judul,b.jilid,b.jenjang,b.noRak,ds." & nc & " as Stock_Sistem,Iif(IsNull(ss." & nc & " ),0,ss." & nc & ") As Sample,Iif(IsNull(sc." & nc & " ),0,sc." & nc & ") As Rusak,op.sFisik as Stock_Nyata,op.SampleNyata,op.RusakNyata,op.keterangan from (((opname op LEFT join buku b on op.isbn=b.isbn) LEFT JOIN dummystock ds on op.kodeBuku=ds.kodeBuku) LEFT JOIN stocksample ss on op.kodeBuku=ss.kodeBuku) LEFT JOIN stockcacad sc on op.kodeBuku=sc.kodeBuku where idInfo='" & idInfo & "'", conn)
        DS.Reset()
        DS.Clear()
        DS.Tables.Clear()
        If Not DA Is Nothing Then
            DA.Fill(DS)
            Laporan_Audit.DataGridView1.DataSource = DS.Tables(0)
            Laporan_Audit.btnExport.Enabled = True
        End If
        conn.Close()
    End Sub
    Public Sub cekLogin(ByVal uname As String, ByVal pwd As String)
        If conn.State = ConnectionState.Open Then
            conn.Close()
            conn.Open()
        Else
            conn.Open()
        End If
        Try
            CMD = New OleDbCommand("select * from login where username='" & uname & "' and password='" & pwd & "'", conn)
            RD = CMD.ExecuteReader()
            RD.Read()
        Catch ex As Exception
            MsgBox(ex.Message.ToString)
        End Try

        If RD.HasRows = True Then
            Form1.Show()
            LoginForm1.Hide()
        Else
            MessageBox.Show("Kombinasi Username dan Password  ", "Konfrimasi", MessageBoxButtons.OK, MessageBoxIcon.Error)
            LoginForm1.UsernameTextBox.Text = ""
            LoginForm1.PasswordTextBox.Text = ""
        End If

    End Sub
    Public Sub SimpanGoodUnit(ByVal kb As String, ByVal qty As String, ByVal field As String)
        If conn.State = ConnectionState.Open Then
            conn.Close()
            conn.Open()
        Else
            conn.Open()
        End If
        CMD = New OleDbCommand("Select * from dummyStock where kodeBuku='" & kb & "'", conn)
        RD = CMD.ExecuteReader
        RD.Read()
        If Not RD.HasRows Then
            conn.Close()
            conn.Open()
            Try
                Dim simpan As String = "insert into dummyStock (kodeBuku," & field & ") values('" & kb & "','" & qty & "')"
                CMD = New OleDbCommand(simpan, conn)
                CMD.ExecuteNonQuery()
                CMD.Dispose()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try

            conn.Close()
        Else
            conn.Close()
            conn.Open()
            Try
                Dim edit As String
                edit = "update dummyStock set " & field & "='" & qty & "' where kodeBuku='" & kb & "'"
                CMD = New OleDbCommand(edit, conn)
                CMD.ExecuteNonQuery()
                CMD.Dispose()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
            conn.Close()
        End If
    End Sub
    Public Sub SimpanSample(ByVal kb As String, ByVal qty As String, ByVal field As String)
        If conn.State = ConnectionState.Open Then
            conn.Close()
            conn.Open()
        Else
            conn.Open()
        End If
        CMD = New OleDbCommand("Select * from stocksample where kodeBuku='" & kb & "'", conn)
        RD = CMD.ExecuteReader
        RD.Read()
        If Not RD.HasRows Then
            conn.Close()
            conn.Open()
            Try
                Dim simpan As String = "insert into stocksample (kodeBuku," & field & ") values('" & kb & "','" & qty & "')"
                CMD = New OleDbCommand(simpan, conn)
                CMD.ExecuteNonQuery()
                CMD.Dispose()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try

            conn.Close()
        Else
            conn.Close()
            conn.Open()
            Try
                Dim edit As String
                edit = "update stocksample set " & field & "='" & qty & "' where kodeBuku='" & kb & "'"
                CMD = New OleDbCommand(edit, conn)
                CMD.ExecuteNonQuery()
                CMD.Dispose()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
            conn.Close()
        End If
    End Sub
    Public Sub SimpanRusak(ByVal kb As String, ByVal qty As String, ByVal field As String)
        If conn.State = ConnectionState.Open Then
            conn.Close()
            conn.Open()
        Else
            conn.Open()
        End If
        CMD = New OleDbCommand("Select * from stockcacad where kodeBuku='" & kb & "'", conn)
        RD = CMD.ExecuteReader
        RD.Read()
        If Not RD.HasRows Then
            conn.Close()
            conn.Open()
            Try
                Dim simpan As String = "insert into stockcacad (kodeBuku," & field & ") values('" & kb & "','" & qty & "')"
                CMD = New OleDbCommand(simpan, conn)
                CMD.ExecuteNonQuery()
                CMD.Dispose()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try

            conn.Close()
        Else
            conn.Close()
            conn.Open()
            Try
                Dim edit As String
                edit = "update stockcacad set " & field & "='" & qty & "' where kodeBuku='" & kb & "'"
                CMD = New OleDbCommand(edit, conn)
                CMD.ExecuteNonQuery()
                CMD.Dispose()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try
            conn.Close()
        End If
    End Sub
End Module
