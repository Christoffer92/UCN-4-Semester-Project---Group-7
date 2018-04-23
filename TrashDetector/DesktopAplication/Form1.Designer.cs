namespace DesktopAplication
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
            this.lblTitel = new System.Windows.Forms.Label();
            this.btnTrain = new System.Windows.Forms.Button();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnView = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblTitel
            // 
            this.lblTitel.AutoSize = true;
            this.lblTitel.Font = new System.Drawing.Font("Microsoft Sans Serif", 28.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitel.Location = new System.Drawing.Point(334, 21);
            this.lblTitel.Name = "lblTitel";
            this.lblTitel.Size = new System.Drawing.Size(342, 55);
            this.lblTitel.TabIndex = 0;
            this.lblTitel.Text = "Trash Detector";
            this.lblTitel.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnTrain
            // 
            this.btnTrain.Enabled = false;
            this.btnTrain.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTrain.Location = new System.Drawing.Point(379, 159);
            this.btnTrain.Name = "btnTrain";
            this.btnTrain.Size = new System.Drawing.Size(260, 61);
            this.btnTrain.TabIndex = 1;
            this.btnTrain.Text = "Train";
            this.btnTrain.UseVisualStyleBackColor = true;
            // 
            // btnTest
            // 
            this.btnTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTest.Location = new System.Drawing.Point(379, 266);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(260, 61);
            this.btnTest.TabIndex = 2;
            this.btnTest.Text = "Test";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnView
            // 
            this.btnView.Enabled = false;
            this.btnView.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnView.Location = new System.Drawing.Point(379, 389);
            this.btnView.Name = "btnView";
            this.btnView.Size = new System.Drawing.Size(260, 61);
            this.btnView.TabIndex = 3;
            this.btnView.Text = "View";
            this.btnView.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 629);
            this.Controls.Add(this.btnView);
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.btnTrain);
            this.Controls.Add(this.lblTitel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitel;
        private System.Windows.Forms.Button btnTrain;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Button btnView;
    }
}

