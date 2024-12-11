using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemRespawn : MonoBehaviour
{
    [SerializeField] GameObject item;  // ��������A�C�e���̃v���n�u
<<<<<<< HEAD
    float time = 0;
    bool isSpawn;
=======
    public float respawnTime = 3.0f;  // �A�C�e�������X�|�[������܂ł̎���
    private float timeRemaining;  // �c�莞��
    public float x, y; //���X�|�[���̍��W
>>>>>>> b2ba948a76161793199e120b2c525b8e38316696

    // �v���C���[1�ƃv���C���[2�̃^�O��
    public string player1Tag = "Player1";
    public string player2Tag = "Player2";
<<<<<<< HEAD
    public float x, y;

    private bool isPlayerInRange = false; // �v���C���[���͈͓��ɂ��邩�ǂ���

    // Start is called before the first frame update
    void Start()
    {
        isSpawn = false;
        time = 0;
=======

    private bool isPlayerInItemLayer = false; // �v���C���[��Item���C���[���ɂ��邩�ǂ���
    private bool isRespawnTriggered = false; // ���X�|�[�����g���K�[���ꂽ���ǂ���

    private Vector2 spawnPosition; // �A�C�e���̐����ʒu

    void Start()
    {
        timeRemaining = 0f;
        isRespawnTriggered = false;
>>>>>>> b2ba948a76161793199e120b2c525b8e38316696
    }

    void Update()
    {
<<<<<<< HEAD
        // �v���C���[���͈͓��ɂ��邩��B�{�^���������ꂽ�Ƃ��ɃA�C�e�������X�|�[��
        if (isPlayerInRange && Input.GetButtonDown("B_Button_1P"))
        {
            Debug.Log("B�{�^���������ꂽ�I�A�C�e�������X�|�[��");
            // �A�C�e�������܂ł̎��Ԃ����Z�b�g
            time = 3.0f;  // 3�b�Ԃ̃^�C�}�[���X�^�[�g
            isSpawn = true;
=======
        // �v���C���[1��Item���C���[���ɂ���B�{�^���������ꂽ�ꍇ�Ƀ^�C�}�[���J�n
        if (isPlayerInItemLayer && Input.GetButtonDown("B_Button_1P")&& !isRespawnTriggered)
        {
            Debug.Log("B�{�^���������ꂽ�I�A�C�e�������X�|�[��");
            timeRemaining = respawnTime;  // �^�C�}�[���Z�b�g
            isRespawnTriggered = true;
        }

        // �v���C���[2��Item���C���[���ɂ���B�{�^���������ꂽ�ꍇ�Ƀ^�C�}�[���J�n
        if (isPlayerInItemLayer && Input.GetButtonDown("B_Button_2P") && !isRespawnTriggered)
        {
            Debug.Log("B�{�^���������ꂽ�I�A�C�e�������X�|�[��");
            timeRemaining = respawnTime;  // �^�C�}�[���Z�b�g
            isRespawnTriggered = true;
        }

        // �^�C�}�[���i�s���A0�ɂȂ�ƃA�C�e�������X�|�[��
        if (isRespawnTriggered && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            Debug.Log("Remaining Time: " + timeRemaining);
        }
        else if (timeRemaining <= 0 && isRespawnTriggered)
        {
            RespawnItem();
>>>>>>> b2ba948a76161793199e120b2c525b8e38316696
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
<<<<<<< HEAD
        // �v���C���[1�܂��̓v���C���[2���͈͂ɓ������Ƃ��A�͈͓��t���O���Z�b�g
        if (other.CompareTag(player1Tag) || other.CompareTag(player2Tag))
        {
            Debug.Log("�v���C���[���͈͓��ɓ������I");
            isPlayerInRange = true;
=======
        // �v���C���[1�܂��̓v���C���[2��Item���C���[���ɓ������Ƃ��A�͈͓��t���O���Z�b�g
        if (other.gameObject.layer == LayerMask.NameToLayer("Item"))
        {
            Debug.Log("�v���C���[��Item���C���[���ɓ������I");
            isPlayerInItemLayer = true;
>>>>>>> b2ba948a76161793199e120b2c525b8e38316696
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
<<<<<<< HEAD
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
=======
        // �v���C���[��Item���C���[����o���Ƃ��A�͈͓��t���O�����Z�b�g
        if (other.gameObject.layer == LayerMask.NameToLayer("Item"))
        {
            Debug.Log("�v���C���[��Item���C���[����o���I");
            isPlayerInItemLayer = false;
        }
    }

    void RespawnItem()
    {
        // �A�C�e�����w�肳�ꂽ�ʒu�Ő���
        Instantiate(item, new Vector2(x, y), Quaternion.identity);
        Debug.Log("�A�C�e�������X�|�[�����܂����I");
        isRespawnTriggered = false;  // ���X�|�[���t���O�����Z�b�g
    }

    // �A�C�e���̃��X�|�[���ʒu��ݒ肷�郁�\�b�h
    public void SetSpawnPosition(Vector2 position)
    {
        spawnPosition = position;
>>>>>>> b2ba948a76161793199e120b2c525b8e38316696
    }
}
