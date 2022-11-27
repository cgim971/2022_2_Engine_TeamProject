using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIManager : MonoBehaviour
{
    [SerializeField] private ScrollRect _scrollRect;
    [SerializeField] private Transform _parent = null;

    Vector2 _mousePosition;

    [SerializeField] private GameObject _slot;
    [SerializeField] private SkinListSO _skinList;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A)) SetInventory();
    }

    private void SetInventory()
    {
        

        foreach (SkinSO skin in _skinList._cubeSkins)
        {
            GameObject newSkin = Instantiate(_slot, _parent);
            newSkin.GetComponent<SkinInfo>().SKINSO = skin;
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
            StartUIManager.Instance.OnClickInventoryBtn(false);
        }
    }

    public void Next_MouseDown()
    {
        _mousePosition = Input.mousePosition;
    }
    public void Next_MouseUp()
    {
        if (Mathf.Abs(Input.mousePosition.x - _mousePosition.x) > 50)
        {
            Debug.Log("Next");
        }
    }

    public void Before_MouseDown()
    {
        _mousePosition = Input.mousePosition;
    }
    public void Before_MouseUp()
    {
        if (Mathf.Abs(Input.mousePosition.x - _mousePosition.x) > 50)
        {
            Debug.Log("Before");
        }
    }

}
