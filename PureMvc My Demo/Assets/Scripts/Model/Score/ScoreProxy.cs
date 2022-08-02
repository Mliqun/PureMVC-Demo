using PureMVC.Patterns;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ScoreProxy : Proxy
{
    int maxScore;
    public new const string NAME = "ScoreProxy";
    public ScoreItem ScoreItem
    {
        get { return (ScoreItem)base.Data; }
    }
    public ScoreProxy() : base(NAME,new ScoreItem(1,0))
    {
        AddScoreItem(new ScoreItem(1,1));
        maxScore =int.Parse( File.ReadAllText("Assets/MaxScore.txt"));
    }
    public void AddScore(ScoreItem item)
    {
        item.score++;
        
        if (item.score> maxScore)
        {
            SendNotification(OrderSystemEvent.RefreshMaxScore, item);
        }
        UpdateScore(item);
    }
    public void AddScoreItem(ScoreItem item)
    {
        //if (ScoreItem.score==item.score)
        {
            UpdateScore(item);
        }
    }
    public void UpdateScore(ScoreItem item)
    {
        SendNotification(OrderSystemEvent.RefreshScore, ScoreItem);
    }
}
