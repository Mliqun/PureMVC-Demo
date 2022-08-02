using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum ENUM_Enemy
{
    Null=0,
    Cube,
    Sphere,
    Capsule
}
public class IEnemy : ICharacter
{
    protected ENUM_Enemy m_emEnemyType = ENUM_Enemy.Null;
    Camera camera;

    public IEnemy()
    {
        camera = Camera.main;
    }
    public override void SetGameObj(GameObject gameObj)
    {
        m_Obj = GameObject.Instantiate(gameObj);
        slider = m_Obj.transform.GetChild(0).GetChild(0).GetComponent<Slider>();
    }
    public ENUM_Enemy GetEnemyType()
    {
        return m_emEnemyType;
    }
    public override void Update()
    {
        m_AI.Update();
        if (slider!=null)
        {
            slider.transform.LookAt(slider.transform.position + (camera.transform.rotation * Vector3.back));
        }
    }
    //被武器攻击
    public void UnderAttack(ICharacter Attacker)
    {
        // 計算傷害值
        //m_Attribute.CalDmgValue(Attacker);

        //DoPlayHitSound();// 音效
        //DoShowHitEffect();// 特效 

        //// 是否陣亡
        //if (m_Attribute.GetNowHP() <= 0)
        //{
        //    Killed();
        //}
    }

}
