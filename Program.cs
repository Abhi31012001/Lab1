/**********************************************************************
 * Filename:Lab -1                                      
 * Author: Abhi Pael                                             
 * StudentNo: 040 978 822                                            
 * Course Name/Number: .NET Enterprise Appl. Dev. CST8359                        
 * Lab Sect: 300(Theory) / 301(Pratical)                                               
 * Assignment #:Lab-1          
 * Submission Date:Jan 23, 2021 
 * Professor:Amir Rad          
 * Purpose:This lab is designed to give you a basic understanding of a C# application and provide an opportunity to use many simple C# techniques.                       
 * *********************************************************************/
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
namespace Lab
{
    class Program
    {
        // public static String[] words;
        public static List<string> words = new List<string>();
        public static int counter = 0;
        /********************************************************************
         * Function name: main
         * Purpose:A console menu with the  options. 
         * Author:Abhi Patel (Pate0789)
         * **********************************************************************/
        static void Main(string[] args)
        {

            String userInput = "x";
            do
            {
                Console.WriteLine("\n\nHello World!!! My First C# App\noption\n----------" +
                    "\n1 - Import Words From File \n" +
                    "2 - Bubble Sort words \n" +
                    "3 - LINQ/Lambda sort words \n" +
                    "4 - Count the Distinct Words \n" +
                    "5 - Take the first 10 words \n" +
                    "6 - Get the number of words that start with 'j' and display the count \n" +
                    "7 - Get and display of words that end with 'd' and display the count \n" +
                    "8 - Get and display of words that are greater than 4 characters long, and display the count \n" +
                    "9 - Get and display of words that are less than 3 characters long and start with the letter 'a', and display the count \n" +
                    "x - Exit\n");
                Console.Write("Make a selection: ");
                userInput = Console.ReadLine();
                if (userInput == "1")
                {
                    Console.Clear();
                    importWords();

                }
                else if (userInput == "2")
                {
                    Console.Clear();
                    bubblesort(words);
                }
                else if (userInput == "3")
                {
                    Console.Clear();
                    linq();
                }
                else if (userInput == "4")
                {
                    Console.Clear();
                    dist();
                }
                else if (userInput == "5")
                {
                    Console.Clear();
                    firstTen();
                }
                else if (userInput == "6")
                {
                    Console.Clear();
                    jstart();
                }
                else if (userInput == "7")
                {
                    Console.Clear();
                    dend();
                }
                else if (userInput == "8")
                {
                    Console.Clear();
                    greater();
                }
                else if (userInput == "9")
                {
                    Console.Clear();
                    lessthan();

                }
                else if (userInput == "x")
                {
                    Console.Clear();
                    System.Environment.Exit(0);
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Input", Console.ForegroundColor);
                    Console.ResetColor();
                }
            } while (userInput != "x");
        }
        /********************************************************************
        * Function name: importWords
        * Purpose:A method that takes the words from a text file and stores them in an array or List. 
        * Author:Abhi Patel (Pate0789)
        * **********************************************************************/
        static void importWords()
        {
            string line;
            Console.WriteLine("Reading Words");
            using (StreamReader reader = new StreamReader("C:\\Users\\abhip\\source\\repos\\Lab-1\\Lab-1\\Words.txt"))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    words.Add(line);
                    counter = counter + 1;
                    //  Console.Write(words + "\t");
                }
                Console.WriteLine("Reading Words complete");
                Console.WriteLine("Number of words found: " + counter);
            }
        }
        /********************************************************************
         * Function name: bubblesort
         * Purpose:A method that accepts a list or array of strings and provides a bubble sort on the collection. 
         * Author:Abhi Patel (Pate0789)
         * **********************************************************************/
        static IList<string> bubblesort(List<string> words)
        {
            String[] wast = new string[words.Count];
            for (int i = 0; i < words.Count; i++)
            {
                wast[i] = words[i];
            }
            Stopwatch sw = new Stopwatch();
            sw.Start();
            string temp;

            for (int i = 0; (i < wast.Length); i++)
            {

                for (int j = 0; j < wast.Length - 1; j++)
                {
                    if (wast[j].CompareTo(words[j + 1]) > 0)
                    {
                        temp = wast[i];
                        wast[j] = wast[j + 1];
                        wast[j + 1] = temp;

                    }
                }
            }

            sw.Stop();

            Console.Write("Time elapsed: " + sw.ElapsedMilliseconds + "ms\n");



            return words.ToArray();
        }

        /********************************************************************
         * Function name: linq() 
         * Purpose:A LINQ query or a Lambda expression to sort your list of strings. 
         * Author:Abhi Patel (Pate0789)
         * **********************************************************************/
        static void linq()
        {
            String[] wast = new string[words.Count];
            for (int i = 0; i < words.Count; i++)
            {
                wast[i] = words[i];
            }
            Stopwatch sw = new Stopwatch();
            sw.Start();

            var lengths = from element in wast
                          orderby element.Length
                          select element;

            sw.Stop();
            Console.Write("Time elapsed: " + sw.ElapsedMilliseconds + "ms\n");
        }

        /********************************************************************
         * Function name: dist 
         * Purpose: Use a LINQ query or Lambda expression to count all the distinct words. 
         * Author:Abhi Patel (Pate0789)
         * **********************************************************************/
        static void dist()
        {
            String[] di;
            di = words.Cast<string>().Distinct().ToArray();

            Console.Write("The number of distinct words is: " + di.Length);
        }

        /********************************************************************
         * Function name: firstTen
         * Purpose: Use a LINQ query or a Lambda expression to ‘take’ only the first 10 words in the list. 
         * Author:Abhi Patel (Pate0789)
         * **********************************************************************/
        static void firstTen()
        {
            var ft = words.Take(10);

            foreach (var f in ft)
            {
                Console.WriteLine(f);
            }
        }
        /********************************************************************
         * Function name: jstart
         * Purpose: Use a LINQ query or Lambda expression to count the number of words that start with ‘j’. 
         * Author:Abhi Patel (Pate0789)
         * **********************************************************************/
        static void jstart()
        {
            var jsat = from st in words
                       where st.StartsWith("j")
                       select st;
            int num = 0;
            foreach (var n in jsat)
            {
                Console.WriteLine(n);
                num++;

            }
            Console.WriteLine("Number of words that start with 'J': " + num);


            //int numofmem = 0;

        }
        /********************************************************************
         * Function name: dend
         * Purpose: Use a LINQ query or Lambda expression to find all the words that end with ‘d’. 
         * Author:Abhi Patel (Pate0789)
         * **********************************************************************/
        static void dend()
        {
            var de = from st in words
                     where st.EndsWith("d")
                     select st;
            int num = 0;
            foreach (var n in de)
            {
                Console.WriteLine(n);
                num++;
            }
            Console.WriteLine("Number of words that end with 'd': " + num);
        }
        /********************************************************************
         * Function name: greater
         * Purpose: Use a LINQ query or Lambda expression to find all the words that are greater than 4 characters’ long. 
         * Author:Abhi Patel (Pate0789)
         * **********************************************************************/
        static void greater()
        {
            var gret = from st in words
                       where st.Length > 4
                       select st;
            /* string[] l = new string[words.Count]; int k = 0;
             for (int j = 0; j < words.Count; j++) {
                 if (words.Count > 4) {
                     words[j] = l[k];
                     k++;
                 }
             }*/
            int sum = 0;
            foreach (var n in gret)
            {
                Console.WriteLine(n);
                sum++;
            }
            Console.WriteLine("Number of words longer than 4 characters: " + sum);
        }
        /********************************************************************
         * Function name: lessthan
         * Purpose: Use a LINQ query or Lambda expression to find all the words that are greater than 4 characters’ long. 
         * Author:Abhi Patel (Pate0789)
         * **********************************************************************/
        static void lessthan()
        {
            var lesss = from less in words
                        where less.Length < 3 && less.StartsWith("a")
                        select less;
            int sum = 0;
            foreach (var n in lesss)
            {
                Console.WriteLine(n);
                sum++;
            }
            Console.WriteLine("Number of words Longer less than 3 characters and start with 'a': " + sum);
        }

    }
}
