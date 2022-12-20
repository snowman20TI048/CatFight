
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private Text PointLabel;

    public int PlayerPointCount;
    public int EnemyPointCount;

    [SerializeField, Header("Linecast�p �����w�n���背�C���[")]
    private LayerMask playerArea;
    [SerializeField, Header("Linecast�p �G�w�n���背�C���[")]
    private LayerMask enemyArea;

    public bool isPlayerArea = false;
    public bool isEnemyArea = false;


    public Radar radarScript;

    // Start is called before the first frame update
    void Start()
    {
        PointLabel.text = "�����̃|�C���g�F" + PlayerPointCount
            + "\n����̃|�C���g�F" + EnemyPointCount;
    }

    // Update is called once per frame
    void Update()
    {
        // �n�ʐڒn  Physics2D.Linecast���\�b�h�����s���āAGround Layer�ƃL�����̃R���C�_�[�Ƃ��ڒn���Ă��鋗�����ǂ������m�F���A�ڒn���Ă���Ȃ� true�A�ڒn���Ă��Ȃ��Ȃ� false ��߂�
        isPlayerArea = Physics.Linecast(transform.position + transform.up * 0.4f, transform.position - transform.up * 0.9f, playerArea);
        isEnemyArea = Physics.Linecast(transform.position + transform.up * 0.4f, transform.position - transform.up * 0.9f, enemyArea);

        if (isPlayerArea == true && radarScript.isChild == false)
        {
            PlayerPointCount++;
            PointLabel.text = "�����̃|�C���g�F" + PlayerPointCount
             + "\n����̃|�C���g�F" + EnemyPointCount;
        }

        if (isEnemyArea == true && radarScript.isChild == false)
        {
            EnemyPointCount++;
            PointLabel.text = "�����̃|�C���g�F" + PlayerPointCount
             + "\n����̃|�C���g�F" + EnemyPointCount;
        }
    }
}
