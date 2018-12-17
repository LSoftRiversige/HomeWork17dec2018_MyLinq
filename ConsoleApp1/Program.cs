using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace ConsoleApp1
{
    public class Car
    {
        private int id;
        public string Name { get; set; }
        public int Id { get => id; set => id = value; }

        public Car(string name)
        {
            Name = name;
        }

        public override string ToString()
        {
            return $"{Name} Id = {Id}";
        }

        public static Car operator +(Car car1, Car car2)
        {
            return new Car($"{car1.Name}+{car2.Name}") { Id=car1.Id+car2.Id};
        }
    }

    class Program
    {

        public static IEnumerable<T> Shuffle<T> (IEnumerable<T> values)
        {
            var r = new Random();
            return values.OrderBy(v => r.Next());
        }

        public class Book
        {
            public string Name { get; set; }
            public string Author { get; set; }
            public int Year { get; set; }
        }

        public static IEnumerable<T> Paging<T>(IEnumerable<T> values, int pageNumber, int elementsInPage)
        {
            return values.Skip(elementsInPage * (pageNumber-1)).Take(elementsInPage);
        }

        class TempEmp
        {
            string empName;
            int id;
            string carModel;

            public TempEmp(string empName, int id, string carModel)
            {
                this.empName = empName;
                this.id = id;
                this.carModel = carModel;
            }

            public override string ToString()
            {
                return $"{empName} {id} {carModel}";
            }
        }

        static void Main(string[] args)
        {

            int[] a1 = {1, 2 };
            int[] a2 = {10, 20, 30, 40, 1};

            //foreach (var val in a1.Zip(a2, (x, y)=>x+y))
            //{
            //    Console.WriteLine(val);
            //}

            //foreach (var val in a1.Union(a2))
            //{
            //    Console.WriteLine(val);
            //}

            foreach (var val in a1.Except(a2))
            {
                Console.WriteLine(val);
            }

            //Console.WriteLine(a1.SequenceEqual(a2));


            Employee[] employees = Employee.GetEmployeesArray();
            EmployeeOptionEntry[] empOptions = EmployeeOptionEntry.GetEmployeeOptionEntries();
            var cars = new List<Car>() {
                new Car("Tesla") { Id=1},
                new Car("Saab") { Id=2},
                new Car("Honda") { Id=3}
            };

            var cars1 = new List<Car>() {
                new Car("Tesla1") { Id=1},
                new Car("Saab1") { Id=2},
                new Car("Honda1") { Id=3},
                new Car("Honda1") { Id=3},
                new Car("Honda5") { Id=3},
                new Car("Honda4") { Id=4},
            };

            //IEnumerable<(Car c1, Car c2)> q = cars.Zip(cars1, (c1, c2) => (c1, c2));

            //foreach (var car in q)
            //{
            //    Console.WriteLine(car);
            //}

            //ILookup<int, Car> q = cars1.ToLookup(c => c.Id);
            //foreach (Car c in q[3])
            //{
            //    Console.WriteLine(c);
            //}

            //Console.WriteLine(cars.Re);

            //foreach (var c in cars1.SkipWhile((c, i)=>i==5))
            //{
            //    Console.WriteLine(c);
            //}

            //var q = cars.Join(cars1, k1 => k1.Id, k2 => k2.Id, (c, c1) => $"{c.Name}-{c1.Name}");
            //IEnumerable<KeyValuePair<Car, Car>> q = cars.Join(cars1, k1 => k1.Id, k2 => k2.Id, (c, c1) => new KeyValuePair<Car, Car>(c, c1));

            //foreach ((Car car, IEnumerable<Car> carList) grp in cars.GroupJoin(cars1, k1 => k1.Id, k2 => k2.Id, (car, carList)=>(car, carList)))
            //{
            //    Console.WriteLine(grp.car.ToString());
            //    foreach (var c in grp.carList)
            //    {
            //        Console.WriteLine(c.ToString());
            //    }
            //}

            //Enumerable

            //foreach (KeyValuePair<Car, Car> j in q)
            //{
            //    Console.WriteLine(j);
            //}

            //foreach (IGrouping<int, Car> g in cars.GroupBy(c=>c.Id))
            //{
            //    Console.WriteLine(g.Key);
            //    foreach (var c in g)
            //    {
            //        Console.WriteLine(c.Name);
            //    }
            //}

            //IEnumerable<TempEmp> q1 = employees
            //    .SelectMany(e=> empOptions.Where(o=>e.id==o.id)
            //    .SelectMany(c=>cars.Where(car=>car.Id==e.id)
            //    .Select(x=>new TempEmp(e.ToString(), e.id, x.Name))));

            //foreach (var item in q1)
            //    Console.WriteLine(item);



            //var arr1 = new int[] { 1, 2, 3, 4};
            //var arr1 = new int[] {1, 1, 1, 1, 1, 3};
            //Console.WriteLine(arr1.Any(i => i >= 4));
            //Console.WriteLine(arr1.Average(i=>i*2));
            //Console.WriteLine(arr1.Cast<string>());
            //Console.WriteLine(arr1.Contains(1, ));
            //var q = arr1.Aggregate(Enumerable.Empty<int>, (x,y)=>x+y);

            //var arr2 = new int[] { 5, 6, 7, 8 };
            //var strs = new List<string>() { "123", "456"};

            //var qSelMany = strs.Select(s=>s);

            //Car MySelector (string s)
            //{
            //    s = s + " tail ";
            //    return new Car(s);
            //};

            //Console.WriteLine(strs.Aggregate("Массив: ", (s1, s2)=> s1+s2, s=>new Car(s)));

            //Console.WriteLine(arr1.Aggregate((x, y)=>x+y));

            //var jArr = arr1.Join(arr2, x => true, y => true, (i1, i2) => new { i1, i2 }).Where(x=>x.i1 != x.i2).SelectMany(x=>$"{x.i1}----{x.i2}");
            //var jArr = arr1.Join(arr2, x => true, y => true, (i1, i2) => new KeyValuePair<int, int>(i1, i2)).Where(x => x.Key != x.Value).SelectMany(p=>);

            //foreach (var p in jArr)
            //{
            //    Console.WriteLine(p);
            //}


            //        Домой: MyLinq

            //• SelectMany
            //• GroupBy(можно написать свой класс, который реализует
            //IGrouping)
            //• Aggregate
            //• Join
            //• GroupJoin
            //• Take, TakeWhile
            //• Skip, SkipWhile




            //var myCount = arr.Aggregate((acc, y) => acc + 1);
            //var myMax = arr.Aggregate((acc, x) => x > acc? x : acc);
            //var myMin = arr.Aggregate((acc, x) => x < acc ? x : acc);
            //var myAvg = arr.Aggregate(0, (acc, x) => acc + x, acc => acc / arr.Length);
            ////var myPares = from a in arr join b in arr equals a != b

            //var myPares = arr.Join(arr, i=>1, i=>1, (i1, i2) => new { i1, i2}).Where(el=>el.i1 != el.i2);

            //foreach (var item in myPares)
            //{
            //    Console.WriteLine($"{item.i1} {item.i2}");
            //}

            //Console.WriteLine(myPares.Count());

            //Console.WriteLine(myAvg);

            //Console.WriteLine("Press any key...");
            //Console.ReadKey();


            //var books = new List<Book>() { new Book() { Name = "LINQ", Year = 2017, Author = "Троелсен" } };

            //var q = books.Where(b => b.Name.Contains("LINQ", StringComparison.InvariantCultureIgnoreCase) && b.Year % 400 == 0 || b.Year % 100 != 0 && b.Year % 4 == 0);

            //// Сколько букв: дана последовательность слов. Сколько
            //// букв алфавита понадобилось для написания этих слов?

            //var words1 = new List<string>() { "sdsadsadas", "asdsadasda"};

            ////var q1 = words1.Select(s=>s.ToUpper()).SelectMany(s=>s).Distinct();
            //var q1 = words1.SelectMany(s=>s);

            //foreach (var c in q1)
            //{
            //    Console.WriteLine(c);
            //}

            //Console.WriteLine("Press any key...");
            //Console.ReadKey();

            ////Упорядочить их по возрастанию старшего разряда, а затем
            ////по убыванию младшего, например, { 14, 12, 23, 20, 33, 32}.

            //var nums = new int[] { 12, 43, 56, 75};

            //var q3 = nums.OrderBy(n => n / 10).ThenByDescending(n=>n % 10);

            //foreach (var nn in q3)
            //{
            //    Console.WriteLine(nn);
            //}

            ////Автора книг: Сколько книг написал каждый автор
            ////(распечатать в два столбца: Автор, Количество)?

            //var q4 = books.GroupBy(b => b.Author).Select(g => new { Author=g.Key, BookCount=g.Count() });
            //foreach (var item in q4)
            //{
            //    Console.WriteLine($"{item.Author} {item.BookCount}");
            //}

            // Перемешка: Написать метод, который принимает
            // обобщенную последовательность и перемешивает ее в
            // произвольном порядке.




            //var letterCount = words.

            //string[] strArray = new string[] { "aaa", "bbb", "ccc", "0000"};

            //IOrderedEnumerable<string> result = strArray.OrderBy(s => s.Length);

            //foreach (string str in result.ThenBy(s=>s))
            //{
            //    Console.WriteLine(str);
            //}

            //var query = strArray.GroupBy(s=>s.Length, s=>s.ToUpper()).GroupBy(g=>g.Key);
            //foreach (var g in query)
            //{
            //    Console.WriteLine(g.Key);
            //    foreach (s in g)
            //    {
            //        Console.WriteLine(s);
            //    }
            //}

            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }

        
    }
}
