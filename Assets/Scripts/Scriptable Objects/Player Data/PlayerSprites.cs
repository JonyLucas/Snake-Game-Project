using UnityEngine;

namespace Game.ScriptableObjects
{
    /// <summary>
    /// This Class centralizes the player's snake sprites, so if you want to change the sprites of the object, you can just put another Scriptable Object instance,
    /// instead of setting each sprite individualy, or making different instance of the same object.
    /// </summary>
    ///
    [CreateAssetMenu(fileName = "Player Sprites", menuName = "Player Sprites", order = 53)]
    public class PlayerSprites : ScriptableObject
    {
        // Snake's head Sprites

        public Sprite headUpwardSprite;
        public Sprite headDownwardSprite;
        public Sprite headBackwardSprite;
        public Sprite headForwardSprite;

        // Snake's body Sprites

        public Sprite turnBodyFirstQuadrantSprite;
        public Sprite turnBodySecondQuadrantSprite;
        public Sprite turnBodyThirdQuadrantSprite;
        public Sprite turnBodyFourthQuadrantSprite;
        public Sprite bodyVerticalSprite;
        public Sprite bodyHorizontalSprite;

        // Snake's Tail Sprites

        public Sprite tailUpwardSprite;
        public Sprite tailDownwardSprite;
        public Sprite tailBackwardSprite;
        public Sprite tailForwardSprite;
    }
}