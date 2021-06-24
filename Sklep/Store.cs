using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Sklep
{
    class Store
    {
        private string path;
        public List<Item> items = new List<Item>();

        public  Store()
        {
            this.path = AppDomain.CurrentDomain.BaseDirectory + "/items/";
            if (Directory.Exists(path))
                ImportItems();
            else
            {
                Directory.CreateDirectory(path);
                ImportItems();
            }

        }
        public void ImportItems()
        {

            string[] filePaths = Directory.GetFiles(path);

            foreach (string file in filePaths)
            {
                string[] tmp = File.ReadAllLines(file);
                if (tmp[0] == "1")
                {
                    items.Add(new GPU(tmp[1], tmp[2], Convert.ToDecimal(tmp[3]), Convert.ToInt32(tmp[4]), Convert.ToDecimal(tmp[5]), tmp[6]));
                }
                else if (tmp[0] == "2")
                {
                    items.Add(new HardDrive(tmp[1], tmp[2], Convert.ToDecimal(tmp[3]), Convert.ToInt32(tmp[4]), Convert.ToDecimal(tmp[5]), tmp[6], Convert.ToBoolean(tmp[7])));
                }
            }
        }
        public void AddItem(int type,string name, string description, decimal price, int pieces,  string opt1 = " ", string opt2 = " ", string opt3=" ")
        {
            string file = path + name + ".txt";
            if (File.Exists(file))
                File.Delete(file);

            using (StreamWriter sw = File.CreateText(file))
            {
                sw.WriteLine(type);
                sw.WriteLine(name);
                sw.WriteLine(description);
                sw.WriteLine(price);
                sw.WriteLine(pieces);
                sw.WriteLine(opt1);
                sw.WriteLine(opt2);
                sw.WriteLine(opt3);
            }
        }
    }
}
