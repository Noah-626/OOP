using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace groupProject
{
    internal class Flight
    {
        private int flightNumber;
        private string flightOrigin;
        private string flightDestination;
        private int maxSeats;
        private int numberOfPassengers;
        private int availableSeats;

        public Flight (int flightNumber, string flightOrigin, string flightDestination, int maxSeats)
        {
            this.flightNumber = flightNumber;
            this.flightOrigin = flightOrigin;
            this.flightDestination = flightDestination;
            this.maxSeats = maxSeats;
            this.numberOfPassengers = 0; // when a customer make a booking => passengers++ 
            this.availableSeats = maxSeats - numberOfPassengers;
        }


        public int getMaxSeats()
        {
            return maxSeats;
        }

        public int getAvailableSeats()
        {
            return availableSeats;
        }
        public int getFlightNumber()
        {
            return flightNumber;
        }

        public string getFightOrigin()
        {
            return flightOrigin;
        }

        public string getFightDestination()
        {
            return flightDestination;
        }

        public int getNumberOfPass()
        {
            return numberOfPassengers;
        }
        
    }
}
