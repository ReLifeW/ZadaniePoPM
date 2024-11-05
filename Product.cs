namespace ZadaniePoPM
{
    internal class Product
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int Stock { get; set; }
        public int Sales { get; set; }
        public int Season { get; set; }

        public Product(string name, string code, int stock, int sales, int season)
        {
            Name = name;
            Code = code;
            Stock = stock;
            Sales = sales;
            Season = season;
        }
        public override string ToString()
        {
            return $"Название: {Name}, Код: {Code}, Остаток: {Stock}, Продажи: {Sales}, Сезон: {Season}";
        }
    }
}
