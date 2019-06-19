using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleLoge : MonoBehaviour
{
    // タイトルロゴを軽率に動かしていくスタイル
    Image logo;
    int moveCnt = 0;
    // Start is called before the first frame update
    void Start()
    {
        logo = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        moveCnt++;
        if(moveCnt / 80 % 2 == 0)
        {
            logo.transform.position += new Vector3(0, 0.08f, 0);
        }
        else
        {
            logo.transform.position -= new Vector3(0, 0.08f, 0);
        }
    }
}
