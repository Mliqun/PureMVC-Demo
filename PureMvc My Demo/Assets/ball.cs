using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(KK(3));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator KK(float time)
    {
        while (true)
        {
            yield return new WaitForSeconds(time);
            time -= 0.2f;
            if (time<1)
            {
                time = 1;
            }
            Debug.Log(time);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "plane")
        {
            Debug.Log("触发了");
            //gameObject.GetComponent<Rigidbody2D>().gravityScale = 0;
            gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 750,ForceMode2D.Impulse);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "plane")
        {
            Debug.Log("离开了");
            //gameObject.GetComponent<Rigidbody2D>().gravityScale = 30;
        }
    }
}
