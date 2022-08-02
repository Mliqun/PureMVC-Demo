using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    public List<GameObject> keys;
    private int currIndex=0;
    private int lastIndex = -1;

    public void SetState(int index)
    {
        if (index==lastIndex)
        {
            return;
        }
        if (lastIndex==-1)
        {
            keys[currIndex].SetActive(false);
        }
        else
        {
            keys[lastIndex].SetActive(false);
        }
        keys[index].SetActive(true);
        lastIndex = index;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            SetState(1);
            gameObject.transform.Translate(Vector3.left * 4);
            //if (transform.position.x<=-495f)
            //{
            //    transform.position = new Vector2(-495f, 0);
            //}
            
        }
        else if(Input.GetKey(KeyCode.D))
        {
            SetState(2);
            gameObject.transform.Translate(Vector3.right*4);
            //if (transform.position.x >= 492f)
            //{
            //    transform.position = new Vector2(492f, 0);
            //}
        }
        else
        {
            //if (Input.GetKeyDown(KeyCode.Space))
            //{
            //    keys[currIndex].GetComponent<Rigidbody2D>().AddForce(Vector2.up * 200,ForceMode2D.Impulse);
            //}
            SetState(0);
        }
    }
}
