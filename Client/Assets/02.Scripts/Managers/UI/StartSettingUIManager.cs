using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartSettingUIManager : MonoBehaviour
{
    Vector2 _mousePosition;

    public void Exit_MouseDown()
    {
        _mousePosition = Input.mousePosition;
    }

    public void Exit_MouseUp()
    {
        if (Input.mousePosition.y - _mousePosition.y > 100)
        {
            StartUIManager.Instance.OnClickSettingBtn(false);
        }
    }
}
