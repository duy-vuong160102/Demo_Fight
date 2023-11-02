using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody rb;
    private PlayerAnimation playerAnim;

    [SerializeField] private float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerAnim = GetComponentInChildren<PlayerAnimation>();
    }

    // Update is called once per frame
    void Update()
    {
        RotatePlayer();
    }

    private void FixedUpdate()
    {
        // Di chuyen nhan vat
        Movement();

        // Animations
        PlayerAnimation();
    }

    private void Movement()
    {
        rb.velocity = new Vector3(Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) * moveSpeed, 
            rb.velocity.y, 
            Input.GetAxisRaw(Axis.VERTICAL_AXIS) * moveSpeed);
    }
    private void RotatePlayer()
    {
        if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) > 0)
        {
            transform.rotation = Quaternion.Euler(0f, 90, 0f);
        }
        else if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) < 0)
        {
            transform.rotation = Quaternion.Euler(0f, -90f, 0f);
        }
    }

    private void PlayerAnimation()
    {
        if (Input.GetAxisRaw(Axis.HORIZONTAL_AXIS) != 0  ||
            Input.GetAxisRaw(Axis.VERTICAL_AXIS) != 0)
        {
            playerAnim.Walk(true);
        }
        else
        {
            playerAnim.Walk(false);
        }
    }
}
