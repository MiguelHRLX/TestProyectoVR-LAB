using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LimitPoll : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("traspasa");
        if (other.CompareTag("Objet"))
        {
            Debug.Log("CELULA");
            other.gameObject.SetActive(false);
        }
    }
}
