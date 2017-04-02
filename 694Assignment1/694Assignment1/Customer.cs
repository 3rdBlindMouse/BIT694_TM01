using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _694Assignment1
{
    class Customer : Person
    {
        static int fee = 3;
        static int fails = 0;


        // basic Customer constructor
        public Customer()
        { }

        // standar customer constructor
        public Customer(String firstName, String lastName, String dob, String id, Double balance) :
            base(firstName, lastName, dob, id, balance)
        { }

        /*
         * Displays first and last names and balance of Person
         * @override : 
         */
        public override void displayAccount()
        {
            //Console.WriteLine();
            Console.WriteLine("This is the account of " + accessFirstName + " " + accessLastName + " \t Current Balance $" + accessBalance.ToString("F"));
            Console.WriteLine();
        }// end of display account method


        /*
         * Method counts and displays number of People 
         * @override : Displays the number of Customer type Persons
         */
        public override int numberOf(Person[] peeps)
        {
            int count = 0;
            foreach (Person p in peeps)
            {
                if (p.GetType() == typeof(Customer))
                    count++;
            }
            Console.WriteLine("there are " + count + " normal customers ");
            return count;
        } // end of numerOFPeople method


        public override void getPeople(Person[] peeps) // displays first anme of vips
        {
            int count = 1;
            foreach (Person p in peeps)
            {
                if (p.GetType() == typeof(Customer))
                {
                    Console.WriteLine(count + ". " +p.accessFirstName + " is a normal customer ");
                    count++;
                }
            }
        }// end of get people mthod

        /*
         * Finds Persons born on leayear 
         * @override : displays Person details, and starsign
         * Makes use of getStarSign() method to get starsign value
         */
        public override void LeapYearAndZodiac()
        {
            String dob = accessDob;
            DateTime date = Convert.ToDateTime(dob);
            int month = date.Month;
            if (leapYear(dob))
            {
                Console.WriteLine("");               
                Console.WriteLine("ID \t \t" + accessID);
                Console.WriteLine("Name \t \t" + accessFirstName + " " + accessLastName);
                Console.WriteLine("Birth Date \t" + accessDob);
                Console.WriteLine("Balance \t" + "$" + accessBalance.ToString("F"));
                Console.WriteLine("Zodiac \t \t" + getStarSign(month));
                Console.WriteLine("-----------------------------------------");
            } // end of if leapyear loop
        }// end of leapyear method


        /*
         * Method conducts the withdrawing activity
         * Makes use of getAmount() method to obtain value to withdraw
         * Updates consol display  
         * @override : fee added, display differs
         */
        public override void withdraw()
        {
            displayAccount();
            Amount = getAmount("Withdraw");
            Double oldbalance = accessBalance;
            Double newbalance = oldbalance - Amount - fee;
            if(newbalance >= 0) // enough in account to cover withdraw and fees
            {
                fails = 0;
                actions = actions + 1;
                balance = oldbalance - Amount - fee;
                Console.WriteLine();
                Console.WriteLine("Withdrawing  $" + Amount.ToString("F") + "   from " + accessFirstName + " " + accessLastName + "'s account \t (A $" + fee + "fee applies)");
                Console.WriteLine("");
                Console.WriteLine("New Balance : \t $" + balance.ToString("F"));
                Console.WriteLine();
                Console.WriteLine("Press any key to return to main menu");
                Console.ReadKey();
            }
            else // if insufficient funds
            {
                fails++;
                if (fails == 3)
                {
                    Console.Clear();
                    Console.WriteLine("--------------------------------------------------");
                    Console.WriteLine("Transaction failed 3 times, Returning to main menu");
                    Console.WriteLine("--------------------------------------------------");
                    Task.Delay(2000).Wait();
                    return;
                }
                Console.WriteLine("Insufficient Funds : Enter Another Amount");
                Task.Delay(2000).Wait();
                ClearLastLine();
                ClearLastLine();
                ClearLastLine();
                ClearLastLine();
                withdraw();
            }// end of insuccifent funds check
        }// end of withdraw method

        /*
        * Method conducts the depositing activity
        * Makes use of getAmount() method to obtain value to withdraw
        * Updates console display  
        * @override : fee added, display differs
        */
        public override void deposit()
        {
            displayAccount();
            Amount = getAmount("Deposit");
            balance = accessBalance + Amount - fee;
            actions = actions + 1;
            Console.WriteLine();
            Console.WriteLine("Despoiting  $" + Amount.ToString("F") + " into " + accessFirstName + " " + accessLastName + "'s account \t (A $" + fee + "fee applies)");
            Console.WriteLine("");
            Console.WriteLine("New Balance : \t $" + balance.ToString("F"));
            Console.WriteLine();
            Console.WriteLine("Press any key to return to main menu");
            Console.ReadKey();
        }


    }
}
