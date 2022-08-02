using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TallTower : ITower
{
    public TallTower()
    {
        m_EnumTower = ENUM_Tower.Low;
        m_AssetName = "Tower3";
        AttrID = 3;
    }
}
