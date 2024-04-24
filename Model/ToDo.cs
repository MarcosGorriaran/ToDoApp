using System.Collections.Immutable;
using System.Runtime.CompilerServices;

namespace ToDoApp.Model
{
	public class ToDo
	{
		const bool DefCompleted = false;
		const int DescCharLimit = 25,
		DefPriority = 2;
		const string LowPriority = "Baja",
		MediumPriority = "Normal",
		HighPriority = "Alta",
		ErrorCharLimit = "El texto no puede superar el limite de 25 caracteres";
		private readonly IEnumerable<string> prioritiesNames = new string[]
		{
			LowPriority, MediumPriority, HighPriority
		};
		private DateTime creationDate;
		private string description;
		private int priority;
		private bool completed;

		public DateTime CreationDate {
			get { return creationDate; }
		}
		public string Description
		{
			get { return description; }
			set 
			{
				if (value.Length > DescCharLimit) throw new Exception(ErrorCharLimit);
				description = value;
			}
		}
		public int Priority
		{
			get { return priority; }
			set 
			{
				_ = prioritiesNames.ToImmutableArray()[value];
				priority = value;
			}
		}
		public bool Completed
		{
			get { return completed; }
			set { completed = value; }
		}
		public string GetNamePriority()
		{
			return prioritiesNames.ToImmutableArray()[Priority-1];
		}

		public ToDo(string description, DateTime creationDate, int priority, bool completed)
		{
			this.creationDate = creationDate;
			this.description = description;
			this.priority = priority;
			this.completed = completed;
		}
		public ToDo(string description, DateTime creationDate, int priority):this(description, creationDate, priority, DefCompleted) { }
		public ToDo(string description, DateTime creationDate) : this(description, creationDate, DefPriority) { }
		public ToDo(string description) : this(description,DateTime.Now) { }
		public ToDo() : this(string.Empty) { }
	}
}
