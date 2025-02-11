using UnityEngine;
using UnityEngine.Audio;
public class AudioManager : MonoBehaviour
{
    public AudioMixer audioMixer; // AudioMixerを指定

    public void SetPlayer1Audio()
    {
        audioMixer.SetFloat("Player1Volume", 0f);  // Player1 の音量を有効化
        audioMixer.SetFloat("Player2Volume", -80f); // Player2 の音量をミュート
    }

    public void SetPlayer2Audio()
    {
        audioMixer.SetFloat("Player1Volume", -80f); // Player1 の音量をミュート
        audioMixer.SetFloat("Player2Volume", 0f);  // Player2 の音量を有効化
    }
}
