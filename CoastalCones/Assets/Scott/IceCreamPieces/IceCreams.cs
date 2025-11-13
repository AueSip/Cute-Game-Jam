using System.Threading.Tasks;

[System.Serializable]
public class IceCreams
{
    //employees is case sensitive and must match the string "employees" in the JSON.
    public Cone[] cones;
    public Flavor[] flavors;
    public Topping[] toppings;
    public Sauce[] sauces;
    public Beverage[] beverages;
    
    public IceCreams SetIceCream(

        int indx,
        Cone coneVal,
        Flavor flavorVal,
        Topping toppingsVal,
        Sauce sauceVal,
        Beverage beverageVal)
    {
        cones = new Cone[1];
        flavors = new Flavor[1];
        toppings = new Topping[1];
        sauces = new Sauce[1];
        beverages = new Beverage[1];
        
        cones[indx] = coneVal;
        flavors[indx] = flavorVal;
        toppings[indx] = toppingsVal;
        sauces[indx] = sauceVal;
        beverages[indx] = beverageVal;
        return this;
    }
}