using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Itemrespawn : MonoBehaviour
{
    [SerializeField] GameObject item;//��������A�C�e���̃v���n�u
    float time;
    bool isSpawn;
    public float x, y;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        isSpawn = false;

    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time <= 0 && !isSpawn)
        {
            // �A�C�e���𐶐��i�ʒu��2D��ԏ�Ŏw��j
            Instantiate(item, new Vector3(x, y, 0), Quaternion.identity);
            isSpawn = true;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // �A�C�e���ƏՓ˂����ꍇ�̏���
        if (other.gameObject.layer == LayerMask.NameToLayer("Item") || Input.GetButtonDown("B_Button_1P") || Input.GetButtonDown("B_Button_2P"))
        {
            Debug.Log("�A�C�e�������X�|�[��");
            //Destroy(other.gameObject);  // �A�C�e��������
            time = 3.0f;  // �A�C�e�������܂ł̎��Ԃ����Z�b�g
            isSpawn = false;  // �ēx�A�C�e���𐶐��ł���悤��
        }
    }
}
