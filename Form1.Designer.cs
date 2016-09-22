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
            this.commentsButton = new System.Windows.Forms.Button();
            this.assignmentIdBox = new System.Windows.Forms.TextBox();
            this.commentsDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.commentsSaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
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
            this.cs1400FileButton.Location = new System.Drawing.Point(6, 20);
            this.cs1400FileButton.Name = "cs1400FileButton";
            this.cs1400FileButton.Size = new System.Drawing.Size(110, 23);
            this.cs1400FileButton.TabIndex = 0;
            this.cs1400FileButton.Text = "CS 1400 File";
            this.cs1400FileButton.UseVisualStyleBackColor = true;
            this.cs1400FileButton.Click += new System.EventHandler(this.cs1400FileButton_Click);
            // 
            // cs1405FileButton
            // 
            this.cs1405FileButton.Location = new System.Drawing.Point(6, 53);
            this.cs1405FileButton.Name = "cs1405FileButton";
            this.cs1405FileButton.Size = new System.Drawing.Size(110, 23);
            this.cs1405FileButton.TabIndex = 1;
            this.cs1405FileButton.Text = "CS1405 File";
            this.cs1405FileButton.UseVisualStyleBackColor = true;
            this.cs1405FileButton.Click += new System.EventHandler(this.cs1405FileButton_Click);
            // 
            // helpButton
            // 
            this.helpButton.Location = new System.Drawing.Point(12, 100);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(75, 23);
            this.helpButton.TabIndex = 2;
            this.helpButton.Text = "Help";
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // commentsButton
            // 
            this.commentsButton.Location = new System.Drawing.Point(10, 53);
            this.commentsButton.Name = "commentsButton";
            this.commentsButton.Size = new System.Drawing.Size(149, 23);
            this.commentsButton.TabIndex = 3;
            this.commentsButton.Text = "Get comments";
            this.commentsButton.UseVisualStyleBackColor = true;
            this.commentsButton.Click += new System.EventHandler(this.commentsButton_Click);
            // 
            // assignmentIdBox
            // 
            this.assignmentIdBox.Location = new System.Drawing.Point(70, 19);
            this.assignmentIdBox.Name = "assignmentIdBox";
            this.assignmentIdBox.Size = new System.Drawing.Size(89, 20);
            this.assignmentIdBox.TabIndex = 4;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.assignmentIdBox);
            this.groupBox1.Controls.Add(this.commentsButton);
            this.groupBox1.Location = new System.Drawing.Point(140, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(165, 82);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Comments";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "AssmntId";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cs1400FileButton);
            this.groupBox2.Controls.Add(this.cs1405FileButton);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(122, 82);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Grade sheet merger";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(318, 131);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.helpButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog cs1400FileDialog;
        private System.Windows.Forms.OpenFileDialog cs1405FileDialog;
        private System.Windows.Forms.Button cs1400FileButton;
        private System.Windows.Forms.Button cs1405FileButton;
        private System.Windows.Forms.SaveFileDialog resultSaveDialog;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.Button commentsButton;
        private System.Windows.Forms.TextBox assignmentIdBox;
        private System.Windows.Forms.OpenFileDialog commentsDialog;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.SaveFileDialog commentsSaveDialog;
    }
}

