using MediatR;

namespace WorkflowR.Workflows.Domain.Abstraction
{
	public abstract class Entity
	{
		private List<INotification> _events;
		public IReadOnlyCollection<INotification> Events { get {  return _events.AsReadOnly(); } }

		public void RaiseDomainEvent(INotification eventItem)
		{
            _events = _events ?? new List<INotification>();
			_events.Add(eventItem);
        }

		public void CleanEvents()
		{
			_events.Clear();
		}
	}
}