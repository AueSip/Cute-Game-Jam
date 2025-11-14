using System.Collections.Generic;
using UnityEngine;

public class S_IceCreamObject : MonoBehaviour
{   

    public JSONReader listOfItems;
    public IceCreams iceCream = new();
    public GameObject coneObject;
     public GameObject iceCreamObject;
    public GameObject toppingObject;
    public GameObject sauceObject;
    public GameObject beverageObject;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {   
        iceCream.GenerateYourIceCream();
         UpdateConeMesh(listOfItems.ReturnThisCone("cone"));
        
        /*
       
        UpdateIceCreamMesh(listOfItems.ReturnThisFlavor("chocolate"));
        UpdateToppingMesh(listOfItems.ReturnThisTopping("bluedust"));
        UpdateSauceMesh(listOfItems.ReturnThisSauce("lime"));
        UpdateBeverageMesh(listOfItems.ReturnThisBeverage("pok"));
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateConeMesh(Cone chosenCone)
    {   
        iceCream.SetConeValue(0, chosenCone);
        if (iceCream.cones[0].name != null)
        {
            UpdateRenderObject(coneObject, true);
            SetMeshMaterial(coneObject, chosenCone.color);
        }
    }

    public void UpdateIceCreamMesh(Flavor chosenFlavor)
    {   
        iceCream.SetFlavorVal(0, chosenFlavor);
        if (iceCream.flavors[0].name != null)
        {
            UpdateRenderObject(iceCreamObject, true);
            SetMeshMaterial(iceCreamObject, chosenFlavor.color);
        }
        
    }

     public void UpdateToppingMesh(Topping chosenTopping)
    {   
        iceCream.SetToppingVal(0, chosenTopping);
        if (iceCream.toppings[0].name != null)
        {
            UpdateRenderObject(toppingObject, true);;
            SetMeshMaterial(toppingObject, chosenTopping.color);
        }
    }

    public void UpdateSauceMesh(Sauce chosenSauce)
    {   
        iceCream.SetSauceVal(0, chosenSauce);
        if (iceCream.sauces[0].name != null)
        {
            UpdateRenderObject(sauceObject, true);
            SetMeshMaterial(sauceObject, chosenSauce.color);
        }
    }

     public void UpdateBeverageMesh(Beverage chosenBeverage)
    {   
        iceCream.SetBeverageVal(0, chosenBeverage);
        if (iceCream.beverages[0].name != null)
        {
            UpdateRenderObject(beverageObject, true);
            SetMeshMaterial(beverageObject, chosenBeverage.color);
        }
    }


    
    void SetMeshMaterial(GameObject mesh, string color)
    {   
        
        Color MyColour = Color.clear;
        ColorUtility.TryParseHtmlString (color, out MyColour);
        mesh.GetComponent<Renderer>().material.SetColor("_BaseColor", MyColour);
        
    }

    void UpdateRenderObject(GameObject obj, bool value)
    {
        if (obj.GetComponent<MeshRenderer>() != null)
        {
            obj.GetComponent<MeshRenderer>().enabled = value;
        }

    }

    public IceCreams ReturnIceCream()
    {
        return iceCream;
    }

    




}
