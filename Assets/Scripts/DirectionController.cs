using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionController : MonoBehaviour
{
    public GameObject StartPosition, EndPosition;
    public GameObject DangerObject;
    new private BoxCollider2D collider2D;

    public Vector2 direction;
    private SimpleMoving instantiatedDanger;
    private bool hasInstantiated = false;
    public float speed;
    public bool horizontal = false;
    // Start is called before the first frame update
    void Start()
    {
        if (!horizontal)
        {
            float YDistance = Vector2.Distance(StartPosition.transform.position, EndPosition.transform.position);
            float XWidth = DangerObject.GetComponent<SpriteRenderer>().bounds.size.x;
            /*collider2D =*/
            GetComponent<BoxCollider2D>().size = new Vector2(XWidth, YDistance);
        }
        else
        {
            float YDistance =  DangerObject.GetComponent<SpriteRenderer>().bounds.size.y;
            float XWidth = Vector2.Distance(StartPosition.transform.position, EndPosition.transform.position);
            /*collider2D =*/
            GetComponent<BoxCollider2D>().size = new Vector2(XWidth, YDistance);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (instantiatedDanger != null)
        {
            if (Vector2.Distance(instantiatedDanger.transform.position, EndPosition.transform.position) < 3f)
            {
                instantiatedDanger.gameObject.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag.Equals("Player") && !hasInstantiated)
        {
            instantiatedDanger = Instantiate(DangerObject, StartPosition.transform.position, Quaternion.identity).GetComponent<SimpleMoving>();
            hasInstantiated = true;
            instantiatedDanger.direction = direction;
            instantiatedDanger.speed = speed;
        }

    }
}
