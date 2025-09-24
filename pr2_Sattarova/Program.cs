Console.WriteLine("Введите текст на русском(миниум 100 символов)");
string text = Console.ReadLine();
while (text.Length < 100) 
{ 
    Console.WriteLine("Введите текст на русском(миниум 100 символов)");
    text = Console.ReadLine();
}
string[] textlist = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

while (true) 
{
    Console.WriteLine("******************");
    Console.WriteLine("МЕНЮ");
    Console.WriteLine("1. Кол-во слов в тексте ");
    Console.WriteLine("2. Поиск самого короткого слова ");
    Console.WriteLine("3. Кол-во предложений в тексте ");
    Console.WriteLine("4. Кол-во гласных и согласных в тексте ");
    Console.WriteLine("5. Поиск самого длинного слова ");
    Console.WriteLine("6. Статистики по частоте встречаемости каждой буквы");
    Console.WriteLine("7. Продолжить работу с новым текстом ");
    Console.WriteLine("8. Сохранение всей статистики в список ");
    Console.WriteLine("9. Статистику по прошлым текстам ");
    Console.WriteLine("******************");
    Console.WriteLine("Выберите команду");
    string choice = Console.ReadLine().Trim();
    Console.WriteLine();
    switch(choice)
    {
        case "1": KolvoSlov(); break;
        case "2": Korotkoe(); break;
        case "3": KolvoPredloj(); break;
        case "4": KolvoGlasSoglas(); break;
        case "5": Dlinnoe(); break;
        case "6": Statistic(); break;
        case "7":
        case "8":
        case "9":
    
        default: Console.WriteLine("Невереная команда, попробуйте другую"); break;
    }
}
void KolvoSlov()
{
    Console.WriteLine($"Кол-во слов в тексте: {textlist.Length}");
}
void Korotkoe()
{
    
    foreach(var word in textlist)
    {
        string min = " ";
        if (word.Length > min.Length)
        {
            continue;
        }
        else
        {
            min = word;
        }
        Console.WriteLine($"Самое короткое слово: {min}");
        break;
    }
}
void Dlinnoe()
{
    string max = "";
    foreach (var word in textlist)
    {
        if (word.Length > max.Length)
        {
            max = word;
        }
    }
    Console.WriteLine($"Самое длинное слово: {max}");
}
void KolvoPredloj()
{
    int count = 0;
    string upper = "ЙЦУКЕНГШЩЗХЪЭЖДЛОРПАВЫФЯЧСМИТЬБЮЁ";

    for (int i = 0; i < text.Length; i++)
    {
        if (i < text.Length - 1 && (text[i] == '.' || text[i] == '!' || text[i] == '?'))
        {
            if (i == text.Length - 1 ||
                upper.Contains(text[i + 1]) ||
                (text[i + 1] == ' ' && i < text.Length - 2 && upper.Contains(text[i + 2])))
            {
                count++;
            }
        }
    }
    if (text.Length > 0 && !".!?".Contains(text[text.Length - 1]))
    {
        count++;
    }

    Console.WriteLine($"Кол-во предложений в тексте: {count}");
}
void KolvoGlasSoglas ()
{
    string glas = "аеёиоуыэюяАЕЁИОУЫЭЮЯ";
    string soglas = "бвгджзйклмнпрстфхцчшщБВГДЖЗЙКЛМНПРСТФХЦЧШЩ";
    int countg = 0;
    int counts = 0;
    foreach (char i in text)
    {
        if (glas.Contains(i))
        {
            countg++;
        }
        else if (soglas.Contains(i))
        {
            counts++;
        }
    }
    Console.WriteLine($"Кол-во согласных: {counts}");
    Console.WriteLine($"Кол-во гласных: {countg}");
}
void Statistic()
{
    string letter = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
    Dictionary<char, int> counts = new Dictionary<char, int>();
    foreach (char i in letter)
    {
        counts[i] = 0;
    }
    foreach (char c in text.ToLower())
    {
        if (counts.ContainsKey(c))
        {
            counts[c]++;
        }
    }
    Console.WriteLine($"Статистика по частоте встречаемости букв:");
    Console.WriteLine("========================================");
    foreach(var pair in counts.OrderByDescending(x => x.Value))
    {
        if (pair.Value > 0)
        {
            Console.WriteLine($"Буква '{pair.Key}': {pair.Value} раз");
        }
    }
}
