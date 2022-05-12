using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PlayerState
{
    Run,Jump,D_Jump,Death
}
public class Player_Ctrl : MonoBehaviour
{
    public PlayerState PS;
    public float Jump_Power = 500f;
    public AudioClip[] Sound;
    public Animator animator;
    public GameObject AnotherSpeaker;

    public GameManager GM;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && PS != PlayerState.Death) 
        {
        if(PS == PlayerState.Jump)
            {
                D_Jump();
            }
        if(PS == PlayerState.Run)
            {
                Jump();
            }
        }


        if(Input.touchCount > 0)
        {
            if(Input.GetTouch(0).phase == TouchPhase.Began)
            {

                if (PS == PlayerState.Jump)
                {
                    D_Jump();
                }
                if (PS == PlayerState.Run)
                {
                    Jump();
                }
            }
        }

    }
    void Jump()
    {
        PS = PlayerState.Jump;
        GetComponent<Rigidbody>().AddForce(new Vector3(0, Jump_Power, 0));
        //SoundPlay(2);
        AnotherSpeaker.SendMessage("SoundPlay");

        animator.SetTrigger("Jump");
        animator.SetBool("Ground", false);
    }

    void D_Jump()
    {
        PS = PlayerState.D_Jump;
        GetComponent<Rigidbody>().AddForce(new Vector3(0, Jump_Power, 0));
        //SoundPlay(2);
        AnotherSpeaker.SendMessage("SoundPlay");

        animator.SetTrigger("D_Jump");
        animator.SetBool("Ground", false);
    }

    void Run()
    {
        PS = PlayerState.Run;
        animator.SetBool("Ground", true);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(PS != PlayerState.Run && PS != PlayerState.Death)
        {
            Run();
        }
    }


    void CoinGet()
    {
        SoundPlay(0);
        if(GM != null)
        {
            GM.CoinGet();
        }
    }

    void GameOver()
    {
        PS = PlayerState.Death;
        SoundPlay(1);
        GM.GameOver();
    }

    void SoundPlay(int Num)
    {
        GetComponent<AudioSource>().clip = Sound[Num];
        GetComponent<AudioSource>().Play();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "coin")
        {
            Destroy(other.gameObject);
            CoinGet();
        }

        if(other.gameObject.name == "DeathZone" && PS != PlayerState.Death)
        {
            GameOver();
        }
       
    }

}
