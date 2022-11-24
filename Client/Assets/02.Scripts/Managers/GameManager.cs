using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoSingleton<GameManager>
{
    private StageSO _currentStage = null;
    public StageSO CURRENTSTAGE
    {
        get => _currentStage;
        set => _currentStage = value;
    }


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
