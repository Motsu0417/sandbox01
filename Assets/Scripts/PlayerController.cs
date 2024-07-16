
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

    // Start is called before the first frame update

    public enum PLAYERSTATE
    {
        PLAY,
        PAUSE,
        CHAT
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

            //------�J�����̉�]------

            // �}�E�X�̈ړ��ʂ��擾
            float mx = Input.GetAxis("Mouse X");
            float my = Input.GetAxis("Mouse Y");
            Debug.Log(mx + ", " + my);

            // X�����Ɉ��ʈړ����Ă���Ή���]
            if (Mathf.Abs(mx) > 0.01f)
            {
                // ��]���̓��[���h���W��Y��
                transform.RotateAround(transform.position, Vector3.up, mx * sency);
            }

            // Y�����Ɉ��ʈړ����Ă���Ώc��]
            if (Mathf.Abs(my) > 0.01f)
            {
                // ��]���̓J�������g��X��
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
