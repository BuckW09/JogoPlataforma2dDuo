using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class botoes : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IrParaJogar()
    {
        SceneManager.LoadScene(1);
    }

    public void IrParaInicio()
    {
        SceneManager.LoadScene(0);
    }

    public void sair()
    {
        Application.Quit();
    }
}
