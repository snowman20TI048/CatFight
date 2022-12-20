
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private Text PointLabel;

    public int PointCount;

    [SerializeField, Header("Linecast�p �n�ʔ��背�C���[")]
    private LayerMask pointLayer;
    public bool isPointed = false;

    public Radar radarScript;

    // Start is called before the first frame update
    void Start()
    {
        PointLabel.text = "�|�C���g�F" + PointCount;
    }

    // Update is called once per frame
    void Update()
    {
        // �n�ʐڒn  Physics2D.Linecast���\�b�h�����s���āAGround Layer�ƃL�����̃R���C�_�[�Ƃ��ڒn���Ă��鋗�����ǂ������m�F���A�ڒn���Ă���Ȃ� true�A�ڒn���Ă��Ȃ��Ȃ� false ��߂�
        isPointed = Physics.Linecast(transform.position + transform.up * 0.4f, transform.position - transform.up * 0.9f, pointLayer);

        if (isPointed == true && radarScript.isChild == false)
        {
            PointCount++;
            PointLabel.text = "�|�C���g�F" + PointCount;
        }
    }
}
