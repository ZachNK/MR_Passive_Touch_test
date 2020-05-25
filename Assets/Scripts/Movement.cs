using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 100.0f;
    public float limit = 5.0f;

    public float initialspeed;
    public float initiallimit;

    public void Start()
    {
        initialspeed = speed;
        initiallimit = limit;
    }

    public void Vibe(float sec)
    {
        StartCoroutine(VibeRoutine(sec));
    }

    private IEnumerator VibeRoutine(float sec)
    {
        float time = 0;
        while (time <= sec)
        {
            transform.Translate(new Vector3(0, Mathf.Sin(Time.timeSinceLevelLoad * speed) * 0.01f * limit, 0));
            time += Time.deltaTime;
            yield return null;
        }
        transform.localPosition = Vector3.zero;
    }

    private void FixedUpdate()
    {
        transform.Rotate(new Vector3(0.0f, 0.1f, 1.0f));
        //transform.Translate(new Vector3(Mathf.Sin(Time.timeSinceLevelLoad * speed) * 0.01f, Mathf.Sin(Time.timeSinceLevelLoad * speed) * 0.01f * limit, Mathf.Sin(Time.timeSinceLevelLoad * speed) * 0.01f));
    }
}