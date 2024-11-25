using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class Naga : MonoBehaviour
{
    public bool hadapKanan = true; // Apakah naga menghadap kanan
    public AIPath aiPath; // Komponen AIPath dari Pathfinding
    public GameObject karakter; // Referensi ke objek karakter

    private PlayerMovement playerMovement; // Untuk mengakses respawnPoint dari PlayerMovement

    void Start()
    {
        // Mendapatkan referensi ke PlayerMovement
        playerMovement = karakter.GetComponent<PlayerMovement>();
    }

    void Update()
    {
        // Jika naga bergerak ke kanan tetapi sedang menghadap kiri
        if (aiPath.desiredVelocity.x > 0f && !hadapKanan)
        {
            transform.Rotate(0f, 180f, 0f); // Rotasi ke kanan
            hadapKanan = true;
        }
        // Jika naga bergerak ke kiri tetapi sedang menghadap kanan
        else if (aiPath.desiredVelocity.x < 0f && hadapKanan)
        {
            transform.Rotate(0f, 180f, 0f); // Rotasi ke kiri
            hadapKanan = false;
        }
    }

    // Fungsi untuk mendeteksi tabrakan dengan karakter
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Karakter"))
        {
            // Menggunakan metode publik untuk mendapatkan respawnPoint
            other.transform.position = playerMovement.GetRespawnPoint(); // Karakter akan respawn
            Debug.Log("Respawned after hitting enemy");
        }
    }
}
