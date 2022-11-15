using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StartUIManager : MonoBehaviour
{
    private Button startBtn;
    private TextMeshProUGUI startBtnText;

    private Button inventoryBtn;
    private TextMeshProUGUI inventoryBtnText;

    private Button settingBtn;
    private TextMeshProUGUI settingBtnText;


    private void Awake()
    {
        startBtn = transform.Find("StartBtn").GetComponent<Button>();
        startBtn.onClick.AddListener(() => OnClickStartBtn());
        inventoryBtn = transform.Find("InventoryBtn").GetComponent<Button>();
        inventoryBtn.onClick.AddListener(() => OnClickInventoryBtn());
        settingBtn = transform.Find("SettingBtn").GetComponent<Button>();
        settingBtn.onClick.AddListener(() => OnClickSettingBtn());

        startBtnText = startBtn.transform.Find("StartBtnText").GetComponent<TextMeshProUGUI>();
        startBtnText.text = "Start";
        inventoryBtnText = inventoryBtn.transform.Find("InventoryBtnText").GetComponent<TextMeshProUGUI>();
        inventoryBtnText.text = "Inventory";
        settingBtnText = settingBtn.transform.Find("SettingBtnText").GetComponent<TextMeshProUGUI>();
        settingBtnText.text = "Setting";
    }

    public void OnClickStartBtn()
    {
        Debug.Log("스테이지 씬으로");
        SceneManager.LoadScene("StageSelectScene");
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
