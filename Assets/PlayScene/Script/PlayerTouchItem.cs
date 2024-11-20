using UnityEngine;

public class PlayerTouchItem : MonoBehaviour
{
    // �v���C���[�I�u�W�F�N�g�ւ̎Q��
    public GameObject player; // �v���C���[�I�u�W�F�N�g���C���X�y�N�^�Őݒ�

    private GameObject currentItem;
    private GameObject itemInRange;
    private bool isInBoxRange = false;  // Box���ɃA�C�e�������邩�ǂ����̔���

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
                    if (isInBoxRange)  // Box���ɓ����Ă���ꍇ�́A�A�C�e����Box���ɒu��
                    {
                        PlaceItemInBox();  // �A�C�e����Box���ɒu������
                    }
                    else
                    {
                        DropItem(); // �A�C�e���𗣂�
                    }
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
                    if (isInBoxRange)  // Box���ɓ����Ă���ꍇ�́A�A�C�e����Box���ɒu��
                    {
                        PlaceItemInBox();  // �A�C�e����Box���ɒu������
                    }
                    else
                    {
                        DropItem(); // �A�C�e���𗣂�
                    }
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

            // �A�C�e���̕��������𖳌����i�A�C�e�������j
            Rigidbody2D rb = currentItem.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.isKinematic = true; // �����V�~�����[�V�����𖳌���
            }

            // BoxCollider2D��Is Trigger��L���ɂ��āA�����I�Փ˂𖳎�
            currentItem.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    // �A�C�e����Box�ɓ���鏈��
    void PlaceItemInBox()
    {
        // Box�͈͓̔��ɃA�C�e����z�u
        BoxCollider2D boxCollider = itemInRange.GetComponent<BoxCollider2D>();  // BoxCollider2D���擾

        if (boxCollider != null)
        {
            // Box���ɃA�C�e����z�u�iBox�̒��S�ɃA�C�e����z�u�j
            currentItem.transform.position = itemInRange.transform.position;
            Debug.Log("�A�C�e����Box���ɔz�u���܂���: " + currentItem.name);

            if (currentItem != null)
            {
                Destroy(currentItem);  // �A�C�e�����V�[������폜
                currentItem = null;  // �A�C�e���������Ă��Ȃ���Ԃɖ߂�
                Debug.Log("�A�C�e�����폜���܂���");
            }

            // "ItemBox"�Ƃ������O�̃I�u�W�F�N�g���폜����
            RemoveObjectByName("Square (9)");
            // "ItemBox"�Ƃ������O�̃I�u�W�F�N�g���폜����
            RemoveObjectByName("Square (10)");
            // "ItemBox"�Ƃ������O�̃I�u�W�F�N�g���폜����
            RemoveObjectByName("Square (25)");
            // "ItemBox"�Ƃ������O�̃I�u�W�F�N�g���폜����
            RemoveObjectByName("Square (26)");

            // �A�C�e���̕����������ēx�L����
            Rigidbody2D rb = currentItem.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.isKinematic = true; // �����V�~�����[�V������L����
            }

            // �A�C�e���������Ă��Ȃ���Ԃɂ���
            currentItem = null;
            isInBoxRange = false;  // Box������o����Ԃɂ���
        }
    }

    // �A�C�e�����h���b�v���鏈��
    void DropItem()
    {
        if (currentItem != null)  // �A�C�e���������Ă���ꍇ
        {
            // �h���b�v��̈ʒu���v�Z�i�v���C���[�̉E���j
            Vector3 dropPosition = new Vector3(player.transform.position.x + 1, player.transform.position.y, player.transform.position.z);

            // �A�C�e�����h���b�v
            currentItem.transform.position = dropPosition;
            Debug.Log("�A�C�e�����h���b�v���܂���: " + currentItem.name);

            // �A�C�e���̕����������ēx�L����
            Rigidbody2D rb = currentItem.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.isKinematic = true; // �����V�~�����[�V������L����
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

        if (other.CompareTag("Box"))
        {
            isInBoxRange = true;  // �A�C�e����Box�͈͓̔��ɓ��������Ƃ��L�^4
                                  // �A�C�e���̕����������ēx�L����

            Debug.Log("Box���ɓ�����");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            itemInRange = null;  // �͈͊O�ɏo���A�C�e�����L�^
            Debug.Log("�A�C�e�����͈͂���o�܂���: " + other.name);
        }

        if (other.CompareTag("Box"))
        {
            isInBoxRange = false;  // �A�C�e����Box�͈̔͊O�ɏo�����Ƃ��L�^
            Debug.Log("Box����o��");
        }
    }

    // ���O�ŃI�u�W�F�N�g���������č폜����
    void RemoveObjectByName(string objectName)
    {
        // ���O�ŃI�u�W�F�N�g������
        GameObject objectToDelete = GameObject.Find(objectName);

        if (objectToDelete != null)
        {
            Destroy(objectToDelete);  // �I�u�W�F�N�g���폜
            Debug.Log(objectName + " ���폜���܂���");
        }
        else
        {
            Debug.LogWarning(objectName + " ���V�[�����Ɍ�����܂���ł���");
        }
    }

}
