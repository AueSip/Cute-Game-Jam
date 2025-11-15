using UnityEngine;

public class Script_Music_Manager : MonoBehaviour
{
    public AudioSource music_Morning;
    public AudioSource music_Evening;


    public float fadeDuration =2f;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public bool CheckAudioPlaying(AudioSource audio)
    {

        return audio.isPlaying;
    }


    public void FadeOutAudio(AudioSource audio)
    {
        StartCoroutine(AudioHelper.FadeOut(audio, fadeDuration));
    }

    public void FadeInAudio(AudioSource audio)
    {
        StartCoroutine(AudioHelper.FadeIn(audio, fadeDuration));
    }

    public void StartMorningTracks()
    {  
        FadeOutAudio(music_Evening);
        FadeInAudio(music_Morning);
       
    }

    /*public void StartEveningTrack()
    {
        
        FadeInAudio(music_Morning);
        FadeOutAudio(music_Evening);
        
    }*/
    
    public bool CheckVolume(AudioSource audio)
    {
        return audio.volume >= 0.2f;
    }
}   

