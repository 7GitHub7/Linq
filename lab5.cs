# Znaleźć nazwy produktów, które są na stanie, kosztują mniej niż 10 i należą do kategorii Seafood.

products
  .Where1(p => p.UnitsInStock > 0 && p.UnitPrice < 10)
  .Where2(p => p.Category == "Seafood")
  .Count()

Count(
Where2(
Where1(products, p => p.UnitsInStock > 0 && p.UnitPrice < 10), p => p.Category == "Seafood")
)
  
itWhere2 -> itWhere1 -> p1 -> lambda1(p1) -if true-> lambda2(p1) -if true-> count++
itWhere2 -> itWhere1 -> p2 -> lambda1(p2) -if true-> lambda2(p2) -if true-> count++
         ...
         
itWhere1 -> p1 -> lambda1(p1) -if true-> res.push(p1)
         -> p2 -> lambda1(p2) -if true-> res.push(p2)
          ...
         
Dla każdej kategorii znaleźć najtańsze i najdroższe produkty. Zwrócić nazwy kategorii i nazwy produktów.  
  
products.GroupBy(p => p.Category, p => p,
    (category, product) => new {​​
        Key = category,
        MostExpensive = product.OrderByDescending(p => p.UnitPrice).First().ProductName,
        LessExpensive = product.OrderBy(p => p.UnitPrice).Select(p => p.ProductName).First()
}​​);
         
products.GroupBy(p => p.Category).Select(c =>
        new
        {
            Category = c.Key,
            OrderedProducts = c.OrderBy(k => k.UnitPrice).ToList()
        })
    .Select(o =>
        new
        {
            o.Category,
            CheapestProduct = o.OrderedProducts.First().ProductName,
            MostExpensiveProduct = o.OrderedProducts.Last().ProductName
        });   
         
O(n + k * (n/k * log(n/k)) ) = O(n + n * log(n / k)) = O(n * log(n / k)) < O(n * n / k)
         
O(n)

products.GroupBy(p => p.Category).Select(c =>
        new
        {
            Category = c.Key,
            ChP = c.Aggregate((a, b) => a.UnitPrice <= b.UnitPrice ? a : b).ProductName,
            MeP = c.Aggregate((a, b) => a.UnitPrice >= b.UnitPrice ? a : b).ProductName,
        });

        O(n + k * (n/k)) = O( n )
         
c = p1, p2,p3,p4
p1 > p2 < p3 < p4

(a -> p1, b -> p2) -> p2 
(a -> p2, b -> p3) -> p2
(a -> p2, b -> p4) -> p2
         
         c.Aggregate((a, b) => new Product("Zestaw " + c.Key, a.UnitPrice + b.UnitPrice))
         
         o operatorze reduce, foldl, foldr
         
* Znaleźć cenę, dla której jest najwięcej sztuk produktów (biorąc pod uwagę też unitInStocks).

var unitsPrice = products.GroupBy(p => p.UnitPrice, p => p, (price, product) => new{
    Key = price,
    Units = product.Select(u => u.UnitsInStock).Sum()
});
var query = unitsPrice.Where(pu => pu.Units == unitsPrice.Select(up => up.Units).Max());  

spróbować rozwiązać używając Aggregate

#var priceMaxUnits = new Lazy <int>(() => unitsPrice.Select(up => up.Units).Max()); 
#var query = unitsPrice.Where(pu => pu.Units == priceMaxUnits.Value);  
 
# Dla każdego produktu podać liczbę produktów, które są od niego tańsze lub jest ich mniej sztuk na składzie.        

products.
    .Select(p =>
        new
        {
            Product = p.ProductName,
            SpecCnt = products.Count(o => o.UnitPrice < p.UnitPrice || o.UnitsInStock < p.UnitsInStock)
        });

O( n * n )


# Dla każdego produktu podaj liczbę produktów, które kosztują tyle samo.

products.Select(p => 
        new {
          name = p.ProductName, 
          count =  products.Where(p1 => p1.UnitPrice == p.UnitPrice).Count()
          });
          
o( n * n )

var productsCountByPrice = products.
  GroupBy(p => p.UnitPrice).ToDictionary(gr => gr.Key, gr => gr.Count());
return products.Select(p => new
    {
    Product = p,
    ProductsCount = productsCountByPrice[p.UnitPrice]
    }).ToList();

o( n ) 



# Produkty, których cena jednostkowa, jest równa cenie produktu o nazwie Ikura.

## Rozwiązania

A. products.Where(p => 
    p.UnitPrice == (products.Where(p => p.ProductName =="Ikura").Select(p=>p.UnitPrice).First()));
//Median time elapsed: 00:00:00.0058272

O ( n * n )

B. from p in products 
    where (from p1 in products
        where p1.ProductName == "Ikura" select p1.UnitPrice).Contains(p.UnitPrice)
    select p.ProductName;
//Median time elapsed: 00:00:01.6294292

O ( n * n )

C. var IkuraPriceThunk = new Lazy<decimal>(() => 
        products.Where(p => p.ProductName =="Ikura").Select(p=>p.UnitPrice).First());
    var query = products.Where(p => p.UnitPrice.Equals(IkuraPriceThunk));
//Median time elapsed: 00:00:00.0002657

O( n )

D. var ikuraPrices =
        from prod in products
        where prod.ProductName == "Ikura"
        select prod.UnitPrice;
var ikuraPricesList = ikuraPrices.ToList();
return from prod in products
        where ikuraPricesList.Contains(prod.UnitPrice)
        select prod.ProductName;

k - liczba produktów Ikura
O( n * k )


















         

         
         
         
         
         
         
         