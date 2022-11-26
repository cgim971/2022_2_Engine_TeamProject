using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StageInfo : MonoBehaviour
{
    private Button _selectBtn;
    private TextMeshProUGUI _stageTitleTxt;
    private TextMeshProUGUI _stageLvTxt;

    public StageSO _stageSO;

    private void Awake()
    {
        Init();
    }

    public void Init()
    {
        _selectBtn = transform.Find("selectBtn").GetComponent<Button>();
        _selectBtn.onClick.AddListener(() => SelectStage());

        _stageTitleTxt = _selectBtn.transform.Find("StageTitleTxt").GetComponent<TextMeshProUGUI>();
        _stageLvTxt = _selectBtn.transform.Find("StageLvTxt").GetComponent<TextMeshProUGUI>();

        SetStageInfo();
    }

    public void SetStageInfo()
    {
        _stageTitleTxt.text = $"{_stageSO._stageTitle}";
        _stageLvTxt.text = $"{_stageSO._stageIndex}";
    }

    public void SelectStage()
    {
        GameManager.Instance.CURRENTSTAGE = _stageSO;

        SceneManager.LoadStageScene($"STAGE_{_stageSO._stageIndex}");
    }
}
