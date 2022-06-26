using System.Runtime.Serialization;

namespace Ancient.Ecs;
[Serializable]
public class ComponentSetNotExistException : Exception
{
    public ComponentSetNotExistException(string componentName)
        : base(string.Format("EntityManager does not contain a ComponentSet for Component {0}", componentName))
    {
    }

    protected ComponentSetNotExistException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}
