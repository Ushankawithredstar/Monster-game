using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Gameplay");

        int selectedChar =
            int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);

        int[] a = new int[10];

        a[selectedChar] = 10;

        Debug.Log("Button pressed.");
    }
}
