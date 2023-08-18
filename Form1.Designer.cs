using System.Windows.Forms;

namespace reportCalendario32
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.genera = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.mese = new System.Windows.Forms.TextBox();
            this.stampa = new System.Windows.Forms.Button();
            this.lista = new System.Windows.Forms.DataGridView();
            this.numero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.giorno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reset = new System.Windows.Forms.Button();
            this.titolo = new System.Windows.Forms.Label();
            this.report = new System.Drawing.Printing.PrintDocument();
            this.previewReport = new System.Windows.Forms.PrintPreviewDialog();
            ((System.ComponentModel.ISupportInitialize)(this.lista)).BeginInit();
            this.SuspendLayout();
            // 
            // genera
            // 
            this.genera.Location = new System.Drawing.Point(380, 212);
            this.genera.Name = "genera";
            this.genera.Size = new System.Drawing.Size(64, 20);
            this.genera.TabIndex = 0;
            this.genera.Text = "genera";
            this.genera.UseVisualStyleBackColor = true;
            this.genera.Click += new System.EventHandler(this.genera_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(413, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "mese";
            // 
            // mese
            // 
            this.mese.Location = new System.Drawing.Point(413, 131);
            this.mese.Name = "mese";
            this.mese.Size = new System.Drawing.Size(31, 20);
            this.mese.TabIndex = 5;
            // 
            // stampa
            // 
            this.stampa.Location = new System.Drawing.Point(380, 187);
            this.stampa.Name = "stampa";
            this.stampa.Size = new System.Drawing.Size(64, 20);
            this.stampa.TabIndex = 6;
            this.stampa.Text = "stampa";
            this.stampa.UseVisualStyleBackColor = true;
            this.stampa.Click += new System.EventHandler(this.stampa_Click);
            // 
            // lista
            // 
            this.lista.AllowDrop = true;
            this.lista.BackgroundColor = System.Drawing.Color.White;
            this.lista.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lista.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.lista.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numero,
            this.giorno,
            this.ore});
            this.lista.Location = new System.Drawing.Point(10, 5);
            this.lista.Name = "lista";
            this.lista.RowTemplate.Height = 25;
            this.lista.Size = new System.Drawing.Size(303, 220);
            this.lista.TabIndex = 7;
            // 
            // numero
            // 
            this.numero.HeaderText = "numero";
            this.numero.Name = "numero";
            // 
            // giorno
            // 
            this.giorno.HeaderText = "giorno";
            this.giorno.Name = "giorno";
            // 
            // ore
            // 
            this.ore.HeaderText = "ore";
            this.ore.Name = "ore";
            // 
            // reset
            // 
            this.reset.Location = new System.Drawing.Point(380, 160);
            this.reset.Name = "reset";
            this.reset.Size = new System.Drawing.Size(64, 20);
            this.reset.TabIndex = 8;
            this.reset.Text = "reset";
            this.reset.UseVisualStyleBackColor = true;
            this.reset.Click += new System.EventHandler(this.reset_Click);
            // 
            // titolo
            // 
            this.titolo.AutoSize = true;
            this.titolo.Location = new System.Drawing.Point(390, 89);
            this.titolo.Name = "titolo";
            this.titolo.Size = new System.Drawing.Size(0, 13);
            this.titolo.TabIndex = 9;
            // 
            // report
            // 
            this.report.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.report_PrintPage);
            // 
            // previewReport
            // 
            this.previewReport.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.previewReport.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.previewReport.ClientSize = new System.Drawing.Size(400, 300);
            this.previewReport.Enabled = true;
            this.previewReport.Icon = ((System.Drawing.Icon)(resources.GetObject("previewReport.Icon")));
            this.previewReport.Name = "printPreviewDialog1";
            this.previewReport.Visible = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 262);
            this.Controls.Add(this.titolo);
            this.Controls.Add(this.reset);
            this.Controls.Add(this.lista);
            this.Controls.Add(this.stampa);
            this.Controls.Add(this.mese);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.genera);
            this.Name = "FormMain";
            this.Text = "reportCalendario";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.lista)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button genera;
        private Label label1;
        private TextBox mese;
        private Button stampa;
        private DataGridView lista;
        private DataGridViewTextBoxColumn numero;
        private DataGridViewTextBoxColumn giorno;
        private DataGridViewTextBoxColumn ore;
        private Button reset;
        private Label titolo;
        private System.Drawing.Printing.PrintDocument report;
        private PrintPreviewDialog previewReport;
    }
}