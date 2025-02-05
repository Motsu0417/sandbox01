
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera maincamra;
    public float sency;
    Rigidbody rb;
    public float speed = 4;
    public float dashRate = 2;
    public float currentSpeed;
    private PLAYERSTATE playerState;

    public PLAYERSTATE GetPlayerState() { return playerState; }
    public PLAYERSTATE SetPlayerState(PLAYERSTATE state)
    {
        playerState = state;
        if (playerState == PLAYERSTATE.PLAY)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
        }
        return playerState;
    }

    public enum PLAYERSTATE
    {
        PLAY,
        PAUSE,
        CHAT,
    }

    void Start()
    {
        maincamra = Camera.main;
        rb = GetComponent<Rigidbody>();
        currentSpeed = 0;
        //Debug.Log(sency);
        playerState = PLAYERSTATE.PLAY;
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerState == PLAYERSTATE.PLAY)
        {

            //------カメラの回転------

            // マウスの移動量を取得
            float mx = Input.GetAxis("Mouse X");
            float my = Input.GetAxis("Mouse Y");
            Debug.Log(mx + ", " + my);

            // X方向に一定量移動していれば横回転
            if (Mathf.Abs(mx) > 0.01f)
            {
                // 回転軸はワールド座標のY軸
                transform.RotateAround(transform.position, Vector3.up, mx * sency);
            }

            // Y方向に一定量移動していれば縦回転
            if (Mathf.Abs(my) > 0.01f)
            {
                // 回転軸はカメラ自身のX軸
                maincamra.transform.RotateAround(maincamra.transform.position, maincamra.transform.right, -my * sency);
            }

            currentSpeed = speed * (Input.GetKey(KeyCode.LeftShift) ? dashRate : 1);
            if (Input.GetKey(KeyCode.W))
            {
                transform.position += transform.forward * currentSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.S))
            {
                transform.position += -transform.forward * currentSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.D))
            {
                transform.position += transform.right * currentSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.A))
            {
                transform.position += -transform.right * currentSpeed * Time.deltaTime;
            }
        }

    }
}
