using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private static Vector3 respawnPoint; 
    private static bool isCheckpointSet = false; 

   
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("karakter")) 
        {
            respawnPoint = transform.position;
            isCheckpointSet = true; 
            Debug.Log("Checkpoint set at: " + respawnPoint);
        }
    }

  
    public static void RespawnPlayer(Transform player)
    {
        if (isCheckpointSet)
        {
            player.position = respawnPoint; 
            Debug.Log("Player respawned at checkpoint.");
        }
        else
        {
            Debug.LogWarning("No checkpoint set, cannot respawn!");
        }
    }
}

public class FallDetector : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("karakter")) 
        {
            Debug.Log("Player fell to the fall area.");
            Checkpoint.RespawnPlayer(other.transform); 
        }
    }
}
