using UnityEngine;

public class Gamemanager : MonoBehaviour
{ 


    [SerializeField]
    private int playerScore;
    public int PlayerScore { get { return playerScore; } set { playerScore = value; } }

    private GameObject[] ballPositions;

    [SerializeField]
    private GameObject ballPrefab;

    public static Gamemanager instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        instance = this;

    }

    // Update is called once per frame
    void Start()
    {
        SetBall(BallColor.Red, 1);
    }

    void Update()
    {

    }

    private void SetBall(BallColor col,int i)
    {
       GameObject obj= Instantiate(ballPrefab, 
            ballPositions[i].transform.position, 
            Quaternion.identity );

        Ball b = obj.GetComponent<Ball>();
        b.SetColorAndPoint(col);
    }
}



