using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New PlayerInventorySO", menuName = "SO/List/PlayerInventoryList")]
public class PlayerInventorySO : ScriptableObject
{
    public List<PlayerColorSO> _playerColorList = new List<PlayerColorSO>();
    public List<PlayerModelSO> _playerModelList = new List<PlayerModelSO>();
}
