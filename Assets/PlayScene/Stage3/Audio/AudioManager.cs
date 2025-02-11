using UnityEngine;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
    public AudioMixer audioMixer; // AudioMixer���w��

    public void SetPlayer1Audio()
    {
        audioMixer.SetFloat("Player1Volume", 0f);  // Player1 �̉��ʂ�L����
        audioMixer.SetFloat("Player2Volume", -80f); // Player2 �̉��ʂ��~���[�g
    }

    public void SetPlayer2Audio()
    {
        audioMixer.SetFloat("Player1Volume", -80f); // Player1 �̉��ʂ��~���[�g
        audioMixer.SetFloat("Player2Volume", 0f);  // Player2 �̉��ʂ�L����
    }
}
