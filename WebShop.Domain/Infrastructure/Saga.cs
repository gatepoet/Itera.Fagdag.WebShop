using System;
using System.Collections.Generic;

namespace Itera.Fagdag.WebShop.Domain.Infrastructure
{
    public abstract class Saga
    {
        private readonly List<Event> _events = new List<Event>();
        protected readonly List<Command> _commands = new List<Command>();

        public abstract Guid Id { get; }
        public int Version { get; internal set; }

        public IEnumerable<Event> GetUncommittedChanges()
        {
            return _events;
        }

        public void MarkChangesAsCommitted()
        {
            _events.Clear();
            _commands.Clear();
        }

        public void LoadsFromHistory(IEnumerable<Event> history)
        {
            foreach (var e in history) Transition(e);
            MarkChangesAsCommitted();
        }

        public void Transition(Event @event)
        {
            this.AsDynamic().Apply(@event);
            _events.Add(@event);
        }

        protected void Send(Command command)
        {
            _commands.Add(command);
        }
    }
}