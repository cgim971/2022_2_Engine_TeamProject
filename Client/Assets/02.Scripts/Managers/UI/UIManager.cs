using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

    private Canvas _canvas;


    private CanvasGroup _padePanel;
    public CanvasGroup PADEPANEL => _padePanel;

    private void Awake()
    {
        _padePanel = transform.Find("Canvas").transform.Find("FadePanel").transform.GetComponent<CanvasGroup>();
    }
}
