namespace Principal
{
    partial class updateProveedor
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
            txtEmail = new TextBox();
            txtTelefono = new TextBox();
            txtNombre = new TextBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            btnGuardar = new RJButton();
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
            // txtEmail
            // 
            txtEmail.Dock = DockStyle.Fill;
            txtEmail.ForeColor = Color.Gray;
            txtEmail.Location = new Point(40, 226);
            txtEmail.Margin = new Padding(40, 3, 40, 3);
            txtEmail.Name = "txtEmail";
            txtEmail.PlaceholderText = "Ingrese el email del Proveedor...";
            txtEmail.Size = new Size(275, 29);
            txtEmail.TabIndex = 4;
            txtEmail.TextAlign = HorizontalAlignment.Center;
            // 
            // txtTelefono
            // 
            txtTelefono.Dock = DockStyle.Fill;
            txtTelefono.ForeColor = Color.Gray;
            txtTelefono.Location = new Point(40, 189);
            txtTelefono.Margin = new Padding(40, 3, 40, 3);
            txtTelefono.Name = "txtTelefono";
            txtTelefono.PlaceholderText = "Ingrese el Telefono del Proveedor...";
            txtTelefono.Size = new Size(275, 29);
            txtTelefono.TabIndex = 5;
            txtTelefono.TextAlign = HorizontalAlignment.Center;
            // 
            // txtNombre
            // 
            txtNombre.Dock = DockStyle.Fill;
            txtNombre.ForeColor = Color.Gray;
            txtNombre.Location = new Point(40, 152);
            txtNombre.Margin = new Padding(40, 3, 40, 3);
            txtNombre.Name = "txtNombre";
            txtNombre.PlaceholderText = "Ingrese el Nombre del Proveedor...";
            txtNombre.Size = new Size(275, 29);
            txtNombre.TabIndex = 6;
            txtNombre.TextAlign = HorizontalAlignment.Center;
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
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.Black;
            btnGuardar.BackgroundColor = Color.Black;
            btnGuardar.BorderColor = Color.Black;
            btnGuardar.BorderRadius = 4;
            btnGuardar.BorderSize = 1;
            btnGuardar.Dock = DockStyle.Fill;
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.Font = new Font("Bahnschrift", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(100, 337);
            btnGuardar.Margin = new Padding(100, 3, 100, 10);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(155, 37);
            btnGuardar.TabIndex = 1;
            btnGuardar.Text = "Editar";
            btnGuardar.TextColor = Color.White;
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.Controls.Add(btnGuardar, 0, 6);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 5);
            tableLayoutPanel2.Controls.Add(txtEmail, 0, 3);
            tableLayoutPanel2.Controls.Add(txtTelefono, 0, 2);
            tableLayoutPanel2.Controls.Add(txtNombre, 0, 1);
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
            label1.Text = "Editar Proveedor";
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
            // updateProveedor
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(449, 491);
            Controls.Add(tableLayoutPanel1);
            Name = "updateProveedor";
            Text = "Editar Proveedor";
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private RJButton rjButton1;
        private TextBox txtEmail;
        private TextBox txtTelefono;
        private TextBox txtNombre;
        private TableLayoutPanel tableLayoutPanel4;
        private RJButton btnGuardar;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label1;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
    }
}