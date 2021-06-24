using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace Sklep
{
    abstract class Item
    {
        protected string path;
        protected string name, description;
        protected decimal price;
        protected int pieces, category;

        public string Name { get => name; }
        public string Description { get => description; }
        public decimal Price { get => price; }
        public int Pieces { get => pieces; }
        public int Category { get => category; }
        

        public Item(int category, string name, string description, decimal price, int pieces)
        {
            this.category = category;
            this.name = name;
            this.description = description;
            this.price = price;
            this.pieces = pieces;
            this.path = Directory.GetCurrentDirectory() + "/items/" + name + ".txt";
        }

        public bool Del(int pieces)
        {
            if (this.pieces - pieces >= 0)
            {
                this.pieces -= pieces;
                return true;
            }
            return false;
        }
        public void Add(int pieces)
        {
            this.pieces += pieces;
        }
        public virtual void Info()
        {
            Console.WriteLine("Nazwa: " + name);
            Console.WriteLine("Opis: " + description);
            Console.WriteLine("Cena: " + price);
            Console.WriteLine("Ilość w magazynie: " + pieces);
        }
        public virtual void Save()
        {

            if (File.Exists(path))
                File.Delete(path);

            using (StreamWriter sw = File.CreateText(path))
            {
                sw.WriteLine(category);
                sw.WriteLine(name);
                sw.WriteLine(description);
                sw.WriteLine(price);
                sw.WriteLine(pieces);
            }
        }
    }

    class GPU:Item   // ID : 1
    {
        private decimal ram;
        private string company;
        public decimal Ram { get => ram; }
        public string Company { get => company; }
        public GPU(string name, string description, decimal price, int pieces, decimal ram, string company) : base(1, name, description, price, pieces)
        {
            this.ram = ram;
            this.company = company;
        }
        public override void Info()
        {
            base.Info();
            Console.WriteLine("Ram: " + ram);
            Console.WriteLine("Firma: " + company);
        }
        public override void Save()
        {
            base.Save();
            using (StreamWriter sw = File.AppendText(base.path))
            {
                sw.WriteLine(ram);
                sw.WriteLine(company);
            }
        }
    }

    class HardDrive : Item // ID: 2
    {
        private decimal memory;
        private string company;
        private bool ssd;

        public decimal Memory { get => memory; }
        public string Company { get => company; }
        public string Ssd
        {
            get
            {
                if (ssd) return "Ssd";
                else return "Hdd";
            }
        }
        public HardDrive( string name, string description, decimal price, int pieces, decimal memory, string company, bool ssd) : base(2 ,name, description, price, pieces)
        {
            this.memory = memory;
            this.company = company;
            this.ssd = ssd;
        }
        public override void Info()
        {
            base.Info();
            Console.WriteLine("Pamięć: " + memory);
            Console.WriteLine("Firma: " + company);
            Console.WriteLine("Typ: " + Ssd);
            
        }
        public override void Save()
        {
            base.Save();
            using (StreamWriter sw = File.AppendText(base.path))
            {
                sw.WriteLine(memory);
                sw.WriteLine(company);
                sw.WriteLine(ssd);

            }
        }
    }
}

