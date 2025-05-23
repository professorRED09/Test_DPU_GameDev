using System.Collections.Generic;
using UnityEngine;

public class PlayerClass : MonoBehaviour
{
    public float moveSpeed = 7f;                                        // the moving speed
    public List<KeyCode> fireKeys = new List<KeyCode> { KeyCode.P };    // set fire keys

    private GameObject bulletPrefab;                                    // for referencing bullet prefab to spawn when press fire keys

    void Start()
    {
        // โหลด Bullet Prefab จาก Resources/Prefabs/Bullets
        bulletPrefab = Resources.Load<GameObject>("Prefabs/Bullet");
        if (bulletPrefab == null)
        {
            Debug.LogWarning("ไม่พบ Bullet Prefab ที่ Resources/Prefabs/Bullet");
        }
    }

    void Update()
    {
        Move();
        Shoot();
    }

    void Move()
    {
        // get direction from both axis
        float moveX = Input.GetAxis("Horizontal"); 
        float moveY = Input.GetAxis("Vertical");

        // create a new vector to drive the spaceship, with direction and speed
        Vector3 delta = new Vector3(moveX, moveY, 0f) * moveSpeed * Time.deltaTime;

        // move the spaceship with the previous new vector
        transform.position += delta;

        // move spaceship within camera view
        Vector3 viewPos = Camera.main.WorldToViewportPoint(transform.position);
        viewPos.x = Mathf.Clamp01(viewPos.x);
        viewPos.y = Mathf.Clamp01(viewPos.y);
        transform.position = Camera.main.ViewportToWorldPoint(viewPos);
    }

    // To shoot with bullets spawned
    void Shoot()
    {
        // when player presses each keys in the list, spawn the bullet
        foreach (KeyCode key in fireKeys)
        {
            if (Input.GetKeyDown(key))
            {
                if (bulletPrefab != null)
                {
                    // spawn bullet prefab with given position and rotation
                    Instantiate(bulletPrefab, transform.position, transform.rotation);
                }
                break;
            }
        }
    }

    // When collided with enemy, find MainLogic script to do damage to player
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            FindObjectOfType<MainLogic>()?.GetDamage();
        }
    }
}
 