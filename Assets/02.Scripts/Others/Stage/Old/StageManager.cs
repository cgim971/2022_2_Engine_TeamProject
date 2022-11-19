using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class StageManager : MonoBehaviour, IBeginDragHandler, IDragHandler, IScrollHandler
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
        }

        if (!isDrag) scroll.value = 0.5f;
    }

    public void OnEndDrag()
    {
        float dis = scroll.value;
        if (0.6f <= dis)
        {
            _lastIndex += 1;
            if (_stageSOList._stageList.Count - 1 < _lastIndex) _lastIndex = 0;
            CreatePanel(_lastIndex, true);

            _stagePanelList[_firstIndex].GetComponent<IPoolable>().PushObj();
            _stagePanelList[_firstIndex] = null;
            _firstIndex += 1;
            if (_stageSOList._stageList.Count - 1 < _firstIndex) _firstIndex = 0;
        }
        else if (dis <= 0.4f)
        {
            _firstIndex -= 1;
            if (_firstIndex < 0) _firstIndex = _stageSOList._stageList.Count - 1;
            CreatePanel(_firstIndex, false);

            _stagePanelList[_lastIndex].GetComponent<IPoolable>().PushObj();
            _stagePanelList[_lastIndex] = null;
            _lastIndex -= 1;
            if (_lastIndex < 0) _lastIndex = _stageSOList._stageList.Count - 1;
        }
    }

    #endregion

    private void Awake()
    {
        for (int i = 0; i < _stageSOList._stageList.Count; i++)
        {
            _stagePanelList.Add(null);
        }

        _firstIndex = _stageSOList._stageList.Count - 1;
        _lastIndex = 1;

        PoolingManager.CreatePool("Panel", "UI", _parent);

        CreatePanel(0, true);
        CreatePanel(_firstIndex, false);
        CreatePanel(_lastIndex, true);
    }
    public void CreatePanel(int index, bool lastSibling = false)
    {
        GameObject newObj = PoolingManager.PopObject("Panel");
        if (lastSibling == false)
        {
            newObj.transform.SetAsFirstSibling();
        }
        else
        {
            newObj.transform.SetAsLastSibling();
        }
        newObj.GetComponent<StageInfo>().STAGESO = _stageSOList._stageList[index];
        _stagePanelList[index] = newObj;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {

    }

    public void OnDrag(PointerEventData eventData)
    {

    }

    public void OnScroll(PointerEventData eventData)
    {

    }
}
