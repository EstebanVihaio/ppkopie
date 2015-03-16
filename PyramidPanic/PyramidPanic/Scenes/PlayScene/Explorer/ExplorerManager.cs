using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PyramidPanic
{
    public class ExplorerManager
    {
        // Fields
        private static Level level;

        // Properties
        public static Level Level
        {
            set { level = value; }
        }

        public static bool CollisionDetectExplorerWallsRight()
        {
            int stepX32 = (int)((level.Explorer.Position.X - 16) / 32);
            int stepY32 = (int)((level.Explorer.Position.Y - 16) / 32);

 


            if (level.Block[stepX32 + 1, stepY32].Passable == false)
            {
                if (level.Explorer.CollisionRectangle.Intersects(level.Block[stepX32 + 1, stepY32].CollisionRectangle))
                {
                    //Console.WriteLine(level.Explorer.WalkRight.DestinationRectangle.X.ToString());
                    //Console.WriteLine(stepX32 + 1);
                    //Console.WriteLine(stepY32);
                    return true;
                }
            }
            //Console.WriteLine(stepX32 + 1);
            //Console.WriteLine(stepY32);
            return false;
        }

        public static bool CollisionDetectExplorerWallsDown()
        {
            int stepX32 = (int)((level.Explorer.Position.X - 16) / 32);
            int stepY32 = (int)((level.Explorer.Position.Y - 16) / 32);


            if (level.Block[stepX32, stepY32 + 1].Passable == false)
            {
                if (level.Explorer.CollisionRectangle.Intersects(level.Block[stepX32, stepY32 + 1].CollisionRectangle))
                {
                    //Console.WriteLine(stepX32);
                    //Console.WriteLine(stepY32 + 1);
                    return true;
                }
            }
            //Console.WriteLine(stepX32);
            //Console.WriteLine(stepY32 + 1);
            return false;
        }

        public static bool CollisionDetectExplorerWallsLeft()
        {
            int stepX32 = (int)((level.Explorer.Position.X - 16f) / 32);
            int stepY32 = (int)((level.Explorer.Position.Y - 16f) / 32);

            //Console.WriteLine("level.Block[{0},{1}].Passable == {2}", (stepX32 - 1), stepY32, level.Block[stepX32 - 1, stepY32].Passable);
            //Console.WriteLine("this.explorer.Position = ({0}, {1})", level.Explorer.Position.X, level.Explorer.Position.Y);
            //Console.WriteLine("level.Explorer.CollisionRectangle[x={12}, y={13}, l={1},R={2},T={3},B={4}].\n" +
            //                  "Intersects(\nlevel.Block[stepX32 - 1[={5}], stepY32[={6}].CollisionRectangle[l={7},R={8},T={9},B={10}]) = {11}",
            //                   level.Explorer.State.ToString(),
            //                   level.Explorer.CollisionRectangle.Left,
            //                   level.Explorer.CollisionRectangle.Right,
            //                   level.Explorer.CollisionRectangle.Top,
            //                   level.Explorer.CollisionRectangle.Bottom,
            //                   stepX32 - 1,
            //                   stepY32,
            //                   level.Block[stepX32 - 1, stepY32].CollisionRectangle.Left,
            //                   level.Block[stepX32 - 1, stepY32].CollisionRectangle.Right,
            //                   level.Block[stepX32 - 1, stepY32].CollisionRectangle.Top,
            //                   level.Block[stepX32 - 1, stepY32].CollisionRectangle.Bottom,
            //                   level.Explorer.CollisionRectangle.Intersects(level.Block[stepX32 - 1, stepY32].CollisionRectangle),
            //                   level.Explorer.State.DestinationRectangle.X,
            //                   level.Explorer.State.DestinationRectangle.Y);
            //Console.WriteLine("_______________________________________________");

            if (level.Block[stepX32, stepY32].Passable == false)
            {
                if (level.Explorer.CollisionRectangle.Intersects(level.Block[stepX32, stepY32].CollisionRectangle))
                {
                    //Console.WriteLine("Hallo" + level.Explorer.WalkRight.DestinationRectangle.X.ToString());
                    return true;
                }
            }
            return false;
        }

        public static bool CollisionDetectExplorerWallsUp()
        {
            int stepX32 = (int)((level.Explorer.Position.X - 16f) / 32);
            int stepY32 = (int)((level.Explorer.Position.Y - 16f) / 32);

            if (level.Block[stepX32, stepY32].Passable == false)
            {
                if (level.Explorer.CollisionRectangle.Intersects(level.Block[stepX32, stepY32].CollisionRectangle))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
