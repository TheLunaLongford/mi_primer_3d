using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_check_points : MonoBehaviour
{
    public GameObject player;
    public GameObject checkpoints;

    public Transform[] puntos;
    public Transform current_check;

    void Start()
    {
        // Load and move character into the desired check-point
        int initial_position = 0;
        // 0 = start of the circuit
        // 1 = first test
        // 2 = second test
        // 3 = third test 
        // 4 = end of third test

        puntos = load_checkpoints();
        current_check = puntos[initial_position];
        player.transform.position = current_check.transform.position;
    }

    private Transform[] load_checkpoints()
    {
        int numero_checks = checkpoints.transform.childCount;
        Transform[] puntos = new Transform[numero_checks];
        for (int i = 0; i < numero_checks; i++)
        {
            puntos[i] = checkpoints.transform.GetChild(i); 
        }
        return puntos;
    }

}
