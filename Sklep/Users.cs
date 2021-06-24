using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Sklep
{
    class Users
    {
        private List<User> users = new List<User>();
        private string path;
        

        public Users ()
        {
            this.path = AppDomain.CurrentDomain.BaseDirectory + "/users/";

            if (Directory.Exists(path))
                ImportUsers();
            else
            {
                Directory.CreateDirectory(path);
                ImportUsers();
            }

        }

        public void ImportUsers()
        {
            
            string[] filePaths = Directory.GetFiles(path);
            
            foreach (string file in filePaths)
            {
                string[] tmp = File.ReadAllLines(file);
                users.Add(new User(tmp[0], tmp[1], tmp[2], tmp[3], tmp[4]));
            }
        }

        public User GetUser(string login, string password)
        {
            foreach (User data in users)
            {
                if (data.Login(login, password))
                {
                    return data;

                }
            }
            return null;
        }

        public void AddUser(string username, string password, string name, string lastName, string mail) 
        {
            string file = path + username + ".txt";
            if (File.Exists(file))
                File.Delete(file);

            using (StreamWriter sw = File.CreateText(file))
            {
                sw.WriteLine(username);
                sw.WriteLine(password);
                sw.WriteLine(name);
                sw.WriteLine(lastName);
                sw.WriteLine(mail);
            }
        }
    }


    class User
    {
        private string username, name, lastName, mail;
        private string password;

        public User(string name, string password) {
            this.username = name;
            this.password = password;
        }
        public User(string username, string password, string name, string lastName, string mail)
        {
            this.username = username;
            this.password = password;
            this.lastName = lastName;
            this.name = name;
            this.mail = mail;
        }

        public string getUsername { get => this.username; }
        public string getName { get => this.name; }
        public string getLastName { get => this.lastName; }
        public string getMail { get => this.mail; }


        public bool Login(string username, string password)
        {
            if ((this.username == username) && (this.password == password))
                    return true;
            return false;
        }  
    }



}
