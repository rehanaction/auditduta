Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports Excel = Microsoft.Office.Interop.Excel
Public Class Upload
    Dim tblImport As DataTable
    Dim con As OleDbConnection
    Dim da As OleDbDataAdapter
    Dim ds As New DataSet
    Dim cmd As OleDbCommand
    Dim source1 As New BindingSource
    Private Sub RbtnOpsi1_CheckedChanged(sender As Object, e As EventArgs) Handles RbtnOpsi1.CheckedChanged
        If RbtnOpsi1.Checked = True Then
            jStock.Refresh()
            RbtnJual.Checked = False
            RbtnRusak.Checked = False
            RbtnSample.Checked = False
            jStock.Enabled = False
            def()
            GroupBox1.Enabled = True
        End If
    End Sub

    Private Sub RbtnOpsi2_CheckedChanged(sender As Object, e As EventArgs) Handles RbtnOpsi2.CheckedChanged
        If RbtnOpsi2.Checked = True Then
            jStock.Refresh()
            jStock.Enabled = True
            GroupBox1.Enabled = False

        End If
    End Sub
    Sub def()
        cmbCabang.Text = ""
        txtBrowse.Text = ""
        Loading.Value = 0
        dgvData.DataSource = Nothing
    End Sub

    Private Sub RbtnSample_CheckedChanged(sender As Object, e As EventArgs) Handles RbtnSample.CheckedChanged
        If RbtnSample.Checked = True Then
            def()
            GroupBox1.Enabled = True
        End If
    End Sub

    Private Sub RbtnRusak_CheckedChanged(sender As Object, e As EventArgs) Handles RbtnRusak.CheckedChanged
        If RbtnRusak.Checked = True Then
            def()
            GroupBox1.Enabled = True
        End If
    End Sub

    Private Sub RbtnJual_CheckedChanged(sender As Object, e As EventArgs) Handles RbtnJual.CheckedChanged
        If RbtnJual.Checked = True Then
            def()
            GroupBox1.Enabled = True
        End If
    End Sub

    Private Sub Upload_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        itemCombo()
    End Sub

    Private Sub btnBrowse_Click(sender As Object, e As EventArgs) Handles btnBrowse.Click
        Dim fBrowse As New OpenFileDialog
        With fBrowse
            .Filter = "excel files 2003-2007 (*.xls)|*.xls|all files (*.*)|*.*"
            .FilterIndex = 1
            .Title = "Import data From Excel File"
        End With
        If fBrowse.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtBrowse.Text = fBrowse.FileName
            Try
                con = New OleDbConnection("provider=Microsoft.Jet.OLEDB.4.0;" &
                    "data source='" & fBrowse.FileName & "';Extended Properties=Excel 8.0;")

                DA = New OleDbDataAdapter("select * from [Sheet1$]", con)

                con.Open()
            Catch ex As Exception
                MsgBox(ex.Message.ToString)
            End Try

            Try
                DS.Reset()
                DS.Clear()
                DS.Tables.Clear()
                DA.Fill(DS)
                dgvData.DataSource = DS.Tables(0)
            Catch ex As Exception
                MsgBox(ex.ToString)
            End Try

            con.Close()



        End If
    End Sub

    Private Sub cmbCabang_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCabang.SelectedIndexChanged
        If cmbCabang.SelectedItem <> "" Then
            btnBrowse.Enabled = True
        End If
    End Sub

    Private Sub txtBrowse_TextChanged(sender As Object, e As EventArgs) Handles txtBrowse.TextChanged
        If txtBrowse.Text <> "" Then
            btnUpload.Enabled = True
        End If
    End Sub

    Private Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        If RbtnOpsi1.Checked = True Then
            Dim kb, ckb As String
            Dim jmldata As Double = dgvData.RowCount - 1
            Loading.Maximum = jmldata
            Loading.Value = 0
            For baris As Integer = 0 To dgvData.RowCount - 2
                If Not IsDBNull(dgvData.Rows(baris).Cells(0).Value) Then
                    If IsDBNull(dgvData.Rows(baris).Cells(2).Value) Then
                        dgvData.Rows(baris).Cells(2).Value = 0
                    End If
                    kb = dgvData.Rows(baris).Cells(0).Value.ToString()
                    ckb = kb.Replace("-", "")
                    toDB.SimpanGoodUnit(ckb, dgvData.Rows(baris).Cells(2).Value, cmbCabang.Text)
                    toDB.SimpanSample(ckb, dgvData.Rows(baris).Cells(3).Value, cmbCabang.Text)
                    toDB.SimpanRusak(ckb, dgvData.Rows(baris).Cells(4).Value, cmbCabang.Text)
                    Loading.Value = Loading.Value + 1
                    lblData.Text = "Menyimpan data " & Loading.Value & " Dari " & jmldata
                Else
                    Exit For
                End If
            Next
            MsgBox("Data Berhasil Tersimpan", MsgBoxStyle.Information)
            def()
        ElseIf RbtnOpsi2.Checked = True And RbtnJual.Checked = True Then
            Dim kb, ckb As String
            Dim jmldata As Double = dgvData.RowCount - 1
            Loading.Maximum = jmldata
            Loading.Value = 0
            For baris As Integer = 0 To dgvData.RowCount - 2
                If Not IsDBNull(dgvData.Rows(baris).Cells(0).Value) Then
                    If IsDBNull(dgvData.Rows(baris).Cells(2).Value) Then
                        dgvData.Rows(baris).Cells(2).Value = 0
                    End If
                    kb = dgvData.Rows(baris).Cells(0).Value.ToString()
                    ckb = kb.Replace("-", "")
                    toDB.SimpanGoodUnit(ckb, dgvData.Rows(baris).Cells(2).Value, cmbCabang.Text)
                    Loading.Value = Loading.Value + 1
                    lblData.Text = "Menyimpan data " & Loading.Value & " Dari " & jmldata
                Else
                    Exit For
                End If
            Next
            MsgBox("Data Berhasil Tersimpan", MsgBoxStyle.Information)
            def()
        ElseIf RbtnOpsi2.Checked = True And RbtnSample.Checked = True Then
            Dim kb, ckb As String
            Dim jmldata As Double = dgvData.RowCount - 1
            Loading.Maximum = jmldata
            Loading.Value = 0
            For baris As Integer = 0 To dgvData.RowCount - 2
                If Not IsDBNull(dgvData.Rows(baris).Cells(0).Value) Then
                    If IsDBNull(dgvData.Rows(baris).Cells(2).Value) Then
                        dgvData.Rows(baris).Cells(2).Value = 0
                    End If
                    kb = dgvData.Rows(baris).Cells(0).Value.ToString()
                    ckb = kb.Replace("-", "")
                    toDB.SimpanSample(ckb, dgvData.Rows(baris).Cells(2).Value, cmbCabang.Text)
                    Loading.Value = Loading.Value + 1
                    lblData.Text = "Menyimpan data " & Loading.Value & " Dari " & jmldata
                Else
                    Exit For
                End If
            Next
            MsgBox("Data Berhasil Tersimpan", MsgBoxStyle.Information)
            def()
        ElseIf RbtnOpsi2.Checked = True And RbtnRusak.Checked = True Then
            Dim kb, ckb As String
            Dim jmldata As Double = dgvData.RowCount - 1
            Loading.Maximum = jmldata
            Loading.Value = 0
            For baris As Integer = 0 To dgvData.RowCount - 2
                If Not IsDBNull(dgvData.Rows(baris).Cells(0).Value) Then
                    If IsDBNull(dgvData.Rows(baris).Cells(2).Value) Then
                        dgvData.Rows(baris).Cells(2).Value = 0
                    End If
                    kb = dgvData.Rows(baris).Cells(0).Value.ToString()
                    ckb = kb.Replace("-", "")
                    toDB.SimpanRusak(ckb, dgvData.Rows(baris).Cells(2).Value, cmbCabang.Text)
                    Loading.Value = Loading.Value + 1
                    lblData.Text = "Menyimpan data " & Loading.Value & " Dari " & jmldata
                Else
                    Exit For
                End If
            Next
            MsgBox("Data Berhasil Tersimpan", MsgBoxStyle.Information)
            def()
        End If

    End Sub
End Class