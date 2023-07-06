using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class AIController : MonoBehaviour
{
    public int CurrentCheckpoint;
    public int CurrentLap;
    public float Speed;
    public Transform target;
    public float rotationSpeed = 10f;

    public float rotationThreshold = 5f;
    private NavMeshAgent agent;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }
    public void IncrementCheckpoint(int n)
    {
        if(CurrentCheckpoint==n)
        CheckPointManager.instance.AiCheckPointReached(this);
    }
    private void Update()
    {
        if (GameManager.instance.State != GameState.Running)
            return;

        agent.speed = UnityEngine.Random.RandomRange(7, 12);


        // Set the destination of the NavMeshAgent to the target position
        agent.SetDestination(target.position);
        // Get the desired velocity of the NavMeshAgent
        Vector3 desiredVelocity = agent.desiredVelocity;

        // Calculate the rotation towards the desired velocity
        Quaternion targetRotation = Quaternion.LookRotation(desiredVelocity);

        //// Rotate towards the desired velocity
        //if (Quaternion.Angle(transform.rotation, targetRotation) > rotationThreshold)
        //{
        //    transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        //}
    }
}
