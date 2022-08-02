using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowTower : ITower
{
    public LowTower()
    {
        m_EnumTower = ENUM_Tower.Low;
        m_AssetName = "Tower1";
        AttrID = 1;
    }
}
