using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private SaveContoller m_SaveContoller;
    void OnGUI()
    {
        if (GUI.Button(new Rect(10, 260, 100, 30), "Load"))
        {
            
        }
        if (GUI.Button(new Rect(10, 280, 100, 30), "Save"))
        {
            m_SaveContoller.SaveGame();
        }
    }
        
    
}
