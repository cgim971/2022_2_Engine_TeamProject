using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpRing : MonoBehaviour
{
    private bool useFlag = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !useFlag)
        {
            useFlag = true;
            //other.GetComponent<>();
            Debug.Log("AA");
            other.GetComponentInParent<PlayerMovement>().JUMPEXTRACOUNT += 1;
            //TODO : 점프가능 트리거 초기화 함수 호출 or 트리거 변경
        }
    }
}
