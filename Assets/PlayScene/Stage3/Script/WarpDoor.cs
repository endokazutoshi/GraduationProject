using UnityEngine;
using System.Collections;  // �R���[�`�����g�p���邽�߂ɕK�v

public class WarpDoor : MonoBehaviour
{
    public Transform targetPosition1;  // �v���C���[1�̈ړ���ʒu
    public Transform targetPosition2;  // �v���C���[2�̈ړ���ʒu
    private GameObject player1;        // �v���C���[1�̃I�u�W�F�N�g
    private GameObject player2;        // �v���C���[2�̃I�u�W�F�N�g
    public AudioClip warpSound;        // ���[�v���ɖ炷��
    private AudioSource audioSource;   // ����炷���߂�AudioSource�R���|�[�l���g

    private bool canOpenDoor1 = false; // �v���C���[1���h�A���J������
    private bool canOpenDoor2 = false; // �v���C���[2���h�A���J������

    void Start()
    {
        // AudioSource�R���|�[�l���g���擾
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // �v���C���[�����[�v�ł��鏈����Update�ł͍s��Ȃ�
    }

    // �v���C���[1���I�u�W�F�N�g�ɐG�ꂽ�Ƃ�
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            Debug.Log("Player 1 ���I�u�W�F�N�g�ɐG��܂����I");
            player1 = other.gameObject;  // �v���C���[1�̃I�u�W�F�N�g��ݒ�
            StartCoroutine(WarpPlayerCoroutine(player1, targetPosition1));  // �v���C���[1���w��ʒu�Ƀ��[�v
        }
        else if (other.CompareTag("Player2"))
        {
            Debug.Log("Player 2 ���I�u�W�F�N�g�ɐG��܂����I");
            player2 = other.gameObject;  // �v���C���[2�̃I�u�W�F�N�g��ݒ�
            StartCoroutine(WarpPlayerCoroutine(player2, targetPosition2));  // �v���C���[2���w��ʒu�Ƀ��[�v
        }
    }

    // �v���C���[���I�u�W�F�N�g���痣�ꂽ�Ƃ�
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            Debug.Log("Player 1 ���I�u�W�F�N�g���痣��܂����I");
            player1 = null;  // �v���C���[1�̃I�u�W�F�N�g�����Z�b�g
        }
        else if (other.CompareTag("Player2"))
        {
            Debug.Log("Player 2 ���I�u�W�F�N�g���痣��܂����I");
            player2 = null;  // �v���C���[2�̃I�u�W�F�N�g�����Z�b�g
        }
    }

    // �v���C���[���w�肳�ꂽ�ʒu�Ƀ��[�v������R���[�`��
    private IEnumerator WarpPlayerCoroutine(GameObject player, Transform targetPosition)
    {
        if (player != null && targetPosition != null)
        {
            Debug.Log("���[�v�J�n");



            // ���[�v�O�ɉ���炷
            if (warpSound != null)
            {
                audioSource.PlayOneShot(warpSound);
                Debug.Log("���[�v�����Đ�");
            }
            else
            {
                Debug.LogWarning("warpSound���ݒ肳��Ă��܂���");
            }
            player.SetActive(false);


            yield return new WaitForSeconds(1f);

            player.transform.position = targetPosition.position;
            player.SetActive(true);

            // �ĕ\����ɉ���炷
            if (warpSound != null)
            {
                audioSource.PlayOneShot(warpSound);
                Debug.Log("���[�v�����Đ�");
            }
        }
        else
        {
            Debug.LogWarning("�v���C���[�܂��̓^�[�Q�b�g�ʒu������");
        }
    }

}
