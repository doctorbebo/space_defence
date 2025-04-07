using System.Collections;
using System.Collections.Generic;
using _Core;
using UnityEngine;

public class Test : MonoBehaviour, IClickable
{
    public MinMaxFloat testValue;

    // Start is called before the first frame update
    void Start()
    {
        print(testValue.min);
        print(testValue.max);
    }

    // Update is called once per frame
    void Update()
    {
        print(testValue.Random);
    }
}
