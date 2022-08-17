using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;



public class PlayerEverything : MonoBehaviour
{

    public Transform GroundCheck; // Put the prefab of the ground here

    public LayerMask groundLayerBlue; // Insert the layer here.
    public LayerMask groundLayerPurple;
    public bool isGroundedBlue;
    public bool isGroundedPurple;
    public Rigidbody2D rb2D;
    public float jumpTimer;
    public bool isGrounded;
    public Transform groundCheck;
    public LayerMask groundLayer;
    public bool isDead = false;
    public Die diescript;
    public ParticleSystem StartEffect;

    public float jumpForceMagnitutde;

    public float rotationmagnitude;

    public float dieTimer = 3.1f;

    public TextMeshProUGUI TimerText;
    public TextMeshProUGUI gameScoreImpressionText;


    private float Speed;

    public ParticleSystem DestructionEffect;
    public bool isPlayerDead;


    public string[] gamescoreimpressions = new string[] { "NICE!", "WOW!", "PERFECT!", "EXCELLENT!" };
    public string[] gamescoreImpressionsSecond = new string[] { "GODLIKE!!", "FABULOUS!", "LEGENDARY!!", "!FLAWLESS" };

    private string pickImpression;
    private string pickImpression2;

    public GameObject ScoreImpressionObject;
    public Animator TimerAnimationObject;

    public GameObject SceneTransitionAnimation;


    [SerializeField] SpriteRenderer playerImage;

    public CharacterShopUI characterShopUI;

    public SwitchToggle switchToggle;

    public AdShower adShower;

    public CoinPicker CoinPicker;

   
    // Start is called before the first frame update
    public void Start()
    {

        //GameDataManager.RemovePurchasedCharacter(10);


        if (PlayerPrefs.GetFloat("tutorial") == 1)
        {
            Time.timeScale = 1f;
        }

        switchToggle.GetComponent<SwitchToggle>();
        
    

        rb2D = GetComponent<Rigidbody2D>();
        diescript = GameObject.Find("Player").GetComponent<Die>();
        CoinPicker = GetComponent<CoinPicker>();
        IsPlayerDead();

        

    }
    public void Awake()
    {
        
        if (PlayerPrefs.GetInt("toggleplayerpref") == 0)
        {

            AudioListener.pause = false;
        }
        else
        {

            AudioListener.pause = true;

        }

        characterShopUI.SetSelectedCharacter();

    }
    public void ChangePlayerSkin()
    {
        Character character = GameDataManager.GetSelectedCharacter();

        if (character.image != null)
        {
            
            playerImage.sprite = character.image;

        }
    }

    // Update is called once per frame
    public void Update()
    {
        

        isGroundedBlue = Physics2D.OverlapCircle(GroundCheck.position, 1f, groundLayerBlue);
        if (isGroundedBlue)
        {
            
            transform.position += Vector3.right / 60;
        }

        if (!isGrounded)
        {
            dieTimer = 3.1f;

            System.Random random = new System.Random();
            int gameScoreImpressionNumber = random.Next(gamescoreimpressions.Length);
            pickImpression = gamescoreimpressions[gameScoreImpressionNumber];
            System.Random random2 = new System.Random();
            int gameScoreImpressionNumber2 = random2.Next(gamescoreImpressionsSecond.Length);
            pickImpression2 = gamescoreImpressionsSecond[gameScoreImpressionNumber2];
        }
        if (isGrounded && PauseMenu.GameIsPaused == false)
        {



            dieTimer -= Time.deltaTime;
            TimerText.text = dieTimer.ToString("f1") + "0";
            if (dieTimer <= 2.00f && dieTimer > 1.10f)
            {
                gameScoreImpressionText.fontSize = 36;
                gameScoreImpressionText.text = pickImpression;
                ScoreImpressionObject.GetComponent<Animator>().Play("ScoreImpressionAnimation", -1, 0.0f);





            }
            if (dieTimer <= 1.00f && dieTimer > 0.10f)
            {
                gameScoreImpressionText.fontSize = 42;
                gameScoreImpressionText.text = pickImpression2;

                ScoreImpressionObject.GetComponent<Animator>().Play("ScoreImpressionAnimation", -1, 0.0f);
                TimerAnimationObject.SetBool("TimerBool", true);


            }
            else if (dieTimer > 1.00f)
            {
                TimerAnimationObject.SetBool("TimerBool", false);
            }
            if (dieTimer <= 0)
            {

                
                SoundMangerScript.PlaySound("lavadie");
                //Instantiate our one-off particle system

                ParticleSystem explosionEffect = Instantiate(DestructionEffect)
                                            as ParticleSystem;
                explosionEffect.transform.position = transform.position;
                //play it
                explosionEffect.loop = false;
                explosionEffect.Play();
                Destroy(explosionEffect.gameObject, explosionEffect.duration);
                //destroy the particle system when its duration is up, right
                //it would play a second time.

                //destroy our game object

                SoundMangerScript.PlaySound("Die");
                Destroy(GameObject.FindGameObjectWithTag("Player"));
                isPlayerDead = true;



            }


            if (Input.GetKey(KeyCode.Mouse0))
            {
                jumpTimer += Time.deltaTime;


            }
            if (Input.GetKeyUp(KeyCode.Mouse0))
            {

            
                DoJump(350f * jumpTimer);
                jumpTimer = 0;
                SoundMangerScript.PlaySound("Jump");
            }


        }



    }

    public void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 1f, groundLayer);

        Speed = 1;
        rb2D.AddTorque(Speed, ForceMode2D.Force);
    }


    public void DoJump(float JumpForce)
    {
         jumpForceMagnitutde = Mathf.Clamp(JumpForce / 3, 0, 50);
        
            rb2D.AddForce(Vector2.up * jumpForceMagnitutde / 2.7f, ForceMode2D.Impulse);
            rb2D.AddForce(Vector2.right * jumpForceMagnitutde / 7, ForceMode2D.Impulse);

       

        



    }


    public void IsPlayerDead()
    {

        if (diescript.isPlayerDead == true)
        {
            SoundMangerScript.PlaySound("lavadie");
            isDead = true;
        }

    }



}
