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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Animate(int value)
    {   
        if (chosenModel != null)
        {
            chosenModel.GetComponent<Animator>().SetInteger("Action", value);
        }
        
    }
}
