using UnityEngine;
using UnityEngine.SceneManagement;
// To integrate the button event listener, we need to attach the parent GO with this script attached
// to the button that we want the trigger to happen. Then we can search for the functions.

public class PlayButton : MonoBehaviour
{
    public void StartGame()
    {
        Debug.Log("Button Clicked");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}