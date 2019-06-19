using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleController : MonoBehaviour
{
    [SerializeField] Text hightScoreLabel;
    // Start is called before the first frame update
    void Start()
    {
        hightScoreLabel.text = "はいすこあ:" + PlayerPrefs.GetInt("HightScore") + "めーとる";
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnStartButtonClicked()
    {
#pragma warning disable CS0618 // 型またはメンバーが古い形式です
        Application.LoadLevel("main");
#pragma warning restore CS0618 // 型またはメンバーが古い形式です
    }
}
