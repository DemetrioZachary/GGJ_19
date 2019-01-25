using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string[] scenesName;

    private int currentScene = 0;

    private void Start()
    {
        SceneManager.LoadSceneAsync(scenesName[0],LoadSceneMode.Additive);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E)) { ChangeInsideScene(); }
    }

    public void ChangeInsideScene()
    {
        // TODO maybe use coroutines
        SceneManager.UnloadSceneAsync(scenesName[currentScene]);
        if (++currentScene >= scenesName.Length) { currentScene = 0; }
        SceneManager.LoadSceneAsync(scenesName[currentScene],LoadSceneMode.Additive);
    }
}
