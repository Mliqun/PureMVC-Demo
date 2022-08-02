using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : ICharacterAI
{
    List<Transform> roots = new List<Transform>();
    public GameObject enemyObj;
    int index=0;
    IEnemy enemy;
    public EnemyAI(ICharacter character,List<Transform> trans ):base(character)
    {
        roots = trans;
        enemy = character as IEnemy;
        enemyObj= m_Character.GetGameObj();
    }
    public override void Update()
    {
        if (enemyObj!=null)
        {
            enemyObj.transform.LookAt(roots[index]);
            enemyObj.transform.Translate(Vector3.forward * Time.deltaTime * enemy.GetCharacterAttr().m_MoveSpeed);
            if (index < roots.Count - 1)
            {
                if (Vector3.Distance(enemyObj.transform.position, roots[index].position) < 0.5f)
                {
                    index++;
                }
            }
            else
            {
                if (Vector3.Distance(enemyObj.transform.position, roots[index].position) <= 0.5f)
                {
                    m_Character.Attack();
                    GameObject.Destroy(enemyObj);
                }
            }
        }
       
    }
}
