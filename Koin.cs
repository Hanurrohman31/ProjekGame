using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Koin : MonoBehaviour
{
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {

    }

  
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Trigger Terdeteksi dengan: " + other.gameObject.name);

       
        if (other.CompareTag("Karakter"))
        {
            
            score += 5;
            Debug.Log("Score: " + score);

           
            Destroy(gameObject);
        }
    }
}
