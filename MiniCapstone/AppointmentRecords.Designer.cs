namespace MiniCapstone
{
    partial class AppointmentRecords
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label1 = new Label();
            Exportbtn = new Guna.UI2.WinForms.Guna2GradientButton();
            guna2DataGridView1 = new Guna.UI2.WinForms.Guna2DataGridView();
            dateTimePicker1 = new DateTimePicker();
            guna2GradientButton1 = new Guna.UI2.WinForms.Guna2GradientButton();
            ((System.ComponentModel.ISupportInitialize)guna2DataGridView1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Broadway", 72F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = SystemColors.ControlLightLight;
            label1.Location = new Point(473, 111);
            label1.Name = "label1";
            label1.Size = new Size(1277, 109);
            label1.TabIndex = 6;
            label1.Text = " Appointments Records";
            // 
            // Exportbtn
            // 
            Exportbtn.CustomizableEdges = customizableEdges1;
            Exportbtn.DisabledState.BorderColor = Color.DarkGray;
            Exportbtn.DisabledState.CustomBorderColor = Color.DarkGray;
            Exportbtn.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            Exportbtn.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            Exportbtn.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            Exportbtn.FillColor = Color.FromArgb(37, 37, 37);
            Exportbtn.FillColor2 = Color.FromArgb(31, 31, 31);
            Exportbtn.Font = new Font("Bookman Old Style", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Exportbtn.ForeColor = Color.White;
            Exportbtn.Location = new Point(1639, 935);
            Exportbtn.Name = "Exportbtn";
            Exportbtn.ShadowDecoration.CustomizableEdges = customizableEdges2;
            Exportbtn.Size = new Size(244, 81);
            Exportbtn.TabIndex = 8;
            Exportbtn.Text = "Export PDF";
            Exportbtn.Click += Exportbtn_Click;
            // 
            // guna2DataGridView1
            // 
            guna2DataGridView1.AllowUserToResizeColumns = false;
            guna2DataGridView1.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(44, 48, 52);
            guna2DataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            guna2DataGridView1.BackgroundColor = Color.FromArgb(31, 31, 31);
            guna2DataGridView1.BorderStyle = BorderStyle.FixedSingle;
            guna2DataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Raised;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(15, 16, 18);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            guna2DataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            guna2DataGridView1.ColumnHeadersHeight = 30;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.FromArgb(33, 37, 41);
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 9F);
            dataGridViewCellStyle3.ForeColor = Color.White;
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(114, 117, 119);
            dataGridViewCellStyle3.SelectionForeColor = Color.White;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            guna2DataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            guna2DataGridView1.GridColor = Color.FromArgb(50, 56, 62);
            guna2DataGridView1.Location = new Point(330, 328);
            guna2DataGridView1.Name = "guna2DataGridView1";
            guna2DataGridView1.ReadOnly = true;
            guna2DataGridView1.RowHeadersVisible = false;
            dataGridViewCellStyle4.Font = new Font("Bookman Old Style", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            guna2DataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle4;
            guna2DataGridView1.Size = new Size(1553, 590);
            guna2DataGridView1.TabIndex = 7;
            guna2DataGridView1.Theme = Guna.UI2.WinForms.Enums.DataGridViewPresetThemes.Dark;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.BackColor = Color.FromArgb(44, 48, 52);
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.Font = null;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            guna2DataGridView1.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            guna2DataGridView1.ThemeStyle.BackColor = Color.FromArgb(31, 31, 31);
            guna2DataGridView1.ThemeStyle.GridColor = Color.FromArgb(50, 56, 62);
            guna2DataGridView1.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(15, 16, 18);
            guna2DataGridView1.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.Raised;
            guna2DataGridView1.ThemeStyle.HeaderStyle.Font = new Font("Segoe UI", 9F);
            guna2DataGridView1.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            guna2DataGridView1.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            guna2DataGridView1.ThemeStyle.HeaderStyle.Height = 30;
            guna2DataGridView1.ThemeStyle.ReadOnly = true;
            guna2DataGridView1.ThemeStyle.RowsStyle.BackColor = Color.FromArgb(33, 37, 41);
            guna2DataGridView1.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            guna2DataGridView1.ThemeStyle.RowsStyle.Font = new Font("Segoe UI", 9F);
            guna2DataGridView1.ThemeStyle.RowsStyle.ForeColor = Color.White;
            guna2DataGridView1.ThemeStyle.RowsStyle.Height = 25;
            guna2DataGridView1.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(114, 117, 119);
            guna2DataGridView1.ThemeStyle.RowsStyle.SelectionForeColor = Color.White;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CalendarMonthBackground = Color.Black;
            dateTimePicker1.CalendarTitleBackColor = SystemColors.ActiveCaptionText;
            dateTimePicker1.CalendarTrailingForeColor = SystemColors.ControlText;
            dateTimePicker1.Font = new Font("Bookman Old Style", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dateTimePicker1.Location = new Point(330, 284);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(382, 32);
            dateTimePicker1.TabIndex = 9;
            dateTimePicker1.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // guna2GradientButton1
            // 
            guna2GradientButton1.CustomizableEdges = customizableEdges3;
            guna2GradientButton1.DisabledState.BorderColor = Color.DarkGray;
            guna2GradientButton1.DisabledState.CustomBorderColor = Color.DarkGray;
            guna2GradientButton1.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            guna2GradientButton1.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            guna2GradientButton1.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            guna2GradientButton1.FillColor = Color.FromArgb(37, 37, 37);
            guna2GradientButton1.FillColor2 = Color.FromArgb(31, 31, 31);
            guna2GradientButton1.Font = new Font("Bookman Old Style", 20.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            guna2GradientButton1.ForeColor = Color.White;
            guna2GradientButton1.Location = new Point(1295, 935);
            guna2GradientButton1.Name = "guna2GradientButton1";
            guna2GradientButton1.ShadowDecoration.CustomizableEdges = customizableEdges4;
            guna2GradientButton1.Size = new Size(244, 81);
            guna2GradientButton1.TabIndex = 10;
            guna2GradientButton1.Text = "Clear";
            guna2GradientButton1.Click += guna2GradientButton1_Click;
            // 
            // AppointmentRecords
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1940, 1100);
            Controls.Add(guna2GradientButton1);
            Controls.Add(dateTimePicker1);
            Controls.Add(Exportbtn);
            Controls.Add(guna2DataGridView1);
            Controls.Add(label1);
            Name = "AppointmentRecords";
            Text = "History";
            Controls.SetChildIndex(label1, 0);
            Controls.SetChildIndex(guna2DataGridView1, 0);
            Controls.SetChildIndex(Exportbtn, 0);
            Controls.SetChildIndex(dateTimePicker1, 0);
            Controls.SetChildIndex(guna2GradientButton1, 0);
            ((System.ComponentModel.ISupportInitialize)guna2DataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Guna.UI2.WinForms.Guna2GradientButton Exportbtn;
        private Guna.UI2.WinForms.Guna2DataGridView guna2DataGridView1;
        private DateTimePicker dateTimePicker1;
        private Guna.UI2.WinForms.Guna2GradientButton guna2GradientButton1;
    }
}