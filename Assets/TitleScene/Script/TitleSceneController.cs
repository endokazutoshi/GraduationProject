using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleSceneController : MonoBehaviour
{
    public AudioClip buttonSound; // Aボタンを押した時の音
    public SpriteRenderer fadeSprite; // フェード用の黒いPNG（SpriteRenderer）
    public Slider volumeSlider;   // 音量調整用のスライダー

    private AudioSource audioSource;
    private bool isTransitioning = false; // 遷移中かどうかを確認するフラグ

    void Start()
    {
        // AudioSourceの設定
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = buttonSound;
        audioSource.playOnAwake = false;

        // フェード画像の初期設定（透明にしておく）
        if (fadeSprite != null)
        {
            var color = fadeSprite.color;
            color.a = 0;
            fadeSprite.color = color;
        }

        // 音量スライダーの初期設定
        if (volumeSlider != null)
        {
            volumeSlider.value = audioSource.volume; // 現在の音量をスライダーに設定
            volumeSlider.onValueChanged.AddListener(OnVolumeChanged); // 音量変更時に呼ばれるイベントを設定
        }
    }

    void Update()
    {
        // Aボタン（Jump_P1）が押されたら
        if (Input.GetButtonDown("Jump_P1") && !isTransitioning)
        {
            StartCoroutine(HandleSceneTransition());
        }
    }

    private IEnumerator HandleSceneTransition()
    {
        isTransitioning = true; // 遷移中フラグを立てる

        // 音を鳴らす
        audioSource.Play();

        // 1秒待機
        yield return new WaitForSeconds(1f);

        // フェードアウトを開始
        yield return StartCoroutine(FadeOut(1f));

        // シーンを切り替え
        SceneManager.LoadScene("SelectScene");
    }

    private IEnumerator FadeOut(float duration)
    {
        if (fadeSprite != null)
        {
            float startAlpha = fadeSprite.color.a;
            float time = 0;

            while (time < duration)
            {
                time += Time.deltaTime;
                float alpha = Mathf.Lerp(startAlpha, 1, time / duration);

                var color = fadeSprite.color;
                color.a = alpha;
                fadeSprite.color = color;

                yield return null;
            }
        }
    }

    // スライダーで音量が変更されたときに呼ばれるメソッド
    private void OnVolumeChanged(float value)
    {
        if (audioSource != null)
        {
            audioSource.volume = value; // 音量をスライダーの値に設定
        }
    }
}
