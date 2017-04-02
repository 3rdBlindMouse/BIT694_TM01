using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _694Assignment1
{
    class VIPCustomer : Person // VIPCustomer is a subclass of Person
    {
        /*
         * Base Constructor for VIPCustomer type Person
         * used primarily for testing and accessing VIPCustomer methods 
         */
        public VIPCustomer()
        { }
        /*
         * Main Constructor for VIPCustomer type Person
         * inherits all variables from Person Class
         */
        public VIPCustomer(String firstName, String lastName, String dob, String id, Double balance) :
            base(firstName, lastName, dob, id, balance)
        { }
        /*
         * Displays some details of VIP customers
         */
        public override void displayDetails()
        {
            Console.WriteLine(firstname + " " + lastName + " is a VIP and has " + balance + " in their account");
        }
        /*
         * Method counts and displays number of People 
         * @override : Displays the number of VIPCustomer type Persons
         */
        public override int numberOf(Person[] peeps)
        {
            int count = 0;
            foreach (Person p in peeps)
            {
                if(p.GetType() == typeof(VIPCustomer))
                count++;
            }
            Console.WriteLine("there are " + count + " VIPS ");
            return count;
        }
        /*
         * Displays a numbered list with first name of all VIPCustomer type Persons
         */
        public override void getPeople(Person[] peeps) 
        {
            int count = 1;
            foreach (Person p in peeps)
            {
                if (p.GetType() == typeof(VIPCustomer))
                {
                    Console.WriteLine(count+ ". " +p.accessFirstName + " is a VIP ");
                    count++;
                }
            }
        }// end of getPeople Method

        /*
         * Displays first and last names and balance of Person
         * @at override : adds VIP to display
         */
        public override void displayAccount()
        {
            //Console.WriteLine();
            Console.WriteLine("This is the account of " + accessFirstName + " " + accessLastName + "(VIP). \t Current Balance $" + accessBalance.ToString("F"));
            Console.WriteLine();
        }

        /*
         * Finds Persons born on leayear 
         * @override : displays Person details, if VIP, and starsign
         *  Makes use of getStarSign() method to get starsign value
         */
        public override void LeapYearAndZodiac()
        {
            String dob = accessDob;
            DateTime date = Convert.ToDateTime(dob);
            int month = date.Month;
            if (leapYear(dob))
            {
                Console.WriteLine("");
                Console.WriteLine("VIP Customer ");
                Console.WriteLine("ID \t \t" + accessID);
                Console.WriteLine("Name \t \t" + accessFirstName + " " + accessLastName);
                Console.WriteLine("Birth Date \t" + accessDob);
                Console.WriteLine("Balance \t" + "$" + accessBalance.ToString("F"));
                Console.WriteLine("Zodiac \t \t" + getStarSign(month));
                Console.WriteLine("-----------------------------------------");
            } // end of if leapyear loop
        }

        /*
        * Method conducts the withdrawing activity
        * Makes use of getAmount() method to obtain value to withdraw
        * Updates consol display  
        * @override :  display differs
        */
        public override void withdraw()
        {
            displayAccount();
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
        }//end of wthdraw method

        /*
        * Method conducts the depositing activity
        * Makes use of getAmount() method to obtain value to withdraw
        * Updates console display  
        * @override :  display differs
        */
        public override void deposit()
        {
            displayAccount();
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
        }// end of deposit method
    }// end of class VIPCustomer
}// end of namespace
