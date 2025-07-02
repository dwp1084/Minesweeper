
namespace Minesweeper_Clone {
    partial class Menus {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.difficultyOptions = new System.Windows.Forms.Panel();
            this.customOption = new System.Windows.Forms.RadioButton();
            this.expertOption = new System.Windows.Forms.RadioButton();
            this.intermediateOption = new System.Windows.Forms.RadioButton();
            this.beginnerOption = new System.Windows.Forms.RadioButton();
            this.playButton = new System.Windows.Forms.Button();
            this.title = new System.Windows.Forms.Label();
            this.difficultyContainer = new System.Windows.Forms.Panel();
            this.customSizeMenu = new System.Windows.Forms.Panel();
            this.enterButton = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.bombsShow = new System.Windows.Forms.Label();
            this.bombs = new System.Windows.Forms.Label();
            this.bombsBar = new System.Windows.Forms.TrackBar();
            this.panel2 = new System.Windows.Forms.Panel();
            this.colShow = new System.Windows.Forms.Label();
            this.colLabel = new System.Windows.Forms.Label();
            this.colBar = new System.Windows.Forms.TrackBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rowShow = new System.Windows.Forms.Label();
            this.rowLabel = new System.Windows.Forms.Label();
            this.rowBar = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.difficultyOptions.SuspendLayout();
            this.difficultyContainer.SuspendLayout();
            this.customSizeMenu.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bombsBar)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colBar)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rowBar)).BeginInit();
            this.SuspendLayout();
            // 
            // difficultyOptions
            // 
            this.difficultyOptions.AutoSize = true;
            this.difficultyOptions.Controls.Add(this.customOption);
            this.difficultyOptions.Controls.Add(this.expertOption);
            this.difficultyOptions.Controls.Add(this.intermediateOption);
            this.difficultyOptions.Controls.Add(this.beginnerOption);
            this.difficultyOptions.Location = new System.Drawing.Point(14, 87);
            this.difficultyOptions.Name = "difficultyOptions";
            this.difficultyOptions.Size = new System.Drawing.Size(128, 162);
            this.difficultyOptions.TabIndex = 0;
            // 
            // customOption
            // 
            this.customOption.AutoSize = true;
            this.customOption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.customOption.Location = new System.Drawing.Point(3, 134);
            this.customOption.Name = "customOption";
            this.customOption.Size = new System.Drawing.Size(82, 25);
            this.customOption.TabIndex = 3;
            this.customOption.TabStop = true;
            this.customOption.Text = "Custom\r\n";
            this.customOption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.customOption.UseVisualStyleBackColor = true;
            this.customOption.CheckedChanged += new System.EventHandler(this.customOption_CheckedChanged);
            // 
            // expertOption
            // 
            this.expertOption.AutoSize = true;
            this.expertOption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.expertOption.Location = new System.Drawing.Point(3, 91);
            this.expertOption.Name = "expertOption";
            this.expertOption.Size = new System.Drawing.Size(71, 25);
            this.expertOption.TabIndex = 2;
            this.expertOption.TabStop = true;
            this.expertOption.Text = "Expert";
            this.expertOption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.expertOption.UseVisualStyleBackColor = true;
            this.expertOption.CheckedChanged += new System.EventHandler(this.expertOption_CheckedChanged);
            // 
            // intermediateOption
            // 
            this.intermediateOption.AutoSize = true;
            this.intermediateOption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.intermediateOption.Location = new System.Drawing.Point(3, 47);
            this.intermediateOption.Name = "intermediateOption";
            this.intermediateOption.Size = new System.Drawing.Size(116, 25);
            this.intermediateOption.TabIndex = 1;
            this.intermediateOption.TabStop = true;
            this.intermediateOption.Text = "Intermediate\r\n";
            this.intermediateOption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.intermediateOption.UseVisualStyleBackColor = true;
            this.intermediateOption.CheckedChanged += new System.EventHandler(this.intermediateOption_CheckedChanged);
            // 
            // beginnerOption
            // 
            this.beginnerOption.AutoSize = true;
            this.beginnerOption.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.beginnerOption.Location = new System.Drawing.Point(3, 3);
            this.beginnerOption.Name = "beginnerOption";
            this.beginnerOption.Size = new System.Drawing.Size(90, 25);
            this.beginnerOption.TabIndex = 0;
            this.beginnerOption.TabStop = true;
            this.beginnerOption.Text = "Beginner";
            this.beginnerOption.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.beginnerOption.UseVisualStyleBackColor = true;
            this.beginnerOption.CheckedChanged += new System.EventHandler(this.beginnerOption_CheckedChanged);
            // 
            // playButton
            // 
            this.playButton.AutoSize = true;
            this.playButton.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.playButton.Location = new System.Drawing.Point(178, 87);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(294, 162);
            this.playButton.TabIndex = 1;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.playButton_Click);
            // 
            // title
            // 
            this.title.AutoSize = true;
            this.title.Font = new System.Drawing.Font("Papyrus", 27.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.title.Location = new System.Drawing.Point(116, 9);
            this.title.Name = "title";
            this.title.Size = new System.Drawing.Size(243, 58);
            this.title.TabIndex = 2;
            this.title.Text = "Minesweeper";
            // 
            // difficultyContainer
            // 
            this.difficultyContainer.AutoSize = true;
            this.difficultyContainer.Controls.Add(this.title);
            this.difficultyContainer.Controls.Add(this.difficultyOptions);
            this.difficultyContainer.Controls.Add(this.playButton);
            this.difficultyContainer.Location = new System.Drawing.Point(472, 253);
            this.difficultyContainer.Name = "difficultyContainer";
            this.difficultyContainer.Size = new System.Drawing.Size(475, 252);
            this.difficultyContainer.TabIndex = 3;
            this.difficultyContainer.Visible = false;
            // 
            // customSizeMenu
            // 
            this.customSizeMenu.Controls.Add(this.enterButton);
            this.customSizeMenu.Controls.Add(this.panel3);
            this.customSizeMenu.Controls.Add(this.panel2);
            this.customSizeMenu.Controls.Add(this.panel1);
            this.customSizeMenu.Controls.Add(this.label1);
            this.customSizeMenu.Location = new System.Drawing.Point(0, 1);
            this.customSizeMenu.Name = "customSizeMenu";
            this.customSizeMenu.Size = new System.Drawing.Size(484, 260);
            this.customSizeMenu.TabIndex = 4;
            this.customSizeMenu.Visible = false;
            // 
            // enterButton
            // 
            this.enterButton.Location = new System.Drawing.Point(12, 230);
            this.enterButton.Name = "enterButton";
            this.enterButton.Size = new System.Drawing.Size(460, 23);
            this.enterButton.TabIndex = 4;
            this.enterButton.Text = "Continue";
            this.enterButton.UseVisualStyleBackColor = true;
            this.enterButton.Click += new System.EventHandler(this.enterButton_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.bombsShow);
            this.panel3.Controls.Add(this.bombs);
            this.panel3.Controls.Add(this.bombsBar);
            this.panel3.Location = new System.Drawing.Point(12, 171);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(460, 52);
            this.panel3.TabIndex = 3;
            // 
            // bombsShow
            // 
            this.bombsShow.AutoSize = true;
            this.bombsShow.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bombsShow.Location = new System.Drawing.Point(420, 3);
            this.bombsShow.Name = "bombsShow";
            this.bombsShow.Size = new System.Drawing.Size(37, 21);
            this.bombsShow.TabIndex = 2;
            this.bombsShow.Text = "000";
            // 
            // bombs
            // 
            this.bombs.AutoSize = true;
            this.bombs.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.bombs.Location = new System.Drawing.Point(4, 4);
            this.bombs.Name = "bombs";
            this.bombs.Size = new System.Drawing.Size(58, 21);
            this.bombs.TabIndex = 1;
            this.bombs.Text = "Bombs";
            // 
            // bombsBar
            // 
            this.bombsBar.Location = new System.Drawing.Point(69, 3);
            this.bombsBar.Name = "bombsBar";
            this.bombsBar.Size = new System.Drawing.Size(348, 45);
            this.bombsBar.TabIndex = 0;
            this.bombsBar.Scroll += new System.EventHandler(this.bombsBar_Scroll);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.colShow);
            this.panel2.Controls.Add(this.colLabel);
            this.panel2.Controls.Add(this.colBar);
            this.panel2.Location = new System.Drawing.Point(13, 117);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(459, 52);
            this.panel2.TabIndex = 2;
            // 
            // colShow
            // 
            this.colShow.AutoSize = true;
            this.colShow.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.colShow.Location = new System.Drawing.Point(419, 3);
            this.colShow.Name = "colShow";
            this.colShow.Size = new System.Drawing.Size(37, 21);
            this.colShow.TabIndex = 2;
            this.colShow.Text = "000";
            // 
            // colLabel
            // 
            this.colLabel.AutoSize = true;
            this.colLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.colLabel.Location = new System.Drawing.Point(4, 3);
            this.colLabel.Name = "colLabel";
            this.colLabel.Size = new System.Drawing.Size(72, 21);
            this.colLabel.TabIndex = 1;
            this.colLabel.Text = "Columns";
            // 
            // colBar
            // 
            this.colBar.Location = new System.Drawing.Point(69, 3);
            this.colBar.Name = "colBar";
            this.colBar.Size = new System.Drawing.Size(344, 45);
            this.colBar.TabIndex = 0;
            this.colBar.Scroll += new System.EventHandler(this.colBar_Scroll);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rowShow);
            this.panel1.Controls.Add(this.rowLabel);
            this.panel1.Controls.Add(this.rowBar);
            this.panel1.Location = new System.Drawing.Point(13, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(459, 52);
            this.panel1.TabIndex = 1;
            // 
            // rowShow
            // 
            this.rowShow.AutoSize = true;
            this.rowShow.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rowShow.Location = new System.Drawing.Point(419, 3);
            this.rowShow.Name = "rowShow";
            this.rowShow.Size = new System.Drawing.Size(37, 21);
            this.rowShow.TabIndex = 2;
            this.rowShow.Text = "000";
            // 
            // rowLabel
            // 
            this.rowLabel.AutoSize = true;
            this.rowLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rowLabel.Location = new System.Drawing.Point(4, 4);
            this.rowLabel.Name = "rowLabel";
            this.rowLabel.Size = new System.Drawing.Size(48, 21);
            this.rowLabel.TabIndex = 1;
            this.rowLabel.Text = "Rows";
            // 
            // rowBar
            // 
            this.rowBar.Location = new System.Drawing.Point(69, 3);
            this.rowBar.Name = "rowBar";
            this.rowBar.Size = new System.Drawing.Size(344, 45);
            this.rowBar.TabIndex = 0;
            this.rowBar.Scroll += new System.EventHandler(this.rowBar_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Papyrus", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(320, 51);
            this.label1.TabIndex = 0;
            this.label1.Text = "Custom Game Menu";
            // 
            // Menus
            // 
            this.AcceptButton = this.playButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.Controls.Add(this.customSizeMenu);
            this.Controls.Add(this.difficultyContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Menus";
            this.Text = "Minesweeper";
            this.Load += new System.EventHandler(this.Menus_Load);
            this.difficultyOptions.ResumeLayout(false);
            this.difficultyOptions.PerformLayout();
            this.difficultyContainer.ResumeLayout(false);
            this.difficultyContainer.PerformLayout();
            this.customSizeMenu.ResumeLayout(false);
            this.customSizeMenu.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bombsBar)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colBar)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rowBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel difficultyOptions;
        private System.Windows.Forms.RadioButton beginnerOption;
        private System.Windows.Forms.RadioButton expertOption;
        private System.Windows.Forms.RadioButton intermediateOption;
        private System.Windows.Forms.RadioButton customOption;
        private System.Windows.Forms.Button playButton;
        private System.Windows.Forms.Label title;
        private System.Windows.Forms.Panel difficultyContainer;
        private System.Windows.Forms.Panel customSizeMenu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label bombsShow;
        private System.Windows.Forms.Label bombs;
        private System.Windows.Forms.TrackBar bombsBar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label colShow;
        private System.Windows.Forms.Label colLabel;
        private System.Windows.Forms.TrackBar colBar;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label rowShow;
        private System.Windows.Forms.Label rowLabel;
        private System.Windows.Forms.TrackBar rowBar;
        private System.Windows.Forms.Button enterButton;
    }
}

