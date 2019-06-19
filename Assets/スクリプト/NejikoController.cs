using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NejikoController : MonoBehaviour {

    const int MinLane = -2;
    const int MaxLane = 2;
    const float LaneWidth = 1;
    const int DefaultLife = 3;
    const float StunDuration = 0.5f;

    string animName;
    public static string getAnimName;

    CharacterController controller;
    Animator animator;

    Vector3 moveDirection = Vector3.zero;
    int targetLane;
    [SerializeField] int life = DefaultLife;
    float recoverTime = 0.0f;

    [SerializeField] float gravity;
    [SerializeField] float speedZ;
    [SerializeField] float speedX;
    [SerializeField] float speedJamp;
    [SerializeField] float accelerationZ;

    [SerializeField] GameObject effectPrefab;
    [SerializeField] Vector3 effectRotation;
	// Use this for initialization

    public int Life()
    {
        return life;
    }

    public bool IsStun()
    {
        return recoverTime > 0.0f || life <= 0;
    }
	void Start () {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        animName = GetComponent<Animator>().name;
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        // デバッグ用
        if (Input.GetKeyDown("left"))
        {
            MoveToLeft();
        }
        if (Input.GetKeyDown("right"))
        {
            MoveToRight();
        }
        if (Input.GetKeyDown("space"))
        {
            Jamp();
        }

        if (IsStun())
        {
            // ネジ子の動きを止める
            moveDirection.x = 0;
            moveDirection.z = 0;
            recoverTime -= Time.deltaTime;
        }
        else
        {
            // 常に前進させる
            float acceleratedZ = moveDirection.z + (accelerationZ * Time.deltaTime);
            moveDirection.z = Mathf.Clamp(acceleratedZ, 0, speedZ);

            // Xは目標の位置までの差分の割合で計算する
            float ratioX = (targetLane * LaneWidth - transform.position.x) - LaneWidth;
            moveDirection.x = ratioX * speedX;

            // 重力分の力を追加
            moveDirection.y -= gravity * Time.deltaTime;
        }
        // 移動実行処理
        Vector3 globalDirection = transform.TransformDirection(moveDirection);
        controller.Move(globalDirection * Time.deltaTime);

        // 移動後設置している場合のY方向のリセット
        if(controller.isGrounded)
        {
            moveDirection.y = 0;
        }

        // 速度が０以上であれば、走っているフラグが立つ
        animator.SetBool("run", moveDirection.z > 0.0f);
        getAnimName = animName;
	}
    public void MoveToLeft()
    {
        if(controller.isGrounded && targetLane>MinLane)
        {
            targetLane--;
        }
    }
    public void MoveToRight()
    {
        if(controller.isGrounded && targetLane<MaxLane)
        {
            targetLane++;
        }
    }
    public void Jamp()
    {
        if(controller.isGrounded)
        {
            moveDirection.y = speedJamp;
            animator.SetTrigger("jump");
        }
    }
    // 当たった時
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if(IsStun())
        {
            return;
        }
        if(hit.gameObject.tag == "Robo")
        {
            life--;
            recoverTime = StunDuration;

            // ダメージのアニメーション
            animator.SetTrigger("damage");

            // 当たったオブジェクトの削除
            Destroy(hit.gameObject);

            if (effectPrefab != null)
            {
                // 当たった場所にパーティクルの生成
                Instantiate(effectPrefab, hit.transform.position, Quaternion.Euler(effectRotation));
            }
        }
    }
}
