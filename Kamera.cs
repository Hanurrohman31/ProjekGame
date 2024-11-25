using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kamera : MonoBehaviour
{
    public GameObject karakter; // Referensi ke karakter
    public Vector3 offset; // Offset posisi kamera relatif terhadap karakter

    // Update is called once per frame
    void Update()
    {
        if (karakter != null) // Pastikan karakter tidak null
        {
            // Atur posisi kamera mengikuti karakter dengan offset
            transform.position = karakter.transform.position + offset;
        }
    }
}
