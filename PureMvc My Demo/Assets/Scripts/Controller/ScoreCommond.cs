using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PureMVC.Patterns;
using PureMVC.Interfaces;

public class ScoreCommond : SimpleCommand
{
    public override void Execute(INotification notification)
    {
        ScoreProxy scoreProxy = Facade.RetrieveProxy(ScoreProxy.NAME) as ScoreProxy;
        if (notification.Type== "AddScore")
        {
            scoreProxy.AddScore(scoreProxy.ScoreItem);
        }
    }
}
