using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ENUM_Bullet
{
    Null=0,
    Single,
    Scope,
    Max
}
public class IBullet:MonoBehaviour
{
    Transform target;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void SetTarget(Transform _target)
    {
        target = _target;
    }
    // Update is called once per frame
    void Update()
    {
        if (target!=null)
        {
            transform.LookAt(target);
            transform.Translate(Vector3.forward*Time.deltaTime*50);
        }else
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag=="Enemy")
        {
            Destroy(gameObject);
        }
    }
}
