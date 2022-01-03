# Computer Vision With Unity
 
 ## Description
This is Computer Vision With Unity, a personal winter break project I built over the course of a few days. Using OpenCV, Mediapipe, and a UDP Client, the project utilizes a python script capable of identifying a user's hand gestures to navigate a randomly organized obstacle track in Unity. The project is quite simple, as my main focus was on learning how to utilize UDP and OpenCV.

Use of the program REQUIRES a webcam.

The program references code from the following sources:

https://www.raywenderlich.com/5475-introduction-to-using-opencv-with-unity

## Features

### Basic Program Functionality

https://user-images.githubusercontent.com/70977089/147899739-d910ff97-7921-4744-bafe-23d8b64eaec8.mp4

## Guide


### Movement

1.) The user closes their fist to move the cube right.
2.) The user opens their palm to move the cube left. 
3.) The user holds a single finger up to stop the cube.

### To run

1.) Install python 3.7.9

2.) Activate the virtual environment in Computer Vision Movement\Computer-Vision-With-Unity\Builds\1.0\HandTrackingProject\HandTracking3.7.9

3.) Run HandRecognition.py in Movement\Computer-Vision-With-Unity\Builds\1.0\HandTrackingProject\src

4.) Run Computer Vision Movement.exe in Computer Vision Movement\Computer-Vision-With-Unity\Builds\1.0\Unity

## Known Issues

1.) Cube movement is choppy. No major impact on gameplay, but is displeasing. Will implement a fix for this eventually
2.) If you launch the Unity .exe file with a visible to your webcam, it may spawn the cube out of bounds. 
