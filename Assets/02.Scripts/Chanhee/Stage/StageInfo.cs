using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StageInfo : MonoBehaviour, IPoolable
{
    Button selectBtn;
    TextMeshProUGUI stageTitleTxt;
    TextMeshProUGUI stageInfoTxt;
    Image stageSprite;

    public StageSO stageSO;

    public StageSO STAGESO
    {
        get => stageSO;
        set
        {
            stageSO = value;
            //SetStageInfo();
        }
    }

    private string _objName;
    public string NAME { get => _objName; set => _objName = value; }

    private void Awake()
    {
        selectBtn = transform.Find("selectBtn").GetComponent<Button>();
        selectBtn.onClick.AddListener(() =>
        {
            Debug.Log("stage select");
        });
        stageTitleTxt = selectBtn.transform.Find("StageTitleTxt").GetComponent<TextMeshProUGUI>();
        stageInfoTxt = selectBtn.transform.Find("StageInfoTxt").GetComponent<TextMeshProUGUI>();
        stageSprite = selectBtn.transform.Find("StageSprite").GetComponent<Image>();
    }

    public void SetStageInfo()
    {
        stageTitleTxt.text = $"{stageSO.stageTitle}";
        stageInfoTxt.text = $"{stageSO.stageInfo}";
        stageSprite.sprite = stageSO.stageSprite;
    }

    public void OnPool()
    {
        
    }

    public void PushObj() => PoolingManager.PushObject(NAME, this.gameObject);
}
