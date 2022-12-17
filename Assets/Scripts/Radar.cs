using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radar : MonoBehaviour
{
    [SerializeField]
    private Transform target;

    // �uOnTriggerStay�v�̓g���K�[�����̃R���C�_�[�ɐG��Ă���Ԓ����s����郁�\�b�h�i�|�C���g�j
    private void OnTriggerStay(Collider other)
    {
        // ���������̃I�u�W�F�N�g�ɁuPlayer�v�Ƃ���Tag�i�^�O�j���t���Ă����Ȃ�΁i�����j
        if (other.CompareTag("Player"))
        {
            if (Input.GetKeyDown(KeyCode.X))
            {
                this.gameObject.GetComponent<Rigidbody>().useGravity = false;
                this.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                this.gameObject.GetComponent<CapsuleCollider>().enabled = false;
                this.gameObject.transform.parent = other.gameObject.transform;
                this.gameObject.transform.localPosition = new Vector3(0f, 0.07f, 0f);
               
            }
        }
    }
}
