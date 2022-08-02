using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreMediator : Mediator
{
    private ScoreProxy scoreProxy = null;
    public new const string NAME = "ClientMediator";
    private ScoreView View
    {
        get { return (ScoreView)ViewComponent; }
    }
    public ScoreMediator(ScoreView view):base(NAME,view)
    {

    }
    public override void OnRegister()
    {
        scoreProxy = Facade.RetrieveProxy(ScoreProxy.NAME) as ScoreProxy;
        View.AddScore(scoreProxy.ScoreItem);
    }
    public override IList<string> ListNotificationInterests()
    {
        IList<string> notifications = new List<string>();
        notifications.Add(OrderSystemEvent.RefreshScore);
        notifications.Add(OrderSystemEvent.RefreshMaxScore);
        return notifications;
    }
    public override void HandleNotification(INotification notification)
    {
        switch(notification.Name)
        {
            case OrderSystemEvent.RefreshScore:
                ScoreItem item = notification.Body as ScoreItem;
                View.AddScore(item);
                ;break;
            case OrderSystemEvent.RefreshMaxScore:
                View.RefreshMaxScore(scoreProxy.ScoreItem); break;
        }
    }
}
