using System.Collections;
using System.Collections.Generic;
using Game.Tank;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public bool Reserved;

    private void OnTriggerStay2D(Collider2D other)
    {
        if(other.TryGetComponent<Tank>(out var tank))
        {
            Reserved = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.TryGetComponent<Tank>(out var tank))
        {
            Reserved = false;
        }
    }
}
