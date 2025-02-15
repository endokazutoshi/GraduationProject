using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    public GameObject[] targetObject;
    private SceneManagerController sceneManagerController;

    void Start()
    {
        sceneManagerController = FindObjectOfType<SceneManagerController>();
    }

    void Update()
    {
        if (sceneManagerController != null && sceneManagerController.IsInputDisabled()) return; // 入力を無効化

        // D-Pad 左の入力
        if (Input.GetAxis("DpadHorizontal") < 0)
        {
            targetObject[0].SetActive(true);
            Debug.Log("D-Pad 左が押されました");
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
        }
        else
        {
            targetObject[1].SetActive(false);
        }
    }
}
