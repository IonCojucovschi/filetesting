using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace LinQ_introduction
{
    delegate Collection<Car> CarMan(Collection<Car> a);
  struct Car
    {
        public string Name { get; set; }
        public string Collor { get; set; }
        public int NR { get; set; }
    }
    enum CollorC { red=1,blue=2,white=3,dark=4,green=5,black=6}
    enum CarModel { BMV=1,Opel=2,Mecedes=3,MAzataty=4,audi=5}

    class Program
    {
       

        public static Collection<Car> FoundCar( Collection<Car> list)
        {
            String Name;
            Console.WriteLine("Modelul masinii : ");
            Name = Console.ReadLine();
            var SubList = from cr in list
                where cr.Name == Name
                orderby cr.NR
                select cr;
            var colCar=new Collection<Car>();
            foreach (var cr in SubList)
            {
                colCar.Add(new Car(){Name = cr.Name,NR = cr.NR,Collor = cr.Collor});
            }
            foreach (var cr in colCar)
            {
                Console.WriteLine(cr.Name+"\t\t"+cr.Collor+"\t\t"+cr.NR);
            }

            return colCar;
        }

        public static Collection<Car> OrderByName(Collection<Car> list)
        {
            int x=0;
            var SubList = from cr in list
               orderby cr.Name
                select cr;
            list.RemoveAt(0);
           /* foreach (var cr in SubList)
            {
                list.Add(new Car() { Name = cr.Name, NR = cr.NR, Collor = cr.Collor });
            }*/
            foreach (var cr in SubList)
            {
                Console.WriteLine(new String('-', 40));

                Console.WriteLine(x+"--"+cr.Name+"\t"+cr.Collor+"\t"+cr.NR);
                x++;
            }
            return list;
        }

        static void Main(string[] args)
        {
           Collection<Car> CarList=new Collection<Car>();
            var r=new Random();
            for (int i = 0; i < 10; i++)
            {
                var car = (CarModel) r.Next(1, 5);
                var col = (CollorC) r.Next(1, 7);
                CarList.Add(new Car(){Name=car.ToString(), Collor=col.ToString(),NR=r.Next(100,20000)});
            }
            foreach (var cr in CarList){Console.WriteLine(cr.Name+ "\t\t"+cr.Collor+"\t\t"+cr.NR);}

            Collection<Car> CarFoundList = new Collection<Car>();
            CarMan NameFounderCar = new CarMan(FoundCar);

           NameFounderCar(CarList);///// Gaseste masina dupa nume
            CarMan CarOrderByName = new CarMan(OrderByName);
            CarOrderByName(CarList);
//////////////////////////////////////////////////////////////////////////////////
            Console.WriteLine(new String('-',40));
           ///foreach (var cr in CarList) { Console.WriteLine(cr.Name + "\t\t" + cr.Collor + "\t\t" + cr.NR); }




            Console.ReadLine();
        }
    }
}
