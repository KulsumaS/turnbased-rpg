// using UnityEngine;
// using System.IO;
// using Unity.VisualScripting.Antlr3.Runtime.Misc;
//
//
// public class RpgSaving : MonoBehaviour
//
// {
//     
//     public FighterStats stats; // Start is called once before the first execution of Update after the MonoBehaviour is created
//     private string savePath;
//     void Start()
//     {
//         savePath = Path.Combine(Application.persistentDataPath, "rpgSave.json");
//         
//     }
//
//     public void SaveRpg()
//     {
//         SaveData saveData = new SaveData()
//         {
//             heroHealth = stats.health
//         };
//         
//         File.WriteAllText(savePath, JsonUtility.ToJson(saveData));
//     }
//
//     public void LoadRpg()
//     {
//         if (File.Exists(savePath))
//         {
//             SaveData saveData = JsonUtility.FromJson<SaveData>(File.ReadAllText(savePath));
//            stats.health = saveData.heroHealth;
//         }
//         else
//         {
//             SaveRpg();
//         }
//     }
// }

