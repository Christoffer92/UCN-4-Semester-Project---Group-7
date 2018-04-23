namespace DesktopAplication
{
    partial class TestForm
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
            this.btnTestFolder = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTestFolder
            // 
            this.btnTestFolder.Location = new System.Drawing.Point(276, 126);
            this.btnTestFolder.Name = "btnTestFolder";
            this.btnTestFolder.Size = new System.Drawing.Size(272, 58);
            this.btnTestFolder.TabIndex = 0;
            this.btnTestFolder.Text = "Test image from folder";
            this.btnTestFolder.UseVisualStyleBackColor = true;
            this.btnTestFolder.Click += new System.EventHandler(this.button1_Click);
            // 
            // TestForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnTestFolder);
            this.Name = "TestForm";
            this.Text = "Test";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTestFolder;
    }
}