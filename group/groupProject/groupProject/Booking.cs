using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace groupProject
{
    internal class Booking
    {
        private string dateOfBooking;
        private string bookingNumber;
        private Flight[] flight;
        private Customer[] customer;
        public Booking()
        {
            this.dateOfBooking = DateTime.Now.ToString(@"MM\/dd\/yyyy h\:mm tt");

            this.bookingNumber = GenerateRandombookingNumber();
        }
        private static string GenerateRandombookingNumber()
        {
            const string characters = "1234567890";
            Random random = new Random();
            char[] idChars = new char[3];
            for (int i = 0; i < idChars.Length; i++)
            {
                idChars[i] = characters[random.Next(characters.Length)];
            }
            return new string(idChars);
        }
        public string getDate()
        {
            return dateOfBooking;
        }

        public string getBookingNumber()
        {
            return bookingNumber;
        }
      
    }
}
