using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using TMPro;

public class MovimentosBasicos : MonoBehaviour
{
    public float movH;
    private Rigidbody2D rB;
    public float velocidade;
    public float jump;

    public Transform posSensor;
    public bool sensor;

    public bool verificarDirecao;

    public int vida;
    public GameObject[] vidaImage;

    public int municao;
    public TextMeshProUGUI txtmunicao;

    public GameObject municaoObj;
    public float velocidadeMunicao;
    public Transform posicaoMunicao;

    bool isGO;

    public Animator anim;

    public int pontuacao;
    public TextMeshProUGUI pontuacaoTxt;


    void Start()
    {
        anim = GetComponent<Animator>();
        rB = GetComponent<Rigidbody2D>();
        vida = 3;
        municao = 5;
    }

    // Update is called once per frame
    void Update()
    {
        if (isGO == false)
        {

            movH = Input.GetAxisRaw("Horizontal");

            rB.velocity = new Vector2(movH * velocidade, rB.velocity.y);

            if (movH > 0 && verificarDirecao)
            {
                flip();

            }
            else if (movH < 0 && verificarDirecao == false)
            {
                flip();
            }

            if (Input.GetButtonDown("Jump") && sensor)
            {
                rB.AddForce(new Vector2(0, jump), ForceMode2D.Impulse);
            }

            if (vida <= 0)
            {
                vida = 0;
            }
            anim.SetInteger("Mov", (int)movH);
            InstanciarMunicao();
            MecVida();
        }
        txtmunicao.text = municao.ToString();

        Morte();
        
    }

    private void InstanciarMunicao()
    {
        if (Input.GetMouseButtonDown(0) && municao > 0)
        {
            anim.SetTrigger("Tiro");
            GameObject temp = Instantiate(municaoObj, posicaoMunicao.position, Quaternion.identity);
            temp.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidadeMunicao, 0);
            municao--;

        }
    }
    void MecVida()
    {
        for (int i = 0; i < 5; i++)
        {
            if (vida >= (i + 1))
            {
                vidaImage[i].SetActive(true);
            }
            else
            {
                vidaImage[i].SetActive(false);
            }
        }
    }
    private void FixedUpdate()
    {
        sensor = Physics2D.OverlapCircle(posSensor.position, 0.3f);
    }
    void Morte()
    {
        if(vida <= 0)
        {
            isGO = true;
        }
        if (isGO)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = 1;
        }
    }



    public void flip()
    {
        verificarDirecao = !verificarDirecao; //verificacar a direcao que o sprite esta olahndo

        float x = transform.localScale.x * -1;

        transform.localScale = new Vector3(x, transform.localScale.y, transform.localScale.z);

        velocidadeMunicao *= -1;


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "+vida" && vida <= 5)
        {
            vida++;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "-vida" && vida >= 0)
        {
            vida--;
            Destroy(collision.gameObject);
        }
        
        if (collision.gameObject.tag == "+mun")
        {
            municao++;
            Destroy(collision.gameObject);
        }
        if(collision.tag == "PontCol")
        {

        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "0vida" && vida >= 0)
        {
            vida = 0;

        }
    }
}
