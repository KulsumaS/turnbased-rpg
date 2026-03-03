using UnityEngine;
using System.IO;
using UnityEditor;

public class rpgSaving : MonoBehaviour
{
    private string HerosaveLocation;
    private FighterStats attackerStats;
    public GameObject hero;
 

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hero = GameObject.FindGameObjectWithTag("Hero");
        attackerStats = hero.GetComponent<FighterStats>();
        HerosaveLocation = Path.Combine(Application.persistentDataPath, "herosaveData.json");
        
    }

    public void rpgSaveGame()
    {
        SaveData herosaveData = new SaveData
        {
            heroHealth = attackerStats.health,
        };
        File.WriteAllText(HerosaveLocation, JsonUtility.ToJson(herosaveData));

    }

    public void rpgLoadGame()
    {
        if (File.Exists(HerosaveLocation))
        {
            SaveData herosaveData = JsonUtility.FromJson<SaveData>(File.ReadAllText(HerosaveLocation));
            attackerStats.health = herosaveData.heroHealth;
        }
        else
        {
            rpgSaveGame();
        }
        
    }

}
