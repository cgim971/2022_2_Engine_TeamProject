using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Skin", menuName = "SO/Inventory/Skin")]
public class SkinSO : ScriptableObject
{
    public int _index;
    public GameObject _sprite;
    public PlayerMode _playerMode;
    public Mesh _model;
}
