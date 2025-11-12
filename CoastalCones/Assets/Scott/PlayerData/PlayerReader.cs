using UnityEngine;

public class PlayerReader : MonoBehaviour
{
    public TextAsset jsonFile;

    void Start()
    {
        PlayerSaves playerSaveData = JsonUtility.FromJson<PlayerSaves>(jsonFile.text);

        /*foreach (PlayerSave data in playerSaveData.playerSaves)
        {
            Debug.Log("Found data: " + data.experience + " " + data.rating + " " + data.money + " " + data.currentDay);
            foreach (string info in data.bought_machines)
            {
                Debug.Log("Found PlayerUnlocks:" + info);
            }
        }*/
    }
}