using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private float inputHorizontal;
    private float inputVertical;
    private Rigidbody rb;

    [SerializeField]
    private float moveSpeed;

    private string jump = "Jump";　　　　　　　　// キー入力用の文字列指定
    [Header("ジャンプ力")]
    public float jumpPower;                      // ジャンプ・浮遊力



    void Start()
    {
        TryGetComponent(out rb);
    }

    void Update()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");
        // ジャンプ
        if (Input.GetButtonDown(jump))
        {    // InputManager の Jump の項目に登録されているキー入力を判定する
            Jump();

        }
    }

    // 前進・後退のメソッド
    void FixedUpdate()
    {
        // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1,0,1)).normalized;

        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;

        // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す
        rb.velocity = moveSpeed * moveForward + new Vector3(0, rb.velocity.y, 0);

        // キー入力により移動方向が決まっている場合には、キャラクターの向きを進行方向に合わせる
        if(moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
    }
        /// <summary>
        /// ジャンプと空中浮遊
        /// </summary>
        private void Jump()
        {

            // キャラの位置を上方向へ移動させる(ジャンプ・浮遊)
            rb.AddForce(transform.up * jumpPower);

        }


    }