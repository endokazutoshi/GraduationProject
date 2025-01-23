using UnityEngine;

public class ItemInteractio2 : MonoBehaviour
{
    public Transform holdPosition;  // �v���C���[���A�C�e�������ʒu
    private GameObject heldItem;    // �����Ă���A�C�e��
    public LayerMask itemLayer;     // �A�C�e���̃��C���[�}�X�N
    private BoxCheck2 boxCheck2;
    private bool isHoldingItem = false;  // �A�C�e���������Ă��邩�ǂ����𔻒肷��t���O
    public float itemYOffset = 0.5f; // �A�C�e����Y���ʒu�����p 
    public float dropYOffset = 0.5f;

    void Start()
    {
        boxCheck2 = FindObjectOfType<BoxCheck2>();

        if (boxCheck2 == null)
        {
            Debug.LogError("BoxCheck1 ���V�[�����ɑ��݂��܂���I");
        }
        else
        {
            Debug.Log("BoxCheck1�̓V�[�����ɑ��݂��܂��I");
        }
    }


    void Update()
    {
        // �v���C���[1�̑���
        if (CompareTag("Player1"))
        {
            // B�{�^���ŃA�C�e�������^���Ƃ�
            if (Input.GetButtonDown("B_Button_1P"))
            {
                if (!isHoldingItem)
                {
                    // �A�C�e���������Ă��Ȃ��ꍇ�A�E��������s��
                    TryPickUpItem2();
                }
                else
                {
                    // �A�C�e���������Ă���ꍇ�A�A�C�e���𗎂Ƃ�
                    DropItem2(new Vector3(0, dropYOffset, 0));
                }
            }

            // �A�C�e�����{�b�N�X�ɓ���鑀��iY�{�^���j
            if (Input.GetButtonDown("Y_Button_1P") && isHoldingItem)
            {
                TryPlaceItemInBox2(); 

            }
        }

        // �v���C���[2�̑���
        if (CompareTag("Player2"))
        {
            // B�{�^���ŃA�C�e�������^���Ƃ�
            if (Input.GetButtonDown("B_Button_2P"))
            {
                if (!isHoldingItem)
                {
                    // �A�C�e���������Ă��Ȃ��ꍇ�A�E��������s��
                    TryPickUpItem2();
                }
                else
                {
                    // �A�C�e���������Ă���ꍇ�A�A�C�e���𗎂Ƃ�
                    DropItem2(new Vector3(0, dropYOffset, 0));
                }
            }

            // �A�C�e�����{�b�N�X�ɓ���鑀��iY�{�^���j
            if (Input.GetButtonDown("Y_Button_2P") && isHoldingItem)
            {
                TryPlaceItemInBox2();

            }
        }
    }

    void TryPickUpItem2()
    {
        // �A�C�e�����E������: �v���C���[�̈ʒu�����Raycast�ŃA�C�e�������o
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.right, 1f, itemLayer);
        if (hit.collider != null)
        {
            heldItem = hit.collider.gameObject;
            heldItem.transform.SetParent(holdPosition);
            heldItem.transform.localPosition = new Vector3(0,itemYOffset,0);  // �v���C���[�̎��ʒu�ɌŒ�

            Rigidbody2D rb = heldItem.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.isKinematic = true;  // �A�C�e���̕��������𖳌���
            }

            isHoldingItem = true;  // �A�C�e������������Ԃɂ���
            Debug.Log("�A�C�e���������܂���: " + heldItem.name);
        }
    }

    void TryPlaceItemInBox2()
    {
        // �{�b�N�X�ɃA�C�e����z�u: �v���C���[�̎��ʒu�����
        Collider2D boxCollider = Physics2D.OverlapCircle(holdPosition.position, 1f, LayerMask.GetMask("Box"));
        if (boxCollider != null)
        {
            boxCheck2.CheckItem2(heldItem);  // �A�C�e�����{�b�N�X�ɓ���鏈��
            Destroy(heldItem);  // �A�C�e����j��i�z�u��j
            heldItem = null;
            isHoldingItem = false;  // �A�C�e�������������Ԃɂ���
        }
        else
        {
            Debug.Log("�{�b�N�X���߂��ɂ���܂���");
        }
    }

    void DropItem2(Vector3 dropOffset2)
    {
        // �A�C�e����e�I�u�W�F�N�g����؂藣��
        heldItem.transform.SetParent(null);
        heldItem.transform.position = transform.position + dropOffset2;

        // �A�C�e���̕����������ēx�L����
        Rigidbody2D rb = heldItem.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.isKinematic = true;  // �����������ēx�L����
        }

        // �A�C�e���𗎂Ƃ�����ɏ������O�ɕ\��
        Debug.Log("�A�C�e���𗎂Ƃ��܂���: " + heldItem.name);
        heldItem = null;
        isHoldingItem = false;  // �A�C�e�������������Ԃɂ���
    }
}
