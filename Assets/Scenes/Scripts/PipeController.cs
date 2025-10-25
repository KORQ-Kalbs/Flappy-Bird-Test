using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PipeController : MonoBehaviour
{
    public float pipeSpeed;

    void Update()
    {
        transform.Translate(Vector2.left * pipeSpeed * Time.deltaTime);
    }
}
