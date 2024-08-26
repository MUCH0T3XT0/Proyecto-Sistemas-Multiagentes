using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : MonoBehaviour
{
    enum SpawnerType { Straight, Circle, Flower }
    [Header("Bullet Attributes")]
    [SerializeField] public GameObject bullet;
    [SerializeField] public float bulletLife = 1f;
    [SerializeField] public float ang = 0f;
    [SerializeField] public float speed = 1f;
    //public float nbullets= 0f;

    [Header("Spawner Attributes")]
    [SerializeField] private SpawnerType spawnerType;
    [SerializeField] private float firingRate = 1f;
    [SerializeField] private float Spin = 0f;
    [SerializeField] private int Bullets = 1;

    private GameObject spawnedBullet;
    private float timer = 0f;
    private float currentAngle = 0f;

    // Start is called before the first frame update
    void Start()
    {
        currentAngle = ang;
    }

    // Update is called once per frame
    void Update()
    { 
        timer += Time.deltaTime;
        if (timer >= firingRate)
        {
            Fire();
            timer = 0;
        }
    }
    private void Fire()
    {

        if (spawnerType == SpawnerType.Straight)
        {
            // Disparar 5 balas en un patrón circular
            int bulletCount = Bullets;
            float angleStep = 360f / bulletCount;

            for (int i = 0; i < bulletCount; i++)
            {
                // Calcula el ángulo para cada bala
                float bulletang = currentAngle + (i * angleStep);

                // Instancia la bala con la rotación calculada
                GameObject spawnedBullet = Instantiate(bullet, transform.position, Quaternion.Euler(0, bulletang, 0));
                CounterManager.IncrementBulletCount();
                Bullet bulletShoot = spawnedBullet.GetComponent<Bullet>();
                bulletShoot.speed = speed;
                bulletShoot.bulletLife = bulletLife;
            }

            // Incrementa el ángulo actual según Spin para que las balas disparadas posteriormente tengan un ángulo diferente
            currentAngle += Spin;
        }
        else if (spawnerType == SpawnerType.Circle)
        {
            // Disparar balas en un círculo completo
            int grades = 40;
            float angleStep = 360f / grades;

            for (int i = 0; i < grades; i++)
            {
                // Calcula el ángulo para cada bala
                float bulletang = currentAngle + (i * angleStep);

                // Instancia la bala con la rotación calculada
                GameObject spawnedBullet = Instantiate(bullet, transform.position, Quaternion.Euler(0, bulletang, 0));
                CounterManager.IncrementBulletCount();
                Bullet bulletShoot = spawnedBullet.GetComponent<Bullet>();
                bulletShoot.speed = speed;
                bulletShoot.bulletLife = bulletLife;
            }
        }
        else if (spawnerType == SpawnerType.Flower)
        {

            // Disparar 5 balas en un patrón circular
            int bulletCount = Bullets;
            float angleStep = 360f / bulletCount;

            for (int i = 0; i < bulletCount; i++)
            {
                // Calcula el ángulo para cada bala
                float bulletang = currentAngle + (i * angleStep);

                // Instancia la bala con la rotación calculada
                GameObject spawnedBullet = Instantiate(bullet, transform.position, Quaternion.Euler(0, bulletang, 0));
                CounterManager.IncrementBulletCount();
                Bullet bulletShoot = spawnedBullet.GetComponent<Bullet>();
                bulletShoot.speed = speed;
                bulletShoot.bulletLife = bulletLife;

                float bulletang2 = - (currentAngle + (i * angleStep));
                GameObject spawnedBullet2 = Instantiate(bullet, transform.position, Quaternion.Euler(0, bulletang2, 0));
                CounterManager.IncrementBulletCount();
                Bullet bulletShoot2 = spawnedBullet2.GetComponent<Bullet>();
                bulletShoot2.speed = speed;
                bulletShoot2.bulletLife = bulletLife;
            }

            // Incrementa el ángulo actual según Spin para que las balas disparadas posteriormente tengan un ángulo diferente
            currentAngle += Spin;
        }
    }
}
