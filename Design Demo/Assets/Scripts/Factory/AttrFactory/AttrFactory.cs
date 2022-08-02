using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttrFactory : IAttrFactory
{
    private Dictionary<int, TowerBassAttr> m_TowerAttrs = null;
    private Dictionary<int, EnemyBaseAttr> m_EnemyAttrs = null;

    public AttrFactory()
    {
        InitTowerAttr();
        InitEnemyAttr();

    }

    private void InitEnemyAttr()
    {
        m_EnemyAttrs = new Dictionary<int, EnemyBaseAttr>();
        m_EnemyAttrs.Add(1, new EnemyBaseAttr(100, 5,1));
        m_EnemyAttrs.Add(2, new EnemyBaseAttr(150, 7,2));
        m_EnemyAttrs.Add(3, new EnemyBaseAttr(200, 10,3));
    }

    private void InitTowerAttr()
    {
        m_TowerAttrs = new Dictionary<int, TowerBassAttr>();
        m_TowerAttrs.Add(1, new TowerBassAttr(10));
        m_TowerAttrs.Add(2, new TowerBassAttr(20));
        m_TowerAttrs.Add(3, new TowerBassAttr(30));
    }

    public override EnemyAttr GetEnemyAttr(int AttrID)
    {
        if (m_EnemyAttrs.ContainsKey(AttrID) == false)
        {
            return null;
        }
        EnemyAttr NowAttr = new EnemyAttr();
        NowAttr.SetBaseAttr(m_EnemyAttrs[AttrID]);
        return NowAttr;
    }

    public override TowerAttr GetTowerAttr(int AttrID)
    {
        if (m_TowerAttrs.ContainsKey(AttrID) == false)
        {
            return null;
        }
        TowerAttr towerAttr = new TowerAttr();
        towerAttr.SetBaseAttr(m_TowerAttrs[AttrID]);
        return towerAttr;
    }
}
