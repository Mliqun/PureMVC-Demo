using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSystem 
{
    TowerDefenceGame towerGame;
    private List<ICharacter> m_Towers = new List<ICharacter>();
    private List<ICharacter> m_Enemys = new List<ICharacter>();
    public CharacterSystem(TowerDefenceGame _towerGame)
    {
        towerGame = _towerGame;
    }
    public void Finish()
    {
        foreach (var item in m_Towers)
        {
            GameObject.Destroy(item.GetGameObj());
        }
        foreach (var item in m_Enemys)
        {
            GameObject.Destroy(item.GetGameObj());
        }
    }
    public void AddTower(ITower theTower)
    {
        m_Towers.Add(theTower);
    }
    public void AddEnemy(IEnemy theEnemy)
    {
        m_Enemys.Add(theEnemy);
    }
    public void RemoveEnemy(IEnemy theEnemy)
    {
        m_Enemys.Remove(theEnemy);
    }

    public void  Update()
    {
        UpdateCharacter();
    }
    private void UpdateCharacter()
    {
        if (m_Towers.Count>0)
        {
            foreach (ICharacter Character in m_Towers)
                Character.UpdateAI(m_Enemys);
        }
      if (m_Enemys.Count>0)
        {
            foreach (ICharacter Character in m_Enemys)
                Character.Update();
        }
    }
}
