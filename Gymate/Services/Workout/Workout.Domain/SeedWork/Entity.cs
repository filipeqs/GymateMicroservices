﻿namespace Workouts.Domain.SeedWork;

public abstract class Entity
{
    private int _id;
    public int Id
    {
        get
        {
            return _id;
        }
        protected set
        {
            _id = value;
        }
    }
}
