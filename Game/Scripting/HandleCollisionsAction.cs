using System;
using System.Collections.Generic;
using System.Data;
using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An update action that handles interactions between the actors.</para>
    /// <para>
    /// The responsibility of HandleCollisionsAction is to handle the situation when the bikes' light ribbons grow,
    /// or the bikes collide with each other, or the game is over.
    /// </para>
    /// </summary>
    public class HandleCollisionsAction : Action
    {
        private bool isGameOver = false;
        private bool SnakeOneLoose = false;
        private bool SnakeTwoLoose = false;
        private int counter = 0;
        /// <summary>
        /// Constructs a new instance of HandleCollisionsAction.
        /// </summary>
        public HandleCollisionsAction()
        {
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            if (isGameOver == false)
            {
                HandleGrowth(cast);
                HandleSegmentCollisions(cast);
                HandleGameOver(cast);
            }
        }

        /// <summary>
        /// Updates the score and size of the bikes' light ribbons. 
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleGrowth(Cast cast)
        {
            Snake snake = (Snake)cast.GetFirstActor("snake");
            SnakeTwo snaketwo = (SnakeTwo)cast.GetFirstActor("snaketwo");
            Score score = (Score)cast.GetFirstActor("score");
            ScoreTwo scoretwo = (ScoreTwo)cast.GetFirstActor("scoretwo");
            counter = counter + 1;
            if (counter % 15 == 0)
            {
                snake.GrowTail(1);
                snaketwo.GrowTail(1);
                score.AddPointsOne(1);
                scoretwo.AddPointsTwo(1);
            }

        }

        /// <summary>
        /// Sets the game over flag if the bikes collide.
        /// </summary>
        /// <param name="cast">The cast of actors.</param>
        private void HandleSegmentCollisions(Cast cast)
        {
            Snake snake = (Snake)cast.GetFirstActor("snake");
            Actor head1 = snake.GetHead();
            List<Actor> body1 = snake.GetBody();
            SnakeTwo snaketwo = (SnakeTwo)cast.GetFirstActor("snaketwo");
            Actor head2 = snaketwo.GetHead();
            List<Actor> body2 = snaketwo.GetBody();

            foreach (Actor segment1 in body1)
            {
                foreach (Actor segment2 in body2)
                    if (segment1.GetPosition().Equals(head2.GetPosition()))
                    {
                        isGameOver = true;
                        SnakeTwoLoose = true;
                    }
                    else if (segment2.GetPosition().Equals(head1.GetPosition()))
                    {
                        isGameOver = true;
                        SnakeOneLoose = true;
                    }

                    else if (segment2.GetPosition().Equals(head2.GetPosition()))
                    {
                        isGameOver = true;
                        SnakeTwoLoose = true;
                    }

                if (segment1.GetPosition().Equals(head1.GetPosition()))
                {
                    isGameOver = true;
                    SnakeOneLoose = true;
                }

            }





        }

        private void HandleGameOver(Cast cast)
        {
            if (isGameOver == true)
            {
                Snake snake = (Snake)cast.GetFirstActor("snake");
                List<Actor> segments1 = snake.GetSegments();
                SnakeTwo snaketwo = (SnakeTwo)cast.GetFirstActor("snaketwo");
                List<Actor> segments2 = snaketwo.GetSegments();

                // create a "game over" message
                //int x = Constants.MAX_X / 2;
                //int y = Constants.MAX_Y / 2;
                //Point position = new Point(x, y);

                //Actor message = new Actor();
                //message.SetText("Game Over!");
                //message.SetPosition(position);
                //cast.AddActor("messages", message);

                // decide the color of the game over screen and the losing cycle
                if (SnakeOneLoose == true)
                {
                    foreach (Actor segment in segments1)
                    {

                        int x = Constants.MAX_X / 2;
                        int y = Constants.MAX_Y / 2;
                        Point position = new Point(x, y);

                        Actor message = new Actor();
                        message.SetText("Player Two Wins!");
                        message.SetPosition(position);
                        cast.AddActor("messages", message);

                        segment.SetColor(Constants.WHITE);
                        message.SetColor(Constants.BLUE);
                    }
                }
                if (SnakeTwoLoose == true)
                {
                    foreach (Actor segment in segments2)
                    {

                        int x = Constants.MAX_X / 2;
                        int y = Constants.MAX_Y / 2;
                        Point position = new Point(x, y);

                        Actor message = new Actor();
                        message.SetText("Player One Wins!");
                        message.SetPosition(position);
                        cast.AddActor("messages", message);

                        segment.SetColor(Constants.WHITE);
                        message.SetColor(Constants.RED);
                    }
                }

            }
        }
    }
}