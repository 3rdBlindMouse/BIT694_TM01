using System;
using System.Threading.Tasks;
using System.IO;



namespace _694Assignment1
{
    class Program
    {

        private static Person max = new Person(); // used to access Person methods
        private static Person[] theTwenty = new Person[20]; // Array with 20 pointers to Persons
        private static FileValidator validator = new FileValidator();

        /*
         * Switch out for checking files for validation
         */
        private static String data = "C:/Users/admin/Documents/BIT694/Assignment1/input_assignment_1.txt";
        // private static String data = "C:/Users/admin/Documents/BIT694/Assignment1/input_assignment_2.txt";
        // private static String data = "C:/Users/admin/Documents/BIT694/Assignment1/input_assignment_3.txt";
        // private static String data = "C:/Users/admin/Documents/BIT694/Assignment1/input_assignment_4.txt";

        static void Main(string[] a)
        {
            validateData(data); // File exists? Correctly formatted?
            populate(data); // Read file
            menu();
            makeSelection();
        }// end of main



        /*********************************************************************************************************************
        ***                                      Methods                                                                  ***
        ********************************************************************************************************************* 
        */



        /*
         * Validates data
         * Notifies of error with appropraue error message
         * then exits program
         */
        static void validateData(String source)
        {
            if (validator.fileExists(source) == false)
            {
                Console.WriteLine(source);
                Console.WriteLine();
                Console.WriteLine("File not found");
                Console.WriteLine();
                exit();
            }
            else if (validator.validateFormat(source) == false)
            {
                //Console.WriteLine(validator.validateFormat(source));
                exit();
            }
        }

        /*
         * Exits program in 10 seconds
         */
        static void exit()
        {
            Console.WriteLine("Exiting Program in 10 seconds");
            Task.Delay(10000).Wait();
            System.Environment.Exit(1);
        }

        /*
         * Reads File data populates arrays and creates objects.
         * Creates Person Array, Creates Person, Customer and VIP Customers
         * 
         */
        static void populate(String source)
        {
            String myLine;
            String[] details; // array holding info contained in each line
            int counter = 0;
            TextReader tr = new StreamReader(source);

            while ((myLine = tr.ReadLine()) != null)
            {
                details = myLine.Split(',');
                try // some lines contain VIP as a string and the end of the line, this will seperate those fomr the lines without
                {
                    if (details[5] == "VIP")
                    {
                        // convert string balance in text file to a double
                        Double balance = Double.Parse(details[4]);
                        VIPCustomer x = new VIPCustomer(details[0], details[1], details[2], details[3], balance);
                        theTwenty[counter] = x;
                        counter++;
                    }// end of do if VIP customer loop
                }// end of try check for VIP
                catch
                {
                    // convert string balance in text file to a double
                    Double balance = Double.Parse(details[4]);
                    Customer x = new Customer(details[0], details[1], details[2], details[3], balance);
                    theTwenty[counter] = x;
                    counter++;
                }  //end of catching non VIPs             
            }// end of while myLine != null
        } // end of populate method
    

        /*
         *  creates the main menu
         */
        static void menu()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("       Banking System");
            Console.WriteLine("------------------------------");
            Console.WriteLine("0. Exit");
            Console.WriteLine("1. Deposit");
            Console.WriteLine("2. Withdraw");
            Console.WriteLine("3. Check Max. Balance");
            Console.WriteLine("4. Check Most Active Account");
            Console.WriteLine("5. Check Youngest Customer");
            Console.WriteLine("6. Show Customers Born On A Leapyear");
            Console.WriteLine();
            Console.Write("Select An Option   ");
        }// end of main menu method

        /*
         * Informs user they have made a bad selection on main menu
         * prompts user to try again
         */
        static void invalidChoice()
        {
            Console.WriteLine();
            Console.WriteLine("Please Select 0 - 6");
            Task.Delay(2000).Wait();
            ClearLastLine();
        }

        /*
         * method to display deposit or withdraw menu
         * @param string as argument as either Deposit or Withdraw
         */
        static void dwMenu(String a)
        {
            Console.Clear();
            Console.WriteLine("------------------------------");
            Console.WriteLine("       " + a + "");
            Console.WriteLine("------------------------------");
            Console.WriteLine();
        }// end of dwmenu method

        /*
         * Method to clear a line in Console to keep console tidy
         */
        public static void ClearLastLine()
        {
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.BufferWidth));
            Console.SetCursorPosition(0, Console.CursorTop - 1);
        }

        /*
         * Conducts the withdraw and deposit actions
         */
        static void doAction(String something, Person[] peeps)
        {
            String action = something;
            dwMenu(action);
            Console.Write("Enter account ID  : ");
            String account = Console.ReadLine();
            checkForAccount(account, peeps, action);
        }

        /*
         * Seeks user numerical input 
         * Verifies amount entered in valid
         * Checks for numerical, non negative input
         * @param action : string representation of users desired action
         */
        static void getAmount(String action)
        {
            ClearLastLine();
            String transaction = action;
            Console.Write("Enter amount to " + transaction + " : ");
            Double value;
            if (Double.TryParse((Console.ReadLine()), out value))
            {
                Double Amount = value;
                if (value < 0) // checks for positive number
                {
                    ClearLastLine();
                    Console.WriteLine("Enter a psoitive amount");
                    Task.Delay(1000).Wait();
                    getAmount(transaction);
                }
            }
            else
            {
                ClearLastLine();
                Console.WriteLine("Enter a valid numerical amount");
                Task.Delay(1000).Wait();
                getAmount(transaction);
            }
        } // end of get amount method


        /*
         * Method checks to ensure account exists then proceeds with users selected action
         * @param account : user entered account number
         * @param peeps : Person array to search
         * @param action : string representation of users desired action
         */
        static void checkForAccount(String account, Person[] peeps, String action)
        {
            int index = -1; // -1 = false by default meaning account won't be found
            foreach (Person p in peeps)
            {
                if (p.accessID == account) // find account
                {
                    index = Array.IndexOf(peeps, p); // if account number exists index = true ie. > -1                  
                    if (index >= 0)
                    {
                        max = p;
                       
                        Console.WriteLine();
                        if(action == "Withdraw")
                        {
                            max.withdraw();
                        }
                        if(action =="Deposit")
                        {
                            max.deposit();
                        }
                    } // end of if index >= 0 ie. if account exists                   
                }
            }
            if (index == -1) // if a matching account hasnt been found
            {
                Console.WriteLine("No such account found. Returning to main menu");
                Task.Delay(3000).Wait();
                return;
            }
        }// end of check for account method

        /*
         * Takes users selection and calls appropriate methods into action 
         */
        private static void makeSelection()
        {
             int choice = 10; // need to declare any value that isn't 0 so as can loop back to menu within main menthod
            while (choice != 0)
            {
                
                try // make sure selection is valid try
                {
                    choice = Int32.Parse(Console.ReadLine());
                    switch (choice)
                    {
                        case 0:
                            Console.Clear();
                            break;
                        case 1:
                            doAction("Deposit", theTwenty);
                            break;
                        case 2:
                            doAction("Withdraw", theTwenty);
                            break;
                        case 3:
                            max.getMaxBalance(theTwenty);
                            break;
                        case 4:
                            max.getMostActiveAccount(theTwenty);
                            break;
                        case 5:
                            max.getYoungest(theTwenty);
                            break;
                        case 6:
                            max.getLeaps(theTwenty);
                            break;
                        default:
                            invalidChoice();
                            break;
                    }// end of switch = Main menu slections
                }// end of try valid selection
                catch (Exception e) // catches non numerical inputs
                {
                    Console.WriteLine();
                    Console.WriteLine(e.Message + " (This is system e.message)"); // incorrect format message may change it
                    invalidChoice();
                    
                }// end of non numerical catch
                Console.Clear();
                menu(); // display main menu method
                
            }// end of Main menu slections ( while choice != 0)
        }


    }// end of class Program
}// end of namespace
