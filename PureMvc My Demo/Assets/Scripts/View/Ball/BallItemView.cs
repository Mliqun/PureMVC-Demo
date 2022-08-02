using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallItemView : MonoBehaviour
{
    public Image image;
    public ConstantForce2D force;
    public BallItem ballItem = null;
    public IList<Action<object>> actionList = new List<Action<object>>();
    public void Awake()
    {
        image = transform.GetComponent<Image>();
        force = gameObject.GetComponent<ConstantForce2D>();
    }
    public void InitBall(BallItem item)
    {
        ballItem = item;
        UpdateState();
    }
    private void UpdateState()
    {
        force.force = ballItem.force;
        transform.localScale = ballItem.scal;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "plane")
        {
            Debug.Log("触发了");
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 750, ForceMode2D.Impulse);
        }else if(collision.transform.name == "Wall")
        {
            actionList[1].Invoke(ballItem);
            actionList[0].Invoke(ballItem);
            Destroy(gameObject);
        }else if(collision.tag == "Player")
        {
            actionList[2].Invoke(null);
        }
    }

}
