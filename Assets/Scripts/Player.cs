using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class Player : MonoBehaviour
{
    [SerializeField] private float _playerSpeed = 1f;
    [SerializeField] private float _jumpPower = 3f;
    public UI_Manager sc;
    private Rigidbody2D _rb;
    private bool _isGrounded;
    private Animator _anim;
    public int _score;
    [SerializeField] TMP_Text _text;
    public bool _work;

    private void Awake()
    {
        _text.text = "";
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
    }
    private void Update()
    {
        MovePlayer();

        if (Input.GetButtonDown("Jump")  & _isGrounded == false)
        {
            Jump();
        }    
        _text.text = "" + _score;
        if (_score % 10 == 0)
        {
            sc.health += 1;
        }
        
    }
    private void MovePlayer()
    {
        float x = Input.GetAxisRaw("Horizontal");
        _rb.velocity = new Vector2(x * _playerSpeed, _rb.velocity.y);
        _anim.SetFloat("Speed", Mathf.Abs(x));
    }
    private void Jump() 
    {
        _rb.AddForce(Vector2.up * _jumpPower, ForceMode2D.Impulse);
    }
    
    public void OnCollisionEnter2D (Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            _isGrounded = false;
            _anim.SetBool("Jump", false);
        }
        if (col.gameObject.tag == "Fire")
        {
            _isGrounded = false;
            _anim.SetBool("Jump", false);
        }
        if (col.gameObject.tag == "Saw")
        {
            sc.health --;
        }
        if (col.gameObject.tag == "Fire" & _work == true)
        {
            sc.health --;
        }
        if (col.gameObject.tag == "Box")
        {
            _isGrounded = false;
            _anim.SetBool("Jump", false);
        }
    }
    public void OnCollisionExit2D (Collision2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            _isGrounded = true;
            _anim.SetBool("Jump", true);
        }
        if (col.gameObject.tag == "Fire" &  _work == false)
        {
            _isGrounded = true;
            _anim.SetBool("Jump", true);
        }
        if (col.gameObject.tag == "Box")
        {
            _isGrounded = true;
            _anim.SetBool("Jump", true);
        }
    }
    public void OnTriggerEnter2D (Collider2D col)
    {
        if (col.gameObject.tag == "Plate")
        {
            _work = true;
        }
        if (col.gameObject.tag == "Spike")
        {
            sc.health --;
        }
        if (col.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene("Level2");
        }
        if (col.gameObject.tag == "Finish2")
        {
            SceneManager.LoadScene("Congrats");
        }
        if (col.gameObject.tag == "Dead")
        {
            sc.health -= 3;
        } 
    }
    public IEnumerator OnTriggerExit2D (Collider2D col)
    {
        if (col.gameObject.tag == "Plate")
        {
            yield return new WaitForSeconds(3f);
            _work = false;
        }
    }    
    
}
