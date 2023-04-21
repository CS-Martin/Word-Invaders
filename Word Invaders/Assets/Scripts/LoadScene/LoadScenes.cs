using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScenes : MonoBehaviour
{
    /// <Brief> Just a defulat game scene
    public void EndlessBattle() {
        SceneManager.LoadScene("EndlessBattle");
    } 

    /// <Brief> Load main menu
    public void MainMenu() {
        Debug.Log("Loaded MainMenu");
        SceneManager.LoadScene("Menu");
    }

    public void Settings() {
        Debug.Log("Loaded Settings");
        SceneManager.LoadScene("Settings");
    }

    /// <Brief> Load stage levels scene 
    public void StageLevelsMap() {
        Debug.Log("Loaded StageLevelsMap");
        SceneManager.LoadScene("StagesMap");
    }

    /// <Brief> Load stage 1 scene
    public void Level1() {

    }

    /// <Brief> Load stage 2 scene
    public void Level2() {

    }

    /// <Brief> Method to exit the application when quit-btn is clicked
    public void QuitGame() {
        /// <note> Just a debug message
        /// <Returns> A message in the terminal
        Debug.Log("QuitGame");

        Application.Quit();
    }
}
