using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NejikoController : MonoBehaviour {

    CharacterController controller;
    Animator animator;

    Vector3 moveDirection = Vector3.zero;

    [SerializeField] float gravity;
    [SerializeField] float speedZ;
    [SerializeField] float speedJamp;
	// Use this for initialization
	void Start () {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if(controller.isGrounded)
        {
            //  地面にいるときの処理
            if(Input.GetAxis("Vertical")>0.0f)
            {
                moveDirection.z = Input.GetAxis("Vertical") * speedZ;
            }
            else
            {
                moveDirection.z = 0;
            }
            // 方向転換
            transform.Rotate(0, Input.GetAxis("Horizontal") * 3, 0);

            // ジャンプの処理
            if(Input.GetButton("Jump"))
            {
                moveDirection.y = speedJamp;
                animator.SetTrigger("jamp");
            }
        }
        moveDirection.y -= gravity * Time.deltaTime;

        // 移動実行処理
        Vector3 globalDirection = transform.TransformDirection(moveDirection);
        controller.Move(globalDirection * Time.deltaTime);

        // 移動後設置している場合のY方向のリセット
        if(controller.isGrounded)
        {
            moveDirection.y = 0;
        }

        // 速度が０以上であれば、入っているフラグが立つ
        animator.SetBool("run", moveDirection.z > 0.0f);
	}
}
