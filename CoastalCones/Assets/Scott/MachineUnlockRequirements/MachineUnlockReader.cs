using UnityEngine;

public class MachineUnlockReader : MonoBehaviour
{
    public TextAsset jsonFile;

    void Start()
    {
        MachineUnlocks machineUnlockData = JsonUtility.FromJson<MachineUnlocks>(jsonFile.text);

        foreach (Zero data in machineUnlockData.zero)
        {
            Debug.Log("Found Unlock: " + data.sauces_unlock + " " + data.cone_unlock + " " + data.flavor_unlock + " " + data.topping_unlock + " " + data.beverage_unlock);


        }

        foreach (One data in machineUnlockData.one)
        {
            Debug.Log("Found Unlock: " + data.sauces_unlock + " " + data.cone_unlock + " " + data.flavor_unlock + " " + data.topping_unlock + " " + data.beverage_unlock);


        }

        foreach (Two data in machineUnlockData.two)
        {
            Debug.Log("Found Unlock: " + data.sauces_unlock + " " + data.cone_unlock + " " + data.flavor_unlock + " " + data.topping_unlock + " " + data.beverage_unlock);


        }

        foreach (Three data in machineUnlockData.three)
        {
            Debug.Log("Found Unlock: " + data.sauces_unlock + " " + data.cone_unlock + " " + data.flavor_unlock + " " + data.topping_unlock + " " + data.beverage_unlock);


        }

        foreach (Four data in machineUnlockData.four)
        {
            Debug.Log("Found Unlock: " + data.sauces_unlock + " " + data.cone_unlock + " " + data.flavor_unlock + " " + data.topping_unlock + " " + data.beverage_unlock);


        }
        
        foreach (Five data in machineUnlockData.five)
        {
            Debug.Log("Found Unlock: " + data.sauces_unlock + " " + data.cone_unlock + " " + data.flavor_unlock + " " + data.topping_unlock + " " + data.beverage_unlock);
            
            
        }
    }
}