using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExpInfo3 : MonoBehaviour
{
    public List<float> VibeSensitivitys;
    public List<float> VibeLimits;
    public List<AudioClip> PTAudios;
    public Movement ball;
    public GameObject Guide;

    private int ExpIdx;
    private List<int> rl;

    public void StartExp(int exidx, int cnt)
    {
        rl = new List<int>();
        for (int i = 0; i < PTAudios.Count; i++)
        {
            int rv = Random.Range(0, PTAudios.Count);
            while (rl.Contains(rv))
            {
                rv = Random.Range(0, PTAudios.Count);
            }
            rl.Add(rv);
        }

        ExpIdx = exidx;

        ball.transform.parent.localPosition = new Vector3(-1.5f, -4.6f, 0);
        ball.transform.parent.gameObject.GetComponent<Rigidbody>().useGravity = false;
        ball.transform.parent.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }

    public void OnDropDownClick(int idx)
    {
        PlayBall(idx);
    }

    public void PlayBall(int idx)
    {
        Guide.SetActive(false);
        ball.transform.parent.gameObject.GetComponent<Rigidbody>().useGravity = true;
        ball.transform.parent.localPosition = new Vector3(-1.5f, -4.6f, 0);
        ball.transform.localPosition = Vector3.zero;
        Time.timeScale = 0.5f;
        ball.speed = ball.initialspeed * VibeSensitivitys[ExpIdx];
        ball.limit = ball.initiallimit * VibeLimits[ExpIdx];
        ball.gameObject.GetComponent<AudioSource>().clip = PTAudios[rl[idx]];
        ball.transform.parent.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
    }
}