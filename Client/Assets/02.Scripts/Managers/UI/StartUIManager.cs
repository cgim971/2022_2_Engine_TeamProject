using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;

public class StartUIManager : MonoBehaviour
{
    [SerializeField] private float _delay = 0.5f;

    #region START
    private Button _startBtn;
    #endregion

    #region INVENTORY
    private Button _inventoryBtn;
    private bool _isInventory = false;
    #endregion

    #region SETTING
    private Button _settingBtn;
    private bool _isSetting = false;
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
    }
    
    public void OnClickStartBtn() => SceneManager.LoadScene("02.StageSelectScene");

    public void OnClickInventoryBtn()
    {
        _isInventory = !_isInventory;

        if (_isInventory)
        {
            
        }
        else
        {
            
        }
    }


    public void OnClickSettingBtn()
    {
        _isSetting = !_isSetting;

        if (_isSetting)
        {
            
        }
        else
        {
            
        }
    }

}
