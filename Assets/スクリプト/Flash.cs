using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Flash : MonoBehaviour
{
    Text text;
    Color color1 = new Color(0, 0, 0, 1);
    Color color2 = new Color(0, 0, 0, 0);

    int flashCnt = 0;
    // 点滅させる
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        flashCnt++;

        if(flashCnt / 30 % 2 == 0)
        {
            text.color = color1;
        }
        else
        {
            text.color = color2;
        }
    }
}
