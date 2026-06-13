// <copyright file="Circle.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

using System;
using Microsoft.Xna.Framework;

namespace MonoGameLibrary.Models;

public readonly struct Circle : IEquatable<Circle>
{
    private static readonly Circle EmptyValue = default(Circle);

    /// <summary>
    /// The x-coordinate of the center of this circle.
    /// </summary>
    public readonly int X;

    /// <summary>
    /// The y-coordinate of the center of this circle.
    /// </summary>
    public readonly int Y;

    /// <summary>
    /// The length, in pixels, from the center of this circle to the edge.
    /// </summary>
    public readonly int Radius;

    /// <summary>
    /// Gets the location of the center of this circle.
    /// </summary>
    public readonly Point Location => new Point(this.X, this.Y);

    /// <summary>
    /// Gets a circle with X=0, Y=0, and Radius=0.
    /// </summary>
    public static Circle Empty => EmptyValue;

    /// <summary>
    /// Gets a value indicating whether gets a value that indicates whether this circle has a radius of 0 and a location of (0, 0).
    /// </summary>
    public readonly bool IsEmpty => this.X == 0 && this.Y == 0 && this.Radius == 0;

    /// <summary>
    /// Gets the y-coordinate of the highest point on this circle.
    /// </summary>
    public readonly int Top => this.Y - this.Radius;

    /// <summary>
    /// Gets the y-coordinate of the lowest point on this circle.
    /// </summary>
    public readonly int Bottom => this.Y + this.Radius;

    /// <summary>
    /// Gets the x-coordinate of the leftmost point on this circle.
    /// </summary>
    public readonly int Left => this.X - this.Radius;

    /// <summary>
    /// Gets the x-coordinate of the rightmost point on this circle.
    /// </summary>
    public readonly int Right => this.X + this.Radius;

    /// <summary>
    /// Initializes a new instance of the <see cref="Circle"/> struct.
    /// Creates a new circle with the specified position and radius.
    /// </summary>
    /// <param name="x">The x-coordinate of the center of the circle.</param>
    /// <param name="y">The y-coordinate of the center of the circle..</param>
    /// <param name="radius">The length from the center of the circle to an edge.</param>
    public Circle(int x, int y, int radius)
    {
        this.X = x;
        this.Y = y;
        this.Radius = radius;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Circle"/> struct.
    /// Creates a new circle with the specified position and radius.
    /// </summary>
    /// <param name="location">The center of the circle.</param>
    /// <param name="radius">The length from the center of the circle to an edge.</param>
    public Circle(Point location, int radius)
    {
        this.X = location.X;
        this.Y = location.Y;
        this.Radius = radius;
    }

    /// <summary>
    /// Returns a value that indicates whether the specified circle intersects with this circle.
    /// </summary>
    /// <param name="other">The other circle to check.</param>
    /// <returns>true if the other circle intersects with this circle; otherwise, false.</returns>
    public bool Intersects(Circle other)
    {
        int radiiSquared = (this.Radius + other.Radius) * (this.Radius + other.Radius);
        float distanceSquared = Vector2.DistanceSquared(this.Location.ToVector2(), other.Location.ToVector2());
        return distanceSquared < radiiSquared;
    }

    /// <summary>
    /// Returns a value that indicates whether this circle and the specified object are equal.
    /// </summary>
    /// <param name="obj">The object to compare with this circle.</param>
    /// <returns>true if this circle and the specified object are equal; otherwise, false.</returns>
    public override readonly bool Equals(object obj) => obj is Circle other && this.Equals(other);

    /// <summary>
    /// Returns a value that indicates whether this circle and the specified circle are equal.
    /// </summary>
    /// <param name="other">The circle to compare with this circle.</param>
    /// <returns>true if this circle and the specified circle are equal; otherwise, false.</returns>
    public readonly bool Equals(Circle other) => this.X == other.X &&
                                                    this.Y == other.Y &&
                                                    this.Radius == other.Radius;

    /// <summary>
    /// Returns the hash code for this circle.
    /// </summary>
    /// <returns>The hash code for this circle as a 32-bit signed integer.</returns>
    public override readonly int GetHashCode() => HashCode.Combine(this.X, this.Y, this.Radius);

    /// <summary>
    /// Returns a value that indicates if the circle on the left hand side of the equality operator is equal to the
    /// circle on the right hand side of the equality operator.
    /// </summary>
    /// <param name="lhs">The circle on the left hand side of the equality operator.</param>
    /// <param name="rhs">The circle on the right hand side of the equality operator.</param>
    /// <returns>true if the two circles are equal; otherwise, false.</returns>
    public static bool operator ==(Circle lhs, Circle rhs) => lhs.Equals(rhs);

    /// <summary>
    /// Returns a value that indicates if the circle on the left hand side of the inequality operator is not equal to the
    /// circle on the right hand side of the inequality operator.
    /// </summary>
    /// <param name="lhs">The circle on the left hand side of the inequality operator.</param>
    /// <param name="rhs">The circle on the right hand side fo the inequality operator.</param>
    /// <returns>true if the two circle are not equal; otherwise, false.</returns>
    public static bool operator !=(Circle lhs, Circle rhs) => !lhs.Equals(rhs);
}