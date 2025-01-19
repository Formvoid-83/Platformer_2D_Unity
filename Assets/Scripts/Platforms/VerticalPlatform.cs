using System.Collections;
using UnityEngine;

public class VerticalPlatform : MonoBehaviour
{
    [SerializeField] private Transform[] points; // References to the child objects
    [SerializeField] private float speed = 5f;

    private Vector3[] targetPositions; // Store the original positions
    private Vector3 currentDestiny;
    private int currentIndex;

    void Start()
    {
        // Store the original positions of the points
        targetPositions = new Vector3[points.Length];
        for (int i = 0; i < points.Length; i++)
        {
            targetPositions[i] = points[i].position;
        }

        currentIndex = 0;
        currentDestiny = targetPositions[currentIndex];
        StartCoroutine(Move());
    }

    IEnumerator Move()
    {
        while (true)
        {
            while (Vector3.Distance(transform.position, currentDestiny) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, currentDestiny, speed * Time.deltaTime);
                yield return null;
            }

            // Snap to the target position
            transform.position = currentDestiny;

            DefineNewDestiny();
            yield return null;
        }
    }

    private void DefineNewDestiny()
    {
        currentIndex++;
        if (currentIndex >= targetPositions.Length)
        {
            currentIndex = 0; // Loop back to the first point
        }
        currentDestiny = targetPositions[currentIndex];
    }

    private void OnDrawGizmos()
    {
        // Optional: Draw lines between the points in the editor
        if (points == null || points.Length < 2) return;

        Gizmos.color = Color.red;
        for (int i = 0; i < points.Length - 1; i++)
        {
            Gizmos.DrawLine(points[i].position, points[i + 1].position);
        }
    }
}
