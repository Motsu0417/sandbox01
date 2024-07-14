using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Camera camera;
    public float sency;
    Rigidbody rigidbody;
    public float speed = 4;
    public float dashRate = 2;
    public float currentSpeed;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        rigidbody = GetComponent<Rigidbody>();
        currentSpeed = 0;
        Debug.Log(sency);
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed = speed * (Input.GetKey(KeyCode.LeftShift) ? dashRate : 1);
        if (Input.GetKey(KeyCode.W)){
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


        //------ƒJƒƒ‰‚Ì‰ñ“]------

        // ƒ}ƒEƒX‚ÌˆÚ“®—Ê‚ğæ“¾
        float mx = Input.GetAxis("Mouse X");
        float my = Input.GetAxis("Mouse Y");
        Debug.Log(mx + ", " + my);

        // X•ûŒü‚Éˆê’è—ÊˆÚ“®‚µ‚Ä‚¢‚ê‚Î‰¡‰ñ“]
        if (Mathf.Abs(mx) > 0.01f)
        {
            // ‰ñ“]²‚Íƒ[ƒ‹ƒhÀ•W‚ÌY²
            transform.RotateAround(transform.position, Vector3.up, mx * sency);
        }

        // Y•ûŒü‚Éˆê’è—ÊˆÚ“®‚µ‚Ä‚¢‚ê‚Îc‰ñ“]
        if (Mathf.Abs(my) > 0.01f)
        {
            // ‰ñ“]²‚ÍƒJƒƒ‰©g‚ÌX²
            camera.transform.RotateAround(camera.transform.position, camera.transform.right, -my * sency);
        }
    }
}
