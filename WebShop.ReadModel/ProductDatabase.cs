using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Itera.Fagdag.WebShop.ReadModel
{
    public static class ProductDatabase
    {
        public static void LoadFromDisk(string folder)
        {
            Products.Clear();
            Products.AddRange(Directory.GetFiles(folder, "*.txt")
                .Select(ReadProduct)
                .ToList());
        }

        private static ProductDto ReadProduct(string path)
        {
            var lines = File.ReadAllLines(path);
            var id = ParseId(path);
            return ParseProduct(id, lines);
        }

        private static ProductDto ParseProduct(int id, IList<string> lines)
        {
            return new ProductDto
            {
                Id = id,
                Price = decimal.Parse(lines[0]),
                Title = lines[1],
                Description = lines[2],
                ImageSource = string.Format("/produkter/{0}.jpg", id),
                Brand = lines[3],
                Color = lines[4],
                MinSize = int.Parse(lines[5]),
                MaxSize = int.Parse(lines[6]),
                Category = lines[7]
            };
        }

        private static int ParseId(string path)
        {
            var filename = Path.GetFileName(path);
            return int.Parse(filename.Substring(0, filename.LastIndexOf('.')));
        }

        public static List<ProductDto> Products = new List<ProductDto>();
    }
}