using UnityEngine;

public class VertPatrol : MonoBehaviour
{
    [SerializeField] private Transform up;
    [SerializeField] private Transform down;
    [SerializeField] private Transform enemy;
    [SerializeField] private float speed;
    private bool movingDown;

    private void Update()
    {
        if (movingDown)
        {
            if (enemy.position.y >= down.position.y)
            {
                MoveInDirection(-1);
            }
            else
            {
                movingDown = false;
            }
        }
        else
        {
            if (enemy.position.y <= up.position.y)
            {
                MoveInDirection(1);
            }
            else
            {
                movingDown = true;
            }
        }
    }

    private void MoveInDirection(int direction_)
    {
        enemy.position = new Vector3(enemy.position.x, enemy.position.y  + Time.deltaTime * direction_ * speed, enemy.position.z);
    }
}
