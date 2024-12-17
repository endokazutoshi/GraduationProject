using UnityEngine;

public class InputItem : MonoBehaviour
{
    public GameObject box; // �Ώۂ̃{�b�N�X
    public GameObject playerTouchItem; // PlayerTouchItem�̎Q��

    private PlayerTouchItem playerScript; // PlayerTouchItem�̃X�N���v�g�Q��
    private bool isInBoxRange = false; // �v���C���[���{�b�N�X���ɂ��邩�ǂ���

    void Start()
    {
        // PlayerTouchItem�X�N���v�g���擾
        playerScript = playerTouchItem.GetComponent<PlayerTouchItem>();
    }

    void Update()
    {
        // �v���C���[���{�b�N�X�͈͓��ɂ���ꍇ
        if (isInBoxRange && playerScript != null && playerScript.GetCurrentItem() != null)
        {
            // B�{�^���������ꂽ�Ƃ�
            if (Input.GetButtonDown("Y_Button_1P"))
            {
                Debug.Log("B�{�^����������܂����B");

                // �v���C���[�X�N���v�g���������擾�ł��Ă���ꍇ
                if (playerScript.GetCurrentItem() != null)
                {
                    GameObject currentItem = playerScript.GetCurrentItem();

                    // �A�C�e�����{�b�N�X�ɔz�u
                    PlaceItemInBox(currentItem);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            isInBoxRange = true;
            Debug.Log("�{�b�N�X�͈͓��Ƀv���C���[������܂���");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            isInBoxRange = false;
            Debug.Log("�{�b�N�X�͈͂���v���C���[���o�܂���");
        }
    }

    void PlaceItemInBox(GameObject item)
    {
        // �A�C�e�����{�b�N�X���ɔz�u�i�{�b�N�X�̈ʒu�ɃA�C�e����z�u�j
        item.transform.position = box.transform.position;

        // �A�C�e�����{�b�N�X�ɓ��ꂽ�ۂɏ�������
        Destroy(item);

        // PlayerTouchItem�̎����������Z�b�g
        playerScript.ClearCurrentItem();

        Debug.Log("�A�C�e�����{�b�N�X�ɓ���܂���: " + item.name);
    }
}
