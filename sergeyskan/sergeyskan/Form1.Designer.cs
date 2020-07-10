namespace sergeyskan
{
    partial class form
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
            this.start = new System.Windows.Forms.Button();
            this.cancel = new System.Windows.Forms.Button();
            this.Headline = new System.Windows.Forms.Label();
            this.legend = new System.Windows.Forms.Label();
            this.status = new System.Windows.Forms.ProgressBar();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.string1 = new System.Windows.Forms.Label();
            this.string2 = new System.Windows.Forms.Label();
            this.string3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(16, 186);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 23);
            this.start.TabIndex = 0;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // cancel
            // 
            this.cancel.Location = new System.Drawing.Point(301, 186);
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(75, 23);
            this.cancel.TabIndex = 1;
            this.cancel.Text = "Cancel";
            this.cancel.UseVisualStyleBackColor = true;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // Headline
            // 
            this.Headline.AutoSize = true;
            this.Headline.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Headline.Location = new System.Drawing.Point(13, 13);
            this.Headline.Name = "Headline";
            this.Headline.Size = new System.Drawing.Size(120, 13);
            this.Headline.TabIndex = 2;
            this.Headline.Text = "TCP ports checkout";
            // 
            // legend
            // 
            this.legend.AutoSize = true;
            this.legend.Location = new System.Drawing.Point(13, 155);
            this.legend.Name = "legend";
            this.legend.Size = new System.Drawing.Size(43, 13);
            this.legend.TabIndex = 3;
            this.legend.Text = "Legend";
            // 
            // status
            // 
            this.status.Location = new System.Drawing.Point(111, 186);
            this.status.Name = "status";
            this.status.Size = new System.Drawing.Size(171, 23);
            this.status.TabIndex = 4;
            // 
            // backgroundWorker1
            // 
            this.backgroundWorker1.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker1_DoWork);
            this.backgroundWorker1.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker1_ProgressChanged);
            this.backgroundWorker1.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker1_RunWorkerCompleted);
            // 
            // string1
            // 
            this.string1.AutoSize = true;
            this.string1.Location = new System.Drawing.Point(13, 51);
            this.string1.Name = "string1";
            this.string1.Size = new System.Drawing.Size(345, 13);
            this.string1.TabIndex = 5;
            this.string1.Text = "The program for checking the availability of IP-addresses on TCP-ports. ";
            // 
            // string2
            // 
            this.string2.AutoSize = true;
            this.string2.Location = new System.Drawing.Point(13, 75);
            this.string2.Name = "string2";
            this.string2.Size = new System.Drawing.Size(362, 13);
            this.string2.TabIndex = 6;
            this.string2.Text = "Before starting the program, copy file \"sample.csv\" to the program directory.";
            // 
            // string3
            // 
            this.string3.AutoSize = true;
            this.string3.Location = new System.Drawing.Point(13, 99);
            this.string3.Name = "string3";
            this.string3.Size = new System.Drawing.Size(342, 13);
            this.string3.TabIndex = 7;
            this.string3.Text = "File \"sample.csv\" should contain a list of addresses and ports: \"IP;port\"";
            // 
            // form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 231);
            this.Controls.Add(this.string3);
            this.Controls.Add(this.string2);
            this.Controls.Add(this.string1);
            this.Controls.Add(this.status);
            this.Controls.Add(this.legend);
            this.Controls.Add(this.Headline);
            this.Controls.Add(this.cancel);
            this.Controls.Add(this.start);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(410, 270);
            this.MinimumSize = new System.Drawing.Size(410, 270);
            this.Name = "form";
            this.Text = "TCP checkout";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button cancel;
        private System.Windows.Forms.Label Headline;
        private System.Windows.Forms.Label legend;
        private System.Windows.Forms.ProgressBar status;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label string1;
        private System.Windows.Forms.Label string2;
        private System.Windows.Forms.Label string3;
    }
}

