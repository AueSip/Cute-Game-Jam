
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public S_DayCycle dayCycleSC;
    public PlayerReader playerReader;

    public GameObject playerC;
    public SaveData saveData;
    public S_IceCreamGenerator iceCreamGenerator;
    public S_NPC_SpawnManager npcSpawnManagement;

    public S_Interact interactManager;
    public Script_NPC_Audio npcAudioManager;

    public Script_Music_Manager musicManager;
    public S_Ui_Manager uiManager;

    public S_UnlockManager unlockManager;

    public S_IceCreamObject iceCreamObj;
    public Transform iceCreamSpawnLocation;
    int money;
    int experience;
    int rating;
    int currentDay;
    public float npc_timer;
    public float npc_timerMax;
    public float npc_timerMin;
    List<string> bought_machines;

    S_ItemToCheckFor[] arrayOfItems;

    private int defExperience = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Start()
    {   
        waitToLoad();
    }

    public async void waitToLoad()
    {
        await Awaitable.WaitForSecondsAsync(2f);
        
          if (saveData.DoesPlayerSaveExist())
        {
        SetValue();
         }
        else
        {
            saveData.SaveToJson();
            SetValue();
        }
        unlockManager.Init(this);
        arrayOfItems = GameObject.FindObjectsByType<S_ItemToCheckFor>(FindObjectsSortMode.None);
        musicManager.StartMorningTracks();
    }

    // Update is called once per frame
    void Update()
    {

    }

     public void SetExperience(int value)
    {
        experience = value;
         uiManager.UpdateExperience(experience);
    }

    public int GetExperience()
    {
        return experience;
    }

    public int GetDefaultExperience()
    {
        return defExperience;
    }

    public void SetDefaultExperience(int val)
    {
         defExperience = val;
    }

     public void SetRating(int value)
    {
        rating = Mathf.Clamp(value, 0,5);
        uiManager.UpdateRatingScale(rating);
    }

    public int GetRating()
    {
        return rating;
    }

     public void SetMoney(int value)
    {
        money = Mathf.Clamp(value, 0,9999);
        uiManager.UpdateCurrency(money);
    }

    public int GetMoney()
    {
        return money;
    }

        public void SetBoughtMachines(List<string> machines)
    {
        bought_machines = new List<string>(machines); // makes a clean copy
    }

    public void AddBoughtMachine(string machineName)
    {
        if (!bought_machines.Contains(machineName))
        {
            bought_machines.Add(machineName);
        }
    }

    public List<string> GetBoughtMachines()
    {
        return bought_machines;
    }

       public void SetCurrentDay(int value)
    {
        currentDay = value;
        uiManager.UpdateDay(currentDay);
    }

    public int GetCurrentDay()
    {
        return currentDay;
    }





    public void GameLoop()
    {   
        playerC.GetComponent<S_PlayerController>().SetCameraLock(false);
        foreach (S_ItemToCheckFor item in arrayOfItems)
        {
            if (!bought_machines.Contains(item.GetName()))
            {
                item.Locked();
            }
        }
        Debug.Log("Day Start");
        dayCycleSC.Startday();
        
        iceCreamGenerator.Init(this);
        npcSpawnManagement.Init(this);
        dayCycleSC.gm = this;
        SpawnIceCream();
       
        
    }

    public void DoEndDay()
    {
        saveData.playerSave.experience = experience;
        saveData.playerSave.rating = rating;
        saveData.playerSave.money = money;
        saveData.playerSave.currentDay = currentDay + 1; // day advance
        saveData.playerSave.bought_machines = bought_machines;
        saveData.SaveToJson();
        
        LoadScene();
        
        
    }

    public void SpawnNPCS()
    {

    }

    public void GetIceCreamGenerator()
    {
        
    }

    public void SetValue()
    {   
      
        SetExperience(playerReader.ReturnPlayerSave().experience);
        print(experience);
       
        SetRating(playerReader.ReturnPlayerSave().rating);
        print(rating);
        
        SetMoney(playerReader.ReturnPlayerSave().money);
        print(money);
        
        SetBoughtMachines(playerReader.ReturnPlayerSave().bought_machines);
        print(bought_machines);

        SetCurrentDay(playerReader.ReturnPlayerSave().currentDay);
        print(currentDay);

        SetDefaultExperience(playerReader.ReturnPlayerSave().experience);
    
        
        
    }


    public async void SpawnIceCream()
    {
        S_IceCreamObject temp = Instantiate(iceCreamObj,iceCreamSpawnLocation);
        temp.Init(this);
        await Awaitable.WaitForSecondsAsync(5f);
        SpawnIceCream();
    }

    public S_Ui_Manager ReturnUIManager()
    {   
       return uiManager;
    }

    public void SetPlayerItemHeld(bool val)
    {
        interactManager.SetItemHeld(val);
    }

    public async void LoadScene()
    {    
        StopAllCoroutines();
        await Awaitable.WaitForSecondsAsync(2f);
       if (currentDay == 0)
        {
            SceneManager.LoadScene("Day1");
        }
        if (currentDay == 1)
        {
             SceneManager.LoadScene("Day2");
        }
        if (currentDay == 2)
        {
             SceneManager.LoadScene("Day3");
        }
        if (currentDay == 3)
        {
             SceneManager.LoadScene("Day4");
        }
        if (currentDay == 4)
        {
             SceneManager.LoadScene("Day5");
        }
        if (currentDay >= 5)
        {   
            if ( money >= 1000)
            {
                SceneManager.LoadScene("WinScreen"); 
            }
            else
            {
                SceneManager.LoadScene("LoseScreen");
            }
            
        
           
        
    }
    }
   
   
    
   

}
