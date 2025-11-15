using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingMenu : MonoBehaviour
{
    public Slider VolumeSlider;
    public Slider SensSlider;
    public S_PlayerController playerController;

    void Start()
    {
        // Load saved values
        VolumeSlider.value = PlayerPrefs.GetFloat("Volume", 1f);
        SensSlider.value   = PlayerPrefs.GetFloat("Sensitivity", 0.5f);

        VolumeSlider.onValueChanged.AddListener(delegate { ChangeVolume(); });
        SensSlider.onValueChanged.AddListener(delegate { ChangeSensitivity(); });

        // Apply saved sens when menu opens
        ChangeSensitivity();
    }

    public void ChangeVolume()
    {
        AudioListener.volume = VolumeSlider.value;
        PlayerPrefs.SetFloat("Volume", VolumeSlider.value);
        PlayerPrefs.Save();
    }

    public void ChangeSensitivity()
    {
        float sens = SensSlider.value;

        if (playerController != null)
            playerController.speed_of_camera = sens;

        PlayerPrefs.SetFloat("Sensitivity", sens);
        PlayerPrefs.Save();
    }

    public void GotoMain()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void Update()
    {
        Debug.Log("Volume = " + PlayerPrefs.GetFloat("Volume") + " Sens = " + PlayerPrefs.GetFloat("Sensitivity"));
    }
}
