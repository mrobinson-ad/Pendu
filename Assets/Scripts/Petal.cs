using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Petal : MonoBehaviour
{
    private SpriteRenderer petalSprite;

    private Transform petalPos;

    Color opaque;

    private Vector3 startPos;

       private Quaternion startRot;

    // Start is called before the first frame update
    void Start()
    {
        petalSprite =GetComponent<SpriteRenderer>();
        petalPos = GetComponent<Transform>();
        opaque = petalSprite.color;
        opaque.a = 1f;
        startPos = petalPos.position;
        startRot = petalPos.rotation;

    }



    public IEnumerator Fade(Vector3 pos, Quaternion rotation, float speed)
    {
        
        Color c = petalSprite.color; // sets c to the color component of the petal targeted
        //petalSprite.sortingOrder = 10; // sends the petal forward in the layer to see the change better
        for (float alpha = 1f; alpha > -0.1; alpha -= 0.1f) // changes the alpha of the petal so it gradually becomes transparent
        {
            c.a = alpha;
            petalSprite.color = c;
            petalPos.SetPositionAndRotation(Vector3.MoveTowards(petalPos.position, pos, speed * Time.fixedDeltaTime), Quaternion.Slerp(petalPos.rotation, rotation, speed * Time.fixedDeltaTime)); // change the position and rotation of the petal to make it fall
                yield return new WaitForSeconds(.1f);
        }
    }

    public void ResetPetal()
    {
        petalSprite.color = opaque;
        petalPos.SetPositionAndRotation(startPos, startRot); 
    }
}
