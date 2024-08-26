using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    // The prefab of the NPC to spawn
    public GameObject npcPrefab;

    // The area where the NPC will spawn (defined by a bounding box)

    public float minX = -400.0f; // minimum x-coordinate of the map
    public float maxX = 1000.0f; // maximum x-coordinate of the map
    public float minZ = -747.0f; // minimum z-coordinate of the map
    public float maxZ = 170.0f; // maximum z-coordinate of the map

    // The rate at which NPCs will spawn (in seconds)
    public float spawnRate = 30f;

    public float temporizator = 1f;

    // The lifetime of each NPC (in seconds)
    public float npcLifetime = 30f;

    public int spawns = 1;

    private float nextSpawnTime;

    void Start()
    {
        // Initialize the next spawn time
        nextSpawnTime = Time.time + spawnRate + temporizator;
        if (temporizator == 0){
            SpawnNPC(spawns);
        }
    }

    void Update()
    {
        // Check if it's time to spawn a new NPC
        if (Time.time > nextSpawnTime)
        {
            // Spawn a new NPC
            SpawnNPC(spawns);

            // Update the next spawn time
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnNPC(int num)
    {
        for (int i = 0; i < num; i++)
        {
            // Generate a random position within the spawn area
            float x = Random.Range(minX, maxX);
            float z = Random.Range(minZ, maxZ);
            Vector3 spawnPosition = new Vector3(x, 0f, z);

            // Instantiate the NPC prefab at the random position
            GameObject npc = Instantiate(npcPrefab, spawnPosition, Quaternion.identity);

            // Optional: set the NPC's rotation to face a random direction
            npc.transform.rotation = Quaternion.Euler(0f, Random.Range(0f, 360f), 0f);

            NPC LifetimeScript = npc.AddComponent<NPC>();
            LifetimeScript.lifetime = npcLifetime;
        }
    }
}
public class NPC : MonoBehaviour
{
    public float lifetime;

    private float birthTime;

    void Start()
    {
        // Record the birth time of the NPC
        birthTime = Time.time;
    }

    void Update()
    {
        // Check if the NPC has exceeded its lifetime
        if (Time.time - birthTime > lifetime)
        {
            // Destroy the NPC
            Destroy(gameObject);
        }
    }
}
