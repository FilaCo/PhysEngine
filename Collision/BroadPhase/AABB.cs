﻿namespace PhysEngine.Collision.BroadPhase
{
    /// <summary>
    /// Структура, представляющая собой прямоугольник, выровненный по осям координат (Axis-Aligned Bounding Box)
    /// </summary>
    public struct AABB
    {
        private Vector _leftUpper;
        private Vector _rightLower;

        public float Width => RightLower.X - LeftUpper.X;

        public float Height => RightLower.Y - LeftUpper.Y;

        public Vector LeftUpper
        {
            get => _leftUpper;
            set
            {
                var tmpWidth = Width;
                var tmpHeight = Height;
                _leftUpper = value;
                _rightLower.Set(LeftUpper.X + Width, LeftUpper.Y + Height);
            }
        }

        public Vector RightLower => _rightLower;

        public Vector Center => 0.5f * (_leftUpper + _rightLower);

        public AABB(float x, float y, float width, float height)
        {
            _leftUpper = new Vector(x, y);
            _rightLower = new Vector(x + width, y + height);
        }

        public AABB(Vector leftUpper, Vector rightLower)
        {
            _leftUpper = leftUpper;
            _rightLower = rightLower;
        }

        public static bool AreCollided(AABB a, AABB b)
        {
            if (a.RightLower.X < b.LeftUpper.X || a.LeftUpper.X > b.RightLower.X)            
                return false;
            
            if (a.RightLower.Y < b.LeftUpper.Y || b.LeftUpper.Y > b.RightLower.Y)
                return false;            

            return true;
        }
    }
}
