using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cell : MonoBehaviour
{   private Rigidbody rigidBodyCell;
    [SerializeField] private float velocity;
    private Transform initialPosition;
    // Start is called before the first frame update
    private void Awake()
    {
        initialPosition = transform;
        rigidBodyCell = gameObject.GetComponent<Rigidbody>();
    }
    void Start()
    {
        
        rigidBodyCell.velocity = (gameObject.transform.right+VarianceVelocity(gameObject)).normalized * velocity;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(rigidbody.velocity.magnitude);
        //Debug.Log(rigidbody.velocity);
        if (rigidBodyCell.velocity.magnitude != velocity) rigidBodyCell.velocity = rigidBodyCell.velocity.normalized * velocity;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("impulce"))
        {
            Debug.Log("impulce");
            rigidBodyCell.velocity = ((other.transform.right)+VarianceVelocity(other.gameObject)).normalized* velocity;
        }
        if (other.transform.CompareTag("Wall"))
        {
            rigidBodyCell.velocity = Vector3.zero;
            transform.position = initialPosition.position;
            gameObject.transform.right = initialPosition.right;
            rigidBodyCell.velocity = (initialPosition.transform.right + VarianceVelocity(gameObject)).normalized * velocity;
            gameObject.SetActive(false);
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        Vector3 initialDirection = gameObject.transform.right;
        rigidBodyCell.velocity = (rigidBodyCell.velocity+VarianceVelocity(gameObject)).normalized* velocity;
        //gameObject.transform.right = rigidbody.velocity.normalized;
        // if (collision != null) Debug.Log("colisi�n");
        //if (collision.transform.CompareTag("Finish")) Debug.Log("Vena");

    }
    private Vector3 VarianceVelocity(GameObject reference)
    { 
        return reference.transform.up * Random.Range(-0.3f, 0.3f) + reference.transform.forward * Random.Range(-0.3f, 0.3f);
    }
    public void SetVelocity(Vector3 direction, GameObject reference)
    {
        rigidBodyCell.velocity = (direction + VarianceVelocity(reference)).normalized * velocity;
    }
    //private void OnEnable()
    //{
    //    GetComponent<Rigidbody>().velocity = (initialPosition.right + VarianceVelocity(gameObject)).normalized * velocity;
    //}

}
