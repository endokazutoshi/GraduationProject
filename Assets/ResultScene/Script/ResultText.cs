//using System.Diagnostics;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class ResultText : MonoBehaviour
{
    public GameObject WinText1P;
    public GameObject LoseText1P;
    public GameObject WinText2P;
    public GameObject LoseText2P;

    public PlayerAnimationController1 player1AnimationController;  // �v���C���[1�̃A�j���[�V��������
    public PlayerAnimationController2 player2AnimationController;  // �v���C���[2�̃A�j���[�V��������
    public PlayerAnimationController1camera2 player1camera2AnimationController;
    public PlayerAnimationController2camera2 player2camera2AnimationContoroller;

    void Start()
    {
        // �ŏ��ɑS�Ĕ�\���ɐݒ�
        WinText1P.SetActive(false);
        LoseText1P.SetActive(false);
        WinText2P.SetActive(false);
        LoseText2P.SetActive(false);

        // PlayerPrefs ����S�[������ǂݍ���
        int player1Goal = PlayerPrefs.GetInt("Player1Goal", 0);  // �f�t�H���g�l��0
        int player2Goal = PlayerPrefs.GetInt("Player2Goal", 0);  // �f�t�H���g�l��0

        // �S�[�������f�o�b�O�Ŋm�F
        Debug.Log("Player1 Goal: " + player1Goal);
        Debug.Log("Player2 Goal: " + player2Goal);

        // �v���C���[1���S�[�������ꍇ
        if (player1Goal == 1 && player2Goal == 0)
        {
            // �A�j���[�V�����ݒ�
            if (player1AnimationController != null)
            {
                player1AnimationController.SetWinAnimation(true);  // �v���C���[1�̏����A�j���[�V����
            }
            if (player2AnimationController != null)
            {
                Debug.Log("Player2����������");
                player2AnimationController.SetLoseAnimation(true);  // �v���C���[2�̔s�k�A�j���[�V����
            }
            if (player1camera2AnimationController != null)
            {
                player1camera2AnimationController.SetWinAnimation(true);//�v���C���[�P�̏����A�j���[�V����
            }
            if (player2camera2AnimationContoroller != null)
            {
                player2camera2AnimationContoroller.SetLoseAnimation(true);//�v���C���[�Q�̔s�k�A�j���[�V����
            }

            // �e�L�X�g�\��
            WinText1P.SetActive(true);  // �v���C���[1�̏���
            LoseText2P.SetActive(true); // �v���C���[2�̔s�k
        }
        // �v���C���[2���S�[�������ꍇ
        else if (player2Goal == 1 && player1Goal == 0)
        {
            // �A�j���[�V�����ݒ�
            if (player2AnimationController != null)
            {
                Debug.Log("Player2����������");
                player2AnimationController.SetWinAnimation(true);  // �v���C���[2�̏����A�j���[�V����
            }
            if (player1AnimationController != null)
            {
                player1AnimationController.SetLoseAnimation(true);  // �v���C���[1�̔s�k�A�j���[�V����
            }
            if (player1camera2AnimationController != null)
            {
                player1camera2AnimationController.SetLoseAnimation(true);//�v���C���[1�̔s�k�A�j���[�V����
            }
            if (player2camera2AnimationContoroller != null)
            {
                player2camera2AnimationContoroller.SetWinAnimation(true);//�v���C���[2�̏����A�j���[�V����
            }
            // �e�L�X�g�\��
            WinText2P.SetActive(true);  // �v���C���[2�̏���
            LoseText1P.SetActive(true); // �v���C���[1�̔s�k
        }
        // �������S�[�������ꍇ�i�s���ȏ�ԁj
        else
        {
            Debug.LogWarning("�s���ȃS�[����Ԃł��B�����̃v���C���[���S�[�����Ă���\��������܂��B");
        }
    }
}
