using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kursova
{
	public class Appointment
	{
		public int Id { get; set; }
		public int PetId { get; set; }
		public string PetName { get; set; }
		public DateTime Date { get; set; }
		public string Reason { get; set; }	
	}
}