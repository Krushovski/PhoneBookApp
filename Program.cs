using System;

namespace PhoneBookApp
{
    class PhoneBook
    {
        private static Tuple<string, string>[] contacts;
        private static int contactsCnt = 0;
        static void Main(string[] args)
        {
            contacts = new Tuple<string, string>[100];

            while (true)
            {
                Console.Clear();
                Console.WriteLine(" Type => |a : Add contact| - |f : Find contact| - |e : Exit| - |v : View all available contacts|");
                Console.WriteLine("-------------------------------------------------------------------------------------------------");
                char command = Console.ReadKey(true).KeyChar;
                if (command == 'a') { }
                else if (command == 'f') { }
                else if (command == 'e') { }
                else if (command == 'v') { }
                else
                {
                    Console.Clear();
                    Console.WriteLine("Incorrect command.Press any key to continue.After that enter a, f, e or v..");
                    Console.ReadKey(true);
                    continue;
                }
                switch (command)
                {
                    case 'a':
                        AddContact();
                        break;
                    case 'f':
                        Console.Clear();
                        int i = 0;
                        Tuple<string, string>[] findContact;
                        while (i < contacts.Length && contacts[i] != null)
                        {
                            i++;
                        }
                        findContact = new Tuple<string, string>[i];
                        i = 0;
                        while (i < contacts.Length && contacts[i] != null)
                        {
                            findContact[i] = contacts[i];
                            i++;
                        }
                        Console.Write("Type name:");
                        string name = Console.ReadLine();
                        Console.Clear();
                        int idxOfName = FindBinary(name, findContact);
                        if (idxOfName == -1)
                            Console.WriteLine("Name not found in phonebook..Try again.");
                        else
                            Console.WriteLine($"Name: {contacts[idxOfName].Item1}, Number: {contacts[idxOfName].Item2}");

                        Console.WriteLine("Press any key to continue..");
                        Console.ReadKey(true);
                        break;
                    case 'v':
                        ViewContacts();
                        Console.ReadKey(true);
                        break;
                    case 'e':
                        return;
                }
            }
        }
        public static void AddContact() //inserting contacts in the correct order(could also be made with BSA)
        {
            Console.Clear();
            if (contactsCnt == contacts.Length - 1)
            {
                Console.WriteLine("You can't add more contacts.Press any key to return to the menu options.");
                Console.ReadKey(true);
                return;
            }
            Console.Write("Enter Name:");
            string name = Console.ReadLine();
            Console.Write("Enter Number:");
            string number = Console.ReadLine();

            int i = 0;
            while (contacts[i] != null && String.Compare(name, contacts[i].Item1) > 0)
            {
                i++;
            }
            if (contacts[i] == null)
            {
                contacts[i] = new Tuple<string, string>(name, number);
                contactsCnt++;
                return;
            }
            for (int k = contactsCnt - 1; k >= i; k--)
            {
                contacts[k + 1] = contacts[k];
            }
            contacts[i] = new Tuple<string, string>(name, number);
            contactsCnt++;
        }
        public static void ViewContacts()//Shows the list of contacts in the correct order
        {
            Console.Write("Displaying contacts");
            for (int i = 0; i < 4; i++)
            {
                Console.Write(".");
                Thread.Sleep(150);
            }
            Console.WriteLine();
            for (int i = 0; i < contacts.Length && (contacts[i] != null); i++)
            {
                Console.WriteLine($"Name: {contacts[i].Item1} ; Phone Number: {contacts[i].Item2}");
                Thread.Sleep(1000 / (i + 1));
            }
            Console.WriteLine();
            Console.WriteLine("Press any key to continue...");
        }
        public static int FindBinary(string findName, Tuple<string, string>[] findContact)//BinarySearchAlgorithm
        {
            int left = 0;
            int right = findContact.Length - 1;
            while (left <= right)
            {
                int middle = (left + right) / 2;
                int compare = String.Compare(findContact[middle].Item1, findName);
                if (compare < 0)
                    left = middle + 1;
                else if (compare > 0)
                    right = middle - 1;
                else
                    return middle;
            }
            return -1;
        }
    }
}









