using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{

    [SerializeField] Transform Player;


    void Start()
    {
        Instantiate(Player, transform.position, transform.rotation);
    }

}
