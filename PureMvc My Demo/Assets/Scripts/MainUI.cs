using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class MainUI : MonoBehaviour
{
    public BallView ballView = null;
    public StartView StartView = null;
    public ScoreView ScoreView = null;
    public Transform backGround;
    public Button btn;
    public Text Maxscore;
    void Start()
    {
        ApplicationFacade facade = new ApplicationFacade();
        //不应该在这里 应该在我的某个command命令里
        Maxscore.text = File.ReadAllText("Assets/MaxScore.txt");
        facade.StartUp(this);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
