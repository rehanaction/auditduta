Imports excel = Microsoft.Office.Interop.Excel
Imports System.IO
Imports System.Data
Imports System.Data.OleDb
Public Class Laporan_Audit

    Private Sub Laporan_Audit_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        toDB.koneksi()
        itemCombo()
    End Sub

    Private Sub cmbNC_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNC.SelectedIndexChanged
        If cmbNC.Text <> "" Then
            cmbNoAudit.Enabled = True
            itemNomorAudit(cmbNC.Text)
        Else
            MsgBox("pilih terlebih dahulu lokasi cabang", MsgBoxStyle.Information, "Informasi")
        End If
    End Sub

    Private Sub cmbNoAudit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbNoAudit.SelectedIndexChanged
        If cmbNoAudit.Text <> "" Then
            btnCari.Enabled = True
        End If
    End Sub

    Private Sub btnCari_Click(sender As Object, e As EventArgs) Handles btnCari.Click
        If cmbNC.Text <> "" And cmbNoAudit.Text <> "" Then
            ReportAudit(cmbNC.Text, cmbNoAudit.Text)
        End If
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
            Dim excel As New excel.Application
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
            Dim strFileName As String = "D:\Audit-" & cmbNoAudit.Text & ".xls"
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
End Class