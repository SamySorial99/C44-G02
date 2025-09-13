using Day_01_G03;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading;


namespace LinQ1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            var outOfStock = ListGenerator.ProductsList.Where(p => p.UnitsInStock == 0);

            Console.WriteLine("Out of Stock Products:");
            foreach (var product in outOfStock)
            {
                Console.WriteLine($"- {product.ProductName}");
            }

            //Find all products that are in stock and cost more than 3.00 per unit.

            var expensiveInStock = ListGenerator.ProductsList.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3.00M);

            //Returns digits whose name is shorter than their value.

            String[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };

            var shortNamedDigits = Arr.Where((digit, index) => digit.Length < index);

            Console.WriteLine(shortNamedDigits.Count());


            // Get first Product out of Stock
            var firstOutOfStock = ListGenerator.ProductsList.FirstOrDefault(p => p.UnitsInStock == 0);

            Console.WriteLine($"First out of stock product: {firstOutOfStock?.ProductName ?? "None"}");


            //Return the first product whose Price > 1000, unless there is no match, in which case null is returned.


            var firstExpensiveProduct = ListGenerator.ProductsList.FirstOrDefault(p => p.UnitPrice > 1000);


            Console.WriteLine($"First product with price > 1000: {firstExpensiveProduct?.ProductName ?? "None"}");

            //Retrieve the second number greater than 5

            int[] arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var secondNumberGreaterThan5 = arr.Where(n => n > 5).Skip(1).FirstOrDefault();

            //Uses Count to get the number of odd numbers in the array

            int[] Arr1 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            var oddNumbers = Arr1.Count(n => n % 2 != 0);
            Console.WriteLine($"Count of odd numbers: {oddNumbers}");


            //Return a list of customers and how many orders each has.

            var customerOrderCounts = ListGenerator.CustomersList.Select(c => new
            {
                CustomerID = c.CustomerID,
                OrderCount = c.Orders.Count()
            });

            foreach (var customer in customerOrderCounts)
            {
                Console.WriteLine($"Customer {customer.CustomerID} has {customer.OrderCount} orders.");
            }

            //Return a list of categories and how many products each has
            var categoryProductCounts = ListGenerator.ProductsList
                .GroupBy(p => p.Category)
                .Select(g => new
                {
                    Category = g.Key,
                    ProductCount = g.Count()
                });

            foreach (var category in categoryProductCounts) { 
                Console.WriteLine($"Category {category.Category} has {category.ProductCount} products.");
            }

            //Get the total of the numbers in an array.

            int[] Arr2 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var total = Arr2.Sum();

            Console.WriteLine($"Total of numbers in array: {total}");

            //Get the total number of characters of all words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
            string[] words = System.IO.File.ReadAllLines("dictionary_english.txt");

            var totalCharacters = words.Sum(w => w.Length);

            Console.WriteLine($"Total number of characters in dictionary: {totalCharacters}");

            //Get the length of the shortest word in dictionary_english.txt(Read dictionary_english.txt into Array of String First).

            var shortestWordLength = words.Min(w => w.Length);


            //Get the length of the longest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).

            var longestWordLength = words.Max(w => w.Length);

            //Get the average length of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First).

            var averageWordLength = words.Average(w => w.Length);


            //Sort a list of products by name

            var sortedProducts = ListGenerator.ProductsList.OrderBy(p => p.ProductName);

            //Uses a custom comparer to do a case-insensitive sort of the words in an array.

            String[] Arr3 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };


            var caseInsensitiveSorted = Arr3.OrderBy(s => s, StringComparer.OrdinalIgnoreCase);


            //Sort a list of products by units in stock from highest to lowest.

            var productSortbyStock = ListGenerator.ProductsList.OrderByDescending(p=>p.UnitsInStock);

            //Sort a list of digits, first by length of their name, and then alphabetically by the name itself.

            string[] Arr4 = {"zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine"};

            var sortedDigits = Arr4.OrderBy(d => d.Length).ThenBy(d => d);

            //Sort first by-word length and then by a case-insensitive sort of the words in an array. ---- SAME AS ARR3

            var sortedWords = Arr3.OrderBy(w => w.Length).ThenBy(w => w, StringComparer.OrdinalIgnoreCase);


            //Sort a list of products, first by category, and then by unit price, from highest to lowest.


            var sortedProductsByCategory = ListGenerator.ProductsList
                .OrderBy(p => p.Category)
                .ThenByDescending(p => p.UnitPrice);


            //Sort first by - word length and then by a case -insensitive descending sort of the words in an array.

            var sortedWordsDesc = Arr3
                .OrderBy(w => w.Length)
                .ThenByDescending(w => w, StringComparer.OrdinalIgnoreCase);

            //Create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.

            var reversedDigits = Arr4
                .Where(d => d.Length > 1 && d[1] == 'i')
                .Reverse();


            //Return a sequence of just the names of a list of products.


            var productNames = ListGenerator.ProductsList.Select(p => p.ProductName);


            foreach (var name in productNames)
            {
                Console.WriteLine(name);
            }

            //Produce a sequence of the uppercase and lowercase versions of each word in the original array (Anonymous Types).

            String[] words1 = { "aPPLE", "BlUeBeRrY", "cHeRry" };

            var upperLowerWords = words1.Select(w => new
            {
                Upper = w.ToUpper(),
                Lower = w.ToLower()
            });

            //Produce a sequence containing some properties of Products, including UnitPrice which is renamed to Price in the resulting type.

            var productInfos = ListGenerator.ProductsList.Select(p => new
            {
                p.ProductName,
                p.Category,
                Price = p.UnitPrice
            });


            foreach (var productInfo in productInfos)
            {
                Console.WriteLine($"{productInfo.ProductName} - {productInfo.Category} - {productInfo.Price}");
            }


            //Determine if the value of int in an array matches their position in the array. --SAME AS ARR2

            bool[] result = Arr2
                .Select((value, index) => value == index)
                .ToArray();

            for(int i = 0; i < result.Length; i++)
            {
                Console.WriteLine($"{Arr2[i]}: {result[i]}");
            }


            //


        }
    }
}
