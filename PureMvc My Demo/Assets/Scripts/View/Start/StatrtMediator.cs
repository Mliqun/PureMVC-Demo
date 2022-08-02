using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatrtMediator : Mediator
{
    public new const string NAME = "StartMediator";
    private StartView View
    {
        get { return (StartView)ViewComponent ;}
    }
    public StatrtMediator(StartView view):base(NAME,view)
    {
        view.submit += () => {
            Facade.RegisterMediator(new BallMediator(view.ballview));
            Facade.RegisterMediator(new ScoreMediator(view.scoreView));
        };
    }

    public override IList<string> ListNotificationInterests()
    {
        IList<string> notifications = new List<string>();
        notifications.Add(OrderSystemEvent.GameOver);
       
        return notifications;
    }
    public override void HandleNotification(INotification notification)
    {
        ScoreProxy scoreProxy = Facade.RetrieveProxy(ScoreProxy.NAME) as ScoreProxy;
        switch (notification.Name)
        {
            case OrderSystemEvent.GameOver:
                View.UpStart(scoreProxy.ScoreItem);break;
        }
    }
}
