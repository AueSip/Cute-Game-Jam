using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class S_UnlockManager : MonoBehaviour
{   
    public GameManager gameManager;

    public List<Button> level1;
     public List<Button> level2;
      public List<Button> level3;
      public List<Button> level4;

    public List<Button> level5;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Init(GameManager gm)
    {   
        gameManager = gm;
        Cursor.lockState = CursorLockMode.None;
        int tempXPRead = gameManager.GetExperience();
        if (tempXPRead >= 1000)
        {
            foreach (Button b in level1)
            {   
                b.GetComponent<S_UnlockButton>().SetGameManager(gameManager);
                b.interactable = true;
               
            }
        }

        if (tempXPRead >= 2000)
        {
            foreach (Button b in level2)
            {   
                b.GetComponent<S_UnlockButton>().SetGameManager(gameManager);
                b.interactable = true;
            }
        }

        if (tempXPRead >= 3000)
        {
            foreach (Button b in level3)
            {   
                b.GetComponent<S_UnlockButton>().SetGameManager(gameManager);
                b.interactable = true;
            }
        }

        if (tempXPRead >= 4000)
        {
            foreach (Button b in level4)
            {   
                b.GetComponent<S_UnlockButton>().SetGameManager(gameManager);
                b.interactable = true;
            }
        }

        if (tempXPRead >= 5000)
        {
            foreach (Button b in level5)
            {   
                b.GetComponent<S_UnlockButton>().SetGameManager(gameManager);
                b.interactable = true;
            }
        }

        UpdateButtonStatus();




    }

    public void AddThisUnlockToList(string unlock)
    {
        gameManager.AddBoughtMachine(unlock);
        print("added");
        UpdateButtonStatus();
    }


    public void UpdateButtonStatus()
    {   
         foreach (Button b in level1)
        {   
            b.GetComponent<S_UnlockButton>().SetGameManager(gameManager);
             b.GetComponent<S_UnlockButton>().CheckIsUnlocked(gameManager.GetBoughtMachines());
        }

        foreach (Button b in level2)
        {   
            b.GetComponent<S_UnlockButton>().SetGameManager(gameManager);
             b.GetComponent<S_UnlockButton>().CheckIsUnlocked(gameManager.GetBoughtMachines());
        }

        foreach (Button b in level3)
        {   
            b.GetComponent<S_UnlockButton>().SetGameManager(gameManager);
             b.GetComponent<S_UnlockButton>().CheckIsUnlocked(gameManager.GetBoughtMachines());
        }

        foreach (Button b in level4)
        {   
            b.GetComponent<S_UnlockButton>().SetGameManager(gameManager);
             b.GetComponent<S_UnlockButton>().CheckIsUnlocked(gameManager.GetBoughtMachines());
        }

        foreach (Button b in level5)
        {   
            b.GetComponent<S_UnlockButton>().SetGameManager(gameManager);
             b.GetComponent<S_UnlockButton>().CheckIsUnlocked(gameManager.GetBoughtMachines());
        }
        
        
    }

    
    

    
    

    public void StartDay()
    {   
        this.gameObject.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        gameManager.GameLoop();
    }


  
}
