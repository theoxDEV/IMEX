namespace IMEX
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.DataGridView dgvPostos;
        private System.Windows.Forms.TextBox txtMunicipio;
        private System.Windows.Forms.ComboBox cmbUF;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Label lblStatus;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvPostos = new System.Windows.Forms.DataGridView();
            this.txtMunicipio = new System.Windows.Forms.TextBox();
            this.cmbUF = new System.Windows.Forms.ComboBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPostos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPostos
            // 
            this.dgvPostos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPostos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPostos.Location = new System.Drawing.Point(12, 58);
            this.dgvPostos.Name = "dgvPostos";
            this.dgvPostos.Size = new System.Drawing.Size(760, 350);
            this.dgvPostos.TabIndex = 0;

            // 
            // txtMunicipio
            // 
            this.txtMunicipio.Location = new System.Drawing.Point(12, 20);
            this.txtMunicipio.Name = "txtMunicipio";
            this.txtMunicipio.PlaceholderText = "Digite o município";
            this.txtMunicipio.Size = new System.Drawing.Size(200, 23);
            this.txtMunicipio.TabIndex = 1;
            // 
            // cmbUF
            // 
            this.cmbUF.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbUF.FormattingEnabled = true;
            this.cmbUF.Items.AddRange(new object[] {
            "AC","AL","AM","AP","BA","CE","DF","ES","GO","MA","MG","MS","MT",
            "PA","PB","PE","PI","PR","RJ","RN","RO","RR","RS","SC","SE","SP","TO"});
            this.cmbUF.Location = new System.Drawing.Point(230, 20);
            this.cmbUF.Name = "cmbUF";
            this.cmbUF.Size = new System.Drawing.Size(60, 23);
            this.cmbUF.TabIndex = 2;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(310, 20);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 3;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(12, 420);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 15);
            this.lblStatus.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.cmbUF);
            this.Controls.Add(this.txtMunicipio);
            this.Controls.Add(this.dgvPostos);
            this.Name = "Form1";
            this.Text = "Consulta de Revendedores - ANP";
            ((System.ComponentModel.ISupportInitialize)(this.dgvPostos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}