using System;

namespace _4._2
{
    /// <summary>
    /// List on the nodes with unique values
    /// </summary>
    public class UniqueList : List
    {
        /// <summary>
        /// Add the element into the list if it's not contained there
        /// </summary>
        /// <param name="value">Value to add</param>
        /// <param name="position">Position on which the element must be added</param>
        public override void Push(string value, int position)
        {
            if (IsContainedByValue(value))
            {
                throw new AddExistingException($"Element {value} already exists in the list");
            }
            base.Push(value, position);
        }

        /// <summary>
        /// Deletes the element from the list if it exists
        /// </summary>
        /// <param name="position">Position by which deletion completes</param>
        public override void Delete(int position)
        {
            if (!IsContainedByPosition(position))
            {
                throw new DeleteUnexistingException($"Element with position {position} doesn't exist in the list");
            }
            base.Delete(position);
        }
    }
}

/* Унаследовавшись от класса список, реализовать класс UniqueList, который не содержит повторяющихся значений. 
Реализовать классы исключений, которые генерируются при попытке добавления в такой список уже существующего 
или при попытке удаления несуществующего элемента. */
