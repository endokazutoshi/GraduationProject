using UnityEngine;

public class StagenotSelect : MonoBehaviour
{
    public GameObject[] targetObject;  // �\������摜�I�u�W�F�N�g�i�Ⴆ�΁A1, 2, 3�̉摜�j
    public int currentMapIndex = 2;   // ���ݑI������Ă���摜�̃C���f�b�N�X

    private bool isDpadPressed = false; // D-Pad�������ꂽ���ǂ����̃t���O
    private SceneManagerController sceneManagerController;
    void Start()
    {
        sceneManagerController = FindObjectOfType<SceneManagerController>();
        // ������Ԃōŏ��̃}�b�v�̂ݕ\��
        UpdateMapSelection1();
    }

    void Update()
    {
        if (sceneManagerController != null && sceneManagerController.IsInputDisabled()) return;
        // D-Pad ���̓��́i�O�̉摜�Ɉړ��j
        if (Input.GetAxisRaw("DpadHorizontal") < 0 && !isDpadPressed)
        {
            currentMapIndex--;  // �C���f�b�N�X�����炷
            if (currentMapIndex < 0)
            {
                currentMapIndex = targetObject.Length - 1;  // �z������i�ŏ��ɖ߂�j
            }
            UpdateMapSelection1();
            isDpadPressed = true; // �{�^���������ꂽ���Ƃ��L�^
        }

        // D-Pad �E�̓��́i���̉摜�Ɉړ��j
        if (Input.GetAxisRaw("DpadHorizontal") > 0 && !isDpadPressed)
        {
            currentMapIndex++;  // �C���f�b�N�X�𑝂₷
            if (currentMapIndex >= targetObject.Length)
            {
                currentMapIndex = 0;  // �z������i�Ōォ��ŏ��ɖ߂�j
            }
            UpdateMapSelection1();
            isDpadPressed = true; // �{�^���������ꂽ���Ƃ��L�^
        }

        // ���͂������ꂽ�ꍇ�A���̃t���[���ɍēx���������邽�߂Ƀt���O�����Z�b�g
        if (Input.GetAxisRaw("DpadHorizontal") == 0)
        {
            isDpadPressed = false;
        }
    }

    // ���ݑI������Ă���摜��\�����A���̉摜���\���ɂ���
    private void UpdateMapSelection1()
    {
       // Debug.Log("���݂̃C���f�b�N�X: " + currentMapIndex); // ���݂̃C���f�b�N�X���f�o�b�O�ŕ\��

        // ���ׂẴ}�b�v�I�u�W�F�N�g���\���ɂ���
        for (int i = 0; i < targetObject.Length; i++)
        {
            targetObject[i].SetActive(false);
        }

        // ���ݑI������Ă���C���f�b�N�X�̃}�b�v�I�u�W�F�N�g��\��
        if (currentMapIndex >= 0 && currentMapIndex < targetObject.Length)
        {
            targetObject[currentMapIndex].SetActive(true);
            //Debug.Log("�I�����ꂽ�I�u�W�F�N�g: " + targetObject[currentMapIndex].name); // �\�������I�u�W�F�N�g���m�F
        }
        else
        {
            //Debug.LogWarning("�C���f�b�N�X���͈͊O: " + currentMapIndex); // �͈͊O�̃C���f�b�N�X�ɒ���
        }
    }
}
