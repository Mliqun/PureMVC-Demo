using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallProxy : Proxy
{
    public new const string NAME = "BallProxy";
    public IList<BallItem> ball
    {
        get { return (IList<BallItem>)base.Data; }
    }
    public BallProxy():base(NAME)
    {
        
    }
    public override void OnRegister()
    {
        //AddBall();
    }
    public void AddBall()
    {
        int x = Random.Range(10, 150);
        float scal = Random.Range(1.0f, 2f);
        BallItem ballItem = new BallItem("ball"+x+scal, new Vector3(scal, scal, scal), new Vector2(x, 0), true);
        UpdateBall(ballItem);
    }
    public void ChangeState(BallItem item)
    {
        if (ball.Contains(item))
        {
            item.isIn = false;
            UpdateBall(item);
        }
    }
    public void UpdateBall(BallItem item)
    {
        {
            SendNotification(OrderSystemEvent.CreateBall, item);
        }
    }

   
}
