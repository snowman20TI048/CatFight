using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private GameObject DrumstickPrefab;

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
    }

    // Update is called once per frame
    void Update()
    {
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
        }
    }
}
