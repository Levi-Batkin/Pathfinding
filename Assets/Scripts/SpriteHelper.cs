using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteHelper : MonoBehaviour
{

    Dir directionX;
    protected MeshRenderer sr;


    private void Awake()
    {
        sr = gameObject.GetComponent<MeshRenderer>();
    }
    private void Start()
    {
    }


    public Dir GetDirection()
    {
        return directionX;
    }

    public void Spawn()
    {

    }

    public void PlayAnimAtFrame(Animator anim, string animName, int totalFrames, int frameToPlay)
    {
        anim.Play(animName, 0, (1f / totalFrames) * frameToPlay);
    }

    public void SetDynamic(Rigidbody2D rb)
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
    }

    public void SetKinematic(Rigidbody2D rb)
    {
        rb.bodyType = RigidbodyType2D.Kinematic;
    }


    public void ZeroVelocity(Rigidbody2D rb)
    {
        rb.velocity = new Vector2(0, 0);
    }







}
