using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace groupProject
{

    
   
    internal class AirlineCoordinator
    {
        private  int maxFlights;
        private  int maxCustomers;
        private  int maxBookings;

        private Flight[] flightList;
        private Customer[] customerList;
        private Booking[] bookingList;

        private int numberOfFlight;
        private int numberOfCustomer;
        private int numberOfBooking;

        private Customer customerFound;
        private Flight flightFound;
        public AirlineCoordinator(int maxFli, int maxCus, int maxBo)
        {
            this.maxFlights = maxFli;
            this.maxCustomers = maxCus;
            this.maxBookings = maxBo;

            flightList = new Flight[maxFli];
            customerList = new Customer[maxCus];
            bookingList = new Booking[maxBo];

            this.numberOfFlight = 0;
            this.numberOfCustomer = 0;
            this.numberOfBooking = 0;

            //this.customerFound = null;
            //this.flightFound = null;
        }
        
        //---------------- Customer ----------------
        //Add customer
        public bool addCustomer(string customerFirstName, string customerLastName, string customerPhone)
        {
            if (numberOfCustomer < maxCustomers && !string.IsNullOrWhiteSpace(customerFirstName) && 
                !string.IsNullOrWhiteSpace(customerLastName) && !string.IsNullOrWhiteSpace(customerPhone))
            {
                customerList[numberOfCustomer] = new Customer(customerFirstName, customerLastName, customerPhone);
                numberOfCustomer++;         
                return true;
            }
            return false;
        }

        //delete customer
        public void deleteCustomer(string id)
        {
           // int indexToDelete = -1;

            // Find the index of the customer with the specified ID
            for(int i = 0; i < numberOfCustomer; i++)
            {
                if (customerList[i].getCustomerId() == id)
                {
                    customerList[i] = customerList[numberOfCustomer - 1];
                }
            }
            numberOfCustomer--;
        }
        //View customer
        public void ViewCustomer()
        {
            Console.WriteLine("Number" + "\t\t" + "Name\t\t\t" + "Phone");
            for (int i = 0; i < numberOfCustomer; i++)
            {
                string cusInfo2 = customerList[i].getCustomerId() + "\t" + customerList[i].getCustomerFirstName() + "\t" +
                customerList[i].getCustomerLastName() + "\t\t" + customerList[i].getCustomerPhone();
                Console.WriteLine(cusInfo2);
            }
        }

        //---------------- Flight ----------------
        public bool makeFlightint(int flightNumber, string flightOrigin, string flightDestination, int maxSeats)
        {
            if (numberOfFlight < maxFlights && !string.IsNullOrWhiteSpace(Convert.ToString(flightNumber)) && !string.IsNullOrWhiteSpace(flightOrigin) && 
                !string.IsNullOrWhiteSpace(flightDestination) && !string.IsNullOrWhiteSpace(Convert.ToString(flightDestination)))
            {
                flightList[numberOfFlight] = new Flight(flightNumber, flightOrigin, flightDestination, maxSeats);
                numberOfFlight++;
                // flightList[numberOfFlight].numberOfPassengers++;
                return true;
            }
            else
            {
                Console.WriteLine("Enter the right form");
            }
            return false;
        }

        public void ViewFlight()
        {
            for(int i = 0;i < numberOfFlight; i++)
            {
                Console.WriteLine(flightList[i].getFlightNumber() + " from " + flightList[i].getFightOrigin() 
                 + " to " + flightList[i].getFightDestination());
            }
        }

        public void ViewparticularFlight(int flNum)
        {
            for (int i = 0; i < numberOfFlight; i++)
            {
                if (flightList[i].getFlightNumber() == flNum)
                {
                    Console.WriteLine("Flight Number: " + flightList[i].getFlightNumber() +
                   "\nOrigin: " + flightList[i].getFightOrigin() +
                   "\nDestination: " + flightList[i].getFightDestination() +
                   "\nNumber of passengers: " + flightList[i].getNumberOfPass() +
                   "\nAvailable seat: " + flightList[i].getAvailableSeats());
                }
            }
        }
        public void deleteFlight(int flightNumber)
        {
            for( int i = 0;i < numberOfFlight;i++)
            {
                if (flightList[i].getFlightNumber() == flightNumber)
                {
                    flightFound = flightList[i];
                    Console.WriteLine("Flight has been deleted");
                    numberOfFlight--;
                }
            }
        }
        //---------------- Booking ----------------
        public bool makeBooking(string customerNo, int flightNo)
        {
            for(int i = 0;i < maxBookings; i++) // TRY ANOTHER CONDITION
            {
                if (numberOfBooking < maxBookings && customerNo == customerList[i].getCustomerId() && 
                    flightNo == flightList[i].getFlightNumber()
                    && flightList[i].getAvailableSeats() <= flightList[i].getMaxSeats())
                {
                    bookingList[numberOfBooking] = new Booking();
                    numberOfBooking++;
                }
                return true;
            }
            return false;
        }

        public void viewBooking()
        {
            for (int i = 0; i < numberOfBooking; i++)
            {
                Console.WriteLine( "Date: " + bookingList[i].getDate() +
                    "\nBooking Number: " + bookingList[i].getBookingNumber() +
                    "\nCustomer Name: " + customerList[i].getCustomerFirstName() + " " + customerList[i].getCustomerLastName() +
                    "\nFlight Number: " + flightList[i].getFlightNumber() + "\n-----------------------");
            }
        }

        //
       /* private bool customerHasBookings(string customerId)
        {
            for (int i = 0; i < numberOfBooking; i++)
            {
                if (bookingList[i].customer.getCustomerId() == customerId)
                {
                    return true; // Customer has bookings
                }
            }
            return false; // Customer has no bookings
        }*/
        //---------------Write to File-----------------------
        public void WriteCustomersToFile(string location)
        {
            StreamWriter outFile = new StreamWriter(location);
            for(int i = 0 ;i < numberOfCustomer; i++)
            {
                outFile.WriteLine(customerList[i].getCustomerId() + " " + customerList[i].getCustomerFirstName() + " " 
                    + customerList[i].getCustomerLastName() + " " + customerList[i].getCustomerPhone());
            }
            outFile.Close();
        }

        public void WriteFlightsToFile(string location)
        {
            StreamWriter outFile = new StreamWriter(location);
            for (int i = 0; i < numberOfFlight; i++)
            {
                outFile.WriteLine(flightList[i].getFlightNumber() + " " + flightList[i].getFightOrigin() + " " +
                    flightList[i].getFightDestination() + flightList[i].getNumberOfPass() + " " +
                    flightList[i].getAvailableSeats() + " " + flightList[i].getMaxSeats());
            }
            outFile.Close();
        }

        public void WriteBookingsToFile(string location)
        {
            StreamWriter outFile = new StreamWriter(location); 
            for (int i = 0; i < numberOfBooking; i++)
            {
                outFile.WriteLine(bookingList[i].getDate() +" "+ bookingList[i].getBookingNumber());
            }
            outFile.Close();
        }

        //---------------Load a File-----------------------
        public Customer[] LoadCustomerFile(string location)
        {
            
            string line;
            if (File.Exists(location))
            {
                StreamReader customerFile = new StreamReader(location);
                //WHILE LOOP WITH READLINE
                    line = customerFile.ReadLine(); 
                    string[] tokens = line.Split();
                    numberOfCustomer = 1;
                    Customer customer = new Customer(tokens[1], tokens[2], tokens[3]);
                    customerList[0] = customer;
                    
                    
                
                customerFile.Close();
            }
            else
            {
                customerList = new Customer[maxCustomers];  
            }
            return customerList;
        }
    }
}
