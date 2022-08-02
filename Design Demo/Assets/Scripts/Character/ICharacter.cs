using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class ICharacter 
{
    protected string m_Name = "";
    protected GameObject m_Obj = null;
    protected string m_AssetName = "";//模型名称
    protected bool m_bKilled = false;//是否阵亡
    protected bool m_bCheckKilled=false;//是否确认阵亡事件
    protected float m_RemoveTimer = 1.5f;//阵亡多久可以移除
    protected bool m_bCanRemove = false;//是否可以移除
    protected GameObject m_bullet = null;
    protected int AttrID;
    protected ICharacterAttr m_Attribute = null;//值
    protected ICharacterAI m_AI = null;//AI
    public Slider slider;

    public int Getattr()
    {
        return AttrID;
    }
    public virtual void SetGameObj(GameObject gameObj)
    {
        m_Obj =GameObject.Instantiate(gameObj);
    }
    public GameObject GetGameObj()
    {
        return m_Obj;
    }
    public void Release()
    {
        if (m_Obj != null)
            GameObject.Destroy(m_Obj);
    }

    public virtual void Update()
    {
       // m_AI.Update();
    }
    
    public virtual void UpdateAI(List<ICharacter> Targets)
    {

    }
    public string GetName()
    {
        return m_Name;
    }

    // 取得Asset名称
    public string GetAssetName()
    {
        return m_AssetName;
    }
    public ICharacterAttr GetCharacterAttr()
    {
        return m_Attribute;
    }
    //设定AI
    public void SetAI(ICharacterAI CharacterAI)
    {
        m_AI = CharacterAI;
    }

    public void Attack()
    {

        TowerDefenceGame.Instance.LessHp(m_Attribute.m_BaseAttr.m_Attack);
        // 設定武器額外攻擊加乘
        //SetWeaponAtkPlusValue(m_Attribute.GetAtkPlusValue());

        // 攻擊
        //WeaponAttackTarget(Target);

        // 攻擊動作
        //m_GameObject.GetComponent<CharacterMovement>().PlayAttackAnim();

        // 面向目標
        //m_Obj.transform.forward = Target.GetPosition() - GetPosition();
    }
    public void Killed()
    {
        if (m_bKilled == true)
            return;
        m_bKilled = true;
        m_bCheckKilled = false;
    }

    // 是否阵亡 
    public bool IsKilled()
    {
        return m_bKilled;
    }

    // 是否确认阵亡过
    public bool CheckKilledEvent()
    {
        if (m_bCheckKilled)
            return true;
        m_bCheckKilled = true;
        return false;
    }

    //  是否可以移除
    public bool CanRemove()
    {
        return m_bCanRemove;
    }
    public void LessHp(int atk)
    {
        m_Attribute.LessHp(atk);
        slider.value = (float)m_Attribute.m_NowHp / maxHp;
        if (m_Attribute.m_NowHp<=0)
        {
            TowerDefenceGame.Instance.Remove(this as IEnemy);
            GameObject.Destroy(m_Obj);
        }
    }
    int maxHp=0;
    // 设定角色数值
    public virtual void SetCharacterAttr(ICharacterAttr CharacterAttr)
    {
        // 设定
        m_Attribute = CharacterAttr;
        m_Attribute.InitAttr();
        maxHp = m_Attribute.m_NowHp;
        

        // 设定移动速度
        //m_NavAgent.speed = m_Attribute.GetMoveSpeed();
        //Debug.Log ("设定移动速度:"+m_NavAgent.speed);

        // 名称
        //m_Name = m_Attribute.GetAttrName();
    }
}
