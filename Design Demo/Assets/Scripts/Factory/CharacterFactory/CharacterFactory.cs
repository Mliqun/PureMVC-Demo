using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterFactory : ICharacterFactory
{
    private CharacterBuilderSystem m_BuilderDirector = new CharacterBuilderSystem();
    public override ITower CreateTower(ENUM_Tower emTower, ENUM_Bullet emBullet, int Lv, Vector3 SpawnPosition)
    {
        TowerBuildParam TowerParam = new TowerBuildParam();
        switch (emTower)
        {
            case ENUM_Tower.Low:
                TowerParam.NewCharacter = new LowTower();
                break;
            case ENUM_Tower.Middle:
                TowerParam.NewCharacter = new MiddleTower();
                break;
            case ENUM_Tower.Tall:
                TowerParam.NewCharacter = new TallTower();
                break;
            default:
                break;
        }
        if (TowerParam.NewCharacter==null)
        {
            return null;
        }
        TowerParam.emBullet = emBullet;
        TowerParam.SpawnPosition = SpawnPosition;
        TowerParam.Lv = Lv;

        TowerBuilder theTowerBuilder = new TowerBuilder();
        theTowerBuilder.SetBuildParam(TowerParam);
        m_BuilderDirector.Construct(theTowerBuilder);
        return TowerParam.NewCharacter as ITower;
    }
    public override IEnemy CreateEnemy(ENUM_Enemy emEnemy, Vector3 SpawnPosition,List<Transform> ss)
    {
        EnemyBuildParm enemyParm = new EnemyBuildParm();
        switch (emEnemy)
        {
            case ENUM_Enemy.Null:
                break;
            case ENUM_Enemy.Cube:
                enemyParm.NewCharacter = new EnemyCube();
                break;
            case ENUM_Enemy.Sphere:
                enemyParm.NewCharacter = new EnemySphere();
                break;
            case ENUM_Enemy.Capsule:
                enemyParm.NewCharacter = new EnemyCapsule();
                break;
            default:
                break;
        }
        if (enemyParm.NewCharacter == null) return null;

        enemyParm.SpawnPosition = SpawnPosition;
        enemyParm.roots = ss;
        EnemyBuilder enemyBuilder = new EnemyBuilder();
        enemyBuilder.SetBuildParam(enemyParm);
        m_BuilderDirector.Construct(enemyBuilder);
        return enemyParm.NewCharacter as IEnemy;
    }

}
