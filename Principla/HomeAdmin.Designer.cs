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
            panel1 = new Panel();
            btnGestionarUser = new Button();
            btnGestionarProveedores = new Button();
            btnAddProduct = new Button();
            panel2 = new Panel();
            label1 = new Label();
            panel3 = new Panel();
            flowLayoutPanel1 = new FlowLayoutPanel();
            panel4 = new Panel();
            comboBoxFiltros = new ComboBox();
            textBoxBuscar = new TextBox();
            label2 = new Label();
            button1 = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(0, 122, 204);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(btnGestionarUser);
            panel1.Controls.Add(btnGestionarProveedores);
            panel1.Controls.Add(btnAddProduct);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 5, 4, 5);
            panel1.Name = "panel1";
            panel1.Size = new Size(300, 748);
            panel1.TabIndex = 0;
            // 
            // btnGestionarUser
            // 
            btnGestionarUser.BackColor = Color.FromArgb(0, 122, 204);
            btnGestionarUser.FlatAppearance.BorderSize = 0;
            btnGestionarUser.FlatStyle = FlatStyle.Flat;
            btnGestionarUser.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGestionarUser.ForeColor = Color.White;
            btnGestionarUser.Location = new Point(18, 323);
            btnGestionarUser.Margin = new Padding(4, 5, 4, 5);
            btnGestionarUser.Name = "btnGestionarUser";
            btnGestionarUser.Size = new Size(264, 65);
            btnGestionarUser.TabIndex = 2;
            btnGestionarUser.Text = "Gestionar Usuarios";
            btnGestionarUser.UseVisualStyleBackColor = false;
            btnGestionarUser.Click += btnGestionarUser_Click;
            // 
            // btnGestionarProveedores
            // 
            btnGestionarProveedores.BackColor = Color.FromArgb(0, 122, 204);
            btnGestionarProveedores.FlatAppearance.BorderSize = 0;
            btnGestionarProveedores.FlatStyle = FlatStyle.Flat;
            btnGestionarProveedores.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGestionarProveedores.ForeColor = Color.White;
            btnGestionarProveedores.Location = new Point(18, 226);
            btnGestionarProveedores.Margin = new Padding(4, 5, 4, 5);
            btnGestionarProveedores.Name = "btnGestionarProveedores";
            btnGestionarProveedores.Size = new Size(264, 65);
            btnGestionarProveedores.TabIndex = 1;
            btnGestionarProveedores.Text = "Gestionar Proveedores";
            btnGestionarProveedores.UseVisualStyleBackColor = false;
            btnGestionarProveedores.Click += btnGestionarProveedores_Click;
            // 
            // btnAddProduct
            // 
            btnAddProduct.BackColor = Color.FromArgb(0, 122, 204);
            btnAddProduct.FlatAppearance.BorderSize = 0;
            btnAddProduct.FlatStyle = FlatStyle.Flat;
            btnAddProduct.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddProduct.ForeColor = Color.White;
            btnAddProduct.Location = new Point(18, 129);
            btnAddProduct.Margin = new Padding(4, 5, 4, 5);
            btnAddProduct.Name = "btnAddProduct";
            btnAddProduct.Size = new Size(264, 65);
            btnAddProduct.TabIndex = 0;
            btnAddProduct.Text = "Agregar Producto";
            btnAddProduct.UseVisualStyleBackColor = false;
            btnAddProduct.Click += btnAddProduct_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(300, 0);
            panel2.Margin = new Padding(4, 5, 4, 5);
            panel2.Name = "panel2";
            panel2.Size = new Size(1070, 97);
            panel2.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Bahnschrift", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.FromArgb(0, 122, 204);
            label1.Location = new Point(24, 27);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(106, 25);
            label1.TabIndex = 0;
            label1.Text = "Productos";
            // 
            // panel3
            // 
            panel3.Controls.Add(flowLayoutPanel1);
            panel3.Controls.Add(panel4);
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(300, 97);
            panel3.Margin = new Padding(4, 5, 4, 5);
            panel3.Name = "panel3";
            panel3.Size = new Size(1070, 651);
            panel3.TabIndex = 2;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.Dock = DockStyle.Fill;
            flowLayoutPanel1.Location = new Point(0, 97);
            flowLayoutPanel1.Margin = new Padding(4, 5, 4, 5);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1070, 554);
            flowLayoutPanel1.TabIndex = 1;
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Controls.Add(comboBoxFiltros);
            panel4.Controls.Add(textBoxBuscar);
            panel4.Controls.Add(label2);
            panel4.Dock = DockStyle.Top;
            panel4.Location = new Point(0, 0);
            panel4.Margin = new Padding(4, 5, 4, 5);
            panel4.Name = "panel4";
            panel4.Size = new Size(1070, 97);
            panel4.TabIndex = 0;
            // 
            // comboBoxFiltros
            // 
            comboBoxFiltros.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBoxFiltros.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxFiltros.Font = new Font("Bahnschrift", 12F);
            comboBoxFiltros.FormattingEnabled = true;
            comboBoxFiltros.Location = new Point(710, 26);
            comboBoxFiltros.Margin = new Padding(4, 5, 4, 5);
            comboBoxFiltros.Name = "comboBoxFiltros";
            comboBoxFiltros.Size = new Size(340, 27);
            comboBoxFiltros.TabIndex = 2;
            // 
            // textBoxBuscar
            // 
            textBoxBuscar.Font = new Font("Bahnschrift", 12F);
            textBoxBuscar.Location = new Point(123, 26);
            textBoxBuscar.Margin = new Padding(4, 5, 4, 5);
            textBoxBuscar.Name = "textBoxBuscar";
            textBoxBuscar.Size = new Size(448, 27);
            textBoxBuscar.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Bahnschrift", 12F);
            label2.Location = new Point(26, 31);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(63, 19);
            label2.TabIndex = 0;
            label2.Text = "Buscar:";
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(0, 122, 204);
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Bahnschrift", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Red;
            button1.Location = new Point(13, 415);
            button1.Margin = new Padding(4, 5, 4, 5);
            button1.Name = "button1";
            button1.Size = new Size(264, 65);
            button1.TabIndex = 3;
            button1.Text = "Facturas";
            button1.UseVisualStyleBackColor = false;
            // 
            // HomeAdmin
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1370, 748);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(4, 5, 4, 5);
            MinimumSize = new Size(1364, 718);
            Name = "HomeAdmin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Panel de Administración";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnAddProduct;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGestionarProveedores;
        private System.Windows.Forms.Button btnGestionarUser;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxBuscar;
        private System.Windows.Forms.ComboBox comboBoxFiltros;
        private Button button1;
    }
}