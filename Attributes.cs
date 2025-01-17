namespace AquaAvgFramework
{
    internal class Attributes
    {
        /// <summary>
        /// Indicate that the object can be animated
        /// </summary>
        /// <param name="isBlockingElement">The object blocking execution</param>
        [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
        internal sealed class ApplyAnimationAttribute(bool isBlockingElement) : Attribute
        {
            internal bool IsBlockingElement {  get; private set; } = isBlockingElement;
        }

        /// <summary>
        /// Indicate that the object is blocked for execution
        /// </summary>
        [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
        internal sealed class BlockExecutionAttribute : Attribute;

        /// <summary>
        /// Indicate that the object is restricted from type execution
        /// </summary>
        [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
        internal sealed class LimitExecutionAttribute : Attribute;
    }
}
