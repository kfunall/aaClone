using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PinSpawner : MonoBehaviour
{
    [SerializeField] GameObject pinPrefab;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            SpawnPin();
    }
    void SpawnPin()
    {
        Instantiate(pinPrefab, transform.position, transform.rotation);
    }
}