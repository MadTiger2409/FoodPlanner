using System;

namespace FoodPlanner.Application.Common.Exceptions
{
	public class EntityNotRemovableException : Exception
	{
		public EntityNotRemovableException(int dependentEntitiesCount) : base(GetProperExcpetionMessage(dependentEntitiesCount)) { }

		private static string GetProperExcpetionMessage(int dependentEntitiesCount)
		{
			if (dependentEntitiesCount == 1)
				return $"Entity can't be deleted because there is 1 entity that rely on it.";

			return $"Entity can't be deleted because there are {dependentEntitiesCount} entities that rely on it.";
		}
	}
}
