﻿using System;

namespace Mathos.Geometry.Shapes
{
    /// <summary>
    /// Right circular cone shape
    /// </summary>
    public class RightCircularCone : IShape3D
    {
        private readonly Circle _circleBase;
        private double _height;

        /// <summary>
        /// Default constructor
        /// </summary>
        public RightCircularCone() : this(new Circle(), 0)
        {
        }

        /// <summary>
        /// Constructor with a Circle, "circleBase", and a double, "height", to base this cone off of
        /// </summary>
        /// <param name="circleBase"></param>
        /// <param name="height"></param>
        public RightCircularCone(Circle circleBase, double height)
        {
            _circleBase = circleBase;
            _height = height < 0 ? 0 : height;
        }

        /// <summary>
        /// Constructor with two doubles, "radius" and "height", to base this cone off of
        /// </summary>
        /// <param name="radius"></param>
        /// <param name="height"></param>
        public RightCircularCone(double radius, double height)
        {
            _circleBase = new Circle(radius);
            _height = height < 0 ? 0 : height;
        }

        /// <summary>
        /// Gets or sets the radius of the right circular cone
        /// </summary>
        public double Radius
        {
            get { return _circleBase.Radius; }
            set { _circleBase.Radius = value; }
        }

        /// <summary>
        /// Gets or sets the Diameter of the right circular cone
        /// </summary>
        public double Diameter
        {
            get { return _circleBase.Diameter; }
            set { _circleBase.Diameter = value; }
        }

        /// <summary>
        /// Gets or sets the height of the right circular cone
        /// </summary>
        public double Height
        {
            get { return _height; }
            set { _height = value < 0 ? 0 : value; }
        }

        /// <summary>
        /// Gets the area of the right circular cone
        /// </summary>
        public double Volume
        {
            get { return _circleBase.Area * _height / 3; }
        }

        /// <summary>
        /// Gets the surface area of the right circular cone
        /// </summary>
        public double SurfaceArea
        {
            get { return _circleBase.Area + _circleBase.Circumference * Pythagorean.FindHypotenuse(_circleBase.Radius, _height) / 2; }
        }

        #region Override Equals

        /// <summary>
        /// Checks whether the cone is equal to the given object.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            var other = obj as RightCircularCone;

            return other != null && (_circleBase == other._circleBase && Math.Abs(_height - other._height) < 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public bool Equals(RightCircularCone other)
        {
            return other != null && (_circleBase == other._circleBase && Math.Abs(_height - other._height) < 1);
        }

        /// <summary>
        /// Gets the hashcode of the cone.
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return _circleBase.GetHashCode() ^ _height.GetHashCode();
        }

        /// <summary>
        /// The equalto operator
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator ==(RightCircularCone a, RightCircularCone b)
        {
            // If both are null, or both are same instance, return true.
            // If one is null, but not both, return false.
            return ReferenceEquals(a, b) || ((object) a != null) && ((object) b != null) &&
                   (a._circleBase == b._circleBase && Math.Abs(a._height - b._height) < 1);
        }

        /// <summary>
        /// The not-equalto operator
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static bool operator !=(RightCircularCone a, RightCircularCone b)
        {
            return ((a != null && b != null) && a._circleBase != b._circleBase) || ((a != null && b != null) && Math.Abs(a._height - b._height) > 0);
        }

        #endregion
    }
}
