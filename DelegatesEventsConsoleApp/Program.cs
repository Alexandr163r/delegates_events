using DelegatesEventsConsoleApp.Extensions;
using DelegatesEventsConsoleApp.Models;
using DelegatesEventsConsoleApp.Services;

namespace DelegatesEventsConsoleApp;

class Program
{
    static void Main()
    { 
        TestGetMaxExtension();
        TestFileSearcher();
    }

    private static void TestGetMaxExtension()
    {
        var products = new List<Product?>
        {
            new Product("Пицца", 285),
            new Product("Пиво", 185),
            new Product("Какая то непонятная фигня, но очень надо ", 300),
        };

        var mostExpensive = products.GetMax(p => p.Price);
        Console.WriteLine($"Самый дорогой продукт: {mostExpensive!.ItemName}, Стоит аж: {mostExpensive.Price}");
    }
    
    private static string _stopWord = "";

    private static void TestFileSearcher()
    {
        var searcher = new FileSearcher();

        Console.WriteLine("Введите стоп слово:");
        _stopWord = Console.ReadLine() ?? "";

        searcher.FileFound += OnFileFound!;

        Console.WriteLine("Где искать?");
        string directoryPath = Console.ReadLine() ?? "";

        if (!Directory.Exists(directoryPath))
        {
            Console.WriteLine("Не найдена дериктория");
            return;
        }

        Console.WriteLine("Начали искать");
        searcher.Search(directoryPath);
        
        // отписка от события 
        searcher.FileFound -= OnFileFound!;
    }

    private static void OnFileFound(object sender, FileFoundEventArgs e)
    {
        Console.WriteLine($"Нашли файл : {e.FileName}");

        if (!string.IsNullOrWhiteSpace(_stopWord) &&
            e.FileName.Contains(_stopWord, StringComparison.OrdinalIgnoreCase))
        {
            Console.WriteLine($"Найден файл со стопсловом \"{_stopWord}\", останавливаем поиск.");
            e.CancelRequested = true;
        }
    }
}
