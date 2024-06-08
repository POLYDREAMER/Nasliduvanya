using System;

public class Пацієнт
{
    // Закриті поля
    private string name;
    private DateTime date_of_birth;
    private string insurance_number;

    // Публічна властивість для зчитування імені
    public string Імя
    {
        get { return name; }
    }

    // Публічна властивість для зчитування та встановлення дати народження
    public DateTime ДатаНародження
{
    get { return date_of_birth; }
    set { date_of_birth = value; }
}

// Публічна властивість для зчитування та встановлення номера страховки
public string НомерСтрахування
{
    get { return insurance_number; }
    set { insurance_number = value; }
}

// Конструктор з параметрами
public Пацієнт(string name, DateTime date_of_birth, string insurance_number)
{
    this.name = name;
    this.date_of_birth = date_of_birth;
    this.insurance_number = insurance_number;
}

// Віртуальний метод для запису діагнозу
public virtual void ЗаписатиДіагноз(string діагноз)
{
    МедичнаКартка.ДодатиДіагноз(діагноз);
}

// Метод для виведення інформації про пацієнта та його діагнози
public void ПоказатиМедичнуКартку()
{
    Console.WriteLine($"Iм'я: {Імя}");
        Console.WriteLine($"Дата народження: {ДатаНародження.ToShortDateString()}");
        Console.WriteLine($"Номер страховки: {НомерСтрахування}");
        Console.WriteLine("Дiагнози:");
        МедичнаКартка.ПоказатиДіагнози();
    }

    // Поле для зберігання медичної картки
    protected МедичнаКартка МедичнаКартка { get; } = new МедичнаКартка();
}

public class Лікар : Пацієнт
{
    // Закрите поле для спеціалізації
    private string specialization;

    // Конструктор з параметрами, включаючи спеціалізацію
    public Лікар(string name, DateTime date_of_birth, string insurance_number, string specialization)
        : base(name, date_of_birth, insurance_number)
    {
        this.specialization = specialization;
    }

    // Метод для встановлення діагнозу пацієнту
    public void ВстановитиДіагноз(Пацієнт пацієнт, string діагноз)
    {
        пацієнт.ЗаписатиДіагноз(діагноз);
    }
}

public class МедичнаКартка
{
    // Відкрите поле для зберігання діагнозів
    private string[] diagnoses;

    // Конструктор за замовчуванням
    public МедичнаКартка()
    {
        diagnoses = new string[0];
    }

    // Метод для додавання діагнозу
    public void ДодатиДіагноз(string діагноз)
    {
        Array.Resize(ref diagnoses, diagnoses.Length + 1);
        diagnoses[diagnoses.Length - 1] = діагноз;
    }

    // Метод для виведення усіх діагнозів
    public void ПоказатиДіагнози()
    {
        foreach (var діагноз in diagnoses)
        {
            Console.WriteLine($"- {діагноз}");
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Створення об'єкта класу Лікар
        Лікар лікар = new Лікар("Доктор Петров", new DateTime(1978, 10, 15), "5432109876", "Терапевт");

        // Створення об'єкта класу Пацієнт
        Пацієнт пацієнт = new Пацієнт("Iван Iванович", new DateTime(1985, 5, 23), "1234567890");

        // Встановлення діагнозу пацієнту
        лікар.ВстановитиДіагноз(пацієнт, "Грип");

        // Виведення медичної картки пацієнта
        пацієнт.ПоказатиМедичнуКартку();
    }
}
