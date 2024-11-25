using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpspeed = 5f;
    private float movement = 0f;
    private Rigidbody2D rigidBody;
    public Transform cekTanah;
    public LayerMask layerTanah;
    public float cekTanahRadius;
    public bool sentuhTanah;
    private Animator animator;
    public bool animasiJalan;
    public bool hadapKanan = true;

    private Vector2 respawnPoint; 

    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        animasiJalan = false;

        
        respawnPoint = transform.position;
    }

    void Update()
    {
        movement = Input.GetAxis("Horizontal");
        sentuhTanah = Physics2D.OverlapCircle(cekTanah.position, cekTanahRadius, layerTanah);

        if (movement > 0)
        {
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
            animasiJalan = true;
            transform.localScale = new Vector2(2.187779f, 2.187779f);
        }
        else if (movement < 0)
        {
            rigidBody.velocity = new Vector2(movement * speed, rigidBody.velocity.y);
            animasiJalan = true;
            transform.localScale = new Vector2(-2.187779f, -2.187779f);
        }

        if (Input.GetButtonDown("Jump") && sentuhTanah)
        {
            rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpspeed);
        }

        animator.SetBool("OnGround", sentuhTanah);
        animator.SetBool("IsRun", animasiJalan);
    }

    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("FallDetector"))
        {
           
            transform.position = respawnPoint;
            Debug.Log("Respawned after falling");
        }
        if (other.CompareTag("Checkpoint"))
        {
            
            respawnPoint = other.transform.position;
            Debug.Log("Checkpoint Updated");
        }

       
        if (other.CompareTag("Musuh"))
        {
           
            transform.position = respawnPoint; 
            Debug.Log("Respawned after hitting enemy");
        }
    }

    
    public Vector2 GetRespawnPoint()
    {
        return respawnPoint;
    }
}
