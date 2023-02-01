using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private GameObject DrumstickPrefab;

    [SerializeField]
    private GameObject Enemy;

    [SerializeField]
    private Text PointLabel;


    [SerializeField]
    private Text TimeLabel;

    public int PlayerPointCount;
    public int EnemyPointCount;

    [Header("��������")]
    public float timer;


    // Start is called before the first frame update
    void Start()
    {
        GenerateBall();

        DontDestroyOnLoad(this);  //����ő��̃V�[���Ɉڂ��Ă����̃Q�[���I�u�W�F�N�g�͔j�󂳂�Ȃ��B
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0) { return; }  //���Ԃ��I�������A�����ŏ������~�߂�B�]���ȏ��������Ȃ����ăQ�[�����y�����邽�߁B
        CountDown();
    }

    public void AddPlayerPointCount()
    {
        PlayerPointCount++;
        PointLabel.text = "�����̃|�C���g�F" + PlayerPointCount
         + "\n����̃|�C���g�F" + EnemyPointCount;
        GenerateBall();
    }

    public void AddEnemyPointCount()
    {
        EnemyPointCount++;
        PointLabel.text = "�����̃|�C���g�F" + PlayerPointCount
         + "\n����̃|�C���g�F" + EnemyPointCount;
        GenerateBall();
    }

    private void GenerateBall()
    {
       GameObject drumstick = Instantiate(DrumstickPrefab, new Vector3(0.0f, 5.0f, 0.0f), Quaternion.identity);
        drumstick.GetComponent<BallController>().SetUpBall(this);
        Enemy.GetComponent<ChaseEnemy>().target = drumstick;
    }

    private void CountDown()
    {
        //���Ԃ��J�E���g�_�E������
        timer -= Time.deltaTime;

        //���Ԃ�\������
        TimeLabel.text  = timer.ToString("f1") + "�b";

        //countdown��0�ȉ��ɂȂ����Ƃ�
        if (timer <= 0)
        {
            TimeLabel.text = "0�b";
            // ���ǉ�
            // 1.5�b��ɁuGoToResult()�v���\�b�h�����s����B
            Invoke("GoToResult", 1.5f);
        }
    }

    // ���ǉ�
    void GoToResult()
    {
        SceneManager.LoadScene("Result");
    }

}
