using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

        SoundManager.Init();
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.U))
        {
            PlayerPrefs.DeleteAll();
        }
    }

}
