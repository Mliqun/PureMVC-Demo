using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IUserInterface 
{
    protected TowerDefenceGame m_TowerGame = null;
    protected GameObject m_RootUI = null;
    private bool m_bActive = true;
    public IUserInterface(TowerDefenceGame tower)
    {
        m_TowerGame = tower;
    }
    public virtual void Initialize() { }
    public virtual void Release() { }
    public virtual void Update() { }
}
