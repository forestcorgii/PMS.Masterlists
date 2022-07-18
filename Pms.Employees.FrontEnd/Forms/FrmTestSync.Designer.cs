
namespace Pms.Employees.FrontEnd.Test
{
    partial class FrmTestSync
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.BtnFindOnServer = new System.Windows.Forms.Button();
            this.TbEEId = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 59);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(607, 231);
            this.dataGridView1.TabIndex = 0;
            // 
            // BtnFindOnServer
            // 
            this.BtnFindOnServer.Location = new System.Drawing.Point(118, 30);
            this.BtnFindOnServer.Name = "BtnFindOnServer";
            this.BtnFindOnServer.Size = new System.Drawing.Size(111, 23);
            this.BtnFindOnServer.TabIndex = 1;
            this.BtnFindOnServer.Text = "Find on Server";
            this.BtnFindOnServer.UseVisualStyleBackColor = true;
            this.BtnFindOnServer.Click += new System.EventHandler(this.BtnFindOnServer_Click);
            // 
            // TbEEId
            // 
            this.TbEEId.Location = new System.Drawing.Point(12, 31);
            this.TbEEId.Name = "TbEEId";
            this.TbEEId.Size = new System.Drawing.Size(100, 23);
            this.TbEEId.TabIndex = 2;
            // 
            // FrmTestSync
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 302);
            this.Controls.Add(this.TbEEId);
            this.Controls.Add(this.BtnFindOnServer);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FrmTestSync";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button BtnFindOnServer;
        private System.Windows.Forms.TextBox TbEEId;
    }
}
