using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartUIManager : MonoBehaviour
{
    private Button _startBtn;
    private TextMeshProUGUI _startBtnText;

    private Button _inventoryBtn;
    private TextMeshProUGUI _inventoryBtnText;

    private Button _settingBtn;
    private TextMeshProUGUI _settingBtnText;

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

        _startBtnText = _startBtn.transform.Find("StartBtnText").GetComponent<TextMeshProUGUI>();
        _startBtnText.text = "Start";
        _inventoryBtnText = _inventoryBtn.transform.Find("InventoryBtnText").GetComponent<TextMeshProUGUI>();
        _inventoryBtnText.text = "Inventory";
        _settingBtnText = _settingBtn.transform.Find("SettingBtnText").GetComponent<TextMeshProUGUI>();
        _settingBtnText.text = "Setting";
    }

    public void OnClickStartBtn()
    {
        SceneManager.LoadScene("02.StageSelectScene");
    }


    public void OnClickInventoryBtn()
    {
        Debug.Log("인벤토리 창 올라옴");
    }

    public void OnClickSettingBtn()
    {
        Debug.Log("셋팅 창 올라옴");
    }

}
