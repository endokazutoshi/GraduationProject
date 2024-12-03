using UnityEngine;

public class PlayerTouchItem : MonoBehaviour
{
    public Transform holdPosition; // �v���C���[���A�C�e�������ʒu
    private GameObject currentItem; // �����Ă���A�C�e��

    void Update()
    {
        // �A�C�e��������
        if (Input.GetButtonDown("B_Button_1P") && currentItem == null) // ���{�^��
        {
            Collider2D item = Physics2D.OverlapCircle(transform.position, 1.0f, LayerMask.GetMask("Item"));
            if (item != null)
            {
                currentItem = item.gameObject;
                PickUpItem(currentItem);
            }
        }

        // �A�C�e���𗎂Ƃ�
        if (Input.GetButtonDown("Y_Button_1P") && currentItem != null) // ���Ƃ��{�^��
        {
            DropItem();
        }
    }

    void PickUpItem(GameObject item)
    {
        // �A�C�e�����v���C���[�̓��̏�ɔz�u
        item.transform.SetParent(holdPosition);
        item.transform.localPosition = Vector3.zero;

        // �A�C�e���̕��������𖳌���
        Rigidbody2D rb = item.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.isKinematic = true;
        }

        Debug.Log("�A�C�e���������܂���: " + item.name);
    }

    void DropItem()
    {
        // �A�C�e����e�I�u�W�F�N�g����؂藣��
        currentItem.transform.SetParent(null);

        // �A�C�e���̕���������L����
        Rigidbody2D rb = currentItem.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.isKinematic = false;
        }

        Debug.Log("�A�C�e���𗎂Ƃ��܂���: " + currentItem.name);
        currentItem = null;
    }

    public GameObject GetCurrentItem()
    {
        return currentItem;
    }

    public void ClearCurrentItem()
    {
        currentItem = null;
    }
}
