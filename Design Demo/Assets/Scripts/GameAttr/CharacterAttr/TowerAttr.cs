using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerAttr : ICharacterAttr
{
    public int m_TowerLv;
    public override void SetBaseAttr(BaseAttr BaseAttr)
    {
        base.SetBaseAttr(BaseAttr);
        m_TowerLv = 1;
    }
} 
