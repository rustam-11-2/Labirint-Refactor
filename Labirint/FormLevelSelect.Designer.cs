namespace Labirint
{
    partial class FormLevelSelect
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
            this.buttonlvl1 = new System.Windows.Forms.Button();
            this.buttonlvl2 = new System.Windows.Forms.Button();
            this.buttonlvl3 = new System.Windows.Forms.Button();
            this.labelLvl = new System.Windows.Forms.Label();
            this.buttonBackToMenu = new System.Windows.Forms.Button();
            this.tableLayoutPanelLevels = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanelLevels.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonlvl1
            // 
            this.buttonlvl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonlvl1.AutoSize = true;
            this.buttonlvl1.BackColor = System.Drawing.SystemColors.Control;
            this.buttonlvl1.Font = new System.Drawing.Font("Century", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonlvl1.Location = new System.Drawing.Point(33, 15);
            this.buttonlvl1.Name = "buttonlvl1";
            this.buttonlvl1.Size = new System.Drawing.Size(104, 47);
            this.buttonlvl1.TabIndex = 0;
            this.buttonlvl1.TabStop = false;
            this.buttonlvl1.Tag = "lvl1";
            this.buttonlvl1.Text = "Уровень 1";
            this.buttonlvl1.UseVisualStyleBackColor = false;
            this.buttonlvl1.Click += new System.EventHandler(this.buttonlvl1_Click);
            // 
            // buttonlvl2
            // 
            this.buttonlvl2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonlvl2.AutoSize = true;
            this.buttonlvl2.Font = new System.Drawing.Font("Century", 10F);
            this.buttonlvl2.Location = new System.Drawing.Point(204, 15);
            this.buttonlvl2.Name = "buttonlvl2";
            this.buttonlvl2.Size = new System.Drawing.Size(104, 47);
            this.buttonlvl2.TabIndex = 1;
            this.buttonlvl2.TabStop = false;
            this.buttonlvl2.Tag = "lvl2";
            this.buttonlvl2.Text = "Уровень 2";
            this.buttonlvl2.UseVisualStyleBackColor = true;
            this.buttonlvl2.Click += new System.EventHandler(this.buttonlvl1_Click);
            // 
            // buttonlvl3
            // 
            this.buttonlvl3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonlvl3.AutoSize = true;
            this.buttonlvl3.Font = new System.Drawing.Font("Century", 10F);
            this.buttonlvl3.Location = new System.Drawing.Point(376, 15);
            this.buttonlvl3.Name = "buttonlvl3";
            this.buttonlvl3.Size = new System.Drawing.Size(104, 47);
            this.buttonlvl3.TabIndex = 2;
            this.buttonlvl3.TabStop = false;
            this.buttonlvl3.Tag = "lvl3";
            this.buttonlvl3.Text = "Уровень 3";
            this.buttonlvl3.UseVisualStyleBackColor = true;
            this.buttonlvl3.Click += new System.EventHandler(this.buttonlvl1_Click);
            // 
            // labelLvl
            // 
            this.labelLvl.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.labelLvl.AutoSize = true;
            this.labelLvl.BackColor = System.Drawing.Color.Transparent;
            this.labelLvl.Font = new System.Drawing.Font("Century", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelLvl.Location = new System.Drawing.Point(191, 44);
            this.labelLvl.Name = "labelLvl";
            this.labelLvl.Size = new System.Drawing.Size(213, 28);
            this.labelLvl.TabIndex = 3;
            this.labelLvl.Text = "Выберите уровень";
            this.labelLvl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonBackToMenu
            // 
            this.buttonBackToMenu.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonBackToMenu.AutoSize = true;
            this.buttonBackToMenu.Font = new System.Drawing.Font("Century", 12F);
            this.buttonBackToMenu.Location = new System.Drawing.Point(40, 399);
            this.buttonBackToMenu.Name = "buttonBackToMenu";
            this.buttonBackToMenu.Size = new System.Drawing.Size(79, 33);
            this.buttonBackToMenu.TabIndex = 4;
            this.buttonBackToMenu.TabStop = false;
            this.buttonBackToMenu.Text = "Назад";
            this.buttonBackToMenu.UseVisualStyleBackColor = true;
            this.buttonBackToMenu.Click += new System.EventHandler(this.buttonBackToMenu_Click);
            // 
            // tableLayoutPanelLevels
            // 
            this.tableLayoutPanelLevels.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.tableLayoutPanelLevels.ColumnCount = 3;
            this.tableLayoutPanelLevels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelLevels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelLevels.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanelLevels.Controls.Add(this.buttonlvl1, 0, 0);
            this.tableLayoutPanelLevels.Controls.Add(this.buttonlvl2, 1, 0);
            this.tableLayoutPanelLevels.Controls.Add(this.buttonlvl3, 2, 0);
            this.tableLayoutPanelLevels.Location = new System.Drawing.Point(40, 101);
            this.tableLayoutPanelLevels.Name = "tableLayoutPanelLevels";
            this.tableLayoutPanelLevels.RowCount = 1;
            this.tableLayoutPanelLevels.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelLevels.Size = new System.Drawing.Size(515, 77);
            this.tableLayoutPanelLevels.TabIndex = 5;
            // 
            // FormLevelSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(594, 478);
            this.Controls.Add(this.tableLayoutPanelLevels);
            this.Controls.Add(this.buttonBackToMenu);
            this.Controls.Add(this.labelLvl);
            this.Name = "FormLevelSelect";
            this.Text = "Выбор уровня";
            this.Load += new System.EventHandler(this.FormLevelSelect_Load);
            this.tableLayoutPanelLevels.ResumeLayout(false);
            this.tableLayoutPanelLevels.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonlvl1;
        private System.Windows.Forms.Button buttonlvl2;
        private System.Windows.Forms.Button buttonlvl3;
        private System.Windows.Forms.Label labelLvl;
        private System.Windows.Forms.Button buttonBackToMenu;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelLevels;
    }
}