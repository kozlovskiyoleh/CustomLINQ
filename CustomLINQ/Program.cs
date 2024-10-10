// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;

namespace CustomLinq
{
    public class Car
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public int ManufactureDate { get; set; }
    }

    public static class LinqExtensions
    {
        public static IEnumerable<T> CustomWhere<T>(this IEnumerable<T> collection, Predicate<T> predicate)
        {
            foreach (var item in collection)
                if(predicate(item)) 
                    yield return item;
        }

        public static List<T> CustomToList<T>(this IEnumerable<T> collection)
        {
            List<T> values = new List<T>();
            foreach(var item in collection)
                values.Add(item);
            return values;
        }

        public static IEnumerable<Tout> CustomSelect<Tin, Tout>(this IEnumerable<Tin> collection,  Func<Tin,Tout> func)
        {
            foreach(var item in collection)
                yield return func(item);
        }

        public static T FistOrDefault<T>(this IEnumerable<T> collection, Predicate<T> filter)
        {
            if (collection.Any())
                foreach(var item in collection)
                    if(filter(item))
                        return item;
            return default(T);
        }

        public static IEnumerable<T> CustomTake<T>(this IEnumerable<T> collection, int count)
        {
            foreach(var item in collection)
            {
                if (count == 0)
                    yield break;
                yield return item;
                count--;
            }
        }
    }

    public class Program
    {
        public static void Main()
        {
            List<Car> cars = new List<Car>() 
            {
                new Car { Id = 1, Manufacturer = "Skoda", Model = "Octavia", ManufactureDate = 2007},
                new Car { Id = 2, Manufacturer = "Skoda", Model = "SuperB", ManufactureDate = 2014},
                new Car { Id = 3, Manufacturer = "Mazda", Model = "3", ManufactureDate = 2004},
                new Car { Id = 4, Manufacturer = "Opel", Model = "Vectra", ManufactureDate = 1999},
                new Car { Id = 5, Manufacturer = "Honda", Model = "Civic", ManufactureDate = 2016},
                new Car { Id = 6, Manufacturer = "Audi", Model = "A7", ManufactureDate = 18},
            };

            var customWhereResult = cars.CustomWhere(x => x.Id == 1).CustomToList();
            var customSelectResult = cars.Select(x => x.Model).CustomToList();
        }
    }
}