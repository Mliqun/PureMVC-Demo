using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SceneName
{
    nullType=0,
    EnterID,
    FightID
}
public enum StateID
{
    nullType=0,
    EnterScene,
    FightScene
}
public class SceneStateBase 
{
    public StateID ID;
    public SceneControl control;
    public SceneStateBase(SceneControl _c)
    {
        control = _c;
    }
    public virtual void OnBegin() { }
    public virtual void OnEnd() { }
    public virtual void Update() { }

}
