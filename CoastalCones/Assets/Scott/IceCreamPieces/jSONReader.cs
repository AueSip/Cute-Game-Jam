using UnityEngine;

public class JSONReader : MonoBehaviour
{
    public TextAsset jsonFile;

    void Start()
    {
        IceCreams iceCreams = JsonUtility.FromJson<IceCreams>(jsonFile.text);

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
}