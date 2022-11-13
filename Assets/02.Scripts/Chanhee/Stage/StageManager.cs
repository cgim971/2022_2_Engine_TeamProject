using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StageManager : MonoBehaviour
{
    public Scrollbar scroll;

    public StageSOList stageSOList;
    public GameObject stage;
    public Transform parent;

    [SerializeField] private int firstIndex = -1;
    [SerializeField] private int lastIndex = 1;

    [SerializeField] private List<GameObject> stagePanelList = new List<GameObject>();

    private void Start()
    {
        for (int i = 0; i < stageSOList.stageList.Count; i++)
        {
            stagePanelList.Add(null);
        }

        firstIndex = stageSOList.stageList.Count - 1;
        lastIndex = 1;

        PoolingManager.CreatePool("Panel", "UI", parent);

        GameObject newObj = PoolingManager.PopObject("Panel");
        newObj.transform.SetAsLastSibling();
        newObj.GetComponent<StageInfo>().STAGESO = stageSOList.stageList[0];

        stagePanelList[0] = newObj;

        newObj = PoolingManager.PopObject("Panel");
        newObj.transform.SetAsFirstSibling();
        newObj.GetComponent<StageInfo>().STAGESO = stageSOList.stageList[firstIndex];

        stagePanelList[firstIndex] = newObj;

        newObj = PoolingManager.PopObject("Panel");
        newObj.transform.SetAsLastSibling();
        newObj.GetComponent<StageInfo>().STAGESO = stageSOList.stageList[lastIndex];

        stagePanelList[lastIndex] = newObj;

        scroll.value = 0.5f;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            GameObject newObj = PoolingManager.PopObject("Panel");
            newObj.transform.SetAsFirstSibling();

            firstIndex -= 1;
            if (firstIndex < 0) firstIndex = stageSOList.stageList.Count - 1;

            newObj.GetComponent<StageInfo>().STAGESO = stageSOList.stageList[firstIndex];
            stagePanelList[firstIndex] = newObj;

            stagePanelList[lastIndex].GetComponent<IPoolable>().PushObj();
            stagePanelList[lastIndex] = null;
            lastIndex -= 1;
            if (lastIndex < 0) lastIndex = stageSOList.stageList.Count - 1;

            scroll.value = 0.5f;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            GameObject newObj = PoolingManager.PopObject("Panel");
            newObj.transform.SetAsLastSibling();

            lastIndex += 1;
            if (stageSOList.stageList.Count - 1 < lastIndex) lastIndex = 0;

            newObj.GetComponent<StageInfo>().STAGESO = stageSOList.stageList[lastIndex];
            stagePanelList[lastIndex] = newObj;

            stagePanelList[firstIndex].GetComponent<IPoolable>().PushObj();
            stagePanelList[firstIndex] = null;
            firstIndex += 1;
            if (stageSOList.stageList.Count - 1 < firstIndex) firstIndex = 0;

            scroll.value = 0.5f;
        }
    }
}
