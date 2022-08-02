using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ICharacterBuildParam
{
	public ENUM_Bullet emBullet = ENUM_Bullet.Null;
	public ICharacter NewCharacter = null;
	public Vector3 SpawnPosition;
	public int AttrID;
	public string AssetName;
	public string IconSpriteName;
}
public abstract class ICharacterBuilder 
{
	//设定建立参数
	public abstract void SetBuildParam(ICharacterBuildParam theParam);
	//载入Asset中的角色模型
	public abstract void LoadAsset(int GameObjectID);
	//加入武器
	public abstract void AddBullet();
	// 加入AI
	public abstract void AddAI();
	// 设定角色能力
	public abstract void SetCharacterAttr();
	// 加入管理器
	public abstract void AddCharacterSystem(TowerDefenceGame TowerGame);
}
