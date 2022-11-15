using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager
{
    public static void LoadScene(string sceneName)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
    }
    public static void LoadScene(string sceneName, LoadSceneMode mode)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName, mode);
    }

}
