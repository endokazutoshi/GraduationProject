using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleSceneController : MonoBehaviour
{
    public AudioClip buttonSound; // A�{�^�������������̉�
    public SpriteRenderer[] fadeSprite; // �t�F�[�h�p�̍���PNG�iSpriteRenderer�j�̔z��
    public Slider volumeSlider;   // ���ʒ����p�̃X���C�_�[

    private AudioSource audioSource;
    private bool isTransitioning = false; // �J�ڒ����ǂ������m�F����t���O

    void Start()
    {
        // AudioSource�̐ݒ�
        audioSource = gameObject.AddComponent<AudioSource>();
        audioSource.clip = buttonSound;
        audioSource.playOnAwake = false;

        // �t�F�[�h�摜�̏����ݒ�i�����ɂ��Ă����j
        if (fadeSprite != null)
        {
            foreach (var sprite in fadeSprite)
            {
                var color = sprite.color;
                color.a = 0;  // �����ɐݒ�
                sprite.color = color;
            }
        }

        // ���ʃX���C�_�[�̏����ݒ�
        if (volumeSlider != null)
        {
            volumeSlider.value = audioSource.volume; // ���݂̉��ʂ��X���C�_�[�ɐݒ�
            volumeSlider.onValueChanged.AddListener(OnVolumeChanged); // ���ʕύX���ɌĂ΂��C�x���g��ݒ�
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
        yield return StartCoroutine(FadeOut(1f));

        // �V�[����؂�ւ�
        SceneManager.LoadScene("SelectScene");
    }

    private IEnumerator FadeOut(float duration)
    {
        if (fadeSprite != null)
        {
            float startAlpha = fadeSprite[0].color.a; // �ŏ���SpriteRenderer��alpha���擾
            float time = 0;

            while (time < duration)
            {
                time += Time.deltaTime;
                float alpha = Mathf.Lerp(startAlpha, 1, time / duration);

                // �eSpriteRenderer��alpha��ύX
                foreach (var sprite in fadeSprite)
                {
                    var color = sprite.color;
                    color.a = alpha;
                    sprite.color = color;
                }

                yield return null;
            }
        }
    }

    // �X���C�_�[�ŉ��ʂ��ύX���ꂽ�Ƃ��ɌĂ΂�郁�\�b�h
    private void OnVolumeChanged(float value)
    {
        if (audioSource != null)
        {
            audioSource.volume = value; // ���ʂ��X���C�_�[�̒l�ɐݒ�
        }
    }
}
