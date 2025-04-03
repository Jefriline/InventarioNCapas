namespace Principal
{
    partial class HomeAdmin
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
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            rjButton2 = new RJButton();
            btnGestionarProveedores = new RJButton();
            btnGestionarUser = new RJButton();
            tableLayoutPanel5 = new TableLayoutPanel();
            vScrollBar2 = new VScrollBar();
            label1 = new Label();
            tableLayoutPanel1.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            tableLayoutPanel5.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 90F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5F));
            tableLayoutPanel1.Controls.Add(tableLayoutPanel2, 1, 2);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel3, 1, 3);
            tableLayoutPanel1.Controls.Add(tableLayoutPanel5, 2, 2);
            tableLayoutPanel1.Controls.Add(label1, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 4;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 0F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 75F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 15F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(1160, 666);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 3;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(61, 69);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 4;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.Size = new Size(1038, 493);
            tableLayoutPanel2.TabIndex = 0;
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 3;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel3.Controls.Add(rjButton2, 1, 0);
            tableLayoutPanel3.Controls.Add(btnGestionarProveedores, 0, 0);
            tableLayoutPanel3.Controls.Add(btnGestionarUser, 2, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(61, 568);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel3.Size = new Size(1038, 95);
            tableLayoutPanel3.TabIndex = 1;
            // 
            // rjButton2
            // 
            rjButton2.BackColor = Color.Black;
            rjButton2.BackgroundColor = Color.Black;
            rjButton2.BorderColor = Color.Black;
            rjButton2.BorderRadius = 1;
            rjButton2.BorderSize = 1;
            rjButton2.FlatAppearance.BorderSize = 0;
            rjButton2.FlatStyle = FlatStyle.Flat;
            rjButton2.Font = new Font("Bahnschrift", 14F, FontStyle.Bold);
            rjButton2.ForeColor = Color.White;
            rjButton2.Location = new Point(418, 20);
            rjButton2.Margin = new Padding(3, 20, 3, 3);
            rjButton2.Name = "rjButton2";
            rjButton2.Size = new Size(200, 54);
            rjButton2.TabIndex = 0;
            rjButton2.Text = "Agregar un Producto";
            rjButton2.TextColor = Color.White;
            rjButton2.UseVisualStyleBackColor = false;
            rjButton2.Click += rjButton2_Click;
            // 
            // btnGestionarProveedores
            // 
            btnGestionarProveedores.BackColor = Color.Black;
            btnGestionarProveedores.BackgroundColor = Color.Black;
            btnGestionarProveedores.BorderColor = Color.Black;
            btnGestionarProveedores.BorderRadius = 1;
            btnGestionarProveedores.BorderSize = 1;
            btnGestionarProveedores.FlatAppearance.BorderSize = 0;
            btnGestionarProveedores.FlatStyle = FlatStyle.Flat;
            btnGestionarProveedores.Font = new Font("Bahnschrift", 14F, FontStyle.Bold);
            btnGestionarProveedores.ForeColor = Color.White;
            btnGestionarProveedores.Location = new Point(30, 20);
            btnGestionarProveedores.Margin = new Padding(30, 20, 3, 3);
            btnGestionarProveedores.Name = "btnGestionarProveedores";
            btnGestionarProveedores.Size = new Size(200, 54);
            btnGestionarProveedores.TabIndex = 1;
            btnGestionarProveedores.Text = "Gestionar Proveedores";
            btnGestionarProveedores.TextColor = Color.White;
            btnGestionarProveedores.UseVisualStyleBackColor = false;
            btnGestionarProveedores.Click += btnGestionarProveedores_Click;
            // 
            // btnGestionarUser
            // 
            btnGestionarUser.BackColor = Color.Black;
            btnGestionarUser.BackgroundColor = Color.Black;
            btnGestionarUser.BorderColor = Color.Black;
            btnGestionarUser.BorderRadius = 1;
            btnGestionarUser.BorderSize = 1;
            btnGestionarUser.FlatAppearance.BorderSize = 0;
            btnGestionarUser.FlatStyle = FlatStyle.Flat;
            btnGestionarUser.Font = new Font("Bahnschrift", 14F, FontStyle.Bold);
            btnGestionarUser.ForeColor = Color.White;
            btnGestionarUser.Location = new Point(802, 20);
            btnGestionarUser.Margin = new Padding(180, 20, 3, 3);
            btnGestionarUser.Name = "btnGestionarUser";
            btnGestionarUser.Size = new Size(200, 54);
            btnGestionarUser.TabIndex = 2;
            btnGestionarUser.Text = "Gestionar Usuarios";
            btnGestionarUser.TextColor = Color.White;
            btnGestionarUser.UseVisualStyleBackColor = false;
            btnGestionarUser.Click += btnGestionarUser_Click;
            // 
            // tableLayoutPanel5
            // 
            tableLayoutPanel5.ColumnCount = 3;
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45.1076126F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 39.856514F));
            tableLayoutPanel5.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 15.0358715F));
            tableLayoutPanel5.Controls.Add(vScrollBar2, 1, 0);
            tableLayoutPanel5.Dock = DockStyle.Fill;
            tableLayoutPanel5.Location = new Point(1105, 69);
            tableLayoutPanel5.Name = "tableLayoutPanel5";
            tableLayoutPanel5.RowCount = 1;
            tableLayoutPanel5.RowStyles.Add(new RowStyle());
            tableLayoutPanel5.Size = new Size(52, 493);
            tableLayoutPanel5.TabIndex = 4;
            // 
            // vScrollBar2
            // 
            vScrollBar2.Location = new Point(23, 0);
            vScrollBar2.Name = "vScrollBar2";
            vScrollBar2.Size = new Size(17, 80);
            vScrollBar2.TabIndex = 0;
            vScrollBar2.Visible = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Bahnschrift SemiCondensed", 20.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(508, 5);
            label1.Margin = new Padding(450, 5, 450, 21);
            label1.Name = "label1";
            label1.Size = new Size(144, 40);
            label1.TabIndex = 5;
            label1.Text = "Inventario";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // Home
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1160, 666);
            Controls.Add(tableLayoutPanel1);
            Name = "Home";
            Text = "Home";
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel5.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel5;
        private Label label1;
        private TableLayoutPanel tableLayoutPanel3;
        private RJButton rjButton2;
        private ProgressBar progressBar1;
        private VScrollBar vScrollBar2;
        private RJButton btnGestionarProveedores;
        private RJButton btnGestionarUser;
    }
}