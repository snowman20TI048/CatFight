
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour
{

   

   
    [SerializeField, Header("Linecast�p �����w�n���背�C���[")]
    private LayerMask playerArea;
    [SerializeField, Header("Linecast�p �G�w�n���背�C���[")]
    private LayerMask enemyArea;

    public bool isPlayerArea = false;
    public bool isEnemyArea = false;


    public Radar radarScript;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // �n�ʐڒn  Physics2D.Linecast���\�b�h�����s���āAGround Layer�ƃL�����̃R���C�_�[�Ƃ��ڒn���Ă��鋗�����ǂ������m�F���A�ڒn���Ă���Ȃ� true�A�ڒn���Ă��Ȃ��Ȃ� false ��߂�
        isPlayerArea = Physics.Linecast(transform.position + transform.up * 0.4f, transform.position - transform.up * 0.9f, playerArea);
        isEnemyArea = Physics.Linecast(transform.position + transform.up * 0.4f, transform.position - transform.up * 0.9f, enemyArea);

        if (isPlayerArea == true && radarScript.isChild == false)
        {
            gameManager.AddEnemyPointCount();
            Destroy(this.gameObject);
        }

        if (isEnemyArea == true && radarScript.isChild == false)
        {
            gameManager.AddPlayerPointCount();           
            Destroy(this.gameObject);
        }
    }

    public void SetUpBall(GameManager gameManager)
    {
        this.gameManager = gameManager;
    }
}
