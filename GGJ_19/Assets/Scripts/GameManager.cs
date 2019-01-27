using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string[] scenesName;

    private int currentScene = 0;
    private ColorChange cg;

    private void Start()
    {
        SceneManager.LoadSceneAsync(scenesName[0], LoadSceneMode.Additive);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        cg = FindObjectOfType<ColorChange>();
    }

    private IEnumerator ChangeInsideScene()
    {
        AsyncOperation op = SceneManager.UnloadSceneAsync(scenesName[currentScene]);
        while (!op.isDone)
        {
            yield return null;
        }

        if (++currentScene >= scenesName.Length) { currentScene = 0; }
        op = SceneManager.LoadSceneAsync(scenesName[currentScene], LoadSceneMode.Additive);

        while (!op.isDone)
        {
            yield return null;
        }
        cg.ChangeColor();
    }

    public void ChangeMinigame()
    {
        StartCoroutine(ChangeInsideScene());
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
