using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CampInfoUI : IUserInterface
{
    public GameObject canvas;
    public Button firstBtn;
    public Button secondBtn;
    public Button thirdBtn;
    bool isSelect=false;
    public Transform closePanel;
    Button BackBtn;
    ENUM_Tower currTower = ENUM_Tower.Null;
    public CampInfoUI(TowerDefenceGame tower):base(tower)
    {
        Initialize();
    }
    public override void Initialize()
    {
        canvas = GameObject.Find("UICanvas");
        Debug.Log(canvas.transform.childCount);
        //if (firstBtn==null)
        {
            firstBtn = canvas.transform.GetChild(0).GetComponent<Button>();
            secondBtn =canvas.transform.GetChild(1).GetComponent<Button>();
            thirdBtn = canvas.transform.GetChild(2).GetComponent<Button>();
            closePanel = canvas.transform.GetChild(3);
            BackBtn = closePanel.GetChild(1).GetComponent<Button>();
            closePanel.gameObject.SetActive(false);
            BackBtn.onClick.AddListener(() =>
            {
                //closePanel.SetActive(false);
                m_TowerGame.Back();
                
            });
            firstBtn.onClick.AddListener(() =>
            {
                isSelect = true;
                currTower = ENUM_Tower.Low;
            });
            secondBtn.onClick.AddListener(() =>
            {
                isSelect = true;
                currTower = ENUM_Tower.Middle;
            });
            thirdBtn.onClick.AddListener(() =>
            {
                isSelect = true;
                currTower = ENUM_Tower.Tall;
            });
        }
        
    }

    public override void Release()
    {
        base.Release();
    }
    public void Defeate()
    {
        closePanel.gameObject.SetActive(true);
    }
    public override void Update()
    {
        if (isSelect)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (EventSystem.current.IsPointerOverGameObject()==false)
                {
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    bool isS = Physics.Raycast(ray, out RaycastHit hit);
                    if (isS)
                    {
                        Debug.Log(hit.transform);
                        if (hit.transform.tag == "map" && hit.transform.GetComponent<MapItem>().IsHave == false)
                        {
                            Debug.Log("创建");
                            m_TowerGame.CreateTower(currTower, hit.transform.position + Vector3.up * 0.5f);
                            hit.transform.GetComponent<MapItem>().IsHave = true;
                        }
                    }
                }
               
            }
        }
    }
}
