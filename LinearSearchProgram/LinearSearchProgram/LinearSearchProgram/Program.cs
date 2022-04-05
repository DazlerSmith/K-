using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinearSearchProgram
{
    class Program
    {
        static void Main(string[] args)
        {
            // declare variables
            const int MaxListSize = 30;
            string MenuItem;
            int NumberOfFriendsStored, ListSize;
            string[] NameList = new string[MaxListSize];
            // program loop
            do
            {
                // get size of the list
                ListSize = OutputNumberOfNamesInList(ref NameList, MaxListSize);
                // display menu and get menu choice
                MenuItem = GetMenuChoice();
                // do something with the menu choice
                switch (MenuItem)
                {
                    case "1":
                        AddNameToList(ref NameList, ListSize);
                        break;
                    case "2":
                        PrintListOfNames(ref NameList, ListSize);
                        break;
                    case "3":
                        LinearSearch(ref NameList, ListSize);
                        break;
                    case "5":
                        break;
                    default:
                        Console.WriteLine("invalid selection");
                        break;
                }
            }
            while (MenuItem != "5");
            Console.WriteLine("end of program");
            Console.ReadLine();
        }

        public static void LinearSearch(ref string[] TheList, int ListSize)
        {
            //code is here
            string namerequired;
            namerequired = Console.ReadLine();
            bool found = false;
            int subscript = 1;
            while (found == false && subscript <= ListSize) 
            {
                if (TheList[subscript] == namerequired)
                {
                    found = true;
                }
                else
                {
                    subscript++;
                }
            }
            if (found == true)
            {
                Console.WriteLine(namerequired + " found in position " + subscript);
            }
            else
            {
                Console.WriteLine(namerequired + " does not exist. ");
            }
        }

        public static void AddNameToList(ref string[] TheList, int ListSize)
        {
            Console.WriteLine("enter the new name");
            string NewName = Console.ReadLine();
            int Count = -1;
            int CompResult = 0;
            do
            {
                Count++;
                if (TheList[Count] != null)
                {
                    CompResult = String.CompareOrdinal(TheList[Count], NewName);
                }
                else
                {
                    break;
                }
            }
            while (CompResult < 0);
            if (CompResult > 0)
            {
                for (int Place = ListSize; Place >= Count; Place--)
                    TheList[Place + 1] = TheList[Place];
                TheList[Count] = NewName;
            }
            else
                TheList[Count] = NewName;
        }

        public static void PrintListOfNames(ref string[] TheList, int ListSize)
        {
            Console.WriteLine();
            Console.WriteLine("The current list:");
            for (int i = 0; i < ListSize; i++)
            {
                if (TheList[i] != null) Console.WriteLine(TheList[i]);
            }
        }

        public static int OutputNumberOfNamesInList(ref string[] TheList, int ListSize)
        {
            int count = 0;
            for (int i = 0; i < ListSize; i++)
            {
                if (TheList[i] != null) count++;
            }
            return count;
        }

        public static string GetMenuChoice()
        {
            //display menu
            Console.WriteLine();
            Console.WriteLine("1) Add a name to the list");
            Console.WriteLine("2) Show list of names");
            Console.WriteLine("3) Search for an item in the list");
            Console.WriteLine("4) Exit program");
            Console.WriteLine();
            Console.WriteLine("Enter your menu choice number");
            // get choice and return the value
            return Console.ReadLine();
        }
    }
}
