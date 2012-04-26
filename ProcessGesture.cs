using System;
using Microsoft.Kinect;
using AppSpecific;

namespace GestureRecognition
{
    public class ProcessGesture
    {
        bool isBackGestureActive = false;
        bool isForwardGestureActive = false;
        bool isLeftGestureActive = false;
        bool isRightGestureActive = false;
        public void GestureRec(Joint head, Joint rightHand, Joint leftHand, Joint rightElbow)
        {
            if (rightHand.Position.X > head.Position.X + 0.45)
            {
                if (!isBackGestureActive && !isForwardGestureActive && !isLeftGestureActive && !isRightGestureActive)
                {
                    isRightGestureActive = true;
                    DefaultListener.gestureOccurs(RightGesture);
                }
            }
            else
            {
                isRightGestureActive = false;
            }

            if (leftHand.Position.X < head.Position.X - 0.45)
            {
                if (!isBackGestureActive && !isForwardGestureActive && !isLeftGestureActive && !isRightGestureActive)
                {
                    isLeftGestureActive = true;
                    DefaultListener.gestureOccurs(LeftGesture);
                }
            }
            else
            {
                isLeftGestureActive = false;
            }

            if (rightHand.Position.Z > head.Position.Z + 0.45)
            {
                if (!isBackGestureActive && !isForwardGestureActive && !isLeftGestureActive && !isRightGestureActive)
                {
                    isForwardGestureActive = true;
                    DefaultListener.gestureOccurs(UpGesture);
                }
            }
            else
            {
                isForwardGestureActive = false;
            }

            if (rightElbow.Position.Z < head.Position.Z - 0.25)
            {
                if (!isBackGestureActive && !isForwardGestureActive && !isLeftGestureActive && !isRightGestureActive)
                {
                    isBackGestureActive = true;
                    DefaultListener.gestureOccurs(DownGesture);
                }
            }
            else
            {
                isBackGestureActive = false;
            }
        }
    }
}
