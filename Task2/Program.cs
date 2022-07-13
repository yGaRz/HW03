using System;
using System.Collections.Generic;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            SurnameSort ss = new SurnameSort();
            ss.AddSurname("Ivanov");
            ss.AddSurname("Petrov");
            ss.AddSurname("Sidorov");
            ss.AddSurname("Kozlov");
            ss.AddSurname("Petrenko");
            ss.AddSurname("Smirnov");

            ss.surnameSortEvent += lstPrint;

            while (true)
            {
                ss.Read();

            }
        }
        static void lstPrint(List<string> lst, int num)
        {
            if (num == 1)
                Console.WriteLine("Сортировка по возрастанию:");
            else
            if (num == 2)
                Console.WriteLine("Сортировка по возрастанию:");
            Console.WriteLine($"List count = {lst.Count}:");
            for (int i = 0; i < lst.Count; i++)
                Console.WriteLine(lst[i]);
        }
    }
    class SurnameSort
    {
        public delegate void SurnameSortDelegate(List<string> lst, int num);
        public event SurnameSortDelegate surnameSortEvent;

        private List<string> listSurname;
        public SurnameSort()
        {
            listSurname = new List<string>();
            surnameSortEvent += lstSort;
        }
        public void AddSurname(string surname)
        {
            if (surname != null)
                listSurname.Add(surname);
        }
        private void lstSort(List<string> lst, int num)
        {
            lst.Sort((a1, a2) => num == 1 ? String.Compare(a1, a2) : String.Compare(a2, a1));
        }

        public void Read()
        {
            Console.WriteLine("Input 1 or 2:");
            int num = int.Parse(Console.ReadLine());
            if (num != 1 && num != 2)
                throw new ArgumentException();
            surnameSortEvent.Invoke(listSurname,num);
        }



    }
}
