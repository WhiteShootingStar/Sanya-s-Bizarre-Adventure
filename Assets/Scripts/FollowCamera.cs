using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public float offsetY = 1.0f;
    private GameObject Player;
    public bool follow = true;
    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (follow)
            transform.position = Player.transform.position + Vector3.back + Vector3.up * offsetY;
    }
}
