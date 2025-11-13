using System.IO;
using UnityEngine;
using UnityEngine.Rendering;

public class SaveData : MonoBehaviour
{
    public PlayerSave playerSave = new PlayerSave();

    public void SaveToJson()
    {

        PlayerSaves wrapper = new PlayerSaves();
        wrapper.playerSaves = new PlayerSave[] { playerSave };

        string json = JsonUtility.ToJson(wrapper, true);
        string filePath = Path.Combine(Application.persistentDataPath + "/playerdata.json");
        Debug.Log(filePath);
        File.WriteAllText(filePath, json);
        Debug.Log($"saved to {filePath}");
        
    }
        
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    
    }
}
