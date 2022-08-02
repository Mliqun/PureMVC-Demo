using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCube : IEnemy
{
    public EnemyCube()
    {
        m_emEnemyType = ENUM_Enemy.Cube;
        m_AssetName = "Enemy1";
        AttrID = 1;
    }
}
