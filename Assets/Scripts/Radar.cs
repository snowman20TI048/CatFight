using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    private bool isChild = false;

    // 「OnTriggerStay」はトリガーが他のコライダーに触れている間中実行されるメソッド（ポイント）
    private void OnTriggerStay(Collider other)
    {
        // もしも他のオブジェクトに「Player」というTag（タグ）が付いていたならば（条件）
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                if (isChild == false)
                {
                    Debug.Log("a");
                    this.gameObject.GetComponent<Rigidbody>().useGravity = false;
                    this.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
                    this.gameObject.transform.parent = other.gameObject.transform;
                    this.gameObject.transform.localPosition = new Vector3(0f, 0.07f, 0f);
                    this.gameObject.GetComponent<SphereCollider>().enabled = false;
                    isChild = true;
                }

           
            }

        }
    }

    private void Update()
    {
        if(isChild == false)
        {
            return;
        }
        if(Input.GetKeyDown(KeyCode.C) && isChild == true)
        {
            Debug.Log("b");
            isChild = false;
            this.gameObject.transform.localPosition = new Vector3(0f, 0.07f, 0.07f);
            this.gameObject.transform.parent = null;
            this.gameObject.GetComponent<CapsuleCollider>().enabled = true;
            this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
            this.gameObject.GetComponent<Rigidbody>().useGravity = true;
            this.gameObject.GetComponent<SphereCollider>().enabled = true;
        }
    }

}
