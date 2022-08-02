using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerBuildParam:ICharacterBuildParam
{
    public int Lv = 0;
    public TowerBuildParam()
    {

    }
}

public class TowerBuilder : ICharacterBuilder
{
    private TowerBuildParam m_BuildParm = null;
    public override void AddAI()
    {
        
    }

    public override void AddBullet()
    {
       
    }

    public override void AddCharacterSystem(TowerDefenceGame TowerGame)
    {
        
    }

    public override void LoadAsset(int GameObjectID)
    {
        GameObject towerGameObject = ResObject.Instance.GetTower(m_BuildParm.NewCharacter.GetAssetName());
        towerGameObject.transform.position = m_BuildParm.SpawnPosition;
        towerGameObject.gameObject.name = GameObjectID.ToString();
        m_BuildParm.NewCharacter.SetGameObj(towerGameObject);
       
    }

    public override void SetBuildParam(ICharacterBuildParam theParam)
    {
        m_BuildParm = theParam as TowerBuildParam;
    }

    public override void SetCharacterAttr()
    {
        AttrFactory attrFactory=TowerDefenceGame.Instance.GetAttrFacatory();
        int attrID = m_BuildParm.NewCharacter.Getattr();
        TowerAttr towerAttr = attrFactory.GetTowerAttr(attrID);
        m_BuildParm.NewCharacter.SetCharacterAttr(towerAttr);
    }
}
