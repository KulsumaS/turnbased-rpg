using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 260, 100, 30), "Load"))
        {
            PlayerGameController.control.Load();
        }
        if (GUI.Button(new Rect(10, 280, 100, 30), "Save"))
        {
            PlayerGameController.control.Save();
        }
    }
        
    
}
