namespace MiniCapstone
{
    partial class UserControlDays
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            eventlbl = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Bookman Old Style", 18F);
            label1.Location = new Point(12, 15);
            label1.Name = "label1";
            label1.Size = new Size(83, 27);
            label1.TabIndex = 0;
            label1.Text = "label1";
            label1.DoubleClick += label1_DoubleClick;
         
            // 
            // eventlbl
            // 
            eventlbl.AutoSize = true;
            eventlbl.BackColor = Color.Transparent;
            eventlbl.Font = new Font("Bookman Old Style", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            eventlbl.Location = new Point(25, 52);
            eventlbl.Name = "eventlbl";
            eventlbl.Size = new Size(0, 20);
            eventlbl.TabIndex = 1;
            eventlbl.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // UserControlDays
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Silver;
            Controls.Add(eventlbl);
            Controls.Add(label1);
            Name = "UserControlDays";
            Size = new Size(153, 102);
            Load += UserControlDays_Load;
            Click += UserControlDays_Click;
        
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label eventlbl;
        private System.Windows.Forms.Timer timer1;
    }
}
