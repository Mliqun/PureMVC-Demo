using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ICharacterFactory 
{
    //建立炮塔
    public abstract ITower CreateTower(ENUM_Tower emTower, ENUM_Bullet emBullet, int Lv, Vector3 SpawnPosition);

    //建立Enemy
    public abstract IEnemy CreateEnemy(ENUM_Enemy emEnemy, Vector3 SpawnPosition,List<Transform> ss);
}
