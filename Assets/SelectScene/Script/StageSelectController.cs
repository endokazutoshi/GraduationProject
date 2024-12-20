using UnityEngine;

public class StageSelectController : MonoBehaviour
{
    public GameObject[] targetObject;  // �}�b�v�I�u�W�F�N�g�̔z��
    public Vector3[] objectScales;     // �e�}�b�v�̃X�P�[���ݒ�z��
    private int currentMapIndex = 0;   // ���ݑI������Ă���}�b�v�̃C���f�b�N�X

    void Start()
    {
        // �ŏ��ɍŏ��̃}�b�v��\��
        UpdateMapSelection();
    }

    void Update()
    {
        // D-Pad ���̓��́i�O�̃}�b�v�Ɉړ��j
        if (Input.GetAxis("DpadHorizontal") < 0)  // �������̓��͂����m
        {
            currentMapIndex--;  // �C���f�b�N�X�����炷
            if (currentMapIndex < 0)
            {
                currentMapIndex = targetObject.Length - 1;  // �z������
            }
            UpdateMapSelection();
        }

        // D-Pad �E�̓��́i���̃}�b�v�Ɉړ��j
        if (Input.GetAxis("DpadHorizontal") > 0)  // �E�����̓��͂����m
        {
            currentMapIndex++;  // �C���f�b�N�X�𑝂₷
            if (currentMapIndex >= targetObject.Length)
            {
                currentMapIndex = 0;  // �z������
            }
            UpdateMapSelection();
        }
    }

    // ���ݑI������Ă���}�b�v��\�����A�ʒu�ƃX�P�[����ύX
    private void UpdateMapSelection()
    {
        // ���ׂẴ}�b�v�����݂̈ʒu�Ɉړ����A�X�P�[����ݒ�
        for (int i = 0; i < targetObject.Length; i++)
        {
            // �e�}�b�v�I�u�W�F�N�g�̈ʒu��ݒ�
            Vector3 position = new Vector3(-960.05f, 543.5f, 0);  // �����ʒu

            // D-Pad���Ȃ�ʒu�����炷
            if (i == currentMapIndex && Input.GetAxis("DpadHorizontal") < 0)
            {
                position = new Vector3(-966.95f, 541.95f, 0);
            }
            // D-Pad�E�Ȃ�ʒu�����炷
            else if (i == currentMapIndex && Input.GetAxis("DpadHorizontal") > 0)
            {
                position = new Vector3(966.95f, 541.95f, 0);
            }

            targetObject[i].transform.position = position;

            // �X�P�[���̐ݒ�
            if (i == currentMapIndex)
            {
                // �I������Ă���}�b�v�̃X�P�[����ݒ�
                targetObject[i].transform.localScale = objectScales[i];
            }
        }
    }
}
