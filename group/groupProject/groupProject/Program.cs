using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace groupProject
{
    internal class Program
    {
        static AirlineCoordinator aCoord;

        
            public static void showMainMenu()
            {
                Console.Clear();
                Console.WriteLine("XYZ Airlines Limited. \nPlease select a choice from the main menu below:\n");
                Console.WriteLine("1: Customer\n2: Flights\n3: Bookings");
                Console.WriteLine("4.exit");
            }

            

            public static int getValidChoice(int upperRange)
            {
                int choice;
                showMainMenu();
                while (!int.TryParse(Console.ReadLine(), out choice) || (choice < 1 || choice > upperRange))
                {
                    showMainMenu();
                    Console.WriteLine("Please enter a Valid Choice");
                }
                return choice;
            }

            //============Get Choice======================
            public static int getCustChoice(int upperRange)
            {
                int choice;
                showCustomerMenu();
                while(!int.TryParse(Console.ReadLine(), out choice)  || (choice < 1 || choice > upperRange))
                {
                    showCustomerMenu();
                    Console.WriteLine("Please enter a valid choice");
                }    
                return choice;
            }
            public static int getFlightChoice(int upperRange)
            {
                int choice;
                showFlightMenu();
                while (!int.TryParse(Console.ReadLine(), out choice) || (choice < 1 || choice > upperRange))
                {
                    showFlightMenu();
                    Console.WriteLine("Please enter a valid choice");
                }
                return choice;
            }

            public static int getBookingChoice(int upperRange)
            {
                int choice;
                showBookingMenu();
                while (!int.TryParse(Console.ReadLine(), out choice) || (choice < 1 || choice > upperRange))
                {
                    showBookingMenu();
                    Console.WriteLine("Please enter a valid choice");
                }
                return choice;
            }

            //===============MENU=========================
            public static void showCustomerMenu()
            {
                Console.Clear();
                Console.WriteLine("XYZ Airlines Limited. \nPlease select a choice from the main menu below:\n");
                Console.WriteLine("1: Add Customer\n2: View Customer\n3: Delete customer\n4: Back to main menu");
            }

            public static void showFlightMenu()
            {
                Console.Clear();
                Console.WriteLine("XYZ Airlines Limited. \nPlease select a choice from the main menu below:\n");
                Console.WriteLine("1: Add Flight\n2: View Flight\n3: View a particular Flight" +
                    "\n4: Delete Flight\n5: Back to main menu");
            }

            public static void showBookingMenu()
            {
                Console.Clear();
                Console.WriteLine("XYZ Airlines Limited. \nPlease select a choice from the main menu below:\n");
                Console.WriteLine("1: Make Booking\n2: View Booking\n3: Delete Booking\n4: Back to main menu");
            }
            public static void customerSubMenu()
            {
                int choice = getCustChoice(4);
                while(choice != 4)
                {
                if(choice == 1) { addCustomer(); };
                if (choice == 2) { viewCustomer(); };
                if (choice == 3) { deleteCustomer(); };
                if (choice == 4) { runProgram(); };
                    choice = getCustChoice(4);
                }
            }

            public static void flightSubMenu()
            {
                int choice = getFlightChoice(5);
                while (choice != 5)
                {
                if (choice == 1) { addFlight(); };
                if (choice == 2) { viewFlight(); };
                if (choice == 3) { viewParticularFlight(); };
                if (choice == 4) { deleteFlight(); };
                if (choice == 5) { runProgram(); };
                    choice = getFlightChoice(5);
                }
            }

            public static void bookingSubMenu()
            {
                int choice = getBookingChoice(4);
                while (choice != 3)
                {
                if (choice == 1) { makeBooking(); };
                if (choice == 2) { viewBooking(); };  
                if (choice == 3) { runProgram(); };
                    choice = getBookingChoice(3);
                }
            }

            //===============Method======================
            public static void makeBooking()
            {
                string customerNo;
                int flightNo;
                Console.Clear();
                Console.WriteLine("---------------- Flight ----------------");
                aCoord.ViewFlight();
                Console.WriteLine("---------------- Customer ----------------");
                aCoord.ViewCustomer();
                Console.WriteLine("----------------Make Booking----------------");
                Console.Write("Please enter Customer Number: ");
                customerNo = Console.ReadLine();
                Console.Write("Please enter Flight Number: ");
                flightNo = Convert.ToInt32(Console.ReadLine());
                if(aCoord.makeBooking(customerNo, flightNo))
                {
                    Console.WriteLine("Booking succesfully added");
                    aCoord.WriteBookingsToFile("C:\\Users\\OWNER\\Desktop\\Bookings.txt");
                }
                else
                {
                    Console.WriteLine("Booking was not made");
                }
            Console.WriteLine("\nPlease enter any key to return to the main menu.");
            Console.ReadKey();
            }

            public static void viewBooking()
            {
                Console.Clear();
                Console.WriteLine("----------------List of Bookings----------------");
                aCoord.viewBooking();
            Console.WriteLine("\nPlease enter any key to return to the main menu.");
            Console.ReadKey();
            }

            public static void addFlight()
            {
                int flightNumber, maxSeats;
                string flightOrigin, flightDestination;
                Console.Clear();
                Console.WriteLine("----------------Add Flight----------------");
                Console.Write("Please enter the Flight Number: ");
                flightNumber = Convert.ToInt32(Console.ReadLine());
                Console.Write("Please enter the Flight port of Origin: ");
                flightOrigin = Console.ReadLine();
                Console.Write("Please enter the Flight destination port: ");
                flightDestination = Console.ReadLine();
                Console.Write("Please enter the maximum of seats: ");
                maxSeats = Convert.ToInt32(Console.ReadLine());

                    if(aCoord.makeFlightint(flightNumber, flightOrigin, flightDestination, maxSeats))
                    {
                        Console.WriteLine("Flight successfully added.");
                        aCoord.WriteFlightsToFile("C:\\Users\\OWNER\\Desktop\\Flights.txt");
                    }
                    else
                    {
                        Console.WriteLine("Flight was not added");
                    }
            Console.WriteLine("\nPlease enter any key to return to the main menu.");
            Console.ReadKey();
            }

            public static void viewFlight()
            {
                Console.Clear ();
                Console.WriteLine("----------------List of Flights----------------");
                aCoord.ViewFlight();
            Console.WriteLine("\nPlease enter any key to return to the main menu.");
            Console.ReadKey();
            }

            public static void viewParticularFlight()
            {
                int flNo;
                Console.Clear ();
                aCoord.ViewFlight();
                Console.WriteLine("----------------Particular Flight----------------");
                Console.Write("Please enter a flight number: ");
                flNo = Convert.ToInt32(Console.ReadLine());
                aCoord.ViewparticularFlight(flNo);
            Console.WriteLine("\nPlease enter any key to return to the main menu.");
            Console.ReadKey();
            }

            public static void deleteFlight()
            {
                int fligNo;
                Console.Clear();
                Console.Write("Please enter a flight number that you want to delete: ");
                fligNo = Convert.ToInt32(Console.ReadLine());
                aCoord.deleteFlight(fligNo);
            Console.WriteLine("\nPlease enter any key to return to the main menu.");
            Console.ReadKey();
            }
            public static void addCustomer()
            {
                string customerFirstName, customerLastName, customerPhone;
                Console.Clear();
                Console.WriteLine("----------------Add Customer----------------");
                Console.Write("Please enter your First Name: ");
                customerFirstName = Console.ReadLine();
                Console.Write("Please enter your Last Name: ");
                customerLastName = Console.ReadLine();
                Console.Write("Please enter your Phone Number: ");
                customerPhone = Console.ReadLine();
                if (aCoord.addCustomer(customerFirstName, customerLastName, customerPhone))
                {
                Console.WriteLine("Customer succesfully added");
                
                }
                else
                {
                    Console.WriteLine("Failed to add Customer");
                }
            aCoord.WriteCustomersToFile("C:\\Users\\OWNER\\Desktop\\Customers.txt");
            Console.WriteLine("\nPlease enter any key to return to the main menu.");
            Console.ReadKey();
             }

            public static void viewCustomer()
            {
                Console.Clear();
                Console.WriteLine("--------------List Of Customers--------------");
                aCoord.ViewCustomer();
            Console.WriteLine("\nPlease enter any key to return to the main menu.");
            Console.ReadKey();
            }

            public static void deleteCustomer()
            {
                string cusId;
                Console.Clear();
                aCoord.ViewCustomer();
                Console.WriteLine("Please enter customer ID:");
                cusId = Console.ReadLine();
                aCoord.deleteCustomer(cusId);
            Console.WriteLine("\nPlease enter any key to return to the main menu.");
            Console.ReadKey();
            }
            //===============MENU=========================
            public static void runProgram()
            {
            
            int choice = getValidChoice(4);
                while (choice != 4)
                {
                    if (choice == 1) { customerSubMenu();};
                    if (choice == 2) { flightSubMenu(); };
                    if (choice == 3) { bookingSubMenu(); };
                    choice = getValidChoice(4);
                }
            }
        static void Main(string[] args)
        {
            // Team Members: 
            // 1. Nhu Nam Nguyen - 101441905
            aCoord = new AirlineCoordinator(200, 3000, 3000);
            aCoord.LoadCustomerFile("C:\\Users\\OWNER\\Desktop\\Customers.txt");
            runProgram();
            Console.WriteLine("Thank you for using XYZ Airline System. Press any key to exit");
            Console.ReadKey();
        }
    }
}
