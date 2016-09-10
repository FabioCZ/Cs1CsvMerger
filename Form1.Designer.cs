namespace GradeSheetMerger
{
    partial class Form1
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
            this.cs1400FileDialog = new System.Windows.Forms.OpenFileDialog();
            this.cs1405FileDialog = new System.Windows.Forms.OpenFileDialog();
            this.cs1400FileButton = new System.Windows.Forms.Button();
            this.cs1405FileButton = new System.Windows.Forms.Button();
            this.resultSaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.helpButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // cs1400FileDialog
            // 
            this.cs1400FileDialog.DefaultExt = "csv";
            // 
            // cs1405FileDialog
            // 
            this.cs1405FileDialog.DefaultExt = "csv";
            // 
            // cs1400FileButton
            // 
            this.cs1400FileButton.Location = new System.Drawing.Point(13, 13);
            this.cs1400FileButton.Name = "cs1400FileButton";
            this.cs1400FileButton.Size = new System.Drawing.Size(75, 23);
            this.cs1400FileButton.TabIndex = 0;
            this.cs1400FileButton.Text = "CS 1400 File";
            this.cs1400FileButton.UseVisualStyleBackColor = true;
            this.cs1400FileButton.Click += new System.EventHandler(this.cs1400FileButton_Click);
            // 
            // cs1405FileButton
            // 
            this.cs1405FileButton.Location = new System.Drawing.Point(13, 43);
            this.cs1405FileButton.Name = "cs1405FileButton";
            this.cs1405FileButton.Size = new System.Drawing.Size(75, 23);
            this.cs1405FileButton.TabIndex = 1;
            this.cs1405FileButton.Text = "CS1405File";
            this.cs1405FileButton.UseVisualStyleBackColor = true;
            this.cs1405FileButton.Click += new System.EventHandler(this.cs1405FileButton_Click);
            // 
            // helpButton
            // 
            this.helpButton.Location = new System.Drawing.Point(13, 72);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(75, 23);
            this.helpButton.TabIndex = 2;
            this.helpButton.Text = "Help";
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(120, 105);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.cs1405FileButton);
            this.Controls.Add(this.cs1400FileButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog cs1400FileDialog;
        private System.Windows.Forms.OpenFileDialog cs1405FileDialog;
        private System.Windows.Forms.Button cs1400FileButton;
        private System.Windows.Forms.Button cs1405FileButton;
        private System.Windows.Forms.SaveFileDialog resultSaveDialog;
        private System.Windows.Forms.Button helpButton;
    }
}

