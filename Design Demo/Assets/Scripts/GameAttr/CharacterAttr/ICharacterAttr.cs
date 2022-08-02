using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ICharacterAttr 
{
    public BaseAttr m_BaseAttr = null;
	public int m_NowHp = 0;
	public int m_MoveSpeed=0;
	public int atk = 0;
	public virtual void SetBaseAttr(BaseAttr BaseAttr)
	{
		m_BaseAttr = BaseAttr;
	}
	public virtual void InitAttr()
    {
		FullNowHP();
	}
	public void LessHp(int a)
    {
		m_NowHp -= a;
		Debug.Log(m_NowHp);

	}
    private void FullNowHP()
    {
		m_NowHp = m_BaseAttr.m_MaxHp;
		atk = m_BaseAttr.m_Attack;
		Debug.Log(atk);
		m_MoveSpeed = m_BaseAttr.m_MoveSpeed;
	}
}
