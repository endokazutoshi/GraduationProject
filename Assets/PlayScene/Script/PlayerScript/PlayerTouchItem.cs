using UnityEngine;

public class PlayerTouchItem : MonoBehaviour
{
    // �v���C���[�I�u�W�F�N�g�ւ̎Q��
    public GameObject player;

    private GameObject currentItem;
    private GameObject itemInRange;
    private bool isInBoxRange = false;  // Box���ɃA�C�e�������邩�ǂ����̔���

    // �������A�C�e����Object�^�̔z��ɂ���
    public Object[] validItems; // �{�b�N�X�ɓ������A�C�e����Object�z��

    // �����A�C�e���̐ݒ�
    public GameObject correctItem;  // �����̃A�C�e����ݒ肷��

    void Update()
    {
        if (currentItem != null)
        {
            currentItem.transform.position = player.transform.position + new Vector3(0, 1, 0);
        }

        if (CompareTag("Player1"))
        {
            if (Input.GetButtonDown("B_Button_1P"))
            {
                Debug.Log("Player1: B�{�^����������Ă��܂�");
                if (currentItem == null)
                {
                    TryPickUpItem();
                }
                else
                {
                    if (isInBoxRange)
                    {
                        PlaceItemInBox();
                    }
                    else
                    {
                        DropItem();
                    }
                }
            }
        }

        if (CompareTag("Player2"))
        {
            if (Input.GetButtonDown("B_Button_2P"))
            {
                Debug.Log("Player2: B�{�^����������Ă��܂�");
                if (currentItem == null)
                {
                    TryPickUpItem();
                }
                else
                {
                    if (isInBoxRange)
                    {
                        PlaceItemInBox();
                    }
                    else
                    {
                        DropItem();
                    }
                }
            }
        }
    }

    // �A�C�e�����E������
    void TryPickUpItem()
    {
        if (itemInRange != null)
        {
            currentItem = itemInRange;
            Debug.Log("�A�C�e���������܂���: " + currentItem.name);

            currentItem.transform.position = player.transform.position + new Vector3(0, 1, 0);
            Debug.Log("�A�C�e���̈ʒu: " + currentItem.transform.position);

            Rigidbody2D rb = currentItem.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.isKinematic = true;
            }

            currentItem.GetComponent<BoxCollider2D>().isTrigger = true;
        }
    }

    // �A�C�e����Box�ɓ���鏈��
    void PlaceItemInBox()
    {
        // �{�b�N�X���ɓ������A�C�e�������`�F�b�N
        if (IsValidItem(currentItem))
        {
            BoxCollider2D boxCollider = itemInRange.GetComponent<BoxCollider2D>();

            if (boxCollider != null)
            {
                currentItem.transform.position = itemInRange.transform.position;
                Debug.Log("�A�C�e����Box���ɔz�u���܂���: " + currentItem.name);

                // �A�C�e�����������ǂ������`�F�b�N
                if (IsCorrectItem(currentItem)) // �����̏ꍇ
                {
                    // �A�C�e�����폜
                    Destroy(currentItem);
                    currentItem = null;
                    // �����������ꍇ�A�w��̃I�u�W�F�N�g���폜
                    RemoveObjectByName("Square (9)");
                    RemoveObjectByName("Square (10)");
                    RemoveObjectByName("Square (25)");
                    RemoveObjectByName("Square (26)");


                    // �A�C�e���̕����������ēx�L����
                    Rigidbody2D rb = currentItem.GetComponent<Rigidbody2D>();
                    if (rb != null)
                    {
                        rb.isKinematic = true;
                    }

          
                    // "Box"�ɃA�C�e������ꂽ��A��Ԃ����Z�b�g
                    isInBoxRange = false;
                }
                else
                {

                    Destroy(currentItem);
                    currentItem = null;
                    Debug.Log("�s�����̃A�C�e����������܂���");
                    // �����łȂ���΁A�A�C�e���͂��̂܂܃{�b�N�X�ɒu������
                    // ���ɍ폜�Ȃǂ̏����͍s��Ȃ�
                }
            }
        }
        else
        {
            Debug.Log("���̃A�C�e���̓{�b�N�X�ɓ�����܂���: " + currentItem.name);
        }
    }

    // �����̃A�C�e�����𔻒肷�郁�\�b�h
    bool IsCorrectItem(GameObject item)
    {
        // �����Ő����̃A�C�e�����ǂ����𔻒�
        return item == correctItem;  // �{�b�N�X�ɓ����ꂽ�A�C�e�������������m�F
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

    // �A�C�e�����͈͓��ɓ���ƌĂяo�����
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            itemInRange = other.gameObject;
            Debug.Log("�A�C�e�����͈͂ɓ���܂���: " + other.name);
        }

        if (other.CompareTag("Box"))
        {
            isInBoxRange = true;
            Debug.Log("Box���ɓ�����");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Item"))
        {
            itemInRange = null;
            Debug.Log("�A�C�e�����͈͂���o�܂���: " + other.name);
        }

        if (other.CompareTag("Box"))
        {
            isInBoxRange = false;
            Debug.Log("Box����o��");
        }
    }

    // �A�C�e�����{�b�N�X�ɓ���邩�ǂ����𔻒�
    bool IsValidItem(GameObject item)
    {
        foreach (Object validItem in validItems)
        {
            if (validItem != null && validItem is GameObject && ((GameObject)validItem).CompareTag(item.tag))
            {
                return true;  // �A�C�e�����L����Object�������Ă���΃{�b�N�X�ɓ������
            }
        }
        return false;  // �L����Object���Ȃ��ꍇ�A�{�b�N�X�ɓ�����Ȃ�
    }

    // ���O�ŃI�u�W�F�N�g���������č폜����
    void RemoveObjectByName(string objectName)
    {
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
