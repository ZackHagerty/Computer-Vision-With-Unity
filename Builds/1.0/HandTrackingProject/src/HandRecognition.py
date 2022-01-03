import cv2
import mediapipe as mp
import time
import socket



UDP_IP = "127.0.0.1"
UDP_PORT = 5065

sock = socket.socket(socket.AF_INET, socket.SOCK_DGRAM)



def findPosition(img, handNo= 0):
        
        lmList = []
        if results.multi_hand_landmarks:

            myHand = results.multi_hand_landmarks[handNo]

            for id, lm in enumerate(myHand.landmark):
                    height, width, channel = img.shape
                    centerX, centerY = int(lm.x * width), int(lm.y * height)
                    lmList.append([id, centerX, centerY])
                    
        return lmList



cap = cv2.VideoCapture(0)

mpHands = mp.solutions.hands
hands = mpHands.Hands()
mpDraw = mp.solutions.drawing_utils

tipIds = [4, 8, 12, 16, 20]

while True:
    success, img = cap.read()
    imgRGB = cv2.cvtColor(img, cv2.COLOR_BGR2RGB)
    results = hands.process(imgRGB)

    # print(results.multi_hand_landmarks)

    if results.multi_hand_landmarks:
        for handLms in results.multi_hand_landmarks:
            
            mpDraw.draw_landmarks(img, handLms, mpHands.HAND_CONNECTIONS)

    lmList = findPosition(img)
    


    if len(lmList) != 0:
        fingers = []

        if lmList[tipIds[0]][1] > lmList[tipIds[0]- 1][1]:
            fingers.append(1)
        else:
            fingers.append(0)


        for id in range(1, 5):

            if lmList[tipIds[id]][2] < lmList[tipIds[id]- 2][2]:
                fingers.append(1)
            else:
                fingers.append(0)

        print(fingers.count(1))

        if fingers.count(1) == 0:
            sock.sendto( ("Left").encode(), (UDP_IP, UDP_PORT) )
            
        if fingers.count(1) == 5:
            sock.sendto(("Right").encode(), (UDP_IP, UDP_PORT))
            


    cv2.imshow("Image", img)
    if cv2.waitKey(1) == ord(' '):
        break

