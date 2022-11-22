using System;


namespace Unit05.Game.Casting
{

    /// <summary>
    /// <para>The score of player Two.</para>
    /// <para>
    /// The responsibility of TwoScore is to keep track of Player two's score.
    /// </para>
    /// </summary>
    public class ScoreTwo : Actor
    {
        private int _points = 0;

        /// <summary>
        /// Constructs a new instance of an TwoScore.
        /// </summary>
        public ScoreTwo()
        {
            AddPointsTwo(0);
        }

        /// <summary>
        /// Adds the given points to the score.
        /// </summary>
        /// <param name="points">The points to add.</param>
        public void AddPointsTwo(int points)
        {
            this._points += points;
            SetText($"Player Two: {this._points}");
        }
    }
}