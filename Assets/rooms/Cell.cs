using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{   private Rigidbody rigidbody;
    [SerializeField] private float velocity;
    Vector3 inicial;
    Vector3 final;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        rigidbody.velocity = (gameObject.transform.right+gameObject.transform.up* Random.Range(0, 0.1f) + gameObject.transform.forward * Random.Range(0, 0.1f)).normalized * velocity;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(rigidbody.velocity.magnitude);
        Debug.Log(rigidbody.velocity);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("impulce"))
        {
            Debug.Log("impulce");
            rigidbody.velocity = other.transform.right * velocity;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Vector3 initialDirection = gameObject.transform.right;
        rigidbody.velocity = rigidbody.velocity.normalized * velocity;
       // gameObject.transform.right = rigidbody.velocity.normalized;
    }
}
