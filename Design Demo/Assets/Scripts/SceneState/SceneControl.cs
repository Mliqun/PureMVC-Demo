using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl 
{
    Dictionary<StateID, SceneStateBase> dic = new Dictionary<StateID, SceneStateBase>();
    public SceneStateBase currState;
    public StateID stateid;
    public void Update()
    {
        currState.Update();
    }
    public void AddState(SceneStateBase s)
    {
        if (currState==null)
        {
            currState = s;
            stateid = s.ID;
        }
        if (!dic.ContainsKey(s.ID))
        {
            dic.Add(s.ID, s);
        }
    }
    public void ChangeScene(StateID iD)
    {
        if (!dic.ContainsKey(iD)) return;
        SceneStateBase sceneState = dic[iD];
        currState.OnEnd();
        Debug.Log(iD.ToString());
        SceneManager.LoadScene(iD.ToString());
        SceneManager.activeSceneChanged += (x, y) => {
            
            currState = sceneState;
            currState.OnBegin();
            //currState.OnBegin();
        };
    }
}
