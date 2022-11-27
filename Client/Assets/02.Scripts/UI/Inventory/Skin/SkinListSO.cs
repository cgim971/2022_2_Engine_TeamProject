using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkinList", menuName = "SO/List/SkinList")]
public class SkinListSO : ScriptableObject
{
    public List<SkinSO> _cubeSkins;
    public List<SkinSO> _airplaneSkins;
    public List<SkinSO> _ufoSkins;
    public List<SkinSO> _robotSkins;
}
