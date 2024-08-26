using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Alentamiento del personaje
    private float slowness= 1f;
    //Velocidad
    public float speed = 40.0f;
    //Velocidad de giro
    public float turnSpeed = 20f;
    //Movimiento hacia adelante
    public float horizontalInput;
    //Entrada de giro
    public float rotationInput;
    //Movimiento hacia adelante
    public float forwardInput;
    //Variables cámara
    public Camera mainCamera;
    public Camera hoodCamera;
    public KeyCode switchKey; //Tecla que permite cambiar entre cámaras
    public KeyCode slowKey; //Tecla que permite cambiar entre cámaras
    //Variables multijugador
    public string inputId;

    // Start es llamado antes del primer Update
    void Start()
    {
    }

    // Update es llamado una vez cada framse
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        rotationInput = Input.GetAxis("Rotation");
        if (Input.GetKey(slowKey))
        {
            slowness = 0.5f;
        }
        else
        {
            slowness = 1f;
        }
        //Rota el vehiculo de acuerdo a las entradas verticales
        transform.Translate(Vector3.forward * Time.deltaTime * speed * forwardInput * slowness);
        transform.Translate(Vector3.right * Time.deltaTime * speed * horizontalInput * slowness);

        //Giro del personaje
        transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed * rotationInput * slowness);
        //Cambio entre cámaras
        if (Input.GetKeyDown(switchKey))
        {
            mainCamera.enabled = !mainCamera.enabled;
            hoodCamera.enabled = !hoodCamera.enabled;
        }
    }
}
