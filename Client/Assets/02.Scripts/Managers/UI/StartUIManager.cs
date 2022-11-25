using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class StartUIManager : MonoBehaviour
{
    [SerializeField] private float _delay = 0.5f;

    private CanvasGroup _fadePanel;

    #region START
    private Button _startBtn;

    static Sequence _selectStartBtnSequence;
    #endregion

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
        _startBtn.transform.Find("StartBtnText").GetComponent<TextMeshProUGUI>().text = "Start";

        _inventoryBtn = transform.Find("InventoryBtn").GetComponent<Button>();
        _inventoryBtn.onClick.AddListener(() => OnClickInventoryBtn());
        _inventoryBtn.transform.Find("InventoryBtnText").GetComponent<TextMeshProUGUI>().text = "Inventory";

        _settingBtn = transform.Find("SettingBtn").GetComponent<Button>();
        _settingBtn.onClick.AddListener(() => OnClickSettingBtn());
        _settingBtn.transform.Find("SettingBtnText").GetComponent<TextMeshProUGUI>().text = "Setting";

        _fadePanel = GameManager.Instance.UIMANAGER.PADEPANEL;
        _inventoryPanelCanvasGroup = GameObject.Find("Canvas").transform.Find("InventoryPanel").GetComponent<CanvasGroup>();
        _inventoryPanelCanvasGroup.transform.Find("ExitBtn").GetComponent<Button>().onClick.AddListener(() => OnClickInventoryBtn());
        _settingPanelCanvasGroup = GameObject.Find("Canvas").transform.Find("SettingPanel").GetComponent<CanvasGroup>();
        _settingPanelCanvasGroup.transform.Find("ExitBtn").GetComponent<Button>().onClick.AddListener(() => OnClickSettingBtn());

        SetSequence();
        SetPanel();
    }

    public void SetSequence()
    {
        #region START
        _selectStartBtnSequence = DOTween.Sequence()
            .SetAutoKill(false)
            .OnRewind(() =>
            {
                Debug.Log("b");

                _fadePanel.interactable = true;
                _fadePanel.blocksRaycasts = true;
            })
            .Append(_fadePanel.DOFade(0.9f, _delay))
            .AppendCallback(() => SceneManager.LoadScene("02.StageSelectScene"))
            .Join(_fadePanel.DOFade(0.0f, _delay))
            .OnComplete(() =>
            {
                _fadePanel.interactable = false;
                _fadePanel.blocksRaycasts = false;
                _inventoryPanelCanvasGroup.interactable = true;
                _inventoryPanelCanvasGroup.blocksRaycasts = true;
            });
        _selectStartBtnSequence.Pause();
        #endregion


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
        _openInventorySequence.Pause();


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
        _closeInventorySequence.Pause();
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
        _openSettingSequence.Pause();


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
        _closeSettingSequence.Pause();
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
        Debug.Log("A");
        _selectStartBtnSequence.Restart();
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
        _isSetting = !_isSetting;

        if (_isSetting)
        {
            _openSettingSequence.Restart();
        }
        else
        {
            _closeSettingSequence.Restart();
        }
    }

}
