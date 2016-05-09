Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Imports Excel = Microsoft.Office.Interop.Excel
Public Class Input
    Dim tglsekarang As String
    Private Sub Input_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        koneksi()
        itemCombo()
        tglsekarang = Format(CDate(Date.Now.Date), "yyyy-MM-dd")
        txtTanggal.Text = tglsekarang
        Bukudgv()
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick

    End Sub

    Private Sub DataGridView1_CellValueChanged(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellValueChanged
        For baris As Integer = 0 To DataGridView1.RowCount - 2
            toDB.ViewBuku2(DataGridView1.Rows(baris).Cells(0).Value, baris, cmbNamacabang.Text)
        Next
    End Sub

    Private Sub BtnSimpan_Click(sender As Object, e As EventArgs) Handles BtnSimpan.Click

        If DataGridView1.Rows(0).Cells(1).Value = "" Then
            MsgBox("Tidak Dapat Menyimpan Data kosong", MsgBoxStyle.Information)
        Else
            simpanInfo(txtAudit.Text, cmbNamacabang.Text, txtTanggal.Text)
            Dim jumlahData As Double = DataGridView1.RowCount - 1
            Loading.Maximum = jumlahData
            Loading.Value = 0
            For baris As Integer = 0 To DataGridView1.RowCount - 2
                toDB.simpanOpname(txtAudit.Text, DataGridView1.Rows(baris).Cells(0).Value, DataGridView1.Rows(baris).Cells(1).Value, DataGridView1.Rows(baris).Cells(7).Value, DataGridView1.Rows(baris).Cells(9).Value, DataGridView1.Rows(baris).Cells(11).Value, DataGridView1.Rows(baris).Cells(12).Value)
                Loading.Value = Loading.Value + 1
            Next


            MsgBox("Data Tersimpan", MsgBoxStyle.Information, "Informasi")
        End If

    End Sub

    Private Sub btnBaru_Click(sender As Object, e As EventArgs) Handles btnBaru.Click
        Bukudgv()
        cmbNamacabang.Text = ""
        BtnSimpan.Text = "Simpan"
        btnExport.Enabled = False
        Loading.Value = 0
        lblData.Text = "0 Data Dari 0"
    End Sub

    Private Sub btnExport_Click(sender As Object, e As EventArgs) Handles btnExport.Click
        If DataGridView1.Rows(0).Cells(1).Value = "" Then
            MsgBox("Tidak Dapat Menyexport Data kosong", MsgBoxStyle.Information)
        Else
            Dim i As Integer
            Dim j As Integer
            Dim curr_row As Double = 0
            curr_row = Val("3")
            If ((DataGridView1.Columns.Count = 0) Or (DataGridView1.Rows.Count = 0)) Then
                Exit Sub
            End If
            Dim dset As New DataSet
            'add table to dataset
            dset.Tables.Add()
            'add column to that table
            For i = 0 To DataGridView1.ColumnCount - 1
                dset.Tables(0).Columns.Add(DataGridView1.Columns(i).HeaderText)
            Next
            Dim dr1 As DataRow
            For i = 0 To DataGridView1.RowCount - 1

                dr1 = dset.Tables(0).NewRow
                For j = 0 To DataGridView1.Columns.Count - 1
                    dr1(j) = DataGridView1.Rows(i).Cells(j).Value
                Next
                dset.Tables(0).Rows.Add(dr1)

            Next
            Dim excel As New Excel.Application
            Dim wBook As Microsoft.Office.Interop.Excel.Workbook
            Dim wSheet As Microsoft.Office.Interop.Excel.Worksheet

            wBook = excel.Workbooks.Add()
            wSheet = wBook.ActiveSheet()

            Dim dt As System.Data.DataTable = dset.Tables(0)
            Dim dc As System.Data.DataColumn
            Dim dr As System.Data.DataRow
            Dim colIndex As Integer = 0
            Dim rowIndex As Integer = 0

            For Each dc In dt.Columns
                colIndex = colIndex + 1
                excel.Cells(1, colIndex) = dc.ColumnName
            Next

            For Each dr In dt.Rows
                rowIndex = rowIndex + 1
                colIndex = 0
                For Each dc In dt.Columns
                    colIndex = colIndex + 1
                    excel.Cells(rowIndex + 1, colIndex) = dr(dc.ColumnName)
                Next
            Next

            wSheet.Columns.AutoFit()
            Dim strFileName As String = "D:\" & cmbNamacabang.Text & "-" & Format(Now, "dd-MM-yyyy") & ".xls"
            Dim blnFileOpen As Boolean = False
            Try
                Dim fileTemp As System.IO.FileStream = System.IO.File.OpenWrite(strFileName)
                fileTemp.Close()
            Catch ex As Exception
                blnFileOpen = False
            End Try

            If System.IO.File.Exists(strFileName) Then
                System.IO.File.Delete(strFileName)
            End If

            wBook.SaveAs(strFileName)

            excel.Visible = True
        End If
    End Sub

    Private Sub cmbNamacabang_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNamacabang.SelectedIndexChanged
        txtAudit.Text = cmbNamacabang.Text + "-" + txtTanggal.Text
    End Sub
End Class