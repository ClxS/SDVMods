namespace LibAffectiveFluids.ECS
{
    using System;
    using System.CodeDom;
    using System.Collections.Generic;
    using System.Linq;
    using StardewModdingAPI;

    public class Entity
    {
        public Entity(object target)
        {
            this.Target = target;
            this.TypedComponents = new Dictionary<Type, List<object>>();
        }

        private void Ensure<T1>()
        {
            if (this.TypedComponents.ContainsKey(typeof(T1)))
            {
                return;
            }

            this.TypedComponents[typeof(T1)] = new List<object>();
        }

        public void AddComponent<T1>(T1 component)
        {
            Ensure<T1>();
            TypedComponents[typeof(T1)].Add(component);
        }

        public void AddComponent<T1, T2>(T1 component)
        {
            Ensure<T1>();
            Ensure<T2>();
            TypedComponents[typeof(T1)].Add(component);
            TypedComponents[typeof(T2)].Add(component);
        }

        public void AddComponent<T1, T2, T3>(T1 component)
        {
            Ensure<T1>();
            Ensure<T2>();
            Ensure<T3>();
            TypedComponents[typeof(T1)].Add(component);
            TypedComponents[typeof(T2)].Add(component);
            TypedComponents[typeof(T3)].Add(component);
        }

        public void AddComponent<T1, T2, T3, T4>(T1 component)
        {
            Ensure<T1>();
            Ensure<T2>();
            Ensure<T3>();
            Ensure<T4>();
            TypedComponents[typeof(T1)].Add(component);
            TypedComponents[typeof(T2)].Add(component);
            TypedComponents[typeof(T3)].Add(component);
            TypedComponents[typeof(T4)].Add(component);
        }

        public void AddComponent<T1, T2, T3, T4, T5>(T1 component)
        {
            Ensure<T1>();
            Ensure<T2>();
            Ensure<T3>();
            Ensure<T4>();
            Ensure<T5>();
            TypedComponents[typeof(T1)].Add(component);
            TypedComponents[typeof(T2)].Add(component);
            TypedComponents[typeof(T3)].Add(component);
            TypedComponents[typeof(T4)].Add(component);
            TypedComponents[typeof(T5)].Add(component);
        }

        public void RemoveComponent(object component)
        {
            foreach (var type in this.TypedComponents)
            {
                type.Value.Remove(component);
            }
        }

        public IEnumerable<TComponent> GetComponents<TComponent>()
        {
            return !this.TypedComponents.ContainsKey(typeof(TComponent))
                ? Enumerable.Empty<TComponent>()
                : this.TypedComponents[typeof(TComponent)].Cast<TComponent>();
        }

        public object Target { get; }

        public Dictionary<Type, List<object>> TypedComponents;
    }

    public struct EntityComponentSet
    {
        public Entity Entity;

        public object[] Components;

        public EntityComponentSet(Entity entity, IEnumerable<object> components)
        {
            this.Entity = entity;
            this.Components = components.Distinct().ToArray();
        }

        public IEnumerable<T1> ComponentsOfType<T1>()
        {
            return this.Components.Where(c => c is T1).Cast<T1>().ToArray();
        }
    }

    internal class EcsManager
    {
        private readonly IModHelper helper;

        private readonly Dictionary<object, Entity> entities;

        private static EcsManager StaticEcsManager;

        public static EcsManager Ensure(IModHelper helper)
        {
            if (StaticEcsManager != null)
            {
                return StaticEcsManager;
            }

            StaticEcsManager = new EcsManager(helper);
            return StaticEcsManager;
        }

        public static EcsManager Get()
        {
            return StaticEcsManager;
        }
        
        public EcsManager(IModHelper helper)
        {
            this.helper = helper;
            this.entities = new Dictionary<object, Entity>();
        }

        public Entity GetOrAddEntity(object target)
        {
            if (!this.entities.ContainsKey(target))
            {
                this.entities[target] = new Entity(target);
            }

            return this.entities[target];
        }

        public Entity GetEntity(object target)
        {
            return !this.entities.ContainsKey(target)
                ? null
                : this.entities[target];
        }

        public void AddComponent<T1>(object target, T1 instance)
        {
            var entity = GetOrAddEntity(target);
            entity.AddComponent(instance);
        }

        public void AddComponent<T1, T2>(object target, T1 instance)
        {
            var entity = GetOrAddEntity(target);
            entity.AddComponent<T1, T2>(instance);
        }

        public void AddComponent<T1, T2, T3>(object target, T1 instance)
        {
            var entity = GetOrAddEntity(target);
            entity.AddComponent<T1, T2, T3>(instance);
        }

        public void AddComponent<T1, T2, T3, T4>(object target, T1 instance)
        {
            var entity = GetOrAddEntity(target);
            entity.AddComponent<T1, T2, T3, T4>(instance);
        }

        public void AddComponent<T1, T2, T3, T4, T5>(object target, T1 instance)
        {
            var entity = GetOrAddEntity(target);
            entity.AddComponent<T1, T2, T3, T4, T5>(instance);
        }

        public void RemoveComponent(object target, object instance)
        {
            var entity = this.GetEntity(target);
            entity?.RemoveComponent(instance);
        }

        public EntityComponentSet[] GetEntitiesWithComponents<T1>()
        {
            return this.entities.Values.Select(e => new EntityComponentSet(e, e.GetComponents<T1>().Cast<object>())).Where(e => e.Components.Any()).ToArray();
        }

        public EntityComponentSet[] GetEntitiesWithComponents<T1, T2>()
        {
            var localEntities = this.entities.Values.Select(e => new EntityComponentSet(e, e.GetComponents<T1>().Cast<object>())).Where(e => e.Components.Any());
            return localEntities.Where(e => e.Entity.GetComponents<T2>().Any()).ToArray();
        }

        public EntityComponentSet[] GetEntitiesWithComponents<T1, T2, T3>()
        {
            var localEntities = this.entities.Values.Select(e => new EntityComponentSet(e, e.GetComponents<T1>().Cast<object>())).Where(e => e.Components.Any());
            localEntities = localEntities.Where(e => e.Entity.GetComponents<T2>().Any());
            return localEntities.Where(e => e.Entity.GetComponents<T3>().Any()).ToArray();
        }

        public EntityComponentSet[] GetEntitiesWithComponents<T1, T2, T3, T4>()
        {
            var localEntities = this.entities.Values.Select(e => new EntityComponentSet(e, e.GetComponents<T1>().Cast<object>())).Where(e => e.Components.Any());
            localEntities = localEntities.Where(e => e.Entity.GetComponents<T2>().Any());
            localEntities = localEntities.Where(e => e.Entity.GetComponents<T3>().Any());
            return localEntities.Where(e => e.Entity.GetComponents<T4>().Any()).ToArray();
        }

        public EntityComponentSet[] GetEntitiesWithComponents<T1, T2, T3, T4, T5>()
        {
            var localEntities = this.entities.Values.Select(e => new EntityComponentSet(e, e.GetComponents<T1>().Cast<object>())).Where(e => e.Components.Any());
            localEntities = localEntities.Where(e => e.Entity.GetComponents<T2>().Any());
            localEntities = localEntities.Where(e => e.Entity.GetComponents<T3>().Any());
            localEntities = localEntities.Where(e => e.Entity.GetComponents<T4>().Any());
            return localEntities.Where(e => e.Entity.GetComponents<T5>().Any()).ToArray();
        }
    }
}