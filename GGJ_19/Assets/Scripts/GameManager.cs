﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public string[] scenesName;

    private int currentScene = 0;

    private void Start()
    {
        SceneManager.LoadSceneAsync(scenesName[0], LoadSceneMode.Additive);
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
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
    }

    public void ChangeMinigame()
    {
        StartCoroutine(ChangeInsideScene());
    }
}
