using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    SceneControl control;
    // Start is called before the first frame update
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        control = new SceneControl();
        SceneStateBase enterScene = new EnterState(control);
        SceneStateBase fightScene = new FightState(control);
        control.AddState(enterScene);
        control.AddState(fightScene);
    }

    // Update is called once per frame
    void Update()
    {
        control.Update();
    }
}
