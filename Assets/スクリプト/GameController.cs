using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    [SerializeField] NejikoController nejiko;
    [SerializeField] Text scoreLabel;
    [SerializeField] LifePanel lifePanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // スコア更新
        int score = CalcScore() / 10;
        scoreLabel.text = "すこあ:" + score + "めーとる";

        lifePanel.UpdateLife(nejiko.Life());

        // ネジ子のライフが0になったら
        if(nejiko.Life() <= 0)
        {
            // updateを止める
            enabled = false;

            // ハイスコアの更新
            if(PlayerPrefs.GetInt("HightScore") < score)
            {
                PlayerPrefs.SetInt("HightScore", score);
            }

            // 2秒後に呼び出す
            Invoke("ReturnTitle", 2.0f);
        }
    }

    int CalcScore()
    {
        // ネジ子のスコア取得
        return (int)nejiko.transform.position.z;
    }
    void ReturnTitle()
    {
        // タイトルに遷移
#pragma warning disable CS0618 // 型またはメンバーが古い形式です
        Application.LoadLevel("title");
#pragma warning restore CS0618 // 型またはメンバーが古い形式です
    }
}
