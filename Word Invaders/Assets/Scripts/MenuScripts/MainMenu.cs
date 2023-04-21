using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    } 

    // Method to exit the application when quit-btn is clicked
    public void QuitGame() {
        // Debug Log Message
        Debug.Log("QuitGame");

        Application.Quit();
    }
}
