using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R)) {
            LoadNextLevel();
        }    
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            QuitGame();
        }
    }

    public void LoadNextLevel () {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadLevelByIndex (int levelIndex) {
        StartCoroutine(LoadLevel(levelIndex));
    }

    public void ReloadLevel () {
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

     public void QuitGame () 
    {
        Application.Quit();
        Debug.Log("Juego terminado");
    }

    IEnumerator LoadLevel (int levelIndex) {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(levelIndex);
    }
}
