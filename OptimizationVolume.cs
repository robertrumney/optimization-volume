using UnityEngine;
using System.Collections.Generic;

public class OptimizationVolume : MonoBehaviour 
{
    // List of items in the volume
    [System.Serializable]
    private GameObject[] items;

    // Whether the volume is activated
    private bool activated = false;

    private void Awake () 
    {
        // Disable the mesh renderer to hide the volume in the scene
        GetComponent<MeshRenderer>().enabled = false;
        // Set all items to inactive by default
        SetItems(false);
    }

    private IEnumerator Start()
    {
        // Wait for 2 seconds before enabling the collider (prevents clipping issues)
        yield return new WaitForSeconds(2);
        // Enable the collider
        GetComponent<Collider>().enabled = true;
        // Mark the volume as activated
        activated = true;
    }

    private void OnTriggerEnter(Collider other) 
    {
        // If the player enters the volume and it's activated
        if (other.CompareTag("Player"))
        {
            if(!activated) return;
        
            // Spawn items if enabled
            if (useSpawning)
            {
                AutoSpawn();
            }
            // Set all items to active
            SetItems(true);
        }
    }

    private void OnTriggerExit(Collider other) 
    {
        // If the player exits the volume
        if (other.CompareTag("Player"))
        {
            // Set all items to inactive
            SetItems(false);
        }
    }

    private void SetItems(bool active)
    {
        // Set all items in the list to the specified active state
        foreach (GameObject item in items)
        {
            if (item) item.SetActive(active);
        }
    }
}
