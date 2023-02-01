using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultController : MonoBehaviour
{

    [SerializeField]
    private Text lblPoint;

    // Start is called before the first frame update
    void Start()
    {
        //�I�u�W�F�N�g�𖼑O�ŒT��
        GameManager gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        lblPoint.text = "�����̃|�C���g�F" +gameManager.PlayerPointCount
        + "\n����̃|�C���g�F" + gameManager.EnemyPointCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            // 1.5�b��ɁuGoToResult()�v���\�b�h�����s����B
            Invoke("GoToTitle", 1.5f);

        }
        
    }

// ���ǉ�
void GoToTitle()
{
    SceneManager.LoadScene("Title");
}

}
