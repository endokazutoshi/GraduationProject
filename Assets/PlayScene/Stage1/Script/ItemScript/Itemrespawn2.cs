using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItemRespawn2 : MonoBehaviour
{
    [SerializeField] GameObject item;  // ��������A�C�e���̃v���n�u
    public float respawnTime = 3.0f;  // �A�C�e�������X�|�[������܂ł̎���
    private float timeRemaining;  // �c�莞��
    public float x, y; //���X�|�[���̍��W

    // �v���C���[1�ƃv���C���[2�̃^�O��
   // public string player1Tag = "Player1";
    public string player2Tag = "Player2";
    public string ItemtagName; //�A�C�e���̖��O
                               // private bool isPlayer1InItemLayer = false; // �v���C���[��Item���C���[���ɂ��邩�ǂ���
    private bool isPlayer2InItemLayer = false; // �v���C���[��Item���C���[���ɂ��邩�ǂ���
    private bool isRespawnTriggered = false; // ���X�|�[�����g���K�[���ꂽ���ǂ���

    private Vector2 spawnPosition; // �A�C�e���̐����ʒu

    void Start()
    {
        timeRemaining = 0f;
        isRespawnTriggered = false;
    }

    void Update()
    {

        // �v���C���[2��Item���C���[���ɂ���B�{�^���������ꂽ�ꍇ�Ƀ^�C�}�[���J�n
        if (isPlayer2InItemLayer && Input.GetButtonDown("B_Button_2P") && !isRespawnTriggered)
        {
            Debug.Log("B�{�^���������ꂽ�I�A�C�e�������X�|�[��");
            timeRemaining = respawnTime;  // �^�C�}�[���Z�b�g
            isRespawnTriggered = true;
        }

        // �^�C�}�[���i�s���A0�ɂȂ�ƃA�C�e�������X�|�[��
        if (isRespawnTriggered && timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            //Debug.Log("Remaining Time: " + timeRemaining);
        }
        else if (timeRemaining <= 0 && isRespawnTriggered)
        {
            RespawnItem();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        // �v���C���[2��Item���C���[���ɓ������Ƃ��A�͈͓��t���O���Z�b�g
        if (other.CompareTag(ItemtagName))
        {
            Debug.Log("�v���C���[2��Item���C���[���ɓ������I");
            isPlayer2InItemLayer = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("other"+other);
        
        // �v���C���[2��Item���C���[����o���Ƃ��A�͈͓��t���O�����Z�b�g
        if (other.CompareTag(ItemtagName))
        {
            Debug.Log("�v���C���[2��Item���C���[����o���I");
            isPlayer2InItemLayer = false;
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
    }
}