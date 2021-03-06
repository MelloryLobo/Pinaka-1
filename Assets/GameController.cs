﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public int Score;
    public Text scoreText;
    public GameObject GamePaused;
    public GameObject Gameplay;
    public GameObject Menu;
    public GameObject Level;
    public GameObject Confirm;
    public GameObject Close;
    public GameObject Fox;

    public GameObject Dificulty;
    private int Mode;
    private int dialogNum=0;
    public Text txtDialog;
    public Text txtTabu;
    public static int testSucess; // variável auxiliar que testa se o usuário pegou a maçã correta
    public GameObject DialogFox;

    public GameObject btnSoundOn;
    public GameObject btnSoundOff;
    

    public AudioSource SoundPoppyCorn;
    private int testaBotaoPause=0;

    public AudioSource SoundButton;

    public AudioSource btnFail;

    public Text txtErroSelect;
    public static bool sinal;

    public AudioSource Correct;
    public AudioSource Incorrect;

    public int testCorrect;
    public int testIncorrect;

    public AudioSource soundVictory;
    public int finalGame;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 0; // pausa a execução
    }

    // Update is called once per frame
    void Update()
    {
        if(testCorrect == 1){
            Correct.Play();
            testCorrect = 0;
        }
        if(testIncorrect == 1){
            Incorrect.Play();
            testIncorrect = 0;
        }

        if(finalGame == 1){
            soundVictory.Play();
            finalGame = 0;
        }
    }

    //  pausa o jogo
    public void pauseGame(){ // exibe tela de pause
        SoundButton.Play(); 
        Time.timeScale = 0; // pausa a execução
        
        Gameplay.SetActive(false);
        Confirm.SetActive(false);
        GamePaused.SetActive(true);
    }

    
    public void continueGame(){ // despausa o jogo através do menu
        SoundButton.Play();
        Gameplay.SetActive(true);
        GamePaused.SetActive(false);
        Time.timeScale = 1;
    }

    public void mainMenu(){ // exibe menu principal
        Spawn_Fruit.n1 = 0;
        sinal = false;
        SceneManager.LoadScene(0);
    }

    

    public void selectLevel(){ // exibe a seleção da tabuada
        SoundButton.Play();
        Menu.SetActive(false);
        Level.SetActive(true);
    }

    public void selectDificulty(){
        txtErroSelect.text = "Escolha a tabuada desejada";
        if(Spawn_Fruit.tryGameplay == true){
            SoundButton.Play();
            txtTabu.text = "Tabuada do número " + Spawn_Fruit.n1;
            Level.SetActive(false);
            Dificulty.SetActive(true);
        }
        else{
            btnFail.Play();
            txtErroSelect.text = "Não é possível jogar sem escolher uma tabuada!"; //  caso o jogador n escolha uma tabuada
        }
    }

    public void selectTabuada(int num){ // verifica se a tabuada foi escolhida e modifica a tabuada conforme a escolha
        SoundButton.Play();
        Spawn_Fruit.n1 = num;
        sinal = true;
    }

    public void startGame(int Mode){ // inicia o jogo
            SoundButton.Play();
            Menu.SetActive(false);
            Dificulty.SetActive(false);
            Gameplay.SetActive(true);
            Fox.SetActive(true);
            Level.SetActive(false);
            if(Mode==2 || Mode==3){
                Time.timeScale = 1;
            }
            SoundPoppyCorn.Play();

            if(Mode==1){
                DialogFox.SetActive(true);
            }
            if(Mode==3){
                Fruit.speed = 2F;
                Fruit2.speed = 2F;
                Fruit3.speed = 2F; 
                TextMove.speed = 182F; 
            }
    }

    public void dialogText(){
        SoundButton.Play();
        if(dialogNum<3){
            if(dialogNum==0){
                txtDialog.text = "Eu tô com fome, que tal me ajudar a comer algumas maçãs? Mova a raposa para cima e para baixo com o seu dedo.";
            }
            if(dialogNum==1){
                txtDialog.text = "Pegue as maçãs que possuem a resposta para a tabuada que vai aparecer em cima para fazer pontos!";
            }
            if(dialogNum==2){
                txtDialog.text = "Eu sei que você consegue, coleguinha. Vamos lá!";
            }
            dialogNum = dialogNum+1;
        }else{
            DialogFox.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void ConfirmToMenu(){ // exibe tela de confirmação para o menu
        SoundButton.Play();
        GamePaused.SetActive(false);
        Confirm.SetActive(true);
    }

    public void CloseMenu(){ // exibe tela de confirmação pra sair do jogo 
        SoundButton.Play();
        Menu.SetActive(false);
        Close.SetActive(true);
    }

    public void quitGame(){ // sai do jogo
        SoundButton.Play();
        Application.Quit();
    }

    public void SoundOnOff(){ //  liga e desliga o som do jogo
        if(testaBotaoPause%2==0){
            SoundButton.Play();
            SoundPoppyCorn.Pause();
            btnSoundOn.SetActive(false);
            btnSoundOff.SetActive(true);
        }else{
            SoundButton.Play();
            SoundPoppyCorn.Play();
            btnSoundOff.SetActive(false);
            btnSoundOn.SetActive(true); 
        }
        testaBotaoPause = testaBotaoPause+1;
    }
}
