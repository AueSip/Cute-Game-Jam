

using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class S_Ui_Manager : MonoBehaviour
{   

    public Image progressBar;

    public Image sunDial;
    public TextMeshProUGUI currencyCount;

    public TextMeshProUGUI dayCount;

    public TextMeshProUGUI experienceCount;

    public TextMeshProUGUI timerCount;

    private float progressSizeX;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        progressSizeX = progressBar.rectTransform.rect.width;
    }

    // Update is called once per frame
    void Update()
    {
        
    }   

    public void UpdateRatingScale(float Value)
    {
       float newWidth = progressSizeX / Value;
        progressBar.rectTransform.sizeDelta = new Vector2(newWidth, progressBar.rectTransform.sizeDelta.y);
    }

        public void UpdateCurrency(int amount)
    {
        currencyCount.text = amount.ToString();
    }

    public void UpdateDay(int day)
    {
        dayCount.text = day.ToString();
    }

    public void UpdateExperience(int exp)
    {
        experienceCount.text = exp.ToString();
    }

    public void UpdateTimer(int timer)
    {
        timerCount.text = timer.ToString();
    }

    //Updates Dial Based On Time
       public void UpdateDialRotation(float value, float maxTime)
        {
           
            float t = Mathf.Clamp01((float)value / maxTime);
            float angle = t * 360f;

           
            Vector3 newRot = new Vector3(0, 0, -angle);

           
            RectTransform rt = sunDial.GetComponent<RectTransform>();
            rt.SetPositionAndRotation(rt.position, Quaternion.Euler(newRot));
        }
}

