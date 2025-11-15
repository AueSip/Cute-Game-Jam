using System.IO;
using UnityEngine;

public class PlayerReader : MonoBehaviour
{
    TextAsset jsonFile;
    PlayerSaves playerSaveData;
    void Start()
    {

    }


    public PlayerSave ReturnPlayerSave()
{
    // Check if data is already loaded
    
    LoadPlayerSave();
    

    // Return first player save
    return playerSaveData.playerSaves[0];
}

// Helper method to load from JSON
    private void LoadPlayerSave()
    {
        string filePath = Path.Combine(Application.persistentDataPath, "playerdata.json");

        if (!File.Exists(filePath))
        {
            Debug.LogWarning("Player save file not found: " + filePath);
            // Optionally, create default save
            playerSaveData = new PlayerSaves { playerSaves = new PlayerSave[] { new PlayerSave() } };
            return;
        }

        string json = File.ReadAllText(filePath);
        playerSaveData = JsonUtility.FromJson<PlayerSaves>(json);

        if (playerSaveData == null || playerSaveData.playerSaves == null || playerSaveData.playerSaves.Length == 0)
        {
            Debug.LogError("Failed to load player save from JSON. Creating default save.");
            playerSaveData = new PlayerSaves { playerSaves = new PlayerSave[] { new PlayerSave() } };
        }
}
}