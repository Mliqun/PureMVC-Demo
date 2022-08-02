using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class StartView : MonoBehaviour
{
    private Button btn;
    private Text text;
    private Text score;

    public Action submit = null;
    bool isMax = false;
    public BallView ballview;
    public GameObject startview;
    public ScoreView scoreView;

    private void Awake()
    {
        ballview = GameObject.Find("Canvas/BallPanel").GetComponent<BallView>();
        scoreView = GameObject.Find("Canvas/ScorePanel").GetComponent<ScoreView>();
        text = transform.Find("GameOver").GetComponent<Text>();
        
        score = transform.Find("Score").GetComponent<Text>();
        btn = transform.Find("StartBtn").GetComponent<Button>();
        btn.onClick.AddListener(() => { CancelStart(); submit(); });
    }
    public void UpStart(ScoreItem score)
    {
        text.gameObject.SetActive(true);
        this.score.gameObject.SetActive(true);
        text.text = "GameOver";
        this.score.text = score.score + "分";
        this.transform.localPosition = new Vector3(0, 0, 0);
        if (score.score>int.Parse( File.ReadAllText("Assets/MaxScore.txt")))
        {
            Debug.Log(score.score);
            File.WriteAllText("Assets/MaxScore.txt", score.score.ToString());
        }
        Time.timeScale = 0;
    }
    
    public void CancelStart()
    {
        btn.gameObject.SetActive(false);
        this.transform.localPosition = new Vector3(0, -800, 0);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
