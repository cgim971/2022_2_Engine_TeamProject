using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransObject : MonoBehaviour
{
    private bool _useFlag = false;
    [SerializeField] private bool _moreUse = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !_useFlag)
        {
            _useFlag = true;
            // 오브젝트 변경 어케 할지 고민
        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("Player") && _useFlag&&_moreUse)
    //    {
    //        _useFlag = false;
    //    }
    //}
}
