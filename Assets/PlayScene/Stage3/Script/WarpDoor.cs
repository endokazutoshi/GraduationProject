using UnityEngine;
using System.Collections;  // コルーチンを使用するために必要

public class WarpDoor : MonoBehaviour
{
    public Transform targetPosition1;  // プレイヤー1の移動先位置
    public Transform targetPosition2;  // プレイヤー2の移動先位置
    private GameObject player1;        // プレイヤー1のオブジェクト
    private GameObject player2;        // プレイヤー2のオブジェクト
    public AudioClip warpSound;        // ワープ時に鳴らす音
    private AudioSource audioSource;   // 音を鳴らすためのAudioSourceコンポーネント

    private bool canOpenDoor1 = false; // プレイヤー1がドアを開ける状態
    private bool canOpenDoor2 = false; // プレイヤー2がドアを開ける状態

    void Start()
    {
        // AudioSourceコンポーネントを取得
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // プレイヤーがワープできる処理はUpdateでは行わない
    }

    // プレイヤー1がオブジェクトに触れたとき
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            Debug.Log("Player 1 がオブジェクトに触れました！");
            player1 = other.gameObject;  // プレイヤー1のオブジェクトを設定
            StartCoroutine(WarpPlayerCoroutine(player1, targetPosition1));  // プレイヤー1を指定位置にワープ
        }
        else if (other.CompareTag("Player2"))
        {
            Debug.Log("Player 2 がオブジェクトに触れました！");
            player2 = other.gameObject;  // プレイヤー2のオブジェクトを設定
            StartCoroutine(WarpPlayerCoroutine(player2, targetPosition2));  // プレイヤー2を指定位置にワープ
        }
    }

    // プレイヤーがオブジェクトから離れたとき
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            Debug.Log("Player 1 がオブジェクトから離れました！");
            player1 = null;  // プレイヤー1のオブジェクトをリセット
        }
        else if (other.CompareTag("Player2"))
        {
            Debug.Log("Player 2 がオブジェクトから離れました！");
            player2 = null;  // プレイヤー2のオブジェクトをリセット
        }
    }

    // プレイヤーを指定された位置にワープさせるコルーチン
    private IEnumerator WarpPlayerCoroutine(GameObject player, Transform targetPosition)
    {
        if (player != null && targetPosition != null)
        {
            Debug.Log("ワープ開始");



            // ワープ前に音を鳴らす
            if (warpSound != null)
            {
                audioSource.PlayOneShot(warpSound);
                Debug.Log("ワープ音を再生");
            }
            else
            {
                Debug.LogWarning("warpSoundが設定されていません");
            }
            player.SetActive(false);


            yield return new WaitForSeconds(1f);

            player.transform.position = targetPosition.position;
            player.SetActive(true);

            // 再表示後に音を鳴らす
            if (warpSound != null)
            {
                audioSource.PlayOneShot(warpSound);
                Debug.Log("ワープ音を再生");
            }
        }
        else
        {
            Debug.LogWarning("プレイヤーまたはターゲット位置が無効");
        }
    }

}
