using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceRoll : MonoBehaviour
{
    // Constants.
    private int numBounces = 3;
    private float timePerVerticalTravel = 0.25f;
    private float maxBounceHeightRatio = 0.8f;
    private float minBounceHeightRatio = 0.4f;

    // Randomed constants for variations in animation.
    private float rotateDegreesPerSecond;
    private float horizontalDistancePerSecond;
    private float startingBounceHeight;

    private enum DiceRollState {
        FallingDown,
        FlyingUp,
        Stopped
    }
    private DiceRollState diceRollState;

    public int FaceNumber { get; set; }
    
    private int numRemainingVerticalTravel;
    private float totalAnimationTime;
    private float timer;
    private float verticalTravelTimer;
    private float currentBounceHeight;

    private Vector3 localPositionStart;
    private Vector3 localPositionEnd;
    private Quaternion localRotationStart;
    private Quaternion localRotationEnd;

    // Start is called before the first frame update
    void Start()
    {
        rotateDegreesPerSecond = Random.Range(500.0f, 1000.0f);
        horizontalDistancePerSecond = Random.Range(5.0f, 10.0f);
        startingBounceHeight = Random.Range(5.0f, 10.0f);
        
        numRemainingVerticalTravel = numBounces * 2 + 1; // down up down up ... down
        totalAnimationTime = numRemainingVerticalTravel * timePerVerticalTravel;
        timer = 0.0f;
        verticalTravelTimer = 0.0f;
        currentBounceHeight = startingBounceHeight;

        // End position is local to parent at zeroes. Work backwards to find starting position.
        localPositionStart = new Vector3(-horizontalDistancePerSecond * numRemainingVerticalTravel * timePerVerticalTravel, currentBounceHeight, 0);
        localPositionEnd = new Vector3(-horizontalDistancePerSecond * (numRemainingVerticalTravel-1) * timePerVerticalTravel, 0, 0);
        localRotationStart = Quaternion.Euler(0, 0, rotateDegreesPerSecond * totalAnimationTime);
        localRotationEnd = Quaternion.identity;
        
        gameObject.transform.localPosition = localPositionStart;
        gameObject.transform.localRotation = localRotationStart;

        diceRollState = DiceRollState.FallingDown;
        FaceNumber = Random.Range(1, 7);
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        verticalTravelTimer += Time.deltaTime;

        gameObject.transform.localPosition = Vector3.Lerp(localPositionStart, localPositionEnd, Mathf.Min(1, verticalTravelTimer / timePerVerticalTravel));
        gameObject.transform.localRotation = Quaternion.Lerp(localRotationStart, localRotationEnd, Mathf.Min(1, timer / totalAnimationTime));

        if (verticalTravelTimer >= timePerVerticalTravel) {
            verticalTravelTimer -= timePerVerticalTravel;
            FlipVerticalTravel();
        }
    }

    void FlipVerticalTravel() {
        numRemainingVerticalTravel--;
        if (diceRollState == DiceRollState.FallingDown) {
            FaceNumber = Random.Range(1, 7);
            if (numRemainingVerticalTravel == 0) {
                FinishAnimations();
            } else {
                diceRollState = DiceRollState.FlyingUp;
                currentBounceHeight = Random.Range(currentBounceHeight * minBounceHeightRatio, currentBounceHeight * maxBounceHeightRatio);
                localPositionStart = new Vector3(-horizontalDistancePerSecond * numRemainingVerticalTravel * timePerVerticalTravel, 0, 0);
                localPositionEnd = new Vector3(-horizontalDistancePerSecond * (numRemainingVerticalTravel-1) * timePerVerticalTravel, currentBounceHeight, 0);
            }
        } else if (diceRollState == DiceRollState.FlyingUp) {
            diceRollState = DiceRollState.FallingDown;
            localPositionStart = new Vector3(-horizontalDistancePerSecond * numRemainingVerticalTravel * timePerVerticalTravel, currentBounceHeight, 0);
            localPositionEnd = new Vector3(-horizontalDistancePerSecond * (numRemainingVerticalTravel-1) * timePerVerticalTravel, 0, 0);
        }
    }

    void FinishAnimations() {
        diceRollState = DiceRollState.Stopped;
        this.enabled = false;
        gameObject.transform.localPosition = localPositionEnd;
        gameObject.transform.localRotation = localRotationEnd;
    }
}
