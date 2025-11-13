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
        GenerateYourIceCream();
        SetConeValue(indx,coneVal);
        SetFlavorVal(indx,flavorVal);
        SetToppingVal(indx,toppingsVal);
        SetSauceVal(indx,sauceVal);
        SetBeverageVal(indx,beverageVal);
        return this;
    }

    public void GenerateYourIceCream()
    {
         cones = new Cone[1];
         flavors = new Flavor[1];
        toppings = new Topping[1];
        sauces = new Sauce[1];
        beverages = new Beverage[1];
    }

    public void SetConeValue(int index, Cone coneVal)
    {
        cones[index] = coneVal;
    }

    public void SetFlavorVal(int index, Flavor flavorVal)
    {
        flavors[index] = flavorVal;
    }

    public void SetToppingVal(int index, Topping toppingVal)
    {
        toppings[index] = toppingVal;
    }

     public void SetSauceVal(int index, Sauce sauceVal)
    {
        sauces[index] = sauceVal;
    }

    public void SetBeverageVal(int index, Beverage beverageVal)
    {
        beverages[index] = beverageVal;
    }
}