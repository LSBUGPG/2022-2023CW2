using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum MoveDirections
{
    Up,
    Down,
    TopLeft,
    TopRight,
    BottomLeft,
    BottomRight
}
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5;
    [SerializeField] float detectionRadius = 3;
    [SerializeField] LayerMask cardLayer;
    [SerializeField] MapCard startingCard;
    [SerializeField] bool startingAnimation = true;
    List<Collider> detectedCards = new List<Collider>();
    MapCard currentCard;
    Dictionary<MoveDirections, MapCard> mapCardDirs = new Dictionary<MoveDirections, MapCard>();
    float groundOffset;
    bool isMoving = false;
    bool initialDetectionDone = false, detectionDone = false;

    Vector3 nextCardPos;
    Animator anim;
    bool allowControl = false;
    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        if(startingCard == null)
        {
            startingCard = DetectCurrentCard();
        }

        groundOffset = transform.position.y;
        allowControl = !startingAnimation;
        if (!startingAnimation) { DetectCards(); }
        startingCard.FlipCard();
    }

    // Update is called once per frame
    void Update()
    {
        if (startingAnimation)
        {
            if (startingCard.cardFlipped)
            {
                anim.SetTrigger("Spawn");
            }
        }

        if (initialDetectionDone && allowControl)
        {
            if (transform.position.x != nextCardPos.x || transform.position.z != nextCardPos.z)
            {
                MovePlayer(nextCardPos);
            }
            else
            {
                isMoving = false;
                if (!detectionDone)
                {
                    detectionDone = true;
                    DetectCards();
                }
                
            }

            if (Input.GetKeyDown(KeyCode.Q) && !isMoving)
            {
                if (mapCardDirs[MoveDirections.TopLeft].cardFlipped)
                {
                    nextCardPos = mapCardDirs[MoveDirections.TopLeft].transform.position;
                    //Debug.Log("Q Pressed, Next Card Pos: " + nextCardPos);
                }
            }
            if (Input.GetKeyDown(KeyCode.W) && !isMoving)
            {
                if (mapCardDirs[MoveDirections.Up].cardFlipped)
                {
                    nextCardPos = mapCardDirs[MoveDirections.Up].transform.position;
                    //Debug.Log("W Pressed, Next Card Pos: " + nextCardPos);
                }
            }
            if (Input.GetKeyDown(KeyCode.E) && !isMoving)
            {
                if (mapCardDirs[MoveDirections.TopRight].cardFlipped)
                {
                    nextCardPos = mapCardDirs[MoveDirections.TopRight].transform.position;
                    //Debug.Log("E Pressed, Next Card Pos: " + nextCardPos);
                }
            }
            if (Input.GetKeyDown(KeyCode.A) && !isMoving)
            {
                if (mapCardDirs[MoveDirections.BottomLeft].cardFlipped)
                {
                    nextCardPos = mapCardDirs[MoveDirections.BottomLeft].transform.position;
                    //Debug.Log("A Pressed, Next Card Pos: " + nextCardPos);
                }
            }
            if (Input.GetKeyDown(KeyCode.S) && !isMoving)
            {
                if (mapCardDirs[MoveDirections.Down].cardFlipped)
                {
                    nextCardPos = mapCardDirs[MoveDirections.Down].transform.position;
                    //Debug.Log("S Pressed, Next Card Pos: " + nextCardPos);
                }
            }
            if (Input.GetKeyDown(KeyCode.D) && !isMoving)
            {
                if (mapCardDirs[MoveDirections.BottomRight].cardFlipped)
                {
                    nextCardPos = mapCardDirs[MoveDirections.BottomRight].transform.position;
                    //Debug.Log("D Pressed, Next Card Pos: " + nextCardPos);
                }
            }
        }
    }
    public void MovePlayer(Vector3 cardPos)
    {
        isMoving = true;
        detectionDone = false;
        var step = moveSpeed * Time.deltaTime;
        Vector3 offsetPos = new Vector3(cardPos.x, groundOffset, cardPos.z);
        transform.position = Vector3.MoveTowards(transform.position, offsetPos, step);
    }
    public MapCard DetectCurrentCard()
    {
        Ray ray = new Ray(transform.position, -transform.up);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, cardLayer))
        {
            if (hit.transform.TryGetComponent(out MapCard mCard))
            {
                return mCard;
            }
        }
        return null;
    }
    public void DetectCards()
    {
        //Reset current card
        currentCard = null;

        //Detect new current card
        currentCard = DetectCurrentCard();
        //Debug.Log(currentCard.gameObject.name);

        //Detect surrounding cards
        Collider[] tempDetectedCards = Physics.OverlapSphere(transform.position, detectionRadius, cardLayer);
        foreach (Collider col in tempDetectedCards)
        {
            //Debug.Log("Detected card direction (" + col.gameObject.name + "): " + (col.transform.position - transform.position).normalized, col.transform);
        }

        //Clear old detected cards
        detectedCards.Clear();

        //Remove current card from detected surrounding cards
        foreach (Collider card in tempDetectedCards)
        {
            if(card.gameObject != currentCard.gameObject)
            {
                detectedCards.Add(card);
            }
        }

        //Set card positions in dictionary
        mapCardDirs = new Dictionary<MoveDirections, MapCard>();
        foreach (Collider card in detectedCards)
        {
            if((card.transform.position - transform.position).normalized.z > 0)
            {
                if((card.transform.position - transform.position).normalized.x == 0){
                    mapCardDirs.Add(MoveDirections.Up, card.GetComponent<MapCard>());
                }
                else if ((card.transform.position - transform.position).normalized.x > 0)
                {
                    mapCardDirs.Add(MoveDirections.TopRight, card.GetComponent<MapCard>());
                }
                else
                {
                    mapCardDirs.Add(MoveDirections.TopLeft, card.GetComponent<MapCard>());
                }
            }
            else
            {
                if ((card.transform.position - transform.position).normalized.x == 0)
                {
                    mapCardDirs.Add(MoveDirections.Down, card.GetComponent<MapCard>());
                }
                else if ((card.transform.position - transform.position).normalized.x > 0)
                {
                    mapCardDirs.Add(MoveDirections.BottomRight, card.GetComponent<MapCard>());
                }
                else
                {
                    mapCardDirs.Add(MoveDirections.BottomLeft, card.GetComponent<MapCard>());
                }
            }
        }

        if (!initialDetectionDone)
        {
            nextCardPos = currentCard.transform.position;
            initialDetectionDone = true;
        }

        foreach (KeyValuePair<MoveDirections, MapCard> kvp in mapCardDirs)
        {
            kvp.Value.FlipCard();
        }
        //DEBUG
        foreach (KeyValuePair<MoveDirections, MapCard> kvp in mapCardDirs)
        {
            //Debug.Log(kvp);
        }
    }

    public void StartingAnimationDone()
    {
        DetectCards();
        allowControl = true;
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(0, 0, 1, .5f);
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
