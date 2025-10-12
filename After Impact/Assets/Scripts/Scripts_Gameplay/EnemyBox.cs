using UnityEngine;

public class EnemyBox : MonoBehaviour
{
    [SerializeField] float speed = 5.0f;

    private void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
