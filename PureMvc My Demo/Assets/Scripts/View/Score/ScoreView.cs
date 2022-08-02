using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView : MonoBehaviour
{
    public Text score;
    private Text Maxscore;
    // Start is called before the first frame update
    private void Awake()
    {
        score = transform.Find("Score").GetComponent<Text>();
        Maxscore = transform.Find("MaxScore").GetComponent<Text>();
    }
    public void AddScore(ScoreItem item)
    {
        score.text = item.score.ToString();
    }
    public void RefreshMaxScore(ScoreItem score)
    {
        Maxscore.text = score.score.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
