namespace SwarmUI
{
    partial class Swarm
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
            this.titleCOM = new System.Windows.Forms.Label();
            this.COMPortSel1 = new System.Windows.Forms.ComboBox();
            this.connect1 = new System.Windows.Forms.Button();
            this.connect2 = new System.Windows.Forms.Button();
            this.COMPortSel2 = new System.Windows.Forms.ComboBox();
            this.fileName = new System.Windows.Forms.TextBox();
            this.browse = new System.Windows.Forms.Button();
            this.titlePython = new System.Windows.Forms.Label();
            this.run = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // titleCOM
            // 
            this.titleCOM.AutoSize = true;
            this.titleCOM.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.titleCOM.Location = new System.Drawing.Point(35, 26);
            this.titleCOM.Name = "titleCOM";
            this.titleCOM.Size = new System.Drawing.Size(187, 25);
            this.titleCOM.TabIndex = 0;
            this.titleCOM.Text = "Select COM Port";
            // 
            // COMPortSel1
            // 
            this.COMPortSel1.FormattingEnabled = true;
            this.COMPortSel1.Location = new System.Drawing.Point(40, 54);
            this.COMPortSel1.Name = "COMPortSel1";
            this.COMPortSel1.Size = new System.Drawing.Size(121, 28);
            this.COMPortSel1.TabIndex = 1;
            this.COMPortSel1.SelectedIndexChanged += new System.EventHandler(this.COMPortSel1_IndexChanged);
            // 
            // connect1
            // 
            this.connect1.Location = new System.Drawing.Point(181, 54);
            this.connect1.Name = "connect1";
            this.connect1.Size = new System.Drawing.Size(80, 28);
            this.connect1.TabIndex = 2;
            this.connect1.Text = "Connect";
            this.connect1.UseVisualStyleBackColor = true;
            this.connect1.Click += new System.EventHandler(this.Connect_Click);
            // 
            // connect2
            // 
            this.connect2.Location = new System.Drawing.Point(181, 88);
            this.connect2.Name = "connect2";
            this.connect2.Size = new System.Drawing.Size(80, 28);
            this.connect2.TabIndex = 2;
            this.connect2.Text = "Connect";
            this.connect2.UseVisualStyleBackColor = true;
            this.connect2.Click += new System.EventHandler(this.Connect_Click);
            // 
            // COMPortSel2
            // 
            this.COMPortSel2.FormattingEnabled = true;
            this.COMPortSel2.Location = new System.Drawing.Point(40, 88);
            this.COMPortSel2.Name = "COMPortSel2";
            this.COMPortSel2.Size = new System.Drawing.Size(121, 28);
            this.COMPortSel2.TabIndex = 1;
            this.COMPortSel2.SelectedIndexChanged += new System.EventHandler(this.COMPortSel2_IndexChanged);
            // 
            // fileName
            // 
            this.fileName.Location = new System.Drawing.Point(40, 175);
            this.fileName.Name = "fileName";
            this.fileName.Size = new System.Drawing.Size(357, 26);
            this.fileName.TabIndex = 3;
            // 
            // browse
            // 
            this.browse.Location = new System.Drawing.Point(403, 173);
            this.browse.Name = "browse";
            this.browse.Size = new System.Drawing.Size(80, 28);
            this.browse.TabIndex = 4;
            this.browse.Text = "Browse";
            this.browse.UseVisualStyleBackColor = true;
            this.browse.Click += new System.EventHandler(this.Browse_Click);
            // 
            // titlePython
            // 
            this.titlePython.AutoSize = true;
            this.titlePython.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.titlePython.Location = new System.Drawing.Point(35, 147);
            this.titlePython.Name = "titlePython";
            this.titlePython.Size = new System.Drawing.Size(204, 25);
            this.titlePython.TabIndex = 0;
            this.titlePython.Text = "Select Python File";
            // 
            // run
            // 
            this.run.Location = new System.Drawing.Point(40, 226);
            this.run.Name = "run";
            this.run.Size = new System.Drawing.Size(121, 46);
            this.run.TabIndex = 2;
            this.run.Text = "Run";
            this.run.UseVisualStyleBackColor = true;
            this.run.Click += new System.EventHandler(this.Run_Click);
            // 
            // Swarm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 530);
            this.Controls.Add(this.browse);
            this.Controls.Add(this.fileName);
            this.Controls.Add(this.run);
            this.Controls.Add(this.connect2);
            this.Controls.Add(this.connect1);
            this.Controls.Add(this.COMPortSel2);
            this.Controls.Add(this.COMPortSel1);
            this.Controls.Add(this.titlePython);
            this.Controls.Add(this.titleCOM);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Swarm";
            this.Text = "Swarm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label titleCOM;
        private System.Windows.Forms.ComboBox COMPortSel1;
        private System.Windows.Forms.Button connect1;
        private System.Windows.Forms.Button connect2;
        private System.Windows.Forms.ComboBox COMPortSel2;
        private System.Windows.Forms.TextBox fileName;
        private System.Windows.Forms.Button browse;
        private System.Windows.Forms.Label titlePython;
        private System.Windows.Forms.Button run;
    }
}

