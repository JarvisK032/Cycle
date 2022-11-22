using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An input action that controls player two's bike.</para>
    /// <para>
    /// The responsibility of ControlActorsAction is to get the direction and move player two's bike.
    /// </para>
    /// </summary>
    public class ControlSnakeTwoAction : Action
    {
        private KeyboardService keyboardService;
        private Point direction = new Point(Constants.CELL_SIZE, 0);

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public ControlSnakeTwoAction(KeyboardService keyboardService)
        {
            this.keyboardService = keyboardService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            // left
            if (keyboardService.IsKeyDown("j"))
            {
                direction = new Point(-Constants.CELL_SIZE, 0);
            }

            // right
            if (keyboardService.IsKeyDown("l"))
            {
                direction = new Point(Constants.CELL_SIZE, 0);
            }

            // up
            if (keyboardService.IsKeyDown("i"))
            {
                direction = new Point(0, -Constants.CELL_SIZE);
            }

            // down
            if (keyboardService.IsKeyDown("k"))
            {
                direction = new Point(0, Constants.CELL_SIZE);
            }

            SnakeTwo snaketwo = (SnakeTwo)cast.GetFirstActor("snaketwo");
            snaketwo.TurnHead(direction);

        }
    }
}