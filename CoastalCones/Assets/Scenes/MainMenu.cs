using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
   public void PlayGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void SettingMenu()
    {
        SceneManager.LoadScene("SettingsMenu");
    }

    public void CreditMenu()
    {
        SceneManager.LoadScene("Credits");
    }

    public void Quitgame()
    {
        Application.Quit();
    }
}
