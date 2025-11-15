using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class S_BubbleChecker : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public List<Sprite> coneImages;

    public List<Sprite> drinkImages;

     public List<Sprite> sauceImages;

     public List<Sprite> toppingImages;

    public List<Sprite> flavorImages;

    public SpriteRenderer coneImage;
    public SpriteRenderer drinkImage;
    public SpriteRenderer sauceImage;
    public SpriteRenderer toppingImage;
    public SpriteRenderer flavorImage;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetThisRequest(IceCreams ic)
    {
        IceCreams iceCream = ic;
        // Cones
        if (coneImage != null && iceCream.cones.Length > 0 && coneImages != null)
        {
            Sprite s = coneImages.Find(x => x.name == iceCream.cones[0].name);
            if (s != null) coneImage.sprite = s;
        }

        // Drinks
        if (drinkImage != null && iceCream.beverages.Length > 0 && drinkImages != null)
        {
            Sprite s = drinkImages.Find(x => x.name == iceCream.beverages[0].name);
            if (s != null) drinkImage.sprite = s;
        }

        // Sauces
        if (sauceImage != null && iceCream.sauces.Length > 0 && sauceImages != null)
        {
            Sprite s = sauceImages.Find(x => x.name == iceCream.sauces[0].name);
            if (s != null) sauceImage.sprite = s;
        }

        // Toppings
        if (toppingImage != null && iceCream.toppings.Length > 0 && toppingImages != null)
        {
            Sprite s = toppingImages.Find(x => x.name == iceCream.toppings[0].name);
            if (s != null) toppingImage.sprite = s;
        }

        // Flavors
        if (flavorImage != null && iceCream.flavors.Length > 0 && flavorImages != null)
        {
            Sprite s = flavorImages.Find(x => x.name == iceCream.flavors[0].name);
            if (s != null) flavorImage.sprite = s;
        }


    }
}
