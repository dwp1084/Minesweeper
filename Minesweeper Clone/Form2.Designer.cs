
namespace Minesweeper_Clone {
    partial class MineGUI {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.numberOfBombsLabel = new System.Windows.Forms.Label();
            this.watch = new System.Windows.Forms.Label();
            this.topMenu = new System.Windows.Forms.TableLayoutPanel();
            this.resetButton = new System.Windows.Forms.Label();
            this.boardPanel = new System.Windows.Forms.Panel();
            this.topMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // numberOfBombsLabel
            // 
            this.numberOfBombsLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numberOfBombsLabel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.numberOfBombsLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.numberOfBombsLabel.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.numberOfBombsLabel.ForeColor = System.Drawing.Color.Red;
            this.numberOfBombsLabel.Location = new System.Drawing.Point(182, 0);
            this.numberOfBombsLabel.Margin = new System.Windows.Forms.Padding(0);
            this.numberOfBombsLabel.Name = "numberOfBombsLabel";
            this.numberOfBombsLabel.Size = new System.Drawing.Size(85, 56);
            this.numberOfBombsLabel.TabIndex = 2;
            this.numberOfBombsLabel.Text = "000";
            this.numberOfBombsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // watch
            // 
            this.watch.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.watch.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.watch.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.watch.ForeColor = System.Drawing.Color.Red;
            this.watch.Location = new System.Drawing.Point(0, 0);
            this.watch.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.watch.Name = "watch";
            this.watch.Size = new System.Drawing.Size(103, 53);
            this.watch.TabIndex = 3;
            this.watch.Text = "0000";
            this.watch.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // topMenu
            // 
            this.topMenu.ColumnCount = 5;
            this.topMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 110F));
            this.topMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.topMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.topMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.topMenu.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 92F));
            this.topMenu.Controls.Add(this.watch, 0, 0);
            this.topMenu.Controls.Add(this.numberOfBombsLabel, 4, 0);
            this.topMenu.Controls.Add(this.resetButton, 2, 0);
            this.topMenu.Location = new System.Drawing.Point(11, 13);
            this.topMenu.Margin = new System.Windows.Forms.Padding(0);
            this.topMenu.Name = "topMenu";
            this.topMenu.RowCount = 1;
            this.topMenu.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.topMenu.Size = new System.Drawing.Size(267, 56);
            this.topMenu.TabIndex = 5;
            // 
            // resetButton
            // 
            this.resetButton.Image = global::Minesweeper_Clone.Properties.Resources.Smile;
            this.resetButton.Location = new System.Drawing.Point(121, 0);
            this.resetButton.Margin = new System.Windows.Forms.Padding(0);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(43, 53);
            this.resetButton.TabIndex = 4;
            // 
            // boardPanel
            // 
            this.boardPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.boardPanel.Location = new System.Drawing.Point(11, 85);
            this.boardPanel.Margin = new System.Windows.Forms.Padding(0);
            this.boardPanel.Name = "boardPanel";
            this.boardPanel.Size = new System.Drawing.Size(23, 26);
            this.boardPanel.TabIndex = 6;
            // 
            // MineGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.ClientSize = new System.Drawing.Size(289, 132);
            this.Controls.Add(this.boardPanel);
            this.Controls.Add(this.topMenu);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.Name = "MineGUI";
            this.Padding = new System.Windows.Forms.Padding(11, 13, 11, 13);
            this.Text = "Minesweeper";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MineGUI_FormClosing);
            this.Load += new System.EventHandler(this.MineGUI_Load);
            this.topMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label numberOfBombsLabel;
        private System.Windows.Forms.Label watch;
        private System.Windows.Forms.TableLayoutPanel topMenu;
        private System.Windows.Forms.Panel boardPanel;
        private System.Windows.Forms.Label resetButton;
    }
}