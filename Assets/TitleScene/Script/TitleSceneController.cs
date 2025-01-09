using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleSceneController : MonoBehaviour
{
    public AudioClip buttonSound; // A�{�^�������������̉�
    public Image fadeImage;       // �t�F�[�h�A�E�g�p��Image�i���F�j
    private AudioSource audioSource;

    private bool isTransitioning = false; // �J�ڒ����ǂ������m�F����t���O

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = buttonSound;
        audioSource.playOnAwake = false;

        // �t�F�[�h�摜�̏����ݒ�i�����ɂ���j
        if (fadeImage != null)
        {
            var color = fadeImage.color;
            color.a = 0;
            fadeImage.color = color;
        }
    }

    void Update()
    {
        // A�{�^���iJump_P1�j�������ꂽ��
        if (Input.GetButtonDown("Jump_P1") && !isTransitioning)
        {
            StartCoroutine(HandleSceneTransition());
        }
    }

    private IEnumerator HandleSceneTransition()
    {
        isTransitioning = true; // �J�ڒ��t���O�𗧂Ă�

        // ����炷
        audioSource.Play();

        // 1�b�ҋ@
        yield return new WaitForSeconds(1f);

        // �t�F�[�h�A�E�g���J�n
        yield return StartCoroutine(FadeOut(2.5f));

        // �V�[����؂�ւ�
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

            // �m���Ƀt�F�[�h������
            var finalColor = fadeImage.color;
            finalColor.a = 1;
            fadeImage.color = finalColor;
        }
    }
}
