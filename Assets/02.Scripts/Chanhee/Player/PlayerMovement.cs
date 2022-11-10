using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface PlayerMovement
{
    IEnumerator Move();
    IEnumerator CheckClick();
    IEnumerator MoveState();

}
