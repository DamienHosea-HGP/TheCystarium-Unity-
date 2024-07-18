using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtons : MonoBehaviour
{
    // Method to be called when the Play button is clicked
    public void OnPlayButtonClick()
    {
        // Load the main game scene
        // Assuming your main game scene is named "TheCrystarium"
        SceneManager.LoadScene("TheCrystarium");
    }

    // Method to be called when the Quit button is clicked
    public void OnQuitButtonClick()
    {
        // If we are running in a standalone build of the game
        #if UNITY_STANDALONE
            // Quit the application
            Application.Quit();
        #endif

        // If we are running in the Unity editor
        #if UNITY_EDITOR
            // Stop playing the scene
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
