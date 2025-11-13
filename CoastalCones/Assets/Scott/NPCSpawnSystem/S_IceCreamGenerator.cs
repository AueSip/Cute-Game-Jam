using System.Collections.Generic;
using UnityEngine;
public class S_IceCreamGenerator : MonoBehaviour
{
    public JSONReader jsonReader;

    public MachineUnlockReader unlockReader;

    public List<Transform> NPCLocations;

    List<string> cone_names = new();
    List<string> sauce_names = new();
    List<string> flavor_names = new();
    
    List<string> topping_names = new();
    List<string>beverage_names= new();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {      
        GetUnlocks();
        for (int i = 0; i < 6; i++)
        {
            ReturnIceCream();
        }
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void GetUnlocks()
    {
        cone_names.Clear();
        sauce_names.Clear();
        flavor_names.Clear();
        topping_names.Clear();
        beverage_names.Clear();
        //Returns array of unlocks, add a check later for level
        Zero[] level0 = unlockReader.ReturnZeroLevel();
        foreach (Zero data in level0)
        {
            cone_names.Add(data.cone_unlock);
            sauce_names.Add(data.sauces_unlock);
            flavor_names.Add(data.flavor_unlock);
            topping_names.Add(data.topping_unlock);
            beverage_names.Add(data.beverage_unlock);
        }
        One[] level1 = unlockReader.ReturnOneLevel();
        foreach (One data in level1)
        {
            cone_names.Add(data.cone_unlock);
            sauce_names.Add(data.sauces_unlock);
            flavor_names.Add(data.flavor_unlock);
            topping_names.Add(data.topping_unlock);
            beverage_names.Add(data.beverage_unlock);
        }
        Two[] level2 = unlockReader.ReturnTwoLevel();
        foreach (Two data in level2)
        {
            cone_names.Add(data.cone_unlock);
            sauce_names.Add(data.sauces_unlock);
            flavor_names.Add(data.flavor_unlock);
            topping_names.Add(data.topping_unlock);
            beverage_names.Add(data.beverage_unlock);
        }
        Three[] level3 = unlockReader.ReturnThreeLevel();
        foreach (Three data in level3)
        {
            cone_names.Add(data.cone_unlock);
            sauce_names.Add(data.sauces_unlock);
            flavor_names.Add(data.flavor_unlock);
            topping_names.Add(data.topping_unlock);
            beverage_names.Add(data.beverage_unlock);
        }
        Four[] level4 = unlockReader.ReturnFourLevel();
        foreach (Four data in level4)
        {
            cone_names.Add(data.cone_unlock);
            sauce_names.Add(data.sauces_unlock);
            flavor_names.Add(data.flavor_unlock);
            topping_names.Add(data.topping_unlock);
            beverage_names.Add(data.beverage_unlock);
        }
        Five[] level5 = unlockReader.ReturnFiveLevel();
        foreach (Five data in level5)
        {
            cone_names.Add(data.cone_unlock);
            sauce_names.Add(data.sauces_unlock);
            flavor_names.Add(data.flavor_unlock);
            topping_names.Add(data.topping_unlock);
            beverage_names.Add(data.beverage_unlock);
        }


    }

    public string ReturnConeName()
    {
        return cone_names[RandomNum(cone_names)];
    }

    public string ReturnFlavorName()
    {
        return flavor_names[RandomNum(flavor_names)];
    }

    public string ReturnToppingName()
    {
        return topping_names[RandomNum(topping_names)];
    }

    public string ReturnSauceName()
    {
        return sauce_names[RandomNum(sauce_names)];
    }
    public string ReturnBeverageNames()
    {
        return beverage_names[RandomNum(beverage_names)];
    }

    public int RandomNum(List<string> variableL)
    {
        return Random.Range(0, variableL.Count);
    }




    public IceCreams ReturnIceCream()
    {
        Cone[] tempConeList;
        Sauce[] tempSauceList;
        Flavor[] tempFlavorList;
        Topping[] tempToppingList;
        Beverage[] tempBeverageList;

        tempConeList = jsonReader.ReturnCones();
        tempSauceList = jsonReader.ReturnSauces();
        tempFlavorList = jsonReader.ReturnFlavor();
        tempToppingList = jsonReader.ReturnToppings();
        tempBeverageList = jsonReader.ReturnBeverages();

        

        Cone targetCone = new();
        Sauce targetSauce = new();
        Flavor targetFlavor = new();
        Topping targetTopping = new();
        Beverage targetBeverage = new();

        string coneName = ReturnConeName();
        string sauceName = ReturnSauceName();
        string flavorName = ReturnFlavorName();
        string toppingName = ReturnToppingName();
        string beverageName = ReturnBeverageNames();
        foreach (Cone data in tempConeList)
        {
            
            if (data.name == coneName )
            {
                targetCone = data;
                break;
            }

        }
        

        foreach (Sauce data in tempSauceList)
        {
           
            if (data.name == sauceName)
            {
                targetSauce = data;
                break;
            }

        }

        foreach (Flavor data in tempFlavorList)
        {
            
            if (data.name == flavorName)
            {
                targetFlavor = data;
                break;
            }

        }

        foreach (Topping data in tempToppingList)
        {
          
            if (data.name == toppingName)
            {
                targetTopping = data;
                break;
            }

        }
        
         
         foreach(Beverage data in tempBeverageList)
        {
            if (data.name == beverageName)
            {
                targetBeverage = data;
                break;
            }

        }

        IceCreams iceCream = new IceCreams();
        iceCream.SetIceCream(0,targetCone,targetFlavor, targetTopping, targetSauce, targetBeverage);

      
        
        return iceCream;
    }

}

    
   