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

    private string jump = "Jump";�@�@�@�@�@�@�@�@// �L�[���͗p�̕�����w��
    [Header("�W�����v��")]
    public float jumpPower;                      // �W�����v�E���V��



    void Start()
    {
        TryGetComponent(out rb);
    }

    void Update()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        inputVertical = Input.GetAxis("Vertical");
        // �W�����v
        if (Input.GetButtonDown(jump))
        {    // InputManager �� Jump �̍��ڂɓo�^����Ă���L�[���͂𔻒肷��
            Jump();

        }
    }

    // �O�i�E��ނ̃��\�b�h
    void FixedUpdate()
    {
        // �J�����̕�������AX-Z���ʂ̒P�ʃx�N�g�����擾
        Vector3 cameraForward = Vector3.Scale(Camera.main.transform.forward, new Vector3(1,0,1)).normalized;

        // �����L�[�̓��͒l�ƃJ�����̌�������A�ړ�����������
        Vector3 moveForward = cameraForward * inputVertical + Camera.main.transform.right * inputHorizontal;

        // �ړ������ɃX�s�[�h���|����B�W�����v�◎��������ꍇ�́A�ʓrY�������̑��x�x�N�g���𑫂�
        rb.velocity = moveSpeed * moveForward + new Vector3(0, rb.velocity.y, 0);

        // �L�[���͂ɂ��ړ����������܂��Ă���ꍇ�ɂ́A�L�����N�^�[�̌�����i�s�����ɍ��킹��
        if(moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
    }
        /// <summary>
        /// �W�����v�Ƌ󒆕��V
        /// </summary>
        private void Jump()
        {

            // �L�����̈ʒu��������ֈړ�������(�W�����v�E���V)
            rb.AddForce(transform.up * jumpPower);

        }


    }