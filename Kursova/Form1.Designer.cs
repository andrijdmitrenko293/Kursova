namespace Kursova
{
	partial class Form1
	{
		/// <summary>
		/// Обязательная переменная конструктора.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Освободить все используемые ресурсы.
		/// </summary>
		/// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Код, автоматически созданный конструктором форм Windows

		/// <summary>
		/// Требуемый метод для поддержки конструктора — не изменяйте 
		/// содержимое этого метода с помощью редактора кода.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.txtSearch = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.btnClear = new System.Windows.Forms.Button();
			this.btnExportExcel = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnUpdate = new System.Windows.Forms.Button();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnUploadPhoto = new System.Windows.Forms.Button();
			this.picPetPhoto = new System.Windows.Forms.PictureBox();
			this.txtPhone = new System.Windows.Forms.TextBox();
			this.txtOwner = new System.Windows.Forms.TextBox();
			this.txtBreed = new System.Windows.Forms.TextBox();
			this.txtSpecies = new System.Windows.Forms.TextBox();
			this.txtName = new System.Windows.Forms.TextBox();
			this.dgvPatients = new System.Windows.Forms.DataGridView();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.btnSell = new System.Windows.Forms.Button();
			this.lblTotalSum = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.txtSellQuantity = new System.Windows.Forms.TextBox();
			this.txtShopProductName = new System.Windows.Forms.TextBox();
			this.dgvShopProducts = new System.Windows.Forms.DataGridView();
			this.tabPage3 = new System.Windows.Forms.TabPage();
			this.tabPage4 = new System.Windows.Forms.TabPage();
			this.btnClearProduct = new System.Windows.Forms.Button();
			this.btnDeleteProduct = new System.Windows.Forms.Button();
			this.btnUpdateProduct = new System.Windows.Forms.Button();
			this.btnAddProduct = new System.Windows.Forms.Button();
			this.txtPrice = new System.Windows.Forms.TextBox();
			this.txtQuantity = new System.Windows.Forms.TextBox();
			this.txtCategory = new System.Windows.Forms.TextBox();
			this.txtProductName = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.dgvProducts = new System.Windows.Forms.DataGridView();
			this.button2 = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.picPetPhoto)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).BeginInit();
			this.tabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvShopProducts)).BeginInit();
			this.tabPage4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).BeginInit();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tabPage1);
			this.tabControl1.Controls.Add(this.tabPage2);
			this.tabControl1.Controls.Add(this.tabPage3);
			this.tabControl1.Controls.Add(this.tabPage4);
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 0);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(1342, 674);
			this.tabControl1.TabIndex = 0;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.Add(this.txtSearch);
			this.tabPage1.Controls.Add(this.label6);
			this.tabPage1.Controls.Add(this.btnClear);
			this.tabPage1.Controls.Add(this.btnExportExcel);
			this.tabPage1.Controls.Add(this.btnDelete);
			this.tabPage1.Controls.Add(this.btnUpdate);
			this.tabPage1.Controls.Add(this.label5);
			this.tabPage1.Controls.Add(this.label4);
			this.tabPage1.Controls.Add(this.label3);
			this.tabPage1.Controls.Add(this.label2);
			this.tabPage1.Controls.Add(this.label1);
			this.tabPage1.Controls.Add(this.btnSave);
			this.tabPage1.Controls.Add(this.btnUploadPhoto);
			this.tabPage1.Controls.Add(this.picPetPhoto);
			this.tabPage1.Controls.Add(this.txtPhone);
			this.tabPage1.Controls.Add(this.txtOwner);
			this.tabPage1.Controls.Add(this.txtBreed);
			this.tabPage1.Controls.Add(this.txtSpecies);
			this.tabPage1.Controls.Add(this.txtName);
			this.tabPage1.Controls.Add(this.dgvPatients);
			this.tabPage1.Location = new System.Drawing.Point(4, 29);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage1.Size = new System.Drawing.Size(1334, 641);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Реєстатура";
			this.tabPage1.UseVisualStyleBackColor = true;
			// 
			// txtSearch
			// 
			this.txtSearch.Location = new System.Drawing.Point(830, 491);
			this.txtSearch.Name = "txtSearch";
			this.txtSearch.Size = new System.Drawing.Size(450, 26);
			this.txtSearch.TabIndex = 19;
			this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(826, 453);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(401, 20);
			this.label6.TabIndex = 18;
			this.label6.Text = "Пошук пацієнта (по кличці,власнику або телефону):";
			// 
			// btnClear
			// 
			this.btnClear.Location = new System.Drawing.Point(531, 563);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(197, 35);
			this.btnClear.TabIndex = 17;
			this.btnClear.Text = "Очистити поля";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click_1);
			// 
			// btnExportExcel
			// 
			this.btnExportExcel.Location = new System.Drawing.Point(531, 491);
			this.btnExportExcel.Name = "btnExportExcel";
			this.btnExportExcel.Size = new System.Drawing.Size(197, 35);
			this.btnExportExcel.TabIndex = 16;
			this.btnExportExcel.Text = "Експорт в Excel";
			this.btnExportExcel.UseVisualStyleBackColor = true;
			this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Location = new System.Drawing.Point(280, 563);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(197, 35);
			this.btnDelete.TabIndex = 15;
			this.btnDelete.Text = "Видалити пацієнта";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnUpdate
			// 
			this.btnUpdate.Location = new System.Drawing.Point(28, 563);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(197, 35);
			this.btnUpdate.TabIndex = 14;
			this.btnUpdate.Text = "Оновити/Змінити";
			this.btnUpdate.UseVisualStyleBackColor = true;
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(24, 369);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(83, 20);
			this.label5.TabIndex = 13;
			this.label5.Text = "Телефон:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(24, 286);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(116, 20);
			this.label4.TabIndex = 12;
			this.label4.Text = "ПІБ власника:";
			this.label4.Click += new System.EventHandler(this.label4_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(24, 193);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(72, 20);
			this.label3.TabIndex = 11;
			this.label3.Text = "Порода:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(24, 102);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(44, 20);
			this.label2.TabIndex = 10;
			this.label2.Text = "Вид:";
			this.label2.Click += new System.EventHandler(this.label2_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(24, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(138, 20);
			this.label1.TabIndex = 9;
			this.label1.Text = "Кличка пацієнта:";
			// 
			// btnSave
			// 
			this.btnSave.Location = new System.Drawing.Point(280, 491);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(197, 35);
			this.btnSave.TabIndex = 8;
			this.btnSave.Text = "Зберегти пацієнта";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnUploadPhoto
			// 
			this.btnUploadPhoto.Location = new System.Drawing.Point(28, 491);
			this.btnUploadPhoto.Name = "btnUploadPhoto";
			this.btnUploadPhoto.Size = new System.Drawing.Size(197, 35);
			this.btnUploadPhoto.TabIndex = 7;
			this.btnUploadPhoto.Text = "Завантажити фото";
			this.btnUploadPhoto.UseVisualStyleBackColor = true;
			this.btnUploadPhoto.Click += new System.EventHandler(this.btnUploadPhoto_Click);
			// 
			// picPetPhoto
			// 
			this.picPetPhoto.Location = new System.Drawing.Point(352, 6);
			this.picPetPhoto.Name = "picPetPhoto";
			this.picPetPhoto.Size = new System.Drawing.Size(190, 192);
			this.picPetPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.picPetPhoto.TabIndex = 6;
			this.picPetPhoto.TabStop = false;
			// 
			// txtPhone
			// 
			this.txtPhone.Location = new System.Drawing.Point(28, 404);
			this.txtPhone.Name = "txtPhone";
			this.txtPhone.Size = new System.Drawing.Size(281, 26);
			this.txtPhone.TabIndex = 5;
			// 
			// txtOwner
			// 
			this.txtOwner.Location = new System.Drawing.Point(28, 318);
			this.txtOwner.Name = "txtOwner";
			this.txtOwner.Size = new System.Drawing.Size(281, 26);
			this.txtOwner.TabIndex = 4;
			// 
			// txtBreed
			// 
			this.txtBreed.Location = new System.Drawing.Point(28, 232);
			this.txtBreed.Name = "txtBreed";
			this.txtBreed.Size = new System.Drawing.Size(281, 26);
			this.txtBreed.TabIndex = 3;
			// 
			// txtSpecies
			// 
			this.txtSpecies.Location = new System.Drawing.Point(28, 134);
			this.txtSpecies.Name = "txtSpecies";
			this.txtSpecies.Size = new System.Drawing.Size(281, 26);
			this.txtSpecies.TabIndex = 2;
			this.txtSpecies.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(28, 52);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(281, 26);
			this.txtName.TabIndex = 1;
			// 
			// dgvPatients
			// 
			this.dgvPatients.AllowUserToAddRows = false;
			this.dgvPatients.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvPatients.Location = new System.Drawing.Point(570, 6);
			this.dgvPatients.Name = "dgvPatients";
			this.dgvPatients.ReadOnly = true;
			this.dgvPatients.RowHeadersWidth = 62;
			this.dgvPatients.RowTemplate.Height = 28;
			this.dgvPatients.Size = new System.Drawing.Size(761, 419);
			this.dgvPatients.TabIndex = 0;
			this.dgvPatients.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPatients_CellContentClick);
			this.dgvPatients.SelectionChanged += new System.EventHandler(this.dgvPatients_SelectionChanged);
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.Add(this.btnSell);
			this.tabPage2.Controls.Add(this.lblTotalSum);
			this.tabPage2.Controls.Add(this.label12);
			this.tabPage2.Controls.Add(this.label11);
			this.tabPage2.Controls.Add(this.txtSellQuantity);
			this.tabPage2.Controls.Add(this.txtShopProductName);
			this.tabPage2.Controls.Add(this.dgvShopProducts);
			this.tabPage2.Location = new System.Drawing.Point(4, 29);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage2.Size = new System.Drawing.Size(1334, 641);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Магазин";
			this.tabPage2.UseVisualStyleBackColor = true;
			// 
			// btnSell
			// 
			this.btnSell.Location = new System.Drawing.Point(18, 410);
			this.btnSell.Name = "btnSell";
			this.btnSell.Size = new System.Drawing.Size(204, 31);
			this.btnSell.TabIndex = 6;
			this.btnSell.Text = "Продати";
			this.btnSell.UseVisualStyleBackColor = true;
			this.btnSell.Click += new System.EventHandler(this.btnSell_Click);
			// 
			// lblTotalSum
			// 
			this.lblTotalSum.AutoSize = true;
			this.lblTotalSum.Location = new System.Drawing.Point(14, 329);
			this.lblTotalSum.Name = "lblTotalSum";
			this.lblTotalSum.Size = new System.Drawing.Size(157, 20);
			this.lblTotalSum.TabIndex = 5;
			this.lblTotalSum.Text = "До оплати: 0.00 грн";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(14, 195);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(304, 20);
			this.label12.TabIndex = 4;
			this.label12.Text = "Введіть кількість товару для продажу:";
			this.label12.Click += new System.EventHandler(this.label12_Click);
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(14, 31);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(259, 20);
			this.label11.TabIndex = 3;
			this.label11.Text = "Введіть назву вибраного товару:";
			// 
			// txtSellQuantity
			// 
			this.txtSellQuantity.Location = new System.Drawing.Point(18, 244);
			this.txtSellQuantity.Name = "txtSellQuantity";
			this.txtSellQuantity.Size = new System.Drawing.Size(402, 26);
			this.txtSellQuantity.TabIndex = 2;
			this.txtSellQuantity.TextChanged += new System.EventHandler(this.txtSellQuantity_TextChanged);
			// 
			// txtShopProductName
			// 
			this.txtShopProductName.Location = new System.Drawing.Point(18, 76);
			this.txtShopProductName.Name = "txtShopProductName";
			this.txtShopProductName.ReadOnly = true;
			this.txtShopProductName.Size = new System.Drawing.Size(402, 26);
			this.txtShopProductName.TabIndex = 1;
			// 
			// dgvShopProducts
			// 
			this.dgvShopProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvShopProducts.Location = new System.Drawing.Point(570, 6);
			this.dgvShopProducts.Name = "dgvShopProducts";
			this.dgvShopProducts.ReadOnly = true;
			this.dgvShopProducts.RowHeadersWidth = 62;
			this.dgvShopProducts.RowTemplate.Height = 28;
			this.dgvShopProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			this.dgvShopProducts.Size = new System.Drawing.Size(757, 385);
			this.dgvShopProducts.TabIndex = 0;
			this.dgvShopProducts.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvShopProducts_CellContentClick);
			this.dgvShopProducts.SelectionChanged += new System.EventHandler(this.dgvShopProducts_SelectionChanged);
			// 
			// tabPage3
			// 
			this.tabPage3.Location = new System.Drawing.Point(4, 29);
			this.tabPage3.Name = "tabPage3";
			this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage3.Size = new System.Drawing.Size(1334, 641);
			this.tabPage3.TabIndex = 2;
			this.tabPage3.Text = "Календар";
			this.tabPage3.UseVisualStyleBackColor = true;
			// 
			// tabPage4
			// 
			this.tabPage4.Controls.Add(this.btnClearProduct);
			this.tabPage4.Controls.Add(this.btnDeleteProduct);
			this.tabPage4.Controls.Add(this.btnUpdateProduct);
			this.tabPage4.Controls.Add(this.btnAddProduct);
			this.tabPage4.Controls.Add(this.txtPrice);
			this.tabPage4.Controls.Add(this.txtQuantity);
			this.tabPage4.Controls.Add(this.txtCategory);
			this.tabPage4.Controls.Add(this.txtProductName);
			this.tabPage4.Controls.Add(this.label10);
			this.tabPage4.Controls.Add(this.label9);
			this.tabPage4.Controls.Add(this.label8);
			this.tabPage4.Controls.Add(this.label7);
			this.tabPage4.Controls.Add(this.dgvProducts);
			this.tabPage4.Location = new System.Drawing.Point(4, 29);
			this.tabPage4.Name = "tabPage4";
			this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
			this.tabPage4.Size = new System.Drawing.Size(1334, 641);
			this.tabPage4.TabIndex = 3;
			this.tabPage4.Text = "Склад";
			this.tabPage4.UseVisualStyleBackColor = true;
			// 
			// btnClearProduct
			// 
			this.btnClearProduct.Location = new System.Drawing.Point(260, 545);
			this.btnClearProduct.Name = "btnClearProduct";
			this.btnClearProduct.Size = new System.Drawing.Size(226, 37);
			this.btnClearProduct.TabIndex = 12;
			this.btnClearProduct.Text = "Очистити поля";
			this.btnClearProduct.UseVisualStyleBackColor = true;
			this.btnClearProduct.Click += new System.EventHandler(this.btnClearProduct_Click);
			// 
			// btnDeleteProduct
			// 
			this.btnDeleteProduct.Location = new System.Drawing.Point(25, 545);
			this.btnDeleteProduct.Name = "btnDeleteProduct";
			this.btnDeleteProduct.Size = new System.Drawing.Size(226, 37);
			this.btnDeleteProduct.TabIndex = 11;
			this.btnDeleteProduct.Text = "Видалити товар";
			this.btnDeleteProduct.UseVisualStyleBackColor = true;
			this.btnDeleteProduct.Click += new System.EventHandler(this.btnDeleteProduct_Click);
			// 
			// btnUpdateProduct
			// 
			this.btnUpdateProduct.Location = new System.Drawing.Point(260, 463);
			this.btnUpdateProduct.Name = "btnUpdateProduct";
			this.btnUpdateProduct.Size = new System.Drawing.Size(226, 37);
			this.btnUpdateProduct.TabIndex = 10;
			this.btnUpdateProduct.Text = "Оновити товар";
			this.btnUpdateProduct.UseVisualStyleBackColor = true;
			this.btnUpdateProduct.Click += new System.EventHandler(this.btnUpdateProduct_Click);
			// 
			// btnAddProduct
			// 
			this.btnAddProduct.Location = new System.Drawing.Point(25, 463);
			this.btnAddProduct.Name = "btnAddProduct";
			this.btnAddProduct.Size = new System.Drawing.Size(226, 37);
			this.btnAddProduct.TabIndex = 9;
			this.btnAddProduct.Text = "Додати товар";
			this.btnAddProduct.UseVisualStyleBackColor = true;
			this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
			// 
			// txtPrice
			// 
			this.txtPrice.Location = new System.Drawing.Point(25, 354);
			this.txtPrice.Name = "txtPrice";
			this.txtPrice.Size = new System.Drawing.Size(503, 26);
			this.txtPrice.TabIndex = 8;
			// 
			// txtQuantity
			// 
			this.txtQuantity.Location = new System.Drawing.Point(25, 255);
			this.txtQuantity.Name = "txtQuantity";
			this.txtQuantity.Size = new System.Drawing.Size(503, 26);
			this.txtQuantity.TabIndex = 7;
			// 
			// txtCategory
			// 
			this.txtCategory.Location = new System.Drawing.Point(25, 159);
			this.txtCategory.Name = "txtCategory";
			this.txtCategory.Size = new System.Drawing.Size(503, 26);
			this.txtCategory.TabIndex = 6;
			// 
			// txtProductName
			// 
			this.txtProductName.Location = new System.Drawing.Point(25, 62);
			this.txtProductName.Name = "txtProductName";
			this.txtProductName.Size = new System.Drawing.Size(503, 26);
			this.txtProductName.TabIndex = 5;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(21, 318);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(46, 20);
			this.label10.TabIndex = 4;
			this.label10.Text = "Ціна:";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(21, 221);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(157, 20);
			this.label9.TabIndex = 3;
			this.label9.Text = "Кількість на складі:";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(21, 125);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(87, 20);
			this.label8.TabIndex = 2;
			this.label8.Text = "Категорія:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(21, 30);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(116, 20);
			this.label7.TabIndex = 1;
			this.label7.Text = "Назва товару:";
			// 
			// dgvProducts
			// 
			this.dgvProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dgvProducts.Location = new System.Drawing.Point(570, 6);
			this.dgvProducts.Name = "dgvProducts";
			this.dgvProducts.RowHeadersWidth = 62;
			this.dgvProducts.RowTemplate.Height = 28;
			this.dgvProducts.Size = new System.Drawing.Size(756, 419);
			this.dgvProducts.TabIndex = 0;
			this.dgvProducts.SelectionChanged += new System.EventHandler(this.dgvProducts_SelectionChanged);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(591, 303);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(153, 35);
			this.button2.TabIndex = 15;
			this.button2.Text = "button2";
			this.button2.UseVisualStyleBackColor = true;
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1342, 674);
			this.Controls.Add(this.tabControl1);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Name = "Form1";
			this.Text = "VetCare System";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.picPetPhoto)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dgvPatients)).EndInit();
			this.tabPage2.ResumeLayout(false);
			this.tabPage2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvShopProducts)).EndInit();
			this.tabPage4.ResumeLayout(false);
			this.tabPage4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.dgvProducts)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TabPage tabPage3;
		private System.Windows.Forms.TabPage tabPage4;
		private System.Windows.Forms.DataGridView dgvPatients;
		private System.Windows.Forms.TextBox txtPhone;
		private System.Windows.Forms.TextBox txtOwner;
		private System.Windows.Forms.TextBox txtBreed;
		private System.Windows.Forms.TextBox txtSpecies;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.PictureBox picPetPhoto;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnUploadPhoto;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button btnUpdate;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnExportExcel;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.TextBox txtSearch;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.DataGridView dgvProducts;
		private System.Windows.Forms.TextBox txtPrice;
		private System.Windows.Forms.TextBox txtQuantity;
		private System.Windows.Forms.TextBox txtCategory;
		private System.Windows.Forms.TextBox txtProductName;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button btnAddProduct;
		private System.Windows.Forms.Button btnClearProduct;
		private System.Windows.Forms.Button btnDeleteProduct;
		private System.Windows.Forms.Button btnUpdateProduct;
		private System.Windows.Forms.DataGridView dgvShopProducts;
		private System.Windows.Forms.Label lblTotalSum;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox txtSellQuantity;
		private System.Windows.Forms.TextBox txtShopProductName;
		private System.Windows.Forms.Button btnSell;
	}
}

