using ZadaniePoPM;

class Program
{
    static void Main(string[] args)
    {
        // Считываем информацию о продажах и остатках товаров из файла Excel
        string filePath = "C:\\Users\\Weresk\\Desktop\\Binary\\Zadanie.xlsx";
        List<Product> products = ProductReader.ReadDataFromExcel(filePath);
        Console.WriteLine("Доступные товары:");
        foreach (Product product in products)
        {
            Console.WriteLine(product); // Выводим информацию о каждом товаре
        }
        Console.WriteLine("Выберите критерии для формирования рейтинга товаров:");
        Console.WriteLine("1. Дефицитные товары");
        Console.WriteLine("2. Самые продаваемые товары");
        Console.WriteLine("3. Сезонные товары (введите номер сезона: 1 - весеннее, 2 - летнее, 3 - осеннее, 4 - зимнее)");
        Console.WriteLine("Введите номера выбранных критериев через пробел:");

        string[] criteria = Console.ReadLine().Split(' ');

        // Формирование рейтинга на основе выбранных критериев
        Rating rating = new Rating(products);
        rating.GetRating(criteria);

    }
}