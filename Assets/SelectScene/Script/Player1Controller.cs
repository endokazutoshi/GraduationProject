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
        if (sceneManagerController != null && sceneManagerController.IsInputDisabled()) return; // ���͂𖳌���

        // D-Pad ���̓���
        if (Input.GetAxis("DpadHorizontal") < 0)
        {
            targetObject[0].SetActive(true);
            Debug.Log("D-Pad ����������܂���");
        }
        else
        {
            targetObject[0].SetActive(false);
        }

        // D-Pad �E�̓���
        if (Input.GetAxis("DpadHorizontal") > 0)
        {
            targetObject[1].SetActive(true);
            Debug.Log("D-Pad �E��������܂���");
        }
        else
        {
            targetObject[1].SetActive(false);
        }
    }
}
