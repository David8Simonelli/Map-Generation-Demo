using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FormBlock : MonoBehaviour {

    private bool formed = false;
    private bool upCheck;
    private bool rightCheck;
    private bool leftCheck;
    private Vector3 myLocation;

    public Sprite leftCliff; // Something Right
    public Sprite leftEdge; // Something Above and Right
    public Sprite rightCliff; // Something Left
    public Sprite rightEdge; // Something Above and Left
    public Sprite plainGrass; // Something Left and Right
    public Sprite pillar; // Nothing detected

    public SpriteRenderer thisBlockSprite;

    private void Start() {
        myLocation = transform.position;
    }

    // Update is called once per frame
    void Update () {
        if (MapGenerator.done == true && formed == false) {
            formed = true;
            Vector2 right = transform.position;
            Vector2 left = transform.position;
            Vector2 up = transform.position;
            right.x += 1;
            left.x -= 1;
            up.y += 1;
            if (CheckLocation(left)) {
                leftCheck = true;
            }
            if (CheckLocation(right)) {
                rightCheck = true;
            }
            if (CheckLocation(up)) {
                upCheck = true;
            }

            if(!upCheck && !leftCheck && !rightCheck) {
                thisBlockSprite.sprite = pillar; // Nothing detected
            } else if(!upCheck && leftCheck && rightCheck) {
                thisBlockSprite.sprite = plainGrass; // Something Left and Right
            } else if(upCheck && leftCheck && !rightCheck) {
                thisBlockSprite.sprite = rightEdge; // Something Above and Left
            } else if(!upCheck && leftCheck && !rightCheck) {
                thisBlockSprite.sprite = rightCliff; // Something Left
            } else if(upCheck && !leftCheck && rightCheck) {
                thisBlockSprite.sprite = leftEdge; // Something Above and Right
            } else if(!upCheck && !leftCheck && rightCheck) {
                thisBlockSprite.sprite = leftCliff; // Something Right
            }

            Debug.Log(CheckLocation(myLocation));
        }
	}

    public bool CheckLocation(Vector2 center) {
        float radius = .3f;
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(center, radius);
        int i = 0;
        Debug.Log (hitColliders.Length);
        if (i < hitColliders.Length) {
            return (true);
        } else {
            return (false);
        }
    }

    private void OnDrawGizmos () {
        Gizmos.color = Color.red;
     //Use the same vars you use to draw your Overlap SPhere to draw your Wire Sphere.
        Gizmos.DrawWireSphere(transform.position, .3f);
    }
}
