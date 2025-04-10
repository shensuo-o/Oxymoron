using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    //stats de Leif
    public float HP;
    public float Speed;

    //variables para el movimiento
    [SerializeField] private Rigidbody rb;
    [SerializeField] private float HorizontalInput;

    //variables para el salto
    [SerializeField] private float jumpForce;
    [SerializeField] private float JumpStartTime;
    [SerializeField] private float jumpTime;
    [SerializeField] private bool isJumping;
    [SerializeField] private Transform groundDetector;
    [SerializeField] private Vector3 detectorDimensions;
    [SerializeField] private bool isGrounded;
    [SerializeField] private LayerMask isFloor;

    //Variables para la caida
    [SerializeField] private float globalGravity;
    [SerializeField] private float gravityScale;
    [SerializeField] private float afterJumpScale;
    [SerializeField] private float maxFallSpeed;
    [SerializeField] private float timer = 1f;

    //Variables para agacharse
    [SerializeField] private float normalSpeed;
    [SerializeField] private float crouchSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        globalGravity = 9.8f;
        normalSpeed = Speed;
    }

    void Update()
    {
        HorizontalInput= Input.GetAxisRaw("Horizontal");
        Jump();
        Crouch();
    }

    private void FixedUpdate()
    {
        Movement(HorizontalInput);
        Gravity();
        Grounded();
    }

    #region Movement

    private void Movement(float dir)//Toma la variable de direccion y la usa para moverse con velocity del rigidbody.
    {
        var xVel = dir * Speed * 100 * Time.fixedDeltaTime;
        Vector2 targetVelocity = new Vector2(xVel, rb.velocity.y);
        rb.velocity = targetVelocity;
    } 

    private void Jump()//Salto que se hace mas alto contra mas se sostiene apretado el boton.
    {
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            isJumping = true;
            jumpTime = JumpStartTime;

            rb.velocity = Vector2.up * jumpForce;
        }

        if (Input.GetButton("Jump") && isJumping)
        {
            if (jumpTime > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTime -= Time.deltaTime;
            }
            else
            {
                isJumping = false;
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
        }
    }

    private void Gravity()//Simula gravedad para matener al jugador en el piso y para tener saltos mas realistas.
    {
        if(!isGrounded && !isJumping)
        {
            timer += Time.fixedDeltaTime;
            Vector3 gravity = Mathf.Clamp(globalGravity * afterJumpScale, 9.8f, maxFallSpeed) * Vector3.down;
            rb.AddForce(gravity * timer, ForceMode.Acceleration);
            if (timer >= 1.3f)
            {
                rb.AddForce(gravity * timer, ForceMode.Acceleration);
            }
        }
        else if (isGrounded && !isJumping)
        {
            timer = 1f;
            Vector3 gravity = Mathf.Clamp(globalGravity * gravityScale, 0, maxFallSpeed) * Vector3.down;
            rb.AddForce(gravity, ForceMode.Acceleration);
        }

    }

    private void Crouch()
    {
        if (isGrounded && !isJumping)
        {
            if (Input.GetKey(KeyCode.LeftControl))
            {
                Speed = crouchSpeed;
            }
            else
            {
                Speed = normalSpeed;
            }
        }
    }

    private void Grounded()//Detecta si el player esta parado en el piso o no.
    {
        isGrounded = Physics.CheckBox(groundDetector.position, detectorDimensions, Quaternion.identity, isFloor);
    }

    #endregion

    private void TakeDamage(int damage)//Llama a este script cada vez que recibe daño de algo.
    {
        HP -= damage;
    }
}
