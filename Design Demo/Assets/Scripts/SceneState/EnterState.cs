using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnterState : SceneStateBase
{
    public Button startBtn;
    public EnterState(SceneControl _c) : base(_c)
    {
        ID = StateID.EnterScene;
        startBtn = GameObject.Find("Canvas/StartBtn").GetComponent<Button>();
        startBtn.onClick.AddListener(() =>
        {
            control.ChangeScene(StateID.FightScene);
        });
    }
    public override void OnBegin()
    {

    }
    public override void OnEnd()
    {
        base.OnEnd();
    }
    public override void Update()
    {

    }
}
