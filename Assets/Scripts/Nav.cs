using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.AI;

public class Nav : MonoBehaviour
{
    public Animator animator;

    private NavMeshAgent agent;
    private GameObject destination;
    
    Vector2 movement;


    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        agent.SetDestination(mousePos);

        movement.x = agent.velocity.normalized.x;
        movement.y = agent.velocity.normalized.y;

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
    }

}
