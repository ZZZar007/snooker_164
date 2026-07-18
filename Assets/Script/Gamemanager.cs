using UnityEngine;

public class Gamemanager : MonoBehaviour
{ 


    [SerializeField]
    private int playerScore;
    public int PlayerScore { get { return playerScore; } set { playerScore = value; } }

    public static Gamemanager instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        instance = this;

    }

    // Update is called once per frame
    void Start()
    {

    }

    void Update()
    {

    }
}



