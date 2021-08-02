# Knight's Adventure

Knight's Adventure is 2D side-scroller platformer game made with Unity for PC 

This game is a project I made to learn a new technology and improve myself during my IT internship in 2021. In this first serious game I designed using the Unity game engine, Sprite Sheets are taken from open source sources from the internet, but there is no problem for personal use.

# Table of Contents
<details open>
<summary><b>(Click to Expand or Hide)</b></summary>
<!-- MarkdownTOC -->

1. [Opening/Title Screen](#opening-screen)
    1. [Language Screen](#language-screen)
    1. [Key Bindings Screen](#key-bindings)
1. [Main Character](#main-character)
    1. [Anim Cycle](#anim-cycle)
1. [Level - 1](#level-1)
    1. [Enemy Objects at Level - 1](#enemy-objects-1)
1. [Level - 2](#level-2)
    1. [Enemy Objects at Level - 2](#enemy-objects-2)
1. [HUD](#hud)
    1. [Paused Screen](#paused-screen)
    1. [Health Bar](#health-bar)
    1. [Coin Canvas](#coin-canvas)
1. [Collectibles](#collectibles)
    1. [Coin](#coin)
    1. [Health Potion](#health-potion)
1. [Camera Follow System](#camera)
1. [Contact](#contact)
  
<!-- /MarkdownTOC -->
</details>


<a id="opening-screen"></a>
# Opening/Title Screen

<img src=img/opening-screen.png><br>


<a id="language-screen"></a>
## Language Screen

<img src=img/language.png width=600 height=600><br>
There are 2 language options in the game, one of them is Turkish and the other is English. The language is changed instantly when the buttons are clicked. The system I use for this localization process is [Lean Localization](https://assetstore.unity.com/packages/tools/localization/lean-localization-28504).


<a id="key-bindings"></a>
## Key Bindings

<img src=img/key-bindings.png width=600 height=600><br>


<a id="main-character"></a>
# Main Character

<img src=img/main-character.png><br>


<a id="anim-cycle"></a>
## Anim Cycle

<img src=img/anim-cycle.png><br>


<a id="level-1"></a>
# Level - 1

<img src=img/level-1.png><br>


<a id="enemy-objects-1"></a>
## Enemy Objects at Level - 1

<div style="float: left"><img src=img/flower-enemy.png width=155/>&emsp;<img src=img/slime-monster.png height=195/>&emsp;<img src=img/spikes.png height=195/>&emsp;<img src=img/cactus.png height=195/></div> 


<a id="level-2"></a>
# Level - 2

<img src=img/level-2.png><br>


<a id="enemy-objects-2"></a>
## Enemy Objects at Level - 2

<div style="float: left"><img src=img/worm-enemy.png width=155/>&emsp;<img src=img/spike-worm.png height=189/>&emsp;<img src=img/wooden-spike.png height=189/></div>


<a id="hud"></a>
# HUD

There are 3 elements on the screen as the HUD Screen. These are Pause Button, Health Bar and Coin Canvas.


<a id="paused-screen"></a>
## Paused Screen

<img src=img/paused.png><br>
Resume, Restart and Exit operations can be performed in this menu that opens when the Pause Button is clicked.
```C#
 public void RestartGame(){
      Scene scene = SceneManager.GetActiveScene();
      SceneManager.LoadScene(scene.name);
      Time.timeScale = 1.0f;
 }

public void PauseGame(){
    isGamePaused = !isGamePaused;

    if (isGamePaused == true){
        Time.timeScale = 0.0f;
        pauseGame.SetActive(true);
    }
    else{
        Time.timeScale = 1.0f;
        pauseGame.SetActive(false);
    }     
}

public void ExitGame(){
    SceneManager.LoadScene("Scenes/OpeningScene");
    Time.timeScale = 1.0f;
}

```

<a id="health-bar"></a>
## Health Bar

<img src=img/health-bar.png><br>
The area where the health status of our character is displayed on the screen.

```C#
  void UpdateUI(){
      healthBar.value = player.currentPlayerHealth;
      if (player.currentPlayerHealth <= 0)
          healthBar.minValue = 0;
  }

```


<a id="coin-canvas"></a>
## Coin Canvas

<img src=img/coin-canvas.png><br>
The area where the amount of coin collected by our character is displayed on the screen.


<a id="collectibles"></a>
# Collectibles

There are 2 collectible objects in the game. These are coin and health potions.


<a id="coin"></a>
## Coin

<img src=img/coin.png><br>
The coin found at different points in the game, instead of appearing on the screen in a fixed way, has a more pleasant appearance by making a rotation animation around itself.


<a id="health-potion"></a>
## Health Potion

<img src=img/health-potion.png><br>
This object, which helps to increase the health of our character, can be found in various parts of the game.

```C#
  void BoostHealth(){
      if (addHealth)
      {
          currentPlayerHealth += giveHealth.health;
          addHealth = false;
          audioSource.PlayOneShot(audioHealth);
      }
  }

```
    

<a id="camera"></a>
## Camera Follow System

I used a package called [Cinemachine](https://docs.unity3d.com/Packages/com.unity.cinemachine@2.1/manual/index.html) for our character to be followed by the camera.


----

### Information

>    Batuhan Demiray
>    <p>Pamukkale University - Computer Engineering

<a id="contact"></a>
Contact Me on [Linkedin](https://www.linkedin.com/in/batuhan-demiray-90b85b1b7/) | [Facebook](https://www.facebook.com/batuhan.demiray)
