using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonUi : MonoBehaviour
{
    public void RestartButton()
    {
        SceneManager.LoadScene("Overworld");
    }
}
