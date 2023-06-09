# Gameability
this is a project made by the team "Gli autostoppisti"

### Team members:
> * [Simone Basso](https://github.com/clbsimone)
>    * Leader
> * [Daniele Di Mantua](https://github.com/1Danielozen1)
>    * Hand recognition programmer
> * [Alexander Becchio](https://github.com/SirAlexanderTheFourth)
>    * Supervisor and assistant programmer
> * [Samuele Bruno](https://github.com/SamueleBruno)
>    * Game programmer


## Description
Our project is a simple game where you are presented with cars at an interception, each car has a number on it and an arrow signaling the path it wants to take, you must guide each car trough the interseption following street laws.

## Objective
the objective is to create a dualtask activity where you guide each car through the interception in the right order using hand and arms gestures.
this helps with cognitive abilities and to reabilitate the upper limbs.


## Components:
* [Leap Motion Controller](https://www.ultraleap.com/product/leap-motion-controller/)

## Softwares:
* Blender
* Unity
  * Unity version used: [LTS 2021.3](https://download.unity3d.com/download_unity/6eacc8284459/Windows64EditorInstaller/UnitySetup64-2021.3.0f1.exe)
* Ultraleap Gemini
  * Gemini version used: [5.7.2](https://www2.leapmotion.com/downloads/gemini/v5.7.2)

## Development: 
### Simone Basso
 Using Blender, a 3D modeling software, I created all the 3D models present in the video game. I spent some time studying the   
 program's functions and faced some initial difficulties, as I had never used it before. However, I overcame the obstacles and 
 managed to complete the work within the expected timeframe.
 ![test](/screenshots/IMG-20230331-WA0012.jpg)

### Daniele Di Mantua

I have programmed the system responsible for recognizing the number of open fingers on a hand to control the game.

To determine if a finger is open, I calculate the distance between the outermost point of the finger and the central position of the palm. Then, I add up the number of open fingers to get the total count.

In addition, the system is capable of recognizing hand movements in different directions, such as right, left, up, and down. However, this feature was scrapped during development due to it not seeming optimal for the rehabilitation activity.

The most difficult part of the project was the connection between Leap Motion and Unity, as there were issues between the software version of Leap Motion and that of Unity. Additionally, I had difficulty writing the program because I had to learn a new programming language from scratch, namely C#, even though it was similar to others I had seen before.
![test](/screenshots/Immagine%20WhatsApp%202023-04-12%20ore%2011.07.32.jpg)

### Samuele Bruno

i worked in unity, my job was to combine the objects made in blender to create the game levels and to write the code for the movement of the cars and for the game menu. For the movement of the cars i created a path using waypoints, but it was not that easy because it was the first time i used c#.
i added the objects created in blender in unity and i added physics, adding the gravity on the cars and the boxcolliders on the plane and on the cars, after which i made sure that the cars follow a predefined path according to a pre-established order using waypoints, the waypoints are spheres connected by lines that disappear once the game has started and are useful for me to manually create the path for each machine. I also managed the part of the menus and the various buttons.

 ![test](/screenshots/Immagine%20WhatsApp%202023-03-31%20ore%2013.21.50.jpg)
 
### Alexander Becchio

 in the first part of the project, I coordinated the team, helping with some disagreements among my teammates and maintaining the 
 repository. I was also tasked with researching which movements would be more helpful in the rehabilitation process.
 I didn't find any particular motion, however, I did find a study published in the [Journal of Rehabilitation Medicine](https://medicaljournalssweden.se/jrm) in which it was found that stroke patients who participated in finger counting exercises that required them to raise the correct number of fingers to indicate the number of an object presented on a computer screen showed improvements in upper limb function, as well as improvements in cognitive processing and reaction time.
 
 ![test](/screenshots/IMG-20230404-WA0004.jpg)
 
After that we all came toghether to merge the two parts of the code.
during the merge we encountered some problems

## How to use:

To install Unity, follow these steps:

1. First download the softwares. To do that go to the "Softwares" section and click on the two links.
2. Next, you will need to download the game folder in the "Download" section, click the link, once in google drive downoad the "builds" forlder.
3. once downoaded open the folder and doubble click on "Gameability.exe"


Game controls:

![](/screenshots/instructions.jpg)

## Download:
[download](https://drive.google.com/drive/folders/1SHpTc99wdVFs-dyO5z-79y9GLz2cAsYm?usp=share_link)
