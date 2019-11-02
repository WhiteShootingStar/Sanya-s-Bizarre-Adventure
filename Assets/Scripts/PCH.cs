using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCH : MonoBehaviour
{
    public float rotationSpeed = 10f;
    public GameObject[] shootPositions;
    public GameObject PCHBullet;
    public float maxDistance;
    public float reloadTime;
    public float hp=150;
    private GameObject Player;
    private float constReloadTime;
    // Start is called before the first frame update
    void Start()
    {
        constReloadTime = reloadTime;
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        reloadTime -= Time.deltaTime;
        transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, Player.transform.position) <= maxDistance)
        {
            for (int i = 0; i < shootPositions.Length; i++)
            {
                Vector3 dir = Player.transform.position - shootPositions[i].transform.position;
                float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
                shootPositions[i].transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                // shootPositions[i].transform.LookAt(Player.transform.position,Vector3.right);
            }
        }
        Shoot();
        if (hp <= 0) Die();

    }

    void Shoot()
    {
        if (reloadTime <= 0f)
        {
            for (int i = 0; i < shootPositions.Length; i++)
            {
                var bullet = Instantiate(PCHBullet, shootPositions[i].transform.position, shootPositions[i].transform.rotation);
                bullet.GetComponent<PCHBullet>().direction = Vector2.right;

            }
            reloadTime = constReloadTime;
            
        }

    }
    void Die()
    {   
        gameObject.SetActive(false);
    }
}
