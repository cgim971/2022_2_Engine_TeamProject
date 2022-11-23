using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StageInfo : MonoBehaviour, IPoolable
{
    private Button _selectBtn;
    private TextMeshProUGUI _stageTitleTxt;
    private TextMeshProUGUI _stageLvTxt;


    public StageSO _stageSO;

    public StageSO STAGESO
    {
        get => _stageSO;
        set
        {
            _stageSO = value;
            SetStageInfo();
        }
    }

    private string _objName;
    public string NAME { get => _objName; set => _objName = value; }

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
    }

    public void SetStageInfo()
    {
        _stageTitleTxt.text = $"{_stageSO._stageTitle}";
        _stageLvTxt.text = $"{_stageSO._stageIndex}";
    }

    public void SelectStage()
    {
        GameManager.Instance.CURRENTSTAGE = _stageSO;

        SceneManager.LoadScene($"STAGE_{_stageSO._stageIndex}");
        SceneManager.LoadScene("GameUI", UnityEngine.SceneManagement.LoadSceneMode.Additive);
    }

    public void OnPool() { }

    public void PushObj() => PoolingManager.PushObject(NAME, this.gameObject);
}
