using UnityEngine;

public class Player1Controller : MonoBehaviour
{
    public GameObject[] targetObject;
    void Update()
    {
        // D-Pad ���̓���
        if (Input.GetAxis("DpadHorizontal") < 0)
        {
            targetObject[0].SetActive(true);
            Debug.Log("D-Pad ����������܂���");
            // ���{�^���������ꂽ�Ƃ��̏����������ɋL�q
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
            // �E�{�^���������ꂽ�Ƃ��̏����������ɋL�q
        }
        else
        {
            targetObject[1].SetActive(false);
        }
    }
}
