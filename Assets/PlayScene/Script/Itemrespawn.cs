using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Itemrespawn : MonoBehaviour
{
    [SerializeField] GameObject item;  // ��������A�C�e���̃v���n�u
    float time = 0;
    bool isSpawn;

    // �v���C���[1�ƃv���C���[2�̃^�O��
    public string player1Tag = "Player1";
    public string player2Tag = "Player2";
    public float x, y;

    private bool isPlayerInRange = false; // �v���C���[���͈͓��ɂ��邩�ǂ���

    // Start is called before the first frame update
    void Start()
    {
        isSpawn = false;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        // �v���C���[���͈͓��ɂ��邩��B�{�^���������ꂽ�Ƃ��ɃA�C�e�������X�|�[��
        if (isPlayerInRange && Input.GetButtonDown("B_Button_1P"))
        {
            Debug.Log("B�{�^���������ꂽ�I�A�C�e�������X�|�[��");
            // �A�C�e�������܂ł̎��Ԃ����Z�b�g
            time = 3.0f;  // 3�b�Ԃ̃^�C�}�[���X�^�[�g
            isSpawn = true;
        }

        // �v���C���[���͈͓��ɂ��Ȃ��Ă��A��Ƀ^�C�}�[������
        if (time > 0)
        {
            time -= Time.deltaTime;  // ���Ԃ��o�߂��邲�ƂɌ���
            Debug.Log("Remaining Time: " + time);
        }

        // �^�C�}�[��0�ɂȂ�����A�C�e���𐶐�
        if (time <= 0 && isSpawn)
        {
            Itemspawn();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // �v���C���[1�܂��̓v���C���[2���͈͂ɓ������Ƃ��A�͈͓��t���O���Z�b�g
        if (other.CompareTag(player1Tag) || other.CompareTag(player2Tag))
        {
            Debug.Log("�v���C���[���͈͓��ɓ������I");
            isPlayerInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        // �v���C���[���͈͊O�ɏo���Ƃ��A�͈͓��t���O�����Z�b�g
        if (other.CompareTag(player1Tag) || other.CompareTag(player2Tag))
        {
            Debug.Log("�v���C���[���͈͊O�ɏo���I");
            isPlayerInRange = false;
        }
    }

    void Itemspawn()
    {
        // �A�C�e���𐶐��i�w�肳�ꂽ�ʒu�Ő����j
        Instantiate(item, new Vector2(x, y), Quaternion.identity);
        Debug.Log("Itemspawn: �A�C�e�������X�|�[��");
        isSpawn = false;  // �A�C�e��������A�t���O�����Z�b�g
    }
}
