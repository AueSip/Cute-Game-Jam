
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]



public class Script_Sound_Player : MonoBehaviour
{
    public List<AudioClip> machine_List;
    public List<AudioClip> interact_List;
    public List<AudioClip> payment_List;
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

    public void PlayMachineList(int indx)
    {
        asource.clip = machine_List[indx];
        asource.Play();

    }

    public float PlayInteractList()
    {
        asource.clip = interact_List[Random.Range(0, interact_List.Count)];
        asource.Play();
        return asource.clip.length;
    }

    public void PlayPaymentList()
    {
        asource.clip = payment_List[Random.Range(0, payment_List.Count)];
        asource.Play();

    }

}
    
