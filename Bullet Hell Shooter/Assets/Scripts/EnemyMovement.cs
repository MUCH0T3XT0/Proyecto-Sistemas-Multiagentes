using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float moveSpeed = 5.0f; // speed of the enemy
    public float changeDirectionInterval = 2.0f; // interval to change direction


    public float mapMinX = -400.0f; // minimum x-coordinate of the map
    public float mapMaxX = 1000.0f; // maximum x-coordinate of the map
    public float mapMinZ = -747.0f; // minimum z-coordinate of the map
    public float mapMaxZ = 170.0f; // maximum z-coordinate of the map


    private Vector3 direction; // current direction of the enemy
    private float nextDirectionChange; // time for the next direction change

    void Start()
    {
        // initialize the direction and next direction change time
        direction = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
        nextDirectionChange = Time.time + changeDirectionInterval;
    }

    void Update()
    {
        // calculate the new position
        Vector3 newPosition = transform.position + direction * moveSpeed * Time.deltaTime;

        // clamp the new position to the map boundaries
        newPosition.x = Mathf.Clamp(newPosition.x, mapMinX, mapMaxX);
        newPosition.z = Mathf.Clamp(newPosition.z, mapMinZ, mapMaxZ);

        // if the new position is different from the original new position, it means the NPC hit an edge
        if (newPosition != transform.position + direction * moveSpeed * Time.deltaTime)
        {
            // change the direction to bounce off the edge
            direction = Vector3.Reflect(direction, transform.position - newPosition);
        }

        // move the enemy to the new position
        transform.position = newPosition;
        transform.rotation = Quaternion.LookRotation(direction, Vector3.up);

        // check if it's time to change direction
        if (Time.time > nextDirectionChange)
        {
            // change the direction
            direction = new Vector3(Random.Range(-1.0f, 1.0f), 0, Random.Range(-1.0f, 1.0f));
            nextDirectionChange = Time.time + changeDirectionInterval;
        }
    }
}