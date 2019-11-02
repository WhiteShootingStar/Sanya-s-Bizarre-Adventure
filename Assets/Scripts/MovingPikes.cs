using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPikes : MonoBehaviour
{
    public GameObject firstPosition, secondPosition;
    public float speed;
    public bool retracting = false;

    private Vector2 firstPositionStart, secondPositionStart;
    // Start is called before the first frame update
    void Start()
    {
        firstPositionStart = firstPosition.transform.position*Vector2.up;
        secondPositionStart = secondPosition.transform.position *Vector2.up;

        Debug.Log(firstPositionStart);
        Debug.Log(secondPositionStart);
    }

    // Update is called once per frame
    void Update()
    {
        ChangeDirection();
        if (!retracting)
        {
            transform.Translate(Vector2.up*speed*Time.deltaTime,Space.World);
        }
        if (retracting)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime,Space.World);
        }
    }

    private void ChangeDirection()
    {
        if (transform.position.y > firstPositionStart.y)
        {
            retracting = true;
        }
        if (transform.position.y < secondPositionStart.y)
        {
            retracting = false;
        }
    }
}
