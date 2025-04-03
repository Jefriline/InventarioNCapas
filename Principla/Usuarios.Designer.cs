namespace Principal
{
    partial class Usuarios
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
            tableLayoutPanel1 = new TableLayoutPanel();
            panel1 = new Panel();
            btnAgregarUsuario = new RJButton();
            label1 = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            tableLayoutPanel1.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(panel1, 0, 0);
            tableLayoutPanel1.Controls.Add(flowLayoutPanel1, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(800, 600);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(btnAgregarUsuario);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(800, 100);
            panel1.TabIndex = 0;
            // 
            // btnAgregarUsuario
            // 
            btnAgregarUsuario.Anchor = AnchorStyles.Right;
            btnAgregarUsuario.BackColor = Color.Black;
            btnAgregarUsuario.BackgroundColor = Color.Black;
            btnAgregarUsuario.BorderColor = Color.Black;
            btnAgregarUsuario.BorderRadius = 5;
            btnAgregarUsuario.BorderSize = 0;
            btnAgregarUsuario.FlatAppearance.BorderSize = 0;
            btnAgregarUsuario.FlatStyle = FlatStyle.Flat;
            btnAgregarUsuario.Font = new Font("Bahnschrift", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregarUsuario.ForeColor = Color.White;
            btnAgregarUsuario.Location = new Point(620, 30);
            btnAgregarUsuario.Name = "btnAgregarUsuario";
            btnAgregarUsuario.Size = new Size(150, 40);
            btnAgregarUsuario.TabIndex = 1;
            btnAgregarUsuario.Text = "Agregar Usuario";
            btnAgregarUsuario.TextColor = Color.White;
            btnAgregarUsuario.UseVisualStyleBackColor = false;
            btnAgregarUsuario.Click += btnAgregarUsuario_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(30, 30);
            label1.Name = "label1";
            label1.Size = new Size(250, 34);
            label1.TabIndex = 0;
            label1.Text = "Gestión de Usuarios";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.BackColor = Color.WhiteSmoke;
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 100);
            flowLayoutPanel1.Margin = new Padding(0);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Padding = new Padding(20);
            flowLayoutPanel1.Size = new Size(800, 500);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // Usuarios
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 600);
            Controls.Add(tableLayoutPanel1);
            Name = "Usuarios";
            Text = "Gestión de Usuarios";
            tableLayoutPanel1.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Panel panel1;
        private Label label1;
        private RJButton btnAgregarUsuario;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}