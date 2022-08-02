using OrderSystem;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class BallView : MonoBehaviour
{
    private ObjectPool<BallItemView> objectPool = null;
    private List<BallItemView> balls = new List<BallItemView>();
    private Transform parent = null;
    bool flag = true;
    public Text scour;
    public Action Create = null;
    public List<Action<object>> actions = new List<Action<object>>();
    private void Awake()
    {
        flag = true;
        parent = transform.Find("Left");
        var prefab = Resources.Load<GameObject>("Ball");
        objectPool = new ObjectPool<BallItemView>(prefab, "BallPool");
    }
    private void Start()
    {
       
    }

    public void UpdateBall(IList<BallItem>ballItem)
    {
        for (int i = 0; i < this.balls.Count; i++)
        {
            objectPool.Push(this.balls[i]);
        }
        this.balls.AddRange(objectPool.Pop(ballItem.Count));
        for (int i = 0; i < balls.Count; i++)
        {
            balls[i].transform.SetParent(parent);
            var item = balls[i];
            item.gameObject.name = ballItem[i].name;
            item.transform.localPosition = new Vector3(0, 0,0);
            item.InitBall(ballItem[i]);
        }
    }
    public void StartXc()
    {
        StartCoroutine(CreatedBall(3));
    }
    public void CreateBall(BallItem ballItem)
    {

    }
    public void UpdateState(BallItem ballItem)
    {
        IList<BallItemView> balls=objectPool.Pop(1);
        var item = balls[0];
        item.transform.SetParent(parent);
        item.gameObject.name = ballItem.name;
        item.transform.localPosition = new Vector3(0, 0, 0);
        item.actionList = actions;
        item.InitBall(ballItem);

    }
    public void RemoveBall(BallItem ballItem)
    {
        for (int i = 0; i < balls.Count; i++)
        {
            if (balls[i].name.Equals(ballItem.name))
            {
                balls.RemoveAt(i);
                return;
            }
        }
    }
    public void GameOver()
    {
        flag = false;
    }
    IEnumerator CreatedBall(float time)
    {
        while (flag)
        {
            Create.Invoke();
            yield return new WaitForSeconds(time);
            time -= 0.1f;
            if (time < 1)
            {
                time = 1;
            }
        }
    }
}
