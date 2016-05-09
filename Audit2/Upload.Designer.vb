<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Upload
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Upload))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.lblLokasi = New System.Windows.Forms.Label()
        Me.cmbCabang = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.txtBrowse = New System.Windows.Forms.TextBox()
        Me.btnBrowse = New System.Windows.Forms.Button()
        Me.btnUpload = New System.Windows.Forms.Button()
        Me.dgvData = New System.Windows.Forms.DataGridView()
        Me.Loading = New System.Windows.Forms.ProgressBar()
        Me.lblData = New System.Windows.Forms.Label()
        Me.RbtnSample = New System.Windows.Forms.RadioButton()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.RbtnOpsi1 = New System.Windows.Forms.RadioButton()
        Me.RbtnOpsi2 = New System.Windows.Forms.RadioButton()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.RbtnRusak = New System.Windows.Forms.RadioButton()
        Me.RbtnJual = New System.Windows.Forms.RadioButton()
        Me.jStock = New System.Windows.Forms.GroupBox()
        Me.GroupBox1.SuspendLayout()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.jStock.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.btnUpload)
        Me.GroupBox1.Controls.Add(Me.btnBrowse)
        Me.GroupBox1.Controls.Add(Me.txtBrowse)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.cmbCabang)
        Me.GroupBox1.Controls.Add(Me.lblLokasi)
        Me.GroupBox1.Enabled = False
        Me.GroupBox1.Location = New System.Drawing.Point(13, 53)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(518, 77)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Upload Data"
        '
        'lblLokasi
        '
        Me.lblLokasi.AutoSize = True
        Me.lblLokasi.Location = New System.Drawing.Point(16, 22)
        Me.lblLokasi.Name = "lblLokasi"
        Me.lblLokasi.Size = New System.Drawing.Size(44, 13)
        Me.lblLokasi.TabIndex = 0
        Me.lblLokasi.Text = "Cabang"
        '
        'cmbCabang
        '
        Me.cmbCabang.FormattingEnabled = True
        Me.cmbCabang.Location = New System.Drawing.Point(93, 19)
        Me.cmbCabang.Name = "cmbCabang"
        Me.cmbCabang.Size = New System.Drawing.Size(121, 21)
        Me.cmbCabang.TabIndex = 1
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(16, 49)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(64, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Lokasi Data"
        '
        'txtBrowse
        '
        Me.txtBrowse.Enabled = False
        Me.txtBrowse.Location = New System.Drawing.Point(93, 46)
        Me.txtBrowse.Name = "txtBrowse"
        Me.txtBrowse.Size = New System.Drawing.Size(121, 20)
        Me.txtBrowse.TabIndex = 3
        '
        'btnBrowse
        '
        Me.btnBrowse.Enabled = False
        Me.btnBrowse.Location = New System.Drawing.Point(220, 43)
        Me.btnBrowse.Name = "btnBrowse"
        Me.btnBrowse.Size = New System.Drawing.Size(75, 23)
        Me.btnBrowse.TabIndex = 4
        Me.btnBrowse.Text = "Browse...."
        Me.btnBrowse.UseVisualStyleBackColor = True
        '
        'btnUpload
        '
        Me.btnUpload.Enabled = False
        Me.btnUpload.Location = New System.Drawing.Point(301, 44)
        Me.btnUpload.Name = "btnUpload"
        Me.btnUpload.Size = New System.Drawing.Size(75, 23)
        Me.btnUpload.TabIndex = 5
        Me.btnUpload.Text = "Upload Data"
        Me.btnUpload.UseVisualStyleBackColor = True
        '
        'dgvData
        '
        Me.dgvData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.dgvData.Location = New System.Drawing.Point(12, 136)
        Me.dgvData.Name = "dgvData"
        Me.dgvData.Size = New System.Drawing.Size(642, 400)
        Me.dgvData.TabIndex = 1
        '
        'Loading
        '
        Me.Loading.Location = New System.Drawing.Point(12, 542)
        Me.Loading.Name = "Loading"
        Me.Loading.Size = New System.Drawing.Size(400, 23)
        Me.Loading.TabIndex = 2
        '
        'lblData
        '
        Me.lblData.AutoSize = True
        Me.lblData.Location = New System.Drawing.Point(418, 546)
        Me.lblData.Name = "lblData"
        Me.lblData.Size = New System.Drawing.Size(70, 13)
        Me.lblData.TabIndex = 3
        Me.lblData.Text = "0 Data Dari 0"
        '
        'RbtnSample
        '
        Me.RbtnSample.AutoSize = True
        Me.RbtnSample.Location = New System.Drawing.Point(78, 16)
        Me.RbtnSample.Name = "RbtnSample"
        Me.RbtnSample.Size = New System.Drawing.Size(105, 17)
        Me.RbtnSample.TabIndex = 7
        Me.RbtnSample.TabStop = True
        Me.RbtnSample.Text = "&Sample / Contoh&"
        Me.RbtnSample.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.RbtnOpsi2)
        Me.GroupBox2.Controls.Add(Me.RbtnOpsi1)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Location = New System.Drawing.Point(13, 1)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(187, 46)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 16)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "&Opsi : &"
        '
        'RbtnOpsi1
        '
        Me.RbtnOpsi1.AutoSize = True
        Me.RbtnOpsi1.Location = New System.Drawing.Point(58, 14)
        Me.RbtnOpsi1.Name = "RbtnOpsi1"
        Me.RbtnOpsi1.Size = New System.Drawing.Size(55, 17)
        Me.RbtnOpsi1.TabIndex = 1
        Me.RbtnOpsi1.TabStop = True
        Me.RbtnOpsi1.Text = "&Opsi 1&"
        Me.RbtnOpsi1.UseVisualStyleBackColor = True
        '
        'RbtnOpsi2
        '
        Me.RbtnOpsi2.AutoSize = True
        Me.RbtnOpsi2.Location = New System.Drawing.Point(119, 14)
        Me.RbtnOpsi2.Name = "RbtnOpsi2"
        Me.RbtnOpsi2.Size = New System.Drawing.Size(55, 17)
        Me.RbtnOpsi2.TabIndex = 2
        Me.RbtnOpsi2.TabStop = True
        Me.RbtnOpsi2.Text = "&Opsi 2&"
        Me.RbtnOpsi2.UseVisualStyleBackColor = True
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(6, 18)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(71, 13)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "&Jenis Stock : &"
        '
        'RbtnRusak
        '
        Me.RbtnRusak.AutoSize = True
        Me.RbtnRusak.Location = New System.Drawing.Point(189, 16)
        Me.RbtnRusak.Name = "RbtnRusak"
        Me.RbtnRusak.Size = New System.Drawing.Size(56, 17)
        Me.RbtnRusak.TabIndex = 8
        Me.RbtnRusak.TabStop = True
        Me.RbtnRusak.Text = "&Rusak&"
        Me.RbtnRusak.UseVisualStyleBackColor = True
        '
        'RbtnJual
        '
        Me.RbtnJual.AutoSize = True
        Me.RbtnJual.Location = New System.Drawing.Point(251, 16)
        Me.RbtnJual.Name = "RbtnJual"
        Me.RbtnJual.Size = New System.Drawing.Size(44, 17)
        Me.RbtnJual.TabIndex = 9
        Me.RbtnJual.TabStop = True
        Me.RbtnJual.Text = "&Jual&"
        Me.RbtnJual.UseVisualStyleBackColor = True
        '
        'jStock
        '
        Me.jStock.Controls.Add(Me.Label4)
        Me.jStock.Controls.Add(Me.RbtnJual)
        Me.jStock.Controls.Add(Me.RbtnRusak)
        Me.jStock.Controls.Add(Me.RbtnSample)
        Me.jStock.Location = New System.Drawing.Point(206, 1)
        Me.jStock.Name = "jStock"
        Me.jStock.Size = New System.Drawing.Size(325, 46)
        Me.jStock.TabIndex = 10
        Me.jStock.TabStop = False
        Me.jStock.Text = "&Jenis Stock&"
        '
        'Upload
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(667, 568)
        Me.Controls.Add(Me.jStock)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.lblData)
        Me.Controls.Add(Me.Loading)
        Me.Controls.Add(Me.dgvData)
        Me.Controls.Add(Me.GroupBox1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Upload"
        Me.Text = "Upload"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.dgvData, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.jStock.ResumeLayout(False)
        Me.jStock.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents btnUpload As Button
    Friend WithEvents btnBrowse As Button
    Friend WithEvents txtBrowse As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents cmbCabang As ComboBox
    Friend WithEvents lblLokasi As Label
    Friend WithEvents dgvData As DataGridView
    Friend WithEvents Loading As ProgressBar
    Friend WithEvents lblData As Label
    Friend WithEvents RbtnSample As RadioButton
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents RbtnJual As RadioButton
    Friend WithEvents RbtnRusak As RadioButton
    Friend WithEvents Label4 As Label
    Friend WithEvents RbtnOpsi2 As RadioButton
    Friend WithEvents RbtnOpsi1 As RadioButton
    Friend WithEvents Label3 As Label
    Friend WithEvents jStock As GroupBox
End Class
