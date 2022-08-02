using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeSystem 
{
    TowerDefenceGame defenceGame;
    List<Transform> objs = new List<Transform>();
    public Transform roots;
    public Transform startPos;
    float times = 0;
    int index=1;
    ENUM_Enemy _Enemy;
    bool IsCreate=false;
    float createTime = 0;
    int createIndex = 0;
    public TimeSystem(TowerDefenceGame game)
    {
        defenceGame = game;
        Init();
    }
    public void Init()
    {
        startPos = GameObject.Find("RoodWz").transform.GetChild(0);
        roots = GameObject.Find("RoadRoot").transform;
        foreach (Transform item in roots.GetComponentsInChildren<Transform>())
        {
            if (item!=roots.transform)
            {
                objs.Add(item);
            }
        }
    }
    public void CreateEnemy()
    {
        switch(index)
        {
            case 1:_Enemy = ENUM_Enemy.Cube;break;
            case 2:_Enemy = ENUM_Enemy.Sphere;break;
            case 3:_Enemy = ENUM_Enemy.Capsule;break;
        }
        index++;
    }
   public void Update()
    {
        times += Time.deltaTime;
        
        if (index<=3)
        {
            if (times >= 5)
            {
                times = 0;
                CreateEnemy();
                IsCreate = true;
                createIndex = 0;
                
            }
        }

        if (IsCreate)
        {
            createTime += Time.deltaTime;
            if (createTime>=0.5f)
            {
                createIndex++;
                createTime = 0;
                defenceGame.CreateEnemy(_Enemy, startPos.position, objs);
                if (createIndex==3)
                {
                    IsCreate = false;
                }
            }
        }
        
    }
}
