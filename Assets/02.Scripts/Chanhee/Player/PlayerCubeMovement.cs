using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerCubeMovement : MonoBehaviour, PlayerMovement
{
    private Vector3 _nextPos = Vector3.zero;
    private Vector3 _nextDis = Vector3.zero;
    private Vector3 _nextRot = Vector3.zero;


    private Vector3 _startTouchPos = Vector3.zero;
    private Vector3 _endTouchPos = Vector3.zero;
    private Vector3 _valuePos = Vector3.zero;


    private Camera camera = null;


    private bool _isPlayingGame;
    private bool isClick = false;


    Coroutine clickCheckCoroutine;


    [SerializeField] private LayerMask _groundLayer;

    private void Start()
    {
        camera = Camera.main;
        _isPlayingGame = true;
        _groundLayer = LayerMask.GetMask("Ground");

        _nextDis.z = 1;

        StartCoroutine(Move());
        StartCoroutine(MoveState());
    }


    Vector3 GetScreenPosition()
    {
        Vector3 pos = Input.mousePosition;
        pos.z = camera.farClipPlane;
        return pos;
    }
    public IEnumerator Move()
    {
        while (true)
        {
            transform.DOMove(_nextPos, 0.8f);
            _nextPos.x = transform.position.x + _nextDis.x;
            _nextPos.z = transform.position.z + _nextDis.z;
            yield return null;
        }
    }

    public void Jump()
    {
        Ray ray = new Ray(transform.position, new Vector3(0, -1, 0));
        if (Physics.Raycast(ray, 0.6f, _groundLayer))
        {
            DOTween.To(() => _nextPos.y, y => _nextPos.y = y, 4, 0.4f).SetEase(Ease.OutQuad).SetLoops(2, LoopType.Yoyo);
        }
    }

    public void Rotation(bool isLeft = false)
    {
        if (isLeft)
        {
            _nextRot.y -= 90;

            if (_nextDis.z == 0)
            {
                _nextDis.z = _nextDis.x == 1 ? 1 : -1;
                _nextDis.x = 0;
            }
            else
            {
                _nextDis.x = _nextDis.z == 1 ? -1 : 1;
                _nextDis.z = 0;
            }
        }
        else
        {
            _nextRot.y += 90;

            if (_nextDis.z == 0)
            {
                _nextDis.z = _nextDis.x == 1 ? -1 : 1;
                _nextDis.x = 0;
            }
            else
            {
                _nextDis.x = _nextDis.z == 1 ? 1 : -1;
                _nextDis.z = 0;
            }
        }
        transform.DORotate(_nextRot, 0.5f).SetEase(Ease.Linear);
    }

    public IEnumerator CheckClick()
    {
        // 0.3f 안에 어떤 동작을 하지 않으면 클릭으로 체크
        yield return new WaitForSeconds(0.3f);
        if (isClick == true)
            isClick = false;
    }
    public IEnumerator MoveState()
    {
        while (_isPlayingGame)
        {
            yield return new WaitUntil(() => Input.GetMouseButton(0));
            _startTouchPos = GetScreenPosition();
            isClick = true;
            clickCheckCoroutine = StartCoroutine(CheckClick());

            yield return new WaitUntil(() => Input.GetMouseButtonUp(0) || isClick == false);
            if (clickCheckCoroutine != null) StopCoroutine(clickCheckCoroutine);
            _endTouchPos = GetScreenPosition();

            if (isClick)
            {
                _valuePos = _endTouchPos - _startTouchPos;
                // 오른쪽
                if (100 <= _valuePos.x)
                {
                    Rotation(false);
                }
                // 왼쪽
                else if (_valuePos.x <= -100)
                {
                    Rotation(true);
                }
                // 클릭
                else
                {
                    Jump();
                }

                isClick = false;
            }
            else
            {
                Jump();
            }
        }
    }
}
