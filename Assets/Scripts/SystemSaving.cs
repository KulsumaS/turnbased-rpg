using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary; 

public static class SystemSaving 
{
   //public static void SavePlayer(PlayerContoller player)
   //{
      //BinaryFormatter formatter = new BinaryFormatter();
     // string path = Application.persistentDataPath + "/player.dat";
     // FileStream stream = new FileStream(path, FileMode.Create);

      //PlayerData data = new PlayerData(player);
      
      //formatter.Serialize(stream, data);
      //stream.Close();
     // Debug.Log("Player saved");
  // }

   //public static PlayerData LoadPlayer()
  // {
      //string path = Application.persistentDataPath + "/player.dat";
      //if (File.Exists(path))
      //{
         //BinaryFormatter formatter = new BinaryFormatter();
         //FileStream stream = new FileStream(path, FileMode.Open); 
         
        //PlayerData data= formatter.Deserialize(stream) as PlayerData;
        //stream.Close();
        
       // return data;
         
     // }
     // else
     // {
        // Debug.LogError("Save file not found in" + path);
         //return null;
     // }
   //}
}
