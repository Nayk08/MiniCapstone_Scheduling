namespace MiniCapstone
{
    partial class Scheduler
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Scheduler));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            daycontainer = new FlowLayoutPanel();
            Nextbtn = new Guna.UI2.WinForms.Guna2GradientButton();
            Previousbtn = new Guna.UI2.WinForms.Guna2GradientButton();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            Monthyearlbl = new Label();
            SuspendLayout();
            // 
            // daycontainer
            // 
            daycontainer.BorderStyle = BorderStyle.FixedSingle;
            daycontainer.Location = new Point(469, 284);
            daycontainer.Name = "daycontainer";
            daycontainer.Size = new Size(1116, 677);
            daycontainer.TabIndex = 2;
            // 
            // Nextbtn
            // 
            Nextbtn.BackgroundImageLayout = ImageLayout.Stretch;
            Nextbtn.CustomizableEdges = customizableEdges1;
            Nextbtn.DisabledState.BorderColor = Color.DarkGray;
            Nextbtn.DisabledState.CustomBorderColor = Color.DarkGray;
            Nextbtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            Nextbtn.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            Nextbtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            Nextbtn.FillColor = Color.Transparent;
            Nextbtn.FillColor2 = Color.Transparent;
            Nextbtn.Font = new Font("Segoe UI", 9F);
            Nextbtn.ForeColor = Color.White;
            Nextbtn.Image = (Image)resources.GetObject("Nextbtn.Image");
            Nextbtn.ImageSize = new Size(50, 50);
            Nextbtn.Location = new Point(1348, 147);
            Nextbtn.Name = "Nextbtn";
            Nextbtn.ShadowDecoration.CustomizableEdges = customizableEdges2;
            Nextbtn.Size = new Size(105, 69);
            Nextbtn.TabIndex = 3;
            Nextbtn.Click += Nextbtn_Click;
            // 
            // Previousbtn
            // 
            Previousbtn.BackColor = Color.Transparent;
            Previousbtn.CustomizableEdges = customizableEdges3;
            Previousbtn.DisabledState.BorderColor = Color.DarkGray;
            Previousbtn.DisabledState.CustomBorderColor = Color.DarkGray;
            Previousbtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            Previousbtn.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            Previousbtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            Previousbtn.FillColor = Color.Transparent;
            Previousbtn.FillColor2 = Color.Transparent;
            Previousbtn.Font = new Font("Segoe UI", 9F);
            Previousbtn.ForeColor = Color.Transparent;
            Previousbtn.Image = (Image)resources.GetObject("Previousbtn.Image");
            Previousbtn.ImageSize = new Size(50, 50);
            Previousbtn.Location = new Point(1237, 147);
            Previousbtn.Name = "Previousbtn";
            Previousbtn.ShadowDecoration.CustomizableEdges = customizableEdges4;
            Previousbtn.Size = new Size(105, 69);
            Previousbtn.TabIndex = 4;
            Previousbtn.TextAlign = HorizontalAlignment.Left;
            Previousbtn.Click += Previousbtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bookman Old Style", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(497, 236);
            label1.Name = "label1";
            label1.Size = new Size(102, 27);
            label1.TabIndex = 5;
            label1.Text = "Sunday";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Bookman Old Style", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = SystemColors.ControlLightLight;
            label2.Location = new Point(661, 236);
            label2.Name = "label2";
            label2.Size = new Size(105, 27);
            label2.TabIndex = 6;
            label2.Text = "Monday";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Bookman Old Style", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = SystemColors.ControlLightLight;
            label3.Location = new Point(949, 236);
            label3.Name = "label3";
            label3.Size = new Size(146, 27);
            label3.TabIndex = 8;
            label3.Text = "Wednesday";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Bookman Old Style", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = SystemColors.ControlLightLight;
            label4.Location = new Point(808, 236);
            label4.Name = "label4";
            label4.Size = new Size(109, 27);
            label4.TabIndex = 7;
            label4.Text = "Tuesday";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Bookman Old Style", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = SystemColors.ControlLightLight;
            label5.Location = new Point(1459, 236);
            label5.Name = "label5";
            label5.Size = new Size(120, 27);
            label5.TabIndex = 11;
            label5.Text = "Saturday";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Bookman Old Style", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = SystemColors.ControlLightLight;
            label6.Location = new Point(1304, 236);
            label6.Name = "label6";
            label6.Size = new Size(87, 27);
            label6.TabIndex = 10;
            label6.Text = "Friday";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Bookman Old Style", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.ControlLightLight;
            label7.Location = new Point(1124, 236);
            label7.Name = "label7";
            label7.Size = new Size(123, 27);
            label7.TabIndex = 9;
            label7.Text = "Thursday";
            // 
            // Monthyearlbl
            // 
            Monthyearlbl.BackColor = Color.Transparent;
            Monthyearlbl.Font = new Font("Bookman Old Style", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Monthyearlbl.ForeColor = SystemColors.ControlLightLight;
            Monthyearlbl.ImageAlign = ContentAlignment.MiddleLeft;
            Monthyearlbl.Location = new Point(497, 132);
            Monthyearlbl.Name = "Monthyearlbl";
            Monthyearlbl.Size = new Size(721, 84);
            Monthyearlbl.TabIndex = 12;
            Monthyearlbl.Text = "Month Year";
            Monthyearlbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // Scheduler
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1924, 1061);
            Controls.Add(Monthyearlbl);
            Controls.Add(label5);
            Controls.Add(label6);
            Controls.Add(label7);
            Controls.Add(label3);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(Previousbtn);
            Controls.Add(Nextbtn);
            Controls.Add(daycontainer);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Scheduler";
            Text = "Scheduler";
            WindowState = FormWindowState.Maximized;
            Load += Scheduler_Load;
            Controls.SetChildIndex(daycontainer, 0);
            Controls.SetChildIndex(Nextbtn, 0);
            Controls.SetChildIndex(Previousbtn, 0);
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(label2, 0);
            Controls.SetChildIndex(label4, 0);
            Controls.SetChildIndex(label3, 0);
            Controls.SetChildIndex(label7, 0);
            Controls.SetChildIndex(label6, 0);
            Controls.SetChildIndex(label5, 0);
            Controls.SetChildIndex(Monthyearlbl, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel daycontainer;
        private Guna.UI2.WinForms.Guna2GradientButton Nextbtn;
        private Guna.UI2.WinForms.Guna2GradientButton Previousbtn;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private Label Monthyearlbl;
    }
}