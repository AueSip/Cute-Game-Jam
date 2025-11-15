
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]



public class Script_NPC_Audio : MonoBehaviour
{
    public List<AudioClip> negative_List;
    public List<AudioClip> appear_List;
    public List<AudioClip> finished_List;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    AudioSource asource;
    void Start()
    {
        asource = GetComponent<AudioSource>();
        asource.spatialBlend = 0;
        asource.maxDistance = 60;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PlayNegativeSound()
    {
        asource.clip = negative_List[Random.Range(0, negative_List.Count)];
        asource.Play();
        

    }

    public float PlayAppearList()
    {
        asource.clip = appear_List[Random.Range(0, appear_List.Count)];
        asource.Play();
        return asource.clip.length;
    }

    public void PlayFinishedList()
    {
        asource.clip = finished_List[Random.Range(0, finished_List.Count)];
        asource.Play();

    }

}
    
