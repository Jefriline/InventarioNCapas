namespace Principal
{
    partial class updateProduct
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
            panel2 = new Panel();
            pictureBox1 = new PictureBox();
            textBoxPrecio = new TextBox();
            tetBoxCodRef = new TextBox();
            textboxNombre = new TextBox();
            tableLayoutPanel4 = new TableLayoutPanel();
            buttonPlus = new Button();
            buttoMinus = new Button();
            textBoxStock = new TextBox();
            btnUpdate = new RJButton();
            comboBoxProveedor = new ComboBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            tableLayoutPanel3 = new TableLayoutPanel();
            label1 = new Label();
            panel1 = new Panel();
            tableLayoutPanel1 = new TableLayoutPanel();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tableLayoutPanel4.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
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
            rjButton1.Size = new Size(40, 45);
            rjButton1.TabIndex = 2;
            rjButton1.Text = "⍇";
            rjButton1.TextAlign = ContentAlignment.TopCenter;
            rjButton1.TextColor = Color.Black;
            rjButton1.UseVisualStyleBackColor = true;
            rjButton1.Click += rjButton1_Click_1;
            // 
            // panel2
            // 
            panel2.BorderStyle = BorderStyle.FixedSingle;
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(82, 16);
            panel2.Name = "panel2";
            panel2.Size = new Size(183, 98);
            panel2.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Cursor = Cursors.Hand;
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.ErrorImage = null;
            pictureBox1.ImageLocation = "";
            pictureBox1.InitialImage = null;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(181, 96);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // textBoxPrecio
            // 
            textBoxPrecio.Dock = DockStyle.Fill;
            textBoxPrecio.ForeColor = Color.Gray;
            textBoxPrecio.Location = new Point(40, 207);
            textBoxPrecio.Margin = new Padding(40, 3, 40, 3);
            textBoxPrecio.Name = "textBoxPrecio";
            textBoxPrecio.PlaceholderText = "Ingrese el precio del Producto...";
            textBoxPrecio.Size = new Size(275, 29);
            textBoxPrecio.TabIndex = 4;
            textBoxPrecio.TextAlign = HorizontalAlignment.Center;
            // 
            // tetBoxCodRef
            // 
            tetBoxCodRef.Dock = DockStyle.Fill;
            tetBoxCodRef.ForeColor = Color.Gray;
            tetBoxCodRef.Location = new Point(40, 173);
            tetBoxCodRef.Margin = new Padding(40, 3, 40, 3);
            tetBoxCodRef.Name = "tetBoxCodRef";
            tetBoxCodRef.PlaceholderText = "Ingrese Cod/referencia del Producto...";
            tetBoxCodRef.Size = new Size(275, 29);
            tetBoxCodRef.TabIndex = 5;
            tetBoxCodRef.TextAlign = HorizontalAlignment.Center;
            // 
            // textboxNombre
            // 
            textboxNombre.Dock = DockStyle.Fill;
            textboxNombre.ForeColor = Color.Gray;
            textboxNombre.Location = new Point(40, 139);
            textboxNombre.Margin = new Padding(40, 3, 40, 3);
            textboxNombre.Name = "textboxNombre";
            textboxNombre.PlaceholderText = "Ingrese el Nombre del Producto...";
            textboxNombre.Size = new Size(275, 29);
            textboxNombre.TabIndex = 6;
            textboxNombre.TextAlign = HorizontalAlignment.Center;
            // 
            // tableLayoutPanel4
            // 
            tableLayoutPanel4.ColumnCount = 3;
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.784111F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 54.431778F));
            tableLayoutPanel4.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22.7841129F));
            tableLayoutPanel4.Controls.Add(panel2, 1, 1);
            tableLayoutPanel4.Dock = DockStyle.Fill;
            tableLayoutPanel4.Location = new Point(3, 3);
            tableLayoutPanel4.Name = "tableLayoutPanel4";
            tableLayoutPanel4.RowCount = 3;
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 80F));
            tableLayoutPanel4.RowStyles.Add(new RowStyle(SizeType.Percent, 10F));
            tableLayoutPanel4.Size = new Size(349, 130);
            tableLayoutPanel4.TabIndex = 7;
            // 
            // buttonPlus
            // 
            buttonPlus.Dock = DockStyle.Fill;
            buttonPlus.Location = new Point(193, 3);
            buttonPlus.Name = "buttonPlus";
            buttonPlus.Size = new Size(28, 22);
            buttonPlus.TabIndex = 0;
            buttonPlus.Text = "+";
            buttonPlus.UseVisualStyleBackColor = true;
            buttonPlus.Click += buttonPlus_Click_1;
            // 
            // buttoMinus
            // 
            buttoMinus.Dock = DockStyle.Fill;
            buttoMinus.Location = new Point(125, 3);
            buttoMinus.Name = "buttoMinus";
            buttoMinus.Size = new Size(28, 22);
            buttoMinus.TabIndex = 1;
            buttoMinus.Text = "-";
            buttoMinus.UseVisualStyleBackColor = true;
            buttoMinus.Click += buttoMinus_Click_1;
            // 
            // textBoxStock
            // 
            textBoxStock.Dock = DockStyle.Fill;
            textBoxStock.Location = new Point(159, 3);
            textBoxStock.Name = "textBoxStock";
            textBoxStock.Size = new Size(28, 29);
            textBoxStock.TabIndex = 2;
            textBoxStock.Text = "0";
            textBoxStock.TextAlign = HorizontalAlignment.Center;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = Color.Black;
            btnUpdate.BackgroundColor = Color.Black;
            btnUpdate.BorderColor = Color.Black;
            btnUpdate.BorderRadius = 4;
            btnUpdate.BorderSize = 1;
            btnUpdate.Dock = DockStyle.Fill;
            btnUpdate.FlatAppearance.BorderSize = 0;
            btnUpdate.FlatStyle = FlatStyle.Flat;
            btnUpdate.Font = new Font("Bahnschrift", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(100, 309);
            btnUpdate.Margin = new Padding(100, 3, 100, 10);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(155, 33);
            btnUpdate.TabIndex = 1;
            btnUpdate.Text = "Actualizar";
            btnUpdate.TextColor = Color.White;
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // comboBoxProveedor
            // 
            comboBoxProveedor.Dock = DockStyle.Fill;
            comboBoxProveedor.DrawMode = DrawMode.OwnerDrawFixed;
            comboBoxProveedor.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxProveedor.FormattingEnabled = true;
            comboBoxProveedor.Location = new Point(40, 241);
            comboBoxProveedor.Margin = new Padding(40, 3, 40, 3);
            comboBoxProveedor.Name = "comboBoxProveedor";
            comboBoxProveedor.Size = new Size(275, 30);
            comboBoxProveedor.TabIndex = 1;
            comboBoxProveedor.SelectedIndexChanged += comboBoxProveedor_SelectedIndexChanged;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle());
            tableLayoutPanel2.Controls.Add(btnUpdate, 0, 6);
            tableLayoutPanel2.Controls.Add(comboBoxProveedor, 0, 4);
            tableLayoutPanel2.Controls.Add(tableLayoutPanel3, 0, 5);
            tableLayoutPanel2.Controls.Add(textBoxPrecio, 0, 3);
            tableLayoutPanel2.Controls.Add(tetBoxCodRef, 0, 2);
            tableLayoutPanel2.Controls.Add(textboxNombre, 0, 1);
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
            tableLayoutPanel2.Size = new Size(354, 352);
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
            tableLayoutPanel3.Controls.Add(buttonPlus, 3, 0);
            tableLayoutPanel3.Controls.Add(buttoMinus, 1, 0);
            tableLayoutPanel3.Controls.Add(textBoxStock, 2, 0);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 275);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 1;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel3.Size = new Size(349, 28);
            tableLayoutPanel3.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Dock = DockStyle.Fill;
            label1.Font = new Font("Bahnschrift SemiBold Condensed", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(48, 0);
            label1.Name = "label1";
            label1.Size = new Size(356, 45);
            label1.TabIndex = 0;
            label1.Text = "Actualizar Producto";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(tableLayoutPanel2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(48, 48);
            panel1.Name = "panel1";
            panel1.Size = new Size(356, 354);
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
            tableLayoutPanel1.Size = new Size(453, 450);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // updateProduct
            // 
            AutoScaleDimensions = new SizeF(9F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(453, 450);
            Controls.Add(tableLayoutPanel1);
            Name = "updateProduct";
            Text = "Update";
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tableLayoutPanel4.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            panel1.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private RJButton rjButton1;
        private Panel panel2;
        private PictureBox pictureBox1;
        private TextBox textBoxPrecio;
        private TextBox tetBoxCodRef;
        private TextBox textboxNombre;
        private TableLayoutPanel tableLayoutPanel4;
        private Button buttonPlus;
        private Button buttoMinus;
        private TextBox textBoxStock;
        private RJButton btnUpdate;
        private ComboBox comboBoxProveedor;
        private TableLayoutPanel tableLayoutPanel2;
        private TableLayoutPanel tableLayoutPanel3;
        private Label label1;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel1;
    }
}