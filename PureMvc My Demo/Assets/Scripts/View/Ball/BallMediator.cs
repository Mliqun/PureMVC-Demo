using PureMVC.Interfaces;
using PureMVC.Patterns;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMediator : Mediator
{
    private BallProxy ballProxy = null;
    public new const string NAME = "BallMediator";
    public BallView View
    {
        get { return (BallView)ViewComponent; }
    }
    public BallMediator(BallView view) : base(NAME, view)
    {
        view.Create += () => { SendNotification(OrderSystemEvent.ADDBALL,"","Add"); };
        view.actions = new List<Action<object>>()
       {
           item=>SendNotification(OrderSystemEvent.AddSCORE,item,"AddScore"),
            item=>SendNotification(OrderSystemEvent.RemoveBall,item),
            item=>SendNotification(OrderSystemEvent.GameOver),
       };
    }
    public override void OnRegister()
    {
        ballProxy = Facade.RetrieveProxy(BallProxy.NAME) as BallProxy;
    }
    public override IList<string> ListNotificationInterests()
    {
        IList<string> notifitions = new List<string>();
        notifitions.Add(OrderSystemEvent.CreateBall);
        
        View.StartXc();
        return notifitions;
        
    }
    public override void HandleNotification(INotification notification)
    {
        BallItem ball = notification.Body as BallItem;
        switch (notification.Name)
        {
            case OrderSystemEvent.CreateBall:
                View.UpdateState(ball);
                ; break;
            case OrderSystemEvent.RemoveBall:
                //View.RemoveBall(ball);
                ; break;
        }
    }
}
