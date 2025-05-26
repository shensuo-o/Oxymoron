using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Personaje : MonoBehaviour
{
    //stats de Leif
    public float HP;
    public float Speed;
    public float Damage;

    #region Variables Movimiento

    //variables para el movimiento
    [SerializeField] private Rigidbody rb;
    public float HorizontalInput;

    //variables para el salto
    [SerializeField] private float jumpForce;
    [SerializeField] private float JumpStartTime;
    [SerializeField] private float jumpTime;
    [SerializeField] public bool isJumping;
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

    //Variables para roll
    [SerializeField] private float rollSpeed;
    [SerializeField] private float normalSpeed;
    [SerializeField] private float rollTime;
    [SerializeField] private float rollCoolDown;
    [SerializeField] private bool canRoll;
    [SerializeField] private bool isRolling;
    [SerializeField] private float rollDirection;
    [SerializeField] private BoxCollider leifCollider;
    [SerializeField] private CapsuleCollider leifAttackDetection;

    #endregion

    //Variables UI
    public Image healthBar;
    public float barHP;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        leifCollider = GetComponentInChildren<BoxCollider>();
        healthBar = GameObject.Find("Health").GetComponent<Image>();
    }

    void Update()
    {
        if (!isRolling)
        {
            HorizontalInput = Input.GetAxisRaw("Horizontal");
            if (HorizontalInput == -1)
            {
                rollDirection = -1;
            }
            if (HorizontalInput == 1)
            {
                rollDirection = 1;
            }
            Jump();
        }

        if (isGrounded && !isJumping && canRoll)
        {
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                StartCoroutine(Roll());
            }
        }

        healthBar.material.SetFloat("_Health", (barHP - HP) / 100);
    }

    private void FixedUpdate()
    {
        if (!isRolling)
        {
            Movement(HorizontalInput);
        }
        Gravity();
        Grounded();
    }

    #region Movement

    private void Movement(float dir)//Toma la variable de direccion y la usa para moverse con velocity del rigidbody.
    {
        var xVel = dir * Speed * 100 * Time.fixedDeltaTime;
        Vector3 targetVelocity = new Vector3(xVel, rb.velocity.y);
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
                rb.velocity = Vector3.up * jumpForce;
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

    private IEnumerator Roll() //Temporalmente aumenta la velocidad de Leif y achica su hitbox
    {
        canRoll = false;
        isRolling = true;

        normalSpeed = Speed;
        Speed = rollSpeed;

        var xVel = rollDirection * Speed * 100 * Time.fixedDeltaTime;
        Vector3 targetVelocity = new Vector3(xVel, rb.velocity.y);
        rb.velocity = targetVelocity;

        leifCollider.center = new Vector3(0, -0.6f, 0);
        leifCollider.size = new Vector3(1, 0.8f, 1);

        leifAttackDetection.enabled = false;

        yield return new WaitForSeconds(rollTime);

        Speed = normalSpeed;
        isRolling = false;
        leifCollider.center = new Vector3(0, 0, 0);
        leifCollider.size = new Vector3(1, 2, 1);
        leifAttackDetection.enabled = true;

        yield return new WaitForSeconds(rollCoolDown);

        canRoll = true;
    }

    private void Grounded()//Detecta si el player esta parado en el piso o no.
    {
        isGrounded = Physics.CheckBox(groundDetector.position, detectorDimensions, Quaternion.identity, isFloor);
    }

    #endregion

    public void TakeDamage(float damage)//Llama a este script cada vez que recibe daño de algo.
    {
        HP -= damage;
    }
}
