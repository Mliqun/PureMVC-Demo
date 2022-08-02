using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBuildParm:ICharacterBuildParam
{
    public List<Transform> roots;
    public EnemyBuildParm()
    {

    }
}
public class EnemyBuilder : ICharacterBuilder
{
    private EnemyBuildParm m_BuildParm = null;
    public override void AddAI()
    {
        EnemyAI theAI = new EnemyAI(m_BuildParm.NewCharacter,m_BuildParm.roots);
        m_BuildParm.NewCharacter.SetAI(theAI);
    }

    public override void AddBullet()
    {
        
    }

    public override void AddCharacterSystem(TowerDefenceGame TowerGame)
    {
        
    }

    public override void LoadAsset(int GameObjectID)
    {
        GameObject enemyGameObject = ResObject.Instance.GetEnemy(m_BuildParm.NewCharacter.GetAssetName());
        enemyGameObject.transform.position = m_BuildParm.SpawnPosition;
        enemyGameObject.gameObject.name = GameObjectID.ToString();
        m_BuildParm.NewCharacter.SetGameObj(enemyGameObject);
    }

    public override void SetBuildParam(ICharacterBuildParam theParam)
    {
        m_BuildParm = theParam as EnemyBuildParm;
    }

    public override void SetCharacterAttr()
    {
        AttrFactory attrFactory = TowerDefenceGame.Instance.GetAttrFacatory();
        int attrID = m_BuildParm.NewCharacter.Getattr();
        EnemyAttr towerAttr = attrFactory.GetEnemyAttr(attrID);
        m_BuildParm.NewCharacter.SetCharacterAttr(towerAttr);
    }
}
