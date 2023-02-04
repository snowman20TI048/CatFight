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
    private float knockbackPower = 5.0f;

    private Animator animator;

    [SerializeField]
    private float moveSpeed;

    private string jump = "Jump";　　　　　　　　// キー入力用の文字列指定
    [Header("ジャンプ力")]
    public float jumpPower;                      // ジャンプ・浮遊力

    // private string hit = "Hit";　　　　　　　　// キー入力用の文字列指定

    [SerializeField]
    private HitController hitControllerPrefab;

    [SerializeField]
    private Transform hitSpherePosition;

    [SerializeField, Header("Linecast用 地面判定レイヤー")]
    private LayerMask groundLayer;
    public bool isGrounded;

    void Start()
    {
        TryGetComponent(out rb);
        TryGetComponent(out animator);
        print(this.transform.childCount);

        

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

        if (Input.GetKeyDown(KeyCode.Z) && this.transform.childCount < 4)
        {    // InputManager の Jump の項目に登録されているキー入力を判定する
            Hit();

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
            animator.SetFloat("Run", 0.3f);
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
        else 
        {
            animator.SetFloat("Run", 0);
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

    private void Hit()
    {
        Debug.Log("Hit関数の呼び出し");
        animator.SetTrigger("Hit");
        //当たり判定を生み出す
        HitController hitController = Instantiate(hitControllerPrefab, hitSpherePosition.position, Quaternion.identity);
        Destroy(hitController.gameObject, 0.5f);

    }

    public void Attack()
    {
        Debug.Log("Attack");

    }

    private void OnTriggerStay(Collider other)
    {
        // もしも他のオブジェクトに「Enemy」というTag（タグ）が付いていたならば（条件）
        if (other.CompareTag("Enemy"))
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {

                StartCoroutine(Knockback(other));

            }


            

        }
    }

    private IEnumerator Knockback(Collider other)
    {
        //もらってくる引数はクラスの情報で書く！！
        yield return new WaitForSeconds(0.5f);
        Debug.Log("hit");
        // transformを取得
       // Transform othertransform = other.transform;
        Vector3 direction = (other.transform.position - this.transform.position).normalized;

        // 座標を取得
        //Vector3 pos = othertransform.position;
        // pos.x += 0.01f;    // x座標へ0.01加算
        //pos.y += 0.01f;    // y座標へ0.01加算
        // pos.z += 5.0f;    // z座標へ0.01加算

        other.transform.position += direction * knockbackPower;

    }


}