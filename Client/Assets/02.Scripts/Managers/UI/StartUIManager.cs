using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class StartUIManager : MonoBehaviour
{
    private Button _startBtn;
    [SerializeField] private float _delay = 0.5f;

    [SerializeField] private Image _fadePanel;

    #region INVENTORY
    private Button _inventoryBtn;
    private bool _isInventory = false;
    [SerializeField] private GameObject _inventoryPanel;

    static Sequence _openInventorySequence;
    static Sequence _closeInventorySequence;

    #endregion


    private Button _settingBtn;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        _startBtn = transform.Find("StartBtn").GetComponent<Button>();
        _startBtn.onClick.AddListener(() => OnClickStartBtn());
        _inventoryBtn = transform.Find("InventoryBtn").GetComponent<Button>();
        _inventoryBtn.onClick.AddListener(() => OnClickInventoryBtn());
        _settingBtn = transform.Find("SettingBtn").GetComponent<Button>();
        _settingBtn.onClick.AddListener(() => OnClickSettingBtn());

        _startBtn.transform.Find("StartBtnText").GetComponent<TextMeshProUGUI>().text = "Start";
        _inventoryBtn.transform.Find("InventoryBtnText").GetComponent<TextMeshProUGUI>().text = "Inventory";
        _settingBtn.transform.Find("SettingBtnText").GetComponent<TextMeshProUGUI>().text = "Setting";

        SetSequence();
    }


    public void SetSequence()
    {
        _openInventorySequence = DOTween.Sequence()
            .SetAutoKill(false)
            .OnRewind(() =>
            {
                _fadePanel.gameObject.SetActive(true);
            })
            .Append(_fadePanel.DOFade(0.9f, _delay))
            .AppendCallback(() =>
            {
                _inventoryPanel.SetActive(true);
            })
            .Append(_fadePanel.DOFade(0.0f, _delay))
            .OnComplete(() =>
            {
                _fadePanel.gameObject.SetActive(false);
            });

        _closeInventorySequence = DOTween.Sequence()
            .SetAutoKill(false)
            .OnRewind(() =>
            {
                _fadePanel.gameObject.SetActive(true);
            })
            .Append(_fadePanel.DOFade(0.9f, _delay))
            .AppendCallback(() =>
            {
                _inventoryPanel.SetActive(false);
            })
            .Append(_fadePanel.DOFade(0.0f, _delay))
            .OnComplete(() =>
            {
                _fadePanel.gameObject.SetActive(false);
            });

    }


    public void OnClickStartBtn()
    {
        SceneManager.LoadScene("02.StageSelectScene");
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            OnClickInventoryBtn();
        }
    }

    public void OnClickInventoryBtn()
    {
        _isInventory = !_isInventory;

        if (_isInventory)
        {
            _openInventorySequence.Restart();
        }
        else
        {
            _closeInventorySequence.Restart();
        }
    }


    public void OnClickSettingBtn()
    {
        Debug.Log("셋팅 창 올라옴");

    }

}
