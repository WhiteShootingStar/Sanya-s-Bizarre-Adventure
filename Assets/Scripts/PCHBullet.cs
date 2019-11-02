using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PCHBullet : MonoBehaviour
{
    public float speed;
    public Vector3 direction;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime,Space.Self);

        Destroy(gameObject, 3f);
    }
}
