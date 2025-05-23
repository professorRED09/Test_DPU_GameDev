using UnityEngine;

public class SpeedOrb : MonoBehaviour, IItem
{    
    [SerializeField] float speed;

    private void Start()
    {
        // random spawned position
        float randomX = Random.Range(0f, 1f);
        float randomY = Random.Range(1f, 5f);
        Vector3 worldPos = Camera.main.ViewportToWorldPoint(new Vector3(randomX, randomY / Camera.main.pixelHeight, 20f));
        transform.position = new Vector3(worldPos.x, randomY, 20f);


    }

    void Update()
    {
        transform.position += Vector3.back * speed * Time.deltaTime;
    }

    public void OnActivated()
    {
        FindObjectOfType<MainLogic>()?.OnHeal();
        print("SPEED");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
        }
    }
}
