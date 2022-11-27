using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkinInfo : MonoBehaviour
{

    [SerializeField] private SkinSO _skinSO;
    public SkinSO SKINSO
    {
        get => _skinSO;
        set
        {
            _skinSO = value;
            SetSkinSO();
        }
    }

    void SetSkinSO()
    {
        this.GetComponent<Button>().onClick.AddListener(() =>
        {
            Debug.Log($"{_skinSO.name}");
        });
    }



}
