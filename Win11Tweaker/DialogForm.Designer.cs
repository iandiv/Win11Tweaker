namespace Win11Tweaker
{
    partial class DialogForm
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
            this.components = new System.ComponentModel.Container();
            this.positiveBtn = new CustomComponent.RoundButton(this.components);
            this.desc = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.negativeBtn = new CustomComponent.RoundButton(this.components);
            this.roundPanel1 = new CustomComponent.RoundPanel();
            this.roundPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // positiveBtn
            // 
            this.positiveBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.positiveBtn.AutoSize = true;
            this.positiveBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(73)))), ((int)(((byte)(128)))));
            this.positiveBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.positiveBtn.BorderRadius = 5;
            this.positiveBtn.BorderRoundSize = 1;
            this.positiveBtn.FlatAppearance.BorderSize = 0;
            this.positiveBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(73)))), ((int)(((byte)(128)))));
            this.positiveBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(2)))), ((int)(((byte)(86)))), ((int)(((byte)(150)))));
            this.positiveBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.positiveBtn.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 9.75F, System.Drawing.FontStyle.Bold);
            this.positiveBtn.ForeColor = System.Drawing.Color.White;
            this.positiveBtn.Location = new System.Drawing.Point(112, 23);
            this.positiveBtn.Name = "positiveBtn";
            this.positiveBtn.Size = new System.Drawing.Size(123, 37);
            this.positiveBtn.TabIndex = 7;
            this.positiveBtn.Text = "Restart Explorer";
            this.positiveBtn.UseVisualStyleBackColor = false;
            this.positiveBtn.Click += new System.EventHandler(this.positiveBtn_Click);
            // 
            // desc
            // 
            this.desc.BackColor = System.Drawing.Color.Transparent;
            this.desc.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.desc.ForeColor = System.Drawing.Color.White;
            this.desc.Location = new System.Drawing.Point(26, 38);
            this.desc.Name = "desc";
            this.desc.Size = new System.Drawing.Size(309, 37);
            this.desc.TabIndex = 9;
            this.desc.Text = "Restart Explorer for the changes to take the effect";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI Variable Small Semibol", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(24, -6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 28);
            this.label1.TabIndex = 8;
            this.label1.Text = "Win11 Tweaker";
            // 
            // negativeBtn
            // 
            this.negativeBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.negativeBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.negativeBtn.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.negativeBtn.BorderRadius = 5;
            this.negativeBtn.BorderRoundSize = 1;
            this.negativeBtn.FlatAppearance.BorderSize = 0;
            this.negativeBtn.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.negativeBtn.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))), ((int)(((byte)(100)))));
            this.negativeBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.negativeBtn.Font = new System.Drawing.Font("Segoe UI Variable Display Semib", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.negativeBtn.ForeColor = System.Drawing.Color.White;
            this.negativeBtn.Location = new System.Drawing.Point(241, 23);
            this.negativeBtn.Name = "negativeBtn";
            this.negativeBtn.Size = new System.Drawing.Size(100, 37);
            this.negativeBtn.TabIndex = 0;
            this.negativeBtn.Text = "Later";
            this.negativeBtn.UseVisualStyleBackColor = false;
            this.negativeBtn.Click += new System.EventHandler(this.negativeBtn_Click);
            // 
            // roundPanel1
            // 
            this.roundPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.roundPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.roundPanel1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.roundPanel1.BorderRadius = 5;
            this.roundPanel1.BorderRoundSize = 1;
            this.roundPanel1.Clickable = false;
            this.roundPanel1.Controls.Add(this.positiveBtn);
            this.roundPanel1.Controls.Add(this.negativeBtn);
            this.roundPanel1.Location = new System.Drawing.Point(-6, 88);
            this.roundPanel1.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.roundPanel1.MouseLeaveBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.roundPanel1.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.roundPanel1.MouseUpBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(70)))));
            this.roundPanel1.Name = "roundPanel1";
            this.roundPanel1.Size = new System.Drawing.Size(370, 84);
            this.roundPanel1.TabIndex = 10;
            // 
            // DialogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(359, 167);
            this.ControlBox = false;
            this.Controls.Add(this.desc);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.roundPanel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DialogForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "    ";
            this.Load += new System.EventHandler(this.DialogForm_Load);
            this.roundPanel1.ResumeLayout(false);
            this.roundPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomComponent.RoundButton positiveBtn;
        private System.Windows.Forms.Label desc;
        private System.Windows.Forms.Label label1;
        private CustomComponent.RoundButton negativeBtn;
        private CustomComponent.RoundPanel roundPanel1;
    }
}