//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class ScrollContent : MonoBehaviour
//{
//    private RectTransform _rectTransform;
//    private List<GameObject> _childrenList;

//    private float _width, _height;
//    public float WIDTH { get => _width; }

//    private float _childWidth, _childHeight;
//    public float CHILDWIDTH { get => _childWidth; }


//    [SerializeField] private float _itemSpacing;
//    public float ITEMSPACING { get => _itemSpacing; }


//    [SerializeField] private float _horizontalMargin;
//    public float HORIZONTALMARGIN { get => _horizontalMargin; }


//    [SerializeField] private float _verticalMargin;
//    public float VERTICALMARGIN { get => _verticalMargin; }

//    private void Awake()
//    {
//        _rectTransform = GetComponent<RectTransform>();
//        PoolingManager.CreatePool("Panel", "UI", this.transform);

//        for (int i = 0; i < 5; i++)
//        {
//            GameObject panelObj = PoolingManager.PopObject("Panel");
//            _childrenList.Add(panelObj);
//        }

//        _width = _rectTransform.rect.width - (2 * _horizontalMargin);
//        _height = _rectTransform.rect.height - (2 * _verticalMargin);

//        _childWidth = _rtChildrens[0].rect.width;
//        _childHeight = _rtChildrens[0].rect.height;

//        InitializeContentHorizontal();
//    }

//    private void InitializeContentHorizontal()
//    {
//        float originX = 0 - (_width * 0.5f);
//        float posOffset = _childWidth * 0.5f;
//        for (int i = 0; i < _rtChildrens.Length; i++)
//        {
//            Vector2 childPos = _rtChildrens[i].localPosition;
//            childPos.x = originX + posOffset + i * (_childWidth + _itemSpacing);
//            _rtChildrens[i].localPosition = childPos;
//        }
//    }
//}
