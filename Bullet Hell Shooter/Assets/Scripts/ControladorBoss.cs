using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerBoss : MonoBehaviour
{
    private BulletSpawner[] myLight;
    private float timer;
    private int currentLightIndex = 0;


    void Start()
    {
        myLight = GetComponents<BulletSpawner>();
        timer = 0f;
    }


    void Update()
    {
        timer += Time.deltaTime;

        // Cada 10 segundos
        if (timer >= 10f)
        {

            myLight[currentLightIndex].enabled = !myLight[currentLightIndex].enabled;
            currentLightIndex = (currentLightIndex + 1) % myLight.Length;
            myLight[currentLightIndex].enabled = !myLight[currentLightIndex].enabled;
            //myLight[1].enabled = !myLight[1].enabled;
            timer = 0f;
        }
    }
}
