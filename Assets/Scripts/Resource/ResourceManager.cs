using Entities;

namespace Resource
{
    public class ResourceManager
    {
        public void DespawnResource(Entity entity)
        {
            entity.gameObject.SetActive(false);
        }
    }
}