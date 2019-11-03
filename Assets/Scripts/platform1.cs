using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class platform1 : MonoBehaviour
{
    public GameObject[] enemies;
    private bool hasToDisappear = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hasToDisappear = true;
        for (int i = 0; i < enemies.Length; i++)
        {
            if (enemies[i].activeInHierarchy) hasToDisappear = false;

        }
        if (hasToDisappear) gameObject.SetActive(false);
    }
}
