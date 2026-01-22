using UnityEngine;

[System.Serializable]
public class PlayerData
{
    //private GameObject hero;
    public int health;
    public int magic;
    public float[]position;
    
   // hero = GameObject.FindGameObjectWithTag("Hero");

    public PlayerData(PlayerContoller player)// constructor
    {
       position = new float[3];
       position[0] = player.transform.position.x;
       position[1] = player.transform.position.y;
       position[2] = player.transform.position.z;
       
    }
    
}
