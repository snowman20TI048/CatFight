using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
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
