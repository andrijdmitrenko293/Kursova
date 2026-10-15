using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ClosedXML.Excel;
using static Kursova.DatabaseConfig;

namespace Kursova
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void textBox2_TextChanged(object sender, EventArgs e)
		{

		}

		private void label4_Click(object sender, EventArgs e)
		{

		}

		private void label2_Click(object sender, EventArgs e)
		{

		}

		private void btnUploadPhoto_Click(object sender, EventArgs e)
		{
			//Відкриваємо діалогове вікно для вибору файлу
			using (OpenFileDialog ofd = new OpenFileDialog())
			{
				// Встановлюємо фільтр для вибору лише зображень
				ofd.Filter = "Image Files(*.jpg;*.jpeg;*.png;)|*.jpg;*.jpeg;*.png;";
				if (ofd.ShowDialog() == DialogResult.OK)
				{
					// Встановлюємо вибране зображення у PictureBox
					picPetPhoto.Image = Image.FromFile(ofd.FileName);
				}
			}
		}

		private void btnSave_Click(object sender, EventArgs e)
		{
			// 1. Перевіряємо, чи всі поля заповнені
			if (string.IsNullOrWhiteSpace(txtName.Text) ||
				string.IsNullOrWhiteSpace(txtSpecies.Text) ||
				string.IsNullOrWhiteSpace(txtBreed.Text) ||
				string.IsNullOrWhiteSpace(txtOwner.Text) ||
				string.IsNullOrWhiteSpace(txtPhone.Text))
			{
				MessageBox.Show("Будь ласка, заповніть всі поля.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// 2. Створюємо об'єкт пацієнта і заповнюємо його даними з форми
			Pet newPet = new Pet
			{
				Name = txtName.Text,
				Species = txtSpecies.Text,
				Breed = txtBreed.Text,
				OwnerName = txtOwner.Text,
				Phone = txtPhone.Text
			};

			// 3. Конвертуємо фотографію в байти, якщо вона є
			if (picPetPhoto.Image != null)
			{
				using (var tempBmp = new System.Drawing.Bitmap(picPetPhoto.Image))
				{
					using (var ms = new System.IO.MemoryStream())
					{
						tempBmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
						newPet.Photo = ms.ToArray();
					}
				}
			}
			else
			{
				newPet.Photo = null; // Якщо фотографії немає
			}

			// 4. ЗБЕРЕЖЕННЯ ТА ОНОВЛЕННЯ (тут важливий порядок!)
			try
			{
				var config = new DbConfig();
				string connStr = ConnectionStringBuilder.Build(config);
				var dbManager = new DatabaseManager(connStr);

				// КРОК А: Відправляємо дані в БД
				dbManager.InsertPet(newPet);

				// КРОК Б: Одразу примусово оновлюємо таблицю на екрані!
				LoadPatientsData();

				// КРОК В: Очищаємо всі поля для наступного клієнта
				txtName.Clear();
				txtSpecies.Clear();
				txtBreed.Clear();
				txtOwner.Clear();
				txtPhone.Clear();
				picPetPhoto.Image = null;

				// КРОК Г: Показуємо повідомлення про успіх (наприкінці)
				MessageBox.Show("Пацієнта успішно додано до бази!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Помилка бази даних: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private void LoadPatientsData()
		{
			try
			{
				var config = new DbConfig();
				string connStr = ConnectionStringBuilder.Build(config);
				var dbManager = new DatabaseManager(connStr);

				// Отримуємо свіжі дані
				var dt = dbManager.GetAllPets();

				// Віддаємо таблиці і примусово оновлюємо візуал
				dgvPatients.DataSource = dt;
				dgvPatients.Refresh();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Помилка завантаження списку: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
		private void Form1_Load(object sender, EventArgs e)
		{
			LoadPatientsData();
			LoadProductsData();
		}

		private void dgvPatients_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		private void dgvPatients_SelectionChanged(object sender, EventArgs e)
		{
			// Перевіряємо, чи є вибраний рядок
			if (dgvPatients.SelectedRows.Count > 0)
			{
				DataGridViewRow row = dgvPatients.SelectedRows[0];

				// Переконуємося, що рядок не порожній і перша клітинка містить ID
				if (row.Cells[0].Value != null && int.TryParse(row.Cells[0].Value.ToString(), out int petId))
				{
					try
					{
						var config = new DbConfig();
						string connStr = ConnectionStringBuilder.Build(config);
						var dbManager = new DatabaseManager(connStr);

						// Отримуємо дані пацієнта з бази за ID
						Pet pet = dbManager.GetPetById(petId);

						if (pet != null)
						{
							// Заповнюємо текстові поля
							txtName.Text = pet.Name;
							txtSpecies.Text = pet.Species;
							txtBreed.Text = pet.Breed;
							txtOwner.Text = pet.OwnerName;
							txtPhone.Text = pet.Phone;

							// Завантажуємо фотографію, якщо вона є
							if (pet.Photo != null && pet.Photo.Length > 0)
							{
								using (var ms = new System.IO.MemoryStream(pet.Photo))
								{
									picPetPhoto.Image = Image.FromStream(ms);
								}
							}
							else
							{
								picPetPhoto.Image = null; // Якщо фото немає
							}
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show("Помилка при завантаженні пацієнта: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}

		private void btnUpdate_Click(object sender, EventArgs e)
		{
			// 1. Перевіряємо, чи взагалі вибраний якийсь рядок у таблиці
			if (dgvPatients.SelectedRows.Count == 0)
			{
				MessageBox.Show("Будь ласка, виберіть пацієнта з таблиці для оновлення!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			// 2. Отримуємо ID вибраного пацієнта з першої колонки
			DataGridViewRow row = dgvPatients.SelectedRows[0];
			if (row.Cells[0].Value != null && int.TryParse(row.Cells[0].Value.ToString(), out int petId))
			{
				// 3. Перевіряємо, чи заповнені текстові поля
				if (string.IsNullOrWhiteSpace(txtName.Text) ||
					string.IsNullOrWhiteSpace(txtSpecies.Text) ||
					string.IsNullOrWhiteSpace(txtBreed.Text) ||
					string.IsNullOrWhiteSpace(txtOwner.Text) ||
					string.IsNullOrWhiteSpace(txtPhone.Text))
				{
					MessageBox.Show("Будь ласка, заповніть усі поля перед оновленням.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				// 4. Формуємо оновлений об'єкт пацієнта
				Pet updatedPet = new Pet
				{
					Id = petId,
					Name = txtName.Text,
					Species = txtSpecies.Text,
					Breed = txtBreed.Text,
					OwnerName = txtOwner.Text,
					Phone = txtPhone.Text
				};

				// 5. Конвертуємо фотографію в байти (безпечний спосіб без помилки GDI+)
				if (picPetPhoto.Image != null)
				{
					using (var tempBmp = new Bitmap(picPetPhoto.Image))
					{
						using (var ms = new System.IO.MemoryStream())
						{
							tempBmp.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
							updatedPet.Photo = ms.ToArray();
						}
					}
				}
				else
				{
					updatedPet.Photo = null;
				}

				// 6. Оновлюємо дані в базі даних та таблиці
				try
				{
					var config = new DbConfig();
					string connStr = ConnectionStringBuilder.Build(config);
					var dbManager = new DatabaseManager(connStr);

					dbManager.UpdatePet(updatedPet);

					// Оновлюємо таблицю на екрані
					LoadPatientsData();

					MessageBox.Show("Дані пацієнта успішно оновлено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch (Exception ex)
				{
					MessageBox.Show("Помилка оновлення: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}

		private void btnDelete_Click(object sender, EventArgs e)
		{
			// 1. Перевіряємо, чи вибраний рядок у таблиці
			if (dgvPatients.SelectedRows.Count == 0)
			{
				MessageBox.Show("Будь ласка, виберіть пацієнта з таблиці для видалення!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			// 2. Запитуємо підтвердження у користувача (щоб випадково не видалити)
			DialogResult result = MessageBox.Show("Ви впевнені, що хочете видалити цього пацієнта?", "Підтвердження видалення", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (result == DialogResult.Yes)
			{
				// 3. Отримуємо ID вибраного пацієнта
				DataGridViewRow row = dgvPatients.SelectedRows[0];
				if (row.Cells[0].Value != null && int.TryParse(row.Cells[0].Value.ToString(), out int petId))
				{
					try
					{
						var config = new DbConfig();
						string connStr = ConnectionStringBuilder.Build(config);
						var dbManager = new DatabaseManager(connStr);

						// Видаляємо з бази даних
						dbManager.DeletePet(petId);

						// Оновлюємо таблицю на екрані
						LoadPatientsData();

						// Очищаємо поля та картинку після видалення
						txtName.Clear();
						txtSpecies.Clear();
						txtBreed.Clear();
						txtOwner.Clear();
						txtPhone.Clear();
						picPetPhoto.Image = null;

						MessageBox.Show("Пацієнта успішно видалено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					catch (Exception ex)
					{
						MessageBox.Show("Помилка видалення: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
		}

		private void btnExportExcel_Click(object sender, EventArgs e)
		{
			try
			{
				// 1. Отримуємо дані пацієнтів з бази
				var config = new DbConfig();
				string connStr = ConnectionStringBuilder.Build(config);
				var dbManager = new DatabaseManager(connStr);
				System.Data.DataTable dt = dbManager.GetAllPets();

				if (dt.Rows.Count == 0)
				{
					MessageBox.Show("Немає даних для експорту!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				// 2. Відкриваємо вікно збереження файлу
				using (var saveFileDialog = new SaveFileDialog())
				{
					saveFileDialog.Filter = "Excel файли (*.xlsx)|*.xlsx";
					saveFileDialog.FileName = "VetClinic_Patients_Report.xlsx";

					if (saveFileDialog.ShowDialog() == DialogResult.OK)
					{
						// 3. Створюємо Excel документ за допомогою ClosedXML без створення зайвих об'єктів таблиць
						using (var workbook = new ClosedXML.Excel.XLWorkbook())
						{
							var worksheet = workbook.Worksheets.Add("Пацієнти");

							//Створюємо заголовки у першому рядку
							for (int i = 0; i < dt.Columns.Count; i++)
							{
								var cell = worksheet.Cell(1, i + 1);
								cell.Value = dt.Columns[i].ColumnName;
								cell.Style.Font.Bold = true;
								cell.Style.Fill.BackgroundColor = ClosedXML.Excel.XLColor.LightGray;
							}

							//Вставляємо самі дані пацієнтів, починаючи з другого рядка 
							worksheet.Cell(2, 1).InsertData(dt.AsEnumerable());

							// Автопідбір ширини стовпчиків
							worksheet.Columns().AdjustToContents();

							// Зберігаємо файл
							workbook.SaveAs(saveFileDialog.FileName);
						}

						MessageBox.Show("Звіт успішно збережено в Excel!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Помилка експорту в Excel: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void txtSearch_TextChanged(object sender, EventArgs e)
		{
			// Отримуємо таблицю з даними
			if (dgvPatients.DataSource is System.Data.DataTable dt)
			{
				// Беремо текст із поля і прибираємо зайві пробіли (також замінюємо одинарні лапки для безпеки)
				string searchText = txtSearch.Text.Trim().Replace("'", "''");

				if (string.IsNullOrEmpty(searchText))
				{
					// Якщо поле пошуку порожнє — знімаємо фільтр і показуємо всіх
					dt.DefaultView.RowFilter = string.Empty;
				}
				else
				{
					// Шукаємо збіги по Кличці, Власнику або Телефону
					dt.DefaultView.RowFilter = $"[Кличка] LIKE '%{searchText}%' OR [Власник] LIKE '%{searchText}%' OR [Телефон] LIKE '%{searchText}%'";
				}
			}
		}

		private void btnClear_Click_1(object sender, EventArgs e)
		{
			// 1. Очищаємо всі текстові поля та картинку
			txtName.Clear();
			txtSpecies.Clear();
			txtBreed.Clear();
			txtOwner.Clear();
			txtPhone.Clear();
			// 2. Очищаємо картинку
			picPetPhoto.Image = null;
			// 3.Знімаємо виділення з таблиці
			dgvPatients.ClearSelection();
		}

		private void btnAddProduct_Click(object sender, EventArgs e)
		{
			// 1. Перевіряємо, чи заповнені назва і категорія
			if (string.IsNullOrWhiteSpace(txtProductName.Text) || string.IsNullOrWhiteSpace(txtCategory.Text))
			{
				MessageBox.Show("Будь ласка, введіть назву та категорію товару.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			// 2. Перевіряємо, чи правильно введені числа для кількості та ціни
			if (!int.TryParse(txtQuantity.Text, out int qty))
			{
				MessageBox.Show("Кількість має бути цілим числом!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// Замінюємо кому на крапку, щоб правильно розпізнати дробові числа (напр. 150,50)
			string priceText = txtPrice.Text.Replace(',', '.');
			if (!decimal.TryParse(priceText, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal price))
			{
				MessageBox.Show("Ціна має бути числом!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			// 3. Створюємо товар і зберігаємо
			Product newProduct = new Product
			{
				Name = txtProductName.Text,
				Category = txtCategory.Text,
				Quantity = qty,
				Price = price
			};

			try
			{
				var config = new DbConfig();
				string connStr = ConnectionStringBuilder.Build(config);
				var dbManager = new DatabaseManager(connStr);

				// Зберігаємо в базу
				dbManager.InsertProduct(newProduct);

				// Оновлюємо таблицю на екрані
				LoadProductsData();

				// Очищаємо поля
				txtProductName.Clear();
				txtCategory.Clear();
				txtQuantity.Clear();
				txtPrice.Clear();

				MessageBox.Show("Товар успішно додано на склад!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Помилка додавання товару: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void dgvProducts_SelectionChanged(object sender, EventArgs e)
		{
			if (dgvProducts.SelectedRows.Count > 0)
			{
				DataGridViewRow row = dgvProducts.SelectedRows[0];
				if (row.Cells[0].Value != null && int.TryParse(row.Cells[0].Value.ToString(), out int productId))
				{
					try
					{
						var config = new DbConfig();
						string connStr = ConnectionStringBuilder.Build(config);
						var dbManager = new DatabaseManager(connStr);

						Product product = dbManager.GetProductById(productId);

						if (product != null)
						{
							txtProductName.Text = product.Name;
							txtCategory.Text = product.Category;
							txtQuantity.Text = product.Quantity.ToString();
							txtPrice.Text = product.Price.ToString("0.00"); // Формат з двома нулями
						}
					}
					catch { /* Ігноруємо дрібні помилки під час перемикання */ }
				}
			}
		}

		private void btnClearProduct_Click(object sender, EventArgs e)
		{
			txtProductName.Clear();
			txtCategory.Clear();
			txtQuantity.Clear();
			txtPrice.Clear();
			dgvProducts.ClearSelection();
		}

		private void btnUpdateProduct_Click(object sender, EventArgs e)
		{
			if (dgvProducts.SelectedRows.Count == 0)
			{
				MessageBox.Show("Виберіть товар з таблиці для оновлення!", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (int.TryParse(dgvProducts.SelectedRows[0].Cells[0].Value.ToString(), out int productId))
			{
				if (!int.TryParse(txtQuantity.Text, out int qty)) return;
				string priceText = txtPrice.Text.Replace(',', '.');
				if (!decimal.TryParse(priceText, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal price)) return;

				Product updatedProduct = new Product
				{
					Id = productId,
					Name = txtProductName.Text,
					Category = txtCategory.Text,
					Quantity = qty,
					Price = price
				};

				try
				{
					var config = new DbConfig();
					string connStr = ConnectionStringBuilder.Build(config);
					var dbManager = new DatabaseManager(connStr);

					dbManager.UpdateProduct(updatedProduct);
					LoadProductsData();
					MessageBox.Show("Дані товару оновлено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				catch (Exception ex) { MessageBox.Show("Помилка: " + ex.Message); }
			}
		}

		private void btnDeleteProduct_Click(object sender, EventArgs e)
		{
			if (dgvProducts.SelectedRows.Count == 0) return;

			if (MessageBox.Show("Ви впевнені, що хочете видалити цей товар?", "Підтвердження", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
			{
				if (int.TryParse(dgvProducts.SelectedRows[0].Cells[0].Value.ToString(), out int productId))
				{
					try
					{
						var config = new DbConfig();
						string connStr = ConnectionStringBuilder.Build(config);
						var dbManager = new DatabaseManager(connStr);

						dbManager.DeleteProduct(productId);
						LoadProductsData();
						btnClearProduct_Click(null, null); // Очищаємо поля після видалення

						MessageBox.Show("Товар видалено!", "Успіх", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					catch (Exception ex) { MessageBox.Show("Помилка: " + ex.Message); }
				}
			}
		}
		private void LoadProductsData()
		{
			try
			{
				var config = new DbConfig();
				string connStr = ConnectionStringBuilder.Build(config);
				var dbManager = new DatabaseManager(connStr);

				var data = dbManager.GetAllProducts();

				// Оновлюємо таблицю на складі
				dgvProducts.DataSource = null;
				dgvProducts.DataSource = data;
				dgvProducts.Refresh();

				// Оновлюємо таблицю в магазині (якщо ви її назвали dgvShopProducts)
				dgvShopProducts.DataSource = null;
				dgvShopProducts.DataSource = data;
				dgvShopProducts.Refresh();
			}
			catch (Exception ex) { /* обробка помилки */ }
		}

		private void label12_Click(object sender, EventArgs e)
		{

		}

		private void dgvShopProducts_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}

		// Зберігаємо ціну вибраного товару в пам'яті форми
		private decimal _currentProductPrice = 0;

		private void dgvShopProducts_SelectionChanged(object sender, EventArgs e)
		{
			if (dgvShopProducts.SelectedRows.Count > 0)
			{
				DataGridViewRow row = dgvShopProducts.SelectedRows[0];

				// Перевіряємо, чи є дані
				if (row.Cells[1].Value != null)
				{
					// Беремо назву товару (2-га колонка)
					txtShopProductName.Text = row.Cells[1].Value.ToString();

					// Беремо ціну товару (5-та колонка)
					if (decimal.TryParse(row.Cells[4].Value.ToString(), out decimal price))
					{
						_currentProductPrice = price;
					}

					// Запускаємо перерахунок суми
					txtSellQuantity_TextChanged(null, null);
				}
			}
		}

		// Автоматичний підрахунок суми при введенні кількості
		private void txtSellQuantity_TextChanged(object sender, EventArgs e)
		{
			if (int.TryParse(txtSellQuantity.Text, out int qty) && qty > 0)
			{
				decimal totalSum = qty * _currentProductPrice;
				lblTotalSum.Text = $"До оплати: {totalSum:0.00} грн";
			}
			else
			{
				lblTotalSum.Text = "До оплати: 0.00 грн";
			}
		}

		private void btnSell_Click(object sender, EventArgs e)
		{
			// 1. Перевіряємо, чи вибрано товар і чи введено кількість
			if (dgvShopProducts.SelectedRows.Count == 0) return;

			if (!int.TryParse(txtSellQuantity.Text, out int qtyToSell) || qtyToSell <= 0)
			{
				MessageBox.Show("Введіть коректну кількість для продажу!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			// 2. Отримуємо ID товару та кількість на складі
			DataGridViewRow row = dgvShopProducts.SelectedRows[0];
			int productId = Convert.ToInt32(row.Cells[0].Value);
			int quantityInStock = Convert.ToInt32(row.Cells[3].Value);

			// 3. Перевіряємо, чи вистачає товару на складі
			if (qtyToSell > quantityInStock)
			{
				MessageBox.Show($"Недостатньо товару на складі! Доступно: {quantityInStock} шт.", "Увага", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			// 4. Виконуємо продаж
			try
			{
				var config = new DbConfig();
				string connStr = ConnectionStringBuilder.Build(config);
				var dbManager = new DatabaseManager(connStr);

				dbManager.SellProduct(productId, qtyToSell);

				// Оновлюємо таблиці (це автоматично оновить і магазин, і склад)
				LoadProductsData();

				txtSellQuantity.Clear();
				MessageBox.Show("Товар успішно продано!", "Каса", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Помилка продажу: " + ex.Message, "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}