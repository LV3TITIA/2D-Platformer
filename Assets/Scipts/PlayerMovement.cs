using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    #region Exposed

    [SerializeField]
    private float _moveSpeed = 5;

    [SerializeField]
    private float _jumpForce;

    [SerializeField]
    private float _maxJump;

    [SerializeField]
    int _fallGravity;

    [SerializeField]
    Animator _animator;

    [SerializeField]
    float _radius;

    [SerializeField]
    [Range(-5, 5)]
    float _offsetYGroundChecker;

    [SerializeField]
    LayerMask _layer;

    #endregion

    #region Unity Lifecycle

    private void Awake()
    {
        _rb2D = GetComponent<Rigidbody2D>();
    }
    void Start()
    { 
    }

    void Update()
    {

        //Groundchecker
        Vector3 positionTransformOffset = new Vector3(transform.position.x, transform.position.y - _offsetYGroundChecker, transform.position.z);
        Collider2D floorCollider = Physics2D.OverlapCircle(transform.position, _radius, _layer);

        // Récupération des bouttons pour le déplacment
        _direction.x = Input.GetAxisRaw("Horizontal") * _moveSpeed;

        _animator.SetFloat("moveSpeedX",Mathf.Abs(_direction.x));
        _animator.SetFloat("moveSpeedY",_direction.y);
        
        // Récupération des bouttons pour le saut
        if (Input.GetButtonDown("Jump") && _numbJump < _maxJump)
        {
            _isJumping = true;
        }

        /*if (floorCollider != null)
        {
            Debug.Log(floorCollider.tag);
           _animator.SetTrigger("Grounded");
           _numbJump = 0;

        }*/
        GroundedCheck();

    }

    private void FixedUpdate()
    {
       // Appliquer une gravité permanente
        _direction.y =_rb2D.velocity.y;

        // Application de la force pour le déplacement
        _rb2D.velocity = _direction;

        // Application de la force pour le saut
        if (_isJumping && _numbJump < _maxJump)
        {
            _numbJump++;
            _isJumping = false;
            Debug.Log("Jumping!!");

            /* Vector2 addJumpForce = new Vector2(_direction.x, _direction.y = _jumpForce);
             _rb2D.AddForce(addJumpForce);*/
           
            _rb2D.velocity = new Vector2(_rb2D.velocity.x, _jumpForce * Time.fixedDeltaTime);
        }

        // Gère la vitesse de chute du player
        if (_rb2D.velocity.y < -0.1f) 
        {
            _rb2D.gravityScale = _fallGravity;
            

        }
        else
        {
            _rb2D.gravityScale = 1;

        }

        // Tourner le personnage dans la bonne direction : 2 Methodes(avec le scale et avec le transform.right)
        /*if (_direction.x < 0f)
        {
            transform.localScale = new Vector3(-Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }
        else if (_direction.x > 0f)
        {
            transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
        }*/

        if (_direction.x < -01f || _direction.x > 0.1f) 
        {
            transform.right = new Vector2(_direction.x,0);
        }
    }

    private void OnDrawGizmos()
    {
        Vector3 positionTransformOffset = new Vector3(transform.position.x, transform.position.y - _offsetYGroundChecker, transform.position.z);

        Gizmos.DrawWireSphere(positionTransformOffset, _radius);

    }

    /*private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "floor")
        {
            _animator.SetTrigger("Grounded");
            _numbJump = 0;

        }

    }*/

    #endregion

    #region Methodes

    void GroundedCheck()

    {
        Vector3 positionTransformOffset = new Vector3(transform.position.x, transform.position.y - _offsetYGroundChecker, transform.position.z);

        Collider2D floorCollider = Physics2D.OverlapCircle(transform.position, _radius, _layer);

        if (floorCollider != null)
        {
            Debug.Log(floorCollider.tag);
            _animator.SetTrigger("Grounded");
            _numbJump = 0;

            if(floorCollider.CompareTag("Plateform"))
            {
                transform.SetParent(floorCollider.transform);
            }
        }
        else
        {
            transform.SetParent(null);
        }

    }



    #endregion

    #region Private & Protected

    private Rigidbody2D _rb2D;
    private Vector2 _direction;
    private bool _isJumping;
    private int _numbJump;

    #endregion
}
