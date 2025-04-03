namespace Principal
{
    partial class addUsuario
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
            rjButton1 = new RJButton();
            textBoxNombreCompleto = new TextBox();
            textBoxContrasena = new TextBox();
            comboBoxRol = new ComboBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            btnAgregarUsuario = new RJButton();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            label1 = new Label();
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            tableLayoutPanel2.SuspendLayout();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // rjButton1
            // 
            rjButton1.BackColor = Color.Transparent;
            rjButton1.BackgroundColor = Color.Transparent;
            rjButton1.BorderColor = Color.Transparent;
            rjButton1.BorderRadius = 10;
            rjButton1.BorderSize = 1;
            rjButton1.Dock = DockStyle.Fill;
            rjButton1.FlatAppearance.BorderSize = 0;
            rjButton1.FlatStyle = FlatStyle.Flat;
            rjButton1.Font = new Font("Microsoft Sans Serif", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            rjButton1.ForeColor = Color.Black;
            rjButton1.ImageAlign = ContentAlignment.TopCenter;
            rjButton1.Location = new Point(5, 0);
            rjButton1.Margin = new Padding(5, 0, 0, 0);
            rjButton1.Name = "rjButton1";
            rjButton1.Padding = new Padding(0, 0, 0, 5);
            rjButton1.Size = new Size(39, 49);
            rjButton1.TabIndex = 2;
            rjButton1.Text = "⍇";
            rjButton1.TextAlign = ContentAlignment.TopCenter;
            rjButton1.TextColor = Color.Black;
            rjButton1.UseVisualStyleBackColor = true;
            rjButton1.Click += btnCancelar_Click;
            // 
            // textBoxNombreCompleto
            // 
            textBoxNombreCompleto.Dock = DockStyle.Fill;
            textBoxNombreCompleto.ForeColor = Color.Gray;
            textBoxNombreCompleto.Location = new Point(40, 152);
            textBoxNombreCompleto.Margin = new Padding(40, 3, 40, 3);
            textBoxNombreCompleto.Name = "textBoxNombreCompleto";
            textBoxNombreCompleto.PlaceholderText = "Ingrese el nombre completo...";
            textBoxNombreCompleto.Size = new Size(275, 29);
            textBoxNombreCompleto.TabIndex = 6;
            textBoxNombreCompleto.TextAlign = HorizontalAlignment.Center;
            textBoxNombreCompleto.Enter += textBoxNombreCompleto_Enter;
            textBoxNombreCompleto.Leave += textBoxNombreCompleto_Leave;
            // 
            // textBoxContrasena
            // 
            textBoxContrasena.Dock = DockStyle.Fill;
            textBoxContrasena.ForeColor = Color.Gray;
            textBoxContrasena.Location = new Point(40, 189);
            textBoxContrasena.Margin = new Padding(40, 3, 40, 3);
            textBoxContrasena.Name = "textBoxContrasena";
            textBoxContrasena.PlaceholderText = "Ingrese la contraseña...";
            textBoxContrasena.Size = new Size(275, 29);
            textBoxContrasena.TabIndex = 5;
            textBoxContrasena.TextAlign = HorizontalAlignment.Center;
            textBoxContrasena.UseSystemPasswordChar = true;
            textBoxContrasena.Enter += textBoxContrasena_Enter;
            textBoxContrasena.Leave += textBoxContrasena_Leave;
            // 
            // comboBoxRol
            // 
            comboBoxRol.Dock = DockStyle.Fill;
            comboBoxRol.ForeColor = Color.Gray;
            comboBoxRol.FormattingEnabled = true;
            comboBoxRol.Location = new Point(40, 226);
            comboBoxRol.Margin = new Padding(40, 3, 40, 3);
            comboBoxRol.Name = "comboBoxRol";
            comboBoxRol.Size = new Size(275, 29);
            comboBoxRol.TabIndex = 4;
            comboBoxRol.SelectedIndexChanged += comboBoxRol_SelectedIndexChanged;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 3;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.784111F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 54.431778F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.7841129F));
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 3;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel4.Size = new Size(349, 143);
            tableLayoutPanel4.TabIndex = 7;
            // 
            // btnAgregarUsuario
            // 
            btnAgregarUsuario.BackColor = Color.Black;
            btnAgregarUsuario.BackgroundColor = Color.Black;
            btnAgregarUsuario.BorderColor = Color.Black;
            btnAgregarUsuario.BorderRadius = 4;
            btnAgregarUsuario.BorderSize = 1;
            btnAgregarUsuario.Dock = DockStyle.Fill;
            btnAgregarUsuario.FlatAppearance.BorderSize = 0;
            btnAgregarUsuario.FlatStyle = FlatStyle.Flat;
            btnAgregarUsuario.Font = new Font("Bahnschrift", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAgregarUsuario.ForeColor = Color.White;
            btnAgregarUsuario.Location = new Point(100, 337);
            btnAgregarUsuario.Margin = new Padding(100, 3, 100, 10);
            btnAgregarUsuario.Name = "btnAgregarUsuario";
            btnAgregarUsuario.Size = new Size(155, 37);
            btnAgregarUsuario.TabIndex = 1;
            btnAgregarUsuario.Text = "Agregar";
            btnAgregarUsuario.TextColor = Color.White;
            btnAgregarUsuario.UseVisualStyleBackColor = false;
            btnAgregarUsuario.Click += btnAgregarUsuario_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.Controls.Add(btnAgregarUsuario, 0, 6);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 5);
            tableLayoutPanel2.Controls.Add(comboBoxRol, 0, 3);
            tableLayoutPanel2.Controls.Add(textBoxContrasena, 0, 2);
            tableLayoutPanel2.Controls.Add(textBoxNombreCompleto, 0, 1);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel4, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 7;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 38.8349533F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 9.708738F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 9.708738F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 9.708738F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 9.708738F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 9.708738F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 12.6213589F));
            tableLayoutPanel2.Size = new Size(351, 384);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 5;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 300);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(349, 31);
            tableLayoutPanel3.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Bahnschrift SemiBold Condensed", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(47, 0);
            label1.Name = "label1";
            label1.Size = new Size(353, 49);
            label1.TabIndex = 0;
            label1.Text = "Agregar Usuario";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(tableLayoutPanel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(47, 52);
            panel1.Name = "panel1";
            panel1.Size = new Size(353, 386);
            panel1.TabIndex = 1;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.Controls.Add(label1, 1, 0);
            tableLayoutPanel1.Controls.Add(panel1, 1, 1);
            tableLayoutPanel1.Controls.Add(rjButton1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.Size = new Size(449, 491);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // addUsuario
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(449, 491);
            Controls.Add(tableLayoutPanel1);
            Name = "addUsuario";
            Text = "Agregar Usuario";
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private RJButton rjButton1;
        private TextBox textBoxNombreCompleto;
        private TextBox textBoxContrasena;
        private ComboBox comboBoxRol;
        private TableLayoutPanel tableLayoutPanel4;
        private RJButton btnAgregarUsuario;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label1;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
    }
}