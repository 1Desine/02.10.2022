using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    short _speed = 20;
    short _damage = 10;
    Vector3 _direction;
    float _scale = 0.4f;
    short _ID = 0;

    CircleCollider2D collider;

    void Start()
    {
        transform.localScale = new Vector3(_scale, _scale, _scale);
        gameObject.AddComponent<CircleCollider2D>();
        collider = GetComponent<CircleCollider2D>();
        //collider.isTrigger = true;
    }

    void FixedUpdate()
    {
        //Bullet movement
        transform.position += _direction.normalized * _speed * Time.deltaTime;
    }

    //Setup initial properties of the bullet
    public void Setup(Vector2 direction, short id)
    {
        if (_ID != 0) return;
        _direction = direction;
        _ID = id;
    }

    //Check for collision with "Player"
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag == "Player")
        {
            if (collision.collider.gameObject.GetComponent<Player>().GetID() == _ID) return;
            collision.gameObject.GetComponent<Player>().Damage(_damage);
        }
        Destroy(gameObject);
    }
}
