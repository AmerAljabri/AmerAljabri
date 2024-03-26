namespace AccountSystem
{
    partial class HomeInvontory2
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.homeDataGridView = new System.Windows.Forms.DataGridView();
            this.a = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.homeDataGridView)).BeginInit();
            this.a.SuspendLayout();
            this.SuspendLayout();
            // 
            // homeDataGridView
            // 
            this.homeDataGridView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.homeDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.homeDataGridView.Location = new System.Drawing.Point(0, 92);
            this.homeDataGridView.Name = "homeDataGridView";
            this.homeDataGridView.Size = new System.Drawing.Size(652, 209);
            this.homeDataGridView.TabIndex = 6;
            // 
            // a
            // 
            this.a.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            this.a.Controls.Add(this.label1);
            this.a.Location = new System.Drawing.Point(0, 0);
            this.a.Name = "a";
            this.a.Size = new System.Drawing.Size(652, 70);
            this.a.TabIndex = 5;
            this.a.Paint += new System.Windows.Forms.PaintEventHandler(this.a_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(206, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "تقرير كشف للحسابات";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(267, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "سند قبض";
            // 
            // HomeInvontory2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.ClientSize = new System.Drawing.Size(653, 300);
            this.Controls.Add(this.homeDataGridView);
            this.Controls.Add(this.a);
            this.Controls.Add(this.label2);
            this.Name = "HomeInvontory2";
            this.Text = "HomeInvontory2";
            this.Load += new System.EventHandler(this.HomeInvontory2_Load);
            ((System.ComponentModel.ISupportInitialize)(this.homeDataGridView)).EndInit();
            this.a.ResumeLayout(false);
            this.a.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView homeDataGridView;
        private System.Windows.Forms.Panel a;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}