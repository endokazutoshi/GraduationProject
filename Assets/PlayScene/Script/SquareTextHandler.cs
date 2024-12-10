using UnityEngine;
using UnityEngine.UI;

public class SquareTextHandler : MonoBehaviour
{
    // �v���C���[���Ƃ̃e�L�X�g
    public Text player1Text;
    public Text player2Text;

    // �e�L�X�g�̐e�L�����o�X�i�f�B�X�v���C����p�j
    public Canvas player1Canvas;
    public Canvas player2Canvas;

    // �v���C���[�̃^�O
    public string player1Tag = "Player1";
    public string player2Tag = "Player2";

    // �\��������f�B�X�v���C�ԍ�
    public int player1Display = 1; // Player1�p�f�B�X�v���C
    public int player2Display = 2; // Player2�p�f�B�X�v���C

    private void Start()
    {
        // �ŏ��̓e�L�X�g���\���ɂ���
        if (player1Text != null) player1Text.gameObject.SetActive(false);
        if (player2Text != null) player2Text.gameObject.SetActive(false);

        // �e�L�����o�X�̃^�[�Q�b�g�f�B�X�v���C��ݒ�
        if (player1Canvas != null) player1Canvas.targetDisplay = player1Display - 1;
        if (player2Canvas != null) player2Canvas.targetDisplay = player2Display - 1;

        // ���p�\�ȃf�B�X�v���C��L����
        if (Display.displays.Length > 1) Display.displays[1].Activate();
        if (Display.displays.Length > 2) Display.displays[2].Activate();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Player1��Square�ɓ������ꍇ
        if (other.CompareTag(player1Tag))
        {
            if (player1Text != null) player1Text.gameObject.SetActive(true);
        }

        // Player2��Square�ɓ������ꍇ
        if (other.CompareTag(player2Tag))
        {
            if (player2Text != null) player2Text.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Player1��Square����o���ꍇ
        if (other.CompareTag(player1Tag))
        {
            if (player1Text != null) player1Text.gameObject.SetActive(false);
        }

        // Player2��Square����o���ꍇ
        if (other.CompareTag(player2Tag))
        {
            if (player2Text != null) player2Text.gameObject.SetActive(false);
        }
    }
}
