using System;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public class PlayerGameController : MonoBehaviour
{
    public static PlayerGameController control;
    [SerializeField] FighterStats fighterStats;
    [SerializeField] PlayerContoller playerContoller;
    
    public float health;
    public float magic;
    public float melee;
    public float magicRange;
    public float defense;
    public float speed;
    
    public float x;
    public float y;
    private string saveLocation;

    private void Awake()
    {
        if (control == null)
        {
            DontDestroyOnLoad(this.gameObject);
            control = this;
            
        }
        else if (control != this)
        {
            Destroy(this.gameObject);
        }
        
    }

    void Start()
    {
        saveLocation = Path.Combine(Application.persistentDataPath, "saveData.json");
        
    }

    /*public void Update()
    {
         health = fighterStats.health;
        magic = fighterStats.magic;
        melee = fighterStats.melee;
        magicRange = fighterStats.magicRange;
        defense = fighterStats.defense;
        speed = fighterStats.speed;
        
        x=playerContoller.x;
        y=playerContoller.y;
        Debug.Log(x);
    }*/

    public void Save()
    {
        SaveData saveData = new SaveData();
        {
            playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
        }
        
        File.WriteAllText(saveLocation, JsonUtility.ToJson(saveData));
        

        /*BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerData.dat");

        PlayerData data = new PlayerData();
        data.health = health;
        data.magic = magic;
        data.melee = melee;
        data.magicRange = magicRange;
        data.defense = defense;
        data.speed = speed;
        data.x = x;
        data.y = y;

        bf.Serialize(file, data);
        file.Close();
        Debug.Log("PlayerData saved");*/

    }

    public void Load()
    {
        if (File.Exists(saveLocation))
        {
            SaveData saveData = JsonUtility.FromJson<SaveData>(File.ReadAllText(saveLocation));
            
            GameObject.FindGameObjectWithTag("Player").transform.position = saveData.playerPosition;
        }
        else
        {
            Save();
        }
        
        /*if (File.Exists(Application.persistentDataPath + "/playerData.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath + "/playerData.dat",FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();
            health = data.health;
            magic = data.magic;
            melee = data.melee;
            magicRange = data.magicRange;
            defense = data.defense;
            speed = data.speed;

            x = data.x;
            y = data.y;

        }*/
    }
    
}
/*
[System.Serializable]
public class PlayerData
{
    public float health;
    public float magic;
    public float melee;
    public float magicRange;
    public float defense;
    public float speed;
    
    public Vector2 playerPosition;
}
*/


