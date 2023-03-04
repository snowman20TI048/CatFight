using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    private Rigidbody rb;
    private CapsuleCollider capsuleCol;
    private SphereCollider sphereCol;
    private Vector3 headPos = new(0f, 0.07f, 0f);

    public enum BALL_STATE_TYPE
    {
        PLAYER_CATCH,       //敵が肉を持っている状態
        ENEMYY_CATCH,      //自分が肉を持っている状態
        EMPTY,             //誰も肉を持っていない状態
    }

    public BALL_STATE_TYPE ball_state_type;

    private void Start()
    {
        TryGetComponent(out rb);
        TryGetComponent(out capsuleCol);
        TryGetComponent(out sphereCol);

        ball_state_type = BALL_STATE_TYPE.EMPTY;
    }

    // 「OnTriggerStay」はトリガーが他のコライダーに触れている間中実行されるメソッド（ポイント）
    private void OnTriggerStay(Collider other)
    {
        /* if (ball_state_type == BALL_STATE_TYPE.ENEMYY_CATCH)
         {
             return;
         }
        */

        if (ball_state_type != BALL_STATE_TYPE.EMPTY)
        {
            return;
        }
        
        if (!other.TryGetComponent(out PlayerController _))
        {
            return;
        }

        if (Input.GetKeyDown(KeyCode.X))
        {
            rb.useGravity = false;
            rb.isKinematic = true;
            capsuleCol.enabled = false;
            
            transform.parent = other.gameObject.transform;
            transform.localPosition = headPos;
            
            sphereCol.enabled = false;
            
            ball_state_type = BALL_STATE_TYPE.PLAYER_CATCH;
        }
        
        /*
        // もしも他のオブジェクトに「Player」というTag（タグ）が付いていたならば（条件）
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                if (ball_state_type == BALL_STATE_TYPE.EMPTY)
                {
                    Debug.Log("a");
                    this.gameObject.GetComponent<Rigidbody>().useGravity = false;
                    this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
                    this.gameObject.transform.parent = other.gameObject.transform;
                    this.gameObject.transform.localPosition = new Vector3(0f, 0.07f, 0f);
                    this.gameObject.GetComponent<SphereCollider>().enabled = false;
                    ball_state_type = BALL_STATE_TYPE.PLAYER_CATCH;
                }

           
            }

        }
        */

       
    }

    private void Update()
    {
        if(ball_state_type == BALL_STATE_TYPE.EMPTY)
        {
            return;
        }
        if(Input.GetKeyDown(KeyCode.C) && ball_state_type == BALL_STATE_TYPE.PLAYER_CATCH )
        {
            Drop();
        }
    }

    public void Drop()
    {
        ball_state_type = BALL_STATE_TYPE.EMPTY;
        transform.parent = null;
        
        capsuleCol.enabled = true;
        rb.isKinematic = false;
        rb.useGravity = true;
        sphereCol.enabled = true;
    }

    public void EnemyGet(GameObject enemy)
    {
       

            if (ball_state_type != BALL_STATE_TYPE.EMPTY)
            {
                return;
            }

            rb.useGravity = false;
            rb.isKinematic = true;
            capsuleCol.enabled = false;
            transform.parent = enemy.transform;
            transform.localPosition = headPos;
            sphereCol.enabled = false;
            ball_state_type = BALL_STATE_TYPE.ENEMYY_CATCH;

            /* 
             * if (ball_state_type == BALL_STATE_TYPE.EMPTY)
             {
            this.gameObject.GetComponent<Rigidbody>().useGravity = false;
            this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
            this.gameObject.transform.parent = enemy.transform;
            this.gameObject.transform.localPosition = new Vector3(0f, 0.07f, 0f);
            this.gameObject.GetComponent<SphereCollider>().enabled = false;
            ball_state_type = BALL_STATE_TYPE.ENEMYY_CATCH;
            }
            */


        
    }

}
