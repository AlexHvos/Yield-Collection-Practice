using System.Collections;
//
Agency a1 = new Agency();
a1.Cars = new Car[]{
        new Car(){ ModelYear = 2001 , Maker = "Subaro"},
        new Car(){ ModelYear = 2021 , Maker = "Toyota"},
        new Car(){ ModelYear = 2013 , Maker = "Subaro"},
        new Car(){ ModelYear = 2004 , Maker = "Fiat"},
        new Car(){ ModelYear = 2021 , Maker = "Fiat"},
        new Car(){ ModelYear = 2015 , Maker = "Subaro"}
};
//
System.Console.WriteLine("All cars in the agency:");
foreach (var car in a1)
    System.Console.WriteLine(car);
System.Console.WriteLine("All cars in the agency from 2021:");
foreach (var car in a1.GetCars(2021))
    System.Console.WriteLine(car);
System.Console.WriteLine("All cars in the agency of Fiat:");
foreach (var car in a1.GetCars("Fiat"))
    System.Console.WriteLine(car);


public class Car 
{
    public int ModelYear;
    public string Maker;
    public override string ToString()
    {
        return ($"{ModelYear}, {Maker}");
    }
}

public class Agency 
{
    public Car[] Cars {get; set;}
    public Car[] GetCars(int modelYear) {
        return Cars.Where(item => item.ModelYear == modelYear).ToArray();
    }
    public Car[] GetCars(string maker) {
        return Cars.Where(item => item.Maker == maker).ToArray();
    }
    public IEnumerator GetEnumerator() {
        IEnumerator enumerator = Cars.GetEnumerator();
        while (enumerator.MoveNext())
          yield return enumerator.Current;
    }
}