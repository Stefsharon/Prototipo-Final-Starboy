using System.Collections;
using UnityEngine;

public class andromaco_clase : MonoBehaviour
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
    void Start()
    {
        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            FreeAndromaco();
        }
    }

    public void FreeAndromaco()
    {
        StartCoroutine(moveAndromaco());
    }

    IEnumerator moveAndromaco()
    {
        animator.SetBool("isWalking", true);

        float fixedY = transform.position.y;

        Vector3 targetPos = new Vector3(endPos.position.x, fixedY, endPos.position.z);

        while(Vector3.Distance(transform.position,targetPos) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
            yield return null;
        }

        animator.SetBool("isWalking", false);
    }
}
