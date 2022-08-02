using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class BallComponent : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        BallProxy ballProxy = Facade.RetrieveProxy(BallProxy.NAME) as BallProxy;

        if (notification.Type=="Add")
        {
            ballProxy.AddBall();
        }
    }
}
