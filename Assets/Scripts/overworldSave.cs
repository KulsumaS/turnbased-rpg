using UnityEngine;

public class overworldSave : MonoBehaviour
{
    public SaveContoller saveContoller;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        saveContoller.LoadGame();
    }

    // Update is called once per frame
    void Update()
    {
        saveContoller.SaveGame();
    }
}
