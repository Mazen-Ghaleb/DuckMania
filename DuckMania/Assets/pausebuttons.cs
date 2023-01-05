using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class pausebuttons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ResumeGame()
    {
        Debug.Log("Resuming");
        //PausePanel.SetActive(false);


        Time.timeScale = 1f;
        PauseMenuScript.isPaused = false;
        SceneManager.UnloadSceneAsync("pauseScene");


    }
    //todo 
    // create main menu

    public void GotoMainMenu()
    {
        Debug.Log("going to main menu!");
        Time.timeScale = 0f;
        PauseMenuScript.isPaused = true;
        SceneManager.UnloadSceneAsync("pauseScene");
        SceneManager.UnloadSceneAsync("DuckMania");

        // Get a list of all game objects in the scene
        GameObject[] objects = UnityEngine.Object.FindObjectsOfType<GameObject>();

        // Destroy each game object
        foreach (GameObject obj in objects)
        {
            Destroy(obj);
        }


        SceneManager.LoadScene("StartScreen", LoadSceneMode.Additive);
    }
    public void ExitGame()
    {
        Application.Quit();
    }
}
