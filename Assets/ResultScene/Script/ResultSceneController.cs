using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultSceneController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // A�{�^���iJump_P1�j�ŃZ���N�g�V�[���Ɉړ�
        if (Input.GetButtonDown("Jump_P1"))
        {
            SceneManager.LoadScene("SelectScene");
            Debug.Log("A�{�^����������Ă���");
        }

        // B�{�^���iB_Button_1P�j�Ń^�C�g���V�[���Ɉړ�
        if (Input.GetButtonDown("B_Button_1P"))
        {
            SceneManager.LoadScene("TitleScene");
            Debug.Log("B�{�^����������Ă���");
        }
    }
}
