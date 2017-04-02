using System;
using System.IO;
using System.Text.RegularExpressions;

namespace _694Assignment1
{
    class FileValidator
    {
        private static int lines; // counting the lines for validting format
        private static TextReader tr;

        /*
         * Method checks for file existence
         * @param a file path
         */
        public Boolean fileExists(String source)
        {
            try // file reader
            {
                tr = new StreamReader(source);
                return true;
            }// end of reading file try
            catch (FileNotFoundException)
            {                
                return false;
            }// end of file not found catch 
        }


        /*
         * Method Checks for Line validation
         * Calls validate method (call different method for different line formats)
         */
        public Boolean validateFormat(String source)
        {
            String myLine;
            lines = 0;
            while ((myLine = tr.ReadLine()) != null)
            {
                if (validate(myLine) == true)   // if line in file is valid             
                {
                    lines++; // increment line number for each validly formatted line
                }// end of if validating
                else // if a line is not valid in file
                {
                    return false;
                }
            }// end of while myLine != null
            return true;
        }
        
        /*
         *Specific regular expression check 
        * Validate File line formatting
        * Checks each line as being read, if it finds an error 
        * dsiplays line first error is and line contents
        * @param line : a line in text file being read
        */
        static Boolean validate(String line)
        {
            /*
            * Validating format of lines in file to be read
            * Courtesy of 
            * https://txt2re.com/index-csharp.php3?s=bob,jones,01-04-1976,1111,50000,VIP&17&-56&6&-57&2&-58&10
            * Using regulare expression to test
            */
            string txt = line; // grab a line starting from first in file and assign to string txt
            string re1 = "((?:[a-z][a-z]+))";   // Word 1
            string re2 = "(,)"; // Any Single Character 1
            string re3 = "((?:[a-z][a-z]+))";   // Word 2
            string re4 = "(,)"; // Any Single Character 2
            string re5 = "((?:(?:[0-2]?\\d{1})|(?:[3][01]{1}))[-:\\/.](?:[0]?[1-9]|[1][012])[-:\\/.](?:(?:[1]{1}\\d{1}\\d{1}\\d{1})|(?:[2]{1}\\d{3})))(?![\\d])";   // DDMMYYYY 1
            string re6 = "(,)"; // Any Single Character 3
            string re7 = "(\\d+)";  // Integer Number 1
            Regex r = new Regex(re1 + re2 + re3 + re4 + re5 + re6 + re7, RegexOptions.IgnoreCase | RegexOptions.Singleline);
            Match m = r.Match(txt);
            /*
                * Test to see if lines are correctly formatted
                * if successful program will continue
                * if unsuccessful ie. badly formatted line
                * program will display line number and line text (if any)
                * after 0 second delay
                * progarm will close
                */
            if (m.Success)
            { return true; }
            else
            {
                lines++;
                Console.WriteLine("Lines in file are not correctly formatted ");
                Console.WriteLine();
                Console.WriteLine("Displaying first incorrectly formatted line number " + lines); // display incorrect line number
                Console.WriteLine();
                Console.WriteLine(line); // display first incorrectly formatted line
                Console.WriteLine();
                //Task.Delay(10000).Wait();
                return false; // exit program  
            }
        } // end of validate method


    }// end of class FileSelector
}// end of namespace

