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

    [SerializeField] private CanvasGroup _fadePanel;

    #region INVENTORY
    private Button _inventoryBtn;
    private bool _isInventory = false;
    private CanvasGroup _inventoryPanelCanvasGroup;

    static Sequence _openInventorySequence;
    static Sequence _closeInventorySequence;

    #endregion

    #region SETTING
    private Button _settingBtn;
    private bool _isSetting = false;
    private CanvasGroup _settingPanelCanvasGroup;

    static Sequence _openSettingSequence;
    static Sequence _closeSettingSequence;
    #endregion

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

        _fadePanel = GameObject.Find("Canvas").transform.Find("FadePanel").GetComponent<CanvasGroup>();
        _inventoryPanelCanvasGroup = GameObject.Find("Canvas").transform.Find("InventoryPanel").GetComponent<CanvasGroup>();
        _settingPanelCanvasGroup = GameObject.Find("Canvas").transform.Find("SettingPanel").GetComponent<CanvasGroup>();

        SetSequence();
        SetPanel();
    }


    public void SetSequence()
    {
        #region Inventory
        _openInventorySequence = DOTween.Sequence()
            .SetAutoKill(false)
            .OnRewind(() =>
            {
                _fadePanel.interactable = true;
                _fadePanel.blocksRaycasts = true;
            })
            .Append(_fadePanel.DOFade(0.9f, _delay))
            .Join(_inventoryPanelCanvasGroup.DOFade(1f, _delay))
            .Append(_fadePanel.DOFade(0.0f, _delay))
            .OnComplete(() =>
            {
                _fadePanel.interactable = false;
                _fadePanel.blocksRaycasts = false;
                _inventoryPanelCanvasGroup.interactable = true;
                _inventoryPanelCanvasGroup.blocksRaycasts = true;
            });


        _closeInventorySequence = DOTween.Sequence()
            .SetAutoKill(false)
            .OnRewind(() =>
            {
                _fadePanel.interactable = true;
                _fadePanel.blocksRaycasts = true;
            })
            .Append(_fadePanel.DOFade(0.9f, _delay))
            .Append(_fadePanel.DOFade(0.0f, _delay))
            .Join(_inventoryPanelCanvasGroup.DOFade(0.0f, _delay))
            .OnComplete(() =>
            {
                _fadePanel.interactable = false;
                _fadePanel.blocksRaycasts = false;
                _inventoryPanelCanvasGroup.interactable = false;
                _inventoryPanelCanvasGroup.blocksRaycasts = false;
            });
        #endregion


        #region SETTING
        _openSettingSequence = DOTween.Sequence()
           .SetAutoKill(false)
           .OnRewind(() =>
           {
               _fadePanel.interactable = true;
               _fadePanel.blocksRaycasts = true;
           })
           .Append(_fadePanel.DOFade(0.9f, _delay))
           .Join(_settingPanelCanvasGroup.DOFade(1f, _delay))
           .Append(_fadePanel.DOFade(0.0f, _delay))
           .OnComplete(() =>
           {
               _fadePanel.interactable = false;
               _fadePanel.blocksRaycasts = false;
               _settingPanelCanvasGroup.interactable = true;
               _settingPanelCanvasGroup.blocksRaycasts = true;
           });


        _closeSettingSequence = DOTween.Sequence()
            .SetAutoKill(false)
            .OnRewind(() =>
            {
                _fadePanel.interactable = true;
                _fadePanel.blocksRaycasts = true;
            })
            .Append(_fadePanel.DOFade(0.9f, _delay))
            .Append(_fadePanel.DOFade(0.0f, _delay))
            .Join(_settingPanelCanvasGroup.DOFade(0.0f, _delay))
            .OnComplete(() =>
            {
                _fadePanel.interactable = false;
                _fadePanel.blocksRaycasts = false;
                _settingPanelCanvasGroup.interactable = false;
                _settingPanelCanvasGroup.blocksRaycasts = false;
            });
        #endregion
    }

    public void SetPanel()
    {
        _fadePanel.interactable = false;
        _fadePanel.blocksRaycasts = false;
        _inventoryPanelCanvasGroup.interactable = false;
        _inventoryPanelCanvasGroup.blocksRaycasts = false;
    }

    public void OnClickStartBtn()
    {
        SceneManager.LoadScene("02.StageSelectScene");
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
