using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleTower : ITower
{
    public MiddleTower()
    {
        m_EnumTower = ENUM_Tower.Low;
        m_AssetName = "Tower2";
        AttrID = 2;
    }
}
