using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova
{
	public class Pet
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Species { get; set; }
		public string Breed { get; set; }
		public string OwnerName { get; set; }
		public string Phone { get; set; }
		public byte[] Photo { get; set; } // Масив байтів для збереження фотографії (тип LONGBLOB)
	}
}
