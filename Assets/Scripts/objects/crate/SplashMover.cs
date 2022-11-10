using UnityEngine;



public class SplashMover : GravityUpdater
{
    public override void ChangeGravity(bool isReversed)
    {
        transform.localPosition = new Vector2(0,-transform.localPosition.y);
    }
}