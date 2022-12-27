using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    private float inputHorizontal;
    private float inputVertical;
    private Rigidbody rb;

    private Animator animator;

    [SerializeField]
    private float moveSpeed;

    private string jump = "Jump";　　　　　　　　// キー入力用の文字列指定
    [Header("ジャンプ力")]
    public float jumpPower;                      // ジャンプ・浮遊力

    [SerializeField, Header("Linecast用 地面判定レイヤー")]
    private LayerMask groundLayer;
    public bool isGrounded;

    void Start()
    {
        TryGetComponent(out rb);
        TryGetComponent(out animator);
    }

    void Update()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");

        // 地面接地  Physics2D.Linecastメソッドを実行して、Ground Layerとキャラのコライダーとが接地している距離かどうかを確認し、接地しているなら true、接地していないなら false を戻す
        isGrounded = Physics.Linecast(transform.position + transform.up * 0.4f, transform.position - transform.up * 0.9f, groundLayer);

        // Sceneビューに Physics2D.LinecastメソッドのLineを表示する
        Debug.DrawLine(transform.position + transform.up * 0.4f, transform.position - transform.up * 0.9f, Color.red, 1.0f);
        // ジャンプ
        if (Input.GetButtonDown(jump) && isGrounded == true)
        {    // InputManager の Jump の項目に登録されているキー入力を判定する
            Jump();

        }
    }

    // 前進・後退のメソッド
    void FixedUpdate()
    {
        // カメラの方向から、X-Z平面の単位ベクトルを取得
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1, 0, 1)).normalized;

        // 方向キーの入力値とカメラの向きから、移動方向を決定
        Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;

        // 移動方向にスピードを掛ける。ジャンプや落下がある場合は、別途Y軸方向の速度ベクトルを足す
        rb.velocity = moveSpeed * moveForward + new Vector3(0, rb.velocity.y, 0);

        // キー入力により移動方向が決まっている場合には、キャラクターの向きを進行方向に合わせる
        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
    }
    /// <summary>
    /// ジャンプと空中浮遊
    /// </summary>
    private void Jump()
    {
        animator.SetTrigger("Jump");
        // キャラの位置を上方向へ移動させる(ジャンプ・浮遊)
        rb.AddForce(transform.up * jumpPower);

    }


}