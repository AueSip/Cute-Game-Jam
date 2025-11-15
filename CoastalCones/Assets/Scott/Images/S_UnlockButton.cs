using System.Collections.Generic;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class S_UnlockButton : MonoBehaviour
{
    public JSONReader json;
    public string unlocks_item;

    private GameManager gameManager;

    public TextMeshProUGUI textV;
    public string type;

    private float cost;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGameManager(GameManager gm)
    {
        gameManager = gm;
        
    }

    public void ReturnUnlock()
    {
        if(gameManager.GetMoney() >= cost)
        {   
            gameManager.SetMoney((int)(gameManager.GetMoney() - cost));
            GetComponentsInParent<S_UnlockManager>()[0].AddThisUnlockToList(unlocks_item);
            
        }
    }

    

    public void CheckIsUnlocked(List<string> bought)
    {
        if (bought.Contains(unlocks_item))
        {
            this.GetComponent<Button>().interactable = false;
        }

        switch (type) // make case-insensitive
        {
            case "cone":
                cost = json.ReturnThisCone(unlocks_item).cost;
                break;
            case "topping":
                 cost = json.ReturnThisTopping(unlocks_item).cost;
                break;
            case "beverage":
                 cost = json.ReturnThisBeverage(unlocks_item).cost;
                break;
            case "flavor":
                cost = json.ReturnThisFlavor(unlocks_item).cost;
                break;
            case "sauce":
                cost = json.ReturnThisSauce(unlocks_item).cost;
                break;

            

        }
        textV.text = cost.ToString();
    }


}
