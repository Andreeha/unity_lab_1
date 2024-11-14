using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Transform left;
    [SerializeField] private Transform right;
    [SerializeField] private Transform enemy;
    [SerializeField] private float speed;
    private bool movingLeft;

    private void Update()
    {
        if (movingLeft)
        {
            if (enemy.position.x >= left.position.x)
            {
                MoveInDirection(-1);
            }
            else
            {
                movingLeft = false;
            }
        }
        else
        {
            if (enemy.position.x <= right.position.x)
            {
                MoveInDirection(1);
            }
            else
            {
                movingLeft = true;
            }
        }
    }

    private void MoveInDirection(int direction_)
    {
        enemy.position = new Vector3(enemy.position.x + Time.deltaTime * direction_ * speed, enemy.position.y, enemy.position.z);
    }
}
