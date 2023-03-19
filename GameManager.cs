using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public GameObject gameOver;
    public GameObject victoryPanel;
    public GameObject beforeAttackPanel;

    public AudioSource eatingSoundSource;
    public AudioSource attackSoundSource;
    public AudioSource spawnWarriorSource;
    public AudioSource spawnPeasantSource;

    public AudioClip attackSound;
    public AudioClip eatingSound;
    public AudioClip spawnWarrior;
    public AudioClip spawnPeasant;


    public ImageTimer harvestTimer;
    public ImageTimer eatingTimer;
    public ImageTimer enemyTimer;

    public Image peasantTimerImg;
    public Image warriorTimerImg;
    public Image enemyTimerImg;

    public Text resourceText;
    public Text beforeAttackText;
    public Text enemysCountText;
    public Text resultGameOver;
    public Text resultWinGame;

    public Button buyPeasantButton;
    public Button buyWarriorButton;
    public Button restarGame;

    
   

    public int raidIncrease;
    public int nextRaid;
    public int raidMaxTime;
    public int numbersOfRaids = 1;
    public int beforeAttackRound = 3;
    public int peasantCost;
    public int peasantCount;
    public int sumOfPeasant = 3;

    public int warriorCost;
    public int warriorCount;
    public int sumOfWarriors = 0;

    public int wheatCount;
    public int wheatPerPeasant;
    public int wheatPerWarriors;
    public int sumOfWheat;
   
   

    public float createPeasantTime;
    public float createWarriorTime;
    public float raidTimer;
    private float peasantTimer = -2;
    private float warriorTimer = -2;




    void Start()
    {
        UpdateText();
        raidTimer = raidMaxTime;
        enemysCountText.text = nextRaid.ToString();
        beforeAttackText.text = beforeAttackRound.ToString();
        

    }

 
    void Update()
    {

        raidTimer -= Time.deltaTime;
        enemyTimerImg.fillAmount = raidTimer / raidMaxTime;

     

        if (beforeAttackRound < 1)
        {
            beforeAttackPanel.SetActive(false);
        }
      
        if (raidTimer <= 0)
        {
            raidTimer = raidMaxTime;
            warriorCount -= nextRaid;
            if (beforeAttackRound <= 1)
            {
            nextRaid += raidIncrease;
            }
            enemysCountText.text = nextRaid.ToString();
            numbersOfRaids += 1;
            attackSoundSource.PlayOneShot(attackSound);
            beforeAttackRound -= 1;
            beforeAttackText.text = beforeAttackRound.ToString();

            if (warriorCount <= -1)
            {
                gameOver.SetActive(true);
                
                sumOfWheat = wheatCount + (sumOfPeasant * 3) + (sumOfWarriors * 5);
                resultGameOver.text = (sumOfPeasant + "\n" + sumOfWarriors + "\n" + sumOfWheat).ToString();
            }

        }



      if (harvestTimer.tick)
        {
            wheatCount += peasantCount * wheatPerPeasant;
            eatingSoundSource.PlayOneShot(eatingSound);
        }

      if (eatingTimer.tick)
        {
            wheatCount -= warriorCount * wheatPerWarriors; 
        }

        UpdateText();

       

        if (peasantTimer > 0)
        {
            peasantTimer -= Time.deltaTime;
            peasantTimerImg.fillAmount = peasantTimer / createPeasantTime;
        }
        else if (peasantTimer > -1)
        {
            spawnPeasantSource.PlayOneShot(spawnPeasant);
            peasantTimerImg.fillAmount = 1;
            buyPeasantButton.interactable = true;
            peasantCount += 1;
            peasantTimer = -2;
           
        }



        if (warriorTimer > 0)
        {
            warriorTimer -= Time.deltaTime;
            warriorTimerImg.fillAmount = warriorTimer / createWarriorTime;
        }
        else if (warriorTimer > -1)
        {
            spawnWarriorSource.PlayOneShot(spawnWarrior);
            warriorTimerImg.fillAmount = 1;
            buyWarriorButton.interactable = true;
            warriorCount += 1;
            warriorTimer = -2;
        }

        if (wheatCount < 3)
        {
            buyPeasantButton.interactable = false;
            buyWarriorButton.interactable = false;
        }
        else if (warriorTimer == -2)
        {
            buyWarriorButton.interactable = true;
        }

        if (wheatCount < 3)
        {
            buyPeasantButton.interactable = false;
            buyWarriorButton.interactable = false;
        }
        else if (peasantTimer == -2)
        {
            buyPeasantButton.interactable = true;
        }

        if (peasantCount >= 100 || wheatCount >= 2000)
        {
            victoryPanel.SetActive(true);
            resultWinGame.text = (sumOfPeasant + "\n" + sumOfWarriors + "\n" + wheatCount).ToString();
            Time.timeScale = 0;
        }
        if (wheatCount < 0)
        {
            gameOver.SetActive(true);
        }

    }
    
    private void UpdateText()
    {
        resourceText.text = wheatCount + "\n\n" + peasantCount + "\n" + warriorCount;
    }

    public void BuyPeasantButton()
    {
        wheatCount -= peasantCost;
        peasantTimer = createPeasantTime;
        buyPeasantButton.interactable = false;
        sumOfPeasant += 1;
       

    }

    public void BuyWarriorButton()
    {
        wheatCount -= warriorCost;
        warriorTimer = createWarriorTime;
        buyWarriorButton.interactable = false;
        sumOfWarriors += 1;
       

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

  
}

