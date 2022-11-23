using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle_Base : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Obstacle");

            // 변경 필요 고쳐라 김찬희
            SceneManager.LoadScene($"STAGE_{GameManager.Instance.CURRENTSTAGE._stageIndex}");
            SceneManager.LoadScene("GameUI", UnityEngine.SceneManagement.LoadSceneMode.Additive);

            //if (IsUp()) return;

            //#if UNITY_EDITOR
            //            UnityEditor.EditorApplication.isPlaying = false;
            //#else
            //        Application.Quit();
            //#endif
        }

    }

    private bool IsUp()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.up, out hit))
        {
            if (hit.collider.CompareTag("Player"))
            {
                return true;
            }
        }
        return false;
    }
}
