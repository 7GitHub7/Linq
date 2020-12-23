//1. Znaleźć nazwy produktów, które są na stanie, kosztują mniej niż 10 i należą do kategorii Seafood.


static void test(int repetitions, List<Product> products) 
  {
      List<double> times = new List<double>();
      Stopwatch stopwatch = new Stopwatch();
      for (int i = 0;i<repetitions;i++)
      {
        stopwatch.Start();

	    var names = products.Where(x=> x.UnitPrice < 10 && x.Category == "Seafood" && x.UnitsInStock != 0).Select(x=> x.ProductName);  
        names.ToList();

        stopwatch.Stop();
        times.Add((double)stopwatch.Elapsed.TotalSeconds);
        Console.WriteLine($"Time elapsed: {stopwatch.Elapsed}");

      } 
     times.Sort();
	 //Mediana...
    
    
  }
List<Product> products = GetProductList();
test(3,products);cts = GetProductList();
test(3,products);


//2. Dla każdej kategorii znaleźć najtańsze i najdroższe produkty. Zwrócić nazwy kategorii i nazwy produktów. *Napisz zapytanie o złożoności lepszej niż O(k*log(k)*n*n), gdzie n odnosi się do liczby produktów, a k do kategorii.

 
 
static void test(int repetitions, List<Product> products) 
  {
      List<double> times = new List<double>();
      Stopwatch stopwatch = new Stopwatch();
      
      for (int i = 0;i<repetitions;i++)
      {
        stopwatch.Start();
          
	    var categories =  products.GroupBy(t => new  {Category = t.Category}).Select (g => new { Max = Math.Round(g.Max (p => p.UnitPrice),2), Min = g.Min(d => d.UnitPrice), Name = g.Min(d => d.ProductName)});
        
        stopwatch.Start();
        foreach(var product in categories){
            
        }
        stopwatch.Stop();

        times.Add((double)stopwatch.Elapsed.TotalSeconds);
        Console.WriteLine($"Time elapsed: {stopwatch.Elapsed}");

      } 
      times.Sort();
	  //Mediana...
     
    
  }
List<Product> products = GetProductList();
test(1,products);




//3

// Znaleźć cenę, dla której jest najwięcej sztuk produktów (biorąc pod uwagę też unitInStocks). Zwrócić cenę i liczbę sztuk.

static void test(int repetitions, List<Product> products) 
  {
      List<double> times = new List<double>();
      Stopwatch stopwatch = new Stopwatch();
      for (int i = 0;i<repetitions;i++)
      {
        stopwatch.Start();
        var result = products.OrderByDescending(x => x.UnitsInStock).First();

	    Console.WriteLine($"Naza: {result}");
        // Console.WriteLine($"Naza: {product.ProductName} cena: {product.UnitPrice}");

        stopwatch.Stop();
        times.Add((double)stopwatch.Elapsed.TotalSeconds);
        Console.WriteLine($"Time elapsed: {stopwatch.Elapsed}");

      } 
     times.Sort();
	 //Mediana...
    
    
  }
List<Product> products = GetProductList();
test(1,products);
// test(3,products);


//4Dla każdego produktu podać liczbę produktów, które są od niego tańsze lub jest ich mniej sztuk na składzie.

static void test(int repetitions, List<Product> products) 
  {
      List<double> times = new List<double>();
      Stopwatch stopwatch = new Stopwatch();
      for (int i = 0;i<repetitions;i++)
      {
        stopwatch.Start();
        var product = products.Select(p => p);
	    foreach(var prod in product){
    Console.WriteLine($"{prod.ProductName} {products.Where(p => p.UnitsInStock < prod.UnitsInStock || p.UnitPrice < prod.UnitPrice).Count()}");
}

        stopwatch.Stop();
        times.Add((double)stopwatch.Elapsed.TotalSeconds);
        Console.WriteLine($"Time elapsed: {stopwatch.Elapsed}");

      } 
     times.Sort();
	 //Mediana...
    
    
  }
List<Product> products = GetProductList();
test(1,products);
// test(3,products);



//5 /Dla każdego produktu podaj liczbę produktów, które kosztują tyle samo. *Napisz zapytanie o złożoności O(n*log(n))


// Dla każdego produktu podaj liczbę produktów, które kosztują tyle samo. *Napisz zapytanie o złożoności O(n*log(n)).

static void test(int repetitions, List<Product> products) 
  {
      List<double> times = new List<double>();
      Stopwatch stopwatch = new Stopwatch();
      for (int i = 0;i<repetitions;i++)
      {
        stopwatch.Start();
        var product = products.Select(p => p);
	    foreach(var prod in product){
    Console.WriteLine($"{prod.ProductName} {products.Where(p => p.UnitPrice == prod.UnitPrice).Count()}");
}

        stopwatch.Stop();
        times.Add((double)stopwatch.Elapsed.TotalSeconds);
        Console.WriteLine($"Time elapsed: {stopwatch.Elapsed}");

      } 
     times.Sort();
	 //Mediana...
    
    
  }
List<Product> products = GetProductList();
test(1,products);
// test(3,products);


//6Do rozwiązań zastosuj Parallel LINQ i sprawdź poprawę wydajności.

static void test(int repetitions, List<Product> products) 
  {
      List<double> times = new List<double>();
      Stopwatch stopwatch = new Stopwatch();
      for (int i = 0;i<repetitions;i++)
      {
        stopwatch.Start();
        var result = products.OrderByDescending(x => x.UnitsInStock).First();

	    Console.WriteLine($"Naza: {result}");
        stopwatch.Stop();
        times.Add((double)stopwatch.Elapsed.TotalSeconds);
        Console.WriteLine($"Time elapsed: {stopwatch.Elapsed}");

      } 
     times.Sort();
	 //Mediana...
    
    
  }
List<Product> products = GetProductList();
test(3,products);
// test(3,products);


//Zad 7
// Dla każdego produktu podaj liczbę produktów, które kosztują tyle samo. *Napisz zapytanie o złożoności O(n*log(n)).

static void test(int repetitions, List<Product> products) 
  {
      List<double> times = new List<double>();
      Stopwatch stopwatch = new Stopwatch();
      for (int i = 0;i<repetitions;i++)
      {
        stopwatch.Start();
        var ikuraPrice = products.Where(x => x.ProductName == "Ikura").Select(x => x.UnitPrice).ToList(); 
	    var names = products.Where(x => x.UnitPrice == ikuraPrice[0]);

	Console.WriteLine("All products:");
	foreach (var name in names)
	{
		Console.WriteLine($"Product: {name} ");
	}

	   
        stopwatch.Stop();
        times.Add((double)stopwatch.Elapsed.TotalSeconds);
        Console.WriteLine($"Time elapsed: {stopwatch.Elapsed}");

      } 
     times.Sort();
	 //Mediana...
    
    
  }
List<Product> products = GetProductList();
test(3,products);
// test(3,products);


 