using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    public GameObject[] targetObject;
    void Update()
    {
        // D-Pad 左の入力
        if (Input.GetAxis("DpadHorizontal") < 0)
        {
            targetObject[0].SetActive(true);
            Debug.Log("D-Pad 左が押されました");
            // 左ボタンが押されたときの処理をここに記述
        }
        else
        {
            targetObject[0].SetActive(false);
        }

        // D-Pad 右の入力
        if (Input.GetAxis("DpadHorizontal") > 0)
        {
            targetObject[1].SetActive(true);
            Debug.Log("D-Pad 右が押されました");
            // 右ボタンが押されたときの処理をここに記述
        }
        else
        {
            targetObject[1].SetActive(false);
        }
    }
}
