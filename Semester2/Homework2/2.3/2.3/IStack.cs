using System;

namespace _2._3
{
    public interface IStack
    {
        void Push(int value);
        int Pop();
        bool IsEmpty();
        int Length();
    }
}