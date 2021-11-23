namespace Game.Player.Movement
{
    public class BodyMovement : BaseMovement
    {
        protected override void SetNextBodyBlock()
        {
            var index = transform.GetSiblingIndex();
            if (index == transform.parent.childCount - 1)
            {
                _nextBodyBlock = GetFirstSnakeElementByTag("SnakeTail");
            }
            else
            {
                _nextBodyBlock = transform.parent.GetChild(index + 1)?.gameObject;
            }
        }
    }
}