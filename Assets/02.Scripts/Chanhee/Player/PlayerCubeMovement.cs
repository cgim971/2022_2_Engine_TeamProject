using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCubeMovement : MonoBehaviour
{
    private Vector3 _startTouchPos = Vector3.zero;
    private Vector3 _endTouchPos = Vector3.zero;
    private Vector3 _valuePos = Vector3.zero;

    private Camera camera = null;

    private bool _isPlayingGame;


    private void Start()
    {
        camera = Camera.main;
        _isPlayingGame = true;
        StartCoroutine(Click());
    }

    bool isClick = false;

    private IEnumerator CheckClick()
    {
        yield return new WaitForSeconds(0.3f);
        if (isClick == true)
            isClick = false;
    }

    private IEnumerator Click()
    {
        while (_isPlayingGame)
        {
            yield return new WaitUntil(() => Input.GetMouseButton(0));
            _startTouchPos = GetScreenPosition();
            isClick = true;

            StartCoroutine(CheckClick());

            yield return new WaitUntil(() => Input.GetMouseButtonUp(0) || isClick == false);
            _endTouchPos = GetScreenPosition();

            if (isClick)
            {
                _valuePos = _endTouchPos - _startTouchPos;
                // 오른쪽
                if (100 <= _valuePos.x)
                {

                }
                // 왼쪽
                else if (_valuePos.x <= -100)
                {

                }
                // 클릭
                else
                {

                }

                isClick = false;
            }
            else
            {
                Debug.Log("클릭");
            }
        }
    }

    Vector3 GetScreenPosition()
    {
        Vector3 pos = Input.mousePosition;
        pos.z = camera.farClipPlane;
        return pos;
    }
}
