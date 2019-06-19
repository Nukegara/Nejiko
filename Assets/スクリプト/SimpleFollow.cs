using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleFollow : MonoBehaviour {
    // カメラ追従のスクリプト
    Vector3 diff;

    [SerializeField] GameObject target;
    [SerializeField] float followSpeed;
    [SerializeField] string animName;
    Vector3 cameraPos;
    float shakePosX, shakePosY;
	// Use this for initialization
	void Start () {
        diff = target.transform.position - transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        shakePosX = Random.Range(-10f, 10f);
        shakePosY = Random.Range(-10f, 10f);
        animName = NejikoController.getAnimName;
        cameraPos = gameObject.transform.position;
	}
    void LateUpdate()
    {
        if(Input.GetKey(KeyCode.S))
        {
            cameraPos.x += shakePosX;
            cameraPos.y += shakePosY;
        }
        else
        {
            transform.position = Vector3.Lerp(transform.position, target.transform.position - diff, Time.deltaTime * followSpeed);
        }
        
    }
}
