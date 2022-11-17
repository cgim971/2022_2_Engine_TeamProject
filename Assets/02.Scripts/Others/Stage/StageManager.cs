using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public StageSOList _stageSOList;
    public Transform _parent;

    private int _firstIndex = -1;
    private int _lastIndex = 1;

    [SerializeField] private List<GameObject> _stagePanelList = new List<GameObject>();


    #region SCROLL
    // 수정해야함
    public Scrollbar scroll;
    bool isDrag = false;

    private void Update()
    {
        if (Input.GetMouseButton(0)) isDrag = true;
        if (Input.GetMouseButtonUp(0))
        {
            OnEndDrag();
            isDrag = false;
            scroll.value = Mathf.Lerp(scroll.value, 0.5f, 0.1f);
        }

        if (!isDrag) scroll.value = Mathf.Lerp(scroll.value, 0.5f, 0.1f);
    }

    public void OnEndDrag()
    {
        float dis = scroll.value;
        if (0.65f < dis)
        {
            Debug.Log("오른쪽");
            GameObject newObj = PoolingManager.PopObject("Panel");
            newObj.transform.SetAsLastSibling();

            _lastIndex += 1;
            if (_stageSOList._stageList.Count - 1 < _lastIndex) _lastIndex = 0;

            newObj.GetComponent<StageInfo>().STAGESO = _stageSOList._stageList[_lastIndex];
            _stagePanelList[_lastIndex] = newObj;

            _stagePanelList[_firstIndex].GetComponent<IPoolable>().PushObj();
            _stagePanelList[_firstIndex] = null;
            _firstIndex += 1;
            if (_stageSOList._stageList.Count - 1 < _firstIndex) _firstIndex = 0;
        }
        else if (dis < 0.35f)
        {
            Debug.Log("왼쪽");
            GameObject newObj = PoolingManager.PopObject("Panel");
            newObj.transform.SetAsFirstSibling();

            _firstIndex -= 1;
            if (_firstIndex < 0) _firstIndex = _stageSOList._stageList.Count - 1;

            newObj.GetComponent<StageInfo>().STAGESO = _stageSOList._stageList[_firstIndex];
            _stagePanelList[_firstIndex] = newObj;

            _stagePanelList[_lastIndex].GetComponent<IPoolable>().PushObj();
            _stagePanelList[_lastIndex] = null;
            _lastIndex -= 1;
            if (_lastIndex < 0) _lastIndex = _stageSOList._stageList.Count - 1;
        }
    }

    #endregion

    private void Start()
    {
        for (int i = 0; i < _stageSOList._stageList.Count; i++)
        {
            _stagePanelList.Add(null);
        }

        _firstIndex = _stageSOList._stageList.Count - 1;
        _lastIndex = 1;

        PoolingManager.CreatePool("Panel", "UI", _parent);

        GameObject newObj = PoolingManager.PopObject("Panel");
        newObj.transform.SetAsLastSibling();
        newObj.GetComponent<StageInfo>().STAGESO = _stageSOList._stageList[0];

        _stagePanelList[0] = newObj;

        newObj = PoolingManager.PopObject("Panel");
        newObj.transform.SetAsFirstSibling();
        newObj.GetComponent<StageInfo>().STAGESO = _stageSOList._stageList[_firstIndex];

        _stagePanelList[_firstIndex] = newObj;

        newObj = PoolingManager.PopObject("Panel");
        newObj.transform.SetAsLastSibling();
        newObj.GetComponent<StageInfo>().STAGESO = _stageSOList._stageList[_lastIndex];

        _stagePanelList[_lastIndex] = newObj;

        scroll.value = 0.5f;
    }
}
