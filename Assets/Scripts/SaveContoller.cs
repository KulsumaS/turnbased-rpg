using System.IO;
using UnityEngine;

public class SaveContoller : MonoBehaviour
{
    private string saveLocation;
    public FighterStats stats;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        saveLocation = Path.Combine(Application.persistentDataPath, "saveData.json");
        GameObject heroGameObject = GameObject.FindGameObjectWithTag("Hero");
        stats = heroGameObject.GetComponent<FighterStats>();
        
        
        LoadGame();
    }

    public void SaveGame()
    {
        SaveData saveData = new SaveData
        {
            playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position, 
            heroHealth = stats.health,
            heroMagic = stats.magic,
            heroMelee = stats.melee,
            heroMagicRange = stats.magicRange,
            heroDefense = stats.defense,
            heroExperience = stats.experience,
            heroSpeed = stats.speed,
           
        };
        File.WriteAllText(saveLocation, JsonUtility.ToJson(saveData));

    }

    public void LoadGame()
    {
        if (File.Exists(saveLocation))
        {
            SaveData saveData = JsonUtility.FromJson<SaveData>(File.ReadAllText(saveLocation));
            GameObject.FindGameObjectWithTag("Player").transform.position = saveData.playerPosition;
           stats.health = saveData.heroHealth;
           stats.magic = saveData.heroMagic;
           stats.melee = saveData.heroMelee;
           stats.magicRange = saveData.heroMagicRange;
           stats.defense = saveData.heroDefense;
           stats.experience = saveData.heroExperience;
           stats.speed = saveData.heroSpeed;
        }
        else
        {
            SaveGame();
        }
        
    }
   
}  

