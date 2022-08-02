using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallItem 
{
    public string name;
    public Vector3 scal;
    public Vector2 force;
    public bool isIn;

    public BallItem(string name, Vector3 scal, Vector2 force, bool isIn)
    {
        this.name = name;
        this.scal = scal;
        this.force = force;
        this.isIn = isIn;
    }
    public override string ToString()
    {
        if (isIn)
        {
            return "在屏幕内";
        }
        else
        {
            return "出屏幕了";
        }
    }
}
