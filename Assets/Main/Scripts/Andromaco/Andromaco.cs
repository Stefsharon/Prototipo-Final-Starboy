using System.Collections;
using UnityEngine;

public class Andromaco : MonoBehaviour
{
    Animator animator;

    Transform startPos;
    public Transform endPos;

    public float speed = 5f;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        startPos = transform;
    }


    public void FreeAndromaco()
    {
        StartCoroutine(moveAndromaco());
    }

    IEnumerator moveAndromaco()
    {

        animator.SetBool("IsWalking", true);

        float fixedY = transform.position.y;

        // Target final sin afectar el eje Y
        Vector3 targetPos = new Vector3(endPos.position.x, fixedY, endPos.position.z);

        while (Vector3.Distance(transform.position, targetPos) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * speed);
            yield return null;
        }

        animator.SetBool("IsWalking", false);
    }
}
