using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _694Assignment1
{
    class Person
    {
        /*
         * Variables used inside Person class
         */
        protected String firstname; 
        protected String lastName;
        protected String dob;
        protected String id;
        protected Double balance; 
        protected int actions = 0; // counter for number of deposits and withdrwals on persons account
        protected Double Amount; // variable used to help with caluclations 
        /*
         * Simple constructor, used to create Person object to access methods
         */
        public Person()
        { }
        /*
         * Main Constructor for Person object
         */
        public Person(String firstName, String lastName, String dob, String id, Double balance)
        {
            this.firstname = firstName;
            this.lastName = lastName;
            this.dob = dob;
            this.id = id;
            this.balance = balance;
        }
        /*
         * Dsiplay Person details
         */
        public virtual void displayDetails()
        {
            Console.WriteLine(firstname + " " + lastName + " " + dob + " " + balance);
        }
        /*
         * Setter / Getter method for first name
         */
        public virtual String accessFirstName
        {
            set { this.firstname = value; }
            get { return this.firstname; }
        }
        /*
         * Setter / Getter method for last name
         */
        public virtual String accessLastName
        {
            set { this.lastName = value; }
            get { return this.lastName; }
        }
        /*
         * Setter / Getter method for ID
         */
        public virtual String accessID
        {
            set { this.id = value; }
            get { return this.id; }
        }
        /*
         * Setter / Getter method for Account Balance
         */
        public virtual Double accessBalance
        {
            set { this.balance = value; }
            get { return this.balance; }
        }
        /*
         * Method counts and displays number of People in Person Array
         */
        public virtual int numberOf(Person[] peeps) // Count how many peopl are in array 
        {
            int count = 0; // keeps count of ps in peeps
            foreach (Person p in peeps)
            {
                count++;
            }
            Console.WriteLine("there are " + count + " people");
            return count;
        }
        /*
         * Method will display a numbered list of all Person objects in Person array
         * Method is overriden in sub classes to display numbered list of Person Type (subclass)
         * */
        public virtual void getPeople(Person[] peeps) // dislays first name of all people in array
        {
            int count = 1;
            foreach (Person p in peeps)
            {
                Console.WriteLine(count + ". " + p.accessFirstName + " is in Person Array ");
                count++;
            }
        }
        /*
         * Getter / Setter method for Date of Birth
         * */
        internal String accessDob
        {
            set { this.dob = value; }
            get { return this.dob; }
        }
        /*
         * Method for determining whether a Person was born on a leapyear
         * @param dob : date of birth as string
         * @return : returns true if year of birth is divisible by 4
         * */
        internal Boolean leapYear(String dob)
        {
            string myDate = dob;
            DateTime date = Convert.ToDateTime(myDate);
            int year = date.Year;
            if (year % 4 == 0)
            {
                return true;
            }
            else
                return false;
        }   // end of leapYear method
            /*
             * Method to work out Person's age from their date of birth
             * @param dob : date of birth as string
             * */
        internal Int32 GetAge(String dob)
        {
            var today = DateTime.Today; //todays date/time
            string myDate = dob; // date of birth of person as parameter
            DateTime date = Convert.ToDateTime(myDate);
            var a = (today.Year * 100 + today.Month) * 100 + today.Day;
            var b = (date.Year * 100 + date.Month) * 100 + date.Day;
            return (a - b) / 10000;
        }   // end of getAge method

        /*
         * Method to count number of Deposits and Withdraws
         * from a Person's account 
         **/
        internal int accessActions
        {
            set { this.actions = value; }
            get { return this.actions; }
        }   // end of accessActions method



        /*
         * Displays first and last names and balance of Person
         */
        public virtual void displayAccount()
        {
            Console.WriteLine();
            Console.WriteLine("This is the account of " + accessFirstName + " " + accessLastName + ". \t Current Balance $" + accessBalance.ToString("F"));
            Console.WriteLine();
        }


        /*
         * Finds Persons born on leayear  
         */
        public virtual void LeapYearAndZodiac()
        {
            String dob = accessDob;
            DateTime date = Convert.ToDateTime(dob);
            int month = date.Month;
                if (leapYear(dob))
                {
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");
                Console.WriteLine("");

                } // end of if leapyear loop
            }
        

         /*
          * methoid fo determining starsign
          * @param month as int between 1 and 12
          */
            public String getStarSign(int month)
        {
            switch(month)
            {
                case 1:
                    return "Alligator";
                case 2:
                    return "Coffee Cup";
                case 3:
                    return "Lamp";
                case 4:
                    return "Breadboard";
                case 5:
                    return "Suzie The Cat";
                case 6:
                    return "Pooltable";
                case 7:
                    return "Paintbrush";
                case 8:
                    return "Book";
                case 9:
                    return "Pencil";
                case 10:
                    return "Toaster";
                case 11:
                    return "Computer";
                case 12:
                    return "Hammer";


                default:
                    return "Block of Cheese";
            }
        }

        /*
         * Method conducts the withdrawing activity
         * Makes use of getAmount() method to obtain value to withdraw
         * Updates consol display  
         */
        virtual public void withdraw()
        {
            Console.WriteLine("This is the account of " + accessFirstName + " " + accessLastName + "\t Old Balance \t $" + accessBalance.ToString("F"));
            Console.WriteLine();
            Amount = getAmount("Withdraw");
            Double oldbalance = accessBalance;
            balance = oldbalance - Amount;
            actions = actions + 1;
            Console.WriteLine();
            Console.WriteLine("Withdrawing  $" + Amount.ToString("F") + " from " + accessFirstName + " " + accessLastName + "'s account");
            Console.WriteLine("");
            Console.WriteLine("New Balance : \t $" + balance.ToString("F"));
            Console.WriteLine();
            Console.WriteLine("Press any key to return to main menu");
            Console.ReadKey();
        }

        /*
        * Method conducts the depositing activity
        * Makes use of getAmount() method to obtain value to withdraw
        * Updates console display  
        */
        virtual public void deposit()
        {
            Console.WriteLine("This is the account of " + accessFirstName + " " + accessLastName + "\t Old Balance \t $" + accessBalance.ToString("F"));
            Console.WriteLine();
            Amount = getAmount("Deposit");
            Double oldbalance = accessBalance;
            balance = oldbalance + Amount;
            actions = actions + 1;
            Console.WriteLine();
            Console.WriteLine("Despoiting  $" + Amount.ToString("F") + " from " + accessFirstName + " " + accessLastName + "'s account");
            Console.WriteLine("");
            Console.WriteLine("New Balance : \t $" + balance.ToString("F"));
            Console.WriteLine();
            Console.WriteLine("Press any key to return to main menu");
            Console.ReadKey();
        }


        /*
        * Verifies amount entered in valid
        * Checks for numerical, non negative input
        */
        virtual public Double getAmount(String action)
        {
            
            String transaction = action;
            Console.Write("Enter amount to " + transaction + " : ");
            Double value;
            if (Double.TryParse((Console.ReadLine()), out value))
            {
                Amount = value;
                if (value < 0) // checks for positive number
                {
                    ClearLastLine();
                    Console.WriteLine("Enter a psoitive amount");
                    Task.Delay(1000).Wait();
                    ClearLastLine();
                    getAmount(transaction);
                }    // end of if value < 0                        
            }
            else // if non number entered
            {
                ClearLastLine();
                Console.WriteLine("Enter a valid numerical amount");
                Task.Delay(1000).Wait();
                ClearLastLine();
                getAmount(transaction);
            } // end else non number
            return Amount;
        } // end of get amount method


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
         * Works out max balance in all accounts and
         * how many people have that max balance
         * displays results to console
         * @param peeps - an array to search
         */
        virtual public void getMaxBalance(Person[] peeps)
        {
            Double max = 0; // start max balance at 0
            List<Person> maxbals = new List<Person>(); // list of people with equal highest balance
            foreach (Person p in peeps) // identify max balance
            {
                if (p.accessBalance >= max)
                {
                    max = p.accessBalance;
                }
            }// end of identifying max balance
            foreach (Person p in peeps) // checks to see if multiple people have same balance
            {
                if (p.accessBalance == max)
                {
                    maxbals.Add(p);
                }
            } // end of adding people with max balance to list
            Console.WriteLine();
            Console.WriteLine("The max balance is $" + max.ToString("F") + ". " + maxbals.Count + " people have this much in their acccount");
            Console.WriteLine();
            foreach (Person p in maxbals) // display al people wtih max balance
            {
                Console.WriteLine(p.accessFirstName + " " + p.accessLastName + " \t ID: " + p.accessID);
            }
            Console.WriteLine();
            Console.WriteLine("press any key to return to main menu");
            Console.ReadKey();
        }


        /*
         * Finds and displays youngest Person(s)
         */
        virtual public void getYoungest(Person[] peeps)
        {
            int youngest = 1000; // sets an unrealistic high number in order to find lowest 
            List<Person> youngList = new List<Person>();
            foreach (Person p in peeps)
            {
                int age = p.GetAge(p.accessDob);
                if (youngest >= age)
                {
                    youngest = age;
                }
            }
            foreach (Person p in peeps)
            {
                if (p.GetAge(p.accessDob) == youngest)
                {
                    youngList.Add(p);
                }
            }
            Console.Clear();
            Console.WriteLine("------------------------------");
            Console.WriteLine("       Youngest Customer      ");
            Console.WriteLine("------------------------------");
            Console.WriteLine();
            // display in console details of youngest person(s)
            foreach (Person p in youngList)
            {
                Console.WriteLine("ID" + "\t" + "\t" + p.accessID);
                Console.WriteLine("Name" + "\t" + "\t" + p.accessFirstName + " " + p.accessLastName);
                Console.WriteLine("Date of Birth" + "\t" + p.accessDob);
                Console.WriteLine("Age" + "\t" + "\t" + p.GetAge(p.accessDob));
                Console.WriteLine("Balance" + "\t" + "\t" + "$" + p.accessBalance.ToString("F"));
                Console.WriteLine("---------------------------------------------------------------");
            }
            Console.WriteLine();
            Console.WriteLine("press any key to return to main menu");
            Console.ReadKey();
        }// end of youngest method

        /*
         * uses Lyzs methos to find persons born on leap year and their starsigns
         * displays results in console
         */
        virtual public void getLeaps(Person[] peeps)
        {
            Console.Clear();
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("       Leaps Years and Zodiak Signs      ");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine();
            foreach (Person x in peeps)
            {
                x.LeapYearAndZodiac(); // leap year and zodiac sign method
            }
            Console.WriteLine("press any key to return to main menu");
            Console.ReadKey();
        }


        /*
     * Keeps track of activities on accounts
     * and displays details ofmost active account(s)
     */
        virtual public void getMostActiveAccount(Person[] peeps)
        {
            int mostActive = 0; // record of highest number of actions over all accounts
            List<Person> activeAccountList = new List<Person>();
            foreach (Person p in peeps)
            {
                int actions = p.accessActions;
                if (mostActive <= actions)
                {
                    mostActive = actions;
                }
            }
            foreach (Person p in peeps)
            {
                if (p.accessActions == mostActive)
                {
                    activeAccountList.Add(p);
                }
            }
            Console.Clear();
            Console.WriteLine("------------------------------");
            Console.WriteLine("       Account Actions      ");
            Console.WriteLine("------------------------------");
            Console.WriteLine();
            // display details in console
            foreach (Person p in activeAccountList)
            {
                Console.WriteLine("ID" + "\t" + "\t" + "\t" + p.accessID);
                Console.WriteLine("Name" + "\t" + "\t" + "\t" + p.accessFirstName + " " + p.accessLastName);
                Console.WriteLine("Date of Birth" + "\t" + "\t" + p.accessDob);
                Console.WriteLine("Balance" + "\t" + "\t" + "\t" + "$" + p.accessBalance.ToString("F"));
                Console.WriteLine("Actions on account" + "\t" + p.accessActions);
                Console.WriteLine("-----------------------------------------------------");
            }
            Console.WriteLine();
            Console.WriteLine("press any key to return to main menu");
            Console.ReadKey();
        }// end of most active account method

    }// end of class Person
}// end of namespace
