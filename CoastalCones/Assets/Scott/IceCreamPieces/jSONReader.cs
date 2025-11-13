using UnityEngine;

public class JSONReader : MonoBehaviour
{
    public TextAsset jsonFile;

    IceCreams iceCreams;

    void Start()
    {
        iceCreams = JsonUtility.FromJson<IceCreams>(jsonFile.text);

        foreach (Cone cone in iceCreams.cones)
        {
            Debug.Log("Found cone: " + cone.name + " " + cone.color + " " + cone.cost + " " + cone.value);


        }

        foreach (Flavor flavor in iceCreams.flavors)
        {
            Debug.Log("Found flavor: " + flavor.name + " " + flavor.color + " " + flavor.cost + " " + flavor.value);


        }

        foreach (Sauce sauce in iceCreams.sauces)
        {
            Debug.Log("Found sauce: " + sauce.name + " " + sauce.color + " " + sauce.cost + " " + sauce.value);


        }

        foreach (Topping topping in iceCreams.toppings)
        {
            Debug.Log("Found topping: " + topping.name + " " + topping.color + " " + topping.cost + " " + topping.value);


        }

        foreach (Beverage beverage in iceCreams.beverages)
        {
            Debug.Log("Found beverage: " + beverage.name + " " + beverage.color + " " + beverage.cost + " " + beverage.value);


        }
    }

    public Cone[] ReturnCones()
    {
        return iceCreams.cones;
    }

    public Sauce[] ReturnSauces()
    {
        return iceCreams.sauces;
    }

    public Flavor[] ReturnFlavor()
    {
        return iceCreams.flavors;
    }

    public Topping[] ReturnToppings()
    {
        return iceCreams.toppings;
    }
    
    public Beverage[] ReturnBeverages()
    {
        return iceCreams.beverages;
    }

    public Cone ReturnThisCone(string str)
    {  
        Cone targetCone = new();
        foreach (Cone cone in this.ReturnCones())
        {
            if (cone.name == str)
            {
               targetCone = cone;
               break;
            }
            
        }
        return targetCone;
        
    }

     public Sauce ReturnThisSauce(string str)
    {  
        Sauce targetCone = new();
        foreach (Sauce sauce in this.ReturnSauces())
        {
            if (sauce.name == str)
            {
               targetCone = sauce;
               break;
            }
            
        }
        return targetCone;
    }


     public Topping ReturnThisTopping(string str)
    {  
        Topping targetCone = new();
        foreach (Topping sauce in this.ReturnToppings())
        {
            if (sauce.name == str)
            {
               targetCone = sauce;
               break;
            }
            
        }
        return targetCone;
        
}

 public Flavor ReturnThisFlavor(string str)
    {  
        Flavor targetCone = new();
        foreach (Flavor sauce in this.ReturnFlavor())
        {
            if (sauce.name == str)
            {
               targetCone = sauce;
               break;
            }
            
        }
        return targetCone;
        
}

public Beverage ReturnThisBeverage(string str)
    {  
        Beverage targetCone = new();
        foreach (Beverage sauce in this.ReturnBeverages())
        {
            if (sauce.name == str)
            {
               targetCone = sauce;
               break;
            }
            
        }
        return targetCone;
        
}
}


