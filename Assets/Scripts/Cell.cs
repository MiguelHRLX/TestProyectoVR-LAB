using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{   private Rigidbody rigidbody;
    [SerializeField] private float velocity;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        rigidbody.velocity = (gameObject.transform.right+VarianceVelocity(gameObject)).normalized * velocity;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(rigidbody.velocity.magnitude);
        //Debug.Log(rigidbody.velocity);
        if (rigidbody.velocity.magnitude != velocity) rigidbody.velocity = rigidbody.velocity.normalized * velocity;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("impulce"))
        {
            Debug.Log("impulce");
            rigidbody.velocity = ((other.transform.right)+VarianceVelocity(other.gameObject)).normalized* velocity;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Vector3 initialDirection = gameObject.transform.right;
        rigidbody.velocity = (rigidbody.velocity+VarianceVelocity(gameObject)).normalized* velocity;
        //gameObject.transform.right = rigidbody.velocity.normalized;
        // if (collision != null) Debug.Log("colisión");
        //if (collision.transform.CompareTag("Finish")) Debug.Log("Vena");

    }
    private Vector3 VarianceVelocity(GameObject reference)
    { 
        return reference.transform.up * Random.Range(-0.3f, 0.3f) + reference.transform.forward * Random.Range(-0.3f, 0.3f);
    }
}
