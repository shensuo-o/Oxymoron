using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Personaje : MonoBehaviour
{
    //Stats de Leif
    public float HP;
    public float Speed;

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
    [SerializeField] private CapsuleCollider leifCollider;
    [SerializeField] private CapsuleCollider leifAttackDetection;

    #endregion

    //Variables UI
    [SerializeField] private Image healthBar;

    //Variables Melee
    public float Damage;
    public LeifKnockBack knockBack;
    public float knockBackForce;
    public float slowSpeed;
    [SerializeField] private Animator animator;
    [SerializeField] private MeleeCombat combat;
    [SerializeField] private float tempSpeed;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        knockBack = GetComponent<LeifKnockBack>();
        tempSpeed = Speed;
    }

    void Update()
    {
        if (!isRolling)
        {
            HorizontalInput = Input.GetAxisRaw("Horizontal");

            animator.SetFloat("Speed", rb.velocity.magnitude);

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

        if(combat.isAttacking == true)
        {
            Speed = 1;
        }
        else
        {
            Speed = tempSpeed;
        }

        healthBar.fillAmount = HP / 100f;
    }

    private void FixedUpdate()
    {
        if (!isRolling && !knockBack.isHit)
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
        if (knockBack.isHit == false)
        {
            if (isGrounded && Input.GetButtonDown("Jump"))
            {
                isJumping = true;
                animator.SetBool("IsJumping", isJumping);
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
                    animator.SetBool("IsJumping", isJumping);
                }
            }
        }

        if (Input.GetButtonUp("Jump"))
        {
            isJumping = false;
            animator.SetBool("IsJumping", isJumping);
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
        animator.SetTrigger("Roll");

        canRoll = false;
        isRolling = true;

        normalSpeed = Speed;
        Speed = rollSpeed;

        var xVel = rollDirection * Speed * 100 * Time.fixedDeltaTime;
        Vector3 targetVelocity = new Vector3(xVel, rb.velocity.y);
        rb.velocity = targetVelocity;

        leifCollider.center = new Vector3(0, -0.6f, 0);
        leifCollider.height = 1.2f;

        leifAttackDetection.enabled = false;

        yield return new WaitForSeconds(rollTime);

        Speed = normalSpeed;
        isRolling = false;
        leifCollider.center = new Vector3(0, 0.16f, 0);
        leifCollider.height = 2.36f;
        leifAttackDetection.enabled = true;

        yield return new WaitForSeconds(rollCoolDown);

        canRoll = true;
    }

    private void Grounded()//Detecta si el player esta parado en el piso o no.
    {
        isGrounded = Physics.CheckBox(groundDetector.position, detectorDimensions, Quaternion.identity, isFloor);
    }

    #endregion

    public void TakeDamage(float damage, Vector3 dir)//Llama a este script cada vez que recibe daño de algo.
    {
        HP -= damage;
        knockBack.Knock(dir, Vector3.up, HorizontalInput);
    }
}
