using UnityEngine;

public class PlayerTouchItem : MonoBehaviour
{
    // �v���C���[�I�u�W�F�N�g�ւ̎Q��
    public GameObject player; // �v���C���[�I�u�W�F�N�g���C���X�y�N�^�Őݒ�

    private GameObject currentItem;
    private GameObject itemInRange;

    void Update()
    {
        if (currentItem != null) // �A�C�e���������Ă���ꍇ
        {
            // �v���C���[�̓��̏�ɃA�C�e����Ǐ]������
            currentItem.transform.position = player.transform.position + new Vector3(0, 1, 0);  // Y + 1
        }

        // �v���C���[1�̑���
        if (CompareTag("Player1"))
        {
            if (Input.GetButtonDown("B_Button_1P")) // B�{�^���Ŏ���/����
            {
                Debug.Log("Player1: B�{�^����������Ă��܂�");
                if (currentItem == null)
                {
                    TryPickUpItem(); // �A�C�e��������
                }
                else
                {
                    DropItem(); // �A�C�e���𗣂�
                }
            }
        }

        // �v���C���[2�̑���
        if (CompareTag("Player2"))
        {
            if (Input.GetButtonDown("B_Button_2P")) // B�{�^���Ŏ���/����
            {
                Debug.Log("Player2: B�{�^����������Ă��܂�");
                if (currentItem == null)
                {
                    TryPickUpItem(); // �A�C�e��������
                }
                else
                {
                    DropItem(); // �A�C�e���𗣂�
                }
            }
        }
    }

    // �A�C�e�����E������
    void TryPickUpItem()
    {
        if (itemInRange != null)  // �A�C�e�����͈͓��ɂ���ꍇ
        {
            currentItem = itemInRange;  // �A�C�e��������
            Debug.Log("�A�C�e���������܂���: " + currentItem.name);

            // �A�C�e���̈ʒu���v���C���[�̓��̏�ɐݒ�i�v���C���[�I�u�W�F�N�g����j
            currentItem.transform.position = player.transform.position + new Vector3(0, 1, 0);  // Y + 1
            Debug.Log("�A�C�e���̈ʒu: " + currentItem.transform.position);

            // Rigidbody2D��isKinematic��L���ɂ��ĕ����V�~�����[�V�����𖳌���
            currentItem.GetComponent<Rigidbody2D>().isKinematic = true;

            // BoxCollider2D��Is Trigger��L���ɂ��āA�����I�Փ˂𖳎�
            currentItem.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    void DropItem()
    {
        if (currentItem != null)  // �A�C�e���������Ă���ꍇ
        {
            // �h���b�v��̈ʒu���v�Z�i�v���C���[�̉E���j
            Vector3 dropPosition = new Vector3(player.transform.position.x + 1, player.transform.position.y, player.transform.position.z);

            // �A�C�e���͈̔́iBoxCollider2D�̑傫�����g���j
            BoxCollider2D itemCollider = currentItem.GetComponent<BoxCollider2D>();

            // �A�C�e���̃h���b�v�ʒu�ɑ΂��āA�d�Ȃ��Ă�����̂����邩���`�F�b�N
            Collider2D[] colliders = Physics2D.OverlapBoxAll(dropPosition, itemCollider.size, 0f); // 0f�ŉ�]�𖳎�

            bool isWallDetected = false;

            // �d�Ȃ��Ă���R���C�_�[�̒���Wall�^�O�����邩���`�F�b�N
            foreach (var collider in colliders)
            {
                if (collider.CompareTag("Wall"))
                {
                    isWallDetected = true;
                    break;  // Wall��������΁A���[�v���I��
                }
            }

            if (isWallDetected)
            {
                // �ǂ�����ꍇ�A�A�C�e�����v���C���[�̈ʒu�ɖ߂�
                dropPosition = player.transform.position;
                Debug.Log("�E���ɕǂ����邽�߁A�A�C�e�����v���C���[�̈ʒu�ɖ߂��܂���");
            }

            // �A�C�e�����h���b�v
            currentItem.transform.position = dropPosition;
            Debug.Log("�A�C�e�����h���b�v���܂���: " + currentItem.name);

            // �A�C�e����Rigidbody2D��isKinematic�𖳌��ɂ��ĕ����V�~�����[�V������L����
            Rigidbody2D rb = currentItem.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.isKinematic = true; // �A�C�e�����h���b�v����ۂɕ����V�~�����[�V������L����
            }

            // �A�C�e���������Ă��Ȃ���Ԃɂ���
            currentItem = null;
        }
    }

    // �A�C�e�����͈͓��ɓ���ƌĂяo�����i�͈̓`�F�b�N�p�j
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            itemInRange = other.gameObject;  // �͈͓��̃A�C�e�����L�^
            Debug.Log("�A�C�e�����͈͂ɓ���܂���: " + other.name);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            itemInRange = null;  // �͈͊O�ɏo���A�C�e�����L�^
            Debug.Log("�A�C�e�����͈͂���o�܂���: " + other.name);
        }
    }
}
