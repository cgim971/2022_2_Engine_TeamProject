using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIManager : MonoBehaviour
{
    [SerializeField] private ScrollRect _scrollRect;

    [SerializeField] private GameObject _skinContent = null;
    [SerializeField] private GameObject _colorContent = null;

    Vector2 _mousePosition;

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

    public void SkinContent()
    {
        _scrollRect.content = _skinContent.GetComponent<RectTransform>();

        _skinContent.SetActive(true);
        _colorContent.SetActive(false);
    }
    public void ColorContent()
    {
        _scrollRect.content = _colorContent.GetComponent<RectTransform>();

        _skinContent.SetActive(false);
        _colorContent.SetActive(true);
    }
}
