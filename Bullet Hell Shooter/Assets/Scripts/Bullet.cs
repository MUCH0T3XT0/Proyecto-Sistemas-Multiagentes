using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletLife = 1f;
    public float speed = 1f;
    public float damage = 1f;

    private Vector3 spawnPoint;
    private float timer = 0f;
    private Vector3 direction;

    public float curvatureRate = 3f;  // Tasa de curvatura (ajusta este valor para cambiar la intensidad de la curva)

    // Start is called before the first frame update
    void Start()
    {
        spawnPoint = transform.position;
        direction = transform.forward.normalized;  // Movimiento lineal
    }

    // Update is called once per frame
    void Update()
    {
        if (timer > bulletLife)
        {
            CounterManager.DecrementBulletCount();
            Destroy(this.gameObject);
        }
        timer += Time.deltaTime;
        transform.position = Movement(timer);
    }

    private Vector3 Movement(float timer)
    {
        return spawnPoint + direction * speed * timer;
    }
    void OnTriggerEnter(Collider other)
    {
        DamageHealth enemy = other.GetComponent<DamageHealth>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage); // Causa daño al enemigo
            Destroy(this.gameObject); // Destruye la bala después de golpear
            CounterManager.DecrementBulletCount();
        }
    }
}
