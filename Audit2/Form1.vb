Public Class Form1

    Private Sub InputAuditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles InputAuditToolStripMenuItem.Click
        Input.Show()
    End Sub

    Private Sub LaporanAuditToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles LaporanAuditToolStripMenuItem.Click
        Laporan_Audit.Show()
    End Sub

    Private Sub Form1_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Application.Exit()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub UploadDataBukuToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles UploadDataBukuToolStripMenuItem.Click
        Upload.Show()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ToolStripStatusLabel2.Text = Date.Now().ToString("dd MMM yyyy - HH:mm:ss")
    End Sub
End Class
