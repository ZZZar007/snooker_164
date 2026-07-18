using UnityEngine;

public class Test : MonoBehaviour
{
    private int n = 0;
    private float timer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        Debug.Log("Awake");
    }

    // Update is called once per frame
    void Start()
    {
        Debug.Log("Start");
    }

    void Update()
    {
        timer += Time.deltaTime;

        n++;

        if (timer >=1f)
        {
            Debug.Log(n);
            timer=0f;
            n = 0;
        }
    }
}
