using System;

namespace Sklep
{
    class Screens
    {
        private int choice;
        public User current;
        private void Logo()
        {
            Console.ResetColor();
            Console.SetCursorPosition(10, 0);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(@"

░██████╗██╗░░██╗██╗░░░░░███████╗██████╗░
██╔════╝██║░██╔╝██║░░░░░██╔════╝██╔══██╗
╚█████╗░█████═╝░██║░░░░░█████╗░░██████╔╝
░╚═══██╗██╔═██╗░██║░░░░░██╔══╝░░██╔═══╝░
██████╔╝██║░╚██╗███████╗███████╗██║░░░░░
╚═════╝░╚═╝░░╚═╝╚══════╝╚══════╝╚═╝░░░░░
");
        }

        public void Register()
        {
            string username, password, name, lastName, mail;

            Console.Clear();
            Logo();

            Console.SetCursorPosition(11, 9);
            Console.WriteLine("Login*:");
            Console.SetCursorPosition(18, 9);
            username = Console.ReadLine();
            if (username == "")
            {
                Console.SetCursorPosition(12, 12);
                Console.WriteLine("Pole wymagane!");
                Console.ReadKey();
                Register();
            }

            Console.SetCursorPosition(11, 10);
            Console.WriteLine("Hasło*:");
            Console.SetCursorPosition(18, 10);
            password = Console.ReadLine();
            if (password == "")
            {
                Console.SetCursorPosition(12, 12);
                Console.WriteLine("Pole wymagane!");
                Console.ReadKey();
                Register();
            }

            Console.SetCursorPosition(13, 11);
            Console.WriteLine("Imie:");
            Console.SetCursorPosition(18, 11);
            name = Console.ReadLine();
            if (name == "") name = "nie podano";

            Console.SetCursorPosition(9, 12);
            Console.WriteLine("Nazwisko:");
            Console.SetCursorPosition(18, 12);
            lastName = Console.ReadLine();
            if (lastName == "") lastName = "nie podano";

            Console.SetCursorPosition(13, 13);
            Console.WriteLine("Mail:");
            Console.SetCursorPosition(18, 13);
            mail = Console.ReadLine();
            if (mail == "") mail = "nie podano";


            Users users = new Users();
            users.AddUser(username, password, name, lastName, mail);

            Console.ReadKey();
        }

        public void Login()
        {
            string login, password;
            Console.Clear();
            Logo();
            Console.SetCursorPosition(12, 9);
            Console.WriteLine("Login:");
            Console.SetCursorPosition(18, 9);
            login = Console.ReadLine();

            Console.SetCursorPosition(12, 10);
            Console.WriteLine("Hasło:");
            Console.SetCursorPosition(18, 10);
            password = Console.ReadLine();
            Console.SetCursorPosition(8, 12);
            Users users = new Users();
            current = users.GetUser(login, password);
            if (current == null)
            {
                Console.WriteLine("Nieprawidlowe dane");
                Console.ReadKey();
                Startup();
            }

            Console.SetCursorPosition(12, 12);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Witaj {current.getUsername}");
            Console.ReadKey();
            Menu();
            }

        public void Startup()
        {

            choice = 0;
            do
            {
                Console.Clear();
                choice = Custom(new string[] { "Logowanie", "Rejestracja", "Koniec" });
                switch (choice)
                {
                    case 0:
                        Login();
                        break;
                    case 1:
                        Register();
                        break;
                    case 2:
                        Environment.Exit(0);
                        break;

                }
            } while (!(choice == 2 || choice == -1));
        }

        public void Profile()
        {
            Console.Clear();
            Logo();
            Console.SetCursorPosition(11, 9);
            Console.WriteLine($"Witaj {current.getUsername}!");
            Console.SetCursorPosition(11, 11);
            Console.WriteLine($"Imie: {current.getName}");
            Console.SetCursorPosition(7, 12);
            Console.WriteLine($"Nazwisko: {current.getLastName}");
            Console.SetCursorPosition(11, 13);
            Console.WriteLine($"Mail: {current.getMail}");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nKliknij dowolny przycisk aby powrócić do menu");

            Console.ReadKey();
        }
        public void StoreAdd(Item item)
        {
            Console.Clear();
            Logo();
            Console.SetCursorPosition(12, 9);
            Console.WriteLine($"Aktualna ilość: {item.Pieces}");
            Console.SetCursorPosition(12, 10);
            Console.WriteLine("Ile sztuk dodać?:");
            Console.SetCursorPosition(30, 10);
            try { item.Add(Convert.ToInt32(Console.ReadLine())); } catch { Unvalid(); }
            Console.SetCursorPosition(12, 11);
            Console.WriteLine($"Aktualna ilość: {item.Pieces}");
            item.Save();
            Console.ReadKey();


        }
        public void StoreNew()
        {
            Console.Clear();
            Logo();

            int category = 1;
            string name = "x";
            string description = "x";
            decimal price = 1;
            int pieces = 1;

            Console.SetCursorPosition(13, 9);
            Console.WriteLine("Typ:");
            Console.SetCursorPosition(20, 9);
            Console.WriteLine("(1 - GPU, 2 - Dysk)");
            Console.SetCursorPosition(18, 9);
            try { category = Convert.ToInt32(Console.ReadLine()); } catch { Unvalid(); }
            Console.SetCursorPosition(11, 10);
            Console.WriteLine("Tytuł:");
            Console.SetCursorPosition(18, 10);
            try { name = Console.ReadLine(); } catch { Unvalid(); }
            Console.SetCursorPosition(12, 11);
            Console.WriteLine("Opis:");
            Console.SetCursorPosition(18, 11);
            try { description = Console.ReadLine(); } catch { Unvalid(); }
            Console.SetCursorPosition(12, 12);
            Console.WriteLine("Cena:");
            Console.SetCursorPosition(18, 12);
            try { price = Convert.ToDecimal(Console.ReadLine()); } catch { Unvalid(); }
            Console.SetCursorPosition(11, 13);
            Console.WriteLine("Ilość:");
            Console.SetCursorPosition(18, 13);
            try { pieces = Convert.ToInt32(Console.ReadLine()); } catch { Unvalid(); }
            if (category == 1)
            {
                decimal ram = 1;
                string company = "asd";
                Console.SetCursorPosition(13, 14);
                Console.WriteLine("Ram:");
                Console.SetCursorPosition(18, 14);
                try { ram = Convert.ToDecimal(Console.ReadLine()); } catch { Unvalid(); }
                Console.SetCursorPosition(11, 15);
                Console.WriteLine("Firma:");
                Console.SetCursorPosition(18, 15);
                try { company = Console.ReadLine(); } catch { Unvalid(); }
                new GPU(name, description, price, pieces, ram, company).Save();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nKliknij dowolny przycisk aby powrócić do menu");
                Console.ReadKey();
            }
            else if (category == 2)
            {
                decimal ram = 1;
                string company = "a";
                bool ssd = true;
                Console.SetCursorPosition(10, 14);
                Console.WriteLine("Pamięć:");
                Console.SetCursorPosition(18, 14);
                try { ram = Convert.ToDecimal(Console.ReadLine());} catch { Unvalid(); }
                Console.SetCursorPosition(11, 15);
                Console.WriteLine("Firma:");
                Console.SetCursorPosition(18, 15);
                try { company = Console.ReadLine(); } catch { Unvalid(); }
                Console.SetCursorPosition(13, 16); 
                Console.WriteLine("Ssd:");
                Console.SetCursorPosition(21, 16); 
                Console.WriteLine("(1 - tak, 0 - nie)");
                Console.SetCursorPosition(18, 16);
                try { ssd = Convert.ToBoolean(Convert.ToInt32(Console.ReadLine())); } catch { Unvalid(); }
                new HardDrive(name, description, price, pieces, ram, company, ssd).Save();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nKliknij dowolny przycisk aby powrócić do menu");
                Console.ReadKey();
            }
            else
            {
                Console.Clear();
                Logo();
                Console.WriteLine("\nBłąd w wprowadzaniu danych");
                Console.ReadKey();
            }
        }

        public void StoreDetail(Item item)
        {
            Console.Clear();
            Logo();
            item.Info();
            Console.WriteLine("\nKliknij dowolny przycisk aby powrócić do menu");

            Console.ReadKey();
        }
        public void StoreDel(Item item)
        {
            Console.Clear();
            Logo();
            bool succes = true;
            Console.SetCursorPosition(12, 9);
            Console.WriteLine($"Aktualna ilość: {item.Pieces}");
            Console.SetCursorPosition(12, 10);
            Console.WriteLine("Ile sztuk odjąć?:");
            Console.SetCursorPosition(31, 10);
            try { succes = item.Del(Convert.ToInt32(Console.ReadLine())); } catch { Unvalid(); }
            Console.SetCursorPosition(12, 11);
            if (succes) 
                Console.WriteLine($"Aktualna ilość: {item.Pieces}");
            else
                Unvalid();
            item.Save();
            Console.ReadKey();
        }
        public void StoreItem(Item item)
        {
            Console.Clear();
            Logo();
            choice = Custom(new string[] { "Wyświetl informacje", "Dodaj szt", "Usun szt" });
            switch (choice) {
                case 0:
                    StoreDetail(item);
                    break;
                case 1:
                    StoreAdd(item);
                    break;
                case 2:
                    StoreDel(item);
                    break;
            }

        }
        public void StoreBrowse()
        {
            Console.Clear();
            Logo();
            choice = 0;
            Console.CursorVisible = false;
            Store store = new Store();
            ConsoleKeyInfo k;
            do
            {
                for (int i = 0; i < store.items.Count; i++)
                {
                    Console.SetCursorPosition(12, 9 + i);
                    if (choice == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("-> ");
                    }
                    else Console.ForegroundColor = ConsoleColor.Red;

                    Console.Write(store.items[i].Name + "           ");
                }
                k = Console.ReadKey(true);
                if (k.Key == ConsoleKey.UpArrow && choice > 0)
                {
                    choice--;
                }
                else
                if (k.Key == ConsoleKey.DownArrow && choice < store.items.Count - 1)
                {
                    choice++;
                }
                else if (k.Key == ConsoleKey.Escape) choice = -1;


            } while (!(k.Key == ConsoleKey.Escape || k.Key == ConsoleKey.Enter));

            Console.ResetColor();
            Console.CursorVisible = true;
            StoreItem(store.items[choice]);
        }


        public void Menu()
        {
            choice = 0;
            do
            {
                Console.Clear();
                choice = Custom(new string[] { "Produkty", "Dodaj Produkt", "Moje konto", "Wyloguj" });
                switch (choice)
                {
                    case 0:
                        StoreBrowse();
                        break;
                    case 1:
                        StoreNew();
                        break;
                    case 2:
                        Console.Clear();
                        Profile();
                        break;
                }


            } while (!(choice == 3 || choice == -1));

        }

        public int Custom(string[] elements)
        {
            Logo();
            choice = 0;
            Console.CursorVisible = false;
            ConsoleKeyInfo k;
            do
            {
                for (int i = 0; i < elements.Length; i++)
                {
                    Console.SetCursorPosition(12, 9 + i);
                    if (choice == i)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("-> ");
                    }
                    else Console.ForegroundColor = ConsoleColor.Red;

                    Console.Write(elements[i] + "   ");
                }
                k = Console.ReadKey(true);
                if (k.Key == ConsoleKey.UpArrow && choice > 0)
                {
                    choice--;
                }
                else
                if (k.Key == ConsoleKey.DownArrow && choice < elements.Length - 1)
                {
                    choice++;
                }
                else if (k.Key == ConsoleKey.Escape) choice = -1;


            } while (!(k.Key == ConsoleKey.Escape || k.Key == ConsoleKey.Enter));

            Console.ResetColor();
            Console.CursorVisible = true;
            return choice;
        }
        public void Unvalid()
        {
            Console.Clear();
            Logo();
            Console.WriteLine("Błąd wprowadzania danych");
            Console.ReadKey();
            Menu();
        }
    }
}
