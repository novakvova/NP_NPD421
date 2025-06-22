// See https://aka.ms/new-console-template for more information
using _3_HttpClient;

Console.InputEncoding = System.Text.Encoding.UTF8;
Console.OutputEncoding = System.Text.Encoding.UTF8;

var categoryService = new CategoryService();

while (true)
{
    Console.WriteLine("Меню:");
    Console.WriteLine("1. Вивести категорії");
    Console.WriteLine("2. Видалити категорію");
    Console.WriteLine("3. Додати категорію");
    Console.WriteLine("0. Вийти");
    Console.Write("Оберіть дію: ");
    var input = Console.ReadLine();

    switch (input)
    {
        case "1":
            {
                var categorySearch = new CategorySearch();
                Console.Write("Введіть номер сторінки: ");
                var pageInput = Console.ReadLine();
                int pageNumber = 1;
                if (!int.TryParse(pageInput, out pageNumber) || pageNumber < 1)
                {
                    Console.WriteLine("Некоректний номер сторінки. Використовується сторінка 1.");
                    pageNumber = 1;
                }
                categorySearch.Page = pageNumber;
                var categoriesResponse = await categoryService.GetCategoriesUri(categorySearch);
                if (categoriesResponse != null)
                {
                    Console.WriteLine(categoriesResponse);
                    foreach (var category in categoriesResponse.Categories)
                    {
                        Console.WriteLine(category);
                    }
                }
                else
                {
                    Console.WriteLine("Не вдалося отримати категорії.");
                }
                break;
            }
        case "2":
            {
                Console.Write("Введіть ID категорії для видалення: ");
                var idInput = Console.ReadLine();
                if (int.TryParse(idInput, out int categoryId))
                {
                    var result = await categoryService.DeleteCategoryAsync(categoryId);
                    if (result)
                    {
                        Console.WriteLine("Категорію видалено.");
                    }
                    else
                    {
                        Console.WriteLine("Не вдалося видалити категорію.");
                    }
                }
                else
                {
                    Console.WriteLine("Некоректний ID.");
                }
                break;
            }
        case "3":
            {
                var categoryCreate = new CategoryCreate();
                Console.Write("Введіть назву нової категорії: ");
                var temp = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(temp))
                {
                    Console.WriteLine("Назва категорії не може бути порожньою.");
                    break;
                }
                categoryCreate.Title = temp;
                categoryCreate.UrlSlug = temp.TransliterateToLatin();

                Console.Write("Введіть шлях до фото: ");
                temp = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(temp))
                {
                    Console.WriteLine("Шлях до фото не може бути порожнім.");
                    break;
                }

                categoryCreate.Image = temp.FileToBase64(); // Якщо у вас є властивість Image в CategoryCreate, розкоментуйте цю строку

                // Додайте інші параметри, якщо потрібно
                Console.Write("Введіть пріорітет: ");
                var priority = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(priority))
                {
                    categoryCreate.Priority = int.Parse(priority);
                }

                var result = await categoryService.AddCategoryAsync(categoryCreate);
                if (result)
                {
                    Console.WriteLine("Категорію створено.");
                }
                else
                {
                    Console.WriteLine("Не вдалося створити категорію.");
                }
                break;
            }
        case "0":
            return;
        default:
            Console.WriteLine("Невідома дія.");
            break;

           
    }
}
