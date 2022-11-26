using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class StartUIManager : MonoBehaviour
{
    public static StartUIManager Instance { get; private set; }
    Vector2 _mousePosition;

    #region START
    private Button _startBtn;
    #endregion

    #region INVENTORY
    [SerializeField] private CanvasGroup _inventoryCanvasGroup;
    private Button _inventoryBtn;
    #endregion

    #region SETTING
    [SerializeField] private CanvasGroup _settingCanvasGroup;
    private Button _settingBtn;
    #endregion

    private void Awake()
    {
        if (Instance == null) Instance = this;

        Init();
    }

    public void Init()
    {
        _startBtn = transform.Find("StartBtn").GetComponent<Button>();
        _startBtn.onClick.AddListener(() => OnClickStartBtn());
        _startBtn.transform.Find("StartBtnText").GetComponent<TextMeshProUGUI>().text = "Start";

        _inventoryBtn = transform.Find("InventoryBtn").GetComponent<Button>();
        _inventoryBtn.onClick.AddListener(() => OnClickInventoryBtn(true));
        _inventoryBtn.transform.Find("InventoryBtnText").GetComponent<TextMeshProUGUI>().text = "Inventory";

        _settingBtn = transform.Find("SettingBtn").GetComponent<Button>();
        _settingBtn.onClick.AddListener(() => OnClickSettingBtn(true));
        _settingBtn.transform.Find("SettingBtnText").GetComponent<TextMeshProUGUI>().text = "Setting";
    }

    public void OnClickStartBtn() => SceneManager.LoadScene("02.StageSelectScene");

    public void OnClickInventoryBtn(bool _isInventory)
    {
        if (_isInventory)
        {
            _inventoryCanvasGroup.alpha = 1;
            _inventoryCanvasGroup.interactable = true;
            _inventoryCanvasGroup.blocksRaycasts = true;
        }
        else
        {
            _inventoryCanvasGroup.alpha = 0;
            _inventoryCanvasGroup.interactable =    false;
            _inventoryCanvasGroup.blocksRaycasts =  false;
        }
    }


    public void OnClickSettingBtn(bool _isSetting)
    {
        if (_isSetting)
        {
            _settingCanvasGroup.alpha = 1;
            _settingCanvasGroup.interactable = true;
            _settingCanvasGroup.blocksRaycasts = true;
        }
        else
        {
            _settingCanvasGroup.alpha = 0;
            _settingCanvasGroup.interactable = false;
            _settingCanvasGroup.blocksRaycasts = false;
        }
    }

    public void Exit_MouseDown()
    {
        _mousePosition = Input.mousePosition;
    }

    public void Exit_MouseUp()
    {
        if (Input.mousePosition.y - _mousePosition.y > 100)
        {
            Debug.Log("Á¾·á?");
            //Application.Quit();
        }
    }
}
