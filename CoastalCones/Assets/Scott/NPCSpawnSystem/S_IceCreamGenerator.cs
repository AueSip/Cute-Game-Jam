using System.Collections.Generic;
using UnityEngine;
public class S_IceCreamGenerator : MonoBehaviour
{
    private JSONReader jsonReader;

    private MachineUnlockReader unlockReader;

    private GameManager gameManager;

    List<string> cone_names = new(){ "none" };
    List<string> sauce_names = new(){ "none" };
    List<string> flavor_names = new() { "none" };
    List<string> topping_names = new() { "none" };
    List<string> beverage_names = new() { "none" };

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
       
        
    }

    public void Init(GameManager gm)
    {   
        gameManager = gm;
        jsonReader = GameObject.Find("GameManager").GetComponent<JSONReader>();
        unlockReader = GameObject.Find("GameManager").GetComponent<MachineUnlockReader>();
        GetUnlocks();
        
        ReturnIceCream();
        
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
        int tempXPRead = gameManager.GetExperience();

        if (tempXPRead >= 0)
        {
            Zero[] level0 = unlockReader.ReturnZeroLevel();


            foreach (Zero data in level0)
            {
                cone_names.Add(data.cone_unlock);
                sauce_names.Add(data.sauces_unlock);
                flavor_names.Add(data.flavor_unlock);
                topping_names.Add(data.topping_unlock);
                beverage_names.Add(data.beverage_unlock);
            }
        }
         if (tempXPRead >= 1000)
        {
            One[] level1 = unlockReader.ReturnOneLevel();
            foreach (One data in level1)
            {
                cone_names.Add(data.cone_unlock);
                sauce_names.Add(data.sauces_unlock);
                flavor_names.Add(data.flavor_unlock);
                topping_names.Add(data.topping_unlock);
                beverage_names.Add(data.beverage_unlock);
            }
        }
         if (tempXPRead >= 2000)
        {
            Two[] level2 = unlockReader.ReturnTwoLevel();
            foreach (Two data in level2)
            {
                cone_names.Add(data.cone_unlock);
                sauce_names.Add(data.sauces_unlock);
                flavor_names.Add(data.flavor_unlock);
                topping_names.Add(data.topping_unlock);
                beverage_names.Add(data.beverage_unlock);
            }
        }
          if (tempXPRead >= 3000)
        {
            Three[] level3 = unlockReader.ReturnThreeLevel();
            foreach (Three data in level3)
            {
                cone_names.Add(data.cone_unlock);
                sauce_names.Add(data.sauces_unlock);
                flavor_names.Add(data.flavor_unlock);
                topping_names.Add(data.topping_unlock);
                beverage_names.Add(data.beverage_unlock);
            }
        }
        if (tempXPRead >= 4000)
                {
            Four[] level4 = unlockReader.ReturnFourLevel();
            foreach (Four data in level4)
            {
                cone_names.Add(data.cone_unlock);
                sauce_names.Add(data.sauces_unlock);
                flavor_names.Add(data.flavor_unlock);
                topping_names.Add(data.topping_unlock);
                beverage_names.Add(data.beverage_unlock);
            }
        }
         if (tempXPRead >= 5000)
        {
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

    
   