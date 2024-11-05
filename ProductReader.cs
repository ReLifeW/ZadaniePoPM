using OfficeOpenXml;

namespace ZadaniePoPM
{
    internal class ProductReader
    {
        public static List<Product> ReadDataFromExcel(string filePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            List<Product> products = new List<Product>();

            // Убедитесь, что файл существует
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("Файл не найден.", filePath);
            }

            // Открываем Excel файл
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                // Получаем первый лист
                var worksheet = package.Workbook.Worksheets[0];

                // Получаем номер последней строки в столбце A
                int lastRow = worksheet.Dimension.End.Row;

                // Читаем данные с A2 до последней строки в столбцах A, B, C, D и E
                for (int row = 2; row <= lastRow; row++)
                {
                    string name = worksheet.Cells[row, 1].Text; // A
                    string code = worksheet.Cells[row, 2].Text; // B
                    int stock = int.Parse(worksheet.Cells[row, 3].Text); // C
                    int sales = int.Parse(worksheet.Cells[row, 4].Text); // D
                    int season = int.Parse(worksheet.Cells[row, 5].Text); // E

                    products.Add(new Product(name, code, stock, sales, season));
                }
            }

            return products;
        }
    }
}
