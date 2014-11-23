class Hauptklasse
{
    enum Sex { ултра_Батка, Яка_Мацка };

    class Person
    {
        public Sex пол { get; set; }
        public string име_на_Чуека { get; set; }
        public int age { get; set; }
    }

    public void Make_Чуек(int магическия_НомерНаЕДИНЧОВЕК)
    {
        Person new_Чуек = new Person();
        new_Чуек.age = магическия_НомерНаЕДИНЧОВЕК;
        if (магическия_НомерНаЕДИНЧОВЕК % 2 == 0)
        {
            new_Чуек.име_на_Чуека = "Батката";
            new_Чуек.пол = Sex.ултра_Батка;
        }
        else
        {
            new_Чуек.име_на_Чуека = "Мацето";
            new_Чуек.пол = Sex.Яка_Мацка;
        }
    }
}
