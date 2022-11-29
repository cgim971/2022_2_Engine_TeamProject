using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionUI : MonoBehaviour
{
    [SerializeField] private Button playBtn;
    [SerializeField] private Button menuBtn;
    [SerializeField] private Button retryBtn;

    [SerializeField] private GameObject optionImg;

    private void Start()
    {
        playBtn.onClick.AddListener(PlayTrigger);
        menuBtn.onClick.AddListener(MenuTrigger);
        retryBtn.onClick.AddListener(RetryTrigger);
    }

    private void PlayTrigger()
    {
       optionImg.SetActive(false);
    }

    private void MenuTrigger()
    {
        //Menu Scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    private void RetryTrigger()
    {
        //Current Scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }


}
