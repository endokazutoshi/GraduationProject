using UnityEngine;

public class ItemInteraction : MonoBehaviour
{
    public bool hasItem = false; // �A�C�e���������Ă��邩
    private GameObject heldItem; // �����Ă���A�C�e��
    public Transform holdPosition; // �A�C�e�������ʒu�i�Ⴆ�΃v���C���[�̎�̈ʒu�j

    void Update()
    {
        // �A�C�e����������
        if (Input.GetButtonDown("B_Button_1P") && !hasItem)
        {
            RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 1f);
            if (hit.collider != null && hit.collider.CompareTag("Item"))
            {
                heldItem = hit.collider.gameObject;
                PickUpItem(heldItem);
            }
        }
        // �A�C�e�������������
        else if (Input.GetButtonDown("B_Button_1P") && hasItem)
        {
            DropItem();
        }

        // �A�C�e�����{�b�N�X�ɓ���鏈��
        if (hasItem && Input.GetButtonDown("B_Button_1P")) // F�L�[�ŃA�C�e�����{�b�N�X�ɓ����
        {
            PlaceItemInBox();
        }
    }

    // �A�C�e����������
    void PickUpItem(GameObject item)
    {
        item.transform.SetParent(holdPosition);
        item.transform.localPosition = Vector3.zero; // ���ʒu�𒲐�

        Rigidbody2D rb = item.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.isKinematic = true; // �������Z�𖳌��ɂ���
        }

        hasItem = true;
        Debug.Log("�A�C�e���������܂���: " + item.name);
    }

    // �A�C�e�������������
    void DropItem()
    {
        if (heldItem != null)
        {
            heldItem.transform.SetParent(null); // �A�C�e���̐e������

            Rigidbody2D rb = heldItem.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.isKinematic = false; // �������Z��L���ɂ���
            }

            Debug.Log("�A�C�e����������܂���: " + heldItem.name);
            heldItem = null;
            hasItem = false;
        }
    }

    // �A�C�e�����{�b�N�X�ɓ���鏈��
    void PlaceItemInBox()
    {
        if (heldItem != null)
        {
            // �A�C�e�����{�b�N�X�̈ʒu�Ɉړ�
            heldItem.transform.position = transform.position;

            // �A�C�e�����{�b�N�X�ɓ����
            Debug.Log("�A�C�e�����{�b�N�X�ɓ���܂���: " + heldItem.name);

            // �{�b�N�X�̐��딻����Ăяo��
            BoxCheck boxCheck = FindObjectOfType<BoxCheck>(); // �V�[������BoxCheck�X�N���v�g��T��
            if (boxCheck != null)
            {
                boxCheck.CheckItem(heldItem); // �A�C�e�����{�b�N�X�ɓ����ꂽ�ۂɐ��딻����s��
            }

            // �A�C�e��������
            Destroy(heldItem);

            // �A�C�e���������
            DropItem();
        }
    }
}
