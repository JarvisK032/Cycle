using System.Collections.Generic;
using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An output action that draws all the actors.</para>
    /// <para>The responsibility of DrawActorsAction is to draw each of the actors.</para>
    /// </summary>
    public class DrawActorsAction : Action
    {
        private VideoService videoService;

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public DrawActorsAction(VideoService videoService)
        {
            this.videoService = videoService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            Snake snake = (Snake)cast.GetFirstActor("snake");
            List<Actor> segments1 = snake.GetSegments();
            SnakeTwo sanketwo = (SnakeTwo)cast.GetFirstActor("snaketwo");
            List<Actor> segments2 = sanketwo.GetSegments();
            Actor score = cast.GetFirstActor("score");
            Actor scroetwo = cast.GetFirstActor("scoretwo");
            scroetwo.SetPosition(new Point(Constants.MAX_X - 100, 0));
            List<Actor> messages = cast.GetActors("messages");

            videoService.ClearBuffer();
            videoService.DrawActors(segments1);
            videoService.DrawActors(segments2);
            videoService.DrawActor(score);
            videoService.DrawActor(scroetwo);
            videoService.DrawActors(messages);
            videoService.FlushBuffer();
        }
    }
}