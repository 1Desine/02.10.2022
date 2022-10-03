using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Diagnostics;


public class Player : MonoBehaviour
{
    [SerializeField] Transform prefabBullet;

    Rigidbody2D body;
    Transform tramsform;

    Camera mainCamera;

    short _health = 100;
    short _speed = 5;
    private short _ID;

    System.Random rand = new System.Random();



    void Start()
    {
        //Set random ID to player
        _ID = (short)rand.Next(101);
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();

        tramsform = GetComponent<Transform>();
        gameObject.AddComponent<Rigidbody2D>();
        body = GetComponent<Rigidbody2D>();
        gameObject.AddComponent<CircleCollider2D>();
        body.constraints = RigidbodyConstraints2D.FreezeRotation;
        body.gravityScale = 0;


    }


    void Update()
    {
        Attack();
    }
    void FixedUpdate()
    {
        Move();
    }



    private void Attack()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //there are we aiming at?
            var mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            var bulletDirection = (mousePosition - tramsform.position);
            //create a bullet
            var bullet_instatce = Instantiate(prefabBullet, transform.position, transform.rotation);
            //setup the bullet
            bullet_instatce.GetComponent<Projectile>().Setup(bulletDirection, _ID);
        }
    }

    public void Damage(short damdage)
    {
        _health -= damdage;
        if (_health <= 0) Kill();
    }
    private void Kill() {
        Destroy(gameObject);
    }

    private void Move()
    {
        var direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        body.velocity = direction * _speed;
    }

    public short GetID()
    {
        return _ID;
    }

}
