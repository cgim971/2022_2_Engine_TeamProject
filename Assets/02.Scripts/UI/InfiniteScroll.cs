//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.EventSystems;
//using UnityEngine.UI;
//public class InfiniteScroll : MonoBehaviour, IBeginDragHandler, IDragHandler, IScrollHandler
//{


//    [SerializeField] private ScrollContent _scrollContent;

//    [SerializeField] private float _outOfBoundsThreshold;

//    private ScrollRect _scrollRect;
//    private Vector2 _lastDragPosition;
//    private bool _positiveDrag;

//    private void Awake()
//    {
//        _scrollRect = GetComponent<ScrollRect>();
//        _scrollRect.movementType = ScrollRect.MovementType.Unrestricted;
//    }


//    public void OnBeginDrag(PointerEventData eventData)
//    {
//        _lastDragPosition = eventData.position;
//    }

//    public void OnDrag(PointerEventData eventData)
//    {
//        _positiveDrag = eventData.position.x > _lastDragPosition.x;

//        _lastDragPosition = eventData.position;
//    }

//    public void OnScroll(PointerEventData eventData)
//    {
//        _positiveDrag = eventData.scrollDelta.y < 0;
//    }

//    public void OnViewScroll()
//    {
//        HandlerHorizontalScroll();
//    }

//    private void HandlerHorizontalScroll()
//    {
//        int curItemIndex = _positiveDrag ? _scrollRect.content.childCount - 1 : 0;
//        var curItem = _scrollRect.content.GetChild(curItemIndex) as RectTransform;

//        if (!ReachedThreshold(curItem)) return;

//        int endItemIndex = _positiveDrag ? 0 : _scrollRect.content.childCount - 1;
//        RectTransform endItem = _scrollRect.content.GetChild(endItemIndex) as RectTransform;

//        Vector2 newPos = endItem.position;

//        if (_positiveDrag)
//        {
//            newPos.x = endItem.position.x - _scrollContent.CHILDWIDTH * 1.5f + _scrollContent.ITEMSPACING;
//        }
//        else
//        {
//            newPos.x = endItem.position.x - _scrollContent.CHILDWIDTH * 1.5f - _scrollContent.ITEMSPACING;
//        }

//        curItem.position = newPos;
//        curItem.SetSiblingIndex(endItemIndex);
//    }

//    private bool ReachedThreshold(RectTransform item)
//    {
//        float posXThreshold = transform.position.x + _scrollContent.WIDTH * 0.5f + _outOfBoundsThreshold;
//        float negXThreshold = transform.position.x + _scrollContent.WIDTH * 0.5f - _outOfBoundsThreshold;
//        return _positiveDrag ? item.position.x - _scrollContent.CHILDWIDTH * 0.5f > posXThreshold : item.position.x + _scrollContent.CHILDWIDTH * 0.5f < negXThreshold;
//    }

//}
