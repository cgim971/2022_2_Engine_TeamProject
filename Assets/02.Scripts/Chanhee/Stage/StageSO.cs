using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Stage", menuName = "SO/Stages/New Stage")]
public class StageSO : ScriptableObject
{
    public string stageTitle;
    public int stageIndex;
}
