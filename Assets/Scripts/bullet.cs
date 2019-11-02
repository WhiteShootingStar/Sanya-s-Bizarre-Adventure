using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float BulletSpeed = 15f;
    public float damage = 10f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * BulletSpeed * Time.deltaTime,Space.Self);
       
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Save"))
        {
          GameManager.spawnPosition= transform.position;
           
        }
        if (!(collision.tag.Equals("DirectionController") || collision.tag.Equals("Boss Zone")))
        {
            Destroy(gameObject);
        }

       
        if (collision.tag.Equals("PCH") )
        {
            collision.gameObject.GetComponent<PCH>().hp -= 20f;
        }

        if (collision.tag.Equals("Boss"))
        {
            collision.gameObject.GetComponent<Boss>().hp -= 75f;
        }
      
    }
}
