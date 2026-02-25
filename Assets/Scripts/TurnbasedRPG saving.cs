using UnityEngine;
using System.IO;

public class TurnbasedRPGsaving : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private string rpgSaveLocation;
    public FighterStats stats;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rpgSaveLocation = Path.Combine(Application.persistentDataPath, "saveData.json");
    }


    public void rpgSaveGame()
    {
        SaveData saveData = new SaveData
        {
            heroHealth = GameObject.FindGameObjectWithTag("Hero").stats.health,
            heroMagic = GameObject.FindGameObjectWithTag("Hero").stats.magic
        };
        File.WriteAllText(rpgSaveLocation, JsonUtility.ToJson(saveData));

    }

    public void rpgLoadGame()
    {
        if (File.Exists(rpgSaveLocation))
        {
            SaveData saveData = JsonUtility.FromJson<SaveData>(File.ReadAllText(rpgSaveLocation));
            GameObject.FindGameObjectWithTag("Player").transform.position = saveData.playerPosition;
        }
        else
        {
            rpgSaveGame();
        }

    }

}