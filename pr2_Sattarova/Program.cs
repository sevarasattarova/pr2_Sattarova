using System.Diagnostics.Metrics;

Console.WriteLine("Введите текст на русском(миниум 100 символов)");
string text = Console.ReadLine();
while (text.Length < 100) 
{ 
    Console.WriteLine("Введите текст на русском(миниум 100 символов)");
    text = Console.ReadLine();
}
string[] textlist = text.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
List<textClass> list = new List<textClass>();

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
        case "1": Console.WriteLine($"Кол-во слов в тексте: {textlist.Length}"); break;
        case "2": Console.WriteLine($"Самое короткое слово: {Korotkoe(textlist)}"); break;
        case "3": Console.WriteLine($"Кол-во предложений в тексте: {KolvoPredloj(text)}"); break;
        case "4": Console.WriteLine($"Кол-во гласных: {KolvoGlas(text)} Кол-во согласных: {KolvoSoglas(text)}"); break;
        case "5": Console.WriteLine($"Самое длинное слово: {Dlinnoe(textlist)}"); break;
        case "6": foreach (var pair in Statistic(text).OrderByDescending(x => x.Value))
            {
                if (pair.Value > 0)
                {
                    Console.WriteLine($"Буква '{pair.Key}': {pair.Value} раз");
                }
            }
            break;
        case "7": list.Add(new textClass(text, textlist.Length, Korotkoe(textlist), Dlinnoe(textlist) , KolvoGlas(text), KolvoSoglas(text), KolvoPredloj(text), Statistic(text))); break;
        case "8":
        case "9":
        case "0": return;
    
        default: Console.WriteLine("Невереная команда, попробуйте другую"); break;
    }
}

///
string Korotkoe(string[] textlist)
{
    string min = " ";
    foreach (var word in textlist)
    {
       
        if (word.Length > min.Length)
        {
            continue;
        }
        else
        {
            min = word;
        }
        break;
    }
    return min;
}

///
string Dlinnoe(string[] textlist)
{
    string max = "";
    foreach (var word in textlist)
    {
        if (word.Length > max.Length)
        {
            max = word;
        }
    }
    return max;
}

///
int KolvoPredloj(string text)
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
    return count;
}

///
int KolvoGlas(string text)
{
    string glas = "аеёиоуыэюяАЕЁИОУЫЭЮЯ";
    int countg = 0;
    foreach (char i in text)
    {
        if (glas.Contains(i))
        {
            countg++;
        }
    }
    return countg;
}

///
int KolvoSoglas (string text)
{
    string soglas = "бвгджзйклмнпрстфхцчшщБВГДЖЗЙКЛМНПРСТФХЦЧШЩ";
    int counts = 0;
    foreach (char i in text)
    {
        if (soglas.Contains(i))
        {
            counts++;
        }
    }
    return counts;

}





Dictionary<char, int> Statistic(string text)
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
    return counts;
}

public class textClass
{
    static public int ids = 0;
    public int id;
    public string text;
    public int countWord;
    public string shortWord;
    public string LongWorld;
    public int Countpredloj;
    public int glas;
    public int soglas;
    public Dictionary<char, int> statistic; 

    public textClass(string text, int countWord, string shortWord, string longWorld, int countpredloj, int glas, int soglas, Dictionary<char, int> statistic)
    {
        ids += 1;
        id += ids;
        this.text = text;
        this.countWord = countWord;
        this.shortWord = shortWord;
        this.LongWorld = longWorld;
        this.Countpredloj = countpredloj;
        this.glas = glas;
        this.soglas = soglas;
        this.statistic = statistic;
    }
}