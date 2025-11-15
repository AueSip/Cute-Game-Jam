using System.Collections.Generic;
using UnityEngine;

public class S_AnimatorManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public List<GameObject> npcModels;

    private GameObject chosenModel;
    void Start()
    {   
        chosenModel = npcModels[Random.Range(0,npcModels.Count)];
        chosenModel.SetActive(true);
        BlinkRandom();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetSpeaking()
    {   
        if (chosenModel != null)
        {   
            print("I AM SPEAKING");
            chosenModel.GetComponent<Animator>().SetTrigger("Speaking");
        }
        
    }


    public async void BlinkRandom()
    {
        await Awaitable.WaitForSecondsAsync(Random.Range(0,2));
         if (chosenModel != null)
        {   
            print("I AM BLINKING");
            chosenModel.GetComponent<Animator>().SetTrigger("Blinking");
        }
        BlinkRandom();
    }
}
