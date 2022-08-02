using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAttr
{
    public int m_MaxHp;
    public int m_MoveSpeed;
    public int m_Attack;
}
public class TowerBassAttr:BaseAttr
{
    public TowerBassAttr(int _attack)
    {
        m_Attack = _attack;
    }
}
public class EnemyBaseAttr : BaseAttr
{
    public EnemyBaseAttr(int maxHp, int moveSpeed,int Attack)
    {
        m_MaxHp = maxHp;
        m_MoveSpeed = moveSpeed;
        m_Attack = Attack;
    }
}
