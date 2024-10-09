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
    public TextMeshProUGUI txtVida;
    public int municao;
    public TextMeshProUGUI txtmunicao;

    public GameObject municaoObj;
    public float velocidadeMunicao;
    public Transform posicaoMunicao;

    void Start()
    {
        rB = GetComponent<Rigidbody2D>();
        vida = 5;
        municao = 5;
    }

    // Update is called once per frame
    void Update()
    {
        txtVida.text = vida.ToString();

        movH = Input.GetAxisRaw("Horizontal");

        rB.velocity = new Vector2(movH * velocidade, rB.velocity.y);

        if(movH > 0 && verificarDirecao)
        {
            flip();

        }else if(movH < 0 && verificarDirecao == false)
        {
            flip();
        }

        if(Input.GetButtonDown("Jump")&& sensor)
        {
            rB.AddForce(new Vector2(0, jump),ForceMode2D.Impulse);
        }

        if (vida <= 0)
        {
            vida = 0;
        }


        txtmunicao.text = municao.ToString();

        InstanciarMunicao();
    }

    private void InstanciarMunicao()
    {
        if(Input.GetMouseButtonDown(0) && municao > 0)
        {
            GameObject temp = Instantiate(municaoObj, posicaoMunicao.position, Quaternion.identity);
            temp.gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(velocidadeMunicao, 0);
            municao--;
        }
    }
    private void FixedUpdate()
    {
        sensor = Physics2D.OverlapCircle(posSensor.position, 0.3f);
    }

    public void flip()
    {
        verificarDirecao = !verificarDirecao; //verificacar a direcao que o sprite esta olahndo
         
        float x = transform.localScale.x * -1;

        transform.localScale = new Vector3(x,transform.localScale.y,transform.localScale.z);

        velocidadeMunicao *= -1;


    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "MaisVida")
        {
            vida++;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "MenosVida")
        {
            vida++;
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.tag == "RecarMunicao")
        {
            municao++;
            Destroy(collision.gameObject);
        }
    }
}
