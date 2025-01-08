using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BlinkerScript : MonoBehaviour
{
    public float speed = 1.0f;
    private float time;
    private TextMeshProUGUI tmpText; // TMP �p�̕ϐ�

    void Start()
    {
        // TextMeshProUGUI �R���|�[�l���g���擾
        tmpText = this.gameObject.GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        // �e�L�X�g�̓����x���X�V
        tmpText.color = GetTextColorAlpha(tmpText.color);
    }

    Color GetTextColorAlpha(Color color)
    {
        time += Time.deltaTime * speed * 5.0f;
        color.a = Mathf.Sin(time) * 0.5f + 0.5f; // 0.0 �` 1.0 �͈̔͂Ɏ��߂�

        return color;
    }
}
