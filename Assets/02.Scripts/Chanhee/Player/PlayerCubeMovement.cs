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
    private bool isClick = false;

    Coroutine clickCheckCoroutine;

    private void Start()
    {
        camera = Camera.main;
        _isPlayingGame = true;
        StartCoroutine(Click());
    }

    private IEnumerator CheckClick()
    {
        // 0.3f 안에 어떤 동작을 하지 않으면 클릭으로 체크
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
            clickCheckCoroutine = StartCoroutine(CheckClick());

            yield return new WaitUntil(() => Input.GetMouseButtonUp(0) || isClick == false);
            if(clickCheckCoroutine != null) StopCoroutine(clickCheckCoroutine);
            _endTouchPos = GetScreenPosition();

            if (isClick)
            {
                _valuePos = _endTouchPos - _startTouchPos;
                // 오른쪽
                if (100 <= _valuePos.x)
                {
                    Debug.Log("오른쪽");
                }
                // 왼쪽
                else if (_valuePos.x <= -100)
                {
                    Debug.Log("왼쪽");
                }
                // 클릭
                else
                {
                    Debug.Log("클릭");
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
