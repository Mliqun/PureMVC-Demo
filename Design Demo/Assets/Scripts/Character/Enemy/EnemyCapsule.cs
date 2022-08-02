using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCapsule : IEnemy
{
    public EnemyCapsule()
    {
        m_emEnemyType = ENUM_Enemy.Capsule;
        m_AssetName = "Enemy3";
        AttrID = 3;
    }
}
