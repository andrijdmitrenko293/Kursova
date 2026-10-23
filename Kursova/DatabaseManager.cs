using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;
using System.Data;
using DocumentFormat.OpenXml.Bibliography;

namespace Kursova
{
	public class DatabaseManager
	{
		private readonly string _connString;

		public DatabaseManager(string connString)
		{
			_connString = connString;
		}

		// Метод для збереження пацієнта разом з фото
		public void InsertPet(Pet newPet)
		{
			using (var conn = new MySqlConnection(_connString))
			{
				conn.Open();
				string query = "INSERT INTO Pets (PetName, Species, Breed, OwnerName, Phone, Photo) " +
							   "VALUES (@name, @species, @breed, @owner, @phone, @photo)";

				using (var cmd = new MySqlCommand(query, conn))
				{
					cmd.Parameters.AddWithValue("@name", newPet.Name);
					cmd.Parameters.AddWithValue("@species", newPet.Species);
					cmd.Parameters.AddWithValue("@breed", newPet.Breed);
					cmd.Parameters.AddWithValue("@owner", newPet.OwnerName);
					cmd.Parameters.AddWithValue("@phone", newPet.Phone);

					// Якщо фото немає, передаємо NULL у базу даних
					if (newPet.Photo != null)
						cmd.Parameters.AddWithValue("@photo", newPet.Photo);
					else
						cmd.Parameters.AddWithValue("@photo", null);

					cmd.ExecuteNonQuery();
				}
			}
		}
		// Метод для оновлення даних існуючого пацієнта
		public void UpdatePet(Pet pet)
		{
			using (var conn = new MySqlConnection(_connString))
			{
				conn.Open();
				string query = "UPDATE Pets SET PetName = @name, Species = @species, Breed = @breed, " +
							   "OwnerName = @owner, Phone = @phone, Photo = @photo WHERE Id = @id";

				using (var cmd = new MySqlCommand(query, conn))
				{
					cmd.Parameters.AddWithValue("@id", pet.Id);
					cmd.Parameters.AddWithValue("@name", pet.Name);
					cmd.Parameters.AddWithValue("@species", pet.Species);
					cmd.Parameters.AddWithValue("@breed", pet.Breed);
					cmd.Parameters.AddWithValue("@owner", pet.OwnerName);
					cmd.Parameters.AddWithValue("@phone", pet.Phone);

					// Якщо фото є, передаємо його, якщо немає — NULL
					if (pet.Photo != null)
						cmd.Parameters.AddWithValue("@photo", pet.Photo);
					else
						cmd.Parameters.AddWithValue("@photo", DBNull.Value);

					cmd.ExecuteNonQuery();
				}
			}
		}
		// Метод для видалення пацієнта за його ID
		public void DeletePet(int petId)
		{
			using (var conn = new MySqlConnection(_connString))
			{
				conn.Open();
				string query = "DELETE FROM Pets WHERE Id = @id";

				using (var cmd = new MySqlCommand(query, conn))
				{
					cmd.Parameters.AddWithValue("@id", petId);
					cmd.ExecuteNonQuery();
				}
			}
		}
		// Метод для отримання конкретного пацієнта за його ID
		public Pet GetPetById(int petId)
		{
			Pet pet = null;
			using (var conn = new MySqlConnection(_connString))
			{
				conn.Open();
				string query = "SELECT * FROM Pets WHERE Id = @id";
				using (var cmd = new MySqlCommand(query, conn))
				{
					cmd.Parameters.AddWithValue("@id", petId);
					using (var reader = cmd.ExecuteReader())
					{
						if (reader.Read())
						{
							pet = new Pet
							{
								Id = reader.GetInt32("Id"),
								Name = reader.GetString("PetName"),
								Species = reader.GetString("Species"),
								Breed = reader.IsDBNull(reader.GetOrdinal("Breed")) ? string.Empty : reader.GetString("Breed"),
								OwnerName = reader.GetString("OwnerName"),
								Phone = reader.IsDBNull(reader.GetOrdinal("Phone")) ? string.Empty : reader.GetString("Phone")
							};

							// Зчитуємо фотографію, якщо вона є в базі
							if (!reader.IsDBNull(reader.GetOrdinal("Photo")))
							{
								long length = reader.GetBytes(reader.GetOrdinal("Photo"), 0, null, 0, 0);
								byte[] buffer = new byte[length];
								reader.GetBytes(reader.GetOrdinal("Photo"), 0, buffer, 0, (int)length);
								pet.Photo = buffer;
							}
						}
					}
				}
			}
			return pet;
		}

		// Метод для отримання всіх пацієнтів у вигляді таблиці
		public DataTable GetAllPets()
		{
			DataTable table = new DataTable();
			using (var conn = new MySqlConnection(_connString))
			{
				conn.Open();
				// Вибираємо дані. Використовуємо AS, щоб у таблиці на екрані були гарні українські назви колонок
				string query = "SELECT Id AS '№', PetName AS 'Кличка', Species AS 'Вид', Breed AS 'Порода', OwnerName AS 'Власник', Phone AS 'Телефон' FROM Pets";

				using (var cmd = new MySqlCommand(query, conn))
				{
					using (var adapter = new MySqlDataAdapter(cmd))
					{
						// Заповнюємо віртуальну таблицю результатами з бази
						adapter.Fill(table);
					}
				}
			}
			return table;
		}
		// --- МЕТОДИ ДЛЯ СКЛАДУ ТА МАГАЗИНУ ---

		// Метод для додавання нового товару на склад
		public void InsertProduct(Product newProduct)
		{
			using (var conn = new MySqlConnection(_connString))
			{
				conn.Open();
				string query = "INSERT INTO Products (ProductName, Category, Quantity, Price) " +
							   "VALUES (@name, @category, @quantity, @price)";

				using (var cmd = new MySqlCommand(query, conn))
				{
					cmd.Parameters.AddWithValue("@name", newProduct.Name);
					cmd.Parameters.AddWithValue("@category", newProduct.Category);
					cmd.Parameters.AddWithValue("@quantity", newProduct.Quantity);
					cmd.Parameters.AddWithValue("@price", newProduct.Price);

					cmd.ExecuteNonQuery();
				}
			}
		}
		// Метод для отримання всіх товарів зі складу для таблиці
		public DataTable GetAllProducts()
		{
			DataTable table = new DataTable();
			using (var conn = new MySqlConnection(_connString))
			{
				conn.Open();
				// Вибираємо дані з красивими назвами колонок
				string query = "SELECT Id AS 'Артикул', ProductName AS 'Назва товару', Category AS 'Категорія', Quantity AS 'На складі (шт)', Price AS 'Ціна (грн)' FROM Products";

				using (var cmd = new MySqlCommand(query, conn))
				{
					using (var adapter = new MySqlDataAdapter(cmd))
					{
						adapter.Fill(table);
					}
				}
			}
			return table;
		}
		// Метод для отримання товару за ID
		public Product GetProductById(int productId)
		{
			Product product = null;
			using (var conn = new MySqlConnection(_connString))
			{
				conn.Open();
				string query = "SELECT * FROM Products WHERE Id = @id";
				using (var cmd = new MySqlCommand(query, conn))
				{
					cmd.Parameters.AddWithValue("@id", productId);
					using (var reader = cmd.ExecuteReader())
					{
						if (reader.Read())
						{
							product = new Product
							{
								Id = reader.GetInt32("Id"),
								Name = reader.GetString("ProductName"),
								Category = reader.IsDBNull(reader.GetOrdinal("Category")) ? string.Empty : reader.GetString("Category"),
								Quantity = reader.IsDBNull(reader.GetOrdinal("Quantity")) ? 0 : reader.GetInt32("Quantity"),
								Price = reader.IsDBNull(reader.GetOrdinal("Price")) ? 0 : reader.GetDecimal("Price")
							};
						}
					}
				}
			}
			return product;
		}

		// Метод для оновлення існуючого товару
		public void UpdateProduct(Product product)
		{
			using (var conn = new MySqlConnection(_connString))
			{
				conn.Open();
				string query = "UPDATE Products SET ProductName = @name, Category = @category, " +
							   "Quantity = @quantity, Price = @price WHERE Id = @id";
				using (var cmd = new MySqlCommand(query, conn))
				{
					cmd.Parameters.AddWithValue("@id", product.Id);
					cmd.Parameters.AddWithValue("@name", product.Name);
					cmd.Parameters.AddWithValue("@category", product.Category);
					cmd.Parameters.AddWithValue("@quantity", product.Quantity);
					cmd.Parameters.AddWithValue("@price", product.Price);
					cmd.ExecuteNonQuery();
				}
			}
		}

		// Метод для видалення товару
		public void DeleteProduct(int productId)
		{
			using (var conn = new MySqlConnection(_connString))
			{
				conn.Open();
				string query = "DELETE FROM Products WHERE Id = @id";
				using (var cmd = new MySqlCommand(query, conn))
				{
					cmd.Parameters.AddWithValue("@id", productId);
					cmd.ExecuteNonQuery();
				}
			}
		}
		// Метод для продажу товару (зменшення кількості на складі)
		public void SellProduct(int productId, int quantityToSell)
		{
			using (var conn = new MySqlConnection(_connString))
			{
				conn.Open();
				// Віднімаємо вказану кількість від поточної кількості на складі
				string query = "UPDATE Products SET Quantity = Quantity - @qty WHERE Id = @id";

				using (var cmd = new MySqlCommand(query, conn))
				{
					cmd.Parameters.AddWithValue("@qty", quantityToSell);
					cmd.Parameters.AddWithValue("@id", productId);
					cmd.ExecuteNonQuery();
				}
			}
		}
		// --- МЕТОДИ ДЛЯ КАЛЕНДАРЯ ---

		// 1. Отримуємо список пацієнтів для випадаючого списку (ComboBox)
		public System.Data.DataTable GetPatientsForComboBox()
		{
			System.Data.DataTable table = new System.Data.DataTable();
			using (var conn = new MySqlConnection(_connString))
			{
				conn.Open();
				string query = "SELECT Id, PetName FROM Pets";
				using (var cmd = new MySqlCommand(query, conn))
				{
					using (var adapter = new MySqlDataAdapter(cmd))
					{
						adapter.Fill(table);
					}
				}
			}
			return table;
		}

		// 2. Додаємо новий запис на прийом у базу
		public void InsertAppointment(int petId, DateTime date, string reason)
		{
			using (var conn = new MySqlConnection(_connString))
			{
				conn.Open();
				string query = "INSERT INTO Appointments (PetId, AppointmentDate, Reason) VALUES (@petId, @date, @reason)";
				using (var cmd = new MySqlCommand(query, conn))
				{
					cmd.Parameters.AddWithValue("@petId", petId);
					cmd.Parameters.AddWithValue("@date", date);
					cmd.Parameters.AddWithValue("@reason", reason);
					cmd.ExecuteNonQuery();
				}
			}
		}

		// 3. Отримуємо всі записи для таблиці на екрані (об'єднуємо таблиці, щоб бачити кличку замість ID)
		public System.Data.DataTable GetAllAppointments()
		{
			System.Data.DataTable table = new System.Data.DataTable();
			using (var conn = new MySqlConnection(_connString))
			{
				conn.Open();
				string query = @"SELECT a.Id AS '№', 
                        p.PetName AS 'Пацієнт', 
                        a.AppointmentDate AS 'Дата та час', 
                        a.Reason AS 'Причина' 
                 FROM Appointments a 
                 JOIN Pets p ON a.PetId = p.Id 
                 ORDER BY a.AppointmentDate";
				using (var cmd = new MySqlCommand(query, conn))
				{
					using (var adapter = new MySqlDataAdapter(cmd))
					{
						adapter.Fill(table);
					}
				}
			}
			return table;
		}
		// --- МЕТОДИ ДЛЯ РЕДАГУВАННЯ КАЛЕНДАРЯ ---

		// 1. Отримати запис за ID (щоб заповнити поля при кліку на таблицю)
		public Appointment GetAppointmentById(int appointmentId)
		{
			Appointment appt = null;
			using (var conn = new MySqlConnection(_connString))
			{
				conn.Open();
				string query = "SELECT * FROM Appointments WHERE Id = @id";
				using (var cmd = new MySqlCommand(query, conn))
				{
					cmd.Parameters.AddWithValue("@id", appointmentId);
					using (var reader = cmd.ExecuteReader())
					{
						if (reader.Read())
						{
							appt = new Appointment
							{
								Id = reader.GetInt32("Id"),
								PetId = reader.GetInt32("PetId"),
								Date = reader.GetDateTime("AppointmentDate"),
								Reason = reader.IsDBNull(reader.GetOrdinal("Reason")) ? string.Empty : reader.GetString("Reason")
							};
						}
					}
				}
			}
			return appt;
		}

		// 2. Оновити існуючий запис
		public void UpdateAppointment(Appointment appt)
		{
			using (var conn = new MySqlConnection(_connString))
			{
				conn.Open();
				string query = "UPDATE Appointments SET PetId = @petId, AppointmentDate = @date, Reason = @reason WHERE Id = @id";
				using (var cmd = new MySqlCommand(query, conn))
				{
					cmd.Parameters.AddWithValue("@id", appt.Id);
					cmd.Parameters.AddWithValue("@petId", appt.PetId);
					cmd.Parameters.AddWithValue("@date", appt.Date);
					cmd.Parameters.AddWithValue("@reason", appt.Reason);
					cmd.ExecuteNonQuery();
				}
			}
		}

		// 3. Видалити запис
		public void DeleteAppointment(int appointmentId)
		{
			using (var conn = new MySqlConnection(_connString))
			{
				conn.Open();
				string query = "DELETE FROM Appointments WHERE Id = @id";
				using (var cmd = new MySqlCommand(query, conn))
				{
					cmd.Parameters.AddWithValue("@id", appointmentId);
					cmd.ExecuteNonQuery();
				}
			}
		}
		// --- МЕТОДИ ДЛЯ СТАТИСТИКИ ---

		// 1. Рахуємо загальну кількість пацієнтів
		public int GetTotalPatientsCount()
		{
			using (var conn = new MySqlConnection(_connString))
			{
				conn.Open();
				string query = "SELECT COUNT(*) FROM Pets";
				using (var cmd = new MySqlCommand(query, conn))
				{
					return Convert.ToInt32(cmd.ExecuteScalar());
				}
			}
		}

		// 2. Рахуємо загальну кількість видів товарів на складі
		public int GetTotalProductsCount()
		{
			using (var conn = new MySqlConnection(_connString))
			{
				conn.Open();
				string query = "SELECT COUNT(*) FROM Products";
				using (var cmd = new MySqlCommand(query, conn))
				{
					return Convert.ToInt32(cmd.ExecuteScalar());
				}
			}
		}

		// 3. Рахуємо кількість майбутніх записів у календарі
		public int GetTotalAppointmentsCount()
		{
			using (var conn = new MySqlConnection(_connString))
			{
				conn.Open();
				string query = "SELECT COUNT(*) FROM Appointments";
				using (var cmd = new MySqlCommand(query, conn))
				{
					return Convert.ToInt32(cmd.ExecuteScalar());
				}
			}
		}

		// 4. Рахуємо загальну вартість усіх товарів на складі (Кількість * Ціна)
		public decimal GetTotalInventoryValue()
		{
			using (var conn = new MySqlConnection(_connString))
			{
				conn.Open();
				string query = "SELECT SUM(Quantity * Price) FROM Products";
				using (var cmd = new MySqlCommand(query, conn))
				{
					object result = cmd.ExecuteScalar();
					return result != DBNull.Value ? Convert.ToDecimal(result) : 0;
				}
			}
		}

		// Метод для отримання даних для графіка (категорія товару і загальна кількість)
		public System.Data.DataTable GetCategoryStatistics()
		{
			System.Data.DataTable table = new System.Data.DataTable();
			using (var conn = new MySqlConnection(_connString))
			{
				conn.Open();
				// Групуємо товари за категоріями і рахуємо загальну кількість
				string query = "SELECT Category, SUM(Quantity) AS TotalQuantity FROM Products GROUP BY Category";
				using (var cmd = new MySqlCommand(query, conn))
				{
					using (var adapter = new MySqlDataAdapter(cmd))
					{
						adapter.Fill(table);
					}
				}
			}
			return table;
		}
	}
}