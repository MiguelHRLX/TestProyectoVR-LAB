using UnityEngine;

public class CellPool : MonoBehaviour
{

    public GameObject objectPool;
    // Movimiento de la celula

    private void Start()
    {
        transform.position = objectPool.transform.position;
    }

    // Detectar colisiones con pared final
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Wall"))
        {
            gameObject.SetActive(false);

        }
    }
}
