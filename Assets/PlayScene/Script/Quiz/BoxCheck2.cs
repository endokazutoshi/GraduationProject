using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxCheck2 : MonoBehaviour
{
    private QuizManager quizManager;

    public GameObject targetObject;
    public GameObject targetObject2;

    public GameObject targetPlayer2;  // �v���C���[2

    public float timerDuration = 2f;  // ����s�\�ɂ�����b��
    private float currentTime;

    public float forceMultiplier = 10f;  // ������΂��͂̔{��

    private Vector2 targetPosition2;  // �v���C���[2�̍ŏI�ړI�n
    private bool isBlown2 = false;  // �v���C���[2��������΂��ꂽ���ǂ���

    private float blowTime = 0f;    // ������΂��ɂ����鎞��
    float speedFactor = 20f;  // ������{�ɂ���i�����\�j
    // Start is called before the first frame update
    void Start()
    {
        quizManager = FindObjectOfType<QuizManager>();
        targetObject.SetActive(false);
        targetObject2.SetActive(false);
        currentTime = 0f;  // ���������Ƀ^�C�}�[��0�ɐݒ肵�Ă���
    }

    // Update is called once per frame
    void Update()
    {
        if (isBlown2)
        {
            // �v���C���[2�𐁂���΂�
            targetPlayer2.transform.position = Vector2.Lerp(targetPlayer2.transform.position, targetPosition2, blowTime * Time.deltaTime);
            // �ړI�n�ɓ��B������ړ����~
            if (Vector2.Distance(targetPlayer2.transform.position, targetPosition2) < 0.1f)
            {
                isBlown2 = false;  // �v���C���[2�̐�����΂����I��
            }
        }
        // ������΂����Ԃ�i�߂�
        blowTime += Time.deltaTime * speedFactor;  // speedFactor���|���đ����i�s������

        // �^�C�}�[����������
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;  // �^�C�}�[������
                                            // Debug.Log("�^�C�}�[�c�莞��: " + currentTime);  // �f�o�b�O���O�Ń^�C�}�[�c�莞�Ԃ�\��
        }
        else if (currentTime <= 0)
        {
            TimerEnded();  // �^�C�}�[��0�ɂȂ�����ATimerEnded���Ăяo��
        }
    }
    public void CheckItem(GameObject item)
    {
        // ���݂̖����擾
        QuizManager.QuestionAnswerPair currentQuestion = quizManager.GetCurrentQuestion();

        if (currentQuestion != null)
        {
            // ���݂̖��̐����^�O���擾
            string correctAnswerTag = currentQuestion.correctAnswerTag;

            // �������ǂ������`�F�b�N
            if (item.CompareTag(correctAnswerTag))
            {
                Debug.Log("�����ł��I");
                CorrectAnswer();
            }
            else
            {
                Debug.Log("�s�����ł��I");

                
                // targetPlayer2��"Player2"�^�O�������Ă��邩�`�F�b�N
                if (targetPlayer2.CompareTag("Player2"))
                {
                    Debug.Log("Player 2 processed");
                    IncorrectAnswer("Player2");
                }
            }
        }
        else
        {
            Debug.LogError("���݂̖�肪����܂���");
        }
    }
    void CorrectAnswer()
    {
        targetObject.SetActive(true);
        targetObject2.SetActive(true);
    }

    void IncorrectAnswer(string playerTag)
    {
        Debug.Log("IncorrectAnswer�����s���܂�");

        // �e�v���C���[��PlayerMovement�R���|�[�l���g���擾
        
        PlayerMovement playerMovement2 = targetPlayer2.GetComponent<PlayerMovement>();

        

        if (playerTag == "Player2" && playerMovement2 != null)
        {
            Debug.Log("�v���C���[2��������т܂�");
            // �v���C���[2���s�����Ȃ�ړ��𖳌���
            playerMovement2.can_move = 1;
            isBlown2 = true;

            // ������΂������Ƌ���������
            Vector2 forceDirection2 = -targetPlayer2.transform.right;  // �v���C���[2�̐�����΂�����
            float blowDistance = 5f;  // ������΂������i���j�b�g�j
            targetPosition2 = (Vector2)targetPlayer2.transform.position + forceDirection2 * blowDistance;
        }

        blowTime = 0f;  // ������΂��̎��Ԃ����Z�b�g

        // �^�C�}�[�J�n
        currentTime = timerDuration;  // �^�C�}�[���J�n
        Debug.Log("�^�C�}�[�J�n: " + currentTime);
    }


    void TimerEnded()
    {
       
        PlayerMovement playerMovement2 = targetPlayer2.GetComponent<PlayerMovement>();

       

        if (playerMovement2 != null)
        {
            // can_move �� 0 �ɐݒ肵�Ĉړ����ċ���
            playerMovement2.can_move = 0;
        }

        Debug.Log("�^�C�}�[�I���B�ړ����ĊJ����܂����B");

        // �^�C�}�[�����Z�b�g
        currentTime = 0;  // �^�C�}�[�����Z�b�g
    }
}


