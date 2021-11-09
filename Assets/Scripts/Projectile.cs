using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody2D rigidbody2d;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        if (transform.position.magnitude > 10.0f)
        {
            Destroy(gameObject);
        }
    }
    // Направление и Сила Снаряда
    public void Launch(Vector2 direction, float force)
    {
        rigidbody2d.AddForce(direction * force);
    }

    //попадение снаряда
    void OnCollisionEnter2D(Collision2D other)
    {
        EnemyController2 e = other.collider.GetComponent<EnemyController2>();
        if (e != null)
        {
            e.Fix();
        }

        Destroy(gameObject);
    }
}
