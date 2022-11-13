using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "StageList", menuName = "SO/List/StageList")]
public class StageSOList : ScriptableObject
{
    public List<StageSO> stageList = new List<StageSO>();
}
