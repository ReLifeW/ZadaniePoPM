using ZadaniePoPM;

internal class Rating
{
    private List<Product> _products;

    public Rating(List<Product> products)
    {
        _products = products;
    }

    public List<Product> GetSortedProducts()
    {
        // Сортируем продукты по имени
        return _products.OrderBy(p => p.Name).Distinct().ToList();
    }

    public void GetRating(string[] criteria)
    {
        List<Product> result = new List<Product>();

        foreach (var criterion in criteria)
        {
            if (int.TryParse(criterion, out int crit))
            {
                switch (crit)
                {
                    case 1: // Дефицитные товары (сортировка по Stock)
                        result = _products.OrderBy(p => p.Stock).ToList();
                        break;
                    case 2: // Самые продаваемые товары
                        result.AddRange(_products.OrderByDescending(p => p.Sales).Take(10)); // Топ-10 по продажам
                        break;
                    case 3: // Сезонные товары
                        Console.WriteLine("Введите номер сезона (1 - весеннее, 2 - летнее, 3 - осеннее, 4 - зимнее):");
                        if (int.TryParse(Console.ReadLine(), out int seasonInput) && seasonInput >= 1 && seasonInput <= 4)
                        {
                            result.AddRange(_products.Where(p => p.Season == seasonInput));
                        }
                        else
                        {
                            Console.WriteLine("Некорректный номер сезона.");
                        }
                        break;
                    default:
                        Console.WriteLine("Некорректный критерий.");
                        break;
                }
            }
        }

        // Удаляем дубликаты из результатов
        var distinctResults = result.Distinct().ToList();

        // Вывод результатов
        if (distinctResults.Count > 0)
        {
            Console.WriteLine("Результаты по заданным критериям:");
            foreach (var product in distinctResults)
            {
                Console.WriteLine(product);
            }
        }
        else
        {
            Console.WriteLine("Нет результатов по заданным критериям.");
        }
    }
}