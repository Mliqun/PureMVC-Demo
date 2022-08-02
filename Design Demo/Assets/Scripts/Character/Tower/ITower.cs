using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ENUM_Tower
{
    Null=0,
    Low,
    Middle,
    Tall,
    Max
}
public abstract class ITower :ICharacter
{
    public ENUM_Tower m_EnumTower = ENUM_Tower.Null;
    float times = 0.3f;
    List<ICharacter> enemys = new List<ICharacter>();
    public ITower()
    {
        m_bullet = Resources.Load<GameObject>("Bullet");
    }

    public override void UpdateAI(List<ICharacter> Targets)
    {
        if (Targets.Count>0)
        {
            foreach (var item in Targets)
            {
                if (item.GetGameObj()!=null)
                {
                    if (Vector3.Distance(m_Obj.transform.position, item.GetGameObj().transform.position) <= 7)
                    {
                        enemys.Add(item);
                    }
                    else
                    {
                        enemys.Remove(item);
                    }
                }
                
            }
            if (enemys.Count>0)
            {
                if (enemys[0].GetGameObj())
                {
                    m_Obj.transform.forward = enemys[0].GetGameObj().transform.position - m_Obj.transform.position;
                    times += Time.deltaTime;
                    if (times >= 0.3f)
                    {
                        times = 0;
                        GameObject zd = GameObject.Instantiate(m_bullet);
                        zd.transform.position = m_Obj.transform.position + Vector3.forward;
                        zd.AddComponent<IBullet>().SetTarget(enemys[0].GetGameObj().transform);
                        enemys[0].LessHp(m_Attribute.atk);
                    }
                }
                else
                {
                    enemys.RemoveAt(0);
                }
                
            }
           
            //Collider[] colliders=Physics.OverlapSphere(m_Obj.transform.position, 8,LayerMask.GetMask("Enemy"));
            //if (colliders.Length>0)
            //{
            //    m_Obj.transform.forward = colliders[0].gameObject.transform.position - m_Obj.transform.position;
            //    times += Time.deltaTime;
            //    if (times>=0.3f)
            //    {
            //       GameObject zd=GameObject.Instantiate(m_bullet);
            //        zd.transform.position = m_Obj.transform.position + Vector3.forward;
            //        zd.AddComponent<IBullet>().SetTarget(colliders[0].transform);
            //        times = 0;
            //    }
            //}
            
        }
    }
    public ENUM_Tower GetSoldierType()
    {
        return m_EnumTower;
    }
    //public TowerAttr GetTowerValue()
    //{
    //    return m_Attribute as TowerAttr;
    //}

}
