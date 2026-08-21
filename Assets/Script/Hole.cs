using UnityEngine;

public class Hole : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Ball b = other.GetComponent<Ball>();

        if (b != null)
        {
            Gamemanager.instance.PlayerScore += b.Point;
            Destroy(b.gameObject );
        }
    }
}
