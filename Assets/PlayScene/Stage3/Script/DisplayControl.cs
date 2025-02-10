using UnityEngine;

public class DisplayControl : MonoBehaviour
{
    public GameObject item;  // �\������A�C�e��

    void Start()
    {
        // �f�B�X�v���C1�����݂���ꍇ�ADisplay1�ɃA�C�e����\��
        if (Display.displays.Length > 1)
        {
            // Display1�ɃA�C�e����\��
            Display.displays[0].Activate(); // �f�B�X�v���C1��L����
            item.SetActive(true); // �A�C�e����\��
        }

        // Display2�ɃA�C�e����\�����Ȃ�
        if (Display.displays.Length > 1)
        {
            // Display2�ɃA�C�e����\�����Ȃ�
            Display.displays[1].Activate(); // �f�B�X�v���C2��L����
            item.SetActive(false); // �A�C�e�����\��
        }
    }
}
