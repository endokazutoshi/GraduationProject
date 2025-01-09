using UnityEngine;
using UnityEngine.SceneManagement;

public class ResultSceneController : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Aボタン（Jump_P1）でセレクトシーンに移動
        if (Input.GetButtonDown("Jump_P1"))
        {
            SceneManager.LoadScene("SelectScene");
            Debug.Log("Aボタンが押されている");
        }

        // Bボタン（B_Button_1P）でタイトルシーンに移動
        if (Input.GetButtonDown("B_Button_1P"))
        {
            SceneManager.LoadScene("TitleScene");
            Debug.Log("Bボタンが押されている");
        }
    }
}
