using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerDefenceGame
{
	private static TowerDefenceGame _instance;
	public static TowerDefenceGame Instance
	{
		get
		{
			if (_instance == null)
				_instance = new TowerDefenceGame();
			return _instance;
		}
	}
	bool isStop = true;
	private CharacterFactory characterFactory = null;
	private CampInfoUI m_campInfoUI = null;
	private TimeSystem timeSystem = null;
	private CharacterSystem characterSystem = null;
	private AttrFactory attrFactory = null;
	private SceneControl control;
	private LastRoot lastRoot;
	public void Init(SceneControl _control)
	{
		control = _control;
		characterSystem = new CharacterSystem(this);
		attrFactory = new AttrFactory();
		
		characterFactory = new CharacterFactory();
		m_campInfoUI = new CampInfoUI(this);
		//m_campInfoUI.Initialize();
		lastRoot = new LastRoot(this);
		timeSystem = new TimeSystem(this);
		
		
		isStop = true;
	}
	public void LessHp(int less)
    {
		lastRoot.LessHp(less);
    }
	public AttrFactory GetAttrFacatory()
	{
		return attrFactory;
	}
	public void Update()
	{
		if (isStop)
		{
			timeSystem.Update();
			characterSystem.Update();
			m_campInfoUI.Update();
		}
	}

	internal void CreateTower(ENUM_Tower currTower, Vector3 v3)
	{
		characterSystem.AddTower(characterFactory.CreateTower(currTower, ENUM_Bullet.Null, 1, v3));
	}

	internal void Back()
	{
		characterSystem.Finish();
		control.ChangeScene(StateID.EnterScene);

		//Time.timeScale = 0;
	}
	public void Finish()
	{
		m_campInfoUI.Defeate();
		isStop = false;
	}

	internal void CreateEnemy(ENUM_Enemy currTower, Vector3 v3, List<Transform> ss)
	{
		characterSystem.AddEnemy(characterFactory.CreateEnemy(currTower, v3, ss));
	}

	internal void Remove(IEnemy character)
	{
		characterSystem.RemoveEnemy(character);
	}
}
