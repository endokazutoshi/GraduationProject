using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleSceneController : MonoBehaviour
{
    public AudioClip buttonSound; // Aボタンを押した時の音
    public Image fadeImage;       // フェードアウト用のImage（黒色）
    private AudioSource audioSource;

    private bool isTransitioning = false; // 遷移中かどうかを確認するフラグ

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = buttonSound;
        audioSource.playOnAwake = false;

        // フェード画像の初期設定（透明にする）
        if (fadeImage != null)
        {
            var color = fadeImage.color;
            color.a = 0;
            fadeImage.color = color;
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
        yield return StartCoroutine(FadeOut(2.5f));

        // シーンを切り替え
        SceneManager.LoadScene("SelectScene");
    }

    private IEnumerator FadeOut(float duration)
    {
        if (fadeImage != null)
        {
            float startAlpha = fadeImage.color.a;
            float time = 0;

            while (time < duration)
            {
                time += Time.deltaTime;
                float alpha = Mathf.Lerp(startAlpha, 1, time / duration);

                var color = fadeImage.color;
                color.a = alpha;
                fadeImage.color = color;

                yield return null;
            }

            // 確実にフェードを完了
            var finalColor = fadeImage.color;
            finalColor.a = 1;
            fadeImage.color = finalColor;
        }
    }
}
