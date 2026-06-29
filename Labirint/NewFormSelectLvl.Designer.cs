namespace Labirint
{
    partial class NewFormSelectLvl
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
            this.flowLayoutPanelLvls = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonBackToMenu = new System.Windows.Forms.Button();
            this.labelLvl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // flowLayoutPanelLvls
            // 
            this.flowLayoutPanelLvls.AutoScroll = true;
            this.flowLayoutPanelLvls.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.flowLayoutPanelLvls.Location = new System.Drawing.Point(73, 101);
            this.flowLayoutPanelLvls.Name = "flowLayoutPanelLvls";
            this.flowLayoutPanelLvls.Size = new System.Drawing.Size(449, 277);
            this.flowLayoutPanelLvls.TabIndex = 0;
            // 
            // buttonBackToMenu
            // 
            this.buttonBackToMenu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonBackToMenu.AutoSize = true;
            this.buttonBackToMenu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBackToMenu.Font = new System.Drawing.Font("Century", 12F);
            this.buttonBackToMenu.Location = new System.Drawing.Point(12, 431);
            this.buttonBackToMenu.Name = "buttonBackToMenu";
            this.buttonBackToMenu.Size = new System.Drawing.Size(81, 35);
            this.buttonBackToMenu.TabIndex = 5;
            this.buttonBackToMenu.TabStop = false;
            this.buttonBackToMenu.Text = "Назад";
            this.buttonBackToMenu.UseVisualStyleBackColor = true;
            this.buttonBackToMenu.Click += new System.EventHandler(this.buttonBackToMenu_Click);
            // 
            // labelLvl
            // 
            this.labelLvl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelLvl.AutoSize = true;
            this.labelLvl.BackColor = System.Drawing.Color.Transparent;
            this.labelLvl.Font = new System.Drawing.Font("Century", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLvl.Location = new System.Drawing.Point(191, 29);
            this.labelLvl.Name = "labelLvl";
            this.labelLvl.Size = new System.Drawing.Size(213, 28);
            this.labelLvl.TabIndex = 6;
            this.labelLvl.Text = "Выберите уровень";
            this.labelLvl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NewFormSelectLvl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 478);
            this.Controls.Add(this.labelLvl);
            this.Controls.Add(this.buttonBackToMenu);
            this.Controls.Add(this.flowLayoutPanelLvls);
            this.Name = "NewFormSelectLvl";
            this.Text = "Выбор уровня";
            this.Load += new System.EventHandler(this.NewFormSelectLvl_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelLvls;
        private System.Windows.Forms.Button buttonBackToMenu;
        private System.Windows.Forms.Label labelLvl;
    }
}