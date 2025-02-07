using UnityEngine;

public class MultiDisplayCameraAdjuster : MonoBehaviour
{
    public Camera player1Camera;  // Player1�̃J����
    public Camera player2Camera;  // Player2�̃J����
    public AudioListener player1Listener;  // Player1��AudioListener
    public AudioListener player2Listener;  // Player2��AudioListener

    void Start()
    {
        // �f�B�X�v���C�̗L�����iDisplay2�����݂���ꍇ�j
        if (Display.displays.Length > 1)
            Display.displays[1].Activate();  // Display2��L����

        // �A�X�y�N�g��ݒ� (��20�}�X�A�c9�}�X)
        AdjustCamera(player1Camera, 20f / 9f, 0); // Player1 �J�����ݒ�
        AdjustCamera(player2Camera, 20f / 9f, 1); // Player2 �J�����ݒ�

        // �I�[�f�B�I���X�i�[�̐ݒ�
        SetAudioListener(player1Listener, player1Camera);  // Player1��AudioListener�ݒ�
        SetAudioListener(player2Listener, player2Camera);  // Player2��AudioListener�ݒ�
    }

    void AdjustCamera(Camera camera, float targetAspect, int displayIndex)
    {
        // �Ή�����f�B�X�v���C�ɐݒ�
        camera.targetDisplay = displayIndex;

        // �A�X�y�N�g��̒���
        float windowAspect = (float)Screen.width / (float)Screen.height;
        float scaleHeight = windowAspect / targetAspect;

        if (scaleHeight < 1.0f)
        {
            // ��ʂ��c���̏ꍇ�A�����ɒ���
            camera.rect = new Rect(0, (1.0f - scaleHeight) / 2.0f, 1.0f, scaleHeight);
        }
        else
        {
            // ��ʂ������̏ꍇ�A�����ɒ���
            float scaleWidth = 1.0f / scaleHeight;
            camera.rect = new Rect((1.0f - scaleWidth) / 2.0f, 0, scaleWidth, 1.0f);
        }
    }

    void SetAudioListener(AudioListener listener, Camera camera)
    {
        // �v���C���[1�܂��̓v���C���[2��AudioListener���A�Ή�����J�����̈ʒu�ɐݒ�
        listener.enabled = false;  // ��U�����ɂ���
        if (camera.targetDisplay == 0)
        {
            player1Listener.enabled = true;  // Player1�̃��X�i�[��L����
        }
        else if (camera.targetDisplay == 1)
        {
            player2Listener.enabled = true;  // Player2�̃��X�i�[��L����
        }
    }
}
