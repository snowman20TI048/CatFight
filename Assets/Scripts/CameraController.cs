using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [Header("�ǐՂ���Q�[���I�u�W�F�N�g")]
    public GameObject targetObj;// targetObj �ϐ��̃Q�[���I�u�W�F�N�g�̈ʒu���L�^����ϐ�

    private Vector3 targetPos;

    [SerializeField, Header("�J�����̉�]���x")]
    private float cameraRotateSpeed = 200f; // �J�����̉�]���x

    [SerializeField, Header("/x�������̉ϔ͈�")]
    private float maxLimit = 30.0f; //x�������̉ϔ͈�

    private float minLimit;



    // Start is called before the first frame update
    void Start()
    {
        // �Ǐ]�Ώ�(targetObj)�̈ʒu�����擾
        targetPos = targetObj.transform.position;

        // X ���̉��͈͂̐ݒ�
        minLimit = 360 - maxLimit;
    }

    // Update is called once per frame
    void Update()
    {
        // �Ǐ]�Ώۂ�����ꍇ
        if (targetObj != null)
        {
            // �J�����̈ʒu���A�Ǐ]�Ώۂ̈ʒu - �␳�l(targetPos)�ɂ��āA��苗������ĒǏ]������
            transform.position += targetObj.transform.position - targetPos;

            // �Ǐ]�Ώ�(targetObj)�̈ʒu�����X�V
            targetPos = targetObj.transform.position;
        }

        if (Input.GetMouseButton(1))
        {
            // �J�����̉�]
            RotateCamera();
        }

    }

    /// <summary>
    /// targetObj �����ɂ����J�����̌��]��]
    /// </summary>
    private void RotateCamera()
    {
        // �}�E�X�̓��͒l���擾
        float x = Input.GetAxis("Mouse X");
        float z = Input.GetAxis("Mouse Y");

        // �J������Ǐ]�Ώۂ̎��͂����]��]������
        transform.RotateAround(targetObj.transform.position, Vector3.up, x * Time.deltaTime * cameraRotateSpeed);

        //�J�����̉�]���̏����l���Z�b�g
        var localAngle = transform.localEulerAngles;

        // X ���̉�]�����Z�b�g
        localAngle.x += z;


        // X �����ғ��͈͓��Ɏ��܂�悤�ɐ���
        if (localAngle.x > maxLimit && localAngle.x < 180) {
            localAngle.x = maxLimit;
        }

        if (localAngle.x < minLimit && localAngle.x > 180){
            localAngle.x = maxLimit;
        }

        // �J�����̉�]
        transform.localEulerAngles = localAngle;

    }
}
