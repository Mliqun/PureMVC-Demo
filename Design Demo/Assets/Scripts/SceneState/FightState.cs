using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightState : SceneStateBase
{
    public FightState(SceneControl _c) : base(_c)
    {
        ID = StateID.FightScene;
    }
    public override void OnBegin()
    {
        Debug.Log("进入战斗场景");
        TowerDefenceGame.Instance.Init(control);
    }
    public override void OnEnd()
    {
       
        
    }
    public override void Update()
    {
        TowerDefenceGame.Instance.Update();
    }
}
