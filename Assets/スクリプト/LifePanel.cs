using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifePanel : MonoBehaviour
{
    [SerializeField] GameObject[] icon;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void UpdateLife (int life)
    {
        for(int i = 0; i < icon.Length; i++)
        {
            if(i < life)
            {
                icon[i].SetActive(true);
            }
            else
            {
                icon[i].SetActive(false);
            }
        }
    }
}
