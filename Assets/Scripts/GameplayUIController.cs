using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameplayUIController : MonoBehaviour
{

    public static void RestartButton() 
    { 
        //reloads active scene.
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public static void HomeButton() 
    { 
        SceneManager.LoadScene("MainMenu"); 
    }
}
