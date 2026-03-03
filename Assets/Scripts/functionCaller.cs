using UnityEngine;

public class functionCaller : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public rpgSaving RpgSaving;
     void Start()
     {
         RpgSaving.rpgLoadGame();
     }

    // Update is called once per frame
     void Update()
     {
         RpgSaving.rpgSaveGame();
     }
}
