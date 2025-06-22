namespace _3_HttpClient;

public static class Helpers
{
    // Додаємо метод для транслітерації name у латинські символи
    public static string TransliterateToLatin(this string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            return string.Empty;

        var map = new Dictionary<char, string>
        {
            // Українські літери
            ['а'] = "a",
            ['б'] = "b",
            ['в'] = "v",
            ['г'] = "h",
            ['ґ'] = "g",
            ['д'] = "d",
            ['е'] = "e",
            ['є'] = "ie",
            ['ж'] = "zh",
            ['з'] = "z",
            ['и'] = "y",
            ['і'] = "i",
            ['ї'] = "i",
            ['й'] = "i",
            ['к'] = "k",
            ['л'] = "l",
            ['м'] = "m",
            ['н'] = "n",
            ['о'] = "o",
            ['п'] = "p",
            ['р'] = "r",
            ['с'] = "s",
            ['т'] = "t",
            ['у'] = "u",
            ['ф'] = "f",
            ['х'] = "kh",
            ['ц'] = "ts",
            ['ч'] = "ch",
            ['ш'] = "sh",
            ['щ'] = "shch",
            ['ю'] = "iu",
            ['я'] = "ia",
            ['ь'] = "",
            ['’'] = "",
            ['ы'] = "y",
            ['э'] = "e",
            // Російські літери (якщо потрібно)
            ['ё'] = "e",
            ['ъ'] = "",
            ['э'] = "e",
        };

        var sb = new System.Text.StringBuilder();
        foreach (char c in input.ToLowerInvariant())
        {
            if (map.TryGetValue(c, out var latin))
                sb.Append(latin);
            else if (char.IsLetterOrDigit(c))
                sb.Append(c);
            else if (char.IsWhiteSpace(c) || c == '-' || c == '_')
                sb.Append('-');
            // ігноруємо інші символи
        }
        // Замінити кілька дефісів на один
        var slug = System.Text.RegularExpressions.Regex.Replace(sb.ToString(), "-{2,}", "-");
        // Видалити дефіси на початку і в кінці
        return slug.Trim('-');
    }

    /// <summary>
    /// Reads the file at the specified path and returns its contents as a Base64-encoded string.
    /// </summary>
    /// <param name="filePath">The path to the file.</param>
    /// <returns>Base64-encoded string of the file contents, or empty string if file does not exist.</returns>
    public static string FileToBase64(this string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
            return string.Empty;

        byte[] fileBytes = File.ReadAllBytes(filePath);
        return Convert.ToBase64String(fileBytes);
    }

}
