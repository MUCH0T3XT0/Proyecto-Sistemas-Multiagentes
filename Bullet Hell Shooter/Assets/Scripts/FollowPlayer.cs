using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FollowPlayer : MonoBehaviour
{
    //Este crea un objeto jugador
    public GameObject player;
    //Se establece los vectores respecto al jugador
    private Vector3 offset = new Vector3(0, 125, 0);
    private Quaternion offset2 = Quaternion.Euler(90, 0, 0);
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update es llamado una vez por frame
    void LateUpdate()
    {
        //Se mueve la position de la camara respecto al vector declarado anteriormente
        transform.position = player.transform.position + offset;
        transform.rotation = player.transform.rotation * offset2;
    }
}
