namespace Game.Player.Movement
{
    public class HeadMovement : BaseMovement
    {
        protected override void SetNextBodyBlock()
        {
            _nextBodyBlock = GetFirstSnakeElementByTag("SnakeBodyBlock");
        }
    }
}