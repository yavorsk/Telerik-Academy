public class Cheff
{
    private Carrot GetCarrot()
    {
        //...
    }

    private Potato GetPotato()
    {
        //...
    }

    private void Cut(Vegetable potato)
    {
        //...
    }

    private Bowl GetBowl()
    {
        //... 
    }

    public void Cook()
    {
        Bowl bowl;
        bowl = GetBowl();

        Potato potato = GetPotato();
        Peel(potato);
        Cut(potato);
        bowl.Add(potato);

        Carrot carrot = GetCarrot();                
        Peel(carrot);
        Cut(carrot);
        bowl.Add(carrot);                
    }
}
