using System.Collections.Generic;
using UnityEngine;

public class S_IceCreamObject : MonoBehaviour
{   

    private JSONReader listOfItems;
    
    private GameManager gameManager;
    public IceCreams iceCream = new();
    public GameObject coneObject;
     public GameObject iceCreamObject;
    public GameObject toppingObject;
    public GameObject sauceObject;
    public GameObject beverageObject;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {       

    }

    public void Init(GameManager gm)
    {
       gameManager = gm;
       iceCream.GenerateYourIceCream();
        UpdateConeMesh(gm.GetComponent<JSONReader>().ReturnThisCone("cone"));
         UpdateIceCreamMesh(gm.GetComponent<JSONReader>().ReturnThisFlavor("none"));
        UpdateToppingMesh(gm.GetComponent<JSONReader>().ReturnThisTopping("none"));
        UpdateSauceMesh(gm.GetComponent<JSONReader>().ReturnThisSauce("none"));
        UpdateBeverageMesh(gm.GetComponent<JSONReader>().ReturnThisBeverage("none"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateConeMesh(Cone chosenCone)
    {   
        iceCream.SetConeValue(0, chosenCone);
        if (iceCream.cones[0].name != "none")
        {
            //UpdateRenderObject(coneObject, true);
            SetMeshMaterial(coneObject, chosenCone.name);
        }
    }

    public void UpdateIceCreamMesh(Flavor chosenFlavor)
    {   
        iceCream.SetFlavorVal(0, chosenFlavor);
        if (iceCream.flavors[0].name != "none")
        {
            //UpdateRenderObject(iceCreamObject, true);
            SetMeshMaterial(iceCreamObject, chosenFlavor.name);
        }
        
    }

     public void UpdateToppingMesh(Topping chosenTopping)
    {   
        iceCream.SetToppingVal(0, chosenTopping);
        if (iceCream.toppings[0].name != "none")
        {
           // UpdateRenderObject(toppingObject, true);
            SetMeshMaterial(toppingObject, chosenTopping.name);
        }
    }

    public void UpdateSauceMesh(Sauce chosenSauce)
    {   
        iceCream.SetSauceVal(0, chosenSauce);
        if (iceCream.sauces[0].name != "none")
        {
            //UpdateRenderObject(sauceObject, true);
            SetMeshMaterial(sauceObject, chosenSauce.name);
        }
    }

     public void UpdateBeverageMesh(Beverage chosenBeverage)
    {   
        iceCream.SetBeverageVal(0, chosenBeverage);
        if (iceCream.beverages[0].name != "none")
        {
            //UpdateRenderObject(beverageObject, true);
            SetMeshMaterial(beverageObject, chosenBeverage.name);
        }
    }


    
    void SetMeshMaterial(GameObject mesh, string modelName)
    {   
        Transform target = mesh.transform.Find(modelName);
        if (target != null)
        {
            target.gameObject.SetActive(true);
        }
        else
        {
            Debug.LogWarning($"Model '{modelName}' not found under '{this.name}'");
        }
        
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
