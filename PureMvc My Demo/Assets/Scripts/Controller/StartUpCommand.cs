using PureMVC.Interfaces;
using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartUpCommand : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        BallProxy ballProxy = new BallProxy();
        Facade.RegisterProxy(ballProxy);
        ScoreProxy scoreProxy = new ScoreProxy();
        Facade.RegisterProxy(scoreProxy);

        MainUI mainUI = notification.Body as MainUI;
        
        Facade.RegisterMediator(new StatrtMediator(mainUI.StartView));
        

        Facade.RegisterCommand(OrderSystemEvent.ADDBALL, typeof(BallComponent));
        Facade.RegisterCommand(OrderSystemEvent.AddSCORE, typeof(ScoreCommond));
    }
}
