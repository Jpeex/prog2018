using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Spravochka
{
    class Spravochka
    {
        static void Main()
        {
            string action;
            int number;
            string name;
            string adress;

            List<Spravochnik> mylist = new List<Spravochnik>();
            Console.WriteLine("Введите число абонентов в справочнике:");
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                Console.WriteLine("");
                Console.WriteLine("Введите имя абонента:");
                name = Console.ReadLine();
                Console.WriteLine("Введите нумер абонента:");
                number = int.Parse(Console.ReadLine());
                Console.WriteLine("Введите адрес абонента:");
                adress = Console.ReadLine();
                mylist.Add(new Spravochnik(number, adress, name));
            }
            do
            {
                Console.WriteLine("");
                Console.WriteLine(
@"1:Найти по нумеру
2:Найти по адресу
3:Найти по имени
4:выход"
);
                Console.WriteLine("");
                action = Console.ReadLine();
                switch (action)
                {
                    case "1":
                        Console.WriteLine("Введите нумер абонента для поиска:");
                        int nomer = int.Parse(Console.ReadLine());
                        Spravochnik spravkaa = new Spravochnik(nomer, "", "");
                        Spravochnik spravka = mylist.Find(new Predicate<Spravochnik>(spravkaa.Findnumber));
                        if (spravka != null)
                        {
                            Console.WriteLine(spravka);
                        }
                        else
                        {
                            Console.WriteLine("В справочнике нет абонента с таким нумером:");
                        }
                        break;
                    case "2":
                        Console.WriteLine("Введите адресс абонента для поиска:");
                        string adress1 = Console.ReadLine();
                        Spravochnik spravkaa1 = new Spravochnik(0, adress1, "");
                        Spravochnik spravka1 = mylist.Find(new Predicate<Spravochnik>(spravkaa1.Findadrees));
                        if (spravka1 != null)
                        {
                            Console.WriteLine(spravka1);
                        }
                        else
                        {
                            Console.WriteLine("В справочнике нет абонента с таким адресом:");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Введите имя для поиска:");
                        string names = Console.ReadLine();
                        Spravochnik spravkaa2 = new Spravochnik(0, names, "");
                        Spravochnik sspravka = new Spravochnik(0, "", names);
                        mylist.FindAll(new Predicate<Spravochnik>(sspravka.Findname)).ForEach(delegate (Spravochnik s) { Console.WriteLine(s); });
                        if (names != null)
                        {
                            Console.WriteLine(names);
                        }
                        else
                        {
                            Console.WriteLine("В справочнике нет абонента с таким именем:");
                        }
                        break;
                    default:
                        Console.WriteLine("Попробуйте ещё разочек.Вводите значения от 1 до 4:");
                        break;
                }
            } while (action != "4");
        }
    }
    class Spravochnik
    {
        int nomer;
        string adress;
        string name;
        public override string ToString()
        {
            return String.Format("Абонент по имени:{0},зарегистрирован под нумером:{1},проживает по адресу:{2}", name, nomer, adress);
        }
        public Spravochnik(int a, string b, string c)
        {
            this.nomer = a;
            this.adress = b;
            this.name = c;
        }
        public bool Findname(Spravochnik spravka)
        {
            return spravka.name == name; ;
        }
        public bool Findnumber(Spravochnik spravka)
        {
            return spravka.nomer == nomer; ;
        }
        public bool Findadrees(Spravochnik spravka)
        {
            return spravka.adress == adress;
        }
    }
}