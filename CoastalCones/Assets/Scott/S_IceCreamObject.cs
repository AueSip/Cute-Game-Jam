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
    

    public List<GameObject> conesToDisable;
     public List<GameObject> iceCreamsToDisable;
    public List<GameObject> toppingsToDisable;
    public List<GameObject> saucesToDisable;
    public List<GameObject> beveragesToDisable;

    bool hasIcecream = false;

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

        
        iceCream.SetToppingVal(0, gm.GetComponent<JSONReader>().ReturnThisTopping("none"));
        iceCream.SetSauceVal(0, gm.GetComponent<JSONReader>().ReturnThisSauce("none"));
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
            DisableTargetMeshes(conesToDisable);
            SetMeshMaterial(coneObject, chosenCone.name);
        }
    }

    public void UpdateIceCreamMesh(Flavor chosenFlavor)
    {   
        iceCream.SetFlavorVal(0, chosenFlavor);
        if (iceCream.flavors[0].name != "none")
        {   
            hasIcecream = true;
            //UpdateRenderObject(iceCreamObject, true);
            DisableTargetMeshes(iceCreamsToDisable);
            SetMeshMaterial(iceCreamObject, chosenFlavor.name);
        }
        
    }

     public void UpdateToppingMesh(Topping chosenTopping)
    {   if (hasIcecream){
        iceCream.SetToppingVal(0, chosenTopping);
        if (iceCream.toppings[0].name != "none")
        {
           // UpdateRenderObject(toppingObject, true);
            DisableTargetMeshes(toppingsToDisable);
            SetMeshMaterial(toppingObject, chosenTopping.name);
        }
    }
    }

    public void UpdateSauceMesh(Sauce chosenSauce)
    {    if (hasIcecream){
        iceCream.SetSauceVal(0, chosenSauce);
        if (iceCream.sauces[0].name != "none")
        {
            //UpdateRenderObject(sauceObject, true);
            DisableTargetMeshes(saucesToDisable);
            SetMeshMaterial(sauceObject, chosenSauce.name);
        }
    }
    }

     public void UpdateBeverageMesh(Beverage chosenBeverage)
    {   
        iceCream.SetBeverageVal(0, chosenBeverage);
        if (iceCream.beverages[0].name != "none")
        {
            //UpdateRenderObject(beverageObject, true);
            DisableTargetMeshes(beveragesToDisable);
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

    public void DisableTargetMeshes(List<GameObject> meshes)
    {
        foreach (GameObject mesh in meshes)
        {
             if (mesh != null)
                {
                    mesh.gameObject.SetActive(false);
                }
        }
    }

    




}
