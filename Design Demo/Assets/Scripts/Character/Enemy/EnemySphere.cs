using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySphere : IEnemy
{
    public EnemySphere()
    {
        m_emEnemyType = ENUM_Enemy.Sphere;
        m_AssetName = "Enemy2";
        AttrID = 2;
    }
}
