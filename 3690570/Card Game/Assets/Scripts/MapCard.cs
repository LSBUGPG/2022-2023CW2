using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapCard : MonoBehaviour
{
    public GameObject spawnOnFlip;
    public bool cardFlipped { get; private set; } = false;
    Animator anim;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    public void FlipCard()
    {
        anim.SetTrigger("Flip");
    }
    public void CardFlipAnimDone()
    {
        cardFlipped = true;
        if(spawnOnFlip != null)
        {
            Instantiate(spawnOnFlip, transform.position, Quaternion.identity);
        }
    }
}
