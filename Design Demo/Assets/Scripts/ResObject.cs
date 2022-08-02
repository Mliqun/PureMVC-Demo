using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResObject 
{
    public GameObject tower1;
    public GameObject tower2;
    public GameObject tower3;
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    public GameObject bullet1;
    public GameObject bullet2;
    public GameObject bullet3;
    private static ResObject _instance;
    public static ResObject Instance
    {
        get
        {
            if (_instance == null)
                _instance = new ResObject();
            return _instance;
        }
    }
    public ResObject()
    {
        Init();
    }

    private void Init()
    {
        tower1 = Resources.Load<GameObject>("Tower/Tower1");
        tower2 = Resources.Load<GameObject>("Tower/Tower2");
        tower3 = Resources.Load<GameObject>("Tower/Tower3");

        enemy1 = Resources.Load<GameObject>("Enemy/Enemy1");
        enemy2 = Resources.Load<GameObject>("Enemy/Enemy2");
        enemy3 = Resources.Load<GameObject>("Enemy/Enemy3");

        bullet1 = Resources.Load<GameObject>("Bullet/Bullet1");
        bullet2 = Resources.Load<GameObject>("Bullet/Bullet2");
        bullet3 = Resources.Load<GameObject>("Bullet/Bullet3");
    }
    public GameObject GetTower(string name)
    {
       return Resources.Load<GameObject>("Tower/"+name);
    }
    public GameObject GetEnemy(string name)
    {
        return Resources.Load<GameObject>("Enemy/" + name);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
