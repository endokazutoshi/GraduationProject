using UnityEngine;
using UnityEngine.UI;

public class InputItem: MonoBehaviour
{
    public GameObject item; // �v���C���[�������Ă���A�C�e��
    public Transform boxPosition; // ���̈ʒu
    public Text promptText; // UI�̃e�L�X�g�i���ɓ���郁�b�Z�[�W�j
    public float interactDistance = 2f; // �C���^���N�g�\�ȋ���

    void Start()
    {
        // �ŏ��Ɂu���ɓ����v�̃e�L�X�g���\���ɂ���
        promptText.gameObject.SetActive(false);
    }

    void Update()
    {
        // �v���C���[�����̋߂��ɂ��邩�`�F�b�N
        if (Vector3.Distance(transform.position, boxPosition.position) <= interactDistance)
        {
            // �v���C���[�������Ă���A�C�e�����uItem�v�^�O�������Ă���ꍇ
            if (item != null && item.CompareTag("Item"))
            {
                promptText.gameObject.SetActive(true); // �߂��ɂ���ꍇ�̓��b�Z�[�W��\��
                promptText.text = "���ɓ���� (E)"; // ���b�Z�[�W��\��

                // ����X-1�̈ʒu�Ƀe�L�X�g��z�u
                Vector3 textPosition = new Vector3(boxPosition.position.x - 1f, boxPosition.position.y, boxPosition.position.z);
                promptText.transform.position = textPosition; // �e�L�X�g�̈ʒu��ݒ�

                // �{�^���uE�v���������Ƃ��ɃA�C�e���𔠂ɓ����
                if (Input.GetKeyDown(KeyCode.E))
                {
                    StoreItemInBox();
                }
            }
        }
        else
        {
            promptText.gameObject.SetActive(false); // �����痣���ƃ��b�Z�[�W���\��
        }
    }

    void StoreItemInBox()
    {
        if (item != null && item.CompareTag("Item"))
        {
            // �A�C�e���𔠂ɓ���鏈���i�C���x���g���Ɉړ��A�A�C�e���I�u�W�F�N�g�̍폜���j
            Debug.Log("�A�C�e���𔠂ɓ���܂���");
            Destroy(item); // �A�C�e���𔠂ɓ��ꂽ��A�A�C�e�����폜
            item = null; // �v���C���[�̃C���x���g������A�C�e�����폜
            promptText.gameObject.SetActive(false); // ���b�Z�[�W���\���ɂ���
        }
    }

    // �v���C���[��Box�͈̔͂ɓ������ꍇ�̏���
    private void OnTriggerEnter(Collider other)
    {
        // ���肪"Box"�^�O�������Ă���ꍇ�ɔ���
        if (other.CompareTag("Box"))
        {
            Debug.Log("�v���C���[��Box�͈̔͂ɓ���܂���");
        }
    }

    // �v���C���[��Box�͈̔͂���o���ꍇ�̏���
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Box"))
        {
            Debug.Log("�v���C���[��Box�͈̔͂���o�܂���");
        }
    }
}
